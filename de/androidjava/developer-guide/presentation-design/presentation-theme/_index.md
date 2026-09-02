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
- Externes Thema
- THMX
- Themenfarbe
- Zusätzliche Palette
- Themenschrift
- Themenstil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Android via Java zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit konsistentem Branding."
---
## **Einleitung**

Ein Präsentationsthema definiert ein abgestimmtes Set aus Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Themen‑aware Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentation‑ebene‑Thema über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) verfügbar. Eine Präsentation kann zudem Themen‑Overrides auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Override, Layout‑Override und Folien‑Override.

![Themenkomponenten: Farben, Schriften, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Themen‑Workflows: ein Thema inspizieren, Farben und Schriften ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Auflösung von Vererbung und Overrides auslesen.

## **Ein Thema inspizieren**

Das [MasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, Schriften‑Schema und Format‑Schema des Themas über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mastertheme/) bereit. Das Inspizieren dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die wichtigsten Thema‑Eigenschaften aus und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf nicht angenommen werden, dass jede Folie dasselbe effektive Thema hat. Inspizieren Sie den Master, der der Folie zugeordnet ist, und verwenden Sie den später in diesem Artikel gezeigten effektiven‑Thema‑Workflow, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Themenfarben ändern**

Themen‑aware Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag in der [IColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icolorscheme/) ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, anhand des neuen Werts aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die Themenfarbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe in der Form, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten aus einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.  
**2** – Aus den Hauptthemenfarben erzeugte hellere und dunklere Varianten.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `Accent4`, wendet für fünf davon Luminanz‑Transformationen an und speichert das Ergebnis:

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

Diese Varianten bleiben an die Themenfarbe gebunden. Ändert sich später `Accent4`, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `IColorScheme`‑Slots zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während die [IColorScheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icolorscheme/) dieselben Themenslots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenslots; sie sind keine Werte, die dynamisch von einer Form in die andere umgewandelt werden.

## **Themen­schriften ändern**

Ein Themen‑Schriften‑Schema enthält ein Hauptschrift‑Set für Überschriften und ein Nebenschrift‑Set für Fließtext. Die Methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontscheme/) und [IFontScheme.getMinor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontscheme/) geben diese Sets frei.

PowerPoint‑kompatible Themen‑Schrift‑Kennungen können in der Textformatierung verwendet werden:

* `+mn‑lt` – Body‑Font Latin (Minor Latin Font)
* `+mj‑lt` – Heading‑Font Latin (Major Latin Font)
* `+mn‑ea` – Body‑Font East Asian (Minor East Asian Font)
* `+mj‑ea` – Heading‑Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Themenschrift verwendet, sowie eine Textzeile, die die Neben‑Latin‑Themenschrift verwendet. Anschließend werden die Themen­schriften geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschrift und der Fließtext der Nebenschrift. Text, dem explizit ein Schriftname anstelle einer Themenkennzeichnung zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriften‑Schema geändert wird.

