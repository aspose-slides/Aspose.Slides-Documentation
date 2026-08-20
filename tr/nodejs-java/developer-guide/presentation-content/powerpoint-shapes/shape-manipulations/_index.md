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
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil düzen biçimleri
- Şekil SVG olarak
- Şekli SVG'ye dönüştür
- şekli hizala
- şekli çevir
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile sunum şekillerini tanımlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java şekilleri bir slaytta sıralı bir [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yer ve yığın sırasının kaynağıdır: indeks `0` en arka şekildir, son indeks ise en önteki şekildir.

Bu makale bu modeli takip eder. Öncelikle bir şekli güvenilir bir şekilde nasıl tanımlayacağınızı açıklar, ardından şekilleri kopyalama, kaldırma, gizleme ve yeniden sıralama gösterilir. Son bölümler düzen seviyesinde biçimlendirme, SVG dışa aktarımı, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece yalnızca iş akışınızın gerektirdiği işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken kullanışlıdır, ancak kararlı tanımlayıcılar değildir. Bir şekli eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve yönetildiğine göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getname/) geliştirici kontrolündeki şablonlar için yararlıdır ve PowerPoint'in Seçim Çubuğu'nda incelemesi kolaydır. İsimler düzenlenebilir ve benzersiz olması garanti edilmez; bu yüzden kodun onlara dayanması durumunda bir adlandırma standardı oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getalternativetext/) bir erişilebilirlik açıklaması veya yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa yararlıdır. Kullanıcılar tarafından görülür, yerelleştirilebilir veya erişilebilirlik amaçlı yeniden yazılabilir ve benzersiz olduğu garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) yalnızca bir slayt içinde benzersiz olan, PowerPoint interop'unda kullanılan şekil kimliğine karşılık gelen salt okunur bir tanımlayıcıdır. PowerPoint ile entegrasyon yaparken veya bir şeklin ömrü boyunca belirsiz olmayan bir referansa ihtiyacınız olduğunda kullanın. Kopyalanmış veya yeniden oluşturulmuş bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [getUniqueId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getuniqueid/) yöntemi sunum kapsamlı bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak kullanılmamalıdır. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, tam bir karşılaştırma ile isimle arama yapar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde kod, yanlış nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil türüne özgüyse, tip‑özel üyelere erişmeden önce çalışma zamanı sınıfını kontrol edin. Bu örnek, adlandırılmış nesne bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ise yalnızca metni ve alternatif metni günceller.

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

## **Şekil Koleksiyonunu Değiştirme**

Ekle, kopyala, kaldır ve yeniden sırala metodları koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını veya sırasını değiştiriyorsa, o işlemden önce yakalanan indekslere güvenmeye devam etmeyin.

### **Bir Şekli Kopyala**

[addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [insertClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/insertclone/) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler kopyayı boyutunu değiştirmeden taşır; genişlik ve yükseklik kabul eden aşırı yüklemeler ise yeniden boyutlandırabilir.

Örnek bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arkaya ekler. Her iki kopyadaki değişiklikler kaynak şekli etkilemez.

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

Kopyalama, şeklin içeriğini ve biçimlendirmesini, isim ve alternatif metin dahil, kopyalar. Bu değerlerin benzersiz olması gerektiğinde kopyaya yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliği olur.

### **Şekilleri Kaldır**

[remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli yineleme sırasında birden fazla eşleşmeyi kaldırırken, kalan indekslerin geçerli kalması için sondan başa doğru dolaşın.

Bu örnek, belirli bir isimle her şekli kaldırır. Şekli mevcut indekste okur ve belirli bir şekil türü varsaymaz.

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

Kaldırma sonrası şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere yapılan referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca kaldırılan nesneye başvuran bağlayıcılar, animasyonlar ve diğer sunum özelliklerini de göz önünde bulundurun; görünen bir şekli kaldırmak slaydın görünümünden fazlasını değiştirebilir.

### **Bir Şekli Gizle**

[Hidden](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/sethidden/) özelliğini `true` yaparak şekil koleksiyonda kalır ancak normal slayt gösterisinde görünmez. İndeksi, biçimlendirmesi ve içeriği koda hâlâ erişilebilir, bu yüzden isterse yeniden ortaya çıkarılabilecek isteğe bağlı öğeler için gizleme uygundur.

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

Gizleme bir silme ya da güvenlik işlemi değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından gizliliği kaldırılabilir ve sunum dosyasının parçası olarak kalır.

### **Z‑Order Değiştir**

Üst üste binen şekiller koleksiyon sırasına göre çizilir. [reorder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/reorder/) mevcut bir şekli kopyalamadan hedef bir indeks'e taşır. İndeks `0` arka; `size() - 1` ön.

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

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında durur. Son indekse taşındığında öne gelir. İlgili tüm şekiller eklenip kopyalandıktan sonra z‑order'ı sonlandırın, çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, normal bir slaytta benzer konumda olan şekil ile aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getfillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getlineformat/) özelliklerini, her şeklin bir `AutoShape` olduğu varsayımı olmadan okur.

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

Bir düzenin düzenlenmesi, onu kullanan birden fazla slaytı etkileyebilir. Bir düzen şekli değiştirmeden önce, normal bir slaydın nesneyi devralıp devralmadığını veya yerel bir geçersiz kılma içerip içermediğini belirleyin ve o düzeni kullanan tüm slaytları test edin.

## **Bir Şekli SVG Olarak Dışa Aktar**

[writeAsSvg](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/writeassvg/) bir şeklin işlenmiş içeriğini bir akıma yazar. Sonuç, şekli içerir; tüm slayt arka planını veya komşu şekilleri içermez.

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

Sunumu render ederken açık tutun. Çıktı şeklin biçimlendirmesine ve yazı tipleri ve resimler gibi kaynaklara bağlıdır. Bütün kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Çağıran akımı kontrol eder ve kapatmalıdır.

## **Şekilleri Hizala**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/alignshapes/) aşırı yüklemeleri ya tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapesalignmenttype/) kenarı, merkez çizgiyi veya dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları kullanılır; `false` yaparsanız seçili şekiller birbirine göre hizalanır.

Bu örnek üç şekli slaytın üst kenarına hizalar. Döndürülen şekil referansları, hizalamadan hemen önce mevcut indekslerine dönüştürülür.

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

Hizalama konumları değiştirir, z‑order'ı değil. Göreli hizalama genellikle en az iki şekil gerektirir, yatay veya dikey dağıtım ise boşluk tanımlamak için yeterli şekle ihtiyaç duyar. Metodu çağırmadan önce koleksiyonu değiştirirseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevir**

[ShapeFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ile dönüşü saklar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` devre dışı, `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki sunumda bir çevirilmemiş şekil vardır.

![Çevirme öncesi şekil](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu, yeni bir [Frame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/setframe/) atandığında çerçevenin tamamının değişmesi nedeniyle önemlidir.

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

Kaydedilen şekil konum, boyut ve dönüşü korurken yatay ve dikey olarak yansıtılır.

![Çevirme sonrası şekil](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcısı olarak koleksiyon indeksini kullanmalı mıyım?**

Sadece koleksiyon işlem sırasında değişmeyecek kısa ömürlü işlemler için. Oluşturulmuş şablonlar için doğrulanmış bir `Name` veya `AlternativeText` standardını, slayt kapsamlı interop çalışmaları için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek z‑order'ı kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Neden kopyalanan bir şekil diğer bir şeklin önünde göründü?**

`addClone` kopyayı koleksiyonun sonuna ekler; bu z‑order'ın ön kısmıdır. Başlangıç indeksini seçmek için `insertClone` kullanın veya tüm şekiller eklendikten sonra `reorder` yapın.