---
title: Hantera slide‑master för presentationer i C++
linktitle: Slide‑master
type: docs
weight: 80
url: /sv/cpp/slide-master/
keywords:
- slide‑master
- master‑bild
- PPT‑master‑bild
- flera master‑bilder
- jämför master‑bilder
- bakgrund
- platshållare
- klona master‑bild
- kopiera master‑bild
- duplicera master‑bild
- oanvänd master‑bild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Hantera slide‑master i Aspose.Slides för C++: åtkomst, redigering, kloning, jämförelse och borttagning av master‑bilder i PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

En **slide master** definierar delade designinställningar för en grupp bilder. Den kan innehålla vanliga former, logotyper, bakgrunder, textstilar, temainställningar och sidfotsinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje bild.

Aspose.Slides för C++ stöder samma modell. En presentation kan innehålla en eller flera master‑bilder, och varje master‑bild kan innehålla flera layout‑bilder. Normala bilder refererar vanligtvis inte direkt till en master‑bild. Istället använder en normal bild en layout‑bild, och den layout‑bilden tillhör en master‑bild.

Hierarkin är:

1. **Slide master** - definierar den delade designen och temat.  
1. **Layout slide** - definierar en specifik placering av platshållare och layout‑nivåformatering.  
1. **Normal slide** - innehåller det faktiska presentationsinnehållet och använder en layout‑bild.

![Hierarkin av master‑bilder, layout‑bilder och normala bilder](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av gränssnittet [IMasterSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/). Alla master‑bilder i en presentation är tillgängliga via samlingen [Presentation::get_Masters](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_masters/), som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
När samma egenskap definieras på mer än en nivå, vinner den mer specifika nivån. Till exempel, om en master‑bild och en layout‑bild båda definierar en bakgrund, använder bilder som baseras på den layouten layout‑bakgrunden. För mer information om layout‑bilder, se [Tillämpa eller ändra bildlayouter](/slides/sv/cpp/slide-layout/).
{{% /alert %}}

## **Åtkomst till Slide Masters**

I PowerPoint kan du öppna Slide Master‑vyn från **View** > **Slide Master**.

![Slide Master‑kommandot på PowerPoint‑fliken View](slide-master_3.jpg)

I Aspose.Slides använder du samlingen `get_Masters()` för att komma åt master‑bilder:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Du kan också hämta master‑bilden som används av en normal bild via dess layout:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Vad en Slide Master innehåller**

En master‑bild är ett bild‑likt objekt. Den implementerar [IBaseSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/), så den exponerar många av samma bildegenskaper som används av normala och layout‑bilder. Master‑specifika medlemmar listas på API‑sidan för [IMasterSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/).

Vanligt använda master‑bild‑medlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| `get_Background()` | Ställer in bakgrunden på master‑nivå för bilden. |
| `get_Shapes()` | Lagrar former placerade på master‑bilden, såsom logotyper, bildramar och delad text. |
| `get_LayoutSlides()` | Lagrar layout‑bilderna som tillhör master‑bilden. |
| `get_ThemeManager()` | Tillhandahåller åtkomst till master‑tema‑API:erna. |
| `get_HeaderFooterManager()` | Styr sidhuvuden, sidfötter, datum och bildnummer för master‑bilden och dess underliggande layouter. |
| `GetDependingSlides()` | Returnerar normala bilder som beror på master‑bilden via sina layouter. |

## **Lägg till en bild i en Slide Master**

När du lägger till en bild i en master‑bild visas den på bilder som använder layouter från den master‑bilden. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första master‑bilden:

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

För mer information om bildramar, se [Bildram](/slides/sv/cpp/picture-frame/).

## **Arbeta med platshållare**

Platshållare definieras normalt på layout‑bilder. Master‑bilden tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint är kommandon för platshållare tillgängliga i Slide Master‑vyn.

![Kommandot Infoga platshållare i PowerPoint Slide Master‑vyn](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides, arbeta med den layout‑bild som tillhör master‑bilden:

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

Du kan också formatera platshållarformer som redan finns på en master‑bild. Följande exempel hittar titel‑platshållaren och tillämpar en linjär gradientfyllning:

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

![Formaterad titel‑platshållare som ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Ställ in frågetext i platshållare](/slides/sv/cpp/manage-placeholder/) och [Textformatering](/slides/sv/cpp/text-formatting/).

## **Ändra bakgrund för en Slide Master**

En master‑bakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första master‑bilden:

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

För relaterade ämnen, se [Presentationsbakgrund](/slides/sv/cpp/presentation-background/) och [Presentationstema](/slides/sv/cpp/presentation-theme/).

## **Klona en Slide Master till en annan presentation**

Använd [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslidecollection/addclone/) för att kopiera en master‑bild till en annan presentation. Den kopierade master‑bilden kan sedan användas av layouter och bilder i mål‑presentationen.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Om du behöver klona normala bilder tillsammans med deras master, se [Klona bilder](/slides/sv/cpp/clone-slides/).

## **Lägg till flera Slide Masters**

En presentation kan innehålla flera master‑bilder. Detta är användbart när olika avsnitt kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera master‑bilder](slide-master_9.jpg)

Följande exempel klonar standard‑master‑bilden, ger klonen en annan bakgrund, skapar en layout under den klonade master‑bilden och lägger till en ny bild baserad på den layouten:

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

## **Jämför Slide Masters**

Master‑bilder kan jämföras med `Equals`‑metoden ärvd från [IBaseSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

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

För mer information, se [Jämför presentationsbilder](/slides/sv/cpp/compare-slides/).

## **Ställ in Slide Master‑vyn som standardvy**

Använd `set_LastView`‑metoden på [ViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/) för att styra den vy som PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

För fler vyinställningar, se [Spara presentation](/slides/sv/cpp/save-presentation/).

## **Ta bort oanvända master‑bilder**

Presentationer kan ibland innehålla master‑bilder som inte längre används av några normala bilder. Att ta bort oanvända master‑bilder kan minska filstorleken och förenkla underhållet av mallar.

Använd [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/sv/cpp/aspose.slides/masterslidecollection/removeunused/) för att ta bort oanvända master‑bilder från samlingen `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Du kan också använda lågkodmetoden [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Vad är skillnaden mellan en slide master och en layout‑slide?**

En slide master definierar delade designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layout‑slide tillhör en master‑slide och definierar en specifik placering av platshållare. En normal slide använder en layout‑slide, så den ärver både från layouten och master‑bilden.

**Kan en presentation innehålla flera slide masters?**

Ja. En presentation kan innehålla flera slide masters. Använd flera master‑bilder när olika avsnitt behöver olika visuella system eller varumärkesprofil.

**Bör jag lägga till platshållare i en master‑slide eller en layout‑slide?**

I de flesta fall bör du lägga till platshållare i layout‑bilder. Placera delade visuella element och delad formatering på master‑sliden, och placera sedan innehålls‑platshållare på layouterna som de normala bilderna kommer att använda.

**Kan jag ta bort en master‑slide som fortfarande används?**

Nej. En master‑slide som har beroende bilder kan inte tas bort säkert direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en rensningsmetod för oanvända master‑bilder som bara tar bort master‑bilder som inte är i bruk.