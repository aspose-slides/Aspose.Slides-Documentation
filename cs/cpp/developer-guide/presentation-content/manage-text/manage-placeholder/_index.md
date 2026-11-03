---
title: Spravovat zástupné prvky prezentace v C++
linktitle: Spravovat zástupné prvky
type: docs
weight: 10
url: /cs/cpp/manage-placeholder/
keywords:
- zástupný prvek
- textový zástupný prvek
- obrázkový zástupný prvek
- grafový zástupný prvek
- obsahový zástupný prvek
- výzva textu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak prozkoumat a upravit textové, obrázkové, grafické a obsahové zástupné prvky a pochopit dědičnost zástupných prvků pomocí Aspose.Slides pro C++."
---
## **Přehled**

Zástupný prvek je tvar, který vyhrazuje pozici pro konkrétní typ obsahu v šabloně prezentace. Mezi běžné příklady patří zástupné prvky pro nadpis, tělo, obrázek, graf a obecný obsah. Na rozdíl od běžného tvaru může zástupný prvek dědit svou pozici, velikost, formátování a další nastavení z rozvržení snímku nebo hlavního snímku.

Aspose.Slides poskytuje informace o zástupných prvcích prostřednictvím metody [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/). Metoda vrací objekt [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) nebo `nullptr` pro běžný tvar. Použijte [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) k určení, co má zástupný prvek obsahovat.

Rozhraní tvaru i po zjištění typu zástupného prvku stále hraje roli:

- Prázdný textový, obrázkový, grafický nebo obsahový zástupný prvek je obvykle reprezentován pomocí [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
- Vyplněný obrázkový zástupný prvek může být reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/).
- Vyplněný grafický zástupný prvek může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/).
- Obsahový zástupný prvek může obsahovat několik typů obsahu. Zkontrolujte jak [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) tak rozhraní tvaru za běhu, místo předpokladu, že každý zástupný prvek je [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) popisuje roli zástupného prvku; nezaručuje typ tvaru za běhu. Vždy použijte kontrolu typu před přístupem k textovým, obrázkovým, grafickým, tabulkovým nebo mediálním členům.
{{% /alert %}}

## **Pochopení dědičnosti zástupných prvků**

Zástupné prvky tvoří hierarchii:

1. Hlavní snímek (master slide) definuje opakovaně použitelné styly a v některých případech také zástupné prvky na úrovni hlavního snímku.
2. Rozvržení snímku (layout slide) určuje uspořádání použité jedním nebo více běžnými snímky a může dědit z hlavního snímku.
3. Běžný snímek obsahuje zástupné prvky pro daný snímek a může dědit ze svého rozvržení.

Zavolejte [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/), abyste se posunuli o jednu úroveň výš v této hierarchii. Zástupný prvek snímku obvykle vrátí svůj zástupný prvek rozvržení; zástupný prvek rozvržení může vrátit svůj hlavní zástupný prvek. Metoda vrací `nullptr`, pokud tvar nemá základní zástupný prvek.

Následující příklad vypíše zástupné prvky na prvním snímku a uvádí jejich základní zástupné prvky:

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

Úprava zástupného prvku na běžném snímku vytvoří nebo změní lokální přepsání pro tento snímek. Úprava souvisejícího rozvržení nebo hlavního snímku může ovlivnit všechny snímky, které stále dědí toto nastavení. Lokální běžný tvar nemá základní zástupný prvek a nezačne dědit jen proto, že zaujímá stejné souřadnice.

## **Odstranění stavu zástupného prvku**

Při úpravě šablony použijte [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) aby byl existující objekt zachován jako běžný tvar. Jeho metoda [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) vrací `nullptr`, ale tvar zůstává v kolekci snímku. Naopak [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) odstraní tvar z této kolekce.

Následující příklad vyžaduje `template.pptx` s alespoň jedním snímkem a neprázdným textovým zástupným prvkem na prvním snímku. Použijte zástupný prvek s formátováním děděným z jeho rozvržení nebo hlavního snímku, abyste viděli vliv odebrání tohoto vztahu. Příklad kontroluje, že stejný tvar zůstává, zavolá metodu znovu na nyní běžný tvar a výsledek uloží.

{{% alert color="warning" title="Warning" %}}
Odstranění stavu zástupného prvku automaticky neuchovává děděná nastavení vzhledu. Níže uvedený příklad úmyslně ponechává tato nastavení nezměněna, takže výstup může vypadat odlišně. Tvar, jehož pozice a velikost jsou zcela zděděny, může po volání mít nulové souřadnice a rozměry a stát se neviditelným, i když zůstává v kolekci.
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // Volání metody na běžném tvaru nemá žádný efekt.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

Pro odpovídající zástupný prvek všechny tři kontroly vrátí `True`. Text zůstane, ale pozice, velikost, rotace, písmo, zarovnání odstavců, okraje textového rámečku, vertikální kotvení, výplň a nastavení čáry mohou být po odebrání vztahu zástupného prvku změněny. Například děděné formátování nadpisu se může vrátit k běžnému formátování textu. Viz [Rozvržení snímku](/slides/cs/cpp/slide-layout/) pro více informací o rozvrzích.

Aby byl zachován zamýšlený vzhled, zachyťte před voláním vypočtenou pozici, velikost a rotaci a zkopírujte požadované hodnoty efektivního formátování do samostatných proměnných. Získejte tyto hodnoty pomocí [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), a [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/). Nespoléhejte se jen na objekty efektivního formátu, protože jejich hodnoty formátování textu se po odebrání vztahu mohou změnit. Výslovně aplikujte zachycené hodnoty na běžný tvar po provedení, včetně rodiny písma, velikosti, stylu, barvy, nastavení odstavce, nastavení textového rámečku, výplně a čáry použité ve vaší šabloně.

