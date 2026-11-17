---
title: Android'de Sunumlarda Görüntü Dönüşüm Efektlerini Yönet
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
- tonlama
- HSL
- renk değiştirme
- bulanıklık
- şeffaflık
- alfa efekti
- efekt zinciri
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java kullanarak resim çerçeveleri için görüntü dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını sıralı bir görüntü dönüşüm işlemleri koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) ile başlayın ve [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) metoduna erişin. Döndürülen [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) size orijinal resim baytlarını yeniden yazmadan ekleme, yineleme, inceleme, kaldırma ve temizleme efektleri yapma imkanı verir.

Bu makale parlaklık ve kontrast, renk dönüşümleri, bulanıklık, şeffaflık, sıralı efekt zincirleri, etkin değerler, kaldırma ve PPTX turu doğrulaması için eksiksiz bir iş akışı gösterir.

## **Efekt Sahipliğini ve Görüntü Yeniden Kullanımını Anlayın**

Bir görüntü kaynağı ve onu gösteren resim farklı nesnelerdir:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) sunumun sahip olduğu kaynak görüntü verilerini depolar veya referans alır.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına başvururken görüntü dönüşüm koleksiyonunu saklar.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) ilgili resim doldurmayı, geometriyi, kırpma ayarlarını ve diğer çerçeve‑seviyesi biçimlendirmeleri barındıran slayt şeklidir.

Bu nedenle, görüntü dönüşüm işlemleri [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) içinde bulunan baytları değiştirmez. Aynı `IPPImage` birden fazla kez [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metoduna aktarılırsa, her yeni resim çerçevesi kendi `ISlidesPicture` ve kendi dönüşüm koleksiyonuna sahip olur. Bir çerçeveye gri tonlama (grayscale) uygulanması diğer çerçeveleri gri tonlamaz, çünkü hepsi aynı gömülü görüntü kaynağını yeniden kullanıyor olsa da her çerçeve ayrı bir `ISlidesPicture` kullanır.

Aynı `ISlidesPicture.getImageTransform` modeli ayrıca şekil veya slayt arka planı gibi diğer resim doldurmalar tarafından da kullanılabilir. Aşağıdaki örnekler resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıklarını ve Birimleri Kullanın**

Gösterilen metodlar aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü hemen her dış‑aralık değerini reddetmese bile bu aralıklar içinde kalın; hedef sunum biçimi kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Yok | Sayısal parametre yoktur. Alfa değişmez. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Koyu ve açık pikseller için iki renk. `android.graphics.Color` tarafından kullanılan RGB ve alfa kanal değerleri `0` ile `255` arasındadır. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Ton (`hue`) `0` dahil ile `360` hariç derece cinsinden; miktar (`amount`) `-100` ile `100` arasında, yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Ton `0` dahil ile `360` hariç derece; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Değiştirme rengi kanallarını `0` ile `255` arasında alır. Mevcut alfa değerleri değişmez. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Yarıçap negatif olamaz ve puan cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına çıkıp çıkmayacağını kontrol eden Boolean değerdir. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen şeffaftır ve `100` mevcut alfanı korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Bu değerin altındakiler şeffaf, eşit veya üzerindekiler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık birbirinin tamamlayıcısıdır. Örneğin, %35 şeffaflık %65 alfa modülasyonu miktarına karşılık gelir.

## **Parlaklık ve Kontrast Uygula**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) bir [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) işlemi döndürür. Ölçekli ayarları işlem oluşturulurken sağlanır. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) hesaplanmış yalnızca‑okunur değerleri verir; bunlar incelenebilir veya kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü resmi değiştirmeden bir ön izleme oluşturur:

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

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) bir Office 2010 resim‑efekt uzantısıdır ve standart DrawingML parlaklık efektinden daha az taşınabilirdir. Parlaklık ve kontrast, PPTX turu sonrası da düzenlenebilir kalmalıysa, [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim sınırlamaları bölümü bu ayrımı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygula**

Renk efektleri, aynı görüntü kaynağını yeniden kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirme uygular.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri eşler. Bu, ayarları tek bir ölçek değerinden daha karmaşık olan bir etkinin yararlı bir örneğidir.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) her pikselin rengini sabit bir renkle değiştirirken alfa kanalını korur. Bu, kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk formatlarını ortaya çıkaran [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) metodundan farklıdır.

### **Luminans Eşiği Uygula**

Bir luminans eşiği, taranmış bir sayfadaki hafif işaretlerin arka plandan ayırt edilmesini kolaylaştırabilir. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) ara gri tonları korur. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) luminansı siyah ya da beyaza eşler, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) ise opaklığa bir eşik uygular.

