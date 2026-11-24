---
title: Präsentationsthemen in Python via Java verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/python-java/presentation-theme/
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
- Python
- Java
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für Python via Java zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit einheitlicher Markenidentität."
---
## **Einleitung**

Ein Präsentationsthema definiert einen abgestimmten Satz von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Theme‑bewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das präsentationsweite Thema über [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) verfügbar. Eine Präsentation kann zudem Themen‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Thema über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) überschreiben kann. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette ermittelt: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themenkomponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gebräuchlichsten Themen‑Workflows: ein Thema inspizieren, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Auflösung von Vererbung und Überschreibungen auslesen.

## **Ein Thema inspizieren**

Das [MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/)‑Objekt stellt das Farbschema, das Schriftartenschema und das Formatschema des Themas über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme) bereit. Diese Sammlungen zu inspizieren, bevor man sie ändert, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, weil die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()

    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Thema hat. Inspiziere den dem Folienobjekt zugehörigen Master und nutze den später in diesem Artikel gezeigten effektiven‑Thema‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themenfarben ändern**

Theme‑bewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) beziehen. Wenn man den entsprechenden Eintrag im [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) ändert, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die `Accent4`‑Farbe des Themas zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)

    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung Rot. Ersetzt man die Schema‑Farbe durch eine direkte Farbe auf der Form, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint erzeugt hellere und dunklere Varianten einer Themenfarbe, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Diese Varianten bleiben an der Themenfarbe ausgerichtet. Ändert sich später `Accent4`, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte zu `ColorScheme`‑Slots zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während das [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) dieselben Themenslots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fix:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenslots; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen­schriftarten ändern**

Ein Themen‑Schriftartenschema enthält ein Haupt‑Schriftset für Überschriften und ein Neben‑Schriftset für Fließtext. Die Methoden [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) und [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) stellen diese Sets bereit.

PowerPoint‑kompatible Themen‑Schriftarten‑Bezeichner können in der Textformatierung verwendet werden:

