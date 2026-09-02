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
- Theme setzen
- Theme ändern
- Theme verwalten
- externes Theme
- THMX
- Theme-Farbe
- zusätzliche Palette
- Theme-Schriftart
- Theme-Stil
- Theme-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für PHP via Java erstellen, anpassen und PowerPoint-Dateien mit konsistenter Markenführung konvertieren."
---
## **Einleitung**

Ein Präsentationsthema definiert einen koordinierten Satz von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themenaware Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das themenbezogene Präsentations‑Theme über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) verfügbar. Eine Präsentation kann außerdem Theme‑Overrides auf tieferen Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr vererbtes Theme über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das effektive Theme einer Folie über diese Vererbungskette aufgelöst: Präsentationstheme, Master‑Override, Layout‑Override und Folien‑Override.

![Theme‑Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Theme‑Workflows: ein Theme inspizieren, Farben und Schriftarten ändern, ein Theme kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Overrides auslesen.

## **Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, das Schriftartenschema und das Formatschema über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/mastertheme/) bereit. Das Inspizieren dieser Sammlungen, bevor Änderungen vorgenommen werden, ist besonders nützlich, wenn die Präsentation aus einer externen Quelle stammt, weil die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die wichtigsten Theme‑Eigenschaften aus und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Theme gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Theme hat. Untersuchen Sie den Master, der der Folie zugeordnet ist, und verwenden Sie den im weiteren Verlauf gezeigten effektiven‑Theme‑Workflow, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Theme‑Farben ändern**

Themenaware Füllungen, Linien und Texte können auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/schemecolor/) verweisen. Wenn Sie den entsprechenden Eintrag im [ColorScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/colorscheme/) ändern, werden alle Objekte, die noch auf diese Theme‑Farbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden von einem Theme‑Farb‑Update nicht beeinflusst.

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung Rot. Ersetzen Sie die Schemafarbe durch eine direkte Farbe auf der Form, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint erzeugt hellere und dunklere Varianten einer Theme‑Farbe durch Farbtransformationen. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/php-java/aspose.slides/colortransformoperation/) bereit.

![Haupt‑Theme‑Farben sowie hellere und dunklere Farben, die aus der zusätzlichen Palette erzeugt wurden](additional-palette-colors.png)

**1** – Haupt‑Theme‑Farben.  
**2** – Hellere und dunklere Varianten, die aus den Haupt‑Theme‑Farben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke basierend auf `Accent4`, wendet Luminanz‑Transformationen auf fünf von ihnen an und speichert das Ergebnis:

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

Diese Varianten bleiben auf der Theme‑Farbe basiert. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während das [ColorScheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/colorscheme/) dieselben Theme‑Plätze als `Dark1`, `Light1`, `Dark2` und `Light2` exponiert. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Theme‑Plätze; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Theme‑Schriftarten ändern**

Ein Theme‑Schriftartenschema enthält einen Hauptschriftset für Überschriften und einen Neben‑Schriftset für Fließtext. Die Methoden [FontScheme.getMajor](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontscheme/) und [FontScheme.getMinor](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontscheme/) geben diese Sets frei.

PowerPoint‑kompatible Theme‑Schriftart‑Identifier können in der Textformatierung verwendet werden:

* `+mn-lt` – Body‑Font Latin (Minor Latin Font)
* `+mj-lt` – Heading‑Font Latin (Major Latin Font)
* `+mn-ea` – Body‑Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading‑Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Theme‑Schriftart verwendet, und eine Textzeile, die die Neben‑Latin‑Theme‑Schriftart verwendet. Anschließend werden die Theme‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschriftart und der Fließtext der Neben­schriftart. Text, der einen expliziten Schriftartnamen anstelle eines Theme‑Identifiers enthält, wechselt nicht automatisch, wenn das Theme‑Schriftartenschema geändert wird.

Die Haupt‑ und Neben‑Schriftartensammlungen können zudem Zuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Ein Theme kopieren oder anwenden**

Die nachfolgenden Workflows lösen verschiedene themenbezogene Probleme.

### **Ein externes Theme auf die von einem Master abhängigen Folien anwenden**

