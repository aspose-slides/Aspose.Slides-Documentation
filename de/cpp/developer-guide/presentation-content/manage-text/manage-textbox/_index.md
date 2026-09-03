---
title: Textfelder in Präsentationen mit C++ verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/cpp/manage-textbox/
keywords:
- Textfeld
- Textrahmen
- Text hinzufügen
- Text aktualisieren
- Textfeld erstellen
- Textfeld prüfen
- Textspalte hinzufügen
- Hyperlink hinzufügen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Textfelder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ erstellen, identifizieren, formatieren und aktualisieren."
---
## **Einleitung**

In Aspose.Slides für C++ wird der Folientext in Textfeldern gespeichert, die zu Formen gehören. Das [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) Interface repräsentiert die am häufigsten vorkommende texttragende Form und stellt ihren Text über die [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/get_textframe/) Methode bereit.

{{% alert color="info" title="Note" %}}

Jede Autoform implementiert [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/), aber nicht jede Form ist eine Autoform oder unterstützt ein Textfeld. Beim Verarbeiten einer vorhandenen Präsentation sollte geprüft werden, ob eine Form [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) implementiert, bevor auf ihren Text zugegriffen wird.

{{% /alert %}}

## **Eine Textbox auf einer Folie erstellen**

Um eine Textbox zu erstellen, fügen Sie einer Folie eine Autoform hinzu, fügen Sie ihrem Textfeld Text hinzu und speichern Sie die Präsentation. Das folgende Beispiel erstellt eine rechteckige Textbox:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

Die an [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addautoshape/) übergebenen Koordinaten und Abmessungen werden in Punkten gemessen. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/addtextframe/) initialisiert das Textfeld mit dem angegebenen Text.

## **Überprüfen, ob eine Form eine Textbox ist**

Verwenden Sie die Methode [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/get_istextbox/), um zu bestimmen, ob eine Autoform als Textbox behandelt wird. Dies ist nützlich, wenn eine Präsentation sowohl texttragende als auch rein grafische Autoformen enthält.

![Eine Textbox und eine Form](istextbox.png)

Das folgende Beispiel untersucht jede Autoform in einer Präsentation:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Eine neu hinzugefügte Autoform wird erst dann als Textbox betrachtet, wenn sie nicht leeren Text enthält. Sie können diesen Text über [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/addtextframe/) oder [ITextFrame::set_Text](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/set_text/) bereitstellen. Das Hinzufügen oder Zuweisen einer leeren Zeichenkette lässt [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/get_istextbox/) `false` zurückgeben:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

Die ersten beiden Prüfungen geben `true` zurück; die letzten beiden geben `false` zurück.

## **Finden Sie die Form, die ein Textfeld besitzt**

Generischer Textverarbeitungscode kann ein [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) erhalten, ohne zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die Methode [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentshape/), um zurück zur zugehörigen [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) zu navigieren.

Für ein Textfeld, das einer Autoform oder einer anderen texttragenden Form gehört, gibt [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentshape/) den Besitzer zurück und [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentcell/) liefert `nullptr`. Beide Methoden bieten eine nur lesbare Navigation. Prüfen Sie den zurückgegebenen Wert auf `nullptr`, bevor Sie darauf zugreifen. Um sowohl Form- als auch Tabellenzellenbesitzer zu identifizieren, einschließlich Formen, die mit SmartArt‑Knoten verknüpft sind, siehe [Search and Replace Text](/slides/de/cpp/search-and-replace-text/).

## **Spalten zu einer Textbox hinzufügen**

Die Methode [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_columncount/) teilt das Textfeld in Spalten auf, während [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_columnspacing/) den Abstand zwischen den Spalten in Punkten festlegt. Beide Methoden gehören zu [ITextFrameFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/) und können über das Textfeld einer vorhandenen Textbox aufgerufen werden. Der Text fließt zwischen den Spalten innerhalb derselben Form um; er wird nicht in eine andere Form fortgesetzt.

Das folgende Beispiel erstellt eine dreispaltige Textbox mit 10 Punkten Abstand zwischen den Spalten, speichert die Präsentation und liest die gespeicherten Einstellungen aus der Ausgabedatei zurück:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Text aus einzelnen Spalten extrahieren**

