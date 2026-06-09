---
title: JavaScript'te Sunum Slayt Ana Sayfalarını Yönetme
linktitle: Slayt Ana Sayfası
type: docs
weight: 70
url: /tr/nodejs-java/slide-master/
keywords:
- slayt ana sayfası
- ana slayt
- PPT ana slaytı
- birden çok ana slayt
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da slayt ana sayfalarını yönetin: PowerPoint ve OpenDocument sunumlarında ana slaytları erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slayt ana sayfası**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve altbilgi ayarları içerebilir. PowerPoint’te, slayt ana sayfasını düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Node.js via Java aynı modeli destekler. Bir sunum bir veya daha fazla ana slayt içerebilir ve her ana slayt birkaç düzen slaytı içerebilir. Normal slaytlar doğrudan bir ana slayta başvurmaz. Bunun yerine, normal bir slayt bir düzen slaytı kullanır ve bu düzen slaytı bir ana slayta aittir.

Hiyerarşi şöyledir:

1. **Slayt ana sayfası** – ortak tasarımı ve temayı tanımlar.  
1. **Düzen slaytı** – yer tutucuların belirli bir düzenini ve düzen‑seviyesi biçimlendirmeyi tanımlar.  
1. **Normal slayt** – gerçek sunum içeriğini içerir ve bir düzen slaytı kullanır.

