---
title: ".NET में प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें"
linktitle: "टेक्स्ट बॉक्स प्रबंधित करें"
type: docs
weight: 20
url: /hi/net/manage-textbox/
keywords:
  - टेक्स्ट बॉक्स
  - टेक्स्ट फ्रेम
  - टेक्स्ट जोड़ें
  - टेक्स्ट अपडेट करें
  - टेक्स्ट बॉक्स बनाएं
  - टेक्स्ट बॉक्स जांचें
  - टेक्स्ट कॉलम जोड़ें
  - हाइपरलिंक जोड़ें
  - PowerPoint
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स बनाने, संपादित करने और क्लोन करने को आसान बनाता है, जिससे आपकी प्रस्तुति स्वचालन में सुधार होता है।"
---
## **परिचय**

स्लाइड्स पर टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या शैप्स में होते हैं। इसलिए, एक स्लाइड में टेक्स्ट जोड़ने के लिए, आपको पहले एक टेक्स्टबॉक्स जोड़ना पड़ता है और फिर उसके अंदर टेक्स्ट डालना होता है। 

आपको टेक्स्ट रखने वाला शैप जोड़ने की अनुमति देने के लिए, Aspose.Slides for .NET [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) इंटरफ़ेस प्रदान करता है। 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides additionally [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape) इंटरफ़ेस प्रदान करता है जिससे आप स्लाइड्स में शैप जोड़ सकते हैं। लेकिन, `IShape` इंटरफ़ेस के माध्यम से जोड़े गए सभी शैप्स टेक्स्ट रख नहीं सकते। [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) इंटरफ़ेस से जोड़े गए शैप्स आमतौर पर टेक्स्ट रखते हैं। 

