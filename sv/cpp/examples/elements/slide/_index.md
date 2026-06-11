---
title: Bild
type: docs
weight: 10
url: /sv/cpp/examples/elements/slide/
keywords:
- kodexempel
- bild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Kontrollera bilder i Aspose.Slides för C++: skapa, klona, omordna, ändra storlek, sätta bakgrunder och tillämpa övergångar med C++ för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln innehåller en serie exempel som visar hur man arbetar med bilder med **Aspose.Slides for C++**. Du kommer att lära dig hur du lägger till, får åtkomst till, klonar, omordnar och tar bort bilder med hjälp av klassen `Presentation`.

Varje exempel nedan innehåller en kort förklaring följd av ett kodexempel i C++.

## **Lägg till en bild**

För att lägga till en ny bild måste du först välja en layout. I detta exempel använder vi layouten `Blank` och lägger till en tom bild i presentationen.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Obs:** Varje bildlayout härstammar från en masterbild, som definierar den övergripande designen och platshållarstrukturen. Bilden nedan visar hur masterbilder och deras associerade layouter är organiserade i PowerPoint.

![Master- och layoutförhållande](master-layout-slide.png)

## **Få åtkomst till bilder efter index**

Du kan komma åt bilder med deras index, eller hitta en bilds index baserat på en referens. Detta är användbart för att iterera igenom eller modifiera specifika bilder.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Lägg till en annan tom bild.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Få åtkomst till bilder efter index.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Hämta bildens index från en referens och få sedan åtkomst till den via index.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Klona en bild**

Detta exempel visar hur man klonar en befintlig bild. Den klonade bilden läggs automatiskt till i slutet av bildsamlingen.

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

## **Omordna bilder**

Du kan ändra ordningen på bilder genom att flytta en till ett nytt index. I detta fall flyttar vi en klonad bild till den första positionen.

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

## **Ta bort en bild**

För att ta bort en bild, referera enkelt till den och anropa `Remove`. Detta exempel lägger till en andra bild och tar sedan bort den ursprungliga, så att endast den nya kvarstår.

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