![Ana slaytların, düzen slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’ta bir slayt ana sayfası, [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) sınıfı tarafından temsil edilir. Bir sunumdaki tüm ana slaytlar `Presentation.getMasters()` koleksiyonu üzerinden erişilebilir.

{{% alert color="info" title="Inheritance" %}}
Aynı özellik birden fazla seviyede tanımlandığında, daha spesifik seviye kazanır. Örneğin, bir ana slayt ve bir düzen slaytı her ikisi de bir arka plan tanımlarsa, o düzene dayalı slaytlar düzen arka planını kullanır. Düzen slaytları hakkında daha fazla bilgi için [Uygula veya Slayt Düzenlerini Değiştir](/nodejs-java/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **Slayt Ana Sayfalarına Erişim**

PowerPoint’te **Görünüm** > **Slayt Ana Sayfası** menüsünden Slayt Ana Sayfası görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slayt Ana Sayfası komutu](slide-master_3.jpg)

Aspose.Slides’ta ana slaytlara erişmek için `getMasters()` koleksiyonunu kullanın:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Ayrıca bir normal slaytın kullandığı ana slaytı, onun düzeni aracılığıyla alabilirsiniz:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Bir Slayt Ana Sayfasının İçeriği**

Bir ana slayt, slayt benzeri bir nesnedir. Ortak slayt davranışını [BaseSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/) sınıfından devralır; bu nedenle normal ve düzen slaytlarıyla aynı slayt özelliklerinin çoğunu sunar. Ana slayta özgü üyeler [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) API sayfasında listelenmiştir.

Sık kullanılan ana slayt üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `getBackground()` | Ana sayfa düzeyinde slayt arka planını ayarlar. |
| `getShapes()` | Logolar, resim çerçeveleri ve paylaşılan metin gibi ana sayfaya yerleştirilen şekilleri depolar. |
| `getLayoutSlides()` | Ana sayfaya ait düzen slaytlarını depolar. |
| `getThemeManager()` | Ana sayfa tema API’lerine erişim sağlar. |
| `getHeaderFooterManager()` | Ana sayfa ve ona bağlı düzenler için üst bilgi, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| `getDependingSlides()` | Düzenleri aracılığıyla ana sayfaya bağlı olan normal slaytları döndürür. |

## **Bir Slayt Ana Sayfaya Görsel Ekleme**

Bir ana slayta görsel eklediğinizde, o ana slayttan gelen düzenleri kullanan slaytlarda görünür. Logo, filigran, süs bandı ve diğer tekrarlanan görsel öğeler için kullanışlıdır.

Aşağıdaki örnek, ilk ana slayta bir logo ekler:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resim çerçeveleri hakkında daha fazla bilgi için [Resim Çerçevesi](/nodejs-java/picture-frame/) bölümüne bakın.

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle düzen slaytlarında tanımlanır. Ana slayt, bu düzenlerin devraldığı ortak stil ve temayı sağlar; her düzen ise hangi yer tutucuların mevcut olduğunu ve nerede konumlandırılacağını belirler.

PowerPoint’te yer tutucu komutları Slayt Ana Sayfası görünümünde bulunur.

![PowerPoint Slayt Ana Sayfası görünümünde Yer Tutucu Ekle komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için, ana slayta ait düzen slaytıyla çalışın:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ayrıca bir ana slayt üzerindeki mevcut yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer bir degrade dolgu uygular:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Normal slaytlar tarafından devralınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Yer Tutucuda İpucu Metni Ayarlama](/nodejs-java/manage-placeholder/) ve [Metin Biçimlendirme](/nodejs-java/text-formatting/) bölümlerine bakın.

## **Slayt Ana Sayfa Arka Planını Değiştirme**

Ana sayfa arka planı, üzerine yazılmadığı sürece düzenler ve slaytlar tarafından devralınır. Aşağıdaki örnek, ilk ana slayt için katı bir arka plan rengi ayarlar:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

İlgili konular için [Sunum Arka Planı](/nodejs-java/presentation-background/) ve [Sunum Teması](/nodejs-java/presentation-theme/) bölümlerine bakın.

## **Bir Slayt Ana Sayfayı Başka Bir Sunuma Klonlama**

`MasterSlideCollection.addClone` yöntemini kullanarak bir ana slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan ana slayt, hedef sunumdaki düzenler ve slaytlar tarafından kullanılabilir.

```javascript
let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Ana slaytlarıyla birlikte normal slaytları da klonlamanız gerekiyorsa, [Slaytları Klonla](/nodejs-java/clone-slides/) bölümüne bakın.

## **Birden Çok Slayt Ana Sayfa Ekleme**

Bir sunum birden çok ana slayt içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda kullanışlıdır.

![Ana slayt ekleme ve yönetme için PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan ana slaytı klonlar, klona farklı bir arka plan verir, o klonlanmış ana slayt altında bir düzen oluşturur ve bu düzen temel alınarak yeni bir slayt ekler:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt Ana Sayfaları Karşılaştırma**

Ana slaytlar, [BaseSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/) sınıfından devralınan `equals` yöntemi ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya mevcut tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

```javascript
let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Daha fazla bilgi için [Sunum Slaytlarını Karşılaştırma](/nodejs-java/compare-slides/) bölümüne bakın.

## **Slayt Ana Sayfa Görünümünü Varsayılan Görünüm Olarak Ayarlama**

[ViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/) üzerinde `setLastView` metodunu kullanarak PowerPoint’in ilk açtığı görünümü kontrol edebilirsiniz. Aşağıdaki örnek, sunumu Slayt Ana Sayfa görünümünde açar:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Daha fazla görünüm ayarı için [Sunumu Kaydet](/nodejs-java/save-presentation/) bölümüne bakın.

## **Kullanılmayan Ana Sayfaları Kaldırma**

Bazen bir sunum, herhangi bir normal slayt tarafından artık kullanılmayan ana slaytlar içerebilir. Kullanılmayan ana sayfaları kaldırmak dosya boyutunu azaltır ve şablon bakımını basitleştirir.

`removeUnused` metodunu kullanarak `getMasters()` koleksiyonundaki kullanılmayan ana slaytları kaldırın:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ayrıca düşük‑kodlu `Compress.removeUnusedMasterSlides` metodunu da kullanabilirsiniz:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir slayt ana sayfası ile bir düzen slaytı arasındaki fark nedir?**  
Bir slayt ana sayfası tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Bir düzen slaytı bir ana slayta aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir düzen slaytı kullanır, bu yüzden hem düzen hem de ana slayttan devralır.

**Bir sunum birden fazla slayt ana sayfası içerebilir mi?**  
Evet. Bir sunum birden fazla slayt ana sayfası içerebilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden fazla ana sayfa kullanın.

**Yer tutucuları bir ana slayta mı yoksa bir düzen slayta mı eklemeliyim?**  
Çoğu durumda yer tutucuları düzen slaytlara ekleyin. Paylaşılan görsel öğeleri ve ortak biçimlendirmeyi ana slayta, içerik yer tutucularını ise normal slaytların kullanacağı düzen slaytlara koyun.

**Kullanımda olan bir ana slaytı silebilir miyim?**  
Hayır. Bağımlı slaytları olan bir ana slayt doğrudan güvenli bir şekilde kaldırılamaz. Önce bu slaytları başka bir ana slayt altındaki düzenlere taşıyın veya yalnızca kullanılmayan ana slaytları temizleyen bir yöntem kullanın.