---
title: Android'de PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/androidjava/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- skeç efekti
- skeç şekil çizgisi
- birleştirme stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- düz renk dolgu
- şekil şeffaflığı
- siyah-beyaz şekil renderleme
- gri tonlamalı şekil renderleme
- şekil döndürme
- 3d kırma efekti
- 3d döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Android'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenarlıklarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin içlerinin nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java, PowerPoint'te bulunan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arabirimler ve yöntemler sunar.

## **Çizgileri Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü özetler:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Indeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) ayarını belirleyin.  
1. Çizgi genişliğini ayarlayın.  
1. Çizginin [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) ayarını belirleyin.  
1. Şeklin çizgi rengini ayarlayın.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen `AutoShape`'ı nasıl biçimlendireceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin doldurmasını kaldırın, böylece sadece çizgileri görünür.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Dikdörtgenin çizgilerine biçimlendirme uygulayın.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Dikdörtgenin çizgi rengi ayarlayın.
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

## **Şekil Çizgilerine Skeç Efektleri Uygulama**

Skeç efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) kullanın, skeç ayarlarına erişmek için [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) kullanın ve [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) ile [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) sayımından bir değer seçin.

Aşağıdaki Java kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) etkisini nasıl uygulayacağınızı, açıkça atanmış değeri nasıl okuyacağınızı ve [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) ile efekti nasıl kaldıracağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi biçimine ve skeç biçimine erişin.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Bir skeç efekti uygulayın.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Şekle doğrudan atanmış skeç efektini okuyun.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Skeç efektini kaldırın.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) tarafından döndürülen değer, şekle doğrudan atanan ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaytından devralınabiliyorsa, [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) kullanın, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/) öğesine erişin ve [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/) değerini okuyun. Etkin değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

## **Birleştirme Stillerini Biçimlendirme**

İşte üç birleştirme türü seçeneği:

* Yuvarlak
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Yuvarlak** ayarını kullanır. Ancak, keskin açılı bir şekil çizerseniz **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki birleştirme stili](join-style-powerpoint.png)

Aşağıdaki Java kodu, yukarıdaki görselde gösterildiği gibi Miter, Bevel ve Yuvarlak birleştirme tipi ayarlarıyla üç dikdörtgenin nasıl oluşturulduğunu gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde üç otomatik şekil ekleyin.
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

## **Gradyan Dolgu**

PowerPoint'te Gradyan Dolgu, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin diğerine yavaşça karıştığı şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Indeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.  
1. [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) arabirimi tarafından sunulan gradient durak koleksiyonunun `add` metodlarıyla konumları tanımlı iki tercih ettiğiniz rengi ekleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu, bir elipse gradyan dolgu efektini nasıl uygulayacağınızı gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation();
try {
    // İlk slaytı alın.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse türünde bir otomatik şekil ekleyin.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipseye gradyan biçimlendirmesi uygulayın.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Gradyanın yönünü ayarlayın.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // İki gradyan durak ekleyin.
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

Bir gradyan, dışa aktarılan bir görüntüde PowerPoint'teki gibi görünmüyorsa, [Choose a Gradient Rendering Style](/slides/tr/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Sunumda depolanan gradyan dolgusunu değiştirmeden bir renderleme stili seçebilirsiniz.

## **Desen Dolgu**

PowerPoint'te Desen Dolgu, bir şekle noktalar, çizgiler, çapraz çizgiler veya kareler gibi iki renkli bir tasarım uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini isteğe göre belirleyebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sağlar. Ön tanımlı bir deseni seçtikten sonra bile kullanılacak kesin renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Indeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.  
1. Ön tanımlı seçeneklerden bir desen stili seçin.  
1. Desenin [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) ayarını belirleyin.  
1. Desenin [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) ayarını belirleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu, bir dikdörtgene desen dolgu nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

![Desenli dolgu uygulanmış dikdörtgen](pattern-fill.png)

## **Resim Dolgu**

PowerPoint'te Resim Dolgu, bir şeklin içinde bir görüntü yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; görüntü şeklin arka planı olarak kullanılır.

Aspose.Slides kullanarak bir şekle resim dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Indeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.  
1. Resim dolgu modunu `Tile` (veya başka bir tercih edilen mod) olarak ayarlayın.  
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) nesnesi oluşturun.  
1. Görüntüyü `ISlidesPicture.setImage` metoduna iletin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Şu resmi içeren bir "lotus.png" dosyamız olduğunu varsayalım:

![Lotus resmi](lotus.png)

Aşağıdaki Java kodu, bir şekle resim dolgu nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

![Resim dolgulu şekil](picture-fill.png)

### **Resmi Doku Olarak Döşeme**

Döşeli bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) arabirimi ve [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) sınıfının aşağıdaki metodlarını kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Resim dolgu modunu ayarlar — `Tile` ya da `Stretch`.  
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Döşemelerin şekil içinde hizalanmasını belirler.  
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.  
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Döşemenin şeklin orijinden yatay kaymasını (puan cinsinden) ayarlar.  
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Döşemenin şeklin orijinden düşey kaymasını (puan cinsinden) ayarlar.  
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Döşemenin yatay ölçeğini yüzde olarak tanımlar.  
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Döşemenin düşey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşeli bir resim dolgusu ile bir dikdörtgen şekli eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

PowerPoint'te Düz Renk Dolgu, bir şekli tek, tekdüze bir renkle dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Indeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
1. Şekle tercih ettiğiniz doldurma rengini atayın.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu, bir PowerPoint slaytındaki bir dikdörtgene düz renk dolgu nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

![Düz renk dolgulu şekil](solid-color-fill.png)

## **Şeffaflığı Ayarla**

PowerPoint'te bir şekle düz renk, gradyan, resim veya doku dolgusu uyguladığınızda, dolgunun opaklığını kontrol etmek için bir şeffaflık seviyesi de belirleyebilirsiniz. Yüksek şeffaflık değeri, şeklin daha çok görünür olmasını sağlar; arka plan veya alttaki nesneler kısmen görülür.

Aspose.Slides, dolgu için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenizi sağlar. İşte nasıl yapacağınız:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Indeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.  
1. [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
1. `Color` sınıfını kullanarak şeffaflığı olan bir renk tanımlayın (`alpha` bileşeni şeffaflığı kontrol eder).  
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir dikdörtgene şeffaf dolgu rengi nasıl uygulanacağını gösterir:

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

    // Katı şeklin üzerine yarı saydam bir dikdörtgen otomatik şekil ekleyin.
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

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım gereksinimlerine göre konumlandırırken yararlı olabilir.

Bir slayttaki bir şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Indeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.  
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir şekli 5 derece döndürmeyi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

![Şekil döndürmesi](shape-rotation.png)

## **3D Kırma Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3D kırma efektleri eklemenizi sağlar.

Bir şekle 3D kırma efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfını örnekleyin.  
1. Indeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) özelliğini yapılandırarak kırma ayarlarını tanımlayın.  
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir şekle 3D kırma efektleri nasıl uygulanacağını gösterir:

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

![3D kırma efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3D döndürme efektleri eklemenizi sağlar.

Bir şekle 3D döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Indeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ekleyin.  
1. [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) ve [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) metodlarını kullanarak 3D döndürmeyi tanımlayın.  
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir şekle 3D döndürme efektleri nasıl uygulanacağını gösterir:

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

## **Şekiller için Siyah-Beyaz Renderlemeyi Kontrol Et**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) yöntemi, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlenirken bireysel bir şeklin nasıl renderleneceğini belirler. Bu yöntem tek başına siyah-beyaz görüntülemeyi etkinleştirmez ve normal renk modunda şeklin dolgusunu, çizgisini veya diğer biçimlendirmesini değiştirmez.

[BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) sınıfından bir değer seçerek istenen davranışı seçin. Örneğin, `Automatic` renderleme uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri renkleme kullanır, `BlackWhite` sadece siyah ve beyazı kullanır, `Black` ve `White` tek bir renk zorlar, `Color` normal renklemeyi korur ve `Hidden` siyah-beyaz modunda şekli atar. `NotDefined` ise şekil‑seviyesi bir mod atanmadığını gösterir.

Aşağıdaki Java kodu, renkli bir şekil oluşturur ve siyah‑beyaz görüntüleme modunda gri görünmesini sağlar:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Turuncu doldurmayı renk modunda tutun, ancak şekli siyah-beyaz modunda gri renkle renderleyin.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normal renk modunda dikdörtgen turuncu dolgusunu korur. Siyah‑beyaz görüntüleme iş akışında modu `Gray` olarak ayarlandığı için gri renkle gösterilir. Bu sayede tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah‑beyaz görüntüleme ayarlarını dikkate alan diğer iş akışları için farklı bir görünüm tanımlayabilirsiniz.

## **Biçimlendirmeyi Sıfırla**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini nasıl sıfırlayacağınızı ve [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara nasıl geri getireceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Düzeni üzerinde yer tutucu bulunan slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi, son sunum dosya boyutunu etkiler mi?**

Sadece çok az etkiler. Gömülü görüntüler ve medya dosyaları dosya boyutunun büyük kısmını oluşturur; renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve neredeyse hiç ek boyut eklemez.

**Bir slayttaki aynı biçimlendirmeye sahip şekilleri nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edip bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerini ayrı bir dosyada kaydedip diğer sunumlarda yeniden kullanabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesi veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.