---
title: Beheer presentatiethema's in .NET
linktitle: Presentatiethema
type: docs
weight: 10
url: /nl/net/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- dia-thema
- thema instellen
- thema wijzigen
- thema beheren
- themakleur
- extra palet
- thema-lettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor .NET om PowerPoint‑bestanden te maken, aan te passen en te converteren met consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert de eigenschappen van ontwerpelementen. Wanneer u een presentatiethema selecteert, kiest u in feite een specifieke set visuele elementen en hun eigenschappen.

In PowerPoint bestaat een thema uit kleuren, [lettertypen](/slides/nl/net/powerpoint-fonts/), [achtergrondstijlen](/slides/nl/net/presentation-background/), en effecten.

![theme-constituents](theme-constituiants.png)

## **Thema‑kleur wijzigen**

Een PowerPoint‑thema gebruikt een specifieke set kleuren voor verschillende elementen op een dia. Als u de kleuren niet bevalt, wijzigt u ze door nieuwe kleuren voor het thema toe te passen. Om u een nieuwe themakleur te laten kiezen, biedt Aspose.Slides waarden onder de [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/) enumeratie.

Deze C#‑code laat zien hoe u de accentkleur voor een thema wijzigt:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Zo kunt u de effectieve waarde van de resulterende kleur bepalen:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Kleur [A=255, R=128, G=100, B=162])
}
```

Om de kleuraanpassing verder te demonstreren, maken we een extra element en wijzen de accentkleur (van de eerste bewerking) toe. Vervolgens wijzigen we de kleur in het thema:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

De nieuwe kleur wordt automatisch op beide elementen toegepast.

### **Themakleur instellen vanuit een extra palet**

Wanneer u luminantie‑transformaties toepast op de hoofdthemakleur (1), ontstaan er kleuren uit het extra palet (2). U kunt die themakleuren vervolgens instellen en ophalen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hoofdthemakleuren  
**2** - Kleuren uit het extra palet.

Deze C#‑code demonstreert een bewerking waarbij kleuren uit het extra palet worden verkregen van de hoofdthemakleur en vervolgens in vormen worden gebruikt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Accent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Accent 4, Lichter 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, Lichter 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, Lichter 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, Donkerder 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, Donkerder 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Map `SchemeColor` naar `IColorScheme`‑kleuren**

Wanneer u werkt met [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/), merkt u misschien op dat het de volgende themakleurwaarden bevat:

`Background1`, `Background2`, `Text1` en `Text2`.

Echter, `Presentation.MasterTheme.ColorScheme` retourneert [IColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/icolorscheme/) die de bijbehorende kleuren exposeert als:

`Dark1`, `Dark2`, `Light1` en `Light2`.

Dit verschil zit alleen in de benaming. Deze waarden verwijzen naar dezelfde themakleur‑slots en de mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Er is geen dynamische conversie tussen `Text`/`Background` en `Dark`/`Light`. Het zijn simpelweg alternatieve namen voor dezelfde themakleuren.

Deze naamsverschillen komen voort uit de terminologie van Microsoft Office. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde slots weergeven als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Thema‑lettertype wijzigen**

Om u lettertypen voor thema’s en andere doeleinden te laten kiezen, gebruikt Aspose.Slides deze speciale identificatoren (vergelijkbaar met die in PowerPoint):

* **+mn-lt** - Body‑lettertype Latijn (Klein Latijns Lettertype)
* **+mj-lt** - Kop‑lettertype Latijn (Groot Latijns Lettertype)
* **+mn-ea** - Body‑lettertype Oost‑Aziatisch (Klein Oost‑Aziatisch Lettertype)
* **+mj-ea** - Body‑lettertype Oost‑Aziatisch (Klein Oost‑Aziatisch Lettertype)

Deze C#‑code laat zien hoe u het Latijnse lettertype aan een themaelement toewijst:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

Deze C#‑code laat zien hoe u het presentatiethema‑lettertype wijzigt:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

Het lettertype in alle tekstvakken wordt bijgewerkt.

{{% alert color="info" title="TIP" %}} 
U wilt mogelijk [PowerPoint‑lettertypen](/slides/nl/net/powerpoint-fonts/) bekijken. 
{{% /alert %}}

## **Thema‑achtergrondstijl wijzigen**

Standaard biedt de PowerPoint‑app 12 vooraf gedefinieerde achtergronden, maar in een typische presentatie worden slechts 3 van die 12 achtergronden opgeslagen.

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat u een presentatie hebt opgeslagen in de PowerPoint‑app, kunt u deze C#‑code uitvoeren om het aantal vooraf gedefinieerde achtergronden in de presentatie te achterhalen:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Met de [BackgroundFillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/backgroundfillstyles/)‑eigenschap van de [FormatScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/)‑klasse kunt u de achtergrondstijl in een PowerPoint‑thema toevoegen of benaderen. 
{{% /alert %}}

Deze C#‑code laat zien hoe u de achtergrond voor een presentatie instelt:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Indexgids**: 0 staat voor geen vulling. De index begint bij 1.

{{% alert color="info" title="TIP" %}} 
U wilt mogelijk [PowerPoint‑achtergrond](/slides/nl/net/presentation-background/) bekijken. 
{{% /alert %}}

## **Thema‑effect wijzigen**

Een PowerPoint‑thema bevat meestal 3 waarden voor elke stijlaray. Die arrays worden gecombineerd tot deze 3 effecten: subtiel, gematigd en intens. Bijvoorbeeld, dit is het resultaat wanneer de effecten op een specifieke vorm worden toegepast:

![todo:image_alt_text](presentation-design_10.png)

Door gebruik te maken van 3 eigenschappen ([FillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/effectstyles)) van de [FormatScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme)‑klasse kunt u de elementen in een thema wijzigen (nog flexibeler dan de opties in PowerPoint).

Deze C#‑code laat zien hoe u een thema‑effect wijzigt door onderdelen van elementen aan te passen:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

De resulterende wijzigingen in vulkleur, vultype, schaduweffect, enzovoort:

![todo:image_alt_text](presentation-design_11.png)

## **Veelgestelde vragen**

### Kan ik een thema op één dia toepassen zonder de master te wijzigen?

Ja. Aspose.Slides ondersteunt thema‑overrides op dia‑niveau, zodat u een lokaal thema alleen op die dia kunt toepassen terwijl het master‑thema ongewijzigd blijft (via de [SlideThemeManager](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/slidethememanager/)).

### Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?

[Clone slides](/slides/nl/net/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de originele master, lay-outs en het bijbehorende thema zodat het uiterlijk consistent blijft.

### Hoe kan ik de “effectieve” waarden zien na alle overerving en overrides?

Gebruik de ["effectieve" weergaven](/slides/nl/net/shape-effective-properties/) van de API voor thema/kleur/lettertype/effect. Deze retourneren de uiteindelijke, opgeloste eigenschappen na toepassen van de master plus eventuele lokale overrides.