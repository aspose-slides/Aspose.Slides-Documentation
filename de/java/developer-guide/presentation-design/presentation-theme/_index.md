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
- Externes Thema
- THMX
- Themenfarbe
- Zusätzliche Palette
- Themenschriftart
- Themenstil
- Theme-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Java zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit konsistenter Markenidentität."
---
## **Einleitung**

Ein Präsentationsthema definiert einen koordinierten Satz von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Thema‑bewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentations‑Thema über [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) verfügbar. Eine Präsentation kann zudem Themen‑Überschreibungen auf unteren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) überschreiben kann. In der Praxis wird das wirksame Thema für eine Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themen‑Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gebräuchlichsten Themen‑Workflows: ein Thema inspizieren, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und wirksame Werte nach Vererbung und Überschreibungen auslesen.

## **Ein Thema inspizieren**

Das [MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, das Schriftartenschema und das Formatschema des Themas über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) bereit. Diese Sammlungen vor Änderungen zu inspizieren ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, weil die Anzahl und der Inhalt der Stilelemente variieren können.

Das folgende Beispiel liest die wichtigsten Theme‑Eigenschaften und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Theme gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe wirksame Theme hat. Inspizieren Sie den dem Folien‑Layout zugehörigen Master und nutzen Sie den später im Artikel gezeigten wirksamen‑Theme‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Theme‑Farben ändern**

Thema‑bewusste Füllungen, Linien und Texte können auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) verweisen. Wenn Sie den entsprechenden Eintrag im [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Themen‑Farb‑Aktualisierung nicht verändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die Theme‑Farbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die wirksame Füllfarbe aus:

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe rot, nachdem das Theme geändert wurde. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe auf der Form, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint erzeugt hellere und dunklere Varianten einer Themenfarbe durch Farb‑Transformationen. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/) bereit.

![Haupt‑Themenfarben und hellere sowie dunklere Farben, erzeugt aus der zusätzlichen Palette](additional-palette-colors.png)

**1** – Haupt‑Themenfarben.

**2** – Hellere und dunklere Varianten, erzeugt aus den Haupt‑Themenfarben.

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

Diese Varianten bleiben an die Themenfarbe gebunden. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte zu `IColorScheme`‑Slots zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während das [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) dieselben Theme‑Slots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Theme‑Slots; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Theme‑Schriftarten ändern**

Ein Theme‑Schriftartenschema enthält einen Haupt‑Schriftartensatz für Überschriften und einen Neben‑Schriftartensatz für Fließtext. Die Methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) und [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) geben diese Sätze frei.

PowerPoint‑kompatible Theme‑Schriftarten‑Bezeichner können in der Textformatierung verwendet werden:

* `+mn-lt` – Fließtext‑Schriftart Lateinisch (Minor Latin Font)
* `+mj-lt` – Überschrift‑Schriftart Lateinisch (Major Latin Font)
* `+mn-ea` – Fließtext‑Schriftart Ostasiatisch (Minor East Asian Font)
* `+mj-ea` – Überschrift‑Schriftart Ostasiatisch (Major East Asian Font)
* `+mn-cs` – Fließtext‑Schriftart Komplexes Skript (Minor Complex Script Font)
* `+mj-cs` – Überschrift‑Schriftart Komplexes Skript (Major Complex Script Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latein‑Theme‑Schriftart verwendet, und eine Textzeile, die die Neben‑Latein‑Theme‑Schriftart verwendet. Anschließend werden die Theme‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Haupt‑Schriftart und der Fließtext der Neben‑Schriftart. Text, der einen expliziten Schriftartnamen statt eines Theme‑Bezeichners enthält, wechselt nicht automatisch, wenn das Theme‑Schriftartenschema geändert wird.

Die Haupt‑ und Neben‑Schriftartensammlungen können zudem Zuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Inspizieren, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/java/powerpoint-fonts/).
{{% /alert %}}

### **Theme‑Schriftart‑Referenzen auflösen**

Beim Inspizieren von Text kann [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) einen Theme‑Verweis wie `+mn-lt` statt eines Schriftfamiliennamens zurückgeben. Rufen Sie [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) mit dem passenden [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) auf, um diesen Verweis aufzulösen. Die Präfixe `+mj` und `+mn` wählen den Haupt‑ bzw. Neben‑Schriftartensatz; die Suffixe `-lt`, `-ea` und `-cs` wählen deren Latein‑, Ostasien‑ bzw. Komplex‑Skript‑Schriftarten.

