---
title: Java'da Slayt Düzenlerini Uygula veya Değiştir
linktitle: Slayt Düzeni
type: docs
weight: 60
url: /tr/java/slide-layout/
keywords:
- slayt düzeni
- içerik düzeni
- yer tutucu
- sunum tasarımı
- slayt tasarımı
- kullanılmayan düzen
- altbilgi görünürlüğü
- başlık slaytı
- başlık ve içerik
- bölüm başlığı
- iki içerik
- karşılaştırma
- sadece başlık
- boş düzen
- altyazılı içerik
- altyazılı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da slayt düzenlerini uygulayın, oluşturun ve değiştirin, yer tutucular ekleyin, kullanılmayan düzenleri kaldırın ve altbilgi görünürlüğünü kontrol edin."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzen uygulamak, slaytlara tutarlı bir yapı verir ve aynı zamanda her slaydın kendi içeriğini içermesine olanak tanır.

En yaygın düzenler şunlardır:

- **Title Slide**: Başlık ve alt başlık yer tutucularını içerir.
- **Title and Content**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Blank**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda kullanışlıdır.

## **Düzen Kalıtımını Anlayın**

Bir sunum üç ilgili seviyeye sahiptir:

1. Bir [master slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
2. Bir [layout slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/) bir mastera aittir ve yer tutucuların belirli bir düzenini tanımlar.
3. Bir [normal slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) bir düzen kullanır ve o slayta girilen içeriği saklar.

Bir normal slayt, düzeninden temayı ve biçimlendirmeyi miras alır, ve düzen de masterından miras alır. Normal bir slayta doğrudan ayarlanan bir değer, o seviyedeki miras alınan değeri geçersiz kılar. Normal bir slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzen üzerinden üretilir, ancak bu yer tutuculara girilen içerik normal slayta aittir.

Bir slayt oluşturulmadan önce gerekli yer tutucuları düzene ekleyin. Bir düzene daha sonra başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişkinin iki önemli sonucu vardır:

- Bir düzen üzerindeki kalıtılan biçimlendirme veya mevcut yer tutucu geometrisini değiştirmek, ona bağımlı olan tüm slaytları güncelleyebilir. Zaten kullanılan bir düzeni düzenlemeden önce, bağımlı slaytlarını inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılamaz. Önce bağımlı slaytlarını başka bir düzene atayın veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için [Slide Master](/slides/tr/java/slide-master/) sayfasına bakın.

Tek bir slaytta veya ortak bir düzen üzerinden kalıtılan logoları ya da süslemeli master şekillerini gizlemek için [Control the Visibility of Master Graphics](/slides/tr/java/slide-master/) sayfasına bakın. Örnek, aynı masterı kullanan iki slaytı karşılaştırır.

## **Bir Slayt Düzeni Seçin ve Uygulayın**

Sunum standart PowerPoint düzen tanımlarını izlediğinde bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu nedenle kaynak şablonun kontrolü yoksa ad‑bazlı seçim daha az güvenilir olur.

Aşağıdaki örnek, ilk masterda **Title and Content** arar. Bu düzen mevcut değilse, kasıtlı olarak **Blank** düzene geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği durumlar için gereklidir. Seçilen düzen daha sonra [ISlide.setLayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) yöntemiyle ilk normal slayta uygulanır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bir slaytın düzenini değiştirmek, doğrudan slayta eklenmiş normal şekilleri kaldırmaz. Ancak, yer tutucu konumları, miras alınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu yüzden önemli ölçüde farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekleyin**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; oluşturmaz. Bir düzen oluşturmak için hedef masterın düzen koleksiyonunda [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) yöntemini çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adlı yeni bir **Title and Content** düzeni ekler, ardından bu düzeni temel alan bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmaktan ziyade onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekleyin**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) yöntemi, bir düzene yer tutucu şekiller eklemek için bir [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucusu | `ILayoutPlaceholderManager` Yöntemi |
| ----------------------- | ----------------------------------- |
| ![İçerik](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![İçerik (Dikey)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Metin](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Metin (Dikey)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Resim](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Grafik](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tablo](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Ortam](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Çevrimiçi Görüntü](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Aşağıdaki örnek, **Blank** düzeninin mevcut olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilen düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta karşılık gelen yer tutucu şekillerini oluşturabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Düzen slaytındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Miras alınan biçimlendirme veya mevcut düzen yer tutucularının geometrisini değiştirmek, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara geriye doğru eklenmez. Düzen değişikliklerini sunumun bir kopyası üzerinde test edin ve her bağımlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırın**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini kullanarak hiçbir normal slayt tarafından referans edilmeyen düzenleri kaldırın. Yöntem hâlâ kullanılan düzenleri olduğu gibi bırakır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Belirli bir düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) veya [getDependingSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) yöntemini kullanın. [ILayoutSlide.remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#remove--) metodunu çağırmadan önce bağımlı slaytları yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxeditexception/) oluşturur.

## **Bir Düzen Slaytında Altbilgi Görünürlüğünü Kontrol Edin**

Bir düzenin kendi altbilgi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) metodunu kullanın. Bu, örneğin içerik düzenlerinin altbilgi göstermesi, başlık düzenlerinin göstermemesi gerektiğinde faydalıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Master ve Alt Düzenlerinde Altbilgi Görünürlüğünü Kontrol Edin**

Master hiyerarşisi genelinde tutarlı altbilgi ayarları uygulamak için [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) metodunu kullanın. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslideheaderfootermanager/) nesnesinin yayma yöntemleri master, bağımlı düzen slaytları ve normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedef almaz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Master Slayt ile Düzen Slaytı Arasındaki Fark Nedir?**

Master slayt, sunumun temasını ve ortak biçimlendirmesini tanımlar. Düzen slaytı bir mastera aittir ve yeniden kullanılabilir bir yer tutucu düzeni tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği saklar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) yöntemiyle hedef koleksiyona bir kopya ekleyin. Sunumlar arasında kopyalarken, kaynak düzenin kullandığı yazı tipleri, temalar, görseller ve diğer kaynakları da doğrulayın.

**Zaten Kullanımda Olan Bir Düzeni Değiştirdiğimde Ne Olur?**

Bağımlı slaytlar, yerel olarak etkilenilen biçimlendirme veya nesneleri geçersiz kılmadıkları sürece düzen değişikliklerini miras alır. Yer tutucu geometrisi ve miras alınan stil, birçok slaytta aynı anda değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxeditexception/) fırlatır. Önce bağımlı slaytları başka bir düzene atayın veya yalnızca referans edilmeyen düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini kullanın.