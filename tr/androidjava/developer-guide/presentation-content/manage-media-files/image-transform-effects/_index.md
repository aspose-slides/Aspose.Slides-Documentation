---
title: Android'de Sunumlarda Görüntü Dönüşüm Efektlerini Yönetme
linktitle: Görüntü Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/androidjava/image-transform-effects/
keywords:
- görüntü dönüşümü
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- ikili ton
- renk tonu
- HSL
- renk değiştirme
- bulanıklık
- şeffaflık
- alfa etkisi
- efekt zinciri
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java üzerinden resim çerçeveleri için görüntü dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını görüntü dönüşüm işlemlerinin sıralı bir koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [ISlidesPicture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidespicture/) öğesiyle başlayın ve [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) öğesine erişin. Döndürülen [IImageTransformOperationCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/) size orijinal görüntü baytlarını yeniden yazmadan, ekleme, sıralama, inceleme, kaldırma ve temizleme işlemlerini yapma imkanı tanır.

Bu makale parlaklık ve kontrast, renk dönüşümleri, bulanıklık, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX yuvarlak dönüş doğrulaması için tam bir iş akışı gösterir.

## **Efekt Sahipliği ve Görüntü Yeniden Kullanımını Anlama**

Bir görüntü kaynağı ve onu gösteren resim farklı nesnelerdir:

