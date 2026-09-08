---
title: Prezentációk exportálása XAML-be Pythonon keresztül Java-val
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/python-java/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- PowerPoint XAML-be
- OpenDocument XAML-be
- prezentáció XAML-be
- PPT XAML-be
- PPTX XAML-be
- ODP XAML-be
- PPT mentése XAML-ként
- PPTX mentése XAML-ként
- ODP mentése XAML-ként
- PPT exportálása XAML-be
- PPTX exportálása XAML-be
- ODP exportálása XAML-be
- Python
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása XAML-be az Aspose.Slides for Python via Java segítségével. Alapértelmezett beállítások használata vagy rejtett diák belefoglalása."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan exportálhatók PowerPoint- és OpenDocument-prezentációk XAML formátumba az Aspose.Slides for Python via Java használatával. Bemutatja a XAML-t, megmutatja, hogyan exportáljunk alapértelmezett beállításokkal, és bemutatja, hogyan lehet rejtett diákot is belefoglalni a [XamlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/).

A példákhoz szükség van az Aspose.Slides for Python via Java-ra és egy kompatibilis Java futtatókörnyezetre. Helyezze a `pres.pptx` fájlt az aktuális munkakönyvtárba. Minden példa csak akkor indítja el a JVM-et, ha az még nem fut.

## **A XAML-ról**

A XAML (Extensible Application Markup Language) egy XML-alapú nyelv a felhasználói felületek leírására. Olyan keretrendszerek használják, mint a Windows Presentation Foundation (WPF). A XAML-t létrehozhatja és szerkesztheti egy vizuális tervezővel vagy egy szövegszerkesztővel.

## **Prezentációk exportálása XAML-be alapértelmezett beállításokkal**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot a bemeneti fájlból, majd adja át a [XamlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/) objektumot a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak, hogy alapértelmezett beállításokkal exportáljon:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Prezentációk exportálása XAML-be egyéni beállításokkal**

Használja a [XamlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/) objektumot az export konfigurálásához. A rejtett diák belefoglalásához hívja meg a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódust `True` értékkel a mentés előtt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **GYIK**

**Hogyan választhatok tartalék betűtípust, ha az eredeti betűtípus nem elérhető?**

Használja a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) metódust a [XamlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/) objektumon, hogy megadjon egy tartalék betűtípust. Győződjön meg arról, hogy a választott betűtípus elérhető az export környezetben.

**Használhatom az exportált markupot bármely XAML keretrendszerben?**

A XAML keretrendszerek eltérnek a támogatott elemeik és funkcióik tekintetében. Tesztelje az exportált markupot a célkeretrendszerében, mielőtt alkalmazásba integrálná.

**Alapértelmezés szerint exportálódnak a rejtett diák?**

Nem. A belefoglaláshoz hívja meg a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódust `True` értékkel. Állítsa `False`-ra, ha ki szeretné zárni őket.