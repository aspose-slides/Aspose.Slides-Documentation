---
title: Java'da Sunum Slide Master'larını Yönet
linktitle: Slayt Master
type: docs
weight: 70
url: /tr/java/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slayt
- birden fazla master slayt
- master slaytları karşılaştır
- arka plan
- yer tutucu
- master slaytı klonla
- master slaytı kopyala
- master slaytı çoğalt
- kullanılmayan master slayt
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarında master slaytları erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarları içerebilir. PowerPoint’te bir slide master’ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrar etmeden sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Java aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birkaç layout slaytı barındırabilir. Normal slaytlar doğrudan bir master slayta başvurmaz. Bunun yerine, normal bir slayt bir layout slaytı kullanır ve bu layout slayt bir master slayta aittir.

Hiyerarşi şudur:

1. **Slide master** – ortak tasarım ve temayı tanımlar.
1. **Layout slayt** – yer tutucuların ve layout‑seviyesi biçimlendirmelerin belirli düzenini tanımlar.
1. **Normal slayt** – gerçek sunum içeriğini barındırır ve bir layout slayt kullanır.

![Master slaytların, layout slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’te bir slide master, [IMasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) arabirimiyle temsil edilir. Bir sunumdaki tüm master slaytlar, [Presentation.getMasters](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getMasters--) koleksiyonu aracılığıyla erişilebilir ve bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/) arayüzünü uygular.

{{% alert color="info" title="Inheritance" %}}

Bir özellik birden fazla seviyede tanımlandığında, daha spesifik seviye kazanır. Örneğin, bir master slayt ve bir layout slayt aynı arka planı tanımlarsa, o layout’a dayalı slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/java/slide-layout/) bölümüne bakın.

{{% /alert %}}

## **Slide Master’lara Erişim**

PowerPoint’te **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides’te master slaytlara erişmek için `getMasters()` koleksiyonunu kullanın:

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

Ayrıca bir normal slaytın kullandığı master slaytı, onun layout’u üzerinden alabilirsiniz:

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

## **Bir Slide Master’ın İçeriği**

Bir master slayt, slayt benzeri bir nesnedir. [IBaseSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/) arayüzünü uygular, bu yüzden normal ve layout slaytlarda kullanılan birçok aynı slayt özelliğine sahiptir. Master‑özel üyeler [IMasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslide/) API sayfasında listelenir.

Sık kullanılan master slayt üyeleri şunlardır:

| Üye | Açıklama |
| --- | --- |
| `getBackground()` | Master‑seviyesindeki slayt arka planını ayarlar. |
| `getShapes()` | Logolar, resim çerçeveleri ve ortak metin gibi master üzerine yerleştirilen şekilleri depolar. |
| `getLayoutSlides()` | Master’a ait layout slaytları depolar. |
| `getThemeManager()` | Master tema API’lerine erişim sağlar. |
| `getHeaderFooterManager()` | Master ve onun alt layoutları için üst bilgi, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| `getDependingSlides()` | Layoutları aracılığıyla master’a bağlı olan normal slaytları döndürür. |

## **Slide Master’a Resim Ekleme**

Bir master slayta resim eklediğinizde, o master’ın layout‑larını kullanan slaytlarda görünür. Bu, logolar, filigranlar, süs şeritleri ve diğer tekrarlanan görsel öğeler için faydalıdır.

Aşağıdaki örnek, ilk master slayta bir logo ekler:

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

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/java/picture-frame/) bölümüne bakın.

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarında tanımlanır. Master slayt, bu layout‑ların miras aldığı ortak stil ve temayı sağlar; her layout ise hangi yer tutucuların bulunacağını ve nerede konumlandırılacağını belirler.

PowerPoint’te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümündeki Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için master’a ait layout slaytı üzerinde çalışın:

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

Ayrıca master slayt üzerinde zaten mevcut olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer bir degrade dolgu uygular:

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Normal slaytlar tarafından miras alınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/java/manage-placeholder/) ve [Text Formatting](/slides/tr/java/text-formatting/) bölümlerine bakın.

## **Slide Master Arka Planını Değiştirme**

Bir master arka planı, onu geçersiz kılan bir layout veya slayt olmadan layout‑lar ve slaytlar tarafından miras alınır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

İlgili konular için [Presentation Background](/slides/tr/java/presentation-background/) ve [Presentation Theme](/slides/tr/java/presentation-theme/) bölümlerine bakın.

## **Slide Master’ı Başka Bir Sunuma Kopyalama**

[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) metodunu kullanarak bir master slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout ve slaytlar tarafından kullanılabilir.

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

Normal slaytları, onların master’larıyla birlikte kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/java/clone-slides/) bölümüne bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden fazla master slayt içerebilir. Bu, farklı bölümlerin farklı marka kimliği, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![Master slayt ekleme ve yönetme için PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan masterı klonlar, klona farklı bir arka plan verir, o klon master altında bir layout oluşturur ve bu layout’a dayalı yeni bir slayt ekler:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **Slide Master’ları Karşılaştırma**

Master slaytlar, [IBaseSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/) üzerinden miras alınan `equals` metodu ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcılar ya da geçerli tarih gibi dinamik yer tutucu değerleri karşılaştırılmaz.

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

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/java/compare-slides/) bölümüne bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

[ViewProperties](https://reference.aspose.com/slides/tr/java/com.aspose.slides/viewproperties/) üzerindeki `setLastView` metodunu kullanarak PowerPoint’in ilk açtığı görünümü kontrol edebilirsiniz. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/java/save-presentation/) bölümüne bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen bir sunum, hiçbir normal slayt tarafından kullanılmayan master slaytlara sahip olabilir. Kullanılmayan master’ları kaldırmak dosya boyutunu azaltır ve şablon bakımını basitleştirir.

`removeUnused` metodunu kullanarak `getMasters()` koleksiyonundan kullanılmayan master’ları kaldırın:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ayrıca düşük‑kodlu [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) metodunu da kullanabilirsiniz:

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

**Slide master ile layout slayt arasındaki fark nedir?**

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Layout slayt bir master slayta aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slayt kullanır, bu yüzden hem layout hem de master’dan miras alır.

**Bir sunum birden fazla slide master içerebilir mi?**

Evet. Bir sunum birden fazla slide master barındırabilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden fazla master kullanın.

**Yer tutucuları master slayta mı yoksa layout slayta mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slaytlara ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeyi master slayta, içerik yer tutucularını ise normal slaytların kullanacağı layout‑lara koyun.

**Kullanımda olan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slaytı doğrudan güvenli bir şekilde kaldırılamaz. Önce bu slaytları başka bir master’ın layout‑larına taşıyın veya kullanılmayan master temizleme yöntemini kullanarak yalnızca kullanılmayan master’ları kaldırın.