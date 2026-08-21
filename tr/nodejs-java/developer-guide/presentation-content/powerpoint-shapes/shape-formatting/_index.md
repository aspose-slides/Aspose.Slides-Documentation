---
title: JavaScript'te PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/nodejs-java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- şekil çizgi eskizi
- eklem stili biçimlendirme
- degrade doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil şeffaflığı
- siyah-beyaz şekil renderlaması
- gri tonlamalı şekil renderlaması
- şekil döndürme
- 3D kırıntı efekti
- 3D döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides kullanarak JavaScript'te PowerPoint şekillerini biçimlendirin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekiller ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerine etkiler uygulayarak veya değiştirerek bunları biçimlendirebilirsiniz. Ayrıca, şekillerin içlerinin nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![PowerPoint'ta şekil biçimlendirme](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java, PowerPoint'ta mevcut aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [çizgi stili](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi kalınlığını ayarlayın.
1. Çizgi [çizgi dash stili](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şekil için çizgi rengini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod bir dikdörtgen `AutoShape`'ın nasıl biçimlendirileceğini gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin doldurmasını kaldır.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Dikdörtgenin çizgilerine biçimlendirme uygula.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Dikdörtgenin çizgi rengi ayarla.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // PPTX dosyasını diske kaydet.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Şekil Çizgilerine Eskiz Efektleri Uygula**

Eskiz efekti, bir şekil çizgisinin elle çizilmiş görünmesini sağlar. Çizgi ayarlarına erişmek için [Shape.getLineFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) metodunu, eskiz ayarlarına erişmek için [LineFormat.getSketchFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/lineformat/) metodunu ve [SketchFormat.setSketchType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sketchformat/) aracılığıyla [LineSketchType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linesketchtype/) sayımından bir değer seçebilirsiniz.

Aşağıdaki JavaScript kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linesketchtype/) etkisini nasıl uygulayacağınızı, açıkça atanan değeri okuduğunuzu ve [LineSketchType.None](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linesketchtype/) ile efekti nasıl kaldıracağınızı gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi biçimine ve onun eskiz biçimine eriş.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Bir eskiz efekti uygula.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Şekle doğrudan atanan eskiz efektini oku.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Eskiz efektini kaldır.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sketchformat/) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir tema, ana slayt ya da düzen slaytından devralınabiliyorsa, [LineFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/lineformat/) metodunu kullanın, döndürülen nesnede `getSketchFormat` metodunu çağırın ve ardından `getSketchType` metodunu çağırın. Etkin değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

## **Eklem Stillerini Biçimlendir**

İşte üç eklem tipi seçeneği:

* Round
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Round** ayarını kullanır. Ancak, keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki eklem stili](join-style-powerpoint.png)

Aşağıdaki JavaScript kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round eklem tipi ayarları kullanılarak nasıl oluşturulduğunu gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde üç otomatik şekil ekle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Her dikdörtgen şeklinin doldurma rengini ayarla.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Çizgi kalınlığını ayarla.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Her dikdörtgenin çizgi rengini ayarla.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Eklem stilini ayarla.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Her dikdörtgene metin ekle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX dosyasını diske kaydet.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Degrade Doldurma**

PowerPoint'te Gradient Doldurma, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, bir rengin diğerine yavaşça karıştığı iki ya da daha fazla rengi uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle degrade doldurma uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. Gradient durak koleksiyonunun `add` metodlarını kullanarak tanımlı konumlarla iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Elips'e degrade biçimlendirme uygula.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Degradenin yönünü ayarla.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // İki degrade durak ekle.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // PPTX dosyasını diske kaydet.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Degrade doldurulmuş elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint'te Pattern Fill, bir şekle iki renkli bir tasarım—örneğin noktalar, çizgiler, çapraz çizgiler veya kareler—uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön planı ve arka planı için özel renkler seçebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'in üzerindeki ön tanımlı desen stilini sunar. Ön tanımlı bir deseni seçtikten sonra, kullanılacak kesin renkleri hâlâ belirleyebilirsiniz.

Desen doldurmayı uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/patternformat/#getBackColor--) özelliğini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/patternformat/#getForeColor--) özelliğini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma tipini Pattern olarak ayarla.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Desen stilini ayarla.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Desenin arka plan ve ön plan renklerini ayarla.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX dosyasını diske kaydet.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Desen doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'te Picture Fill, bir şeklin içine bir görüntü yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir—görüntüyü şeklin arka planı gibi kullanır.

