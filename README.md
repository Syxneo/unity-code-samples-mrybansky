# Unity Code Samples – Martin Rybanský

Tento repozitár obsahuje výber mojich najzaujímavejších skriptov z dvoch študentských herných projektov vytvorených v Unity pomocou C#. Skripty demonštrujú prácu s hernou logikou, fyzikou, animáciami, používateľským rozhraním a systémami v hrách.

---

## DodgeZone (mobilná hypercasual hra)

### PlayerGravityMovement.cs
Logika pohybu hráča na planéte s vlastnou gravitáciou. Spracúva joystick input, pohyb po zakrivenom povrchu, animácie a rotáciu podľa povrchu (Raycast + Quaternion).

### FauxGravityAttractor.cs
Simulácia gravitácie smerom k stredu objektu. Pracuje s rotáciou postavy a jej zarovnaním k povrchu.

### MainMenuScript.cs
UI logika pre hlavné menu – prepínanie medzi sekciami (leaderboard, avatar, questy...), používa `DOTween` pre animácie `CanvasGroup`, `Image` a `RectTransform`.

### LeaderboardAnim.cs
Zobrazovanie leaderboardu s víťazmi pomocou sekvenčných fade-in animácií. Pracuje s výberom dát z leaderboardu a ich prezentáciou cez UI.

---

## Vermin Venture (2D pixelartová platformovka)

### MovementPlayer.cs
Komplexný skript pre 2D pohyb postavy – chôdza, skákanie, lezenie po stenách, otáčanie podľa smeru pohybu. Využíva `Rigidbody2D`, `Animator`, `Input` a detekciu kontaktu s podložkou/stĺpom.

### HealthSystem.cs
Zdravotný systém hráča – pokles života, spustenie animácie smrti, deaktivácia pohybu a zobrazenie koncového screen. Obsahuje prácu s `Animator`, `CanvasGroup`, `DOTween`.

### AnimateTxt.cs
Efekt "písacieho stroja" pre texty počas prechodov medzi scénami. Pracuje s `TextMeshPro`, `DOText`, fade a načasovaním cez `Coroutine`.

---

## 🔧 Použité technológie a techniky
- Unity API: `Rigidbody`, `Transform`, `Input`, `Animator`, `Collider`, `SceneManager`, `CanvasGroup`
- DOTween: `DOFade`, `DOScale`, `DOAnchorPos`, `DOText`
- UI: `TextMeshPro`, `Image`, `RectTransform`
- Fyzika: gravitácia, pohyb po zakrivenom povrchu, Raycast
- OOP: oddelenie zodpovednosti, single-responsibility princípy

---

V prípade záujmu viem poskytnúť aj širšiu ukážku kódu alebo celý projekt.
