---
title: VBA projektek kezelése prezentációkban Python használatával
linktitle: Prezentáció VBA-val
type: docs
weight: 250
url: /hu/python-java/presentation-via-vba/
keywords:
- makró
- VBA
- VBA makró
- makró hozzáadása
- makró eltávolítása
- makró kinyerése
- VBA hozzáadása
- VBA eltávolítása
- VBA kinyerése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet VBA-val PowerPoint és OpenDocument prezentációkat létrehozni és módosítani az Aspose.Slides for Python via Java segítségével a munkafolyamat egyszerűsítése érdekében."
---
## **Bevezetés**

Az Aspose.Slides osztályokat és interfészeket biztosít a makrókkal és VBA kóddal való munkához.

{{% alert title="Warning" color="warning" %}} 

Ha egy makrókat tartalmazó bemutatót átalakít más fájlformátumba (PDF, HTML stb.), az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrehozott fájlba).

Ha makrókat ad hozzá egy bemutatóhoz vagy újra ment egy makrókat tartalmazó bemutatót, az Aspose.Slides egyszerűen csak a makrók bájjtárait írja.

Az Aspose.Slides **soha** nem futtatja a bemutatóban lévő makrókat.

{{% /alert %}}

## **VBA makrók hozzáadása**

Az Aspose.Slides a [VbaProject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/vbaproject/) osztályt biztosítja, amely lehetővé teszi VBA projektek (és projekt hivatkozások) létrehozását és meglévő modulok szerkesztését. A [VbaProject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/vbaproject/) osztály segítségével kezelheti a bemutatóba beágyazott VBA-t.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Használja a [VbaProject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/vbaproject/#vbaproject) konstruktorát egy új VBA projekt hozzáadásához.
1. Adjon hozzá egy modult a VBA projekthez.
1. Állítsa be a modul forráskódját.
1. Adjon hozzá hivatkozásokat a `stdole`-hez.
1. Adjon hozzá hivatkozásokat a **Microsoft Office**-hoz.
1. Kapcsolja össze a hivatkozásokat a VBA projekttel.
1. Mentse el a bemutatót.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Új VBA projekt létrehozása.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Üres modul hozzáadása és a forráskód beállítása.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Hivatkozások létrehozása a stdole-ra és a Microsoft Office-ra.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Hivatkozások hozzáadása a VBA projekthez.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Prezentáció mentése.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Érdemes megtekinteni az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) ingyenes webalkalmazást, amelyet a PowerPoint, Excel és Word dokumentumokból származó makrók eltávolítására használnak. 

{{% /alert %}} 

## **VBA makrók eltávolítása**

A [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztály [getVbaProject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getvbaproject) metódusának használatával eltávolíthat egy VBA makrót.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a makrót tartalmazó bemutatót.
1. Hozzáfér a makró modulhoz, és eltávolítja azt.
1. Mentse el a módosított bemutatót.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Töltse be a makrót tartalmazó prezentációt.
presentation = Presentation("VBA.pptm")
try:
    # Hozzáfér a VBA modulhoz és eltávolítja.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Prezentáció mentése.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **VBA makrók kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a makrót tartalmazó bemutatót.
2. Ellenőrizze, hogy a bemutató tartalmaz-e VBA projektet.
3. Iteráljon végig a VBA projektben lévő összes modulon a makrók megtekintéséhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Töltse be a makrót tartalmazó prezentációt.
presentation = Presentation("VBA.pptm")
try:
    # Ellenőrizze, hogy a prezentáció tartalmaz-e VBA projektet.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Ellenőrizze, hogy a VBA projekt jelszóvédett-e**

A [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/hu/python-java/aspose.slides/vbaproject/#ispasswordprotected) metódus használatával meghatározhatja, hogy egy projekt tulajdonságai jelszóvédettek-e.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a makrót tartalmazó bemutatót.
2. Ellenőrizze, hogy a bemutató tartalmaz-e [VBA projektet](https://reference.aspose.com/slides/hu/python-java/aspose.slides/vbaproject/).
3. Ellenőrizze, hogy a VBA projekt jelszóvédett-e a tulajdonságai megtekintéséhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Ellenőrizze, hogy a prezentáció tartalmaz-e VBA projektet.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**Mi történik a makrókkal, ha PPTX formátumban mentem a bemutatót?**

A makrók eltávolításra kerülnek, mivel a PPTX nem támogatja a VBA-t. A makrók megtartásához válassza a PPTM, PPSM vagy POTM formátumot.

**Futtathatja az Aspose.Slides makrókat a bemutatóban például adatok frissítéséhez?**

Nem. A könyvtár soha nem hajtja végre a VBA kódot; a végrehajtás csak a megfelelő biztonsági beállításokkal rendelkező PowerPoint-ban lehetséges.

**Támogatott az ActiveX vezérlőkkel való munka, amelyek VBA kódhoz vannak kapcsolva?**

Igen, hozzáférhet a meglévő [ActiveX controls](/slides/hu/python-java/activex/) elemekhez, módosíthatja azok tulajdonságait, és eltávolíthatja őket. Ez hasznos, amikor a makrók az ActiveX-szel kommunikálnak.