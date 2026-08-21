---
title: JavaScript'te Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/nodejs-java/low-code-presentation-operations/
keywords:
- düşük kodlu sunum API'si
- sunumu dönüştür
- sunumları birleştir
- slaytları yinele
- şekilleri yinele
- metni yinele
- şekilleri topla
- sunumu sıkıştır
- kullanılmayan ana slaytları kaldır
- kullanılmayan düzen slaytlarını kaldır
- gömülü yazı tiplerini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te Aspose.Slides düşük kodlu API'sini kullanarak sunumları dönüştürün ve birleştirin, içerikte dolaşın, şekilleri toplayın ve sunum boyutunu azaltın."
---
## **Genel Bakış**

`aspose.slides` ad alanı, yaygın sunum işlemleri için statik yardımcı sınıflar sağlar. Bu yardımcılar, sık kullanılan nesne‑model iş akışlarını odaklanmış yöntemlerde sarar, böylece dosyaları dönüştürebilir veya birleştirebilir, sunum öğelerini işleyebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Kod azdırıcı yardımcılar, işlem tüm bir dosya veya sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinize uyduğunda en faydalıdır. Bireysel slaytlar, ana slaytlar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı kontrol gerektiğinde tam [Aspose.Slides object model](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıları özetler:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/convert/) | Bir sunumu doğrudan dosya‑dosya çağrısıyla başka bir biçime dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/merger/) | Aynı biçimdeki tam sunum dosyalarını birleştirme. |
| [ForEach](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/) | Her slayt, şekil, paragraf veya metin parçası için bir eylem çalıştırma. |
| [Collect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/collect/) | Tekrarlanan işleme veya analiz için tüm sunumdan şekilleri geri alma. |
| [Compress](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/) | Kullanılmayan ana slaytları ve düzenleri kaldırma ve gömülü yazı tipi verilerini azaltma. |

## **Sunumu Dönüştür**

[Convert.autoByExtension](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/convert/#autoByExtension) çıkış dosyası uzantısının dışa aktarma biçimini seçmek için yeterli olduğu durumlarda kullanın. Yöntem kaynak sunumu açar, çıkış yolundan gerekli biçimi belirler ve sonucu yazar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıkışı için özel yöntemler sunar. Dışa aktarmadan önce sunumu incelemeniz veya değiştirmeniz veya seçili yardımcı tarafından sunulmayan bir dışa aktarım seçeneği yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçim‑özel iş akışları ve seçenekler için [Sunumu Dönüştür](/nodejs-java/convert-presentation/) sayfasına bakın.

## **Sunumları Birleştir**

[Merger.process](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/merger/#process) bir çağrı ile tam sunum dosyalarını birleştirmek için kullanın. Girdi sunumları aynı dosya biçiminde olmalıdır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Tüm slaytların tek bir sonuçta birleştirilmesi ve her birinin ayrı ayrı seçilip yeniden eşlenmemesi gerektiğinde bu yardımcı uygundur. Seçili slaytları birleştirmeniz, hedef bir ana slayt veya düzen uygulamanız, bölümleri açıkça korumanız veya farklı slayt boyutlarını uzlaştırmanız gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Sunumları Birleştir](/nodejs-java/merge-presentation/) sayfasına bakın.

## **Sunum Öğeleri Üzerinde Dolaşın**

[ForEach](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/) sınıfı, istenen türdeki her sunum öğesi için bir geri arama (callback) çalıştırır. İç içe koleksiyon döngülerini önler ve sunum‑geneli denetim veya biçimlendirme değişiklikleri için uygundur. Node.js ortamında, geri arama arabirimlerinin uygulamalarını `java.newProxy` ile oluşturabilirsiniz.

Aşağıdaki örnek, ilgili öğeleri incelemek için [ForEach.slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#paragraph) ve [ForEach.portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#portion) kullanımını gösterir:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Varsayılan olarak, sunum‑geneli şekil ve metin geçişi normal, ana ve düzen slaytlarını içerir. `includeNotes` parametresiyle aşırı yüklenmiş sürümler not slaytlarını da işleyebilir. Geçiş sırası, erken çıkış, geri aramadan önce filtreleme veya ayrıntılı ebeveyn‑çocuk kontrolünün önemli olduğu durumlarda doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Topla**

[Collect.shapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/collect/#shapes) bir sunumdaki tüm şekillerin koleksiyonuna ihtiyaç duyduğunuzda, her şekil için bir geri arama yerine bunu kullanın. Aynı küme birden fazla kez filtrelenecek, sayılacak veya işlenecekse bu özellikle yararlıdır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Her şekil hemen işlenebiliyorsa ve topladığınız sonucu saklamanıza gerek yoksa bunun yerine [ForEach.shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#shape) kullanın.

## **Sunum İçeriğini Sıkıştır**

[Compress](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/) sınıfı, kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verilerini azaltabilir:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) hiçbir normal slaytın referans vermediği düzen slaytlarını kaldırır.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) artık kullanılmayan ana slaytları kaldırır.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) gömülü yazı tiplerinden kullanılmayan karakterleri kaldırır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kullanılmayan düzenleri, kullanılmayan ana slaytlardan önce kaldırın; böylece düzen temizliğinin ardından referanssız kalan bir ana slayt da kaldırılabilir. Orijinal ana slaytlar, düzenler veya tam gömülü yazı tipi verilerine daha sonra ihtiyaç duyabileceğiniz durumlar için optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/nodejs-java/slide-master/) ve [Embedded Font](/nodejs-java/embedded-font/) sayfalarına bakın.

