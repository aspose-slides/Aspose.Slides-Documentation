---
title: JavaScript'te PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/nodejs-java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- çizim efekti
- şekil çizgi skeç efekti
- eklem stili biçimlendirme
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- düz renk doldurma
- şekil şeffaflığı
- şekil döndürme
- 3b kenar efekti
- 3b döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides kullanarak JavaScript'te PowerPoint şekillerini biçimlendirin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'ta slaytlara şekiller ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerini değiştirerek veya onlara efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin iç kısımlarının nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java, PowerPoint'ta mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenize olanak tanıyan sınıflar ve yöntemler sağlar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi kalınlığını ayarlayın.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şekil için çizgi rengini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen `AutoShape` nasıl biçimlendirilir gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin doldurma rengini ayarlayın.
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

Bir çizim efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [Shape.getLineFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) kullanın, çizim ayarlarına erişmek için [LineFormat.getSketchFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/lineformat/) kullanın ve [SketchFormat.setSketchType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sketchformat/) ile [LineSketchType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linesketchtype/) enum değerlerinden birini seçin.

Aşağıdaki JavaScript kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linesketchtype/) etkisinin nasıl uygulanacağını, açıkça atanmış değerinin nasıl okunacağını ve [LineSketchType.None](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linesketchtype/) ile etkisinin nasıl kaldırılacağını gösterir:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Shape'in çizgi formatına ve çizim formatına erişin.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Bir çizim efekti uygulayın.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Şekle doğrudan atanmış çizim efektini okuyun.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Çizim efektini kaldırın.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sketchformat/) tarafından döndürülen değer, doğrudan shape'e atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaytından devralınabiliyorsa, [LineFormat.getEffective](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/lineformat/) kullanın, döndürülen nesne üzerinde `getSketchFormat` çağırın ve ardından `getSketchType` metodunu çağırın. Etkili değer, devralma çözüldükten sonra gerçekten uygulanan biçimlendirmeyi yansıtır:

```js
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

## **Eklem Stilleri Biçimlendirme**

Üç eklem tipi seçeneği şunlardır:

* Round
* Miter
* Bevel

PowerPoint varsayılan olarak iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Round** ayarını kullanır. Ancak keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki eklem stili](join-style-powerpoint.png)

Aşağıdaki JavaScript kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round eklem tipi ayarlarıyla nasıl oluşturulduğunu gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle tipinde üç otomatik şekil ekleyin.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Her dikdörtgen şeklinin doldurma rengini ayarlayın.
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

    // Eklem stilini ayarlayın.
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

PowerPoint'ta Gradyan Doldurma, bir şekle sürekli bir renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin diğerine yavaşça karıştığı bir şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan doldurma uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [GradientFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/gradientformat/) sınıfı tarafından sunulan gradyan durak koleksiyonunun `add` yöntemleriyle tanımlı konumlarda iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki JavaScript kodu, bir elipse gradyan doldurma etkisinin nasıl uygulanacağını gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Ellipse'e gradyan biçimlendirme uygulayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Gradyanın yönünü ayarlayın.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // İki gradyan durak ekleyin.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Gradyan doldurmalı elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint'ta Desen Doldurma, iki renkli bir tasarımı—örneğin nokta, çizgi, çapraz çizgi veya kare—şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumunuzun görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sunar. Önceden tanımlı bir deseni seçtikten sonra, hâlâ kullanılacak kesin renkleri belirtebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Önceden tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/patternformat/#getBackColor--) özelliğini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/patternformat/#getForeColor--) özelliğini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki JavaScript kodu, bir dikdörtgene desen doldurma nasıl uygulanacağını gösterir:

```js
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

![Desen doldurmalı dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'ta Resim Doldurma, bir resmi şeklin içine yerleştirmenizi sağlar—dolayısıyla resmi şeklin arka planı olarak kullanır.

Aspose.Slides kullanarak bir şekle resim doldurma uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüyü temsil eden bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesi oluşturun.
1. Görüntüyü `ISlidesPicture.setImage` metoduna geçirin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Örneğin aşağıdaki "lotus.png" dosyasını kullanalım:

![Lotus resmi](lotus.png)

Aşağıdaki JavaScript kodu, bir şekle resim doldurma nasıl uygulanacağını gösterir:

```js
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

![Resim doldurmalı şekil](picture-fill.png)

### **Desen Olarak Döşeme Resmi**

Döşeme bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) sınıfının aşağıdaki yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim doldurma modunu `Tile` veya `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Döşemelerin şekil içindeki hizalamasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Döşemenin şeklin orijinden (puan cinsinden) yatay ofsetini ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Döşemenin şeklin orijinden (puan cinsinden) dikey ofsetini ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşeme bir resim doldurmasıyla bir dikdörtgen şekli eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

```js
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

    // Resim doldurma modunu ve döşeme özelliklerini yapılandırın.
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

![Döşeme seçenekleri](tile-options.png)

## **Düz Renk Doldurma**

PowerPoint'ta Düz Renk Doldurma, bir şekli tek bir, tekdüz renk ile dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, hiçbir gradyan, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk doldurma uygulamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. İstediğiniz doldurma rengini şekle atayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki JavaScript kodu, bir PowerPoint slaytındaki bir dikdörtgene düz renk doldurma nasıl uygulanacağını gösterir:

```js
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

![Düz renk doldurmalı şekil](solid-color-fill.png)

## **Şeffaflığı Ayarlama**

PowerPoint'ta bir şekle düz renk, gradyan, resim veya doku doldurması uyguladığınızda, doldurmanın opaklığını kontrol etmek için şeffaflık düzeyini de ayarlayabilirsiniz. Daha yüksek bir şeffaflık değeri, şeklin daha geçirgen olmasını sağlar; arka plan veya alt nesneler kısmen görünür hâle gelir.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` kullanarak şeffaflığı olan bir renk tanımlayın (alpha bileşeni şeffaflığı kontrol eder).
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir dikdörtgene şeffaf bir doldurma rengi nasıl uygulanacağını gösterir:

```js
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

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenize olanak tanır. Bu, görsel öğeleri belirli hizalama veya tasarım gereksinimleriyle konumlandırırken faydalı olabilir.

Bir slayttaki bir şekli döndürmek için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin döndürme özelliğini istenen açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir şekli 5 derece döndürmeyi gösterir:

```js
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

![Şekil dönüşü](shape-rotation.png)

## **3B Kenar Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B kenar efektleri uygulamanıza izin verir.

Bir şekle 3B kenar efektleri eklemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) özelliğini kenar ayarlarını tanımlamak için yapılandırın.
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir şekle 3B kenar efektleri nasıl uygulanacağını gösterir:

```js
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

![3B kenar efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza izin verir.

Bir şekle 3B döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
1. 3B döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/camera/#setCameraType) ve [setLightType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/lightrig/#setLightType) yöntemlerini kullanın.
1. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir şekle 3B döndürme efektleri nasıl uygulanacağını gösterir:

```js
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

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) üzerindeki yer tutucularla olan tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına geri döndürmeyi gösterir:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Düzeninde yer tutucu bulunan slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi final sunum dosya boyutunu etkiler mi?**

Sadece çok az etkiler. Gömülü görüntüler ve medya dosyaları dosyanın çoğunlukta yerini alırken, renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir boyut eklemez.

**Bir slayttaki aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa stillerini aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerinin bir setini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesi veya .POTX şablon dosyası içinde saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan biçimlendirilmiş şekilleri klonlayın ve gerektiği yerde biçimlendirmeyi yeniden uygulayın.