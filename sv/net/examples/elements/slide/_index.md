---
title: Bild
type: docs
weight: 10
url: /sv/net/examples/elements/slide/
keywords:
- bild
- lägga till bild
- åtkomst bild
- bildindex
- klona bild
- omordna bilder
- ta bort bild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Kontrollera bilder i Aspose.Slides för .NET: skapa, klona, omordna, ändra storlek, ange bakgrunder och tillämpa övergångar med C# för PPT-, PPTX- och ODP-presentationer."
---
Denna artikel ger en serie exempel som visar hur du arbetar med bilder med **Aspose.Slides för .NET**. Du kommer att lära dig hur du lägger till, hämtar, klonar, omordnar och tar bort bilder med hjälp av `Presentation`‑klassen.

Varje exempel nedan innehåller en kort förklaring följt av ett kodexempel i C#.

## **Lägg till en bild**

För att lägga till en ny bild måste du först välja en layout. I det här exemplet använder vi layouten `Blank` och lägger till en tom bild i presentationen.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Varje bild är baserad på en layout, som i sin tur är baserad på en masterbild.
    // Använd Blank-layouten för att skapa en ny bild.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Lägg till en ny tom bild med den valda layouten.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Obs:** Varje bildlayout härstammar från en masterbild, som definierar den övergripande designen och platshållarstrukturen. Bilden nedan illustrerar hur masterbilder och deras associerade layouter är organiserade i PowerPoint.

![Master och layoutrelation](master-layout-slide.png)

## **Åtkomst till bilder efter index**

Du kan komma åt bilder med hjälp av deras index, eller hitta en bilds index baserat på en referens. Detta är användbart för att iterera genom eller ändra specifika bilder.

```csharp
static void AccessSlide()
{
    // Som standard skapas en presentation med en tom bild.
    using var presentation = new Presentation();

    // Lägg till en till tom bild.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Åtkomst till bilder efter index.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Hämta bildens index från en referens, och åtkomst den sedan via index.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Klona en bild**

Detta exempel visar hur man klonar en befintlig bild. Den klonade bilden läggs automatiskt till i slutet av bildsamlingen.

```csharp
static void CloneSlide()
{
    // Som standard innehåller presentationen en tom bild.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Klona den första bilden; den kommer att läggas till i slutet av presentationen.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // Den klonade bildens index är 1 (andra bilden i presentationen).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Omordna bilder**

Du kan ändra ordningen på bilder genom att flytta en till ett nytt index. I det här fallet flyttar vi en klonad bild till första positionen.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Lägg till en klon av den första bilden (skapad som standard).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Flytta den klonade bilden till första positionen (övriga flyttas ner).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Ta bort en bild**

För att ta bort en bild, referera bara till den och anropa `Remove`. Detta exempel lägger till en andra bild och tar sedan bort den ursprungliga, så att endast den nya kvarstår.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Lägg till en ny tom bild utöver den första standardbilden.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Ta bort den första bilden; endast den nyligen tillagda bilden kommer att återstå.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```