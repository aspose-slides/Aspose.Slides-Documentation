---
title: Android'de Sunum Slide Master'larını Yönet
linktitle: Slayt Ana Taslağı
type: docs
weight: 70
url: /tr/androidjava/slide-master/
keywords:
- slayt ana taslağı
- ana slayt
- PPT ana slaytı
- çoklu ana slaytlar
- ana slaytları karşılaştır
- arka plan
- yer tutucu
- ana slaytı klonla
- ana slaytı kopyala
- ana slaytı çoğalt
- kullanılmayan ana slayt
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da slayt ana taslaklarını yönetin: PowerPoint ve OpenDocument sunumlarında ana taslak slaytlarına erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için paylaşılan tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve altbilgi ayarları içerebilir. PowerPoint'te, bir slide master'ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Android via Java aynı modeli destekler. Bir sunum bir veya daha fazla ana taslak (master slide) içerebilir ve her ana taslak birden çok düzen slaytı (layout slide) barındırabilir. Normal slaytlar doğrudan bir ana taslağa referans vermez; bunun yerine bir düzen slaytı kullanır ve bu düzen slaytı bir ana taslağa aittir.

Hiyerarşi şu şekildedir:

1. **Slide master** – paylaşılan tasarımı ve temayı tanımlar.  
1. **Layout slide** – yer tutucuların belirli bir düzenini ve düzen‑seviyesindeki biçimlendirmeyi tanımlar.  
1. **Normal slide** – gerçek sunum içeriğini barındırır ve bir düzen slaytı kullanır.

![Ana taslakların, düzen slaytlarının ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides'te bir slide master, [IMasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslide/) arabirimiyle temsil edilir. Bir sunumdaki tüm ana taslaklar, [Presentation.getMasters](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getMasters--) koleksiyonu aracılığıyla elde edilir ve bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/) arabirimini uygular. Android via Java için tam API yüzeyi hakkında bilgi için [com.aspose.slides API reference](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) sayfasına bakın.

{{% alert color="info" title="Inheritance" %}}

Bir özellik birden fazla seviyede tanımlandığında, daha spesifik seviye geçerli olur. Örneğin, bir ana taslak ve bir düzen slaytı aynı arka planı tanımlarsa, o düzene dayalı slaytlar düzen arka planını kullanır. Düzen slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/androidjava/slide-layout/) bölümüne bakın.

{{% /alert %}}

## **Slayt Ana Taslaklarına Erişim**

PowerPoint'te **View** > **Slide Master** yolunu izleyerek Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides'te ana taslaklara erişmek için `getMasters()` koleksiyonunu kullanın:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Ayrıca bir normal slaytın kullandığı ana taslağı, onun düzeni üzerinden alabilirsiniz:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Bir Slide Master Ne İçerir**

Bir ana taslak, slayt benzeri bir nesnedir. [IBaseSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/) arabirimini uygular, bu nedenle normal ve düzen slaytlarıyla aynı birçok slayt özelliğine sahiptir.

Sık kullanılan ana taslak üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `getBackground()` | Ana taslak seviyesindeki slayt arka planını ayarlar. |
| `getShapes()` | Logolar, resim çerçeveleri ve paylaşılan metin gibi ana taslağa eklenen şekilleri depolar. |
| `getLayoutSlides()` | Ana taslağa ait düzen slaytlarını depolar. |
| `getThemeManager()` | Ana taslak tema API'lerine erişim sağlar. |
| `getHeaderFooterManager()` | Ana taslak ve onun alt düzenleri için üstbilgi, altbilgi, tarih ve slayt numarası kontrolü yapar. |
| `getDependingSlides()` | Düzenleri aracılığıyla ana taslağa bağımlı olan normal slaytları döndürür. |

## **Bir Slide Master'a Resim Ekleme**

Bir ana taslağa resim eklediğinizde, o ana taslağın düzenlerini kullanan slaytlarda görünür. Bu, logolar, filigranlar, dekoratif bantlar ve diğer tekrarlanan görsel öğeler için kullanışlıdır.

