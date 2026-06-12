---
title: "Beheer presentatieslide‑masters in C++"
linktitle: "Slide‑master"
type: docs
weight: 80
url: /nl/cpp/slide-master/
keywords:
- "slide‑master"
- "master‑dia"
- "PPT‑master‑dia"
- "meerdere master‑dia’s"
- "master‑dia’s vergelijken"
- "achtergrond"
- "plaatsaanduiding"
- "master‑dia klonen"
- "master‑dia kopiëren"
- "master‑dia dupliceren"
- "ongebruikte master‑dia"
- "PowerPoint"
- "OpenDocument"
- "presentatie"
- "C++"
- "Aspose.Slides"
description: "Beheer slide‑masters in Aspose.Slides voor C++: toegang, bewerken, klonen, vergelijken en verwijderen van master‑dia’s in PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Een **slide‑master** definieert gedeelde ontwerpinstellingen voor een groep dia’s. Hij kan gemeenschappelijke vormen, logo’s, achtergronden, tekststijlen, themainstellingen en voetteksten bevatten. In PowerPoint is het bewerken van een slide‑master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides voor C++ ondersteunt hetzelfde model. Een presentatie kan één of meerdere master‑dia’s bevatten, en elke master‑dia kan verschillende lay-out‑dia’s bevatten. Normale dia’s verwijzen doorgaans niet rechtstreeks naar een master‑dia. In plaats daarvan gebruikt een normale dia een lay-out‑dia, en die lay-out‑dia behoort tot een master‑dia.

De hiërarchie is:

1. **Slide master** – definieert het gedeelde ontwerp en thema.  
1. **Layout slide** – definieert een specifieke rangschikking van tijdelijke aanduidingen en opmaak op lay-outniveau.  
1. **Normal slide** – bevat de feitelijke presentatiewaarde en gebruikt één lay‑out‑dia.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

In Aspose.Slides wordt een slide‑master weergegeven door de interface [IMasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/). Alle master‑dia’s in een presentatie zijn beschikbaar via de collectie [Presentation::get_Masters](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_masters/), die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/) implementeert.

{{% alert color="info" title="Overerving" %}}

Wanneer dezelfde eigenschap op meer dan één niveau wordt gedefinieerd, heeft het specifiekere niveau voorrang. Bijvoorbeeld, als een master‑dia en een lay‑out‑dia beide een achtergrond definiëren, gebruiken dia’s die op die lay‑out gebaseerd zijn de lay‑out‑achtergrond. Voor meer informatie over lay‑out‑dia’s, zie [Apply or Change Slide Layouts](/slides/nl/cpp/slide-layout/).

{{% /alert %}}

## **Toegang tot Slide Masters**

In PowerPoint kun je de slide‑masterweergave openen via **Beeld** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

In Aspose.Slides gebruik je de collectie `get_Masters()` om master‑dia’s te benaderen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Je kunt ook de master‑dia ophalen die door een normale dia wordt gebruikt via zijn lay‑out:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Wat een Slide Master Bevat**

Een master‑dia is een dia‑achtig object. Hij implementeert [IBaseSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/), zodat hij veel van dezelfde dia‑eigenschappen blootlegt die door normale en lay‑out‑dia’s worden gebruikt. Master‑specifieke leden staan opgesomd op de API‑pagina van [IMasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/).

Veelgebruikte master‑dia‑leden zijn onder andere:

| Lid | Doel |
| --- | --- |
| `get_Background()` | Stelt de master‑niveau dia‑achtergrond in. |
| `get_Shapes()` | Bevat vormen die op de master zijn geplaatst, zoals logo’s, afbeeldingsframes en gedeelde tekst. |
| `get_LayoutSlides()` | Bevat de lay‑out‑dia’s die tot de master behoren. |
| `get_ThemeManager()` | Biedt toegang tot de master‑thema‑API’s. |
| `get_HeaderFooterManager()` | Beheert kop‑ en voetteksten, datum‑ en dia‑nummers voor de master en de bijbehorende lay‑outs. |
| `GetDependingSlides()` | Retourneert normale dia’s die via hun lay‑outs afhankelijk zijn van de master. |

## **Een Afbeelding Toevoegen aan een Slide Master**

Wanneer je een afbeelding aan een master‑dia toevoegt, verschijnt deze op alle dia’s die lay‑outs van die master gebruiken. Dit is handig voor logo’s, watermerken, decoratieve bandjes en andere herhalende visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste master‑dia:

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