Die Haupt‑ und Neben‑Schrift‑Sammlungen können zudem Schrift‑Mappings für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Inspizieren, Hinzufügen, Ersetzen oder Entfernen dieser Mappings siehe [Script‑Specific Theme Fonts](/slides/de/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Hinweis" %}}

Weitere Informationen zu Präsentations­schriften finden Sie unter [PowerPoint Fonts](/slides/de/androidjava/powerpoint-fonts/).

{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Die nachfolgenden Workflows lösen unterschiedliche themenbezogene Probleme.

### **Ein externes Thema auf Folien eines Masters anwenden**

Verwenden Sie [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/), wenn Sie eine PowerPoint‑Thema‑Datei (`.thmx`) besitzen und jeden Folie, die von einem bestimmten Master abhängt, neu stylen möchten. Wählen Sie den Master aus der [Presentation.getMasters](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Sammlung, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/) implementiert, und übergeben Sie dem Methodenaufruf den Pfad zur Thema‑Datei.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folien‑Instanz auf Basis des gewählten Masters.  
1. Wendet das externe Thema auf den neuen Master an.  
1. Ordnet den neuen Master allen Folien zu, die zuvor vom gewählten Master abhingen.  
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

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann eine [PptxReadException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxreadexception/) auslösen. Validieren Sie von Benutzern angegebene Pfade, behandeln Sie Zugriffsfehler auf das Dateisystem und speichern Sie die Präsentation erst, nachdem das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom gewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten deren aktuelle Master und Themen bei. Themen‑aware Farben, Schriften, Füllungen, Linien, Hintergründe und Effekte werden anhand des externen Themas aufgelöst. Direkt zugewiesene Farben, Schriften, Füllungen und sonstige explizite Formatierungen können unverändert bleiben. Layout‑ und Folien‑Overrides können ebenfalls Vorrang vor den vom neuen Master geerbten Werten haben.

Das Thema kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistentes Rendering und Export sollten die benötigten Schriften installiert, über [custom font sources](/slides/de/androidjava/custom-font/) bereitgestellt oder [font substitution](/slides/de/androidjava/font-substitution/) konfiguriert werden.

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert keine manuelle Erstellung von Folien‑ oder Layout‑Themen‑Overrides.

### **Verschiedene externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master im Voraus nicht bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mit [ISlide.getLayoutSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/) und [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jedem Abschnitt ein unterschiedliches externes Thema an:

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

Der erste Aufruf betrifft nur Folien, die von `firstGroupMaster` abhängen, der zweite Aufruf betrifft nur Folien, die von `secondGroupMaster` abhängen. Folien, die zu einem anderen Master gehören, werden nicht neu gestylt.

### **Quell‑Thema beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei das ursprüngliche Design beibehalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/), klonen Sie anschließend die Folie mit [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/) und dem geklonten Master. Dadurch werden Master, dessen Layouts und das zugehörige Thema gemeinsam übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das bloße Klonen von Inhalten auf einen fremden Ziel‑Master kann themen‑gesteuerte Farben, Schriften, Hintergründe und Effekte verändern.

### **Themen‑Werte auf eine bestehende Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie ein Folien‑Level‑Override aus dem Quell‑Thema. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/) kopieren die drei Haupt‑Themen‑Komponenten in das Override.

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

Damit wird das von dieser Folie genutzte Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um das lokale Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/overridetheme/) auf.

### **Ein Themen‑Override auf ein Layout anwenden**

Ein Layout‑Level‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihr eigenes Override definiert. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein abweichendes Design benötigt, und ein Folien‑Override nur für echte Ausnahmen. Exzessive Folien‑Level‑Overrides erschweren spätere globale Themen‑Änderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden über [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/) bereitgestellt. PowerPoint kann im UI mehr Hintergrund‑Optionen anzeigen, als tatsächlich in dieser Sammlung definiert sind, weil das UI Thema‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor ein Hintergrund‑Stil verwendet wird, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine thematisierte Füllung; positive Werte verweisen auf themen‑Hintergrund‑Stil‑Referenzen. Das unterscheidet sich vom direkten Indexieren der Java‑Sammlung, bei dem `get_Item(0)` das erste Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füll‑Stilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl an Hintergrund‑Füllungen aus, weist dem ersten Master eine thematisierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Thema‑Eintrag und von möglichen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, ändert sich dieser ggf. nicht, wenn nur der Master‑Hintergrund geändert wird. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/), wenn Sie den endgültigen Hintergrund nach Anwendung der Vererbung ermitteln müssen.

{{% alert color="warning" title="Warnung" %}}

Betrachten Sie den Stil‑Index nicht als null‑basierten Sammlungs‑Index. Vermeiden Sie zudem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei gleich aussieht; Themen‑Stil‑Definitionen sind presentationsspezifisch.

{{% /alert %}}

{{% alert color="info" title="Hinweis" %}}

Für direkte Hintergrund‑Formatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/androidjava/presentation-background/).

