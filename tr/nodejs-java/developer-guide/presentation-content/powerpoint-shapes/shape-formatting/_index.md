---
title: JavaScript'te PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/nodejs-java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- birleşim stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- katı renk dolgu
- şekil şeffaflığı
- şekli döndürme
- 3d koni efekti
- 3d döndürme efekti
- biçimlendirmeyi sıfırlama
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript kullanarak Aspose.Slides ile PowerPoint şekillerini biçimlendirin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassas ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint’te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenarlarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin içini doldurmayı kontrol eden ayarları belirterek de şekilleri biçimlendirebilirsiniz.

![şekil‑biçimlendirme‑powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java, PowerPoint’te mevcut aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıf ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü özetler:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [line style](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linestyle/) özelliğini ayarlayın.
5. Çizgi kalınlığını belirleyin.
6. Çizginin [dash style](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/linedashstyle/) özelliğini ayarlayın.
7. Şeklin çizgi rengini belirleyin.
8. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen `AutoShape` nasıl biçimlendirilir gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin dolgu rengini ayarlayın.
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

![sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Kavrama Stilini Biçimlendirme**

Üç kavrama türü seçeneği vardır:

* Round
* Miter
* Bevel

PowerPoint, iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken varsayılan olarak **Round** ayarını kullanır. Ancak keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![sunumdaki kavrama stili](join-style-powerpoint.png)

Aşağıdaki JavaScript kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round kavrama ayarlarıyla nasıl oluşturulduğunu gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde üç otomatik şekil ekleyin.
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

    // Çizgi kalınlığını ayarlayın.
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

    // Kavrama stilini ayarlayın.
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

## **Gradyan Dolgu**

PowerPoint’te Gradyan Dolgu, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin iki veya daha fazla rengi, birinin yavaşça diğerine karıştığı şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulamanın yolu:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
5. [GradientFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/gradientformat/) sınıfı tarafından sunulan gradyan durak koleksiyonunun `add` yöntemleriyle istediğiniz iki rengi ve konumlarını ekleyin.
6. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki JavaScript kodu, bir elips üzerine gradyan dolgu efekti nasıl uygulanır gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Ellipse türünde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Elipse gradyan biçimlendirmesi uygulayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Gradyanın yönünü ayarlayın.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // İki gradyan durağı ekleyin.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // PPTX dosyasını diske kaydedin.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![gradyan dolgu uygulanmış elips](gradient-fill.png)

## **Desen Dolgu**

PowerPoint’te Desen Dolgu, bir şekle iki renkli bir tasarım (nokta, şerit, çapraz çizgi veya kare gibi) uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön planı ve arka planı için özel renkler seçebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45’ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra, kullanılacak kesin renkleri yine belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulamanın yolu:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
5. Ön tanımlı seçeneklerden bir desen stili seçin.
6. Desenin [Background Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/patternformat/#getBackColor--) özelliğini ayarlayın.
7. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/patternformat/#getForeColor--) özelliğini ayarlayın.
8. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki JavaScript kodu, bir dikdörtgene desen dolgu nasıl uygulanır gösterir:

```js
    // Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
    let presentation = new aspose.slides.Presentation();
    try {
        // İlk slaytı alın.
        let slide = presentation.getSlides().get_Item(0);

        // Rectangle türünde bir otomatik şekil ekleyin.
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

        // Dolgu tipini Pattern olarak ayarlayın.
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

![desen dolgu uygulanmış dikdörtgen](pattern-fill.png)

## **Resim Dolgu**

PowerPoint’te Resim Dolgu, bir şeklin içine bir resim yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; yani resmi şeklin arka planı olarak kullanırsınız.

Aspose.Slides kullanarak bir şekle resim dolgu uygulamanın yolu:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
5. Resim dolgu modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
6. Kullanmak istediğiniz görüntüden bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesi oluşturun.
7. Görüntüyü `ISlidesPicture.setImage` yöntemine aktarın.
8. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki resim “lotus.png” dosyasını göstermektedir:

![lotus resmi](lotus.png)

Aşağıdaki JavaScript kodu, bir şekle resim dolgu nasıl uygulanır gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Dolgu tipini Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Resim dolgu modunu ayarlayın.
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

![resim dolgulu şekil](picture-fill.png)

### **Doku Olarak Döşeme Resmi**

Döşeme bir resmi doku olarak ayarlayıp döşeme davranışını özelleştirmek istiyorsanız, [PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) sınıfının aşağıdaki yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim dolgu modunu `Tile` veya `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Döşemelerin şekil içinde hizalanmasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Döşemenin yatay ofsetini (point cinsinden) şeklin orijininden ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Döşemenin dikey ofsetini (point cinsinden) şeklin orijininden ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşeme bir resim dolgu içeren bir dikdörtgen şekil ekleyip döşeme seçeneklerini yapılandırmayı gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Bir dikdörtgen otomatik şekil ekleyin.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Şeklin dolgu tipini Picture olarak ayarlayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Görüntüyü yükleyin ve sunum kaynaklarına ekleyin.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Görüntüyü şekle atayın.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Resim dolgu modunu ve döşeme özelliklerini yapılandırın.
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

![döşeme seçenekleri](tile-options.png)

## **Katı Renk Dolgu**

PowerPoint’te Katı Renk Dolgu, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle katı renk dolgu uygulamak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
5. İstediğiniz dolgu rengini şekle atayın.
6. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki JavaScript kodu, bir PowerPoint slaytındaki dikdörtgene katı renk dolgu nasıl uygulanır gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Solid olarak ayarlayın.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Dolgu rengini ayarlayın.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX dosyasını diske kaydedin.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![katı renk dolgulu şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint’te bir şekle katı renk, gradyan, resim veya doku dolgu uyguladığınızda, dolgunun saydamlık seviyesini de ayarlayabilirsiniz. Daha yüksek şeffaflık değeri, şekli daha geçirgen yapar ve arka planın ya da alttaki nesnelerin kısmen görünmesini sağlar.

Aspose.Slides, dolgu için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
5. Şeffaflığı olan bir renk tanımlamak için `Color` sınıfını kullanın (alpha bileşeni şeffaflığı kontrol eder).
6. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir dikdörtgene şeffaf dolgu rengi nasıl uygulanır gösterir:

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

![şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama ya da tasarım gereksinimlerine göre konumlandırırken faydalı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.
5. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir şekli 5 derece nasıl döndürülür gösterir:

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slaytı alın.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
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

![şekil döndürme](shape-rotation.png)

## **3D Koni Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B koni efektleri uygulamanızı sağlar.

Bir şekle 3B koni efektleri eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini başlatın.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) özelliğini koni ayarlarını tanımlayacak şekilde yapılandırın.
5. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir şekle 3B koni efektleri nasıl uygulanır gösterir:

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

    // Sunumu bir PPTX dosyası olarak kaydedin.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![3B koni efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanızı sağlar.

Bir şekle 3B döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. 3B döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/camera/#setCameraType) ve [setLightType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/lightrig/#setLightType) yöntemlerini kullanın.
5. Sunumu kaydedin.

Aşağıdaki JavaScript kodu, bir şekle 3B döndürme efektleri nasıl uygulanır gösterir:

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

    // Sunumu bir PPTX dosyası olarak kaydedin.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![3B döndürme efekti](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini sıfırlayarak [LayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürür:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Düzen üzerindeki yer tutucuya sahip slayttaki her şekli sıfırla.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosyasının boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosya alanının büyük kısmını oluşturur; renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve neredeyse hiç ek boyut oluşturmaz.

**Aynı biçimlendirmeye sahip şekilleri bir slaytta nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı kabul edip bu şekilleri mantıksal olarak gruplayabilirsiniz; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerini ayrı bir dosyada depolayıp başka sunumlarda yeniden kullanabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesinde ya da .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri klonlayın ve gerekli yerlerde biçimlendirmeyi yeniden uygulayın.