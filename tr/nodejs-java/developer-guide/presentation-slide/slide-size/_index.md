---
title: JavaScript ile Sunum Slayt Boyutunu Değiştirme
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/nodejs-java/slide-size/
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
- uygunluğu sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
descriptions: "Node.js ve Aspose.Slides ile PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırmayı öğrenin, kalite kaybı olmadan herhangi bir ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides PowerPoint sunumlarında slayt boyutu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekrandaki görüntüleme için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 Aspect Ratio)**: Eski ekranlar ve cihazlar için idealdir.
- **Widescreen (16:9 Aspect Ratio)**: Modern projeksiyon cihazları ve göstergeler için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, karmaşıklığı önlemek amacıyla sunum oluşturma sürecinin başında slayt boyutlarınızı ayarlayın.

{{% alert color="primary" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, JavaScript'te Aspose.Slides kullanarak bir sunumun slayt boyutunu nasıl değiştireceğinizi gösterir:

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

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı tercih edebilirsiniz. Örneğin, sunumunuzu özel bir sayfa düzeninde tam boyutta yazdırmayı ya da belirli ekran tiplerinde göstermek istiyorsanız, özel bir boyut ayarı kullanmak sizin için faydalı olacaktır.

Bu örnek kod, JavaScript'te Node.js için Aspose.Slides'i Java aracılığıyla kullanarak bir sunum için özel bir slayt boyutu belirlemenizi gösterir:

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

## **Sunumlarda Slayt Boyutu Değiştirirken Oluşabilecek Sorunlarla Baş Etme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytlardaki içerikler (örneğin resimler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içeriklerle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmak istediğinize bağlı olarak aşağıdaki ayarlardan birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **istemiyorsanız**, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek ve tüm nesnelerin slaytlara sığmasını sağlamak (içeriğin kaybolmasını önlemek) için Aspose.Slides'in nesneleri küçültmesini istiyorsanız, bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek ve nesnelerin yeni slayt boyutuna göre orantılı olarak büyütülmesini istiyorsanız, bu ayarı kullanın.

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarını nasıl kullanacağınızı gösterir:

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

**Slayt boyutunu inç dışındaki birimlerle (örneğin puan veya milimetre) ayarlayabilir miyim?**

Evet. Aspose.Slides dahili olarak puanları kullanır; 1 puan 1/72 inçtir. Milimetre veya santimetre gibi birimleri puana dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliği olarak tanımlayabilirsiniz.

**Çok büyük bir özel slayt boyutu render sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan olarak) ve yüksek render ölçeği, bellek tüketimini artırır ve işlem sürelerini uzatır. Pratik bir slayt boyutu hedefleyin ve yalnızca gereken kaliteyi elde etmek için render ölçeğini ayarlayın.

**Farklı boyutlarda olan sunumlardan slaytları birleştirirken tek bir standart dışı slayt boyutu tanımlayıp sonra birleştirebilir miyim?**

Farklı slayt boyutlarına sahip iken [merge presentations](/slides/tr/nodejs-java/merge-presentation/) yapamazsınız — önce bir sunumu diğerine eşitleyecek şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken mevcut içeriğin nasıl ele alınacağını [SlideSizeScaleType](/reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları eşitledikten sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya slaydın belirli bölgeleri için küçük resimler (thumbnail) oluşturabilir miyim ve bunlar yeni slayt boyutunu dikkate alır mı?**

Evet. Aspose.Slides, [entire slides](/reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) ve [selected shapes](/reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage) için küçük resimler oluşturabilir. Oluşturulan görseller mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeve ve geometri sağlar.