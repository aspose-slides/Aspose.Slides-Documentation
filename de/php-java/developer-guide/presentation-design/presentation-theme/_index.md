---
title: Präsentationsthema
type: docs
weight: 10
url: /php-java/presentation-theme/
keywords: "Thema, PowerPoint-Thema, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "PowerPoint-Präsentationsthema"
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen eine spezifische Gruppe von visuellen Elementen und deren Eigenschaften aus.

In PowerPoint umfasst ein Thema Farben, [Schriften](/slides/php-java/powerpoint-fonts/), [Hintergrundstile](/slides/php-java/presentation-background/) und Effekte.

![theme-constituents](theme-constituents.png)

## **Themenfarbe ändern**

Ein PowerPoint-Thema verwendet eine spezifische Gruppe von Farben für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, können Sie die Farben ändern, indem Sie neue Farben für das Thema anwenden. Um Ihnen zu ermöglichen, eine neue Themenfarbe auszuwählen, bietet Aspose.Slides Werte unter der [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor) Enumeration an.

Dieser PHP-Code zeigt Ihnen, wie Sie die Akzentfarbe für ein Thema ändern:

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
  echo(sprintf("Farbe [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));
```

Um die Farbänderungsoperation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ursprünglichen Operation) zu. Dann ändern wir die Farbe im Thema:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themenfarbe aus zusätzlicher Palette festlegen**

Wenn Sie Helligkeitstransformationen auf die Hauptthemenfarbe(1) anwenden, werden Farben aus der zusätzlichen Palette(2) gebildet. Sie können dann diese Themenfarben festlegen und abrufen. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Hauptthemenfarben

**2** - Farben aus der zusätzlichen Palette.

Dieser PHP-Code demonstriert eine Operation, bei der zusätzliche Palettenfarben aus der Hauptthemenfarbe abgeleitet und dann in Formen verwendet werden:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Akzent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Akzent 4, Heller 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Akzent 4, Heller 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Akzent 4, Heller 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Akzent 4, Dunkler 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Akzent 4, Dunkler 50%
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

## **Themen Schriftart ändern**

Um Ihnen die Auswahl von Schriftarten für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen, die in PowerPoint verwendet werden):

* **+mn-lt** - Schriftart Körper Latein (Minor Latin Font)
* **+mj-lt** - Schriftart Überschrift Latein (Major Latin Font)
* **+mn-ea** - Schriftart Körper Ostasiatisch (Minor East Asian Font)
* **+mj-ea** - Schriftart Überschrift Ostasiatisch (Major East Asian Font)

Dieser PHP-Code zeigt Ihnen, wie Sie die lateinische Schriftart einem Themalement zuweisen:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Themen Textformat");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```

Dieser PHP-Code zeigt Ihnen, wie Sie die Schriftart des Präsentationsthemas ändern:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```

Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten vielleicht die [PowerPoint-Schriften](/slides/php-java/powerpoint-fonts/) sehen.

{{% /alert %}}

## **Themen Hintergrundstil ändern**

Standardmäßig bietet die PowerPoint-Anwendung 12 vordefinierte Hintergründe, aber nur 3 dieser 12 Hintergründe werden in einer typischen Präsentation gespeichert. 

![todo:image_alt_text](presentation-design_8.png)

Wenn Sie beispielsweise eine Präsentation in der PowerPoint-Anwendung speichern, können Sie diesen PHP-Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation herauszufinden:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Anzahl der Hintergrundfüllstile für das Thema ist " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Durch die Verwendung der [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) Eigenschaft der [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) Klasse können Sie den Hintergrundstil in einem PowerPoint-Thema hinzufügen oder darauf zugreifen.

{{% /alert %}} 

Dieser PHP-Code zeigt Ihnen, wie Sie den Hintergrund für eine Präsentation festlegen:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Indexanleitung**: 0 wird für keine Füllung verwendet. Der Index beginnt bei 1.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten vielleicht den [PowerPoint-Hintergrund](/slides/php-java/presentation-background/) sehen.

{{% /alert %}}

## **Themen Effekt ändern**

Ein PowerPoint-Thema enthält normalerweise 3 Werte für jedes Stilarray. Diese Arrays sind in diese 3 Effekte kombiniert: subtil, moderat und intensiv. Beispiel: Dies ist das Ergebnis, wenn die Effekte auf eine spezifische Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Mit den 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)) aus der [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) Klasse können Sie die Elemente in einem Thema ändern (sogar flexibler als die Optionen in PowerPoint).

Dieser PHP-Code zeigt Ihnen, wie Sie einen Themaeffekt ändern, indem Sie Teile von Elementen ändern:

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

Die resultierenden Änderungen in Füllfarbe, Fülltyp, Schatteneffekt usw.:

![todo:image_alt_text](presentation-design_11.png)