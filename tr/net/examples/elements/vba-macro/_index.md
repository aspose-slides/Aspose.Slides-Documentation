---
title: VBA Makrosu
type: docs
weight: 150
url: /tr/net/examples/elements/vba-macro/
keywords:
- VBA makrosu
- VBA makrosu ekle
- VBA makrosuna eriş
- VBA makrosunu kaldır
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile sunumları otomatikleştirin: PPT, PPTX ve ODP'de VBA makrolarını oluşturun, çalıştırın, içe aktarın ve güvenli hale getirin, net C# örnekleri kullanarak."
---
Bu makale, **Aspose.Slides for .NET** kullanarak VBA makrolarını ekleme, erişme ve kaldırma işlemlerini göstermektedir.

## **VBA Makrosu Ekle**

VBA projesi ve basit bir makro modülü içeren bir sunum oluşturun.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **VBA Makrosuna Erişme**

VBA projesinden ilk modülü alın.

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **VBA Makrosunu Kaldırma**

VBA projesinden bir modülü silin.

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```