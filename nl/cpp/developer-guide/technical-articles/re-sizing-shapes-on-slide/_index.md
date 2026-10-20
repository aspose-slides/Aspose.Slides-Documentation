---
title: Vormen schalen op presentatiedia's in C++
type: docs
weight: 130
url: /nl/cpp/resizing-shapes-on-slide/
aliases:
  - /nl/cpp/re-sizing-shapes-on-slide/
keywords:
  - vorm schalen
  - vormgrootte wijzigen
  - PowerPoint
  - OpenDocument
  - presentatie
  - C++
  - Aspose.Slides
description: "Schaal eenvoudig vormen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor C++ — automatiseer aanpassingen van de dia-indeling en verhoog de productiviteit."
---
## **Overzicht**

Wanneer je de dia-grootte van een presentatie wijzigt, moet je mogelijk ook de vormen aanpassen en opnieuw positioneren zodat ze passen bij de nieuwe afmetingen. Dit artikel laat zien hoe je vormen handmatig kunt schalen en hoe je met tabellen op dia's, masters en lay-outs omgaat.

## **Vormen schalen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldig je de horizontale coördinaten en de breedte met de verhouding tussen de nieuwe dia-breedte en de oorspronkelijke breedte. Pas de overeenkomstige hoogte-verhouding toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, verandert de dia-grootte naar A4 en slaat het resultaat op. Het gebruikt [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) met [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) zodat de daaropvolgende lus de schaling regelt. De verhoudingen zijn dimensieloos; de positie en afmetingen van vormen worden gemeten in punten. Verschillende breedte- en hoogteverhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

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

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Tabellen vereisen een aparte behandeling: schaal hun kolom-breedtes en rij-hoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rij-hoogtes kunnen groter blijven dan gevraagd als de celinhoud meer ruimte nodig heeft.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay-outs, evenals op afzonderlijke dia's, voordat de vergrote presentatie wordt opgeslagen. De hulpprogramma behandelt elke [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) door [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) en [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) te schalen. Vervolgens schaalt het de positie van de tabel zonder de totale afmetingen afzonderlijk te schalen.

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
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Bereken onafhankelijke horizontale en verticale schaalfactoren.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // Tabelafmetingen worden bestuurd door kolombreedtes en rijhoogtes.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// Schaalt vormen die gedefinieerd zijn op masters en lay-outs, evenals op individuele dia's.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Waarom worden vormen vervormd of afgesneden na het aanpassen van de dia-grootte?**

Als je de dia-grootte wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke positie en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan vormen ook vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de grenzen van vormen direct en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen apart. Controleer de resulterende lay-out, met name tekst en tabellen, omdat deze voorbeelden de lettergroottes niet schalen en de inhoud van tabellen de rij-hoogtes kan beperken.

**Hoe kan ik tabellen aanpassen bij het wijzigen van een dia?**

Schaal de kolom-breedtes met de breedte-verhouding en de minimale rij-hoogtes met de hoogte-verhouding, en schaaf vervolgens de positie van de tabel, zoals weergegeven in het tweede voorbeeld.

**Werkt deze aanpassing voor master-dia's en layout-dia's?**

Ja. Het tweede voorbeeld doorloopt [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) en de [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) van elke master en past dezelfde aanpassingslogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (portret/landschap) wijzigen samen met het aanpassen?**

Ja. Stel [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) in na het wijzigen van de dia-grootte en vóór het lezen van de doelafmetingen, zodat de schaalfactoren de uiteindelijke oriëntatie weerspiegelen.

**Is er een limiet aan de dia-grootte die ik kan instellen?**

Je kunt aangepaste dia-afmetingen opgeven met [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). De ondersteunde afmetingen hangen ook af van het presentatie-formaat en de toepassing die het bestand opent.

**Hoe kan ik voorkomen dat vormen met een vaste verhouding vervormd raken?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de originele lay-out in de nieuwe dia-afmetingen te laten passen, gebruik je de kleinere van de breedte- en hoogte-verhoudingen voor beide afmetingen en posities. Dit behoudt de verhoudingen, maar kan ongebruikt ruimte langs één rand achterlaten.