---
title: Vormen schalen op presentatiedia's in C++
type: docs
weight: 130
url: /nl/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /nl/cpp/re-sizing-shapes-on-slide/
keywords:
- vorm schalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Schakel eenvoudig het schalen van vormen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor C++—automatiseer aanpassingen van de diavormgeving en verhoog de productiviteit."
---
## **Overzicht**

Wanneer je de diaafmeting van een presentatie wijzigt, moet je mogelijk ook de vormen opnieuw dimensioneren en verplaatsen zodat ze passen binnen de nieuwe afmetingen. Dit artikel laat zien hoe je vormen handmatig kunt schalen en hoe je tabellen op dia's, masters en lay‑outs kunt behandelen.

## **Vormen schalen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldig je de horizontale coördinaten en de breedte met de verhouding van de nieuwe dia‑breedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogteratio toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, wijzigt de dia‑afmeting naar A4 en slaat het resultaat op. Het gebruikt [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) met [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) zodat de daaropvolgende lus de scaling regelt. De verhoudingen zijn dimensieloos; de positie en afmetingen van vormen worden gemeten in punten. Verschillende breedte‑ en hoogteratio’s kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

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
Tabellen vereisen een aparte behandeling: schaalt hun kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan gevraagd als de celinhoud meer ruimte nodig heeft.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay‑outs evenals op individuele dia's voordat de aangepaste presentatie wordt opgeslagen. De helper behandelt elke [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) door [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) en [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) te schalen. Vervolgens schaalt hij de positie van de tabel zonder de totale afmetingen apart te schalen.

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
            // De afmetingen van de tabel worden bepaald door de kolombreedtes en rijhoogtes.
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

// Vormaat vormen die gedefinieerd zijn op masters en lay‑outs, evenals op individuele dia's.
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

## **Veelgestelde vragen**

**Waarom worden vormen vervormd of afgesneden na het wijzigen van de dia‑afmeting?**

Als je de dia‑afmeting wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke positie en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan vormen eveneens vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de grenzen van vormen direct en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen afzonderlijk. Controleer de resulterende lay‑out, met name tekst en tabellen, omdat deze voorbeelden de lettergroottes niet schalen en de inhoud van tabellen de rijhoogtes kan beperken.

**Hoe schaalt ik tabellen bij het wijzigen van de dia‑afmeting?**

Schaal de kolombreedtes met de breedteratio en de minimale rijhoogtes met de hoogteratio, en schaal vervolgens de positie van de tabel, zoals getoond in het tweede voorbeeld.

**Zal deze aanpassing ook werken voor masterdia's en lay‑outdia's?**

Ja. Het tweede voorbeeld doorloopt [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) en voor elke master de [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) en past dezelfde aanpassingslogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (portret/landschap) wijzigen samen met de schaalverandering?**

Ja. Stel [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) in na het wijzigen van de dia‑afmeting en vóór het uitlezen van de doelafmetingen, zodat de schaalfactoren de uiteindelijke oriëntatie weergeven.

**Is er een limiet aan de dia‑afmeting die ik kan instellen?**

Je kunt aangepaste dia‑afmetingen opgeven met [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). De ondersteunde afmetingen hangen ook af van het presentatieformaat en van de applicatie die het bestand opent.

**Hoe voorkom ik dat vormen met een vaste beeldverhouding vervormd worden?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay‑out binnen de nieuwe dia‑afmetingen te laten passen, gebruik je de kleinere van de breedte‑ en hoogteratio’s voor beide afmetingen en posities. Dit behoudt de verhoudingen, maar kan leiden tot ongebruikte ruimte langs één rand.