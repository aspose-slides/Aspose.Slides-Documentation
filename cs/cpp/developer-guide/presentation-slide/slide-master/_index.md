---
title: Spravovat master snímky v prezentaci v C++
linktitle: Master snímku
type: docs
weight: 80
url: /cs/cpp/slide-master/
keywords:
- master snímku
- master snímek
- PPT master snímek
- více master snímků
- porovnat master snímky
- pozadí
- zástupný objekt
- klonovat master snímek
- kopírovat master snímek
- duplikovat master snímek
- nepoužívaný master snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Spravovat master snímky v Aspose.Slides pro C++: přístup, úpravy, klonování, porovnání a odstraňování master snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Slide master definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž by se opakovalo stejné formátování na každém snímku.

Aspose.Slides pro C++ podporuje stejný model. Prezentace může obsahovat jeden nebo více master slidů a každý master slide může obsahovat několik layout slidů. Normální snímky obvykle neodkazují přímo na master slide. Místo toho normální snímek používá layout slide, který patří k master slide.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.  
1. **Layout slide** – definuje konkrétní uspořádání zástupných objektů a formátování na úrovni rozvržení.  
1. **Normal slide** – obsahuje skutečný obsah prezentace a používá jeden layout slide.

![Hierarchie master slidů, layout slidů a normálních slidů](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován rozhraním [IMasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/) . Všechny master slidů v prezentaci jsou dostupné prostřednictvím kolekce [Presentation::get_Masters](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_masters/) , která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vítězí konkrétnější úroveň. Například pokud master slide i layout slide definují pozadí, snímky založené na tomto rozvržení použijí pozadí rozvržení. Další informace o layout slidech naleznete v [Apply or Change Slide Layouts](/slides/cs/cpp/slide-layout/).
{{% /alert %}}

## **Přístup k Slide Masters**

V PowerPointu můžete otevřít zobrazení Slide Masteru přes **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `get_Masters()` pro přístup k master slidem:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Můžete také získat master slide použité normálním snímkem přes jeho rozvržení:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Co Slide Master obsahuje**

Master slide je objekt podobný snímku. Implementuje [IBaseSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/), takže vystavuje mnoho stejných vlastností snímku používaných normálními a layout snímky. Specifické členy masteru jsou uvedeny na stránce API [IMasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/) .

Často používané členy master slide zahrnují:

| Člen | Účel |
| --- | --- |
| `get_Background()` | Nastavuje pozadí slidu na úrovni masteru. |
| `get_Shapes()` | Ukládá tvary umístěné na master, jako jsou loga, rámečky obrázků a sdílený text. |
| `get_LayoutSlides()` | Ukládá layout slidů patřících k masteru. |
| `get_ThemeManager()` | Poskytuje přístup k API motivu masteru. |
| `get_HeaderFooterManager()` | Řídí záhlaví, zápatí, data a čísla snímků pro master a jeho podřízená rozvržení. |
| `GetDependingSlides()` | Vrací normální snímky, které závisí na masteru přes jejich rozvržení. |

## **Přidání obrázku do Slide Masteru**

Když přidáte obrázek do master slide, objeví se na snímcích, které používají rozvržení z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pásy a další opakující se vizuální elementy.

Následující příklad přidá logo na první master slide:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Další informace o rámečcích obrázků najdete v [Picture Frame](/slides/cs/cpp/picture-frame/).

## **Řízení viditelnosti grafik masteru**

Použijte [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/set_showmastershapes/) , aby se skryly zděděné grafiky masteru, jako jsou loga nebo dekorativní tvary, aniž by byly smazány z masteru. Předávejte `false` metodě [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/set_showmastershapes/) na snímku, který by měl tyto grafiky vynechat, a `true` na snímcích, které je mají zobrazit.

Následující samostatný příklad vytvoří modrý dekorativní pás na masteru a dvou snímcích, které používají stejné prázdné rozvržení. Pás je viditelný na prvním snímku a skrytý na druhém. Není vyžadována žádná vstupní prezentace ani obrázek.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Příklad používá rozvržení **Blank** dodané s novou prezentací a odstraňuje vlastní zástupné objekty počátečního snímku.

### **Zvolte rozsah nastavení**

Normální snímek používá svého mastera přes [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/get_layoutslide/) a [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_masterslide/). Nastavení vlastnosti na jednotlivém snímku ovlivní jen tento snímek. Předání `false` metodě [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/layoutslide/set_showmastershapes/) skryje grafiky masteru pro snímky, které používají toto sdílené rozvržení, i když jejich vlastní nastavení je `true`. Pro skrytí grafik jen na jednom snímku změňte vlastnost snímku a nechte sdílené rozvržení beze změny.

Nastavení není podporováno jako řízení viditelnosti přímo na master slide. Na masteru vždy vrací `false` a při přiřazení `true` vyvolá `System::NotSupportedException`. Použijte jej na normální snímek nebo rozvržení.

### **Rozlišování grafik od pozadí**

| Operace | Efekt |
| --- | --- |
| Hide master graphics | Skrývá zděděné tvary masteru bez jejich mazání nebo změny tvarů snímku. |
| Change the slide background fill | Mění výplň pozadí snímku – barvu, gradient nebo obrázek. Grafiky masteru jsou oddělené tvary a mohou zůstat viditelné nad tímto pozadím. Viz [Presentation Background](/slides/cs/cpp/presentation-background/). |
| Delete a shape from the master | Odstraní sdílený zdrojový tvar, takže není nadále dostupný žádnému snímku používajícímu tento master. |

## **Práce se zástupnými objekty**

Zástupné objekty jsou obvykle definovány na layout slidech. Master slide poskytuje sdílený styl a motiv, které tyto rozvržení dědí, zatímco každé rozvržení rozhoduje, které zástupné objekty jsou k dispozici a kde jsou umístěny.

V PowerPointu jsou příkazy pro zástupné objekty dostupné v zobrazení Slide Master.

![Příkaz Insert Placeholder v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Pro přidání nových zástupných objektů pomocí Aspose.Slides pracujte s layout slide, který patří k masteru:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Můžete také formátovat tvary zástupných objektů, které již na master slide existují. Následující příklad najde zástupný objekt title a použije lineární gradientní výplň:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Formátovaný zástupný objekt title zděděný normálními snímky](slide-master_8.png)

Další možnosti nastavení zástupných objektů a formátování textu najdete v [Set Prompt Text in Placeholder](/slides/cs/cpp/manage-placeholder/) a [Text Formatting](/slides/cs/cpp/text-formatting/).

## **Změna pozadí Slide Masteru**

Pozadí masteru je děděno rozvrženími a snímky, které jej nepřepisují. Následující příklad nastaví pevnou barvu pozadí pro první master slide:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

S souvisejícími tématy se podívejte na [Presentation Background](/slides/cs/cpp/presentation-background/) a [Presentation Theme](/slides/cs/cpp/presentation-theme/).

## **Klonování Slide Masteru do jiné prezentace**

Použijte [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/addclone/) , aby se master slide zkopíroval do jiné prezentace. Zkopírovaný master pak může být použit rozvrženími a snímky v cílové prezentaci.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Pokud potřebujete klonovat normální snímky spolu s jejich masterem, viz [Clone Slides](/slides/cs/cpp/clone-slides/).

## **Přidání více Slide Masterů**

Prezentace může obsahovat více master slidů. To je užitečné, když různé sekce vyžadují odlišnou značku, strukturu stránky nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu master slidů](slide-master_9.jpg)

