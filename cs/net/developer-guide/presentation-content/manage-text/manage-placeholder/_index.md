---
title: Spravovat zástupné prvky prezentace v .NET
linktitle: Spravovat zástupné prvky
type: docs
weight: 10
url: /cs/net/manage-placeholder/
keywords:
- zástupný prvek
- textový zástupný prvek
- obrázkový zástupný prvek
- grafický zástupný prvek
- obsahový zástupný prvek
- výzva (prompt) text
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak kontrolovat a upravovat textové, obrázkové, grafické a obsahové zástupné prvky a pochopit dědičnost zástupných prvků s Aspose.Slides pro .NET."
---
## **Přehled**

Zástupný prvek je tvar, který vyhrazuje pozici pro konkrétní typ obsahu v šabloně prezentace. Běžné příklady jsou zástupné prvky pro název, tělo, obrázek, graf a obecné účely. Na rozdíl od běžného tvaru může zástupný prvek dědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo hlavního snímku.

Aspose.Slides zpřístupňuje informace o zástupných prvcích prostřednictvím vlastnosti [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). Vlastnost vrací objekt [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) nebo `null` pro běžný tvar. Použijte [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) k určení, co je zástupný prvek určen k obsahu.

Rozhraní tvaru je stále důležité, i když znáte typ zástupného prvku:

