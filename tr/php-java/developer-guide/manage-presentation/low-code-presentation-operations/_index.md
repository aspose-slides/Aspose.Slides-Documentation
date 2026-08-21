---
title: PHP'de Düşük-Kod Sunum İşlemleri
linktitle: Düşük-Kod API
type: docs
weight: 50
url: /tr/php-java/low-code-presentation-operations/
keywords:
- düşük-kod sunum API
- sunumu dönüştür
- sunumları birleştir
- slaytları yinele
- şekilleri yinele
- metni yinele
- şekilleri topla
- sunumu sıkıştır
- kullanılmayan ana slaytları kaldır
- kullanılmayan düzen slaytlarını kaldır
- gömülü fontları sıkıştır
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides düşük-kod API'sini kullanarak sunumları dönüştürüp birleştirin, içerikte dolaşın, şekilleri toplayın ve sunum boyutunu küçültün."
---
## **Genel Bakış**

[aspose.slides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/) ad alanı, yaygın sunum işlemleri için statik yardımcı sınıflar sağlar. Bu yardımcılar, sık kullanılan nesne‑model iş akışlarını odaklanmış metodlarda sarar, böylece dosyaları dönüştürebilir veya birleştirebilir, sunum öğelerini işleyebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Düşük‑kodlu yardımcılar, işlem tüm bir dosya veya sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinize uyduğunda en faydalıdır. Bireysel slaytlar, masterlar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı kontrol gerektiğinde tam [Aspose.Slides object model](https://reference.aspose.com/slides/tr/php-java/aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıları özetler:

| Yardımcı | Ne İçin Kullanılır |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/php-java/aspose.slides/convert/) | Sunumu başka bir formata, doğrudan dosya‑dosya çağrısıyla dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/php-java/aspose.slides/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [ForEach_](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/) | Her slayt, şekil, paragraf veya metin bölümü için bir geri çağırma çalıştırma. |
| [Collect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/collect/) | Tekrar tekrar işlemek veya analiz etmek için tüm sunumdan şekilleri alma. |
| [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) | Kullanılmayan master ve düzenleri kaldırma ve gömülü font verilerini azaltma. |

## **Sunumu Dönüştürme**