Voor meer informatie over afbeeldingsframes, zie [Picture Frame](/slides/nl/cpp/picture-frame/).

## **Werken met Plaatsaanduidingen**

Plaatsaanduidingen worden normaal gedefinieerd op lay‑out‑dia’s. De master‑dia levert de gedeelde stijl en het thema waar deze lay‑outs van erven, terwijl elke lay‑out bepaalt welke plaatsaanduidingen beschikbaar zijn en waar ze geplaatst worden.

In PowerPoint zijn de plaatsaanduidingsopdrachten beschikbaar in de Slide Master‑weergave.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Om nieuwe plaatsaanduidingen toe te voegen met Aspose.Slides, werk je met de lay‑out‑dia die bij de master hoort:

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

Je kunt ook de vorm van bestaande plaatsaanduidingen op een master‑dia opmaken. Het volgende voorbeeld zoekt de titel‑plaatsaanduiding en past een lineaire gradiëntvulling toe:

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Voor meer opties rond plaatsaanduidingen en tekstopmaak, zie [Set Prompt Text in Placeholder](/slides/nl/cpp/manage-placeholder/) en [Text Formatting](/slides/nl/cpp/text-formatting/).

## **Achtergrond van een Slide Master Wijzigen**

Een master‑achtergrond wordt geërfd door lay‑outs en dia’s die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste master‑dia:

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

Gerelateerde onderwerpen: [Presentation Background](/slides/nl/cpp/presentation-background/) en [Presentation Theme](/slides/nl/cpp/presentation-theme/).

## **Een Slide Master Kopiëren naar een Andere Presentatie**

Gebruik [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/addclone/) om een master‑dia naar een andere presentatie te kopi ren. De gekopieerde master kan vervolgens worden gebruikt door lay‑outs en dia’s in de doelpresentatie.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Als je normale dia’s wilt kopiëren samen met hun master, zie [Clone Slides](/slides/nl/cpp/clone-slides/).

## **Meerdere Slide Masters Toevoegen**

Een presentatie kan meerdere master‑dia’s bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginacompositie of themainstellingen vereisen.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard‑master, geeft de kloon een andere achtergrond, maakt een lay‑out onder die gekloonde master en voegt een nieuwe dia toe gebaseerd op die lay‑out:

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

## **Slide Masters Vergelijken**

Master‑dia’s kunnen worden vergeleken met de `Equals`‑methode die is geërfd van [IBaseSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Unieke identifiers, zoals dia‑ID’s, of dynamische plaatsaanduidingswaarden, zoals de huidige datum, worden niet vergeleken.

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

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/cpp/compare-slides/).

## **Slide Master‑weergave Instellen als Standaardweergave**

Gebruik de methode `set_LastView` op [ViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint als eerste opent. Het volgende voorbeeld opent de presentatie in de Slide Master‑weergave:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/cpp/save-presentation/).

## **Ongebruikte Master Slides Verwijderen**

Soms bevatten presentaties master‑dia’s die door geen enkele normale dia meer worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/nl/cpp/aspose.slides/masterslidecollection/removeunused/) om ongebruikte masters uit de collectie `get_Masters()` te verwijderen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Je kunt ook de low‑code‑methode [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) gebruiken:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Wat is het verschil tussen een slide master en een layout slide?**

Een slide master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een layout slide behoort tot een master‑dia en bepaalt een specifieke rangschikking van plaatsaanduidingen. Een normale dia gebruikt een layout slide, waardoor hij zowel van de layout als van de master erft.

**Kan één presentatie meerdere slide masters bevatten?**

Ja. Een presentatie kan meerdere slide masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik plaatsaanduidingen toevoegen aan een master‑dia of een layout‑dia?**

In de meeste gevallen voeg je plaatsaanduidingen toe aan layout‑dia’s. Plaats gedeelde visuele elementen en gedeelde opmaak op de master‑dia en voeg vervolgens de inhoud‑plaatsaanduidingen toe op de lay‑outs die normale dia’s zullen gebruiken.

**Kan ik een master‑dia verwijderen die nog wordt gebruikt?**

Nee. Een master‑dia met afhankelijke dia’s kan niet veilig direct worden verwijderd. Verplaats eerst die dia’s naar lay‑outs onder een andere master, of gebruik een opruimingsmethode die alleen ongebruikte masters verwijdert.