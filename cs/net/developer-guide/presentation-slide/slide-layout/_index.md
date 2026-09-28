---
title: Použití nebo změna rozvržení snímků v .NET
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/net/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupný objekt
- návrh prezentace
- návrh snímku
- nepoužívané rozvržení
- viditelnost zápatí
- titulní snímek
- nadpis a obsah
- záhlaví sekce
- dvě části
- porovnání
- pouze nadpis
- prázdné rozvržení
- obsah s popiskem
- obrázek s popiskem
- nadpis a svislý text
- svislý nadpis a text
- PowerPoint
- OpenDocument
- prezentace
- C#
- .NET
- Aspose.Slides
description: "Použijte, vytvářejte a upravujte rozvržení snímků v Aspose.Slides pro .NET, přidávejte zástupné objekty, odstraňujte nepoužívaná rozvržení a řiďte viditelnost zápatí."
---
## **Přehled**

Rozvržení snímku určuje polohy a formátování zástupných objektů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozvržení poskytuje snímkům konzistentní strukturu a zároveň umožňuje každému snímku obsahovat vlastní obsah.

Nejčastější rozvržení zahrnují:

- **Title Slide**: Obsahuje zástupné objekty pro nadpis a podnadpis.
- **Title and Content**: Obsahuje zástupný objekt pro nadpis a obecný zástupný objekt pro obsah.
- **Blank**: Neobsahuje žádné zástupné objekty pro obsah a je užitečné, když budou všechny tvary umístěny ručně.

## **Pochopte dědičnost rozvržení**

Prezentace má tři související úrovně:

1. Hlavní snímek ([master slide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/)) definuje motiv, sdílené formátování, pozadí a společné objekty.
1. Rozvržení snímku ([layout slide](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/)) patří k hlavnímu snímku a určuje konkrétní uspořádání zástupných objektů.
1. Normální snímek ([normal slide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/)) používá jedno rozvržení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozvržení a rozvržení dědí z hlavního snímku. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je vytvořen normální snímek, jeho tvary zástupných objektů jsou vygenerovány podle vybraného rozvržení, zatímco obsah zadaný do těchto objektů patří k normálnímu snímku.

Přidejte požadované zástupné objekty do rozvržení před vytvořením snímků z něj. Přidání dalšího zástupného objektu do rozvržení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozvržení, které je již v používání, zkontrolujte jeho závislé snímky a prohlédněte si výslednou prezentaci.
- Rozvržení, které je stále používáno snímkem, nelze odstranit. Nejprve přesuňte jeho závislé snímky na jiné rozvržení nebo odstraňte jen nepoužívaná rozvržení.

Pro více informací o nejvyšší úrovni této hierarchie viz [Slide Master](/slides/cs/net/slide-master/).

Pro skrytí zděděných log nebo dekorativních hlavních tvarů na jednom snímku nebo prostřednictvím sdíleného rozvržení viz [Control the Visibility of Master Graphics](/slides/cs/net/slide-master/). Příklad porovnává dva snímky používající stejný hlavní snímek.

## **Vyberte a použijte rozvržení snímku**

Používejte typ rozvržení, když prezentace následuje standardní definice rozvržení PowerPointu. Názvy rozvržení jsou editovatelné uživatelem a mohou být lokalizovány, takže výběr podle názvu je méně spolehlivý, pokud nekontrolujete zdrojovou šablonu.

