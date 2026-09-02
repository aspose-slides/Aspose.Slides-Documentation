---
title: Verwalten von Präsentationsthemen auf Android
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/androidjava/presentation-theme/
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
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Android über Java erstellen, anpassen und PowerPoint-Dateien mit einheitlichem Branding konvertieren."
---
## **Einleitung**

Ein Präsentationsthema definiert einen koordinierten Satz von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsam genutzten Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das präsentationsweite Thema über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) verfügbar. Eine Präsentation kann außerdem Themenüberschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette ermittelt: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themen‑Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Themen‑Workflows: ein Thema inspizieren, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Überschreibungen auslesen.

## **Ein Thema inspizieren**

Das [MasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, das Schriftartenschema und das Formatschema des Themas über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/) bereit. Das Inspizieren dieser Sammlungen vor Änderungen ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt an, wie viele Hintergrund-, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Thema hat. Inspiziere den dem Folienlayout zugeordneten Master und nutze den später in diesem Artikel gezeigten effektiven‑Themen‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themenfarben ändern**

Themenbewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in [IColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icolorscheme/) ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht verändert.

Das folgende End‑zu‑End‑Beispiel erzeugt eine Form, die `Accent4` verwendet, ändert die Themen‑Farbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung Rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe in der Form, wirken spätere Änderungen von `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten aus einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke basierend auf `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

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

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icolorscheme/) dieselben Themenplätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen‑Schriftarten ändern**

Ein Themen‑Schriftartenschema enthält einen Satz von Hauptschriftarten für Überschriften und einen Satz von Nebenschriftarten für Fließtext. Die Methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontscheme/) und [IFontScheme.getMinor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontscheme/) geben diese Sätze zurück.

PowerPoint‑kompatible Themen‑Schriftart‑Kennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Nebenschriftart Latein)
* `+mj-lt` – Heading Font Latin (Hauptschriftart Latein)
* `+mn-ea` – Body Font East Asian (Nebenschriftart Ostasiatisch)
* `+mj-ea` – Heading Font East Asian (Hauptschriftart Ostasiatisch)

Das folgende Beispiel erzeugt eine Überschrift, die die Haupt‑Latein‑Themen­schriftart verwendet, und eine Textzeile, die die Neben‑Latein‑Themen­schriftart verwendet. Anschließend werden die Themen‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschriftart und der Fließtext der Nebenschriftart. Text, dem ein expliziter Schriftartname statt einer Themenkennung zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

Die Haupt‑ und Nebenschriftartensammlungen können außerdem Schriftart‑Zuordnungen für einzelne Schriftsysteme wie Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana enthalten. Zum Inspizieren, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zu Präsentationsschriftarten finden Sie unter [PowerPoint Fonts](/slides/de/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Die nachstehenden Workflows lösen verschiedene themenbezogene Probleme.

### **Ein externes Thema auf Folien anwenden, die von einem Master abhängen**

Verwenden Sie [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/), wenn Sie eine PowerPoint‑Themadatei (`.thmx`) besitzen und alle Folien neu gestalten möchten, die von einem bestimmten Master abhängen. Wählen Sie den Master aus der [Presentation.getMasters](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Sammlung aus, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/) implementiert, und übergeben Sie den Pfad zur Themadatei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folie basierend auf dem ausgewählten Master.  
1. Wendet das externe Thema auf den neuen Master an.  
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhängig waren.  
1. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/) zurück.

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

Eine ungültige, beschädigte oder nicht unterstützte Themadatei kann eine [PptxReadException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxreadexception/) auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Dateisystem‑Zugriffsfehler und speichern Sie die Präsentation erst, nachdem das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten deren vorhandene Master und Themen. Themenbewusste Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formatierungen können unverändert bleiben. Layout‑ und Folien‑Überschreibungen können ebenfalls Vorrang vor den aus dem neuen Master geerbten Werten haben.

