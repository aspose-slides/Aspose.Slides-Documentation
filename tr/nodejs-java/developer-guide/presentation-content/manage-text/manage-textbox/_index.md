---
title: JavaScript Kullanarak Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/nodejs-java/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- hiperlink ekle
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js, PowerPoint ve OpenDocument dosyalarında metin kutularını oluşturmayı, düzenlemeyi ve kopyalamayı kolaylaştırarak sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler tipik olarak metin kutularında veya şekillerde bulunur. Bu nedenle bir slayta metin eklemek için bir metin kutusu eklemeniz ve ardından metni metin kutusunun içine yerleştirmeniz gerekir. Aspose.Slides for Node.js via Java, bazı metin içeren bir şekil eklemenizi sağlayan [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) sınıfını sunar.

{{% alert title="Info" color="info" %}}
Aspose.Slides ayrıca slaytlara şekil eklemenizi sağlayan [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape) sınıfını da sunar. Ancak, `Shape` sınıfı aracılığıyla eklenen tüm şekiller metin tutamaz. Fakat [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) sınıfı aracılığıyla eklenen şekiller metin içerebilir.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Bu nedenle, metin eklemek istediğiniz bir şekille çalışırken, onun `AutoShape` sınıfı aracılığıyla oluşturulduğunu kontrol edip doğrulamak isteyebilirsiniz. Ancak o zaman `AutoShape` altında bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame) ile çalışabilirsiniz. Bu sayfadaki [Update Text](https://docs.aspose.com/slides/tr/nodejs-java/manage-textbox/#update-text) bölümüne bakın.
{{% /alert %}}

## **Slayta Metin Kutusu Oluşturma**

Bir slayta metin kutusu oluşturmak için şu adımları izleyin:

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Yeni oluşturulan sunumdaki ilk slayt için bir referans alın.  
3. Slayt üzerinde belirtilen bir konuma `Rectangle` olarak ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) ile bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) nesnesi ekleyin ve yeni eklenen `AutoShape` nesnesi için referansı alın.  
4. `AutoShape` nesnesine metin içerecek bir `TextFrame` özelliği ekleyin. Aşağıdaki örnekte şu metni ekledik: *Aspose TextBox*  
5. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla yazın.  

