---
title: Präsentationsthemen in PHP verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/php-java/presentation-theme/
keywords:
- PowerPoint-Theme
- Präsentationsthema
- Folienthema
- Theme festlegen
- Theme ändern
- Theme verwalten
- Theme-Farbe
- Zusätzliche Palette
- Theme-Schriftart
- Theme-Stil
- Theme-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Meistern Sie Präsentationsthemen in Aspose.Slides für PHP via Java, um PowerPoint-Dateien mit konsistenter Markenführung zu erstellen, anzupassen und zu konvertieren."
---
## **Einleitung**

Ein Präsentations‑Theme definiert ein koordiniertes Set aus Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Theme‑bewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Theme‑Wechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentations‑Theme über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) verfügbar. Eine Präsentation kann zudem Theme‑Überschreibungen auf tieferen Ebenen enthalten. Ein Master kann das Präsentations‑Theme über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr vererbtes Theme über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das effektive Theme einer Folie über diese Vererbungskette ermittelt: Präsentations‑Theme, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themenkomponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die häufigsten Theme‑Workflows: ein Theme untersuchen, Farben und Schriftarten ändern, ein Theme kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Überschreibungen lesen.

## **Ein Theme untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, das Schriftartenschema und das Formatschema des Themes über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/mastertheme/) bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stil‑Einträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themes und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Theme gespeichert sind:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Theme hat. Untersuchen Sie den Master, der der Folie zugeordnet ist, und verwenden Sie den später im Artikel gezeigten effektiven‑Theme‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Theme‑Farben ändern**

Theme‑bewusste Füllungen, Linien und Texte können auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/schemecolor/) verweisen. Wenn Sie den entsprechenden Eintrag im [ColorScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/colorscheme/) ändern, werden alle Objekte, die noch auf diese Theme‑Farbe verweisen, auf den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Theme‑Farb‑Update nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die Theme‑Farbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Theme‑Änderung Rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe in der Form, so wirkt sich ein späterer Wechsel von `Accent4` nicht mehr auf diese Füllung aus.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Theme‑Farbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/php-java/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und hellere sowie dunklere aus der zusätzlichen Palette erzeugte Farben](additional-palette-colors.png)

**1** - Hauptthemenfarben.

**2** - Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt werden.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Diese Varianten bleiben an der Theme‑Farbe ausgerichtet. Ändert sich später `Accent4`, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **Zuordnung von `SchemeColor`‑Werten zu `ColorScheme`‑Plätzen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [ColorScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/colorscheme/) dieselben Theme‑Plätze als `Dark1`, `Light1`, `Dark2` und `Light2` expose. Die Zuordnung ist festgelegt:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Theme‑Plätze; es handelt sich nicht um Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Theme‑Schriftarten ändern**

Ein Theme‑Schriftartenschema enthält ein Hauptschriftartenset für Überschriften und ein Nebenschriftartenset für Fließtext. Die Methoden [FontScheme.getMajor](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontscheme/) und [FontScheme.getMinor](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontscheme/) stellen diese Sets bereit.

PowerPoint‑kompatible Theme‑Schriftarten‑Identifier können in der Textformatierung verwendet werden:

* `+mn‑lt` – Body‑Font Latin (Minor Latin Font)
* `+mj‑lt` – Heading‑Font Latin (Major Latin Font)
* `+mn‑ea` – Body‑Font East Asian (Minor East Asian Font)
* `+mj‑ea` – Heading‑Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Theme‑Schriftart verwendet, und eine Textzeile, die die Neben‑Latin‑Theme‑Schriftart nutzt. Anschließend werden die Theme‑Schriftarten geändert und das Ergebnis gespeichert:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Überschrift folgt der Hauptschriftart und der Fließtext der Neben­schriftart. Text, dem ein expliziter Schriftname anstelle eines Theme‑Identifiers zugewiesen ist, wechselt nicht automatisch, wenn das Theme‑Schriftartenschema geändert wird.

Die Haupt‑ und Neben‑Schriftartensammlungen können zudem Zuordnungen für einzelne Schriftsysteme wie Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana enthalten. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Theme kopieren oder anwenden**

Es gibt zwei gängige Workflows, die unterschiedliche Probleme lösen.