Verwenden Sie [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/), wenn Sie eine PowerPoint‑Theme‑Datei (`.thmx`) besitzen und jede Folie, die von einem bestimmten Master abhängt, neu stylen wollen. Wählen Sie den Master aus der [Presentation::getMasters](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Sammlung, die durch [MasterSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/) repräsentiert wird, und übergeben Sie den Pfad zur Theme‑Datei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folien‑Instanz basierend auf dem ausgewählten Master.  
1. Wendet das externe Theme auf den neuen Master an.  
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.  
1. Gibt das neu erstellte [MasterSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) zurück.

Das folgende Beispiel wendet ein externes Theme auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ein ungültiges, beschädigtes oder nicht unterstütztes Theme kann eine [PptxReadException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxreadexception/) auslösen. Validieren Sie Pfade, die von Benutzern bereitgestellt werden, behandeln Sie Zugriffsfehler auf das Dateisystem und speichern Sie die Präsentation erst, nachdem das Theme erfolgreich angewendet wurde.

Nur die Folien, die vom gewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themes. Theme‑aware Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Theme aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formate können unverändert bleiben. Overrides auf Layout‑ und Folien‑Ebene können ebenfalls Vorrang vor den vom neuen Master geerbten Werten haben.

Das Theme kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistente Darstellung und Export installieren Sie die erforderlichen Schriftarten, stellen Sie sie über [custom font sources](/slides/de/php-java/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/php-java/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert kein manuelles Erstellen von Folien‑ oder Layout‑Overrides.

### **Unterschiedliche externe Themes in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [Slide::getLayoutSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/) und [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themes anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, um deren Master zu finden, und wendet jedem Abschnitt ein unterschiedliches externes Theme an:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Der erste Aufruf wirkt nur auf Folien, die von `$firstGroupMaster` abhängen, der zweite Aufruf nur auf Folien, die von `$secondGroupMaster` abhängen. Folien, die zu einem anderen Master gehören, bleiben unverändert.

### **Ein Quell‑Theme beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/), anschließend klonen Sie die Folie mit [SlideCollection.addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/) und dem geklonten Master. Dadurch werden Master, seine Layouts und das zugehörige Theme gemeinsam übertragen.

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

Dies ist der empfohlene Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen muss. Das reine Klonen von Inhalten auf einen fremden Ziel‑Master kann Theme‑abhängige Farben, Schriftarten, Hintergründe und Effekte verändern.

### **Theme‑Werte auf eine bestehende Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout verbleiben, initialisieren Sie einen Folien‑Level‑Override aus dem Quell‑Theme. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/overridetheme/) kopieren die drei Haupt‑Theme‑Komponenten in den Override.

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

Damit wird das von dieser Folie genutzte Theme geändert, ohne das von anderen Folien geerbte Theme zu beeinflussen. Um den lokalen Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/overridetheme/) auf.

### **Ein Theme‑Override auf ein Layout anwenden**

Ein Layout‑Level‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie keinen eigenen Override besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Theme, wenn viele Layouts und Folien dasselbe Basiskonzept teilen sollen; ein Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt; und ein Folien‑Override nur für echte Ausnahmen. Zu viele Folien‑Overrides erschweren spätere globale Theme‑Änderungen.

## **Theme‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen eines Themes werden in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/formatscheme/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anbieten, als tatsächlich Füllungsdefinitionen in dieser Sammlung vorhanden sind, weil das UI Theme‑Füllungen mit Theme‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstil‑Galerie für ein Präsentations‑Theme](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, inspizieren Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/php-java/aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine themenbasierte Füllung; positive Werte sind Referenzen auf Theme‑Hintergrundstile. Das unterscheidet sich von der direkten Indizierung der PHP‑Sammlung, bei der `get_Item(0)` das erste gespeicherte Element liefert. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl an Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbasierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom Theme‑Eintrag ab, den der Master referenziert, sowie von möglichen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene. Verwendet eine Folie ihren eigenen Hintergrund, ändert das Anpassen des Master‑Hintergrunds möglicherweise nicht diese Folie. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/background/), wenn Sie den endgültigen Hintergrund nach Vererbung kennen müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie den Stil‑Index nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coden einer Stild‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei identisch aussieht; Theme‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/php-java/presentation-background/).
{{% /alert %}}

## **Theme‑Effekte aktualisieren**

Ein Theme‑Formatschema enthält separate Sammlungen für Füll‑, Linien‑ und Effektstile, die über [FormatScheme.getFillStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/formatscheme/) und [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/php-java/aspose.slides/formatscheme/) bereitgestellt werden. Typische Office‑Themes enthalten häufig drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Theme‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Greift man in PHP auf diese Sammlungen zu, ist der Sammlungs‑Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil, `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form bilden ein separates Konzept, das über [ShapeStyle](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapestyle/) zugänglich ist. Das Ändern eines Theme‑Stils wirkt sich auf Formen aus, die diesen Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die benötigten Stile vorhanden sind, ändert den ersten Linienstil, den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effektstil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Theme‑Linienstil rot, der dritte Theme‑Füllstil einfarbig Waldgrün und der dritte Effektstil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung den Theme‑Stil überschreibt.

![Theme‑Effektstile nach Änderung von Linie, Füllung und Schatteneinstellungen](presentation-design_11.png)

## **Ermitteln, ob eine effektive einfarbige Füllung ein Theme‑Farb verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder von einem Absatz, Layout, Master, Theme‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [FillFormat::getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/) auf, um diese Hierarchie in unveränderliche effektive Fülldaten aufzulösen. Prüfen Sie zuerst das Ergebnis von `getFillType`. Nur wenn es `FillType::Solid` ist, sollten Sie die einfarbigen Füllparameter auslesen.

Für eine einfarbige Füllung liefert `getSolidFillColor` den endgültigen gerenderten RGB‑Wert nach Vererbung, Theme‑Lookup und Farb‑Transformationen. Die Methode `getSolidFillSchemeColor` gibt das entsprechende logische [SchemeColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/schemecolor/)‑Slot zurück, z. B. `Text1` oder `Accent6`. Ein Wert von `SchemeColor::NotDefined` bedeutet, dass die effektive einfarbige Füllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, bei dem Füllungen entweder Theme‑Farben oder direkte RGB‑Farben sind, kennzeichnet dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/colorformat/)‑Wert, um eine Füllung zu klassifizieren. Beispielsweise kann ein Textabschnitt keinen lokal definierten SchemeColor haben (`NotDefined`), während seine effektive Füllung ein Theme‑Farb‑Slot wie `Text1` oder `Accent6` ist. Umgekehrt gibt `getSolidFillSchemeColor` an, welches logische Theme‑Slot die effektive Farbe erzeugt hat, jedoch nicht, von welcher Ebene (Objekt, Absatz, Layout, Master usw.) es stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitts‑Füllungen, gibt jeden endgültigen RGB‑Wert und das zugehörige Scheme‑Color aus und markiert einfarbige Füllungen, die Theme‑Farbänderungen nicht folgen:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Der `NotDefined`‑Zweig liefert eine Prüf­liste einfarbiger Füllungen, die nicht auf Theme‑Farben reagieren. Prüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Erscheinungsbild, während der Scheme‑Wert erklärt, ob das Erscheinungsbild mit dem Theme verbunden ist.

Effektive‑Format‑Objekte sind Momentaufnahmen. Nach einer Änderung des Präsentations‑Themes, eines Theme‑Overrides oder beliebiger vererbter Formatierungen rufen Sie erneut `getEffective` auf und lesen die neuen effektiven Fülldaten, bevor Sie Farben vergleichen oder melden.

## **Effektive Theme‑Werte auslesen**

Roh‑Theme‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Overrides verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/).

Das folgende Beispiel liest das effektive Theme, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) inspizieren, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Override übersehen, der das endgültige Erscheinungsbild ändert.

## **FAQ**

**Hat das Anwenden eines externen Themes Auswirkungen auf jede Folie der Präsentation?**

Nein. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) weist nur die Folien zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themes.

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Theme. Die Änderung bleibt lokal auf dieser Folie; andere Folien erben weiterhin ihre bestehenden Themes.

**Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übertragen?**

Beim Verschieben einer Folie und dem Erhalt ihres Quell‑Erscheinungsbildes klonen Sie den Quell‑Master in das Ziel und klonen die Folie mit diesem Master mittels [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/) und [SlideCollection.addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/). Dadurch bleiben Master, Layouts und Theme zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Theme sowie die zugehörigen effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Overrides zurück.