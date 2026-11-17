---
title: JavaScript ile Sunumlarda Görüntü Dönüşüm Efektlerini Yönetme
linktitle: Görüntü Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/nodejs-java/image-transform-effects/
keywords:
- görüntü dönüşümü
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- iki tonlu
- renk tonu
- HSL
- renk değiştirme
- bulanıklaştırma
- şeffaflık
- alfa efekti
- efekt zinciri
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile Java üzerinden resim çerçeveleri için görüntü dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını sıralı bir görüntü dönüşüm işlemleri koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) ile başlayın ve [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) öğesine erişin. Döndürülen [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) size etkileri yeniden yazmadan ekleme, sayma, inceleme, kaldırma ve temizleme imkanı sunar.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklaştırma, şeffaflık, sıralı etki zincirleri, etkili değerler, kaldırma ve PPTX çift yönlü doğrulama için tam bir iş akışını gösterir.

## **Etkilerin Sahipliğini ve Görüntü Yeniden Kullanımını Anlamak**

Bir görüntü kaynağı ve onu gösteren resim farklı nesnelerdir:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) kaynak görüntü verilerini sunum tarafından sahip olunan şekilde depolar veya referans verir.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) bir resim dolduruma aittir ve bir görüntü kaynağına başvururken aynı zamanda görüntü dönüşüm koleksiyonunu depolar.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) ilgili resim doldurumu, geometriyi, kırpma ayarlarını ve diğer çerçeve düzeyindeki biçimlendirmeleri sahip olan slayt şeklidir.

Bu nedenle, görüntü dönüşüm işlemleri [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) içindeki baytları değiştirmez. Aynı [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) birden fazla kez [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) öğesine aktarılırsa, her yeni resim çerçevesi kendi [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) ve kendi dönüşüm koleksiyonunu alır. Bir çerçeveye gri tonlama uygulamak, diğer çerçeveleri gri tonlamaz, tüm çerçeveler aynı gömülü görüntü kaynağını kullansa bile.

Aynı [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) modeli şekil doldurumu veya slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıklarını ve Birimlerini Kullanma**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü her dışarıdaki değeri hemen reddetmese bile bu aralıklarda kalın; hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Yok | Sayısal parametre yok. Alfa değişmez. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Karanlık ve açık pikseller için iki renk. `java.awt.Color` içindeki RGB ve alfa kanalları `0` ile `255` arasında. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Ton `0` dahil, `360` hariç derecede; miktar `-100` ile `100` arasında, yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Ton `0` dahil, `360` hariç derecede; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Yerine geçen renk, kanal değerlerini `0` ile `255` arasında kullanır. Mevcut alfa değerleri değişmez. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Yarıçap negatif olmamalı ve puan cinsinden ölçülür; `grow` bulanık içeriğin orijinal sınırların dışına uzanıp uzanamayacağını kontrol eden bir Boolean'dır. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen şeffaf, `100` mevcut alfanı korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Bu değerin altındaki değerler şeffaf, eşit ya da üzerindeki değerler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık birbirini tamamlar. Örneğin, %35 şeffaflık, %65 alfa modülasyon miktarına karşılık gelir.

## **Parlaklık ve Kontrast Uygulama**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) bir [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) işlemi döndürür. Ölçek ayarları işlem oluşturulurken sağlanır. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) hesaplanmış yalnızca‑okunur değerleri verir; bu değerler incelenebilir veya kaydedilebilir.

Aşağıdaki örnek parlaklığı %15 ve kontrastı %20 artırır, ardından gömülü görüntüyü değiştirmeden bir önizleme oluşturur:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) bir Office 2010 resim‑efekt uzantısıdır ve standart DrawingML parlaklık efektinden daha az taşınabilirdir. Parlaklık ve kontrastın PPTX çift yönlü geçişten sonra da düzenlenebilir kalması gerekiyorsa, [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Format sınırlamaları bölümü bu ayrımı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulama**

Renk efektleri, aynı görüntü kaynağını yeniden kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirme uygular.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri eşler. Bu, ayarları tek bir skaler değerden daha karmaşık bir etki örneği olduğundan faydalı bir örnek oluşturur.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) her pikselin rengini sabit bir renkle değiştirirken alfabı korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya koyan [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) işlevinden farklıdır.

### **Parlaklık Eşiği Uygulama**

