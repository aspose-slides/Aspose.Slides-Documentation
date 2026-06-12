---
title: Vormen schalen op presentatiedia's
type: docs
weight: 100
url: /nl/cpp/re-sizing-shapes-on-slide/
keywords:
- vorm schalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Schakel gemakkelijk het schalen van vormen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor C++ in--automatiseer dia-indelingsaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Een van de meest voorkomende vragen van Aspose.Slides voor C++-klanten is hoe vormen te schalen zodat, wanneer de diaformaat verandert, de gegevens niet worden afgeknipt. Dit korte technische artikel laat zien hoe dat te doen.

## **Vormen schalen**

Om te voorkomen dat vormen scheef komen te staan wanneer de diaformaat verandert, dient u de positie en afmetingen van elke vorm bij te werken zodat ze overeenkomen met de nieuwe dia‑indeling.

```cpp
// Laad het presentatiebestand.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Haal de oorspronkelijke diaformaat op.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Wijzig de diaformaat zonder bestaande vormen te schalen.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Haal de nieuwe diaformaat op.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Formen schalen en verplaatsen op elke dia.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Schaal de vormgrootte.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Schaal de vormpositie.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Als een dia een tabel bevat, werkt de bovenstaande code niet correct. In dat geval moet elke cel in de tabel worden geschaald.
{{% /alert %}} 

Gebruik de volgende code aan uw kant om dia's die tabellen bevatten te schalen. Voor tabellen is het instellen van de breedte of hoogte een speciaal geval: u moet de hoogtes van afzonderlijke rijen en de breedtes van kolommen aanpassen om de totale grootte van de tabel te wijzigen.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Haal de oorspronkelijke diaformaat op.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Wijzig de diaformaat zonder bestaande vormen te schalen.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Haal de nieuwe diaformaat op.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Schaal de vormgrootte.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Schaal de vormpositie.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Schaal de vormgrootte.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Schaal de vormpositie.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Schaal de vormgrootte.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Schaal de vormpositie.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Veelgestelde vragen**

**Waarom worden vormen vervormd of afgeknipt na het schalen van een dia?**

Bij het schalen van een dia behouden vormen hun oorspronkelijke positie en grootte, tenzij de schaal expliciet wordt aangepast. Hierdoor kan inhoud worden bijgesneden of kunnen vormen scheef komen te staan.

**Werkt de meegeleverde code voor alle vormtypen?**

Het basisvoorbeeld werkt voor de meeste vormtypen (tekstvakken, afbeeldingen, diagrammen, enz.). Voor tabellen moet u echter rijen en kolommen afzonderlijk behandelen, omdat de hoogte en breedte van een tabel worden bepaald door de afmetingen van individuele cellen.

**Hoe schaalt ik tabellen bij het schalen van een dia?**

U moet door alle rijen en kolommen van de tabel itereren en hun hoogte en breedte evenredig aanpassen, zoals getoond in het tweede code‑voorbeeld.

**Werkt deze schaalverandering ook voor masterdia's en lay‑outdia's?**

Ja, maar u moet ook door de [Masters](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_masters/) en [Layout slides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_layoutslides/) itereren en dezelfde schaallogica op hun vormen toepassen om consistentie in de hele presentatie te waarborgen.

**Kan ik de oriëntatie van een dia (staand/liggend) tegelijk met het schalen wijzigen?**

Ja. U kunt [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidesize/set_orientation/) gebruiken om de oriëntatie te wijzigen. Zorg ervoor dat u de schaallogica hierop aanpast om de indeling te behouden.

**Is er een limiet aan de diaformaat die ik kan instellen?**

Aspose.Slides ondersteunt aangepaste formaten, maar zeer grote formaten kunnen de prestaties beïnvloeden of incompatibel zijn met bepaalde versies van PowerPoint.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd raken?**

U kunt de `get_AspectRatioLocked`-methode van de vorm controleren voordat u schaalt. Als deze vergrendeld is, past u de breedte of hoogte evenredig aan in plaats van ze afzonderlijk te schalen.