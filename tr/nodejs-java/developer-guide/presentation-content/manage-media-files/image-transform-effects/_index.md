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
- çift ton
- renk tonu
- HSL
- renk değiştirme
- bulanıklık
- şeffaflık
- alfa efekti
- efekt zinciri
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile Java aracılığıyla resim çerçeveleri için görüntü dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını sıralı bir görüntü dönüşüm işlemleri koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [Picture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/) nesnesiyle başlayın ve [Picture.getImageTransform](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/) yöntemine erişin. Döndürülen [ImageTransformOperationCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) size orijinal görüntü baytlarını yeniden yazmadan efekt ekleme, listeleme, inceleme, kaldırma ve temizleme imkanı verir.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklık, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX çift yönlü doğrulama için tam bir iş akışı gösterir.

## **Efekt Sahipliğini ve Görüntü Yeniden Kullanımını Anlama**

Bir görüntü kaynağı ve onu gösteren resim farklı nesnelerdir:

- [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) sunumun sahip olduğu kaynak görüntü verilerini depolar veya referans verir.
- [Picture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/) bir resim doldurmasına aittir ve bir görüntü kaynağına başvururken görüntü dönüşüm koleksiyonunu saklar.
- [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) ilgili resim doldurmasını, geometrisini, kırpma ayarlarını ve diğer çerçeve‑seviyesi biçimlendirmeyi sahipleyen slayt şeklidir.

Bu nedenle, görüntü dönüşüm işlemleri [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) içindeki baytları değiştirmez. Aynı [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) birden fazla kez [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/) metoduna gönderildiğinde, her yeni resim çerçevesi kendi [Picture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/) ve kendi dönüşüm koleksiyonuna sahip olur. Bir çerçeveye gri tonlama uygulamak diğer çerçeveleri gri tonlamaz, çünkü hepsi aynı gömülü görüntü kaynağını kullanır.

