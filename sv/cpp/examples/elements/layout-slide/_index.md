---
title: Layoutbild
type: docs
weight: 20
url: /sv/cpp/examples/elements/layout-slide/
keywords:
- kodexempel
- layoutbild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska layout-slides i Aspose.Slides för C++: välj, tillämpa och anpassa bildlayouter, platshållare och master-slides med C++-exempel för PPT-, PPTX- och ODP-presentationer."
---
Denna artikel visar hur du arbetar med **Layout Slides** i Aspose.Slides för C++. En layout‑slide definierar designen och formateringen som ärvs av vanliga slides. Du kan lägga till, komma åt, klona och ta bort layout‑slides, samt rensa bort oanvända för att minska presentationens storlek.

## **Lägg till en Layout Slide**

Du kan skapa en anpassad layout‑slide för att definiera återanvändbar formatering. Till exempel kan du lägga till en textruta som visas på alla slides som använder denna layout.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Skapa en layout‑slide med en tom layouttyp och ett anpassat namn.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Lägg till en textruta på layout‑sliden.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Lägg till två slides med denna layout; båda kommer att ärva texten från layouten.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Notering 1:** Layout‑slides fungerar som mallar för enskilda slides. Du kan definiera gemensamma element en gång och återanvända dem i många slides.

> 💡 **Notering 2:** När du lägger till former eller text i en layout‑slide kommer alla slides baserade på den layouten automatiskt att visa detta gemensamma innehåll. Skärmdumpen nedan visar två slides, var och en som ärver en textruta från samma layout‑slide.

![Slides som ärver layoutinnehåll](layout-slide-result.png)

## **Åtkomst till en Layout Slide**

Layout‑slides kan nås via index eller via layout‑typ (t.ex. `Blank`, `Title`, `SectionHeader` osv.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Åtkomst till en layout slide via index.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Åtkomst till en layout slide via typ.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Ta bort en Layout Slide**

Du kan ta bort en specifik layout‑slide om den inte längre behövs.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Hämta en layout-slide efter typ och ta bort den.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Ta bort oanvända Layout Slides**

För att minska presentationens storlek kan du vilja ta bort layout‑slides som inte används av några vanliga slides.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Tar automatiskt bort alla layout‑slides som inte refereras av någon slide.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Klona en Layout Slide**

Du kan duplicera en layout‑slide med hjälp av metoden `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Hämta en befintlig layout‑slide efter typ.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Klona layout‑sliden till slutet av layout‑slide‑samlingen.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Sammanfattning:** Layout‑slides är kraftfulla verktyg för att hantera konsekvent formatering över slides. Aspose.Slides ger full kontroll över att skapa, hantera och optimera layout‑slides.