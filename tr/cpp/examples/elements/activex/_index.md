---
title: ActiveX
type: docs
weight: 200
url: /tr/cpp/examples/elements/activex/
keywords:
- kod örneği
- ActiveX
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "C++ için Aspose.Slides ActiveX örneklerine bakın: PPT ve PPTX sunumlarındaki ActiveX nesnelerini ekleyin, yapılandırın ve kontrol edin, net C++ koduyla."
---
Bu makale, **Aspose.Slides for C++** kullanarak bir sunumda ActiveX denetimlerini ekleme, erişme, kaldırma ve yapılandırma işlemlerini gösterir.

## **ActiveX Denetimi Ekleme**

Yeni bir ActiveX denetimi ekleyin ve isteğe bağlı olarak özelliklerini ayarlayın.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Yeni bir ActiveX denetimi ekle.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // İsteğe bağlı olarak bazı özellikleri ayarla.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX Denetimine Erişim**

Slayttaki ilk ActiveX denetiminden bilgi okuyun.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // İlk ActiveX denetimine eriş.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **ActiveX Denetimini Kaldırma**

Varolan bir ActiveX denetimini slayttan silin.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // İlk ActiveX denetimini kaldır.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX Özelliklerini Ayarlama**

Bir denetim ekleyin ve birden fazla ActiveX özelliğini yapılandırın.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Windows Media Player denetimi ekle ve özellikleri yapılandır.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```