---
title: JavaScript'te Slayt Düzenlerini Uygula veya Değiştir
linktitle: Slayt Düzeni
type: docs
weight: 60
url: /tr/nodejs-java/slide-layout/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile slayt düzenlerini uygula, oluştur ve değiştir, yer tutucular ekle, kullanılmayan düzenleri kaldır ve alt bilgi görünürlüğünü kontrol et."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzeni uygulamak, slaytlara tutarlı bir yapı kazandırır ve her slaytın kendi içeriğini içermesine izin verir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda faydalıdır.

## **Düzen Kalıtımını Anlamak**

Bir sunum üç ilgili seviyeye sahiptir:

1. Bir [master slaytı](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
2. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) bir mastera aittir ve belirli bir yer tutucu düzenini tanımlar.
3. Bir [normal slayt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/) bir düzen kullanır ve o slayt için girilen içeriği depolar.

Bir normal slayt temayı ve biçimlendirmeyi düzeninden devralır ve düzen de masterından devralır. Normal bir slaytta doğrudan ayarlanan bir değer, o seviyedeki devralınan değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzen üzerinden üretilir, bu yer tutuculara girilen içerik ise normal slayta aittir.

Bir slayt oluşturulmadan önce düzene gerekli yer tutucular ekleyin. Daha sonra düzene başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişki iki önemli sonuca sahiptir:

- Bir düzen üzerinde devralınan biçimlendirme veya mevcut yer tutucu geometrisini değiştirmek, ona bağlı tüm slaytları güncelleyebilir. Zaten kullanımdaki bir düzeni düzenlemeden önce, bağlı slaytları inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılmaz. Önce bağlı slaytları başka bir düzene atayın veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için, [Slayt Masterı](/slides/tr/nodejs-java/slide-master/) sayfasına bakın.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını izlediğinde bir [SlideLayoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidelayouttype/) değeri kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu nedenle ad tabanlı seçim, kaynak şablonun kontrolü altında olmadıkça daha az güvenilirdir.

Aşağıdaki örnek, ilk masterda **Başlık ve İçerik** düzenini arar. Bu düzen mevcut değilse, bilinçli olarak **Boş** düzenine geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği için gereklidir. Seçilen düzen daha sonra [Slide.setLayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#setLayoutSlide) yöntemiyle ilk normal slayta uygulanır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bir slaytın düzenini değiştirmek, slayta doğrudan eklenen sıradan şekilleri kaldırmaz. Ancak, yer tutucu konumları, devralınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu nedenle, önemli ölçüde farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekleme**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; bir tane yaratmaz. Bir düzen oluşturmak için hedef masterın düzen koleksiyonunda [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) yöntemini çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adlı yeni bir **Başlık ve İçerik** düzeni ekler ve ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmak yerine onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekleme**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu              | `LayoutPlaceholderManager` Yöntemi |
| ----------------------------------- | ----------------------------------- |
| ![İçerik](content.png)             | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![İçerik (Dikey)](contentV.png)    | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Metin](text.png)                 | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Metin (Dikey)](textV.png)        | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Resim](picture.png)              | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafik](chart.png)               | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tablo](table.png)                | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)          | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Medya](media.png)                | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Çevrimiçi Resim](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Aşağıdaki örnek, **Boş** düzeninin varlığını doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta karşılık gelen yer tutucu şekilleri üretebilir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Düzen slaydındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Uyarı" %}}
Devralınan biçimlendirme veya mevcut düzen yer tutucularının geometrisini değiştirmek, bağlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara geri eklenmez. Düzen değişikliklerini sunumun bir kopyasında test edin ve tüm bağlı slaytları inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini, hiçbir normal slaytın başvurduğu olmayan düzenleri kaldırmak için kullanın. Yöntem hâlâ kullanılan düzenleri olduğu gibi bırakır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Belirli bir düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) veya [getDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın. [LayoutSlide.remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#remove) yöntemini çağırmadan önce bağlı tüm slaytları yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxeditexception/) hatasına neden olur.

## **Bir Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir düzenin kendi alt bilgi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) yöntemini kullanın. Bu, örneğin içerik düzenlerinin alt bilgi göstermesi, ancak başlık düzenlerinin göstermemesi gerektiğinde kullanışlıdır.

Aşağıdaki örnek, bir düzeni güvenli bir şekilde seçer ve alt bilgi öğelerini görünür yapar:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Master ve Çocuk Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir master hiyerarşisi boyunca tutarlı alt bilgi ayarları uygulamak için [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) yöntemini kullanın. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslideheaderfootermanager/) sınıfının yayılım yöntemleri master ve onun bağlı düzen slaytları ile normal slaytlar üzerinde çalışır; yalnızca bir normal slaytı hedeflemez.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Master Slaytı ile Layout Slaytı Arasındaki Fark Nedir?**

Bir master slaytı, sunumun temasını ve ortak biçimlendirmesini tanımlar. Bir layout slaytı, bir mastera aittir ve yer tutucuların yeniden kullanılabilir bir düzenini tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Layout Slaytı bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. Hedef koleksiyona bir kopya eklemek için [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) yöntemini kullanın. Sunumlar arasında kopyalarken, kaynak düzende kullanılan yazı tiplerini, temaları, resimleri ve diğer kaynakları da doğrulayın.

**Zaten Kullanımda Olan Bir Düzeni Değiştirdiğimde Ne Olur?**

Bağlı slaytlar, etkilenilen biçimlendirme veya nesneleri yerel olarak geçersiz kılmadıkları sürece düzen değişikliklerini devralır. Bu yüzden yer tutucu geometrisi ve devralınan stil birçok slaytta bir anda değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxeditexception/) hatası fırlatır. Önce bağlı slaytları yeniden atayın veya yalnızca başvurulan olmayan düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini kullanın.