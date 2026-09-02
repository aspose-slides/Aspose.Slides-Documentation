---
title: Verwalten von Präsentationsthemen in JavaScript
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/nodejs-java/presentation-theme/
keywords:
- PowerPoint-Theme
- Präsentationsthema
- Folienthema
- Theme festlegen
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Master-Präsentationsthemen in JavaScript mit Aspose.Slides für Node.js erstellen, anpassen und PowerPoint-Dateien mit einheitlicher Markenidentität konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert einen koordinierten Satz von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Theme‑aware Objekte verweisen auf diese gemeinsam genutzten Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte auf einmal aktualisieren kann.

In Aspose.Slides ist das thema‑ebene Präsentationsthema über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getmastertheme/) verfügbar. Eine Präsentation kann außerdem Theme‑Overrides auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das effektive Thema für eine Folie über diese Vererbungskette ermittelt: Präsentationsthema, Master‑Override, Layout‑Override und Folien‑Override.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Theme‑Workflows: ein Theme untersuchen, Farben und Schriftarten ändern, ein Theme kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Overrides auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, Schriftartenschema und Formatschema des Themas über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mastertheme/) bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Theme gespeichert sind:

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

Wenn eine Datei mehrere Master verwendet, darf nicht angenommen werden, dass jede Folie das gleiche effektive Theme hat. Untersuchen Sie den Master, der der Folie zugeordnet ist, und verwenden Sie den effektiven‑Theme‑Workflow, der später in diesem Artikel gezeigt wird, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Themafarben ändern**

Theme‑aware Füllungen, Linien und Text können sich auf eine logische Farbe aus der [SchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/schemecolor/)‑Aufzählung beziehen. Wenn Sie den entsprechenden Eintrag im [ColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colorscheme/) ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Theme‑Farbupdate nicht geändert.

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung rot. Wenn Sie die Schema‑Farbe durch eine direkte Farbe auf der Form ersetzen, wirken sich spätere Änderungen an `Accent4` nicht mehr auf diese Füllung aus.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die [ColorTransformOperation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colortransformoperation/)‑Aufzählung bereit.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt werden.

Das folgende Beispiel erstellt sechs Rechtecke, die auf `Accent4` basieren, wendet Luminanz‑Transformationen auf fünf von ihnen an und speichert das Ergebnis:

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

Diese Varianten bleiben auf der Themenfarbe basierend. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Slots zuordnen**

Die [SchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/schemecolor/)‑Aufzählung verwendet `Text1`, `Background1`, `Text2` und `Background2`, während das [ColorScheme](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colorscheme/) dieselben Themenslots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenslots; es handelt sich nicht um Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Thema‑Schriftarten ändern**

Ein Theme‑Schriftartenschema enthält ein Hauptschriftset für Überschriften und ein Neben­schriftset für Fließtext. Die Methoden [FontScheme.getMajor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontscheme/) und [FontScheme.getMinor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontscheme/) geben diese Sets zurück.

PowerPoint‑kompatible Theme‑Schriftart‑Kennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Theme‑Schriftart verwendet, und eine Textzeile, die die Neben‑Latin‑Theme‑Schriftart verwendet. Anschließend werden die Theme‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschriftart und der Fließtext folgt der Neben­schriftart. Text, der einen expliziten Schriftartnamen anstelle einer Theme‑Kennung enthält, wird nicht automatisch umgeschaltet, wenn sich das Theme‑Schriftartenschema ändert.

Die Haupt‑ und Neben­schriftart‑Sammlungen können auch Schriftzuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Ein Theme kopieren oder anwenden**

Die nachstehenden Workflows lösen unterschiedliche Theme‑bezogene Probleme.

### **Ein externes Theme auf Folien anwenden, die von einem Master abhängen**

