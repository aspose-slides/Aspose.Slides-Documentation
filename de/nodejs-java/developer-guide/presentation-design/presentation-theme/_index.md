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
- Themenfarbe
- Zusätzliche Palette
- Themenschrift
- Themenstil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Master-Präsentationsthemen in JavaScript mit Aspose.Slides für Node.js erstellen, anpassen und PowerPoint-Dateien mit einheitlichem Branding konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert einen abgestimmten Satz von Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte beziehen sich auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das themenbezogene Design der Präsentation über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getmastertheme/) verfügbar. Eine Präsentation kann außerdem Theme‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Theme über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das effektive Theme einer Folie über diese Vererbungskette aufgelöst: Präsentationstheme, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themenkomponenten: Farben, Schriften, Hintergrundstile und Effekte](theme-constituents.png)

Die folgenden Abschnitte zeigen die gängigsten Theme‑Workflows: ein Theme untersuchen, Farben und Schriften ändern, ein Theme kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Überschreibungen auslesen.

## **Ein Theme untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, das Schriften‑Schema und das Format‑Schema des Themes über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/) bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da Anzahl und Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themes und meldet, wie viele Hintergrund-, Füll‑, Linien‑ und Effektstile im Theme gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Theme hat. Untersuchen Sie den Master, der der Folie zugeordnet ist, und nutzen Sie den im Folgenden gezeigten Workflow für effektive Themes, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themenfarben ändern**

Themenbewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in der [ColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colorscheme/)-Auflistung ändern, werden alle Objekte, die noch auf diese Theme‑Farbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Theme‑Farbänderung nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die Theme‑Farbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung Rot. Ersetzen Sie die Scheme‑Color durch eine direkte Farbe in der Form, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Theme‑Farbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.  
**2** – Aus den Hauptthemenfarben erzeugte hellere und dunklere Varianten.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `Accent4`, wendet auf fünf davon Luminanz‑Transformationen an und speichert das Ergebnis:

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

Diese Varianten bleiben an der Theme‑Farbe ausgerichtet. Ändert sich später `Accent4`, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während das [ColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colorscheme/) dieselben Theme‑Plätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Theme‑Plätze; es handelt sich nicht um Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen‑Schriftarten ändern**

Ein Theme‑Schriften‑Schema enthält einen Hauptschrift‑Satz für Überschriften und einen Neben‑schrift‑Satz für Fließtext. Die Methoden [FontScheme.getMajor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontscheme/) und [FontScheme.getMinor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontscheme/) geben diese Sätze frei.

PowerPoint‑kompatible Theme‑Schrift‑Bezeichner können bei der Textformatierung verwendet werden:

