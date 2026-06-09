---
title: Aspose.Slides for .NET'te Çoklu İş Parçacığı
linktitle: Çoklu İş Parçacığı
type: docs
weight: 310
url: /tr/net/multithreading/
keywords:
- çoklu iş parçacığı
- birden fazla iş parçacığı
- paralel çalışma
- slaytları dönüştür
- slaytlardan görüntülere
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET çoklu iş parçacığı, PowerPoint ve OpenDocument işleme performansını artırır. Verimli sunum iş akışları için en iyi uygulamaları keşfedin."
---
## **Giriş**

Sunumlarla paralel çalışmak (parçalama/yükleme/kopyalama dışında) mümkün ve çoğu zaman her şey sorunsuz ilerlese de, kütüphaneyi birden çok iş parçacığında kullandığınızda yanlış sonuçlar elde etme ihtimali düşük bir ihtimal vardır.

Çok iş parçacıklı bir ortamda tek bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) örneğini **kullanmamanızı** şiddetle öneririz, çünkü bu, kolayca tespit edilemeyen öngörülemeyen hatalar veya başarısızlıklara yol açabilir. 

Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini birden çok iş parçacığında yüklemek, kaydetmek ve/veya kopyalamak **güvenli değildir**. Bu tür işlemler **desteklenmez**. Bu görevleri yerine getirmeniz gerekiyorsa, işlemleri birkaç tek iş parçacıklı süreç kullanarak paralelleştirmeniz gerekir ve bu süreçlerin her biri kendi sunum örneğini kullanmalıdır. 

## **Sunum Slaytlarını Paralel Olarak Görsellere Dönüştürme**

Diyelim ki bir PowerPoint sunumundaki tüm slaytları paralel olarak PNG görüntülerine dönüştürmek istiyoruz. Tek bir `Presentation` örneğini birden çok iş parçacığında kullanmak güvenli olmadığından, sunum slaytlarını ayrı sunumlara bölüyor ve her bir sunumu ayrı bir iş parçacığında kullanarak slaytları paralel olarak görüntülere dönüştürüyoruz. Aşağıdaki kod örneği bunu nasıl yapacağınızı gösteriyor.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Slayt i'yi ayrı bir sunuma çıkar.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Slaytı ayrı bir görevde görüntüye dönüştür.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **SSS**

**Her iş parçacığında lisans kurulumunu çağırmam gerekir mi?**

Hayır. İş parçacıkları başlamadan önce süreç/app domain başına bir kez yapmak yeterlidir. [license setup](/slides/tr/net/licensing/) aynı anda (örneğin tembel başlatma sırasında) çağrılabilecekse, bu çağrıyı senkronize edin çünkü lisans kurulum yöntemi kendisi iş parçacığı güvenli değildir.

**`Presentation` veya `Slide` nesnelerini iş parçacıkları arasında aktarabilir miyim?**

İş parçacıkları arasında “canlı” sunum nesnelerini geçirmek önerilmez: her iş parçacığı için bağımsız örnekler kullanın veya her iş parçacığı için ayrı sunum/slayt konteynerleri önceden oluşturun. Bu yaklaşım, tek bir sunum örneğinin iş parçacıkları arasında paylaşılmaması gerektiği genel önerisini takip eder.

**Her iş parçacığının kendi `Presentation` örneğine sahip olduğu durumda farklı formatlara (PDF, HTML, görüntüler) dışa aktarmayı paralelleştirmek güvenli midir?**

Evet. Bağımsız örnekler ve ayrı çıktı yolları ile bu görevler genellikle doğru şekilde paralelleşir; ortak sunum nesnelerinden ve ortak I/O akışlarından kaçının.

**Çok iş parçacıklı ortamda global yazı tipi ayarları (klasörler, ikameler) ile ne yapmalıyım?**

Tüm global yazı tipi ayarlarını iş parçacıklarını başlatmadan önce başlatın ve paralel çalışma sırasında bunları değiştirmeyin. Bu, paylaşılan yazı tipi kaynaklarına erişimde oluşabilecek yarış durumlarını ortadan kaldırır.