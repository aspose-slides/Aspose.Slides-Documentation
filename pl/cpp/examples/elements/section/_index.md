---
title: Sekcja
type: docs
weight: 90
url: /pl/cpp/examples/elements/section/
keywords:
- przykład kodu
- sekcja
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów w Aspose.Slides for C++: twórz, zmieniaj nazwy, zmieniaj kolejność oraz grupuj slajdy przy użyciu przykładów C++ dla formatów PPT, PPTX i ODP."
---
Przykłady zarządzania sekcjami prezentacji — dodawanie, dostęp, usuwanie i zmienianie ich nazw programowo przy użyciu **Aspose.Slides for C++**.

## **Dodaj sekcję**

Utwórz sekcję, która zaczyna się od określonego slajdu.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Określ slajd, który oznacza początek sekcji.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Uzyskaj dostęp do sekcji**

Odczytaj informacje o sekcji z prezentacji.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Uzyskaj dostęp do sekcji według indeksu.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Usuń sekcję**

Usuń wcześniej dodaną sekcję.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Usuń pierwszą sekcję.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Zmień nazwę sekcji**

Zmień nazwę istniejącej sekcji.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```