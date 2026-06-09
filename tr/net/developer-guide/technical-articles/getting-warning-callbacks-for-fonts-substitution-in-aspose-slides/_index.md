---
title: .NET'te Yazı Tipi İkamesi İçin Uyarı Geri Aramalarını Alın
type: docs
weight: 120
url: /tr/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- uyarı geri araması
- yazı tipi ikamesi
- render süreci
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde yazı tipi ikamesi için uyarı geri aramalarını almayı öğrenin ve PowerPoint ve OpenDocument sunumlarını doğru bir şekilde görüntüleyin."
---
## **Giriş**

Aspose.Slides for .NET, gerekli bir yazı tipi render sırasında makinede bulunmadığında yazı tipi ikamesi için uyarı geri aramaları almanıza olanak tanır. Bu geri aramalar, eksik veya erişilemeyen yazı tipleriyle ilgili sorunları teşhis etmeye yardımcı olur.

## **Uyarı Geri Aramalarını Etkinleştirme**

Aspose.Slides for .NET, sunum slaytlarını render ederken uyarı geri aramaları almanız için basit API'ler sunar. Uyarı geri aramalarını yapılandırmak için aşağıdaki adımları izleyin:

1. Uyarıları işlemek için [IWarningCallback](https://reference.aspose.com/slides/tr/net/aspose.slides.warnings/iwarningcallback/) arayüzünü uygulayan özel bir geri arama sınıfı oluşturun.
1. [RenderingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmloptions/) gibi seçenek sınıflarını kullanarak uyarı geri aramasını ayarlayın ve diğerleri.
1. Hedef makinede bulunmayan bir yazı tipi kullanan bir sunumu yükleyin.
1. Etkisini görmek için bir slayt küçük resmi oluşturun veya sunumu dışa aktarın.

**Özel Uyarı Geri Arama Sınıfı:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Örnek çıktı:
// 
// Yazı tipi XYZ'den {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}} yerine ikame edilecektir
```

**Bir Slayt Küçük Resmi Oluşturma:**

```c#
 // Slayt render'ı sırasında yazı tipiyle ilgili uyarıları işlemek için bir uyarı geri araması ayarlayın.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Belirtilen dosya yolundan sunumu yükleyin.
using var presentation = new Presentation("sample.pptx");

// Sunumdaki her slayt için bir küçük resim oluşturun.
foreach (var slide in presentation.Slides)
{
    // Belirtilen render seçeneklerini kullanarak slaytın küçük resim görüntüsünü alın.
    using var image = slide.GetImage(options);
    // ...
}
```

**PDF Biçimine Dışa Aktarma:**

```c#
// PDF dışa aktarımı sırasında yazı tipiyle ilgili uyarıları işlemek için bir uyarı geri araması ayarlayın.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Belirtilen dosya yolundan sunumu yükleyin.
using var presentation = new Presentation("sample.pptx");

// Sunumu PDF olarak dışa aktarın.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**HTML Biçimine Dışa Aktarma:**

```c#
 // HTML dışa aktarımı sırasında yazı tipiyle ilgili uyarıları işlemek için bir uyarı geri araması ayarlayın.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Belirtilen dosya yolundan sunumu yükleyin.
using var presentation = new Presentation("sample.pptx");

// Sunumu HTML formatında dışa aktarın.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```