---
title: Java’da PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- şekil çizgi eskizi
- birleştirme stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- düz renk dolgu
- şekil şeffaflığı
- siyah-beyaz şekil işleme
- gri tonlamalı şekil işleme
- şekli döndürme
- 3b koni efekti
- 3b döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java’da PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassas ve tam kontrol ile ayarlayın."
---
## **Giriş**

PowerPoint’te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için kenar çizgilerini değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca şekillerin iç doldurulmasını kontrol eden ayarları belirterek de biçimlendirme yapabilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java, şekilleri PowerPoint’te mevcut olan aynı seçeneklerle biçimlendirmenizi sağlayan arayüzler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel çizgi stili belirtebilirsiniz. Aşağıdaki adımlar bu prosedürü özetler:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the [çizgi stili](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) of the shape.
1. Set the line width.
1. Set the [çizgi kesik stili](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) of the line.
1. Set the line color for the shape.
1. Save the modified presentation as a PPTX file.

Aşağıdaki kod, bir `AutoShape` dikdörtgeninin nasıl biçimlendirileceğini gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
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

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Bir eskiz efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), eskiz ayarlarına erişmek için [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) ve [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) yöntemlerini kullanarak [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) enum’undan bir değer seçebilirsiniz.

Aşağıdaki Java kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) etkisini nasıl uygulayacağınızı, açıkça atanmış değeri nasıl okuyacağınızı ve [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) ile etkiyi nasıl kaldıracağınızı gösterir:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi biçimine ve eskiz biçimine eriş.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Bir eskiz efekti uygula.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Şekle doğrudan atanmış eskiz efektini oku.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Eskiz efektini kaldır.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir tema, ana slayt veya yerleşim slaytından devralınabiliyorsa, [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/) ve [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/) kullanarak etkili değeri okuyabilirsiniz. Etkili değer, miras çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Birleştirme Stillerini Biçimlendirme**

İşte üç birleştirme tipi seçeneği:

* Yuvarlak
* Miter
* Köşeli

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Round** ayarını kullanır. Ancak keskin köşeli bir şekil çiziyorsanız **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki birleştirme stili](join-style-powerpoint.png)

Aşağıdaki Java kodu, yukarıdaki görselde gösterildiği gibi Miter, Bevel ve Round birleştirme tipi ayarlarıyla üç dikdörtgenin nasıl oluşturulduğunu gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde üç otomatik şekil ekleyin.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Her bir dikdörtgen şeklinin dolgu rengini ayarlayın.
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

    // Her bir dikdörtgenin çizgi rengini ayarlayın.
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

    // Her bir dikdörtgene metin ekleyin.
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

PowerPoint’te Gradyan Dolgu, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin bir rengin diğerine yavaşça geçiş yaptığı iki veya daha fazla renk uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulamak için:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Gradient`.
1. Add your two preferred colors with defined positions using the `add` methods of the gradient stop collection exposed by the [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) interface.
1. Save the modified presentation as a PPTX file.

Aşağıdaki Java kodu, bir elips üzerinde gradyan dolgu etkisinin nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipsa gradyan biçimlendirmesi uygulayın.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Gradyanın yönünü ayarlayın.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // İki gradyan durak noktası ekleyin.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gradyan dolgulu elips](gradient-fill.png)

Bir gradyan dışa aktarılan bir görüntüde PowerPoint’teki gibi görünmüyorsa, [Choose a Gradient Rendering Style](/slides/tr/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Sunumda depolanan gradyan dolgusunu değiştirmeden bir işleme stili seçebilirsiniz.

## **Desen Dolgu**

PowerPoint’te Desen Dolgu, bir şekle iki renkli bir tasarım (nokta, çizgi, çapraz çizgiler veya dama tahtası gibi) uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45’den fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra hâlâ kullanılan renkleri belirtebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulamak için:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Pattern`.
1. Choose a pattern style from the predefined options.
1. Set the [Arka Plan Rengi](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) of the pattern.
1. Set the [Ön Plan Rengi](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) of the pattern.
1. Save the modified presentation as a PPTX file.

Aşağıdaki Java kodu, bir dikdörtgene desen dolgu uygulamanın nasıl yapıldığını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dolgu türünü Pattern olarak ayarlayın.
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

PowerPoint’te Resim Dolgu, bir şeklin içinde bir resmi arka plan olarak yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir.

Aspose.Slides kullanarak bir şekle resim dolgu uygulamak için:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Picture`.
1. Set the picture fill mode to `Tile` (or another preferred mode).
1. Create an [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) object from the image you want to use.
1. Pass the image to the `ISlidesPicture.setImage` method.
1. Save the modified presentation as a PPTX file.

Örneğin aşağıdaki "lotus.png" dosyasını kullanalım:

![Lotus resmi](lotus.png)

Aşağıdaki Java kodu, bir şekle resim dolgu nasıl uygulanır gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Dolgu türünü Picture olarak ayarlayın.
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

![Resim dolgulu şekil](picture-fill.png)

### **Desen Olarak Döşeme Resmi**

Döşeme resmini doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) sınıfının aşağıdaki yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Resim dolgu modunu `Tile` veya `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Döşemelerin şekil içinde hizalanmasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Döşemenin şeklin orijinden yatay offsetini (puan cinsinden) ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Döşemenin şeklin orijinden dikey offsetini (puan cinsinden) ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekline döşeme resimli dolgu eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin dolgu türünü Picture olarak ayarlayın.
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

PowerPoint’te Düz Renk Dolgu, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku veya desen olmaksızın uygulanır.

Aspose.Slides kullanarak bir şekle düz renk dolgu uygulamak için şu adımları izleyin:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Solid`.
1. Assign your preferred fill color to the shape.
1. Save the modified presentation as a PPTX file.

Aşağıdaki Java kodu, bir PowerPoint slaytında bir dikdörtgene düz renk dolgu nasıl uygulanır gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dolgu türünü Solid olarak ayarlayın.
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

![Düz renk dolgulu şekil](solid-color-fill.png)

## **Şeffaflık Ayarla**

PowerPoint’te bir şekle düz renk, gradyan, resim veya doku dolgusu uyguladığınızda, dolgunun saydamlık seviyesini ayarlayarak dolgunun opaklığını kontrol edebilirsiniz. Daha yüksek saydamlık değeri, şeklin daha çok görünür olmasını sağlar ve arka plan veya alt nesneler kısmen görünür hale gelir.

Aspose.Slides, dolgu için kullanılan rengin alfa değerini ayarlayarak saydamlık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) to `Solid`.
1. Use `Color` to define a color with transparency (the `alpha` component controls transparency).
1. Save the presentation.

Aşağıdaki Java kodu, bir dikdörtgene saydam dolgu rengi nasıl uygulanır gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarıyla konumlandırırken faydalı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Set the shape’s rotation property to the desired angle.
1. Save the presentation.

Aşağıdaki Java kodu, bir şekli 5 derece döndürmeyi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
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

![Şekil döndürmesi](shape-rotation.png)

## **3B Koni Efektleri Ekle**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3B koni efektleri uygulamanıza olanak tanır.

Bir şekle 3B koni efekti eklemek için şu adımları izleyin:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Configure the shape’s [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) to define bevel settings.
1. Save the presentation.

Aşağıdaki Java kodu, bir şekle 3B koni efektinin nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![3B koni efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekle**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza olanak tanır.

Bir şekle 3B döndürme uygulamak için:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) to the slide.
1. Use the [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) and [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) to define the 3D rotation.
1. Save the presentation.

Aşağıdaki Java kodu, bir şekle 3B döndürme efektinin nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;

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

![3B döndürme efekti](3D-rotation-effect.png)

## **Şekiller İçin Siyah-Beyaz İşleme Kontrolü**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) yöntemi, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl işleneceğini belirtir. Bu yöntem tek başına siyah-beyaz görüntülemeyi etkinleştirmez ve normal renk modundaki şeklin dolgu, çizgi veya diğer biçimlendirmesini değiştirmez.

İstediğiniz davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) sınıfından bir değer kullanın. Örneğin `Automatic` uygulama tarafından dönüşümün seçilmesini sağlar, `Gray` ve `LightGray` gri renkleme kullanır, `BlackWhite` sadece siyah ve beyazı, `Black` ve `White` tek bir rengi zorlar, `Color` normal renklendirmeyi korur ve `Hidden` şekli siyah-beyaz modunda gizler. `NotDefined` bir şekil düzeyinde modun atanmadığını gösterir.

Aşağıdaki Java kodu, renkli bir şekil oluşturur ve siyah-beyaz görüntüleme modunda gri görünmesini sağlar:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Renkli modda turuncu dolguyu koruyun, ancak siyah-beyaz modda şekli gri renkle işleyin.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normal renk modunda, dikdörtgen turuncu dolgusunu korur. Siyah-beyaz görüntüleme iş akışında, modu `Gray` olarak ayarlandığı için gri renk kullanır. Bu, tam renkli bir slaytı korurken baskı, ön izleme veya sunumun siyah-beyaz görüntüleme ayarlarını kullanan diğer iş akışları için ayrı bir görünüm tanımlamanıza olanak tanır.

## **Biçimlendirmeyi Sıfırla**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürmeyi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Yerleşimdeki yer tutucuya sahip slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Yalnızca çok az etkiler. Gömülü resimler ve medya dosyaları dosya alanının büyük bölümünü oluşturur, şekil parametreleri (renkler, efektler, gradyanlar) ise meta veri olarak saklanır ve ek bir alan kaplamaz.

**Aynı biçimlendirmeye sahip şekilleri slaytta nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm değerler aynıysa stiller aynı kabul edilir ve bu şekilleri mantıksal olarak gruplayarak stil yönetimini kolaylaştırabilirsiniz.

**Özel şekil stillerini başka sunumlarda tekrar kullanmak üzere ayrı bir dosyada saklayabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt dosyası (.POTX) içinde depolayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri kopyalayın ve gerektiğinde biçimlendirmelerini yeniden uygulayın.