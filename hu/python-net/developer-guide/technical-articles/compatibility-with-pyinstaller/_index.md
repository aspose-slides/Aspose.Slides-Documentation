---
title: Kompatibilitás a PyInstaller és a cx_Freeze használatával
linktitle: Kompatibilitás a PyInstallerrel
type: docs
weight: 122
url: /hu/python-net/compatibility-with-pyinstaller/
keywords:
- kompatibilitás
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Csomagolja az Aspose.Slides for Python via .NET-et a PyInstallerrel. Kövesse ezt az útmutatót a program csomagolásához, konfigurálásához és a felmerülő problémák elhárításához, hogy önálló futtatható állományt hozzon létre."
---
## **Bevezetés**

Aspose.Slides for Python via .NET kiterjesztések szabványos Python C kiterjesztések, így fagyaszthatók programfüggőségekként olyan eszközökkel, mint a PyInstaller és a cx_Freeze (vagy hasonló). Ez lehetővé teszi, hogy futtatható fájlokat hozz létre Python szkriptedből. Az ilyen eszközöket “freezer”-nek hívják, mert a kódot és függőségeit egyetlen terjeszthető fájlba csomagolják, amely más gépeken is futtatható Python telepítés vagy további könyvtárak nélkül. Ez az megközelítés egyszerűsíti a Python alkalmazások terjesztését.

Az Aspose.Slides for Python via .NET kiterjesztés függőségként történő fagyasztását az alábbi egyszerű program mutatja be, amely az Aspose.Slides‑t használja.

## **PyInstaller**

Általában nincs szükség különleges lépésekre, amikor egy Aspose.Slides for Python via .NET kiterjesztéstől függő programot csomagolunk. Ha a program úgy importálja a kiterjesztést, ahogyan a PyInstaller láthatja, a kiterjesztés a programmal együtt lesz becsomagolva. Mivel az Aspose.Slides for Python via .NET tartalmaz PyInstaller hook‑okat, függőségei automatikusan fel vannak ismerve és a csomagba másolva.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Azonban a PyInstaller időnként elmulaszthat rejtett importokat – olyan modulokat, amelyeket a kód dinamikusan vagy közvetve importál. A rejtett importok felvételéhez használd a PyInstaller opcióit. A kiterjesztés függőségei a Aspose.Slides for Python via .NET-et szállító PyInstaller hook‑okban vannak megadva.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

A cx_Freeze használatával történő programfagyasztáshoz konfiguráld úgy, hogy tartalmazza a használt Aspose.Slides for Python via .NET kiterjesztés gyökércsomagját. Ez biztosítja, hogy a kiterjesztés és minden függő modul a buildbe, az alkalmazásod mellé kerüljenek.

### **A cxfreeze szkript használata**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **A setup szkript használata**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **GYIK**

**Szükséges-e a Microsoft PowerPoint vagy a .NET a felhasználó gépén?**

Nem, a PowerPoint nem szükséges. Az Aspose.Slides egy önálló motor; a Python csomag mindent tartalmaz, ami a CPython számára kiterjesztésként kell. A felhasználónak nem kell külön telepítenie a .NET‑et.

**Hogyan csatoljam helyesen a licencet egy fagyasztott alkalmazáshoz?**

A licenc XML‑t elhelyezheted a futtatható fájl mellett, vagy beágyazhatod erőforrásként, majd betöltheted egy elérhető útvonalról az első API hívás előtt. Fontos: ne módosítsd az XML tartalmát (még a sortöréseket sem).

**Mit tegyek, ha a betűtípusok másként jelennek meg a build után, mint fejlesztés közben?**

Győződj meg arról, hogy a használt betűtípusok elérhetők a célkörnyezetben (csomagolt vagy rendszerben telepített) és hogy azok útvonalai helyesen kerülnek feloldásra futásidőben; a betűtípusok viselkedése különösen érzékeny Linuxon.