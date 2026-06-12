---
title: Pokročilá extrakce textu z prezentací v C++
linktitle: Extrahovat text
type: docs
weight: 90
url: /cs/cpp/extract-text-from-presentation/
keywords:
- extrahovat text
- extrahovat text ze snímku
- extrahovat text z prezentace
- extrahovat text z PowerPointu
- extrahovat text z OpenDocument
- extrahovat text z PPT
- extrahovat text z PPTX
- extrahovat text z ODP
- získat text
- získat text ze snímku
- získat text z prezentace
- získat text z PowerPointu
- získat text z OpenDocument
- získat text z PPT
- získat text z PPTX
- získat text z ODP
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Rychle extrahujte text z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Postupujte podle našeho jednoduchého, krok za krokem průvodce a ušetřete čas."
---
## **Přehled**

Extrahování textu z prezentací je běžný, ale zásadní úkol pro vývojáře pracující s obsahem snímků. Ať už pracujete se soubory Microsoft PowerPoint ve formátu PPT nebo PPTX, nebo s prezentacemi OpenDocument (ODP), přístup a získávání textových dat může být klíčové pro analýzu, automatizaci, indexaci či migraci obsahu.

Tento článek poskytuje komplexní návod, jak efektivně extrahovat text z různých formátů prezentací, včetně PPT, PPTX a ODP, pomocí Aspose.Slides pro C++. Naučíte se, jak systematicky procházet prvky prezentace a přesně získat potřebný textový obsah.

## **Extrahování textu ze snímku**

Aspose.Slides pro C++ poskytuje jmenný prostor [Aspose.Slides.Util](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/), který obsahuje třídu [SlideUtil](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/). Tato třída nabízí několik přetížených statických metod pro extrahování veškerého textu z prezentace nebo snímku. Pro extrahování textu ze snímku v prezentaci použijte metodu [GetAllTextBoxes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/getalltextboxes/). Tato metoda přijímá objekt typu [IBaseSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/) jako parametr. Po spuštění metoda prohledá celý snímek a vrátí pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/), zachovávajících veškeré formátování textu.

Následující úryvek kódu extrahuje veškerý text z prvního snímku prezentace:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Extrahování textu z prezentace**

Pro prohledání textu v celé prezentaci použijte statickou metodu [GetAllTextFrames](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/getalltextframes/), kterou poskytuje třída [SlideUtil](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/). Přijímá dva parametry:

1. První je objekt [IPresentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/), který představuje prezentaci PowerPoint nebo OpenDocument, ze které bude text extrahován.
1. Druhý je hodnota typu `Boolean`, která udává, zda mají být při prohledávání textu zahrnuty hlavní snímky (master slides).

Metoda vrací pole objektů typu [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/), včetně informací o formátování textu. Níže uvedený kód prohledá text a podrobnosti o formátování v prezentaci, včetně hlavních snímků.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Kategorizovaná a rychlá extrakce textu**

Třída [PresentationFactory](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentationfactory/) také poskytuje metody pro extrahování veškerého textu z prezentací:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Argument výčtového typu [TextExtractionArrangingMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textextractionarrangingmode/) určuje režim uspořádání výsledku extrakce textu a může být nastaven na následující hodnoty:
- `Unarranged` - Surový text bez ohledu na jeho pozici na snímku.
- `Arranged` - Text je uspořádán ve stejném pořadí jako na snímku.

Neuspořádaný režim lze použít, když je rychlost kritická; je rychlejší než uspořádaný režim.

[IPresentationText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationtext/) představuje surový text extrahovaný z prezentace. Jeho metoda `get_SlidesText()` vrací pole objektů typu [ISlideText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidetext/). Každý objekt představuje text na odpovídajícím snímku. Objekt typu [ISlideText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidetext/) má následující metody:

- `get_Text()` – Text uvnitř tvarů snímku.
- `get_MasterText()` – Text uvnitř tvarů hlavního snímku (master slide) spojeného s tímto snímkem.
- `get_LayoutText()` – Text uvnitř tvarů rozložení snímku (layout slide) spojeného s tímto snímkem.
- `get_NotesText()` – Text uvnitř tvarů poznámkového snímku (notes slide) spojeného s tímto snímkem.
- `get_CommentsText()` – Text v poznámkách spojených s tímto snímkem.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **Často kladené otázky**

**Jak rychle Aspose.Slides zpracovává velké prezentace při extrakci textu?**

Aspose.Slides je optimalizováno pro vysoký výkon a dokáže zpracovat i [large presentations](/slides/cs/cpp/open-presentation/), což jej činí vhodným pro scénáře zpracování v reálném čase nebo hromadně.

**Umí Aspose.Slides extrahovat text z tabulek a grafů v prezentacích?**

Ano. Aspose.Slides dokáže extrahovat text z mnoha prvků snímků, včetně tabulek a objektů souvisejících s grafy, takže můžete přistupovat k textovému obsahu a analyzovat jej v běžných strukturách prezentací.

**Potřebuji speciální licenci Aspose.Slides pro extrakci textu z prezentací?**

Můžete extrahovat text pomocí bezplatné zkušební verze Aspose.Slides, i když má [certain limitations](/slides/cs/cpp/licensing/), například zpracování pouze omezeného počtu snímků. Pro neomezené použití a zpracování větších prezentací se doporučuje zakoupit plnou licenci.