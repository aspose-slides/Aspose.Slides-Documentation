---
title: Android'de PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/androidjava/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- kesişme stili biçimlendirme
- dereceli dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- düz renk dolgu
- şekil saydamlığı
- şekli döndürme
- 3B koni efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırlama
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Android'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenarlarını düzenleyerek veya onlara efektler uygulayarak biçimlendirebilirsiniz. Ayrıca şekillerin içini dolduran ayarları belirterek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java, PowerPoint'te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arayüzler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özelleştirilmiş bir çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü gösterir:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi kalınlığını belirleyin.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini belirleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod bir dikdörtgen `AutoShape`'ı nasıl biçimlendireceğinizi gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin doldurma rengini ayarlayın.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Dikdörtgenin çizgilerine biçimlendirme uygulayın.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Dikdörtgenin çizgi rengini ayarlayın.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX dosyasını diske kaydedin.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The formatted lines in the presentation](formatted-lines.png)

## **Kesişme Stili Biçimlendirme**

Üç kesişme tipi seçeneği vardır:

* Round
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Round** ayarını kullanır. Ancak, keskin açılara sahip bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![The join style in the presentation](join-style-powerpoint.png)

Aşağıdaki Java kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round kesişme tipi ayarlarıyla nasıl oluşturulduğunu gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde üç otomatik şekil ekleyin.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Her dikdörtgen şeklinin doldurma rengini ayarlayın.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Çizgi kalınlığını ayarlayın.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Her dikdörtgenin çizgi rengini ayarlayın.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Kesişme stilini ayarlayın.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Her dikdörtgene metin ekleyin.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX dosyasını diske kaydedin.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dereceli Dolgu**

PowerPoint'te Dereceli Dolgu, bir şekle sürekli bir renk karışımı uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, bir rengin yavaşça diğerine geçmesini sağlayarak iki veya daha fazla rengi uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle dereceli dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [IGradientFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igradientformat/) arayüzünün sunduğu gradient durak koleksiyonunun `add` metodlarını kullanarak istediğiniz iki rengi ve konumlarını ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu bir elips üzerine dereceli dolgu etkisi nasıl uygulanacağını gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipse degrade biçimlendirme uygulayın.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Degrenin yönünü ayarlayın.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // İki degrade durağı ekleyin.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The ellipse with gradient fill](gradient-fill.png)

## **Desen Dolgu**

PowerPoint'te Desen Dolgu, bir şekle iki renkten oluşan bir tasarım (nokta, çizgi, çapraz çizgi veya kare gibi) uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini isteğe göre seçebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla önceden tanımlı desen stili sunar. Önceden tanımlı bir deseni seçtikten sonra, hâlâ kullanılacak kesin renkleri belirtebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Önceden tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/patternformat/#getBackColor--) rengini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/patternformat/#getForeColor--) rengini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu bir dikdörtgene desen dolgu nasıl uygulanacağını gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma tipini Pattern olarak ayarlayın.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Desen stilini ayarlayın.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Desenin arka plan ve ön plan renklerini ayarlayın.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // PPTX dosyasını diske kaydedin.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The rectangle with pattern fill](pattern-fill.png)

## **Resim Dolgu**

PowerPoint'te Resim Dolgu, bir şeklin içine bir görüntü eklemenizi sağlayan bir biçimlendirme seçeneğidir; yani görüntüyü şeklin arka planı olarak kullanırsınız.