{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/) und [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iformatscheme/) bereitgestellt werden. Typische Office‑Themen enthalten oft drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind; Code sollte jedoch jede Sammlung inspizieren, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Themen‑Effekte, auf dieselbe Form angewendet](presentation-design_10.png)

Greift man in Java auf diese Sammlungen zu, ist der Collections‑Index null‑basiert: `get_Item(0)` ist der erste gespeicherte Stil, `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf Formen aus, die diesen Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

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

Für Formen, die diese Slots referenzieren, wird der erste Themen‑Linien‑Stil rot, der dritte Themen‑Füll‑Stil zu einem durchgängigen Waldgrün, und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das exakte visuelle Ergebnis hängt weiterhin davon ab, welchen Stil‑Slot jede Form verwendet und ob direkte Formatierungen das Thema überschreiben.

![Themen‑Effekt‑Stile nach Änderungen an Linie, Füllung und Schatten](presentation-design_11.png)

## **Ermitteln, ob eine effektive einfarbige Füllung eine Themenfarbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert oder von einem Absatz, Layout, Master, Themen‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [IFillFormat.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformat/) auf, um diese Hierarchie in ein unveränderliches [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformateffectivedata/) aufzulösen. Prüfen Sie zuerst [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformateffectivedata/). Nur wenn der Typ `FillType.Solid` ist, sollten Sie die Eigenschaften einer einfarbigen Füllung auslesen.

Für eine einfarbige Füllung liefert [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformateffectivedata/) den final gerenderten RGB‑Wert nach Vererbung, Themen‑Lookup und Farb‑Transformationen. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformateffectivedata/) gibt den zugehörigen logischen [SchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/schemecolor/)‑Slot zurück, z. B. `Text1` oder `Accent6`. Der Wert `SchemeColor.NotDefined` bedeutet, dass die effektive einfarbige Füllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, bei dem Füllungen entweder Themen‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icolorformat/)‑Wert, um eine Füllung zu klassifizieren. Beispielsweise kann ein Textabschnitt keine lokal definierte Schema‑Farbe besitzen, sodass sein lokaler Wert `NotDefined` ist, während seine effektive Füllung eine Themenfarbe erbt und zu `Text1` oder `Accent6` aufgelöst wird. Umgekehrt gibt `getSolidFillSchemeColor` an, welcher logische Themen‑Slot die effektive Farbe erzeugt hat, nicht jedoch, von welchem Objekt, Absatz, Layout, Master oder anderer Ebene der Hierarchie er stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitts‑Füllungen, gibt jeden finalen RGB‑Wert sowie die zugehörige Schema‑Farbe aus und markiert einfarbige Füllungen, die Themen‑Farbänderungen nicht folgen:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
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

Der `NotDefined`‑Zweig liefert eine Prüfliste einfarbiger Füllungen, die nicht auf Änderungen von Themen‑Farb‑Slots reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Erscheinungsbild, während der Schema‑Wert erklärt, ob dieses Erscheinungsbild mit dem Thema verbunden ist.

Effektive Format‑Objekte sind Schnappschüsse. Nachdem Sie das Präsentationsthema, ein Themen‑Override oder eine vererbte Formatierung geändert haben, rufen Sie `getEffective` erneut auf und lesen ein neues `IFillFormatEffectiveData`‑Objekt, bevor Sie Farben vergleichen oder berichten.

## **Effektive Themen‑Werte auslesen**

Roh‑Thema‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form nach Vererbung und lokalen Overrides tatsächlich verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/), für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/).

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) inspizieren, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Override übersehen, der das endgültige Erscheinungsbild ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themas auf jede Folie der Präsentation?**

Nein. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themen.

**Kann ich ein Thema nur auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Thema. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übertragen?**

Beim Verschieben einer Folie und dem Beibehalten des Quell‑Designs klonen Sie den Quell‑Master in das Ziel und klonen die Folie mit diesem Master mittels [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/) und [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/). So bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fillformat/). Diese APIs geben die aufgelösten Werte nach Vererbung und Overrides zurück.