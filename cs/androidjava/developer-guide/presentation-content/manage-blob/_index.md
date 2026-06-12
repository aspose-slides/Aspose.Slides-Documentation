---
title: Správa BLOBů prezentací na Androidu pro efektivní využití paměti
linktitle: Správa BLOB
type: docs
weight: 10
url: /cs/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Spravujte BLOB data v Aspose.Slides pro Android pomocí Javy, aby bylo zjednodušeno zpracování souborů PowerPoint a OpenDocument pro efektivní správu prezentací."
---
## **Přehled**

Aspose.Slides poskytuje založené na BLOB zpracování velkých binárních dat v prezentacích, aby pomohlo snížit spotřebu paměti při práci s velkými obrázky, zvuky, videi a soubory prezentací.

Tento článek ukazuje, jak použít BLOB‑založené zpracování k přidání velkých médií do prezentace, exportu velkých médií z prezentace a načítání velkých prezentací efektivněji. Také vysvětluje, jak lze během zpracování používat dočasné soubory a jak změnit složku, ve které jsou uloženy.

## **O BLOB**

**BLOB** (**Binary Large Object**) je obvykle velká položka (fotografie, prezentace, dokument nebo média) uložená v binárních formátech.

Aspose.Slides for Android via Java umožňuje používat BLOBy pro objekty způsobem, který snižuje spotřebu paměti při práci s velkými soubory.

{{% alert title="Info" color="info" %}}
Aby se obešlo některé omezení při práci s proudy, Aspose.Slides může kopírovat obsah proudu. Načtení velké prezentace přes její proud povede ke kopírování obsahu prezentace a zpomalí načítání. Proto, když chcete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace, nikoli její proud.
{{% /alert %}}

## **Použití BLOB ke snížení spotřeby paměti**

### **Přidání velkého souboru pomocí BLOB do prezentace**

[Aspose.Slides](/slides/cs/androidjava/) pro Java umožňuje přidávat velké soubory (v tomto případě velký video soubor) pomocí procesu zahrnujícího BLOBy, aby se snížila spotřeba paměti.

Tento Java příklad ukazuje, jak přidat velký video soubor pomocí BLOB procesu do prezentace:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Vytvoří novou prezentaci, ke které bude video přidáno
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Přidáme video do prezentace – zvolili jsme chování KeepLocked, protože
        // neplánujeme přistupovat k souboru "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Uloží prezentaci. Zatímco se vytváří velká prezentace, spotřeba paměti
        // zůstává nízká během životního cyklu objektu pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Export velkého souboru pomocí BLOB z prezentace**

Aspose.Slides for Android via Java umožňuje exportovat velké soubory (v tomto případě audio nebo video soubor) pomocí procesu zahrnujícího BLOBy z prezentací. Například můžete potřebovat extrahovat velký mediální soubor z prezentace, ale nechcete, aby byl načten do paměti počítače. Exportováním souboru přes BLOB proces udržíte spotřebu paměti nízkou.

Tento kód v Java demonstruje popsanou operaci:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Uzamkne zdrojový soubor a NENAHRÁVÁ ho do paměti
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// vytvořte instanci Presentation, uzamkněte soubor "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Uložíme každé video do souboru. Abychom zabránili vysoké spotřebě paměti, potřebujeme buffer, který bude použit
    // k přenosu dat z video proudu prezentace do proudu nově vytvořeného video souboru.
    byte[] buffer = new byte[8 * 1024];

    // Prochází videa
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Otevře video proud prezentace. Všimněte si, že jsme úmyslně vyhnuli přístupu k vlastnostem
        // jako video.BinaryData – protože tato vlastnost vrací pole bytů obsahující celé video, což
        // způsobuje načtení bytů do paměti. Používáme video.GetStream, který vrátí Stream – a NENÍ
        //  vyžadovat načtení celého videa do paměti.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
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
    // V případě potřeby můžete použít stejné kroky pro audio soubory. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Přidání obrázku jako BLOB v prezentaci**

Pomocí metod rozhraní [**IImageCollection**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IImageCollection) a třídy [**ImageCollection**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ImageCollection) můžete přidat velký obrázek jako proud, aby byl zpracován jako BLOB.

Tento Java kód ukazuje, jak přidat velký obrázek pomocí BLOB procesu:

