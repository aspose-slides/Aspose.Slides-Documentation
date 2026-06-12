---
title: Přechod snímku
type: docs
weight: 110
url: /cs/cpp/examples/elements/slide-transition/
keywords:
- ukázka kódu
- přechod snímku
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Ovládněte přechody snímků v Aspose.Slides pro C++: přidávejte, přizpůsobujte a řaďte efekty a jejich trvání pomocí příkladů v C++ pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje použití efektů přechodů snímků a časování s **Aspose.Slides for C++**.

## **Přidat přechod snímku**

Použijte přechod typu rozplynutí na první snímek.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Použít přechod typu rozplynutí.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Přístup k přechodu snímku**

Přečtěte typ přechodu aktuálně přiřazený ke snímku.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Přístup k typu přechodu.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Odstranit přechod snímku**

Odstraňte jakýkoli efekt přechodu nastavením typu na `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Odstranit přechod nastavením na None.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Nastavit dobu trvání přechodu**

Určete, jak dlouho je snímek zobrazen před automatickým přechodem.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // V milisekundách.

    presentation->Dispose();
}
```