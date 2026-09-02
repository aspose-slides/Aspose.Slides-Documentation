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
- kullanılmayan master slaytları kaldır
- kullanılmayan düzen slaytlarını kaldır
- gömülü yazı tiplerini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te Aspose.Slides düşük kodlu API'sini kullanarak sunumları dönüştürün ve birleştirin, içerikte yineleme yapın, şekilleri toplayın ve sunum boyutunu küçültün."
---
## **Genel Bakış**

`aspose.slides` ad alanı, ortak sunum işlemleri için statik yardımcı sınıflar sağlar. Bu yardımcılar, sık kullanılan nesne modeli iş akışlarını odaklanmış metodlarla sarar; böylece dosyaları dönüştürebilir veya birleştirebilir, sunum öğelerini işleyebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Düşük kodlu yardımcılar, işlem bir bütün dosya veya sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinize uyduğunda en faydalıdır. Tek tek slaytlar, masterlar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı kontrol gerektiğinde tam [Aspose.Slides nesne modeli](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıları özetler:

| Yardımcı | Ne İçin Kullanılır |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/convert/) | Bir sunumu doğrudan dosya-dosya çağrısıyla başka bir biçime dönüştürmek. |
| [Merger](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/merger/) | Aynı biçimdeki tam sunum dosyalarını birleştirmek. |
| [ForEach](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/) | Her slayt, şekil, paragraf veya metin bölümü için bir eylem çalıştırmak. |
| [Collect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/collect/) | Tekrar işleme veya analiz için tüm sunumdaki şekilleri almak. |
| [Compress](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/) | Kullanılmayan master ve düzenleri kaldırmak ve gömülü yazı tipi verilerini azaltmak. |

## **Sunumu Dönüştür**

