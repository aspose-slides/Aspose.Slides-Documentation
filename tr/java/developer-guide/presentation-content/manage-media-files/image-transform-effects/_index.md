---
title: Java ile Sunumlarda Görüntü Dönüşüm Efektlerini Yönetme
linktitle: Görüntü Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/java/image-transform-effects/
keywords:
- görüntü dönüşüm
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- çift ton
- ton
- HSL
- renk değiştirme
- bulanıklaştırma
- şeffaflık
- alfa efekti
- efekt zinciri
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile resim çerçevelerinde görüntü dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlarını görüntü dönüşüm işlemlerinin sıralı bir koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) ile başlayın ve [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--) öğesine erişin. Döndürülen [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) efektleri eklemenize, enumerate etmenize, incelemenize, kaldırmanıza ve temizlemenize olanak tanır; orijinal görüntü baytlarını yeniden yazmadan.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklaştırma, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX turu doğrulaması için tam bir iş akışını gösterir.

## **Etkilerin Sahipliğini ve Görüntü Yeniden Kullanımını Anlayın**

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) sunumun sahip olduğu kaynak görüntü verilerini depolar veya referans gösterir.  
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına başvururken görüntü dönüşüm koleksiyonunu da saklar.  
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) ilgili resim doldurmayı, geometriyi, kırpma ayarlarını ve diğer çerçeve‑seviyesindeki biçimlendirmeyi sahiplenir.

Bu nedenle, görüntü dönüşüm işlemleri [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) içindeki baytları değiştirmez. Aynı `IPPImage` [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metoduna birden fazla kez geçirilirse, her yeni resim çerçevesi kendi `ISlidesPicture` ve kendi dönüşüm koleksiyonuna sahip olur. Bir çerçeveye gri tonlaması uygulamak diğer çerçeveleri gri yapmaz; tüm çerçeveler aynı gömülü görüntü kaynağını yeniden kullansa da.

Aynı `ISlidesPicture.getImageTransform` modeli diğer resim doldurmalar, örneğin şekil ya da slayt arka planı tarafından da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanmaktadır.

## **Geçerli Parametre Aralıklarını ve Birimlerini Kullanın**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü out‑of‑range değerleri hemen reddetmese bile bu aralıklarda kalın; hedef sunum formatı kaydetme sırasında ya da PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Yok | Sayısal parametre yok. Alfa değişmez. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | İki renk koyu ve açık pikseller için. `java.awt.Color` içindeki RGB ve alfa kanalları `0` ile `255` arasında kullanılır. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Ton `0` dahil ile `360` hariç derece cinsinden; miktar `-100` ile `100` arasında, yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Ton `0` dahil ile `360` hariç derece; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Yedek renk, kanal değerlerini `0` ile `255` arasında kullanır. Mevcut alfa değerleri değişmez. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Yarıçap negatif olmayan ve puan cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına uzanıp uzanmayacağını belirleyen Boolean bir değerdir. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen şeffaftır ve `100` mevcut alfa değerini korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Bu değerin altındaki değerler şeffaf, eşit veya üstündeki değerler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık birbirini tamamlar. Örneğin, %35 şeffaflık %65 alfa modülasyonu miktarına karşılık gelir.

## **Parlaklık ve Kontrast Uygulama**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) bir [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) işlemi döndürür. İşlem oluşturulurken skaler ayarlar sağlanır. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) hesaplanmış yalnızca‑okunur değerleri döndürür; bu değerler incelenebilir veya kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü görüntüyü değiştirmeden bir ön izleme oluşturur:

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) Office 2010 resim‑efekt uzantısıdır ve standart DrawingML parlaklık efektinden daha az taşınabilirdir. Parlaklık ve kontrastın PPTX turu sonrasında da düzenlenebilir kalması gerektiğinde [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim kısıtlamaları bölümü bu ayrımı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulama**

Renk efektleri, aynı görüntü kaynağını kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, duotone, ton, HSL ayarı ve renk değiştirme uygular.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu piksellere, `color2` ise açık piksellere eşlenir. Bu, ayarları tek bir skaler değerden daha karmaşık bir efekt örneği yapar.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) her pikselin rengini sabit bir renkle değiştirirken alfa değerini korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) ile farklıdır.

### **Parlaklık Eşiği Uygulama**

Parlaklık eşiği, taranmış bir sayfada hafif izlerin arka plandan daha kolay ayırt edilmesini sağlar. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) ara tonlamaları korur. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) parlaklığı siyah veya beyaza eşler, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) ise opaklığa bir eşik uygular.

