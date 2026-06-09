---
title: Android'de Sunumlarda Metin Kutularını Yönet
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/androidjava/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- bağlantı ekle
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java, PowerPoint ve OpenDocument dosyalarında metin kutularını kolayca oluşturmanıza, düzenlemenize ve kopyalamanıza olanak tanır ve sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler genellikle metin kutuları veya şekiller içinde bulunur. Bu nedenle, bir slayta metin eklemek için bir metin kutusu eklemeniz ve ardından metni bu metin kutusunun içine yerleştirmeniz gerekir. Aspose.Slides for Android via Java, bir metin içeren şekil eklemenizi sağlayan [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) arayüzünü sunar.

{{% alert title="Bilgi" color="info" %}}

Aspose.Slides ayrıca slaytlara şekil eklemenizi sağlayan [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape) arayüzünü de sunar. Ancak, `IShape` arayüzüyle eklenen tüm şekiller metin tutamaz. Ancak, [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) arayüzüyle eklenen şekiller metin içerebilir.

{{% /alert %}}

{{% alert title="Not" color="warning" %}} 

Bu nedenle, metin eklemek istediğiniz bir şekille çalışırken, şeklin `IAutoShape` arayüzü üzerinden dönüştürülüp dönüştürülmediğini kontrol edip doğrulamak isteyebilirsiniz. Ancak bu şekilde, `IAutoShape` altında bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextFrame) ile çalışabilirsiniz. Bu sayfadaki [Update Text](https://docs.aspose.com/slides/tr/androidjava/manage-textbox/#update-text) bölümüne bakın.

{{% /alert %}}

## **Bir Slayta Metin Kutusu Oluşturma**

Bir slayta metin kutusu oluşturmak için şu adımları izleyin:

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Yeni oluşturulan sunumun ilk slaytı için bir referans alın.  
3. Slayt üzerindeki belirli bir konumda `Rectangle` olarak ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) ile bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) nesnesi ekleyin ve yeni eklenen `IAutoShape` nesnesinin referansını alın.  
4. `IAutoShape` nesnesine bir metin içerecek `TextFrame` özelliği ekleyin. Aşağıdaki örnekte bu metni ekledik: *Aspose TextBox*  
5. Son olarak, `Presentation` nesnesiyle PPTX dosyasını yazın.  

Bu Java kodu—yukarıdaki adımların uygulanması—bir slayta nasıl metin ekleyeceğinizi gösterir:

```java
// Sunumu oluşturur
Presentation pres = new Presentation();
try {
    // Sunumdaki ilk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);

    // Türü Rectangle olarak ayarlanmış bir AutoShape ekler
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle'a TextFrame ekler
    ashp.addTextFrame(" ");

    // Metin çerçevesine erişir
    ITextFrame txtFrame = ashp.getTextFrame();

    // Metin çerçevesi için Paragraph nesnesi oluşturur
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Paragraf için Portion nesnesi oluşturur
    IPortion portion = para.getPortions().get_Item(0);

    // Metni ayarlar
    portion.setText("Aspose TextBox");

    // Sunumu diske kaydeder
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Metin Kutusu Şekli Kontrolü**

Aspose.Slides, [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) arayüzünden [isTextBox](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#isTextBox--) yöntemini sağlar ve bu sayede şekilleri inceleyip metin kutularını tanımlayabilirsiniz.

![Metin kutusu ve şekil](istextbox.png)

Bu Java kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Şunu unutmayın: [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) arayüzündeki `addAutoShape` yöntemiyle sadece bir otomatik şekil eklediğinizde, otomatik şeklin `isTextBox` yöntemi `false` dönecektir. Ancak, `addTextFrame` yöntemi veya `setText` yöntemiyle otomatik şekle metin ekledikten sonra, `isTextBox` özelliği `true` döner.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() false döndürür
shape1.addTextFrame("shape 1");
// shape1.isTextBox() true döndürür

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() false döndürür
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() true döndürür

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() false döndürür
shape3.addTextFrame("");
// shape3.isTextBox() false döndürür

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() false döndürür
shape4.getTextFrame().setText("");
// shape4.isTextBox() false döndürür
```

## **Metin Kutusuna Sütun Ekleme**

Aspose.Slides, metin kutularına sütun eklemenizi sağlayan [ColumnCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) ve [ColumnSpacing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) özelliklerini ([ITextFrameFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrameFormat) arayüzü ve [TextFrameFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TextFrameFormat) sınıfı aracılığıyla) sunar. Metin kutusundaki sütun sayısını belirleyebilir ve sütunlar arasındaki boşluğu puan cinsinden ayarlayabilirsiniz.

