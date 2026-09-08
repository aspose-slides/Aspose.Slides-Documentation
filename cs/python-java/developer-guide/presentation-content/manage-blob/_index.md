---
title: Správa BLOB prezentací v Pythonu přes Java pro efektivní využití paměti
linktitle: Spravovat BLOB
type: docs
weight: 10
url: /cs/python-java/manage-blob/
keywords:
- velký objekt
- velká položka
- velký soubor
- přidat BLOB
- exportovat BLOB
- přidat obrázek jako BLOB
- snížit paměť
- spotřeba paměti
- velká prezentace
- dočasný soubor
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Spravujte BLOB data v Aspose.Slides pro Python přes Java, abyste zefektivnili operace se soubory PowerPoint a OpenDocument a dosáhli efektivního zpracování prezentací."
---
## **Přehled**

Aspose.Slides poskytuje zpracování založené na BLOB pro velká binární data v prezentacích, což pomáhá snížit spotřebu paměti při práci s velkými obrázky, zvukem, videem a soubory prezentací.

Tento článek ukazuje, jak použít zpracování založené na BLOB k přidání velkých multimédií do prezentace, exportu velkých multimédií z prezentace a efektivnějšímu načtení velkých prezentací. Také vysvětluje, jak lze během zpracování použít dočasné soubory a jak změnit složku, ve které jsou ukládány.

## **O BLOB**

**BLOB** (**Binary Large Object**) je obvykle velká položka (fotografie, prezentace, dokument nebo multimédia) uložená v binárním formátu.

Aspose.Slides for Python via Java vám umožňuje používat BLOB pro objekty způsobem, který snižuje spotřebu paměti při práci s velkými soubory.

{{% alert color="info" title="Note" %}}

To circumvent certain limitations when interacting with streams, Aspose.Slides may copy the stream's content. Loading a large presentation through its stream will result in the copying of the presentation's contents and cause slow loading. Therefore, when you intend to load a large presentation, we strongly recommend that you use the presentation file path and not its stream.

{{% /alert %}}

## **Použít BLOB ke snížení spotřeby paměti**

### **Přidání velkého souboru pomocí BLOB do prezentace**

[Aspose.Slides](/slides/cs/python-java/) for Python via Java vám umožňuje přidat velké soubory (v tomto případě velký video soubor) prostřednictvím procesu zahrnujícího BLOB, aby se snížila spotřeba paměti.

Tento Python kód vám ukazuje, jak přidat velký video soubor pomocí procesu BLOB do prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Vytvořte novou prezentaci, do které bude video přidáno.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Zachovejte stream zamčený, protože neplánujeme přistupovat k video souboru.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Uložte prezentaci a současně udržujte nízkou spotřebu paměti.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Export velkého souboru pomocí BLOB z prezentace**

Aspose.Slides for Python via Java umožňuje exportovat velké soubory (v tomto případě audio‑ nebo video soubor) prostřednictvím procesu zahrnujícího BLOB z prezentací. Například můžete potřebovat extrahovat velký multimediální soubor z prezentace, ale nechcete, aby byl soubor načten do paměti počítače. Exportováním souboru pomocí procesu BLOB udržíte spotřebu paměti nízkou.

Tento kód v Pythonu demonstruje popsanou operaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Zamkněte zdrojový soubor místo načtení do paměti.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Přeneste video data přes buffer, aby byla spotřeba paměti nízká.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Použijte stream místo načtení celého videa do pole bajtů.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # V případě potřeby použijte stejné kroky i na audio soubory.
finally:
    presentation.dispose()
```

### **Přidání obrázku jako BLOB do prezentace**

S metodami třídy [ImageCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/) můžete přidat velký obrázek jako stream, aby byl zpracován jako BLOB.

Tento Python kód vám ukazuje, jak přidat velký obrázek pomocí procesu BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Vytvořte novou prezentaci, do které bude obrázek přidán.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Zamkněte stream, protože neplánujeme přístup k souboru obrázku.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Uložte prezentaci a zároveň udržujte nízkou spotřebu paměti.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Paměť a velké prezentace**

Obvykle pro načtení velké prezentace počítače potřebují hodně dočasné paměti. Veškerý obsah prezentace se načte do paměti a soubor (ze kterého byla prezentace načtena) přestane být používán.

Uvažujme velkou PowerPoint prezentaci (large.pptx), která obsahuje 1,5 GB video soubor. Standardní metoda načítání prezentace je popsána v tomto Python kódu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Tato metoda však spotřebuje přibližně 1,6 GB dočasné paměti.

### **Načtení velké prezentace jako BLOB**

Prostřednictvím procesu zahrnujícího BLOB můžete načíst velkou prezentaci při minimální spotřebě paměti. Tento Python kód popisuje implementaci, kde je proces BLOB použit k načtení velkého souboru prezentace (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Změna složky pro dočasné soubory**

Když je použit proces BLOB, počítač vytváří dočasné soubory ve výchozí složce pro dočasné soubory. Pokud chcete, aby byly dočasné soubory uchovávány v jiné složce, můžete změnit nastavení úložiště pomocí [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}

When you use [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides does not automatically create a folder to store temporary files. You have to create the folder manually.

{{% /alert %}}

### **Uvolnění objektů prezentace pro uvolnění paměti**

Při zpracování velkých prezentací zajistěte, aby instance [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) byla řádně uvolněna, aby se uvolnila paměť, kterou zabírala. Po dokončení práce s prezentací zavolejte [Presentation.dispose](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#dispose), abyste uvolnili neřízené zdroje.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...zpracovat prezentaci...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Explicitně uvolněte prostředky.
    presentation.dispose()
```

## **Často kladené otázky**

**Jaká data v prezentaci Aspose.Slides jsou považována za BLOB a řízena možnostmi BLOB?**

Velké binární objekty, jako jsou obrázky, audio a video, jsou považovány za BLOB. Celý soubor prezentace také podléhá zpracování BLOB při načítání nebo ukládání. Tyto objekty jsou spravovány zásadami BLOB, které vám umožňují řídit využití paměti a přechod na dočasné soubory podle potřeby.

**Kde mohu během načítání prezentace nakonfigurovat pravidla zpracování BLOB?**

Použijte [LoadOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/) spolu s [BlobManagementOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/). Zde nastavíte limit paměti pro BLOB, povolíte nebo zakážete dočasné soubory, zvolíte kořenovou cestu pro dočasné soubory a vyberete chování zamykání zdroje.

**Ovlivňují nastavení BLOB výkon a jak najít rovnováhu mezi rychlostí a pamětí?**

Ano. Udržování BLOB v paměti maximalizuje rychlost, ale zvyšuje spotřebu RAM; snížení limitu paměti přesune více práce na dočasné soubory, čímž snižuje RAM za cenu dodatečného I/O. Použijte metodu [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) k dosažení správné rovnováhy pro vaše zatížení a prostředí.

**Pomáhají možnosti BLOB při otevírání extrémně velkých prezentací (např. v gigabajtech)?**

Ano. [BlobManagementOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/) jsou navrženy pro takové scénáře: povolení dočasných souborů a použití zamykání zdroje může významně snížit špičkovou spotřebu RAM a stabilizovat zpracování velmi velkých prezentací.

**Mohu použít zásady BLOB při načítání ze streamů místo souborů na disku?**

Ano. Stejná pravidla platí pro streamy: instance prezentace může vlastnit a zamknout vstupní stream (v závislosti na zvoleném režimu zamykání) a dočasné soubory jsou použity, pokud jsou povoleny, což udržuje předvídatelnou spotřebu paměti během zpracování.