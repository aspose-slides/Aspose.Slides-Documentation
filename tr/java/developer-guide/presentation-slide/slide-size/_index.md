---
title: Java'da Sunum Slayt Boyutunu Değiştirme
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/java/slide-size/
keywords:
- slayt boyutu
- en‑boy oranı
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
- ölçeklendirme yok
- uyumu sağla
- azami
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java ve Aspose.Slides ile PPT, PPTX ve ODP dosyalarındaki slaytları hızlı bir şekilde yeniden boyutlandırmayı, kalite kaybı olmadan herhangi bir ekrana uyacak şekilde sunumları optimize etmeyi öğrenin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, hem baskı hem de ekran görüntüsü için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En‑Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En‑Boy Oranı)**: Modern projektörler ve görüntüleyiciler için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için slayt boyutlarını sunum oluşturma sürecinin başında belirleyin; aksi takdirde karmaşıklık ortaya çıkabilir.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

 Bu örnek kod, Java’da Aspose.Slides kullanarak bir sunumda slayt boyutunun nasıl değiştirileceğini gösterir:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumlarda Özel Slayt Boyutlarını Belirtme**

Yaygın slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanabilirsiniz. Örneğin, sunumunuzdaki slaytları özel bir sayfa düzeninde tam boyutlu olarak yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran tiplerinde göstermek istiyorsanız, özel bir boyut ayarı size fayda sağlayacaktır.

Bu örnek kod, Java’da Aspose.Slides kullanarak bir sunum için özel bir slayt boyutunun nasıl belirtileceğini gösterir:

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

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin, görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna sığacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar seçebilirsiniz.

Ne yapmayı amaçladığınızı göz önünde bulundurarak aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **istemiyorsanız** bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek ve tüm nesnelerin slaytlara sığmasını sağlamak (içeriğin kaybolmasını önlemek) istiyorsanız bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek ve nesnelerin yeni slayt boyutuna orantılı olarak büyütülmesini istiyorsanız bu ayarı kullanın.

Bu örnek kod, bir sunumun slayt boyutu değiştirilirken `Maximize` ayarının nasıl kullanılacağını gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Ölçü birimi olarak inç dışındaki (örneğin, puan veya milimetre) birimler kullanarak özel bir slayt boyutu belirleyebilir miyim?**

Evet. Aspose.Slides içsel olarak puan (point) kullanır; 1 puan 1/72 inçtir. Milimetre veya santimetre gibi herhangi bir birimi puana dönüştürerek slayt genişliği ve yüksekliği için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, oluşturma sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği, bellek tüketimini artırır ve işlem süresini uzatır. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesini elde etmek için render ölçeğini yalnızca gerektiği kadar ayarlayın.

**Standart dışı bir slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip sunumları [sunumları birleştirme](/slides/tr/java/merge-presentation/) yapılamaz — önce bir sunumu diğerine uyacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya slaytın belirli bölgeleri için küçük resimler (thumbnail) oluşturabilir miyim ve bunlar yeni slayt boyutunu dikkate alır mı?**

Evet. Aspose.Slides, [tüm slaytlar](/reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) ve [seçili şekiller](/reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) için küçük resimler oluşturabilir. Oluşturulan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.