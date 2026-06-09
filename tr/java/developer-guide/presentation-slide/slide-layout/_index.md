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
description: "Aspose.Slides for Java'da slayt düzenlerini yönetin ve özelleştirin. Düzen türlerini, yer tutucu kontrolünü ve altbilgi görünürlüğünü Java kod örnekleriyle keşfedin."
---
## **Giriş**

Bir slayt düzeni, bir slayttaki yer tutucu kutuların yerleşimini ve içeriğin biçimlendirmesini tanımlar. Hangi yer tutucuların mevcut olduğunu ve nerede göründüklerini kontrol eder. Slayt düzenleri, basit ya da daha karmaşık bir şey oluşturuyor olun, sunumları hızlı ve tutarlı bir şekilde tasarlamanıza yardımcı olur. PowerPoint'te en yaygın slayt düzenlerinden bazıları şunlardır:

**Başlık Slaytı düzeni** – Başlık ve alt başlık için iki metin yer tutucusu içerir.

**Başlık ve İçerik düzeni** – Üstte daha küçük bir başlık yer tutucusu ve altında metin, madde işaretleri, grafikler, resimler ve daha fazlası gibi ana içerik için daha büyük bir yer tutucu bulunur.

**Boş düzen** – Hiç yer tutucu içermez, slaytı sıfırdan tasarlamak için tam kontrol sağlar.

Slayt düzenleri, düzen stillerini tanımlayan üst düzey slayt olan slayt anahtarının bir parçasıdır. Düzen slaytlarına slayt anahtarını kullanarak – tip, ad veya benzersiz kimliklerine göre – erişebilir ve bunları değiştirebilirsiniz. Alternatif olarak, bir düzen slaytını doğrudan sunum içinde düzenleyebilirsiniz.

Aspose.Slides for Java'da slayt düzenleriyle çalışmak için şunları kullanabilirsiniz:

