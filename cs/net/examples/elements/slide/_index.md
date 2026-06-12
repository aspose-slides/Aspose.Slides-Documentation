---
title: Snímek
type: docs
weight: 10
url: /cs/net/examples/elements/slide/
keywords:
- snímek
- přidat snímek
- přístup k snímku
- index snímku
- klonovat snímek
- přeskupit snímky
- odstranit snímek
- ukázkový kód
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte snímky v Aspose.Slides pro .NET: vytvářejte, klonujte, přeskupujte, měňte velikost, nastavujte pozadí a aplikujte přechody pomocí C# pro prezentace PPT, PPTX a ODP."
---
Tento článek poskytuje řadu příkladů, které ukazují, jak pracovat se snímky pomocí **Aspose.Slides for .NET**. Naučíte se, jak pomocí třídy `Presentation` přidávat, získávat, klonovat, přesouvat a odstraňovat snímky.

Každý příklad níže obsahuje stručné vysvětlení a poté úryvek kódu v C#.

## **Přidat snímek**

Pro přidání nového snímku musíte nejprve vybrat rozvržení. V tomto příkladu používáme rozvržení `Blank` a přidáváme prázdný snímek do prezentace.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Každý snímek je založen na rozvržení, které samo vychází z hlavního snímku.
    // Použijte rozvržení Blank pro vytvoření nového snímku.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Přidejte nový prázdný snímek pomocí vybraného rozvržení.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Poznámka:** Každé rozvržení snímku je odvozeno od hlavního snímku, který určuje celkový design a strukturu zástupných objektů. Obrázek níže ukazuje, jak jsou v PowerPointu uspořádány hlavní snímky a jejich související rozvržení.

![Vztah mezi hlavním snímkem a rozvržením](master-layout-slide.png)

## **Přístup k snímkům podle indexu**

Můžete přistupovat k snímkům pomocí jejich indexu nebo najít index snímku na základě reference. To je užitečné pro procházení nebo úpravu konkrétních snímků.

```csharp
static void AccessSlide()
{
    // Ve výchozím nastavení je prezentace vytvořena s jedním prázdným snímkem.
    using var presentation = new Presentation();

    // Přidejte další prázdný snímek.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Přístup ke snímkům podle indexu.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Získejte index snímku z reference a poté k němu přistupte podle indexu.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Klonovat snímek**

Tento příklad ukazuje, jak klonovat existující snímek. Klonovaný snímek je automaticky přidán na konec kolekce snímků.

```csharp
static void CloneSlide()
{
    // Ve výchozím nastavení prezentace obsahuje jeden prázdný snímek.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Klonujte první snímek; bude přidán na konci prezentace.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // Index klonovaného snímku je 1 (druhý snímek v prezentaci).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Přeskupit snímky**

Pořadí snímků můžete změnit přesunutím jednoho na nový index. V tomto případě přesuneme klonovaný snímek na první pozici.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Přidejte klon prvního snímku (vytvořený ve výchozím nastavení).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Přesuňte klonovaný snímek na první pozici (ostatní se posunou dolů).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Odstranit snímek**

Pro odstranění snímku jej jednoduše odkažte a zavolejte `Remove`. Tento příklad přidá druhý snímek a poté odstraní původní, zůstane jen nový.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Přidejte nový prázdný snímek kromě výchozího prvního snímku.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Odstraňte první snímek; zůstane pouze nově přidaný snímek.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```