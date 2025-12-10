---
title: Textfelder in Präsentationen mit C++
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
description: "Aspose.Slides für C++ ermöglicht das einfache Erstellen, Bearbeiten und Klonen von Textfeldern in PowerPoint- und OpenDocument-Dateien und verbessert Ihre Präsentationsautomatisierung."
---

Texte auf Folien befinden sich typischerweise in Textfeldern oder Formen. Daher müssen Sie, um einen Text zu einer Folie hinzuzufügen, ein Textfeld einfügen und dann etwas Text in das Textfeld setzen. Aspose.Slides für C++ stellt die [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)-Schnittstelle bereit, die es ermöglicht, eine Form mit Text hinzuzufügen.

{{% alert title="Info" color="info" %}}

Aspose.Slides bietet außerdem die [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)-Schnittstelle, mit der Sie Formen zu Folien hinzufügen können. Nicht alle über die `IShape`-Schnittstelle hinzugefügten Formen können jedoch Text enthalten. Formen, die über die [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)-Schnittstelle hinzugefügt werden, können Text enthalten. 

{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie also mit einer Form arbeiten, zu der Sie Text hinzufügen möchten, sollten Sie prüfen und bestätigen, dass sie über die `IAutoShape`-Schnittstelle gecastet wurde. Nur dann können Sie mit [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) arbeiten, das eine Eigenschaft von `IAutoShape` ist. Siehe den Abschnitt [Update Text](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) auf dieser Seite. 

{{% /alert %}}

## **Ein Textfeld auf einer Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse. 
2. Holen Sie sich eine Referenz für die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape)-Objekt mit [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) = `Rectangle` an einer bestimmten Position auf der Folie hinzu und erhalten Sie die Referenz für das neu hinzugefügte `IAutoShape`-Objekt. 
4. Fügen Sie dem `IAutoShape`-Objekt die `TextFrame`-Eigenschaft hinzu, die einen Text enthält. Im Beispiel unten fügen wir diesen Text ein: *Aspose TextBox* 
5. Schreiben Sie abschließend die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser C++‑Code – eine Umsetzung der oben genannten Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:
```cpp
// Erstellt eine Präsentation
auto pres = System::MakeObject<Presentation>();

// Holt die erste Folie in der Präsentation
auto sld = pres->get_Slides()->idx_get(0);

// Fügt eine AutoShape mit dem Typ Rechteck hinzu
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Fügt dem Rechteck ein TextFrame hinzu
ashp->AddTextFrame(u" ");

// Greift auf das TextFrame zu
auto txtFrame = ashp->get_TextFrame();

// Erstellt das Paragraph-Objekt für das TextFrame
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Erstellt ein Portion-Objekt für den Absatz
auto portion = para->get_Portions()->idx_get(0);

// Setzt den Text
portion->set_Text(u"Aspose TextBox");

// Speichert die Präsentation auf dem Datenträger
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```


## **Prüfen, ob eine Form ein Textfeld ist**

Aspose.Slides stellt die Methode [get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) der [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)-Schnittstelle zur Verfügung, mit der Sie Formen untersuchen und Textfelder identifizieren können.

![Text box and shape](istextbox.png)

Dieser C++‑Code zeigt Ihnen, wie Sie prüfen, ob eine Form als Textfeld erstellt wurde: 
```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
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


Beachten Sie, dass die `get_IsTextBox`‑Methode eines über die `AddAutoShape`‑Methode der [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/)-Schnittstelle hinzugefügten AutoShape `false` zurückgibt. Nachdem Sie jedoch Text über die `AddTextFrame`‑Methode oder die `set_Text`‑Methode hinzugefügt haben, liefert `get_IsTextBox` `true`. 
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() gibt false zurück
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() gibt true zurück

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() gibt false zurück
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() gibt true zurück

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() gibt false zurück
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() gibt false zurück

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() gibt false zurück
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() gibt false zurück
```


## **Spalten zu einem Textfeld hinzufügen**

Aspose.Slides bietet die Methoden [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) und [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (aus der [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)-Schnittstelle und der Klasse [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)), mit denen Sie Spalten zu Textfeldern hinzufügen können. Sie können die Anzahl der Spalten und den Abstand in Punkten zwischen den Spalten festlegen. 

Dieser C++‑Code demonstriert die beschriebene Operation: 
```cpp
auto presentation = System::MakeObject<Presentation>();
// Holt die erste Folie in der Präsentation
auto slide = presentation->get_Slides()->idx_get(0);

// Fügt eine AutoShape mit dem Typ Rechteck hinzu
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Fügt dem Rechteck ein TextFrame hinzu
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Holt das Textformat des TextFrames
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Legt die Anzahl der Spalten im TextFrame fest
format->set_ColumnCount(3);

// Legt den Abstand zwischen den Spalten fest
format->set_ColumnSpacing(10);

// Speichert die Präsentation
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **Spalten zu einem Textframe hinzufügen**

Aspose.Slides für C++ stellt die Methode [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) der [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format)-Schnittstelle zur Verfügung, mit der Sie Spalten in Textframes hinzufügen können. Über diese Methode können Sie die gewünschte Spaltenzahl in einem Textframe festlegen. 

Dieser C++‑Code zeigt Ihnen, wie Sie eine Spalte in einem Textframe hinzufügen:
```cpp
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

Dieser C++‑Code demonstriert eine Operation, bei der alle Texte in einer Präsentation aktualisiert werden:
```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Ändert Text
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Ändert Formatierung
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Speichert geänderte Präsentation
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```


## **Ein Textfeld mit Hyperlink hinzufügen** 

Sie können einen Link in ein Textfeld einfügen. Beim Anklicken des Textfelds wird der Link geöffnet. 

So fügen Sie ein Textfeld mit einem Link hinzu:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse. 
2. Holen Sie sich eine Referenz für die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape`‑Objekt mit `ShapeType` = `Rectangle` an einer bestimmten Position auf der Folie hinzu und erhalten Sie die Referenz des neu hinzugefügten AutoShape‑Objekts. 
4. Fügen Sie dem `AutoShape`‑Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die `IHyperlinkManager`‑Klasse. 
6. Weisen Sie das `IHyperlinkManager`‑Objekt der [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c)-Methode zu, die mit dem von Ihnen gewünschten Teil des `TextFrame` verbunden ist. 
7. Schreiben Sie abschließend die PPTX‑Datei über das `Presentation`‑Objekt. 

Dieser C++‑Code – eine Umsetzung der obigen Schritte – zeigt Ihnen, wie Sie ein Textfeld mit Hyperlink zu einer Folie hinzufügen:
```cpp
// Instanziert eine Presentation-Klasse, die eine PPTX repräsentiert
auto presentation = System::MakeObject<Presentation>();

// Holt die erste Folie in der Präsentation
auto slide = presentation->get_Slides()->idx_get(0);

// Fügt ein AutoShape-Objekt mit dem Typ Rectangle hinzu
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Castet das Shape zu AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Greift auf die ITextFrame‑Eigenschaft der AutoShape zu
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Fügt dem TextFrame Text hinzu
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Setzt den Hyperlink für den Portion‑Text
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Speichert die PPTX‑Präsentation
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Was ist der Unterschied zwischen einem Textfeld und einem Text‑Platzhalter bei der Arbeit mit Master‑Folien?**

Ein [placeholder](/slides/de/cpp/manage-placeholder/) erbt Stil/Position vom [master](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) und kann in [layouts](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) überschrieben werden, während ein normales Textfeld ein unabhängiges Objekt auf einer konkreten Folie ist und sich beim Wechseln von Layouts nicht ändert.

**Wie kann ich einen großen Text‑Ersetzungsvorgang in der gesamten Präsentation durchführen, ohne Texte in Diagrammen, Tabellen und SmartArt zu berühren?**

Beschränken Sie die Iteration auf Auto‑Shapes, die TextFrames besitzen, und schließen Sie eingebettete Objekte ([charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) aus, indem Sie deren Sammlungen separat durchlaufen oder diese Objekttypen überspringen.