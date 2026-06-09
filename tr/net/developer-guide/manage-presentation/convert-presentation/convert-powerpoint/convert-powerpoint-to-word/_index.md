---
title: PowerPoint Sunumlarını .NET'te Word Belgelerine Dönüştür
linktitle: PowerPoint'tan Word'e
type: docs
weight: 110
url: /tr/net/convert-powerpoint-to-word/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan Word'e
- sunumdan Word'e
- slayttan Word'e
- PPT'den Word'e
- PPTX'den Word'e
- PowerPoint'tan DOCX'e
- sunumdan DOCX'e
- slayttan DOCX'e
- PPT'den DOCX'e
- PPTX'den DOCX'e
- PowerPoint'tan DOC'a
- sunumdan DOC'a
- slayttan DOC'a
- PPT'den DOC'a
- PPTX'den DOC'a
- PPT'yi DOCX olarak kaydet
- PPTX'i DOCX olarak kaydet
- PPT'yi DOCX'e dışa aktar
- PPTX'i DOCX'e dışa aktar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak C# ile PowerPoint PPT ve PPTX slaytlarını düzenlenebilir Word belgelerine dönüştürün; kesin düzen, görseller ve biçimlendirme korunur."
---
## **Genel Bakış**

Bu makale, geliştiricilere Aspose.Slides for .NET ve Aspose.Words for .NET kullanarak PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürme konusunda bir çözüm sunar. Adım adım kılavuz, dönüştürme sürecinin her aşamasında size rehberlik eder.

## **Bir Sunumu Word Belgesine Dönüştürme**

Aşağıdaki talimatları izleyerek bir PowerPoint veya OpenDocument sunumunu Word belgesine dönüştürün:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı örnekleyin ve bir sunum dosyasını yükleyin.
2. Bir Word belgesi oluşturmak için [Document](https://reference.aspose.com/words/net/aspose.words/document/) ve [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) sınıflarını örnekleyin.
3. Word belgesinin sayfa boyutunu, sunumla aynı olacak şekilde [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) özelliğiyle ayarlayın.
4. Word belgesinde kenar boşluklarını [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) özelliğiyle ayarlayın.
5. [Presentation.Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) özelliğini kullanarak tüm sunum slaytlarını dolaşın.
    - [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/) arayüzündeki `GetImage` metodunu kullanarak bir slayt görüntüsü oluşturun ve bunu bir bellek akışına kaydedin.
    - [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) sınıfındaki `InsertImage` metodunu kullanarak slayt görüntüsünü Word belgesine ekleyin.
6. Word belgesini bir dosyaya kaydedin.

Diyelim ki aşağıdaki gibi görünen bir "sample.pptx" sunumumuz var:

![PowerPoint sunumu](PowerPoint.png)

Aşağıdaki C# kod örneği, PowerPoint sunumunu bir Word belgesine nasıl dönüştüreceğinizi gösterir:

```cs
// Bir sunum dosyası yükle.
using var presentation = new Presentation("sample.pptx");

// Document ve DocumentBuilder nesnelerini oluştur.
var document = new Document();
var builder = new DocumentBuilder(document);

// Word belgesindeki sayfa boyutunu ayarla.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Word belgesindeki kenar boşluklarını ayarla.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Tüm sunum slaytlarını dolaş.
foreach (var slide in presentation.Slides)
{
    // Bir slayt resmi oluştur ve bir bellek akışına kaydet.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Slayt resmini Word belgesine ekle.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Word belgesini bir dosyaya kaydet.
document.Save("output.docx");
```

Sonuç:

![Word belgesi](Word.png)

{{% alert color="primary" %}} 

PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürerek ne elde edebileceğinizi görmek için [**Online PPT to Word Dönüştürücü**](https://products.aspose.app/slides/tr/conversion/ppt-to-word) aracını deneyin. 

{{% /alert %}}

## **SSS**

**PowerPoint ve OpenDocument sunumlarını Word belgelerine dönüştürmek için hangi bileşenlerin kurulması gerekir?**

C# projenize yalnızca [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) ve [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) için ilgili NuGet paketlerini eklemeniz yeterlidir. Her iki kütüphane de bağımsız API'ler olarak çalışır ve Microsoft Office'in kurulmuş olmasına gerek yoktur.

**Tüm PowerPoint ve OpenDocument sunum formatları destekleniyor mu?**

Aspose.Slides for .NET, PPT, PPTX, ODP ve diğer yaygın dosya türleri dahil olmak üzere [tüm sunum formatlarını destekler](/slides/tr/net/supported-file-formats/). Bu, Microsoft PowerPoint'in çeşitli sürümlerinde oluşturulmuş sunumlarla çalışabilmenizi sağlar.