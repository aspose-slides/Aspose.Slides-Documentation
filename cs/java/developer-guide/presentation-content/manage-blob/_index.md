---
title: Správa BLOBů v prezentaci v Javě pro efektivní využití paměti
linktitle: Správa BLOB
type: docs
weight: 10
url: /cs/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Spravujte BLOB data v Aspose.Slides pro Javu, abyste zefektivnili operace se soubory PowerPoint a OpenDocument pro efektivní zpracování prezentací."
---
## **Přehled**

Aspose.Slides poskytuje zpracování BLOB pro velká binární data v prezentacích, aby pomohlo snížit spotřebu paměti při práci s velkými obrázky, audio, video a soubory prezentací.

Tento článek ukazuje, jak pomocí BLOB‑zpracování přidat velká média do prezentace, exportovat velká média z prezentace a načíst velké prezentace efektivněji. Také vysvětluje, jak mohou být během zpracování použity dočasné soubory a jak změnit složku, ve které jsou ukládány.

## **O BLOB**

**BLOB** (**Binary Large Object**) je obvykle velká položka (foto, prezentace, dokument nebo média) uložená v binárním formátu.

Aspose.Slides for Java vám umožňuje používat BLOBy pro objekty způsobem, který snižuje spotřebu paměti, když jsou zapojeny velké soubory.

{{% alert title="Info" color="info" %}}
Aby se obešlo několik omezení při práci se streamy, Aspose.Slides může zkopírovat obsah streamu. Načtení velké prezentace přes její stream způsobí kopírování obsahu prezentace a zpomalí načítání. Proto, když chcete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace, nikoli její stream.
{{% /alert %}}

## **Použití BLOB ke snížení spotřeby paměti**

### **Přidání velkého souboru pomocí BLOB do prezentace**

[Aspose.Slides](/slides/cs/java/) for Java vám umožňuje přidávat velké soubory (v tomto případě velký video soubor) pomocí procesu zahrnujícího BLOBy, aby se snížila spotřeba paměti.

Tento Java kód vám ukáže, jak přidat velký video soubor pomocí BLOB procesu do prezentace:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Vytvoří novou prezentaci, ke které bude video přidáno
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Přidáme video do prezentace – zvolili jsme chování KeepLocked, protože
        //neplánujeme přistupovat k souboru "veryLargeVideo.avi" file.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Uloží prezentaci. I když se výstupem stane velká prezentace, spotřeba paměti
        //zůstává nízká během životního cyklu objektu pres
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

Aspose.Slides for Java vám umožňuje exportovat velké soubory (např. audio nebo video soubor) pomocí procesu zahrnujícího BLOBy z prezentací. Například můžete potřebovat extrahovat velký mediální soubor z prezentace, ale nechcete, aby byl soubor načten do paměti počítače. Exportem souboru přes BLOB proces udržíte spotřebu paměti nízkou.

Tento Java kód demonstruje popsanou operaci:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Uzamkne zdrojový soubor a NENAČTE ho do paměti
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// vytvoří instanci Presentation a uzamkne soubor "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Uložíme každé video do souboru. Abychom zabránili vysoké spotřebě paměti, potřebujeme buffer, který bude použit
    // k přenosu dat z video streamu prezentace do streamu nově vytvořeného video souboru.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Otevře video stream prezentace. Všimněte si, že jsme úmyslně nevyužili přístup k vlastnostem
        // jako video.BinaryData - protože tato vlastnost vrací pole byte obsahující celé video, což pak
        // způsobí načtení bytů do paměti. Používáme video.GetStream, který vrátí Stream - a NENÍ
        //  potřeba načíst celé video do paměti.
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
    // V případě potřeby můžete použít stejný postup i pro audio soubory. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Přidání obrázku jako BLOB do prezentace**

Pomocí metod rozhraní [**IImageCollection**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IImageCollection) a třídy [**ImageCollection**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ImageCollection) můžete přidat velký obrázek jako stream, aby byl zpracován jako BLOB.

Tento Java kód vám ukáže, jak přidat velký obrázek pomocí BLOB procesu:

```java
String pathToLargeImage = "large_image.jpg";

// vytvoří novou prezentaci, ke které bude obrázek přidán.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Přidáme obrázek do prezentace – zvolíme chování KeepLocked, protože
		// NEPLÁNUJEME přistupovat k souboru "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Uloží prezentaci. I když se výstupem stane velká prezentace, spotřeba paměti
		// zůstává nízká během životního cyklu objektu pres
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

Obvykle při načítání velké prezentace vyžadují počítače hodně dočasné paměti. Veškerý obsah prezentace se načte do paměti a soubor (ze kterého byla prezentace načtena) přestane být používán.

Uvažujme velkou PowerPoint prezentaci (large.pptx), která obsahuje 1,5 GB video soubor. Standardní metoda načtení prezentace je popsána v tomto Java kódu:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Tato metoda ale spotřebuje přibližně 1,6 GB dočasné paměti.

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

Když je použit BLOB proces, počítač vytváří dočasné soubory ve výchozí složce pro dočasné soubory. Pokud chcete, aby byly dočasné soubory uloženy v jiné složce, můžete změnit nastavení úložiště pomocí `TempFilesRootPath`:

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

Při zpracování velkých prezentací zajistěte, aby byla instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) řádně uvolněna, aby se uvolnila paměť, kterou zabírala. Po dokončení práce s prezentací zavolejte `dispose()`, abyste uvolnili neřízené zdroje.

```java
Presentation presentation = new Presentation("large.pptx");

// ...zpracujte prezentaci...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitně uvolněte prostředky.
presentation.dispose();
```

## **FAQ**

**Jaká data v prezentaci Aspose.Slides jsou považována za BLOB a řízena možnostmi BLOB?**

Velké binární objekty, jako jsou obrázky, audio a video, jsou považovány za BLOB. Celý soubor prezentace také zahrnuje BLOB zpracování při načítání nebo ukládání. Tyto objekty jsou řízeny BLOB politikami, které vám umožňují spravovat využití paměti a přepínat na dočasné soubory podle potřeby.

**Kde mohu konfigurovat pravidla BLOB zpracování během načítání prezentace?**

Použijte [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/) s [BlobManagementOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/blobmanagementoptions/). Zde nastavíte limit paměti pro BLOB, povolíte nebo zakážete dočasné soubory, zvolíte kořenovou cestu pro dočasné soubory a určíte chování zamykání zdroje.

**Ovlivňují nastavení BLOB výkon a jak vybalancovat rychlost vůči paměti?**

Ano. Udržení BLOB v paměti maximalizuje rychlost, ale zvyšuje spotřebu RAM; snížení limitu paměti přesouvá více práce do dočasných souborů, čímž snižuje RAM za cenu vyššího vstupně‑výstupního provozu. Použijte metodu [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) k dosažení správné rovnováhy pro vaše zatížení a prostředí.

**Pomáhají BLOB možnosti při otevírání extrémně velkých prezentací (např. gigabajty)?**

Ano. [BlobManagementOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/blobmanagementoptions/) jsou navrženy pro takové scénáře: povolení dočasných souborů a použití zamykání zdroje může výrazně snížit špičkovou spotřebu RAM a stabilizovat zpracování velmi velkých sad.

**Mohu použít BLOB politiky při načítání ze streamů místo souborů na disku?**

Ano. stejná pravidla platí i pro streamy: instance prezentace může vlastnit a zamknout vstupní stream (v závislosti na zvoleném režimu zamykání) a dočasné soubory jsou používány, pokud jsou povoleny, čímž se během zpracování udržuje předvídatelná spotřeba paměti.