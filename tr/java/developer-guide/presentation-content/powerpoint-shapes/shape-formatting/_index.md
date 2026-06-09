---
title: Java'da PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- birleştirme stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- düz renk dolgu
- şekil şeffaflığı
- şekli döndür
- 3d kenar efekti
- 3d döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te, slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenarlıklarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin içlerinin nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![şekil-biçimlendirme-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java, PowerPoint'te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arabirimler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi genişliğini ayarlayın.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şekil için çizgi rengini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir `AutoShape` dikdörtgenini nasıl biçimlendireceğinizi gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin dolgu rengini ayarlayın.
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

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Birleştirme Stilleri Biçimlendirme**

İşte üç birleştirme tipi seçeneği:

* Yuvarlak
* Miter
* Bevel

PowerPoint varsayılan olarak iki çizgiyi bir açıyla (örneğin bir şeklin köşesinde) birleştirirken **Yuvarlak** ayarını kullanır. Ancak, keskin açılara sahip bir şekil çizerseniz **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki birleştirme stili](join-style-powerpoint.png)

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde üç otomatik şekil ekleyin.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Her dikdörtgen şeklinin dolgu rengini ayarlayın.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Çizgi genişliğini ayarlayın.
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

    // Birleştirme stilini ayarlayın.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Her dikdörtgenin metnini ekleyin.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX dosyasını diske kaydedin.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradyan Dolgu**

PowerPoint'te Gradient Fill, bir şekle sürekli bir renk karışımı uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin yavaşça diğerine geçecek şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. İki tercih ettiğiniz rengi, tanımlı konumlarla, [IGradientFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igradientformat/) arayüzünün sunduğu `add` metodlarıyla ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elips'e gradyan biçimlendirme uygulayın.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Gradyanın yönünü ayarlayın.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // İki gradyan durağı ekleyin.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gradyan dolgu ile elips](gradient-fill.png)

## **Desen Dolgu**

PowerPoint'te Pattern Fill, şekle iki renkli bir tasarım—nokta, çizgi, çapraz tarama veya kare gibi—uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stiline sahiptir. Ön tanımlı bir deseni seçtikten sonra, kullanılacak kesin renkleri yine belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçeneklerden bir desen stilini seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/patternformat/#getBackColor--) özelliğini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/patternformat/#getForeColor--) özelliğini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Pattern olarak ayarlayın.
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

![Desenli dolgu ile dikdörtgen](pattern-fill.png)

## **Resim Dolgu**

PowerPoint'te Picture Fill, bir resmi şeklin içine yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; böylece resmi şeklin arka planı olarak kullanabilirsiniz.

Aspose.Slides kullanarak bir şekle resim dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim dolgu modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.setImage` metoduna aktarın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

![Lotus resmi](lotus.png)

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Dolgu tipini Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Resim dolgu modunu ayarlayın.
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

![Resim dolgu ile şekil](picture-fill.png)

### **Döşeme Resmi Doku Olarak**

Bir döşeme resmi dokusu ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) arayüzünün ve [PictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/picturefillformat/) sınıfının aşağıdaki metodlarını kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Resim dolgu modunu ayarlar — `Tile` veya `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Döşemelerin şekil içinde hizalanmasını belirtir.
- [setTileFlip](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Döşemenin şeklin orijinalinden yatay ofsetini (point cinsinden) ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Döşemenin şeklin orijinalinden düşey ofsetini (point cinsinden) ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Döşemenin düşey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşeme resimli bir dikdörtgen şekli ekleyip döşeme seçeneklerini yapılandırır:

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Rectangle otomatik şekli ekleyin.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin dolgu tipini Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Görüntüyü yükleyin ve sunum kaynaklarına ekleyin.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Görüntüyü şekle atayın.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Resim dolgu modunu ve döşeme özelliklerini yapılandırın.
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

![Döşeme seçenekleri](tile-options.png)

## **Düz Renk Dolgu**

PowerPoint'te Solid Color Fill, bir şekli tek, tekdüze bir renkle dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, gradyan, doku ya da desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şekle tercih ettiğiniz dolgu rengini atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Solid olarak ayarlayın.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Dolgu rengini ayarlayın.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX dosyasını diske kaydedin.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Düz renk dolgu ile şekil](solid-color-fill.png)

## **Şeffaflık Ayarla**

PowerPoint'te, bir şekle düz renk, gradyan, resim ya da doku dolgusu uyguladığınızda, dolgunun opaklığını kontrol etmek için bir şeffaflık seviyesi de belirleyebilirsiniz. Daha yüksek şeffaflık değeri, şeklin daha çok görünür olmasını sağlar; arka plan ya da alt nesneler kısmen görülebilir.

Aspose.Slides, dolgu rengi içindeki alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` aracılığıyla alfa bileşeni şeffaflığı kontrol eden bir renk tanımlayın.
1. Sunumu kaydedin.

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
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

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama ya da tasarım gereksinimleriyle konumlandırırken faydalı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndürün.
    shape.setRotation(5);

    // PPTX dosyasını diske kaydedin.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şekil döndürme](shape-rotation.png)

## **3D Kenar Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3D kenar (bevel) efektleri uygulamanıza olanak tanır.

Bir şekle 3D kenar efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) özelliğini kenar ayarlarını tanımlayacak şekilde yapılandırın.
1. Sunumu kaydedin.

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

![3D kenar etkisi](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3D döndürme efektleri uygulamanıza olanak tanır.

Bir şekle 3D döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. 3D döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icamera/#setCameraType-int-) ve [setLightType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilightrig/#setLightType-int-) metodlarını kullanın.
1. Sunumu kaydedin.

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

![3D döndürme etkisi](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırla**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini sıfırlayarak [LayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslide/) üzerindeki yer tutucularla tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürür:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Yerleşimde yer tutucu bulunan slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosya boyutunu etkiler mi?**

Sadece çok az bir etkisi vardır. Gömülü görüntüler ve medya dosyaları dosya alanının büyük bir kısmını oluşturur, renkler, efektler ve gradyanlar gibi şekil parametreleri ise meta veri olarak saklanır ve neredeyse ek bir boyut katmaz.

**Aynı biçimlendirmeye sahip şekilleri bir slaytta nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edip bu şekilleri mantıksal olarak gruplayın; bu, daha sonraki stil yönetimini basitleştirir.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyada kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesi ya da .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilli şekilleri kopyalayın ve gerektiği yerde biçimlendirmeyi yeniden uygulayın.