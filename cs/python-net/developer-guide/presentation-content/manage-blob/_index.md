---
title: Správa BLOBů v prezentacích pomocí Pythonu pro efektivní využití paměti
linktitle: Spravovat BLOB
type: docs
weight: 10
url: /cs/python-net/manage-blob/
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
- Aspose.Slides
description: "Spravujte BLOB data v Aspose.Slides pro Python přes .NET, abyste zjednodušili operace se soubory PowerPoint a OpenDocument pro efektivní zpracování prezentací."
---
## **Přehled**

Aspose.Slides poskytuje zpracování založené na BLOB pro velké binární údaje v prezentacích, aby pomohlo snížit spotřebu paměti při práci s velkými obrázky, zvukovými soubory, videi a soubory prezentací.

Tento článek ukazuje, jak použít zpracování založené na BLOB k přidání velkých multimédií do prezentace, exportu velkých multimédií z prezentace a efektivnějšímu načítání velkých prezentací. Také vysvětluje, jak lze během zpracování používat dočasné soubory a jak změnit složku, ve které jsou ukládány.

## **O BLOB**

**BLOB** (**Binary Large Object**) je obvykle velká položka (fotografie, prezentace, dokument nebo multimédium) uložená v binárních formátech.

Aspose.Slides for Python via .NET vám umožňuje používat BLOBy pro objekty způsobem, který snižuje spotřebu paměti při práci s velkými soubory.

## **Použití BLOB ke snížení spotřeby paměti**

### **Přidání velkého souboru přes BLOB do prezentace**

[Aspose.Slides](/slides/cs/python-net/) pro .NET vám umožňuje přidávat velké soubory (v tomto případě velký video soubor) pomocí procesu zahrnujícího BLOBy, čímž snižuje spotřebu paměti.

Tento příklad v Pythonu ukazuje, jak přidat velký video soubor pomocí BLOB procesu do prezentace:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Vytvoří novou prezentaci, do které bude video přidáno
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Přidáme video do prezentace – zvolili jsme chování KeepLocked, protože
        # neplánujeme přistupovat k souboru "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Uloží prezentaci. I když je vytvořena velká prezentace, spotřeba paměti
        # zůstává nízká během životního cyklu objektu pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Export velkého souboru přes BLOB z prezentace**

Aspose.Slides for Python via .NET vám umožňuje exportovat velké soubory (v tomto případě audio nebo video soubor) pomocí procesu zahrnujícího BLOBy z prezentací. Například můžete potřebovat extrahovat velký mediální soubor z prezentace, ale nechcete, aby byl soubor načten do paměti počítače. Exportováním souboru pomocí BLOB procesu udržujete nízkou spotřebu paměti.

Tento kód v Pythonu demonstruje popsanou operaci:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Uložíme každé video do souboru. Abychom předešli vysoké spotřebě paměti, potřebujeme buffer, který bude použit
	# k přenosu dat z video proudu prezentace do proudu pro nově vytvořený video soubor.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Prochází videa
    index = 0
    # V případě potřeby můžete použít stejné kroky i pro audio soubory. 
    for video in pres.videos:
		# Otevře video proud prezentace. Všimněte si, že jsme záměrně vyhnuli přístupu k vlastnostem
		# jako video.BinaryData - protože tato vlastnost vrací pole bytů obsahující celé video, což pak
		# způsobí načtení bytů do paměti. Používáme video.GetStream, který vrátí Stream - a NE
		#  vyžaduje, abychom načetli celé video do paměti.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Přidání obrázku jako BLOB v prezentaci**

Pomocí metod ze třídy [**ImageCollection**](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/) můžete přidat velký obrázek jako proud, aby byl považován za BLOB.

Tento kód v Pythonu ukazuje, jak přidat velký obrázek pomocí BLOB procesu:

```py
import aspose.slides as slides

# vytvoří novou prezentaci, do které bude obrázek přidán.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Paměť a velké prezentace**

Obvykle pro načtení velké prezentace počítače potřebují hodně dočasné paměti. Veškerý obsah prezentace je načten do paměti a soubor (ze kterého byla prezentace načtena) se přestane používat.

Uvažujte o velké PowerPoint prezentaci (large.pptx), která obsahuje 1,5 GB video soubor. Standardní metoda načtení prezentace je popsána v tomto Python kódu:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Avšak tato metoda spotřebuje přibližně 1,6 GB dočasné paměti.

### **Načtení velké prezentace jako BLOB**

Pomocí procesu zahrnujícího BLOB můžete načíst velkou prezentaci při malém využití paměti. Tento Python kód popisuje implementaci, kde se proces BLOB používá k načtení velkého souboru prezentace (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Změna složky pro dočasné soubory**

Když je použit proces BLOB, váš počítač vytváří dočasné soubory ve výchozí složce pro dočasné soubory. Pokud chcete, aby byly dočasné soubory uloženy v jiné složce, můžete změnit nastavení úložiště pomocí `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Když použijete `temp_files_root_path`, Aspose.Slides automaticky nevytvoří složku pro ukládání dočasných souborů. Musíte složku vytvořit ručně.
{{% /alert %}}

### **Uvolnění objektů prezentace pro uvolnění paměti**

Při zpracování velkých prezentací se ujistěte, že instance [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) je řádně uvolněna, aby byla uvolněna paměť, kterou zabírala. Doporučený způsob je použít kontextový manažer (`with slides.Presentation(...) as presentation:`) jako je ukázáno v příkladech výše; automaticky uzavře prezentaci a uvolní neřízené prostředky při opuštění bloku.

Pokud vytvoříte prezentaci bez bloku `with`, explicitně zavolejte `presentation.dispose()` poté, co jste ji dokončili používat, a odstraňte všechny zbývající reference, aby garbage collector v Pythonu mohl uvolnit paměť.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...zpracovat prezentaci...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Výslovně uvolnit prostředky.
presentation.dispose()
```

## **Často kladené dotazy**

**Jaká data v prezentaci Aspose.Slides jsou považována za BLOB a řízena nastavením BLOB?**

Velké binární objekty, jako jsou obrázky, audio a video, jsou považovány za BLOB. Celý soubor prezentace také zahrnuje zpracování BLOB při načítání nebo ukládání. Tyto objekty jsou řízeny politikami BLOB, které vám umožňují spravovat využití paměti a přelévat data do dočasných souborů podle potřeby.

**Kde mohu nakonfigurovat pravidla zpracování BLOB během načítání prezentace?**

Použijte [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/) spolu s [BlobManagementOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/blobmanagementoptions/). Zde nastavíte limit paměti pro BLOB, povolíte či zakážete dočasné soubory, zvolíte kořenovou cestu pro dočasné soubory a vyberete chování zamykání zdroje.

**Ovlivňují nastavení BLOB výkon a jak najít rovnováhu mezi rychlostí a pamětí?**

Ano. Udržování BLOB v paměti maximalizuje rychlost, ale zvyšuje spotřebu RAM; snížením limitu paměti se více práce přesune do dočasných souborů, což snižuje RAM za cenu dalšího vstupně‑výstupního provozu. Laděním prahu [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/cs/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) dosáhnete vhodné rovnováhy pro své zatížení a prostředí.

**Pomáhají nastavení BLOB při otevírání extrémně velkých prezentací (např. v gigabytech)?**

Ano. [BlobManagementOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/blobmanagementoptions/) jsou navrženy pro takové scénáře: povolení dočasných souborů a použití zamykání zdroje může výrazně snížit špičkovou spotřebu RAM a stabilizovat zpracování velmi velkých sad.

**Mohu použít politiky BLOB při načítání ze streamů místo souborů na disku?**

Ano. Stejná pravidla platí pro streamy: instance prezentace může vlastnit a zamknout vstupní stream (v závislosti na zvoleném režimu zamykání) a dočasné soubory jsou používány, když je to povoleno, čímž se udržuje předvídatelné využití paměti během zpracování.