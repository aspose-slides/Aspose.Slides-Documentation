---
title: Präsentationsthemen in PHP verwalten
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
- Themenschriftart
- Themenstil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Präsentationsthemen in Aspose.Slides für PHP über Java, um PowerPoint-Dateien mit konsequenter Markenidentität zu erstellen, anzupassen und zu konvertieren."
---
Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriftarten](/slides/de/php-java/powerpoint-fonts/), [Hintergrundstilen](/slides/de/php-java/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Themafarbe ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Themafarbe zu ermöglichen, stellt Aspose.Slides Werte aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/SchemeColor) bereit.

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
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

Um die Farbänderungsoperation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Danach ändern wir die Farbe im Thema:
```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themafarbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanz-Transformationen auf die Hauptthemafarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Sie können diese Themafarben dann festlegen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hauptthemafarben

**2** - Farben aus der zusätzlichen Palette.

Dieser PHP-Code demonstriert einen Vorgang, bei dem Farben aus der zusätzlichen Palette aus der Hauptthemafarbe gewonnen und anschließend in Formen verwendet werden:
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

### **`SchemeColor` zu `ColorScheme`-Farben zuordnen**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/schemecolor/) arbeiten, werden Sie feststellen, dass es die folgenden Themenfarbwerte enthält:
`Background1`, `Background2`, `Text1` und `Text2`.

Allerdings liefert `Presentation::getMasterTheme()::getColorScheme()` [ColorScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/colorscheme/), das die entsprechenden Farben wie folgt bereitstellt:
`Dark1`, `Dark2`, `Light1` und `Light2`.

Dieser Unterschied besteht nur in der Benennung. Diese Werte beziehen sich auf dieselben Themenfarbplätze und die Zuordnung ist festgelegt:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Es gibt keine dynamische Umwandlung zwischen `Text`/`Background` und `Dark`/`Light`. Sie sind lediglich alternative Namen für dieselben Themenfarben.

Dieser Namensunterschied stammt aus der Terminologie von Microsoft Office. Ältere Office-Versionen verwendeten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere UI-Versionen dieselben Plätze als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Thema-Schriftart ändern**

Um Ihnen die Auswahl von Schriftarten für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen, die in PowerPoint verwendet werden):

* **+mn-lt** - Körper-Schriftart Latein (Minor Latin Font)
* **+mj-lt** - Überschrift-Schriftart Latein (Major Latin Font)
* **+mn-ea** - Körper-Schriftart Ostasiatisch (Minor East Asian Font)
* **+mj-ea** - Körper-Schriftart Ostasiatisch (Major East Asian Font)

Dieser PHP-Code zeigt Ihnen, wie Sie die lateinische Schriftart einem Thema-Element zuweisen:
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

Dieser PHP-Code zeigt Ihnen, wie Sie die Schriftart des Präsentationsthemas ändern:
```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie sich [PowerPoint-Schriftarten](/slides/de/php-java/powerpoint-fonts/) ansehen.
{{% /alert %}}

## **Thema-Hintergrundstil ändern**

Standardmäßig stellt die PowerPoint-App 12 vordefinierte Hintergründe bereit, aber in einer typischen Präsentation werden nur 3 dieser 12 Hintergründe gespeichert.

![todo:image_alt_text](presentation-design_8.png)

Beispielsweise können Sie nach dem Speichern einer Präsentation in der PowerPoint-App diesen PHP-Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:
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
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) der Klasse [FormatScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/FormatScheme) können Sie den Hintergrundstil in einem PowerPoint-Thema hinzufügen oder darauf zugreifen.
{{% /alert %}} 

Dieser PHP-Code zeigt Ihnen, wie Sie den Hintergrund für eine Präsentation festlegen:
```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Index-Anleitung**: 0 wird für keine Füllung verwendet. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie sich [PowerPoint-Hintergrund](/slides/de/php-java/presentation-background/) ansehen.
{{% /alert %}}

## **Thema-Effekt ändern**

Ein PowerPoint-Thema enthält typischerweise 3 Werte für jedes Stil-Array. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:
![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/FormatScheme#getEffectStyles--)) der Klasse [FormatScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/FormatScheme) können Sie die Elemente in einem Thema ändern (noch flexibler als die Optionen in PowerPoint).

Dieser PHP-Code zeigt Ihnen, wie Sie einen Thema-Effekt ändern, indem Sie Teile von Elementen verändern:
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

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Aspose.Slides unterstützt Themenüberschreibungen auf Folienebene, sodass Sie ein lokales Thema nur auf diese Folie anwenden können, während das Master-Thema unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidethememanager/)).

**Was ist die sicherste Methode, ein Thema von einer Präsentation in eine andere zu übertragen?**

[Clone slides](/slides/de/php-java/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben der ursprüngliche Master, Layouts und das zugehörige Thema erhalten, sodass das Aussehen konsistent bleibt.

**Wie kann ich die "effektiven" Werte nach allen Vererbungen und Überschreibungen sehen?**

Verwenden Sie die ["effective" views](/slides/de/php-java/shape-effective-properties/) der API für Thema/Farbe/Schriftart/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem der Master sowie etwaige lokale Überschreibungen angewendet wurden.