Parlaklık eşiği, taranmış bir sayfadaki soluk izleri arka planla ayırt etmeyi kolaylaştırabilir. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ara ton gri tonlarını korur. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) parlaklığı siyah veya beyaza eşler, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ise opaklığa bir eşik uygular.

Parlaklık eşiği %0‑%100 arasında, yüzde dahil olmak üzere değişir. Eşiğin altındaki pikseller siyah, eşit ya da üzerindeki pikseller beyaz olur. Eşiği yükseltmek, daha fazla tonu siyaha çevirir çünkü daha çok piksel kesim noktasının altına düşer.

[grayscale-swatches.png](grayscale-swatches.png) dosyasını çalışma dizinine indirin. Her etiket, 0‑255 ölçeğinde özgün gri seviyesini gösterir. Örnek, özgünü iki kopyanın yanına koyar ve her kopyanın eşiğini sunuma kaydeder.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Çıktı sunumunu PowerPoint ile açıp üç çerçeveyi karşılaştırın. 96 etiketi %38 parlaklığa (255 içinde 96) sahiptir. %20 eşiğinde beyaza, %60 eşiğinde siyaha dönüştürülür.

![Orijinal gri tonlu örnekler, yüzde 20 ve %60 parlaklık eşiğinde siyah‑beyaz sonuçların yanında](luminance-threshold.png)

## **Bulanıklaştırma, Şeffaflık ve Alfa Efektleri Ekleme**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) tüm renk kanallarını, alfa dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına uzanabileceği durumlarda `grow` değerini `true` yapın.

Tekdüzen şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) kullanın. Bu, mevcut her alfa değerini çarpar; böylece kısmen şeffaf pikseller orantısal farklılıklarını korur. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ise tüm piksellere tek bir alfa değeri atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) alfa değerini bir eşik üzerinden iki seviyeye dönüştürür.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diğer parametresiz alfa işlemleri şunları içerir: [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), tüm sıfırdan farklı alfalara tam opaklık verir; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), %100 altındaki tüm alfalara tam şeffaflık verir; ve [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), alfabı `100% - alfa` olarak değiştirir.

## **Sıralı Etki Zinciri Oluşturma**

Her `add...Effect` yöntemi yeni bir işlemi koleksiyonun sonuna ekler. İşleyici koleksiyonu sıralı bir boru hattı olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur, vb. Sonuç olarak, aynı işlemler farklı bir sırada farklı bir görüntü üretebilir.

Örneğin, gri tonlama ardından tonlama önce renk bilgisini kaldırır, ardından parlaklık sonucunu yeniden renklendirir. Tonlama ardından gri tonlama tonlamayı tekrar kaldırır. Benzer şekilde, alfa değiştirme, önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise bunların göreli farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem türlerini hem de sırasını denetler ve yeniden açılan sonucu render eder:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Koleksiyon, renk, alfa ve bulanıklaştırma işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Birleştirilebilirler, ancak birleşimler her zaman yararlı olmayabilir. Sabit bir renk değiştirme, önceki renk efektleri tarafından üretilen RGB varyasyonunu kaldırır; duotone’dan sonra gri tonlama iki seçilmiş rengi ortadan kaldırır; ve alfa tavan, taban, değiştirme veya iki‑seviyeli işlemler, önceki adımlarda oluşturulan alfa detayını yok edebilir. Zinciri, istenen piksel‑işleme sırasına göre oluşturun; öğeleri sırasız biçimlendirme bayrakları gibi düşünmeyin.


<!-- visual-explanation:image-transform-effects:start -->
[![Aynı resim önce gri tonlamadan sonra tonlama, ardından tonlamadan sonra gri tonlama. İki son gri tonlama görüntüsü farklı tonlara sahiptir.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Bu görsel Aspose.Slides for .NET 26.11 gösteriminde, %25 şeffaflıkta 220° tonlama gri tonlama görüntüsünü değiştirmez. Aynı tonlamayı gri tonlamadan önce uygulamak farklı tonlar üretir.*
<!-- visual-explanation:image-transform-effects:end -->

## **Düzenlenebilir ve Etkili Değerleri İnceleme**

Düzenlenebilir bir işlem, [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) içinde depolanan nesnedir. Etkiye bağlı olarak, doğrudan yazılabilir üyeler sunulabilir. Örneğin, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) `radius` ve `grow` değerlerini, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) `amount` değerini, [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) `threshold` değerini yazılabilir olarak ortaya koyar. [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) gibi renk efektleri değiştirilebilir [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) nesnelerini açığa çıkarır.

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), ve [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/) gibi bazı işlemler, oluşturma skalerlerini yazılabilir özellik olarak göstermez. Bu ayarları değiştirmek için işlemi kaldırıp gerekli konuma yeni bir işlem ekleyin.

