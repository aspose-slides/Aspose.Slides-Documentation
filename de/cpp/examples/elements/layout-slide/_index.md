---
title: Layout-Folie
type: docs
weight: 20
url: /de/cpp/examples/elements/layout-slide/
keywords:
- Codebeispiel
- Layout-Folie
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Master-Layout-Folien in Aspose.Slides für C++: Auswahl, Anwendung und Anpassung von Folienlayouts, Platzhaltern und Masterfolien mit C++-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie man mit **Layout Slides** in Aspose.Slides für C++ arbeitet. Eine Layout-Folie definiert das Design und die Formatierung, die von normalen Folien geerbt werden. Sie können Layout-Folien hinzufügen, darauf zugreifen, sie klonen und entfernen sowie unbenutzte Folien bereinigen, um die Präsentationsgröße zu reduzieren.

## **Eine Layout-Folie hinzufügen**

Sie können eine benutzerdefinierte Layout-Folie erstellen, um wiederverwendbare Formatierungen zu definieren. Beispielsweise könnten Sie ein Textfeld hinzufügen, das auf allen Folien dieses Layouts angezeigt wird.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Erstelle eine Layout-Folie mit einem leeren Layouttyp und einem benutzerdefinierten Namen.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Füge ein Textfeld zur Layout-Folie hinzu.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Füge zwei Folien mit diesem Layout hinzu; beide erben den Text aus dem Layout.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Hinweis 1:** Layout-Folien fungieren als Vorlagen für einzelne Folien. Sie können gemeinsame Elemente einmal definieren und sie über viele Folien hinweg wiederverwenden.

> 💡 **Hinweis 2:** Wenn Sie Formen oder Text zu einer Layout-Folie hinzufügen, wird dieser gemeinsam genutzte Inhalt automatisch auf allen Folien angezeigt, die auf diesem Layout basieren.  
> Der Screenshot unten zeigt zwei Folien, die jeweils ein Textfeld vom selben Layout erben.

![Folien, die Layout-Inhalt erben](layout-slide-result.png)

## **Auf eine Layout-Folie zugreifen**

Layout-Folien können nach Index oder nach Layout-Typ (z. B. `Blank`, `Title`, `SectionHeader` usw.) abgerufen werden.

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Greife auf eine Layout-Folie per Index zu.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Greife auf eine Layout-Folie per Typ zu.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Eine Layout-Folie entfernen**

Sie können eine bestimmte Layout-Folie entfernen, wenn sie nicht mehr benötigt wird.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Hole eine Layout-Folie nach Typ und entferne sie.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Unbenutzte Layout-Folien entfernen**

Um die Präsentationsgröße zu reduzieren, können Sie Layout-Folien entfernen, die von keinen normalen Folien verwendet werden.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Entfernt automatisch alle Layout-Folien, die von keiner Folie referenziert werden.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Eine Layout-Folie klonen**

Sie können eine Layout-Folie mit der Methode `AddClone` duplizieren.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Hole eine vorhandene Layout-Folie nach Typ.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Klone die Layout-Folie an das Ende der Layout-Folien-Sammlung.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Zusammenfassung:** Layout-Folien sind leistungsstarke Werkzeuge zur Verwaltung einheitlicher Formatierungen über Folien hinweg. Aspose.Slides bietet vollständige Kontrolle über das Erstellen, Verwalten und Optimieren von Layout-Folien.