Zděděná geometrie tvaru může také vyžadovat explicitní přiřazení pomocí [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/). Pro obdélníkový textový zástupný prvek to znamená přiřadit [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); obnovení pouze výplně a čáry nemusí obnovit viditelný obdélník. Šablony s dalšími efekty nebo složitějším formátováním také vyžadují, aby tato nastavení byla zpracována.

## **Změna textu ve zástupném prvku**

Zástupné prvky pro nadpis, centrovaný nadpis, podnadpis, tělo a text obvykle podporují text. Zkontrolujte [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), než použijete jeho metodu [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/).

Tento příklad aktualizuje první zástupný prvek nadpisu na prvním snímku a uloží výsledek:

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

Tento vzor se vyhýbá přetypování obrázkových, grafových, tabulkových nebo mediálních zástupných prvků na [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Také identifikuje zástupný prvek podle účelu místo spoléhaní se na křehký index tvaru.

## **Nastavení výzvy (prompt) textu v rozvržení**

Výzva (prompt) text je návrhový pokyn zobrazený v prázdném zástupném prvku, například *Klikněte pro přidání nadpisu*. Nastavte vlastní výzvu na zástupném prvku rozvržení místo pokusu o dosažení přes kolekci tvarů běžného snímku. Přístup k rozvržení získáte pomocí [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) a iterujte přes [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/).

Následující příklad mění výzvy nadpisu a podnadpisu v rozvržení použitém prvním snímkem:

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

Výzva není běžný obsah snímku. Je určena pro prázdné zástupné prvky v editačních aplikacích, jako je PowerPoint. Jakmile uživatel nebo program poskytne skutečný obsah, výzva se již nezobrazuje. Změna výzvy také nenahrazuje existující text na snímcích, které rozvržení používají.

## **Aktualizace obrázkového zástupného prvku**

Je třeba řešit dva případy:

- Pokud je obrázkový zástupný prvek již vyplněn a je reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), nahraďte obrázek pomocí [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) a [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/).
- Pokud je stále prázdný zástupný prvek, přidejte obrázkový rám na souřadnice zástupného prvku pomocí [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) a odstraňte prázdný zástupný prvek.

Následující příklad podporuje oba případy a uloží prezentaci:

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

Náhrada vytvořená pro prázdný zástupný prvek je lokální obrázkový rám, nikoli nový zástupný prvek, protože [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) je pouze pro čtení. Uchovává vyhrazenou pozici, ale již nepřebírá chování specifické pro zástupný prvek. Pokud je zachování vztahu zástupného prvku podstatné, připravte a vyplňte zástupný prvek v PowerPointu nejprve, pak aktualizujte vzniklý [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, ořezávání a další efekty specifické pro obrázek viz [Spravovat obrázkové rámy](/slides/cs/cpp/picture-frame/). Tyto operace patří k obrázkovému rámu nebo výplni obrázku, nikoli k metadatům zástupného prvku.

## **Práce s grafovými a obsahovými zástupnými prvky**

Vyplněný grafový zástupný prvek může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/). Tento příklad vyhledá takový graf jak podle typu zástupného prvku, tak rozhraní za běhu, změní jeho nadpis a uloží soubor:

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

Obecný obsahový zástupný prvek obvykle má [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč několika typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho vyplnění zkoumejte skutečné rozhraní tvaru, abyste zjistili, co obsahuje. Specializovaná rozvržení mohou také odhalit [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) nebo [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/).

Aspose.Slides nepřevádí prázdný [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) zástupný prvek na [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) pouhým změněním [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/); typ je jen pro čtení. Pro programové vyplnění prázdné oblasti grafu nebo obsahu přidejte požadovaný objekt na souřadnice zástupného prvku a poté odstraňte prázdný zástupný prvek. Následující příklad to provádí pro graf:

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

Přidaný graf je běžný lokální graf. Zaujímá oblast zástupného prvku, ale nezdědí vlastnosti z rozvržení zástupného prvku. Použijte věnované [články o správě grafů](/slides/cs/cpp/powerpoint-charts/) když potřebujete nahradit jeho kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textového nebo obrázkového obsahu**

Následující kompletní příklad otevře šablonu, vyhledá na prvním snímku buď zástupný prvek nadpisu nebo obrázku, zkontroluje typy zástupného prvku a tvaru, aktualizuje příslušný obsah a výsledek uloží. Příklad úmyslně nevyužívá předpoklad o indexu tvaru ani nepřetypovává každý zástupný prvek na stejné rozhraní.

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

## **FAQ**

**Co je základní zástupný prvek?**

Základní zástupný prvek je odpovídající tvar v rozvržení nebo hlavním snímku, ze kterého další zástupný prvek dědí. Použijte [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/), abyste jej získali. Běžný lokální tvar vrací `nullptr`, protože není součástí hierarchie zástupných prvků.

**Mohu změnit všechny nadpisy snímků úpravou zástupného prvku v rozvržení?**

Můžete změnit děděné formátování nebo výzvu pomocí rozvržení, ale existující obsah nadpisu je uložen na běžných snímcích. Pro nahrazení skutečného textu nadpisů v celé prezentaci iterujte po snímcích a aktualizujte každý zástupný prvek nadpisu.

**Jak spravovat zástupné prvky data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na příslušném rozsahu – snímek, rozvržení, hlavní snímek, poznámky nebo výstřižky. Viz [Správa záhlaví a zápatí prezentace](/slides/cs/cpp/presentation-header-and-footer/) pro kompletní příklady.