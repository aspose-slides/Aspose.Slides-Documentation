---
title: Präsentationsthemen in Java verwalten
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
- Externes Thema
- THMX
- Themenfarbe
- Zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Java erstellen, anpassen und PowerPoint-Dateien mit konsistentem Branding konvertieren."
---
## **Einleitung**

Ein Präsentationsthema definiert ein koordiniertes Set von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themen‑aware Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte auf einmal aktualisieren kann.

In Aspose.Slides ist das Präsentation‑Level‑Thema über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) verfügbar. Eine Präsentation kann außerdem Themen‑Overrides auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Override, Layout‑Override und Folien‑Override.

![Themenkomponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gebräuchlichsten Themen‑Workflows: ein Thema untersuchen, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Overrides auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, das Schriftartenschema und das Format‑Schema des Themas über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/mastertheme/) bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders hilfreich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

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

Verwendet eine Datei mehrere Master, darf nicht davon ausgegangen werden, dass jede Folie dasselbe effektive Thema hat. Untersuchen Sie den dem Slide zugehörigen Master und nutzen Sie den später im Artikel gezeigten Workflow für effektive Themen, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Theme‑Farben ändern**

Themen‑aware Füllungen, Linien und Texte können auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/schemecolor/) verweisen. Wenn Sie den entsprechenden Eintrag in [IColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorscheme/) ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Themen‑Farb‑Update nicht geändert.

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach dem Themenwechsel rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe in der Form, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint erzeugt hellere und dunklere Varianten einer Themenfarbe, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/java/com.aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und hellere sowie dunklere Farben, die aus der zusätzlichen Palette erzeugt wurden](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `Accent4`, wendet auf fünf davon Luminanz‑Transformationen an und speichert das Ergebnis:

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

### **Zuordnen von `SchemeColor`‑Werten zu `IColorScheme`‑Plätzen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/icolorscheme/) dieselben Themenplätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; es handelt sich nicht um Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Theme‑Schriftarten ändern**

Ein Themen‑Schriftartenschema enthält einen Hauptschriftset für Überschriften und einen Nebenschriftset für Fließtext. Die Methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontscheme/) und [IFontScheme.getMinor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontscheme/) geben diese Sätze frei.

PowerPoint‑kompatible Themen‑Schriftart‑Identifier können in der Textformatierung verwendet werden:

* `+mn-lt` – Body‑Font Latin (Minor Latin Font)
* `+mj-lt` – Heading‑Font Latin (Major Latin Font)
* `+mn-ea` – Body‑Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading‑Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Themen‑Schriftart verwendet, und eine Textzeile, die die Neben‑Latin‑Themen‑Schriftart nutzt. Anschließend werden die Themen‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschriftart und der Fließtext der Neben‑Schriftart. Text, dem ein expliziter Schriftartname anstelle eines Themen‑Identifiers zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

Die Haupt‑ und Neben‑Schriftartensammlungen können zudem Schriftzuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Weitere Informationen zu Präsentationsschriftarten finden Sie unter [PowerPoint Fonts](/slides/de/java/powerpoint-fonts/).
{{% /alert %}}

## **Theme kopieren oder anwenden**

Die nachfolgenden Workflows lösen verschiedene themenbezogene Probleme.

### **Ein externes Theme auf die von einem Master abhängigen Folien anwenden**

Verwenden Sie [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/), wenn Sie eine PowerPoint‑Themen‑Datei (`.thmx`) besitzen und jede Folie neu stylen möchten, die von einem bestimmten Master abhängt. Wählen Sie den Master aus der [Presentation.getMasters](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Sammlung, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/) implementiert, und übergeben Sie den Pfad zur Themen‑Datei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folie basierend auf dem ausgewählten Master.
1. Wendet das externe Theme auf den neuen Master an.
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.
1. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) zurück.

Das folgende Beispiel wendet ein externes Theme auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

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

Ein ungültiges, beschädigtes oder nicht unterstütztes Theme kann eine [PptxReadException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxreadexception/) auslösen. Validieren Sie vom Benutzer angegebene Pfade, behandeln Sie Dateisystem‑Zugriffsfehler und speichern Sie die Präsentation erst, nachdem das Theme erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themes. Themen‑aware Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Theme aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formatierungen können unverändert bleiben. Layout‑ und Folien‑Overrides können ebenfalls Vorrang vor den vom neuen Master vererbten Werten haben.

