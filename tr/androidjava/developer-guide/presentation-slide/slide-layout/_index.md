---
title: "Android'de Slayt Düzenlerini Uygula veya Değiştir"
linktitle: "Slayt Düzeni"
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
description: "Aspose.Slides for Android'da slayt düzenlerini yönetin ve özelleştirin. Düzen türlerini, yer tutucu kontrolünü ve alt bilgi görünürlüğünü Java kod örnekleriyle keşfedin."
---
## **Giriş**

Bir slayt düzeni, bir slayttaki içeriğin yer tutucu kutularının ve biçimlendirmesinin düzenini tanımlar. Hangi yer tutucuların mevcut olduğunu ve nerede göründüklerini kontrol eder. Slayt düzenleri, basit ya da daha karmaşık bir şey oluştururken sunumları hızlı ve tutarlı bir şekilde tasarlamanıza yardımcı olur. PowerPoint'teki en yaygın slayt düzenlerinden bazıları şunlardır:

**Başlık Slaytı düzeni** – Başlık için bir ve alt başlık için bir olmak üzere iki metin yer tutucusunu içerir.

**Başlık ve İçerik düzeni** – Üstte daha küçük bir başlık yer tutucusu ve altında ana içerik (metin, madde işaretleri, grafikler, resimler vb.) için daha büyük bir yer tutucu bulunur.

**Boş düzen** – Hiçbir yer tutucu içermez, slaytı sıfırdan tasarlamanıza tam kontrol sağlar.

Slayt düzenleri, sunum için düzen stillerini tanımlayan üst düzey slayt olan slayt ana şablonunun bir parçasıdır. Slayt düzenlerine slayt ana şablonu üzerinden—türüne, adına veya benzersiz kimliğine göre—erişebilir ve bunları değiştirebilirsiniz. Alternatif olarak, belirli bir slayt düzenini sunum içinde doğrudan düzenleyebilirsiniz.

Slayt düzenleriyle Aspose.Slides for Android içinde çalışmak için şunları kullanabilirsiniz:

- [Presentation] sınıfı altında [getLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) ve [getMasters](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getMasters--) gibi yöntemler
- [ILayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), ve [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) gibi tipler

{{% alert title="Info" color="info" %}}

Ana slaytlarla çalışmak hakkında daha fazla bilgi edinmek için [Slide Master](/slides/tr/androidjava/slide-master/) makalesine göz atın.

{{% /alert %}}

## **Sunumalara Slayt Düzenleri Ekleme**

Slaytlarınızın görünümünü ve yapısını özelleştirmek için bir sunuma yeni düzen slaytları eklemeniz gerekebilir. Aspose.Slides for Android, belirli bir düzenin zaten mevcut olup olmadığını kontrol etmenizi, gerektiğinde yeni bir tane eklemenizi ve bu düzeni temel alarak slayt eklemenizi sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterlayoutslidecollection/) erişin.
3. İstenen düzen slaydının koleksiyon içinde zaten mevcut olup olmadığını kontrol edin. Yoksa ihtiyacınız olan düzen slaydını ekleyin.
4. Yeni düzen slaydına dayalı boş bir slayt ekleyin.
5. Sunumu kaydedin.

Aşağıdaki Java kodu, bir PowerPoint sunumuna slayt düzeni eklemeyi gösterir:

