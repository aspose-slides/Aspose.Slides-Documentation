---
title: JavaScript'te Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/nodejs-java/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekli kopyalama
- şekli kaldırma
- şekli gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini alma
- şekil alternatif metni
- şekil ayar noktası
- önceden ayarlanmış şekil ayarı
- şekil geometrisi
- şekil düzen formatları
- Şekil SVG olarak
- Şekli SVG'ye
- şekli hizalama
- şekli çevirme
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile sunum şekillerini tanımlamayı, ayarlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, bir slayttaki şekilleri sıralı bir [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yer olduğu gibi, yığın sırasının kaynağıdır: indeks `0` en arkadaki şekli, son indeks ise en öndeki şekli gösterir.

Bu makale bu modeli izler. Öncelikle bir şekli güvenilir bir şekilde nasıl tanımlayacağınızı ve önceden ayarlanmış şekil ayar noktalarını nasıl değiştireceğinizi açıklar, ardından şekilleri nasıl kopyalayacağınızı, kaldıracağınızı, gizleyeceğinizi ve yeniden sıralayacağınızı gösterir. Son bölümler, düzen seviyesi biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece iş akışınızın gerektirdiği işlemleri yalnızca kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri, bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve yönetildiğine göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getname/) geliştiricinin kontrol ettiği şablonlar için kullanışlıdır ve PowerPoint'in Seçim Bölmesi'nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz olması garanti edilmez, bu yüzden kod bu isimlere bağımlıysa bir adlandırma kuralları oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getalternativetext/) erişilebilirlik açıklaması ya da yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa faydalıdır. Kullanıcılara görünür, yerelleştirilebilir ya da erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak yeniden kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) yalnızca bir slayt içinde benzersiz, salt okunur bir tanımlayıcıdır ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyduğunuzda kullanın. Kopyalanan ya da yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [getUniqueId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getuniqueid/) yöntemi sunum kapsamlı bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak kullanılmamalıdır. Uzun vadeli kimliklendirme kritikse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, tam bir karşılaştırma yaparak isme göre arama gerçekleştirir ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde, kod hatalı nesneyle devam etmek yerine bu sonucu raporlar.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Bir işlem belirli bir şekil türüne özgü ise, tür‑özel üyeleri kullanmadan önce çalışma zaman sınıfını kontrol edin. Bu örnek, adlandırılmış nesne bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ise metni ve alternatif metni günceller.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Önceden Ayarlanmış Şekil Ayarlarını Tanımlama ve Değiştirme**

Önceden ayarlanmış geometrik şekiller, köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayar noktaları sunabilir. Bu noktalara salt okunur [GeometryShape.getAdjustments](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/geometryshape/) koleksiyonu üzerinden erişin. Koleksiyon şekil tarafından sağlanır, ancak her [AdjustValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/) değiştirilebilen bir değer içerir.

Yalnızca sabit bir koleksiyon indeksine dayanmayın. Ayarları döngüyle gezerek salt okunur [getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/) metodunu inceleyin; bu metodun döndürdüğü [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapeadjustmenttype/) değeri, ayarın neyi kontrol ettiğini tanımlar. Salt okunur [getName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/getname/) metodu ek tanımlama bilgisi sunar ve aynı anlamsal tipe sahip birden fazla ayar bulunduğunda özellikle yararlıdır.

Ayara uygun değeri değiştirmek için aşağıdaki yöntemleri kullanın:

