---
title: Sunumlarda Java ile Görüntü Dönüştürme Efektlerini Yönetin
linktitle: Görüntü Dönüştürme Efektleri
type: docs
weight: 11
url: /tr/java/image-transform-effects/
keywords:
- görüntü dönüştürme
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- çift ton
- renk tonu
- HSL
- renk değiştirme
- bulanıklaştırma
- şeffaflık
- alfa efekti
- etki zinciri
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile resim çerçevelerinde görüntü dönüştürme efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını görüntü dönüştürme işlemlerinin sıralı bir koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [ISlidesPicture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidespicture/) ile başlayın ve [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidespicture/#getImageTransform--) zaman erişin. Döndürülen [IImageTransformOperationCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/) ekleme, yineleme, inceleme, kaldırma ve etkileri temizleme imkanı sağlar; orijinal resim baytlarını yeniden yazmaz.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklaştırma, şeffaflık, sıralı etki zincirleri, etkili değerler, kaldırma ve PPTX çift yönlü doğrulama için tam bir iş akışını gösterir.

## **Etki Sahipliğini ve Görüntü Yeniden Kullanımını Anlayın**

Bir görüntü kaynağı ve onu görüntüleyen resim farklı nesnelerdir:

- [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) sunumun sahip olduğu kaynak resim verilerini saklar veya referans verir.
- [ISlidesPicture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidespicture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına başvurur, aynı zamanda görüntü dönüştürme koleksiyonunu saklar.
- [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) ilgili resim doldurmayı, geometrileri, kırpma ayarlarını ve diğer çerçeve düzeyindeki biçimlendirmeleri sahip olan slayt şeklidir.

Bu nedenle, görüntü dönüştürme işlemleri [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) baytlarını değiştirmez. Aynı `IPPImage` birden fazla kez [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yöntemine geçirildiğinde, her yeni resim çerçevesi kendi `ISlidesPicture` ve kendi dönüştürme koleksiyonunu alır. Bir çerçeveye gri tonlama uygulamak diğer çerçeveleri gri tonlamaz; tüm çerçeveler aynı gömülü görüntü kaynağını kullanır ancak her biri ayrı bir `ISlidesPicture` nesnesine sahiptir.

Aynı `ISlidesPicture.getImageTransform` modeli, şekil veya slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanmaktadır.

## **Geçerli Parametre Aralıklarını ve Birimleri Kullanın**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü hemen her geçersiz değeri reddetmese bile bu aralıkta kalın; hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Yok | Sayısal parametre yoktur. Alfa değişmez. |
| [addDuotoneEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Koyu ve açık pikseller için iki renk. `java.awt.Color` içinde RGB ve alfa kanalları `0`‑`255` aralığındadır. |
| [addTintEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Ton `0` dahil, `360` hariç derece cinsinden; miktar `-100` ile `100` arasında, yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Ton `0` dahil, `360` hariç derece; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Yerine konulan renk, kanal değerleri `0`‑`255` aralığındadır. Mevcut alfa değerleri değişmez. |
| [addBlurEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Yarıçap negatif olamaz ve puan cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına çıkıp çıkmayacağını kontrol eden Boolean’dır. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeği için `0`‑`100` kullanın: `0` tamamen şeffaf, `100` mevcut alfabeyi korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0`‑`100` arasında, yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0`‑`100` arasında, yüzde alfa eşik değeri. Bu değerin altı şeffaf, eşik ve üzeri opaktır. |

Sabit alfa modülasyonu için şeffaflık ve opaklık tamamlayıcıdır. Örneğin, %35 şeffaflık %65 alfa modülasyon miktarına karşılık gelir.

## **Parlaklık ve Kontrast Uygula**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) bir [IBrightnessContrast](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibrightnesscontrast/) işlemi döndürür. İşlem oluşturulurken skaler ayarları sağlanır. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) hesaplanmış yalnızca‑okunur değerleri verir; bu değerler incelenebilir veya kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü resmi değiştirmeden bir önizleme oluşturur:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/tr/java/com.aspose.slides/brightnesscontrast/) bir Office 2010 resim‑etki uzantısıdır ve standart DrawingML parlaklık etkisine göre daha az taşınabilirdir. Parlaklık ve kontrastın PPTX çift yönlü işleminden sonra düzenlenebilir kalması gerekiyorsa, [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim sınırlamaları bölümü bu ayrımı ayrıntılı olarak açıklar.

## **Renk Dönüşümlerini Uygula**

Renk etkileri, aynı görüntü kaynağını kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirme uygular.

[IDuotone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iduotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri eşler. Bu, ayarları tek bir skaler değerden daha karmaşık bir etki örneği olduğundan yararlıdır.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) her pikselin rengini sabit bir renk ile değiştirir, alfabayı korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [addColorChangeEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) yönteminden farklıdır.

## **Bulanıklaştırma, Şeffaflık ve Alfa Etkileri Ekle**

[addBlurEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) tüm renk kanallarını, alfabı da dahil, etkiler. Bulanık kenarın orijinal resim sınırlarını aşabileceği durumlarda `grow` değerini `true` yapın.

Tek tip şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) kullanın. Mevcut her alfa değerini çarpar, böylece kısmen şeffaf pikseller orantılı olarak farklı kalır. [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) ise tüm piksellere tek bir alfa değeri atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Parametresiz diğer alfa işlemleri şunlardır: [addAlphaCeilingEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) tüm sıfır olmayan alfabı tamamen opak yapar; [addAlphaFloorEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) %100 altında kalan alfabı tamamen şeffaf yapar; ve [addAlphaInverseEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) alfabı `100% - alfa` olarak değiştirir.

## **Sıralı Bir Etki Zinciri Oluştur**

Her `add...Effect` yöntemi yeni bir işlemi koleksiyonun sonuna ekler. Çizer, koleksiyonu sıralı bir boru hattı olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur, vs. Dolayısıyla aynı işlemler farklı bir sırada farklı bir görüntü üretebilir.

Örneğin, önce gri tonlama ardından tonlama uygulamak önce renk bilgisini kaldırır, sonra parlaklık sonucunu yeniden renklendirir. Tonlama ardından gri tonlama ise tonlamayı tekrar ortadan kaldırır. Benzer şekilde, alfa değiştirme daha önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise bu değerlerin göreli farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir kurar, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem türlerini hem de sırasını kontrol eder ve yeniden açılan sonucu oluşturur:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

Koleksiyon, renk, alfa ve bulanıklaştırma işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Birlikte kullanılabilirler, ancak kombinasyonlar her zaman yararlı değildir. Sabit bir renk değiştirme, önceki renk etkileriyle üretilen RGB varyasyonlarını kaldırır; duotoneden sonra gelen gri tonlama iki seçili rengi ortadan kaldırır; ve alfa tavan, taban, değiştirme veya iki‑seviye işlemleri önceki alfa detayını yok edebilir. Zinciri, istenen piksel‑işleme sırasına göre oluşturun; öğeleri sırasız biçim bayrakları gibi düşünmeyin.

## **Düzenlenebilir ve Etkili Değerleri İncele**

Düzenlenebilir bir işlem, `ISlidesPicture.getImageTransform` içinde depolanan nesnedir. Etkiye bağlı olarak, doğrudan yazılabilir üyeler sergileyebilir. Örneğin, [IBlur](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iblur/) yazılabilir `radius` ve `grow` değerlerini, [IAlphaModulateFixed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ialphamodulatefixed/) yazılabilir `amount` değerini, ve [IAlphaBiLevel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ialphabilevel/) yazılabilir `threshold` değerini ortaya koyar. [IDuotone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iduotone/) gibi renk etkileri, değiştirilebilir [IColorFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icolorformat/) nesnelerini açığa çıkarır.

[IBrightnessContrast](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itint/) ve [IAlphaReplace](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ialphareplace/) gibi bazı işlem arayüzleri, oluşturma skalerlerini yazılabilir özellikler olarak sunmaz. Bu ayarları değiştirmek için işlemi kaldırıp istenen konumda yeni bir işlem ekleyin.

`getEffective()` tarafından döndürülen etkili veri hesaplanmış ve yalnızca‑okunurdur. Tema‑bağımlı renkleri çözmek ve çizerin kullandığı normalleştirilmiş değerleri okumak için kullanışlıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri yineleyerek, ilgili API’nin sağladığı etkili değerleri inceler:

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

Gri tonlama, alfa tavan ve alfa tersine çevirme gibi parametresiz etkiler de bir etkili‑veri nesnesine sahiptir, ancak yazdırılacak skaler ayar yoktur. Koleksiyondaki varlıkları ve konumları önemli bilgidir.

## **Görüntü Dönüştürmelerini Kaldır veya Temizle**

Bir işlemi indeksle kaldırmak için [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) kullanın. Kaldırma işleminden sonra indeksler kayar; bu yüzden önce hedefi bulun, ardından yinelemeden sonra kaldırın. Tüm zinciri kaldırmak için [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imagetransformoperationcollection/#clear--) kullanın.

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

Dönüştürmeleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) kaynağı silinmez, yeniden sıkıştırılmaz veya başka bir şekilde değiştirilmez.

## **Sunum Biçimlerini ve Dışa Aktarım Hedeflerini Göz Önünde Bulundurun**

Görüntü dönüştürmeleri DrawingML’de ortaya çıkar, bu yüzden PPTX etkili zincirler için tercih edilen düzenlenebilir formattır. PPTX içinde bile, her işlem aynı taşınabilirliğe sahip değildir:

- Luminans, gri tonlama, duotone, tonlama, HSL, bulanıklaştırma ve yaygın alfa işlemleri gibi standart DrawingML işlemleri, PPTX çift yönlü işleminde hayatta kalma ihtimali en yüksek olandır. Korumak bir gereklilikse, oluşturulan dosyayı her zaman yeniden açın ve koleksiyonu inceleyin.
- [BrightnessContrast](https://reference.aspose.com/slides/tr/java/com.aspose.slides/brightnesscontrast/) bir Office 2010 uzantısıdır, standart DrawingML luminans işlemi değildir. Bellek içi oluşturma için kullanılabilir, ancak PPTX kaydedilip yeniden açıldıktan sonra düzenlenebilir bir [IBrightnessContrast] olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarları için [addLuminanceEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) tercih edin.
- Eski PPT biçimi, tam DrawingML etki modelinden önce gelir. PPT’ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt küme ile sınırlayabilir veya görünümü yaklaşık olarak oluşturabilir. Karmaşık düzenlenebilir zincirler için PPT’yi doğrulama biçimi olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılar, desteklenen zinciri işlenmiş görünüme uygular. Bu çıktılar, düzenlenebilir bir `IImageTransformOperationCollection` içermez; raster biçimler sonucu piksellere dönüştürür, belge/vektör dışa aktarımları ise kendi işleme temsilini saklar.
- Etkiler, bağlı bir görüntüyü kendi içinde bütünleştirilebilir hâle getirmez. Bağlı bir resmi işlerken, sunum yüklendiğinde bağlı kaynak mevcut olmalıdır.

Farklı sunum tüketicileri, özellikle birkaç alfa veya renk‑kuantizasyon işlemi birleştirildiğinde kenar durumlarını farklı işleyebilir. Kritik çıktılar için aynı Aspose.Slides sürümüyle düzenlenebilir çift yönlü ve nihai dışa aktarım biçimini test edin.

## **SSS**

**Görüntü dönüştürme etkileri gömülü resim verilerini değiştirir mi?**  
Hayır. İşlemler, resim doldurmayı kullanan `ISlidesPicture` nesnesine aittir. Altındaki `IPPImage` baytları değişmez.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi etkilerini paylaşır mı?**  
Hayır. `IPPImage` yeniden kullanımı, görüntü verisinin çoğaltılmasını önler; ancak her resim çerçevesi normalde ayrı bir `ISlidesPicture` ve görüntü dönüştürme koleksiyonu taşır.

**Renk, bulanıklaştırma ve alfa etkileri birleştirilebilir mi?**  
Evet. Koleksiyon, tek bir sıralı zincirde bunları kabul eder. Her işlem önceki işlem çıktısını etkilediğinden, değiştirme ve eşik işlemleri daha önceki renk veya alfa detayını silebilir; bu yüzden sıralamayı dikkatle planlayın.

**Neden etkili değerler yalnızca‑okunur?**  
Etkili veri, render için kullanılan hesaplanmış değerleri (çözülmüş renkler dahil) temsil eder. Yazılabilir üyeleri olan bir işlem varsa, o nesneyi düzenleyin; aksi takdirde işlemi kaldırıp yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Hangi format bir dönüşüm zincirini korumalı?**  
PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT tam DrawingML etki modelini temsil edemez; render dışa aktarma biçimleri yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini değil.