---
title: Aspose.Slides for Java'da Çoklu İş Parçacığı
linktitle: Çoklu İş Parçacığı
type: docs
weight: 310
url: /tr/java/multithreading/
keywords:
- çoklu iş parçacığı
- birden fazla iş parçacığı
- paralel çalışma
- slaytları dönüştür
- slaytlardan görüntülere
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java çoklu iş parçacığı, PowerPoint ve OpenDocument işleme performansını artırır. Verimli sunum iş akışları için en iyi uygulamaları keşfedin."
---
## **Giriş**

Sunumlarla paralel çalışma (ayrıca ayrıştırma/yükleme/kopyalama dışında) mümkün olsa da ve çoğu zaman her şey sorunsuz gelse de, kütüphaneyi birden çok iş parçacığında kullandığınızda yanlış sonuçlar elde etme ihtimali vardır.

Çok iş parçacıklı bir ortamda tek bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) örneğini **kullanmamanızı** şiddetle öneririz, çünkü bu tahmin edilemeyen hatalar veya kolayca tespit edilemeyen başarısızlıklara yol açabilir. 

Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini birden çok iş parçacığında yüklemek, kaydetmek ve/veya kopyalamak **güvenli değildir**. Bu tür işlemler **desteklenmez**. Bu görevleri gerçekleştirmeniz gerekiyorsa, işlemleri birden fazla tek iş parçacıklı süreç kullanarak paralelleştirmeniz gerekir ve bu süreçlerin her biri kendi sunum örneğini kullanmalıdır. 

## **Sunum Slaytlarını Paralel Olarak Görsellere Dönüştürme**

Tüm PowerPoint sunum slaytlarını paralel olarak PNG görüntülerine dönüştürmek istediğimizi varsayalım. Tek bir `Presentation` örneğini birden çok iş parçacığında kullanmak güvenli olmadığı için, sunum slaytlarını ayrı sunumlara böler ve slaytları paralel olarak, her bir sunumu ayrı bir iş parçacığında kullanarak görüntülere dönüştürürüz. Aşağıdaki kod örneği bunu nasıl yapacağınızı gösterir.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Slayt i'yi ayrı bir sunuma çıkar.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Slaytı ayrı bir görevde görüntüye dönüştür.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Tüm görevlerin tamamlanmasını bekle.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **SSS**

**Her iş parçacığında lisans ayarını çağırmam gerekiyor mu?**

Hayır. İş parçacıkları başlatılmadan önce süreç/applikasyon alanı başına bir kez yapmak yeterlidir. Eğer [lisans ayarı](/slides/tr/java/licensing/) aynı anda (örneğin tembel başlatma sırasında) çağrılabilecekse, bu çağrıyı senkronize edin çünkü lisans ayarı yöntemi kendisi iş parçacığı güvenli değildir.

**`Presentation` veya `Slide` nesnelerini iş parçacıkları arasında aktarabilir miyim?**

“Canlı” sunum nesnelerini iş parçacıkları arasında geçirmek önerilmez: her iş parçacığı için bağımsız örnekler kullanın veya her iş parçacığı için ayrı sunum/slayt konteynerleri önceden oluşturun. Bu yaklaşım, tek bir sunum örneğini iş parçacıkları arasında paylaşmama konusundaki genel öneriyi izler.

**Her iş parçacığının kendi `Presentation` örneği olduğu sürece farklı formatlara (PDF, HTML, görüntüler) dışa aktarımı paralelleştirmek güvenli mi?**

Evet. Bağımsız örnekler ve ayrı çıktı yolları ile bu görevler genellikle doğru şekilde paralelleşir; ortak sunum nesneleri ve ortak I/O akışlarından kaçının.

**Çok iş parçacıklı ortamda global yazı tipi ayarları (klasörler, ikameler) ile ne yapmalıyım?**

Tüm global [yazı tipi ayarları](/slides/tr/java/powerpoint-fonts/) öğelerini iş parçacıklarını başlatmadan önce başlatın ve paralel çalışma sırasında değiştirmeyin. Bu, paylaşılan yazı tipi kaynaklarına erişimde yarış durumlarını ortadan kaldırır.