---
title: Hantera presentationsformer i PHP
linktitle: Formmanipulering
type: docs
weight: 40
url: /sv/php-java/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta interop-form-ID
- formens alternativa text
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig att skapa, redigera och optimera former i Aspose.Slides för PHP via Java och leverera högpresterande PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med former i presentationer med Aspose.Slides. Den visar hur man hittar en form på en bild, klonar den, tar bort den, döljer den, ändrar dess ordning, hämtar dess Interop‑form‑ID och anger alternativ text för identifiering och vidare behandling.

Den behandlar också hur man får åtkomst till layoutformat för former, renderar en form som SVG, justerar former på en bild och använder vändningsegenskaper för horisontell och vertikal spegling. Dessutom innehåller artikeln en kort FAQ om kombination av former, staplingsordning och låsning av former.

## **Hitta en form på en bild**
Detta ämne beskriver en enkel teknik för att underlätta för utvecklare att hitta en specifik form på en bild utan att använda dess interna ID. Det är viktigt att veta att PowerPoint‑presentationer inte har något sätt att identifiera former på en bild förutom ett internt unikt ID. Det kan vara svårt för utvecklare att hitta en form med dess interna unika ID. Alla former som lagts till på bilderna har någon alternativ text. Vi rekommenderar utvecklare att använda alternativ text för att hitta en specifik form. Du kan använda MS PowerPoint för att definiera den alternativa texten för objekt som du planerar att ändra i framtiden.

När du har angett den alternativa texten för en önskad form kan du öppna presentationen med Aspose.Slides för PHP via Java och iterera genom alla former som lagts till på en bild. Vid varje iteration kan du kontrollera formens alternativa text och formen med matchande alternativ text är den form du söker. För att demonstrera denna teknik på ett bättre sätt har vi skapat en metod, [findShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) som löser uppgiften att hitta en specifik form på en bild och sedan helt enkelt returnerar den formen.

```php
  # Instansiera en Presentation-klass som representerar presentationsfilen
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Alternativ text för den form som ska hittas
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Klona en form**
För att klona en form till en bild med Aspose.Slides för PHP via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta referensen till en bild genom att använda dess index.
3. Få åtkomst till källbildens formsamling.
4. Lägg till en ny bild i presentationen.
5. Klona former från källbildens formsamling till den nya bilden.
6. Spara den modifierade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

```php
  # Instansiera Presentation-klass
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Skriv PPTX-filen till disk
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ta bort en form**
Aspose.Slides för PHP via Java låter utvecklare ta bort vilken form som helst. För att ta bort formen från en bild, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Få åtkomst till den första bilden.
3. Hitta formen med specifik AlternativeText.
4. Ta bort formen.
5. Spara filen till disk.

```php
  # Skapa Presentation-objekt
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till autoshape av rektangeltyp
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Spara presentationen till disk
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dölj en form**
Aspose.Slides för PHP via Java låter utvecklare dölja vilken form som helst. För att dölja formen från en bild, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Få åtkomst till den första bilden.
3. Hitta formen med specifik AlternativeText.
4. Dölj formen.
5. Spara filen till disk.

```php
  # Instansiera Presentation-klass som representerar PPTX
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till autoshape av rektangeltyp
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Spara presentationen till disk
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra formordning**
Aspose.Slides för PHP via Java låter utvecklare omordna formerna. Att omordna en form bestämmer vilken form som är längst fram eller längst bak. För att omordna formerna på en bild, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Få åtkomst till den första bilden.
3. Lägg till en form.
4. Lägg till lite text i formens textruta.
5. Lägg till en annan form med samma koordinater.
6. Omordna formerna.
7. Spara filen till disk.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hämta Interop‑form‑ID**
Aspose.Slides för PHP via Java låter utvecklare få ett unikt formidentifierare på bildnivå i motsats till metoden [getUniqueId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getuniqueid/) som ger ett unikt identifierare på presentationsnivå. Metoden [getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getofficeinteropshapeid/) har lagts till i klassen [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/). Värdet som returneras av metoden [getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getofficeinteropshapeid/) motsvarar Id‑värdet för Microsoft.Office.Interop.PowerPoint.Shape‑objektet. Nedan ges ett exempel på kod.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Hämtar unikt formidentifierare i bildnivå
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange alternativ text för en form**
Aspose.Slides för PHP via Java låter utvecklare ange AlternateText för vilken form som helst.
Former i en presentation kan särskiljas med `Alternative Text` eller metoden [Shape Name](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/setname/).
Metoderna [setAlternativeText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/setalternativetext/) och [getAlternativeText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getalternativetext/) kan läsas eller skrivas med Aspose.Slides såväl som Microsoft PowerPoint.
Genom att använda denna metod kan du märka en form och utföra olika operationer som att ta bort en form,
dölja en form eller omordna former på en bild.
För att ange AlternateText för en form, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Få åtkomst till den första bilden.
3. Lägg till någon form på bilden.
4. Utför någon operation med den nylagda formen.
5. Gå igenom formerna för att hitta en form.
6. Sätt AlternativeText.
7. Spara filen till disk.

