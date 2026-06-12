---
title: Pokročilé extrahování textu z prezentací v .NET
linktitle: Extrahovat text
type: docs
weight: 90
url: /cs/net/extract-text-from-presentation/
keywords:
- extrahovat text
- extrahovat text ze snímku
- extrahovat text z prezentace
- extrahovat text z PowerPointu
- extrahovat text z OpenDocumentu
- extrahovat text z PPT
- extrahovat text z PPTX
- extrahovat text z ODP
- získat text
- získat text ze snímku
- získat text z prezentace
- získat text z PowerPointu
- získat text z OpenDocumentu
- získat text z PPT
- získat text z PPTX
- získat text z ODP
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Rychle extrahujte text z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Následujte náš jednoduchý, krok za krokem průvodce a ušetřete čas."
---
## **Přehled**

Extrahování textu z prezentací je běžný, ale zároveň zásadní úkol pro vývojáře pracující se obsahem snímků. Ať už pracujete se soubory Microsoft PowerPoint ve formátu PPT nebo PPTX, nebo s OpenDocument prezentacemi (ODP), přístup k textovým datům a jejich získávání může být klíčové pro analýzu, automatizaci, indexaci či migraci obsahu.

Tento článek poskytuje komplexní průvodce, jak efektivně extrahovat text z různých formátů prezentací, včetně PPT, PPTX a ODP, pomocí Aspose.Slides for .NET. Naučíte se, jak systematicky procházet prvky prezentace, abyste přesně získali požadovaný textový obsah.

## **Extrahování textu ze snímku**

Aspose.Slides for .NET poskytuje prostor názvů [Aspose.Slides.Util](https://reference.aspose.com/slides/cs/net/aspose.slides.util/), který obsahuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/). Tato třída exponuje několik přetížených statických metod pro extrahování veškerého textu z prezentace nebo snímku. Pro extrahování textu ze snímku v prezentaci použijte metodu [GetAllTextBoxes](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/getalltextboxes/). Tato metoda přijímá objekt typu [IBaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/) jako parametr. Při provedení metoda prohledá celý snímek a vrátí pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/), přičemž zachová veškeré formátování textu.

Následující úryvek kódu extrahuje veškerý text z prvního snímku prezentace:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Extrahování textu z prezentace**

Pro skenování textu z celé prezentace použijte statickou metodu [GetAllTextFrames](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/getalltextframes/) vystavenou třídou [SlideUtil](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/). Přijímá dva parametry:

1. Nejprve objekt [IPresentation](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/) představující PowerPoint nebo OpenDocument prezentaci, ze které bude text extrahován.
1. Zadruhé hodnota typu `Boolean`, která určuje, zda mají být zahrnuty master snímky při skenování textu z prezentace.

Metoda vrací pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/), včetně informací o formátování textu. Níže uvedený kód skenuje text a podrobnosti o formátování z prezentace, včetně master snímků.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Kategorizované a rychlé extrahování textu**

Třída [PresentationFactory](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/) také poskytuje metody pro extrahování veškerého textu z prezentací:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Argument výčtu [TextExtractionArrangingMode](https://reference.aspose.com/slides/cs/net/aspose.slides/textextractionarrangingmode/) určuje režim uspořádání výsledku extrakce textu a může být nastaven na následující hodnoty:
- `Unarranged` - Neupravený text bez ohledu na jeho umístění na snímku.
- `Arranged` - Text je uspořádán ve stejném pořadí jako na snímku.

Neuspořádaný režim lze použít, když je rychlost kritická; je rychlejší než uspořádaný režim.

[IPresentationText](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationtext/) představuje neupravený text extrahovaný z prezentace. Jeho vlastnost `SlidesText` vrací pole objektů typu [ISlideText](https://reference.aspose.com/slides/cs/net/aspose.slides/islidetext/). Každý objekt představuje text na odpovídajícím snímku. Objekt typu [ISlideText](https://reference.aspose.com/slides/cs/net/aspose.slides/islidetext/) má následující vlastnosti:

- `Text` - Text uvnitř tvarů snímku.
- `MasterText` - Text uvnitř tvarů master snímku, který je k tomuto snímku přiřazen.
- `LayoutText` - Text uvnitř tvarů layout snímku, který je k tomuto snímku přiřazen.
- `NotesText` - Text uvnitř tvarů poznámkového snímku, který je k tomuto snímku přiřazen.
- `CommentsText` - Text uvnitř komentářů přiřazených k tomuto snímku.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **Často kladené dotazy**

**Jak rychle Aspose.Slides zpracovává velké prezentace při extrahování textu?**

Aspose.Slides je optimalizováno pro vysoký výkon a dokáže zpracovat i [velké prezentace](/slides/cs/net/open-presentation/), což ho činí vhodným pro scénáře v reálném čase nebo hromadného zpracování.

**Může Aspose.Slides extrahovat text z tabulek a grafů v prezentacích?**

Ano. Aspose.Slides dokáže extrahovat text z mnoha prvků snímků, včetně tabulek a objektů souvisejících s grafy, takže můžete přistupovat k textovému obsahu a analyzovat jej v běžných strukturách prezentací.

**Potřebuji speciální licenci Aspose.Slides pro extrahování textu z prezentací?**

Text můžete extrahovat pomocí bezplatné zkušební verze Aspose.Slides, i když bude mít [určité omezení](/slides/cs/net/licensing/), například zpracování pouze omezeného počtu snímků. Pro neomezené používání a práci s většími prezentacemi se doporučuje zakoupit plnou licenci.