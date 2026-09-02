---
title: Použít nebo změnit rozvržení snímků v .NET
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
- nepoužité rozvržení
- viditelnost zápatí
- titulní snímek
- název a obsah
- hlavička sekce
- dva obsahy
- porovnání
- pouze název
- prázdné rozvržení
- obsah s popiskem
- obrázek s popiskem
- název a vertikální text
- vertikální název a text
- PowerPoint
- OpenDocument
- prezentace
- C#
- .NET
- Aspose.Slides
description: "Používejte, vytvářejte a upravujte rozvržení snímků v Aspose.Slides pro .NET, přidávejte zástupné objekty, odstraňujte nepoužitá rozvržení a ovládejte viditelnost zápatí."
---
## **Přehled**

Rozvržení snímku určuje pozice a formátování zástupných objektů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozvržení poskytuje snímkům konzistentní strukturu a zároveň umožňuje každému snímku obsahovat vlastní obsah.

Mezi nejčastější rozvržení patří:

- **Title Slide**: Obsahuje zástupné objekty názvu a podnázvu.
- **Title and Content**: Obsahuje zástupný objekt názvu a obecný zástupný objekt obsahu.
- **Blank**: Neobsahuje žádné zástupné objekty obsahu a je užitečný, když budou všechny tvary umístěny ručně.

## **Pochopit dědičnost rozvržení**

Prezentační soubor má tři související úrovně:

1. A [master slide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/) definuje téma, sdílené formátování, pozadí a společné objekty.
2. A [layout slide](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/) patří k masteru a určuje konkrétní uspořádání zástupných objektů.
3. A [normal slide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/) používá jedno rozvržení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí téma a formátování ze svého rozvržení a rozvržení dědí z masteru. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je normální snímek vytvořen, jeho tvary zástupných objektů jsou generovány podle vybraného rozvržení, zatímco obsah vložený do těchto zástupných objektů patří normálnímu snímku.

Přidejte požadované zástupné objekty do rozvržení před vytvořením snímků z něj. Přidání dalšího zástupného objektu do rozvržení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může aktualizovat všechny snímky, které na něm závisí. Před úpravou rozvržení, které je již používáno, zkontrolujte jeho závislé snímky a přezkoumejte výslednou prezentaci.
- Rozvržení, které je stále použito některým snímkem, nelze odstranit. Nejprve přiřaďte jeho závislé snímky k jinému rozvržení nebo odstraňte jen nepoužívaná rozvržení.

Pro více informací o nejvyšší úrovni této hierarchie viz [Slide Master](/slides/cs/net/slide-master/).

## **Vybrat a použít rozvržení snímku**

Použijte typ rozvržení, když prezentace používá standardní definice rozvržení PowerPointu. Názvy rozvržení jsou upravitelné uživatelem a mohou být lokalizovány, takže výběr založený na názvu je méně spolehlivý, pokud nepřevzímáte kontrolu nad zdrojovou šablonou.

Následující příklad hledá **Title and Content** na prvním masteru. Pokud toto rozvržení není k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat pouze vlastní rozvržení. Vybrané rozvržení je pak použito na první normální snímek pomocí vlastnosti [ISlide.LayoutSlide].

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

Změna rozvržení snímku neodstraňuje běžné tvary přidané přímo na snímek. Nicméně se mohou změnit pozice zástupných objektů, zděděné formátování a odpovídající vztah mezi existujícími zástupnými objekty a novým rozvržením, proto prověřte výstup při přepínání mezi podstatně odlišnými rozvrženími.

## **Přidat rozvržení snímku**

Výběr a vytvoření jsou samostatné operace. Předchozí příklad vybírá existující rozvržení; nevytváří žádné. Pro vytvoření rozvržení zavolejte metodu [IMasterLayoutSlideCollection.Add] na kolekci rozvržení cílového masteru.

Následující příklad vždy přidá nové rozvržení **Title and Content** s názvem `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozvržení musí být v kolekci jedinečné.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Přidejte rozvržení jen tehdy, když šablona skutečně potřebuje další znovupoužitelnou strukturu. Pokud vhodné rozvržení již existuje, vyberte a použijte jej místo vytvoření duplikátu.

## **Přidat zástupné objekty do rozvržení snímku**

Vlastnost [ILayoutSlide.PlaceholderManager] poskytuje [ILayoutPlaceholderManager] pro přidávání tvarů zástupných objektů do rozvržení.

| Zástupný objekt PowerPoint | Metoda `ILayoutPlaceholderManager` |
| -------------------------- | ---------------------------------- |
| ![Obsah](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Obsah (vertikální)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (vertikální)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Obrázek](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Graf](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tabulka](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Média](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online obrázek](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Následující příklad ověří, že rozvržení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který použije upravené rozvržení. Pořadí je záměrné: zástupné objekty jsou přidány před vytvořením normálního snímku, takže Aspose.Slides může vygenerovat odpovídající tvary zástupných objektů na tomto snímku.

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
Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozvržení se nevyplní do existujících normálních snímků. Testujte změny rozvržení na kopii prezentace a prověřte každý závislý snímek.
{{% /alert %}}

## **Odstranit nepoužívaná rozvržení snímků**

Použijte metodu [Compress.RemoveUnusedLayoutSlides] k odstranění rozvržení, na která neodkazuje žádný normální snímek. Metoda ponechá rozvržení, která jsou stále používána, beze změny.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Pro odstranění konkrétního rozvržení nejprve použijte jeho vlastnost [HasDependingSlides] nebo metodu [GetDependingSlides]. Před voláním [ILayoutSlide.Remove] přesuňte všechny závislé snímky. Pokus o odstranění používaného rozvržení vyvolá výjimku [PptxEditException].

## **Ovládání viditelnosti zápatí na rozvržení snímku**

Rozvržení má své vlastní zástupné objekty zápatí, číslo snímku a datum/čas. Použijte vlastnost [ILayoutSlide.HeaderFooterManager] k řízení těchto zástupných objektů pro jedno rozvržení. To je užitečné například, když rozvržení obsahu má zobrazovat zápatí, ale rozvržení titulku ne.

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

## **Ovládání viditelnosti zápatí na masteru a jeho podřízených rozvrženích**

Pro použití jednotných nastavení zápatí napříč hierarchií masteru použijte vlastnost [IMasterSlide.HeaderFooterManager]. Metody šíření [IMasterSlideHeaderFooterManager] působí na master a jeho závislá rozvržení snímků i normální snímky; nezasahují pouze do jednoho normálního snímku.

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

**Jaký je rozdíl mezi master snímkem a layout snímkem?**

Master snímek určuje téma prezentace a sdílené formátování. Layout snímek patří k masteru a definuje jedno znovupoužitelné uspořádání zástupných objektů. Normální snímky používají tato rozvržení a ukládají obsah specifický pro snímek.

**Mohu zkopírovat layout snímek z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [AddClone]. Při kopírování mezi prezentacemi také ověřte písma, témata, obrázky a další zdroje používané zdrojovým rozvržením.

**Co se stane, když upravím rozvržení, které je již používáno?**

Závislé snímky zdědí změny rozvržení, pokud lokálně nepřepíší ovlivněné formátování nebo objekty. Geometrie zástupných objektů a zděděné stylování se tedy mohou najednou změnit na mnoha snímcích. Použijte [GetDependingSlides] k určení ovlivněných snímků před úpravou rozvržení.

**Co se stane, pokud odstraním rozvržení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException]. Nejprve přesuňte závislé snímky, nebo použijte [RemoveUnusedLayoutSlides] k odstranění pouze neodkazovaných rozvržení.