---
title: ActiveX
type: docs
weight: 200
url: /pl/cpp/examples/elements/activex/
keywords:
- przykład kodu
- ActiveX
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zobacz przykłady ActiveX w Aspose.Slides for C++: wstawianie, konfigurowanie i kontrolowanie obiektów ActiveX w prezentacjach PPT i PPTX przy użyciu przejrzystego kodu C++."
---
Ten artykuł demonstruje, jak dodawać, uzyskiwać dostęp, usuwać i konfigurować kontrolki ActiveX w prezentacji przy użyciu **Aspose.Slides for C++**.

## **Dodaj kontrolkę ActiveX**

Wstaw nową kontrolkę ActiveX i opcjonalnie ustaw jej właściwości.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Dodaj nową kontrolkę ActiveX.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Opcjonalnie ustaw niektóre właściwości.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Uzyskaj dostęp do kontrolki ActiveX**

Odczytaj informacje z pierwszej kontrolki ActiveX na slajdzie.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Uzyskaj dostęp do pierwszej kontrolki ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Usuń kontrolkę ActiveX**

Usuń istniejącą kontrolkę ActiveX ze slajdu.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Usuń pierwszą kontrolkę ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Ustaw właściwości ActiveX**

Dodaj kontrolkę i skonfiguruj kilka właściwości ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Dodaj kontrolkę Windows Media Player i skonfiguruj właściwości.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```