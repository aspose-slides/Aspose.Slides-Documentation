---
title: Hyperlink
type: docs
weight: 130
url: /de/cpp/examples/elements/hyperlink/
keywords:
- Codebeispiel
- Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Hyperlinks in Aspose.Slides für C++ hinzufügen und verwalten: Text, Formen und Bilder verlinken, Ziele und Aktionen für PPT, PPTX und ODP festlegen, mit C++-Beispielen."
---
Dieser Artikel demonstriert das Hinzufügen, Zugreifen, Entfernen und Aktualisieren von Hyperlinks auf Formen mit **Aspose.Slides for C++**.

## **Hyperlink hinzufügen**

Erstellen Sie eine Rechteckform mit einem Hyperlink, der auf eine externe Website verweist.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Hyperlink abrufen**

Lesen Sie Hyperlink-Informationen aus dem Textbereich einer Form.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Hyperlink entfernen**

Entfernen Sie den Hyperlink aus dem Text einer Form.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Hyperlink aktualisieren**

Ändern Sie das Ziel eines vorhandenen Hyperlinks. Verwenden Sie `HyperlinkManager`, um Text, der bereits einen Hyperlink enthält, zu bearbeiten, was dem sicheren Aktualisieren von Hyperlinks in PowerPoint entspricht.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Das Ändern eines Hyperlinks im bestehenden Text sollte über
    // HyperlinkManager anstelle die Eigenschaft direkt zu setzen.
    // Dies ahmt nach, wie PowerPoint Hyperlinks sicher aktualisiert.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```