Aynı [Picture.getImageTransform](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/) modeli, şekil ya da slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler yalnızca resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıklarını ve Birimleri Kullanma**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü hemen her geçersiz değeri reddetmese bile bu aralıklarda kalın; hedef sunum biçimi kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Yok | Sayısal parametre yoktur. Alfa değişmez. |
| [addDuotoneEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Koyu ve açık pikseller için iki renk. `java.awt.Color` içinde RGB ve alfa kanalları `0`‑`255` aralığındadır. |
| [addTintEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Açık renk `0` (dahil) ile `360` (hariç) derece; miktar `-100`‑`100` yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Açık renk `0`‑`360` derece; doygunluk ve parlaklık `-100`‑`100` yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Değiştirme rengi kanallar `0`‑`255` aralığındadır. Mevcut alfa değerleri değişmez. |
| [addBlurEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Yarıçap negatif olmayan ve puan cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına çıkıp çıkmayacağını kontrol eden Boolean’dır. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0`‑`100` kullanın: `0` tamamen şeffaf, `100` mevcut alfasını korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0`‑`100` yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0`‑`100` yüzde alfa eşiği. Bu değerin altı şeffaf, eşit veya üstü opaktır. |

Sabit alfa modülasyonu için şeffaflık ve opaklık karşılıklıdır. Örneğin, %35 şeffaflık alfa modülasyonu %65 değerine eşittir.

## **Parlaklık ve Kontrast Uygulama**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) bir [BrightnessContrast](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/brightnesscontrast/) işlemi döndürür. İşlem oluşturulurken skaler ayarları sağlanır. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/brightnesscontrast/) yalnızca okunabilen, hesaplanmış değerleri verir; bunlar incelenebilir veya kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü görüntüyü değiştirmeden bir ön izleme oluşturur:

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

[BrightnessContrast](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/brightnesscontrast/) bir Office 2010 resim‑efekti uzantısıdır ve standart DrawingML parlaklık efekti kadar taşınabilir değildir. Parlaklık ve kontrastın PPTX çift yönlü işleminden sonra da düzenlenebilir kalmasını istiyorsanız, [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim sınırlamaları bölümü bu farkı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulama**

Renk efektleri, aynı görüntü kaynağını kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve sırasıyla gri tonlama, duotone, renk tonu, HSL ayarı ve renk değiştirme uygular.

[Duotone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/duotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri eşler. Bu, ayarları tek bir skaler değerden daha karmaşık olan bir efekt örneği olarak yararlıdır.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) her pikselin rengini sabit bir renk ile değiştirirken alfasını korur. Bu, kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini gösteren [addColorChangeEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) metodundan farklıdır.

## **Bulanıklık, Şeffaflık ve Alfa Efektleri Ekleme**

[addBlurEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) tüm renk kanallarını, alfanın da dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına çıkabileceği durumlarda `grow` değerini `true` yapın.

Tekdüze şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) kullanın. Bu, mevcut alfa değerlerini çarpar; böylece kısmı şeffaf pikseller orantılı olarak farklı kalır. [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) ise tüm piksellere aynı alfa değerini atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

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

Parametresiz diğer alfa operasyonları arasında [addAlphaCeilingEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) (her sıfır olmayan alfa %100 opak olur), [addAlphaFloorEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) (her alfa %100’ün altında %0 şeffaf olur) ve [addAlphaInverseEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) (alfa `100% - alpha` olur) yer alır.

## **Sıralı Bir Efekt Zinciri Oluşturma**

Her `add...Effect` metodu işlemi koleksiyonun sonuna ekler. İşleyici bu koleksiyonu sıralı bir boru hattı gibi kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur ve böyle devam eder. Dolayısıyla aynı işlemler farklı bir sırada farklı bir görüntü üretebilir.

Örneğin, gri tonlama ardından renk tonu uygulamak önce kromatik bilgiyi kaldırıp ardından parlaklık sonucunu yeniden renklendirir. Renk tonu ardından gri tonlama eski renk tonunu ortadan kaldırır. Benzer şekilde, alfa değiştirme daha önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılar, alfa modülasyonu ise bu değerlerin göreli farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir kurar, PPTX olarak kaydeder, sunumu yeniden açar, işlem tiplerini ve sırasını kontrol eder ve yeniden açılan sonucu render eder:

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

Koleksiyon, renk, alfa ve bulanıklaştırma işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Kombinasyonlar yapılabilir, ancak her zaman anlamlı olmayabilir. Sabit bir renk değişimi, önceki renk efektlerinin oluşturduğu RGB varyasyonlarını yok eder; duotone’dan sonra gri tonlama iki seçili rengi kaldırır; alfa tavan, taban, değiştirme veya çift‑seviyeli işlemler, daha önce yaratılan alfa detayını silebilir. Zinciri, istenen piksel işleme sırasına göre kurun; öğeleri sırasız biçimleme bayrakları gibi düşünmeyin.

## **Düzenlenebilir ve Etkili Değerleri İnceleme**

Düzenlenebilir bir işlem, [Picture.getImageTransform](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/) içinde depolanan nesnedir. Efekte bağlı olarak doğrudan yazılabilir üyeler sunabilir. Örneğin, [Blur](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/blur/) `radius` ve `grow` değerlerini, [AlphaModulateFixed](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/alphamodulatefixed/) `amount` değerini, [AlphaBiLevel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/alphabilevel/) `threshold` değerini yazılabilir olarak gösterir. [Duotone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/duotone/) gibi renk efektleri, değiştirilebilir [ColorFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/colorformat/) nesnelerini açığa çıkarır.

[BrightnessContrast](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tint/) ve [AlphaReplace](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/alphareplace/) gibi bazı işlemler, oluşturma skalerlerini yazılabilir özellik olarak sunmaz. Bu ayarları değiştirmek için işlemi kaldırıp istenen konumda yeni bir işlem ekleyin.

`getEffective()` tarafından döndürülen etkili veri hesaplanmış ve salt‑okunandır. Tema bağımlı renklerin çözülmesinde ve renderlayıcının kullandığı normalleştirilmiş değerlerin okunmasında faydalıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri enumerate eder ve ilgili API etkili değer sağladığında bu değerleri inceler:

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

Gri tonlama, alfa tavan ve alfa tersine çevirme gibi parametresiz efektlerin de bir etkili‑veri nesnesi vardır, ancak yazdırılacak skaler ayarları yoktur. Koleksiyondaki varlıkları ve konumları önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

Bir işlemi indeksle kaldırmak için [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) kullanın. Kaldırma sonrası indeksler kayar; bu yüzden önce hedefi bulup enumerate ettikten sonra kaldırın. Tüm zinciri kaldırmak için [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) kullanın.

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

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) kaynağını silmez, sıkıştırmaz veya başka bir şekilde etkilemez.

## **Sunum Biçimlerini ve Dışa Aktarım Hedeflerini Düşünme**

Görüntü dönüşümleri DrawingML’den gelir, bu yüzden PPTX etkili zincirler için tercih edilen düzenlenebilir formattır. PPTX olsa bile, her işlem aynı taşınabilirliğe sahip değildir:

- Luminans, gri tonlama, duotone, renk tonu, HSL, bulanıklaştırma ve yaygın alfa işlemleri gibi standart DrawingML işlemleri PPTX çift yönlü işleminde en yüksek koruma şansına sahiptir. Kalıcı olma gereksinimi varsa her zaman oluşturulan dosyayı yeniden açıp koleksiyonu inceleyin.
- [BrightnessContrast](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/brightnesscontrast/) bir Office 2010 uzantısıdır, standart DrawingML luminans işlemi değildir. Bellek içi renderlama için kullanılabilir, ancak PPTX kaydedilip yeniden açıldıktan sonra düzenlenebilir bir [BrightnessContrast] işlemi olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarları için [addLuminanceEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagetransformoperationcollection/) tercih edin.
- İkili PPT biçimi tam DrawingML efekt modelinden önce ortaya çıkmıştır. PPT’ye kaydetmek desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaştırabilir. Karmaşık düzenlenebilir zincirler için PPT’yi doğrulama biçimi olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML gibi görsel çıktılar desteklenen zinciri renderlanmış görünüme uygular. Bu çıktılar bir [ImageTransformOperationCollection] içermez; raster biçimler sonucu piksellere dönüştürür, belge/vektör dışa aktarımları ise kendi render temsillerini saklar.
- Efektler, bağlanan bir görüntünün bağımsız hâle gelmesini sağlamaz. Bağlı bir resim renderlandığında sunum yüklendiğinde bağlantılı kaynağın mevcut olması gerekir.

Farklı sunum tüketicileri, özellikle birkaç alfa veya renk‑kuantizasyon işlemi bir arada kullanıldığında kenar durumlarını farklı yorumlayabilir. Kritik çıktılar için aynı Aspose.Slides sürümüyle hem düzenlenebilir çift yönlü işlemi hem de son dışa aktarım biçimini test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler, resim doldurması tarafından kullanılan [Picture] nesnesine aittir. Altındaki [PPImage] baytları değişmeden kalır.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi etkilerini paylaşır mı?**

Hayır. [PPImage] yeniden kullanmak veri çoğaltmayı önler, ancak her resim çerçevesi genellikle ayrı bir [Picture] ve ayrı bir görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklık ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon bu efektleri tek bir sıralı zincirde kabul eder. Her işlem bir öncekinin çıktısını nasıl etkilediğini dikkate alın; değiştirme ve eşik işlemleri önceki renk veya alfa detayını silebilir.

**Etkili değerler neden sadece okunabilir?**

Etkili veri, renderlama için kullanılan hesaplanmış değerleri ve çözülmüş renkleri temsil eder. Yazılabilir üyeleri olan işlemi koleksiyonda düzenleyin; aksi takdirde işlemi kaldırıp yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT tam DrawingML efekt modelini temsil edemez; render çıktıları ise sadece görünümü saklar, düzenlenebilir dönüşüm işlemlerini içermez.