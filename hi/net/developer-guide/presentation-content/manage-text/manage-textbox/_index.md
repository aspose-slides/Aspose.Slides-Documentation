---
title: ".NET में प्रस्तुतियों में टेक्स्ट बॉक्स को प्रबंधित करना"
linktitle: "टेक्स्ट बॉक्स प्रबंधित करें"
type: docs
weight: 20
url: /hi/net/manage-textbox/
keywords:
- "टेक्स्ट बॉक्स"
- "टेक्स्ट फ्रेम"
- "पाठ जोड़ें"
- "पाठ अपडेट करें"
- "टेक्स्ट बॉक्स बनाएं"
- "टेक्स्ट बॉक्स जांचें"
- "टेक्स्ट कॉलम जोड़ें"
- "हाइपरलिंक जोड़ें"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET PowerPoint और OpenDocument फाइलों में टेक्स्ट बॉक्स बनाने, संपादित करने और क्लोन करने को आसान बनाता है, जिससे आपकी प्रस्तुति ऑटोमेशन बेहतर होती है।"
---
## **परिचय**

स्लाइड्स पर पाठ आमतौर पर टेक्स्ट बॉक्स या शैलियों में होते हैं। इसलिए, स्लाइड में पाठ जोड़ने के लिए, आपको पहले एक टेक्स्ट बॉक्स जोड़ना होगा और फिर उस टेक्स्ट बॉक्स के भीतर कुछ पाठ डालना होगा। 

आपको ऐसा आकार जोड़ने की अनुमति देने के लिए जो पाठ रख सके, Aspose.Slides for .NET [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) इंटरफ़ेस प्रदान करता है। 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides भी [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape) इंटरफ़ेस प्रदान करता है जिससे आप स्लाइड्स में शैलियां जोड़ सकते हैं। हालांकि, `IShape` इंटरफ़ेस के माध्यम से जोड़ी गई सभी शैलियां पाठ नहीं रख सकतीं। जो शैलियां [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) इंटरफ़ेस के माध्यम से जोड़ती हैं, आमतौर पर पाठ रखती हैं। 

