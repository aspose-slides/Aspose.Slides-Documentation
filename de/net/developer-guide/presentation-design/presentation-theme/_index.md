---
title: Verwalten von Präsentationsthemen in .NET
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
- Themen-Schriftart
- Themenstil
- Themaeffekt
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für .NET zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit konsistenter Markenführung."
---
## **Einleitung**

Ein Präsentationsthema definiert einen koordinierten Satz von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsam genutzten Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass eine Themenänderung viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das Präsentationsebene‑Thema über die Eigenschaft [Presentation.MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/mastertheme/) verfügbar. Eine Präsentation kann außerdem Themen‑Overrides auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/masterthememanager/overridetheme/) überschreiben, ein Layout kann sein geerbtes Thema über [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) überschreiben, und eine einzelne Folie kann dasselbe tun. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Override, Layout‑Override und Folien‑Override.

![Themen‑Komponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die folgenden Abschnitte zeigen die gängigsten Themen‑Workflows: ein Thema untersuchen, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren sowie effektive Werte nach Auflösung von Vererbung und Overrides auslesen.

## **Ein Thema untersuchen**

Das Objekt [MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/) stellt das [ColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/colorscheme/), das [FontScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/fontscheme/) und das [FormatScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/formatscheme/) des Themas bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die Haupteigenschaften des Themas und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effektstile im Thema gespeichert sind:

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

Verwendet eine Datei mehrere Master, gehen Sie nicht davon aus, dass jede Folie das gleiche effektive Thema hat. Untersuchen Sie den mit der Folie verbundenen Master und verwenden Sie den später in diesem Artikel gezeigten effektiven‑Thema‑Workflow, wenn Layout‑ oder Folien‑Overrides vorhanden sein können.

## **Themenfarben ändern**

Themenbewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag im [IColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/icolorscheme/) des Themas ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch ein Update der Themenfarbe nicht geändert.

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

Da das Rechteck weiterhin mit `Accent4` verknüpft ist, wird seine sichtbare Farbe nach der Themenänderung rot. Wenn Sie die Schema‑Farbe durch eine direkte Farbe auf der Form ersetzen, wirken spätere Änderungen an `Accent4` nicht mehr auf diese Füllung.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem Farbtransformationen angewendet werden. Aspose.Slides stellt diese Transformationen über [ColorTransformOperation](https://reference.aspose.com/slides/de/net/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.  
**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt werden.

Das folgende Beispiel erstellt sechs Rechtecke auf Basis von `Accent4`, wendet auf fünf von ihnen Luminanz‑Transformationen an und speichert das Ergebnis:

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

Diese Varianten bleiben auf der Themenfarbe basierend. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `IColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/icolorscheme/) dieselben Themenplätze als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenplätze; sie sind keine Werte, die dynamisch von einer Form in eine andere konvertiert werden.

## **Themen­schriftarten ändern**

Ein Themen‑Schriftartenschema enthält einen Haupt‑Schriftartensatz für Überschriften und einen Neben‑Schriftartensatz für Fließtext. Die Eigenschaften [FontScheme.Major](https://reference.aspose.com/slides/de/net/aspose.slides.theme/fontscheme/major/) und [FontScheme.Minor](https://reference.aspose.com/slides/de/net/aspose.slides.theme/fontscheme/minor/) geben diese Sätze frei.

PowerPoint‑kompatible Themen‑Schriftart‑Kennungen können in der Textformatierung verwendet werden:

* `+mn-lt` – Fließtext‑Schriftart Latin (Minor Latin Font)
* `+mj-lt` – Überschrift‑Schriftart Latin (Major Latin Font)
* `+mn-ea` – Fließtext‑Schriftart Ostasiatisch (Minor East Asian Font)
* `+mj-ea` – Überschrift‑Schriftart Ostasiatisch (Major East Asian Font)

Das folgende Beispiel erstellt eine Überschrift, die die Haupt‑Latin‑Themen­schriftart verwendet, und eine Textzeile, die die Neben‑Latin‑Themen­schriftart verwendet. Anschließend werden die Themen­schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift folgt der Hauptschriftart und der Fließtext folgt der Nebenschriftart. Text, der einen expliziten Schriftartnamen anstelle einer Themen‑Kennung hat, wechselt nicht automatisch, wenn das Themen‑Schriftartenschema geändert wird.

Die Haupt‑ und Nebenschriftart‑Sammlungen können außerdem Schriftartenzuordnungen für einzelne Schriftsysteme enthalten, z. B. Kyrillisch, Arabisch, Japanisch, Georgisch und Thaana. Zum Untersuchen, Hinzufügen, Ersetzen oder Entfernen dieser Zuordnungen siehe [Script-Specific Theme Fonts](/slides/de/net/script-specific-font-mappings/).

{{% alert color="info" title="Tipp" %}}
Weitere Informationen zu Präsentations­schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/net/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Die folgenden Workflows lösen verschiedene themenbezogene Probleme.

### **Ein externes Thema auf Folien anwenden, die von einem Master abhängen**

Verwenden Sie [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/), wenn Sie eine PowerPoint‑Themadatei (`.thmx`) besitzen und jede Folie neu formatieren möchten, die von einem bestimmten Master abhängt. Wählen Sie den Master aus der Sammlung [Presentation.Masters](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/masters/), die [IMasterSlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/) implementiert, und übergeben Sie den Pfad zur Themendatei an die Methode.

Die Methode führt die folgenden Vorgänge aus:

1. Erstellt eine neue Master‑Folie basierend auf dem ausgewählten Master.  
2. Wendet das externe Thema auf den neuen Master an.  
3. Ordnet den neuen Master allen Folien zu, die zuvor vom ausgewählten Master abhingen.  
4. Gibt das neu erstellte [IMasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/) zurück.

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

Ein ungültiges, beschädigtes oder nicht unterstütztes Thema kann eine [PptxException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxexception/) oder eine ihrer formatbezogenen Unterklassen auslösen. Validieren Sie von Benutzern bereitgestellte Pfade, behandeln Sie Dateisystem‑Zugriffsfehler und speichern Sie die Präsentation nur, nachdem das Thema erfolgreich angewendet wurde.

Nur die Folien, die vom ausgewählten Master abhingen, werden neu zugewiesen. Folien, die anderen Master‑Instanzen zugeordnet sind, behalten ihre bestehenden Master und Themen. Themenbewusste Farben, Schriftarten, Füllungen, Linien, Hintergründe und Effekte werden gegen das externe Thema aufgelöst. Direkt zugewiesene Farben, Schriftarten, Füllungen und andere explizite Formatierungen können unverändert bleiben. Overrides auf Layout‑Ebene und Folien‑Ebene können ebenfalls Vorrang vor den vom neuen Master vererbten Werten haben.

Das Thema kann Schriftarten referenzieren, die in der Laufzeitumgebung nicht verfügbar sind. Für konsistentes Rendering und Export installieren Sie die benötigten Schriftarten, stellen Sie sie über [custom font sources](/slides/de/net/custom-font/) bereit oder konfigurieren Sie [font substitution](/slides/de/net/font-substitution/).

Dies ist ein direkter Workflow auf Master‑Ebene: Die Methode akzeptiert einen Dateipfad zu einer `.thmx`‑Datei und erfordert nicht das manuelle Erstellen von Themen‑Overrides auf Folien‑ oder Layout‑Ebene.

### **Verschiedene externe Themen in einer Multi‑Master‑Präsentation anwenden**

Wenn der relevante Master nicht im Voraus bekannt ist, erhalten Sie ihn über eine repräsentative Folie mit [ISlide.LayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide/layoutslide/) und [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/masterslide/). Speichern Sie die ursprünglichen Master‑Referenzen, bevor Sie Themen anwenden, da jeder Aufruf einen weiteren Master in der Präsentation erstellt.

Das folgende Beispiel verwendet Folien aus zwei Abschnitten, um deren Master zu ermitteln, und wendet jedem Abschnitt ein anderes externes Thema an:

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

Der erste Aufruf wirkt nur auf Folien, die von `firstGroupMaster` abhingen, und der zweite Aufruf nur auf Folien, die von `secondGroupMaster` abhingen. Folien, die zu einem anderen Master gehören, werden nicht neu gestaltet.

### **Ein Quell‑Thema beim Verschieben von Folien beibehalten**

Wenn Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten möchten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/addclone/), klonen anschließend die Folie mit [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/) und den geklonten Master. Dadurch werden der Master, seine Layouts und das zugehörige Thema zusammen übertragen.

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

Dies ist der bevorzugte Workflow, wenn die Quellfolie im Ziel identisch aussehen muss. Das bloße Klonen von Inhalten auf einen nicht zum Quellmaster gehörenden Ziel‑Master kann themengesteuerte Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Themenwerte auf einer bestehenden Folie anwenden**

Wenn die Ziel‑Folie ihren aktuellen Master und ihr Layout beibehalten muss, initialisieren Sie einen Folien‑Override aus dem Quell‑Thema. Die Methoden [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/initfontschemefrom/) und [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopieren die drei Haupt‑Themenkomponenten in den Override.

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

Dies ändert das von dieser Folie verwendete Thema, ohne das von anderen Folien vererbte Thema zu ändern. Um den lokalen Override zu entfernen und zu den geerbten Werten zurückzukehren, rufen Sie [OverrideTheme.Clear](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/clear/) auf.

### **Einen Themen‑Override auf ein Layout anwenden**

Ein Layout‑Override gilt für Folien, die dieses Layout verwenden, sofern eine bestimmte Folie keinen eigenen Override hat. Die gleichen Initialisierungsmethoden können über den [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/net/aspose.slides.theme/layoutslidethememanager/) des Layouts verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, ein Layout‑Override, wenn eine Layout‑Familie ein anderes Styling benötigt, und ein Folien‑Override nur für echte Ausnahmen. Übermäßige Folien‑Overrides erschweren die Vorhersage späterer globaler Themenänderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) gespeichert. PowerPoint kann in seiner Benutzeroberfläche mehr Hintergrundoptionen anzeigen, als die in dieser Sammlung physisch gespeicherten Fülldefinitionen existieren, da die UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrundstil‑Galerie für ein Präsentationsthema](presentation-design_8.png)

Bevor Sie einen Hintergrundstil verwenden, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.StyleIndex](https://reference.aspose.com/slides/de/net/aspose.slides/background/styleindex/). `StyleIndex` verwendet `0` für keine themenbasierte Füllung; positive Werte sind Referenzen auf Themen‑Hintergrundstile. Dies unterscheidet sich von der direkten Indizierung der .NET‑Sammlung, wo `[0]` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation dieselbe Anzahl an Hintergrund‑Füllstilen enthält.

Das folgende Beispiel meldet die verfügbare Anzahl an Hintergrund‑Füllungen, weist dem ersten Master eine themenbasierte Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themen‑Eintrag und von etwaigen Hintergrund‑Overrides auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, führt das Ändern des Master‑Hintergrunds möglicherweise nicht zu einer Änderung dieser Folie. Verwenden Sie [Background.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/background/geteffective/), wenn Sie den endgültigen Hintergrund nach Anwendung der Vererbung wissen müssen.

{{% alert color="warning" title="Warnung" %}}
Behandeln Sie `StyleIndex` nicht als nullbasierten Sammlungsindex. Vermeiden Sie zudem, eine Stil‑Nummer aus einer Datei fest zu kodieren und anzunehmen, dass sie in einer anderen Datei das gleiche Aussehen hat; Themen‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/net/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für [FillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/linestyles/) und [EffectStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/effectstyles/). Typische Office‑Themen enthalten häufig drei Hauptstil‑Einträge, die visuell subtiler, moderater und intensiver Formatierung entsprechen, doch sollte der Code jede Sammlung prüfen, anstatt eine feste Anzahl anzunehmen.

![Subtile, moderate und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Wenn Sie in C# auf diese Sammlungen zugreifen, ist der Sammlungsindex nullbasiert: `[0]` ist der zuerst gespeicherte Stil und `[2]` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/net/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf Formen aus, die diesen Themen‑Stil referenzieren; Formen mit direkter Formatierung können unverändert bleiben.

Das folgende Beispiel prüft, ob die erforderlichen Stil‑Einträge vorhanden sind, ändert den ersten Linienstil, ändert den dritten Füllstil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Plätze referenzieren, wird der erste Themen‑Linienstil rot, der dritte Themen‑Füllstil wird zu einer durchgehenden Waldgrün‑Farbe, und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einer Distanz von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Plätze jede Form referenziert und ob direkte Formatierung den Themenstil überschreibt.

![Themen‑Effekt‑Stile nach Änderungen von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Effektive Themen‑Werte auslesen**

Roh‑Themaobjekte geben an, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich verwendet, nachdem Vererbung und lokale Overrides aufgelöst wurden. Für eine Folie rufen Sie [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/de/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) auf. Für einen Hintergrund verwenden Sie [Background.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/background/geteffective/), und für eine Füllung [FillFormat.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/geteffective/).

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

Verwenden Sie effektive Daten für Render‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/mastertheme/) untersuchen, können Sie einen Master‑, Layout‑, Folien‑ oder Form‑Override übersehen, der das endgültige Erscheinungsbild ändert.

## **FAQ**

**Wirkt das Anwenden eines externen Themas auf jede Folie in der Präsentation?**

Nein. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) weist nur die Folien neu zu, die vom ausgewählten Master abhängen. Folien, die andere Master verwenden, behalten ihre bestehenden Themen.

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/net/aspose.slides.theme/slidethememanager/) der Folie und initialisieren Sie deren Override‑Thema. Die Änderung bleibt lokal auf diese Folie beschränkt; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist die sicherste Methode, ein Thema von einer Präsentation in eine andere zu übernehmen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen beibehalten möchten, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master über [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/addclone/) und [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Overrides sehen?**

Verwenden Sie [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/de/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Format‑Objekte wie [Background.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/background/geteffective/) und [FillFormat.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/geteffective/). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Overrides zurück.