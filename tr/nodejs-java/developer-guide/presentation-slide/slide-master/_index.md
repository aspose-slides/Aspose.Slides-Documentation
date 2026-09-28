---
title: JavaScript'te Sunum Slayt Master'larını Yönet
linktitle: Slayt Master
type: docs
weight: 70
url: /tr/nodejs-java/slide-master/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarında master slaytlarına erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için paylaşılan tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarları içerebilir. PowerPoint’te, slide master’ı düzenlemek, aynı biçimlendirmeyi her slayda tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for Node.js via Java aynı modeli destekler. Bir sunum bir veya daha fazla ana slayt içerebilir ve her ana slayt birkaç yerleşim slaytı barındırabilir. Normal slaytlar genellikle doğrudan bir ana slayta başvurmaz. Bunun yerine, normal bir slayt bir yerleşim slaytı kullanır ve bu yerleşim slaytı bir ana slayta aittir.

Hiyerarşi şudur:

1. **Slide master** – paylaşılan tasarım ve temayı tanımlar.  
1. **Layout slide** – yer tutucuların ve yerleşim‑seviyesi biçimlendirmenin belirli bir düzenini tanımlar.  
1. **Normal slide** – gerçek sunum içeriğini içerir ve bir yerleşim slaytı kullanır.

![Ana slaytların, yerleşim slaytlarının ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’ta bir slide master, [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) sınıfı ile temsil edilir. Bir sunumdaki tüm ana slaytlar `Presentation.getMasters()` koleksiyonu aracılığıyla erişilebilir.

{{% alert color="info" title="Inheritance" %}}

Aynı özellik birden fazla seviyede tanımlandığında, daha özgül seviye kazanır. Örneğin, bir ana slayt ve bir yerleşim slaytı her ikisi de arka plan tanımlarsa, o yerleşime dayalı slaytlar yerleşim arka planını kullanır. Yerleşim slaytları hakkında daha fazla bilgi için [Slayt Düzenlerini Uygula veya Değiştir](/nodejs-java/slide-layout/) bölümüne bakın.

{{% /alert %}}

## **Slayt Üstatlarına Erişim**

PowerPoint’te **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides’ta ana slaytlara erişmek için `getMasters()` koleksiyonunu kullanın:

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

Ayrıca, normal bir slaytın kullandığı yerleşim üzerinden ana slaytı şu şekilde alabilirsiniz:

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

## **Bir Slide Master Ne İçerir**

Bir ana slayt, slayt benzeri bir nesnedir. Ortak slayt davranışını [BaseSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/) sınıfından devraldığından, normal ve yerleşim slaytlarıyla aynı birçok slayt özelliğine sahiptir. Ana slayta özgü üyeler [MasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) API sayfasında listelenmiştir.

Sık kullanılan ana slayt üyeleri şunlardır:

| Üye | Açıklama |
| --- | --- |
| `getBackground()` | Ana‑seviye slayt arka planını ayarlar. |
| `getShapes()` | Logolar, resim çerçeveleri ve paylaşılan metin gibi ana slayta yerleştirilen şekilleri depolar. |
| `getLayoutSlides()` | Ana slayta ait yerleşim slaytlarını depolar. |
| `getThemeManager()` | Ana tema API’lerine erişim sağlar. |
| `getHeaderFooterManager()` | Ana slayt ve alt slaytları için üst bilgi, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| `getDependingSlides()` | Yerleşimleri aracılığıyla ana slayta bağımlı olan normal slaytları döndürür. |

## **Bir Slide Master’a Resim Ekleme**

Bir ana slayta resim eklediğinizde, o ana slayttan gelen yerleşimleri kullanan slaytlarda görünür. Bu, logolar, filigranlar, dekoratif bantlar ve diğer yinelenen görsel öğeler için yararlıdır.

Aşağıdaki örnek, ilk ana slayta bir logo ekler:

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

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/nodejs-java/picture-frame/) bölümüne bakın.

## **Ana Grafiklerin Görünürlüğünü Kontrol Etme**