### **Quell‑Theme beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design bewahren, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/), dann klonen Sie die Folie mit [SlideCollection.addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/) und dem geklonten Master. Dadurch werden Master, Layouts und das zugehörige Theme gemeinsam übernommen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das reine Klonen von Inhalten auf einen nicht zugehörigen Ziel‑Master kann Theme‑gesteuerte Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Theme‑Werte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Theme. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/overridetheme/) kopieren die drei Hauptelemente des Themes in die Überschreibung.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Damit wird das von dieser Folie genutzte Theme geändert, ohne das von anderen Folien geerbte Theme zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/overridetheme/) auf.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie den Stil‑Index **nicht** als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem, eine Stil‑Nummer aus einer Datei hart zu codieren und anzunehmen, dass sie in einer anderen Datei das gleiche Aussehen hat; Theme‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}
Für direkte Hintergrundformatierung und Hintergrundvererbung siehe [Presentation Background](/slides/de/php-java/presentation-background/).
{{% /alert %}}

### **Theme‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Überschreibung gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie keine eigene Überschreibung besitzt. Die selben Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslidethememanager/) verwendet werden:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Verwenden Sie ein Master‑ oder Präsentations‑Theme, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein anderes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Zu viele Folien‑Überschreibungen erschweren spätere globale Theme‑Änderungen.

## **Theme‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themes werden in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/formatscheme/) gespeichert. PowerPoint kann in seiner Benutzeroberfläche mehr Hintergrund‑Optionen anbieten, als tatsächlich in dieser Sammlung definiert sind, weil die UI Theme‑Füllungen mit Theme‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstilgalerie für ein Präsentations‑Theme](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/php-java/aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine thematisierte Füllung; positive Werte sind Referenzen auf Theme‑Hintergrundstile. Das unterscheidet sich von der direkten Indizierung der PHP‑Sammlung, bei der `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllungsstilen enthält.

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das sichtbare Ergebnis hängt vom Theme‑Eintrag ab, auf den der Master verweist, sowie von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene. Verwendet eine Folie ihren eigenen Hintergrund, wirkt sich nur das Ändern des Master‑Hintergrunds möglicherweise nicht aus. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/background/), wenn Sie den endgültigen Hintergrund nach Anwendung der Vererbung wissen müssen.

{{% alert color="info" title="Hinweis" %}}
Behandeln Sie den Stil‑Index nicht als nullbasierten Sammlungs‑Index. Und vermeiden Sie das Hard‑Coden einer Stil‑Nummer aus einer Datei, weil Theme‑Stil‑Definitionen presentationsspezifisch sind.
{{% /alert %}}

## **Theme‑Effekte aktualisieren**

Ein Theme‑Formatschema enthält getrennte Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [FormatScheme.getFillStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/formatscheme/) und [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/formatscheme/) bereitgestellt werden. Typische Office‑Themes enthalten oft drei Hauptstil‑Einträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Theme‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Greifen Sie in PHP auf diese Sammlungen zu, ist der Sammlungs‑Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil und `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [ShapeStyle](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapestyle/) bereitgestellt wird. Das Ändern eines Theme‑Stils wirkt sich auf Formen aus, die diesen Theme‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Für Formen, die diese Plätze referenzieren, wird der erste Theme‑Linienstil rot, der dritte Theme‑Füllstil wird zu einem satten Waldgrün und dem dritten Effekt‑Stil wird ein äußerer Schatten mit einem Abstand von 10 Punkten hinzugefügt. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung die Theme‑Einstellungen überschreibt.

![Theme‑Effektstile nach Änderung von Linie, Füllung und Schatteneinstellungen](presentation-design_11.png)

## **Effektive Theme‑Werte lesen**

Roh‑Theme‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Überschreibungen aufgelöst wurden. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Untersuchen Sie ausschließlich [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/), können Sie Master‑, Layout‑, Folien‑ oder Form‑Überschreibungen übersehen, die das endgültige Erscheinungsbild ändern.

## **FAQ**

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Theme. Die Änderung bleibt lokal auf dieser Folie; andere Folien erben weiterhin ihre bestehenden Themes.

**Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren möchten, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/) und [SlideCollection.addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/). Dadurch bleiben Master, Layouts und Theme zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Theme und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen zurück.