Ermitteln Sie das wirksame Theme über [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) am Objekt, dessen Theme auf den zu inspizierenden Text angewendet wird. Für normalen Text auf einer Folie rufen Sie diese Methode an der Folie selbst auf, damit der Kontext das vererbte Theme der Folie und lokale Überschreibungen enthält. Beim Inspizieren eines Layouts oder Masters verwenden Sie dessen eigenes wirksames Theme. Gehen Sie nicht davon aus, dass das Theme des ersten Masters für jede Folie gilt.

Das folgende Beispiel erzeugt einen Textabschnitt, der explizit die Neben‑Latein‑Schriftart referenziert. Es initialisiert das Folien‑Schriftartenschema über [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) und setzt die Haupt‑ und Neben‑Latein‑Familien auf `Arial` bzw. `Calibri`, sodass das Ergebnis ohne Eingabedatei reproduzierbar ist:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Die Ausgabe lautet `+mn-lt -> Calibri` gefolgt von `Verdana -> Verdana`. Der gespeicherte Verweis bleibt unverändert, während ein expliziter Familienname unverändert zurückgegeben wird. Wäre der Abschnitt `+mj-lt` verwendet worden, würde er in diesem Theme zu `Arial` aufgelöst.

Das Auflösen eines Theme‑Verweises bestimmt die durch das Theme angegebene Schriftfamilie. Es prüft nicht die Verfügbarkeit der Schriftart oder welche Schriftdatei letztlich nach Substitution oder Glyph‑Fallback beim Rendern verwendet wird. Siehe [Font Selection Sequence](/slides/de/java/font-selection-sequence/) und [Font Substitution](/slides/de/java/font-substitution/) für diese separaten Schritte.

## **Ein Theme kopieren oder anwenden**

Die nachfolgenden Workflows lösen unterschiedliche problemstellungen rund um Themes.

### **Ein externes Theme auf Folien anwenden, die von einem Master abhängen**

