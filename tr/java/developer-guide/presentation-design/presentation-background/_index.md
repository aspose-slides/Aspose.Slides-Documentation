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
- geçişli renk
- görüntü arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planları nasıl ayarlayacağınızı öğrenin, sunumlarınızı güçlendirecek kod ipuçlarıyla."
---
## **Giriş**

Katı renkler, geçişler ve görüntüler genellikle slayt arka planları için kullanılır. Arka planı **normal slayt** (tek bir slayt) veya **ana slayt** (birden fazla slayta aynı anda uygulanır) için ayarlayabilirsiniz.

![PowerPoint arka planı](powerpoint-background.png)

## **Normal Slayt için Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için arka planı katı bir renk olarak ayarlamanıza olanak tanır—sunum bir ana slayt kullansa bile. Değişiklik yalnızca seçilen slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) üzerindeki [getSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/#getSolidFillColor--) metodunu kullanarak katı arka plan rengini belirleyin.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki Java örneği, normal bir slayt için mavi katı renk nasıl ayarlanacağını gösterir:

```java
// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Slaytın arka plan rengini mavi olarak ayarla.
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

Aspose.Slides, bir sunumdaki ana slayt için arka planı katı bir renk olarak ayarlamanıza olanak tanır. Ana slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi görür; bu nedenle ana slaytın arka planı için katı bir renk seçtiğinizde bu renk her slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Ana slaytın [BackgroundType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/backgroundtype/) ( `getMasters` aracılığıyla) özelliğini `OwnBackground` olarak ayarlayın.
3. Ana slayt arka planının [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. Katı arka plan rengini belirlemek için [getSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/#getSolidFillColor--) metodunu kullanın.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki Java örneği, ana slayt için arka planı katı bir renk (yeşil) olarak nasıl ayarlayacağını gösterir:

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

## **Slayt için Geçişli Arka Plan Ayarlama**

Geçişli, renklerin yavaş yavaş değiştiği bir grafik etkisidir. Slayt arka planı olarak kullanıldığında geçişler, sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytlar için arka plan olarak bir geçişli renk ayarlamanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) üzerindeki [getGradientFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/#getGradientFormat--) metodunu kullanarak istediğiniz geçişli ayarlarını yapılandırın.
5. Değiştirilen sunumu kaydedin.

Aşağıdaki Java örneği, bir slayt için geçişli renk nasıl ayarlanacağını gösterir:

```java
// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Arka plana bir geçiş efekti uygula.
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

Katı ve geçişli doldurmaların yanı sıra Aspose.Slides, slayt arka planı olarak görüntü kullanmanıza da olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun görsel koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) üzerindeki [getPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/#getPictureFillFormat--) metodunu kullanarak görüntüyü arka plan olarak atayın.
7. Değiştirilen sunumu kaydedin.

Aşağıdaki Java örneği, bir slayt için arka plan olarak bir görüntünün nasıl ayarlanacağını gösterir:

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

{{% alert color="primary" %}}
Daha fazla bilgi: [**Döşeme Resmi Doku Olarak**](/slides/tr/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştirme**

Slaytın arka plan görüntüsünün şeffaflığını ayarlamak isteyebilirsiniz; bu sayede slayt içeriği daha öne çıkar. Aşağıdaki Java kodu, bir slayt arka planı görüntüsünün şeffaflığının nasıl değiştirileceğini gösterir:

```java
int transparencyValue = 30; // Örneğin.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Slayt Arka Plan Değerini Almak**

Aspose.Slides, bir slaytın etkili arka plan değerlerini almak için [IBackgroundEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibackgroundeffectivedata/) arabirimini sunar. Bu arabirim, etkili [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) ve [EffectFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) özelliklerini ortaya çıkarır.

[BaseSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslide/) sınıfının `getBackground` metodunu kullanarak bir slaytın etkili arka planını elde edebilirsiniz.

Aşağıdaki Java örneği, bir slaytın etkili arka plan değerinin nasıl alınacağını gösterir:

```java
// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ana slayt, yerleşim ve temayı dikkate alarak etkili arka planı al.
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

**Özel bir arka planı sıfırlayıp tema/yerleşim arka planını geri yükleyebilir miyim?**

Evet. Slaytın özel doldurmasını kaldırın; arka plan, ilgili [yerleşim](/slides/tr/java/slide-layout/)/[ana](/slides/tr/java/slide-master/) slaydından (yani [tema arka planı](/slides/tr/java/presentation-theme/)) tekrar devralınacaktır.

**Sunumun temasını daha sonra değiştirirsem arka plan ne olur?**

Eğer bir slaytın kendi doldurması varsa değişmez. Arka plan [yerleşim](/slides/tr/java/slide-layout/)/[ana](/slides/tr/java/slide-master/) slaydından devralındıysa, yeni tema ile eşleşecek şekilde güncellenir.