इसलिए, जब आप किसी मौजूदा आकार के साथ काम कर रहे हों जिसमें आप पाठ जोड़ना चाहते हैं, तो आपको यह जांचना और पुष्टि करना चाहिए कि वह `IAutoShape` इंटरफ़ेस के माध्यम से कास्ट किया गया है। तभी आप [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/properties/textframe) के साथ काम कर पाएँगे, जो `IAutoShape` की एक प्रॉपर्टी है। इस पृष्ठ पर [Update Text](https://docs.aspose.com/slides/hi/net/manage-textbox/#update-text) अनुभाग देखें। 

{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से पहली स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड पर निर्दिष्ट स्थिति पर `Rectangle` के रूप में सेट किए गए [ShapeType](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape/properties/shapetype) के साथ एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) ऑब्जेक्ट जोड़ें और नए जोड़े गए `IAutoShape` ऑब्जेक्ट का रेफ़रेंस प्राप्त करें। 
4. `IAutoShape` ऑब्जेक्ट में एक `TextFrame` प्रॉपर्टी जोड़ें जो पाठ समाहित करेगा। नीचे के उदाहरण में, हमने यह पाठ जोड़ा: *Aspose TextBox*
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल को लिखें। 

यह C# कोड—उपरोक्त चरणों का कार्यान्वयन—आपको स्लाइड में पाठ जोड़ने का तरीका दिखाता है:

```c#
using Aspose.Slides;

// PresentationEx का उदाहरण बनाता है
using (Presentation pres = new Presentation())
{

    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.Slides[0];

    // Rectangle प्रकार सेट के साथ AutoShape जोड़ता है
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle में TextFrame जोड़ता है
    ashp.AddTextFrame(" ");

    // टेक्स्ट फ्रेम तक पहुँचता है
    ITextFrame txtFrame = ashp.TextFrame;

    // टेक्स्ट फ्रेम के लिए Paragraph ऑब्जेक्ट बनाता है
    IParagraph para = txtFrame.Paragraphs[0];

    // Paragraph के लिए Portion ऑब्जेक्ट बनाता है
    IPortion portion = para.Portions[0];

    // पाठ सेट करता है
    portion.Text = "Aspose TextBox";

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **टेक्स्ट बॉक्स आकार की जाँच करें**

Aspose.Slides [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) इंटरफ़ेस से [IsTextBox](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/istextbox/) प्रॉपर्टी प्रदान करता है, जिससे आप शैलियों की जांच कर सकते हैं और टेक्स्ट बॉक्स की पहचान कर सकते हैं।

![Text box and shape](istextbox.png)

यह C# कोड दिखाता है कि कैसे जांचें कि कोई आकार टेक्स्ट बॉक्स के रूप में बनाया गया है या नहीं: 

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

ध्यान दें कि यदि आप केवल [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/) इंटरफ़ेस की `AddAutoShape` मेथड का उपयोग करके एक ऑटोशेप जोड़ते हैं, तो ऑटोशेप की `IsTextBox` प्रॉपर्टी `false` लौटाएगी। हालांकि, जब आप `AddTextFrame` मेथड या `Text` प्रॉपर्टी का उपयोग करके ऑटोशेप में पाठ जोड़ते हैं, तो `IsTextBox` प्रॉपर्टी `true` लौटाएगी।

```cs
using Aspose.Slides;

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

## **टेक्स्ट फ़्रेम का स्वामी आकार खोजें**

सामान्य टेक्स्ट-प्रोसेसिंग कोड में, आप [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्राप्त कर सकते हैं बिना यह जाने कि कौन सा प्रेज़ेंटेशन ऑब्जेक्ट इसे रखता है। स्वामी [IShape](/slides/hi/net/ishape/) पर वापस नेविगेट करने के लिए [ITextFrame.ParentShape](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentshape/) प्रॉपर्टी का उपयोग करें।

यदि एक टेक्स्ट फ्रेम किसी [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) या अन्य टेक्स्ट‑धारक आकार से संबंधित है, तो [ITextFrame.ParentShape](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentshape/) सेट होता है और [ITextFrame.ParentCell](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentcell/) `null` रहता है। दोनों प्रॉपर्टी केवल‑पढ़ने योग्य नेविगेशन प्रॉपर्टी हैं, इसलिए इन्हें पढ़ने से स्वामित्व नहीं बदलता। आकार तक पहुँचने से पहले हमेशा लौटाए गए मान को `null` के लिए जाँचें।

एक पूर्ण उदाहरण के लिए जो आकार और टेबल‑सेल के मालिकों की पहचान करता है, जिसमें SmartArt नोड्स से जुड़े आकार भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/net/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides [ColumnCount](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/columncount) और [ColumnSpacing](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/properties/columnspacing) प्रॉपर्टीज़ ([ITextFrameFormat] इंटरफ़ेस और [TextFrameFormat] क्लास से) प्रदान करता है जिससे आप टेक्स्ट बॉक्स में कॉलम जोड़ सकते हैं। आप टेक्स्ट बॉक्स में कॉलमों की संख्या और फिर कॉलमों के बीच पॉइंट में स्पेसिंग निर्दिष्ट कर सकते हैं। 

यह C# कोड वर्णित क्रिया को दर्शाता है: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// प्रस्तुति में पहली स्लाइड प्राप्त करता है
	ISlide slide = presentation.Slides[0];

	// Rectangle प्रकार सेट के साथ AutoShape जोड़ता है
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Rectangle में TextFrame जोड़ता है
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// TextFrame का टेक्स्ट फ़ॉर्मेट प्राप्त करता है
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// TextFrame में कॉलमों की संख्या निर्दिष्ट करता है
	format.ColumnCount = 3;

	// कॉलमों के बीच स्पेसिंग निर्दिष्ट करता है
	format.ColumnSpacing = 10;

	// प्रस्तुति सहेजता है
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**
Aspose.Slides for .NET [ITextFrameFormat] इंटरफ़ेस से [ColumnCount](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/columncount) प्रॉपर्टी प्रदान करता है, जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस प्रॉपर्टी के द्वारा आप टेक्स्ट फ्रेम में अपनी इच्छित कॉलम संख्या निर्दिष्ट कर सकते हैं। 

यह C# कोड दिखाता है कि कैसे टेक्स्ट फ्रेम के अंदर एक कॉलम जोड़ा जाता है:

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

## **टेक्स्ट अपडेट करें**

Aspose.Slides आपको टेक्स्ट बॉक्स में या प्रेज़ेंटेशन में मौजूद सभी पाठ को बदलने या अपडेट करने की अनुमति देता है। 

यह C# कोड एक ऐसी क्रिया दर्शाता है जहाँ प्रेज़ेंटेशन के सभी पाठ अपडेट या बदले जाते हैं:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //जांचता है कि आकार टेक्स्ट फ्रेम (IAutoShape) को समर्थन करता है।
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //टेक्स्ट फ्रेम में पैराग्राफ़्स के माध्यम से इटरेट करता है
               {
                   foreach (IPortion portion in paragraph.Portions) //पैराग्राफ में प्रत्येक पोर्शन के माध्यम से इटरेट करता है
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //पाठ बदलता है
                       portion.PortionFormat.FontBold = NullableBool.True; //फ़ॉर्मेटिंग बदलता है
                   }
               }
           }
       }
   }
  
   //संशोधित प्रस्तुति सहेजता है
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें** 

