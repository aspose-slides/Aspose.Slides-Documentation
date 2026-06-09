---
title: Aspose.Slides for Android via Java'da Çoklu İş Parçacığı
linktitle: Çoklu İş Parçacığı
type: docs
weight: 310
url: /tr/androidjava/multithreading/
keywords:
- çoklu iş parçacığı
- birden fazla iş parçacığı
- paralel çalışma
- slaytları dönüştür
- slaytlar görsellere
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da çoklu iş parçacığı, PowerPoint ve OpenDocument işleme performansını artırır. Verimli sunum iş akışları için en iyi uygulamaları keşfedin."
---
## **Giriş**

Sunumlarla paralel çalışma mümkün (parsing/yükleme/kopyalama dışında) ve çoğu zaman her şey sorunsuz yürürken, kütüphaneyi birden fazla iş parçacığında kullandığınızda yanlış sonuçlar almanız olasılığı azdır.

Çok iş parçacıklı bir ortamda tek bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) örneğini **not** kullanmamanızı şiddetle öneririz çünkü bu, kolayca tespit edilemeyen öngörülemeyen hatalar veya başarısızlıklara yol açabilir.

Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının örneğini birden fazla iş parçacığında yüklemek, kaydetmek ve/veya klonlamak **not** güvenli değildir. Bu tür işlemler **not** desteklenmez. Böyle görevleri yerine getirmeniz gerekiyorsa, işlemleri birkaç tek iş parçacıklı süreç kullanarak paralelleştirmeniz gerekir ve bu süreçlerin her biri kendi sunum örneğini kullanmalıdır.

## **Paralelde Sunum Slaytlarını Görsellere Dönüştür**

Diyelim ki bir PowerPoint sunumundaki tüm slaytları paralelde PNG görsellere dönüştürmek istiyoruz. Tek bir `Presentation` örneğini birden fazla iş parçacığında kullanmak güvensiz olduğu için, sunum slaytlarını ayrı sunumlara bölüp, slaytları paralelde görsellere dönüştürüyoruz; her sunumu ayrı bir iş parçacığında kullanıyoruz. Aşağıdaki kod örneği bunu nasıl yapacağınızı gösterir.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Slayt i'yi ayrı bir sunuma çıkar.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Slaytı ayrı bir görevde görsele dönüştür.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
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
		}
	}));
}

// Tüm görevlerin tamamlanmasını bekle.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **SSS**

**Her iş parçacığında lisans kurulumunu çağırmam gerekiyor mu?**

Hayır. İş parçacıkları başlamadan önce süreç/app domain başına bir kez yapmak yeterlidir. [lisans kurulumu](/slides/tr/androidjava/licensing/) eşzamanlı olarak çağrılabilir (örneğin, tembel başlatma sırasında), bu çağrıyı senkronize edin çünkü lisans kurulum yöntemi kendisi iş parçacığı güvenli değildir.

**`Presentation` veya `Slide` nesnelerini iş parçacıkları arasında aktarabilir miyim?**

İş parçacıkları arasında “canlı” sunum nesnelerini aktarmak önerilmez: her iş parçacığı için bağımsız örnekler kullanın veya her iş parçacığı için ayrı sunum/slayt konteynerleri önceden oluşturun. Bu yaklaşım, tek bir sunum örneğinin iş parçacıkları arasında paylaşılmaması gerektiği genel önerisini takip eder.

**Her iş parçacığının kendi `Presentation` örneğine sahip olduğu şartıyla farklı formatlara (PDF, HTML, görseller) dışa aktarmayı paralelleştirmek güvenli mi?**

Evet. Bağımsız örnekler ve ayrı çıktı yolları ile bu görevler genellikle doğru şekilde paralelleşir; ortak sunum nesneleri ve ortak I/O akışlarından kaçının.

**Çok iş parçacıklı ortamda küresel font ayarları (klasörler, ikameler) ile ne yapmalıyım?**

Tüm küresel [font ayarlarını](/slides/tr/androidjava/powerpoint-fonts/) iş parçacıklarını başlatmadan önce başlatın ve paralel çalışma sırasında değiştirmeyin. Bu, paylaşılan font kaynaklarına erişimde yarış koşullarını ortadan kaldırır.