Luminans eşiği %0 ile %100 arasında, iki uç dahil olmak üzere değişir. Eşiğin altındaki pikseller siyah, eşikte ya da üzerindeki pikseller beyaz olur. Eşiği yükseltmek daha fazla tonu siyaha dönüştürür, çünkü daha fazla piksel kesim altına düşer.

[grayscale-swatches.png](grayscale-swatches.png) dosyasını çalışma dizinine indirin. Her etiket, 0‑255 ölçeğindeki orijinal gri seviyeyi gösterir. Örnek, orijinali iki kopyanın yanına yerleştirir ve her kopyanın eşik değerini sunuma kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Çıktı sunumunu PowerPoint’te açıp üç çerçeveyi karşılaştırın. 96‑lık etiket, yaklaşık %38 luminansa sahiptir (96/255). %20 eşiğinde beyaza, %60 eşiğinde siyaha dönüşür.

![Orijinal gri tonlu örnekler, %20 ve %60 luminans eşiklerinde siyah‑beyaz sonuçların yanında](luminance-threshold.png)

*Bu görsel Aspose.Slides for .NET 26.11 örneğinde, %25 şiddetinde 220° tonlama gri tonlama görüntüsünü değiştirmez. Aynı tonlama gri tonlamadan önce uygulandığında tonlar farklı olur.*

## **Bulanıklık, Şeffaflık ve Alfa Efektleri Ekle**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) tüm renk kanallarını, alfa dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına çıkabileceği durumlarda `grow` değerini `true` olarak ayarlayın.

Tek tip şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) kullanın. Bu, mevcut alfa değerlerini çarparak kısmen şeffaf piksellerin orantısal farklılıklarını korur. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) tüm piksellere tek bir alfa değeri atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) ise alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

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

Diğer parametresiz alfa işlemleri şunlardır: [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) tüm sıfır olmayan alfalara %100 opaklık verir; [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) %100’nin altındaki tüm alfalara %0 şeffaflık verir; ve [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) alfabı `100% - alfa` olarak değiştirir.

## **Sıralı Bir Etki Zinciri Oluştur**

Her `add...Effect` metodu yeni bir işlemi koleksiyonun sonuna ekler. Renderlayıcı koleksiyonu sıralı bir veri yolu olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur ve böyle devam eder. Dolayısıyla aynı işlemler farklı bir sırada uygulandığında farklı bir görüntü elde edilebilir.

Örneğin, gri tonlama ardından tonlama önce renk bilgisini siler, ardından parlaklık sonucunu yeniden renklendirir. Tonlama ardından gri tonlama ise tonlamayı tekrar kaldırır. Benzer şekilde, alfa değiştirme daha önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, oysa alfa modülasyonu göreceli farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem tiplerini hem de sırasını kontrol eder ve yeniden açılan sonucu renderlar:

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

Koleksiyon, renk, alfa ve bulanıklık işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Birlikte kullanılabilirler, ama kombinasyonlar her zaman faydalı olmayabilir. Sabit renk değiştirme, önceki renk efektleriyle oluşturulan RGB varyasyonunu kaldırır; duotoneden sonra gri tonlama iki seçili rengi kaldırır; alfa tavan, taban, değiştirme veya iki‑seviyeli işlemler, önceki adımlarda oluşturulan alfa detayını silebilir. Zinciri, istenen piksel‑işleme sırasına göre oluşturun; öğelerini rasgele biçimleme işaretleri gibi düşünmeyin.


<!-- visual-explanation:image-transform-effects:start -->
[![Aynı görüntü önce gri tonlamadan sonra tonlamadan, ardından tonlamadan sonra gri tonlamadan geçer. İki son gri tonlama görüntüsü farklı tonlardadır.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Bu illüstratif Aspose.Slides for .NET 26.11 render’ında, %25 şiddetinde 220° tonlama gri tonlama görüntüsünü değiştirmez. Aynı tonlama gri tonlamadan önce uygulandığında tonlar farklı olur.*
<!-- visual-explanation:image-transform-effects:end -->

## **Düzenlenebilir ve Etkin Değerleri İncele**

Düzenlenebilir bir işlem, `ISlidesPicture.getImageTransform` içinde depolanan nesnedir. Etkiye bağlı olarak, yazılabilir üyeler doğrudan ortaya çıkarılabilir. Örneğin, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) `radius` ve `grow` değerlerini, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) `amount` değerini, [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) `threshold` değerini yazılabilir olarak sunar. [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) gibi renk efektleri ise değiştirilebilir [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) nesnelerini ortaya çıkarır.

[IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/) ve [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/) gibi bazı işlem arabirimleri, oluşturma ölçeklerini yazılabilir özellikler olarak göstermez. Bu ayarları değiştirmek için işlemi kaldırıp istenen konumda yeni bir işlem ekleyin.

`getEffective()` tarafından döndürülen etkin veri hesaplanmış ve yalnızca‑okunurdur. Tema‑bağımlı renkleri çözümlemek ve renderlayıcının kullandığı normalleştirilmiş değerleri okumak için yararlıdır, ancak düzenleme için ayrı bir yüzey değildir. Aşağıdaki örnek zinciri yineleyerek ilgili API’nin sağladığı yerlerde etkin değerleri inceler:

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

Parametresiz efektler (gri tonlama, alfa tavan, alfa tersine çevirme gibi) bir etkin‑veri nesnesine sahiptir, ancak yazdırılacak ölçekli ayarları yoktur. Bulunma ve koleksiyondaki konumları önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldır veya Temizle**

Bir işlemi indeksle kaldırmak için [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) kullanın. İndeksler kaldırma sonrası kaydığından, önce hedefi bulun ve yinelemeden sonra kaldırın. Tüm zinciri kaldırmak için [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) metodunu kullanın.

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

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde değiştirmez.

## **Sunum Biçimlerini ve Dışa Aktarım Hedeflerini Düşünün**

Görüntü dönüşümleri DrawingML içinde ortaya çıkar, bu yüzden PPTX etki zincirleri için tercih edilen düzenlenebilir formattır. PPTX içinde bile, her işlem aynı taşınabilirliğe sahip değildir:

- Luminans, gri tonlama, duotone, tonlama, HSL, bulanıklık ve ortak alfa işlemleri gibi standart DrawingML işlemleri PPTX turunda en yüksek hayatta kalma şansına sahiptir. Oluşturulan dosyayı her zaman yeniden açın ve koleksiyonu kontrol edin; koruma bir gereksinimse bu şarttır.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) bir Office 2010 uzantısıdır; standart DrawingML luminans işlemi değildir. Bellek içi render için kullanılabilir, fakat kaydedilip PPTX yeniden açıldıktan sonra düzenlenebilir bir [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) olarak kalması garanti edilmez. Kalıcı parlaklık ve kontrast ayarları için [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) tercih edilmelidir.
- Binary PPT formatı tam DrawingML efekt modelinden önce gelir. PPT’ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaşık olarak taklit edebilir. Karmaşık düzenlenebilir zincirler için doğrulama formatı olarak PPT kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılara renderlamak, desteklenen zinciri render edilen görünüme uygular. Bu çıktılar düzenlenebilir bir `IImageTransformOperationCollection` içermez; raster formatlar sonucu piksel olarak düzleştirir, belge/vektör dışa aktarımları kendi render temsillerini saklar.
- Efektler bağlantılı bir resmi kendine yeten hâle getirmez. Bağlantılı bir resim renderlanırken, sunum yüklendiğinde bağlanan kaynağın mevcut olması gerekir.

Farklı sunum tüketicileri, özellikle birden fazla alfa veya renk‑kuantalama işlemi birleştirildiğinde, kenar durumlarını farklı yorumlayabilir. Kritik çıktılar için aynı Aspose.Slides sürümünü üretimde kullandığınızda, hem düzenlenebilir turu hem de son dışa aktarma formatını test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler resim doldurması tarafından kullanılan `ISlidesPicture` içinde yer alır. Altındaki `IPPImage` baytları değişmeden kalır.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi efektleri paylaşır mı?**

Hayır. `IPPImage` yeniden kullanmak veri çoğaltmayı önler, ancak her resim çerçevesi genellikle ayrı bir `ISlidesPicture` ve ayrı bir görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklık ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon tek bir sıralı zincirde bunları kabul eder. Her bir işlemin bir öncekinin çıktısına ne yaptığını düşünün; değiştirme ve eşik işlemleri önceki renk ya da alfa detayını atabilir.

**Etkin değerler neden yalnızca‑okunur?**

Etkin veri, render için kullanılan hesaplanmış değerleri (çözülmüş renkler dahil) temsil eder. Yazılabilir üyeleri olan işlemi koleksiyonda düzenleyin; aksi takdirde işlemi kaldırıp yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT tam DrawingML efekt modelini temsil edemez; render dışa aktarma formatları yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini değil.