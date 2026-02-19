---
title: Tinte
type: docs
weight: 180
url: /de/cpp/examples/elements/ink/
keywords:
- Codebeispiel
- Tinte
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Arbeiten Sie mit Tinte in Aspose.Slides für C++: Zeichnen, Importieren und Bearbeiten von Strichen, Anpassen von Farbe und Breite sowie Exportieren zu PPT, PPTX und ODP mithilfe von C++-Beispielen."
---
Dieser Artikel enthält Beispiele zum Zugriff auf vorhandene Tintenformen und deren Entfernung mit **Aspose.Slides for C++**.

> ❗ **Hinweis:** Tintenformen repräsentieren Benutzereingaben von spezialisierten Geräten. Aspose.Slides kann keine neuen Tintenstriche programmgesteuert erstellen, aber Sie können vorhandene Tinte lesen und ändern.

## **Zugriff auf Tinte**

Lesen Sie die Tags der ersten Tintenform auf einer Folie.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // Verwenden Sie tagName nach Bedarf.
        }
    }

    presentation->Dispose();
}
```

## **Tinte entfernen**

Löschen Sie eine Tintenform von der Folie, falls eine vorhanden ist.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```