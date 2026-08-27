---
title: Java Kullanarak Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/java/manage-textbox/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java, PowerPoint ve OpenDocument dosyalarında metin kutularını oluşturmayı, düzenlemeyi ve kopyalamayı kolaylaştırarak sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler genellikle metin kutuları veya şekiller içinde bulunur. Bu nedenle, bir slayta metin eklemek için bir metin kutusu eklemeniz ve ardından metni bu kutuya yerleştirmeniz gerekir. Aspose.Slides for Java, içinde metin barındıran bir şekil eklemenizi sağlayan [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) arayüzünü sunar.

{{% alert title="Info" color="info" %}}
Aspose.Slides ayrıca slaytlara şekil eklemenizi sağlayan [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape) arayüzünü sunar. Ancak, `IShape` arayüzü üzerinden eklenen tüm şekiller metin tutamaz. Fakat [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) arayüzü üzerinden eklenen şekiller metin içerebilir. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Bu nedenle, metin eklemek istediğiniz bir şekille çalışırken, şeklin `IAutoShape` arayüzü üzerinden dönüştürüldüğünden emin olmanız gerekir. Ancak o zaman `IAutoShape` altında bulunan [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TextFrame) özelliğiyle çalışabilirsiniz. Bu sayfadaki [Update Text](https://docs.aspose.com/slides/tr/java/manage-textbox/#update-text) bölümüne bakın. 
{{% /alert %}}

## **Bir Slayta Metin Kutusu Oluşturma**

Bir slayta metin kutusu oluşturmak için şu adımları izleyin:

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun. 
2. Yeni oluşturulan sunumun ilk slaytı için bir referans alın. 
3. Slaytta belirli bir konumda `Rectangle` olarak ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IGeometryShape#setShapeType-int-) ile bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) nesnesi ekleyin ve yeni eklenen `IAutoShape` nesnesi için referansı alın. 
4. `IAutoShape` nesnesine bir metin içerecek `TextFrame` özelliği ekleyin. Aşağıdaki örnekte şu metni ekledik: *Aspose TextBox*
5. Son olarak, `Presentation` nesnesi aracılığıyla PPTX dosyasını kaydedin. 

Bu Java kodu—yukarıdaki adımların bir uygulaması—size bir slayta metin eklemeyi gösterir:

```java
import com.aspose.slides.*;

// Presentation örneğini oluşturur
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

    // Paragraph için Portion nesnesi oluşturur
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

Aspose.Slides, [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) arayüzünden [isTextBox](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/#isTextBox--) metodunu sağlayarak şekilleri incelemenizi ve metin kutularını tanımlamanızı sağlar.

![Text box and shape](istextbox.png)

Bu Java kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını kontrol etmeyi gösterir:

```java
import com.aspose.slides.*;

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

Not: `addAutoShape` metodunu [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/) arayüzünden kullanarak bir otomatik şekil eklediğinizde, otomatik şeklin `isTextBox` metodu `false` döndürür. Ancak, `addTextFrame` ya da `setText` metodunu kullanarak otomatik şekle metin eklediğinizde, `isTextBox` özelliği `true` döndürür.

```java
import com.aspose.slides.*;

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

## **Bir TextFrame’e Sahip Şekli Bulma**

Genel metin işleme kodunda, içinde bulunduğu sunum nesnesini bilmeden bir [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) alabilirsiniz. Sahibi olan [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) nesnesine geri dönmek için [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentShape--) metodunu kullanın.

[IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) ya da başka bir metin içeren şekle ait bir text frame için, [ITextFrame.getParentShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentShape--) sahibi döndürür ve [ITextFrame.getParentCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/#getParentCell--) `null` verir. Her iki metod da yalnızca okuma amaçlı gezinme sağlar; çağrıldıklarında sahiplik değişmez. Şekle erişmeden önce döndürülen değerin `null` olup olmadığını her zaman kontrol edin.

SmartArt düğümleriyle ilişkili şekilleri de içeren, şekil ve tablo hücresi sahiplerini tanımlayan eksiksiz bir örnek için [Search and Replace Text](/slides/tr/java/search-and-replace-text/) sayfasına bakın.

## **Metin Kutusuna Sütun Ekleme**

Aspose.Slides, metin kutularına sütun eklemenizi sağlayan [ColumnCount](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) ve [ColumnSpacing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) özelliklerini ([ITextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrameFormat) arayüzü ve [TextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TextFrameFormat) sınıfı) sunar. Bir metin kutusundaki sütun sayısını belirtebilir ve sütunlar arasındaki boşluğu nokta cinsinden ayarlayabilirsiniz.

Bu Java kodu, açıklanan işlemi gösterir:

```java
import com.aspose.slides.*;

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

    // TextFrame'in metin biçimini alır
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // TextFrame'deki sütun sayısını belirler
    format.setColumnCount(3);

    // Sütunlar arasındaki boşluğu belirler
    format.setColumnSpacing(10);

    // Sunumu kaydeder
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **TextFrame’e Sütun Ekleme**

Aspose.Slides for Java, text frame içinde sütun eklemenizi sağlayan [ColumnCount](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) özelliğini ([ITextFrameFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrameFormat) arayüzü) sunar. Bu özellik sayesinde bir text frame içinde istediğiniz sütun sayısını belirtebilirsiniz.

Bu Java kodu, bir text frame içine sütun eklemeyi gösterir:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Metni Güncelleme**

Aspose.Slides, bir metin kutusunda veya bir sunumdaki tüm metinlerdeki içeriği değiştirmenize veya güncellemenize olanak tanır.

Bu Java kodu, bir sunumdaki tüm metinlerin güncellendiği veya değiştirildiği bir işlemi gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Şeklin metin çerçevesini (IAutoShape) destekleyip desteklemediğini kontrol eder.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Metin çerçevesindeki paragraflar arasında dolaşır
                {
                    for (IPortion portion : paragraph.getPortions()) //Paragraftaki her bölümü dolaşır
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Metni değiştirir
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Biçimlendirmeyi değiştirir
                    }
                }
            }
        }
    }

    //Değiştirilen sunumu kaydeder
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Köprü İçeren Bir Metin Kutusu Ekleme**

