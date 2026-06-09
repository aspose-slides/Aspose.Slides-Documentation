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
- metin güncelle
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
## **Introduction**

Slaytlardaki metinler genellikle metin kutularında veya şekillerde bulunur. Bu nedenle, bir slayta metin eklemek için önce bir metin kutusu eklemeli ve ardından metni bu kutuya yerleştirmelisiniz. 

Metin tutabilen bir şekil eklemenize olanak sağlamak için Aspose.Slides for .NET, [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) arayüzünü sağlar. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides ayrıca slaytlara şekil eklemenize olanak tanıyan [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape) arayüzünü de sağlar. Ancak, `IShape` arayüzü üzerinden eklenen tüm şekiller metin tutamaz. [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) arayüzü üzerinden eklenen şekiller genellikle metin içerir. 

Bu nedenle, metin eklemek istediğiniz mevcut bir şekille çalışırken, şeklin `IAutoShape` arayüzü üzerinden dönüştürülüp dönüştürülmediğini kontrol edip doğrulamak isteyebilirsiniz. Ancak o zaman `IAutoShape` altında bulunan bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/properties/textframe) ile çalışabilirsiniz. Bu sayfadaki [Update Text](https://docs.aspose.com/slides/tr/net/manage-textbox/#update-text) bölümüne bakın. 

{{% /alert %}}

## **Create a Text Box on a Slide**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun. 
2. İlk slaytın referansını indeks üzerinden alın. 
3. Slayt üzerindeki belirli bir konuma, `Rectangle` olarak ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/properties/shapetype) özelliğiyle bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) nesnesi ekleyin ve yeni eklenen `IAutoShape` nesnesinin referansını alın. 
4. `IAutoShape` nesnesine metin içerecek bir `TextFrame` özelliği ekleyin. Aşağıdaki örnekte bu metni ekledik: *Aspose TextBox*
5. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla kaydedin. 

C# kodu—yukarıdaki adımların bir uygulaması—size bir slayta metin nasıl eklenir gösterir:

```c#
// PresentationEx'i örnekleyerek oluşturur
using (Presentation pres = new Presentation())
{

    // Sunumdaki ilk slaytı alır
    ISlide sld = pres.Slides[0];

    // Türü Rectangle olarak ayarlanmış bir AutoShape ekler
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle'a TextFrame ekler
    ashp.AddTextFrame(" ");

    // Metin çerçevesine erişir
    ITextFrame txtFrame = ashp.TextFrame;

    // Metin çerçevesi için Paragraph nesnesini oluşturur
    IParagraph para = txtFrame.Paragraphs[0];

    // Paragraf için Portion nesnesi oluşturur
    IPortion portion = para.Portions[0];

    // Metni ayarlar
    portion.Text = "Aspose TextBox";

    // Sunumu diske kaydeder
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Metin Kutusu Şekli Kontrolü**

Aspose.Slides, [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) arayüzünden [IsTextBox](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/istextbox/) özelliğini sağlayarak şekilleri incelemenize ve metin kutularını tanımlamanıza olanak tanır.

![Metin kutusu ve şekil](istextbox.png)

C# kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir: 

```c#
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

