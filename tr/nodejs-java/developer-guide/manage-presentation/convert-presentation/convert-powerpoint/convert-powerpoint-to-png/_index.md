---
title: JavaScript'te PowerPoint Slaytlarını PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint dönüştürme
- sunumu dönüştürme
- slaytı dönüştürme
- PPT dönüştürme
- PPTX dönüştürme
- PowerPoint'ten PNG'ye
- sunumdan PNG'ye
- slayttan PNG'ye
- PPT'den PNG'ye
- PPTX'ten PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript'te PowerPoint sunumlarını yüksek kaliteli PNG görüntülerine hızlı bir şekilde dönüştürün, kesin ve otomatik sonuçlar sağlayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java kullanarak sunum slaytlarını PNG görüntülerine nasıl dönüştüreceğinizi açıklar. PPT, PPTX ve ODP gibi formatlardaki sunumları yükleyebilir, her bir slaytı renderlayabilir ve ayrı bir PNG görüntüsü olarak kaydedebilirsiniz.

Aşağıdaki örnekler, varsayılan ölçekle renderlamayı, ölçeği artırmayı, çıktı boyutlarını piksel olarak belirtmeyi ve bir degrade renderlama stilini seçmeyi gösterir.

## **PowerPoint'i PNG'ye Dönüştür**

Bir sunumu [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytlarına [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) koleksiyonu aracılığıyla erişin. Örnek, her bir slaytı parametresiz olarak [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) kullanarak bir thumbnail oluşturur. Ardından [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) metodunu [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) ile çağırarak renderlanan her slaytı PNG görüntüsü olarak kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Parametresiz [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) aşırı yüklemesi 0.2 ölçekle renderlar. Örneğin, 720 × 540 puan ölçüsündeki bir slayt 144 × 108 piksel thumbnail üretir. Çıktı boyutlarını kontrol etmek için aşağıda gösterildiği gibi ölçek faktörleriyle veya açık bir görüntü boyutuyla aşırı yüklemeleri kullanın.
{{% /alert %}}

## **PowerPoint'i Özelleştirilmiş Boyutlarda PNG'ye Dönüştür**

Renderlanan boyutları kontrol etmek için [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) yöntemine yatay ve düşey ölçek faktörlerini geçirin. Bu örnekte, her iki faktör de 2'dir, bu nedenle 720 × 540 puan ölçüsündeki bir slayt 1440 × 1080 piksel görüntü üretir. Eşit ölçek faktörleri slaytın en‑boy oranını korur. Her görüntü, [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) kullanılarak PNG formatında kaydedilir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **PowerPoint'i Özelleştirilmiş Boyutla PNG'ye Dönüştür**

Çıktı boyutlarını piksel olarak belirtmek için ölçek faktörleri yerine bir boyut değerini [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) yöntemine geçirin. Bu örnek, her slaytı 960 × 720 piksel olarak renderlar ve sonucu [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) ile kaydeder. Görüntünün gerilmesini önlemek için slaytın en‑boy oranına uygun boyutları seçin.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Bir Degrade Renderlama Stili Seçin**

Bir slayt degrade dolgu içerdiğini varsayalım, ancak dışa aktarılan PNG'deki geçişler PowerPoint'te gördüklerinizden daha açık ya da farklı görünsün. Degradelerin nasıl renderlanacağını seçmek için [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) sınıfı tarafından miras alınan [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) metodunu kullanabilirsiniz.

[gradient-styles.pptx](gradient-styles.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı, üstte camgöbeği‑turuncu ve altta mavi‑sarı olmak üzere iki lineer degrade içerir. Her degrade, %0 ve %100 konumunda iki durak noktasına sahiptir.

Aşağıdaki örnek bu sunumu yükler ve aynı ilk slaytı her iki modda da [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) kullanarak renderlar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| Default | PowerPointUI |
| --- | --- |
| ![Default ile renderlanan camgöbeği‑turuncu ve mavi‑sarı degradeler](gradient-Default.png) | ![PowerPointUI ile renderlanan aynı degradeler](gradient-PowerPointUI.png) |

Bu örnekte, `Default` daha açık ara renkler üretirken, `PowerPointUI` daha koyu ara renkler üretir. Fark, degradede kullanılan renkler ve durak noktasına bağlıdır.

`Default` i, standart Aspose.Slides çıktısı ihtiyaçlarınızı karşılıyorsa seçin. `PowerPointUI` i, önceliğiniz PowerPoint'teki görünümü eşleştirmekse deneyin. Her iki çıktıyı da hedefinizle karşılaştırın; hiçbir mod evrensel olarak daha üstün değildir.

## **SSS**

**Tüm slayt yerine bir grafik veya resim gibi belirli bir şekli nasıl dışa aktarabilirim?**

Aspose.Slides, [individual shapes için thumbnail oluşturmayı](/slides/tr/nodejs-java/create-shape-thumbnails/) destekler ve böylece bir şekli PNG görüntüsü olarak renderlayabilirsiniz.

**Sunucuda paralel dönüştürme destekleniyor mu?**

Evet. Her bir iş parçacığı veya süreç için ayrı bir sunum örneği kullanın; [iş parçacıkları arasında tek bir örnek paylaşmayın](/slides/tr/nodejs-java/multithreading/).

**PNG'ye dışa aktarırken değerlendirme sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/nodejs-java/licensing/) uygular.