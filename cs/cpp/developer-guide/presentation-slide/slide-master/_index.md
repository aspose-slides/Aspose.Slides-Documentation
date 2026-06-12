---
title: Správa slide masterů v C++
linktitle: Slide master
type: docs
weight: 80
url: /cs/cpp/slide-master/
keywords:
- slide master
- master snímek
- PPT master snímek
- více master snímků
- porovnání master snímků
- pozadí
- zástupce
- klonování master snímku
- kopírování master snímku
- duplikování master snímku
- nepoužívaný master snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Spravujte slide mastery v Aspose.Slides pro C++: přístup, úpravy, klonování, porovnání a odstranění master snímků v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

**slide master** definuje sdílená nastavení designu pro skupinu snímků. Může obsahovat společné tvary, loga, pozadí, styly textu, nastavení motivu a nastavení zápatí. V PowerPointu je úprava slide masteru obvyklý způsob, jak udržet prezentaci konzistentní, aniž byste opakovali stejné formátování na každém snímku.

Aspose.Slides for C++ podporuje stejný model. Prezentace může obsahovat jeden nebo více master snímků a každý master snímek může obsahovat několik layout snímků. Normální snímky obvykle neodkazují přímo na master snímek. Místo toho normální snímek používá layout snímek, který patří pod master snímek.

Hierarchie je:

1. **Slide master** – definuje sdílený design a motiv.
2. **Layout slide** – definuje konkrétní uspořádání zástupců a formátování na úrovni rozvržení.
3. **Normal slide** – obsahuje skutečný obsah prezentace a používá jedno rozvržení snímku.

![Hierarchie master snímků, layout snímků a normálních snímků](slide-master_2.jpg)

V Aspose.Slides je slide master reprezentován rozhraním [IMasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/). Všechny master snímky v prezentaci jsou dostupné přes kolekci [Presentation::get_Masters](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_masters/) , která implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Když je stejná vlastnost definována na více úrovních, vyhrává konkrétnější úroveň. Například pokud master snímek a layout snímek oba definují pozadí, snímky založené na tomto layoutu použijí pozadí layoutu. Další informace o layout snímcích najdete v [Apply or Change Slide Layouts](/slides/cs/cpp/slide-layout/).
{{% /alert %}}

## **Přístup k masterům snímků**

V PowerPointu můžete otevřít zobrazení Slide Master přes **View** > **Slide Master**.

![Příkaz Slide Master na kartě View v PowerPointu](slide-master_3.jpg)

V Aspose.Slides použijte kolekci `get_Masters()` k přístupu k master snímkům:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Můžete také získat master snímek použitý normálním snímkem přes jeho layout:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Co obsahuje slide master**

Master snímek je objekt podobný snímku. Implementuje [IBaseSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/), takže poskytuje mnoho stejných vlastností snímku používaných normálními a layout snímky. Specifické členy pro master jsou uvedeny na stránce API [IMasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/).

Mezi často používané členy master snímku patří:

| Člen | Účel |
| --- | --- |
| `get_Background()` | Nastavuje pozadí na úrovni master snímku. |
| `get_Shapes()` | Ukládá tvary umístěné na masteru, jako jsou loga, rámečky obrázků a sdílený text. |
| `get_LayoutSlides()` | Ukládá rozvržení snímků, které patří k masteru. |
| `get_ThemeManager()` | Poskytuje přístup k API motivu masteru. |
| `get_HeaderFooterManager()` | Řídí záhlaví, zápatí, data a čísla snímků pro master a jeho podřízené rozvržení. |
| `GetDependingSlides()` | Vrací normální snímky, které závisí na masteru skrze jejich rozvržení. |

## **Přidání obrázku do slide masteru**

Když přidáte obrázek do master snímku, objeví se na snímcích, které používají rozvržení z tohoto masteru. To je užitečné pro loga, vodoznaky, dekorativní pásky a další opakující se vizuální prvky.

Následující příklad přidá logo na první master snímek:

```cpp
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

Pro více informací o rámečcích obrázků viz [Picture Frame](/slides/cs/cpp/picture-frame/).

## **Práce se zástupci**

Zástupci jsou obvykle definováni na layout snímcích. Master snímek poskytuje sdílený styl a motiv, který tyto layouty dědí, zatímco každý layout rozhoduje, kteří zástupci jsou k dispozici a kde jsou umístěni.

V PowerPointu jsou příkazy pro zástupce dostupné v zobrazení Slide Master.

![Příkaz Insert Placeholder v zobrazení Slide Master v PowerPointu](slide-master_5.png)

Chcete-li přidat nové zástupce pomocí Aspose.Slides, pracujte s layout snímkem, který patří pod master:

```cpp
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

