---
title: Verwalten von Präsentations-Platzhaltern in C++
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/cpp/manage-placeholder/
keywords:
- Platzhalter
- Text-Platzhalter
- Bild-Platzhalter
- Diagramm-Platzhalter
- Inhalts-Platzhalter
- Aufforderungstext
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text-, Bild-, Diagramm- und Inhalts-Platzhalter untersuchen und bearbeiten sowie die Platzhalter-Vererbung mit Aspose.Slides für C++ verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die in einer Präsentationsvorlage eine Position für eine bestimmte Art von Inhalt reserviert. Häufige Beispiele sind Titel‑, Text‑, Bild‑, Diagramm‑ und generische Inhaltsplatzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folie oder Master‑Folie erben.

Aspose.Slides stellt Platzhalterinformationen über die Methode [IShape::get_Placeholder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_placeholder/) bereit. Die Methode gibt ein [IPlaceholder](https://reference.aspose.com/slides/de/cpp/aspose.slides/iplaceholder/)‑Objekt oder `nullptr` für eine normale Form zurück. Verwenden Sie [IPlaceholder::get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/iplaceholder/get_type/), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Die Form‑Schnittstelle bleibt wichtig, nachdem Sie den Platzhaltertyp kennen:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird in der Regel durch ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) dargestellt.
- Ein gefüllter Bildplatzhalter kann durch ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) dargestellt werden.
- Ein gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann mehrere Arten von Inhalt enthalten. Prüfen Sie sowohl [IPlaceholder::get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/iplaceholder/get_type/) als auch die Laufzeit‑Form‑Schnittstelle, anstatt anzunehmen, dass jeder Platzhalter ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/iplaceholder/get_type/) beschreibt die Rolle eines Platzhalters; es garantiert nicht den Laufzeit‑Typ der Form. Verwenden Sie immer eine Typprüfung, bevor Sie auf text‑, bild‑, diagramm‑, tabellen‑ oder medienspezifische Mitglieder zugreifen.
{{% /alert %}}

## **Verstehen der Platzhalter‑Vererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folie definiert wiederverwendbare Stile und, in manchen Fällen, Platzhalter auf Master‑Ebene.
2. Eine Layout‑Folie definiert das Layout, das von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/getbaseplaceholder/) auf, um eine Ebene in dieser Hierarchie nach oben zu gehen. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode gibt `nullptr` zurück, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter auf der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Das Bearbeiten eines Platzhalters auf einer normalen Folie erstellt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale normale Form hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil sie dieselben Koordinaten einnimmt.

## **Text in einem Platzhalter ändern**

Titel‑, zentrierte‑Titel‑, Untertitel‑, Text‑ und Inhaltsplatzhalter unterstützen normalerweise Text. Prüfen Sie auf [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/), bevor Sie dessen [get_TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/get_textframe/)‑Methode verwenden.

Dieses Beispiel aktualisiert den ersten Titel‑Platzhalter auf der ersten Folie und speichert das Ergebnis:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Dieses Muster vermeidet das Casten von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern zu [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/). Es identifiziert den Platzhalter außerdem nach seiner Bestimmung, anstatt sich auf einen fragilen Form‑Index zu verlassen.

## **Aufforderungstext auf einem Layout festlegen**

Prompt‑Text ist die Design‑Zeit‑Anleitung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken Sie, um den Titel hinzuzufügen*. Setzen Sie benutzerdefinierten Prompt‑Text auf dem Layout‑Platzhalter, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/get_layoutslide/) auf das Layout zu und iterieren Sie über [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/get_shapes/).

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Aufforderungen auf dem Layout, das von der ersten Folie verwendet wird:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Prompt‑Text ist kein normaler Folieninhalt. Er ist für leere Platzhalter in Bearbeitungs‑Applikationen wie PowerPoint vorgesehen. Sobald ein Benutzer oder ein Programm echten Inhalt bereitstellt, wird der Prompt nicht mehr angezeigt. Das Ändern eines Prompts ersetzt zudem nicht den bestehenden Text auf Folien, die das Layout verwenden.

