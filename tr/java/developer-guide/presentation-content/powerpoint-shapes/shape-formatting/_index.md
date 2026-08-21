---
title: Java'da PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- çizim efekti
- çizim şekil çizgisi
- bağlama stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- katı renk dolgu
- şekil şeffaflığı
- siyah-beyaz şekil renderlaması
- gri tonlu şekil renderlaması
- şekil döndürme
- 3b kırma efekti
- 3b döndürme efekti
- biçimlendirme sıfırlama
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyalarında dolgu, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint’te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerine efekt uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin iç kısımlarının nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![PowerPoint'ta şekil biçimlendirme](format-shape-powerpoint.png)

Aspose.Slides for Java, PowerPoint’te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan arabirimler ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. İşlem aşağıdaki adımlarla gerçekleştirilir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi genişliğini ayarlayın.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen `AutoShape`’i nasıl biçimlendireceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfını örnekle.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin doldurma rengini ayarla.
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

## **Şekil Çizgilerine Çizim Efekti Uygulama**

Bir çizim efekti, şekil çizgisinin el çizimi gibi görünmesini sağlar. [IShape.getLineFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) ile çizgi ayarlarına, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilineformat/) ile çizim ayarlarına ve [ISketchFormat.setSketchType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isketchformat/) ile [LineSketchType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linesketchtype/) adlı enumeration’dan bir değer seçebilirsiniz.

Aşağıdaki Java kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linesketchtype/) efekti nasıl uygulanacağını, açıkça atanan değerin nasıl okunacağını ve [LineSketchType.None](https://reference.aspose.com/slides/tr/java/com.aspose.slides/linesketchtype/) ile etkinin nasıl kaldırılacağını gösterir:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi formatına ve onun taslak formatına eriş.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Bir taslak efekti uygula.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Şekle doğrudan atanmış taslak efektini oku.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Taslak efektini kaldır.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isketchformat/) tarafından döndürülen değer, şekle doğrudan atanan ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya slayt düzeninden devralınabiliyorsa, [ILineFormat.getEffective](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilineformat/) kullanın, [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilineformateffectivedata/) öğesine erişin ve [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isketchformateffectivedata/) değerini okuyun. Etkili değer, devralma çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

## **Bağlama Stilleri Biçimlendirme**

İşte üç bağlama tipi seçeneği:

* Yuvarlak
* Köşe
* Pala

Varsayılan olarak PowerPoint, iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Yuvarlak** ayarını kullanır. Ancak, keskin açılarla bir şekil çiziyorsanız **Köşe** seçeneğini tercih edebilirsiniz.

![Sunumdaki bağlama stili](join-style-powerpoint.png)

Aşağıdaki Java kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round bağlama tipi ayarlarıyla nasıl oluşturulduğunu gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
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

    // Çizgi genişliğini ayarla.
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

    // Bağlama stilini ayarla.
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

## **Gradyan Dolgu**

PowerPoint’te Gradyan Dolgu, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin diğerine yavaşça karıştığı şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değerini `Gradient` olarak ayarlayın.
1. [IGradientFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igradientformat/) arabiriminin sunduğu gradyan durak koleksiyonunun `add` metodlarıyla iki tercih ettiğiniz rengi ve konumlarını ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu, bir elipse gradyan dolgu etkisi nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekle.
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

![Gradyan dolgu ile elips](gradient-fill.png)

## **Desen Dolgu**

PowerPoint’te Desen Dolgu, iki renkli bir tasarım (nokta, çizgi, çapraz çizgi veya kare gibi) bir şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45’den fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra bile kullanılacak kesin renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değerini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/patternformat/#getBackColor--) özelliğini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/patternformat/#getForeColor--) özelliğini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu, bir dikdörtgene desen dolgu nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma türünü Pattern olarak ayarla.
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

![Desenli dolgu ile dikdörtgen](pattern-fill.png)

## **Resim Dolgu**

PowerPoint’te Resim Dolgu, bir şeklin içine bir görüntü yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; yani görüntüyü şeklin arka planı olarak kullanır.

Aspose.Slides kullanarak bir şekle resim dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değerini `Picture` olarak ayarlayın.
1. Resim dolgu kipini `Tile` (veya tercih ettiğiniz başka bir kip) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.setImage` metoduna aktarın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Şu resme sahip bir “lotus.png” dosyamız olduğunu varsayalım:

![Lotus resmi](lotus.png)

Aşağıdaki Java kodu, bir şekle resim dolgu nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Doldurma türünü Picture olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Resim dolgu kipini ayarla.
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

![Resim dolgu ile şekil](picture-fill.png)

### **Resmi Doku Olarak Döşeme**

Döşeme davranışını özelleştirerek bir resmi doku olarak ayarlamak isterseniz, aşağıdaki [IPictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/) arabirimi ve [PictureFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/picturefillformat/) sınıfının yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Resim dolgu kipini `Tile` veya `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Döşemelerin şekil içinde hizalanmasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Döşemenin şeklin orijininden yatay kaydırmasını (point cinsinden) ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Döşemenin şeklin orijininden dikey kaydırmasını (point cinsinden) ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşemeli bir resim dolgulu dikdörtgen şekli ekleyip döşeme seçeneklerini yapılandırmayı gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Bir dikdörtgen otomatik şekil ekle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin doldurma türünü Picture olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Görüntüyü yükle ve sunum kaynaklarına ekle.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Görüntüyü şekle ata.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Resim dolgu kipini ve döşeme özelliklerini yapılandır.
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

## **Katı Renk Dolgu**

PowerPoint’te Katı Renk Dolgu, bir şekli tek bir, tekdüze renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku veya desen olmaksızın uygulanır.

Aspose.Slides kullanarak bir şekle katı renk dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
1. Şekle tercih ettiğiniz dolgu rengini atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Java kodu, bir PowerPoint slaydındaki bir dikdörtgene katı renk dolgu nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma türünü Solid olarak ayarla.
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

![Katı renk dolgu ile şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint’te bir şekle katı renk, gradyan, resim veya doku dolgusu uyguladığınızda, dolgunun opaklığını kontrol etmek için şeffaflık seviyesini de ayarlayabilirsiniz. Yüksek şeffaflık değeri, şeklin arka planı veya alt nesneleri kısmen görünür hâle getirir.

Aspose.Slides, dolgu için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
1. `Color` sınıfını kullanarak alfa bileşeni şeffaflığı kontrol eden bir renk tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir dikdörtgene şeffaf dolgu rengi nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Katı bir dikdörtgen otomatik şekil ekle.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Katı şeklin üzerine saydam bir dikdörtgen otomatik şekil ekle.
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

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarıyla konumlandırırken faydalı olabilir.

Bir slayttaki bir şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir şekli 5 derece döndürmeyi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
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

## **3B Kırma Efekti Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3B kırma efektleri uygulamanızı sağlar.

Bir şekle 3B kırma efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini başlatın.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) özelliğini yapılandırarak kırma ayarlarını tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir şekle 3B kırma efektleri nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![3B kırma efekti](3D-bevel-effect.png)

## **3B Döndürme Efekti Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanızı sağlar.

Bir şekle 3B döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ekleyin.
1. 3B döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icamera/#setCameraType-int-) ve [setLightType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilightrig/#setLightType-int-) metodlarını kullanın.
1. Sunumu kaydedin.

Aşağıdaki Java kodu, bir şekle 3B döndürme efektleri nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;

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

![3B döndürme efekti](3D-rotation-effect.png)

## **Şekiller için Siyah-Beyaz Renderlamayı Kontrol Etme**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) yöntemi, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendğinde bireysel bir şeklin nasıl renderlanacağını belirler. Bu yöntem tek başına siyah-beyaz görüntülemeyi etkinleştirmez ve normal renk modundaki şeklin dolgu, çizgi veya diğer biçimlendirmelerini değiştirmez.

İstenilen davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/blackwhitemode/) sınıfından bir değer kullanın. Örneğin, `Automatic` dönüşümün uygulama tarafından seçilmesini sağlar, `Gray` ve `LightGray` gri renklendirme yapar, `BlackWhite` sadece siyah ve beyaz kullanır, `Black` ve `White` tek renk zorlar, `Color` normal renkleri korur ve `Hidden` şekli siyah-beyaz modunda gizler. `NotDefined` ise şekil seviyesinde bir mod atanmadığını gösterir.

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

    // Turuncu dolguyu renk modunda tut, ancak şekli siyah-beyaz modunda gri renkyle renderle.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normal renk modunda dikdörtgen turuncu dolgusunu korur. Siyah-beyaz görüntüleme iş akışında, modu `Gray` olarak ayarlandığı için gri renklendirme kullanılır. Bu sayede tam renkli bir slaytı korurken, yazdırma, ön izleme veya sunumun siyah-beyaz görüntüleme ayarlarını dikkate alan diğer iş akışları için farklı bir görünüm tanımlayabilirsiniz.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini nasıl sıfırlayacağınızı ve [LayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına nasıl geri getireceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Düzen üzerindeki yer tutucuya sahip slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosya boyutunu etkiler mi?**

Sadece çok az etkiler. Gömülü görüntüler ve medya dosyaları dosya alanının çoğunu oluştururken, renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir boyut katmaz.

**Aynı biçimlendirmeye sahip şekilleri bir slaytta nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stilleri aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, stil yönetimini sonradan basitleştirir.

**Özel şekil stillerinin bir kümesini ayrı bir dosyada saklayıp diğer sunumlarda yeniden kullanabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesi veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stil verilen şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.