Resim doldurmayı uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.setImage` metoduna aktarın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

![Lotus resmi](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Doldurma tipini Picture olarak ayarla.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Resim doldurma modunu ayarla.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Bir görüntü yükle ve sunum kaynaklarına ekle.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Resmi ayarla.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX dosyasını diske kaydet.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Resim doldurulmuş şekil](picture-fill.png)

### **Döşeme Resmini Doku Olarak Kullanma**

Döşeme bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek isterseniz, [PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) sınıfının aşağıdaki metodlarını kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim doldurma modunu — `Tile` ya da `Stretch` — ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Şekil içinde döşemelerin hizalamasını belirtir.
- [setTileFlip](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Şeklin başlangıç noktasından döşemenin yatay ofsetini (nokta olarak) ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Şeklin başlangıç noktasından döşemenin dikey ofsetini (nokta olarak) ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı al.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Bir dikdörtgen otomatik şekil ekle.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin doldurma tipini Picture olarak ayarla.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Görüntüyü yükle ve sunum kaynaklarına ekle.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Görüntüyü şekle ata.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Resim doldurma modunu ve döşeme özelliklerini yapılandır.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // PPTX dosyasını diske kaydet.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Döşeme seçenekleri](tile-options.png)

## **Katı Renk Doldurma**

PowerPoint'te Solid Color Fill, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, hiçbir degrade, doku veya desen olmaksızın uygulanır.

Aspose.Slides kullanarak bir şekle katı renk doldurma uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şekle tercih ettiğiniz doldurma rengini atayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Doldurma tipini Solid olarak ayarla.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Doldurma rengini ayarla.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX dosyasını diske kaydet.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Katı renk doldurulmuş şekil](solid-color-fill.png)

## **Şeffaflık Ayarla**

PowerPoint'te bir şekle katı renk, degrade, resim veya doku doldurduğunuzda, doldurmanın opaklığını kontrol etmek için bir şeffaflık seviyesi de ayarlayabilirsiniz. Daha yüksek şeffaflık değeri şekli daha geçirgen yapar, arka planın veya alt nesnelerin kısmen görünmesini sağlar.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` kullanarak şeffaflık içeren bir renk tanımlayın (alpha bileşeni şeffaflığı kontrol eder).
1. Sunumu kaydedin.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Katı bir dikdörtgen otomatik şekil ekle.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekle.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // PPTX dosyasını diske kaydet.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndür**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarıyla konumlandırırken yararlı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin döndürme özelliğini istenen açıya ayarlayın.
1. Sunumu kaydedin.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndür.
    shape.setRotation(5);

    // PPTX dosyasını diske kaydet.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Şekil döndürülmesi](shape-rotation.png)

## **3D Kırıntı Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D kırıntı efektleri eklemenizi sağlar.

3D kırıntı efektleri eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) özelliğini yapılandırarak kırıntı ayarlarını tanımlayın.
1. Sunumu kaydedin.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation sınıfının bir örneğini oluştur.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Slayta bir şekil ekle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Şeklin ThreeDFormat özelliklerini ayarla.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Sunumu PPTX dosyası olarak kaydet.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![3B kırıntı efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D döndürme efektleri eklemenizi sağlar.

3D döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. 3D döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/camera/#setCameraType) ve [setLightType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/lightrig/#setLightType) metodlarını kullanın.
1. Sunumu kaydedin.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation sınıfının bir örneğini oluştur.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Sunumu PPTX dosyası olarak kaydet.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![3B döndürme efekti](3D-rotation-effect.png)

## **Şekiller İçin Siyah‑Beyaz Renderlamayı Kontrol Et**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) yöntemi, bir sunum siyah‑beyaz modunda görüntülendiğinde veya işlendiğinde tek bir şeklin nasıl renderlanacağını belirler. Bu yöntem yalnızca siyah‑beyaz görüntülemeyi etkinleştirmez ve normal renk modunda şeklin doldurmasını, çizgisini veya diğer biçimlendirmesini değiştirmez.

İstenen davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/blackwhitemode/) sayımından bir değer kullanın. Örneğin, `Automatic` renderlama uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri renkleme kullanır, `BlackWhite` sadece siyah ve beyaz kullanır, `Black` ve `White` tek bir rengi zorlar, `Color` normal renklendirmeyi korur ve `Hidden` şekli siyah‑beyaz modunda gizler. `NotDefined` ise şekil düzeyinde bir mod atanmadığını gösterir.

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

    // Turuncu doldurmayı renk modunda tut, ancak şekli siyah-beyaz modunda gri renkle renderle.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normal renk modunda dikdörtgen turuncu doldurmasını korur. Siyah‑beyaz gösterim akışında ise modu `Gray` olduğu için gri renklendirme kullanır. Bu sayede tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah‑beyaz gösterim ayarlarını dikkate alan diğer akışlar için farklı bir görünüm tanımlayabilirsiniz.

## **Biçimlendirmeyi Sıfırla**

Aşağıdaki JavaScript kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) üzerindeki yer tutuculara sahip tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürmeyi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Slayttaki, düzen üzerindeki yer tutucuya sahip her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosya alanının çoğunu oluşturur, şekil parametreleri (renkler, efektler, degradeler) meta veri olarak saklanır ve neredeyse hiç ek boyut eklemez.

**Bir slaytta aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerini ayrı bir dosyada saklayıp diğer sunumlarda yeniden kullanabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt dosyasında ya da .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stillendirilmiş şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.