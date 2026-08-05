---
title: Android'de PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/androidjava/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- taslak efekti
- şekil çizgisi taslağı
- birleşim stili biçimlendirme
- degrade doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil şeffaflığı
- şekil döndürme
- 3D köşe efekti
- 3D döndürme efekti
- biçimlendirme sıfırlama
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Android'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerini değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin iç kısımlarının nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![PowerPoint'te şekil biçimlendirme](format-shape-powerpoint.png)

Java üzerinden Android için Aspose.Slides, PowerPoint'te bulunan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arabirimler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. Aşağıdaki adımlar prosedürü özetler:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi genişliğini ayarlayın.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen `AutoShape` nasıl biçimlendirilir gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin dolgu rengini ayarla.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Dikdörtgenin çizgilerine biçimlendirme uygula.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Dikdörtgenin çizgi rengini ayarla.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX dosyasını diske kaydet.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Şekil Çizgilerine Çizim Efektleri Uygulama**

Bir çizim efekti, şekil çizgisini el yapımı gibi gösterir. Çizgi ayarlarına erişmek için [IShape.getLineFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) kullanın, çizim ayarlarına erişmek için [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilineformat/) kullanın ve [ISketchFormat.setSketchType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isketchformat/) ile [LineSketchType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linesketchtype/) enum\'undan bir değer seçin.

Aşağıdaki Java kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linesketchtype/) efekti nasıl uygulanır, açıkça atanmış değer nasıl okunur ve [LineSketchType.None](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/linesketchtype/) ile nasıl kaldırılır gösterir:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi biçimine ve taslak biçimine eriş.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Taslak etkisi uygula.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Şekle doğrudan atanmış taslak etkisini oku.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Taslak etkisini kaldır.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isketchformat/) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirme bir temadan, ana slayttan veya düzen slaytından devralınabiliyorsa, [ILineFormat.getEffective](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilineformat/) kullanarak, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilineformateffectivedata/) erişin ve [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isketchformateffectivedata/) okuyun. Etkin değer, devralma çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

İşte üç bağlantı tipi seçeneği:

* Round
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirdiğinde **Round** ayarını kullanır. Ancak, keskin açılara sahip bir şekil çiziyorsanız **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki bağlantı stili](join-style-powerpoint.png)

Aşağıdaki Java kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round bağlantı tipi ayarları kullanılarak nasıl oluşturulduğunu gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde üç otomatik şekil ekle.
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

    // Her dikdörtgenin çizgi rengini ayarla.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Bağlantı stilini ayarla.
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

## **Degrade Doldurma**

PowerPoint'te Degrade Doldurma, bir şekle sürekli bir renk karışımı uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, bir rengin diğerine yavaşça geçiş yaptığı iki veya daha fazla renk uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle degrade doldurma uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [IGradientFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igradientformat/) arabirimi tarafından sunulan degrade durak koleksiyonunun `add` metodlarını kullanarak tanımlı konumlarla iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu, bir elipse degrade doldurma etkisi nasıl uygulanır gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipseye degrade biçimlendirme uygula.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Degradenin yönünü ayarla.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // İki degrade durak ekle.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX dosyasını diske kaydet.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Degrade doldurmalı elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint'te Desen Doldurma, iki renkli bir tasarım—nokta, şerit, çapraz çizgi veya kare gibi—şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45\'ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir desen seçtikten sonra bile kullanılacak kesin renkleri belirtebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/patternformat/#getBackColor--) özelliğini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/patternformat/#getForeColor--) özelliğini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu, bir dikdörtgene desen doldurma nasıl uygulanır gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma tipini Pattern olarak ayarla.
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

![Desen doldurmalı dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'te Resim Doldurma, bir şeklin içine bir görüntü yerleştirmenizi sağlar—görüntüyü şeklin arka planı gibi kullanır.

Aspose.Slides kullanarak bir şekle resim doldurma uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.setImage` metoduna geçirin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

![Lotus resmi](lotus.png)

Aşağıdaki Java kodu, bir şekli resimle nasıl dolduracağınızı gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Doldurma tipini Picture olarak ayarla.
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

![Resim doldurmalı şekil](picture-fill.png)

### **Döşeme Resmi Doku Olarak**

Döşeme bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek isterseniz, [IPictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/) arabiriminin ve [PictureFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/picturefillformat/) sınıfının aşağıdaki yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Resim doldurma modunu `Tile` ya da `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Döşemelerin şekil içinde hizalamasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Döşemenin yatay ofsetini (puan cinsinden) şeklin orijinal noktasından ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Döşemenin dikey ofsetini (puan cinsinden) şeklin orijinal noktasından ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşemeli bir resim doldurmasıyla bir dikdörtgen şekil eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Bir dikdörtgen otomatik şekil ekle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin doldurma tipini Picture olarak ayarla.
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

PowerPoint'te Katı Renk Doldurma, bir şekli tek ve tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, degrade, doku veya desen olmaksızın uygulanır.

Aspose.Slides kullanarak bir şekle katı renk doldurma uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şekle istediğiniz doldurma rengini atayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu, bir PowerPoint slaydındaki bir dikdörtgene katı renk doldurma nasıl uygulanır gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma tipini Solid olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Doldurma rengini ayarla.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX dosyasını diske kaydet.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Katı renk doldurmalı şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint'te bir şekle katı renk, degrade, resim veya doku doldurması uyguladığınızda, doldurmanın saydamlık seviyesini ayarlayarak opaklığını kontrol edebilirsiniz. Daha yüksek bir şeffaflık değeri, şeklin daha çok geçiş yapmasını sağlar ve arka plan ya da alt nesneler kısmen görünür hâle gelir.

Aspose.Slides, doldurma için kullanılan renkteki alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` kullanarak alfa bileşeniyle şeffaflığı kontrol eden bir renk tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir dikdörtgene şeffaf bir doldurma rengi nasıl uygulanır gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
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

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarıyla konumlandırmak için yararlı olabilir.

Bir slayttaki bir şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin döndürme özelliğini istenen açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir şekli 5 derece döndürmeyi gösterir:

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
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

![Şekil döndürme](shape-rotation.png)

## **3D Köşe Efektleri Ekleme**

Aspose.Slides, şekillere 3D köşe efektleri uygulamanıza izin verir; bunun için [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) özelliklerini yapılandırmanız yeterlidir.

Bir şekle 3D köşe efektleri eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini başlatın.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) özelliklerini köşe ayarlarını tanımlamak için yapılandırın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir şekle 3D köşe efektleri nasıl uygulanır gösterir:

```java
// Presentation sınıfının bir örneğini oluştur.
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

![3D köşe efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekleme**

Aspose.Slides, şekillere 3D döndürme efektleri uygulamanıza izin verir; bunun için [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) özelliklerini yapılandırmanız yeterlidir.

Bir şekle 3D döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ekleyin.
1. 3D döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icamera/#setCameraType-int-) ve [setLightType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) yöntemlerini kullanın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir şekle 3D döndürme efektleri nasıl uygulanır gösterir:

```java
// Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Sunumu PPTX dosyası olarak kaydet.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![3D döndürme efekti](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına geri getirmeyi gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Düzen üzerindeki bir yer tutucuya sahip slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosya boyutunu etkiler mi?**

Sadece çok az etkiler. Gömülü görüntüler ve medya dosyaları dosya alanının çoğunu kaplarken, renkler, efektler ve degrade gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir boyut eklemez.

**Aynı biçimlendirmeyi paylaşan slayt üzerindeki şekilleri nasıl algılayıp gruplandırabilirim?**

Her şeklin doldurma, çizgi ve efekt ayarlarını karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edip mantıksal bir grup oluşturun; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerinin bir setini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstediğiniz stilleri içeren örnek şekilleri bir şablon slayt destesi veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.