Verwenden Sie [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/), wenn Sie eine PowerPoint‑Theme‑Datei (`.thmx`) haben und jede Folie neu stylen möchten, die von einem bestimmten Master abhängt. Wählen Sie den Master aus der [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Sammlung, die [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) implementiert, und übergeben Sie den Pfad zur Theme‑Datei an die Methode.

Die Methode führt die folgenden Schritte aus:

1. Erstellt einen neuen Master‑Slide basierend auf dem ausgewählten Master.  
2. Wendet das externe Theme auf den neuen Master an.  
3. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.  
4. Gibt den neu erstellten [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) zurück.

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

Ein ungültiges, beschädigtes oder nicht unterstütztes Theme kann eine [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/) auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Zugriffsfehler auf das Dateisystem und speichern Sie die Präsentation erst, nachdem das Theme erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themes. Thema‑bewusste Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Theme aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formatierungen können unverändert bleiben. Layout‑ und Folien‑Überschreibungen können ebenfalls Vorrang vor Werten haben, die vom neuen Master geerbt wurden.

Das Theme kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für ein konsistentes Rendering und Export installieren Sie die erforderlichen Schriftarten, stellen Sie sie über [custom font sources](/slides/de/java/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/java/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert kein manuelles Erzeugen von Folien‑ oder Layout‑Theme‑Überschreibungen.

### **Unterschiedliche externe Themes in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master im Voraus nicht bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) und [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themes anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jeweils ein unterschiedliches externes Theme an:

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

Der erste Aufruf wirkt nur auf Folien, die von `firstGroupMaster` abhingen, der zweite Aufruf nur auf Folien, die von `secondGroupMaster` abhingen. Folien, die einem anderen Master zugeordnet sind, werden nicht neu gestaltet.

### **Ein Quell‑Theme beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei ihr ursprüngliches Design bewahren, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), dann klonen Sie die Folie mit [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) und dem geklonten Master. Damit werden Master, Layouts und das zugehörige Theme zusammengeführt.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das reine Klonen von Inhalten auf einen nicht zugehörigen Ziel‑Master kann Thema‑gesteuerte Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Theme‑Werte auf eine bestehende Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout verbleiben, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Theme. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) kopieren die drei Haupt‑Theme‑Komponenten in die Überschreibung.

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

Damit wird das von dieser Folie verwendete Theme geändert, ohne das von anderen Folien geerbte Theme zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) auf.

### **Ein Theme‑Override auf ein Layout anwenden**

Eine Layout‑Überschreibung gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Theme, wenn viele Layouts und Folien dasselbe Basis‑Design teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides erschweren spätere globale Theme‑Änderungen.

<!-- visual-explanation:presentation-theme:start -->
[![Ein Master‑Theme speist zwei Layouts; ein Layout‑Override beeinflusst seine Folien, außer einer Folie mit einem lokaleren Override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Ein Layout‑Override gilt für Folien, die dieses Layout verwenden, sofern die Folie keinen eigenen Override besitzt. Themenbasierte Werte folgen ihrem aufgelösten Schema; explizit formatierte Objekte können ihr lokales Erscheinungsbild beibehalten. Halten Sie Overrides so eng wie die beabsichtigte Design‑Ausnahme.*
<!-- visual-explanation:presentation-theme:end -->

## **Theme‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themes werden über [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anzeigen, als tatsächlich in dieser Sammlung definiert sind, weil das UI Theme‑Füllungen mit Theme‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstil‑Galerie für ein Präsentations‑Theme](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, inspizieren Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/). Ein Stil‑Index von `0` bedeutet keine thematisierte Füllung; positive Werte sind Referenzen auf thematisierte Hintergrund‑Stile. Dies unterscheidet sich vom direkten Indexieren der Java‑Sammlung, bei dem `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstil‑Einträgen enthält.

Das folgende Beispiel meldet die verfügbare Anzahl von Hintergrund‑Füllungen, weist dem ersten Master eine thematisierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom Theme‑Eintrag ab, auf den der Master verweist, sowie von etwaigen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene. Verwendet eine Folie ihren eigenen Hintergrund, ändert das Ändern nur des Master‑Hintergrunds diese Folie möglicherweise nicht. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung wissen müssen.

{{% alert color="warning" title="Warning" %}}
Betrachten Sie den Stil‑Index nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei das gleiche Aussehen hat; Theme‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/java/presentation-background/).
{{% /alert %}}

## **Theme‑Effekte aktualisieren**

Ein Theme‑Formatschema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) und [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) zugänglich sind. Typische Office‑Themes enthalten oft drei Haupteinträge, die visuell subtil, moderat und intensiv formatiert sind, aber der Code sollte jede Sammlung inspizieren, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Theme‑Effekte, angewendet auf dieselbe Form](presentation-design_10.png)