Můžete také formátovat tvary zástupců, které již na master snímku existují. Následující příklad najde zástupce názvu a použije lineární gradientní výplň:

```cpp
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

![Formátovaný zástupce názvu, který dědí normální snímky](slide-master_8.png)

Pro více možností formátování zástupců a textu viz [Set Prompt Text in Placeholder](/slides/cs/cpp/manage-placeholder/) a [Text Formatting](/slides/cs/cpp/text-formatting/).

## **Změna pozadí slide masteru**

Master pozadí je děděno layouty a snímky, které jej nepřepisují. Následující příklad nastaví plnou barvu pozadí pro první master snímek:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Související témata najdete v [Presentation Background](/slides/cs/cpp/presentation-background/) a [Presentation Theme](/slides/cs/cpp/presentation-theme/).

## **Klonování slide masteru do jiné prezentace**

Použijte [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/addclone/) k zkopírování master snímku do jiné prezentace. Zkopírovaný master pak může být použit layouty a snímky v cílové prezentaci.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Pokud potřebujete klonovat normální snímky spolu s jejich masterem, viz [Clone Slides](/slides/cs/cpp/clone-slides/).

## **Přidání více slide masterů**

Prezentace může obsahovat více master snímků. To je užitečné, když různé sekce vyžadují různou značku, strukturu stránky nebo nastavení motivu.

![Příkazy PowerPointu pro vkládání a správu master snímků](slide-master_9.jpg)

Následující příklad klonuje výchozí master, přiřadí klonu jiné pozadí, vytvoří layout pod tímto klonovaným masterem a přidá nový snímek založený na tomto layoutu:

```cpp
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

## **Porovnání slide masterů**

Master snímky lze porovnat pomocí metody `Equals` zděděné z [IBaseSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/). Porovnání kontroluje strukturu a statický obsah, jako jsou tvary, text, formátování, animace a další nastavení snímku. Nekontroluje jedinečné identifikátory, jako jsou ID snímků, ani dynamické hodnoty zástupců, například aktuální datum.

```cpp
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

Pro více informací viz [Compare Presentation Slides](/slides/cs/cpp/compare-slides/).

## **Nastavení zobrazení Slide Master jako výchozího zobrazení**

Použijte metodu `set_LastView` na [ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/) k ovládání zobrazení, které PowerPoint otevře jako první. Následující příklad otevře prezentaci v zobrazení Slide Master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pro více nastavení zobrazení viz [Save Presentation](/slides/cs/cpp/save-presentation/).

## **Odstranění nepoužívaných master snímků**

Prezentace někdy obsahují master snímky, které již nejsou použity žádnými normálními snímky. Odstranění nepoužívaných masterů může snížit velikost souboru a zjednodušit údržbu šablony.

Použijte [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/cs/cpp/aspose.slides/masterslidecollection/removeunused/) k odstranění nepoužívaných masterů z kolekce `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Můžete také použít low-code metodu [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Jaký je rozdíl mezi slide masterem a layout snímkem?**

Slide master definuje sdílená nastavení designu, jako je motiv, pozadí, společné tvary a styly textu. Layout snímek patří pod master a definuje konkrétní uspořádání zástupců. Normální snímek používá layout snímek, a tak dědí jak z layoutu, tak z masteru.

**Může jedna prezentace obsahovat několik slide masterů?**

Ano. Prezentace může obsahovat několik slide masterů. Používejte více masterů, když různé sekce potřebují odlišné vizuální systémy nebo značku.

**Mám přidávat zástupce do slide masteru nebo do layout snímku?**

Ve většině případů přidávejte zástupce do layout snímků. Sdílené vizuální prvky a formátování umístěte na slide master, pak přidejte obsahové zástupce na layouty, které budou používat normální snímky.

**Mohu smazat slide master, který je stále používán?**

Ne. Slide master, který má závislé snímky, nelze bezpečně odstranit přímo. Nejprve přesuňte tyto snímky do layoutů pod jiným masterem nebo použijte metodu pro čištění nepoužívaných masterů, která odstraní pouze mastery, které nejsou v používání.