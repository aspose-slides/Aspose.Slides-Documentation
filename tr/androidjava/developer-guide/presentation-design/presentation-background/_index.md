---
title: Android'de Sunum Arka Planlarını Yönet
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/androidjava/presentation-background/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java üzerinden kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planların nasıl ayarlanacağını öğrenin, sunumlarınızı güçlendirecek kod ipuçlarıyla."
---
## **Giriş**

Katı renkler, degradeler ve görüntüler slayt arka planları için yaygın olarak kullanılır. Arka planı **normal slayt** (tek bir slayt) veya **ana slayt** (birden fazla slayta aynı anda uygulanır) için ayarlayabilirsiniz.

![PowerPoint background](powerpoint-background.png)

## **Normal Slayt için Katı Renkli Arka Plan Ayarla**

Aspose.Slides, bir sunumdaki belirli bir slayt için arka planı katı bir renk olarak ayarlamanıza olanak tanır—sunum bir ana slayt kullansa bile. Değişiklik yalnızca seçilen slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı örneği oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) üzerindeki [getSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) metodunu kullanarak katı arka plan rengini belirtin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Java örneği, normal bir slayt için mavi katı rengini arka plan olarak nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation sınıfının bir örneğini oluştur.
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

## **Ana Slayt için Katı Renkli Arka Plan Ayarla**

Aspose.Slides, bir sunumdaki ana slaytın arka planını katı bir renk olarak ayarlamanıza olanak tanır. Ana slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi görür; bu nedenle ana slaytın arka planı için katı bir renk seçtiğinizde, bu renk her slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı örneği oluşturun.
2. Ana slaytın [BackgroundType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/backgroundtype/) (`getMasters` aracılığıyla) özelliğini `OwnBackground` olarak ayarlayın.
3. Ana slayt arka planının [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. Katı arka plan rengini belirtmek için [getSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) metodunu kullanın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Java örneği, ana slayt için katı bir renk (yeşil) arka planını nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Master slaytının arka plan rengini yeşile ayarla.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Sunumu diske kaydet.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Slayt için Degrade Arka Plan Ayarla**

Degrade, renklerin kademeli değişimiyle oluşturulan bir grafik etkisidir. Slayt arka planı olarak kullanıldığında, degrade sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytların arka planı olarak bir degrade renk ayarlamanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı örneği oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) üzerindeki [getGradientFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) metodunu kullanarak tercih ettiğiniz degrade ayarlarını yapılandırın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Java örneği, bir slayt için degrade rengini arka plan olarak nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Arka plana bir degrade etkisi uygula.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Degrade renklerini ekle. Degrade durakları olmadan, arka plan varsayılan siyah-beyaz geçişe döner.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Sunumu diske kaydet.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Slaytı Arka Plan Görüntüsü Olarak Ayarla**

Katı ve degrade doldurmalara ek olarak, Aspose.Slides slayt arka planı olarak görüntüleri kullanmanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı örneği oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) üzerindeki [getPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) metodunu kullanarak görüntüyü arka plan olarak atayın.
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Java örneği, bir slayt için arka plan olarak bir görüntünün nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;

// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Arka plan görüntüsü özelliklerini ayarla.
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

Aşağıdaki kod örneği, arka plan doldurma türünü döşeli bir resim olarak ayarlamayı ve döşeme özelliklerini değiştirmeyi gösterir:

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

    // Arka plan doldurması için kullanılan görüntüyü ayarla.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Resim doldurma modunu Döşeme olarak ayarla ve döşeme özelliklerini ayarla.
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
Daha fazla bilgi için: [**Döşeli Resmi Doku Olarak Kullan**](/slides/tr/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştir**

Slaytın içeriğinin öne çıkması için slayt arka plan görüntüsünün şeffaflığını ayarlamak isteyebilirsiniz. Aşağıdaki Java kodu, slayt arka plan görüntüsünün şeffaflığını nasıl değiştireceğinizi gösterir:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Örneğin.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Resim dönüşüm işlemlerinin koleksiyonunu al.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Mevcut sabit yüzde şeffaflık etkisini bul.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Yeni şeffaflık değerini ayarla.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt Arka Plan Değerini Al**

Aspose.Slides, bir slaytın etkin arka plan değerlerini almak için [IBackgroundEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibackgroundeffectivedata/) arayüzünü sağlar. Bu arayüz, etkin [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) ve [EffectFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) öğelerini ortaya çıkarır.

[BaseSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslide/) sınıfının `getBackground` metodunu kullanarak bir slaytın etkin arka planını elde edebilirsiniz.

Aşağıdaki Java örneği, bir slaytın etkin arka plan değerini nasıl alacağınızı gösterir:

```java
import com.aspose.slides.*;

// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Retrieve the effective background, taking into account master, layout, and theme.
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

Evet. Slaytın özel doldurmasını kaldırın; böylece arka plan, ilgili [yerleşim](/slides/tr/androidjava/slide-layout/)/[ana](/slides/tr/androidjava/slide-master/) slaytından (yani [tema arka planı](/slides/tr/androidjava/presentation-theme/)) yeniden devralınır.

### Sunum temasını daha sonra değiştirirsem arka plan ne olur?

Bir slaytın kendi doldurması varsa, bu değişmeden kalır. Arka plan [yerleşim](/slides/tr/androidjava/slide-layout/)/[ana](/slides/tr/androidjava/slide-master/) üzerinden devralındıysa, [yeni tema](/slides/tr/androidjava/presentation-theme/) ile eşleşecek şekilde güncellenir.