```java
String pathToLargeImage = "large_image.jpg";

// vytvoří novou prezentaci, ke které bude obrázek přidán.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Přidáme obrázek do prezentace – zvolíme chování KeepLocked, protože
		// NEPLÁNUJEME přistupovat k souboru "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Uloží prezentaci. Zatímco se vytváří velká prezentace, spotřeba paměti
		// zůstává nízká během životního cyklu objektu pres.
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Paměť a velké prezentace**

Typicky pro načtení velké prezentace počítače vyžadují hodně dočasné paměti. Veškerý obsah prezentace je načten do paměti a soubor, ze kterého byla prezentace načtena, přestane být používán.

Uvažujte o velké PowerPoint prezentaci (large.pptx), která obsahuje 1,5 GB video soubor. Standardní metoda načtení prezentace je popsána v tomto Java kódu:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Ale tato metoda spotřebuje přibližně 1,6 GB dočasné paměti.

### **Načtení velké prezentace jako BLOB**

Pomocí procesu zahrnujícího BLOB můžete načíst velkou prezentaci při minimální spotřebě paměti. Tento Java kód popisuje implementaci, kde je BLOB proces použit k načtení velkého souboru prezentace (large.pptx):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Změna složky pro dočasné soubory**

Když je použit BLOB proces, váš počítač vytváří dočasné soubory ve výchozí složce pro dočasné soubory. Pokud chcete, aby byly dočasné soubory uloženy v jiné složce, můžete změnit nastavení úložiště pomocí `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Když použijete `TempFilesRootPath`, Aspose.Slides automaticky nevytvoří složku pro ukládání dočasných souborů. Musíte složku vytvořit ručně.
{{% /alert %}}

### **Uvolnění objektů prezentace pro uvolnění paměti**

Při zpracování velkých prezentací zajistěte, aby instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) byla řádně uvolněna, aby se uvolnila paměť, kterou zabírala. Po dokončení používání prezentace zavolejte `dispose()`, abyste uvolnili nevyužívané prostředky.

```java
Presentation presentation = new Presentation("large.pptx");

// ...zpracujte prezentaci...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitně uvolněte zdroje.
presentation.dispose();
```

## **Často kladené otázky**

**Jaká data v prezentaci Aspose.Slides jsou považována za BLOB a řízena možnostmi BLOB?**  
Velké binární objekty, jako jsou obrázky, audio a video, jsou považovány za BLOB. Celý soubor prezentace také zahrnuje BLOB zpracování při načítání nebo ukládání. Tyto objekty jsou řízeny BLOB politikami, které vám umožňují spravovat využití paměti a přesouvat data do dočasných souborů podle potřeby.

**Kde mohu nakonfigurovat pravidla zpracování BLOB během načítání prezentace?**  
Použijte [LoadOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/) spolu s [BlobManagementOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/blobmanagementoptions/). Zde nastavíte limit paměti pro BLOB, povolíte nebo zakážete dočasné soubory, vyberete kořenovou cestu pro dočasné soubory a zvolíte chování zamykání zdroje.

**Ovlivňují nastavení BLOB výkon a jak vyvážit rychlost proti paměti?**  
Ano. Udržování BLOB v paměti maximalizuje rychlost, ale zvyšuje spotřebu RAM; snížení limitu paměti přesune více práce do dočasných souborů, čímž snižuje RAM za cenu dalšího I/O. Použijte metodu [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) k dosažení správné rovnováhy pro váš pracovní load a prostředí.

**Pomáhají možnosti BLOB při otevírání extrémně velkých prezentací (např. gigabajty)?**  
Ano. [BlobManagementOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/blobmanagementoptions/) jsou navrženy pro takové scénáře: povolení dočasných souborů a použití zamykání zdroje může výrazně snížit špičkovou spotřebu RAM a stabilizovat zpracování velmi velkých prezentací.

**Mohu použít BLOB politiky při načítání ze streamů místo souborů na disku?**  
Ano. Stejná pravidla platí pro streamy: instance prezentace může vlastnit a zamknout vstupní stream (v závislosti na zvoleném režimu zamykání) a dočasné soubory jsou použity, pokud jsou povoleny, čímž se udržuje předvídatelná spotřeba paměti během zpracování.