Aşağıdaki örnek, ilk ana taslağa bir logo ekler:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/androidjava/picture-frame/) bölümüne bakın.

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle düzen slaytlarında tanımlanır. Ana taslak, bu düzenlerin devraldığı ortak stil ve temayı sağlar; her düzen ise hangi yer tutucuların mevcut olduğunu ve nerede bulunduğunu belirler.

PowerPoint'te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümünde Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için, ana taslağa ait düzen slaytıyla çalışın:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ayrıca zaten bir ana taslakta bulunan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve doğrusal bir degrade dolgu uygular:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Normal slaytlar tarafından devralınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/androidjava/manage-placeholder/) ve [Text Formatting](/slides/tr/androidjava/text-formatting/) bölümlerine bakın.

## **Bir Slide Master Arka Planını Değiştirme**

Ana taslak arka planı, üzerine yazılmadığı sürece düzenler ve slaytlar tarafından devralınır. Aşağıdaki örnek, ilk ana taslak için katı bir arka plan rengi ayarlar:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

İlgili konular için [Presentation Background](/slides/tr/androidjava/presentation-background/) ve [Presentation Theme](/slides/tr/androidjava/presentation-theme/) bölümlerine bakın.

## **Bir Slide Master'ı Başka Bir Sunuma Kopyalama**

Bir ana taslağı başka bir sunuma kopyalamak için [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) yöntemini kullanın. Kopyalanan ana taslak, hedef sunumdaki düzenler ve slaytlar tarafından kullanılabilir.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Normal slaytları ve ana taslaklarını aynı anda kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/androidjava/clone-slides/) bölümüne bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden çok ana taslak içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda kullanışlıdır.

![Ana taslak ekleme ve yönetme PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan ana taslağı kopyalar, kopyaya farklı bir arka plan verir, bu kopyalanan ana taslağın altında bir düzen oluşturur ve o düzene dayalı yeni bir slayt ekler:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slide Master'ları Karşılaştırma**

Ana taslaklar, [IBaseSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/) tarafından devralınan `equals` metodu ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya geçerli tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/androidjava/compare-slides/) bölümüne bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

PowerPoint'in ilk açtığı görünümü kontrol etmek için [ViewProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/viewproperties/) üzerindeki `setLastView` yöntemini kullanın. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/androidjava/save-presentation/) bölümüne bakın.

## **Kullanılmayan Ana Taslakları Kaldırma**

Bazen sunumlar, hiçbir normal slayt tarafından kullanılmayan ana taslaklar içerir. Kullanılmayan ana taslakları kaldırmak, dosya boyutunu azaltabilir ve şablon bakımını basitleştirebilir.

`removeUnused` yöntemini kullanarak `getMasters()` koleksiyonundaki kullanılmayan ana taslakları kaldırın:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ayrıca düşük‑kodlu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) yöntemini de kullanabilirsiniz:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Slide master ile layout slide arasındaki fark nedir?**

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi paylaşılan tasarım ayarlarını tanımlar. Layout slide, bir master slide'a aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slide kullanır, bu nedenle hem layout hem de master'dan devralır.

**Bir sunum birden çok slide master içerebilir mi?**

Evet. Bir sunum birden çok slide master içerebilir. Farklı bölümlerin farklı görsel sistemler veya markalaşma gerektirdiği durumlarda birden çok master kullanın.

**Yer tutucuları master slide'a mı yoksa layout slide'a mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slide'lara ekleyin. Paylaşılan görsel öğeleri ve ortak biçimlendirmeyi master slide'a, içerik yer tutucularını ise normal slaytların kullanacağı layout'lara yerleştirin.

**Kullanılan bir master slide'ı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slide doğrudan güvenli bir şekilde silinemez. Önce bu slaytları başka bir master'ın altındaki layout'lara taşıyın veya sadece kullanılmayan master'ları kaldıran temizlik yöntemini kullanın.