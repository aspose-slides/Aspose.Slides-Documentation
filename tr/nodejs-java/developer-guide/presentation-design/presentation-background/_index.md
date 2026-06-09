---
title: JavaScript'te Sunum Arka Planlarını Yönetme
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/nodejs-java/presentation-background/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planları nasıl ayarlayacağınızı öğrenin, sunumlarınızı geliştirecek kod ipuçlarıyla."
---
## **Giriş**

Katı renkler, degrade'ler ve görüntüler slayt arka planları için yaygın olarak kullanılır. **normal slayt** (tek bir slayt) veya **master slayt** (birden çok slayta aynı anda uygulanır) için arka planı ayarlayabilirsiniz.

![PowerPoint arka planı](powerpoint-background.png)

## **Normal Slayt için Katı Renkli Arka Plan Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için katı renkli arka plan ayarlamanıza olanak tanır—sunum bir master slayt kullansa bile. Değişiklik yalnızca seçili slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/) üzerindeki [getSolidFillColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) yöntemini kullanarak katı arka plan rengini belirtin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki JavaScript örneği, normal bir slayt için mavi katı rengi arka plan olarak nasıl ayarlayacağınızı gösterir:

```js
// Presentation sınıfının bir örneğini oluştur.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Slaytın arka plan rengini mavi olarak ayarla.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Sunumu diske kaydet.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Master Slayt için Katı Renkli Arka Plan Ayarlama**

Aspose.Slides, bir sunumdaki master slayt için katı renkli arka plan ayarlamanıza olanak tanır. Master slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi görür; bu nedenle master slaytın arka planı için katı renk seçtiğinizde, bu renk her slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Master slaytın [BackgroundType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/backgroundtype/) (`getMasters` aracılığıyla) özelliğini `OwnBackground` olarak ayarlayın.
3. Master slayt arka planının [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
4. [getSolidFillColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) yöntemini kullanarak katı arka plan rengini belirtin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki JavaScript örneği, master slayt için katı renk (yeşil) arka planını nasıl ayarlayacağınızı gösterir:

```js
// Presentation sınıfının bir örneğini oluştur.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Master slaytının arka plan rengini Orman Yeşili olarak ayarla.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Sunumu diske kaydet.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt için Degrade Arka Plan Ayarlama**

Degrade, rengin kademeli değişimiyle oluşturulan bir grafik etkidir. Slayt arka planı olarak kullanıldığında, degrade sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytlar için degrade renkli arka plan ayarlamanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/) üzerindeki [getGradientFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/#getGradientFormat) yöntemini kullanarak tercih ettiğiniz degrade ayarlarını yapılandırın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki JavaScript örneği, bir slayt için degrade rengi arka plan olarak nasıl ayarlayacağınızı gösterir:

```js
// Presentation sınıfının bir örneğini oluştur.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Arka plana bir degrade efekti uygula.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Sunumu diske kaydet.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slayt Arka Planı Olarak Görüntü Ayarlama**

Katı ve degrade dolgu seçeneklerine ek olarak, Aspose.Slides slayt arka planı olarak görüntü kullanmanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/backgroundtype/) özelliğini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/) üzerindeki [getPictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) yöntemini kullanarak görüntüyü arka plan olarak atayın.
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki JavaScript örneği, bir slayt için görüntüyü arka plan olarak nasıl ayarlayacağınızı gösterir:

```js
// Presentation sınıfının bir örneğini oluştur.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Arka plan görüntüsü özelliklerini ayarla.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Görüntüyü yükle.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Görüntüyü sunumun görüntü koleksiyonuna ekle.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Sunumu diske kaydet.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki kod örneği, arka plan dolgu türünü döşenen bir resim olarak ayarlamayı ve döşeme özelliklerini değiştirmeyi gösterir:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Arka plan dolgu için kullanılan görüntüyü ayarla.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Resim dolgu modunu Döşeme olarak ayarla ve döşeme özelliklerini ayarla.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Daha fazla bilgi için: [**Döşeme Resmi Doku Olarak**](/slides/tr/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştirme**

Slaytın arka plan görüntüsünün şeffaflığını ayarlamak isteyebilirsiniz, böylece slayt içeriği öne çıkar. Aşağıdaki JavaScript kodu, bir slayt arka plan görüntüsünün şeffaflığını nasıl değiştireceğinizi gösterir:

```js
var transparencyValue = 30; // Örneğin.

// Resim dönüşüm işlemlerinin koleksiyonunu al.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Sabit yüzde şeffaflık etkisini bul.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Yeni şeffaflık değerini ayarla.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Slayt Arka Plan Değerini Alma**

Aspose.Slides, bir slaytın etkili arka plan değerlerini almanız için `BackgroundEffectiveData` sınıfını sağlar. Bu sınıf, etkili [FillFormat] ve [EffectFormat] öğelerini sunar.

[BaseSlide] sınıfının `getBackground` yöntemiyle, bir slaytın etkili arka planını elde edebilirsiniz.

Aşağıdaki JavaScript örneği, bir slaytın etkili arka plan değerini nasıl alacağınızı gösterir:

```js
// Presentation sınıfının bir örneğini oluştur.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Master, düzen ve temayı göz önünde bulundurarak etkili arka planı al.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **SSS**

**Özel bir arka planı sıfırlayıp tema/düzen arka planını geri yükleyebilir miyim?**

Evet. Slaytın özel dolgusunu kaldırın; arka plan, ilgili [layout](/slides/tr/nodejs-java/slide-layout/)/[master](/slides/tr/nodejs-java/slide-master/) slaytından (yani [tema arka planı](/slides/tr/nodejs-java/presentation-theme/)) tekrar devralınacaktır.

**Sunumun temasını daha sonra değiştirirsem arka plana ne olur?**

Bir slaytın kendi dolgu ayarı varsa, bu değişmeden kalır. Arka plan [layout](/slides/tr/nodejs-java/slide-layout/)/[master](/slides/tr/nodejs-java/slide-master/) üzerinden devralındıysa, [yeni tema](/slides/tr/nodejs-java/presentation-theme/) ile eşleşecek şekilde güncellenir.