* `+mn‑lt` – Fließtext‑Latein (Minor Latin Font)
* `+mj‑lt` – Überschrift‑Latein (Major Latin Font)
* `+mn‑ea` – Fließtext‑Ostasisch (Minor East Asian Font)
* `+mj‑ea` – Überschrift‑Ostasisch (Major East Asian Font)
* `+mn‑cs` – Fließtext‑Komplexes‑Skript (Minor Complex Script Font)
* `+mj‑cs` – Überschrift‑Komplexes‑Skript (Major Complex Script Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latein‑Themenschrift verwendet, und eine Textzeile, die die Neben‑Latein‑Themenschrift verwendet. Anschließend werden die Themen‑Schriftarten geändert und das Ergebnis gespeichert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Überschrift folgt der Hauptschrift und der Fließtext der Neben­schrift. Text, dem ein expliziter Schriftname anstelle eines Themen‑Bezeichners zugewiesen ist, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

Die Haupt‑ und Neben‑Schriftkollektionen können zudem Schriftzuweisungen für einzelne Schriftsysteme wie Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana enthalten. Zum Inspizieren, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tipp" %}}

Weitere Informationen zu Präsentationsschriftarten finden Sie unter [PowerPoint Fonts](/slides/de/python-java/powerpoint-fonts/).

{{% /alert %}}

### **Themen‑Schriftverweise auflösen**

Beim Inspizieren von Text kann [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) einen Themen‑Verweis wie `+mn‑lt` anstelle eines Schriftfamiliennamens zurückgeben. Rufen Sie [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) mit den entsprechenden effektiven Themendaten auf, um diesen Verweis aufzulösen. Die Präfixe `+mj` und `+mn` wählen das Haupt‑ bzw. Neben‑Schriftset; die Suffixe `-lt`, `-ea` und `-cs` wählen deren Latein‑, Ostasisch‑ bzw. Komplex‑Skript‑Schriften.

Ermitteln Sie das effektive Thema über [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) am Themen‑Manager des Objekts, dessen Thema auf den inspizierten Text angewendet wird. Für gewöhnlichen Text auf einer Folie verwenden Sie den Folien‑Themen‑Manager, sodass der Kontext das vererbte Folien‑Thema und lokale Überschreibungen einschließt. Beim Inspizieren eines Layouts oder Masters verwenden Sie dessen eigenes effektives Thema. Gehen Sie nicht davon aus, dass das Thema des ersten Masters für jede Folie gilt.

Das folgende Beispiel erstellt einen Textabschnitt, der explizit die Neben‑Latein‑Schrift referenziert. Es initialisiert ein Folien‑Schriftartenschema über [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) und setzt die Haupt‑ und Neben‑Latein‑Familien auf `Arial` bzw. `Calibri`, sodass das Ergebnis ohne Eingabedatei reproduzierbar ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

Die Ausgabe ist `+mn‑lt -> Calibri` gefolgt von `Verdana -> Verdana`. Der gespeicherte Verweis bleibt unverändert, während ein expliziter Familienname unverändert zurückgegeben wird. Wäre der Abschnitt mit `+mj‑lt` versehen, würde er in diesem Thema zu `Arial` aufgelöst.

Das Auflösen eines Themen‑Verweises ermittelt die durch das Thema angegebene Schriftfamilie. Es prüft nicht die Verfügbarkeit der Schrift oder die letztlich beim Rendern verwendete Schriftdatei nach Substitution oder Glyph‑Fallback. Siehe [Font Selection Sequence](/slides/de/python-java/font-selection-sequence/) und [Font Substitution](/slides/de/python-java/font-substitution/) für diese separaten Schritte.

## **Ein Thema kopieren oder anwenden**

Die nachstehenden Workflows lösen unterschiedliche themenbezogene Probleme.

### **Ein externes Thema auf die von einem Master abhängigen Folien anwenden**

Verwenden Sie [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides), wenn Sie eine PowerPoint‑Themendatei (`.thmx`) besitzen und jede Folie, die von einem bestimmten Master abhängt, neu stylen möchten. Wählen Sie den Master aus der Sammlung [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters), repräsentiert durch [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/), und übergeben Sie den Pfad zur Themendatei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt einen neuen Master‑Slide basierend auf dem ausgewählten Master.  
2. Wendet das externe Thema auf den neuen Master an.  
3. Ordnet den neuen Master allen Folien zu, die vorher vom ausgewählten Master abhingen.  
4. Gibt den neu erstellten [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/) zurück.

Das folgende Beispiel wendet ein externes Thema auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")
    print("Created master:", themed_master.getName())

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann eine [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/) auslösen. Validieren Sie Pfade, die von Benutzern angegeben werden, behandeln Sie Zugriffs‑Fehler auf das Dateisystem und speichern Sie die Präsentation erst, nachdem das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugewiesen. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themen. Theme‑bewusste Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formatierungen können unverändert bleiben. Überschreibungen auf Layout‑ und Folien‑Ebene können ebenfalls Vorrang vor Werten haben, die vom neuen Master geerbt wurden.

Das Thema kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistentes Rendern und Exportieren installieren Sie die erforderlichen Schriftarten, stellen sie über [custom font sources](/slides/de/python-java/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/python-java/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert nicht, dass manuell Folien‑ oder Layout‑Überschreibungen erzeugt werden.

### **Verschiedene externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) und [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jeweils ein unterschiedliches externes Thema an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der erste Aufruf betrifft nur Folien, die von `first_group_master` abhingen, der zweite nur Folien, die von `second_group_master` abhingen. Folien, die einem anderen Master zugeordnet sind, werden nicht neu gestylt.

### **Ein Quell‑Thema beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei ihr ursprüngliches Design bewahren, klonen Sie den Quell‑Master in die Zielpräsentation mit [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) und klonen Sie anschließend die Folie mit [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) zusammen mit dem geklonten Master. Damit werden Master, Layouts und das zugehörige Thema gemeinsam übertragen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)

        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Dies ist der bevorzugte Workflow, wenn die Quell‑Folien im Ziel gleich aussehen sollen. Das reine Klonen von Inhalten auf einen fremden Ziel‑Master kann jedoch themenbezogene Farben, Schriftarten, Hintergründe und Effekte verändern.

### **Themenwerte auf eine vorhandene Folie anwenden**

Muss die Ziel‑Folien ihren aktuellen Master und Layout beibehalten, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) kopieren die drei Haupt‑Themenkomponenten in die Überschreibung.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Damit wird das Thema der betreffenden Folie geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear) auf.

