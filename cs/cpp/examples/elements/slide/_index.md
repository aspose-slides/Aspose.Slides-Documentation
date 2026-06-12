---
title: Snímek
type: docs
weight: 10
url: /cs/cpp/examples/elements/slide/
keywords:
- příklad kódu
- snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Spravujte snímky v Aspose.Slides pro C++: vytvářejte, klonujte, přeskupujte, měňte velikost, nastavujte pozadí a aplikujte přechody pomocí C++ pro prezentace PPT, PPTX a ODP."
---
Tento článek poskytuje řadu příkladů, které ukazují, jak pracovat se snímky pomocí **Aspose.Slides for C++**. Naučíte se, jak přidávat, přistupovat, klonovat, přeskupovat a odstraňovat snímky pomocí třídy `Presentation`.

Každý níže uvedený příklad obsahuje stručné vysvětlení následované úryvkem kódu v C++.

## **Přidat snímek**

Chcete‑li přidat nový snímek, musíte nejprve vybrat rozložení. V tomto příkladu používáme rozložení `Blank` a přidáváme prázdný snímek do prezentace.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Poznámka:** Každé rozložení snímku je odvozeno od hlavního snímku, který určuje celkový design a strukturu zástupných prvků. Obrázek níže ukazuje, jak jsou hlavní snímky a jejich přidružená rozložení v PowerPointu uspořádány.

![Master and Layout Relationship](master-layout-slide.png)

## **Přístup ke snímkům podle indexu**

Snímky můžete přistupovat pomocí jejich indexu nebo zjistit index snímku na základě reference. To je užitečné při procházení nebo úpravě konkrétních snímků.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Přidejte další prázdný snímek.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Přistupujte ke snímkům podle indexu.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Získejte index snímku z reference a poté k němu přistupte pomocí indexu.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Klonovat snímek**

Tento příklad demonstruje, jak klonovat existující snímek. Klonovaný snímek je automaticky přidán na konec kolekce snímků.

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

## **Přeskupit snímky**

Pořadí snímků můžete změnit přesunutím jednoho na nový index. V tomto případě přesuneme klonovaný snímek na první pozici.

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

## **Odstranit snímek**

Pro odstranění snímku stačí na něj odkazovat a zavolat `Remove`. Tento příklad přidá druhý snímek a poté odstraní původní, takže zůstane jen nový.

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