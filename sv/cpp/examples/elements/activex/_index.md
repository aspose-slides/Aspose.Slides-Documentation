---
title: ActiveX
type: docs
weight: 200
url: /sv/cpp/examples/elements/activex/
keywords:
- kodexempel
- ActiveX
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Se Aspose.Slides for C++ ActiveX-exempel: infoga, konfigurera och kontrollera ActiveX-objekt i PPT- och PPTX-presentationer med tydlig C++-kod."
---
Denna artikel demonstrerar hur man lägger till, får åtkomst till, tar bort och konfigurerar ActiveX-kontroller i en presentation med hjälp av **Aspose.Slides for C++**.

## **Lägg till en ActiveX-kontroll**

Infoga en ny ActiveX-kontroll och sätt eventuellt dess egenskaper.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Lägg till en ny ActiveX-kontroll.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Ställ eventuellt in några egenskaper.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Få åtkomst till en ActiveX-kontroll**

Läs information från den första ActiveX-kontrollen på bilden.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Åtkomst till den första ActiveX-kontrollen.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Ta bort en ActiveX-kontroll**

Ta bort en befintlig ActiveX-kontroll från bilden.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Ta bort den första ActiveX-kontrollen.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Ställ in ActiveX-egenskaper**

Lägg till en kontroll och konfigurera flera ActiveX-egenskaper.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Lägg till en Windows Media Player-kontroll och konfigurera egenskaper.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```