---
title: Präsentationsdesigns in Python über Java verwalten
linktitle: Präsentationsdesign
type: docs
weight: 10
url: /de/python-java/presentation-theme/
keywords:
- PowerPoint-Design
- Präsentationsdesign
- Folien-Design
- Design festlegen
- Design ändern
- Design verwalten
- externes Design
- THMX
- Designfarbe
- zusätzliche Palette
- Designschrift
- Designstil
- Designeffekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Master-Präsentationsdesigns in Aspose.Slides für Python via Java erstellen, anpassen und PowerPoint-Dateien mit konsistenter Markenidentität konvertieren."
---
## **Einleitung**

Ein Präsentations‑Design definiert ein abgestimmtes Set aus Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Design‑bewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Design‑Wechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentations‑Design über [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getMasterTheme) verfügbar. Eine Präsentation kann außerdem Design‑Überschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentations‑Design über [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterthememanager/#getOverrideTheme) überschreiben, während ein Layout oder eine einzelne Folie ihr geerbtes Design über [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) überschreiben kann. In der Praxis wird das effektive Design einer Folie über diese Vererbungskette ermittelt: Präsentations‑Design, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Design‑Komponenten: Farben, Schriften, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Design‑Workflows: Design inspizieren, Farben und Schriften ändern, ein Design kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Vererbung und Überschreibungen auslesen.

## **Ein Design inspizieren**

Das Objekt [MasterTheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/mastertheme/) stellt das Farbschema, das Schriften­schema und das Formatschema über [MasterTheme.getColorScheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/mastertheme/#getFontScheme) und [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/mastertheme/#getFormatScheme) bereit. Diese Sammlungen vor der Änderung zu inspizieren ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Style‑Einträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Designs und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effekt‑Stile im Design gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf nicht angenommen werden, dass jede Folie dasselbe effektive Design hat. Inspizieren Sie den Master, der der Folie zugeordnet ist, und nutzen Sie den später in diesem Artikel gezeigten Workflow für effektive Designs, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Design‑Farben ändern**

Design‑bewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag im [ColorScheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/colorscheme/) ändern, werden alle Objekte, die noch auf diese Design‑Farbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Design‑Farb‑Aktualisierung nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die Design‑Farbe `Accent4` zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Design‑Änderung rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe in der Form, wird eine spätere Änderung von `Accent4` diese Füllung nicht mehr beeinflussen.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Design‑Farbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über die Aufzählung [ColorTransformOperation](https://reference.aspose.com/slides/de/python-java/aspose.slides/colortransformoperation/) bereit.

![Haupt‑Design‑Farben sowie hellere und dunklere Farben, die aus der zusätzlichen Palette erzeugt wurden](additional-palette-colors.png)

**1** – Haupt‑Design‑Farben.  
**2** – Hellere und dunklere Varianten, die aus den Haupt‑Design‑Farben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke basierend auf `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

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

Diese Varianten bleiben an die Design‑Farbe gebunden. Ändert sich später `Accent4`, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `ColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während das [ColorScheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/colorscheme/) dieselben Design‑Plätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Design‑Plätze; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Design‑Schriften ändern**

Ein Design‑Schriften‑Schema enthält ein Haupt‑Schriftset für Überschriften und ein Neben‑Schriftset für Fließtext. Die Methoden [FontScheme.getMajor](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontscheme/#getMajor) und [FontScheme.getMinor](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontscheme/#getMinor) geben diese Sets frei.

PowerPoint‑kompatible Design‑Schrift‑Kennungen können in der Textformatierung verwendet werden:

* `+mn‑lt` – Fließtext‑Schrift Lateinisch (Minor Latin Font)
* `+mj‑lt` – Überschrifts‑Schrift Lateinisch (Major Latin Font)
* `+mn‑ea` – Fließtext‑Schrift Ostasiatisch (Minor East Asian Font)
* `+mj‑ea` – Überschrifts‑Schrift Ostasiatisch (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latein‑Design‑Schrift verwendet, und eine Textzeile, die die Neben‑Latein‑Design‑Schrift verwendet. Anschließend werden die Design‑Schriften geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Haupt‑Schrift und der Fließtext der Neben‑Schrift. Text, der explizit einen Schriftnamen anstelle einer Design‑Kennung enthält, wechselt nicht automatisch, wenn das Design‑Schriften‑Schema geändert wird.

Die Haupt‑ und Neben‑Schrift‑Sammlungen können außerdem Schriftzuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Inspizieren, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tipp" %}}
Weitere Informationen zu Präsentations‑Schriften finden Sie unter [PowerPoint Fonts](/slides/de/python-java/powerpoint-fonts/).
{{% /alert %}}

## **Ein Design kopieren oder anwenden**

Die nachstehenden Workflows lösen verschiedene designbezogene Probleme.

### **Ein externes Design auf Folien eines Masters anwenden**

Verwenden Sie [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides), wenn Sie eine PowerPoint‑Design‑Datei (`.thmx`) besitzen und sämtliche Folien, die von einem bestimmten Master abhängen, neu stylen möchten. Wählen Sie den Master aus der [Presentation.getMasters](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getMasters)‑Sammlung, repräsentiert durch [MasterSlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/), und übergeben Sie den Pfad zur Design‑Datei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folien‑Instanz basierend auf dem gewählten Master.  
1. Wendet das externe Design auf den neuen Master an.  
1. Ordnet den neuen Master allen Folien zu, die zuvor vom gewählten Master abhingen.  
1. Gibt die neu erstellte [MasterSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/) zurück.

Das folgende Beispiel wendet ein externes Design auf die Folien an, die vom ersten Master abhängen, und speichert die Präsentation:

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

Ein ungültiges, beschädigtes oder nicht unterstütztes Design kann eine [PptxReadException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxreadexception/) auslösen. Validieren Sie benutzereingebene Pfade, behandeln Sie Zugriffsfehler auf das Dateisystem und speichern Sie die Präsentation erst, wenn das Design erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugeordnet. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Designs. Design‑bewusste Farben, Schriften, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Design aufgelöst. Direkt zugewiesene Farben, Schriften, Füllungen und weitere explizite Formatierungen können unverändert bleiben. Layout‑ und Folien‑Überschreibungen können ebenfalls Vorrang vor den vom neuen Master geerbten Werten haben.

Das Design kann Schriften referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistentes Rendering und Export installieren Sie die erforderlichen Schriften, stellen sie über [custom font sources](/slides/de/python-java/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/python-java/font-substitution/).

Dies ist ein direkter Master‑Level‑Workflow: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert keine manuelle Erstellung von Folien‑ oder Layout‑Überschreibungen.

### **Verschiedene externe Designs in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master im Vorfeld nicht bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mit [Slide.getLayoutSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getLayoutSlide) und [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getMasterSlide). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Designs anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jeweils ein anderes externes Design auf jede Gruppe an:

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

Der erste Aufruf betrifft nur Folien, die von `first_group_master` abhängen, der zweite Aufruf betrifft nur Folien, die von `second_group_master` abhängen. Folien, die zu einem anderen Master gehören, bleiben unverändert.

### **Ein Quell‑Design beim Verschieben von Folien beibehalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei ihr ursprüngliches Design beibehalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/#addClone) und klonen anschließend die Folie zusammen mit dem geklonten Master über [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone). Damit werden Master, dessen Layouts und das zugehörige Design gemeinsam übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quell‑Folien im Ziel‑Dokument gleich aussehen sollen. Das reine Kopieren von Inhalten auf einen nicht zugehörigen Ziel‑Master kann hingegen Farben, Schriften, Hintergründe und Effekte, die vom Design abhängen, ändern.

### **Design‑Werte auf einer bestehenden Folie anwenden**

Muss die Ziel‑Folie ihren aktuellen Master und ihr Layout beibehalten, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Design. Die Methoden [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/de/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/de/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) und [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/de/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) kopieren die drei Haupt‑Design‑Komponenten in die Überschreibung.

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

Damit wird das von dieser Folie genutzte Design geändert, ohne das von anderen Folien geerbte Design zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/overridetheme/#clear) auf.

### **Ein Design‑Override auf ein Layout anwenden**

Ein Layout‑Override gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihr eigenes Override besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Design, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein abweichendes Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides erschweren spätere globale Design‑Änderungen.

## **Design‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Designs werden in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/de/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) gespeichert. PowerPoint kann im UI mehr Hintergrundoptionen anbieten, als physisch in dieser Sammlung gespeichert sind, weil das UI Design‑Füllungen mit Design‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgallerie für ein Präsentations‑Design](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, inspizieren Sie die gespeicherte Sammlung und den aktuellen Wert von [Background.getStyleIndex](https://reference.aspose.com/slides/de/python-java/aspose.slides/background/#getStyleIndex). Ein Stil‑Index von `0` bedeutet keine Design‑Füllung; positive Werte sind Referenzen auf Design‑Hintergrund‑Stile. Das ist anders als das direkte Indizieren der Sammlung, bei dem `get_Item(0)` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl von Hintergrund‑Füllstilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine Design‑Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom Design‑Eintrag ab, auf den der Master verweist, sowie von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene. Nutzt eine Folie ihren eigenen Hintergrund, bewirkt eine rein Master‑Hintergrund‑Änderung möglicherweise keine Änderung dieser Folie. Verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/background/#getEffective), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung kennen müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie den Stil‑Index nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie zudem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei identisch aussieht; Design‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="success" title="Tipp" %}}
Für direkte Hintergrund‑Formatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/python-java/presentation-background/).
{{% /alert %}}

## **Design‑Effekte aktualisieren**

Ein Design‑Formatschema enthält separate Sammlungen für Füll‑, Linien‑ und Effekt‑Stile, die über [FormatScheme.getFillStyles](https://reference.aspose.com/slides/de/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/de/python-java/aspose.slides/formatscheme/#getLineStyles) und [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/de/python-java/aspose.slides/formatscheme/#getEffectStyles) bereitgestellt werden. Typische Office‑Designs enthalten oft drei Haupteinträge, die visuell subtile, moderate und intensive Formatierungen darstellen, jedoch sollte der Code jede Sammlung prüfen, anstatt von einer festen Anzahl auszugehen.

![Subtile, moderate und intensive Design‑Effekte, die auf dieselbe Form angewendet wurden](presentation-design_10.png)

Greift man in Python über Java auf diese Sammlungen zu, ist der Collection‑Index nullbasiert: `get_Item(0)` ist der erste gespeicherte Stil, `get_Item(2)` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [ShapeStyle](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapestyle/) bereitgestellt wird. Das Ändern eines Design‑Stils wirkt sich auf Formen aus, die diesen Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stile vorhanden sind, ändert den ersten Linienstil, den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effektstil und speichert das Ergebnis:

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

Für Formen, die diese Slots referenzieren, wird der erste Design‑Linienstil rot, der dritte Design‑Füllstil zu einem satten Waldgrün und der dritte Effektstil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das tatsächliche visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung das Design überschreibt.

![Design‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Ermitteln, ob eine effektive einfarbige Füllung eine Design‑Farbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder aus einem Absatz, Layout, Master, Design‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [FillFormat.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#getEffective) auf, um diese Hierarchie in unveränderliche effektive Fülldaten aufzulösen. Prüfen Sie zuerst `getFillType` am effektiven Datenobjekt. Nur wenn dieser `FillType.Solid` ist, sollten Sie die Eigenschaften einer einfarbigen Füllung auslesen.

Für eine einfarbige Füllung liefert `getSolidFillColor` den endgültigen gerenderten RGB‑Wert nach Vererbung, Design‑Lookup und Farbtransformationen. `getSolidFillSchemeColor` gibt den zugehörigen logischen [SchemeColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/schemecolor/)-Slot zurück, z. B. `Text1` oder `Accent6`. Ein Wert von `SchemeColor.NotDefined` bedeutet, dass die effektive einfarbige Füllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, in dem Füllungen entweder Design‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht allein den lokalen Wert von [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/colorformat/#getSchemeColor) zur Klassifizierung einer Füllung. Beispielsweise kann ein Textabschnitt keine lokal definierte Schema‑Farbe besitzen, sodass sein lokaler Wert `NotDefined` ist, während seine effektive Füllung ein Design‑Farb‑Slot wie `Text1` oder `Accent6` erbt. Umgekehrt sagt `getSolidFillSchemeColor` Ihnen, welcher logische Design‑Slot die effektive Farbe erzeugt hat, liefert jedoch keinen Hinweis darauf, ob dieser Slot vom Objekt, Absatz, Layout, Master oder einer anderen Ebene stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitt‑Füllungen, gibt jeweils den finalen RGB‑Wert und die zugehörige Schema‑Farbe aus und markiert einfarbige Füllungen, die Design‑Farb‑Änderungen nicht folgen:

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

Der `NotDefined`‑Zweig liefert eine Prüfliste einfarbiger Füllungen, die nicht auf Design‑Farb‑Slots reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einem neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während das Schema‑Tag erklärt, ob dieses Aussehen mit dem Design verknüpft ist.

Effektive Format‑Objekte sind Momentaufnahmen. Nach einer Änderung des Präsentations‑Designs, eines Design‑Overrides oder einer anderen geerbten Formatierung rufen Sie `getEffective` erneut auf und lesen ein neues effektives Fülldaten‑Objekt, bevor Sie Farben vergleichen oder melden.

## **Effektive Design‑Werte auslesen**

Roh‑Design‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form nach Vererbung und lokalen Overrides tatsächlich verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) auf. Für einen Hintergrund verwenden Sie [Background.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/background/#getEffective), und für eine Füllung [FillFormat.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#getEffective).

Das folgende Beispiel liest das effektive Design, den Hintergrund und die erste Form‑Füllung einer Folie aus:

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.getMasterTheme](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getMasterTheme) inspizieren, können Sie einen Master-, Layout-, Folien‑ oder Form‑Override übersehen, der das endgültige Aussehen ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Designs auf jede Folie der Präsentation?**

Nein. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Designs.

**Kann ich ein Design auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidethememanager/) der Folie und initialisieren Sie dessen Override‑Design. Die Änderung bleibt lokal auf dieser Folie; andere Folien erben weiterhin ihr bestehendes Design.

**Wie übertrage ich ein Design sicher von einer Präsentation in eine andere?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren möchten, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master über [MasterSlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslidecollection/#addClone) und [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone). Dadurch bleiben Master, Layouts und Design zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) für das Design einer Folie oder eines Layouts und die entsprechenden Effective‑Data‑Methoden für Formatobjekte wie [Background.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/background/#getEffective) und [FillFormat.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#getEffective). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Overrides zurück.