इसलिए, जब आप किसी मौजूदा शैप को टेक्स्ट जोड़ने के लिए संभाल रहे हों, तो आपको यह जांचना और पुष्टि करना चाहिए कि वह `IAutoShape` इंटरफ़ेस के माध्यम से कास्ट किया गया है। केवल तब आप [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/properties/textframe) के साथ काम कर सकेंगे, जो `IAutoShape` का एक प्रॉपर्टी है। इस पृष्ठ के [Update Text](https://docs.aspose.com/slides/hi/net/manage-textbox/#update-text) सेक्शन को देखें। 

{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाएं**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की इंस्टेंस बनाएं। 
2. इंडेक्स द्वारा पहली स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड पर निर्दिष्ट स्थिति पर `Rectangle` के रूप में सेट किए हुए [ShapeType](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape/properties/shapetype) के साथ एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) ऑब्जेक्ट जोड़ें और नए जोड़े गए `IAutoShape` ऑब्जेक्ट का रेफ़रेंस प्राप्त करें। 
4. `IAutoShape` ऑब्जेक्ट में एक `TextFrame` प्रॉपर्टी जोड़ें जो टेक्स्ट रखेगी। नीचे के उदाहरण में, हमने यह टेक्स्ट जोड़ा: *Aspose TextBox* 
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह C# कोड—ऊपर बताए चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में टेक्स्ट कैसे जोड़ें:

```c#
 // PresentationEx को इंस्टैंसिएट करता है
 using (Presentation pres = new Presentation())
 {
 
     // प्रस्तुति में पहली स्लाइड प्राप्त करता है
     ISlide sld = pres.Slides[0];
 
     // टाइप को Rectangle सेट करके एक AutoShape जोड़ता है
     IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);
 
     // Rectangle में TextFrame जोड़ता है
     ashp.AddTextFrame(" ");
 
     // टेक्स्ट फ्रेम तक पहुँचता है
     ITextFrame txtFrame = ashp.TextFrame;
 
     // टेक्स्ट फ्रेम के लिए Paragraph ऑब्जेक्ट बनाता है
     IParagraph para = txtFrame.Paragraphs[0];
 
     // Paragraph के लिए Portion ऑब्जेक्ट बनाता है
     IPortion portion = para.Portions[0];
 
     // टेक्स्ट सेट करता है
     portion.Text = "Aspose TextBox";
 
     // प्रस्तुति को डिस्क पर सेव करता है
     pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **टेक्स्ट बॉक्स शैप की जाँच करें**

Aspose.Slides [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) इंटरफ़ेस से [IsTextBox](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/istextbox/) प्रॉपर्टी प्रदान करता है, जिससे आप शैप्स की जाँच करके टेक्स्ट बॉक्स की पहचान कर सकते हैं। 

![Text box and shape](istextbox.png)

यह C# कोड दिखाता है कि कैसे जाँचें कि कोई शैप टेक्स्ट बॉक्स के रूप में बनाया गया है या नहीं: 

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

ध्यान दें कि यदि आप [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/) इंटरफ़ेस की `AddAutoShape` मेथड का उपयोग करके केवल एक ऑटोशेप जोड़ते हैं, तो ऑटोशेप की `IsTextBox` प्रॉपर्टी `false` लौटाएगी। हालांकि, जब आप `AddTextFrame` मेथड या `Text` प्रॉपर्टी का उपयोग करके ऑटोशेप में टेक्स्ट जोड़ते हैं, तो `IsTextBox` प्रॉपर्टी `true` लौटाएगी।

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox false है
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox true है

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox false है
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox true है

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox false है
    shape3.AddTextFrame("");
    // shape3.IsTextBox false है

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox false है
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox false है
}
```

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides [ITextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat) इंटरफ़ेस और [TextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat) क्लास से [ColumnCount](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/columncount) और [ColumnSpacing](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/properties/columnspacing) प्रॉपर्टी प्रदान करता है, जिससे आप टेक्स्ट बॉक्स में कॉलम जोड़ सकते हैं। आप टेक्स्ट बॉक्स में कॉलमों की संख्या निर्धारित कर सकते हैं और फिर कॉलमों के बीच पॉइंट्स में स्पेसिंग सेट कर सकते हैं। 

यह C# कोड वर्णित ऑपरेशन को दर्शाता है: 

```c#
using (Presentation presentation = new Presentation())
{
	// प्रस्तुति में पहली स्लाइड प्राप्त करता है
	ISlide slide = presentation.Slides[0];

	// टाइप को Rectangle सेट करके एक AutoShape जोड़ता है
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Rectangle में TextFrame जोड़ता है
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// TextFrame का टेक्स्ट फ़ॉर्मेट प्राप्त करता है
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// TextFrame में कॉलम की संख्या निर्दिष्ट करता है
	format.ColumnCount = 3;

	// कॉलमों के बीच की स्पेसिंग निर्दिष्ट करता है
	format.ColumnSpacing = 10;

	// प्रस्तुति को सेव करता है
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**
Aspose.Slides for .NET [ITextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat) इंटरफ़ेस से [ColumnCount](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/columncount) प्रॉपर्टी प्रदान करता है, जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस प्रॉपर्टी के माध्यम से आप टेक्स्ट फ्रेम में इच्छित कॉलम संख्या निर्दिष्ट कर सकते हैं। 

यह C# कोड दिखाता है कि टेक्स्ट फ्रेम के अंदर कॉलम कैसे जोड़ें:

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

## **टेक्स्ट अपडेट करें**

Aspose.Slides आपको टेक्स्ट बॉक्स में मौजूद टेक्स्ट या प्रस्तुति में मौजूद सभी टेक्स्ट को बदलने या अपडेट करने की अनुमति देता है। 

यह C# कोड एक ऑपरेशन को दर्शाता है जहाँ प्रस्तुति में सभी टेक्स्ट अपडेट या बदल दिए जाते हैं:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) // जांचता है कि शेप टेक्स्ट फ्रेम (IAutoShape) का समर्थन करता है या नहीं।
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) // टेक्स्ट फ्रेम में पैराग्राफ़ों के माध्यम से इटररेट करता है
               {
                   foreach (IPortion portion in paragraph.Portions) // पैराग्राफ में प्रत्येक पोर्शन के माध्यम से इटररेट करता है
                   {
                       portion.Text = portion.Text.Replace("years", "months"); // टेक्स्ट बदलता है
                       portion.PortionFormat.FontBold = NullableBool.True; // फ़ॉर्मेटिंग बदलता है
                   }
               }
           }
       }
   }
  
   // संशोधित प्रस्तुति को सेव करता है
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें** 

आप टेक्स्ट बॉक्स के भीतर एक लिंक डाल सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता उस लिंक को खोलने की दिशा में ले जाए जाते हैं। 

1. `Presentation` क्लास की एक इंस्टेंस बनाएं। 
2. इंडेक्स द्वारा पहली स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड पर निर्दिष्ट स्थिति पर `Rectangle` के रूप में सेट किए हुए `ShapeType` के साथ एक `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़े गए AutoShape ऑब्जेक्ट का रेफ़रेंस प्राप्त करें। 
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें डिफ़ॉल्ट टेक्स्ट के रूप में *Aspose TextBox* हो। 
5. `IHyperlinkManager` क्लास की एक इंस्टेंस बनाएं। 
6. `IHyperlinkManager` ऑब्जेक्ट को `TextFrame` के इच्छित भाग से जुड़े [HyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/properties/hyperlinkclick) प्रॉपर्टी में असाइन करें। 
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह C# कोड—ऊपर बताए चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स कैसे जोड़ें:

```c#
// इंस्टैंसिएट करता है एक Presentation क्लास जो PPTX का प्रतिनिधित्व करता है
Presentation pptxPresentation = new Presentation();

// प्रस्तुति में पहली स्लाइड प्राप्त करता है
ISlide slide = pptxPresentation.Slides[0];

// टाइप को Rectangle सेट करके एक AutoShape ऑब्जेक्ट जोड़ता है
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// शेप को AutoShape में कास्ट करता है
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// AutoShape से जुड़े ITextFrame प्रॉपर्टी तक पहुँचता है
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// फ्रेम में कुछ टेक्स्ट जोड़ता है
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// पोर्शन टेक्स्ट के लिए हाइपरलिंक सेट करता है
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// PPTX प्रस्तुति को सेव करता है
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/net/manage-placeholder/) मास्टर से शैली/स्थिति विरासत में लेता है और [layouts](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि एक सामान्य टेक्स्ट बॉक्स एक विशिष्ट स्लाइड पर स्वतंत्र ऑब्जेक्ट होता है और लेआउट बदलने पर नहीं बदलता।

**मैं चार्ट्स, टेबल्स और SmartArt के भीतर के टेक्स्ट को छुए बिना पूरी प्रस्तुति में एक साथ टेक्स्ट रिप्लेसमेंट कैसे कर सकता हूँ?**

इटरिटेशन को केवल उन ऑटो-शेप्स तक सीमित करें जिनमें टेक्स्ट फ्रेम है और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hi/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/smartart/)) को बाहर रखें, उनके कलेक्शन्स को अलग से ट्रैवर्स करके या उन ऑब्जेक्ट प्रकारों को स्किप करके।