Bu Java kodu, açıklanan işlemi gösterir:

```java
Presentation pres = new Presentation();
try {
    // Sunumdaki ilk slaytı alır
    ISlide slide = pres.getSlides().get_Item(0);

    // Türü Rectangle olarak ayarlanmış bir AutoShape ekler
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Rectangle'a TextFrame ekler
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // TextFrame'in metin formatını alır
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // TextFrame içindeki sütun sayısını belirtir
    format.setColumnCount(3);

    // Sütunlar arasındaki boşluğu belirler
    format.setColumnSpacing(10);

    // Sunumu kaydeder
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Metin Çerçevesine Sütun Ekleme**
Aspose.Slides for Android via Java, metin çerçevelerine sütun eklemenizi sağlayan [ColumnCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) özelliğini ([ITextFrameFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrameFormat) arayüzünden) sunar. Bu özellik sayesinde bir metin çerçevesinde istediğiniz sütun sayısını belirleyebilirsiniz.

Bu Java kodu, bir metin çerçevesine nasıl sütun ekleyeceğinizi gösterir:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Metni Güncelleme**

Aspose.Slides, bir metin kutusundaki veya bir sunumdaki tüm metinleri değiştirme veya güncelleme imkanı sağlar.

Bu Java kodu, bir sunumdaki tüm metinlerin güncellenip değiştirildiği bir işlemi gösterir:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Şeklin metin çerçevesini (IAutoShape) destekleyip desteklemediğini kontrol eder.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Metin çerçevesindeki paragraflar arasında iterasyon yapar
                {
                    for (IPortion portion : paragraph.getPortions()) //Paragraftaki her bölüm (portion) arasında iterasyon yapar
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Metni değiştirir
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Biçimlendirmeyi değiştirir
                    }
                }
            }
        }
    }

    //Değiştirilmiş sunumu kaydeder
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bağlantılı Metin Kutusu Ekleme** 

Bir metin kutusuna bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında kullanıcılar bağlantıyı açmak için yönlendirilir. 

Bağlantı içeren bir metin kutusu eklemek için şu adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun.  
2. Yeni oluşturulan sunumun ilk slaytı için bir referans alın.  
3. Slayt üzerindeki belirli bir konumda `ShapeType`ı `Rectangle` olarak ayarlanmış bir `AutoShape` nesnesi ekleyin ve yeni eklenen AutoShape nesnesinin referansını alın.  
4. `AutoShape` nesnesine, varsayılan metni *Aspose TextBox* olan bir `TextFrame` ekleyin.  
5. `IHyperlinkManager` sınıfının bir örneğini oluşturun.  
6. `IHyperlinkManager` nesnesini, `TextFrame` içinde istediğiniz bölüme bağlı olan [HyperlinkClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) özelliğine atayın.  
7. Son olarak, `Presentation` nesnesiyle PPTX dosyasını yazın.  

Bu Java kodu—yukarıdaki adımların uygulanması—bir slayta bağlantılı metin kutusu nasıl ekleyeceğinizi gösterir:

```java
// Bir PPTX'i temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // Sunumdaki ilk slaytı alır
    ISlide slide = pres.getSlides().get_Item(0);

    // Türü Rectangle olarak ayarlanmış bir AutoShape nesnesi ekler
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Şekli AutoShape tipine dönüştürür
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape ile ilişkili ITextFrame özelliğine erişir
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Çerçeveye bir metin ekler
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Bölüm metni için Hiperviz linkini ayarlar
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // PPTX Sunumunu kaydeder
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Üst slaytlarla çalışırken bir metin kutusu ile bir metin yer tutucusu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/androidjava/manage-placeholder/) stil/konumu [master](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/masterslide/) üzerinden miras alır ve [layouts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslide/) üzerinde geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slayt üzerindeki bağımsız bir nesnedir ve düzenleri değiştirdiğinizde değişmez.

**Grafikler, tablolar ve SmartArt içindeki metinlere dokunmadan sunum genelinde toplu metin değiştirmeyi nasıl yapabilirim?**

Yinelemeyi, sadece metin çerçevelerine sahip otomatik şekillerle sınırlayın ve gömülü nesneleri ([charts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/smartart/)) ayrı koleksiyonları gezerek veya bu nesne türlerini atlayarak dışarıda bırakın.