आप टेक्स्ट बॉक्स के अंदर एक लिंक सम्मिलित कर सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता लिंक खोलने के लिए निर्देशित होते हैं। 

1. `Presentation` क्लास का एक इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से पहली स्लाइड का रेफरेंस प्राप्त करें।  
3. स्लाइड पर निर्दिष्ट स्थिति पर `ShapeType` को `Rectangle` सेट करके एक `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़े गए AutoShape ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें डिफ़ॉल्ट टेक्स्ट *Aspose TextBox* हो। 
5. `IHyperlinkManager` क्लास का एक इंस्टेंस बनाएं। 
6. `IHyperlinkManager` ऑब्जेक्ट को `TextFrame` के वांछित भाग से सम्बंधित [HyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/properties/hyperlinkclick) प्रॉपर्टी में असाइन करें। 
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह C# कोड—उपरोक्त चरणों का कार्यान्वयन—आपको स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ने का तरीका दिखाता है:

```c#
using Aspose.Slides;

// एक Presentation क्लास का इंस्टैंस बनाता है जो PPTX को दर्शाता है
Presentation pptxPresentation = new Presentation();

// प्रस्तुति में पहली स्लाइड प्राप्त करता है
ISlide slide = pptxPresentation.Slides[0];

// Rectangle प्रकार सेट के साथ एक AutoShape ऑब्जेक्ट जोड़ता है
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// शेप को AutoShape में कास्ट करता है
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// AutoShape से जुड़ी ITextFrame प्रॉपर्टी तक पहुँचता है
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// फ़्रेम में कुछ पाठ जोड़ता है
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// पोर्टियन टेक्स्ट के लिए हाइपरलिंक सेट करता है
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// PPTX प्रस्तुति को सहेजता है
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**मुख्य स्लाइड्स (master slides) के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/net/manage-placeholder/) [master](https://reference.aspose.com/slides/hi/net/aspose.slides/masterslide/) से शैली/स्थिति विरासत में प्राप्त करता है और इसे [layouts](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि एक सामान्य टेक्स्ट बॉक्स एक विशिष्ट स्लाइड पर स्वतंत्र ऑब्जेक्ट होता है और लेआउट बदलने पर नहीं बदलता।

**मैं चार्ट, टेबल और SmartArt के अंदर के पाठ को छुए बिना पूरे प्रेज़ेंटेशन में बड़े पैमाने पर पाठ प्रतिस्थापन कैसे कर सकता हूँ?**

अपनी इटरेशन को केवल उन ऑटो-शेप्स तक सीमित रखें जिनमें टेक्स्ट फ्रेम हैं और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hi/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/smartart/)) को अलग-अलग उनके संग्रहों को पार करके या उन ऑब्जेक्ट प्रकारों को छोड़कर बाहर रखें।