Das Theme kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistentes Rendering und Export installieren Sie die benötigten Schriftarten, stellen Sie sie über [custom font sources](/slides/de/java/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/java/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert kein manuelles Erstellen von Folien‑ oder Layout‑Overrides.

### **Verschiedene externe Themes in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master im Voraus nicht bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [ISlide.getLayoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/) und [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themes anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, um deren Master zu ermitteln, und wendet jedem Gruppe ein unterschiedliches externes Theme an:

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

Der erste Aufruf betrifft nur Folien, die von `firstGroupMaster` abhängen, der zweite Aufruf betrifft nur Folien, die von `secondGroupMaster` abhängen. Folien, die zu einem anderen Master gehören, bleiben unverändert.

### **Ein Quell‑Theme beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und ihr Original‑Design beibehalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/), klonen Sie anschließend die Folie mit [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/) und dem geklonten Master. Damit werden Master, Layouts und das zugehörige Theme zusammen übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das bloße Klonen von Inhalten auf einen nicht zugehörigen Ziel‑Master kann themenbasierte Farben, Schriftarten, Hintergründe und Effekte verändern.

### **Theme‑Werte auf einer bestehenden Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie einen Folien‑Override aus dem Quell‑Theme. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/) kopieren die drei Haupt‑Themen‑Komponenten in den Override.

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

Damit wird das von dieser Folie genutzte Theme geändert, ohne das von anderen Folien geerbte Theme zu beeinflussen. Um den lokalen Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/overridetheme/) auf.

### **Ein Theme‑Override auf ein Layout anwenden**

Ein Layout‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie keinen eigenen Override besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Theme, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein unterschiedliches Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides machen spätere globale Themenänderungen schwer vorhersehbar.

## **Hintergrund‑Stile des Themes aktualisieren**

Die Hintergrund‑Füllungen des Themes werden in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anbieten, als tatsächlich in dieser Sammlung definiert sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrund‑Stil verwenden, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine thematisierte Füllung; positive Werte verweisen auf themenbasierte Hintergrund‑Stil‑Referenzen. Das unterscheidet sich vom direkten Indexieren der Java‑Sammlung, wo `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl an Hintergrund‑Füll‑Stilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine thematisierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Theme‑Eintrag und von etwaigen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie einen eigenen Hintergrund, kann das Ändern nur des Master‑Hintergrunds diese Folie unverändert lassen. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/), wenn Sie den finalen Hintergrund nach angewandter Vererbung benötigen.

{{% alert color="warning" title="Warning" %}}
Behandeln Sie den Stil‑Index nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei dieselbe Darstellung hat; Theme‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrund‑Formatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/java/presentation-background/).
{{% /alert %}}

## **Theme‑Effekte aktualisieren**

Ein Theme‑Format‑Schema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/) und [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/java/com.aspose.slides/iformatscheme/) bereitgestellt werden. Typische Office‑Themes enthalten oft drei Haupteinträge, die visuell subtilen, moderaten und intensiven Formatierungen entsprechen, aber der Code sollte jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Theme‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Greift man in Java auf diese Sammlungen zu, ist der Sammlungs‑Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil und `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Theme‑Stils beeinflusst Formen, die auf diesen Theme‑Stil verweisen; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die benötigten Stil‑Einträge existieren, ändert den ersten Linien‑Stil, den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Theme‑Linien‑Stil rot, der dritte Theme‑Füll‑Stil zu einem satten Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einer Distanz von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welchen Stil‑Platz jede Form referenziert und ob direkte Formatierung den Theme‑Wert überschreibt.

![Theme‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten](presentation-design_11.png)

## **Effektive Theme‑Werte auslesen**

Roh‑Theme‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Overrides aufgelöst wurden. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/).

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Untersuchen Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/), können Sie ein Master‑, Layout‑, Folien‑ oder Form‑Override übersehen, das das endgültige Erscheinungsbild ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themes auf jede Folie der Präsentation?**

Nein. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master nutzen, behalten ihre bestehenden Themes.

**Kann ich ein Theme nur auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Theme. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre vorhandenen Themes.

**Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master über [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/) und [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/). Damit bleiben Master, Layouts und Theme zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Theme und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/java/com.aspose.slides/fillformat/). Diese APIs liefern die aufgelösten Werte nach Anwendung von Vererbung und Overrides.