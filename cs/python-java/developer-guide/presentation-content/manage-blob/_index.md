---
title: Správa BLOBů prezentace v Pythonu přes Java pro efektivní využití paměti
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
description: "Spravujte BLOB data v Aspose.Slides pro Python přes Java, aby byl zjednodušený provoz souborů PowerPoint a OpenDocument pro efektivní zpracování prezentací."
---
## **Přehled**

Aspose.Slides poskytuje zpracování založené na BLOB pro velká binární data v prezentacích, aby pomohlo snížit spotřebu paměti při práci s velkými obrázky, zvuky, videi a soubory prezentací.

Tento článek ukazuje, jak použít zpracování založené na BLOB pro přidání velkých médií do prezentace, export velkých médií z prezentace a efektivnější načítání velkých prezentací. Také vysvětluje, jak lze během zpracování používat dočasné soubory a jak změnit složku, ve které jsou uloženy.

## **O BLOB**

**BLOB** (**Binary Large Object**) je obvykle velká položka (fotografie, prezentace, dokument nebo média) uložená v binárním formátu.

Aspose.Slides for Python via Java vám umožňuje používat BLOBy pro objekty způsobem, který snižuje spotřebu paměti při práci s velkými soubory.

{{% alert color="info" title="Note" %}}
Aby se obešla určitá omezení při práci se streamy, Aspose.Slides může zkopírovat obsah streamu. Načtení velké prezentace přes její stream povede ke kopírování obsahu prezentace a způsobí pomalé načítání. Proto, když chcete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace a ne její stream.
{{% /alert %}}

## **Použijte BLOBy ke snížení spotřeby paměti**

### **Přidání velkého souboru do prezentace pomocí BLOBů**

[Aspose.Slides](/slides/cs/python-java/) for Python via Java umožňuje přidávat velké soubory (v tomto případě velký video soubor) pomocí procesu zahrnujícího BLOBy ke snížení spotřeby paměti.

Tento Python kód vám ukazuje, jak přidat velký video soubor pomocí BLOB procesu do prezentace:

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
        # Uchovejte stream uzamčený, protože neplánujeme přistupovat k video souboru.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Save the presentation while keeping memory consumption low.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Exportování velkého souboru z prezentace pomocí BLOBů**

Aspose.Slides for Python via Java vám umožňuje exportovat velké soubory (v tomto případě audio nebo video soubor) pomocí procesu zahrnujícího BLOBy z prezentací. Například můžete potřebovat extrahovat velký mediální soubor z prezentace, ale nechcete, aby byl soubor načten do paměti počítače. Exportováním souboru pomocí BLOB procesu udržíte spotřebu paměti nízkou.

Tento kód v Pythonu demonstruje popsanou operaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Uzamkněte zdrojový soubor místo načítání do paměti.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Přeneste video data přes buffer, aby byla spotřeba paměti nízká.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Použijte stream místo načítání celého videa do pole bajtů.
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

Pomocí metod třídy [ImageCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/) můžete přidat velký obrázek jako stream, aby byl považován za BLOB.

Tento Python kód vám ukazuje, jak přidat velký obrázek pomocí BLOB procesu:

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
        # Uchovejte stream uzamčený, protože neplánujeme přistupovat k souboru obrázku.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Uložte prezentaci při zachování nízké spotřeby paměti.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Paměť a velké prezentace**

Obvykle pro načtení velké prezentace počítače vyžadují hodně dočasné paměti. Veškerý obsah prezentace se načte do paměti a soubor (ze kterého byla prezentace načtena) se přestane používat.

Uvažujme velkou PowerPoint prezentaci (large.pptx), která obsahuje video soubor o velikosti 1,5 GB. Standardní metoda načtení prezentace je popsána v tomto Python kódu:

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

Pomocí zpracování BLOB můžete načíst velkou prezentaci s malou spotřebou paměti. Tento Python kód ukazuje, jak použít BLOB zpracování k načtení velkého souboru prezentace (large.pptx):

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

Když je použit BLOB proces, váš počítač vytváří dočasné soubory ve výchozí složce pro dočasné soubory. Pokud chcete, aby byly dočasné soubory uloženy v jiné složce, můžete změnit nastavení úložiště pomocí [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

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
Když použijete [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides automaticky nevytvoří složku pro ukládání dočasných souborů. Složku musíte vytvořit ručně.
{{% /alert %}}

### **Uvolnění objektů prezentace pro uvolnění paměti**

Při zpracování velkých prezentací zajistěte, aby instance [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) byla řádně uvolněna, aby byla paměť, kterou zabírala, uvolněna. Po dokončení práce s prezentací zavolejte [Presentation.dispose](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#dispose), abyste uvolnili neřízené prostředky.

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

Velké binární objekty jako obrázky, audio a video jsou považovány za BLOBy. Celý soubor prezentace také zahrnuje zpracování BLOB při načítání nebo ukládání. Tyto objekty jsou řízeny politikami BLOB, které vám umožňují spravovat využití paměti a přesměrování do dočasných souborů podle potřeby.

**Kde mohu konfigurovat pravidla zpracování BLOB během načítání prezentace?**

Použijte [LoadOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/) s [BlobManagementOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/). Zde nastavíte limit paměti pro BLOBy, povolíte nebo zakážete dočasné soubory, zvolíte kořenovou cestu pro dočasné soubory a nastavíte chování uzamykání zdroje.

**Ovlivňují nastavení BLOB výkon a jak vyvážit rychlost versus paměť?**

Ano. Udržování BLOBů v paměti maximalizuje rychlost, ale zvyšuje spotřebu RAM; snížení limitu paměti přesune více práce do dočasných souborů, čímž snižuje RAM za cenu dalšího I/O. Použijte metodu [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) k dosažení správné rovnováhy pro vaše pracovní zatížení a prostředí.

**Pomáhají možnosti BLOB při otevírání extrémně velkých prezentací (např. gigabajty)?**

Ano. [BlobManagementOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blobmanagementoptions/) je navrženo pro takové scénáře: povolení dočasných souborů a použití uzamykání zdroje může výrazně snížit špičkovou spotřebu RAM a stabilizovat zpracování velmi velkých prezentací.

**Mohu použít politiky BLOB při načítání ze streamů místo souborů na disku?**

Ano. Stejná pravidla platí pro streamy: instance prezentace může vlastnit a zamknout vstupní stream (v závislosti na zvoleném režimu uzamykání) a dočasné soubory jsou používány, pokud jsou povoleny, což udržuje předvídatelnou spotřebu paměti během zpracování.