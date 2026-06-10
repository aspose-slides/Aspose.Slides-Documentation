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
- Windows
- macOS
- Python
description: "Ismerje meg, hogyan telepítheti gyorsan az Aspose.Slides for Python via .NET-et. Lépésről lépésre útmutató, rendszerkövetelmények és kódminták — kezdje el a PowerPoint‑prezentációk használatát még ma!"
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET csomag minden szükséges .NET könyvtárat tartalmaz, ami azt jelenti, hogy a .NET-et külön nem kell telepíteni. Ez egyszerűsíti a beállítási folyamatot, és lehetővé teszi a fejlesztők számára, hogy azonnal prezentációkkal dolgozhassanak. Fontos azonban megjegyezni, hogy operációs rendszerétől vagy környezetétől függően előfordulhat, hogy a .NET-hez szükséges platformspecifikus függőségeket még mindig telepíteni kell. Továbbá bizonyos rendszerkövetelményeket teljesíteni kell a csomag teljes kompatibilitásának és megfelelő működésének biztosítása érdekében.

## **Windows**

**Rendszerkövetelmények**

Ellenőrizze és erősítse meg, hogy gépe specifikációi megfelelnek vagy meghaladják a [rendszerkövetelmények](/slides/hu/python-net/system-requirements/).

### **Aspose.Slides telepítése**

`pip` a legegyszerűbb módja a [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) letöltésének és telepítésének Windows rendszeren.

Az Aspose.Slides telepítéséhez futtassa a következő parancsot:

```sh
pip install aspose-slides
```

**Aspose.Slides használata**

Tesztelje az Aspose.Slides telepítését a következő kód futtatásával egy PowerPoint‑prezentáció létrehozásához:

```python
# Aspose.Slides for Python via .NET modul importálása.
import aspose.slides as slides

# A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Rendszerkövetelmények**

Ellenőrizze és erősítse meg, hogy gépe specifikációi megfelelnek vagy meghaladják a [rendszerkövetelmények](/slides/hu/python-net/system-requirements/).

### **Előfeltételek**

**Python megosztott könyvtárakkal**

Több mód is létezik a Python macOS‑ra történő telepítésére, de erősen ajánljuk a [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos) használatát.

A **pyenv** telepítése és konfigurálása után telepítse a Python‑t megosztott könyvtárakkal a Terminal alkalmazásban a következő parancsok futtatásával:

1. Python telepítése:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Állítsa be globális Python verzióként:

```sh
pyenv global 3.9.13
```

3. Állítsa be a shell‑specifikus Python verzióként:

```sh
pyenv shell 3.9.13
```

4. Hozzon létre szimbolikus linket a libpython könyvtárhoz egy rendszermappában:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Megjegyzés: Python 3.5 vagy újabb szükséges. A 3.9.13 verzió csak példaként van használva.

**A libgdiplus könyvtár telepítése**

A **libgdiplus** könyvtár egy Windows GDI+ megvalósítás macOS‑ra és Linuxra, amelyre a .NET a grafikai funkciók biztosításához támaszkodik.  
A könyvtár macOS‑on való telepítéséhez futtassa a következő parancsot:

```sh
brew install mono-libgdiplus
```

### **Aspose.Slides telepítése**

`pip` a legegyszerűbb módja a [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) letöltésének és telepítésének macOS rendszeren.

Az Aspose.Slides telepítéséhez futtassa a következő parancsot:

```sh
pip install aspose-slides
```

**Aspose.Slides használata**

Tesztelje az Aspose.Slides telepítését a következő kód futtatásával egy PowerPoint‑prezentáció létrehozásához:

```python
# Aspose.Slides for Python via .NET modul importálása.
import aspose.slides as slides

# A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Telepíthetem az Aspose.Slides‑t virtuális környezetben?**

Igen, bármely Python virtuális környezetben telepítheti a `pip` segítségével. Ügyeljen arra, hogy a környezet hozzáférjen a szükséges natív függőségekhez operációs rendszerétől függően.

**Használhatom az Aspose.Slides‑t Docker konténerekben?**

Igen, de biztosítania kell, hogy a Docker‑képe tartalmazza a szükséges natív könyvtárakat (**libgdiplus**, betűcsomagok stb.) és a megfelelő Python verziót.

**Van ingyenes verzió vagy próbaidő korlátozás?**

Igen, alapértelmezés szerint az Aspose.Slides értékelő módban fut, amely vízjeleket helyez el és egyéb korlátozásokkal is járhat. A korlátozások eltávolításához egy érvényes [licenc](/slides/hu/python-net/licensing/) alkalmazása szükséges.