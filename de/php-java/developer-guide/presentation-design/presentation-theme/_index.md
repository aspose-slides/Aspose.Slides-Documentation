---
title: Verwalten von Präsentationsthemen in PHP
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/php-java/presentation-theme/
keywords:
- PowerPoint-Thema
- Präsentationsthema
- Folienthema
- Thema festlegen
- Thema ändern
- Thema verwalten
- Themenfarbe
- zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Master-Präsentationsthemen in Aspose.Slides für PHP via Java, um PowerPoint-Dateien mit einheitlichem Branding zu erstellen, anzupassen und zu konvertieren."
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriften](/slides/de/php-java/powerpoint-fonts/), [Hintergrundstilen](/slides/de/php-java/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Theme-Farbe ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, können Sie sie ändern, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Theme-Farbe zu ermöglichen, stellt Aspose.Slides Werte aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor) bereit.

Dieser PHP-Code zeigt, wie Sie die Akzentfarbe für ein Thema ändern:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


So können Sie den effektiven Wert der resultierenden Farbe bestimmen:
```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```


Um den Farbwechsel weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Anschließend ändern wir die Farbe im Thema:
```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```


Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Theme-Farbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanz‑Transformationen auf die Haupt‑Theme‑Farbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Diese Theme‑Farben können Sie dann setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** – Haupt‑Theme‑Farben  
**2** – Farben aus der zusätzlichen Palette.

Dieser PHP-Code demonstriert einen Vorgang, bei dem Farben der zusätzlichen Palette aus der Haupt‑Theme‑Farbe gewonnen und anschließend in Formen verwendet werden:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Akzent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Akzent 4, 80% heller
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Akzent 4, 60% heller
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Akzent 4, 40% heller
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Akzent 4, 25% dunkler
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Akzent 4, 50% dunkler
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Theme‑Schriftart ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Kennungen (ähnlich denen, die in PowerPoint verwendet werden):

* **+mn-lt** – Fließtextschrift Latein (Minor Latin Font)  
* **+mj-lt** – Überschriftenschrift Latein (Major Latin Font)  
* **+mn-ea** – Fließtextschrift Ostasiatisch (Minor East Asian Font)  
* **+mj-ea** – Fließtextschrift Ostasiatisch (Major East Asian Font)

Dieser PHP-Code zeigt, wie Sie die lateinische Schrift einer Theme‑Komponente zuweisen:
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```


Dieser PHP-Code zeigt, wie Sie die Theme‑Schriftart der Präsentation ändern:
```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```


Die Schrift in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie sich die [PowerPoint-Schriften](/slides/de/php-java/powerpoint-fonts/) ansehen. 
{{% /alert %}}

## **Theme‑Hintergrundstil ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, von denen in einer typischen Präsentation nur 3 gespeichert werden. 

![todo:image_alt_text](presentation-design_8.png)

Zum Beispiel können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App diesen PHP-Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" %}} 
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) der Klasse [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) können Sie den Hintergrundstil in einem PowerPoint‑Theme hinzufügen oder darauf zugreifen. 
{{% /alert %}} 

Dieser PHP-Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:
```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```


**Index‑Hinweis**: 0 wird für keine Füllung verwendet. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie sich den [PowerPoint-Hintergrund](/slides/de/php-java/presentation-background/) ansehen. 
{{% /alert %}}

## **Theme‑Effekt ändern**

Ein PowerPoint‑Theme enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Beispielhaft ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Mit den 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)) der Klasse [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) können Sie die Elemente eines Themes ändern (noch flexibler als die Optionen in PowerPoint).

Dieser PHP-Code zeigt, wie Sie einen Theme‑Effekt ändern, indem Sie Teile von Elementen anpassen:
```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Die daraus resultierenden Änderungen bei Füllfarbe, Fülltyp, Schatteneffekt usw.:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne das Master‑Theme zu ändern?**  
Ja. Aspose.Slides unterstützt Theme‑Überschreibungen auf Folienebene, sodass Sie ein lokales Theme nur auf diese Folie anwenden können, während das Master‑Theme unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/)).

**Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übernehmen?**  
[Folien klonen](/slides/de/php-java/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben der ursprüngliche Master, die Layouts und das zugehörige Theme erhalten, sodass das Aussehen konsistent bleibt.

**Wie kann ich die "effektiven" Werte nach allen Vererbungen und Überschreibungen sehen?**  
Verwenden Sie die "effektiven" Ansichten der API ([\"effective\" views](/slides/de/php-java/shape-effective-properties/)) für Theme/Farbe/Schrift/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem der Master und etwaige lokale Überschreibungen angewendet wurden.