```java
// PowerPoint dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Düzen slayt türlerini gezerek bir düzen slaytı seçin.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Sunumun tüm düzen türlerini içermediği bir durum.
        // Sunum dosyası yalnızca Boş ve Özel düzen türlerini içerir.
        // Ancak, özel türlere sahip düzen slaytları tanınabilir adlara sahip olabilir,
        // örneğin "Title", "Title and Content", vb., bu isimler düzen slaytı seçimi için kullanılabilir.
        // Ayrıca bir dizi yer tutucu şekil tipine güvenebilirsiniz.
        // Örneğin, bir Başlık slaytı yalnızca Başlık yer tutucu tipine sahip olmalıdır, vb.
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

    // Eklenen düzen slaytını kullanarak boş bir slayt ekleyin.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Sunumu diske kaydedin.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kullanılmayan Slayt Düzenlerini Kaldırma**

Aspose.Slides, kullanılmayan ve istenmeyen düzen slaytlarını silmenize olanak tanıyan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) sınıfından sağlar.

Aşağıdaki Java kodu, bir PowerPoint sunumundan düzen slaytını kaldırmayı gösterir:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt Düzenlerine Yer Tutucular Ekleme**

Aspose.Slides, bir düzen slaytına yeni yer tutucular eklemenizi sağlayan [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) yöntemini sunar.

Bu yönetici, aşağıdaki yer tutucu türleri için yöntemler içerir:

| PowerPoint Yer Tutucu | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) Yöntemi |
| ---------------------- | ------------------------------------------------------------ |
| ![İçerik](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![İçerik (Dikey)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Metin](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Metin (Dikey)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Resim](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafik](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tablo](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medya](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Çevrimiçi Resim](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Aşağıdaki Java kodu, Boş düzen slaydına yeni yer tutucu şekilleri eklemeyi gösterir:

```java
Presentation presentation = new Presentation();
try {
    // Boş düzen slaytını alın.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Düzen slaydının yer tutucu yöneticisini alın.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Boş düzen slaytına farklı yer tutucular ekleyin.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Boş düzenle yeni bir slayt ekleyin.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Düzen slaydındaki yer tutucular](add_placeholders.png)

## **Bir Düzen Slaytı İçin Alt Bilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özel metin gibi alt bilgi öğeleri, slayt düzenine bağlı olarak gösterilebilir veya gizlenebilir. Aspose.Slides for Android, bu alt bilgi yer tutucularının görünürlüğünü kontrol etmenizi sağlar. Belirli düzenlerin alt bilgi bilgilerini göstermesini, diğerlerinin ise temiz ve minimal kalmasını istediğinizde bu özellik faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir indeksle düzen slaytı referansını alın.
3. Slayt alt bilgi yer tutucusunu görünür olarak ayarlayın.
4. Slayt numarası yer tutucusunu görünür olarak ayarlayın.
5. Tarih‑saat yer tutucusunu görünür olarak ayarlayın.
6. Sunumu kaydedin.

Aşağıdaki Java kodu, bir slayt alt bilgisinin görünürlüğünü ayarlamayı ve ilgili görevleri göstermektedir:

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

## **Bir Slayt İçin Alt Slayt Alt Bilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özel metin gibi alt bilgi öğeleri, tutarlılığı sağlamak amacıyla ana slayt seviyesinde kontrol edilebilir ve bu ayarlar tüm alt düzen slaytlarına uygulanabilir. Aspose.Slides for Android, bu alt bilgi yer tutucularının görünürlüğünü ve içeriğini ana slaytta ayarlamanıza ve bu ayarları tüm alt düzen slaytlarına yaymanıza olanak tanır. Bu yaklaşım, sunumunuz boyunca tutarlı bir alt bilgi bilgisi sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir indeksle ana slayta referans alın.
3. Ana slaytın ve tüm alt slaytların alt bilgi yer tutucularını görünür olarak ayarlayın.
4. Ana slaytın ve tüm alt slaytların slayt numarası yer tutucularını görünür olarak ayarlayın.
5. Ana slaytın ve tüm alt slaytların tarih‑saat yer tutucularını görünür olarak ayarlayın.
6. Sunumu kaydedin.

Aşağıdaki Java kodu bu işlemi göstermektedir:

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

Ana slayt, genel temayı ve varsayılan biçimlendirmeyi tanımlarken, düzen slaytları farklı içerik türleri için yer tutucuların belirli düzenlemelerini tanımlar.

**Bir düzen slaydını bir sunumdan diğerine kopyalayabilir miyim?**

Evet, bir sunumun [getLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) yöntemiyle erişilebilen düzen slayt koleksiyonundan bir düzen slaytını klonlayabilir ve `addClone` yöntemiyle başka bir sunuma ekleyebilirsiniz.

**Kullanımda olan bir slayt hala başvuruda bulunuyorsa bir düzen slaydını silersem ne olur?**

Bir düzen slaytı, sunumda en az bir slayt tarafından hâlâ referans alınıyorsa silmeye çalışırsanız Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxeditexception/) fırlatır. Bunu önlemek için kullanılmayanları güvenle kaldıran [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) yöntemini kullanın.