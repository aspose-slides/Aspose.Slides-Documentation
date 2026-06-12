---
title: Správa BLOBů prezentace v PHP pro efektivní využití paměti
linktitle: Správa BLOB
type: docs
weight: 10
url: /cs/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "Spravujte BLOB data v Aspose.Slides pro PHP přes Java a usnadněte operace se soubory PowerPoint a OpenDocument pro efektivní zpracování prezentací."
---
## **Přehled**

Aspose.Slides poskytuje zpracování založené na BLOB pro velká binární data v prezentacích, aby pomohlo snížit spotřebu paměti při práci s velkými obrázky, zvuky, videi a soubory prezentací.

Tento článek ukazuje, jak používat zpracování založené na BLOB k přidání velkých medií do prezentace, exportu velkých medií z prezentace a efektivnějšímu načtení velkých prezentací. Také vysvětluje, jak lze během zpracování používat dočasné soubory a jak změnit složku, ve které jsou uloženy.

## **O BLOB**

**BLOB** (**Binary Large Object**) je obvykle velká položka (foto, prezentace, dokument nebo média) uložená v binárním formátu.

Aspose.Slides pro PHP přes Java umožňuje používat BLOBy pro objekty způsobem, který snižuje spotřebu paměti při práci s velkými soubory.

{{% alert title="Info" color="info" %}}
Aby se obešli některé omezení při práci se streamy, Aspose.Slides může kopírovat obsah streamu. Načtení velké prezentace přes její stream povede ke kopírování obsahu prezentace a způsobí pomalé načítání. Proto, když chcete načíst velkou prezentaci, důrazně doporučujeme použít cestu k souboru prezentace a ne její stream.
{{% /alert %}}

## **Použijte BLOB ke snížení spotřeby paměti**

### **Přidání velkého souboru přes BLOB do prezentace**

[Aspose.Slides](/slides/cs/php-java/) pro Java umožňuje přidávat velké soubory (v tomto případě velký video soubor) pomocí procesu zahrnujícího BLOBy k snížení spotřeby paměti.

Tento příklad v Javě ukazuje, jak přidat velký video soubor pomocí procesu BLOB do prezentace:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Vytvoří novou prezentaci, do které bude video přidáno
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Přidáme video do prezentace – zvolili jsme chování KeepLocked, protože
      # neplánujeme přistupovat k souboru "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Uloží prezentaci. I když je výstup velká prezentace, spotřeba paměti
      # zůstává nízká po celou dobu životnosti objektu pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Export velkého souboru přes BLOB z prezentace**

Aspose.Slides pro PHP přes Java umožňuje exportovat velké soubory (v tomto případě audio nebo video soubor) pomocí procesu zahrnujícího BLOBy z prezentací. Například můžete potřebovat extrahovat velký mediální soubor z prezentace, ale nechcete, aby byl soubor načten do paměti vašeho počítače. Exportováním souboru pomocí procesu BLOB udržíte spotřebu paměti nízkou.

Tento kód demonstruje popsanou operaci:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Uzamkne zdrojový soubor a NENAHRANÍ ho do paměti
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # vytvoří instanci Presentation, uzamkne soubor "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Uložíme každé video do souboru. Abychom zabránili vysoké spotřebě paměti, potřebujeme buffer, který bude použit
    # k přenosu dat z video streamu prezentace do streamu nově vytvořeného video souboru.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Prochází videa
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Otevírá video stream prezentace. Všimněte si, že jsme úmyslně vyhnuli přístupu k vlastnostem
      # jako video.BinaryData - protože tato vlastnost vrací pole bajtů obsahující celé video, což pak
      # způsobí načtení bajtů do paměti. Používáme video.GetStream, který vrátí Stream - a NENÍ
      # nutný načíst celé video do paměti.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Spotřeba paměti zůstane nízká bez ohledu na velikost videa či prezentace.
    }
    # V případě potřeby můžete použít stejný postup i pro audio soubory.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Přidání obrázku jako BLOB do prezentace**

Pomocí metod třídy [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/) můžete přidat velký obrázek jako stream, aby byl zpracován jako BLOB.

