---
title: Správa BLOBů prezentace v JavaScriptu pro efektivní využití paměti
linktitle: Spravovat BLOB
type: docs
weight: 10
url: /cs/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte BLOB data v JavaScriptu pomocí Aspose.Slides pro Node.js, abyste zjednodušili operace se soubory PowerPoint a OpenDocument pro efektivní práci s prezentacemi."
---
## **Přehled**

Aspose.Slides poskytuje zpracování založené na BLOB pro velká binární data v prezentacích, aby pomohlo snížit spotřebu paměti při práci s velkými obrazy, zvukem, videem a soubory prezentací.

Tento článek ukazuje, jak použít zpracování založené na BLOB k přidání velkých médií do prezentace, exportu velkých médií z prezentace a efektivnějšímu načítání velkých prezentací. Také vysvětluje, jak lze během zpracování použít dočasné soubory a jak změnit složku, ve které jsou ukládány.

## **O BLOB**

**BLOB** (**Binary Large Object**) je obvykle velká položka (foto, prezentace, dokument nebo média) uložená v binárních formátech. 

Aspose.Slides pro Node.js prostřednictvím Java vám umožňuje používat BLOBy pro objekty způsobem, který snižuje spotřebu paměti, pokud jsou zapojeny velké soubory.

{{% alert title="Info" color="info" %}}
Aby se obešly některé omezení při práci s proudy, Aspose.Slides může zkopírovat obsah proudu. Načtení velké prezentace přes její proud povede ke kopírování obsahu prezentace a zpomalí načítání. Proto, když chcete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace a ne její proud.
{{% /alert %}}

## **Použijte BLOB ke snížení spotřeby paměti**

### **Přidání velkého souboru přes BLOB do prezentace**

[Aspose.Slides](/slides/cs/nodejs-java/) pro Node.js prostřednictvím Java vám umožňuje přidat velké soubory (v tomto případě velký video soubor) pomocí procesu zahrnujícího BLOBy ke snížení spotřeby paměti.

Tento JavaScript vám ukazuje, jak přidat velký video soubor pomocí procesu BLOB do prezentace:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Vytvoří novou prezentaci, do které bude video přidáno
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Přidáme video do prezentace - zvolili jsme chování KeepLocked, protože
        // neplánujeme přistupovat k souboru "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Uloží prezentaci. I když je výstup velké prezentace, spotřeba paměti
        // zůstává nízká během životního cyklu objektu pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Export velkého souboru přes BLOB z prezentace**

Aspose.Slides pro Node.js prostřednictvím Java vám umožňuje exportovat velké soubory (v tomto případě audio nebo video soubor) pomocí procesu zahrnujícího BLOBy z prezentací. Například můžete potřebovat extrahovat velký mediální soubor z prezentace, ale nechcete, aby byl soubor načten do paměti vašeho počítače. Exportováním souboru pomocí procesu BLOB udržíte spotřebu paměti nízkou.

Tento kód v JavaScriptu demonstruje popsanou operaci:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Uzamkne zdrojový soubor a NE NAČÍTÁ jej do paměti
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// vytvoří instanci Presentation a uzamkne soubor "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Uložíme každé video do souboru. Abychom předešli vysoké spotřebě paměti, potřebujeme buffer, který bude použit
    // k přenosu dat z video proudu prezentace do proudu nově vytvořeného video souboru.
    var buffer = new byte[8 * 1024];
    // Iteruje přes videa
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Otevře video proud prezentace. Všimněte si, že jsme úmyslně vyhnuli přístupu k vlastnostem
        // jako video.BinaryData - protože tato vlastnost vrací pole bajtů obsahující celé video, což pak
        // způsobuje načtení bajtů do paměti. Používáme video.GetStream, který vrátí Stream - a NE
        // vyžaduje od nás načíst celé video do paměti.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Spotřeba paměti zůstane nízká bez ohledu na velikost videa nebo prezentace.
    }
    // V případě potřeby můžete použít stejné kroky i pro audio soubory.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Přidání obrázku jako BLOB v prezentaci**

Pomocí metod ze třídy [**ImageCollection**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ImageCollection) a [**ImageCollection** ](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ImageCollection) můžete přidat velký obrázek jako proud, aby byl zpracován jako BLOB.

