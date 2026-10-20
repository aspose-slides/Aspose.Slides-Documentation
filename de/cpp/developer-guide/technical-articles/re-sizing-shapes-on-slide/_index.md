---
title: Formen auf Präsentationsfolien in C++ skalieren
type: docs
weight: 130
url: /de/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /de/cpp/re-sizing-shapes-on-slide/
keywords:
- Formgröße ändern
- Formgröße anpassen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Skalieren Sie mühelos Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für C++—automatisieren Sie die Anpassung von Folienlayouts und steigern Sie die Produktivität."
---
## **Übersicht**

Wenn Sie die Foliengröße einer Präsentation ändern, müssen Sie möglicherweise auch deren Formen skalieren und neu positionieren, um die neuen Abmessungen anzupassen. Dieser Artikel zeigt, wie Formen manuell skaliert werden und wie Tabellen auf Folien, Masterfolien und Layouts behandelt werden.

## **Formen skalieren**

Um die relative Position und Größe jeder Form beizubehalten, multiplizieren Sie ihre horizontalen Koordinaten und Breite mit dem Verhältnis der neuen Folienbreite zur ursprünglichen Breite. Wenden Sie das entsprechende Höhenverhältnis auf ihre vertikalen Koordinaten und Höhe an.

Das erste Beispiel lädt eine Präsentation, deren Folien keine Tabellen enthalten, ändert die Foliengröße zu A4 und speichert das Ergebnis. Es verwendet [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) mit [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/), sodass die nachfolgende Schleife die Skalierung steuert. Die Verhältnisse sind einheitenlos; Positionen und Abmessungen von Formen werden in Punkten gemessen. Unterschiedliche Breiten- und Höhenverhältnisse können Formen verzerren, und das Ändern der Formabmessungen skaliert die Schriftgrößen nicht.

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
Tabellen erfordern eine separate Behandlung: Skalieren Sie deren Spaltenbreiten und Zeilenhöhen, anstatt die gesamte Breite und Höhe der Tabelle zuzuweisen. Zeilenhöhen können größer bleiben als angefordert, wenn der Zellinhalt mehr Platz benötigt.
{{% /alert %}}

Das zweite Beispiel unterstützt Tabellen und verarbeitet Formen auf Masterfolien und Layouts sowie einzelnen Folien, bevor die skalierte Präsentation gespeichert wird. Sein Hilfsprogramm verarbeitet jedes [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/), indem es [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) und [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) skaliert. Anschließend wird die Position der Tabelle skaliert, ohne ihre Gesamtabmessungen separat zu skalieren.

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

// Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
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
            // Tabellendimensionen werden durch Spaltenbreiten und Zeilenhöhen gesteuert.
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

// Resize shapes defined on masters and layouts as well as individual slides.
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

**Warum werden Formen nach dem Ändern der Foliengröße verzerrt oder abgeschnitten?**

Wenn Sie die Foliengröße ändern, ohne die Formen zu skalieren, behalten sie ihre ursprünglichen Positionen und Abmessungen bei und können über die Folie hinausragen. Das Skalieren von Breite und Höhe mit unterschiedlichen Verhältnissen kann ebenfalls Formen verzerren.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das erste Beispiel ändert die Formgrenzen direkt und ist für Folien ohne Tabellen vorgesehen. Das zweite Beispiel behandelt Tabellen separat. Überprüfen Sie das resultierende Layout, insbesondere Text und Tabellen, da diese Beispiele Schriftgrößen nicht skalieren und Tabellendaten die Zeilenhöhen einschränken können.

**Wie kann ich Tabellen beim Ändern der Foliengröße skalieren?**

Skalieren Sie die Spaltenbreiten mit dem Breitenverhältnis und die minimalen Zeilenhöhen mit dem Höhenverhältnis, und skalieren Sie anschließend die Position der Tabelle, wie im zweiten Beispiel gezeigt.

**Funktioniert diese Skalierung für Masterfolien und Layoutfolien?**

Ja. Das zweite Beispiel iteriert über [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) und über die [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) jedes Masters und wendet die gleiche Skalierungslogik auf deren Formen an.

**Kann ich die Ausrichtung einer Folie (Hochformat/Querformat) zusammen mit der Skalierung ändern?**

Ja. Setzen Sie [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) nach dem Ändern der Foliengröße und bevor Sie die Zielabmessungen auslesen, sodass die Skalierungsfaktoren die endgültige Ausrichtung berücksichtigen.

**Gibt es ein Limit für die Foliengröße, die ich festlegen kann?**

Sie können benutzerdefinierte Folienabmessungen mit [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) festlegen. Die unterstützten Abmessungen hängen zudem vom Präsentationsformat und von der Anwendung ab, mit der die Datei geöffnet wird.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Verwenden Sie denselben Skalierungsfaktor für Breite und Höhe. Um das ursprüngliche Layout in die neuen Folienabmessungen einzupassen, nutzen Sie das kleinere der Breiten- und Höhenverhältnisse für beide Dimensionen und Positionen. Dies bewahrt die Proportionen, kann jedoch an einer Kante ungenutzten Raum hinterlassen.