- [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) sunum tarafından sahip olunan kaynak görüntü verisini saklar veya referans verir.
- [ISlidesPicture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islidespicture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına başvururken görüntü dönüşüm koleksiyonunu depolar.
- [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) ilgili resim doldurmayı, geometriyi, kırpma ayarlarını ve diğer çerçeve‑düzeyi biçimlendirmeleri içeren slayt şeklidir.

Bu nedenle, görüntü dönüşüm işlemleri [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) içindeki baytları değiştirmez. Aynı `IPPImage` [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metoduna birden fazla kez geçirildiğinde, her yeni resim çerçevesi kendi `ISlidesPicture` ve kendi dönüşüm koleksiyonuna sahiptir. Bir çerçeveye gri tonlama uygulanması, diğer çerçeveleri gri tonlamaz; tüm çerçeveler aynı gömülü görüntü kaynağını kullanıyor olsa bile.

Aynı `ISlidesPicture.getImageTransform` modeli, şekil veya slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıkları ve Birimlerini Kullanma**

Gösterilen metodlar aşağıdaki anlamlı aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü hemen her dışarıdaki değeri reddetmese bile, değerleri bu aralıkta tutun; hedef sunum biçimi kaydetme sırasında ya da PowerPoint dosyayı açarken geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Yok | Sayısal parametre yok. Alfa değiştirilmez. |
| [addDuotoneEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Koyu ve açık pikseller için iki renk. `android.graphics.Color` tarafından kullanılan RGB ve alfa kanal değerleri `0` ile `255` arasındadır. |
| [addTintEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Renk tonu `0` dahil `360` hariç derece cinsinden; miktar `-100` ile `100` arasında, yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Renk tonu `0` dahil `360` hariç derece cinsinden; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Değiştirme rengi kanal değerleri `0` ile `255` arasındadır. Mevcut alfa değerleri değiştirilmez. |
| [addBlurEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Yarıçap sıfırdan büyük ve nokta cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına çıkıp çıkmayacağını kontrol eden bir Boole değeridir. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen saydam, `100` mevcut alfabı korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Bu değerin altındaki pikseller şeffaf, eşit ya da üzerindeki pikseller opaktır. |

Sabit alfa modülasyonu için şeffaflık ve opaklık birbirini tamamlar. Örneğin, %35 şeffaflık alfa modülasyonu %65 değerine eşittir.

## **Parlaklık ve Kontrast Uygulama**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) bir [IBrightnessContrast](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibrightnesscontrast/) işlemi döndürür. Oluşturulurken skaler ayarları sağlanır. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) hesaplanmış yalnızca‑okunur değerleri döndürür; bu değerler incelenebilir veya kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü görüntüyü değiştirmeden bir ön izleme oluşturur:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/brightnesscontrast/) Office 2010 resim‑efekt uzantısıdır ve standart DrawingML parlaklık efektinden daha az taşınabilir. Parlaklık ve kontrastın bir PPTX yuvarlak dönüşten sonra da düzenlenebilir kalması gerekiyorsa, [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim sınırlamaları bölümü bu farkı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulama**

Renk efektleri, aynı görüntü kaynağını yeniden kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve sırasıyla gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirme uygular.

[IDuotone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iduotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri temsil eder. Bu, ayarları tek bir skaler değerden daha karmaşık olan bir efekt örneği olarak faydalıdır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) her pikselin rengini sabit bir renkle değiştirirken alfa kanalını korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [addColorChangeEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) metodundan farklıdır.

## **Bulanıklık, Şeffaflık ve Alfa Efektleri Ekleme**

[addBlurEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) tüm renk kanallarını, alfabı da dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına çıkabileceği durumlarda `grow` parametresini `true` yapın.

Tek tip şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) kullanın. Bu, mevcut her alfa değerini çarparak kısmen şeffaf piksellerin oranını korur. [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) ise tüm piksellere aynı alfa değerini atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Parametresiz diğer alfa işlemleri şunlardır: [addAlphaCeilingEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) – sıfırdan farklı her alfabı tamamen opak yapar; [addAlphaFloorEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) – %100 altında kalan her alfabı tamamen şeffaf yapar; ve [addAlphaInverseEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) – alfabı `100% - alpha` olarak değiştirir.

## **Sıralı Bir Efekt Zinciri Oluşturma**

Her `add...Effect` yöntemi yeni bir işlemi koleksiyonun sonuna ekler. İşleyici koleksiyonu sıralı bir boru hattı olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur ve bu şekilde devam eder. Dolayısıyla aynı işlemler farklı sırayla uygulandığında farklı bir görüntü elde edilebilir.

Örneğin, önce gri tonlama sonra tonlama uygulandığında önce renk bilgisi silinir, ardından parlaklık sonucu yeniden renklendirilir. Tonlama ardından gri tonlama ise tonlamayı tekrar kaldırır. Benzer şekilde, alfa değiştirme önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise göreceli farkları korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem tiplerini hem de sırasını denetler ve yeniden açılan sonucu işler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Koleksiyon, renk, alfa ve bulanıklık işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Birleştirilebilirler, ancak kombinasyonlar her zaman faydalı olmayabilir. Sabit bir renk değiştirme, önceki renk efektleri tarafından üretilen RGB varyasyonunu siler; duotone sonrası gri tonlama iki seçili rengi kaldırır; ve alfa tavan, taban, değiştirme veya iki‑seviye işlemleri, daha önce oluşturulan alfa detaylarını yok edebilir. Zinciri, istenen piksel‑işleme sırasına göre oluşturun; öğeleri sırasız biçim bayrakları gibi düşünmeyin.

## **Düzenlenebilir ve Etkin Değerleri İnceleme**

Düzenlenebilir bir işlem, `ISlidesPicture.getImageTransform` içinde depolanan nesnedir. Efekte bağlı olarak, doğrudan yazılabilir üyeler sunabilir. Örneğin, [IBlur](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iblur/) `radius` ve `grow` değerlerini, [IAlphaModulateFixed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ialphamodulatefixed/) `amount` değerini, [IAlphaBiLevel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ialphabilevel/) `threshold` değerini yazılabilir olarak sunar. [IDuotone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iduotone/) gibi renk efektleri, değiştirilebilir [IColorFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icolorformat/) nesnelerini ortaya çıkarır.

[IBrightnessContrast](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itint/) ve [IAlphaReplace](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ialphareplace/) gibi bazı işlem arabirimleri, oluşturulma skalerlerini yazılabilir özellik olarak sunmaz. Bu ayarları değiştirmek için işlemi kaldırıp, istenen konumda yeni bir işlem ekleyin.

`getEffective()` tarafından döndürülen etkili veri hesaplanmış ve yalnızca‑okunurdur. Tema‑bağımlı renkleri çözümlemek ve işleyicinin kullandığı normalleştirilmiş değerleri okumak için faydalıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri sıralar ve ilgili API’nin sağladığı etkili değerleri inceler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Gri tonlama, alfa tavan ve alfa tersine çevirme gibi parametresiz efektler de bir etkili‑veri nesnesine sahiptir, ancak yazdırılacak skaler ayarları yoktur. Koleksiyondaki varlıkları ve konumları önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

Bir işlemi indeksle kaldırmak için [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) kullanın. Kaldırma sonrası indeksler kayar, bu yüzden önce hedefi arayın, ardından sıralama sırasında kaldırın. Tüm zinciri kaldırmak için [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) kaynağı silinmez, yeniden sıkıştırılmaz veya başka bir şekilde değiştirilmez.

## **Sunum Biçimlerini ve Dışa Aktarım Hedeflerini Düşünün**

Görüntü dönüşümleri DrawingML içinde ortaya çıkar, bu yüzden PPTX, efekt zincirleri için tercih edilen düzenlenebilir formattır. PPTX bile olsa, her işlem aynı taşınabilirliğe sahip değildir:

- Luminans, gri tonlama, duotone, tonlama, HSL, bulanıklık ve ortak alfa işlemleri gibi standart DrawingML işlemleri PPTX yuvarlak dönüşünden sonra da kalma olasılığı en yüksek olandır. Kalıcılık bir gereksinimse, oluşturulan dosyayı her zaman yeniden açın ve koleksiyonu kontrol edin.
- [BrightnessContrast](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/brightnesscontrast/) Office 2010 uzantısıdır, standart DrawingML luminans işlemi değildir. Bellek içi işleme için kullanılabilir, ancak PPTX kaydedilip yeniden açıldıktan sonra düzenlenebilir bir [IBrightnessContrast] olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarları için [addLuminanceEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) tercih edin.
- İkili PPT formatı, tam DrawingML efekt modelinden önce gelir. PPT’ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaşık olarak oluşturabilir. Karmaşık düzenlenebilir bir zincir için PPT’yi doğrulama formatı olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML gibi görsel çıktı formatları, desteklenen zinciri işlenmiş görünüme uygular. Bu çıktılar düzenlenebilir bir `IImageTransformOperationCollection` içermez; raster formatları sonucu piksellere döker, belge/vektör dışa aktarımları kendi işleme temsilini saklar.
- Efektler, bağlantılı bir resmi kendi içinde bağımsız hale getirmez. Bağlantılı bir resmi işlemek, sunum yüklendiğinde bağlantılı kaynağın mevcut olmasına bağlıdır.

Farklı sunum tüketicileri, özellikle birden çok alfa veya renk‑kuantizasyon işlemi birleştirildiğinde, kenar durumlarını farklı yorumlayabilir. Kritik çıktılar için, üretimde kullanılan aynı Aspose.Slides sürümüyle düzenlenebilir yuvarlak dönüşü ve nihai dışa aktarma formatını test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verisini değiştirir mi?**

Hayır. İşlemler, resim doldurması tarafından kullanılan `ISlidesPicture` öğesine aittir. Temel `IPPImage` baytları değişmeden kalır.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi efektlerini paylaşır mı?**

Hayır. `IPPImage` yeniden kullanmak, görüntü verisinin çoğaltılmasını önler, ancak her resim çerçevesi genellikle ayrı bir `ISlidesPicture` ve ayrı bir görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklık ve alpha efektleri birleştirilebilir mi?**

Evet. Koleksiyon, bunları tek bir sıralı zincirde kabul eder. Önceki işlemin çıktısını sonraki işlem ne şekilde etkilediğini göz önünde bulundurun; değiştirme ve eşik işlemleri önceki renk veya alfa detayını yok edebilir.

**Etkin değerler neden yalnızca‑okunur?**

Etkin veri, renderleme için kullanılan hesaplanmış değerleri (çözülmüş renkler dahil) temsil eder. Yazılabilir üye bulunan bir işlem varsa, o işlemi koleksiyonda düzenleyin; aksi takdirde işlemi kaldırıp yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT, tam DrawingML efekt modelini temsil edemez; renderleme dışa aktarma formatları ise yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini içermez.