Çıktı dosya uzantısının dışa aktarma biçimini seçmek için yeterli olduğu durumlarda [Convert.autoByExtension](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/convert/#autoByExtension) kullanın. Metot, kaynak sunumu açar, çıktı yolundan gerekli biçimi belirler ve sonucu yazar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel metodlar sunar. Dışa aktarmadan önce sunumu incelemeniz veya değiştirmeniz ya da seçilen yardımcı tarafından sunulmayan bir dışa aktarma seçeneği yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçime özgü iş akışları ve seçenekler için [Convert Presentation](/slides/tr/nodejs-java/convert-presentation/) sayfasına bakın.

## **Sunumları Birleştir**

Tam sunum dosyalarını tek bir çağrı ile birleştirmek için [Merger.process](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/merger/#process) kullanın. Giriş sunumlarının aynı dosya biçiminde olması gerekir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Bu yardımcı, tüm slaytların tek bir sonuca eklenmesi gerektiğinde, her birini ayrı ayrı seçme veya yeniden eşleme yapmadan uygundur. Seçili slaytları birleştirmeniz, bir hedef master veya düzen uygulamanız, bölümleri açıkça korumanız veya farklı slayt boyutlarını uyumlu hâle getirmeniz gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Merge Presentations](/slides/tr/nodejs-java/merge-presentation/) sayfasına bakın.

## **Sunum Öğeleri Üzerinde Yineleme**

[ForEach](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/) sınıfı, istenen her sunum öğesi türü için bir geri çağırma (callback) tetikler. İç içe koleksiyon döngülerinden kaçınır ve sunum genelinde denetleme veya biçimlendirme değişiklikleri için uygundur. Node.js'de geri çağırma arabirimlerinin implementasyonlarını `java.newProxy` ile oluşturun.

Aşağıdaki örnek, ilgili öğeleri incelemek için [ForEach.slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#paragraph) ve [ForEach.portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#portion) kullanır:

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

Varsayılan olarak, sunum genelindeki şekil ve metin dolaşımı normal, master ve düzen slaytlarını içerir. `includeNotes` parametresi olan aşırı yüklemeler not slaytlarını da işleyebilir. Dolaşım sırası, erken çıkış, geri çağırmadan önce filtreleme veya ayrıntılı ebeveyn-çocuk kontrolü önemli olduğunda doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Topla**

Her şekil için bir geri çağırma yerine, bir sunumdaki tüm şekillerin koleksiyonuna ihtiyacınız olduğunda [Collect.shapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/collect/#shapes) kullanın. Aynı küme birden fazla kez filtrelenecek, sayılacak veya işlenecekse bu faydalıdır.

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

Her şekil hemen işlenebiliyorsa ve toplanan sonucu saklamanıza gerek yoksa bunun yerine [ForEach.shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#shape) kullanın.

## **Sunum İçeriğini Sıkıştır**

[Compress](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/) sınıfı kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verilerini azaltabilir:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) normal bir slaytın başvurmadığı düzen slaytlarını kaldırır.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) artık kullanılmayan master slaytları kaldırır.
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

Kullanılmayan düzenleri, kullanılmayan masterlardan önce kaldırın; böylece düzen temizliğinden sonra başvurulmayan bir master da kaldırılabilir. Orijinal master, düzen veya tam gömülü yazı tipi verilerine daha sonra ihtiyaç duyulabilecekse optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/slides/tr/nodejs-java/slide-master/) ve [Embedded Font](/slides/tr/nodejs-java/embedded-font/) sayfalarına bakın.

## **SSS**

**Düşük kodlu API'yi tam nesne modeline göre ne zaman kullanmalıyım?**

Düşük kodlu yardımcıları, standart bir işlem bir bütün dosya veya sunuma uygulanıyorsa ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmiyorsa kullanın. Belirli slaytları seçmeniz, master ve düzen ilişkilerini kontrol etmeniz, ara durumu incelemeniz veya yardımcı tarafından sunulmayan bir davranışı yapılandırmanız gerektiğinde tam nesne modelini kullanın.

**Merger farklı dosya formatlarındaki sunumları birleştirebilir mi?**

Hayır. [Merger.process](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/merger/#process) aynı formatta giriş sunumları gerektirir. Giriş dosyalarını ortak bir formata, örneğin [Convert.autoByExtension](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/convert/#autoByExtension) ile dönüştürün, ardından dönüştürülmüş dosyaları birleştirin.

**ForEach master, layout ve not slaytlarını işliyor mu?**

[ForEach.slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#slide) normal sunum slaytları üzerinde yineleme yapar. Sunum genelinde [ForEach.shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#paragraph) ve [ForEach.portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#portion) işlemleri varsayılan olarak normal, master ve layout slaytlarını içerir. Not slaytlarını dahil etmek için `includeNotes` parametresini `true` olarak ayarlayın.

**ForEach.shape ile Collect.shapes arasındaki fark nedir?**

[ForEach.shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/#shape) her şekli hemen bir geri çağırma ile işler. [Collect.shapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/collect/#shapes) ise saklanabilir, filtrelenebilir, sayılabilir veya birden fazla kez dolaşılabilir bir iterable sonuç gerektiğinde kullanılır.

**Compress her zaman sunum dosyasını küçültür mü?**

Zorunlu değildir. Sonuç, sunumda kullanılmayan düzenler, kullanılmayan masterlar veya kullanılmayan karakterlere sahip gömülü yazı tipleri olup olmamasına bağlıdır. Bunlardan hiçbiri yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar, bellekte yüklü [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/foreach/) geri çağırma içinde öğeleri değiştirdikten veya [Compress](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metodunu çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştür](/slides/tr/nodejs-java/convert-presentation/)
- [Sunumları Birleştir](/slides/tr/nodejs-java/merge-presentation/)
- [Slayt Master](/slides/tr/nodejs-java/slide-master/)
- [Metin Kutusunu Yönet](/slides/tr/nodejs-java/manage-textbox/)
- [Gömülü Yazı Tipi](/slides/tr/nodejs-java/embedded-font/)