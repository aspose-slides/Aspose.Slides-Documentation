---
title: Beheer presentatiethema’s in .NET
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
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer presentatiethema’s in Aspose.Slides voor .NET om PowerPoint-bestanden te maken, aanpassen en converteren met een consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert de eigenschappen van ontwerpelementen. Wanneer u een presentatiethema selecteert, kiest u in feite een specifieke set visuele elementen en hun eigenschappen.

In PowerPoint bestaat een thema uit kleuren, [lettertypen](/slides/nl/net/powerpoint-fonts/), [achtergrondstijlen](/slides/nl/net/presentation-background/) en effecten.

![theme-constituents](theme-constituents.png)

## **Themakleur wijzigen**

Een PowerPoint‑thema gebruikt een specifieke set kleuren voor verschillende elementen op een dia. Als u de kleuren niet bevalt, wijzigt u ze door nieuwe kleuren voor het thema toe te passen. Om een nieuwe themakleur te selecteren, biedt Aspose.Slides waarden onder de [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/)‑enumeratie.

Deze C#‑code laat zien hoe u de accentkleur van een thema wijzigt:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

U kunt de effectieve waarde van de resulterende kleur op deze manier bepalen:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Kleur [A=255, R=128, G=100, B=162])
```

Om de kleuraanpassing verder te demonstreren, maken we een extra element en wijzen we de accentkleur (van de eerste bewerking) toe. Vervolgens wijzigen we de kleur in het thema:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

De nieuwe kleur wordt automatisch toegepast op beide elementen.

### **Themakleur instellen vanuit een extra palet**

Wanneer u luminantietransformaties toepast op de hoofdthemakleur(1), ontstaan er kleuren uit het extra palet(2). Deze themakleuren kunt u vervolgens instellen en ophalen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hoofdthemakleuren  

**2** - Kleuren uit het extra palet.

Deze C#‑code demonstreert een bewerking waarbij extra paletkleuren worden afgeleid van de hoofdthemakleur en vervolgens in vormen worden gebruikt:

```c#
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

### **`SchemeColor` koppelen aan `IColorScheme`‑kleuren**

Wanneer u werkt met [SchemeColor](https://reference.aspose.com/slides/nl/net/aspose.slides/schemecolor/), ziet u dat deze de volgende themakleurwaarden bevat:

`Background1`, `Background2`, `Text1` en `Text2`.

Echter, `Presentation.MasterTheme.ColorScheme` geeft een [IColorScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/icolorscheme/) terug, die de overeenkomstige kleuren exposeert als:

`Dark1`, `Dark2`, `Light1` en `Light2`.

Dit verschil zit alleen in de benaming. Deze waarden verwijzen naar dezelfde themakleur‑posities en de mapping is vast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Er is geen dynamische conversie tussen `Text`/`Background` en `Dark`/`Light`. Het zijn simpelweg alternatieve namen voor dezelfde themakleuren.

Dit benamingsverschil komt voort uit de Microsoft‑Office‑terminologie. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde posities weergeven als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Thema‑lettertype wijzigen**

Om u in staat te stellen lettertypen voor thema’s en andere doeleinden te selecteren, gebruikt Aspose.Slides deze speciale identifiers (vergelijkbaar met die in PowerPoint):

* **+mn-lt** – Body Font Latin (Minor Latin Font)  
* **+mj-lt** – Heading Font Latin (Major Latin Font)  
* **+mn-ea** – Body Font East Asian (Minor East Asian Font)  
* **+mj-ea** – Body Font East Asian (Minor East Asian Font)

Deze C#‑code toont hoe u het Latijnse lettertype aan een thema‑element toewijst:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Deze C#‑code toont hoe u het presentatiethema‑lettertype wijzigt:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Het lettertype in alle tekstvakken wordt bijgewerkt.

{{% alert color="primary" title="TIP" %}} 
U wilt misschien de [PowerPoint‑lettertypen](/slides/nl/net/powerpoint-fonts/) bekijken. 
{{% /alert %}}

## **Achtergrondstijl van thema wijzigen**

Standaard biedt de PowerPoint‑applicatie 12 voorgedefinieerde achtergronden, maar slechts 3 van die 12 worden bewaard in een typische presentatie.

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat u een presentatie hebt opgeslagen in de PowerPoint‑app, kunt u deze C#‑code uitvoeren om het aantal voorgedefinieerde achtergronden in de presentatie te achterhalen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Met de eigenschap [BackgroundFillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) van de [FormatScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/)‑klasse kunt u de achtergrondstijl in een PowerPoint‑thema toevoegen of benaderen. 
{{% /alert %}}

Deze C#‑code laat zien hoe u de achtergrond voor een presentatie instelt:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Indexgids**: 0 betekent geen vulling. De index start bij 1.

{{% alert color="primary" title="TIP" %}} 
U wilt misschien de [PowerPoint‑achtergrond](/slides/nl/net/presentation-background/) bekijken. 
{{% /alert %}}

## **Thema‑effect wijzigen**

Een PowerPoint‑thema bevat doorgaans 3 waarden voor elke stijlaray. Deze arrays worden samengevoegd tot de 3 effecten: subtiel, gematigd en intens. Bijvoorbeeld, dit is het resultaat wanneer de effecten op een specifieke vorm worden toegepast:

![todo:image_alt_text](presentation-design_10.png)

Met 3 eigenschappen ([FillStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme/effectstyles)) van de [FormatScheme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/formatscheme)‑klasse kunt u elementen in een thema wijzigen (nog flexibeler dan de opties in PowerPoint).

Deze C#‑code laat zien hoe u een thema‑effect wijzigt door delen van elementen aan te passen:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

De resulterende wijzigingen in vulkleur, vultype, schaduweffect, enz.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kan ik een thema op een enkele dia toepassen zonder de master te wijzigen?**

Ja. Aspose.Slides ondersteunt thema‑overschrijvingen op dia‑niveau, zodat u een lokaal thema op alleen die dia kunt toepassen terwijl het master‑thema intact blijft (via de [SlideThemeManager](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/slidethememanager/)).

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**

[Slides dupliceren](/slides/nl/net/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de originele master, lay-outs en het bijbehorende thema zodat de weergave consistent blijft.

**Hoe kan ik de “effectieve” waarden zien na alle overerving en overschrijvingen?**

Gebruik de ["effectieve"](/slides/nl/net/shape-effective-properties/) weergaven van de API voor thema/kleur/lettertype/effect. Deze geven de uiteindelijke, berekende eigenschappen terug na toepassing van de master en eventuele lokale overschrijvingen.