Miras alınan ana grafikleri (ör. logolar veya dekoratif şekiller) silmeden gizlemek için [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) metodunu kullanın. Görüntülenmemesi gereken slaytta `false` değerini, göstermek istediğiniz slaytlarda ise `true` değerini [Slide.setShowMasterShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#setShowMasterShapes) metoduna geçirin.

Aşağıdaki bağımsız örnek, bir ana slayta mavi bir dekoratif bant ekler ve aynı boş yerleşimi kullanan iki slaytta farklı görünürlük ayarları uygular. İlk slaytta bant görünür, ikincisinde gizlenir. Giriş sunumu veya resim gerektirmez.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Örnek, yeni bir sunumla gelen **Blank** yerleşimini kullanır ve başlangıç slaydının kendi yer tutucularını kaldırır.

### **Ayarın Kapsamını Seçme**

Normal bir slayt, ana slaytına [Slide.getLayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getLayoutSlide) ve [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#getMasterSlide) aracılığıyla başvurur. Özelliği bireysel bir slaytta ayarlamak yalnız o slaytı etkiler. `false` değerini [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) metoduna geçirerek, aynı ortak yerleşimi kullanan tüm slaytlarda ana grafikler gizlenir; kendi ayarları `true` olsa bile. Tek bir slaytta grafik gizlemek için slayt özelliğini değiştirin, ortak yerleşimi değiştirmeyin.

Bu ayar, ana slaytın kendisinde görünürlük kontrolü olarak desteklenmez. Bir ana slaytta [getShowMasterShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) her zaman `false` döner ve [setShowMasterShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) metoduna `true` gönderildiğinde bir istisna oluşur. Bunu normal bir slayt veya bir yerleşim üzerinde uygulayın.

### **Grafikleri Arka Plandan Ayırma**

| İşlem | Etki |
| --- | --- |
| Ana grafikleri gizle | Miras alınan ana şekilleri silmeden veya slaytın kendi şekillerini değiştirmeden görünürlüğünü kontrol eder. |
| Slayt arka plan dolgusunu değiştir | Arka plan renk, degrade veya resmi değiştirir. Ana grafikler ayrı şekiller olarak kalır ve arka planın üzerine görünür. [Presentation Background](/slides/tr/nodejs-java/presentation-background/) bölümüne bakın. |
| Ana slayttan bir şekli sil | Paylaşılan kaynak şekli kaldırır; bu şekil artık o ana slaytı kullanan hiçbir slaytta bulunmaz. |

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle yerleşim slaytlarında tanımlanır. Ana slayt, bu yerleşimlerin miras alacağı ortak stil ve temayı sağlar; her yerleşim ise hangi yer tutucuların bulunacağını ve nerede konumlanacağını belirler.

PowerPoint’te yer tutucu komutları Slide Master görünümünde mevcuttur.

![PowerPoint Slide Master görünümündeki Yer Tutucu Ekle komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için ana slayta ait yerleşim slaytıyla çalışın:

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

Ayrıca, ana slaytta zaten var olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer bir degrade dolgu uygular:

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

![Normal slaytlarda miras alınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Diğer yer tutucu ve metin biçimlendirme seçenekleri için [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) ve [Text Formatting](/nodejs-java/text-formatting/) bölümlerine bakın.

## **Bir Slide Master Arka Planını Değiştirme**

Ana arka plan, üzerine yazılmadığı sürece yerleşim ve slaytlar tarafından miras alınır. Aşağıdaki örnek, ilk ana slayta katı bir arka plan rengi atar:

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

İlgili konular için [Presentation Background](/nodejs-java/presentation-background/) ve [Presentation Theme](/nodejs-java/presentation-theme/) bölümlerine göz atın.

## **Bir Slide Master’ı Başka Bir Sunuma Kopyalama**

`MasterSlideCollection.addClone` metodunu kullanarak bir ana slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan ana slayt, hedef sunumdaki yerleşimler ve slaytlar tarafından kullanılabilir.

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

Normal slaytları ana slaytlarıyla birlikte kopyalamanız gerekiyorsa, [Clone Slides](/nodejs-java/clone-slides/) bölümüne bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden fazla ana slayt içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda yararlıdır.

![PowerPoint’te ana slayt ekleme ve yönetme komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan ana slaytı klonlar, kopyaya farklı bir arka plan verir, bu klonun altında bir yerleşim oluşturur ve bu yerleşime dayalı yeni bir slayt ekler:

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

## **Slide Master’ları Karşılaştırma**

Ana slaytlar, [BaseSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/) sınıfından miras alınan `equals` yöntemi ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya mevcut tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

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

[ViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/) üzerindeki `setLastView` metodunu kullanarak PowerPoint’in ilk açtığında hangi görünümde olacağını kontrol edebilirsiniz. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

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

Diğer görünüm ayarları için [Save Presentation](/slides/tr/nodejs-java/save-presentation/) bölümüne bakın.

## **Kullanılmayan Ana Slaytları Kaldırma**

Bazen bir sunum, hiçbir normal slayt tarafından kullanılmayan ana slaytlar içerir. Kullanılmayan ana slaytları kaldırmak dosya boyutunu azaltabilir ve şablon bakımını basitleştirebilir.

`removeUnused` metodunu kullanarak `getMasters()` koleksiyonundaki kullanılmayan ana slaytları kaldırın:

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

Ayrıca düşük‑kodlu `Compress.removeUnusedMasterSlides` metodunu da kullanabilirsiniz:

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

## **SSS**

**Slide master ile layout slide arasındaki fark nedir?**  
Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi paylaşılan tasarım ayarlarını tanımlar. Layout slide, bir master slayta aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slide kullanır, böylece hem layout hem de master’dan miras alır.

**Bir sunum birden fazla slide master içerebilir mi?**  
Evet. Bir sunum birden fazla slide master içerebilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden fazla master kullanın.

**Yer tutucuları bir master slayta mı yoksa bir layout slide’a mı eklemeliyim?**  
Çoğu durumda yer tutucuları layout slide’lara ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeyi master slayta, içerik yer tutucularını ise normal slaytların kullanacağı layout slide’lara yerleştirin.

**Kullanılan bir master slaytı silebilir miyim?**  
Hayır. Bağımlı slaytları olan bir master slayt doğrudan güvenli bir şekilde kaldırılamaz. Öncelikle bu slaytları başka bir master altındaki layout’lara taşımalı veya yalnızca kullanılmayan masterları temizleyen bir yöntemle kaldırmalısınız.