Greift man in Java auf diese Sammlungen zu, ist der Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil und `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Theme‑Stils wirkt sich auf Formen aus, die diesen Theme‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stil‑Einträge vorhanden sind, ändert den ersten Linien‑Stil, den dritten Füll‑Stil und aktiviert einen äußeren Schatten im dritten Effekt‑Stil, und speichert das Ergebnis:

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

Für Formen, die diese Slots referenzieren, wird der erste Theme‑Linien‑Stil rot, der dritte Theme‑Füll‑Stil zu solidem Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einer Distanz von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung den Theme‑Wert überschreibt.

![Theme‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Theme‑Füll‑ und Linien‑Stile für eine Form auswählen**

Eine Form kann ihre Füllung und Kontur unabhängig über [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) bzw. [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) auswählen. Für beide Methoden wählt Index `1` den ersten Eintrag in der jeweiligen Theme‑Sammlung (`get_Item(0)`), Index `2` den zweiten (`get_Item(1)`).

Das folgende Beispiel legt zwei Füll‑Stile (Gold und Himmelblau) und zwei Linien‑Stile (dunkelblau 6 pt und dunkelrot 12 pt) im Standard‑Theme einer neuen Präsentation an. Es speichert die Folie in drei Phasen, sodass Sie die Ergebnisse in PowerPoint vergleichen können:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Anfangsstile | Rechte Kontur ändern | Erster Theme‑Füllstil bearbeiten |
|:---:|:---:|:---:|
| ![Gold‑ und Himmelblau‑Rechtecke mit passender dünner dunkelblauer Kontur](theme-style-initial.png) | ![Das Himmelblau‑Rechteck hat jetzt eine dicke dunkelrote Kontur](theme-style-line-changed.png) | ![Das linke Rechteck ist jetzt grün, beide Konturen bleiben unverändert](theme-style-fill-changed.png) |

Das Auswählen eines anderen Linien‑Stils ändert nur die Kontur des rechten Rechtecks. Das Bearbeiten des ersten Theme‑Füllstils aktualisiert jede Form, die ihn verwendet. Hier wird nur das linke Rechteck grün.

Auf einer bestehenden Form kann eine lokale Füll‑, Linien‑ oder Linien‑Breiten‑Farbe diesen Teil des Theme‑Stils überschreiben. Wenn das Ändern eines Stil‑Indexes keine sichtbare Wirkung zeigt, prüfen Sie die [direct formatting](/slides/de/java/shape-formatting/) der Form.

## **Ermitteln, ob eine wirksame Voll‑Füllung eine Theme‑Farbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder von einem Absatz, Layout, Master, Theme‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) auf, um diese Hierarchie in ein unveränderliches [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) aufzulösen. Prüfen Sie zuerst [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). Nur wenn dieser `FillType.Solid` ist, sollten Sie die Eigenschaften einer Voll‑Füllung auslesen.

Für eine Voll‑Füllung liefert [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) den finalen gerenderten RGB‑Wert nach Vererbung, Theme‑Lookup und Farb‑Transformationen. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) gibt das zugehörige logische [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/)‑Slot zurück, z. B. `Text1` oder `Accent6`. Ein Wert von `SchemeColor.NotDefined` bedeutet, dass die wirksame Voll‑Füllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, in dem Füllungen entweder Theme‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen Wert von [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) zur Klassifizierung einer Füllung. Ein Textabschnitt kann lokal keinen Schema‑Farbwert haben (also `NotDefined`), während seine wirksame Füllung eine Theme‑Farbe erbt und zu `Text1` oder `Accent6` aufgelöst wird. Umgekehrt sagt Ihnen `getSolidFillSchemeColor`, welches logische Theme‑Slot die wirksame Farbe erzeugt hat, nicht jedoch, von welchem Objekt, Absatz, Layout, Master oder anderer Ebene es stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitt‑Füllungen, gibt jeden finalen RGB‑Wert und den zugehörigen Schema‑Farbwert aus und markiert Voll‑Füllungen, die Theme‑Farbänderungen nicht folgen:

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

Der `NotDefined`‑Zweig liefert eine Prüf‑Liste von Voll‑Füllungen, die nicht auf Theme‑Farb‑Slots reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während der Schema‑Wert erklärt, ob dieses Aussehen mit dem Theme verknüpft ist.

Wirksame‑Format‑Objekte sind Momentaufnahmen. Nachdem Sie das Präsentations‑Theme, ein Theme‑Override oder irgendeine vererbte Formatierung geändert haben, rufen Sie erneut `getEffective` auf und lesen ein neues `IFillFormatEffectiveData`‑Objekt, bevor Sie Farben vergleichen oder melden.

## **Wirksame Theme‑Werte auslesen**

Roh‑Theme‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Wirksame Werte zeigen, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Overrides verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/).

Das folgende Beispiel liest das wirksame Theme, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwenden Sie wirksame Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) inspizieren, können Sie einen Master, Layout, Folien‑ oder Form‑Override übersehen, der das finale Erscheinungsbild ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themes auf jede Folie der Präsentation?**

Nein. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master nutzen, behalten ihre bestehenden Themes.

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Theme. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre vorhandenen Themes.

**Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übertragen?**

Beim Verschieben einer Folie und dem Erhalt ihres Quell‑Designs klonen Sie den Quell‑Master in das Ziel und klonen die Folie mit diesem Master über [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) und [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/). So bleiben Master, Layouts und Theme zusammen.

**Wie kann ich die wirksamen Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) für ein Folien‑ oder Layout‑Theme und die entsprechenden wirksamen‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) und [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/). Diese APIs geben die aufgelösten Werte nach Vererbung und Overrides zurück.