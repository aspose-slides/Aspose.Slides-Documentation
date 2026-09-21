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
- ekran türü
- yeniden ölçekleme yok
- uyumu sağla
- büyüt
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlıca yeniden boyutlandırmayı, kalite kaybı olmadan herhangi bir ekran için sunumları optimize etmeyi öğrenin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarındaki slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem yazdırma hem de ekranda görüntüleme için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En-Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En-Boy Oranı)**: Modern projektörler ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için, karmaşıklıkları önlemek adına slayt boyutlarını sunum oluşturma sürecinin başında ayarlayın.

{{% alert color="info" title="Note" %}}
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

Not ve el ilanı sayfaları, normal slaytlardan ayrı boyutlara sahiptir. Boyutlarını ve yönlerini değiştirmek için [Not Sayfası Boyutu](/slides/tr/nodejs-java/notes-size/) sayfasına bakın.

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak JavaScript'te bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Sunumlarda Özel Slayt Boyutlarını Belirtme**

Yaygın slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmaya karar verebilirsiniz. Örneğin, sunumunuzdan tam boyutta slaytlar yazdırmayı özel bir sayfa düzenine göre planlıyorsanız ya da sunumunuzu belirli ekran türlerinde görüntülemeyi amaçlıyorsanız, özel bir boyut ayarı kullanmanız faydalı olacaktır.

Bu örnek kod, JavaScript'te bir sunum için özel slayt boyutu belirtmek amacıyla Node.js için Aspose.Slides'i Java üzerinden nasıl kullanacağınızı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Sunumlarda Slayt Boyutu Değiştirilirken Oluşabilecek Sorunlarla Baş etme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna sığacak şekilde otomatik olarak yeniden boyutlandırılır. Ancak, sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içeriği nasıl ele alacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya neyi başarmayı amaçladığınıza bağlı olarak, aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Eğer slaytlardaki nesnelerin yeniden boyutlandırılmasını İSTEMİYORSANIZ, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını sağlamak (bu şekilde içeriği kaybetmezsiniz) istiyorsanız, bu ayarı kullanın.

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın.

Bu örnek kod, `Maximize` ayarını bir sunumun slayt boyutunu değiştirirken nasıl kullanacağınızı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

**İnç dışındaki birimler (örneğin, puan veya milimetre) kullanarak özel bir slayt boyutu belirleyebilir miyim?**

Evet. Aspose.Slides dahili olarak puan kullanır; 1 puan 1/72 inçe eşittir. Milimetre veya santimetre gibi herhangi bir birimi puana dönüştürüp, bu dönüştürülmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

**Çok büyük bir özel slayt boyutu, renderleme sırasında performans ve bellek kullanımını etkiler mi?**

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek render ölçeği, bellek tüketimini artırır ve işlem süresini uzatır. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesine ulaşmak için render ölçeğini yalnızca gerektiğinde ayarlayın.

**Tek bir standart dışı slayt boyutu tanımlayıp, farklı boyutlara sahip sunumlardan slaytları birleştirebilir miyim?**

Farklı slayt boyutlarına sahip olduğu sürece [sunumları birleştiremezsiniz](/slides/tr/nodejs-java/merge-presentation/) — önce bir sunumu diğerine uyacak şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl işlendiğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları hizaladıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

**Bireysel şekiller veya bir slaydın belirli bölgeleri için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutunu dikkate alır mı?**

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) ve [seçili şekiller](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage) için küçük resimler oluşturabilir. Oluşturulan görüntüler mevcut slayt boyutu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.