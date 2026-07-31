---
title: "Pokročilá extrakce textu z prezentací v .NET"
linktitle: "Extrahovat text"
type: docs
weight: 90
url: /cs/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/cs/
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
  - presentation
  - .NET
  - C#
  - Aspose.Slides
description: "Rychle extrahujte text z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Postupujte podle našeho jednoduchého, krok za krokem průvodce a ušetřete čas."
---
## **Přehled**

Extrahování textu z prezentací je běžný, ale přesto zásadní úkol pro vývojáře pracující s obsahem snímků. Ať už pracujete se soubory Microsoft PowerPoint ve formátu PPT nebo PPTX, nebo s OpenDocument prezentacemi (ODP), přístup k textovým datům a jejich získávání může být klíčové pro analýzu, automatizaci, indexování nebo migraci obsahu.

Tento článek poskytuje komplexní průvodce, jak efektivně extrahovat text z různých formátů prezentací, včetně PPT, PPTX a ODP, pomocí Aspose.Slides pro .NET. Naučíte se, jak systematicky procházet prvky prezentace a přesně získat požadovaný textový obsah.

## **Extrahovat text ze snímku**

Aspose.Slides pro .NET poskytuje obor názvů [Aspose.Slides.Util](https://reference.aspose.com/slides/cs/net/aspose.slides.util/), který obsahuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/). Tato třída nabízí několik přetížených statických metod pro extrahování celého textu z prezentace nebo snímku. Pro extrahování textu ze snímku v prezentaci použijte metodu [GetAllTextBoxes](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/getalltextboxes/). Tato metoda přijímá jako parametr objekt typu [IBaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/). Po provedení metoda prohledá celý snímek a vrátí pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/), zachovávající veškeré formátování textu.

Následující úryvek kódu extrahuje celý text z prvního snímku prezentace:

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

## **Extrahovat text z prezentace**

Pro prohledání textu v celé prezentaci použijte statickou metodu [GetAllTextFrames](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/getalltextframes/), kterou poskytuje třída [SlideUtil](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/). Metoda přijímá dva parametry:

1. Nejprve objekt typu [IPresentation](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/), který představuje PowerPoint nebo OpenDocument prezentaci, ze které bude text extrahován.
1. Dále hodnota typu `Boolean`, která určuje, zda mají být při prohledávání textu zahrnuty i hlavní snímky.

Metoda vrací pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/), včetně informací o formátování textu. Níže uvedený kód prohledá text a podrobnosti o formátování v prezentaci, včetně hlavních snímků.

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

## **Kategorizovaná a rychlá extrakce textu**

Třída [PresentationFactory](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/) také poskytuje metody pro extrahování celého textu z prezentací:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Argument výčtu [TextExtractionArrangingMode](https://reference.aspose.com/slides/cs/net/aspose.slides/textextractionarrangingmode/) určuje režim organizace výsledku extrakce textu a může být nastaven na následující hodnoty:
- `Unarranged` – Surový text bez ohledu na jeho umístění na snímku.
- `Arranged` – Text je uspořádán ve stejném pořadí jako na snímku.

Režim Unarranged lze použít, když je rychlost kritická; je rychlejší než režim Arranged.

[IPresentationText](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationtext/) představuje surový text extrahovaný z prezentace. Jeho vlastnost `SlidesText` vrací pole objektů typu [ISlideText](https://reference.aspose.com/slides/cs/net/aspose.slides/islidetext/). Každý objekt představuje text na odpovídajícím snímku. Objekt typu [ISlideText](https://reference.aspose.com/slides/cs/net/aspose.slides/islidetext/) má následující vlastnosti:

- `Text` – Text uvnitř tvarů snímku.
- `MasterText` – Text uvnitř tvarů hlavního snímku (master slide) přiřazeného k tomuto snímku.
- `LayoutText` – Text uvnitř tvarů rozložení snímku (layout slide) přiřazeného k tomuto snímku.
- `NotesText` – Text uvnitř tvarů poznámkového snímku (notes slide) přiřazeného k tomuto snímku.
- `CommentsText` – Text v komentářích přiřazených k tomuto snímku.

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

## **Často kladené otázky**

**Jak rychle Aspose.Slides zpracovává velké prezentace při extrakci textu?**

Aspose.Slides je optimalizováno pro vysoký výkon a dokáže zpracovat i [velké prezentace](/slides/cs/net/open-presentation/), což jej činí vhodným pro scénáře v reálném čase nebo hromadného zpracování.

**Může Aspose.Slides extrahovat text z tabulek a grafů v prezentacích?**

Ano. Aspose.Slides dokáže extrahovat text z mnoha prvků snímků, včetně tabulek a objektů souvisejících s grafy, takže můžete přistupovat k textovému obsahu a analyzovat jej v běžných strukturách prezentací.

**Potřebuji speciální licenci Aspose.Slides pro extrakci textu z prezentací?**

Text můžete extrahovat pomocí bezplatné zkušební verze Aspose.Slides, i když má [některá omezení](/slides/cs/net/licensing/), například zpracování pouze omezeného počtu snímků. Pro neomezené použití a práci s většími prezentacemi se doporučuje zakoupit plnou licenci.