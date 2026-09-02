---
title: Java'da PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- eskiz şekil çizgisi
- bağlaç stili biçimlendirme
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil şeffaflığı
- şekil döndürme
- 3b kırma efekti
- 3b döndürme efekti
- biçimlendirmeyi sıfırlama
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassas ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'ta slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için konturları üzerinde değişiklik yaparak veya efekt uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin iç kısımlarının nasıl doldurulacağını kontrol eden ayarları belirleyerek de biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java, şekilleri PowerPoint'te mevcut aynı seçeneklerle biçimlendirebilmenizi sağlayan arayüzler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [line style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linestyle/) özelliğini ayarlayın.  
1. Çizgi kalınlığını ayarlayın.  
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linedashstyle/) özelliğini ayarlayın.  
1. Şeklin çizgi rengini ayarlayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod bir dikdörtgen `AutoShape` nasıl biçimlendirilir gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
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

    // Dikdörtgenin çizgisinin rengini ayarlayın.
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

Eskiz efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. [IShape.getLineFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) ile çizgi ayarlarına, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilineformat/) ile eskiz ayarlarına ve [ISketchFormat.setSketchType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isketchformat/) ile [LineSketchType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linesketchtype/) enum'undan bir değer seçerek bu efekti uygulayabilirsiniz.

Aşağıdaki Java kodu, [LineSketchType.Curved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linesketchtype/) efektini nasıl uygulayacağınızı, atanmış değeri nasıl okuyacağınızı ve [LineSketchType.None](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linesketchtype/) ile efekti nasıl kaldıracağınızı gösterir:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi biçimine ve onun eskiz biçimine erişin.
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

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isketchformat/) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya yerleşim slaydından kalıtılmış olabiliyorsa, [ILineFormat.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilineformat/) kullanın, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilineformateffectivedata/) erişin ve [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isketchformateffectivedata/) okuyun. Etkili değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

## **Bağlantı Stilleri Biçimlendirme**

Üç bağlantı tipi seçeneği şunlardır:

* Round  
* Miter  
* Bevel  

PowerPoint varsayılan olarak iki çizgiyi bir açıyla birleştirdiğinde (örneğin bir şeklin köşesinde) **Round** ayarını kullanır. Ancak keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki bağlaç stili](join-style-powerpoint.png)

Aşağıdaki Java kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round bağlaç tipi ayarlarıyla nasıl oluşturulduğunu gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde üç otomatik şekil ekle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Her dikdörtgen şeklinin dolgu rengini ayarla.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Çizgi kalınlığını ayarla.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Her dikdörtgenin çizgisinin rengini ayarla.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Bağlaç stilini ayarla.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Her dikdörtgene metin ekle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX dosyasını diske kaydet.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradyan Doldurma**

PowerPoint'ta Gradyan Doldurma, bir şekle sürekli bir renk karışımı uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin diğerine yavaşça geçecek şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan doldurma uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.  
1. [IGradientFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igradientformat/) arayüzünün sunduğu gradyan durak koleksiyonunun `add` metodlarını kullanarak tanımlı konumlarla iki tercih ettiğiniz rengi ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu bir elips üzerinde gradyan doldurma etkisinin nasıl uygulanacağını gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipseye gradyan biçimlendirmesi uygula.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Gradyanın yönünü ayarla.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // İki gradyan durak ekle.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX dosyasını diske kaydet.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gradyan doldurulmuş elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint'ta Desen Doldurma, bir şekle iki renkli bir tasarım (nokta, çizgi, çapraz çizgi veya dama gibi) uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stilini sunar. Ön tanımlı bir deseni seçtikten sonra kullanılacak kesin renkleri hâlâ belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.  
1. Ön tanımlı seçeneklerden bir desen stili seçin.  
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/patternformat/#getBackColor--) özelliğini ayarlayın.  
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/patternformat/#getForeColor--) özelliğini ayarlayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu bir dikdörtgene desen doldurma nasıl uygulanır gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Pattern olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Desen stilini ayarla.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Desenin arka plan ve ön plan renklerini ayarla.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // PPTX dosyasını diske kaydet.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Desen doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'ta Resim Doldurma, bir şeklin içine bir görüntü eklemenizi ve görüntüyü şeklin arka planı olarak kullanmanızı sağlayan bir biçimlendirme seçeneğidir.

Aspose.Slides ile bir şekle resim doldurma uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.  
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.  
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesi oluşturun.  
1. Görüntüyü `ISlidesPicture.setImage` metoduna iletin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki resim "lotus.png" dosyasını göstermektedir:

![Lotus resmi](lotus.png)

Aşağıdaki Java kodu bir şekle resmi nasıl dolduracağınızı gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Dolgu tipini Picture olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Resim doldurma modunu ayarla.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Bir görüntü yükle ve sunum kaynaklarına ekle.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Resmi ayarla.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX dosyasını diske kaydet.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Resim doldurulmuş şekil](picture-fill.png)

### **Döşeme Resmini Doku Olarak Kullanma**

Döşeme bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) arayüzünün ve [PictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/picturefillformat/) sınıfının aşağıdaki yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Resim doldurma modunu `Tile` veya `Stretch` olarak ayarlar.  
- [setTileAlignment](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Döşemelerin şekil içinde hizalanmasını belirler.  
- [setTileFlip](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.  
- [setTileOffsetX](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Döşemenin yatay ofsetini (puan cinsinden) şeklin orijiniyle karşılaştırarak ayarlar.  
- [setTileOffsetY](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Döşemenin dikey ofsetini (puan cinsinden) şeklin orijiniyle karşılaştırarak ayarlar.  
- [setTileScaleX](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Döşemenin yatay ölçeğini yüzde olarak tanımlar.  
- [setTileScaleY](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği bir dikdörtgen şekil ekleyip döşeme resmi doldurmasını ve döşeme seçeneklerini yapılandırmayı gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin dolgu tipini Picture olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Görüntüyü yükle ve sunum kaynaklarına ekle.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Görüntüyü şekle ata.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Resim doldurma modunu ve döşeme özelliklerini yapılandır.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // PPTX dosyasını diske kaydet.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Katı Renk Doldurma**

PowerPoint'ta Katı Renk Doldurma, bir şekli tek bir, eşit renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku veya desen olmadan uygulanır.

Aspose.Slides ile bir şekle katı renk doldurma uygulamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
1. Şekle tercih ettiğiniz doldurma rengini atayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu bir PowerPoint slaydındaki dikdörtgene katı renk doldurma nasıl uygulanır gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Solid olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Dolgu rengini ayarla.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX dosyasını diske kaydet.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Katı renk doldurulmuş şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint'ta bir şekle katı renk, gradyan, resim veya doku doldurması uyguladığınızda, doldurmanın opaklığını kontrol etmek için şeffaflık seviyesi de ayarlayabilirsiniz. Yüksek şeffaflık değeri, şeklin daha çok görülmesini sağlar ve arka planın ya da alt öğelerin kısmen görünmesine izin verir.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.  
1. [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.  
1. `Color` sınıfını kullanarak şeffaflığı (alfa bileşeni şeffaflığı kontrol eder) içeren bir renk tanımlayın.  
1. Sunumu kaydedin.

Aşağıdaki Java kodu bir dikdörtgene şeffaf bir doldurma rengi nasıl uygulanır gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Katı bir dikdörtgen otomatik şekil ekle.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekle.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // PPTX dosyasını diske kaydet.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım gereksinimlerine göre konumlandırırken faydalı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.  
1. Sunumu kaydedin.

Aşağıdaki Java kodu bir şekli 5 derece döndürmeyi gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndür.
    shape.setRotation(5);

    // PPTX dosyasını diske kaydet.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şekil döndürmesi](shape-rotation.png)

## **3B Kırma Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3B kırma efektleri uygulamanızı sağlar.

Bir şekle 3B kırma efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.  
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) özelliklerini yapılandırarak kırma ayarlarını tanımlayın.  
1. Sunumu kaydedin.

Aşağıdaki Java kodu bir şekle 3B kırma efektleri nasıl uygulanır gösterir:

```java
// Presentation sınıfının bir örneğini oluşturun.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Slayta bir şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Şeklin ThreeDFormat özelliklerini ayarla.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Sunumu PPTX dosyası olarak kaydet.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![3B kırma efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanızı sağlar.

Bir şekle 3B döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.  
1. [setCameraType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icamera/#setCameraType-int-) ve [setLightType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilightrig/#setLightType-int-) metodlarını kullanarak 3B döndürmeyi tanımlayın.  
1. Sunumu kaydedin.

Aşağıdaki Java kodu bir şekle 3B döndürme efekti nasıl uygulanır gösterir:

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

![3B döndürme efekti](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini sıfırlayarak [LayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslide/) üzerindeki yer tutucu içerikli tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına geri döndürür:

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

**Şekil biçimlendirmesi nihai sunum dosyasının boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosya boyutunun büyük kısmını oluşturur, şekil parametreleri (renkler, efektler, gradyanlar) meta veri olarak saklanır ve neredeyse ek bir boyut eklemez.

**Aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa stillerini aynı olarak kabul edip mantıksal bir grup oluşturun; bu daha sonraki stil yönetimini basitleştirir.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesi veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyaç duyduğunuz stillendirilmiş şekilleri klonlayın ve gerektiği yerde biçimlendirmeyi yeniden uygulayın.