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
- yalnızca başlık
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
description: "Aspose.Slides for Node.js'te Java aracılığıyla slayt düzenlerini uygulayın, oluşturun ve değiştirin, yer tutucular ekleyin, kullanılmayan düzenleri kaldırın ve alt bilgi görünürlüğünü kontrol edin."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzen uygulandığında slaytlara tutarlı bir yapı kazandırılırken, her slayt kendi içeriğini barındırabilir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: Hiç içerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlar için kullanışlıdır.

## **Düzen Kalıtımını Anlayın**

Bir sunum üç ilişkili seviyeye sahiptir:

1. Bir [master slayt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
2. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) bir master’a aittir ve belirli bir yer tutucu düzenini tanımlar.
3. Bir [normal slayt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/) bir düzeni kullanır ve o slayt için girilen içeriği depolar.

Normal bir slayt, temayı ve biçimlendirmeyi düzeninden kalıtım alır; düzen ise kendi master’ından kalıtım alır. Normal slaytta doğrudan ayarlanan bir değer, o seviyedeki kalıtım değerini geçersiz kılar. Normal bir slayt oluşturulduğunda, seçilen düzenten yer tutucu şekilleri üretilir; bu yer tutuculara girilen içerik ise normal slayta aittir.

Bir slaytı bu düzen üzerinden oluşturmadan önce gerekli yer tutucuları ekleyin. Daha sonra bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişkinin iki önemli sonucu vardır:

- Bir düzen üzerindeki kalıtılan biçimlendirme veya mevcut yer tutucu geometrisini değiştirmek, ona bağlı tüm slaytları güncelleyebilir. Kullanımda olan bir düzeni düzenlemeden önce, bağlı slaytları inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt hâlâ kullanıyorsa, o düzen kaldırılamaz. Önce bağlı slaytları başka bir düzenle ilişkilendirin veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin en üst seviyesi hakkında daha fazla bilgi için [Slide Master](/slides/tr/nodejs-java/slide-master/) sayfasına bakın.

Bir slaytta veya ortak bir düzen üzerinden kalıtılan logo ve dekoratif master şekillerini gizlemek için [Control the Visibility of Master Graphics](/slides/tr/nodejs-java/slide-master/) bölümüne bakın. Örnek, aynı master’ı kullanan iki slaytı karşılaştırır.

## **Bir Slayt Düzeni Seçin ve Uygulayın**

Sunum standart PowerPoint düzen tanımlarını izliyorsa, bir [SlideLayoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidelayouttype/) değeri kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden ad‑tabanlı seçim, kaynak şablonun kontrolü elinizde değilse daha az güvenilir olur.

Aşağıdaki örnek, ilk master’da **Title and Content** düzenini arar. Bu düzen bulunamazsa, bilinçli olarak **Blank** düzenine geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği durumlar için gereklidir. Seçilen düzen daha sonra [Slide.setLayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#setLayoutSlide) yöntemiyle ilk normal slayta uygulanır.

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

Bir slaytın düzenini değiştirmek, doğrudan slayta eklenen sıradan şekilleri kaldırmaz. Ancak, yer tutucu konumları, kalıtılan biçimlendirme ve mevcut yer tutucularla yeni düzen arasındaki eşleşme değişebilir; bu yüzden farklı düzenler arasında geçiş yaparken çıktıyı kontrol edin.

## **Bir Düzen Slaytı Ekleyin**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; yeni bir tane oluşturmaz. Bir düzen oluşturmak için hedef master’ın düzen koleksiyonunda [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) yöntemini çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adlı yeni bir **Title and Content** düzeni ekler ve ardından buna dayalı bir normal slayt oluşturur. Düzen adları koleksiyon içinde benzersiz olmalıdır.

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

Şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyuyorsa bir düzen ekleyin. Uygun bir düzen zaten varsa, yeni bir tane oluşturmaktan kaçının; bunun yerine mevcut düzeni seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekleyin**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu                | `LayoutPlaceholderManager` Yöntemi |
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

Aşağıdaki örnek, **Blank** düzeninin var olduğunu doğrular, dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra bilerek seçilmiştir: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides ilgili yer tutucu şekillerini o slayt üzerinde oluşturabilir.

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

![Düzen slaytındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Kalıtılan biçimlendirme veya mevcut düzen yer tutucularının geometrisini değiştirmek, bağlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu, mevcut normal slaytlara geriye doğru doldurulmaz. Düzen değişikliklerini bir sunum kopyası üzerinde test edin ve her bağlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırın**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini kullanarak hiçbir normal slayt tarafından başvurulmayan düzenleri kaldırın. Yöntem hâlâ kullanılan düzenleri olduğu gibi bırakır.

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

Belirli bir düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) veya [getDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın. Bağlı slaytları, [LayoutSlide.remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#remove) metodunu çağırmadan önce yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxeditexception/) fırlatır.

## **Bir Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Edin**

Bir düzenin kendi alt bilgi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek amacıyla [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) yöntemini kullanın. Örneğin, içerik düzenlerinin alt bilgi göstermesi, başlık düzenlerinin göstermemesi gibi durumlar için faydalıdır.

Aşağıdaki örnek, bir düzeni güvenli bir şekilde seçer ve alt bilgi öğelerini görünür kılar:

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

## **Bir Master ve Alt Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Edin**

Tutarlı alt bilgi ayarlarını bir master hiyerarşisi boyunca uygulamak için [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) yöntemini kullanın. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslideheaderfootermanager/) nesnesinin yayılım yöntemleri master, ona bağlı düzen slaytları ve normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedef almaz.

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

**Master Slayt ile Düzen Slaytı Arasındaki Fark Nedir?**

Master slayt, sunumun temasını ve ortak biçimlendirmesini tanımlar. Düzen slaytı bir master’a aittir ve yeniden kullanılabilir bir yer tutucu düzeni tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. Hedef koleksiyona bir kopya eklemek için [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) yöntemini kullanın. Sunumlar arasında kopyalama yaparken, kaynak düzenin kullandığı yazı tipleri, temalar, resimler ve diğer kaynakları da doğrulayın.

**Kullanımda Olan Bir Düzeni Değiştirirsem Ne Olur?**

Bağlı slaytlar, yerel olarak ilgili biçimlendirmeyi veya nesneleri geçersiz kılmadıkları sürece, düzen değişikliklerini kalıtım olarak alır. Yer tutucu geometrisi ve kalıtılan stil, bir kerede birçok slaytta değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxeditexception/) fırlatır. Önce bağlı slaytları yeniden atayın veya yalnızca başvuru alınmayan düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini kullanın.