- Metotlar gibi [getLayoutSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getLayoutSlides--) ve [getMasters](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getMasters--) [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı altında
- Türler gibi [ILayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/), ve [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Ana slaytlarla çalışmayı daha fazla öğrenmek için [Slide Master](/slides/tr/java/slide-master/) makalesine göz atın.
{{% /alert %}}

## **Sunumlara Slayt Düzenleri Ekleme**

Slaytlarınızın görünümünü ve yapısını özelleştirmek için bir sunuma yeni düzen slaytları eklemeniz gerekebilir. Aspose.Slides for Java, belirli bir düzenin zaten var olup olmadığını kontrol etmenize, gerekirse yeni bir tane eklemenize ve bu düzeni temel alarak slayt eklemenize olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterlayoutslidecollection/) öğesine erişin.
1. İstenen düzen slaydının koleksiyonda zaten bulunup bulunmadığını kontrol edin. Yoksa ihtiyacınız olan düzen slaydını ekleyin.
1. Yeni düzen slaydına dayalı boş bir slayt ekleyin.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, PowerPoint sunumuna bir slayt düzeni eklemeyi gösterir:

```java
// PowerPoint dosyasını temsil eden Presentation sınıfını örnekle.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Bir düzen slaytı seçmek için düzen slaytı türleri üzerinden geç.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Sunumun tüm düzen türlerini içermediği bir durum.
        // Sunum dosyası yalnızca Boş ve Özel düzen türlerini içerir.
        // Ancak, özel türlü düzen slaytlarının tanınabilir adları olabilir,
        // örneğin "Title", "Title and Content" gibi, bunlar düzen slaytı seçimi için kullanılabilir.
        // Ayrıca bir dizi yer tutucu şekil türüne güvenebilirsiniz.
        // Örneğin, bir Başlık slaytı yalnızca Başlık yer tutucu türüne sahip olmalıdır, vb.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Eklenen düzen slaytını kullanarak boş bir slayt ekle.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Sunumu diske kaydet.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

Aspose.Slides, istenmeyen ve kullanılmayan düzen slaytlarını silmenizi sağlayan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metodunu [Compress](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/) sınıfından sunar.

Aşağıdaki Java kodu, PowerPoint sunumundan bir düzen slaydını nasıl kaldıracağınızı gösterir:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt Düzenlerine Yer Tutucu Ekleme**

Aspose.Slides, bir düzen slaydına yeni yer tutucular eklemenizi sağlayan [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) metodunu sunar.

Bu yönetici, aşağıdaki yer tutucu türleri için metodlar içerir:

| PowerPoint Yer Tutucu | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilayoutplaceholdermanager/) Metodu |
| --------------------- | ------------------------------------------------------------ |
| ![İçerik](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![İçerik (Dikey)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Metin](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Metin (Dikey)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Resim](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafik](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tablo](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Ortam](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Çevrimiçi Resim](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Aşağıdaki Java kodu, Boş düzen slaydına yeni yer tutucu şekilleri eklemeyi gösterir:

```java
Presentation presentation = new Presentation();
try {
    // Boş düzen slaydını al.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Düzen slaydının yer tutucu yöneticisini al.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Boş düzen slaydına farklı yer tutucular ekle.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Boş düzenle yeni bir slayt ekle.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Düzen slaydındaki yer tutucular](add_placeholders.png)

## **Bir Düzen Slaytı için Altbilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özel metin gibi altbilgi öğeleri, slayt düzenine bağlı olarak gösterilebilir veya gizlenebilir. Aspose.Slides for Java, bu altbilgi yer tutucularının görünürlüğünü kontrol etmenizi sağlar. Bu, belirli düzenlerin altbilgi bilgilerini gösterirken diğerlerinin temiz ve sade kalmasını istediğinizde faydalıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir düzen slaytı referansı alın.
1. Slayt altbilgi yer tutucusunu görünür olarak ayarlayın.
1. Slayt numarası yer tutucusunu görünür olarak ayarlayın.
1. Tarih‑saat yer tutucusunu görünür olarak ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir slayt altbilgisinin görünürlüğünü ayarlamayı ve ilgili işlemleri gösterir:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Bir Slayt için Alt Slayt Altbilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özel metin gibi altbilgi öğeleri, tüm düzen slaytları arasında tutarlılığı sağlamak için ana slayt seviyesinde kontrol edilebilir. Aspose.Slides for Java, bu altbilgi yer tutucularının görünürlüğünü ve içeriğini ana slaytta ayarlamanıza ve bu ayarları tüm alt düzen slaytlarına yaymanıza olanak tanır. Bu yaklaşım, sunumunuz boyunca tutarlı bir altbilgi bilgisi sağlar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle ana slayta bir referans alın.
1. Ana ve tüm alt slaytların altbilgi yer tutucularını görünür olarak ayarlayın.
1. Ana ve tüm alt slaytların slayt numarası yer tutucularını görünür olarak ayarlayın.
1. Ana ve tüm alt slaytların tarih‑saat yer tutucularını görünür olarak ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu bu işlemi gösterir:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Ana slayt ile düzen slaytı arasındaki fark nedir?**

Ana slayt genel temayı ve varsayılan biçimlendirmeyi tanımlarken, düzen slaytları farklı içerik türleri için yer tutucu düzenlemelerini belirler.

**Bir düzen slaydını bir sunumdan diğerine kopyalayabilir miyim?**

Evet, bir sunumun düzen slayt koleksiyonundan ( [getLayoutSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getLayoutSlides--) metodu ile erişilebilir) bir düzen slaydını klonlayabilir ve `addClone` metodu kullanarak başka bir sunuma ekleyebilirsiniz.

**Bir slayt hâlâ o düzen slaydını kullanıyorken bu düzen slaydını silersem ne olur?**

Bir düzen slaydı, sunumda en az bir slayt tarafından hâlâ referans alınıyorsa silmeye çalıştığınızda Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxeditexception/) fırlatır. Bunu önlemek için, yalnızca kullanılmayan düzen slaytlarını güvenli bir şekilde kaldıran [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) metodunu kullanın.