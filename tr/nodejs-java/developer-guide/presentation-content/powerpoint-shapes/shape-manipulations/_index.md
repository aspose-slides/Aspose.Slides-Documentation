---
title: JavaScript ile Sunum Şekillerini Yönetme
linktitle: Şekil İşleme
type: docs
weight: 40
url: /tr/nodejs-java/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini alma
- şekil alternatif metni
- şekil düzen formatları
- şekil SVG olarak
- şekli SVG'ye dönüştürme
- şekli hizalama
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js via Java kullanarak şekilleri oluşturmayı, düzenlemeyi ve optimize etmeyi öğrenin ve yüksek performanslı PowerPoint sunumları sunun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlardaki şekillerle nasıl çalışılacağını açıklar. Bir slaytta bir şekil bulma, kopyalama, kaldırma, gizleme, sırasını değiştirme, Interop şekil kimliğini alma ve tanımlama ile sonraki işleme yönelik alternatif metin ayarlama konularını gösterir.

Ayrıca şekiller için düzen formatlarına erişim, bir şeklin SVG olarak oluşturulması, slayttaki şekillerin hizalanması ve yatay ve dikey yansıtma için flip özelliklerinin kullanılması da ele alınmaktadır. Ek olarak, şekil birleştirme, yığın sırası ve şekil kilitleme hakkında kısa bir SSS de içerir.

## **Slaytta Şekil Bulma**
Bu konu, geliştiricilerin bir slaytta belirli bir şekli iç kimliğini (Id) kullanmadan bulmasını kolaylaştıran basit bir tekniği açıklayacaktır. PowerPoint sunum dosyalarının bir slayttaki şekilleri iç kimliği (benzersiz Id) dışında tanımlamanın bir yolu olmadığını bilmek önemlidir. Geliştiricilerin iç benzersiz kimliği kullanarak bir şekil bulması zor görünebilir. Slaytlara eklenen tüm şekillerin bir Alt Metni (Alternative Text) vardır. Geliştiricilere, belirli bir şekli bulmak için alternatif metni kullanmalarını öneriyoruz. Gelecekte değiştirmeyi planladığınız nesneler için MS PowerPoint’te alternatif metni tanımlayabilirsiniz.

İstenilen şeklin alternatif metni ayarlandıktan sonra, Aspose.Slides for Node.js via Java kullanarak o sunumu açabilir ve bir slayta eklenen tüm şekiller arasında döngü yapabilirsiniz. Her yinelemede, şeklin alternatif metnini kontrol edebilir ve eşleşen alternatif metne sahip şekil size gereken şekil olacaktır. Bu tekniği daha iyi göstermek için, bir slaytta belirli bir şekli bulup döndüren bir yöntem oluşturduk, [findShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-).

```javascript
// Sunum dosyasını temsil eden bir Presentation sınıfı örnekleyin
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Bulunacak şeklin alternatif metni
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Şekil Kopyalama**
Aspose.Slides for Node.js via Java kullanarak bir slayta şekil kopyalamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İndeksini kullanarak bir slayt referansı alın.  
1. Kaynak slaytın şekil koleksiyonuna erişin.  
1. Sunuma yeni bir slayt ekleyin.  
1. Kaynak slayt şekil koleksiyonundaki şekilleri yeni slayta kopyalayın.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek, bir slayta grup şekli ekler.

```javascript
// Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // PPTX dosyasını diske kaydedin
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekil Kaldırma**
Aspose.Slides for Node.js via Java, geliştiricilerin herhangi bir şekli kaldırmasına olanak tanır. Bir şekli herhangi bir slayttan kaldırmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Belirli bir AlternativeText’e sahip şekli bulun.  
1. Şekli kaldırın.  
1. Dosyayı diske kaydedin.

```javascript
// Presentation nesnesi oluştur
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    // Dikdörtgen türünde otomatik şekil ekle
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Sunumu diske kaydet
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekil Gizleme**
Aspose.Slides for Node.js via Java, geliştiricilerin herhangi bir şekli gizlemesine olanak tanır. Bir şekli herhangi bir slaytta gizlemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Belirli bir AlternativeText’e sahip şekli bulun.  
1. Şekli gizleyin.  
1. Dosyayı diske kaydedin.

```javascript
// PPTX'i temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alın
    var sld = pres.getSlides().get_Item(0);
    // Dikdörtgen türünde otomatik şekil ekle
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Sunumu diske kaydedin
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekil Sırasını Değiştirme**
Aspose.Slides for Node.js via Java, geliştiricilerin şekil sırasını yeniden düzenlemesine olanak tanır. Şekil sırasının değiştirilmesi, hangi şeklin ön planda, hangisinin arka planda olacağını belirler. Bir slayttaki şekilleri yeniden sıralamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Bir şekil ekleyin.  
1. Şeklin metin çerçevesine bir metin ekleyin.  
1. Aynı koordinatlarda başka bir şekil ekleyin.  
1. Şekilleri yeniden sıralayın.  
1. Dosyayı diske kaydedin.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Interop Şekil Kimliğini Alma**
Aspose.Slides for Node.js via Java, geliştiricilerin slayt kapsamındaki benzersiz bir şekil tanımlayıcısını almasına olanak tanır; bu, [getUniqueId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getUniqueId--) metodunun sunum kapsamındaki benzersiz tanımlayıcı elde etmesinden farklıdır. [getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) metodu, [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape) sınıfına eklenmiştir. [getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) metodunun döndürdüğü değer, Microsoft.Office.Interop.PowerPoint.Shape nesnesinin Id değerine karşılık gelir. Aşağıda örnek kod verilmiştir.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Slayt kapsamında benzersiz şekil tanımlayıcısını alıyor
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekil İçin Alternatif Metin Ayarlama**
Aspose.Slides for Node.js via Java, geliştiricilerin herhangi bir şeklin AlternateText (Alternatif Metin) değerini ayarlamasına olanak tanır.
Bir sunumdaki şekiller, [AlternativeText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) veya [Shape Name](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) yöntemiyle ayırt edilebilir.
[setAlternativeText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) ve [getAlternativeText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getAlternativeText--) metodları, Aspose.Slides ve Microsoft PowerPoint tarafından okunup ayarlanabilir.
Bu yöntemi kullanarak bir şekli etiketleyebilir ve Şekil Kaldırma, Şekil Gizleme veya Slaytta Şekil Sırasını Değiştirme gibi farklı işlemler gerçekleştirebilirsiniz.
Bir şeklin AlternateText değerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Slayta herhangi bir şekil ekleyin.  
1. Yeni eklenen şekille bazı işlemler yapın.  
1. Şekiller arasında dolaşarak bir şekil bulun.  
1. AlternativeText değerini ayarlayın.  
1. Dosyayı diske kaydedin.

