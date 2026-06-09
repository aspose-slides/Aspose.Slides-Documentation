---
title: Android'de Sunum Arka Planlarını Yönetme
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/androidjava/presentation-background/
keywords:
- sunum arka planı
- slayt arka planı
- katı renk
- gradyan renk
- görsel arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planları nasıl ayarlayacağınızı, sunumlarınızı güçlendirecek kod ipuçlarıyla öğrenin."
---
## **Giriş**

Katı renkler, geçişler ve görüntüler genellikle slayt arka planları için kullanılır. Arka planı **normal bir slayt** (tek bir slayt) veya **ana slayt** (birden fazla slayta aynı anda uygulanır) için ayarlayabilirsiniz.

![PowerPoint background](powerpoint-background.png)

## **Normal Slayt için Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için katı bir rengi arka plan olarak ayarlamanıza olanak tanır—sunum bir ana slayt kullansa bile. Değişiklik yalnızca seçilen slayta uygulanır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) üzerindeki [getSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) yöntemini kullanarak katı arka plan rengini belirleyin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Java örneği, normal bir slayt için mavi katı renk nasıl ayarlanacağını gösterir:

```java
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

## **Ana Slayt için Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki ana slayt için katı bir rengi arka plan olarak ayarlamanıza olanak tanır. Ana slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablondur; bu nedenle ana slaytın arka planına katı bir renk seçtiğinizde bu renk her slayta uygulanır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Ana slaytın [BackgroundType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/backgroundtype/) değerini (`getMasters` aracılığıyla) `OwnBackground` olarak ayarlayın.
3. Ana slayt arka planının [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
4. [getSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) yöntemini kullanarak katı arka plan rengini belirleyin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Java örneği, ana slayt için katı bir renk (yeşil) nasıl ayarlanacağını gösterir:

```java
// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ana slaytın arka plan rengini Orman Yeşili olarak ayarla.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Sunumu diske kaydet.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt için Gradyan Arka Planı Ayarlama**

Gradyan, renklerin yavaş yavaş değişmesiyle oluşturulan bir grafik etkisidir. Slayt arka planı olarak kullanıldığında, sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytların arka planı olarak bir gradyan rengi ayarlamanıza olanak tanır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) değerini `Gradient` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) üzerindeki [getGradientFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) yöntemini kullanarak tercih edilen gradyan ayarlarını yapılandırın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Java örneği, bir slayt için gradyan renk nasıl ayarlanacağını gösterir:

```java
// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Arka plana bir gradyan efekti uygula.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Sunumu diske kaydet.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt Arka Planı Olarak Görüntü Ayarlama**

Katı ve gradyan doldurmaların yanı sıra, Aspose.Slides slayt arka planı olarak görüntü kullanmanıza da olanak tanır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) değerini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) üzerindeki [getPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) yöntemini kullanarak görüntüyü arka plan olarak atayın.
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Java örneği, bir slayt için arka plan olarak bir görüntü nasıl ayarlanacağını gösterir:

```java
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

```java
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

    // Resim doldurma modunu Tile olarak ayarla ve karo özelliklerini ayarla.
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

{{% alert color="primary" %}}
Daha fazla okuyun: [**Tile Picture As Texture**](/slides/tr/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştirme**

Slaytın arka plan görüntüsünün şeffaflığını ayarlamak, slayt içeriğinin öne çıkmasını sağlayabilir. Aşağıdaki Java kodu, bir slayt arka plan görüntüsünün şeffaflığını nasıl değiştireceğinizi gösterir:

```java
int transparencyValue = 30; // Örneğin.

// Resim dönüşüm işlemlerinin koleksiyonunu al.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Mevcut bir sabit yüzde şeffaflık etkisini bul.
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
```

## **Slayt Arka Plan Değerini Alın**

Aspose.Slides, bir slaytın etkili arka plan değerlerini almak için [IBackgroundEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibackgroundeffectivedata/) arayüzünü sağlar. Bu arayüz, etkili [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) ve [EffectFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) öğelerini ortaya çıkarır.

[BaseSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslide/) sınıfının `getBackground` yöntemini kullanarak bir slaytın etkili arka planını elde edebilirsiniz.

Aşağıdaki Java örneği, bir slaytın etkili arka plan değerini nasıl alacağınızı gösterir:

```java
// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ana slayt, yerleşim ve temayı göz önünde bulundurarak etkili arka planı al.
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

**Özel bir arka planı sıfırlayıp tema/layout arka planını geri yükleyebilir miyim?**

Evet. Slaytın özel doldurmasını kaldırın; arka plan, ilgili [layout](/slides/tr/androidjava/slide-layout/)/[master](/slides/tr/androidjava/slide-master/) slaytından (yani [tema arka planı](/slides/tr/androidjava/presentation-theme/)) yeniden devralınacaktır.

**Sunumun temasını daha sonra değiştirirsem arka plan ne olur?**

Slaytın kendi doldurması varsa, bu değişmeden kalır. Arka plan, [layout](/slides/tr/androidjava/slide-layout/)/[master](/slides/tr/androidjava/slide-master/) üzerinden devralındıysa, yeni tema ile eşleşecek şekilde güncellenir.