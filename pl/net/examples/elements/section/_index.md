---
title: Sekcja
type: docs
weight: 90
url: /pl/net/examples/elements/section/
keywords:
- sekcja
- sekcja slajdu
- dodaj sekcję
- dostęp do sekcji
- usuń sekcję
- zmień nazwę sekcji
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów w Aspose.Slides dla .NET: twórz, zmieniaj nazwy, zmieniaj kolejność i grupuj slajdy z przykładami w C# dla PPT, PPTX i ODP."
---
Przykłady zarządzania sekcjami prezentacji — dodawanie, dostęp, usuwanie i zmienianie ich nazw programowo przy użyciu **Aspose.Slides for .NET**.

## **Dodaj sekcję**

Utwórz sekcję, która zaczyna się od określonego slajdu.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Określ slajd, który oznacza początek sekcji.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Dostęp do sekcji**

Odczytaj informacje o sekcji z prezentacji.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Uzyskaj dostęp do sekcji po indeksie.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Usuń sekcję**

Usuń wcześniej dodaną sekcję.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Usuń pierwszą sekcję.
    presentation.Sections.RemoveSection(section);
}
```

## **Zmień nazwę sekcji**

Zmień nazwę istniejącej sekcji.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```