Das Thema kann Schriftarten referenzieren, die zur Laufzeit nicht verfügbar sind. Für konsistente Darstellung und Export installieren Sie die erforderlichen Schriftarten, stellen sie über [custom font sources](/slides/de/androidjava/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/androidjava/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert keine manuelle Erstellung von Folien‑ oder Layout‑Themen‑Überschreibungen.

### **Verschiedene externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Vorfeld bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [ISlide.getLayoutSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/) und [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jedem Bereich ein anderes externes Thema an:

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

Der erste Aufruf wirkt nur auf Folien, die von `firstGroupMaster` abhängen, der zweite Aufruf nur auf Folien, die von `secondGroupMaster` abhängen. Folien, die einem anderen Master zugeordnet sind, werden nicht neu gestaltet.

### **Ein Quell‑Thema beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei ihr ursprüngliches Design bewahren, klonen Sie den Quell‑Master in die Zielpräsentation mit [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/), klonen anschließend die Folie mit [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/) und dem geklonten Master. Damit werden Master, Layouts und das zugehörige Thema gemeinsam übertragen.

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

Dies ist der empfohlene Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das bloße Klonen von Inhalten auf einen fremden Ziel‑Master kann themenabhängige Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Themenwerte auf einer bestehenden Folie anwenden**

Muss die Ziel‑Folie ihren aktuellen Master und ihr Layout behalten, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/) kopieren die drei Haupt‑Themenkomponenten in die Überschreibung.

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

Damit wird das von dieser Folie genutzte Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/) auf.

### **Eine Themen‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Überschreibung gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung hat. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein abweichendes Design benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Überschreibungen erschweren die Vorhersagbarkeit späterer globaler Themenänderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/) gespeichert. PowerPoint kann in seiner Benutzeroberfläche mehr Hintergrund‑Optionen anzeigen, als tatsächlich in dieser Sammlung definiert sind, da die UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, inspizieren Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine themenbasierte Füllung; positive Werte sind Referenzen auf Themen‑Hintergrundstile. Dies unterscheidet sich vom direkten Indexieren der Java‑Sammlung, bei dem `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation die gleiche Anzahl an Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl an Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbasierte Hintergrundreferenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom Thema‑Eintrag ab, auf den der Master verweist, sowie von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene. Verwendet eine Folie einen eigenen Hintergrund, ändert sich dieser möglicherweise nicht, wenn nur der Master‑Hintergrund geändert wird. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/), wenn Sie den finalen Hintergrund nach angewandter Vererbung benötigen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie den Stil‑Index nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem, eine Stil‑Nummer aus einer Datei hart zu kodieren und anzunehmen, dass sie in einer anderen Datei identisch aussieht; Themen‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/androidjava/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Formatschema enthält separate Sammlungen für Füll‑, Linien‑ und Effektstile, die über [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/) und [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/) zugänglich sind. Typische Office‑Themen enthalten häufig drei primäre Stileinträge, die visuell subtilen, moderaten und intensiven Formatierungen entsprechen, jedoch sollte der Code jede Sammlung prüfen, anstatt eine feste Anzahl anzunehmen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dieselbe Form angewendet wurden](presentation-design_10.png)

Wenn Sie in Java auf diese Sammlungen zugreifen, ist der Sammlungs‑Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil und `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf Formen aus, die diesen Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linienstil, den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effektstil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Themen‑Linienstil rot, der dritte Themen‑Füllstil zu einem satten Waldgrün und der dritte Effektstil erhält einen äußeren Schatten mit einer Distanz von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung die Themen‑Stile überschreibt.

![Themen‑Effektstile nach Änderung von Linie, Füllung und Schatteneinstellungen](presentation-design_11.png)

## **Effektive Themen‑Werte auslesen**

Roh‑Themenobjekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Überschreibungen aufgelöst wurden. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) inspizieren, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Überschreibung überssehen, die das endgültige Aussehen ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themas auf jede Folie der Präsentation?**

Nein. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themen.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Überschreibungsthema. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Wie übertrage ich ein Thema am sichersten von einer Präsentation in eine andere?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren möchten, klonen Sie den Quell‑Master in das Ziel und klonen die Folie mit diesem Master mittels [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/) und [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Formatobjekte wie [Background.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/). Diese APIs liefern die aufgelösten Werte nach angewandter Vererbung und Überschreibung.