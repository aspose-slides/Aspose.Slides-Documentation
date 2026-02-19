---
title: Textfeld
type: docs
weight: 40
url: /de/cpp/examples/elements/text-box/
keywords:
- Codebeispiel
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Arbeiten Sie mit Textfeldern in Aspose.Slides für C++: Text hinzufügen, formatieren, ausrichten, umbrechen, automatisch anpassen und gestalten für PPT-, PPTX- und ODP-Präsentationen."
---
In Aspose.Slides wird ein **Textfeld** durch ein `AutoShape` dargestellt. Fast jede Form kann Text enthalten, aber ein typisches Textfeld hat keine Füllung oder Kontur und zeigt nur Text an.

Dieser Leitfaden erklärt, wie man Textfelder programmgesteuert hinzufügt, darauf zugreift und sie entfernt.

## **Textfeld hinzufügen**

Ein Textfeld ist einfach ein `AutoShape` ohne Füllung oder Kontur und mit etwas formatiertem Text. So erstellen Sie eines:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Erstelle eine Rechteckform (standardmäßig gefüllt mit Rand und ohne Text).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Entferne Füllung und Rand, damit es wie ein typisches Textfeld aussieht.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Setze Textformatierung.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Weise den tatsächlichen Textinhalt zu.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Hinweis:** Jedes `AutoShape`, das ein nicht leeres `TextFrame` enthält, kann als Textfeld fungieren.

## **Zugriff auf Textfelder nach Inhalt**

Um alle Textfelder zu finden, die ein bestimmtes Schlüsselwort enthalten (z. B. „Slide“), iterieren Sie über die Formen und prüfen deren Text:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Nur AutoShapes können editierbaren Text enthalten.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Etwas mit dem passenden Textfeld tun.
            }
        }
    }

    presentation->Dispose();
}
```

## **Textfelder nach Inhalt entfernen**

Dieses Beispiel findet und löscht alle Textfelder auf der ersten Folie, die ein bestimmtes Schlüsselwort enthalten:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Tipp:** Erstellen Sie immer eine Kopie der Formensammlung, bevor Sie sie während der Iteration ändern, um Fehler bei der Modifikation der Sammlung zu vermeiden.