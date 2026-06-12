---
title: Beheer van presentatieachtergronden in C++
linktitle: Slide-achtergrond
type: docs
weight: 20
url: /nl/cpp/presentation-background/
keywords:
- presentatie-achtergrond
- slide-achtergrond
- effen kleur
- verloopkleur
- afbeeldingsachtergrond
- achtergrond-transparantie
- achtergrond-eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je dynamische achtergronden instelt in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor C++, inclusief code-tips om je presentaties te verbeteren."
---
## **Inleiding**

Effen kleuren, verlopen en afbeeldingen worden vaak gebruikt als slide‑achtergronden. Je kunt de achtergrond instellen voor een **normale slide** (een enkele slide) of een **master‑slide** (van toepassing op meerdere slides tegelijk).

![PowerPoint background](powerpoint-background.png)

## **Stel een effenkleurige achtergrond in voor een normale slide**

Aspose.Slides stelt je in staat een effen kleur als achtergrond in te stellen voor een specifieke slide in een presentatie — zelfs als de presentatie een master‑slide gebruikt. De wijziging is alleen van toepassing op de geselecteerde slide.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse aan.
2. Stel de slide‑[BackgroundType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/backgroundtype/) in op `OwnBackground`.
3. Stel de slide‑achtergrond [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) in op `Solid`.
4. Gebruik de [get_SolidFillColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/get_solidfillcolor/)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

Het volgende C++‑voorbeeld laat zien hoe je een blauwe effen kleur als achtergrond voor een normale slide instelt:

```cpp
// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Stel de achtergrondkleur van de slide in op blauw.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Sla de presentatie op naar schijf.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Stel een effenkleurige achtergrond in voor een master‑slide**

Aspose.Slides stelt je in staat een effen kleur als achtergrond in te stellen voor de master‑slide in een presentatie. De master‑slide fungeert als een sjabloon dat de opmaak van alle slides beheert, dus wanneer je een effen kleur kiest voor de achtergrond van de master‑slide, geldt deze voor elke slide.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse aan.
2. Stel de master‑slide‑[BackgroundType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/backgroundtype/) (via `get_Masters`) in op `OwnBackground`.
3. Stel de master‑slide‑achtergrond [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) in op `Solid`.
4. Gebruik de [get_SolidFillColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/get_solidfillcolor/)‑methode om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

Het volgende C++‑voorbeeld laat zien hoe je een effen kleur (bosgroen) als achtergrond voor een master‑slide instelt:

```cpp
// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Stel de achtergrondkleur van de Master-slide in op bosgroen.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Sla de presentatie op naar schijf.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Stel een verlopen achtergrond in voor een slide**

Een verloop is een grafisch effect dat ontstaat door een geleidelijke kleurschakering. Wanneer het wordt gebruikt als slide‑achtergrond, kunnen verlopen presentaties er meer kunstzinnig en professioneel laten uitzien. Aspose.Slides stelt je in staat een verloopkleur als achtergrond voor slides in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse aan.
2. Stel de slide‑[BackgroundType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/backgroundtype/) in op `OwnBackground`.
3. Stel de slide‑achtergrond [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) in op `Gradient`.
4. Gebruik de [get_GradientFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/get_gradientformat/)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/) om je gewenste verloopinstellingen te configureren.
5. Sla de gewijzigde presentatie op.

Het volgende C++‑voorbeeld laat zien hoe je een verloopkleur als achtergrond voor een slide instelt:

```cpp
// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Pas een verloop-effect toe op de achtergrond.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Sla de presentatie op naar schijf.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Stel een afbeelding in als slide‑achtergrond**

Naast effen en verloopvullingen stelt Aspose.Slides je in staat afbeeldingen te gebruiken als slide‑achtergronden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse aan.
2. Stel de slide‑[BackgroundType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/backgroundtype/) in op `OwnBackground`.
3. Stel de slide‑achtergrond [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) in op `Picture`.
4. Laad de afbeelding die je wilt gebruiken als slide‑achtergrond.
5. Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
6. Gebruik de [get_PictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/get_picturefillformat/)‑methode op [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de gewijzigde presentatie op.

Het volgende C++‑voorbeeld laat zien hoe je een afbeelding als achtergrond voor een slide instelt:

```cpp
// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Stel achtergrondafbeeldings-eigenschappen in.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Laad de afbeelding.
auto image = Images::FromFile(u"Tulips.jpg");
// Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Sla de presentatie op naar schijf.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het volgende code‑voorbeeld laat zien hoe je het vultype van de achtergrond instelt op een betegelde afbeelding en de tegel‑eigenschappen wijzigt:

```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}

Lees meer: [**Tegelafbeelding als textuur**](/slides/nl/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Wijzig de transparantie van de achtergrondafbeelding**

Je wilt misschien de transparantie van de achtergrondafbeelding van een slide aanpassen zodat de inhoud van de slide beter tot uiting komt. De volgende C++‑code laat zien hoe je de transparantie van een slide‑achtergrondafbeelding wijzigt:

```cpp
auto transparencyValue = 30; // Bijvoorbeeld.

// Haal de collectie van afbeeldingstransformatie‑operaties op.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Zoek een bestaand transparantie‑effect met vaste percentage.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Stel de nieuwe transparantiewaarde in.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Ophalen van de slide‑achtergrondwaarde**

Aspose.Slides biedt de [IBackgroundEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibackgroundeffectivedata/)‑interface voor het ophalen van de effectieve achtergrondwaarden van een slide. Deze interface geeft toegang tot de effectieve [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) en [EffectFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

Met de `get_Background`‑methode van de [BaseSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseslide/)‑klasse kun je de effectieve achtergrond van een slide verkrijgen.

Het volgende C++‑voorbeeld laat zien hoe je de effectieve achtergrondwaarde van een slide ophaalt:

```cpp
// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

**Kan ik een aangepaste achtergrond resetten en het thema‑/layout‑achtergrond herstellen?**

Ja. Verwijder de aangepaste vulling van de slide, en de achtergrond wordt opnieuw geërfd van de bijbehorende [layout](/slides/nl/cpp/slide-layout/)/[master](/slides/nl/cpp/slide-master/)‑slide (dus de [thema‑achtergrond](/slides/nl/cpp/presentation-theme/)).

**Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?**

Als een slide een eigen vulling heeft, blijft deze onveranderd. Als de achtergrond wordt geërfd van de [layout](/slides/nl/cpp/slide-layout/)/[master](/slides/nl/cpp/slide-master/), wordt deze bijgewerkt om overeen te komen met het [nieuwe thema](/slides/nl/cpp/presentation-theme/).