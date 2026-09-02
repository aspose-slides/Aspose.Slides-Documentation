---
title: Präsentationsthemen in Java verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/java/presentation-theme/
keywords:
- PowerPoint-Theme
- Präsentations-Theme
- Folien-Theme
- Theme festlegen
- Theme ändern
- Theme verwalten
- Theme-Farbe
- zusätzliche Palette
- Theme-Schriftart
- Theme-Stil
- Theme-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Master‑Präsentations‑Themes in Aspose.Slides für Java, um PowerPoint‑Dateien mit konsistenter Marken‑Identität zu erstellen, anzupassen und zu konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert ein abgestimmtes Set von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themen‑bewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das thema‑bezogene Präsentations‑Theme über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) verfügbar. Eine Präsentation kann außerdem Themen‑Überschreibungen auf niedrigerer Ebene enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Theme über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das wirksame Theme für eine Folie über diese Vererbungskette ermittelt: Präsentationstheme, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themen‑Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Theme‑Workflows: ein Theme untersuchen, Farben und Schriftarten ändern, ein Theme kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Auflösung von Vererbung und Überschreibungen auslesen.

## **Ein Theme untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, das Schriftartenschema und das Format‑Schema des Themes über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/) bereit. Das Untersuchen dieser Sammlungen, bevor man Änderungen vornimmt, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, weil die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themes und gibt aus, wie viele Hintergrund‑, Füll‑, Linien‑ und Effekte‑Stile im Theme gespeichert sind:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe wirksame Theme hat. Untersuchen Sie den Master, der der Folie zugeordnet ist, und verwenden Sie den im weiteren Verlauf dieses Artikels gezeigten Wirksame‑Theme‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Theme‑Farben ändern**

Themen‑bewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in der [IColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorscheme/)-Sammlung ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht geändert.

Das folgende End‑to‑End‑Beispiel erzeugt eine Form, die `Accent4` verwendet, ändert die Theme‑Farbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die wirksame Füllfarbe aus:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach dem Themenwechsel Rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe auf der Form, beeinflussen spätere Änderungen von `Accent4` diese Füllung nicht mehr.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/java/com.aspose.slides/colortransformoperation/) bereit.

![Haupt‑Theme‑Farben und hellere sowie dunklere Farben, die aus der zusätzlichen Palette erzeugt wurden](additional-palette-colors.png)

**1** – Haupt‑Theme‑Farben.

**2** – Hellere und dunklere Varianten, die aus den Haupt‑Theme‑Farben erzeugt wurden.

