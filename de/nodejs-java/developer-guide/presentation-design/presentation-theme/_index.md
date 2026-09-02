---
title: Präsentationsthemen in JavaScript verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/nodejs-java/presentation-theme/
keywords:
- PowerPoint-Thema
- Präsentationsthema
- Folienthema
- Thema festlegen
- Thema ändern
- Thema verwalten
- externes Thema
- THMX
- Themenfarbe
- zusätzliche Palette
- Themenschrift
- Themestil
- Themaeffekt
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Master-Präsentationsthemen in JavaScript mit Aspose.Slides für Node.js erstellen, anpassen und PowerPoint-Dateien mit konsistenter Markenbindung konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert einen koordinierten Satz von Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das präsentationsweite Thema über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getmastertheme/) verfügbar. Eine Präsentation kann zudem Themen‑Überschreibungen auf tieferen Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das effektive Thema einer Folie über die Vererbungskette aufgelöst: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die häufigsten Themen‑Workflows: ein Thema inspizieren, Farben und Schriften ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Auflösung von Vererbung und Überschreibungen auslesen.

## **Ein Thema inspizieren**

Das [MasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, Schriften‑schema und Format‑Schema über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/) bereit. Diese Sammlungen zu inspizieren, bevor man sie ändert, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Thema hat. Inspizieren Sie den zum Folien‑Master gehörenden Master und verwenden Sie den später in diesem Artikel gezeigten effektiven‑Thema‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themenfarben ändern**

Themenbewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag im [ColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colorscheme/) ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, anhand des neuen Werts aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht geändert.