Verwenden Sie [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/), wenn Sie eine PowerPoint‑Themedatei (`.thmx`) besitzen und jedes Folie neu stylen möchten, das von einem bestimmten Master abhängt. Wählen Sie den Master aus der [Presentation.getMasters](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Sammlung, die durch [MasterSlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslidecollection/) repräsentiert wird, und übergeben Sie den Theme‑Dateipfad an die Methode.

Die Methode führt die folgenden Schritte aus:

1. Erstellt eine neue Master‑Folien basierend auf dem ausgewählten Master.
1. Wendet das externe Theme auf den neuen Master an.
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.
1. Gibt die neu erstellte [MasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) zurück.

Das folgende Beispiel wendet ein externes Theme auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

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

Ein ungültiges, beschädigtes oder nicht unterstütztes Theme kann eine [PptxReadException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxreadexception/) auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Zugriffsfehler auf das Dateisystem und speichern Sie die Präsentation erst, nachdem das Theme erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugewiesen. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themes. Theme‑aware Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Theme aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formatierungen können unverändert bleiben. Layout‑ und Folien‑Overrides können ebenfalls Vorrang vor den vom neuen Master vererbten Werten haben.

Das Theme kann Schriftarten referenzieren, die im Laufzeit‑Umfeld nicht verfügbar sind. Für konsistente Darstellung und Export installieren Sie die benötigten Schriftarten, stellen Sie sie über [custom font sources](/slides/de/nodejs-java/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/nodejs-java/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert nicht das manuelle Erstellen von Folien‑ oder Layout‑Theme‑Overrides.

### **Verschiedene externe Themes in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master im Voraus nicht bekannt ist, erhalten Sie ihn über eine repräsentative Folie mit [Slide.getLayoutSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/) und [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themes anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jedem Gruppe ein unterschiedliches externes Theme an:

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

Der erste Aufruf wirkt nur auf Folien, die von `firstGroupMaster` abhingen, der zweite Aufruf wirkt nur auf Folien, die von `secondGroupMaster` abhingen. Folien, die zu einem anderen Master gehören, werden nicht neu gestylt.

### **Ein Quell‑Theme beim Verschieben von Folien beibehalten**

Wenn Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten wollen, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslidecollection/), klonen anschließend die Folie mit [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/) und dem geklonten Master. Damit werden Master, dessen Layouts und das zugehörige Theme zusammen übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folien im Ziel identisch aussehen muss. Ein bloßes Klonen von Inhalten auf einen nicht verwandten Ziel‑Master kann Theme‑gesteuerte Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Theme‑Werte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folien auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie einen Folien‑Override aus dem Quell‑Theme. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/) kopieren die drei Haupt‑Theme‑Komponenten in den Override.

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

Damit wird das Theme dieser Folie geändert, ohne das von anderen Folien geerbte Theme zu beeinflussen. Um den lokalen Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/overridetheme/) auf.

### **Ein Theme‑Override auf ein Layout anwenden**

Ein Layout‑Level‑Override gilt für Folien, die dieses Layout verwenden, sofern eine bestimmte Folie keinen eigenen Override besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Theme, wenn viele Layouts und Folien dasselbe Basisdesign teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides erschweren Vorhersagen bei späteren globalen Theme‑Änderungen.

## **Theme‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themes werden über [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen präsentieren, als die Anzahl der physisch in dieser Sammlung gespeicherten Fülldefinitionen, weil das UI Theme‑Füllungen mit Theme‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine thematisierte Füllung; positive Werte sind Referenzen zu Theme‑Hintergrund‑Stilen. Dies unterscheidet sich von einem direkten Index der JavaScript‑Sammlung, bei dem Index `0` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die Anzahl verfügbarer Hintergrund‑Füllungen aus, weist dem ersten Master eine thematisierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt von dem Theme‑Eintrag ab, auf den der Master verweist, sowie von etwaigen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene. Verwendet eine Folie ihren eigenen Hintergrund, ändert das Ändern nur des Master‑Hintergrunds diese Folie möglicherweise nicht. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/), wenn Sie den finalen Hintergrund nach angewandter Vererbung kennen müssen.

{{% alert color="warning" title="Warnung" %}}
Betrachten Sie den Stil‑Index nicht als nullbasierenden Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei dieselbe Darstellung hat; Theme‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/nodejs-java/presentation-background/).
{{% /alert %}}

## **Theme‑Effekte aktualisieren**

