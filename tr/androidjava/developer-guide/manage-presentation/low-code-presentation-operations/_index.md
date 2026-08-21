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
- kullanılmayan master slaytları kaldır
- kullanılmayan düzen slaytlarını kaldır
- gömülü yazı tiplerini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Android'de Aspose.Slides düşük kodlu API'yi kullanarak sunumları dönüştürüp birleştirin, içeriği yineleyin, şekilleri toplayın ve sunum boyutunu küçültün."
---
## **Genel Bakış**

[com.aspose.slides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) paketi, yaygın sunum işlemleri için statik yardımcı sınıflar sağlar. Bu yardımcılar, sık kullanılan nesne‑model iş akışlarını odaklanmış yöntemlerde paketler, böylece dosyaları dönüştürebilir veya birleştirebilir, sunum öğelerini işleyebilir, şekilleri toplayabilir ve kullanılmayan içeriği daha az kodla kaldırabilirsiniz.

Düşük kodlu yardımcılar, işlem tüm dosya veya sunuma uygulandığında ve varsayılan iş akışı gereksinimlerinize uyduğunda en faydalıdır. Bireysel slaytlar, masterlar, düzenler, şekiller, dışa aktarma ayarları veya sunum öğeleri arasındaki ilişkiler üzerinde ayrıntılı kontrol gerektiğinde tam [Aspose.Slides object model](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) kullanın.

Aşağıdaki tablo mevcut yardımcıları özetlemektedir:

| Yardımcı | Ne için kullanılır |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/convert/) | Sunumu doğrudan dosya‑dosya çağrısı ile başka bir formata dönüştürme. |
| [Merger](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/merger/) | Aynı formatta tam sunum dosyalarını birleştirme. |
| [ForEach](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/) | Her slayt, şekil, paragraf veya metin parçası için bir eylem çalıştırma. |
| [Collect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/collect/) | Tekrarlı işleme veya analiz için tüm sunumdan şekilleri alma. |
| [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) | Kullanılmayan master ve düzenleri kaldırma ve gömülü yazı tipi verilerini azaltma. |

## **Sunumu Dönüştürme**

Çıktı dosya uzantısı dışa aktarma formatını seçmek için yeterli olduğunda [Convert.autoByExtension](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) kullanın. Yöntem, kaynak sunumu açar, çıktı yolundan gerekli formatı belirler ve sonucu yazar.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/convert/) sınıfı ayrıca PDF, SVG, JPEG, PNG ve TIFF çıktısı için özel yöntemler sunar. Dışa aktarmadan önce sunumu incelemeniz veya değiştirmeniz ya da seçilen yardımcı tarafından sunulmayan bir dışa aktarma seçeneği yapılandırmanız gerektiğinde tam nesne modelini kullanın. Biçim‑özel iş akışları ve seçenekler için [Convert Presentation](/androidjava/convert-presentation/) sayfasına bakın.

## **Sunumları Birleştirme**

[Merger.process](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) tek bir çağrı ile tam sunum dosyalarını birleştirir. Girdi sunumlarının aynı dosya formatında olması gerekir.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Bu yardımcı, tüm slaytların tek bir sonuca eklenmesi gerektiğinde, her bir slaytı ayrı ayrı seçmeye veya yeniden eşleştirmeye gerek kalmadan uygundur. Seçili slaytları birleştirmeniz, hedef bir master veya düzen uygulamanız, bölümleri açıkça korumanız veya farklı slayt boyutlarını uzlaştırmanız gerektiğinde tam nesne modelini kullanın. Bu senaryolar için [Merge Presentations](/androidjava/merge-presentation/) sayfasına bakın.

## **Sunum Öğeleri Üzerinde Dolaşma**

[ForEach](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/) sınıfı, istenen her sunum öğesi türü için bir geri çağırma (callback) çalıştırır. İç içe koleksiyon döngülerini önler ve sunum çapında denetim veya biçimlendirme değişiklikleri için uygundur.

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

Varsayılan olarak, sunum çapında şekil ve metin dolaşımı normal, master ve düzen slaytlarını içerir. `includeNotes` parametresiyle gelen aşırı yüklemeler not slaytlarını da işleyebilir. Dolaşım sırası, erken çıkış, geri çağırmadan önce filtreleme veya ayrıntılı üst‑alt kontrolünün önemli olduğu durumlarda doğrudan koleksiyon döngüleri kullanın.

