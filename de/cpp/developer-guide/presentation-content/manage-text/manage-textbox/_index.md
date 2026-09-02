---
title: Verwalten von Textfeldern in Präsentationen mit C++
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
description: "Aspose.Slides für C++ erleichtert das Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert die Automatisierung Ihrer Präsentationen."
---
## **Einführung**

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um Text zu einer Folie hinzuzufügen, ein Textfeld hinzufügen und dann Text in das Textfeld einfügen. Aspose.Slides für C++ stellt die [IAutoShape](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_auto_shape) Schnittstelle bereit, die es Ihnen ermöglicht, eine Form mit Text hinzuzufügen.

{{% alert title="Info" color="info" %}}
Aspose.Slides stellt außerdem die [IShape](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_shape) Schnittstelle bereit, mit der Sie Formen zu Folien hinzufügen können. Allerdings können nicht alle über die `IShape`‑Schnittstelle hinzugefügten Formen Text enthalten. Formen, die über die [IAutoShape](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_auto_shape) Schnittstelle hinzugefügt werden, können jedoch Text enthalten. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Daher sollten Sie, wenn Sie mit einer Form arbeiten, zu der Sie Text hinzufügen möchten, überprüfen und bestätigen, dass sie über die `IAutoShape`‑Schnittstelle gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.text_frame) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/de/cpp/manage-textbox/#update-text) auf dieser Seite. 
{{% /alert %}}

