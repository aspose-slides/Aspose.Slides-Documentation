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
- Themafarbe
- zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Thementeffekt
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für .NET zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit konsistenter Markenidentität."
---
## **Einführung**

Ein Präsentationsthema definiert ein abgestimmtes Set von Farben, Schriftarten, Hintergrundstilen, Füllungen, Linien und Effekten. Themenbewusste Objekte verweisen auf diese gemeinsamen Definitionen, anstatt jede visuelle Eigenschaft als festen Wert zu speichern, sodass ein Themenwechsel viele Objekte gleichzeitig aktualisieren kann.

In Aspose.Slides ist das präsentationsweite Thema über die [Presentation.MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/mastertheme/)‑Eigenschaft verfügbar. Eine Präsentation kann zudem Themenüberschreibungen auf niedrigeren Ebenen enthalten. Ein Master kann das Präsentationsthema über [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/masterthememanager/overridetheme/) überschreiben, ein Layout kann sein geerbtes Thema über [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) überschreiben, und eine einzelne Folie kann dasselbe tun. In der Praxis wird das effektive Thema einer Folie über diese Vererbungskette aufgelöst: Präsentationsthema, Master‑Überschreibung, Layout‑Überschreibung und Folien‑Überschreibung.

![Themenkomponenten: Farben, Schriftarten, Hintergrundstile und Effekte](theme-constituents.png)

Die nachfolgenden Abschnitte zeigen die gebräuchlichsten Themen‑Workflows: ein Thema untersuchen, Farben und Schriftarten ändern, ein Thema kopieren oder anwenden, Hintergrund‑ und Effektstile aktualisieren und effektive Werte nach Auflösung von Vererbung und Überschreibungen auslesen.

## **Ein Thema untersuchen**

Das [MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/)‑Objekt stellt das [ColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/colorscheme/), das [FontScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/fontscheme/) und das [FormatScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/mastertheme/formatscheme/) des Themas bereit. Das Untersuchen dieser Sammlungen, bevor sie geändert werden, ist besonders nützlich, wenn eine Präsentation aus einer externen Quelle stammt, da die Anzahl und der Inhalt der Stileinträge variieren können.

Das folgende Beispiel liest die wichtigsten Thema‑Eigenschaften aus und gibt an, wie viele Hintergrund‑, Füll‑, Linien‑ und Effekt‑Stile im Thema gespeichert sind:

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

Verwendet eine Datei mehrere Master, darf nicht angenommen werden, dass jede Folie dasselbe effektive Thema hat. Untersuchen Sie den dem Slide zugeordneten Master und verwenden Sie den später in diesem Artikel gezeigten effektiven‑Thema‑Workflow, wenn Layout‑ oder Folien‑Überschreibungen vorhanden sein können.

## **Themenfarben ändern**

Themenbewusste Füllungen, Linien und Texte können sich auf eine logische Farbe aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) beziehen. Wenn Sie den entsprechenden Eintrag im [IColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/icolorscheme/) des Themas ändern, werden alle Objekte, die noch auf diese Themenfarbe verweisen, gegen den neuen Wert aufgelöst. Objekte, die eine direkte RGB‑Farbe verwenden, werden durch eine Themenfarb‑Aktualisierung nicht verändert.

Das folgende End‑to‑End‑Beispiel erzeugt eine Form, die `Accent4` verwendet, ändert die `Accent4`‑Farbe des Themas zu Rot, speichert die Präsentation, öffnet sie erneut und gibt die effektive Füllfarbe aus:

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

Da das Rechteck mit `Accent4` verknüpft bleibt, wird seine sichtbare Farbe nach der Themenänderung Rot. Ersetzen Sie die Schema‑Farbe durch eine direkte Farbe auf der Form, wirken spätere Änderungen von `Accent4` nicht mehr auf diese Füllung ein.

### **Farben aus der zusätzlichen Palette verwenden**

