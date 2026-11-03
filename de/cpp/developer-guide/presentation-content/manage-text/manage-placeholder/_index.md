---
title: Verwalten von Präsentationsplatzhaltern in C++
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
- Hinweistext
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text‑, Bild‑, Diagramm‑ und Inhalts‑Platzhalter untersuchen und bearbeiten sowie die Platzhalter‑Vererbung mit Aspose.Slides für C++ verstehen."
---
## **Übersicht**

Ein Platzhalter ist ein Shape, das eine Position für eine bestimmte Art von Inhalt in einer Präsentationsvorlage reserviert. Typische Beispiele sind Titel‑, Text‑, Bild‑, Diagramm‑ und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einem gewöhnlichen Shape kann ein Platzhalter seine Position, Größe, Formatierung und weitere Einstellungen von einer Layout‑Folien oder einer Master‑Folien übernehmen.

Aspose.Slides stellt Platzhalterinformationen über die [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) bereit. Die Methode gibt ein [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/)‑Objekt oder `nullptr` für ein normales Shape zurück. Verwenden Sie [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/), um zu bestimmen, welchen Inhalt der Platzhalter haben soll.

Die Shape‑Schnittstelle bleibt auch nach Kenntnis des Platzhaltertyps relevant:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird in der Regel durch ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) dargestellt.
- Ein bereits gefüllter Bild‑Platzhalter kann durch ein [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) dargestellt werden.
- Ein bereits gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann mehrere Arten von Inhalt enthalten. Prüfen Sie sowohl [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) als auch die Laufzeit‑Shape‑Schnittstelle, anstatt anzunehmen, dass jeder Platzhalter ein [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) beschreibt die Rolle eines Platzhalters; sie garantiert nicht den Laufzeit‑Typ des Shapes. Verwenden Sie stets eine Typprüfung, bevor Sie Text‑, Bild‑, Diagramm‑, Tabellen‑ oder medienspezifische Member zugreifen.
{{% /alert %}}

## **Verstehen der Platzhalter‑Vererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folien definiert wiederverwendbare Stile und, in manchen Fällen, Master‑Platzhalter.
2. Eine Layout‑Folien definiert das Layout, das von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folien enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) auf, um eine Ebene in dieser Hierarchie nach oben zu gehen. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode liefert `nullptr`, wenn das Shape keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

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

Das Bearbeiten eines Platzhalters auf einer normalen Folie erzeugt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Ein lokales normales Shape hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil es dieselben Koordinaten einnimmt.

## **Platzhalter‑Status entfernen**

Beim Anpassen einer Vorlage verwenden Sie [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/), um ein vorhandenes Objekt als gewöhnliches Shape zu behalten. Seine [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/)‑Methode liefert `nullptr`, aber das Shape bleibt in der Folien‑Sammlung. Im Gegensatz dazu löscht [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) das Shape aus dieser Sammlung.

Das folgende Beispiel erfordert `template.pptx` mit mindestens einer Folie und einem nicht leeren Text‑Platzhalter auf der ersten Folie. Verwenden Sie einen Platzhalter mit vom Layout oder Master geerbter Formatierung, um die Auswirkung der Entfernung dieser Beziehung zu sehen. Das Beispiel prüft, dass das gleiche Shape erhalten bleibt, ruft die Methode erneut auf dem nun normalen Shape auf und speichert das Ergebnis.

{{% alert color="warning" title="Warning" %}}
Das Entfernen des Platzhalter‑Status bewahrt nicht automatisch die geerbten Darstellungseinstellungen. Das nachstehende Beispiel lässt diese Einstellungen absichtlich unverändert, sodass die Ausgabe anders aussehen kann. Ein Shape, dessen Position und Größe vollständig geerbt sind, kann nach dem Aufruf Null‑Koordinaten und -Abmessungen besitzen und unsichtbar werden, obwohl es in der Sammlung bleibt.
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // Der Aufruf der Methode auf einem normalen Shape hat keine Wirkung.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

Für einen passenden Platzhalter geben alle drei Prüfungen `True` aus. Der Text bleibt erhalten, aber die geerbte Position, Größe, Drehung, Schriftart, Absatz‑Ausrichtung, Text‑Frame‑Ränder, vertikale Verankerung, Füll‑ und Linien‑Einstellungen können sich ändern, wenn die Platzhalter‑Beziehung entfernt wird. Beispielsweise kann die geerbte Titelformatierung wieder auf die normale Textformatierung zurückfallen. Siehe [Folienlayout](/slides/de/cpp/slide-layout/) für weitere Informationen zu Layouts.

Um das beabsichtigte Aussehen beizubehalten, erfassen Sie vor dem Aufruf die aufgelöste Position, Größe und Drehung und kopieren die erforderlichen effektiven Formatierungswerte in separate Variablen. Rufen Sie diese Werte über [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), und [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) ab. Verlassen Sie sich nicht ausschließlich auf die Effektiv‑Format‑Objekte, da deren Text‑Formatierungswerte sich ändern können, nachdem die Beziehung entfernt wurde. Wenden Sie die erfassten Werte anschließend explizit auf das gewöhnliche Shape an, einschließlich Schriftfamilie, Größe, Stil, Farbe, Absatz‑Einstellungen, Text‑Frame‑Einstellungen, Füll‑ und Linien‑Einstellungen, die in Ihrer Vorlage verwendet werden.

