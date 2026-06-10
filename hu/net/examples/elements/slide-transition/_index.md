---
title: Diaátmenet
type: docs
weight: 110
url: /hu/net/examples/elements/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet elérése
- diaátmenet eltávolítása
- átmenet időtartam
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET diátmenetek mesteri kezelése: hozzáadás, testreszabás és hatások és időtartamok sorozása C# példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja a diák átlépés hatások és időzítések alkalmazását az **Aspose.Slides for .NET**-vel.

## **Diátmenet hozzáadása**

Alkalmazzon egy elhalványuló átmeneti hatást az első diára.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Alkalmazzon egy elhalványuló átmenetet.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Diátmenet elérése**

Olvassa el a diára jelenleg beállított átmenet típusát.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // A tranzíció típusának elérése.
    var type = slide.SlideShowTransition.Type;
}
```

## **Diátmenet eltávolítása**

Távolítson el minden átmeneti hatást a típus `None`-ra állítással.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Átmenet eltávolítása a None beállításával.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Átmenet időtartam beállítása**

Adja meg, mennyi ideig jelenik meg a dia, mielőtt automatikusan továbblép.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // ezredmásodpercben
}
```