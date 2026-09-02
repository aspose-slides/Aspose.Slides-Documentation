---
title: Präsentationsthemen auf Android verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "Master‑Präsentationsthemen in Aspose.Slides für Android mittels Java erstellen, anpassen und PowerPoint‑Dateien mit konsistenter Markenidentität konvertieren."
---
## **Einführung**

Ein Präsentationsthema definiert ein koordiniertes Set aus Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsam genutzten Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung zahlreiche Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das präsentationsweite Thema über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) verfügbar. Eine Präsentation kann außerdem Themen‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das wirksame Thema für eine Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themen‑Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die häufigsten Themen‑Workflows: Ein Thema untersuchen, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und wirksame Werte nach Auflösung von Vererbung und Überschreibungen auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, das Schriftartenschema und das Formatschema des Themas über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/) bzw. [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/) bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas aus und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

Wenn eine Datei mehrere Master verwendet, darf man nicht davon ausgehen, dass jede Folie dasselbe wirksame Thema hat. Untersuchen Sie den mit der Folie verbundenen Master und verwenden Sie den wirksamen‑Thema‑Workflow, der später in diesem Artikel gezeigt wird, falls Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themenfarben ändern**

Themenbewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der [SchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/schemecolor/)‑Aufzählung beziehen. Wenn Sie den entsprechenden Eintrag in der [IColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icolorscheme/) ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, anhand des neuen Werts aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Themenfarb‑Aktualisierung nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die `Accent4`‑Farbe des Themas zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die wirksame Füllfarbe aus:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Da das Rechteck mit `Accent4` verknüpft bleibt, wird seine sichtbare Farbe nach der Themenänderung Rot. Wenn Sie die Schema‑Farbe durch eine direkte Farbe in der Form ersetzen, wirken sich spätere Änderungen von `Accent4` nicht mehr auf diese Füllung aus.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint erzeugt hellere und dunklere Varianten einer Themenfarbe, indem Farb‑Transformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die [ColorTransformOperation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/colortransformoperation/)‑Aufzählung bereit.

![Hauptthemenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.  
**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke basierend auf `Accent4`, wendet fünf davon Luminanz‑Transformationen an und speichert das Ergebnis:

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

Diese Varianten bleiben an der Themenfarbe ausgerichtet. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `IColorScheme`‑Plätzen zuordnen**

Die [SchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/schemecolor/)‑Aufzählung verwendet `Text1`, `Background1`, `Text2` und `Background2`, während die [IColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icolorscheme/) dieselben Themenplätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; es handelt sich nicht um Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen‑Schriftarten ändern**

Ein Themen‑Schriftartenschema enthält einen Hauptschriftartensatz für Überschriften und einen Nebenschriftartensatz für Fließtext. Die Methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontscheme/) und [IFontScheme.getMinor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontscheme/) stellen diese Sätze bereit.

PowerPoint‑kompatible Themen‑Schriftarten‑Kennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)  
* `+mj-lt` – Heading Font Latin (Major Latin Font)  
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)  
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Themen‑Schriftart verwendet, und eine Textzeile, die die Nebensatz‑Latin‑Themen‑Schriftart verwendet. Anschließend werden die Themen‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschriftart und der Fließtext der Nebenschriftart. Text, dem ein expliziter Schriftartname anstelle einer Themen‑Kennung zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

Die Haupt‑ und Nebenschriftartensammlungen können zudem Schriftzuordnungen für einzelne Schriftsysteme enthalten, etwa Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Skript‑spezifische Themen‑Schriftarten](/slides/de/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tipp" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Es gibt zwei häufige Workflows, die unterschiedliche Probleme lösen.

### **Quell‑Thema beim Verschieben von Folien erhalten**

Wenn Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten möchten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/), und klonen Sie anschließend die Folie mit [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/) sowie den geklonten Master. Dadurch werden Master, Layouts und das zugehörige Thema zusammen transportiert.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das einfache Klonen von Inhalten auf einen nicht verwandten Ziel‑Master kann themen‑gesteuerte Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Themenwerte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie eine Folien‑Ebene‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/) kopieren die drei Haupt‑Themen‑Komponenten in die Überschreibung.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Damit wird das von dieser Folie verwendete Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/) auf.

### **Eine Themen‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Ebene‑Überschreibung gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/layoutslidethememanager/) verwendet werden:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Basisedesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein anderes Styling benötigt, und nur bei echten Ausnahmen eine Folien‑Überschreibung. Übermäßige Folien‑Überschreibungen erschweren die Vorhersagbarkeit späterer globaler Themen‑Änderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anbieten, als die physisch in dieser Sammlung gespeicherten Fülldefinitionen vorhanden sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstil‑Galerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine thematisierte Füllung; positive Werte sind Referenzen auf thematische Hintergrund‑Stile. Das unterscheidet sich von der direkten Java‑Sammlungsindizierung, bei der `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine thematische Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themaintrag sowie von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, kann das Ändern des Master‑Hintergrunds diese Folie unbeeinflusst lassen. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/), wenn Sie den finalen Hintergrund nach Anwendung der Vererbung kennen müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie den Stil‑Index nicht wie einen nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem, eine Stil‑Nummer aus einer Datei hart zu codieren und anzunehmen, dass sie in einer anderen Datei dieselbe Darstellung hat; thematische Stil‑Definitionen sind präsentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/androidjava/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Formatschema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/) und [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/) zugänglich sind. Typische Office‑Themen enthalten häufig drei zentrale Stil‑Einträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Themeneffekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Wenn Sie in Java auf diese Sammlungen zugreifen, ist der Sammlungs‑Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil und `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapestyle/) bereitgestellt wird. Das Modifizieren eines Themen‑Stils wirkt sich auf alle Formen aus, die diesen Themen‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stil‑Einträge existieren, ändert den ersten Linien‑Stil, den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für Formen, die diese Plätze referenzieren, wird der erste Themen‑Linien‑Stil rot, der dritte Themen‑Füll‑Stil zu einem durchgängigen Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung die Themen‑Stile überschreibt.

![Themen‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Wirksame Themen‑Werte auslesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Wirksame Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Überschreibungen aufgelöst wurden. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/).

Das folgende Beispiel liest das wirksame Thema, den Hintergrund und die erste Form‑Füllung einer Folie aus:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Verwenden Sie wirksame Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) untersuchen, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das endgültige Aussehen ändert.

## **FAQ**

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Überschreibungsthema. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen beibehalten wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/) und [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/). So bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die wirksamen Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Thema und die entsprechenden wirksamen‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen zurück.