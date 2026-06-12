---
title: Přechod snímku
type: docs
weight: 110
url: /cs/net/examples/elements/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- získat přechod snímku
- odstranit přechod snímku
- délka trvání přechodu
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Mistrovské přechody snímků v Aspose.Slides pro .NET: přidávejte, upravujte a řaďte efekty a délky trvání s ukázkami v C# pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak použít efekty přechodů snímků a časování s **Aspose.Slides for .NET**.

## **Přidat přechod snímku**

Aplikujte přechod typu rozplynutí na první snímek.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Aplikovat rozplývací přechod.
}
```

## **Získat přechod snímku**

Načtěte typ přechodu aktuálně přiřazený snímku.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Získat typ přechodu.
    var type = slide.SlideShowTransition.Type;
}
```

## **Odebrat přechod snímku**

Odstraňte jakýkoli efekt přechodu nastavením typu na `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Odstranit přechod nastavením None.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Nastavit dobu trvání přechodu**

Určete, jak dlouho se snímek zobrazí, než se automaticky přejde dál.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // v milisekundách
}
```