| Ayarlama tipi | Amaç | Değiştirilecek Değer |
|---|---|---|
| `CornerSize` | Yuvarlak köşelerin boyutu | [setRawValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Ok kuyruğunun kalınlığı | `setRawValue` |
| `ArrowheadLength` | Ok başının uzunluğu | `setRawValue` |
| `ArrowheadWidth` | Ok başının genişliği | `setRawValue` |
| `StartAngle` | Dilim ya da yay başlangıç açısı | [setAngleValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Dilim ya da yay bitiş açısı | `setAngleValue` |

`getType` ve `getName` salt okunur bilgileri döndürür. `getRawValue` ve `setRawValue`, önceden ayarlanmış şeklin yerel geometri birimlerinde bir tamsayıyla çalışırken, `getAngleValue` ve `setAngleValue` derece cinsinden bir açıyla çalışır. Ayarların sayısı, sırası, anlamı ve geçerli aralığı, önceden ayarlanmış [GeometryShape.getShapeType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/geometryshape/) değerine bağlıdır. Bir önceden ayarlanmış için geçerli bir değer, başka bir önceden ayarlanmış için geçersiz olabilir ya da farklı bir etki oluşturabilir.

`getType` `ShapeAdjustmentType.Custom` döndürdüğünde API standart bir anlamsal anlamı tanımaz. `getName`, önceden ayarlanmış tipi ve mevcut değeri inceleyin ve beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan tipler için bile aynı tip birden fazla kez göründüğünde bir değer seçmeden önce kontrol edin. [Connector](/slides/tr/nodejs-java/connector/) makalesi, bağlayıcı bükülme ayarlarıyla bu durumu gösterir.

Aşağıdaki tam örnek, üç önceden ayarlanmış şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarı döngüyle gezerek adını ve tipini raporlar, boyutla ilgili değerleri `setRawValue` ile, açıları `setAngleValue` ile değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometriyi, sağ sütun ise ayarlanmış yuvarlak dikdörtgeni, dört yönlü oku ve dilimi gösterir.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Varsayılan ve ayarlanmış şekil sütunları için başlıklar ekler.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Değeri değiştirmeden önce anlamsal tipi kontrol etmek, kodun amacını açıkça ortaya koyar ve aynı koleksiyon indeksinin farklı önceden ayarlanmış şekillerde aynı anlama gelmesini varsaymaktan kaçınır.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, kopyala, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında etkili olur. Bir işlem şekil sayısını ya da sırasını değiştiriyorsa, o işlemden önce yakalanmış indekslere güvenmeye devam etmeyin.

### **Bir Şekli Kopyalama**

[addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [insertClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/insertclone/) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler klonu boyutunu değiştirmeden taşırken, genişlik ve yükseklik kabul eden aşırı yüklemeler yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arka tarafa ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klonlama, şeklin içeriğini ve biçimlendirmesini, ismini ve alternatif metnini de kopyalar. Bu değerlerin benzersiz olması gerektiğinde klona yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak klon yeni bir koleksiyon öğesi ve yeni bir şekil kimliği olur.

### **Şekilleri Kaldırma**

[remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli döngü sırasında birden fazla eşleşme kaldırıyorsanız, indekslerin geçerli kalmasını sağlamak için sondan geriye doğru dolaşın.

Bu örnek, belirli bir isme sahip her şekli kaldırır. Şekli mevcut indekste okur ve belirli bir şekil tipini varsaymaz.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaldırma sonrasında şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere referanslar, kaydedilmiş indekslerden daha güvenilirdir. Bağlayıcılar, animasyonlar ve kaldırılan nesneye başvuran diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şeklin kaldırılması slaydın görünümünden daha fazlasını etkileyebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/sethidden/) özelliğini `true` olarak ayarlamak, şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeksi, biçimi ve içeriği kod tarafından kullanılabilir, bu yüzden gizleme, daha sonra geri getirilebilecek isteğe bağlı öğeler için uygundur.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gizleme silme ya da güvenlik değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından tekrar görünür hâle getirilebilir; ayrıca sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste gelen şekiller koleksiyon sırasına göre çizilir. [reorder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/reorder/) mevcut bir şekli klonlamadan hedef bir indekse taşır. İndeks `0` arka, `size() - 1` ön demektir.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında durur. Son indekse taşındığında ön tarafa gelir. Tüm ilgili şekilleri ekledikten ya da kopyaladıktan sonra z‑sırasını kesin, çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığılımı değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytların ayrı şekil koleksiyonları vardır. Bir düzen koleksiyonundaki şekil, aynı konumda bir normal slayttaki şekil ile aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak ya da değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getfillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getlineformat/) öğesini, her şeklin bir `AutoShape` olduğunu varsaymadan okur.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Bir düzeni düzenlemek, onu kullanan birden çok slaytı etkileyebilir. Bir düzen şekli değiştirmeden önce, normal bir slaydın nesneyi devralıp devralmadığını ya da yerel bir geçersiz kılma içerip içermediğini belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[writeAsSvg](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/writeassvg/) bir şeklin işlenmiş içeriğini bir akıma yazar. Sonuç, bütün slayt arka planı ya da yan komşu şekiller olmadan yalnızca şekli içerir.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Sunumu render ederken açık tutun. Çıktı, şeklin biçimlendirmesine ve fontlar ile görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Akımı çağıran taraf sahiplenir ve kapatmalıdır.

## **Şekilleri Hizalama**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/alignshapes/) aşırı yüklemeleri, ya tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapesalignmenttype/) kenar, merkez çizgisi ya da dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarlarını, `false` yaparsanız seçili şekilleri birbirlerine göre hizalarsınız.

Bu örnek, üç şekli slaytın üst kenarına hizalar. Dönen şekil referansları, hizalama öncesinde mevcut indekslerine dönüştürülür.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hizalama konumları değiştirir, z‑sırasını değil. Göreli hizalama genellikle en az iki şekil gerektirirken, yatay ya da dikey dağıtım yeterli aralık tanımlamak için birden çok şekil gerekir. Yöntemi çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ve dönüşü saklar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` çevirme devre dışı, `NotDefined` tanımsız/varsayılan durumu korur.

Aşağıdaki giriş sunumu, çevirilmemiş bir şekil içerir.

![The shape before flipping](shape_to_be_flipped.png)

Bu örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/setframe/) atamak tüm çerçeveyi değiştirir.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen şekil, konumunu, boyutunu ve dönüşünü korurken yatay ve dikey olarak aynalanır.

![The shape after flipping](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcısı olarak koleksiyon indeksi kullanmalı mıyım?**

Yalnızca koleksiyonun indeks kullanılmadan önce değişmeyeceği kısa vadeli işlemler için. Oluşturulmuş şablonlar için doğrulanmış bir `Name` veya `AlternativeText` kuralı, slayt kapsamlı interop çalışması için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek, onu z‑sırasından kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir ya da tekrar görünür hâle getirilebilir.

**Neden bir kopyalanan şekil başka bir şeklin önünde belirdi?**

`addClone` klonu koleksiyonun sonuna ekler; bu, z‑sırasının ön tarafıdır. Başlangıç indeksini seçmek için `insertClone` kullanın ya da tüm şekiller eklendikten sonra `reorder` ile konumlandırın.

**Önceden ayarlanmış bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Yalnızca kesin önceden ayarlanmış ve koleksiyon düzeni doğrulandıysa. `GeometryShape.getAdjustments` üzerinde dönüp `AdjustValue.getType` kontrol etmeyi tercih edin; aynı anlamsal tip birden çok kez ortaya çıkıyorsa ek bilgi için `AdjustValue.getName` kullanın.