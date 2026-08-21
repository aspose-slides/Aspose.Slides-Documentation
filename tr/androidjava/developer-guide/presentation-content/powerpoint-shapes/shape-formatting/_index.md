---
title: Android'de PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/androidjava/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- şekil çizgi eskizi
- kesişme stilini biçimlendirme
- degrade doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- düz renk doldurma
- şekil saydamlığı
- siyah-beyaz şekil renderı
- gri tonlamalı şekil renderı
- şekli döndür
- 3D kırışıklık efekti
- 3D döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Android'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenarlıklarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin içlerinin nasıl doldurulacağını kontrol eden ayarları belirleyerek de biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java, PowerPoint'te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arayüzler ve metodlar sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü özetler:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans elde edin.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linestyle/) ayarını belirleyin.
1. Çizgi kalınlığını ayarlayın.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linedashstyle/) ayarını ayarlayın.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen `AutoShape`'in nasıl biçimlendirileceğini gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle (dikdörtgen) türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin dolgusunu kaldırın, böylece sadece çizgileri görünür.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Dikdörtgenin çizgilerine biçimlendirme uygulayın.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Dikdörtgenin çizgi rengine ayarlayın.
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

Eskiz efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. [IShape.getLineFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) ile çizgi ayarlarına, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilineformat/) ile eskiz ayarlarına erişebilir ve [ISketchFormat.setSketchType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isketchformat/) ile [LineSketchType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linesketchtype/) enumerasyonundan bir değer seçebilirsiniz.

Aşağıdaki Java kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linesketchtype/) efekti nasıl uygulanır, açıkça atanmış değer nasıl okunur ve [LineSketchType.None](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linesketchtype/) ile efekt nasıl kaldırılır gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi biçimine ve eskiz biçimine erişin.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Bir eskiz efekti uygulayın.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Şekle doğrudan atanmış eskiz efektini okuyun.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Eskiz efektini kaldırın.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isketchformat/) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya yerleşim slaydından devralınabiliyorsa, [ILineFormat.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilineformat/) kullanın, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilineformateffectivedata/) erişin ve [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isketchformateffectivedata/) okuyun. Etkili değer, kalıtım çözüldükten sonra aslında uygulanan biçimlendirmeyi yansıtır:

```java
import com.aspose.slides.*;

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

## **Köşe Biçimlendirme Stilleri**

İşte üç köşe tipi seçeneği:

* Round
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Round** ayarını kullanır. Ancak, keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki köşe stili](join-style-powerpoint.png)

Aşağıdaki Java kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round köşe tipi ayarlarıyla nasıl oluşturulduğunu gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle (dikdörtgen) tipinde üç otomatik şekil ekleyin.
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

    // Köşe stilini ayarlayın.
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

## **Degrade Doldurma**

PowerPoint'te Degrade Doldurma, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin diğerine yavaşça geçecek şekilde uygulayabilirsiniz.

Aşağıda Aspose.Slides kullanarak bir şekle degrade doldurma nasıl uygulanır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans elde edin.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. İki tercih ettiğiniz rengi, konumları tanımlı olarak, [IGradientFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igradientformat/) arayüzünün sunduğu gradient durak koleksiyonunun `add` metodlarıyla ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse (elips) tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipseye degrade biçimlendirme uygulayın.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Degrade yönünü ayarlayın.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // İki adet degrade durak ekleyin.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Degrade doldurulmuş elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint'te Desen Doldurma, iki renkli bir tasarım—örneğin noktalar, çizgiler, çapraz tarama veya kareler—şekle uygulanmasını sağlayan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini isteğe göre seçebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stilı sunar. Ön tanımlı bir deseni seçtikten sonra, hâlâ kullanılacak kesin renkleri belirleyebilirsiniz.

Aşağıda Aspose.Slides kullanarak bir şekle desen doldurma nasıl uygulanır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans elde edin.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/patternformat/#getBackColor--) ayarını belirleyin.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/patternformat/#getForeColor--) ayarını belirleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma türünü Pattern olarak ayarlayın.
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

![Desen doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'te Resim Doldurma, bir şeklin içine bir resim eklemenizi ve resmi şeklin arka planı gibi kullanmanızı sağlayan bir biçimlendirme seçeneğidir.

Aspose.Slides kullanarak bir şekle resim doldurma nasıl uygulanır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans elde edin.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz resimden bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesi oluşturun.
1. Resmi `ISlidesPicture.setImage` metoduna iletin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

![Lotus resmi](lotus.png)

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Doldurma türünü Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Resim doldurma modunu ayarlayın.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Bir resmi yükleyin ve sunum kaynaklarına ekleyin.
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

![Resim doldurulmuş şekil](picture-fill.png)

### **Döşeme Resmi Doku Olarak**

Döşeme şeklinde bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek isterseniz, [IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) arayüzünün ve [PictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturefillformat/) sınıfının aşağıdaki metodlarını kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Resim doldurma modunu ayarlar — `Tile` veya `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Döşemelerin şekil içinde hizalamasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Döşemenin yatay ofsetini (puan cinsinden) şeklin orijinalinden ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Döşemenin dikey ofsetini (puan cinsinden) şeklin orijinalinden ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekle döşeme resimli doldurma ekleyip döşeme seçeneklerini yapılandırmayı gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Dikdörtgen bir otomatik şekil ekleyin.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin doldurma türünü Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Resmi yükleyin ve sunum kaynaklarına ekleyin.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Resmi şekle atayın.
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

![Döşeme seçenekleri](tile-options.png)

## **Düz Renk Doldurma**

PowerPoint'te Düz Renk Doldurma, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradient, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk doldurma uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans elde edin.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şekle tercih ettiğiniz doldurma rengini atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle (dikdörtgen) tipinde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma türünü Solid olarak ayarlayın.
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

![Düz renk doldurulmuş şekil](solid-color-fill.png)

## **Saydamlık Ayarlama**

PowerPoint'te bir şekle düz renk, degrade, resim ya da doku doldurma uyguladığınızda, doldurmanın opaklığını kontrol etmek için saydamlık seviyesini de ayarlayabilirsiniz. Daha yüksek bir saydamlık değeri şekli daha şeffaf hâle getirir, arka planın veya alt nesnelerin kısmen görünmesine izin verir.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak saydamlık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans elde edin.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` kullanarak alfa bileşeni saydamlığı kontrol eden bir renk tanımlayın.
1. Sunumu kaydedin.

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

![Saydam şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama ya da tasarım ihtiyaçlarıyla konumlandırırken faydalı olabilir.

Bir slayttaki bir şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans elde edin.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin döndürme özelliğini istenen açıya ayarlayın.
1. Sunumu kaydedin.

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

![Şekil dönmesi](shape-rotation.png)

## **3D Kırışıklık Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3D kırışıklık efektleri eklemenizi sağlar.

Bir şekle 3D kırışıklık efekti eklemek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans elde edin.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) özelliklerini kırışıklık ayarlarını tanımlayacak şekilde yapılandırın.
1. Sunumu kaydedin.

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

![3D kırışıklık efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3D döndürme efektleri eklemenizi sağlar.

Bir şekle 3D döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans elde edin.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. [setCameraType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icamera/#setCameraType-int-) ve [setLightType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) metodlarını kullanarak 3D döndürmeyi tanımlayın.
1. Sunumu kaydedin.

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

![3D döndürme efekti](3D-rotation-effect.png)

## **Şekiller için Siyah-Beyaz Render Kontrolü**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) metodu, bir sunum siyah-beyaz modunda görüntülenirken veya işlenirken ayrı bir şeklin nasıl render edileceğini belirler. Bu metod tek başına siyah-beyaz görüntülemeyi etkinleştirmez ve normal renk modundaki şeklin doldurma, çizgi ya da diğer biçimlendirmelerini değiştirmez.

İstenen davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/blackwhitemode/) sınıfındaki bir değeri kullanın. Örneğin, `Automatic` render uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri tonlamayı kullanır, `BlackWhite` yalnızca siyah ve beyazı, `Black` ve `White` tek bir rengi zorlar, `Color` normal renklendirmeyi korur ve `Hidden` şekli siyah‑beyaz modunda gizler. `NotDefined` ise şekil düzeyinde bir mod atanmadığını gösterir.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Renkli modda turuncu doldurmayı koruyun, ancak siyah-beyaz modda şekli gri renkle render edin.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normal renk modunda, dikdörtgen turuncu doldurmasını korur. Siyah‑beyaz görüntüleme akışında, modu `Gray` olarak ayarlandığı için gri renkte görüntülenir. Bu, tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah‑beyaz görüntüleme ayarlarını dikkate alan diğer akışlar için farklı bir görünüm tanımlamanıza olanak tanır.

## **Biçimlendirmeyi Sıfırla**

Aşağıdaki Java kodu, bir slaytın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürmeyi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Yerleşim üzerindeki bir yer tutucuya sahip slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosyasının boyutunu etkiler mi?**

Yalnızca çok az etkiler. Gömülü resimler ve medya dosyaları dosya alanının büyük kısmını kaplarken, renkler, efektler ve degrade gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir boyut eklemez.

**Aynı biçimlendirmeyi paylaşan şekilleri bir slaytta nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edip bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini kolaylaştırır.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstenilen stillere sahip örnek şekilleri bir şablon slayt destesi ya da .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri kopyalayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.