Verwenden Sie [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/splittextbycolumns/), um den Text abzurufen, der jeder visuellen Spalte in einem bestehenden Textfeld zugewiesen ist. Die Methode gibt für jede Spalte einen String in spaltenbasierter Lesereihenfolge zurück. Ein einspaltiges Textfeld erzeugt ein Array mit einem Element, und eine leere Spalte wird durch einen leeren String dargestellt. Die Strings enthalten ausschließlich reinen Text; Formatierungen auf Portionsebene werden nicht beibehalten.

Dies ist nützlich, wenn Sie:

- Text extrahieren und dabei die spaltenbasierte Lesereihenfolge beibehalten.
- Den Inhalt von Folien mit mehreren Spalten indexieren oder vergleichen.
- Jede Spalte in eine separate Datei, Datenbankfeld oder ein anderes Ziel exportieren.
- Untersuchen, wie Text nach dem Festlegen der Spaltenzahl mit [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_columncount/) oder des Abstands mit [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_columnspacing/) bzw. nach Änderungen der Schriftart oder der Größe des Textfeldes umverteilt wird.

Die Methode gibt den im aktuellen [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) verteilten Text zurück; sie lässt Text nicht automatisch zwischen separaten Formen oder Textboxen fließen. Die Spaltenverteilung kann von verfügbaren Schriftarten und anderen Textlayout‑Einstellungen abhängen, daher sollten die erforderlichen Schriftarten vorhanden sein, wenn konsistente Ergebnisse wichtig sind.

Das folgende Beispiel lädt eine Präsentation, findet die erste mehrspaltige Autoform mit einem Textfeld auf der ersten Folie, liest die konfigurierte Spaltenzahl und schreibt den Text jeder Spalte in eine separate Datei. Formen, die kein Textfeld bereitstellen, werden übersprungen.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Text aktualisieren**

Um Text in einer gesamten Präsentation zu aktualisieren, iterieren Sie über die Folien und Formen, wählen Autoformen aus und bearbeiten anschließend deren Textabschnitte. Das Arbeiten auf Abschnittsebene ermöglicht es, sowohl den Text als auch die Zeichenformatierung zu ändern.

Das folgende Beispiel ersetzt jedes Vorkommen von `years` durch `months` in einzelnen Textabschnitten von Autoformen und macht jeden betroffenen Abschnitt fett:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Diese Durchlauf aktualisiert Text nur in Autoformen. In Tabellen, Diagrammen, SmartArt oder Gruppierungen gespeicherter Text erfordert das Durchlaufen der jeweiligen Objekt­sammlungen.

## **Eine Textbox mit Hyperlink hinzufügen**

Einem bestimmten Textabschnitt kann ein Hyperlink zugewiesen werden, sodass nur dieser Text als anklickbarer Link fungiert. Verwenden Sie [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/de/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), um den Abschnitt mit einer externen URL zu verknüpfen.

Das folgende Beispiel erstellt verknüpften Text und speichert ihn in einer Präsentation:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Was ist der Unterschied zwischen einer Textbox und einem Textplatzhalter auf einer Master‑ oder Layoutfolie?**

Ein [placeholder](/slides/de/cpp/manage-placeholder/) kann seine Position und Formatierung von einer [master slide](https://reference.aspose.com/slides/de/cpp/aspose.slides/masterslide/) oder [layout slide](https://reference.aspose.com/slides/de/cpp/aspose.slides/layoutslide/) übernehmen. Eine normale Textbox ist eine eigenständige Form auf der Folie, auf der sie erstellt wurde, und übernimmt kein Platzhalter‑Verhalten, wenn sich das Layout ändert.

**Wie kann ich Text ersetzen, ohne den Text in Diagrammen, Tabellen oder SmartArt zu ändern?**

Beschränken Sie die Durchlauf auf Formen, die [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) implementieren, wie im Beispiel zum Aktualisieren von Text gezeigt. Diagramme, Tabellen und SmartArt speichern Text in ihren eigenen Objektmodellen, sodass sie durch diese Schleife nicht verändert werden.