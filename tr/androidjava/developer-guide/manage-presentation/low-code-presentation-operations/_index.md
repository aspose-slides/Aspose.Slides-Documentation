---
title: Android'de Düşük Kodlu Sunum İşlemleri
linktitle: Düşük Kodlu API
type: docs
weight: 50
url: /tr/androidjava/low-code-presentation-operations/
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
- Android
- Java
- Aspose.Slides
description: "Android'de Aspose.Slides düşük kodlu API'yi kullanarak sunumları dönüştürün ve birleştirin, içerikte dolaşın, şekilleri toplayın ve sunum boyutunu azaltın."
---
## **Genel Bakış**

[com.aspose.slides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) paketi, yaygın sunum işlemleri için statik yardımcı sınıflar sağlar. Bu yardımcılar, sık kullanılan nesne‑modeli iş akışlarını odaklanmış yöntemlerde sarar; böylece dosyaları dönüştürebilir veya birleştirebilir, sunum öğelerini işleyebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Düşük‑kodlu yardımcılar, işlem tüm bir dosya veya sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinizi karşıladığında en faydalıdır. Bireysel slaytlar, ana slaytlar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı kontrol gerektiğinde tam [Aspose.Slides nesne modeli](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıların özetini sunar:

| Yardımcı | Ne için kullanılır |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/convert/) | Bir sunumu doğrudan dosya‑dosya çağrısıyla başka bir formata dönüştürmek. |
| [Merger](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/merger/) | Aynı formatta tam sunum dosyalarını birleştirmek. |
| [ForEach](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/) | Her slayt, şekil, paragraf veya metin bölümü için bir eylem çalıştırmak. |
| [Collect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/collect/) | Tekrar eden işleme veya analiz için tüm sunumdaki şekilleri almak. |
| [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) | Kullanılmayan ana slaytları ve düzenleri kaldırmak ve gömülü yazı tipi verilerini azaltmak. |

## **Sunumu Dönüştürme**

Çıktı dosya uzantısının ihracat formatını seçmek için yeterli olduğu durumlarda [Convert.autoByExtension](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) kullanın. Yöntem kaynak sunumu açar, çıktı yolundan gerekli formatı belirler ve sonucu yazar.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel yöntemler sağlar. Dönüştürmeden önce sunumu incelemeniz veya değiştirmemeniz, ya da yardımcı sınıfın sunmadığı bir dışa aktarma seçeneği yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçime özgü iş akışları ve seçenekler için [Sunumu Dönüştürme](/slides/tr/androidjava/convert-presentation/) sayfasına bakın.

## **Sunumları Birleştirme**

Tam bir çağrı ile tam sunum dosyalarını birleştirmek için [Merger.process](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) kullanın. Giriş sunumları aynı dosya formatında olmalıdır.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Tüm slaytların tek bir sonuca seçilmeden veya yeniden eşleştirilmeden eklenmesi gerektiğinde bu yardımcı uygundur. Seçili slaytları birleştirmeniz, bir hedef ana slayt veya düzen uygulamanız, bölümleri açıkça korumanız veya farklı slayt boyutlarını uyumlu hâle getirmeniz gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Sunumları Birleştirme](/slides/tr/androidjava/merge-presentation/) sayfasına bakın.

## **Sunum Öğeleri Üzerinde Döngü**

[ForEach](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/) sınıfı, istenen her sunum öğesi tipi için bir geri çağırma (callback) yürütür. İç içe koleksiyon döngülerini önler ve sunum genelinde inceleme veya biçimlendirme değişiklikleri için uygundır.

Aşağıdaki örnek, ilgili öğeleri incelemek için [ForEach.slide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) ve [ForEach.portion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) kullanır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Varsayılan olarak, sunum genelindeki şekil ve metin dolaşımı normal, ana ve düzen slaytlarını içerir. `includeNotes` parametresiyle aşırı yüklemeler, not slaytlarını da işleyebilir. Dolaşım sırası, erken çıkış, geri çağırma öncesi filtreleme veya ayrıntılı ebeveyn‑çocuk kontrolünün önemli olduğu durumlarda doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Toplama**