Bir metin kutusunun içine bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında kullanıcılar bağlantıyı açar.

Köprü içeren bir metin kutusu eklemek için şu adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun. 
2. Yeni oluşturulan sunumun ilk slaytı için bir referans alın. 
3. Slaytta belirli bir konumda `Rectangle` olarak ayarlanmış `ShapeType` ile bir `AutoShape` nesnesi ekleyin ve yeni eklenen AutoShape nesnesi için referans alın.
4. `AutoShape` nesnesine varsayılan metni *Aspose TextBox* olan bir `TextFrame` ekleyin. 
5. `IHyperlinkManager` sınıfının bir örneğini oluşturun. 
6. `IHyperlinkManager` nesnesini `TextFrame`'in istediğiniz kısmına ilişkili [HyperlinkClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Shape#getHyperlinkClick--) özelliğine atayın. 
7. Son olarak, `Presentation` nesnesi aracılığıyla PPTX dosyasını kaydedin. 

Bu Java kodu—yukarıdaki adımların bir uygulaması—size bir slayta köprü içeren bir metin kutusu eklemeyi gösterir:

```java
import com.aspose.slides.*;

// PPTX'i temsil eden bir Presentation sınıfını örnekler
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

    // Çerçeveye bazı metinler ekler
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Bölüm metni için Köprüyü ayarlar
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

**Ana slaytlarla çalışırken bir metin kutusu ile bir metin yer tutucusu arasındaki fark nedir?**

Bir [yer tutucu](/slides/tr/java/manage-placeholder/) stil/konumu [ana slayttan](https://reference.aspose.com/slides/tr/java/com.aspose.slides/masterslide/) devralır ve [düzenlerde](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslide/) değiştirilebilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve düzenleri değiştirdiğinizde değişmez.

**Grafikler, tablolar ve SmartArt içindeki metinlere dokunmadan sunum genelinde toplu metin değiştirme nasıl yapılır?**

Yinelemeyi yalnızca metin çerçevelerine sahip otomatik şekillerle sınırlayın ve gömülü nesneleri ([grafikler](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/), [tablolar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/smartart/)) onların koleksiyonlarını ayrı ayrı dolaşarak veya bu nesne tiplerini atlayarak dışarıda bırakın.