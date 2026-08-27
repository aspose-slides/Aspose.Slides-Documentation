---
title: .NET'te Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/net/manage-textbox/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET, PowerPoint ve OpenDocument dosyalarında metin kutularını oluşturmayı, düzenlemeyi ve kopyalamayı kolaylaştırarak sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler genellikle metin kutularında veya şekillerde bulunur. Bu nedenle, bir slayta metin eklemek için önce bir metin kutusu eklemeli ve ardından metin kutusunun içine metin koymalısınız. 

Metin tutabilen bir şekil eklemenize olanak sağlamak için Aspose.Slides for .NET, [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) arabirimini sunar. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides ayrıca slaytlara şekil eklemenize olanak tanıyan [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape) arabirimini sağlar. Ancak, `IShape` arabirimi üzerinden eklenen tüm şekiller metin tutamaz. [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) arabirimi üzerinden eklenen şekiller genellikle metin içerir. 

Bu nedenle, metin eklemek istediğiniz mevcut bir şekille çalışırken, şeklin `IAutoShape` arabirimi üzerinden döndürüldüğünü kontrol etmek ve onaylamak isteyebilirsiniz. Ancak o zaman, `IAutoShape` altında bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/properties/textframe) ile çalışabilirsiniz. Bu sayfadaki [Update Text](https://docs.aspose.com/slides/tr/net/manage-textbox/#update-text) bölümüne bakın. 

{{% /alert %}}

## **Bir Slayta Metin Kutusu Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun. 
2. İlk slaydın referansını indeks üzerinden alın. 
3. Slayt üzerindeki belirli bir konuma, `Rectangle` olarak ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/properties/shapetype) olan bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) nesnesi ekleyin ve yeni eklenen `IAutoShape` nesnesinin referansını alın. 
4. `IAutoShape` nesnesine metin içerecek bir `TextFrame` özelliği ekleyin. Aşağıdaki örnekte bu metni ekledik: *Aspose TextBox*
5. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla yazın. 

Bu C# kodu—yukarıdaki adımların bir uygulaması—size bir slayta metin nasıl eklenir gösterir:

```c#
using Aspose.Slides;

// PresentationEx örneğini oluşturur
using (Presentation pres = new Presentation())
{

    // Sunumdaki ilk slaytı alır
    ISlide sld = pres.Slides[0];

    // Tipi Rectangle olarak ayarlanmış bir AutoShape ekler
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle'a TextFrame ekler
    ashp.AddTextFrame(" ");

    // Metin çerçevesine erişir
    ITextFrame txtFrame = ashp.TextFrame;

    // Metin çerçevesi için Paragraph nesnesi oluşturur
    IParagraph para = txtFrame.Paragraphs[0];

    // Paragraph için Portion nesnesi oluşturur
    IPortion portion = para.Portions[0];

    // Metni ayarlar
    portion.Text = "Aspose TextBox";

    // Sunumu diske kaydeder
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Metin Kutusu Şeklini Kontrol Etme**

Aspose.Slides, şekilleri incelemenize ve metin kutularını tanımlamanıza olanak tanıyan [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) arabiriminden [IsTextBox](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/istextbox/) özelliğini sağlar. 

![Metin kutusu ve şekil](istextbox.png)

Bu C# kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir: 

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

Şunu unutmayın: [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/) arabiriminden `AddAutoShape` metodunu kullanarak sadece bir otomatik şekil eklerseniz, otomatik şeklin `IsTextBox` özelliği `false` dönecektir. Ancak, `AddTextFrame` metodu veya `Text` özelliğiyle otomatik şekle metin ekledikten sonra, `IsTextBox` özelliği `true` döner.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox false'dur
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox true'dur

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox false'dur
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox true'dur

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox false'dur
    shape3.AddTextFrame("");
    // shape3.IsTextBox false'dur

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox false'dur
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox false'dur
}
```

## **Bir Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodunda, içinde bulunduğu sunum nesnesini bilmeden bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) alabilirsiniz. Sahibi olan [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) nesnesine geri dönmek için [ITextFrame.ParentShape](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentshape/) özelliğini kullanın.

[IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) veya başka bir metin içeren şekle ait bir metin çerçevesi için, [ITextFrame.ParentShape](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentshape/) ayarlanmıştır ve [ITextFrame.ParentCell](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentcell/) `null` değerindedir. Her iki özellik de sadece okuma amaçlı gezinme özellikleri olduğundan, okunmaları sahipliği değiştirmez. Şekle erişmeden önce her zaman dönen değerin `null` olup olmadığını kontrol edin.

Şekil ve tablo hücresi sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de tanımlayan tam bir örnek için [Search and Replace Text](/slides/tr/net/search-and-replace-text/) bölümüne bakın.

## **Metin Kutusuna Sütun Ekleme**

