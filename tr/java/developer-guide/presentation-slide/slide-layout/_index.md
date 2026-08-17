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
- yalnızca başlık
- boş düzen
- başlıklı içerik
- başlıklı resim
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

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzen uygulamak, slaytlara tutarlı bir yapı kazandırır ve her slaytın kendi içeriğini içermesine olanak tanır.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda kullanışlıdır.

## **Düzen Kalıtımını Anlayın**

Bir sunum üç ilgili seviyeye sahiptir:

1. A [ana slayt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) temayı, paylaşılan biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
2. A [düzen slaytı](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/) bir ana slayta aittir ve belirli bir yer tutucu düzenini tanımlar.
3. A [normal slayt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) bir düzen kullanır ve o slayt için girilen içeriği saklar.

Bir normal slayt, temasını ve biçimlendirmesini düzeninden devralır ve düzen, anasından devralır. Normal bir slayta doğrudan ayarlanan bir değer, bu seviyedeki devralınan değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçili düzen üzerinden üretilir; bu yer tutuculara girilen içerik ise normal slayta aittir.

Bir slayt oluşturulmadan önce bir düzene gerekli yer tutucular ekleyin. Daha sonra bir düzene başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişkinin iki önemli sonucu vardır:

- Bir düzen üzerindeki devralınan biçimlendirmeyi veya mevcut yer tutucu geometrisini değiştirmek, ona bağımlı olan her slaytı güncelleyebilir. Kullanımda olan bir düzeni düzenlemeden önce, bağımlı slaytlarını inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt hâlâ kullandığı bir düzen kaldırılamaz. Önce bağımlı slaytlarını başka bir düzene yeniden atayın veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için [Slayt Ana Şablonu](/slides/tr/java/slide-master/) bölümüne bakın.

## **Bir Slayt Düzeni Seçin ve Uygulayın**

Sunum standart PowerPoint düzen tanımlarını izliyorsa bir düzen tipi kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden kaynak şablonu kontrol etmiyorsanız ad‑tabanlı seçim daha az güvenilirdir.

Aşağıdaki örnek, ilk ana üzerinde **Başlık ve İçerik** arar. Bu düzen bulunamazsa, kasıtlı olarak **Boş** düzenine geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği durum için gereklidir. Seçilen düzen ardından ilk normal slayta [ISlide.setLayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) yöntemiyle uygulanır.

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

Bir slaytın düzenini değiştirmek, slayta doğrudan eklenen sıradan şekilleri kaldırmaz. Ancak, yer tutucu konumları, devralınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki ilişki değişebilir; bu yüzden büyük ölçüde farklı düzenler arasında geçiş yaptığınızda çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekleyin**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; bir tane oluşturmaz. Bir düzen oluşturmak için hedef ana slaydın düzen koleksiyonunda [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) yöntemini çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adında yeni bir **Başlık ve İçerik** düzeni ekler, ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

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

Şablon gerçekten başka bir tekrar kullanılabilir yapı gerektirdiğinde bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmaktansa onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekleyin**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu | `ILayoutPlaceholderManager` Metodu |
| --------------------- | ---------------------------------- |
| ![İçerik](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![İçerik (Dikey)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Metin](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Metin (Dikey)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Resim](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Grafik](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tablo](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Medya](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Çevrimiçi Görüntü](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Aşağıdaki örnek, **Boş** düzeninin var olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides bu slaytta karşılık gelen yer tutucu şekillerini üretebilir.

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

![Düzen slaydındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Uyarı" %}}
Devralınan biçimlendirmeyi veya mevcut düzen yer tutucularının geometrisini değiştirmek, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara geri eklenmez. Düzen değişikliklerini bir sunum kopyası üzerinde test edin ve her bağımlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırın**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini kullanarak hiçbir normal slayt tarafından başvurulmayan düzenleri kaldırın. Yöntem hâlâ kullanımda olan düzenleri olduğu gibi bırakır.

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

Belirli bir düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) veya [getDependingSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) yöntemini kullanın. Bağımlı slaytları [ILayoutSlide.remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#remove--) çağırmadan önce yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxeditexception/) fırlatır.

## **Bir Düzen Slaytında Altbilgi Görünürlüğünü Kontrol Edin**

Bir düzenin kendi altbilgi, slayt‑numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) yöntemini kullanın. Bu, örneğin içerik düzenlerinin altbilgi göstermesi, başlık düzenlerinin ise göstermemesi gerektiğinde faydalıdır.

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

## **Bir Ana Şablonda ve Çocuk Düzenlerinde Altbilgi Görünürlüğünü Kontrol Edin**

Bir ana şablon hiyerarşisi boyunca tutarlı altbilgi ayarları uygulamak için [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) yöntemini kullanın. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslideheaderfootermanager/) yayılım yöntemleri ana şablon, ona bağlı düzen slaytları ve normal slaytlar üzerinde çalışır; sadece tek bir normal slaytı hedeflemez.

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

**Bir Ana Slayt ile Bir Düzen Slaytı Arasındaki Fark Nedir?**

Bir ana slayt, sunumun temasını ve paylaşılan biçimlendirmesini tanımlar. Bir düzen slaytı, bir ana slayta aittir ve yer tutucuların yeniden kullanılabilir bir düzenini tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği saklar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. Hedef koleksiyona bir kopya eklemek için [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) yöntemini kullanın. Sunumlar arasında kopyalarken, kaynak düzenin kullandığı yazı tiplerini, temaları, görüntüleri ve diğer kaynakları da doğrulayın.

**Kullanımda Olan Bir Düzeni Değiştirirsem Ne Olur?**

Bağımlı slaytlar, yerel olarak etkilenmiş biçimlendirmeyi veya nesneleri geçersiz kılmadıkları sürece düzen değişikliklerini devralır. Yer tutucu geometrisi ve devralınan stil bu nedenle birçok slaytta bir anda değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxeditexception/) fırlatır. Önce bağımlı slaytları yeniden atayın veya yalnızca başvurulmayan düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini kullanın.