Ein Theme‑Formatschema enthält separate Sammlungen für Füll‑, Linien‑ und Effektstile, die über [FormatScheme.getFillStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/) und [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/formatscheme/) bereitgestellt werden. Typische Office‑Themes enthalten häufig drei Haupteintrags‑Stile, die visuell subtil, moderat und intensiv dargestellt werden, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Wenn Sie in JavaScript auf diese Sammlungen zugreifen, ist der Sammlungs‑Index nullbasiert: Index `0` ist der erste gespeicherte Stil und Index `2` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [ShapeStyle](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapestyle/) bereitgestellt wird. Das Ändern eines Theme‑Stils wirkt sich auf Formen aus, die diesen Theme‑Stil referenzieren; Formen mit direkter Formatierung können unverändert bleiben.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linienstil, den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effektstil und speichert das Ergebnis:

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

Für Formen, die diese Slots referenzieren, wird der erste Theme‑Linienstil rot, der dritte Theme‑Füllstil erhält ein sattes Waldgrün und der dritte Effektstil gewinnt einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung den Theme‑Wert überschreibt.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Ermitteln, ob eine effektive Vollfüllung eine Theme‑Farbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder von einem Absatz, Layout, Master, Theme‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [FillFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fillformat/) auf, um diese Hierarchie in einen unveränderlichen effektiven‑Füll‑Snapshot aufzulösen. Prüfen Sie zuerst den Wert von `getFillType`. Nur wenn er `FillType.Solid` ist, sollten Sie die Eigenschaften einer Vollfüllung lesen.

Für eine Vollfüllung liefert `getSolidFillColor` den endgültigen gerenderten RGB‑Wert nach Vererbung, Theme‑Lookup und Farbtransformationen. Die Methode `getSolidFillSchemeColor` gibt den zugehörigen logischen [SchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/schemecolor/)‑Slot zurück, z. B. `Text1` oder `Accent6`. Ein Wert von `SchemeColor.NotDefined` bedeutet, dass die effektive Vollfüllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, bei dem Füllungen entweder Theme‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colorformat/)‑Wert, um eine Füllung zu klassifizieren. Ein Textabschnitt kann beispielsweise keinen lokal definierten Schema‑Farbwert haben, sodass sein lokaler Wert `NotDefined` ist, während seine effektive Füllung eine Theme‑Farbe erbt und zu `Text1` bzw. `Accent6` aufgelöst wird. Umgekehrt sagt `getSolidFillSchemeColor` Ihnen, welcher logische Theme‑Slot die effektive Farbe erzeugt hat, aber nicht, ob dieser Slot vom Objekt, Absatz, Layout, Master oder einer anderen Ebene stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitt‑Füllungen, gibt jeweils den finalen RGB‑Wert und die zugehörige Schema‑Farbe aus und kennzeichnet Vollfüllungen, die Theme‑Farbänderungen nicht folgen:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Der `NotDefined`‑Zweig liefert eine Prüfliste von Vollfüllungen, die nicht auf Änderungen in Theme‑Farbslots reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während der Schema‑Wert erklärt, ob dieses Aussehen mit dem Theme verbunden ist.

Effektive Format‑Objekte sind Schnappschüsse. Nachdem Sie das Präsentations‑Theme, einen Theme‑Override oder irgendeine geerbte Formatierung geändert haben, rufen Sie erneut `getEffective` auf und lesen ein neues effektives‑Füll‑Objekt, bevor Sie Farben vergleichen oder berichten.

## **Effektive Theme‑Werte auslesen**

Roh‑Theme‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Overrides verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fillformat/).

Das folgende Beispiel liest das effektive Theme, den Hintergrund und die erste Form‑Füllung von einer Folie:

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

**Wirkt das Anwenden eines externen Themes auf jede Folie der Präsentation?**

Nein. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themes.

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Theme. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themes.

**Was ist der sicherste Weg, ein Theme von einer Präsentation zur anderen zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren möchten, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mithilfe von [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslidecollection/) und [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/). Dadurch bleiben Master, Layouts und Theme zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Theme und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fillformat/). Diese APIs geben die aufgelösten Werte nach Vererbung und Overrides zurück.