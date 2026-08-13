---
title: Java'da Sunum Arka Planlarını Yönetme
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/java/presentation-background/
keywords:
- sunum arka planı
- slayt arka planı
- katı renk
- degrade renk
- görüntü arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planları nasıl ayarlayacağınızı, sunumlarınızı güçlendirecek kod ipuçlarıyla öğrenin."
---
## **Giriş**

Katı renkler, degradeler ve görüntüler slayt arka planları için yaygın olarak kullanılır. Arka planı **normal bir slayt** (tek bir slayt) veya **ana slayt** (birden fazla slayta aynı anda uygulanır) için ayarlayabilirsiniz.

![PowerPoint arka planı](powerpoint-background.png)

## **Normal Bir Slayt için Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için katı bir rengi arka plan olarak ayarlamanıza izin verir—sunum bir ana slayt kullansa bile. Değişiklik yalnızca seçilen slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
4. Katı arka plan rengini belirtmek için [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) üzerindeki [getSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/#getSolidFillColor--) yöntemini kullanın.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki Java örneği, normal bir slayt için mavi katı renk nasıl ayarlanır gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Slaytın arka plan rengini maviye ayarla.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Sunumu diske kaydet.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ana Slayt için Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki ana slayt için katı bir rengi arka plan olarak ayarlamanıza izin verir. Ana slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon olarak çalışır; bu yüzden ana slaytın arka planı için katı bir renk seçtiğinizde, bu her slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Ana slaytın [BackgroundType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/backgroundtype/) (`getMasters` aracılığıyla) değerini `OwnBackground` olarak ayarlayın.
3. Ana slayt arka planının [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
4. Katı arka plan rengini belirtmek için [getSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/#getSolidFillColor--) yöntemini kullanın.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki Java örneği, ana slayt için yeşil katı renk nasıl ayarlanır gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ana slaytın arka plan rengini yeşile ayarla.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Sunumu diske kaydet.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt İçin Degrade Arka Planı Ayarlama**

Degrade, rengin kademeli değişimiyle oluşturulan bir grafik etkidir. Slayt arka planı olarak kullanıldığında, degradeler sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytlar için arka plan olarak bir degrade renk ayarlamanıza imkan tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değerini `Gradient` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) üzerindeki [getGradientFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/#getGradientFormat--) yöntemini kullanarak tercih ettiğiniz degrade ayarlarını yapılandırın.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki Java örneği, slayt için degrade renk nasıl ayarlanır gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Arka plana bir degrade efekti uygulayın.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Degrade renklerini ekleyin. Degrade durakları olmadan, arka plan varsayılan siyah-beyaz geçişe geri döner.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Sunumu diske kaydedin.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt Arka Planı Olarak Görüntü Ayarlama**

Katı ve degrade doldurmaların yanı sıra, Aspose.Slides slayt arka planı olarak görüntü kullanmanıza da olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değerini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) üzerindeki [getPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/#getPictureFillFormat--) yöntemini kullanarak görüntüyü arka plan olarak atayın.
7. Değiştirilen sunumu kaydedin.

Aşağıdaki Java örneği, bir slayt için arka plan olarak görüntü nasıl ayarlanır gösterir:

```java
import com.aspose.slides.*;

// Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Arka plan görüntüsü özelliklerini ayarlayın.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Görüntüyü yükle.
    IImage image = Images.fromFile("Tulips.jpg");
    // Görüntüyü sunumun görüntü koleksiyonuna ekle.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Sunumu diske kaydet.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki kod örneği, arka plan dolgu tipini döşeme resmi olarak ayarlamayı ve döşeme özelliklerini değiştirmeyi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Arka plan doldurması için kullanılan resmi ayarlayın.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Resim doldurma kipini Döşeme olarak ayarlayın ve döşeme özelliklerini ayarlayın.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Daha fazla bilgi edinin: [**Döşeme Resmi Doku Olarak**](/slides/tr/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştirme**

Slaytın arka plan görüntüsünün şeffaflığını ayarlamak isteyebilirsiniz; bu sayede slayt içeriği öne çıkar. Aşağıdaki Java kodu, slayt arka plan görüntüsünün şeffaflığını nasıl değiştireceğinizi gösterir:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Örneğin.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Resim dönüştürme işlemlerinin koleksiyonunu alın.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Mevcut sabit yüzde şeffaflık etkisini bulun.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Yeni şeffaflık değerini ayarlayın.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt Arka Planı Değerini Alın**

Aspose.Slides, bir slaytın etkin arka plan değerlerini almak için [IBackgroundEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibackgroundeffectivedata/) arayüzünü sağlar. Bu arayüz, etkin [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) ve [EffectFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) öğelerini ortaya çıkarır.

[BaseSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslide/) sınıfının `getBackground` metodunu kullanarak bir slaytın etkin arka planını elde edebilirsiniz.

Aşağıdaki Java örneği, bir slaytın etkin arka plan değerinin nasıl alınacağını gösterir:

```java
import com.aspose.slides.*;

// Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ana, düzen ve temayı dikkate alarak etkili arka planı alın.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **SSS**

### Özel bir arka planı sıfırlayıp tema/yerleşim arka planını geri yükleyebilir miyim?

Evet. Slaytın özel doldurulmasını kaldırın; arka plan, ilgili [yerleşim](/slides/tr/java/slide-layout/)/[ana slayt](/slides/tr/java/slide-master/) slaytından (yani [tema arka planı](/slides/tr/java/presentation-theme/) ) yeniden miras alınır.

### Sunumun temasını daha sonra değiştirirsem arka plan ne olur?

Bir slaytın kendi doldurulması varsa, değişmeden kalır. Arka plan [yerleşim](/slides/tr/java/slide-layout/)/[ana slayt](/slides/tr/java/slide-master/) üzerinden miras alınmışsa, [yeni tema](/slides/tr/java/presentation-theme/) ile eşleşecek şekilde güncellenir.