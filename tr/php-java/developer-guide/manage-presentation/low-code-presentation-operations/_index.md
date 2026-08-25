---
title: PHP'de Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/php-java/low-code-presentation-operations/
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
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides düşük kodlu API'sini kullanarak sunumları dönüştürün ve birleştirin, içerikte dolaşın, şekilleri topla ve sunum boyutunu azaltın."
---
## **Genel Bakış**

[aspose.slides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/) ad alanı, ortak sunum işlemleri için statik yardımcı sınıflar sağlar. Bu yardımcılar, sık kullanılan nesne‑model iş akışlarını odaklanmış yöntemlerle sarmalar; böylece dosyaları dönüştürebilir veya birleştirebilir, sunum öğelerini işleyebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Low-code yardımcılar, işlem tüm bir dosya veya sunum üzerine uygulandığında ve varsayılan iş akışı gereksinimlerinizi karşıladığında en yararlıdır. Bireysel slaytlar, master’lar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı kontrol gerektiğinde tam [Aspose.Slides nesne modelini](https://reference.aspose.com/slides/tr/php-java/aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıların özetini sunar:

| Yardımcı | Kullanım Amacı |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/php-java/aspose.slides/convert/) | Bir sunumu doğrudan dosyadan dosyaya çağrı ile başka bir biçime dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/php-java/aspose.slides/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [ForEach_](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/) | Her slayt, şekil, paragraf veya metin parçası için geri arama çalıştırma. |
| [Collect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/collect/) | Tekrar işleme veya analiz için tüm sunumdan şekilleri alma. |
| [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) | Kullanılmayan master ve düzenleri kaldırma ve gömülü yazı tipi verilerini azaltma. |

## **Bir Sunumu Dönüştürme**

