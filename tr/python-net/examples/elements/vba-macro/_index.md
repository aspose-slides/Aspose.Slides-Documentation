---
title: VbaMakro
type: docs
weight: 150
url: /tr/python-net/examples/elements/vba-macro/
keywords:
- VBA makro
- VBA makro ekle
- VBA makro eriş
- VBA makro kaldır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ile Aspose.Slides kullanarak VBA makrolarıyla çalışın: projeleri ve modülleri ekleyin veya düzenleyin, makroları imzalayın veya kaldırın ve sunumları PPT, PPTX ve ODP formatlarında kaydedin."
---
**Aspose.Slides for Python via .NET** kullanarak VBA makrolarını ekleme, erişme ve kaldırma yöntemini gösterir.

## **VBA Makrosu Ekle**

VBA projesi ve basit bir makro modülü içeren bir sunum oluşturun.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Bir VBA projesi başlatın.
        presentation.vba_project = slides.vba.VbaProject()

        # "Module" adlı boş bir modül ekleyin.
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA Makrosuna Erişim**

VBA projesinden ilk modülü alın.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **VBA Makrosunu Kaldır**

VBA projesinden bir modülü silin.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Sunumun bir VBA projesi ve en az bir modül içerdiği varsayılıyor.
        module = presentation.vba_project.modules[0]

        # Modülü projeden kaldır.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```