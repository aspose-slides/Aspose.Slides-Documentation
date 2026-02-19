---
title: Masterfolie
type: docs
weight: 30
url: /de/cpp/examples/elements/master-slide/
keywords:
- Codebeispiel
- Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie Beispiele für Masterfolien mit Aspose.Slides für C++: Erstellen, Bearbeiten und Gestalten von Masterfolien, Platzhaltern und Designs in PPT, PPTX und ODP mit klarem C++-Code."
---
Masterfolien bilden die oberste Ebene der Folienvererbungshierarchie in PowerPoint. Eine **Masterfolie** definiert gängige Designelemente wie Hintergründe, Logos und Textformatierung. **Layoutfolien** erben von Masterfolien, und **Normalfolien** erben von Layoutfolien.

Dieser Artikel zeigt, wie man Masterfolien mit Aspose.Slides für C++ erstellt, ändert und verwaltet.

## **Masterfolie hinzufügen**

Dieses Beispiel zeigt, wie man eine neue Masterfolie erstellt, indem man die Standardfolie klont. Anschließend wird ein Banner mit dem Firmennamen zu allen Folien über die Layoutvererbung hinzugefügt.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Klone die standardmäßige Masterfolie.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Füge ein Banner mit dem Firmennamen oben auf der Masterfolie hinzu.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Ordne die neue Masterfolie einer Layoutfolie zu.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Ordne die Layoutfolie der ersten Folie in der Präsentation zu.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Hinweis 1:** Masterfolien ermöglichen es, ein konsistentes Branding oder gemeinsam genutzte Designelemente auf allen Folien anzuwenden. Änderungen an der Masterfolie werden automatisch auf abhängige Layout- und Normalfolien übertragen.

> 💡 **Hinweis 2:** Alle Formen oder Formatierungen, die einer Masterfolie hinzugefügt werden, werden von Layoutfolien und wiederum von allen Normalfolien, die diese Layouts verwenden, geerbt.

> Das Bild unten veranschaulicht, wie ein Textfeld, das einer Masterfolie hinzugefügt wurde, automatisch auf der endgültigen Folie dargestellt wird.

![Beispiel für Mastervererbung](master-slide-banner.png)

## **Zugriff auf eine Masterfolie**

Sie können auf Masterfolien über die Präsentations-Mastersammlung zugreifen. So erhalten Sie sie und arbeiten mit ihnen:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Ändere den Hintergrundtyp.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Masterfolie entfernen**

Masterfolien können entweder nach Index oder per Referenz entfernt werden.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Entferne eine Masterfolie nach Index.
    presentation->get_Masters()->RemoveAt(0);

    // Entferne eine Masterfolie nach Referenz.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Unbenutzte Masterfolien entfernen**

Einige Präsentationen enthalten Masterfolien, die nicht verwendet werden. Das Entfernen dieser Folien kann dabei helfen, die Dateigröße zu reduzieren.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Entferne alle unbenutzten Masterfolien (auch die, die als Preserve gekennzeichnet sind).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```