### **Eine Themen‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Überschreibung gilt für Folien, die dieses Layout verwenden, sofern eine bestimmte Folie keine eigene Überschreibung besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/) verwendet werden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein abweichendes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Überschreibungen erschweren die Vorhersagbarkeit späterer globaler Themenänderungen.


<!-- visual-explanation:presentation-theme:start -->
[![Ein Master‑Thema speist zwei Layouts; eine Layout‑Überschreibung beeinflusst seine Folien, außer einer Folie mit einer noch lokaleren Überschreibung.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Eine Layout‑Überschreibung gilt für Folien, die dieses Layout verwenden, sofern die Folie nicht selbst eine Überschreibung liefert. Themenbasierte Werte folgen ihrem aufgelösten Schema; explizit formatierte Objekte können ihr lokales Aussehen beibehalten. Halten Sie Überschreibungen so eng wie die beabsichtigte Design‑Ausnahme.*
<!-- visual-explanation:presentation-theme:end -->

## **Hintergrundstile des Themas aktualisieren**

Die Hintergrund‑Füllungen des Themas werden über [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen präsentieren, als in dieser Sammlung physisch definiert sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrund‑Stil verwenden, inspizieren Sie die gespeicherte Sammlung und den aktuellen [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex). Ein Stil‑Index von `0` bedeutet keine themenbasierte Füllung; positive Werte sind Referenzen zu Themen‑Hintergrund‑Stilen. Das unterscheidet sich von einem direkten Index in der Sammlung, bei dem `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation die gleiche Anzahl an Hintergrund‑Füll‑Stilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl an Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbasierte Hintergrund‑Referenz zu und speichert die Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)

        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themen‑Eintrag sowie von eventuellen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie einen eigenen Hintergrund, ändert das reine Ändern des Master‑Hintergrunds diese Folie möglicherweise nicht. Nutzen Sie [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung wissen müssen.

{{% alert color="warning" title="Warnung" %}}

Behandeln Sie den Stil‑Index nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coding einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei das gleiche Aussehen hat; Themen‑Stil‑Definitionen sind presentationsspezifisch.

{{% /alert %}}

{{% alert color="success" title="Tipp" %}}

Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/python-java/presentation-background/).

{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Formatschema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles) und [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles) verfügbar sind. Typische Office‑Themen enthalten oft drei Haupteinträge, die visuell subtil, moderat und intensiv formatieren, aber der Code sollte jede Sammlung inspizieren, anstatt von einer fixen Anzahl auszugehen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Greift man in Python via Java auf diese Sammlungen zu, ist der Sammlungs‑Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil und `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/) bereitgestellt wird. Änderungen an einem Themen‑Stil wirken sich auf Formen aus, die diesen Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge existieren, ändert den ersten Linienstil, den dritten Füllstil und aktiviert einen äußeren Schatten im dritten Effekt‑Stil, und speichert das Ergebnis:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)

        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Für Formen, die diese Slots referenzieren, wird der erste Themen‑Linienstil rot, der dritte Themen‑Füllstil ein sattes Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 pt. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung den Themen‑Stil überschreibt.

![Themen‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Füll‑ und Linien‑Stile eines Themas für eine Form auswählen**

Eine Form kann ihre Füllung und Kontur unabhängig über [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) bzw. [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex) auswählen. Für beide Methoden wählt Index `1` den ersten Eintrag in der entsprechenden Themen‑Sammlung (`get_Item(0)`), Index `2` den zweiten (`get_Item(1)`).

Das folgende Beispiel richtet zwei Füll‑Stile (Gold und Himmelblau) und zwei Linien‑Stile (dunkelblau 6 pt und dunkelrot 12 pt) im Standards‑Thema einer neuen Präsentation ein. Es speichert die Folie in drei Stufen, sodass Sie die Ergebnisse in PowerPoint vergleichen können.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Anfangsstile | Rechte Kontur ändern | Ersten Themen‑Füllstil bearbeiten |
|:---:|:---:|:---:|
| ![Goldene und himmelblaue Rechtecke mit passenden dünnen dunkelblauen Konturen](theme-style-initial.png) | ![Das himmelblaue Rechteck hat jetzt eine dicke dunkelrote Kontur](theme-style-line-changed.png) | ![Das linke Rechteck ist jetzt grün und beide Konturen bleiben unverändert](theme-style-fill-changed.png) |

Die Auswahl eines anderen Linien‑Stils ändert nur die Kontur des rechten Rechtecks. Das Bearbeiten des ersten Themen‑Füllstils aktualisiert jede Form, die ihn verwendet. Hier wird nur das linke Rechteck grün.

Bei einer bestehenden Form kann eine lokale Füll‑, Linien‑ oder Linienstärken‑Farbe die entsprechende Themen‑Stil‑Komponente überschreiben. Wenn das Ändern eines Stil‑Index keine sichtbare Wirkung zeigt, prüfen Sie die [direct formatting](/slides/de/python-java/shape-formatting/) der Form.

## **Ermitteln, ob eine effektive Voll‑Füllung eine Themen‑Farbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder von einem Absatz, Layout, Master, Themen‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) auf, um diese Hierarchie in unveränderliche effektive Füll‑Daten aufzulösen. Prüfen Sie zunächst `getFillType` im effektiven Datenobjekt. Nur wenn es `FillType.Solid` ist, sollten Sie die Eigenschaften einer Voll‑Füllung auslesen.

Bei einer Voll‑Füllung liefert `getSolidFillColor` den final gerenderten RGB‑Wert nach Vererbung, Themen‑Lookup und angewendeten Farb‑Transformationen. `getSolidFillSchemeColor` gibt das entsprechende logische [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/)‑Slot zurück, z. B. `Text1` oder `Accent6`. Ein Wert von `SchemeColor.NotDefined` bedeutet, dass die effektive Voll‑Füllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, in dem Füllungen entweder Themen‑Farben oder direkte RGB‑Farben sind, kennzeichnet dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht ausschließlich den lokalen Wert von [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor), um eine Füllung zu klassifizieren. Beispielsweise kann ein Textabschnitt kein lokal definiertes Schema‑Farbe‑Tag besitzen, sodass sein lokaler Wert `NotDefined` ist, während seine effektive Füllung eine Themen‑Farbe erbt und zu `Text1` oder `Accent6` aufgelöst wird. Umgekehrt sagt `getSolidFillSchemeColor` nur aus, welches logische Themen‑Slot die effektive Farbe erzeugt hat, nicht jedoch, aus welcher Hierarchie‑Ebene das Slot stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitt‑Füllungen, gibt jeden finalen RGB‑Wert und das zugehörige Schema‑Farbe‑Tag aus und markiert Voll‑Füllungen, die Themen‑Farbänderungen nicht folgen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

Der `NotDefined`‑Zweig liefert eine Prüfliste von Voll‑Füllungen, die nicht auf Änderungen von Themen‑Farb‑Slots reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während das Schema‑Tag erklärt, ob dieses Aussehen mit dem Thema verknüpft ist.

Effektive Format‑Objekte sind Momentaufnahmen. Nach einer Themen‑Änderung, einer Themen‑Überschreibung oder irgendeiner geerbten Formatierung rufen Sie `getEffective` erneut auf und lesen ein neues effektives Füll‑Datenobjekt, bevor Sie Farben vergleichen oder berichten.

## **Effektive Themen‑Werte auslesen**

Roh‑Thema‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich nach Vererbung und lokalen Überschreibungen verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die erste Form‑Füllung einer Folie aus:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie ausschließlich [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) inspizieren, können Sie einen Master-, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das finale Aussehen verändert.

## **FAQ**

**Wird beim Anwenden eines externen Themas jede Folie in der Präsentation beeinflusst?**

Nein. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master nutzen, behalten ihre bestehenden Themen.

**Kann ich ein Thema nur auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Überschreibungsthema. Die Änderung bleibt lokal zu dieser Folie; andere Folien erben weiterhin ihre vorhandenen Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Erscheinungsbild bewahren wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) und [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone). Das hält Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) für das Thema einer Folie oder eines Layouts und die entsprechenden Effektiv‑Daten‑Methoden für Format‑Objekte wie [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) und [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen zurück.