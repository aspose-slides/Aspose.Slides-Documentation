---
title: Präsentationsthemen in .NET verwalten
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/net/presentation-theme/
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
- Thema-Schrift
- Themenstil
- Thema-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für .NET zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit einheitlicher Markenidentität."
---
## **Einführung**

Ein Präsentationsthema definiert ein abgestimmtes Set aus Farben, Schriften, Hintergrundstilen, Füllungen, Linien und Effekten. Themen‑bewusste Objekte verweisen auf diese gemeinsam genutzten Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentationstheme über die Eigenschaft [Presentation.MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/mastertheme/) verfügbar. Eine Präsentation kann außerdem auf niedrigeren Ebenen Themen‑Überschreibungen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/masterthememanager/overridetheme/) überschreiben, ein Layout kann sein geerbtes Thema über [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) überschreiben und eine einzelne Folie kann dasselbe tun. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Theme‑Komponenten: Farben, Schriften, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gängigsten Themen‑Workflows: ein Thema inspizieren, Farben und Schriften ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und wirksame Werte nach Vererbung und Überschreibungen auslesen.

## **Ein Thema inspizieren**

Das Objekt [MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/) stellt das [ColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/fontscheme/) und [FormatScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/formatscheme/) des Themas bereit. Diese Sammlungen vor einer Änderung zu inspizieren ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, weil die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt aus, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Verwendet eine Datei mehrere Master, darf man nicht davon ausgehen, dass jede Folie dasselbe effektive Thema hat. Inspizieren Sie den zugehörigen Master der Folie und verwenden Sie den im Folgenden gezeigten effektiven‑Thema‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themenfarben ändern**

Themen‑bewusste Füllungen, Linien und Texte können auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) verweisen. Wenn Sie den entsprechenden Eintrag im [IColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/icolorscheme/) des Themas ändern, werden alle Objekte, die noch auf diese Themen‑Farbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Themen‑Farb‑Aktualisierung nicht geändert.