```php
  # Instansiera Presentation-klass som representerar PPTX
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till autoshape av rektangeltyp
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Spara presentationen till disk
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Få åtkomst till layoutformat för en form**
Aspose.Slides för PHP via Java erbjuder ett enkelt API för att komma åt layoutformat för en form. Denna artikel visar hur du kan komma åt layoutformat.

Nedan ges exempel på kod.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rendera en form som SVG**
Nu har Aspose.Slides för PHP via Java stöd för att rendera en form som SVG. Metoden [writeAsSvg](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/writeassvg/) (och dess överlagring) har lagts till i klassen [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/). Denna metod möjliggör att spara formens innehåll som en SVG‑fil. Kodsnutten nedan visar hur du exporterar en bilds form till en SVG‑fil.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Justera en form**
Aspose.Slides möjliggör att justera former antingen i förhållande till bildens marginaler eller i förhållande till varandra. För detta ändamål har den överlagrade metoden [SlidesUtil::alignShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/alignshapes/) lagts till. Uppräkningen [ShapesAlignmentType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapesalignmenttype/) definierar möjliga justeringsalternativ.

**Example 1**

Källkoden nedan justerar former med index 1,2 och 4 längs bildens överkant.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Example 2**

Exemplet nedan visar hur du justerar hela samlingen av former i förhållande till den nedersta formen i samlingen.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Flip Properties**

I Aspose.Slides ger klassen [ShapeFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapeframe/) kontroll över horisontell och vertikal spegling av former via dess `flipH`‑ och `flipV`‑egenskaper. Båda egenskaperna är av typen [NullableBool](https://reference.aspose.com/slides/sv/php-java/aspose.slides/nullablebool/), vilket tillåter värdena `True` för att ange en spegling, `False` för ingen spegling, eller `NotDefined` för att använda standardbeteendet. Dessa värden är åtkomliga via en forms [Frame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getFrame).

För att ändra speglingsinställningarna skapas en ny [ShapeFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapeframe/)‑instans med formens nuvarande position och storlek, önskade värden för `flipH` och `flipV` samt rotationsvinkeln. Genom att tilldela denna instans till formens [Frame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getFrame) och spara presentationen tillämpas speglingstransformationerna och lagras i utdatafilen.

Anta att vi har en sample.pptx‑fil där den första bilden innehåller en enda form med standardinställningar för spegling, som visas nedan.

![Formen som ska vändas](shape_to_be_flipped.png)

Följande kodexempel hämtar formens aktuella speglingsegenskaper och vänder den både horisontellt och vertikalt.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Hämta den horisontella vändningsegenskapen för formen.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Hämta den vertikala vändningsegenskapen för formen.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Vänd horisontellt.
    $flipV = NullableBool::True; // Vänd horisontellt.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Den vända formen](flipped_shape.png)

## **FAQ**

**Kan jag kombinera former (union/intersect/subtract) på en bild som i ett skrivbordsredigeringsprogram?**

Det finns inget inbyggt API för booleska operationer. Du kan approximera det genom att själva konstruera önskad kontur – exempelvis beräkna den resulterande geometrin (via [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometrypath/)) och skapa en ny form med den konturen, eventuellt ta bort de ursprungliga.

**Hur kan jag kontrollera staplingsordningen (z-order) så att en form alltid förblir "överst"?**

Ändra infognings-/flyttningsordningen inom bildens [shapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getShapes)-samling. För förutsägbara resultat, avsluta z‑ordningen efter alla andra bildändringar.

**Kan jag "låsa" en form för att hindra användare från att redigera den i PowerPoint?**

Ja. Ställ in skyddsflaggor på formenivå (t.ex. lås markering, flytt, storleksändring, textredigering). Om så behövs, spegla begränsningarna på mastern eller layouten. Observera att detta är skydd på UI‑nivå, inte en säkerhetsfunktion; för starkare skydd kombinera med filnivåbegränsningar som [read‑only‑rekommendationer eller lösenord](/slides/sv/php-java/password-protected-presentation/).