`getEffective()` tarafından döndürülen etkili veri, hesaplanmış ve yalnızca‑okunur. Tema‑bağımlı renkleri çözmek ve işleyicinin kullandığı normalleştirilmiş değerleri okumak için faydalıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri sayar ve ilgili API sağladığında etkili değerleri inceler:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Gri tonlama, alfa tavan ve alfa ters gibi parametresiz etkiler de bir etkili‑veri nesnesine sahiptir, ancak yazdırılacak skaler ayar yoktur. Bunların varlığı ve koleksiyondaki konumu önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

Belirli bir işlemi indeksle kaldırmak için [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) kullanın. Kaldırmadan sonra indeksler kaydığı için, önce hedefi bulun ve sayma işleminden sonra kaldırın. Tüm zinciri kaldırmak için [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) kullanın.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Tekrar kullanılan [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde etkilemez.

## **Sunum Formatlarını ve Dışa Aktarım Hedeflerini Düşünme**

Görüntü dönüşümleri DrawingML’den kaynaklanır, bu nedenle PPTX etki zincirleri için tercih edilen düzenlenebilir formattır. PPTX ile bile, her işlem aynı taşınabilirliğe sahip değildir:

- Luminance, grayscale, duotone, tint, HSL, blur ve yaygın alfa işlemleri gibi standart DrawingML işlemleri, PPTX çift yönlü geçişinden sonra hayatta kalma şansı en yüksek olanlardır. Koruma bir gereklilik olduğunda, her zaman oluşturulan dosyayı yeniden açın ve koleksiyonu denetleyin.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) bir Office 2010 uzantısıdır, standart DrawingML luminance işlemi değildir. Bellek içi render için kullanılabilir, ancak PPTX kaydedilip yeniden açıldığında düzenlenebilir bir [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) işlemi olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarlamaları için [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) tercih edin.
- Binary PPT formatı tam DrawingML etki modelinden önce gelmiştir. PPT’ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaşık olarak oluşturabilir. Karmaşık düzenlenebilir bir zincir için PPT’yi doğrulama formatı olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılara render etmek, desteklenen zinciri render edilen görünüme uygular. Bu çıktılar düzenlenebilir bir [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) içermez; raster formatlar sonucu piksellere düzleştirir, belge/vektör dışa aktarımları ise kendi render temsillerini saklar.
- Efektler, bağlı bir resmi kendine yeterli hâle getirmez. Bağlı bir resmi render etmek, sunum yüklendiğinde bağlı kaynağın erişilebilir olmasına hâlâ bağlıdır.

Farklı sunum tüketicileri, özellikle birkaç alfa veya renk‑kuantalama işlemi birleştirildiğinde kenar durumlarını farklı şekilde render edebilir. Kritik çıktılar için, üretimde kullanılan aynı Aspose.Slides sürümüyle hem düzenlenebilir çift yönlü geçişi hem de nihai dışa aktarma formatını test edin.

## **FAQ**

**Görüntü dönüşüm efektleri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler, resim doldurumu tarafından kullanılan [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) nesnesine aittir. Altındaki [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) baytları değişmez.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi etkilerini paylaşır mı?**

Hayır. Aynı [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) kullanmak veri çoğaltmayı önler, ancak her resim çerçevesi genellikle ayrı bir [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) ve görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklaştırma ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon, bunları tek bir sıralı zincirde kabul eder. Önceki işlemin çıktısına ne yaptığına dikkat edin; değiştirme ve eşik işlemleri, önceki renk veya alfa detayını yok edebilir.

**Etkili değerler neden yalnızca‑okunur?**

Etkili veri, render sırasında kullanılan hesaplanmış değerleri (çözülmüş renkler dahil) temsil eder. Yazılabilir üyeler mevcutsa dönüşüm koleksiyonunda saklanan işlemi düzenleyin; aksi takdirde işlemi kaldırıp yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Legacy PPT, tam DrawingML etki modelini temsil edemez; render edilen dışa aktarma formatları ise yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini tutmaz.