---
title: Sunum Slide Master'larını JavaScript ile Yönet
linktitle: Slayt Master
type: docs
weight: 70
url: /tr/nodejs-java/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slaytı
- çoklu master slaytlar
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarında master slaytlarını erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarları içerebilir. PowerPoint'te, bir slide master'ı düzenlemek, her slaytta aynı biçimlendirmeyi tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Node.js via Java aynı modeli destekler. Bir sunum bir veya daha fazla master slide içerebilir ve her master slide birkaç layout slide içerebilir. Normal slaytlar genellikle doğrudan bir master slide'a başvurmaz. Bunun yerine, normal bir slayt bir layout slide kullanır ve o layout slide bir master slide'a aittir.

The hierarchy is:

1. **Slide master** - ortak tasarımı ve temayı tanımlar.
1. **Layout slide** - yer tutucuların ve düzen seviyesi biçimlendirmesinin belirli bir düzenini tanımlar.
1. **Normal slide** - gerçek sunum içeriğini içerir ve bir layout slide kullanır.

![master slide'ların, layout slide'ların ve normal slide'ların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides'de bir slide master, [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) sınıfı tarafından temsil edilir. Bir sunumdaki tüm master slide'lar `Presentation.getMasters()` koleksiyonu aracılığıyla erişilebilir.

{{% alert color="info" title="Inheritance" %}}
Bir özellik birden fazla seviyede tanımlandığında, daha spesifik seviye geçerli olur. Örneğin, bir master slide ve bir layout slide aynı arka planı tanımlarsa, o layout'a dayalı slaytlar layout arka planını kullanır. Layout slide'lar hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/nodejs-java/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **Slide Master'lara Erişim**

PowerPoint'te, **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides'de, master slide'lara erişmek için `getMasters()` koleksiyonunu kullanın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Normal bir slaytın kullandığı master slide'ı, slaytın layout'u aracılığıyla da alabilirsiniz:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Bir Slide Master'ın İçeriği**

Bir master slide, slayt benzeri bir nesnedir. Ortak slayt davranışını [BaseSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/) sınıfından devralır, bu sayede normal ve layout slaytlarda kullanılan birçok slayt özelliğini sunar. Master'a özgü üyeler [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) API sayfasında listelenmiştir.

Yaygın olarak kullanılan master slide üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `getBackground()` | Master seviyesindeki slayt arka planını ayarlar. |
| `getShapes()` | Master üzerinde bulunan şekilleri, örneğin logolar, resim çerçeveleri ve ortak metinleri depolar. |
| `getLayoutSlides()` | Master'a ait layout slide'ları depolar. |
| `getThemeManager()` | Master tema API'lerine erişim sağlar. |
| `getHeaderFooterManager()` | Master ve onun alt layoutları için üst bilgi, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| `getDependingSlides()` | Layout'ları aracılığıyla master'a bağımlı olan normal slaytları döndürür. |

## **Slide Master'a Görüntü Ekleme**

Bir master slide'a bir görüntü eklendiğinde, o master'dan layout kullanan slaytlarda görünür. Bu, logolar, filigranlar, dekoratif bantlar ve diğer tekrarlanan görsel öğeler için yararlıdır.

Aşağıdaki örnek, ilk master slide'a bir logo ekler:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/nodejs-java/picture-frame/) sayfasına bakın.

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slide'larda tanımlanır. Master slide, bu layout'ların devraldığı ortak stil ve temayı sağlar, her layout ise hangi yer tutucuların mevcut olduğunu ve nerede konumlandırılacağını belirler.

PowerPoint'te, yer tutucu komutları Slide Master görünümünde mevcuttur.

![PowerPoint Slide Master görünümünde Yer Tutucu Ekle komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için master'a ait layout slide ile çalışın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Master slide'da zaten bulunan yer tutucu şekillerini de biçimlendirebilirsiniz. Aşağıdaki örnek başlık yer tutucusunu bulur ve lineer gradient doldurma uygular:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Normal slaytlar tarafından devralınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) ve [Text Formatting](/nodejs-java/text-formatting/) bölümlerine bakın.

## **Slide Master Arka Planını Değiştirme**

Bir master arka planı, üzerine yazılmayan layout'lar ve slaytlar tarafından devralınır. Aşağıdaki örnek, ilk master slide için katı bir arka plan rengi ayarlar:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

İlgili konular için [Presentation Background](/nodejs-java/presentation-background/) ve [Presentation Theme](/nodejs-java/presentation-theme/) bölümlerine bakın.

## **Slide Master'ı Başka Bir Sunuma Kopyalama**

`MasterSlideCollection.addClone` kullanarak bir master slide'ı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout'lar ve slaytlar tarafından kullanılabilir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Master'larıyla birlikte normal slaytları da kopyalamanız gerekiyorsa, [Clone Slides](/nodejs-java/clone-slides/) bölümüne bakın.

## **Birden Fazla Slide Master Ekleme**

Bir sunum birden fazla master slide içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiğinde yararlıdır.

![Slide master ekleme ve yönetme için PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master'ı klonlar, klona farklı bir arka plan verir, o klonlanmış master altında bir layout oluşturur ve bu layout'a dayalı yeni bir slayt ekler:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Slide Master'ları Karşılaştırma**

Master slide'lar, [BaseSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/) üzerinden devralınan `equals` yöntemi ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya geçerli tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/nodejs-java/compare-slides/) bölümüne bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

[ViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/) üzerindeki `setLastView` metodunu kullanarak PowerPoint'in ilk açtığı görünümü kontrol edebilirsiniz. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/nodejs-java/save-presentation/) bölümüne bakın.

## **Kullanılmayan Master Slide'ları Kaldırma**

Sunumlar bazen, hiçbir normal slayt tarafından kullanılmayan master slide'lar içerir. Kullanılmayan master'ları kaldırmak dosya boyutunu azaltabilir ve şablon bakımıyla ilgilenmeyi basitleştirir.

`removeUnused` kullanarak `getMasters()` koleksiyonundaki kullanılmayan master'ları kaldırabilirsiniz:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ayrıca düşük kodlu `Compress.removeUnusedMasterSlides` metodunu da kullanabilirsiniz:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Slide master ile layout slide arasındaki fark nedir?

Bir slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Bir layout slide, bir master slide'a aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slide kullanır, böylece hem layout hem de master'dan miras alır.

### Bir sunum birden fazla slide master içerebilir mi?

Evet. Bir sunum birden fazla slide master içerebilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden çok master kullanın.

### Yer tutucuları bir master slide'a mı yoksa bir layout slide'a mı eklemeliyim?

Çoğu durumda, yer tutucuları layout slide'lara ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeleri master slide'a koyun, ardından içerik yer tutucularını normal slaytların kullanacağı layout'lara yerleştirin.

### Kullanımda olan bir master slide'ı silebilir miyim?

Hayır. Bağımlı slaytları olan bir master slide, doğrudan güvenli bir şekilde kaldırılamaz. Önce bu slaytları başka bir master altındaki layout'lara taşıyın veya yalnızca kullanılmayan master'ları kaldıran bir temizlik yöntemi kullanın.