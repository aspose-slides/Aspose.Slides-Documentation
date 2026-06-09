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
- altbilgi görünürlüğü
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te slayt düzenlerini yönetin ve özelleştirin. Düzen türlerini, yer tutucu kontrolünü ve altbilgi görünürlüğünü kod örnekleriyle keşfedin."
---
## **Giriş**

Bir slayt düzeni, bir slayttaki yer tutucu kutuların düzenini ve içeriğin biçimlendirmesini tanımlar. Hangi yer tutucuların mevcut olduğunu ve nerede görüneceklerini kontrol eder. Slayt düzenleri, ister basit ister daha karmaşık bir şey oluşturuyor olun, sunumları hızlı ve tutarlı bir şekilde tasarlamanıza yardımcı olur. PowerPoint'teki en yaygın slayt düzenlerinden bazıları şunlardır:

**Başlık Slaytı düzeni** – Başlık için bir ve alt başlık için bir olmak üzere iki metin yer tutucusu içerir.

**Başlık ve İçerik düzeni** – Üstte daha küçük bir başlık yer tutucusu ve altında esas içerik (metin, madde işaretleri, grafikler, görseller vb.) için daha büyük bir yer tutucu bulunur.

**Boş düzen** – Yer tutucu içermez, slaytı sıfırdan tasarlamak için tam kontrol sağlar.

Slayt düzenleri, sunumun düzen stillerini tanımlayan üst seviyedeki slayt olan bir slayt anahtarının parçasıdır. Düzen slaytlarına, tipine, adına veya benzersiz kimliğine göre slayt anahtarı üzerinden erişebilir ve değiştirebilirsiniz. Alternatif olarak, belirli bir düzen slaytını doğrudan sunum içinde düzenleyebilirsiniz.

PowerPoint sunumlarında slayt düzenleriyle çalışmak için Aspose.Slides for Node.js'te aşağıdakileri kullanabilirsiniz:

- [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı altında [getLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getLayoutSlides) ve [getMasters](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getMasters) gibi yöntemler
- [LayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/), ve [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) türleri

{{% alert title="Info" color="info" %}}
Ana slaytlarla çalışma hakkında daha fazla bilgi edinmek için [Slide Master](/slides/tr/nodejs-java/slide-master/) makalesine göz atın.
{{% /alert %}}

## **Sunumlara Slayt Düzenleri Eklemek**

Slaytlarınızın görünüm ve yapısını özelleştirmek için bir sunuma yeni düzen slaytları eklemeniz gerekebilir. Aspose.Slides for Node.js, belirli bir düzenin zaten mevcut olup olmadığını kontrol etmenizi, gerekirse yeni bir tane eklemenizi ve bu düzeni temel alarak slayt eklemenizi sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [MasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterlayoutslidecollection/) öğesine erişin.
1. İstenen düzen slaydının koleksiyonda zaten var olup olmadığını kontrol edin. Yoksa ihtiyacınız olan düzen slaydını ekleyin.
1. Yeni düzen slaydına dayanarak boş bir slayt ekleyin.
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir PowerPoint sunumuna slayt düzeni eklemeyi göstermektedir:

```js
// PowerPoint dosyasını temsil eden Presentation sınıfını oluşturun.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Bir düzen slaytı seçmek için düzen slaytı türleri arasında gezinin.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Sunumun tüm düzen türlerini içermediği bir durum.
        // Sunum dosyası yalnızca Boş ve Özel düzen türlerini içerir.
        // Ancak, özel türlere sahip düzen slaytlarının tanınabilir adları olabilir,
        // "Title", "Title and Content", vb., gibi, düzen slaytı seçimi için kullanılabilecek adlar.
        // Ayrıca bir dizi yer tutucu şekil türüne dayanabilirsiniz.
        // Örneğin, bir Başlık slaytı yalnızca Başlık yer tutucu tipine sahip olmalıdır, vb.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Eklenen düzen slaytını kullanarak boş bir slayt ekleyin.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Sunumu diske kaydedin.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

Aspose.Slides, istenmeyen ve kullanılmayan düzen slaytlarını silmenizi sağlayan [Compress](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/) sınıfındaki [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini sunar.

Aşağıdaki JavaScript kodu, bir PowerPoint sunumundan bir düzen slaytını nasıl kaldıracağınızı gösterir:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt Düzenlerine Yer Tutucular Ekleme**

Aspose.Slides, bir düzen slaydına yeni yer tutucular eklemenizi sağlayan [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) yöntemini sunar.

Bu yönetici aşağıdaki yer tutucu türleri için yöntemler içerir:

| PowerPoint Yer Tutucu | [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutplaceholdermanager/) Yöntemi |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Aşağıdaki JavaScript kodu, Boş düzen slaydına yeni yer tutucu şekilleri eklemeyi göstermektedir:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Boş düzen slaytını alın.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Düzen slaydının yer tutucu yöneticisini alın.
    let placeholderManager = layout.getPlaceholderManager();

    // Boş düzen slaytına farklı yer tutucular ekleyin.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Boş düzen ile yeni bir slayt ekleyin.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Düzen slaydındaki yer tutucular](add_placeholders.png)

## **Bir Düzen Slaytı için Altbilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında, tarih, slayt numarası ve özel metin gibi altbilgi öğeleri slayt düzenine bağlı olarak gösterilebilir veya gizlenebilir. Aspose.Slides for Node.js, bu altbilgi yer tutucularının görünürlüğünü kontrol etmenizi sağlar. Bu, belirli düzenlerin altbilgi bilgilerini gösterirken diğerlerinin temiz ve minimal kalmasını istediğinizde kullanışlıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Bir düzen slaytı referansını indeksine göre alın.
1. Slayt altbilgi yer tutucusunu görünür olarak ayarlayın.
1. Slayt numarası yer tutucusunu görünür olarak ayarlayın.
1. Tarih‑zaman yer tutucusunu görünür olarak ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir slayt altbilgisinin görünürlüğünü nasıl ayarlayacağınızı ve ilgili görevleri nasıl gerçekleştireceğinizi gösterir:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Bir Slayt İçin Alt Slayt Altbilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında, tarih, slayt numarası ve özel metin gibi altbilgi öğeleri, tüm düzen slaytları arasında tutarlılık sağlamak amacıyla ana slayt seviyesinde kontrol edilebilir. Aspose.Slides for Node.js, bu altbilgi yer tutucularının görünürlüğünü ve içeriğini ana slaytta ayarlamanıza ve bu ayarları tüm alt düzen slaytlarına yaymanıza olanak tanır. Bu yaklaşım, sunumunuz boyunca tutarlı altbilgi bilgileri sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Ana slayta indeksine göre bir referans alın.
1. Ana slaytın ve tüm alt slaytların altbilgi yer tutucularını görünür olarak ayarlayın.
1. Ana slaytın ve tüm alt slaytların slayt numarası yer tutucularını görünür olarak ayarlayın.
1. Ana slaytın ve tüm alt slaytların tarih‑zaman yer tutucularını görünür olarak ayarlayın.
1. Sunumu kaydedin.

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir ana slayt ile bir düzen slaytı arasındaki fark nedir?**

Ana slayt, genel temayı ve varsayılan biçimlendirmeyi tanımlarken, düzen slaytları farklı içerik türleri için yer tutucuların belirli düzenlemelerini tanımlar.

**Bir düzen slaytını bir sunumdan diğerine kopyalayabilir miyim?**

Evet, bir sunumun [getLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getLayoutSlides) yöntemiyle erişilebilen düzen slaytı koleksiyonundan bir düzen slaytını klonlayabilir ve `addClone` yöntemiyle başka bir sunuma ekleyebilirsiniz.

**Bir slayt hâlâ kullandığı bir düzen slaytını silersem ne olur?**

Sunumdaki en az bir slayt tarafından hâlâ referans verilen bir düzen slaytını silmeye çalışırsanız, Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxeditexception/) fırlatır. Bunu önlemek için, yalnızca kullanılmayan düzen slaytlarını güvenli bir şekilde kaldıran [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini kullanın.