[Convert::autoByExtension](https://reference.aspose.com/slides/tr/php-java/aspose.slides/convert/#autoByExtension) çıktının dosya uzantısının dışa aktarım biçimini seçmek için yeterli olduğu durumlarda kullanın. Yöntem kaynak sunumu açar, çıkış yolundan gerekli biçimi belirler ve sonucu yazar.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/php-java/aspose.slides/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel yöntemler sağlar. Dışa aktarmadan önce sunumu incelemeniz veya değiştirmeniz gerektiğinde ya da seçili yardımcı tarafından sunulmamış bir dışa aktarım seçeneği yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçime özgü iş akışları ve seçenekler için [Convert Presentation](/slides/tr/php-java/convert-presentation/) sayfasına bakın.

## **Sunumları Birleştirme**

[Merger::process](https://reference.aspose.com/slides/tr/php-java/aspose.slides/merger/#process) tam sunum dosyalarını tek bir çağrıyla birleştirmek için kullanılır. Girdi sunumlarının aynı dosya biçimine sahip olması gerekir.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Tüm slaytların tek bir sonuca eklenmesi gerektiğinde ve bireysel olarak seçilip yeniden eşleştirilmesi gerekmediğinde bu yardımcı uygundur. Seçili slaytları birleştirmeniz, hedef bir master veya düzen uygulamanız, bölümleri açıkça korumanız veya farklı slayt boyutlarını uzlaştırmanız gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Merge Presentations](/slides/tr/php-java/merge-presentation/) sayfasına bakın.

## **Sunum Öğeleri Üzerinde Dönme**

[ForEach_](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/) sınıfı, istenen sunum öğesi türü için bir geri arama çağırır. İç içe koleksiyon döngülerini önler ve sunum geneli denetim veya biçimlendirme değişiklikleri için kullanışlıdır.

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

Varsayılan olarak, sunum geneli şekil ve metin geçişi normal, master ve layout slaytlarını içerir. `includeNotes` parametresiyle aşırı yüklemeler not slaytlarını da işleyebilir. Geçiş sırası, erken çıkış, geri aramadan önce filtreleme veya ayrıntılı üst‑alt kontrolünün önemli olduğu durumlarda doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Toplama**

[Collect::shapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/collect/#shapes) tüm sunumdaki şekillerin bir koleksiyonuna ihtiyacınız olduğunda ve her şekil için bir geri arama yerine bu koleksiyonu tekrar‑tekrar filtrelemek, saymak veya işlemek istediğinizde kullanın.

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

Her şekil anında işlenebiliyorsa ve toplanan sonucu tutmanız gerekmiyorsa bunun yerine [ForEach_::shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#shape) kullanın.

## **Sunum İçeriğini Sıkıştırma**

[Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) sınıfı kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verilerini azaltabilir:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) normal bir slaytın referans vermediği düzen slaytlarını kaldırır.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedMasterSlides) artık kullanılmayan master slaytları kaldırır.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#compressEmbeddedFonts) gömülü yazı tiplerinden kullanılmayan karakterleri kaldırır.

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

Kullanılmayan masterları da kaldırmak için önce kullanılmayan düzenleri kaldırın; böylece düzen temizliğinden sonra referanssız kalan bir master da silinebilir. Orijinal master, layout veya tam gömülü yazı tipi verilerine daha sonra ihtiyaç duyulabilecekse, optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/slides/tr/php-java/slide-master/) ve [Embedded Font](/slides/tr/php-java/embedded-font/) sayfalarına bakın.

## **SSS**

**Low-code API'yi tam nesne modeline ne zaman kullanmalıyım?**

Standart bir işlem tüm bir dosya veya sunum üzerine uygulandığında ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmediğinde low-code yardımcıları kullanın. Belirli slaytları seçmeniz, master‑layout ilişkilerini kontrol etmeniz, ara durumu incelemeniz veya yardımcı tarafından sunulmayan bir davranışı yapılandırmanız gerektiğinde tam nesne modelini tercih edin.

**Merger farklı dosya biçimlerindeki sunumları birleştirebilir mi?**

Hayır. [Merger::process](https://reference.aspose.com/slides/tr/php-java/aspose.slides/merger/#process) giriş sunumlarının aynı biçimde olmasını şart koşar. Önce giriş dosyalarını ortak bir biçime dönüştürün; örneğin [Convert::autoByExtension](https://reference.aspose.com/slides/tr/php-java/aspose.slides/convert/#autoByExtension) kullanarak, ardından dönüştürülen dosyaları birleştirin.

**ForEach_ master, layout ve not slaytlarını işliyor mu?**

[ForEach_::slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#slide) normal sunum slaytları üzerinde döner. Sunum geneli [ForEach_::shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#paragraph) ve [ForEach_::portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#portion) işlemleri varsayılan olarak normal, master ve layout slaytlarını içerir. Not slaytlarını dahil etmek için `includeNotes` parametresini `true` olarak ayarlayan aşırı yüklemelerini kullanın.

**ForEach_::shape ile Collect::shapes arasındaki fark nedir?**

Her şekli anında bir geri arama ile işlemek istiyorsanız [ForEach_::shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/#shape) kullanın. Şekilleri daha sonra tutup filtreleyebileceğiniz, sayabileceğiniz veya birden çok kez dolaşabileceğiniz bir iterable sonuç gerektiğinde ise [Collect::shapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/collect/#shapes) tercih edin.

**Compress sunum dosyasını her zaman küçültür mü?**

Mutlaka değil. Sonuç, sunumda kullanılmayan layout'lar, kullanılmayan master'lar veya kullanılmayan karakterlere sahip gömülü yazı tiplerinin bulunup bulunmadığına bağlıdır. Bu öğeler yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach_ veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar bellekte yüklü [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach_](https://reference.aspose.com/slides/tr/php-java/aspose.slides/foreach_/) geri aramasında ya da [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) çalıştırıldığında, sonucu yazmak için [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) çağırmanız gerekir.

## **İlgili Makaleler**

- [Convert Presentation](/slides/tr/php-java/convert-presentation/)
- [Merge Presentations](/slides/tr/php-java/merge-presentation/)
- [Slide Master](/slides/tr/php-java/slide-master/)
- [Manage Text Box](/slides/tr/php-java/manage-textbox/)
- [Embedded Font](/slides/tr/php-java/embedded-font/)