## **Ein Textfeld auf einer Folie erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation). 
2. Holen Sie sich eine Referenz auf die erste Folie der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_auto_shape)‑Objekt mit [ShapeType](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie die Referenz auf das neu hinzugefügte `IAutoShape`‑Objekt. 
4. Fügen Sie dem `IAutoShape`‑Objekt die `TextFrame`‑Eigenschaft hinzu, die einen Text enthält. Im folgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Schließlich schreiben Sie die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser C++‑Code – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie man Text zu einer Folie hinzufügt:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Erzeugt eine Präsentation
auto pres = System::MakeObject<Presentation>();

// Liest die erste Folie der Präsentation
auto sld = pres->get_Slides()->idx_get(0);

// Fügt ein AutoShape mit dem Typ Rechteck hinzu
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Fügt dem Rechteck einen TextFrame hinzu
ashp->AddTextFrame(u" ");

// Greift auf den TextFrame zu
auto txtFrame = ashp->get_TextFrame();

// Erstellt das Paragraph-Objekt für den TextFrame
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Erstellt ein Portion-Objekt für den Paragraphen
auto portion = para->get_Portions()->idx_get(0);

// Setzt den Text
portion->set_Text(u"Aspose TextBox");

// Speichert die Präsentation auf dem Datenträger
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Überprüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die Methode [get_IsTextBox](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/get_istextbox/) aus der [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/)‑Schnittstelle bereit, mit der Sie Formen untersuchen und Textfelder identifizieren können.

![Textfeld und Form](istextbox.png)

Dieser C++‑Code zeigt, wie Sie prüfen können, ob eine Form als Textfeld erstellt wurde: 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Beachten Sie, dass, wenn Sie einfach ein AutoShape mithilfe der `AddAutoShape`‑Methode aus der [IShapeCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/)‑Schnittstelle hinzufügen, die `get_IsTextBox`‑Methode des AutoShape `false` zurückgibt. Nachdem Sie jedoch Text zum AutoShape mit der `AddTextFrame`‑Methode oder der `set_Text`‑Methode hinzugefügt haben, gibt die `get_IsTextBox`‑Methode `true` zurück.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() liefert false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() liefert true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() liefert false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() liefert true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() liefert false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() liefert false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() liefert false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() liefert false
```

## **Die Form finden, die einen TextFrame besitzt**

In generischem Textverarbeitungs‑Code können Sie ein [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) erhalten, ohne bereits zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentshape/), um zur übergeordneten [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) zurückzukehren.

Für einen TextFrame, der zu einer [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) oder einer anderen text‑enthaltenden Form gehört, gibt [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentshape/) den Besitzer zurück und [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_parentcell/) liefert `nullptr`. Beide Methoden bieten nur Lese‑Navigation, sodass ihr Aufruf den Besitz nicht ändert. Überprüfen Sie immer den zurückgegebenen Wert auf `nullptr`, bevor Sie auf die Form zugreifen.

Ein vollständiges Beispiel, das Form‑ und Tabellenzellen‑Besitzer identifiziert, einschließlich Formen, die mit SmartArt‑Knoten verbunden sind, finden Sie unter [Search and Replace Text](/slides/de/cpp/search-and-replace-text/).

## **Spalten zu einem Textfeld hinzufügen**

Aspose.Slides stellt die Methoden [set_ColumnCount](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) und [set_ColumnSpacing](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (aus der [ITextFrameFormat](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_text_frame_format)-Schnittstelle und der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_text_frame_format)) bereit, mit denen Sie Textfeldern Spalten hinzufügen können. Sie können die Anzahl der Spalten in einem Textfeld festlegen und den Abstand in Punkten zwischen den Spalten bestimmen. 

Dieser C++‑Code demonstriert die beschriebene Vorgehensweise: 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// Liest die erste Folie der Präsentation
auto slide = presentation->get_Slides()->idx_get(0);

// Fügt ein AutoShape mit dem Typ Rechteck hinzu
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Fügt dem Rechteck einen TextFrame hinzu
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Liest das Textformat des TextFrames
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Legt die Anzahl der Spalten im TextFrame fest
format->set_ColumnCount(3);

// Legt den Abstand zwischen den Spalten fest
format->set_ColumnSpacing(10);

// Speichert die Präsentation
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Spalten zu einem TextFrame hinzufügen**

Aspose.Slides für C++ bietet die Methode [set_ColumnCount](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (aus der [ITextFrameFormat](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_text_frame_format)-Schnittstelle) an, mit der Sie Spalten in TextFrames hinzufügen können. Mit dieser Methode können Sie die gewünschte Spaltenzahl in einem TextFrame festlegen. 

Dieser C++‑Code zeigt, wie Sie einer TextFrame eine Spalte hinzufügen:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Text aktualisieren**

Aspose.Slides ermöglicht es Ihnen, den Text in einem Textfeld oder alle Texte in einer Präsentation zu ändern oder zu aktualisieren. 

Dieser C++‑Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert bzw. geändert werden:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //Ändert den Text
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Ändert die Formatierung
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Speichert die geänderte Präsentation
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Ein Textfeld mit Hyperlink hinzufügen**

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, wird der Benutzer zum Öffnen des Links weitergeleitet. 

Um ein Textfeld mit einem Link hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse `Presentation`. 
2. Holen Sie sich eine Referenz auf die erste Folie der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape`‑Objekt mit `ShapeType` auf `Rectangle` an einer angegebenen Position auf der Folie hinzu und erhalten Sie eine Referenz auf das neu hinzugefügte AutoShape‑Objekt.
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die Klasse `IHyperlinkManager`. 
6. Weisen Sie das `IHyperlinkManager`‑Objekt der Methode [set_HyperlinkClick](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) zu, die dem gewünschten Teil des `TextFrame` zugeordnet ist. 
7. Schließlich schreiben Sie die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser C++‑Code – eine Umsetzung der obigen Schritte – zeigt, wie Sie ein Textfeld mit Hyperlink zu einer Folie hinzufügen:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instanziert eine Presentation‑Klasse, die ein PPTX darstellt
auto presentation = System::MakeObject<Presentation>();

// Liest die erste Folie der Präsentation
auto slide = presentation->get_Slides()->idx_get(0);

// Fügt ein AutoShape‑Objekt mit dem Typ Rechteck hinzu
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Wandelt die Form in ein AutoShape um
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Greift auf die ITextFrame‑Eigenschaft zu, die dem AutoShape zugeordnet ist
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Fügt dem Frame etwas Text hinzu
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Setzt den Hyperlink für den Portion‑Text
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Speichert die PPTX‑Präsentation
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [Platzhalter](/slides/de/cpp/manage-placeholder/) erbt Stil/Position vom [Master](https://reference.aspose.com/slides/de/cpp/aspose.slides/masterslide/) und kann auf [Layouts](https://reference.aspose.com/slides/de/cpp/aspose.slides/layoutslide/) überschrieben werden, während ein reguläres Textfeld ein unabhängiges Objekt auf einer konkreten Folie ist und sich beim Wechseln von Layouts nicht ändert.

**Wie kann ich einen massiven Textaustausch in der gesamten Präsentation durchführen, ohne Text in Diagrammen, Tabellen und SmartArt zu verändern?**

Beschränken Sie Ihre Iteration auf AutoShapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([Charts](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chart/), [Tables](https://reference.aspose.com/slides/de/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.