```javascript
// PPTX'i temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    // Dikdörtgen türünde otomatik şekil ekle
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Sunumu diske kaydet
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekil İçin Düzen Formatlarına Erişim**
Aspose.Slides for Node.js via Java, bir şekil için düzen formatlarına erişim sağlayan basit bir API sunar. Bu makale, düzen formatlarına nasıl erişileceğini göstermektedir.

Aşağıda örnek kod verilmiştir.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekli SVG Olarak Oluşturma**
Artık Aspose.Slides for Node.js via Java, bir şekli SVG olarak oluşturmayı desteklemektedir. [writeAsSvg](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (ve aşırı yüklemesi) metodu, [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape) sınıfına eklenmiştir. Bu yöntem, şeklin içeriğini bir SVG dosyası olarak kaydetmeye olanak tanır. Aşağıdaki kod parçacığı, bir slaydın şeklinin SVG dosyasına dışa aktarılmasını gösterir.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekil Hizalama**
Aspose.Slides, şekilleri ya slayt kenar boşluklarına göre ya da birbirlerine göre hizalamaya olanak tanır. Bu amaçla, aşırı yüklenmiş [SlidesUtil.alignShape()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) yöntemi eklenmiştir. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapesAlignmentType) enum'ı olası hizalama seçeneklerini tanımlar.

**Örnek 1**

Aşağıdaki kaynak kod, 1, 2 ve 4 indisli şekilleri slaydın üst kenarıyla hizalar.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Örnek 2**

Aşağıdaki örnek, şekil koleksiyonundaki en alt şekle göre tüm koleksiyonun nasıl hizalanacağını gösterir.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Flip Özellikleri**

Aspose.Slides içinde, [ShapeFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapeframe/) sınıfı, şekillerin yatay ve dikey yansıtılmasını `flipH` ve `flipV` özellikleri aracılığıyla kontrol eder. Her iki özellik de `byte` tipindedir; `1` değerinde yansıtma, `0` değerinde yansıtma yok ve `-1` değerinde varsayılan davranış kullanılır. Bu değerler, bir şeklin [Frame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getFrame) özelliğinden elde edilebilir.

Flip ayarlarını değiştirmek için, şeklin mevcut konumu ve boyutu, istenen `flipH` ve `flipV` değerleri ve döndürme açısı kullanılarak yeni bir [ShapeFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapeframe/) örneği oluşturulur. Bu örnek şeklin [Frame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getFrame) özelliğine atanıp sunum kaydedildiğinde yansıtma dönüşümleri uygulanır ve çıktı dosyasına yazılır.

Örneğin, aşağıdaki gibi bir sample.pptx dosyamız var ve ilk slayt tek bir şekil içeriyor, varsayılan flip ayarlarıyla:

![The shape to be flipped](shape_to_be_flipped.png)

Aşağıdaki kod örneği, şeklin mevcut flip özelliklerini alır ve hem yatay hem de dikey olarak ters çevirir.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Şeklin yatay yansıma özelliğini alın.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Şeklin dikey yansıma özelliğini alın.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Yatay olarak çevir.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Dikey olarak çevir.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The flipped shape](flipped_shape.png)

## **SSS**

**Bir slaytta şekilleri (birleştirme/kesişme/çıkarma) bir masaüstü editörü gibi birleştirebilir miyim?**

Yerleşik bir Boolean işlem API'si bulunmamaktadır. İstediğiniz konturu kendiniz oluşturup (ör. [GeometryPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/geometrypath/) aracılığıyla sonuç geometrisini hesaplayıp) yeni bir şekil oluşturabilir, isteğe bağlı olarak orijinallerini kaldırabilirsiniz.

**Bir şeklin her zaman “en üstte” kalmasını sağlamak için yığın sırasını (z-order) nasıl kontrol edebilirim?**

Slaytın [shapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getShapes) koleksiyonundaki ekleme/taşıma sırasını değiştirin. Öngörülebilir sonuçlar için, diğer tüm slayt değişikliklerinden sonra z-order'ı sonlandırın.

**PowerPoint’te bir şekli kullanıcıların düzenlemesini engellemek için “kilitleyebilir” miyim?**

Evet. Şekil seviyesinde koruma bayrakları (ör. seçim, hareket, yeniden boyutlandırma, metin düzenlemelerini kilitle) ayarlayabilirsiniz. Gerekirse, bunu master ya da layout üzerinde de uygulayabilirsiniz. Bu, UI düzeyinde bir korumadır, güvenlik özelliği değildir; daha güçlü koruma için dosya düzeyinde sınırlamalar (örn. sadece‑okunur önerileri veya parolalar) ile birleştirilebilir [/slides/tr/nodejs-java/password-protected-presentation/].