Das folgende durchgängige Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die `Accent4`‑Farbe des Themas zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung Rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe in der Form, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem Farb‑Transformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colortransformoperation/) bereit.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke basierend auf `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diese Varianten bleiben an der Themenfarbe ausgerichtet. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [ColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colorscheme/) dieselben Themenplätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; es handelt sich nicht um Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen‑Schriften ändern**

Ein Themen‑Schriften‑Schema enthält einen Hauptschrift‑Satz für Überschriften und einen Neben‑schrift‑Satz für Fließtext. Die Methoden [FontScheme.getMajor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontscheme/) und [FontScheme.getMinor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontscheme/) geben diese Sätze zurück.

PowerPoint‑kompatible Themen‑Schrift‑Bezeichner können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latein‑Themenschrift verwendet, und eine Textzeile, die die Neben‑Latein‑Themenschrift verwendet. Anschließend werden die Themen‑Schriften geändert und das Ergebnis gespeichert:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Überschrift folgt der Hauptschrift und der Fließtext der Neben‑schrift. Text, der einen expliziten Schrift­namen anstelle eines Themen‑Bezeichners verwendet, wechselt nicht automatisch, wenn das Themen‑Schriften‑Schema geändert wird.

Die Haupt‑ und Neben‑Schrift‑Sammlungen können außerdem Schrift‑Zuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Inspizieren, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script-Specific Theme Fonts](/slides/de/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zu Präsentations‑Schriften finden Sie unter [PowerPoint Fonts](/slides/de/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Die nachfolgenden Workflows lösen unterschiedliche themenbezogene Probleme.

### **Ein externes Thema auf abhängige Folien eines Masters anwenden**

Verwenden Sie [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/), wenn Sie eine PowerPoint‑Themen‑Datei (`.thmx`) haben und jede Folie, die von einem bestimmten Master abhängt, neu stylen möchten. Wählen Sie den Master aus der [Presentation.getMasters](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Sammlung, die durch [MasterSlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslidecollection/) dargestellt wird, und übergeben Sie den Pfad zur Themen‑Datei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folien‑Instanz basierend auf dem ausgewählten Master.
1. Wendet das externe Thema auf den neuen Master an.
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.
1. Gibt die neu erstellte [MasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) zurück.

Das folgende Beispiel wendet ein externes Thema auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann [PptxReadException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxreadexception/) auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Zugriffs‑Fehler auf das Dateisystem und speichern Sie die Präsentation erst, nachdem das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugewiesen. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themen. Themenbewusste Farben, Schriften, Füllungen, Linien, Hintergründe und Effekte werden am externen Thema ausgerichtet. Direkt zugewiesene Farben, Schriften, Füllungen und andere explizite Formatierungen bleiben möglicherweise unverändert. Layout‑ und Folien‑Überschreibungen können ebenfalls Vorrang vor Werten haben, die vom neuen Master geerbt wurden.

Das Thema kann Schriften referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistente Darstellung und Export installieren Sie die erforderlichen Schriften, stellen Sie sie über [custom font sources](/slides/de/nodejs-java/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/nodejs-java/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert kein manuelles Erstellen von Folien‑ oder Layout‑Themen‑Überschreibungen.

### **Unterschiedliche externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, erhalten Sie ihn über eine repräsentative Folie mit [Slide.getLayoutSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/) und [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Bereichen, ermittelt deren Master und wendet für jede Gruppe ein anderes externes Thema an:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Der erste Aufruf betrifft nur Folien, die von `firstGroupMaster` abhingen, der zweite Aufruf nur Folien, die von `secondGroupMaster` abhingen. Folien, die zu einem anderen Master gehören, werden nicht neu gestylt.

### **Ein Quell‑Thema beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslidecollection/), klonen Sie anschließend die Folie mit [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/) und dem geklonten Master. Damit werden Master, Layouts und das zugehörige Thema gemeinsam übernommen.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Dies ist der bevorzugte Workflow, wenn die Quell‑Folien im Ziel‑Dokument identisch aussehen sollen. Das reine Kopieren von Inhalten auf einen nicht zugehörigen Ziel‑Master kann themen‑gesteuerte Farben, Schriften, Hintergründe und Effekte ändern.

### **Themenwerte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folien ihren aktuellen Master und ihr Layout behalten, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/) kopieren die drei Haupt‑Themen‑Komponenten in die Überschreibung.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Damit wird das von dieser Folie verwendete Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/) auf.

### **Eine Themen‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Überschreibung gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslidethememanager/) verwendet werden:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Basendesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein abweichendes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Überschreibungen erschweren die Vorhersagbarkeit späterer globaler Themenänderungen.

## **Hintergrundstile des Themas aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anzeigen, als im Collection‑Objekt physisch gespeichert sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Bevor Sie einen Hintergrund‑Stil verwenden, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine thematisierte Füllung; positive Werte sind Referenzen zu Themen‑Hintergrund‑Stilen. Das unterscheidet sich von der direkten Indexierung der JavaScript‑Sammlung, bei der Index `0` das erste Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation die gleiche Anzahl von Hintergrund‑Füll‑Stilen enthält.

Das folgende Beispiel gibt die vorhandene Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine thematisierte Hintergrund‑Referenz zu und speichert die Präsentation:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das sichtbare Ergebnis hängt vom Themen‑Eintrag ab, auf den der Master verweist, sowie von etwaigen Hintergrund‑Überschreibungen im Layout oder auf Folien‑Ebene. Verwendet eine Folie ihren eigenen Hintergrund, kann das Ändern nur des Master‑Hintergrunds diese Folie nicht beeinflussen. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/), wenn Sie den endgültigen Hintergrund nach Anwendung der Vererbung wissen müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie den Stil‑Index nicht als nullbasierte Sammlungs‑Indexierung. Vermeiden Sie außerdem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei identisch aussieht; Themen‑Stil‑Definitionen sind präsentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}
Für direkte Hintergrund‑Formatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/nodejs-java/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [FormatScheme.getFillStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/) und [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/) verfügbar sind. Übliche Office‑Themen enthalten oft drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind, aber Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Greift man in JavaScript auf diese Sammlungen zu, ist der Sammlungs‑Index nullbasiert: Index `0` ist der erste gespeicherte Stil, Index `2` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [ShapeStyle](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf Formen aus, die diesen Themen‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stile vorhanden sind, ändert den ersten Linien‑Stil, den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für Formen, die diese Slots referenzieren, wird der erste Themen‑Linien‑Stil Rot, der dritte Themen‑Füll‑Stil zu einem satten Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welchen Stil‑Slot jede Form referenziert und ob direkte Formatierung die Themen‑Stile überschreibt.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Effektive Themen‑Werte auslesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Überschreibungen aufgelöst wurden. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fillformat/).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die erste Form‑Füllung einer Folie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getmastertheme/) inspizieren, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das endgültige Aussehen ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themas auf jede Folie der Präsentation?**

Nein. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themen.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Überschreibungsthema. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übernehmen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren möchten, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslidecollection/) und [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Thema und die entsprechenden Effektdaten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fillformat/). Diese APIs liefern die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen.