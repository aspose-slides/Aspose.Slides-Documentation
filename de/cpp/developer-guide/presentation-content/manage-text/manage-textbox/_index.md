---
title: TextBox verwalten
type: docs
weight: 20
url: /de/cpp/manage-textbox/
keywords: "Textbox, Textfeld, Textbox hinzufügen, Textbox mit Hyperlink, C++, Aspose.Slides für C++"
description: "Fügen Sie Textbox oder Textfeld in PowerPoint-Präsentationen in C++ hinzu"
---

Texte auf Folien existieren typischerweise in Textfeldern oder Formen. Um also Text zu einer Folie hinzuzufügen, müssen Sie ein Textfeld hinzufügen und dann etwas Text in das Textfeld einfügen. Aspose.Slides für C++ bietet das [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) Interface, das es Ihnen ermöglicht, eine Form mit etwas Text hinzuzufügen.

{{% alert title="Info" color="info" %}}

Aspose.Slides bietet auch das [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) Interface, mit dem Sie Formen zu Folien hinzufügen können. Allerdings können nicht alle über das `IShape` Interface hinzugefügten Formen Text halten. Formen, die über das [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) Interface hinzugefügt werden, können jedoch Text enthalten.

{{% /alert %}}

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie daher mit einer Form umgehen, zu der Sie Text hinzufügen möchten, sollten Sie überprüfen und bestätigen, dass sie durch das `IAutoShape` Interface gecastet wurde. Nur dann können Sie mit dem [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) arbeiten, der eine Eigenschaft unter `IAutoShape` ist. Siehe den Abschnitt [Text aktualisieren](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) auf dieser Seite.

{{% /alert %}}

## **Textfeld auf Folie erstellen**

Um ein Textfeld auf einer Folie zu erstellen, gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse. 
2. Erhalten Sie eine Referenz für die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) Objekt mit [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) als `Rectangle` an einer bestimmten Position auf der Folie hinzu und erhalten Sie die Referenz für das neu hinzugefügte `IAutoShape` Objekt. 
4. Fügen Sie der `IAutoShape` Objekt eine `TextFrame` Eigenschaft hinzu, die einen Text enthält. Im folgenden Beispiel haben wir diesen Text hinzugefügt: *Aspose TextBox*
5. Schließlich speichern Sie die PPTX-Datei über das `Presentation` Objekt.

Dieser C++ Code – eine Implementierung der obigen Schritte – zeigt Ihnen, wie Sie Text zu einer Folie hinzufügen:

```cpp
// Instanziiert die Präsentation
auto pres = System::MakeObject<Presentation>();

// Holt die erste Folie in der Präsentation
auto sld = pres->get_Slides()->idx_get(0);

// Fügt eine AutoShape mit typ als Rechteck hinzu
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Fügt TextFrame zum Rechteck hinzu
ashp->AddTextFrame(u" ");

// Greift auf das Textfeld zu
auto txtFrame = ashp->get_TextFrame();

// Erstellt das Paragraph-Objekt für das Textfeld
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Erstellt ein Portion-Objekt für den Absatz
auto portion = para->get_Portions()->idx_get(0);

// Setzt den Text
portion->set_Text(u"Aspose TextBox");

// Speichert die Präsentation auf der Festplatte
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Überprüfen, ob es sich um eine Textfeldform handelt**

Aspose.Slides bietet die [get_IsTextBox()](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) Methode (aus der [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) Klasse), mit der Sie Formen untersuchen und Textfelder finden können.

![Textfeld und Form](istextbox.png)

Dieser C++ Code zeigt Ihnen, wie Sie überprüfen können, ob eine Form als Textfeld erstellt wurde: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
for (auto&& slide : pres->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        auto autoShape = System::DynamicCast_noexcept<Aspose::Slides::AutoShape>(shape);
        if (autoShape != nullptr)
        {
            System::Console::WriteLine(autoShape->get_IsTextBox() ? System::String(u"Form ist ein Textfeld") : System::String(u"Form ist kein Textfeld"));
        }
    }
}
```

## **Spalte im Textfeld hinzufügen**

Aspose.Slides bietet die [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) und [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) Methoden (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) Interface und der [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) Klasse), die es Ihnen ermöglichen, Spalten zu Textfeldern hinzuzufügen. Sie können die Anzahl der Spalten in einem Textfeld angeben und den Abstand in Punkten zwischen den Spalten festlegen.

