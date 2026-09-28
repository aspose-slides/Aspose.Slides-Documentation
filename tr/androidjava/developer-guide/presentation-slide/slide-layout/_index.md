---
title: Android'de Slayt Düzenlerini Uygula veya Değiştir
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
- altyazılı içerik
- altyazılı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de Java aracılığıyla slayt düzenlerini uygulayın, oluşturun ve değiştirin; yer tutucular ekleyin, kullanılmayan düzenleri kaldırın ve alt bilgi görünürlüğünü kontrol edin."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzenin uygulanması, slaytlara tutarlı bir yapı kazandırırken her slaydın kendi içeriğini içermesine izin verir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusunu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda faydalıdır.

## **Düzen Mirasını Anlama**

Bir sunum üç ilgili seviyeye sahiptir:

1. A [ana slayt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
2. A [düzen slaytı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/) bir ana slayta aittir ve belirli bir yer tutucu düzenini tanımlar.
3. A [normal slayt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) bir düzen kullanır ve o slayt için girilen içeriği depolar.

Bir normal slayt, temasını ve biçimlendirmesini düzeninden devralır ve düzen, ana slayttan devralır. Normal bir slayta doğrudan ayarlanan bir değer, o seviyedeki devralınmış değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzen üzerinden oluşturulur, bu yer tutuculara girilen içerik ise normal slayta aittir.

Bir düzenten slayt oluşturmadan önce gerekli yer tutucuları ekleyin. Daha sonra bir düzene başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişki iki önemli sonuca sahiptir:

- Bir düzen üzerindeki devralınmış biçimlendirme veya mevcut yer tutucu geometrisinin değiştirilmesi, ona bağımlı tüm slaytları güncelleyebilir. Zaten kullanılan bir düzeni düzenlemeden önce, ona bağlı slaytları inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılamaz. Önce bağlı slaytlarını başka bir düzene atayın veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için [Slayt Ana](/slides/tr/androidjava/slide-master/) bölümüne bakın.

Bir slaytta veya paylaşılan bir düzen üzerinden devralınan logoları veya dekoratif ana şekilleri gizlemek için [Ana Grafiklerin Görünürlüğünü Kontrol Etme](/slides/tr/androidjava/slide-master/) bölümüne bakın. Örnek, aynı ana slaytı kullanan iki slaytı karşılaştırır.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını izlediğinde bir düzen tipi kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden ad bazlı seçim, kaynağı şablonu kontrol etmediğiniz sürece daha az güvenilir olur.

Şu örnek, ilk ana slaytta **Başlık ve İçerik** düzenini arar. Bu düzen bulunamazsa, kasıtlı olarak **Boş** düzenine geçer. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebilmesi nedeniyle gereklidir. Seçilen düzen daha sonra [ISlide.setLayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) yöntemiyle ilk normal slayta uygulanır.

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

Bir slaydın düzenini değiştirmek, slayda doğrudan eklenen sıradan şekilleri kaldırmaz. Ancak, yer tutucu konumları, devralınmış biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki uyum değişebilir; bu yüzden önemli derecede farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekle**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; yeni bir tane oluşturmaz. Bir düzen oluşturmak için hedef ana slaydın düzen koleksiyonunda [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) yöntemini çağırın.

Aşağıdaki örnek, her zaman `Report Title and Content` adlı yeni bir **Başlık ve İçerik** düzeni ekler ve ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

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

Şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda yalnızca bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmaktan ziyade onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekle**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) sunar.

| PowerPoint Yer Tutucusu              | `ILayoutPlaceholderManager` Metodu |
| ----------------------------------- | ----------------------------------- |
| ![İçerik](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![İçerik (Dikey)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Metin](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Metin (Dikey)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Resim](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Grafik](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tablo](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Ortam](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Çevrimiçi Görüntü](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Aşağıdaki örnek, **Boş** düzenin varlığını doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta ilgili yer tutucu şekillerini oluşturabilir.

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

{{% alert color="warning" title="Warning" %}}
Devralınmış biçimlendirme veya mevcut düzen yer tutucularının geometrisinin değiştirilmesi, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu, mevcut normal slaytlara geri eklenmez. Düzen değişikliklerini sunumun bir kopyasında test edin ve her bağımlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldır**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini, hiçbir normal slaytın referans vermediği düzenleri kaldırmak için kullanın. Yöntem hâlâ kullanılan düzenleri olduğu gibi bırakır.

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

Belirli bir düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) veya [getDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) yöntemini kullanın. [ILayoutSlide.remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#remove--) yöntemini çağırmadan önce bağlı slaytları başka bir düzene atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxeditexception/) hatası oluşturur.

## **Bir Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Et**

Bir düzenin kendi alt bilgi, slayt numarası ve tarih-saat yer tutucuları vardır. Bu yer tutucuları tek bir düzen için kontrol etmek üzere [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) yöntemini kullanın. Bu, örneğin içerik düzenlerinin alt bilgi göstermesi, başlık düzenlerinin göstermemesi gerektiğinde faydalıdır.

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

## **Ana Slayt ve Çocuk Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Et**

Bir ana slayt hiyerarşisi içinde tutarlı alt bilgi ayarları uygulamak için [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) yöntemini kullanın. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) iletme yöntemleri, ana slayt ve ona bağlı düzen slaytları ve normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedeflemez.

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

**Ana Slayt ile Düzen Slaytı Arasındaki Fark Nedir?**

Bir ana slayt, sunumun temasını ve ortak biçimlendirmesini tanımlar. Bir düzen slaytı, bir ana slayta aittir ve yer tutucuların yeniden kullanılabilir bir düzenini tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içerikleri depolar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. Hedef koleksiyona [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) yöntemiyle bir kopya ekleyin. Sunumlar arasında kopyalama yaparken, kaynak düzenin kullandığı yazı tiplerini, temaları, resimleri ve diğer kaynakları da doğrulayın.

**Halihazırda Kullanılan Bir Düzeni Değiştirirsem Ne Olur?**

Bağlı slaytlar, yerel olarak etkilenmiş biçimlendirmeyi veya nesneleri geçersiz kılmadıkça düzen değişikliklerini devralır. Yer tutucu geometrisi ve devralınan stil bu nedenle birden fazla slaytta aynı anda değişebilir. Düzeni düzenlemeden önce etkilenmiş slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) yöntemini kullanın.

**Hâlâ Kullanılan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxeditexception/) hatası fırlatır. Önce bağlı slaytları başka bir düzene atayın veya yalnızca referans alınmayan düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini kullanın.