Şunu unutmayın: `AddAutoShape` metodunu [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/) arayüzünden kullanarak sadece bir otomatik şekil eklediğinizde, otomatik şeklin `IsTextBox` özelliği `false` dönecektir. Ancak, otomatik şekle `AddTextFrame` metodu veya `Text` özelliği ile metin ekledikten sonra, `IsTextBox` özelliği `true` dönecektir.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox yanlıştır
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox doğru

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox yanlıştır
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox doğru

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox yanlıştır
    shape3.AddTextFrame("");
    // shape3.IsTextBox yanlıştır

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox yanlıştır
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox yanlıştır
}
```

## **Metin Kutusuna Sütun Ekle**

Aspose.Slides, metin kutularına sütun eklemenizi sağlayan [ColumnCount](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/columncount) ve [ColumnSpacing](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/properties/columnspacing) özelliklerini ([ITextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat) arayüzü ve [TextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat) sınıfı üzerinden) sunar. Bir metin kutusundaki sütun sayısını ve sütunlar arasındaki boşluğu puan cinsinden belirleyebilirsiniz. 

C# kodu, açıklanan işlemi gösterir: 

```c#
using (Presentation presentation = new Presentation())
{
	// Sunumdaki ilk slaytı alır
	ISlide slide = presentation.Slides[0];

	// Türü Rectangle olarak ayarlanmış bir AutoShape ekler
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Rectangle'a TextFrame ekler
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// TextFrame'in metin formatını alır
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// TextFrame içinde sütun sayısını belirtir
	format.ColumnCount = 3;

	// Sütunlar arasındaki boşluğu belirtir
	format.ColumnSpacing = 10;

	// Sunumu kaydeder
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **Metin Çerçevesine Sütun Ekle**
Aspose.Slides for .NET, metin çerçevelerinde sütun eklemenizi sağlayan [ColumnCount](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/properties/columncount) özelliğini ([ITextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat) arayüzünden) sunar. Bu özellik sayesinde bir metin çerçevesinde istediğiniz sütun sayısını belirleyebilirsiniz. 

C# kodu, bir metin çerçevesine nasıl sütun ekleyeceğinizi gösterir:

```c#
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
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
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

## **Metni Güncelle**

Aspose.Slides, bir metin kutusunda bulunan metni ya da bir sunumdaki tüm metinleri değiştirmenize veya güncellemenize olanak tanır. 

C# kodu, bir sunumdaki tüm metinlerin güncellenmesi veya değiştirilmesi işlemini gösterir:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Şeklin metin çerçevesini (IAutoShape) destekleyip desteklemediğini kontrol eder.
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Metin çerçevesindeki paragraflar arasında döner
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

## **Köprü İçeren Bir Metin Kutusu Ekle** 

Bir metin kutusunun içine bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında, kullanıcılar bağlantıyı açmak için yönlendirilir. 

1. `Presentation` sınıfının bir örneğini oluşturun. 
2. İlk slaytın referansını indeks üzerinden alın.  
3. Slayt üzerindeki belirli bir konuma, `Rectangle` olarak ayarlanmış `ShapeType` özelliğiyle bir `AutoShape` nesnesi ekleyin ve yeni eklenen AutoShape nesnesinin referansını alın.
4. `AutoShape` nesnesine, varsayılan metni *Aspose TextBox* olan bir `TextFrame` ekleyin. 
5. `IHyperlinkManager` sınıfını örnekleyin. 
6. `IHyperlinkManager` nesnesini, `TextFrame`'in istediğiniz bölümüne bağlı olan [HyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/properties/hyperlinkclick) özelliğine atayın. 
7. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla kaydedin. 

C# kodu—yukarıdaki adımların bir uygulaması—size bir slayta köprü içeren bir metin kutusu nasıl eklenir gösterir:

```c#
// PPTX'yi temsil eden bir Presentation sınıfını örnekler
Presentation pptxPresentation = new Presentation();

// Sunumdaki ilk slaytı alır
ISlide slide = pptxPresentation.Slides[0];

// Türü Rectangle olarak ayarlanmış bir AutoShape nesnesi ekler
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Şekli AutoShape tipine dönüştürür
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// AutoShape ile ilişkilendirilmiş ITextFrame özelliğine erişir
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Adds some text to the frame
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Sets the Hyperlink for the portion text
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Saves the PPTX Presentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **SSS**

**Metin kutusu ile metin yer tutucusu arasında ana slaytlarla çalışırken ne fark vardır?**

Bir [placeholder](/slides/tr/net/manage-placeholder/) [master](https://reference.aspose.com/slides/tr/net/aspose.slides/masterslide/) stilini/konumunu devralır ve [layout](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutslide/) üzerinde geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve layout değiştirdiğinizde değişmez.

**Sunum üzerindeki metinleri toplu olarak değiştirmek, ancak grafikler, tablolar ve SmartArt içindeki metinlere dokunmadan nasıl yapılır?**

Yinelemeyi, metin çerçevelerine sahip otomatik şekillerle sınırlayın ve gömülü nesneleri ([charts](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/tr/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/net/aspose.slides.smartart/smartart/)) ayrı koleksiyonlarını gezerek veya bu nesne türlerini atlayarak dışarıda bırakın.