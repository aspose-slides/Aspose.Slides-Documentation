---
title: Správa master snímků prezentace v .NET
linktitle: Master snímku
type: docs
weight: 80
url: /cs/net/slide-master/
keywords:
- master snímku
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
description: "Spravujte master snímky v Aspose.Slides pro .NET: přístup, úprava, klonování, porovnání a odstraňování master snímků v PowerPoint a OpenDocument prezentacích."
---
## **Přehled**

**Slide master** určuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž by se stejné formátování opakovalo na každém snímku.

Aspose.Slides pro .NET podporuje stejný model. Prezentace může obsahovat jeden nebo více master snímků a každý master snímek může obsahovat několik layout snímků. Normální snímky obvykle neodkazují přímo na master snímek. Místo toho normální snímek používá layout snímek, který patří k master snímku.

Hierarchie je:

1. **Slide master** – určuje sdílený design a motiv.
1. **Layout slide** – určuje konkrétní uspořádání zástupných objektů a formátování na úrovni rozvržení.
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jedno rozvržení.

![Hierarchie master snímků, layout snímků a normálních snímků](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován rozhraním [IMasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/). Všechny master snímky v prezentaci jsou dostupné přes kolekci [Presentation.Masters](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/masters/), která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vyhrává specifikovanější úroveň. Například pokud master snímek i layout snímek definují pozadí, snímky založené na tomto layoutu použijí pozadí layoutu. Další informace o layout snímcích naleznete v [Apply or Change Slide Layouts](/slides/cs/net/slide-layout/).
{{% /alert %}}

## **Přístup k Slide Mastreům**

V PowerPointu můžete otevřít zobrazení Slide Master přes **View** > **Slide Master**.

![Příkaz Slide Master na kartě PowerPoint View](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `Masters` pro přístup k master snímkům:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Můžete také získat master snímek použité normálním snímkem přes jeho layout:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Co Slide Master Obsahuje**

Master snímek je objekt podobný snímku. Implementuje [IBaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/), takže vystavuje mnoho stejných vlastností snímku používaných normálními a layout snímky. Master‑specifické členy jsou uvedeny na stránce API [IMasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/).

Často používané členy master snímku zahrnují:

| Člen | Účel |
| --- | --- |
| `Background` | Nastavuje pozadí na úrovni master snímku. |
| `Shapes` | Uchovává tvary umístěné na masteru, např. loga, rámečky obrázků a sdílený text. |
| `LayoutSlides` | Uchovává layout snímky, které patří k masteru. |
| `ThemeManager` | Poskytuje přístup k API motivu masteru. |
| `HeaderFooterManager` | Řídí záhlaví, zápatí, datum a čísla snímků pro master a jeho podřízené layouty. |
| `GetDependingSlides` | Vrací normální snímky, které jsou na masteru závislé skrze své layouty. |

## **Přidání Obrázku do Slide Masteru**

Když přidáte obrázek do master snímku, objeví se na snímcích, které používají layouty z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální prvky.

Následující příklad přidá logo na první master snímek:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Další informace o rámečcích obrázků najdete v [Picture Frame](/slides/cs/net/picture-frame/).

## **Řízení Viditelnosti Grafiky Masteru**

Použijte [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/showmastershapes/) k skrytí děděné grafiky masteru, jako jsou loga nebo dekorativní tvary, aniž byste je mazali z masteru. Nastavte [Slide.ShowMasterShapes](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/showmastershapes/) na `false` u snímku, který má tyto grafiky vynechat, a ponechte jej `true` u snímků, které je mají zobrazit.

Následující samostatný příklad vytvoří modrý dekorativní pás na masteru a dva snímky, které používají stejný prázdný layout. Pás je viditelný na prvním snímku a skrytý na druhém. Nevstupní prezentace ani obrázek nejsou potřeba.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

Příklad používá layout **Blank**, který je součástí nové prezentace, a odstraňuje počáteční zástupné objekty snímku.

### **Zvolte Rozsah Nastavení**

Normální snímek používá svého mastera přes [ISlide.LayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/layoutslide/) a [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/masterslide/). Nastavení vlastnosti na jednotlivém snímku ovlivní jen tento snímek. Nastavení [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutslide/showmastershapes/) na `false` skryje grafiku masteru pro všechny snímky používající daný sdílený layout, i když je jejich vlastní nastavení `true`. Pro skrytí grafiky jen na jednom snímku změňte vlastnost snímku a ponechte sdílený layout nezměněný.

Nastavení není podporováno jako řízení viditelnosti přímo na master snímku. Na masteru vždy vrací `false` a při přiřazení `true` vyvolá `NotSupportedException`. Použijte jej na normální snímek nebo na layout.

### **Rozlišení Grafiky od Pozadí**

| Operace | Efekt |
| --- | --- |
| Skrýt grafiku masteru | Řídí viditelnost děděných tvarů masteru, aniž by je mazala nebo měnila tvary snímku. |
| Změnit výplň pozadí snímku | Mění barvu, gradient nebo obrázek pozadí. Grafika masteru je samostatný tvar a může zůstávat viditelná nad tímto pozadím. Viz [Presentation Background](/slides/cs/net/presentation-background/). |
| Smazat tvar z masteru | Odstraní sdílený zdrojový tvar, takže už není k dispozici žádnému snímku používajícímu tento master. |

## **Práce se Zástupnými Objekty**

Zástupné objekty jsou obvykle definovány na layout snímcích. Master snímek poskytuje sdílený styl a motiv, který layouty dědí, zatímco každý layout rozhoduje, které zástupné objekty jsou dostupné a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty dostupné v zobrazení Slide Master.

![Příkaz Insert Placeholder v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových zástupných objektů v Aspose.Slides pracujte s layout snímkem, který patří k masteru:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Můžete také formátovat tvary zástupných objektů, které již na master snímku existují. Následující příklad najde zástupný objekt titulu a použije lineární gradientní výplň:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Formátovaný titulek zástupného objektu děděný normálními snímky](slide-master_8.png)

Další možnosti formátování zástupných objektů a textu najdete v [Set Prompt Text in Placeholder](/slides/cs/net/manage-placeholder/) a [Text Formatting](/slides/cs/net/text-formatting/).

## **Změna Pozadí Slide Masteru**

Pozadí masteru je děděno layouty a snímky, které jej nepřepíší. Následující příklad nastaví jednolitou barvu pozadí pro první master snímek:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Související témata: [Presentation Background](/slides/cs/net/presentation-background/) a [Presentation Theme](/slides/cs/net/presentation-theme/).

## **Klonování Slide Masteru do Jiné Prezentace**

Použijte [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection/addclone/) k zkopírování master snímku do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Pokud potřebujete klonovat normální snímky společně s jejich masterem, viz [Clone Slides](/slides/cs/net/clone-slides/).

## **Přidání Více Slide Masterů**

Prezentace může obsahovat více master snímků. To je užitečné, když různé sekce vyžadují odlišnou značku, strukturu stránek nebo nastavení motivu.

![Příkazy PowerPoint pro vkládání a správu master snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí master, dá klonu jiné pozadí, vytvoří layout pod tímto klonovaným masterem a přidá nový snímek založený na tomto layoutu:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Master snímky lze porovnat metodou `Equals` zděděnou z [IBaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Neporovnává jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, jako je aktuální datum.

```csharp
using Aspose.Slides;

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

Další informace najdete v [Compare Presentation Slides](/slides/cs/net/compare-slides/).

## **Nastavení Slide Master View jako Výchozího Zobrazení**

Použijte vlastnost `LastView` na [ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/) k řízení zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Další nastavení zobrazení najdete v [Save Presentation](/slides/cs/net/save-presentation/).

## **Odstranění Nepoužívaných Master Snímků**

Prezentace někdy obsahují master snímky, které již žádný normální snímek nepoužívá. Odstranění nepoužívaných masterů může snížit velikost souboru a zjednodušit údržbu šablon.

Použijte [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/cs/net/aspose.slides/masterslidecollection/removeunused/) k odstranění nepoužívaných masterů ze sbírky `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Můžete také použít low‑code metodu [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Jaký je rozdíl mezi slide masterem a layout snímkem?**  
Slide master určuje sdílená nastavení designu, jako jsou motiv, pozadí, společné tvary a styly textu. Layout snímek patří k masteru a definuje konkrétní uspořádání zástupných objektů. Normální snímek používá layout snímek, takže dědí jak z layoutu, tak z masteru.

**Může jedna prezentace obsahovat několik slide masterů?**  
Ano. Prezentace může obsahovat několik master snímků. Používejte více masterů, když různé sekce potřebují odlišné vizuální systémy nebo značku.

**Mám přidávat zástupné objekty na master snímek nebo na layout snímek?**  
Ve většině případů přidávejte zástupné objekty na layout snímky. Sdílené vizuální prvky a formátování umístěte na master snímek a obsahové zástupné objekty na layouty, které budou normální snímky používat.

**Mohu smazat master snímek, který je stále používán?**  
Ne. Master snímek, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky na layouty pod jiný master, nebo použijte metodu pro úklid nepoužívaných masterů, která odstraňuje jen ty, které nejsou v použití.