Parlaklık eşiği %0 ile %100 arasında, dahil olmak üzere değişir. Eşiğin altındaki pikseller siyah olur. Eşiğe eşit ya da üzerindeki pikseller beyaz olur. Eşiği yükseltmek daha fazla tonu siyah yapar çünkü daha çok ton kesme noktasının altına düşer.

[grayscale-swatches.png](grayscale-swatches.png) dosyasını çalışma dizinine indirin. Her etiket, 0‑255 ölçeğindeki orijinal gri seviyesini gösterir. Örnek, orijinali iki kopyanın yanına yerleştirir ve her kopyanın eşik değerini sunuma kaydeder.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Çıktı sunumunu PowerPoint’te açıp üç çerçeveyi karşılaştırın. 96 etiketi, yaklaşık %38 parlaklığa (255 içinde 96) sahiptir. %20 eşiğinde beyaza, %60 eşiğinde ise siyaha dönüşür.

![Orijinal gri örnekler, 20% ve 60% parlaklık eşiklerinde siyah‑beyaz sonuçların yanında](luminance-threshold.png)

## **Bulanıklaştırma, Şeffaflık ve Alfa Efektleri Ekleme**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) tüm renk kanallarını, alfab dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına uzanabileceği durumlarda `grow` değerini `true` olarak ayarlayın.

Tekdüzen şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) kullanın. Bu, mevcut her alfa değerini çarpar; böylece kısmen şeffaf pikseller oranlı olarak farklı kalır. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) ise tüm piksellere tek bir alfa değeri atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) alfabı bir eşik temelinde iki seviyeye dönüştürür.

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

Diğer parametresiz alfa işlemleri şunlardır: [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) – sıfırdan farklı tüm alfabı tam opak yapar; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) – %100 altındaki tüm alfabı tamamen şeffaf yapar; ve [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) – alfabı `100% - alpha` olarak değiştirir.

## **Sıralı Bir Etki Zinciri Oluşturma**

Her `add...Effect` metodu, yeni bir işlemi koleksiyonun sonuna ekler. Renderlayıcı koleksiyonu sıralı bir işlem hattı olarak kullanır: işlem 0 çıktısı işlem 1 girdisi olur, böyle devam eder. Dolayısıyla aynı işlemler farklı bir sırada sıralandığında farklı bir görüntü elde edilebilir.

Örneğin, gri tonlama ardından ton uygulanması önce renk bilgisini kaldırır, ardından parlaklık sonucunu yeniden renklendirir. Ton ardından gri tonlama tonlamayı tekrar ortadan kaldırır. Benzer şekilde, alfa değiştirme önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise bunların göreceli farklarını korur.

Aşağıdaki örnek dört işlemlik bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, işlem türlerini ve sırasını kontrol eder ve yeniden açılan sonucu renderlar:

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

Koleksiyon, renk, alfa ve bulanıklaştırma işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Birleştirilebilirler, ancak birleşimler her zaman yararlı olmayabilir. Sabit renk değiştirme, önceki renk efektleriyle üretilen RGB çeşitliliğini ortadan kaldırır; duotone sonrası gri tonlama iki seçili rengi siler; ve alfa tavan, taban, değiştirme ya da iki‑seviyeli işlemler, önceki adımlarda oluşturulan alfa detayını silebilir. Zinciri, istenen piksel‑işleme sırasına göre oluşturun; öğeleri sırasız biçimlendirme bayrakları gibi düşünmeyin.