PowerPoint leitet hellere und dunklere Varianten von einer Themenfarbe ab, indem Farb‑Transformationen angewendet werden. Aspose.Slides stellt diese Transformationen über [ColorTransformOperation](https://reference.aspose.com/slides/de/net/aspose.slides/colortransformoperation/) bereit.

![Hauptthemenfarben und aus der zusätzlichen Palette erzeugte hellere und dunklere Farben](additional-palette-colors.png)

**1** – Hauptthemenfarben.

**2** – Hellere und dunklere Varianten, die aus den Hauptthemenfarben erzeugt wurden.

Das folgende Beispiel erzeugt sechs Rechtecke auf Basis von `Accent4`, wendet auf fünf davon Luminanz‑Transformationen an und speichert das Ergebnis:

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

Diese Varianten bleiben an der Themenfarbe ausgerichtet. Ändert sich `Accent4` später, werden die transformierten Farben aus dem neuen `Accent4`‑Wert neu berechnet.

### **`SchemeColor`‑Werte den `IColorScheme`‑Plätzen zuordnen**

Die Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) verwendet `Text1`, `Background1`, `Text2` und `Background2`, während [IColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/icolorscheme/) dieselben Themenslots als `Dark1`, `Light1`, `Dark2` und `Light2` bereitstellt. Die Zuordnung ist fest:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Dies sind alternative Bezeichnungen für dieselben Themenslots; sie sind keine Werte, die dynamisch von einer Form in die andere konvertiert werden.

## **Themen-Schriftarten ändern**