Dieser C++ Code demonstriert die beschriebene Operation: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Holt die erste Folie in der Präsentation
auto slide = presentation->get_Slides()->idx_get(0);

// Fügt eine AutoShape mit typ als Rechteck hinzu
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Fügt TextFrame zum Rechteck hinzu
aShape->AddTextFrame(String(u"Alle diese Spalten sind darauf beschränkt, innerhalb eines einzigen Textrahmens zu bleiben -- ") 
    + u" Sie können Text hinzufügen oder löschen, und der neue oder verbleibende Text passt sich automatisch " 
    + u"an, um im Rahmen zu fließen. Sie können keinen Text von einem Rahmen " 
    + u"zu einem anderen fließen lassen -- wir haben Ihnen gesagt, dass die Spaltenoptionen für Texte in PowerPoint eingeschränkt sind!");

// Holt das Textformat des TextFrames
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Gibt die Anzahl der Spalten im TextFrame an
format->set_ColumnCount(3);

// Gibt den Abstand zwischen den Spalten an
format->set_ColumnSpacing(10);

// Speichert die Präsentation
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Spalte im Textfeld hinzufügen**

Aspose.Slides für C++ bietet die [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) Methode (aus dem [ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) Interface), die es Ihnen ermöglicht, Spalten in Textfeldern hinzuzufügen. Mit dieser Methode können Sie Ihre bevorzugte Anzahl von Spalten in einem Textfeld angeben.

Dieser C++ Code zeigt Ihnen, wie Sie eine Spalte innerhalb eines Textfeldes hinzufügen:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"Alle diese Spalten sind gezwungen, innerhalb eines einzigen Textrahmens zu bleiben -- ") 
    + u" Sie können Text hinzufügen oder löschen - und der neue oder verbleibende Text passt sich automatisch " 
    + u"an, um im Rahmen zu bleiben. Sie können keinen Text von einem Rahmen " 
    + u"zu einem anderen fließen lassen, obwohl -- weil die Spaltenoptionen für Texte in PowerPoint eingeschränkt sind!");
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

Aspose.Slides ermöglicht es Ihnen, den Text in einem Textfeld oder allen Texten in einer Präsentation zu ändern oder zu aktualisieren.

Dieser C++ Code demonstriert einen Vorgang, bei dem alle Texte in einer Präsentation aktualisiert oder geändert werden:

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
                    //Ändert den Text
                    portion->set_Text(portion->get_Text().Replace(u"Jahre", u"Monate"));
                    //Ändert das Format
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Speichert die geänderte Präsentation
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Textbox mit Hyperlink hinzufügen**

Sie können einen Link in ein Textfeld einfügen. Wenn das Textfeld angeklickt wird, werden die Benutzer auf den Link weitergeleitet.

Um ein Textfeld hinzuzufügen, das einen Link enthält, gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der `Presentation` Klasse. 
2. Erhalten Sie eine Referenz für die erste Folie in der neu erstellten Präsentation. 
3. Fügen Sie ein `AutoShape` Objekt mit `ShapeType` als `Rectangle` an einer bestimmten Position auf der Folie hinzu und erhalten Sie eine Referenz für das neu hinzugefügte AutoShape Objekt.
4. Fügen Sie dem `AutoShape` Objekt ein `TextFrame` hinzu, das *Aspose TextBox* als Standardtext enthält. 
5. Instanziieren Sie die `IHyperlinkManager` Klasse. 
6. Weisen Sie das `IHyperlinkManager` Objekt der [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) Methode zu, die mit Ihrem bevorzugten Abschnitt des `TextFrame` verknüpft ist. 
7. Schließlich schreiben Sie die PPTX-Datei über das `Presentation` Objekt.

Dieser C++ Code – eine Implementierung der oben beschriebenen Schritte – zeigt Ihnen, wie Sie ein Textfeld mit einem Hyperlink zu einer Folie hinzufügen:

```cpp
// Instanziiert eine Präsentationsklasse, die eine PPTX darstellt
auto presentation = System::MakeObject<Presentation>();

// Holt die erste Folie in der Präsentation
auto slide = presentation->get_Slides()->idx_get(0);

// Fügt ein AutoShape Objekt mit typ als Rechteck hinzu
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Castet die Form in AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Greift auf die ITextFrame Eigenschaft zu, die mit dem AutoShape verbunden ist
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Fügt dem Rahmen etwas Text hinzu
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Setzt den Hyperlink für den Portiontext
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Speichert die PPTX-Präsentation
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```