Tento JavaScript kód vám ukazuje, jak přidat velký obrázek pomocí procesu BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// vytvoří novou prezentaci, do které bude obrázek přidán.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Přidáme obrázek do prezentace - zvolíme chování KeepLocked, protože
        // NE hodláme přistupovat k souboru "largeImage.png" file.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Uloží prezentaci. I když je výstup velké prezentace, spotřeba paměti
        // zůstává nízká během životního cyklu objektu pres.
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Paměť a velké prezentace**

Obvykle pro načtení velké prezentace počítače potřebují velké množství dočasné paměti. Veškerý obsah prezentace je načten do paměti a soubor (ze kterého byla prezentace načtena) přestane být používán.

Uvažujme velkou PowerPoint prezentaci (large.pptx), která obsahuje 1,5 GB video soubor. Standardní metoda pro načtení prezentace je popsána v tomto JavaScript kódu:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tato metoda však spotřebuje přibližně 1,6 GB dočasné paměti.

### **Načtení velké prezentace jako BLOB**

Pomocí procesu zahrnujícího BLOB můžete načíst velkou prezentaci při minimálním využití paměti. Tento JavaScript kód popisuje implementaci, kde je proces BLOB použit k načtení velkého souboru prezentace (large.pptx):

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Změna složky pro dočasné soubory**

Když je použit proces BLOB, váš počítač vytváří dočasné soubory ve výchozí složce pro dočasné soubory. Pokud chcete, aby byly dočasné soubory uloženy v jiné složce, můžete změnit nastavení úložiště pomocí `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Když použijete `setTempFilesRootPath`, Aspose.Slides automaticky nevytvoří složku pro ukládání dočasných souborů. Složku musíte vytvořit ručně.
{{% /alert %}}

### **Uvolněte objekty Presentation pro uvolnění paměti**

Při zpracování velkých prezentací zajistěte, aby instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) byla řádně uvolněna, aby byla uvolněna paměť, kterou zabírala. Po dokončení práce s prezentací zavolejte `dispose()`, abyste uvolnili neřízené prostředky.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...zpracovat prezentaci...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitně uvolnit prostředky.
presentation.dispose();
```

## **Časté dotazy**

**Jaká data v prezentaci Aspose.Slides jsou považována za BLOB a řízena možnostmi BLOB?**

Velké binární objekty, jako jsou obrázky, audio a video, jsou považovány za BLOB. Celý soubor prezentace také zahrnuje zpracování BLOB při načítání nebo ukládání. Tyto objekty jsou řízeny politikami BLOB, které vám umožňují spravovat využití paměti a v případě potřeby přenášet data do dočasných souborů.

**Kde mohu během načítání prezentace nakonfigurovat pravidla zpracování BLOB?**

Použijte [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/) s [BlobManagementOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/blobmanagementoptions/). Zde můžete nastavit limit paměti v RAM pro BLOB, povolit či zakázat dočasné soubory, zvolit kořenovou cestu pro dočasné soubory a vybrat chování zamykání zdroje.

**Ovlivňují nastavení BLOB výkon a jak vyvážit rychlost vůči paměti?**

Ano. Udržování BLOB v paměti maximalizuje rychlost, ale zvyšuje spotřebu RAM; snížení limitu paměti přesouvá více práce do dočasných souborů, což snižuje RAM za cenu dodatečného I/O. Použijte metodu [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) k dosažení správné rovnováhy pro vaše zatížení a prostředí.

**Pomáhají možnosti BLOB při otevírání extrémně velkých prezentací (např. gigabajty)?**

Ano. [BlobManagementOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/blobmanagementoptions/) jsou navrženy pro takové scénáře: povolení dočasných souborů a použití zamykání zdroje může výrazně snížit špičkovou spotřebu RAM a stabilizovat zpracování velmi velkých prezentací.

**Mohu použít politiky BLOB při načítání ze streamů místo diskových souborů?**

Ano. Stejná pravidla platí pro streamy: instance prezentace může vlastnit a zamknout vstupní stream (v závislosti na zvoleném režimu zamykání) a dočasné soubory jsou používány, pokud jsou povoleny, což udržuje předvídatelné využití paměti během zpracování.