- Prázdný textový, obrázkový, grafický nebo obsahový zástupný prvek je obvykle reprezentován pomocí [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Vyplněný obrázkový zástupný prvek může být reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Vyplněný grafický zástupný prvek může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Obsahový zástupný prvek může obsahovat několik typů obsahu. Zkontrolujte jak [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) tak rozhraní tvaru za běhu, místo předpokladu, že každý zástupný prvek je [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) popisuje roli zástupného prvku; nezaručuje typ tvaru za běhu. Vždy použijte kontrolu typu před přístupem k textu, obrázku, grafu, tabulce nebo mediálním specifickým členům.
{{% /alert %}}

## **Pochopení dědičnosti zástupných prvků**

Zástupné prvky tvoří hierarchii:

1. Hlavní snímek (master slide) definuje opakovaně použitelné styly a v některých případech i zástupné prvky úrovně hlavního snímku.
2. Rozložení snímku (layout slide) určuje uspořádání použité jedním nebo více normálními snímky a může dědit od hlavního snímku.
3. Normální snímek obsahuje zástupné prvky pro tento snímek a může dědit od svého rozložení.

Zavolejte [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) pro posun o úroveň výš v této hierarchii. Zástupný prvek snímku obvykle vrací svůj zástupný prvek rozložení; zástupný prvek rozložení může vrátit svůj hlavní zástupný prvek. Metoda vrací `null`, když tvar nemá základní zástupný prvek.

Následující příklad vypisuje zástupné prvky na prvním snímku a uvádí jejich základní zástupné prvky:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Úprava zástupného prvku na normálním snímku vytvoří nebo změní místní přepsání pro tento snímek. Úprava souvisejícího rozložení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Místní běžný tvar nemá základní zástupný prvek a nezačíná dědit jen proto, že obsazuje stejné souřadnice.

## **Odstranění stavu zástupného prvku**

Při úpravě šablony použijte [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) k zachování existujícího objektu jako běžného tvaru. Jeho vlastnost [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) se stane `null`, ale tvar zůstane ve sbírce snímku. Naopak [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) smaže tvar z této sbírky.

Následující příklad vyžaduje `template.pptx` s alespoň jedním snímkem a neprázdným textovým zástupným prvkem na prvním snímku. Použijte zástupný prvek s formátováním děděným z jeho rozložení nebo hlavního snímku, abyste viděli efekt odstranění tohoto vztahu. Příklad kontroluje, že stejný tvar zůstane, volá metodu znovu na nyní běžném tvaru a ukládá výsledek.

{{% alert color="warning" title="Warning" %}}
Odstranění stavu zástupného prvku automaticky neuchovává děděná nastavení vzhledu. Níže uvedený příklad úmyslně nechává tato nastavení nezměněná, takže výstup může vypadat odlišně. Tvar, jehož pozice a velikost jsou zcela zděděny, může po volání mít nulové souřadnice a rozměry a stát se neviditelným, i když zůstane v kolekci.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Volání metody na běžném tvaru nemá žádný efekt.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Pro odpovídající zástupný prvek všechny tři kontroly vytisknou `True`. Text zůstane, ale děděná pozice, velikost, rotace, písmo, zarovnání odstavců, okraje textového rámce, vertikální ukotvení, výplň a nastavení čáry se mohou změnit, když je vztah zástupného prvku odstraněn. Například děděné formátování názvu může přejít na běžné textové formátování. Viz [Slide Layout](/slides/cs/net/slide-layout/) pro více informací o rozložení.

Pro zachování zamýšleného vzhledu zachyťte vypočtenou pozici, velikost a rotaci před voláním a zkopírujte požadované hodnoty efektivního formátování do samostatných proměnných. Získejte tyto hodnoty pomocí [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), a [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Nespoléhejte se pouze na objekty efektivního formátu, protože jejich hodnoty textového formátování se mohou po odstranění vztahu změnit. Výslovně aplikujte zachycené hodnoty na běžný tvar následně, včetně rodiny písma, velikosti, stylu, barvy, nastavení odstavců, nastavení textového rámce, výplně a čáry použité ve vaší šabloně.

Děděná geometrie tvaru může také vyžadovat explicitní přiřazení pomocí [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). Pro obdélníkový textový zástupný prvek to znamená přiřadit [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); obnovení pouze výplně a čáry nemusí obnovit viditelný obdélník. Šablony s dalšími efekty nebo složitějším formátováním vyžadují, aby byla tato nastavení také zpracována.

## **Změna textu ve zástupném prvku**

Název, centrovaný název, podtitul, tělo a textové zástupné prvky obvykle podporují text. Před použitím vlastnosti [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) zkontrolujte, zda se jedná o [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

Tento příklad aktualizuje první zástupný prvek názvu na prvním snímku a uloží výsledek:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Tento vzor zabraňuje přetypování obrázkových, grafových, tabulkových nebo mediálních zástupných prvků na [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Také identifikuje zástupný prvek podle účelu místo spoléhaní se na křehký index tvaru.

## **Nastavení výzvy (prompt) textu v rozložení**

Prompt text je návrhový pokyn zobrazený v prázdném zástupném prvku, například *Click to add title*. Nastavte vlastní prompt text v zástupném prvku rozložení místo pokusu o jeho získání přes kolekci tvarů normálního snímku. Přístup k rozložení získáte přes [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) a iterujte přes [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

Následující příklad mění výzvy názvu a podtitulu v rozložení použitém na prvním snímku:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Prompt text není běžný obsah snímku. Je určen pro prázdné zástupné prvky v editačních aplikacích, jako je PowerPoint. Jakmile uživatel nebo program dodá skutečný obsah, prompt již není zobrazen. Změna promptu také nenahrazuje existující text na snímcích, které používají rozložení.

## **Aktualizace obrázkového zástupného prvku**

Existují dva případy, které je třeba ošetřit:

- Pokud je obrázkový zástupný prvek již vyplněn a reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), nahraďte obrázek pomocí [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) a [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Pokud je stále prázdný zástupný prvek, přidejte obrázkový rámec na souřadnice zástupného prvku pomocí [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) a odstraňte prázdný zástupný prvek.

Následující příklad podporuje oba případy a ukládá prezentaci:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Nahrazení vytvořené pro prázdný zástupný prvek je místní obrázkový rámec, ne nový zástupný prvek, protože [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) je pouze ke čtení. Uchovává vyhrazenou pozici, ale již nezdědí chování specifické pro zástupný prvek. Pokud je zachování vztahu zástupného prvku podstatné, nejprve připravte a vyplňte zástupný prvek v PowerPointu a poté aktualizujte vzniklý [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, oříznutí a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/net/picture-frame/). Tyto operace patří k obrázkovému rámci nebo výplni obrázku, nikoli k metadatům zástupného prvku.

## **Práce s grafy a obsahovými zástupnými prvky**

Vyplněný grafový zástupný prvek může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Tento příklad najde takový graf podle typu zástupného prvku i rozhraní za běhu, změní jeho název a uloží soubor:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Obecný obsahový zástupný prvek obvykle má [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho vyplnění prozkoumejte skutečné rozhraní tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také exponovat [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), nebo [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Aspose.Slides nepřevádí prázdný [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) zástupný prvek na [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) pouhým změněním [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); typ je pouze ke čtení. Pro naplnění prázdné grafické nebo obsahové oblasti programově přidejte požadovaný objekt na souřadnice zástupného prvku a poté odstraňte prázdný zástupný prvek. Následující příklad to provádí pro graf:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Přidaný graf je běžný místní graf. Zabírá oblast zástupného prvku, ale nezdědí z rozložení zástupného prvku. Použijte věnované [chart management articles](/slides/cs/net/powerpoint-charts/), když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textu nebo obrázkového obsahu**

Následující end-to-end příklad otevře šablonu, prohledá první snímek buď pro název, nebo pro obrázkový zástupný prvek, zkontroluje typy zástupného prvku a tvaru, aktualizuje příslušný obsah a uloží výstup. Příklad úmyslně nevyužívá předpoklad o indexu tvaru nebo přetypování každého zástupného prvku na stejné rozhraní.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **Často kladené dotazy**

**Co je základní zástupný prvek?**

Základní zástupný prvek je odpovídající tvar v rozložení nebo hlavním snímku, ze kterého jiný zástupný prvek dědí. Použijte [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) k jeho získání. Běžný místní tvar vrací `null`, protože není součástí hierarchie zástupných prvků.

**Mohu změnit všechny názvy snímků úpravou zástupného prvku v rozložení?**

Můžete měnit děděné formátování nebo prompt text přes rozložení, ale existující obsah názvu je uložen na normálních snímcích. Pro nahrazení skutečného textu názvu v celé prezentaci iterujte přes snímky a aktualizujte každý názevový zástupný prvek.

**Jak spravovat zástupné prvky data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na příslušném rozsahu – snímek, rozložení, hlavní snímek, poznámky nebo výstřižky. Viz [Manage Presentation Header and Footer](/slides/cs/net/presentation-header-and-footer/) pro kompletní příklady.