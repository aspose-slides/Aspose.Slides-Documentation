---
title: VBA makró
type: docs
weight: 150
url: /hu/python-net/examples/elements/vba-macro/
keywords:
- VBA makró
- VBA makró hozzáadása
- VBA makró elérése
- VBA makró eltávolítása
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Dolgozzon VBA makrókkal Pythonban az Aspose.Slides használatával: adjon hozzá vagy szerkesszen projekteket és modulokat, írjon alá vagy távolítson el makrókat, és mentse a bemutatókat PPT, PPTX és ODP formátumban."
---
Bemutatja, hogyan lehet VBA makrókat hozzáadni, elérni és eltávolítani az **Aspose.Slides for Python via .NET** használatával.

## **VBA makró hozzáadása**

Hozzon létre egy prezentációt VBA projekttel és egy egyszerű makrómodullal.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Inicializálja a VBA projektet.
        presentation.vba_project = slides.vba.VbaProject()

        # Üres modult ad hozzá "Module" névvel.
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA makró elérése**

Hozza vissza az első modult a VBA projektből.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **VBA makró eltávolítása**

Töröljön egy modult a VBA projektből.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Feltételezve, hogy a bemutató tartalmaz VBA projektet és legalább egy modult.
        module = presentation.vba_project.modules[0]

        # Távolítsa el a modult a projektből.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```