Následující příklad klonuje výchozí master, přiřadí klonu jiné pozadí, vytvoří rozvržení pod tímto klonovaným masterem a přidá nový snímek založený na tomto rozvržení:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Porovnání Slide Masterů**

Master slidů lze porovnat metodou `Equals` zděděnou z [IBaseSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupných objektů, jako je aktuální datum.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Další informace naleznete v [Compare Presentation Slides](/slides/cs/cpp/compare-slides/).

## **Nastavení Slide Master View jako výchozího zobrazení**

Použijte metodu `set_LastView` na [ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/) , abyste řídili, které zobrazení PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Další nastavení zobrazení najdete v [Save Presentation](/slides/cs/cpp/save-presentation/).

## **Odstranění nepoužívaných Master slidů**

Prezentace někdy obsahují master slidů, které již nejsou použity žádnými normálními snímky. Odstranění nepoužívaných masterů může snížit velikost souboru a zjednodušit údržbu šablony.

Použijte [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/cs/cpp/aspose.slides/masterslidecollection/removeunused/) , aby se odstranily nepoužívané mastery z kolekce `get_Masters()` :

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Můžete také použít low-code metodu [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Jaký je rozdíl mezi slide master a layout slide?**

Slide master definuje sdílená nastavení designu, jako je motiv, pozadí, společné tvary a styly textu. Layout slide patří k slide masteru a definuje konkrétní uspořádání zástupných objektů. Normální snímek používá layout slide, takže dědí jak z rozvržení, tak z masteru.

**Může jedna prezentace obsahovat několik slide masterů?**

Ano. Prezentace může obsahovat několik slide masterů. Používejte více masterů, když různé sekce vyžadují odlišné vizuální systémy nebo značku.

**Mám přidávat zástupné objekty na master slide nebo na layout slide?**

Ve většině případů přidávejte zástupné objekty do layout slidů. Sdílené vizuální prvky a formátování umístěte na master slide a obsahové zástupné objekty na rozvržení, které budou používat normální snímky.

**Mohu smazat master slide, který je ještě používán?**

Ne. Master slide, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky na rozvržení pod jiný master nebo použijte metodu úklidu nepoužívaných masterů, která odstraňuje pouze mastery, které nejsou používány.