Çıktı dosya uzantısının dışa aktarma formatını seçmek için yeterli olduğu durumlarda [Convert::autoByExtension](https://reference.aspose.com/slides/tr/php-java/aspose.slides/convert/#autoByExtension) kullanın. Metot, kaynak sunumu açar, çıktının yolundan gerekli formatı belirler ve sonucu yazar.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/php-java/aspose.slides/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel metodlar sunar. Dışa aktarmadan önce sunumu incelemeniz veya değiştirmeniz ya da seçilen yardımcıda bulunmayan bir dışa aktarma seçeneğini yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçim‑özel iş akışları ve seçenekler için [Sunumu Dönüştür](/php-java/convert-presentation/) sayfasına bakın.

## **Sunumları Birleştirme**

Tam bir çağrı ile tam sunum dosyalarını birleştirmek için [Merger::process](https://reference.aspose.com/slides/tr/php-java/aspose.slides/merger/#process) kullanın. Girdi sunumlarının aynı dosya biçiminde olması gerekir.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Tüm slaytların tek bir sonuç dosyasına eklenmesi ve bireysel olarak seçilip yeniden eşlenmemesi gerektiğinde bu yardımcı uygundur. Seçili slaytları birleştirmeniz, hedef bir master veya düzen uygulamanız, bölümleri açıkça korumanız veya farklı slayt boyutlarını uzlaştırmanız gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Sunumları Birleştirme](/php-java/merge-presentation/) sayfasına bakın.

## **Sunum Öğeleri Üzerinde Dolaşma**

[ForEach_](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/) sınıfı, istenen sunum öğesi tipinin her örneği için bir geri çağırma yürütür. İç içe koleksiyon döngülerini önler ve sunum‑geneli denetim veya biçimlendirme değişiklikleri için kullanışlıdır.

Aşağıdaki örnek, ilgili öğeleri incelemek için [ForEach_::slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#paragraph) ve [ForEach_::portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#portion) kullanır:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Varsayılan olarak, sunum‑geneli şekil ve metin geçişi normal, master ve layout slaytlarını içerir. `includeNotes` parametresiyle aşırı yüklemeler, not slaytlarını da işleyebilir. Geçiş sırası, erken çıkış, geri çağırmadan önce filtreleme veya ayrıntılı ebeveyn‑çocuk kontrolü önemli olduğunda doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Toplama**

Her şekil için bir geri çağırma yerine bir sunumdaki tüm şekillerin koleksiyonuna ihtiyacınız varsa [Collect::shapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/collect/#shapes) kullanın. Aynı küme birden çok kez filtrelenecek, sayılacak veya işlenecekse bu faydalıdır.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Her şekil anında işlenebiliyorsa ve toplanan sonucu tutmanıza gerek yoksa yerine [ForEach_::shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#shape) kullanın.

## **Sunum İçeriğini Sıkıştırma**

[Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) sınıfı, kullanılmayan yapı öğelerini kaldırabilir ve gömülü font verilerini azaltabilir:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) normal slaytların referans vermediği layout slaytlarını kaldırır.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedMasterSlides) artık kullanılmayan master slaytlarını kaldırır.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#compressEmbeddedFonts) gömülü fontlardaki kullanılmayan karakterleri kaldırır.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kullanılmayan layoutları, kullanılmayan masterlardan önce kaldırın; böylece layout temizliğinden sonra referanssız kalan master da silinebilir. Orijinal master, layout veya tam gömülü font verilerine daha sonra ihtiyaç duyabilecekseniz optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/php-java/slide-master/) ve [Embedded Font](/php-java/embedded-font/) sayfalarına bakın.

## **SSS**

**Düşük‑kodlu API'yi tam nesne modeline göre ne zaman kullanmalıyım?**

Standart bir işlem tüm dosya ya da sunuma uygulanıyorsa ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmiyorsa düşük‑kodlu yardımcıları kullanın. Belirli slaytları seçmeniz, master‑layout ilişkilerini kontrol etmeniz, ara durumları incelemeniz veya yardımcı tarafından sunulmayan davranışları yapılandırmanız gerektiğinde tam nesne modelini tercih edin.

**Merger farklı dosya biçimlerindeki sunumları birleştirebilir mi?**

Hayır. [Merger::process](https://reference.aspose.com/slides/tr/php-java/aspose.slides/merger/#process) aynı biçimdeki giriş sunumlarını gerektirir. Önce giriş dosyalarını ortak bir formata dönüştürün; örneğin [Convert::autoByExtension](https://reference.aspose.com/slides/tr/php-java/aspose.slides/convert/#autoByExtension) ile, ardından dönüştürülmüş dosyaları birleştirin.

**ForEach_ master, layout ve not slaytlarını işliyor mu?**

[ForEach_::slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#slide) normal sunum slaytları üzerinde dolaşır. Sunum‑geneli [ForEach_::shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#paragraph) ve [ForEach_::portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#portion) işlemleri varsayılan olarak normal, master ve layout slaytlarını içerir. Not slaytlarını dahil etmek için `includeNotes` parametresini `true` olarak ayarlayan aşırı yüklemelerini kullanın.

**ForEach_::shape ile Collect::shapes arasındaki fark nedir?**

Her şekli bir geri çağırma içinde hemen işlemek istiyorsanız [ForEach_::shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#shape) kullanın. Şekilleri toplamak, daha sonra filtrelemek, saymak veya birden çok kez dolaşmak istiyorsanız [Collect::shapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/collect/#shapes) tercih edin.

**Compress her zaman sunum dosyasını küçültür mü?**

Mutlaka değil. Sonuç, sunumda kullanılmayan layoutların, kullanılmayan masterların veya kullanılmayan karakterlere sahip gömülü fontların bulunup bulunmadığına bağlıdır. Bu öğeler yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach_ veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar, bellekte yüklü olan [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach_](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/) geri çağırmasında öğeleri değiştirdikten veya [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) metodunu çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştür](/php-java/convert-presentation/)
- [Sunumları Birleştirme](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)