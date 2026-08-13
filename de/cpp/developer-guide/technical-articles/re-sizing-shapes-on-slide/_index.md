---
title: Formen auf Präsentationsfolien skalieren
type: docs
weight: 100
url: /de/cpp/re-sizing-shapes-on-slide/
keywords:
- Formgröße anpassen
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Einfach Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für C++ skalieren – die Folienlayout-Anpassungen automatisieren und die Produktivität steigern."
---
## **Übersicht**

Eine der häufigsten Fragen von Aspose.Slides for C++ Kunden ist, wie man Formen skaliert, sodass bei Änderung der Foliengröße die Daten nicht abgeschnitten werden. Dieser kurze technische Artikel zeigt, wie das geht.

## **Formen skalieren**

Um zu verhindern, dass Formen bei Änderung der Foliengröße verschoben werden, aktualisieren Sie die Position und die Abmessungen jeder Form, sodass sie dem neuen Folienlayout entsprechen.

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

// Laden Sie die Präsentationsdatei.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Erhalten Sie die ursprüngliche Foliengröße.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Ändern Sie die Foliengröße, ohne vorhandene Formen zu skalieren.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Erhalten Sie die neue Foliengröße.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Skalieren Sie die Formgröße.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skalieren Sie die Formgröße.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skalieren Sie die Formposition.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Enthält eine Folie eine Tabelle, funktioniert der obige Code nicht korrekt. In diesem Fall muss jede Zelle der Tabelle skaliert werden.
{{% /alert %}} 

Verwenden Sie den folgenden Code, um Folien, die Tabellen enthalten, zu skalieren. Bei Tabellen ist das Festlegen von Breite oder Höhe ein Sonderfall: Sie müssen die Höhen einzelner Zeilen und die Breiten einzelner Spalten anpassen, um die Gesamtgröße der Tabelle zu ändern.

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

// Erhalte die ursprüngliche Foliengröße.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Ändere die Foliengröße, ohne vorhandene Formen zu skalieren.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Erhalte die neue Foliengröße.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Skaliere die Formgröße.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skaliere die Formposition.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Skaliere die Formgröße.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Skaliere die Formposition.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skaliere die Formgröße.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skaliere die Formposition.
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

### Warum werden Formen nach dem Skalieren einer Folie verzerrt oder abgeschnitten?

Beim Skalieren einer Folie behalten Formen ihre ursprüngliche Position und Größe bei, sofern die Skalierung nicht explizit geändert wird. Das kann dazu führen, dass Inhalte abgeschnitten oder Formen verschoben werden.

### Funktioniert der bereitgestellte Code für alle Formtypen?

Das Grundbeispiel funktioniert für die meisten Formtypen (Textfelder, Bilder, Diagramme usw.). Für Tabellen müssen Sie jedoch Zeilen und Spalten separat behandeln, da Höhe und Breite einer Tabelle durch die Abmessungen der einzelnen Zellen bestimmt werden.

### Wie skaliere ich Tabellen beim Skalieren einer Folie?

Sie müssen alle Zeilen und Spalten der Tabelle durchlaufen und deren Höhe und Breite proportional anpassen, wie im zweiten Codebeispiel gezeigt.

### Funktioniert dieses Skalieren für Masterfolien und Layoutfolien?

Ja, aber Sie sollten auch durch [Masters](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_masters/) und [Layoutfolien](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_layoutslides/) iterieren und dieselbe Skalierungslogik auf deren Formen anwenden, um Konsistenz in der gesamten Präsentation zu gewährleisten.

### Kann ich die Ausrichtung einer Folie (Portrait/Landscape) zusammen mit dem Skalieren ändern?

Ja. Sie können [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidesize/set_orientation/) verwenden, um die Ausrichtung zu ändern. Stellen Sie sicher, dass Sie die Skalierungslogik entsprechend einstellen, um das Layout beizubehalten.

### Gibt es eine Begrenzung für die Foliengröße, die ich festlegen kann?

Aspose.Slides unterstützt benutzerdefinierte Größen, aber sehr große Größen können die Leistung beeinträchtigen oder die Kompatibilität mit einigen PowerPoint-Versionen einschränken.

### Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?

Sie können die Methode `get_AspectRatioLocked` der Form vor dem Skalieren prüfen. Ist sie gesperrt, passen Sie Breite oder Höhe proportional an, anstatt sie einzeln zu skalieren.