---
title: Aspose.Slides for Node.js via Java'da Çoklu İş Parçacığı
linktitle: Çoklu İş Parçacığı
type: docs
weight: 310
url: /tr/nodejs-java/multithreading/
keywords:
- çoklu iş parçacığı
- birden çok iş parçacığı
- paralel çalışma
- slaytları dönüştür
- slaytlardan görüntülere
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da çoklu iş parçacığı, PowerPoint ve OpenDocument işleme performansını artırır. Etkin sunum iş akışları için en iyi uygulamaları keşfedin."
---
## **Giriş**

Sunumlarla paralel çalışmak (parsing/yükleme/kopyalama dışındaki işlemler dahil) mümkündür ve çoğu zaman sorunsuz yürür; ancak kütüphaneyi birden çok iş parçacığında kullandığınızda yanlış sonuçlar elde etme ihtimali vardır.

Tek bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneğini çoklu iş parçacığı ortamında **kullanmamanızı** şiddetle öneririz; çünkü bu, kolayca tespit edilemeyen öngörülemeyen hatalara veya başarısızlıklara yol açabilir.

Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini birden çok iş parçacığında yüklemek, kaydetmek ve/veya klonlamak **güvenli değildir**. Bu tür işlemler **desteklenmez**. Böyle görevleri yerine getirmeniz gerekiyorsa, işlemleri birkaç tek iş parçacıklı süreç kullanarak paralelleştirmeniz gerekir ve bu süreçlerin her biri kendi sunum örneğini kullanmalıdır.

## **Paralel Olarak Sunum Slaytlarını Görsellere Dönüştürme**

Tüm PowerPoint slaytlarını paralel olarak PNG görsellere dönüştürmek istediğimizi varsayalım. Tek bir `Presentation` örneğini birden çok iş parçacığında kullanmak güvensiz olduğundan, sunum slaytlarını ayrı sunumlara bölüp her birini ayrı bir iş parçacığında görsellere dönüştürüyoruz. Aşağıdaki kod örneği bunu nasıl yapacağınızı gösterir.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Slayt i'yi ayrı bir sunuma çıkar.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Tüm görevlerin tamamlanmasını bekle.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **SSS**

**Her iş parçacığında lisans kurulumu çağırmam gerekir mi?**

Hayır. İş parçacıkları başlamadan önce **süreç/uygulama alanı** başına bir kez yapmak yeterlidir. [lisans kurulumu](/slides/tr/nodejs-java/licensing/) eşzamanlı olarak (örneğin tembel başlatma sırasında) çağrılabilecekse, bu çağrıyı senkronize edin; çünkü lisans kurulum yöntemi kendisi iş parçacığı güvenli değildir.

**`Presentation` veya `Slide` nesnelerini iş parçacıkları arasında aktarabilir miyim?**

“Canlı” sunum nesnelerini iş parçacıkları arasında geçirmek önerilmez: her iş parçacığı için bağımsız örnekler kullanın ya da her iş parçacığı için ayrı sunum/slayt konteynerleri önceden oluşturun. Bu yaklaşım, tek bir sunum örneğinin iş parçacıkları arasında paylaşılmaması gerektiği genel önerisini takip eder.

**Her iş parçacığının kendi `Presentation` örneği olduğu sürece farklı formatlara (PDF, HTML, görseller) dışa aktarımı paralelleştirmek güvenli midir?**

Evet. Bağımsız **örnekler** ve ayrı çıktı yolları ile bu tür görevler genellikle düzgün bir şekilde paralelleşir; ortak sunum nesneleri ve ortak I/O akışlarından kaçının.

**Çok iş parçacıklı ortamda global font ayarları (klasörler, ikameler) ile ne yapılmalı?**

Tüm global font ayarlarını iş parçacıkları başlamadan önce başlatın ve paralel çalışma sırasında değiştirmeyin. Bu, paylaşılan font kaynaklarına erişimde yarış koşullarını ortadan kaldırır.