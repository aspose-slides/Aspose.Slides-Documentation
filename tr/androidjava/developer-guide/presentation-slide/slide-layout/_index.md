---
title: Android'de Slayt Düzenlerini Uygulama veya Değiştirme
linktitle: Slayt Düzeni
type: docs
weight: 60
url: /tr/androidjava/slide-layout/
keywords:
- slayt düzeni
- içerik düzeni
- yer tutucu
- sunum tasarımı
- slayt tasarımı
- kullanılmayan düzen
- alt bilgi görünürlüğü
- başlık slaytı
- başlık ve içerik
- bölüm başlığı
- iki içerik
- karşılaştırma
- sadece başlık
- boş düzen
- başlıklı içerik
- başlıklı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de Java aracılığıyla slayt düzenlerini uygulayın, oluşturun ve değiştirin, yer tutucular ekleyin, kullanılmayan düzenleri kaldırın ve alt bilgi görünürlüğünü kontrol edin."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzenin uygulanması, slaytlara tutarlı bir yapı kazandırırken her slaytın kendi içeriğini içermesine izin verir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusunu ve genel amaçlı bir içerik yer tutucusunu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda faydalıdır.

## **Düzen Mirasını Anlamak**

Bir sunum üç ilgili seviyeye sahiptir:

1. Bir [master slayt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
2. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/) bir mastera aittir ve yer tutucuların belirli bir düzenini tanımlar.
3. Bir [normal slayt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) bir düzen kullanır ve o slayt için girilen içeriği depolar.

Bir normal slayt, temasını ve biçimlendirmesini düzeninden miras alır ve düzen, masterından miras alır. Normal bir slaytta doğrudan ayarlanan bir değer, o seviyedeki miras alınan değerin üzerine yazar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzen üzerinden üretilir, bu yer tutuculara girilen içerik ise normal slayta aittir.

Bir slayt oluşturmadan önce bir düzene gerekli yer tutucuları ekleyin. Daha sonra bir düzene başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişki iki önemli sonuca sahiptir:

- Bir düzen üzerindeki miras alınan biçimlendirmeyi veya mevcut yer tutucu geometrisini değiştirmek, ona bağlı tüm slaytları güncelleyebilir. Zaten kullanımda olan bir düzeni düzenlemeden önce, ona bağlı slaytları inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılamaz. Önce bağlı slaytlarını başka bir düzene yeniden atayın veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için [Slide Master](/slides/tr/androidjava/slide-master/) bölümüne bakın.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını izlediğinde bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu nedenle ad tabanlı seçim, kaynağı şablonu kontrol etmediğiniz sürece daha az güvenilir olur.

Aşağıdaki örnek, ilk masterda **Başlık ve İçerik** arar. Bu düzen mevcut değilse, kasıtlı olarak **Boş** seçeneğine geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği durum için gereklidir. Seçilen düzen daha sonra [ISlide.setLayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) yöntemi aracılığıyla ilk normal slayta uygulanır.

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

Bir slaytın düzenini değiştirmek, slayta doğrudan eklenmiş sıradan şekilleri kaldırmaz. Ancak, yer tutucu konumları, miras alınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu nedenle, önemli ölçüde farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekleme**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; bir düzen oluşturmaz. Bir düzen oluşturmak için, hedef masterın düzen koleksiyonunda [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) yöntemini çağırın.

Aşağıdaki örnek, her zaman `Report Title and Content` adlı yeni bir **Başlık ve İçerik** düzeni ekler ve ardından ona dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

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

Bir şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopyasını oluşturmak yerine onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucu Ekleme**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu | `ILayoutPlaceholderManager` Method |
| --------------------- | ---------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Aşağıdaki örnek, **Boş** düzenin var olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta ilgili yer tutucu şekillerini oluşturabilir.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Miras alınan biçimlendirmeyi veya mevcut düzen yer tutucularının geometrisini değiştirmek, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara geri eklenmez. Düzen değişikliklerini sunumun bir kopyasında test edin ve her bağımlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini, hiçbir normal slaytın başvurduğu bir düzeni kaldırmak için kullanın. Yöntem, hâlâ kullanımda olan düzenleri olduğu gibi bırakır.

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

Belirli bir düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) veya [getDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) yöntemini kullanın. [ILayoutSlide.remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#remove--) yöntemini çağırmadan önce bağımlı slaytları yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxeditexception/) hatasına yol açar.

## **Bir Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir düzenin kendi alt bilgi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek amacıyla [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) yöntemini kullanın. Bu, örneğin içerik düzenlerinin alt bilgileri gösterirken başlık düzenlerinin göstermemesi gerektiğinde faydalıdır.

Aşağıdaki örnek, bir düzeni güvenli bir şekilde seçer ve onun alt bilgi öğelerini görünür yapar:

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

## **Bir Master ve Çocuk Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir master hiyerarşisi boyunca tutarlı alt bilgi ayarları uygulamak için [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) yöntemini kullanın. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) yöntemlerinin yayılımı, master ve ona bağlı düzen slaytları ile normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedeflemez.

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

Bir master slayt, sunumun temasını ve ortak biçimlendirmesini tanımlar. Bir düzen slaytı, bir mastera aittir ve yer tutucuların yeniden kullanılabilir bir düzenini tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) yöntemiyle hedef koleksiyona bir kopya ekleyin. Sunumlar arasında kopyalama yaparken, kaynak düzenin kullandığı yazı tiplerini, temaları, resimleri ve diğer kaynakları da doğrulayın.

**Zaten Kullanımda Olan Bir Düzeni Değiştirdiğimde Ne Olur?**

Bağlı slaytlar, yerel olarak etkilenen biçimlendirmeyi veya nesneleri geçersiz kılmadıkça düzen değişikliklerini miras alır. Bu nedenle yer tutucu geometrisi ve miras alınan stil, birçok slaytta aynı anda değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxeditexception/) hatası verir. Önce bağlı slaytları yeniden atayın veya yalnızca referans edilmeyen düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini kullanın.