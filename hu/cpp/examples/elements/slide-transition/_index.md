---
title: Diaátmenet
type: docs
weight: 110
url: /hu/cpp/examples/elements/slide-transition/
keywords:
- kódpélda
- diaátmenet
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ segítségével a diaátmenetek mestersége: hozzáadás, testreszabás és sorozás a hatások és időtartamok tekintetében C++ példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja a diaátmeneti effektusok és időzítések alkalmazását a **Aspose.Slides for C++** segítségével.

## **Diaátmenet hozzáadása**

Alkalmazzon halványuló átmeneti effektust az első diára.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Alkalmazzon egy halványuló átmenetet.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Diaátmenet elérése**

Olvassa ki a diára jelenleg beállított átmenet típusát.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Az átmenet típusának elérése.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Diaátmenet eltávolítása**

Törölje az átmeneti effektust a típus `None` beállításával.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Az átmenet eltávolítása a None beállításával.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Átmenet időtartamának beállítása**

Adja meg, mennyi ideig jelenik meg a dia, mielőtt automatikusan lép tovább.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // milliszekundumban.

    presentation->Dispose();
}
```