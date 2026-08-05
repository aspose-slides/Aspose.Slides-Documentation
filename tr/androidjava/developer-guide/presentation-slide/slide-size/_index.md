---
title: Android'de Sunum Slayt Boyutunu Değiştir
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/androidjava/slide-size/
keywords:
- slayt boyutu
- en-boy oranı
- standart
- geniş ekran
- 4:3
- 16:9
- slayt boyutunu ayarla
- slayt boyutunu değiştir
- özel slayt boyutu
- özel slayt boyutu
- benzersiz slayt boyutu
- tam boyutlu slayt
- ekran tipi
- ölçekleme yok
- sığdırmayı sağla
- en çok büyüt
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Java ve Aspose.Slides for Android ile PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırın, herhangi bir ekranda kalite kaybı olmadan sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem baskı hem de ekran görüntüsü için kritiktir. 

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En-Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 En-Boy Oranı)**: Modern projeksiyon cihazları ve ekranlar için önerilir.

Sunumunuzda tutarlılığı sağlamak için tüm slaytlara tek bir slayt boyutu ve en‑boy oranı uygulanır. En iyi sonuçlar için, slayt boyutlarını sunumu oluşturma sürecinin başında belirleyin ve sorunlardan kaçının.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Java’da Aspose.Slides kullanarak bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumlarda Özel Slayt Boyutlarını Belirleme**

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı tercih edebilirsiniz. Örneğin, sunumunuzdaki tam boy slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız ya da sunumunuzu belirli ekran tiplerinde göstermek istiyorsanız, özel bir boyut ayarı kullanmak size fayda sağlayacaktır. 

Bu örnek kod, Java üzerinden Aspose.Slides for Android kullanarak bir sunum için özel bir slayt boyutu nasıl belirtileceğini gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 kağıt boyutu
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini İşleme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna sığacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl ilgileneceğini belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya başarmayı planladığınıza bağlı olarak, aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını İSTEMİYORSANIZ, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklemek ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını (böylece içeriği kaybetmezsiniz) sağlamasını istiyorsanız, bu ayarı kullanın. 

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklemek ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın. 

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarının nasıl kullanılacağını gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**İnç dışında birim (örneğin, puan veya milimetre) kullanarak özel bir slayt boyutu belirleyebilir miyim?**

Evet. Aspose.Slides dahili olarak puan (point) kullanır; 1 puan 1/72 inçtir. Milimetre veya santimetre gibi herhangi bir birimi puana dönüştürüp slayt genişliği ve yüksekliğini tanımlamak için dönüştürülmüş değerleri kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, render sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği, daha fazla bellek tüketimi ve daha uzun işleme süresi ile sonuçlanır. Pratik bir slayt boyutu hedefleyin ve sadece ihtiyaç duyulan çıktı kalitesine ulaşmak için render ölçeğini ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştirme](/slides/tr/androidjava/merge-presentation/) yapamazsınız — önce bir sunumu diğerine uyacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bir slaydın tek tek şekilleri veya belirli bölgeleri için küçük resimler (thumbnail) oluşturabilir miyim ve bunlar yeni slayt boyutuna saygı gösterir mi?**

Evet. Aspose.Slides, [tam slaytlar](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ve aynı zamanda [seçili şekiller](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) için küçük resimler oluşturabilir. Oluşturulan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.