Bu JavaScript kodu—yukarıdaki adımların bir uygulaması—size bir slayta metin eklemenin nasıl yapılacağını gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation nesnesini oluşturur
var pres = new aspose.slides.Presentation();
try {
    // Sunumdaki ilk slaytı alır
    var sld = pres.getSlides().get_Item(0);
    // Türü Rectangle olarak ayarlanmış bir AutoShape ekler
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Rectangle'a TextFrame ekler
    ashp.addTextFrame(" ");
    // Metin çerçevesine erişir
    var txtFrame = ashp.getTextFrame();
    // Metin çerçevesi için Paragraph nesnesini oluşturur
    var para = txtFrame.getParagraphs().get_Item(0);
    // Paragraf için Portion nesnesi oluşturur
    var portion = para.getPortions().get_Item(0);
    // Metni ayarlar
    portion.setText("Aspose TextBox");
    // Sunumu diske kaydeder
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Metin Kutusu Şekli Kontrolü**

Aspose.Slides, şekilleri incelemenize ve metin kutularını tanımlamanıza olanak tanıyan [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) sınıfının [isTextBox](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/#isTextBox) metodunu sunar.

![Metin kutusu ve şekil](istextbox.png)

Bu JavaScript kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Şunu unutmayın: eğer bir autoshape'i yalnızca [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/) sınıfının `addAutoShape` metodu ile eklerseniz, autoshape'in `isTextBox` metodu `false` dönecektir. Ancak, autoshape'e `addTextFrame` metodu veya `setText` metodu ile metin ekledikten sonra, `isTextBox` özelliği `true` döner.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() false döner
shape1.addTextFrame("shape 1");
// shape1.isTextBox() true döner

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() false döner
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() true döner

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() false döner
shape3.addTextFrame("");
// shape3.isTextBox() false döner

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() false döner
shape4.getTextFrame().setText("");
// shape4.isTextBox() false döner
```

## **Bir Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodunda, içinde bulunduğu sunum nesnesini bilmeksizin bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) alabilirsiniz. Sahibi olan [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) nesnesine geri dönmek için [TextFrame.getParentShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentShape--) metodunu kullanın.

[AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) veya başka bir metin içeren şekle ait bir metin çerçevesi için, [TextFrame.getParentShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentShape--) sahibi döndürür ve [TextFrame.getParentCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParentCell--) `null` döndürür. Her iki yöntem de yalnızca okuma amaçlı gezinme sağlar; bu yüzden çağrılmaları sahipliği değiştirmez. Şekle erişmeden önce dönen değerin `null` olup olmadığını her zaman kontrol edin.

Şekil ve tablo hücresi sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de tanımlayan eksiksiz bir örnek için, [Search and Replace Text](/slides/tr/nodejs-java/search-and-replace-text/) bölümüne bakın.

## **Metin Kutusuna Sütun Ekleme**

Aspose.Slides, metin kutularına sütun eklemenizi sağlayan [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat) sınıfının [setColumnCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) ve [setColumnSpacing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) metodlarını sunar. Metin kutusundaki sütun sayısını belirleyebilir ve sütunlar arasındaki boşluğu puan cinsinden ayarlayabilirsiniz.

Bu JavaScript kodu açıklanan işlemi gösterir: 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Sunumdaki ilk slaytı alır
    var slide = pres.getSlides().get_Item(0);
    // Türü Rectangle olarak ayarlanmış bir AutoShape ekler
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Rectangle'a TextFrame ekler
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
    // TextFrame'in metin biçimini alır
    var format = aShape.getTextFrame().getTextFrameFormat();
    // TextFrame içindeki sütun sayısını belirler
    format.setColumnCount(3);
    // Sütunlar arasındaki boşluğu belirler
    format.setColumnSpacing(10);
    // Sunumu kaydeder
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Metin Çerçevesine Sütun Ekleme**

Aspose.Slides for Node.js via Java, metin çerçevelerine sütun eklemenizi sağlayan [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat) sınıfının [setColumnCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) metodunu sunar. Bu özellik sayesinde bir metin çerçevesinde istediğiniz sütun sayısını belirtebilirsiniz.

Bu JavaScript kodu, bir metin çerçevesine nasıl sütun ekleyeceğinizi gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Sütun boşluğu hiç ayarlanmamıştı, bu yüzden NaN olarak raporlanıyor.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Metni Güncelleme**

Aspose.Slides, bir metin kutusundaki ya da bir sunumdaki tüm metinleri değiştirmenize veya güncellemenize olanak tanır. 

Bu JavaScript kodu, bir sunumdaki tüm metinlerin nasıl güncellendiğini veya değiştirildiğini gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Şeklin metin çerçevesini (IAutoShape) destekleyip desteklemediğini kontrol eder.
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Metin çerçevesindeki paragraflar üzerinde döner
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Paragraftaki her bölümü iterasyonla dolaşır
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Metni değiştirir
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Biçimlendirmeyi değiştirir
                    }
                }
            }
        }
    }
    // Değiştirilmiş sunumu kaydeder
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bağlantılı Metin Kutusu Ekleme** 

Bir metin kutusunun içine bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında, kullanıcılar bağlantıyı açmaya yönlendirilir. 

Bağlantı içeren bir metin kutusu eklemek için şu adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun.  
2. Yeni oluşturulan sunumdaki ilk slayt için bir referans alın.  
3. Slayt üzerinde belirtilen bir konuma `Rectangle` olarak ayarlanmış `ShapeType` ile bir `AutoShape` nesnesi ekleyin ve yeni eklenen AutoShape nesnesi için referans alın.  
4. `AutoShape` nesnesine bir `TextFrame` ekleyin ve ilk bölümünün metnini ayarlayın. Aşağıdaki örnekte şu metni kullandık: *Aspose.Slides*  
5. Bu bölümün `PortionFormat`ı aracılığıyla `HyperlinkManager`'ını alın.  
6. `HyperlinkManager` üzerinde `setExternalHyperlinkClick` metodunu çağırarak bağlantıyı bölüme ekleyin.  
7. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla yazın.  

Bu JavaScript kodu—yukarıdaki adımların bir uygulaması—size bir slayta bağlantılı bir metin kutusu eklemenin nasıl yapılacağını gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// PPTX'i temsil eden bir Presentation sınıfı örneği oluşturur
var pres = new aspose.slides.Presentation();
try {
    // Sunumdaki ilk slaytı alır
    var slide = pres.getSlides().get_Item(0);
    // Türü Rectangle olarak ayarlanmış bir AutoShape nesnesi ekler
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Şekli AutoShape tipine dönüştürür
    var pptxAutoShape = shape;
    // AutoShape ile ilişkili ITextFrame özelliğine erişir
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Çerçeveye bazı metinler ekler
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Bölüm metni için Hipervizyonu ayarlar
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // PPTX Sunumunu kaydeder
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Bir master slaytla çalışırken bir metin kutusu ile bir metin yer tutucu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/nodejs-java/manage-placeholder/) stil/konumu [master](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) dan devralır ve [layouts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) üzerinde geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve düzenleri değiştirdiğinizde değişmez.

**Sunumdaki metinleri, grafikler, tablolar ve SmartArt içindeki metinlere dokunmadan toplu olarak nasıl değiştirebilirim?**

İterasyonunuzu sadece metin çerçevelerine sahip otomatik şekillerle sınırlayın ve gömülü nesneleri ([charts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartart/)) ayrı ayrı koleksiyonlarını dolaşarak veya bu nesne türlerini atlayarak dışarıda bırakın.