---
title: Telepítés
type: docs
weight: 70
url: /hu/python-net/installation/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- Aspose.Slides használata
- Aspose.Slides telepítése
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Telepítse az Aspose.Slides for Python via .NET csomagot a PyPI-ról pip segítségével Windows, Linux és macOS rendszeren, és telepítse a Linux és macOS által igényelt natív könyvtárakat."
---
## **Áttekintés**

Ez a cikk leírja, hogyan telepíthető az Aspose.Slides for Python via .NET Windows, Linux és macOS operációs rendszerekre. A csomag a [PyPI](https://pypi.org/project/aspose.slides/) oldalon érhető el, és a pip segítségével telepíthető. Tartalmazza a használt .NET futtatókörnyezetet, így nem szükséges a .NET-et külön telepíteni. Linuxon és macOS-en a futtatókörnyezethez natív könyvtárakra van szükség, amelyeket a rendszer esetleg nem biztosít; az alábbi szakaszok megnevezik ezeket.

Az Aspose.Slides for Python via .NET a Python 3.5‑től 3.14‑ig terjedő verzióit támogatja. A PyPI Windowsra (32‑bit és 64‑bit), Linuxra (x86_64 és ARM64) és macOS‑re (Intel és Apple szilícium) kínál csomagokat.

## **Windows**

Windowson a csomagot a pip‑el telepítheti. Egyéb könyvtárak nem szükségesek.

```bash
pip install aspose.slides
```

## **Linux**

Linuxon a csomagban szereplő .NET futtatókörnyezetnek két könyvtárra van szüksége:

- **libgdiplus**, a Windows GDI+ grafikus API megvalósítása. Nélküle a prezentáció mentése a `The type initializer for 'Gdip' threw an exception` hibával kudarcot vall.
- **ICU** (International Components for Unicode). Nélküle a Python folyamat az első Aspose.Slides hívásnál leáll a `Couldn't find a valid ICU package installed on the system` üzenettel.

Debianon és Ubuntu-n mindkettőt az apt‑vel telepítheti:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Az ICU csomag neve tartalmazza a verziót: a `libicu76` a Debian 13‑hoz tartozó csomag. Debian 12‑n a `libicu72`‑t kell telepíteni, Ubuntu 24.04‑n pedig a `libicu74`‑et. A rendszerén lévő név megállapításához futtassa:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Ezután telepítse a csomagot egy virtuális környezetbe. A jelenlegi Debian és Ubuntu kiadásokban a rendszerszintű Python nem engedélyezi a `pip install` végrehajtását virtuális környezet nélkül, és a `externally-managed-environment` hibával áll le.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

A szkriptjeit ugyanabban a aktivált virtuális környezetben futtassa. Ha olyan Python‑t használ, amelyet a disztribúciója nem kezel, például a hivatalos `python` Docker‑képekben lévőt, akkor a `pip install aspose.slides` parancsot virtuális környezet nélkül is futtathatja.

A prezentációkban használt betűtípusoknak, vagy megfelelő helyettesítőknek a rendszerre telepítve kell lenniük, hogy a szöveg PDF‑re vagy képekre konvertálásakor helyesen jelenjen meg.

## **macOS**

A macOS‑on történő telepítést még nem ellenőriztük. macOS‑en az Aspose.Slides a következő előfeltételeket igényli:

- **Python megosztott könyvtárakkal**, vagyis olyan Python, amely a `--enable-shared` konfigurációs opcióval lett felépítve. Ha a Python‑t a [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos)‑vel telepíti, állítsa a `PYTHON_CONFIGURE_OPTS` környezeti változót `--enable-shared`‑re a Python verzió telepítésekor.
- **A libpython könyvtár a rendszerkönyvtárban**. A pyenv‑vel telepített Python a libpython könyvtárát, például a *libpython3.9.dylib*-t, a *~/.pyenv/versions* könyvtárban tartja; hozzon létre egy szimbolikus linket rá a */usr/local/lib* könyvtárban.
- **libgdiplus**, a Windows GDI+ grafikus API megvalósítása. A Homebrew a `mono-libgdiplus` csomagként biztosítja.

Ezután a csomagot a pip‑el telepítse.

## **A telepítés ellenőrzése**

A telepítés ellenőrzéséhez mentse el az első példát a [Create Presentations](/slides/hu/python-net/create-presentation/) oldalról *hello.py* néven, és futtassa a `python hello.py` parancsot. A parancs a *new_presentation.pptx*-t a jelenlegi mappába menti.

## **Frissítés**

A meglévő telepítés legújabb verzióra történő frissítéséhez futtassa ezt a parancsot abban a környezetben, ahol a csomagot telepítette:

```bash
pip install --upgrade aspose.slides
```

## **GYIK**

**Telepíthetek Aspose.Slides‑t virtuális környezetben?**

Igen. Bármely Python virtuális környezetben a pip‑el telepítheti. A Linuxnak és a macOS‑nek szükséges natív könyvtárak a rendszerre vannak telepítve, nem a virtuális környezetbe.

**Használhatom az Aspose.Slides‑t Docker konténerekben?**

Igen. A képfájlnak tartalmaznia kell ugyanazokat a natív könyvtárakat, mint egy Linux rendszer – a libgdiplus‑t és az ICU‑t –, valamint a prezentációkban használt betűtípusokat.

**Van ingyenes verzió vagy próbaverzió korlátozással?**

Igen. Licenc nélkül az Aspose.Slides értékelési módban működik: minden mentett diára egy értékelési vízjelet helyez, és a prezentációkból beolvasott szöveget csonkolja. E korlátozások eltávolításához alkalmazzon egy érvényes [license](/slides/hu/python-net/licensing/) licencet.