* `+mn-lt` – Körper‑Schrift Latein (Minor Latin Font)
* `+mj-lt` – Überschrifts‑Schrift Latein (Major Latin Font)
* `+mn-ea` – Körper‑Schrift Ostasien (Minor East Asian Font)
* `+mj-ea` – Überschrifts‑Schrift Ostasien (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latein‑Theme‑Schrift verwendet, und eine Textzeile, die die Neben‑Latein‑Theme‑Schrift verwendet. Anschließend werden die Theme‑Schriften geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschrift und der Fließtext der Neben­schrift. Text, dem ein expliziter Schriftname anstelle eines Theme‑Bezeichners zugewiesen ist, wechselt nicht automatisch, wenn das Theme‑Schriften‑Schema geändert wird.

Der Haupt‑ und Neben‑Schrift‑Sammlung können außerdem Schrift‑Mappings für einzelne Schriftsysteme wie Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana zugeordnet sein. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Mappings siehe [Script‑Specific Theme Fonts](/slides/de/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zu Präsentationsschriften finden Sie unter [PowerPoint Fonts](/slides/de/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Ein Theme kopieren oder anwenden**

Es gibt zwei gängige Workflows, die unterschiedliche Probleme lösen.

### **Quell‑Theme beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten, klonen Sie den Quell‑Master in die Zielpräsentation mit [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslidecollection/), und klonen Sie anschließend die Folie mit [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/) und dem geklonten Master. Dadurch werden Master, Layouts und das zugehörige Theme zusammen übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen muss. Das bloße Klonen von Inhalten auf einen nicht verwandten Ziel‑Master kann themenbasierte Farben, Schriften, Hintergründe und Effekte verändern.

### **Theme‑Werte auf eine bestehende Folie anwenden**

Muss die Ziel‑Folie ihren aktuellen Master und ihr Layout behalten, initialisieren Sie ein Folien‑Override‑Theme aus dem Quell‑Theme. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/) kopieren die drei Haupt‑Theme‑Komponenten in das Override‑Theme.

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

Damit ändert sich das für diese Folie verwendete Theme, ohne das von anderen Folien geerbte Theme zu beeinflussen. Um das lokale Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/) auf.

### **Ein Theme‑Override auf ein Layout anwenden**

Ein Layout‑Override wirkt sich auf alle Folien aus, die dieses Layout verwenden, es sei denn, eine bestimmte Folie hat ein eigenes Override. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Theme, wenn viele Layouts und Folien dasselbe Basendesign teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides erschweren die Vorhersagbarkeit späterer globaler Theme‑Änderungen.

## **Theme‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themes werden in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anbieten, als die physisch in dieser Sammlung abgelegten Füllungsdefinitionen vorhanden sind, weil das UI Theme‑Füllungen mit Theme‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint-Galerie für Hintergrundstile eines Präsentationsthemes](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine themenbasierte Füllung; positive Werte sind Referenzen auf Theme‑Hintergrundstile. Das unterscheidet sich vom direkten Indexieren der JavaScript‑Sammlung, wo Index `0` das erste gespeicherte Element bezeichnet. Gehen Sie nicht davon aus, dass jede Präsentation die gleiche Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbasierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Theme‑Eintrag und von etwaigen Hintergrund‑Overrides im Layout oder auf Folienebene ab. Verwendet eine Folie einen eigenen Hintergrund, kann das alleinige Ändern des Master‑Hintergrunds diese Folie unverändert lassen. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/), wenn Sie den endgültigen Hintergrund nach Vererbung kennen müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie den Stil‑Index nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem, eine Stil‑Nummer aus einer Datei hart zu kodieren und anzunehmen, dass sie in einer anderen Datei gleich aussieht; Theme‑Stil‑Definitionen sind präsentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}
Für direkte Hintergrundformatierung und Hintergrundvererbung siehe [Presentation Background](/slides/de/nodejs-java/presentation-background/).
{{% /alert %}}

## **Theme‑Effekte aktualisieren**

Ein Theme‑Format‑Schema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [FormatScheme.getFillStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/) und [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/) bereitgestellt werden. Typische Office‑Themes enthalten häufig drei Haupt‑Stileinträge, die visuell subtilen, moderaten und intensiven Formatierungen entsprechen, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Theme‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Wenn Sie in JavaScript auf diese Sammlungen zugreifen, ist der Sammlungs‑Index nullbasiert: Index `0` ist der erste gespeicherte Stil und Index `2` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [ShapeStyle](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapestyle/) bereitgestellt wird. Das Ändern eines Theme‑Stils beeinflusst Formen, die diesen Theme‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linien‑Stil, ändert den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Theme‑Linienstil rot, der dritte Theme‑Füllstil wird zu einem satten Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einer Distanz von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierungen das Theme überschreiben.

![Theme‑Effektstile nach Änderung von Linien-, Füll‑ und Schatteneinstellungen](presentation-design_11.png)

## **Effektive Theme‑Werte lesen**

Roh‑Theme‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte geben an, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Overrides verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fillformat/).

Das folgende Beispiel liest das effektive Theme, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getmastertheme/) untersuchen, können Sie einen Master-, Layout-, Folien‑ oder Form‑Override übersehen, der das endgültige Erscheinungsbild ändert.

## **FAQ**

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Theme. Die Änderung bleibt lokal auf dieser Folie; andere Folien erben weiterhin ihre bestehenden Themes.

**Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Erscheinungsbild erhalten wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master über [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslidecollection/) und [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/). Dadurch bleiben Master, Layouts und Theme zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Theme und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fillformat/). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Overrides zurück.