Aspose.Slides kullanarak bir şekle resim dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim dolgu modunu `Tile` (veya tercih ettiğiniz başka bir modu) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.setImage` metoduna aktarın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki resim "lotus.png" dosyasını göstermektedir:

![The lotus picture](lotus.png)

Aşağıdaki Java kodu bir şekle resim dolgu nasıl uygulanacağını gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Doldurma tipini Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Resim doldurma modunu ayarlayın.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Bir görüntü yükleyin ve sunum kaynaklarına ekleyin.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Resmi ayarlayın.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX dosyasını diske kaydedin.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The shape with picture fill](picture-fill.png)

### **Doku Olarak Döşeme Resmi**

Döşeli resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) arayüzünün ve [PictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturefillformat/) sınıfının aşağıdaki yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Resim dolgu modunu `Tile` ya da `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Döşemelerin şekil içinde hizalanmasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Döşemenin yatay ofsetini (nokta cinsinden) şeklin kökeninden ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Döşemenin dikey ofsetini (nokta cinsinden) şeklin kökeninden ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşeli bir resim dolguya sahip bir dikdörtgen şekli eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin doldurma tipini Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Görseli yükleyin ve sunum kaynaklarına ekleyin.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Görseli şekle atayın.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Resim doldurma modunu ve döşeme özelliklerini yapılandırın.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // PPTX dosyasını diske kaydedin.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The tile options](tile-options.png)

## **Düz Renk Dolgu**

PowerPoint'te Düz Renk Dolgu, bir şekli tek bir, tekdüze renk ile dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, hiçbir degrade, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk dolgu uygulamak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. İstediğiniz dolgu rengini şekle atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu bir PowerPoint slaydındaki bir dikdörtgene düz renk dolgu nasıl uygulanacağını gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma tipini Solid olarak ayarlayın.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Doldurma rengini ayarlayın.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX dosyasını diske kaydedin.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The shape with solid color fill](solid-color-fill.png)

## **Saydamlığı Ayarlama**

PowerPoint'te bir şekle düz renk, degrade, resim veya doku dolgu uyguladığınızda, dolgunun opaklığını kontrol etmek için bir saydamlık seviyesi de ayarlayabilirsiniz. Daha yüksek bir saydamlık değeri, şeklin daha geçişken olmasını sağlar; arka plan ya da alt nesneler kısmen görünür hâle gelir.

Aspose.Slides, dolgu için kullanılan renkteki alfa değerini ayarlayarak saydamlık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` kullanarak saydamlığı olan bir renk tanımlayın (alfa bileşeni saydamlığı kontrol eder).
1. Sunumu kaydedin.

Aşağıdaki Java kodu bir dikdörtgene saydam bir dolgu rengi nasıl uygulanacağını gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Katı bir dikdörtgen otomatik şekil ekleyin.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekleyin.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // PPTX dosyasını diske kaydedin.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The transparent shape](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarına göre konumlandırmak için yararlı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu bir şekli 5 derece döndürmeyi gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndür.
    shape.setRotation(5);

    // PPTX dosyasını diske kaydedin.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The shape rotation](shape-rotation.png)

## **3B Koni Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3B koni efektleri uygulamanıza olanak tanır.

Bir şekle 3B koni efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) özelliğini koni ayarlarını tanımlayacak şekilde yapılandırın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu bir şekle 3B koni efektleri nasıl uygulanacağını gösterir:

```java
// Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Slayta bir şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Şeklin ThreeDFormat özelliklerini ayarlayın.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The 3D bevel effect](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza olanak tanır.

Bir şekle 3B döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. 3B döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icamera/#setCameraType-int-) ve [setLightType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) yöntemlerini kullanın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu bir şekle 3B döndürme efektleri nasıl uygulanacağını gösterir:

```java
// Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The 3D rotation effect](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürmeyi göstermektedir:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Yerleşimde bir yer tutucu bulunan slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Sadece çok az bir etkisi vardır. Gömülü görüntüler ve medya dosyaları dosya alanının büyük kısmını oluşturur; renkler, efektler ve degrade gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir boyut katmaz.

**Aynı biçimlendirmeyi paylaşan şekilleri bir slaytta nasıl tespit edip gruplayabilirim?**

Her şeklin kilit biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stilleri aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerini ayrı bir dosyada saklayıp diğer sunumlarda yeniden kullanabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesine ya da .POTX şablon dosyasına kaydedin. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stillendirilmiş şekilleri klonlayın ve gerektiğinde biçimlendirmelerini yeniden uygulayın.