Aspose.Slides, metin kutularına sütun eklemenizi sağlayan [ITextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat) arabiriminden ve [TextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat) sınıfından gelen [ColumnCount](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/columncount) ve [ColumnSpacing](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/properties/columnspacing) özelliklerini sunar. Bir metin kutusunda kaç sütun olacağını ve sütunlar arasındaki boşluğu puan olarak belirleyebilirsiniz. 

Bu C# kodu, açıklanan işlemi gösterir: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// Sunumdaki ilk slaytı alır
	ISlide slide = presentation.Slides[0];

	// Tipi Rectangle olarak ayarlanmış bir AutoShape ekler
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Rectangle'a TextFrame ekler
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// TextFrame'in metin biçimini alır
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// TextFrame'deki sütun sayısını belirtir
	format.ColumnCount = 3;

	// Sütunlar arasındaki boşluğu belirtir
	format.ColumnSpacing = 10;

	// Sunumu kaydeder
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Metin Çerçevesine Sütun Ekleme**

Aspose.Slides for .NET, metin çerçevelerine sütun eklemenizi sağlayan [ITextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat) arabiriminden gelen [ColumnCount](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/columncount) özelliğini sunar. Bu özellik aracılığıyla, bir metin çerçevesinde istediğiniz sütun sayısını belirleyebilirsiniz. 

Bu C# kodu, bir metin çerçevesine sütun nasıl eklenir gösterir:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Metni Güncelleme**

Aspose.Slides, bir metin kutusundaki veya bir sunumdaki tüm metinlerde değişiklik yapmanızı veya güncellemenizi sağlar. 

Bu C# kodu, bir sunumdaki tüm metinlerin güncellendiği veya değiştirildiği bir işlemi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Şeklin metin çerçevesini (IAutoShape) destekleyip desteklemediğini kontrol eder. 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Metin çerçevesindeki paragraflar üzerinde döner
               {
                   foreach (IPortion portion in paragraph.Portions) //Paragraftaki her bölümü dolaşır
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Metni değiştirir
                       portion.PortionFormat.FontBold = NullableBool.True; //Biçimlendirmeyi değiştirir
                   }
               }
           }
       }
   }
  
   //Değiştirilmiş sunumu kaydeder
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Köprü İçeren Bir Metin Kutusu Ekleme** 

Bir metin kutusunun içine bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında kullanıcılar bağlantıyı açmak üzere yönlendirilir. 

1. `Presentation` sınıfının bir örneğini oluşturun. 
2. İlk slaydın referansını indeks üzerinden alın.  
3. `ShapeType` değeri `Rectangle` olarak ayarlanmış bir `AutoShape` nesnesini slayt üzerindeki belirli bir konuma ekleyin ve yeni eklenen AutoShape nesnesinin referansını alın.
4. `AutoShape` nesnesine varsayılan metni *Aspose TextBox* olan bir `TextFrame` ekleyin. 
5. `IHyperlinkManager` sınıfını örnekleyin. 
6. `IHyperlinkManager` nesnesini `TextFrame`'in istediğiniz kısmına bağlı [HyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/properties/hyperlinkclick) özelliğine atayın. 
7. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla yazın. 

Bu C# kodu—yukarıdaki adımların bir uygulaması— size bir slayta köprü içeren bir metin kutusu nasıl eklenir gösterir:

```c#
using Aspose.Slides;

// PPTX'i temsil eden bir Presentation sınıfını örnekleştirir
Presentation pptxPresentation = new Presentation();

// Sunumdaki ilk slaytı alır
ISlide slide = pptxPresentation.Slides[0];

// Tipi Rectangle olarak ayarlanmış bir AutoShape nesnesi ekler
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Şekli AutoShape tipine dönüştürür
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// AutoShape ile ilişkili ITextFrame özelliğine erişir
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Çerçeveye bir miktar metin ekler
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Bölüm metni için Köprüyü ayarlar
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// PPTX Sunumunu kaydeder
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **SSS**

**Metin kutusu ile bir metin yer tutucusunun ana slaytlarla çalışırken farkı nedir?**

Bir [placeholder](/slides/tr/net/manage-placeholder/), [master](https://reference.aspose.com/slides/tr/net/aspose.slides/masterslide/)'dan stil/konum miras alır ve [layouts](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutslide/) üzerinde geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve düzenleri değiştirdiğinizde değişmez.

**Sunum boyunca grafik, tablo ve SmartArt içindeki metinlere dokunmadan toplu metin değiştirme nasıl yapılır?**

Yinelemeyi, metin çerçevelerine sahip otomatik şekillerle sınırlayın ve gömülü nesneleri ([charts](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/tr/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/smartart/)) ayrı ayrı koleksiyonlarını dolaşarak veya bu nesne türlerini atlayarak dışarıda bırakın.