Her şekil için bir geri çağırma yerine bir sunumdaki tüm şekillerin koleksiyonuna ihtiyacınız varsa [Collect.shapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) kullanın. Aynı küme birden fazla kez filtrelenecek, sayılacak veya işlenecekse bu yararlıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Her şekil hemen işlenebiliyorsa ve toplanan sonucu saklamaya ihtiyacınız yoksa [ForEach.shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) yerine onu kullanın.

## **Sunum İçeriğini Sıkıştırma**

[Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) sınıfı kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verilerini azaltabilir:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) hiçbir normal slaytın referans almadığı düzen slaytlarını kaldırır.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) artık kullanılmayan ana slaytları kaldırır.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) gömülü yazı tiplerinden kullanılmayan karakterleri kaldırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kullanılmayan düzenleri, kullanılmayan ana slaytlardan önce kaldırın; böylece düzen temizliğinden sonra referanssız kalan bir ana slayt da kaldırılabilir. Optimize edilmiş sunumu, orijinal ana slaytlara, düzenlere veya tam gömülü yazı tipi verilerine daha sonra ihtiyaç duyabilecekseniz yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/slides/tr/androidjava/slide-master/) ve [Embedded Font](/slides/tr/androidjava/embedded-font/) sayfalarına bakın.

## **SSS**

**Düşük kodlu API'yi tam nesne modeline ne zaman kullanmalıyım?**

Standart bir işlem tüm bir dosya veya sunuma uygulandığında ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmediğinde düşük kodlu yardımcıları kullanın. Belirli slaytları seçmeniz, ana ve düzen ilişkilerini kontrol etmeniz, ara durumu incelemeniz veya yardımcı sınıfın sunmadığı bir davranışı yapılandırmanız gerektiğinde tam nesne modelini kullanın.

**Merger farklı dosya biçimlerinde sunumları birleştirebilir mi?**

Hayır. [Merger.process](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) aynı formatta giriş sunumları gerektirir. Önce giriş dosyalarını ortak bir formata dönüştürün; örneğin [Convert.autoByExtension](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) kullanarak, ardından dönüştürülmüş dosyaları birleştirin.

**ForEach ana, düzen ve not slaytlarını işliyor mu?**

[ForEach.slide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) normal sunum slaytları üzerinde döner. Sunum genelinde [ForEach.shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) ve [ForEach.portion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) işlemleri varsayılan olarak normal, ana ve düzen slaytlarını içerir. Not slaytlarını dahil etmek için `includeNotes` parametresini `true` olarak ayarlayan aşırı yüklemelerini kullanın.

**ForEach.shape ile Collect.shapes arasındaki fark nedir?**

[ForEach.shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) her şekli hemen bir geri çağırma ile işler. Tekrar kullanılabilecek, filtrelenebilecek veya birden çok kez sayılabilecek bir iterable sonuç gerektiğinde [Collect.shapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) kullanın.

**Compress her zaman sunum dosyasını küçültür mü?**

Zorunlu değildir. Sonuç, sunumda kullanılmayan düzenler, kullanılmayan ana slaytlar veya kullanılmayan karakterlere sahip gömülü yazı tipleri olup olmamasına bağlıdır. Bu unsurlardan hiçbiri yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**

Hayır. Bu yardımcılar, bellek içindeki yüklü [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/) geri çağırması içinde öğeleri değiştirdikten veya [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) çalıştırdıktan sonra sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) çağırın.

## **İlgili Makaleler**

- [Sunumu Dönüştürme](/slides/tr/androidjava/convert-presentation/)
- [Sunumları Birleştirme](/slides/tr/androidjava/merge-presentation/)
- [Slide Master](/slides/tr/androidjava/slide-master/)
- [Manage Text Box](/slides/tr/androidjava/manage-textbox/)
- [Embedded Font](/slides/tr/androidjava/embedded-font/)