Das folgende End‑to‑End‑Beispiel erstellt eine Form, die `Accent4` verwendet, ändert die `Accent4`‑Farbe des Themas zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach dem Themenwechsel rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe auf der Form, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint erzeugt hellere und dunklere Varianten einer Themenfarbe, indem Farb‑Transformationen angewendet werden. Aspose.Slides stellt diese Transformationen über [ColorTransformOperation](https://reference.aspose.com/slides/de/net/aspose.slides/colortransformoperation/) bereit.

![Hauptthema‑Farben und hellere sowie dunklere Farben aus der zusätzlichen Palette erzeugt](additional-palette-colors.png)

**1** – Hauptthema‑Farben.  
**2** – Hellere und dunklere Varianten, die aus den Hauptthema‑Farben erzeugt wurden.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `Accent4`, wendet Luminanz‑Transformationen auf fünf davon an und speichert das Ergebnis:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Diese Varianten bleiben an die Themenfarbe gebunden. Ändert sich später `Accent4`, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `IColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/icolorscheme/) dieselben Themenplätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; sie sind keine Werte, die dynamisch von einer Form in eine andere konvertiert werden.

## **Themen‑Schriften ändern**

Ein Themen‑Schriftenschema enthält einen Hauptschriftensatz für Überschriften und einen Nebenschriftensatz für Fließtext. Die Eigenschaften [FontScheme.Major](https://reference.aspose.com/slides/de/net/aspose.slides.theme/fontscheme/major/) und [FontScheme.Minor](https://reference.aspose.com/slides/de/net/aspose.slides.theme/fontscheme/minor/) geben diese Sätze frei.

PowerPoint‑kompatible Themen‑Schrift‑Kennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Themen‑Schrift verwendet, und eine Textzeile, die die Neben‑Latin‑Themen‑Schrift verwendet. Anschließend werden die Themen‑Schriften geändert und das Ergebnis gespeichert:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Die Überschrift folgt der Hauptschrift und der Fließtext der Nebenschrift. Text, dem ein expliziter Schriftname anstelle einer Themen‑Kennung zugewiesen wurde, wechselt nicht automatisch, wenn das Themen‑Schriftenschema geändert wird.

Die Haupt‑ und Nebenschrift‑Sammlungen können zudem Schrift‑Zuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Inspizieren, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script‑Specific Theme Fonts](/slides/de/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Weitere Informationen zu Präsentationsschriften finden Sie unter [PowerPoint Fonts](/slides/de/net/powerpoint-fonts/).

{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Die nachstehenden Workflows lösen verschiedene themenbezogene Probleme.

### **Ein externes Thema auf Folien anwenden, die von einem Master abhängen**

Verwenden Sie [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/), wenn Sie eine PowerPoint‑Themen‑Datei (`.thmx`) besitzen und jede Folie, die von einem bestimmten Master abhängt, neu gestalten möchten. Wählen Sie den Master aus der Sammlung [Presentation.Masters](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/masters/) aus, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/) implementiert, und übergeben Sie den Pfad zur Themen‑Datei an die Methode.

Die Methode führt folgende Schritte aus:

1. Erstellt eine neue Master‑Folie basierend auf dem ausgewählten Master.  
1. Wendet das externe Thema auf den neuen Master an.  
1. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.  
1. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/) zurück.

Das folgende Beispiel wendet ein externes Thema auf die Folien an, die vom ersten Master abhängen, speichert die Präsentation und öffnet das Ergebnis erneut:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann eine [PptxException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxexception/) oder eine ihrer formatbezogenen Unterklassen auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Zugriffs‑Fehler auf das Dateisystem und speichern Sie die Präsentation erst, nachdem das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugewiesen. Folien, die anderen Mastern zugeordnet sind, behalten ihre bestehenden Master und Themen. Themen‑bewusste Farben, Schriften, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriften, Füllungen und andere explizite Formatierungen können unverändert bleiben. Überschreibungen auf Layout‑ und Folien‑Ebene können ebenfalls Vorrang vor den von dem neuen Master geerbten Werten haben.

Das Thema kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistente Darstellung und Export installieren Sie die erforderlichen Schriften, stellen sie über [custom font sources](/slides/de/net/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/net/font-substitution/).

Dies ist ein direkter Workflow auf Master‑Ebene: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert keine manuelle Erstellung von Folien‑ oder Layout‑Überschreibungen.

### **Verschiedene externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, ermitteln Sie ihn über eine repräsentative Folie mittels [ISlide.LayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide/layoutslide/) und [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/masterslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erzeugt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, ermittelt deren Master und wendet jeweils ein anderes externes Thema auf die beiden Gruppen an:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

Der erste Aufruf betrifft nur Folien, die von `firstGroupMaster` abhingen, und der zweite Aufruf betrifft nur Folien, die von `secondGroupMaster` abhingen. Folien, die zu anderen Mastern gehören, werden nicht neu gestaltet.

### **Ein Quell‑Thema beim Verschieben von Folien erhalten**

Möchten Sie eine Folie in eine andere Präsentation verschieben und dabei das ursprüngliche Design beibehalten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/addclone/), klonen Sie anschließend die Folie mit [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/) und dem geklonten Master. Dadurch werden Master, dessen Layouts und das zugehörige Thema gemeinsam übertragen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Dies ist der empfohlene Workflow, wenn die Quell‑Folie im Ziel‑Dokument exakt gleich aussehen soll. Das reine Klonen von Inhalten auf einen fremden Ziel‑Master kann Themen‑basierte Farben, Schriften, Hintergründe und Effekte ändern.

### **Themenwerte auf einer bestehenden Folie anwenden**

Soll die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie eine Folien‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/initfontschemefrom/) und [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopieren die drei Haupt‑Themen‑Komponenten in die Überschreibung.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Damit wird das von dieser Folie genutzte Thema geändert, ohne das von anderen Folien geerbte Thema zu beeinflussen. Um die lokale Überschreibung zu entfernen und zu geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.Clear](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/clear/) auf.

### **Eine Themen‑Überschreibung auf ein Layout anwenden**

Eine Layout‑Überschreibung gilt für alle Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung besitzt. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/net/aspose.slides.theme/layoutslidethememanager/) des Layouts verwendet werden:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Basisdesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein abweichendes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Überschreibungen erschweren die Vorhersagbarkeit späterer globaler Themen‑Änderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen anzeigen, als physisch in dieser Sammlung definiert sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrund‑Stil verwenden, inspizieren Sie die gespeicherte Sammlung und den aktuellen [Background.StyleIndex](https://reference.aspose.com/slides/de/net/aspose.slides/background/styleindex/). `StyleIndex` verwendet `0` für keine themenbasierte Füllung; positive Werte sind Referenzen auf Themen‑Hintergrund‑Stile. Dies unterscheidet sich vom direkten Indexieren der .NET‑Sammlung, bei dem `[0]` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl an Hintergrund‑Füllungs‑Stilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbasierte Hintergrund‑Referenz zu und speichert die Präsentation:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themen‑Eintrag sowie von möglichen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, ändert das reine Ändern des Master‑Hintergrunds diese Folie möglicherweise nicht. Nutzen Sie [Background.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/background/geteffective/), wenn Sie den endgültigen Hintergrund nach Anwendung der Vererbung ermitteln müssen.

{{% alert color="warning" title="Warning" %}}

Behandeln Sie `StyleIndex` nicht wie einen nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem das Hard‑Coden einer Stil‑Nummer aus einer Datei und die Annahme, dass sie in einer anderen Datei das gleiche Aussehen hat; Themen‑Stil‑Definitionen sind presentationsspezifisch.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Für direkte Hintergrund‑Formatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/net/presentation-background/).

{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für [FillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/linestyles/) und [EffectStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/effectstyles/). Typische Office‑Themen enthalten häufig drei Haupteinträge, die visuell subtilen, mittleren und intensiven Stil repräsentieren, aber der Code sollte jede Sammlung inspizieren, anstatt von einer festen Anzahl auszugehen.

![Subtile, mittlere und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Greifen Sie in C# auf diese Sammlungen zu, ist der Sammlungs‑Index nullbasiert: `[0]` ist der erste gespeicherte Stil, `[2]` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/net/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils beeinflusst Formen, die diesen Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stil‑Einträge vorhanden sind, ändert den ersten Linien‑Stil, den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Für Formen, die diese Plätze referenzieren, wird der erste Themen‑Linien‑Stil rot, der dritte Themen‑Füll‑Stil zu einem satten Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierungen die Themen‑Werte überschreiben.

![Themen‑Effektstile nach Änderung von Linie, Füllung und Schatteneinstellungen](presentation-design_11.png)

## **Ermitteln, ob eine effektive einfarbige Füllung eine Themen‑Farbe verwendet**

Eine Füllung kann direkt auf einem Objekt gespeichert sein oder von einem Absatz, Layout, Master, Themen‑Stil oder einer anderen Formatierungsebene geerbt werden. Rufen Sie [IFillFormat.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformat/geteffective/) auf, um diese Hierarchie in ein unveränderliches [IFillFormatEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformateffectivedata/) aufzulösen. Prüfen Sie zuerst [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformateffectivedata/filltype/). Nur wenn es `FillType.Solid` ist, sollten Sie die einfarbigen Füll‑Eigenschaften lesen.

Bei einer einfarbigen Füllung liefert [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) den final gerenderten RGB‑Wert nach Anwendung von Vererbung, Themen‑Lookup und Farb‑Transformationen. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) gibt den zugehörigen logischen [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/)‑Platz zurück, z. B. `Text1` oder `Accent6`. Der Wert `SchemeColor.NotDefined` bedeutet, dass die effektive einfarbige Füllung nicht auf einer Schema‑Farbe basiert. In einem Workflow, in dem Füllungen entweder Themen‑Farben oder direkte RGB‑Farben sind, identifiziert dieser Wert eine direkte RGB‑Füllung.

Verwenden Sie nicht ausschließlich den lokalen [IColorFormat.SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/icolorformat/schemecolor/)‑Wert, um eine Füllung zu klassifizieren. Zum Beispiel kann ein Textabschnitt keine lokal definierte Schema‑Farbe besitzen, sodass sein lokaler Wert `NotDefined` ist, während seine effektive Füllung eine Themen‑Farbe erbt und zu `Text1` bzw. `Accent6` aufgelöst wird. Umgekehrt sagt Ihnen `SolidFillSchemeColor`, welcher logische Themen‑Platz die effektive Farbe erzeugt hat, aber nicht, ob dieser Platz vom Objekt, Absatz, Layout, Master oder einer anderen Ebene stammt.

Das folgende Beispiel lädt eine Präsentation, prüft sowohl Form‑Füllungen als auch Text‑Abschnitt‑Füllungen, gibt jeden finalen RGB‑Wert und die zugehörige Schema‑Farbe aus und markiert einfarbige Füllungen, die Veränderungen von Themen‑Farben nicht folgen:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

Der `NotDefined`‑Zweig liefert eine Prüfliste einfarbiger Füllungen, die nicht auf Änderungen von Themen‑Farb‑Plätzen reagieren. Überprüfen Sie diese Objekte, wenn eine Präsentation einer neuen Marken‑Palette folgen muss. Der gemeldete RGB‑Wert zeigt weiterhin das aktuelle Aussehen, während der Schema‑Wert erklärt, ob dieses Aussehen mit dem Thema verbunden ist.

Effektive Format‑Objekte sind Momentaufnahmen. Nachdem das Präsentations‑Thema, eine Themen‑Überschreibung oder irgendeine vererbte Formatierung geändert wurde, rufen Sie `GetEffective` erneut auf und lesen ein neues `IFillFormatEffectiveData`‑Objekt, bevor Sie Farben vergleichen oder berichten.

## **Effektive Themen‑Werte auslesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich nutzt, nachdem Vererbung und lokale Überschreibungen aufgelöst wurden. Für eine Folie rufen Sie [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/de/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) auf. Für einen Hintergrund verwenden Sie [Background.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/background/geteffective/), und für eine Füllung [FillFormat.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/geteffective/).

Das folgende Beispiel liest das effektive Thema, den Hintergrund und die erste Form‑Füllung einer Folie aus:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/mastertheme/) inspizieren, können Sie einen Master-, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das endgültige Aussehen verändert.

## **FAQ**

**Beeinflusst das Anwenden eines externen Themas jede Folie in der Präsentation?**

Nein. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) ordnet nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themen.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/net/aspose.slides.theme/slidethememanager/) der Folie und initialisieren Sie dessen Überschreibungs‑Thema. Die Änderung bleibt lokal für diese Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mittels [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/addclone/) und [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/de/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/background/geteffective/) und [FillFormat.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/geteffective/). Diese APIs liefern die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen.