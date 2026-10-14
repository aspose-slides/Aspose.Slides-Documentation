---
title: JavaScript'te PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/nodejs-java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- taslak efekti
- şekil çizgisi taslağı
- birleşim stili biçimlendirme
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil şeffaflığı
- siyah-beyaz şekil işleme
- gri tonlamalı şekil işleme
- şekil döndürme
- 3d koni efekti
- 3d döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides kullanarak JavaScript'te PowerPoint şekillerini biçimlendirin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'ta slaytlara şekiller ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerine etkiler uygulayarak veya değiştirerek biçimlendirebilirsiniz. Ayrıca, iç doldurulmalarını kontrol eden ayarları belirterek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java, PowerPoint'ta mevcut aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. İşlem adımları aşağıda sıralanmıştır:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [çizgi stili](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) ayarlayın.
1. Çizgi genişliğini ayarlayın.
1. Çizginin [çizgi dash stili](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) ayarlayın.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod bir dikdörtgen `AutoShape`'ın nasıl biçimlendirileceğini gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin doldurmasını kaldırın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Dikdörtgenin çizgilerine biçimlendirme uygulayın.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Dikdörtgenin çizgi rengini ayarlayın.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // PPTX dosyasını diske kaydedin.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Şekil Çizgilerine Çizim Efektleri Uygulama**

Bir çizim efekti, şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), çizim ayarlarına erişmek için [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/), ve [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) kullanarak [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) enumerasyonundan bir değer seçebilirsiniz.

Aşağıdaki JavaScript kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) etkisinin nasıl uygulanacağını, açıkça atanmış değerin nasıl okunacağını ve [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) ile etkisinin nasıl kaldırılacağını gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi biçimi ve taslak biçimine erişin.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Bir taslak efekti uygulayın.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Şekle doğrudan atanmış taslak efektini okuyun.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Taslak efektini kaldırın.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) tarafından döndürülen değer, doğrudan şekle atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaytından miras alınabiliyorsa, [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) kullanın, döndürülen nesnede `getSketchFormat` çağırın ve ardından `getSketchType` metodunu çağırın. Etkili değer, miras çözülüp uygulanan gerçek biçimlendirmeyi yansıtır:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Köşe Stilleri Biçimlendirme**

Aşağıda üç birleşim tipi seçeneği bulunmaktadır:

* Round
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Round** ayarını kullanır. Ancak, keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki birleşim stili](join-style-powerpoint.png)

Aşağıdaki JavaScript kodu, yukarıdaki görüntüde gösterilen üç dikdörtgenin Miter, Bevel ve Round birleşim tipi ayarlarıyla nasıl oluşturulduğunu gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde üç otomatik şekil ekleyin.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Her dikdörtgen şeklinin dolgu rengini ayarlayın.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Çizgi genişliğini ayarlayın.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Her dikdörtgenin çizgi rengini ayarlayın.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Birleşim stilini ayarlayın.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Her dikdörtgene metin ekleyin.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX dosyasını diske kaydedin.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradyan Doldurma**

PowerPoint'ta Gradyan Doldurma, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin diğerine yavaşça karıştığı şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/) sınıfı tarafından sağlanan gradyan durak koleksiyonunun `add` metodlarıyla tanımlı konumlarda iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki JavaScript kodu bir elipse gradyan doldurma efekti uygulamayı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipseye gradyan biçimlendirmesi uygulayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Gradyanın yönünü ayarlayın.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // İki gradyan durak noktasını ekleyin.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gradyan doldurulmuş elips](gradient-fill.png)

Eğer bir gradyan dışa aktarılan bir görüntüde PowerPoint'takinden farklı görünüyorsa, [Choose a Gradient Rendering Style](/slides/tr/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Sunumda saklanan gradyan doldurmayı değiştirmeden bir işleme stili seçebilirsiniz.

## **Desen Doldurma**

PowerPoint'ta Desen Doldurma, iki renkli bir tasarım—nokta, çizgi, çapraz çizgi veya kare gibi—şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini isteğe göre belirleyebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra, kullanılacak tam renkleri hâlâ belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) ayarını yapın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) ayarını yapın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki JavaScript kodu bir dikdörtgene desen doldurma uygulamayı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma türünü Pattern olarak ayarlayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Desen stilini ayarlayın.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Desenin arka plan ve ön plan renklerini ayarlayın.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX dosyasını diske kaydedin.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Desen doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'ta Resim Doldurma, bir şeklin içine bir görüntü yerleştirerek resmi şeklin arka planı olarak kullanmanızı sağlayan bir biçimlendirme seçeneğidir.

Aspose.Slides kullanarak bir şekle resim doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.setImage` metoduna aktarın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Şöyle bir "lotus.png" dosyamız olduğunu varsayalım:

![Lotus resmi](lotus.png)

Aşağıdaki JavaScript kodu bir şekle resmi doldurma uygulamayı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Doldurma türünü Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Resim doldurma modunu ayarlayın.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Bir görüntü yükleyin ve sunum kaynaklarına ekleyin.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Resmi ayarlayın.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX dosyasını diske kaydedin.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Resim doldurulmuş şekil](picture-fill.png)

### **Karo Resmi Doku Olarak**

Karo resmi bir doku olarak ayarlamak ve karolama davranışını özelleştirmek isterseniz, [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) sınıfının aşağıdaki yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim doldurma modunu `Tile` veya `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Karoların şekil içinde hizalamasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Karonun yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Karonun şeklin başlangıcından (puan cinsinden) yatay ofsetini ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Karonun şeklin başlangıcından (puan cinsinden) dikey ofsetini ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Karonun yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Karonun dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekline karo resim doldurma ekleyip karo seçeneklerini yapılandırmayı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Bir dikdörtgen otomatik şekil ekleyin.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin doldurma türünü Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Görüntüyü yükleyin ve sunum kaynaklarına ekleyin.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Görüntüyü şekle atayın.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Resim doldurma modunu ve karolama özelliklerini yapılandırın.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // PPTX dosyasını diske kaydedin.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Karo seçenekleri](tile-options.png)

## **Katı Renk Doldurma**

PowerPoint'ta Katı Renk Doldurma, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku veya desen olmaksızın uygulanır.

Aspose.Slides kullanarak bir şekle katı renk doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şekle tercih ettiğiniz doldurma rengini atayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki JavaScript kodu bir dikdörtgene katı renk doldurma uygulamayı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma türünü Solid olarak ayarlayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Doldurma rengini ayarlayın.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX dosyasını diske kaydedin.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Katı renk doldurulmuş şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint'ta bir şekle katı renk, gradyan, resim veya doku doldurması uyguladığınızda, doldurmanın saydamlık seviyesini ayarlayarak opaklığını kontrol edebilirsiniz. Daha yüksek bir şeffaflık değeri, şeklin arka planını veya alt nesneleri kısmen görünür kılar.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` kullanarak şeffaflığı olan bir renk tanımlayın (`alpha` bileşeni şeffaflığı kontrol eder).
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu bir dikdörtgene şeffaf doldurma rengi uygulamayı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Katı bir dikdörtgen otomatik şekil ekleyin.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekleyin.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // PPTX dosyasını diske kaydedin.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım gereksinimleriyle konumlandırırken yararlı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin dönüşüm özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu bir şekli 5 derece döndürmeyi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndürün.
    shape.setRotation(5);

    // PPTX dosyasını diske kaydedin.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Şekil döndürmesi](shape-rotation.png)

## **3D Koni Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D koni efektleri uygulamanızı sağlar.

Bir şekle 3D koni efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) özelliğini koni ayarlarını tanımlayacak şekilde yapılandırın.
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu bir şekle 3D koni efekti uygulamayı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation sınıfının bir örneğini oluşturun.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Slayta bir şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Şeklin ThreeDFormat özelliklerini ayarlayın.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![3B koni efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D döndürme efektleri uygulamanızı sağlar.

Bir şekle 3D döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) ve [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) metodlarını kullanarak 3D dönüşümü tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu bir şekle 3D döndürme efekti uygulamayı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation sınıfının bir örneğini oluşturun.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![3B döndürme efekti](3D-rotation-effect.png)

## **Şekiller İçin Siyah-Beyaz İşleme Kontrolü**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) yöntemi, bir sunum siyah‑beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl render edileceğini belirtir. Bu yöntem tek başına siyah‑beyaz görüntülemeyi etkinleştirmez ve şeklin normal renk modundaki doldurmasını, çizgisini veya diğer biçimlendirmesini değiştirmez.

[BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) enumerasyonundan bir değer kullanarak istenen davranışı seçin. Örneğin, `Automatic` render uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri tonlamayı kullanır, `BlackWhite` yalnızca siyah ve beyazı, `Black` ve `White` tek bir rengi zorlar, `Color` normal renklemeyi korur ve `Hidden` şekli siyah‑beyaz modunda gizler. `NotDefined` ise şekil‑seviyesi bir mod atanmadığını ifade eder.

Aşağıdaki JavaScript kodu renkli bir şekil oluşturur ve siyah‑beyaz görüntü modunda gri görünmesini sağlar:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Renk modunda turuncu doldurmayı koruyun, ancak siyah-beyaz modunda şekli gri renkle render edin.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normal renk modunda, dikdörtgen turuncu dolgu ile kalır. Siyah‑beyaz görüntü iş akışında, modu `Gray` olarak ayarlandığı için gri renkte görüntülenir. Bu, tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah‑beyaz görüntüleme ayarlarını dikkate alan diğer iş akışları için farklı bir görünüm tanımlamanızı sağlar.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki JavaScript kodu bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına geri döndürmeyi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Yerleşimde bir yer tutucuya sahip slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosyasının boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosya boyutunun çoğunu oluşturur, şekil parametreleri (renkler, efektler, gradyanlar) meta veri olarak saklanır ve neredeyse ek bir boyut eklemez.

**Bir slaytta aynı biçimlendirmeye sahip şekilleri nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stilleri aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, stil yönetimini sonradan basitleştirir.

**Özel şekil stillerinin bir kümesini ayrı bir dosyada saklayıp diğer sunumlarda yeniden kullanabilir miyim?**

Evet. İstenen stillere sahip örnek şekilleri bir şablon slayt destesi veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stillendirilmiş şekilleri kopyalayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.