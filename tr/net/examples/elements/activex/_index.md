---
title: ActiveX
type: docs
weight: 200
url: /tr/net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX ekle
- ActiveX erişimi
- ActiveX kaldırma
- ActiveX özellikleri
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ActiveX örneklerini inceleyin: PPT ve PPTX sunumlarında ActiveX nesnelerini ekleyin, yapılandırın ve kontrol edin, açık C# kodu ile."
---
Bu makale, bir sunumda **Aspose.Slides for .NET** kullanarak ActiveX denetimlerini ekleme, erişme, kaldırma ve yapılandırma işlemlerini göstermektedir.

## **ActiveX Denetimi Ekle**

Yeni bir ActiveX denetimi ekleyin ve isteğe bağlı olarak özelliklerini ayarlayın.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Yeni bir ActiveX denetimi ekle.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // İsteğe bağlı olarak bazı özellikleri ayarla.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX Denetimine Erişim**

Slayttaki ilk ActiveX denetiminden bilgileri okuyun.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // İlk ActiveX denetimine erişin.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **ActiveX Denetimini Kaldır**

Slayttan mevcut bir ActiveX denetimini silin.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // İlk ActiveX denetimini kaldır.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX Özelliklerini Ayarla**

Bir denetim ekleyin ve birkaç ActiveX özelliğini yapılandırın.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Bir CommandButton ekleyin ve özellikleri yapılandırın.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```