## **SSS**

**Kod azdırıcı API'yi tam nesne modeli yerine ne zaman kullanmalıyım?**

Standart bir işlem tüm bir dosya veya sunuma uygulanıyor ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmiyorsa kod azdırıcı yardımcıları kullanın. Belirli slaytları seçmeniz, ana ve düzen ilişkilerini kontrol etmeniz, ara durumu incelemeniz veya yardımcı tarafından sunulmayan davranışı yapılandırmanız gerektiğinde tam nesne modelini kullanın.

**Merger farklı dosya biçimlerinde sunumları birleştirebilir mi?**

Hayır. [Merger.process](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/merger/#process) aynı biçimdeki giriş sunumlarını gerektirir. Önce girdi dosyalarını ortak bir biçime dönüştürün, örneğin [Convert.autoByExtension](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/convert/#autoByExtension) ile, ardından dönüştürülmüş dosyaları birleştirin.

**ForEach ana, düzen ve not slaytlarını işliyor mu?**

[ForEach.slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#slide) normal sunum slaytlarını iterasyona alır. Sunum‑geneli [ForEach.shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#paragraph) ve [ForEach.portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#portion) işlemleri varsayılan olarak normal, ana ve düzen slaytlarını içerir. Not slaytlarını da dahil etmek için `includeNotes` parametresini `true` olarak ayarlayan aşırı yüklemelerini kullanın.

**ForEach.shape ile Collect.shapes arasındaki fark nedir?**

Her şekli geri arama ile hemen işlemek istiyorsanız [ForEach.shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#shape) kullanın. Şekilleri tutabilir, filtreleyebilir, sayabilir veya birden çok kez dolaşmak istediğinizde iterable bir sonuç gerektiğinde [Collect.shapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/collect/#shapes) kullanın.

**Compress her zaman sunum dosyasını küçültür mü?**

Mutlaka değil. Sonuç, sunumun kullanılmayan düzenler, kullanılmayan ana slaytlar veya kullanılmayan karakterlere sahip gömülü yazı tipleri içerip içermediğine bağlıdır. Bu öğeler yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar, bellekteki yüklü [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/) geri aramasında veya [Compress](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metodunu çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştür](/nodejs-java/convert-presentation/)
- [Sunumları Birleştir](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)