Tento kód v PHP ukazuje, jak přidat velký obrázek pomocí procesu BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # vytvoří novou prezentaci, do které bude obrázek přidán.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Přidáme obrázek do prezentace – zvolíme chování KeepLocked, protože
      # NEplánujeme přistupovat k souboru "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Uloží prezentaci. I když je vytvořena velká prezentace, spotřeba paměti
      # zůstává nízká po celou dobu životnosti objektu pres.
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Paměť a velké prezentace**

Obvykle k načtení velké prezentace počítače vyžadují hodně dočasné paměti. Veškerý obsah prezentace se načte do paměti a soubor (ze kterého byla prezentace načtena) se přestal používat.

Uvažujme velkou PowerPoint prezentaci (large.pptx), která obsahuje 1,5 GB video soubor. Standardní metoda načtení prezentace je popsaná v tomto PHP kódu:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tato metoda však spotřebuje přibližně 1,6 GB dočasné paměti.

### **Načtení velké prezentace jako BLOB**

Pomocí procesu zahrnujícího BLOB můžete načíst velkou prezentaci při minimální spotřebě paměti. Tento PHP kód popisuje implementaci, kde je proces BLOB použit k načtení velkého souboru prezentace (large.pptx):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Změna složky pro dočasné soubory**

Když je použit proces BLOB, počítač vytváří dočasné soubory ve výchozí složce pro dočasné soubory. Pokud chcete, aby byly dočasné soubory ukládány do jiné složky, můžete změnit nastavení úložiště pomocí `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
Když použijete `setTempFilesRootPath`, Aspose.Slides automaticky nevytvoří složku pro ukládání dočasných souborů. Musíte složku vytvořit ručně.
{{% /alert %}}

### **Uvolnění objektů prezentace pro uvolnění paměti**

Při zpracování velkých prezentací se ujistěte, že instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) je řádně uvolněna, aby byla uvolněna paměť, kterou zabírala. Po dokončení práce s prezentací zavolejte `dispose()`, abyste uvolnili neřízené prostředky.

```php
$presentation = new Presentation("large.pptx");

# ...zpracovat prezentaci...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Výslovně uvolnit prostředky.
$presentation->dispose();
```

## **Často kladené otázky**

**Jaká data v prezentaci Aspose.Slides jsou považována za BLOB a řízena možnostmi BLOB?**

Velké binární objekty, jako jsou obrázky, audio a video, jsou považovány za BLOB. Celý soubor prezentace také zahrnuje zpracování BLOB při načítání nebo ukládání. Tyto objekty jsou řízeny politikami BLOB, které vám umožňují spravovat využití paměti a přenášet data do dočasných souborů podle potřeby.

**Kde mohu nastavit pravidla pro zpracování BLOB během načítání prezentace?**

Použijte [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/) s [BlobManagementOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/blobmanagementoptions/). Zde nastavíte limit paměti pro BLOB, povolíte nebo zakážete dočasné soubory, vyberete kořenovou cestu pro dočasné soubory a určíte chování zamykání zdroje.

**Ovlivňují nastavení BLOB výkon a jak vyvážit rychlost versus paměť?**

Ano. Udržení BLOB v paměti maximalizuje rychlost, ale zvyšuje spotřebu RAM; snížení limitu paměti přesune více práce do dočasných souborů, snižuje RAM za cenu dodatečného I/O. Použijte metodu [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/cs/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) k dosažení správné rovnováhy pro vaše pracovní zatížení a prostředí.

**Pomáhají možnosti BLOB při otevírání extrémně velkých prezentací (např. gigabajty)?**

Ano. [BlobManagementOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/blobmanagementoptions/) jsou navrženy pro takové scénáře: povolení dočasných souborů a použití zamykání zdroje může výrazně snížit špičkovou spotřebu RAM a stabilizovat zpracování velmi velkých prezentací.

**Mohu použít politiky BLOB při načítání ze streamů místo diskových souborů?**

Ano. Stejná pravidla platí pro streamy: instance prezentace může vlastnit a zamknout vstupní stream (v závislosti na zvoleném režimu zamykání) a dočasné soubory jsou používány, pokud jsou povoleny, což udržuje využití paměti předvídatelné během zpracování.