## **Şekilleri Toplama**

[Collect.shapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) tüm sunumdaki şekillerin bir koleksiyonuna ihtiyacınız olduğunda, her şekil için bir geri çağırma yerine kullanın. Aynı kümenin birden fazla kez filtrelenmesi, sayılması veya işlenmesi gerektiğinde faydalıdır.

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

Her şekil hemen işlenebiliyorsa ve topladığınız sonucu saklamanıza gerek yoksa bunun yerine [ForEach.shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) kullanın.

## **Sunum İçeriğini Sıkıştırma**

[Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) sınıfı, kullanılmayan yapısal öğeleri kaldırabilir ve gömülü yazı tipi verilerini azaltabilir:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) kullanılmayan bir normal slaytın referans vermediği düzen slaytlarını kaldırır.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) artık kullanılmayan master slaytlarını kaldırır.
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

Kullanılmayan masterların da kaldırılabilmesi için önce kullanılmayan düzenler kaldırılmalıdır; böylece düzen temizliği sonrasında referanssız kalan bir master da silinebilir. Orijinal masterları, düzenleri veya tam gömülü yazı tipi verilerini ileride ihtiyaç duyabilecekseniz optimize edilmiş sunumu yeni bir dosyaya kaydedin. Daha fazla ayrıntı için [Slide Master](/androidjava/slide-master/) ve [Embedded Font](/androidjava/embedded-font/) sayfalarına bakın.

## **SSS**

**Düşük kodlu API'yi tam nesne modeline ne zaman kullanmalıyım?**  
Standart bir işlem tüm dosya veya sunuma uygulanıyor ve bireysel öğeler üzerinde ayrıntılı kontrol gerektirmiyorsa düşük kodlu yardımcıları kullanın. Belirli slaytları seçmeniz, master‑ve‑düzen ilişkilerini yönetmeniz, ara durumu incelemeniz veya yardımcı tarafından sunulmayan bir davranışı yapılandırmanız gerektiğinde tam nesne modelini tercih edin.

**Merger farklı dosya formatlarındaki sunumları birleştirebilir mi?**  
Hayır. [Merger.process](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) aynı formatta giriş sunumları gerektirir. Önce giriş dosyalarını ortak bir formata dönüştürün; örneğin [Convert.autoByExtension](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) ile ve ardından dönüştürülmüş dosyaları birleştirin.

**ForEach master, layout ve not slaytlarını işliyor mu?**  
[ForEach.slide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) yalnızca normal sunum slaytlarını dolaşır. Sunum çapında [ForEach.shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) ve [ForEach.portion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) işlemleri varsayılan olarak normal, master ve layout slaytlarını içerir. Not slaytlarını dahil etmek için `includeNotes` parametresi `true` olarak ayarlanan aşırı yüklemeleri kullanın.

**ForEach.shape ile Collect.shapes arasındaki fark nedir?**  
Her şekli anında bir geri çağırma ile işlemek istiyorsanız [ForEach.shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) kullanın. Şekilleri bir koleksiyon olarak saklamak, ardından filtrelemek, saymak veya birden çok kez dolaşmak istiyorsanız [Collect.shapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) tercih edin.

**Compress her zaman sunum dosyasını küçültür mü?**  
Mutlaka. Sonuç, sunumda kullanılmayan düzenler, kullanılmayan masterlar veya kullanılmayan karakterlere sahip gömülü yazı tipleri olup olmadığına bağlıdır. Bu unsurlardan hiçbiri yoksa ilgili [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) işlemleri dosya boyutunu azaltmayabilir.

**ForEach veya Compress tarafından yapılan değişiklikler otomatik olarak kaydedilir mi?**  
Hayır. Bu yardımcılar, bellekte yüklü olan [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) nesnesi üzerinde çalışır. Bir [ForEach](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/foreach/) geri çağırması içinde öğeleri değiştirdikten ya da [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) işlemini çalıştırdıktan sonra sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu çağırın.

## **İlgili Makaleler**

- [Convert Presentation](/androidjava/convert-presentation/)
- [Merge Presentations](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Manage Text Box](/androidjava/manage-textbox/)
- [Embedded Font](/androidjava/embedded-font/)