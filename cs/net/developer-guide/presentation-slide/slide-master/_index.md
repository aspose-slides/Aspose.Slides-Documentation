---
title: Správa master snímků prezentace v .NET
linktitle: Mistrovský snímek
type: docs
weight: 80
url: /cs/net/slide-master/
keywords:
- master snímek
- master snímek
- PPT master snímek
- více master snímků
- porovnání master snímků
- pozadí
- zástupný objekt
- klonovat master snímek
- kopírovat master snímek
- duplikovat master snímek
- nepoužívaný master snímek
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte master snímky v Aspose.Slides pro .NET: přístup, úpravy, klonování, porovnání a odstraňování master snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**Slide master** definuje sdílená nastavení návrhu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž byste opakovali stejné formátování na každém snímku.

Aspose.Slides pro .NET podporuje stejný model. Prezentace může obsahovat jeden nebo více master snímků a každý master snímek může obsahovat několik layout snímků. Normální snímky se obvykle nepřipojují přímo k master snímku. Místo toho normální snímek používá layout snímek, který patří k master snímku.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.
1. **Layout slide** – definuje konkrétní uspořádání zástupných objektů a formátování na úrovni layoutu.
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden layout snímek.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován rozhraním [IMasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/). Všechny master snímky v prezentaci jsou dostupné přes kolekci [Presentation.Masters](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/masters/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vyhrává specifikovanější úroveň. Například pokud master snímek i layout snímek definují pozadí, snímky založené na tomto layoutu použijí pozadí layoutu. Další informace o layout snímcích najdete v [Apply or Change Slide Layouts](/slides/cs/net/slide-layout/).
{{% /alert %}}

## **Přístup k Slide Masterům**

V PowerPointu můžete otevřít zobrazení Slide Master přes **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `Masters` pro přístup k master snímkům:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Můžete také získat master snímek použité normálním snímkem přes jeho layout:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Co Slide Master obsahuje**

Master snímek je objekt podobný snímku. Implementuje [IBaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/), takže zpřístupňuje mnoho stejných vlastností snímku používaných normálními a layout snímky. Členové specifické pro master jsou uvedeni na stránce API [IMasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/).

Mezi často používané členy master snímku patří:

| Member | Purpose |
| --- | --- |
| `Background` | Nastavuje pozadí na úrovni master snímku. |
| `Shapes` | Uchovává tvary umístěné na masteru, jako jsou loga, rámy obrázků a sdílený text. |
| `LayoutSlides` | Uchovává layout snímky, které patří k masteru. |
| `ThemeManager` | Poskytuje přístup k API motivu masteru. |
| `HeaderFooterManager` | Ovládá záhlaví, zápatí, datum a číslování snímků pro master a jeho podřízené layouty. |
| `GetDependingSlides` | Vrací normální snímky, které závisí na masteru prostřednictvím jejich layoutů. |

## **Přidání obrázku do Slide Masteru**

Když přidáte obrázek do master snímku, objeví se na snímcích, které používají layouty z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidá logo na první master snímek:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Další informace o rámech obrázků najdete v [Picture Frame](/slides/cs/net/picture-frame/).

## **Práce se zástupnými objekty**

Zástupné objekty jsou obvykle definovány na layout snímcích. Master snímek poskytuje sdílený styl a motiv, které layouty dědí, zatímco každý layout rozhoduje, které zástupné objekty jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty dostupné v zobrazení Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Chcete‑li přidat nové zástupné objekty s Aspose.Slides, pracujte s layout snímkem, který patří k masteru:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Můžete také formátovat tvary zástupných objektů, které již na master snímku existují. Následující příklad najde zástupný objekt titulu a aplikuje lineární přechod výplně:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Další možnosti formátování zástupných objektů a textu najdete v [Set Prompt Text in Placeholder](/slides/cs/net/manage-placeholder/) a [Text Formatting](/slides/cs/net/text-formatting/).

## **Změna pozadí Slide Masteru**

Pozadí masteru je děděno layouty a snímky, které jej nepřepíší. Následující příklad nastaví jednotnou barvu pozadí pro první master snímek:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Související témata najdete v [Presentation Background](/slides/cs/net/presentation-background/) a [Presentation Theme](/slides/cs/net/presentation-theme/).

## **Klonování Slide Masteru do jiné prezentace**

Použijte [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/) k kopírování master snímku do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Pokud potřebujete klonovat normální snímky spolu s jejich masterem, podívejte se na [Clone Slides](/slides/cs/net/clone-slides/).

## **Přidání více Slide Masterů**

Prezentace může obsahovat více master snímků. To je užitečné, pokud různé sekce vyžadují odlišnou značku, strukturu stránky nebo nastavení motivu.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Následující příklad klonuje výchozí master, dá klonu jiné pozadí, vytvoří layout pod tímto klonovaným masterem a přidá nový snímek založený na tomto layoutu:

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Porovnání Slide Masterů**

Master snímky lze porovnat metodou `Equals` zděděnou z [IBaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, jako je aktuální datum.

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Další informace naleznete v [Compare Presentation Slides](/slides/cs/net/compare-slides/).

## **Nastavení Slide Master View jako výchozího zobrazení**

Použijte vlastnost `LastView` na [ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/) k ovládání zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Další nastavení zobrazení najdete v [Save Presentation](/slides/cs/net/save-presentation/).

## **Odstranění nepoužívaných Master Snímků**

Někdy prezentace obsahuje master snímky, které již nejsou používány žádnými normálními snímky. Odstranění nepoužívaných masterů může zmenšit velikost souboru a zjednodušit údržbu šablony.

Použijte [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/cs/net/aspose.slides/masterslidecollection/removeunused/) k odstranění nepoužívaných masterů z kolekce `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Můžete také použít low‑code metodu [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Jaký je rozdíl mezi slide masterem a layout snímkem?**

Slide master definuje sdílená nastavení návrhu, jako je motiv, pozadí, společné tvary a styly textu. Layout snímek patří k masteru a definuje konkrétní uspořádání zástupných objektů. Normální snímek používá layout snímek, takže dědí jak z layoutu, tak z masteru.

**Může jedna prezentace obsahovat několik slide masterů?**

Ano. Prezentace může obsahovat několik slide masterů. Používejte více masterů, když různé sekce potřebují odlišné vizuální systémy nebo značkování.

**Mám přidávat zástupné objekty do master snímku nebo do layout snímku?**

Ve většině případů přidávejte zástupné objekty do layout snímků. Sdílené vizuální prvky a společné formátování umístěte na master snímek a obsahové zástupné objekty na layouty, které budou používat normální snímky.

**Mohu smazat master snímek, který je ještě používán?**

Ne. Master snímek, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky na layouty pod jiným masterem nebo použijte metodu úklidu nepoužívaných masterů, která odstraní pouze master snímky, které nejsou v použití.