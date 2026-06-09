---
title: Sunumlarda JavaScript Kullanarak Metin Kutularını Yönetme
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
- köprü ekle
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js, PowerPoint ve OpenDocument dosyalarında metin kutularını oluşturmayı, düzenlemeyi ve kopyalamayı kolaylaştırarak sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler genellikle metin kutularında veya şekillerde bulunur. Bu nedenle, bir slayta metin eklemek için bir metin kutusu eklemeniz ve ardından metin kutusunun içine bazı metinler yerleştirmeniz gerekir. Aspose.Slides for Node.js via Java, bazı metin içeren bir şekil eklemenizi sağlayan [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) sınıfını sunar.

{{% alert title="Info" color="info" %}}
Aspose.Slides ayrıca slaytlara şekil eklemenizi sağlayan [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape) sınıfını da sunar. Ancak, `Shape` sınıfı aracılığıyla eklenen tüm şekiller metin tutamaz. Fakat [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) sınıfı aracılığıyla eklenen şekiller metin içerebilir.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Bu nedenle, bir şekle metin eklemek istediğinizde, şeklin `AutoShape` sınıfı aracılığıyla oluşturulup oluşturulmadığını kontrol edip onaylamak isteyebilirsiniz. Ancak o zaman `AutoShape` altında bir özelliktir olan [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame) ile çalışabilirsiniz. Bu sayfadaki [Update Text](https://docs.aspose.com/slides/tr/nodejs-java/manage-textbox/#update-text) bölümüne bakın.
{{% /alert %}}

## **Slayta Metin Kutusu Oluşturma**

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Yeni oluşturulan sunumda ilk slayta bir referans alın.  
3. Slayt üzerinde belirli bir konumda `Rectangle` olarak ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) ile bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) nesnesi ekleyin ve yeni eklenen `AutoShape` nesnesi için referans alın.  
4. `AutoShape` nesnesine bir `TextFrame` özelliği ekleyin; bu özellik bir metin içerecek. Aşağıdaki örnekte bu metni ekledik: *Aspose TextBox*  
5. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla yazın.  

Bu JavaScript kodu—yukarıdaki adımların bir uygulaması—size bir slayta nasıl metin ekleyeceğinizi gösterir:

```javascript
// Sunumu örnekler
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
    // Metin çerçevesi için Paragraph nesnesi oluşturur
    var para = txtFrame.getParagraphs().get_Item(0);
    // Paragraph için Portion nesnesi oluşturur
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

Aspose.Slides, şekilleri incelemenizi ve metin kutularını tanımlamanızı sağlayan [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) sınıfından [isTextBox](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/#isTextBox) metodunu sunar.

![Metin kutusu ve şekil](istextbox.png)

Bu JavaScript kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Şunu unutmayın: [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/) sınıfındaki `addAutoShape` yöntemiyle bir autoshape eklediğinizde, autoshape'in `isTextBox` metodu `false` dönecektir. Ancak, autoshape'e `addTextFrame` yöntemiyle ya da `setText` yöntemiyle metin ekledikten sonra, `isTextBox` özelliği `true` döner.

```javascript
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

## **Metin Kutusuna Sütun Ekleme**

Aspose.Slides, metin kutularına sütun eklemenizi sağlayan [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat) sınıfından [setColumnCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) ve [setColumnSpacing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) metodlarını sunar. Bir metin kutusundaki sütun sayısını belirleyebilir ve sütunlar arasındaki boşluğu puan cinsinden ayarlayabilirsiniz.

JavaScript'teki bu kod, açıklanan işlemi gösterir: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunumdaki ilk slaytı alır
    var slide = pres.getSlides().get_Item(0);
    // Türü Rectangle olarak ayarlanmış bir AutoShape ekler
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Rectangle'a TextFrame ekler
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // TextFrame’in metin biçimini alır
    var format = aShape.getTextFrame().getTextFrameFormat();
    // TextFrame içinde sütun sayısını belirler
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

Aspose.Slides for Node.js via Java, metin çerçevelerine sütun eklemenizi sağlayan [TextFrameFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat) sınıfından [setColumnCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) metodunu sunar. Bu özellik sayesinde bir metin çerçevesinde istediğiniz sütun sayısını belirtebilirsiniz.

Bu JavaScript kodu, bir metin çerçevesine nasıl sütun ekleyeceğinizi gösterir:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

Aspose.Slides, bir metin kutusundaki ya da bir sunumdaki tüm metinleri değiştirme veya güncelleme imkanı verir.

Bu JavaScript kodu, bir sunumdaki tüm metinlerin nasıl güncelleneceğini veya değiştirileceğini gösterir:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Şeklin metin çerçevesini (IAutoShape) destekleyip desteklemediğini kontrol eder.
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Metin çerçevesindeki paragrafları iterasyonla dolaşır
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

## **Köprülü Metin Kutusu Ekleme** 

Bir metin kutusunun içinde bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında, kullanıcılar bağlantıyı açmaya yönlendirilir. 

Bağlantı içeren bir metin kutusu eklemek için şu adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun.  
2. Yeni oluşturulan sunumda ilk slayta bir referans alın.  
3. Slayt üzerinde belirli bir konumda `Rectangle` olarak ayarlanmış `ShapeType` ile bir `AutoShape` nesnesi ekleyin ve yeni eklenen AutoShape nesnesi için bir referans alın.  
4. `AutoShape` nesnesine, varsayılan metni *Aspose TextBox* olan bir `TextFrame` ekleyin.  
5. `HyperlinkManager` sınıfının bir örneğini oluşturun.  
6. `HyperlinkManager` nesnesini, `TextFrame` içinde istediğiniz bölüme bağlı [HyperlinkClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) özelliğine atayın.  
7. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla yazın. 

Bu JavaScript kodu—yukarıdaki adımların bir uygulaması—size bir slayta köprülü bir metin kutusu nasıl ekleyeceğinizi gösterir:

```javascript
// PPTX'i temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // Sunumdaki ilk slaytı alır
    var slide = pres.getSlides().get_Item(0);
    // Türü Rectangle olarak ayarlanmış bir AutoShape nesnesi ekler
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Şekli AutoShape olarak dönüştürür
    var pptxAutoShape = shape;
    // AutoShape ile ilişkili ITextFrame özelliğine erişir
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Çerçeveye bazı metinler ekler
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Bölüm metni için Köprüyü ayarlar
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // PPTX sunumunu kaydeder
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Ana slaytlarla çalışırken bir metin kutusu ile bir metin yer tutucusu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/nodejs-java/manage-placeholder/), [master](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/masterslide/) üzerinden stilleri/konumunu devralır ve [layout](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/)larda geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve layout değiştirdiğinizde değişmez.

**Grafikler, tablolar ve SmartArt içindeki metinlere dokunmadan sunum genelinde toplu bir metin değiştirme nasıl yapabilirim?**

İterasyonunuzu yalnızca metin çerçevelerine sahip autoshape'lerle sınırlayın ve gömülü nesneleri ([chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/), [table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartart/)) ayrı ayrı koleksiyonlarını dolaşarak veya bu nesne türlerini atlayarak dışarıda bırakın.