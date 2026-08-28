---
title: Verwalten von Präsentationsthemen in Java
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/java/presentation-theme/
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
- Themen-Schriftart
- Themenstil
- Themaeffekt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Java zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit einheitlichem Branding."
---
## **Einleitung**

Ein Präsentationsthema definiert ein koordiniertes Set aus Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das thema‑bezogene Thema auf Präsentationsebene über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) verfügbar. Eine Präsentation kann außerdem Themen‑Overrides auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Override, Layout‑Override und Folien‑Override.

![Theme‑Komponenten: Farben, Schriften, Hintergrundstile und Effekte](theme-constituents.png)

Die folgenden Abschnitte zeigen die häufigsten Workflows zum Thema: ein Thema untersuchen, Farben und Schriften ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Overrides auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, Schriftschema und Format‑Schema des Themas über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/) bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, weil die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf nicht davon ausgegangen werden, dass jede Folie dasselbe effektive Thema hat. Untersuchen Sie den dem Layout zugehörigen Master und verwenden Sie den später in diesem Artikel gezeigten effektiven‑Thema‑Workflow, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Themenfarben ändern**

Themenbewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in [IColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorscheme/) ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die Themenfarbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe in der Form, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten aus einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/java/com.aspose.slides/colortransformoperation/) bereit.

![Haupt‑Themenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Haupt‑Themenfarben.

**2** – Hellere und dunklere Varianten, die aus den Haupt‑Themenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke basierend auf `Accent4`, wendet auf fünf davon Luminanz‑Transformationen an und speichert das Ergebnis:

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

Diese Varianten bleiben auf der Themenfarbe basiert. Wenn `Accent4` später geändert wird, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **SchemeColor‑Werte den IColorScheme‑Slots zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorscheme/) dieselben Themenslots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist festgelegt:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenslots; sie sind keine Werte, die dynamisch von einer Form zur anderen konvertiert werden.

## **Themen‑Schriften ändern**

Ein Themen‑Schriftenschema enthält einen Majorschriftensatz für Überschriften und einen Minorschriftensatz für Fließtext. Die Methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontscheme/) und [IFontScheme.getMinor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontscheme/) geben diese Sätze zurück.

PowerPoint‑kompatible Themen‑Schrift‑Kennungen können bei der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Majorschrift Latin des Themas verwendet, und eine Textzeile, die die Minorschrift Latin des Themas verwendet. Anschließend werden die Themen‑Schriften geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Majorschrift und der Fließtext der Minorschrift. Text, dem ein expliziter Schriftname anstelle einer Themen‑Kennung zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriftenschema geändert wird.

Die Majors- und Minors‑Schriftensammlungen können außerdem Schriftzuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Weitere Informationen zu Präsentations‑Schriften finden Sie unter [PowerPoint Fonts](/slides/de/java/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Die nachstehenden Workflows lösen verschiedene themenbezogene Probleme.

### **Ein externes Thema auf von einem Master abhängige Folien anwenden**

Verwenden Sie [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/), wenn Sie eine PowerPoint‑Themadatei (`.thmx`) haben und jede Folie neu stylen möchten, die von einem bestimmten Master abhängt. Wählen Sie den Master aus der [Presentation.getMasters](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Sammlung, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/) implementiert, und übergeben Sie den Pfad zur Themadatei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folien‑Instanz basierend auf dem ausgewählten Master.
1. Wendet das externe Thema auf den neuen Master an.
1. Ordnet den neuen Master allen Folien zu, die vorher von dem ausgewählten Master abhängig waren.
1. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) zurück.

Das folgende Beispiel wendet ein externes Thema auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann eine [PptxReadException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxreadexception/) auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Zugriffsfehler auf das Dateisystem und speichern Sie die Präsentation erst, wenn das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhängig waren, werden neu zugewiesen. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themen. Themen‑bewusste Farben, Schriften, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriften, Füllungen und andere explizite Formatierungen können unverändert bleiben. Overrides auf Layout‑ oder Folien‑Ebene können ebenfalls Vorrang vor den aus dem neuen Master geerbten Werten haben.

Das Thema kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht vorhanden sind. Für konsistente Darstellung und Export installieren Sie die erforderlichen Schriften, stellen Sie sie über [custom font sources](/slides/de/java/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/java/font-substitution/).

Dies ist ein direkter Workflow auf Master‑Ebene: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert nicht das manuelle Erstellen von Theme‑Overrides auf Folien‑ oder Layout‑Ebene.

### **Verschiedene externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, holen Sie ihn über [ISlide.getLayoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/) und [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/) von einer repräsentativen Folie. Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet für jede Gruppe ein anderes externes Thema an:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Der erste Aufruf wirkt nur auf Folien, die von `firstGroupMaster` abhängen, und der zweite Aufruf nur auf Folien, die von `secondGroupMaster` abhängen. Folien, die zu anderen Mastern gehören, werden nicht neu gestaltet.

### **Ein Quell‑Thema beim Verschieben von Folien beibehalten**

Wenn Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten möchten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/), klonen Sie anschließend die Folie mit [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/) und dem geklonten Master. Dadurch werden Master, seine Layouts und das zugehörige Thema zusammen übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das einfache Klonen von Inhalten auf einen nicht zugehörigen Ziel‑Master kann themenabhängige Farben, Schriften, Hintergründe und Effekte ändern.

### **Themen‑Werte auf eine bestehende Folie anwenden**

