---
title: JavaScript'te Sunum Slayt Boyutunu Değiştirme
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/nodejs-java/slide-size/
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
- yeniden ölçekleme
- uygunluğu sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırmayı, kalite kaybı yaşamadan herhangi bir ekran için sunumları optimize etmeyi öğrenin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekranda görüntüleme için kritiktir. 

Popüler Slayt Boyutları ve Oranlar:

- **Standard (4:3 En–Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 En–Boy Oranı)**: Modern projektörler ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tüm slaytlara aynı slayt boyutu ve en‑boy oranı uygulanır. En iyi sonuçlar için, slayt boyutlarını sunum oluşturma sürecinin başında ayarlayın; böylece komplikasyonlardan kaçınırsınız.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak JavaScript'te bir sunumun slayt boyutunu nasıl değiştireceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sunumlarda Özel Slayt Boyutlarını Belirleme**

Eğer yaygın slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı tercih edebilirsiniz. Örneğin, sunumunuzdan tam boy slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız veya sunumunuzu belirli ekran tiplerinde görüntülemeyi düşünüyorsanız, özel bir boyut ayarı kullanmak size fayda sağlayabilir.

Bu örnek kod, Aspose.Slides for Node.js'i Java üzerinden kullanarak JavaScript'te bir sunum için özel bir slayt boyutu nasıl belirleyeceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4 kağıt boyutu
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sunumlarda Slayt Boyutunu Değiştirirken Oluşabilecek Sorunlarla Baş Etme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna sığacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl ilgileneceğini belirleyen bir ayar seçebilirsiniz.

Ne yapmayı veya elde etmeyi amaçladığınıza bağlı olarak, bu ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını İSTEMİYORSANIZ bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek istiyor ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını (böylece içeriği kaybetmezsiniz) sağlamasını istiyorsanız bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek istiyor ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız bu ayarı kullanın.

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarının nasıl kullanılacağını gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**İnç dışında birimlerle (örneğin, puan veya milimetre) özel bir slayt boyutu ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puan (point) birimini kullanır; 1 puan bir inçin 1/72’sine eşittir. Herhangi bir birimi (örneğin milimetre veya santimetre) puana dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, oluşturma sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek oluşturma ölçeği, bellek tüketimini artırır ve işlem süresini uzatır. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için yalnızca gerektiğinde oluşturma ölçeğini ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştirme](/slides/tr/nodejs-java/merge-presentation/) yapamazsınız — önce bir sunumu diğerine uyacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bir slaydın tek tek şekilleri veya belirli bölgeleri için küçük resimler oluşturabilir miyim ve yeni slayt boyutuna saygı gösterirler mi?**

Evet. Aspose.Slides, [tam slaytlar](/slides/tr/nodejs-java/aspose.slides/slide/#getImage) için olduğu gibi [seçili şekiller](/slides/tr/nodejs-java/aspose.slides/shape/#getImage) için de küçük resimler oluşturabilir. Oluşan görseller, mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.