<!-- visual-explanation:image-transform-effects:start -->
[![Aynı görüntü önce griye, sonra tonlamaya, ve tonlama ardından griye geçerek geçer. İki son gri görüntü farklı tonlara sahiptir.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Bu gösterimsel Aspose.Slides for .NET 26.11 render'ında, %25 tonlamalı 220° ton, gri görüntüyü değiştirmez. Aynı tonlamayı griye önce uygularsanız farklı tonlar elde edersiniz.*  
<!-- visual-explanation:image-transform-effects:end -->

## **Düzenlenebilir ve Etkili Değerleri İnceleme**

Düzenlenebilir bir işlem, `ISlidesPicture.getImageTransform` içinde saklanan nesnedir. Etkiye bağlı olarak, yazılabilir üyeler doğrudan ortaya çıkabilir. Örneğin, [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) yazılabilir `radius` ve `grow` değerlerini ortaya çıkarır, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) yazılabilir `amount` değerini, [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) ise yazılabilir `threshold` değerini ortaya çıkarır. [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) gibi renk efektleri, değiştirilebilir [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) nesnelerini ortaya çıkarır.

Bazı işlem arabirimleri, [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/) ve [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/) gibi, oluşturma skalerlerini yazılabilir özellikler olarak ortaya koymaz. Bu ayarları değiştirmek için işlemi kaldırıp istenen konumda yeni bir işlem ekleyin.

`getEffective()` tarafından döndürülen etkili veri hesaplanmış ve yalnızca‑okunurdur. Tema‑bağımlı renkleri çözümlemek ve renderlayıcının kullandığı normalleştirilmiş değerleri okumak için yararlıdır; ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri enumerate eder ve ilgili API etkili değerleri sunduğu yerlerde bunları inceler:

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

Grayscale, alfa tavan ve alfa tersine gibi parametresiz efektlerin hâlâ bir etkili‑veri nesnesi vardır, ancak yazdırılacak skaler ayar yoktur. Bulunmaları ve koleksiyondaki konumları önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

Bir işlemi indekse göre kaldırmak için [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) kullanın. Kaldırmadan sonra indeksler kayar; bu yüzden önce hedefi arayın ve enumerate ettikten sonra kaldırın. Tüm zinciri kaldırmak için [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) kullanın.

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

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde etkilemez.

## **Sunum Formatlarını ve Dışa Aktarım Hedeflerini Düşünme**

Görüntü dönüşümleri DrawingML’de oluşur; bu yüzden PPTX efekt zincirleri için tercih edilen düzenlenebilir formattır. PPTX ile bile, her işlem aynı taşınabilirliğe sahip değildir:

- Luminance, grayscale, duotone, tint, HSL, blur ve yaygın alfa işlemleri gibi standart DrawingML işlemleri, bir PPTX turu sonrasında hayatta kalma ihtimali en yüksek olanlardır. Koruma bir gereklilikse, oluşturulan dosyayı her zaman yeniden açıp koleksiyonu inceleyin.  
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) standart DrawingML luminance işlemi yerine Office 2010 uzantısıdır. Bellek‑içi render için kullanılabilir, ancak kaydedilip PPTX yeniden açıldığında düzenlenebilir bir [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarları için [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) tercih edin.  
- İkili PPT formatı tam DrawingML efekt modelinden önce gelmiştir. PPT’ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt küme ile sınırlayabilir veya görünümü tahmini olarak oluşturabilir. Karmaşık düzenlenebilir bir zincir için PPT’yi doğrulama formatı olarak kullanmayın.  
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılara renderlamak, desteklenen zinciri renderlanmış görünüme uygular. Bu çıktılar düzenlenebilir `IImageTransformOperationCollection` içermez; raster formatlar sonucu piksellere döker, belge/vektör dışa aktarımları kendi render temsillerini saklar.  
- Efektler, bağlı bir görüntüyü kendi içinde paketlemez. Bağlı bir resmi renderlamak, sunum yüklendiğinde bağlı kaynağın erişilebilir olmasına bağlıdır.

Farklı sunum tüketicileri kenar durumlarını farklı renderlayabilir, özellikle birden fazla alfa veya renk‑kuantizasyon işlemi birleştirildiğinde. Kritik çıktılar için, aynı Aspose.Slides sürümüyle üretimde kullanılan, düzenlenebilir turu ve nihai dışa aktarma formatını birlikte test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler, resim doldurması tarafından kullanılan `ISlidesPicture`’a aittir. Alttaki `IPPImage` baytları değişmeden kalır.

**Aynı resmi yeniden kullanan iki resim çerçevesi efektlerini paylaşır mı?**

Hayır. `IPPImage` yeniden kullanmak, görüntü verisinin çoğaltılmasını önler, ancak her resim çerçevesi normalde ayrı bir `ISlidesPicture` ve görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklaştırma ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon, bunları tek bir sıralı zincirde kabul eder. Her bir işlemin önceki çıktıya ne yaptığını dikkate alın; değiştirme ve eşik işlemleri önceki renk ya da alfa detayını ortadan kaldırabilir.

**Etkili değerler neden yalnızca okunabilir?**

Etkili veri, render için kullanılan, renklerin çözümlendiği hesaplanmış değerleri temsil eder. Yazılabilir üyeleri olan işlemi, dönüşüm koleksiyonunda düzenleyin; aksi takdirde onu kaldırıp yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT, tam DrawingML efekt modelini temsil edemez; renderlenen dışa aktarma formatları ise sadece görünümü korur, düzenlenebilir dönüşüm işlemlerini içermez.