Ein Themen‑Schriftart‑Schema enthält einen Hauptschriftart‑Satz für Überschriften und einen Neben‑Schriftart‑Satz für Fließtext. Die Eigenschaften [FontScheme.Major](https://reference.aspose.com/slides/de/net/aspose.slides.theme/fontscheme/major/) und [FontScheme.Minor](https://reference.aspose.com/slides/de/net/aspose.slides.theme/fontscheme/minor/) geben diese Sätze frei.

PowerPoint‑kompatible Themen‑Schriftarten‑Kennungen können in der Textformatierung verwendet werden:

* `+mn‑lt` – Body Font Latin (Minor Latin Font)
* `+mj‑lt` – Heading Font Latin (Major Latin Font)
* `+mn‑ea` – Body Font East Asian (Minor East Asian Font)
* `+mj‑ea` – Heading Font East Asian (Major East Asian Font)

Das folgende Beispiel erzeugt eine Überschrift, die die Haupt‑Latin‑Themen­schriftart verwendet, und eine Textzeile, die die Neben‑Latin‑Themen­schriftart verwendet. Anschließend werden die Themen‑Schriftarten geändert und das Ergebnis gespeichert:

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

Die Überschrift nutzt die Hauptschriftart und der Fließtext die Neben­schriftart. Text, der einen expliziten Schriftart‑Namen anstelle einer Themen‑Kennung enthält, wechselt nicht automatisch, wenn das Themen‑Schriftart‑Schema geändert wird.

{{% alert color="info" title="Tipp" %}}
Weitere Informationen zu Präsentations‑Schriftarten finden Sie unter [PowerPoint Fonts](/slides/de/net/powerpoint-fonts/).
{{% /alert %}}

## **Ein Thema kopieren oder anwenden**

Es gibt zwei gängige Workflows, die unterschiedliche Probleme lösen.

### **Ein Quell‑Thema beim Verschieben von Folien erhalten**

Wenn Sie eine Folie in eine andere Präsentation verschieben und ihr ursprüngliches Design beibehalten möchten, klonen Sie den Quell‑Master in die Ziel‑Präsentation mit [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/addclone/), klonen anschließend die Folie mit [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/) und dem geklonten Master. Dadurch werden Master, zugehörige Layouts und das zugehörige Thema zusammen transportiert.

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

Dies ist der empfohlene Workflow, wenn die Quell‑Folie im Ziel exakt gleich aussehen soll. Das einfache Klonen von Inhalten auf einen nicht zugehörigen Ziel‑Master kann themenabhängige Farben, Schriftarten, Hintergründe und Effekte ändern.

### **Themen‑Werte auf eine bestehende Folie anwenden**

Muss die Ziel‑Folie auf ihrem aktuellen Master und Layout bleiben, initialisieren Sie eine Folien‑Ebene‑Überschreibung aus dem Quell‑Thema. Die Methoden [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/initfontschemefrom/) und [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/de/net/aspose.slides.theme/overridetheme/initformatschemefrom/) kopieren die drei Haupt‑Themen‑Komponenten in die Überschreibung.

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

Eine Layout‑Ebene‑Überschreibung gilt für Folien, die dieses Layout verwenden, sofern eine bestimmte Folie nicht ihre eigene Überschreibung besitzt. Die gleichen Initialisierungsmethoden können über den Layout‑Managers [LayoutSlideThemeManager](https://reference.aspose.com/slides/de/net/aspose.slides.theme/layoutslidethememanager/) verwendet werden:

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

Verwenden Sie ein Master‑ oder Präsentations‑Thema, wenn viele Layouts und Folien dasselbe Grunddesign teilen sollen, eine Layout‑Überschreibung, wenn eine Layout‑Familie ein anderes Styling benötigt, und eine Folien‑Überschreibung nur für echte Ausnahmen. Übermäßige Folien‑Überschreibungen erschweren spätere globale Themen‑Änderungen.

## **Themen‑Hintergrundstile aktualisieren**

Die Hintergrund‑Füllungen des Themas werden in [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) gespeichert. PowerPoint kann im UI mehr Hintergrund‑Optionen präsentieren, als tatsächlich in dieser Sammlung definiert sind, weil das UI Themen‑Füllungen mit Themen‑Farben und anderen Stil‑Referenzen kombinieren kann.

![PowerPoint‑Hintergrund‑Stilgalerie für ein Präsentationsthema](presentation-design_8.png)

Bevor ein Hintergrund‑Stil verwendet wird, prüfen Sie die gespeicherte Sammlung und den aktuellen [Background.StyleIndex](https://reference.aspose.com/slides/de/net/aspose.slides/background/styleindex/). `StyleIndex` verwendet `0` für keine themenbezogene Füllung; positive Werte sind Referenzen auf Themen‑Hintergrund‑Stile. Das unterscheidet sich von der Indexierung der .NET‑Sammlung, bei der `[0]` das erste gespeicherte Element bedeutet. Gehen Sie nicht davon aus, dass jede Präsentation die gleiche Anzahl von Hintergrund‑Füll‑Stilen enthält.

Das folgende Beispiel gibt die verfügbare Anzahl von Hintergrund‑Füllungen aus, weist dem ersten Master eine themenbezogene Hintergrund‑Referenz zu und speichert die Präsentation:

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

Das sichtbare Ergebnis hängt vom vom Master referenzierten Themen‑Eintrag sowie von etwaigen Hintergrund‑Überschreibungen auf Layout‑ oder Folien‑Ebene ab. Verwendet eine Folie ihren eigenen Hintergrund, bewirkt das Ändern des Master‑Hintergrunds möglicherweise keine Änderung dieser Folie. Nutzen Sie [Background.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/background/geteffective/), wenn Sie den endgültigen Hintergrund nach angewandter Vererbung wissen müssen.

{{% alert color="warning" title="Warnung" %}}
Betrachten Sie `StyleIndex` nicht als nullbasierten Sammlungs‑Index. Vermeiden Sie außerdem, eine Stil‑Nummer aus einer Datei hart zu codieren und anzunehmen, dass sie in einer anderen Datei identisch aussieht; Themen‑Stil‑Definitionen sind presentationsspezifisch.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Für direkte Hintergrundformatierung und Hintergrund‑Vererbung siehe [Presentation Background](/slides/de/net/presentation-background/).
{{% /alert %}}

## **Themen‑Effekte aktualisieren**

Ein Themen‑Format‑Schema enthält separate Sammlungen für [FillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/linestyles/) und [EffectStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/effectstyles/). Typische Office‑Themen enthalten häufig drei Haupteinträge, die visuell subtil, mittel und intensiv formatieren, aber der Code sollte jede Sammlung prüfen, anstatt eine feste Anzahl anzunehmen.

![Subtile, mittlere und intensive Themen‑Effekte, die auf dieselbe Form angewendet werden](presentation-design_10.png)

Wenn Sie in C# auf diese Sammlungen zugreifen, ist der Sammlungs‑Index nullbasiert: `[0]` ist der erste gespeicherte Stil und `[2]` der dritte. Die Stil‑Referenz‑Indizes einer Form sind ein separates Konzept, das über [IShapeStyle](https://reference.aspose.com/slides/de/net/aspose.slides/ishapestyle/) bereitgestellt wird. Das Ändern eines Themen‑Stils wirkt sich auf Formen aus, die diesen Themen‑Stil referenzieren; Formen mit direkter Formatierung bleiben unverändert.

Das folgende Beispiel prüft, ob die erforderlichen Stileinträge vorhanden sind, ändert den ersten Linien‑Stil, ändert den dritten Füll‑Stil, aktiviert einen äußeren Schatten im dritten Effekt‑Stil und speichert das Ergebnis:

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

Für Formen, die diese Slots referenzieren, wird der erste Themen‑Linien‑Stil rot, der dritte Themen‑Füll‑Stil zu sattem Waldgrün und der dritte Effekt‑Stil erhält einen äußeren Schatten mit einem Abstand von 10 Punkten. Das genaue visuelle Ergebnis hängt weiterhin davon ab, welche Stil‑Slots jede Form referenziert und ob direkte Formatierung die Themen‑Einstellung überschreibt.

![Themen‑Effekt‑Stile nach Änderung von Linie, Füllung und Schatten‑Einstellungen](presentation-design_11.png)

## **Effektive Themen‑Werte auslesen**

Roh‑Themen‑Objekte zeigen, was auf einer bestimmten Ebene definiert ist. Effektive Werte zeigen, was eine Folie oder Form tatsächlich nach Auflösung von Vererbung und lokalen Überschreibungen verwendet. Für eine Folie rufen Sie [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/de/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) auf. Für einen Hintergrund verwenden Sie [Background.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/background/geteffective/), und für eine Füllung [FillFormat.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/geteffective/).

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

Verwenden Sie effektive Daten für Rendering‑Diagnosen, Validierung und Vergleiche. Wenn Sie nur [Presentation.MasterTheme](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/mastertheme/) untersuchen, können Sie eine Master‑, Layout‑, Folien‑ oder Form‑Überschreibung übersehen, die das endgültige Aussehen ändert.

## **FAQ**

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Verwenden Sie den [SlideThemeManager](https://reference.aspose.com/slides/de/net/aspose.slides.theme/slidethememanager/) der Folie und initialisieren Sie sein Überschreibungsthema. Die Änderung bleibt lokal auf dieser Folie; andere Folien erben weiterhin ihre bestehenden Themen.

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übertragen?**

Wenn Sie eine Folie verschieben und ihr ursprüngliches Aussehen bewahren wollen, klonen Sie den Quell‑Master in das Ziel und klonen Sie die Folie mit diesem Master mithilfe von [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/addclone/) und [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/). Dadurch bleiben Master, Layouts und Thema zusammen.

**Wie kann ich die effektiven Werte nach Vererbung und Überschreibungen sehen?**

Verwenden Sie [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/de/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) für ein Folien‑ oder Layout‑Thema und die entsprechenden effektiven‑Daten‑Methoden für Formatobjekte wie [Background.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/background/geteffective/) und [FillFormat.GetEffective](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/geteffective/). Diese APIs geben die aufgelösten Werte nach Anwendung von Vererbung und Überschreibungen zurück.