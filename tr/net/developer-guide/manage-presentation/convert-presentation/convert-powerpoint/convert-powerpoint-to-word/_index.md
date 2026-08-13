---
title: PowerPoint Sunumlarını .NET'te Word Belgelerine Dönüştür
linktitle: PowerPoint'ten Word'e
type: docs
weight: 110
url: /tr/net/convert-powerpoint-to-word/
keywords:
- PowerPoint Dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten Word'e
- sunumu Word'e
- slaytı Word'e
- PPT'yi Word'e
- PPTX'i Word'e
- PowerPoint'ten DOCX'e
- sunumu DOCX'e
- slaytı DOCX'e
- PPT'yi DOCX'e
- PPTX'i DOCX'e
- PowerPoint'ten DOC'a
- sunumu DOC'a
- slaytı DOC'a
- PPT'yi DOC'a
- PPTX'i DOC'a
- PPT'yi DOCX olarak kaydet
- PPTX'i DOCX olarak kaydet
- PPT'yi DOCX'e dışa aktar
- PPTX'i DOCX'e dışa aktar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak C# içinde PowerPoint PPT ve PPTX slaytlarını düzenlenebilir Word belgelerine dönüştürün; tam düzen, görseller ve biçimlendirme korunur."
---
## **Genel Bakış**

Bu makale, geliştiricilere Aspose.Slides for .NET ve Aspose.Words for .NET kullanarak PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürme konusunda bir çözüm sunar. Adım adım rehber, dönüşüm sürecinin her aşamasında size yol gösterir.

## **Sunumu Word Belgesine Dönüştür**

PowerPoint veya OpenDocument sunumunu bir Word belgesine dönüştürmek için aşağıdaki talimatları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı örneği oluşturun ve bir sunum dosyasını yükleyin.
2. [Document](https://reference.aspose.com/words/net/aspose.words/document/) ve [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) sınıflarını örnekleyerek bir Word belgesi oluşturun.
3. Word belgesinin sayfa boyutunu, sunumun sayfa boyutuna eşitlemek için [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) özelliğini kullanın.
4. Word belgesinde kenar boşluklarını ayarlamak için [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) özelliğini kullanın.
5. [Presentation.Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) özelliğini kullanarak tüm sunum slaytlarını dolaşın.
   - `GetImage` yöntemini [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/) arayüzünden kullanarak bir slayt görüntüsü oluşturun ve bellek akışına kaydedin.
   - `InsertImage` yöntemini [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) sınıfından kullanarak slayt görüntüsünü Word belgesine ekleyin.
6. Word belgesini bir dosyaya kaydedin.

Örneğin, aşağıdaki gibi bir "sample.pptx" sunumuz olduğunu varsayalım:

![PowerPoint sunumu](PowerPoint.png)

Aşağıdaki C# kod örneği, PowerPoint sunumunu bir Word belgesine nasıl dönüştüreceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Words;

// Bir sunum dosyasını yükleyin.
using var presentation = new Presentation("sample.pptx");

// Document ve DocumentBuilder nesnelerini oluşturun.
var document = new Document();
var builder = new DocumentBuilder(document);

// Word belgesindeki sayfa boyutunu ayarlayın.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Word belgesindeki kenar boşluklarını ayarlayın.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Tüm sunum slaytlarını dolaşın.
foreach (var slide in presentation.Slides)
{
    // Bir slayt görüntüsü oluşturun ve bir bellek akışına kaydedin.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Slayt görüntüsünü Word belgesine ekleyin.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Word belgesini bir dosyaya kaydedin.
document.Save("output.docx");
```

Sonuç:

![Word belgesi](Word.png)

{{% alert color="info" %}} 
PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürerek ne kazanabileceğinizi görmek için [**Online PPT to Word Converter**](https://products.aspose.app/slides/tr/conversion/ppt-to-word) aracını deneyin. 
{{% /alert %}}

## **SSS**

### PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürmek için hangi bileşenlerin kurulması gerekir?

C# projenize yalnızca [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) ve [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) için ilgili NuGet paketlerini eklemeniz yeterlidir. Her iki kütüphane de bağımsız API'lar olarak çalışır ve Microsoft Office'in yüklü olmasını gerektirmez.

### Tüm PowerPoint ve OpenDocument sunum formatları destekleniyor mu?

Aspose.Slides for .NET [supports all presentation formats](/slides/tr/net/supported-file-formats/), PPT, PPTX, ODP ve diğer yaygın dosya türleri dahil olmak üzere tüm sunum formatlarını destekler. Bu sayede, Microsoft PowerPoint'in farklı sürümlerinde oluşturulmuş sunumlarla çalışabilirsiniz.