Wenn die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben soll, initialisieren Sie einen Folien‑Override aus dem Quell‑Thema. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/) kopieren die drei Haupt‑Themen‑Komponenten in den Override.

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

Damit wird das von dieser Folie genutzte Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um den lokalen Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/) auf.

### **Ein Theme‑Override auf ein Layout anwenden**

Ein Layout‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie keinen eigenen Override hat. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, einen Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt, und einen Folien‑Override nur für echte Ausnahmen. Zu viele Folien‑Overrides erschweren spätere globale Themen‑Änderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/) gespeichert. PowerPoint kann im UI mehr Hintergrundoptionen anbieten, als tatsächlich in dieser Sammlung definiert sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, untersuchen Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine themenbezogene Füllung; positive Werte sind Referenzen zu themenbezogenen Hintergrundstilen. Dies unterscheidet sich von der direkten Indizierung der Java‑Sammlung, bei der `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation die gleiche Anzahl an Hintergrund‑Füllungsstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl an Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbezogene Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themaintrag sowie von möglichen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, kann das Ändern nur des Master‑Hintergrunds diese Folie nicht beeinflussen. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/), wenn Sie den finalen Hintergrund nach angewendeter Vererbung kennen müssen.

{{% alert color="warning" title="Warning" %}}
Betrachten Sie den Stil‑Index nicht als null‑basierte Sammlungs‑Indexierung. Vermeiden Sie außerdem das Hard‑Coding einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei das gleiche Aussehen hat; Themen‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/java/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für Füll‑, Linien‑ und Effektstile, die über [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/) und [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/) bereitgestellt werden. Typische Office‑Themen enthalten häufig drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Wenn Sie in Java auf diese Sammlungen zugreifen, ist der Sammlungs‑Index null‑basiert: `get_Item(0)` ist der erste gespeicherte Stil und `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils beeinflusst Formen, die diesen Themen‑Stil referenzieren; Formen mit direkter Formatierung können unverändert bleiben.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linien‑Stil, den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Slots referenzieren, wird der erste Themen‑Linienstil rot, der dritte Themen‑Füllstil zu einem kräftigen Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung den Themenstil überschreibt.

![Themen‑Effekt‑Stile nach Änderungen von Linie, Füllung und Schatten](presentation-design_11.png)

## **Ermitteln, ob eine effektive Voll‑Füllung eine Themen‑Farbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder von einem Absatz, Layout, Master, Themen‑Stil oder einer anderen Formatierungs‑Ebene geerbt werden. Rufen Sie [IFillFormat.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifillformat/) auf, um diese Hierarchie in ein unveränderliches [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifillformateffectivedata/) aufzulösen. Prüfen Sie zuerst [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifillformateffectivedata/). Nur wenn es `FillType.Solid` ist, sollten Sie die Eigenschaften einer Voll‑Füllung auslesen.

Für eine Voll‑Füllung liefert [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifillformateffectivedata/) den endgültigen gerenderten RGB‑Wert nach Vererbung, Themen‑Lookup und Farb‑Transformationen. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifillformateffectivedata/) gibt das zugehörige logische [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/schemecolor/)‑Slot zurück, z. B. `Text1` oder `Accent6`. Ein Wert von `SchemeColor.NotDefined` bedeutet, dass die effektive Voll‑Füllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, bei dem Füllungen entweder Themen‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorformat/)‑Wert, um eine Füllung zu klassifizieren. Zum Beispiel kann ein Textabschnitt keine lokal definierte Schema‑Farbe haben, sodass sein lokaler Wert `NotDefined` ist, während seine effektive Füllung eine Themenfarbe erbt und zu `Text1` oder `Accent6` aufgelöst wird. Umgekehrt sagt Ihnen `getSolidFillSchemeColor`, welches logische Themen‑Slot die effektive Farbe erzeugt hat, aber nicht, ob dieses Slot vom Objekt, Absatz, Layout, Master oder einer anderen Ebene stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitt‑Füllungen, gibt jeweils den finalen RGB‑Wert und die zugehörige Schema‑Farbe aus und markiert Voll‑Füllungen, die Themen‑Farbänderungen nicht folgen:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Der `NotDefined`‑Zweig liefert eine Audit‑Liste von Voll‑Füllungen, die nicht auf Änderungen von Themen‑Farb‑Slots reagieren. Prüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Erscheinungsbild, während der Schema‑Wert erklärt, ob dieses Erscheinungsbild mit dem Thema verbunden ist.

Effektive Format‑Objekte sind Momentaufnahmen. Nach einer Änderung des Präsentations‑Themas, eines Themen‑Overrides oder einer anderen geerbten Formatierung rufen Sie `getEffective` erneut auf und lesen ein neues `IFillFormatEffectiveData`‑Objekt, bevor Sie Farben vergleichen oder berichten.

## **Effektive Themen‑Werte auslesen**

Roh‑Thema‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Overrides verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierungen und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) untersuchen, können Sie einen Master-, Layout-, Folien‑ oder Form‑Override übersehen, der das endgültige Erscheinungsbild verändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themas auf jede Folie der Präsentation?**

Nein. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) weist nur die Folien neu zu, die vom ausgewählten Master abhängig sind. Folien, die andere Master verwenden, behalten ihre bestehenden Themen bei.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Thema. Die Änderung bleibt lokal auf dieser Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übernehmen?**

Wenn Sie eine Folie bewegen und ihr ursprüngliches Aussehen beibehalten wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mithilfe von [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/) und [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Overrides zurück.