Geerbte Shape‑Geometrie muss möglicherweise ebenfalls explizit über [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/) zugewiesen werden. Für einen rechteckigen Text‑Platzhalter bedeutet dies die Zuweisung von [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); das Wiederherstellen nur von Füll‑ und Linien‑Eigenschaften stellt das sichtbare Rechteck möglicherweise nicht wieder her. Vorlagen mit zusätzlichen Effekten oder komplexerer Formatierung erfordern ebenfalls die Behandlung dieser Einstellungen.

## **Text in einem Platzhalter ändern**

Titel‑, zentrierte‑Titel‑, Untertitel‑, Text‑ und Inhalts‑Platzhalter unterstützen normalerweise Text. Prüfen Sie auf [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), bevor Sie dessen [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/)‑Methode verwenden.

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

Dieses Muster vermeidet das Casten von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern zu [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Es identifiziert den Platzhalter zudem nach Zweck statt sich auf einen anfälligen Shape‑Index zu verlassen.

## **Hinweistext in einem Layout festlegen**

Hinweistext ist die Entwurfs‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken Sie, um einen Titel hinzuzufügen*. Legen Sie benutzerdefinierten Hinweistext im Layout‑Platzhalter fest, anstatt zu versuchen, ihn über die Shape‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) auf das Layout zu und iterieren Sie über [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/).

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Hinweise im Layout, das von der ersten Folie verwendet wird:

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

Hinweistext ist kein normaler Folien‑Inhalt. Er ist für leere Platzhalter in Bearbeitungs‑Anwendungen wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt bereitstellt, wird der Hinweis nicht mehr angezeigt. Das Ändern eines Hinweises ersetzt zudem nicht den bereits vorhandenen Text auf Folien, die das Layout verwenden.

## **Bild‑Platzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bild‑Platzhalter bereits gefüllt ist und durch ein [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) dargestellt wird, ersetzen Sie das Bild mittels [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) und [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie an den Koordinaten des Platzhalters einen Bild‑Frame mit [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) hinzu und entfernen den leeren Platzhalter.

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

Der für einen leeren Platzhalter erstellte Ersatz ist ein lokaler Bild‑Frame, kein neuer Platzhalter, da [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) schreibgeschützt ist. Er bewahrt die reservierte Position, erbt jedoch nicht mehr das platzhalterspezifische Verhalten. Wenn das Beibehalten der Platzhalter‑Beziehung essenziell ist, erstellen und füllen Sie den Platzhalter zunächst in PowerPoint und aktualisieren anschließend das resultierende [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) mit Aspose.Slides.

Für Bild‑Transparenz, Zuschneiden und andere bild‑spezifische Effekte siehe [Bildrahmen verwalten](/slides/de/cpp/picture-frame/). Diese Vorgänge gehören zum Bildrahmen bzw. Bild‑Füllbereich, nicht zu den Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhalts‑Platzhaltern**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl nach Platzhaltertyp als auch nach Laufzeit‑Schnittstelle, ändert dessen Titel und speichert die Datei:

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

Ein allgemeiner Inhalts‑Platzhalter hat in der Regel [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). In PowerPoint dient er als Starter für mehrere Inhaltstypen, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er gefüllt wurde, prüfen Sie die tatsächliche Shape‑Schnittstelle, um zu erfahren, was er enthält. Spezialisierte Layouts können außerdem [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) oder [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) bereitstellen.

Aspose.Slides konvertiert einen leeren [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)‑Platzhalter nicht in ein [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/), allein durch Ändern von [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/); der Typ ist schreibgeschützt. Um ein leeres Diagramm‑ oder Inhalts‑Bereich programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters ein und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel erledigt dies für ein Diagramm:

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

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die speziellen [Diagramm‑Verwaltungsartikel](/slides/de/cpp/powerpoint-charts/), wenn Sie dessen Kategorien, Serien oder Arbeitsblattdaten ersetzen müssen.

## **Komplettbeispiel: Text‑ oder Bildinhalt aktualisieren**

Das folgende End‑to‑End‑Beispiel öffnet eine Vorlage, sucht auf der ersten Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Shape‑Typen, aktualisiert den entsprechenden Inhalt und speichert die Ausgabe. Das Beispiel vermeidet bewusst die Annahme eines Shape‑Index oder das Casten jedes Platzhalters zur gleichen Schnittstelle.

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

Ein Basis‑Platzhalter ist das entsprechende Shape im Layout oder Master, von dem ein anderer Platzhalter erbt. Verwenden Sie [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/), um ihn abzurufen. Ein gewöhnliches lokales Shape liefert `nullptr`, weil es nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout die vererbte Formatierung oder den Hinweistext ändern, aber der vorhandene Titelinhalt ist auf den normalen Folien gespeichert. Um den tatsächlichen Titeltext einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummern‑, Kopf‑ und Fußzeilen‑Platzhalter?**

Verwenden Sie die Kopf‑ und Fußzeilen‑Manager im entsprechenden Folien‑, Layout‑, Master‑, Notizen‑ oder Handout‑Umfang. Siehe [Präsentationskopf‑ und -fußzeilen verwalten](/slides/de/cpp/presentation-header-and-footer/) für vollständige Beispiele.