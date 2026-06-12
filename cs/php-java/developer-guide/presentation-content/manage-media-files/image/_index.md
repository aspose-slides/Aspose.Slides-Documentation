---
title: "Optimalizace správy obrázků v prezentacích pomocí PHP"
linktitle: "Správa obrázků"
type: docs
weight: 10
url: /cs/php-java/image/
keywords:
- přidat obrázek
- přidat obrázek
- přidat bitmapu
- nahradit obrázek
- nahradit obrázek
- z webu
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- přidat EMF
- přidat WMF
- přidat TIFF
- PowerPoint
- OpenDocument
- prezentace
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Zefektivněte správu obrázků v PowerPointu a OpenDocument pomocí Aspose.Slides pro PHP přes Java, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a zajímavějšími. V Microsoft PowerPoint můžete do snímků vložit obrázky ze souboru, internetu nebo jiných míst. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků ve vašich prezentacích různými postupy. 

{{% alert  title="Tip" color="primary" %}} 

Aspose poskytuje bezplatné převodníky—[JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt)—které umožňují rychle vytvořit prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete přidat obrázek jako objekt rámce—zejména pokud plánujete použít standardní možnosti formátování k úpravě jeho velikosti, přidání efektů atd.—podívejte se na [Rámec obrázku](/slides/cs/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Poznámka" color="warning" %}}

Můžete manipulovat s operacemi vstupu/výstupu zahrnujícími obrázky a PowerPoint prezentace pro převod obrázku z jednoho formátu do druhého. Viz tyto stránky: převod [obrázku na JPG](https://products.aspose.com/slides/cs/php-java/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-png/), převod [PNG na JPG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-svg/), převod [SVG na PNG](https://products.aspose.com/slides/cs/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides podporuje operace s obrázky v těchto populárních formátech: JPEG, PNG, GIF a dalších. 

## **Přidání lokálně uložených obrázků do snímků**

Můžete na snímek v prezentaci přidat jeden nebo několik obrázků z vašeho počítače. Tento ukázkový kód vám ukazuje, jak přidat obrázek do snímku:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání obrázků z webu do snímků**

Pokud obrázek, který chcete do snímku přidat, není k dispozici ve vašem počítači, můžete jej přidat přímo z webu. 

Tento ukázkový kód vám ukazuje, jak přidat obrázek z webu do snímku :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání obrázků do hlavních snímků (Slide Masters)**

Hlavní snímek je vrchní snímek, který ukládá a řídí informace (téma, rozvržení, atd.) o všech snímcích pod ním. Když tedy přidáte obrázek do hlavního snímku, tento obrázek se objeví na každém snímku pod tímto hlavním snímkem. 

Tento Java ukázkový kód vám ukazuje, jak přidat obrázek do hlavního snímku:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání obrázků jako pozadí snímků**

Můžete se rozhodnout použít obrázek jako pozadí pro konkrétní snímek nebo několik snímků. V takovém případě se podívejte, jak [nastavit obrázek jako pozadí snímku](/slides/cs/php-java/presentation-background/#set-an-image-as-a-slide-background).

## **Přidání SVG do prezentací**
Můžete přidat nebo vložit jakýkoli obrázek do prezentace pomocí metody [addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addpictureframe/) patřící do třídy [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/).

Pro vytvoření objektu obrázku založeného na SVG obrázku můžete postupovat takto:

1. Vytvořte objekt SvgImage pro vložení do ImageShapeCollection
2. Vytvořte objekt PPImage z ISvgImage
3. Vytvořte objekt PictureFrame pomocí třídy PPImage

Tento ukázkový kód vám ukazuje, jak implementovat výše uvedené kroky pro přidání SVG obrázku do prezentace:
```php
  # Vytvořte instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Převod SVG na sadu tvarů**
Převod SVG na sadu tvarů v Aspose.Slides je podobný funkčnosti PowerPointu používané pro práci s SVG obrázky:

![PowerPoint Popup Menu](img_01_01.png)

Funkčnost je poskytována jednou z přetížených metod [addGroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addgroupshape/) třídy [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/), která přijímá objekt [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/) jako první argument.

Tento ukázkový kód vám ukazuje, jak použít popsanou metodu k převodu SVG souboru na sadu tvarů:

```php
  # Vytvořit novou prezentaci
  $presentation = new Presentation();
  try {
    # Načíst obsah souboru SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Vytvořit objekt SvgImage
    $svgImage = new SvgImage($svgContent);
    # Získat velikost snímku
    $slideSize = $presentation->getSlideSize()->getSize();
    # Převést SVG obrázek na skupinu tvarů a přizpůsobit jej velikosti snímku
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Uložit prezentaci ve formátu PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Přidání obrázků jako EMF do snímků**
Aspose.Slides for PHP via Java umožňuje generovat EMF obrázky z excelových listů a přidávat je jako EMF do snímků pomocí Aspose.Cells. 

Tento ukázkový kód vám ukazuje, jak provést popsaný úkol:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Uložit sešit do proudu
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nahrazení obrázků ve sbírce obrázků**

Aspose.Slides umožňuje nahradit obrázky uložené v kolekci obrázků prezentace (včetně těch, které používají tvary snímků). Tato sekce ukazuje několik přístupů k aktualizaci obrázků v kolekci. API poskytuje jednoduché metody pro nahrazení obrázku pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje.

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Načtěte nový obrázek ze souboru do bajtového pole.
1. Nahraďte cílový obrázek novým obrázkem pomocí bajtového pole.
1. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.
1. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci prezentace existuje.
1. Uložte upravenou prezentaci jako soubor PPTX.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation("sample.pptx");
try {
    // První způsob.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Druhý způsob.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Třetí způsob.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Uložit prezentaci do souboru.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Pomocí Aspose FREE [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) převodníku můžete snadno animovat texty, vytvářet GIFy z textu atd. 

{{% /alert %}}

## **Často kladené otázky**

**Zůstane po vložení původní rozlišení obrázku zachováno?**

Ano. Původní pixely jsou zachovány, ale finální vzhled závisí na tom, jak je [obrázek](/slides/cs/php-java/picture-frame/) škálován na snímku a jaká komprese je aplikována při uložení.

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítkách snímků?**

Umístěte logo na hlavní snímek nebo rozvržení a nahraďte jej v kolekci obrázků prezentace — aktualizace se projeví ve všech prvcích, které tento zdroj používají.

**Může být vložený SVG převeden na editovatelné tvary?**

Ano. SVG můžete převést na skupinu tvarů, po čemž se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvaru.

**Jak nastavit obrázek jako pozadí pro více snímků najednou?**

[Přiřaďte obrázek jako pozadí](/slides/cs/php-java/presentation-background/) na hlavním snímku nebo příslušném rozvržení — všechny snímky používající tento hlavní snímek/rozvržení zdědí pozadí.

**Jak zabránit „nafouknutí“ prezentace kvůli mnoha obrázkům?**

Znovu použijte jediný zdroj obrázku místo duplicit, zvolte rozumná rozlišení, aplikujte kompresi při ukládání a opakovanou grafiku umístěte na hlavní snímek, kde je to vhodné.