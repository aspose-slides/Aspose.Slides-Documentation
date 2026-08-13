---
title: Vormen op presentatieslides schalen
type: docs
weight: 100
url: /nl/cpp/re-sizing-shapes-on-slide/
keywords:
- vorm schalen
- grootte van vorm wijzigen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Schakel eenvoudig het schalen van vormen op PowerPoint- en OpenDocument-slides met Aspose.Slides voor C++—automatiseer aanpassingen van de slide‑lay-out en verhoog de productiviteit."
---
## **Overzicht**

Een van de meest voorkomende vragen van Aspose.Slides voor C++ klanten is hoe vormen te verkleinen zodat, wanneer de slidegrootte verandert, de data niet wordt afgekapt. Dit korte technische artikel laat zien hoe dat te doen.

## **Vormen schalen**

Om te voorkomen dat vormen uit lijnen raken wanneer de slidegrootte verandert, moet u de positie en afmetingen van elke vorm bijwerken zodat ze overeenkomen met de nieuwe slide‑indeling.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Laad het presentatie‑bestand.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Haal de oorspronkelijke slide‑grootte op.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Wijzig de slide‑grootte zonder bestaande vormen te schalen.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Haal de nieuwe slide‑grootte op.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Verklein en verplaats vormen op elke slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Schaalt de grootte van de vorm.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Schaalt de positie van de vorm.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Als een slide een tabel bevat, werkt de bovenstaande code niet correct. In dat geval moet elke cel in de tabel worden herschaald.
{{% /alert %}} 

Gebruik de onderstaande code om slides met tabellen te herschalen. Voor tabellen is het instellen van de breedte of hoogte een speciaal geval: u moet de hoogtes van individuele rijen en de breedtes van kolommen aanpassen om de totale grootte van de tabel te wijzigen.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Haal de oorspronkelijke slidegrootte op.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Wijzig de slidegrootte zonder bestaande vormen te schalen.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Haal de nieuwe slidegrootte op.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Schaald de grootte van de vorm.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Schaald de positie van de vorm.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Schaald de grootte van de vorm.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Schaald de positie van de vorm.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Schaald de grootte van de vorm.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Schaald de positie van de vorm.
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

## **FAQ**

### Waarom worden vormen vervormd of afgeknipt na het schalen van een slide?

Bij het schalen van een slide behouden vormen hun oorspronkelijke positie en grootte tenzij de schaal expliciet wordt gewijzigd. Dit kan ertoe leiden dat inhoud wordt bijgesneden of dat vormen uit lijnen raken.

### Werkt de geleverde code voor alle vormtypen?

Het basisvoorbeeld werkt voor de meeste vormtypen (tekstvakken, afbeeldingen, grafieken, enz.). Voor tabellen moet u echter rijen en kolommen apart behandelen, aangezien de hoogte en breedte van een tabel worden bepaald door de afmetingen van individuele cellen.

### Hoe schaalt u tabellen bij het schalen van een slide?

U moet door alle rijen en kolommen van de tabel lopen en hun hoogte en breedte evenredig aanpassen, zoals weergegeven in het tweede code‑voorbeeld.

### Werkt deze schaalbewerking voor masterslides en layoutslides?

Ja, maar u moet ook door [Masters](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_masters/) en [Layout slides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_layoutslides/) lopen en dezelfde schaallogica toepassen op hun vormen om consistentie door de hele presentatie te waarborgen.

### Kan ik de oriëntatie van een slide (portret/landschap) wijzigen samen met het schalen?

Ja. U kunt [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidesize/set_orientation/) gebruiken om de oriëntatie te wijzigen. Zorg ervoor dat u de schaallogica dienovereenkomstig aanpast om de lay‑out te behouden.

### Is er een limiet aan de slidegrootte die ik kan instellen?

Aspose.Slides ondersteunt aangepaste groottes, maar zeer grote groottes kunnen de prestaties beïnvloeden of compatibiliteitsproblemen veroorzaken met sommige versies van PowerPoint.

### Hoe kan ik voorkomen dat vormen met een vast beeldverhouding vervormd raken?

U kunt de `get_AspectRatioLocked`‑methode van de vorm controleren vóór het schalen. Als deze vergrendeld is, past u de breedte of hoogte evenredig aan in plaats van ze afzonderlijk te schalen.