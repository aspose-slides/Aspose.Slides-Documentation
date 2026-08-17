---
title: Spravovat zástupce prezentace v C++
linktitle: Spravovat zástupce
type: docs
weight: 10
url: /cs/cpp/manage-placeholder/
keywords:
- zástupce
- textový zástupce
- obrázkový zástupce
- grafový zástupce
- obsahový zástupce
- výzva text
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak prohlížet a upravovat textové, obrázkové, grafové a obsahové zástupce a pochopit dědičnost zástupců pomocí Aspose.Slides pro C++."
---
## **Přehled**

Zástupce je tvar, který vyhrazuje pozici pro konkrétní typ obsahu v šabloně prezentace. Běžnými příklady jsou zástupci názvu, těla, obrázku, grafu a univerzální zástupci obsahu. Na rozdíl od obyčejného tvaru může zástupce zdědit svou pozici, velikost, formátování a další nastavení z rozložení snímku nebo hlavního snímku.

Aspose.Slides zpřístupňuje informace o zástupcích prostřednictvím metody [IShape::get_Placeholder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_placeholder/). Metoda vrací objekt [IPlaceholder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iplaceholder/) nebo `nullptr` pro běžný tvar. K určení, co je zástupce určen k obsahu, použijte [IPlaceholder::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iplaceholder/get_type/).

Rozhraní tvaru je stále důležité poté, co znáte typ zástupce:

- Prázdný textový, obrázkový, grafový nebo obsahový zástupce je obvykle reprezentován jako [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
- Vyplněný obrázkový zástupce může být reprezentován jako [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/).
- Vyplněný grafový zástupce může být reprezentován jako [IChart](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/).
- Obsahový zástupce může obsahovat několik typů obsahu. Zkontrolujte jak [IPlaceholder::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iplaceholder/get_type/), tak rozhraní tvaru v běhu, namísto předpokladu, že každý zástupce je [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iplaceholder/get_type/) popisuje roli zástupce; nezaručuje runtime typ tvaru. Vždy proveďte kontrolu typu před přístupem k textovým, obrázkovým, grafovým, tabulkovým nebo mediálním členům.
{{% /alert %}}

## **Pochopení dědičnosti zástupců**

Zástupci tvoří hierarchii:

1. Hlavní snímek definuje znovupoužitelné styly a v některých případech zástupce na úrovni hlavního snímku.
2. Rozložení snímku určuje uspořádání použité jedním nebo více běžnými snímky a může dědit z hlavního snímku.
3. Běžný snímek obsahuje zástupce pro daný snímek a může dědit z jeho rozložení.

Voláním [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/getbaseplaceholder/) se posunete o jednu úroveň výše v této hierarchii. Zástupce snímku obvykle vrací svůj zástupce rozložení; zástupce rozložení může vrátit svůj hlavní zástupce. Metoda vrací `nullptr`, když tvar nemá základní zástupce.

Níže uvedený příklad vypisuje zástupce na prvním snímku a uvádí jejich základní zástupce:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Úprava zástupce na běžném snímku vytvoří nebo změní lokální přepis pro tento snímek. Úprava souvisejícího rozložení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Běžný lokální tvar nemá základní zástupce a nezačíná dědit jen proto, že zabírá stejné souřadnice.

## **Změna textu v zástupci**

Zástupci názvu, centrovaného názvu, podtitulku, těla a textu obvykle podporují text. Před použitím metody [get_TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/get_textframe/) zkontrolujte, zda jde o [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).

Tento příklad aktualizuje první zástupce názvu na prvním snímku a uloží výsledek:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Tento vzor se vyhýbá přetypování obrázkových, grafových, tabulkových nebo mediálních zástupců na [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/). Také identifikuje zástupce podle účelu namísto spoléhaní se na křehký index tvaru.

## **Nastavení výzvy (prompt) v rozložení**

Text výzvy je návrhový pokyn zobrazovaný v prázdném zástupci, například *Klikněte pro přidání názvu*. Nastavte vlastní text výzvy na zástupci rozložení místo pokusu o dosažení přes kolekci tvarů běžného snímku. Přistupte k rozložení pomocí [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/get_layoutslide/) a iterujte přes [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/get_shapes/).

Následující příklad mění výzvy názvu a podtitulku v rozložení použitém prvním snímkem:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Text výzvy není běžný obsah snímku. Je určen pro prázdné zástupce v editovacích aplikacích, jako je PowerPoint. Jakmile uživatel nebo program poskytne skutečný obsah, výzva se již nezobrazuje. Změna výzvy také nenahrazuje existující text na snímcích, které rozložení používají.

## **Aktualizace obrázkového zástupce**

Existují dva případy k ošetření:

- Pokud je obrázkový zástupce již vyplněn a reprezentován jako [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/), nahraďte obrázek pomocí [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipicturefillformat/get_picture/) a [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidespicture/set_image/).
- Pokud je stále prázdný zástupce, přidejte obrázkový rámec na souřadnice zástupce pomocí [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addpictureframe/) a odstraňte prázdný zástupce.

Další příklad podporuje oba případy a ukládá prezentaci:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

Náhrada vytvořená pro prázdný zástupce je lokální obrázkový rámec, nikoli nový zástupce, protože [IShape::get_Placeholder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_placeholder/) je jen pro čtení. Uchovává vyhrazenou pozici, ale již nedědí chování specifické pro zástupce. Pokud je zachování vztahu k zástupci podstatné, připravte a vyplňte zástupce v PowerPointu nejprve, pak aktualizujte výsledný [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrazu, oříznutí a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/cpp/picture-frame/). Tyto operace patří k obrázkovému rámci nebo výplni obrázku, ne k metadatům zástupce.

## **Práce s grafovými a obsahovými zástupci**

Vyplněný grafový zástupce může být reprezentován jako [IChart](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/). Tento příklad najde takový graf podle typu zástupce i runtime rozhraní, změní jeho název a uloží soubor:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Obecný obsahový zástupce má obvykle [PlaceholderType::Object](https://reference.aspose.com/slides/cs/cpp/aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho vyplnění prozkoumejte skutečné rozhraní tvaru, abyste zjistili, co obsahuje. Specializovaná rozložení mohou také vystavovat [PlaceholderType::Chart](https://reference.aspose.com/slides/cs/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cs/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cs/cpp/aspose.slides/placeholdertype/), nebo [PlaceholderType::Diagram](https://reference.aspose.com/slides/cs/cpp/aspose.slides/placeholdertype/).

Aspose.Slides nepřemění prázdný [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) zástupce na [IChart](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/) pouhým změněním [IPlaceholder::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iplaceholder/get_type/); typ je jen pro čtení. Pro naplnění prázdného grafu nebo oblasti obsahu programově přidejte požadovaný objekt na souřadnice zástupce a pak odstraňte prázdný zástupce. Následující příklad to provádí pro graf:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

Přidaný graf je obyčejný lokální graf. Zabírá oblast zástupce, ale nedědí z rozložení zástupce. Použijte specializované články o správě grafů [chart management articles](/slides/cs/cpp/powerpoint-charts/), když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textového nebo obrazového obsahu**

Níže uvedený end-to-end příklad otevírá šablonu, hledá na prvním snímku buď název nebo obrázkový zástupce, kontroluje typy zástupce i tvaru, aktualizuje příslušný obsah a uloží výstup. Příklad úmyslně nevyužívá předpoklad indexu tvaru ani přetypování každého zástupce na stejné rozhraní.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Co je základní (base) zástupce?**

Základní zástupce je odpovídající tvar v rozložení nebo hlavním snímku, ze kterého další zástupce dědí. Použijte [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/getbaseplaceholder/) k jeho získání. Běžný lokální tvar vrací `nullptr`, protože není součástí hierarchie zástupců.

**Mohu změnit všechny názvy snímků úpravou zástupce v rozložení?**

Můžete změnit děděné formátování nebo text výzvy prostřednictvím rozložení, ale existující text názvu je uložen na běžných snímcích. Pro nahrazení skutečného textu názvu napříč prezentací iterujte přes snímky a aktualizujte každý název‑zástupce.

**Jak spravovat zástupce data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na úrovni specifického snímku, rozložení, hlavního snímku, poznámek nebo podkladů. Viz [Manage Presentation Header and Footer](/slides/cs/cpp/presentation-header-and-footer/) pro kompletní příklady.