## **Ein Bildplatzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bildplatzhalter bereits gefüllt ist und durch ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) dargestellt wird, ersetzen Sie das Bild über [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/get_picture/) und [ISlidesPicture::set_Image](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidespicture/set_image/).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie an den Koordinaten des Platzhalters einen Bildrahmen mit [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addpictureframe/) hinzu und entfernen Sie den leeren Platzhalter.

Das nächste Beispiel unterstützt beide Fälle und speichert die Präsentation:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

Der für einen leeren Platzhalter erstellte Ersatz ist ein lokaler Bildrahmen, kein neuer Platzhalter, weil [IShape::get_Placeholder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_placeholder/) schreibgeschützt ist. Er behält die reservierte Position bei, erbt jedoch nicht mehr das platzhalterspezifische Verhalten. Wenn das Beibehalten der Platzhalter‑Beziehung wichtig ist, erstellen und füllen Sie den Platzhalter zuerst in PowerPoint und aktualisieren Sie dann den resultierenden [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) mit Aspose.Slides.

Für Bild‑Transparenz, Zuschneiden und andere bild‑spezifische Effekte siehe [Manage Picture Frames](/slides/de/cpp/picture-frame/). Diese Vorgänge gehören zum Bildrahmen oder Bild‑Füllformat, nicht zu den Metadaten des Platzhalters.

## **Mit Diagramm‑ und Inhaltsplatzhaltern arbeiten**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl über den Platzhaltertyp als auch über die Laufzeit‑Schnittstelle, ändert seinen Titel und speichert die Datei:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Ein allgemeiner Inhaltsplatzhalter hat normalerweise [PlaceholderType::Object](https://reference.aspose.com/slides/de/cpp/aspose.slides/placeholdertype/). In PowerPoint fungiert er als Launcher für mehrere Inhaltstypen, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er gefüllt wurde, prüfen Sie die tatsächliche Form‑Schnittstelle, um zu erfahren, was er enthält. Spezialisi­erte Layouts können zudem [PlaceholderType::Chart](https://reference.aspose.com/slides/de/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/de/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/de/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/de/cpp/aspose.slides/placeholdertype/) oder [PlaceholderType::Diagram](https://reference.aspose.com/slides/de/cpp/aspose.slides/placeholdertype/) bereitstellen.

Aspose.Slides konvertiert einen leeren [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/)‑Platzhalter nicht in ein [IChart](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/), nur indem [IPlaceholder::get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/iplaceholder/get_type/) geändert wird; der Typ ist schreibgeschützt. Um ein leeres Diagramm‑ oder Inhaltsfeld programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters hinzu und entfernen Sie anschließend den leeren Platzhalter. Das folgende Beispiel erledigt dies für ein Diagramm:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die dedizierten [chart management articles](/slides/de/cpp/powerpoint-charts/), wenn Sie Kategorien, Reihen oder Arbeitsmappendaten ersetzen müssen.

## **Vollständiges Beispiel: Text‑ oder Bildinhalt aktualisieren**

Das folgende End‑to‑End‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Form‑Typen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel verzichtet bewusst darauf, einen Form‑Index anzunehmen oder jeden Platzhalter in dieselbe Schnittstelle zu casten:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Was ist ein Basis‑Platzhalter?**

Ein Basis‑Platzhalter ist die entsprechende Form auf dem Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/getbaseplaceholder/), um ihn abzurufen. Eine gewöhnliche lokale Form gibt `nullptr` zurück, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout vererbte Formatierungen oder Prompt‑Texte ändern, aber der vorhandene Titelinhalt ist auf den normalen Folien gespeichert. Um den tatsächlichen Titeltext in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren Sie jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fußzeilen‑Platzhalter?**

Verwenden Sie die Kopf‑ und Fußzeilen‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notizen‑ oder Handout‑Bereich. Siehe [Manage Presentation Header and Footer](/slides/de/cpp/presentation-header-and-footer/) für vollständige Beispiele.