Následující příklad hledá **Title and Content** v prvním hlavním snímku. Pokud toto rozvržení není k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat jen vlastní rozvržení. Vybrané rozvržení je poté použito na první normální snímek pomocí vlastnosti [ISlide.LayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Změna rozvržení snímku neodstraní obyčejné tvary přidané přímo na snímek. Nicméně mohou se změnit pozice zástupných objektů, zděděné formátování a shoda mezi existujícími zástupnými objekty a novým rozvržením, proto při přepínání mezi podstatně odlišnými rozvrženími výsledek pečlivě kontrolujte.

## **Přidejte rozvržení snímku**

Výběr a vytvoření jsou oddělené operace. Předchozí příklad vybere existující rozvržení; nevytvoří žádné. Pro vytvoření rozvržení zavolejte metodu [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/cs/net/aspose.slides/masterlayoutslidecollection/add/) na kolekci rozvržení cílového hlavního snímku.

Následující příklad vždy přidá nové rozvržení **Title and Content** pojmenované `Report Title and Content` a poté přidá normální snímek založený na tomto rozvržení. Názvy rozvržení musí být v kolekci jedinečné.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Přidejte rozvržení pouze tehdy, když šablona skutečně potřebuje další znovupoužitelnou strukturu. Pokud již existuje vhodné rozvržení, vyberte a znovu ho použijte místo vytváření duplikátu.

## **Přidejte zástupné objekty do rozvržení snímku**

Vlastnost [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/placeholdermanager/) poskytuje [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutplaceholdermanager/) pro přidávání tvarů zástupných objektů do rozvržení.

| Zástupný objekt PowerPointu | `ILayoutPlaceholderManager` Metoda |
| --------------------------- | ---------------------------------- |
| ![Obsah](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Obsah (svisle)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (svisle)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Obrázek](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Graf](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tabulka](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Média](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online obrázek](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Následující příklad ověří, že rozvržení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který použije upravené rozvržení. Pořadí je úmyslné: zástupné objekty jsou přidány před vytvořením normálního snímku, aby Aspose.Slides mohl vygenerovat odpovídající tvary zástupných objektů na tomto snímku.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Výsledek:

![Zástupné objekty na rozvržení snímku](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může ovlivnit závislé snímky. Nově přidaný zástupný objekt v rozvržení se nevyplní do existujících normálních snímků. Testujte změny rozvržení na kopii prezentace a kontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstraňte nepoužívaná rozvržení snímků**

Použijte metodu [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) k odebrání rozvržení, na která neodkazuje žádný normální snímek. Metoda ponechá rozvržení, která jsou stále používána, nedotčena.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Pro odebrání konkrétního rozvržení nejprve použijte jeho vlastnost [HasDependingSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/hasdependingslides/) nebo metodu [GetDependingSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/getdependingslides/). Přesuňte všechny závislé snímky před voláním [ILayoutSlide.Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/remove/). Pokus o odebrání používaného rozvržení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxeditexception/).

## **Ovládejte viditelnost patičky na rozvržení snímku**

Rozvržení má své vlastní zástupné objekty pro patičku, číslo snímku a datum‑čas. Použijte vlastnost [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/headerfootermanager/) k řízení těchto objektů pro jedno rozvržení. To je užitečné například, když rozvržení obsahu má zobrazovat patičky, ale rozvržení titulku ne.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Ovládejte viditelnost patičky na hlavním snímku a jeho podřízených rozvrženích**

Pro aplikaci jednotných nastavení patičky napříč hierarchií hlavního snímku použijte vlastnost [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/headerfootermanager/). Metody šíření [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslideheaderfootermanager/) působí na hlavní snímek i na jeho závislé rozvržení snímků a normální snímky; nemíří pouze na jeden normální snímek.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**What Is the Difference Between a Master Slide and a Layout Slide?**

Hlavní snímek definuje motiv a sdílené formátování prezentace. Rozvržení snímku patří k hlavnímu snímku a určuje jedno znovupoužitelné uspořádání zástupných objektů. Normální snímky používají tato rozvržení a ukládají obsah specifický pro konkrétní snímek.

**Can I Copy a Layout Slide from One Presentation to Another?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/globallayoutslidecollection/addclone/). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další zdroje použité ve zdrojovém rozvržení.

**What Happens When I Modify a Layout That Is Already in Use?**

Závislé snímky zdědí změny rozvržení, pokud místně nepřepíšou ovlivněné formátování nebo objekty. Geometrie zástupných objektů a zděděné stylování se tak mohou najednou změnit na mnoha snímcích. Před úpravou rozvržení použijte [GetDependingSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/getdependingslides/) k identifikaci ovlivněných snímků.

**What Happens If I Remove a Layout That Is Still in Use?**

Aspose.Slides vyhodí výjimku [PptxEditException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxeditexception/). Nejprve přesuňte závislé snímky, nebo použijte [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) k odebrání pouze neodkazovaných rozvržení.