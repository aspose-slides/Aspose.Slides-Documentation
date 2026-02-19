---
title: Folie
type: docs
weight: 10
url: /de/cpp/examples/elements/slide/
keywords:
- Codebeispiel
- Folie
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Steuern Sie Folien in Aspose.Slides für C++: Erstellen, duplizieren, neu anordnen, Größe ändern, Hintergründe festlegen und Übergänge anwenden mit C++ für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel enthält eine Reihe von Beispielen, die zeigen, wie man mit Folien unter **Aspose.Slides for C++** arbeitet. Sie lernen, wie man Folien mit der Klasse `Presentation` hinzufügt, darauf zugreift, sie kopiert, neu anordnet und entfernt.

Jedes unten stehende Beispiel enthält eine kurze Erklärung, gefolgt von einem C++‑Code‑Snippet.

## **Folie hinzufügen**

Um eine neue Folie hinzuzufügen, muss zunächst ein Layout ausgewählt werden. In diesem Beispiel verwenden wir das Layout `Blank` und fügen der Präsentation eine leere Folie hinzu.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Hinweis:** Jedes Folienlayout leitet sich von einer Master‑Folie ab, die das Gesamtdesign und die Platzhalterstruktur definiert. Das Bild unten zeigt, wie Master‑Folien und ihre zugehörigen Layouts in PowerPoint organisiert sind.

![Beziehung zwischen Master und Layout](master-layout-slide.png)

## **Zugriff auf Folien nach Index**

Sie können Folien über ihren Index ansprechen oder den Index einer Folie anhand einer Referenz ermitteln. Dies ist nützlich, um durch Folien zu iterieren oder bestimmte Folien zu ändern.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Füge eine weitere leere Folie hinzu.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Greife auf Folien per Index zu.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Erhalte den Folienindex aus einer Referenz und greife dann per Index darauf zu.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Folie duplizieren**

Dieses Beispiel demonstriert, wie eine vorhandene Folie dupliziert wird. Die duplizierte Folie wird automatisch am Ende der Folien‑Sammlung hinzugefügt.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Folien neu anordnen**

Sie können die Reihenfolge der Folien ändern, indem Sie eine Folie an einen neuen Index verschieben. In diesem Fall verschieben wir eine duplizierte Folie an die erste Position.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Folie entfernen**

Um eine Folie zu entfernen, referenzieren Sie sie einfach und rufen `Remove` auf. Dieses Beispiel fügt eine zweite Folie hinzu und entfernt anschließend die ursprüngliche, sodass nur die neue übrig bleibt.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```