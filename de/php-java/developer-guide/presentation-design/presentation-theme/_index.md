---
title: Verwalten von Präsentationsthemen in PHP
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/php-java/presentation-theme/
keywords:
- PowerPoint-Thema
- Präsentations-Thema
- Folien-Thema
- Thema festlegen
- Thema ändern
- Thema verwalten
- externes Thema
- THMX
- Themenfarbe
- zusätzliche Palette
- Themen-Schrift
- Themen-Stil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für PHP über Java, um PowerPoint-Dateien mit konsistenter Marken-Identität zu erstellen, anzupassen und zu konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert einen koordinierten Satz von Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Theme‑aware‑Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentation‑ebene‑Thema über [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) verfügbar. Eine Präsentation kann auch Themen‑Overrides auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das wirksame Thema einer Folie durch folgende Vererbungskette ermittelt: Präsentationsthema, Master‑Override, Layout‑Override und Folien‑Override.

![Themenkomponenten: Farben, Schriften, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Themen‑Workflows: ein Thema untersuchen, Farben und Schriften ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und wirksame Werte nach Vererbung und Overrides auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, Schriften‑Schema und Format‑Schema des Themas über [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) und [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) bereit. Diese Sammlungen zu untersuchen, bevor man sie ändert, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, weil die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe wirksame Thema hat. Untersuchen Sie den dem Folieninhalt zugeordneten Master und verwenden Sie den später im Artikel gezeigten Wirksame‑Thema‑Workflow, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Themenfarben ändern**

Theme‑aware Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag im [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, anhand des neuen Wertes aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht verändert.

Das folgende End‑to‑End‑Beispiel erzeugt eine Form, die `Accent4` verwendet, ändert die Themenfarbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die wirksame Füllfarbe aus:

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach dem Themenwechsel rot. Wenn Sie die Schema‑Farbe durch eine direkte Farbe an der Form ersetzen, wirken sich spätere Änderungen an `Accent4` nicht mehr auf diese Füllung aus.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem es Farbtransformationen anwendet. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der Zusatzpalette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt werden.

Das folgende Beispiel erzeugt sechs Rechtecke basierend auf `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

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

Diese Varianten bleiben an der Themenfarbe ausgerichtet. Wenn sich `Accent4` später ändert, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während das [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) dieselben Themenplätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; sie sind keine Werte, die dynamisch von der einen Form in die andere konvertiert werden.

## **Themen‑Schriften ändern**

Ein Themen‑Schriften‑Schema enthält einen Satz von Hauptschriften für Überschriften und einen Satz von Nebenschriften für Fließtext. Die Methoden [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) und [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) geben diese Sätze zurück.

PowerPoint‑kompatible Themen‑Schriften‑Kennungen können in der Textformatierung verwendet werden:

* `+mn‑lt` – Körperschrift Latein (Minor Latin Font)
* `+mj‑lt` – Überschriftschrift Latein (Major Latin Font)
* `+mn‑ea` – Körperschrift Ostasiatisch (Minor East Asian Font)
* `+mj‑ea` – Überschriftschrift Ostasiatisch (Major East Asian Font)
* `+mn‑cs` – Körperschrift Komplexes Skript (Minor Complex Script Font)
* `+mj‑cs` – Überschriftschrift Komplexes Skript (Major Complex Script Font)

Das folgende Beispiel erzeugt eine Überschrift, die die Haupt‑Latein‑Themenschrift verwendet, und eine Textzeile, die die Neben‑Latein‑Themenschrift verwendet. Anschließend werden die Themen‑Schriften geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschrift und der Fließtext der Neben­schrift. Text, dem ein expliziter Schriftname anstelle einer Themen‑Kennung zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriften‑Schema geändert wird.

Die Haupt‑ und Nebenschrift‑Sammlungen können außerdem Schriftenzuordnungen für einzelne Schriftsysteme wie Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana enthalten. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Weitere Informationen zu Präsentationsschriften finden Sie unter [PowerPoint Fonts](/slides/de/php-java/powerpoint-fonts/).
{{% /alert %}}

### **Themen‑Schriften‑Referenzen auflösen**

Beim Untersuchen von Text kann [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) eine Themen‑Referenz wie `+mn‑lt` statt eines Schriftfamilien‑Namens zurückgeben. Rufen Sie [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) mit den entsprechenden wirksamen Themen‑Daten auf, um diese Referenz aufzulösen. Die Präfixe `+mj` und `+mn` wählen den Haupt‑ bzw. Neben‑Schrift‑Satz; die Suffixe `-lt`, `-ea` und `-cs` wählen deren Latein‑, Ostasien‑ bzw. Komplex‑Skript‑Schriften.

Ermitteln Sie das wirksame Thema über [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) für das Objekt, dessen Thema auf den untersuchten Text angewendet wird. Für normalen Text auf einer Folie rufen Sie diese Methode auf der Folie selbst auf, damit der Kontext das geerbte Folienthema und lokale Overrides einschließt. Beim Untersuchen eines Layouts oder Masters verwenden Sie dessen eigenes wirksames Thema. Gehen Sie nicht davon aus, dass das Thema des ersten Masters für jede Folie gilt.

Das folgende Beispiel erzeugt einen Textabschnitt, der ausdrücklich die Neben‑Latein‑Schrift referenziert. Es initialisiert ein Folien‑Schriften‑Schema über [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) und setzt die Haupt‑ und Neben‑Latein‑Familien auf `Arial` bzw. `Calibri`, sodass das Ergebnis ohne Eingabedatei reproduzierbar ist:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Die Ausgabe lautet `+mn‑lt -> Calibri` gefolgt von `Verdana -> Verdana`. Die gespeicherte Referenz bleibt unverändert, während ein expliziter Familienname unverändert zurückgegeben wird. Wurde `+mj‑lt` verwendet, hätte sie in diesem Thema zu `Arial` aufgelöst.

Das Auflösen einer Themen‑Referenz ermittelt die vom Thema angegebene Schriftfamilie. Es wird nicht geprüft, ob die Schrift verfügbar ist, und es wird nicht bestimmt, welche Schriftdatei letztlich nach Substitution oder Glyph‑Fallback beim Rendern verwendet wird. Siehe [Font Selection Sequence](/slides/de/php-java/font-selection-sequence/) und [Font Substitution](/slides/de/php-java/font-substitution/) für diese separaten Schritte.

## **Ein Thema kopieren oder anwenden**

Die nachstehenden Workflows lösen unterschiedliche themenbezogene Probleme.

### **Ein externes Thema auf master‑abhängige Folien anwenden**

Verwenden Sie [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/), wenn Sie eine PowerPoint‑Themendatei (`.thmx`) besitzen und jede Folie, die von einem bestimmten Master abhängt, neu stylen möchten. Wählen Sie den Master aus der Sammlung [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), die durch [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) repräsentiert wird, und übergeben Sie den Pfad zur Themendatei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folien‑Instanz basierend auf dem ausgewählten Master.
1. Wendet das externe Thema auf den neuen Master an.
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.
1. Gibt das neu erstellte [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) zurück.

Das folgende Beispiel wendet ein externes Thema auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

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

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/) auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Fehler beim Zugriff auf das Dateisystem und speichern Sie die Präsentation erst, wenn das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themen. Theme‑aware Farben, Schriften, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriften, Füllungen und andere explizite Formatierungen können unverändert bleiben. Layout‑ und Folien‑Overrides können ebenfalls Vorrang vor Werten haben, die vom neuen Master geerbt wurden.

Das Thema kann Schriften referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistentes Rendern und Exportieren installieren Sie die benötigten Schriften, stellen sie über [custom font sources](/slides/de/php-java/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/php-java/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert kein manuelles Erzeugen von Folien‑ oder Layout‑Overrides.

### **Verschiedene externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mit [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) und [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jedem Gruppen‑Master ein unterschiedliches externes Thema zu:

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

Der erste Aufruf wirkt nur auf Folien, die von `$firstGroupMaster` abhingen, und der zweite Aufruf wirkt nur auf Folien, die von `$secondGroupMaster` abhingen. Folien, die zu anderen Mastern gehören, werden nicht neu gestaltet.

### **Quell‑Thema beim Verschieben von Folien erhalten**

Wenn Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design bewahren wollen, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), klonen anschließend die Folie mit [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) und dem geklonten Master. Damit werden Master, seine Layouts und das zugehörige Thema zusammen übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen muss. Das bloße Klonen von Inhalten auf einen fremden Ziel‑Master kann themen‑gesteuerte Farben, Schriften, Hintergründe und Effekte ändern.

### **Themenwerte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie ein Folien‑Level‑Override aus dem Quell‑Thema. Die Methoden [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) und [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) kopieren die drei Haupt‑Themen‑Komponenten in das Override.

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

Damit wird das von dieser Folie genutzte Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um das lokale Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) auf.

### **Ein Themen‑Override auf ein Layout anwenden**

Ein Layout‑Level‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihr eigenes Override hat. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Theme, wenn viele Layouts und Folien dasselbe Basiskonzept teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides erschweren spätere globale Themen‑Änderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden über [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) bereitgestellt. PowerPoint kann im UI mehr Hintergrund‑Optionen anbieten, als in dieser Sammlung tatsächlich gespeichert sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrund‑Stil verwenden, untersuchen Sie die gespeicherte Sammlung und den aktuellen [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine themenbezogene Füllung; positive Werte sind Referenzen zu themen‑Hintergrund‑Stilen. Das unterscheidet sich vom direkten Indexieren der PHP‑Sammlung, bei dem `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füll‑Stilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine themen‑Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themen‑Eintrag und von etwaigen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, ändert das reine Ändern des Master‑Hintergrunds diese Folie möglicherweise nicht. Nutzen Sie [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung wissen müssen.

{{% alert color="warning" title="Warning" %}}
Betrachten Sie den Stil‑Index nicht als nullbasierten Sammlungsindex. Vermeiden Sie außerdem, eine Stil‑Nummer aus einer Datei hart zu kodieren und anzunehmen, dass sie in einer anderen Datei gleich aussieht; Themen‑Stil‑Definitionen sind präsentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrundformatierung und Hintergrundvererbung siehe [Presentation Background](/slides/de/php-java/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) und [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) bereitgestellt werden. Typische Office‑Themen enthalten oft drei Haupt‑Stileinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung prüfen, anstatt eine feste Anzahl anzunehmen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Wenn Sie diese Sammlungen in PHP ansprechen, ist der Sammlungs‑Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil und `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf alle Formen aus, die diesen Themen‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linien‑Stil, ändert den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Themen‑Linien‑Stil rot, der dritte Themen‑Füll‑Stil zu einem satten Waldgrün, und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung das Thema überschreibt.

![Themen‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten](presentation-design_11.png)

## **Themen‑Füll‑ und Linien‑Stile für eine Form auswählen**

Eine Form kann ihre Füll‑ und Kontur‑Stile unabhängig über [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) und [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex) auswählen. Für beide Methoden wählt Index `1` den ersten Eintrag in der jeweiligen Themen‑Sammlung (`get_Item(0)`) und Index `2` den zweiten (`get_Item(1)`).

Das folgende Beispiel legt zwei Füll‑Stile (Gold und Himmelblau) und zwei Linien‑Stile (dunkelblau mit 6 pt und dunkelrot mit 12 pt) im Standard‑Thema einer neuen Präsentation fest. Es speichert die Folie in drei Schritten, sodass Sie die Ergebnisse in PowerPoint vergleichen können:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Anfangsstile | Rechte Kontur ändern | ersten Themen‑Füllstil bearbeiten |
|:---:|:---:|:---:|
| ![Gold‑ und Himmelblau‑Rechtecke mit passenden dünnen dunkelblauen Konturen](theme-style-initial.png) | ![Das Himmelblau‑Rechteck hat jetzt eine dicke dunkelrote Kontur](theme-style-line-changed.png) | ![Das linke Rechteck ist jetzt grün und beide Konturen bleiben unverändert](theme-style-fill-changed.png) |

Die Auswahl eines anderen Linien‑Stils ändert nur die Kontur des rechten Rechtecks. Das Bearbeiten des ersten Themen‑Füllstils aktualisiert jede Form, die ihn verwendet. Hier wird nur das linke Rechteck grün.

Bei einer bestehenden Form kann eine lokale Füll‑Farbe, Linien‑Farbe oder Linien‑Breite diesen Teil des Themen‑Stils überschreiben. Wenn das Ändern eines Stil‑Indexes keine sichtbare Wirkung hat, prüfen Sie die [direct formatting](/slides/de/php-java/shape-formatting/) der Form.

## **Ermitteln, ob eine wirksame Voll‑Füllung eine Themen‑Farbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder von einem Absatz, Layout, Master, Themen‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) auf, um diese Hierarchie in unveränderliche wirksame Füll‑Daten aufzulösen. Prüfen Sie zuerst das Ergebnis von `getFillType`. Nur wenn es `FillType::Solid` ist, sollten Sie die Eigenschaften der Voll‑Füllung lesen.

Für eine Voll‑Füllung liefert `getSolidFillColor` den endgültigen gerenderten RGB‑Wert nach Vererbung, Themen‑Lookup und Anwendung von Farbtransformationen. Die Methode `getSolidFillSchemeColor` gibt den zugehörigen logischen [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/)‑Platz zurück, z. B. `Text1` oder `Accent6`. Ein Wert von `SchemeColor::NotDefined` bedeutet, dass die wirksame Voll‑Füllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, in dem Füllungen entweder Themen‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/)‑Wert, um eine Füllung zu klassifizieren. Beispielsweise kann ein Textabschnitt keine lokal definierte Schema‑Farbe haben, sodass sein lokaler Wert `NotDefined` ist, während seine wirksame Füllung eine Themen‑Farbe erbt und zu `Text1` oder `Accent6` aufgelöst wird. Umgekehrt sagt `getSolidFillSchemeColor` Ihnen, welcher logische Themen‑Platz die wirksame Farbe erzeugt hat, jedoch nicht, ob dieser Platz vom Objekt, Absatz, Layout, Master oder einer anderen Ebene der Formatierungs‑Hierarchie stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitts‑Füllungen, gibt jeden finalen RGB‑Wert und zugehörige Schema‑Farbe aus und markiert Voll‑Füllungen, die Themen‑Farbänderungen nicht verfolgen:

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

Der Zweig `NotDefined` liefert eine Prüf­liste von Voll‑Füllungen, die nicht auf Themen‑Farbplätze reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während der Schema‑Wert erklärt, ob dieses Aussehen mit dem Thema verbunden ist.

Wirksame Format‑Objekte sind Schnappschüsse. Nach einer Änderung des Präsentations‑Themas, eines Themen‑Overrides oder beliebiger vererbter Formatierung rufen Sie `getEffective` erneut auf und lesen neue wirksame Füll‑Daten, bevor Sie Farben vergleichen oder berichten.

## **Wirksame Themen‑Werte auslesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Wirksame Werte zeigen, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Overrides verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), und für eine Füllung [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

Das folgende Beispiel liest das wirksame Thema, den Hintergrund und die erste Form‑Füllung einer Folie:

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

Verwenden Sie wirksame Daten für Render‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) prüfen, können Sie einen Master-, Layout‑, Folien‑ oder Form‑Override übersehen, der das endgültige Aussehen verändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themas auf jede Folie in der Präsentation?**

Nein. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themen.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Thema. Die Änderung bleibt lokal auf dieser Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übernehmen?**

Wenn Sie eine Folie verschieben und ihr Quell‑Design bewahren möchten, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) und [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die wirksamen Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Thema und die entsprechenden Wirksame‑Daten‑Methoden für Format‑Objekte wie [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) und [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). Diese APIs geben die aufgelösten Werte nach Vererbung und Overrides zurück.