Das folgende Beispiel erzeugt sechs Rechtecke auf Basis von `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diese Varianten bleiben auf der Themenfarbe basierend. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `IColorScheme`‑Slots zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während die [IColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorscheme/)-Schnittstelle dieselben Theme‑Slots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Theme‑Slots; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Theme‑Schriftarten ändern**

Ein Theme‑Schriftartenschema enthält einen Haupt‑Schriftartensatz für Überschriften und einen Neben‑Schriftartensatz für Fließtext. Die Methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontscheme/) und [IFontScheme.getMinor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontscheme/) geben diese Sätze frei.

PowerPoint‑kompatible Theme‑Schriftart‑Kennzeichner können in der Textformatierung verwendet werden:

* `+mn-lt` – Body‑Font Latin (Minor Latin Font)
* `+mj-lt` – Heading‑Font Latin (Major Latin Font)
* `+mn-ea` – Body‑Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading‑Font East Asian (Major East Asian Font)

Das folgende Beispiel erzeugt eine Überschrift, die die Haupt‑Latin‑Theme‑Schriftart verwendet, und eine Textzeile, die die Neben‑Latin‑Theme‑Schriftart verwendet. Anschließend werden die Theme‑Schriftarten geändert und das Ergebnis gespeichert:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Überschrift folgt der Hauptschriftart und der Fließtext folgt der Neben‑Schriftart. Text, der einen expliziten Schriftartnamen anstelle eines Theme‑Kennzeichners enthält, wechselt nicht automatisch, wenn das Theme‑Schriftartenschema geändert wird.

Die Haupt‑ und Neben‑Schriftartsammlungen können außerdem Schriftartenzuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/java/powerpoint-fonts/).
{{% /alert %}}

## **Ein Theme kopieren oder anwenden**

Es gibt zwei gängige Workflows, die unterschiedliche Probleme lösen.

### **Quell‑Theme beim Verschieben von Folien beibehalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/), anschließend klonen Sie die Folie mit [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/) und dem geklonten Master. Dadurch werden Master, Layouts und das zugehörige Theme gemeinsam übertragen.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel‑Dokument identisch aussehen soll. Das simple Klonen von Inhalten auf einen nicht verwandten Ziel‑Master kann themenbezogene Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Theme‑Werte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie eine Folien‑Level‑Überschreibung aus dem Quell‑Theme. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/) kopieren die drei Haupt‑Theme‑Komponenten in die Überschreibung.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Damit wird das Theme dieser Folie geändert, ohne das von anderen Folien geerbte Theme zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/) auf.

### **Eine Theme‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Level‑Überschreibung gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung hat. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/layoutslidethememanager/) verwendet werden:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Verwenden Sie ein Master‑ oder Präsentations‑Theme, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein anderes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Level‑Überschreibungen erschweren spätere globale Theme‑Änderungen.

## **Theme‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themes werden in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anbieten, als in dieser Sammlung physisch definiert sind, weil das UI Theme‑Füllungen mit Theme‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstil‑Galerie für ein Präsentations‑Theme](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine themenbezogene Füllung; positive Werte sind Referenzen auf Theme‑Hintergrundstile. Das unterscheidet sich vom direkten Indexieren der Java‑Sammlung, bei dem `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation die gleiche Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbezogene Hintergrund‑Referenz zu und speichert die Präsentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das sichtbare Ergebnis hängt vom Theme‑Eintrag ab, auf den der Master verweist, und von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene. Verwendet eine Folie ihren eigenen Hintergrund, ändert das Ändern nur des Master‑Hintergrunds diese Folie möglicherweise nicht. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/), wenn Sie den endgültigen Hintergrund nach Anwendung der Vererbung kennen müssen.

{{% alert color="warning" title="Warning" %}}
Behandeln Sie den Stil‑Index nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie zudem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei dasselbe Aussehen hat; Theme‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/java/presentation-background/).
{{% /alert %}}

## **Theme‑Effekte aktualisieren**

Ein Theme‑Format‑Schema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/) und [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/) bereitgestellt werden. Typische Office‑Themes enthalten häufig drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Theme‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Beim Zugriff auf diese Sammlungen in Java ist der Sammlungs‑Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil und `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Theme‑Stils wirkt sich auf Formen aus, die diesen Theme‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linienstil, den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effektstil und speichert das Ergebnis:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für Formen, die diese Slots referenzieren, wird der erste Theme‑Linienstil rot, der dritte Theme‑Füllstil wird zu einem einheitlichen Waldgrün, und der dritte Effektstil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung die Theme‑Einstellungen überschreibt.

![Theme‑Effektstile nach Änderung von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Effektive Theme‑Werte auslesen**

Roh‑Theme‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich nach Auflösung von Vererbung und lokalen Überschreibungen verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/).

Das folgende Beispiel liest das effektive Theme, den Hintergrund und die erste Form‑Füllung einer Folie aus:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) untersuchen, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Override übersehen, der das endgültige Erscheinungsbild ändert.

## **FAQ**

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Theme. Die Änderung bleibt lokal zu dieser Folie; andere Folien erben weiterhin ihre bestehenden Themes.

**Was ist der sicherste Weg, ein Theme von einer Präsentation zur anderen zu übertragen?**

Wenn Sie eine Folie verschieben und ihr Quell‑Design beibehalten möchten, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/) und [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/). Dadurch bleiben Master, Layouts und Theme zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen anzeigen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Theme und die entsprechenden Effekt‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/). Diese APIs liefern die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen.