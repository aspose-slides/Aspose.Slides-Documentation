---
title: VBA Makrosu
type: docs
weight: 150
url: /tr/cpp/examples/elements/vba-macro/
keywords:
- kod örneği
- VBA
- makro
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunumları otomatikleştirin: PPT, PPTX ve ODP'de VBA makrolarını oluşturun, çalıştırın, içe aktarın ve güvenli hale getirin, net C++ örnekleriyle."
---
Bu makale, **Aspose.Slides for C++** kullanarak VBA makrolarını ekleme, erişme ve kaldırma işlemlerini göstermektedir.

## **VBA Makro Ekle**
VBA projesi ve basit bir makro modülü içeren bir sunum oluşturun.

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **VBA Makrosuna Erişim**
VBA projesinden ilk modülü alın.

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **VBA Makrosunu Kaldır**
VBA projesinden bir modülü silin.

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```