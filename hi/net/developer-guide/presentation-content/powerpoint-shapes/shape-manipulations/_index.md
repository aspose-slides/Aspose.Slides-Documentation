---
title: ".NET में प्रस्तुति आकार प्रबंधन"
linktitle: "आकार हेरफेर"
type: docs
weight: 40
url: /hi/net/shape-manipulations/
keywords:
- "PowerPoint आकार"
- "प्रस्तुति आकार"
- "स्लाइड पर आकार"
- "आकार खोजें"
- "आकार क्लोन करें"
- "आकार हटाएँ"
- "आकार छिपाएँ"
- "आकार क्रम बदलें"
- "Interop आकार ID प्राप्त करें"
- "आकार वैकल्पिक पाठ"
- "आकार लेआउट फ़ॉर्मेट"
- "SVG के रूप में आकार"
- "आकार को SVG में"
- "आकार संरेखित करें"
- PowerPoint
- "प्रस्तुति"
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में आकार बनाना, संपादित करना और अनुकूलित करना सीखें और उच्च-प्रदर्शन PowerPoint प्रस्तुतियों को वितरित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रेजेंटेशन में आकारों (shapes) के साथ काम करने का तरीका समझाता है। यह दिखाता है कि स्लाइड पर किसी आकार को कैसे खोजें, उसे क्लोन करें, हटाएँ, छिपाएँ, उसका क्रम बदलें, उसका Interop shape ID प्राप्त करें, और पहचान व आगे की प्रोसेसिंग के लिए वैकल्पिक पाठ (alternative text) सेट करें।

यह आकारों के लिए लेआउट फ़ॉर्मैट तक पहुँच, आकार को SVG के रूप में रेंडर करना, स्लाइड पर आकारों को संरेखित करना, और क्षैतिज व लंबवत मिररिंग के लिए फ्लिप प्रॉपर्टीज़ का उपयोग करना भी बताता है। इसके अतिरिक्त, लेख में आकार संयोजन, स्टैकिंग क्रम, और आकार लॉक करने के बारे में एक छोटा FAQ भी शामिल है।

## **स्लाइड पर आकार खोजें**

यह विषय एक सरल तकनीक का वर्णन करेगा जिससे डेवलपर्स को स्लाइड पर किसी विशिष्ट आकार को इसके आंतरिक Id का उपयोग किए बिना ढूँढ़ना आसान हो सके। यह जानना महत्वपूर्ण है कि PowerPoint प्रेजेंटेशन फ़ाइलों में स्लाइड पर आकारों की पहचान के लिए केवल आंतरिक यूनिक Id ही उपलब्ध है। डेवलपर्स के लिए इस आंतरिक यूनिक Id का उपयोग करके आकार ढूँढ़ना कठिन हो सकता है। स्लाइड में जोड़े गए सभी आकारों में कुछ Alt Text होता है। हम डेवलपर्स को सुझाव देते हैं कि विशिष्ट आकार ढूँढ़ने के लिए वैकल्पिक पाठ (alternative text) का उपयोग करें। आप भविष्य में बदलने की योजना वाले ऑब्जेक्ट्स के लिए MS PowerPoint का उपयोग करके वैकल्पिक पाठ परिभाषित कर सकते हैं।

किसी भी इच्छित आकार का वैकल्पिक पाठ सेट करने के बाद, आप Aspose.Slides for .NET का उपयोग करके वह प्रेजेंटेशन खोल सकते हैं और स्लाइड में जोड़े गए सभी आकारों पर इटरेट कर सकते हैं। प्रत्येक इटरेशन में आप आकार का वैकल्पिक पाठ जांच सकते हैं और मिलते‑जुलते वैकल्पिक पाठ वाला आकार वही होगा जो आपको चाहिए। इस तकनीक को बेहतर तरीके से दर्शाने के लिए हमने एक मेथड, [FindShape](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/findshape/#findshape_1) बनाया है जो स्लाइड में विशिष्ट आकार को खोजता है और उसे 반환 करता है।

```c#
public static void Run()
{
    // प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // खोजे जाने वाले आकार का वैकल्पिक पाठ
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// स्लाइड में उसके वैकल्पिक पाठ का उपयोग करके एक आकार खोजने की मेथड इम्प्लीमेंटेशन
public static IShape FindShape(ISlide slide, string alttext)
{
    // स्लाइड के भीतर सभी आकारों पर इटररेट करना
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // यदि स्लाइड का वैकल्पिक पाठ वांछित पाठ से मेल खाता है तो
        // आकार लौटाएँ
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **एक आकार को क्लोन करें**

Aspose.Slides for .NET का उपयोग करके स्लाइड पर एक आकार को क्लोन करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड का संदर्भ उसके इंडेक्स का उपयोग करके प्राप्त करें।
3. स्रोत स्लाइड के shape संग्रह (shape collection) तक पहुँचें।
4. प्रेजेंटेशन में एक नई स्लाइड जोड़ें।
5. स्रोत स्लाइड के shape संग्रह से आकारों को नई स्लाइड में क्लोन करें।
6. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

नीचे उदाहरण एक ग्रुप आकार को स्लाइड में जोड़ता है।

```c#
// Presentation क्लास का उदाहरण बनाएं
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// PPTX फ़ाइल को डिस्क पर लिखें
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **एक आकार हटाएँ**

Aspose.Slides for .NET डेवलपर्स को किसी भी आकार को हटाने की अनुमति देता है। किसी स्लाइड से आकार हटाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएँ।
2. पहली स्लाइड तक पहुँचें।
3. विशिष्ट AlternativeText वाले आकार को खोजें।
4. आकार को हटाएँ।
5. फ़ाइल को डिस्क पर सहेजें।

```c#
// Presentation ऑब्जेक्ट बनाएं
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// rectangle प्रकार का ऑटोशेप जोड़ें
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// प्रेजेंटेशन को डिस्क पर सहेजें
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **एक आकार छिपाएँ**

Aspose.Slides for .NET डेवलपर्स को किसी भी आकार को छिपाने की अनुमति देता है। किसी स्लाइड से आकार छिपाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएँ।
2. पहली स्लाइड तक पहुँचें।
3. विशिष्ट AlternativeText वाले आकार को खोजें।
4. आकार को छिपाएँ।
5. फ़ाइल को डिस्क पर सहेजें।

```c#
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation();

// पहली स्लाइड प्राप्त करें
ISlide sld = pres.Slides[0];

// rectangle प्रकार का ऑटोशेप जोड़ें
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// प्रेजेंटेशन को डिस्क पर सहेजें
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **आकार का क्रम बदलें**

Aspose.Slides for .NET डेवलपर्स को आकारों को पुनः क्रमित (reorder) करने की अनुमति देता है। आकार का पुनः क्रमित करना निर्धारित करता है कि कौन सा आकार आगे है और कौन सा पीछे। किसी स्लाइड में आकार का क्रम बदलने के लिए, नीचे दिए गए चरणों का पालन करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएँ।
2. पहली स्लाइड तक पहुँचें।
3. एक आकार जोड़ें।
4. आकार के टेक्स्ट फ्रेम में कुछ पाठ जोड़ें।
5. समान निर्देशांक (coordinates) वाले एक और आकार जोड़ें।
6. आकारों का क्रम बदलें।
7. फ़ाइल को डिस्क पर सहेजें।

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```

## **Interop Shape ID प्राप्त करें**

Aspose.Slides for .NET डेवलपर्स को स्लाइड स्तर पर एक यूनिक आकार पहचानकर्ता प्राप्त करने की अनुमति देता है, जबकि UniqueId प्रॉपर्टी प्रेजेंटेशन स्तर पर यूनिक पहचानकर्ता देती है। प्रॉपर्टी OfficeInteropShapeId को IShape इंटरफ़ेस और Shape क्लास में जोड़ा गया है। OfficeInteropShapeId प्रॉपर्टी द्वारा लौटाया गया मान Microsoft.Office.Interop.PowerPoint.Shape ऑब्जेक्ट के Id के मान के समान होता है। नीचे एक नमूना कोड दिया गया है।

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// स्लाइड स्कोप में यूनिक आकार पहचानकर्ता प्राप्त करना
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **आकार के लिए वैकल्पिक पाठ सेट करें**

Aspose.Slides for .NET डेवलपर्स को किसी भी आकार का AlternateText सेट करने की अनुमति देता है।  
प्रेजेंटेशन में आकारों को AlternativeText या Shape Name प्रॉपर्टी से पहचाना जा सकता है।  
AlternativeText प्रॉपर्टी को Aspose.Slides या Microsoft PowerPoint दोनों से पढ़ा या सेट किया जा सकता है।  
इस प्रॉपर्टी का उपयोग करके आप आकार को टैग कर सकते हैं और विभिन्न कार्य जैसे आकार हटाना,  
आकार छिपाना या स्लाइड पर आकारों का क्रम बदलना कर सकते हैं।  
आकार का AlternateText सेट करने के लिए, नीचे दिए गए चरणों का पालन करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएँ।
2. पहली स्लाइड तक पहुँचें।
3. स्लाइड में कोई भी आकार जोड़ें।
4. नई जोड़ी गई आकार के साथ कुछ कार्य करें।
5. आकारों के माध्यम से इटररेट करके आकार खोजें।
6. AlternativeText सेट करें।
7. फ़ाइल को डिस्क पर सहेजें।

```c#
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation();

// पहली स्लाइड प्राप्त करें
ISlide sld = pres.Slides[0];

// rectangle प्रकार का ऑटोशेप जोड़ें
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// प्रेजेंटेशन को डिस्क पर सहेजें
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **एक आकार के लिए लेआउट फ़ॉर्मेट तक पहुँच**

Aspose.Slides for .NET एक सरल API प्रदान करता है जिससे आप किसी आकार के लिए लेआउट फ़ॉर्मेट तक पहुँच सकते हैं। यह लेख दर्शाता है कि आप लेआउट फ़ॉर्मेट कैसे प्राप्त कर सकते हैं।

नीचे एक नमूना कोड दिया गया है।

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **आकार को SVG के रूप में रेंडर करें**

अब Aspose.Slides for .NET आकार को SVG के रूप में रेंडर करने का समर्थन करता है। Shape क्लास और IShape इंटरफ़ेस में WriteAsSvg मेथड (और उसका ओवरलोड) जोड़ा गया है। यह मेथड आकार की सामग्री को SVG फ़ाइल के रूप में सहेजने की अनुमति देता है। नीचे दिया गया कोड स्निपेट दिखाता है कि स्लाइड के आकार को SVG फ़ाइल में कैसे एक्सपोर्ट करें।

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **एक आकार संरेखित करें**

[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/methods/alignshapes/index) ओवरलोडेड मेथड के माध्यम से, आप

* स्लाइड की मार्जिन के संबंध में आकारों को संरेखित कर सकते हैं। उदाहरण 1 देखें।
* एक दूसरे के सापेक्ष आकारों को संरेखित कर सकते हैं। उदाहरण 2 देखें।

[ShapesAlignmentType](https://reference.aspose.com/slides/hi/net/aspose.slides/shapesalignmenttype) एन्यूमरेशन उपलब्ध संरेखण विकल्पों को परिभाषित करता है।

**उदाहरण 1**

यह C# कोड दिखाता है कि स्लाइड के शीर्ष किनारे पर इंडेक्स 1, 2 और 4 वाले आकारों को कैसे संरेखित किया जाए:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**उदाहरण 2**

यह C# कोड दिखाता है कि संग्रह में निचले आकार के सापेक्ष पूरी आकार संग्रह को कैसे संरेखित किया जाए:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **फ़्लिप प्रॉपर्टीज़**

Aspose.Slides में, [ShapeFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/shapeframe/) क्लास `FlipH` और `FlipV` प्रॉपर्टीज़ के माध्यम से आकारों की क्षैतिज और लंबवत मिररिंग को नियंत्रित करती है। दोनों प्रॉपर्टीज़ का प्रकार [NullableBool](https://reference.aspose.com/slides/hi/net/aspose.slides/nullablebool/) है, जो `True` को फ्लिप दर्शाता है, `False` को कोई फ्लिप नहीं, और `NotDefined` को डिफ़ॉल्ट व्यवहार के लिए उपयोग किया जाता है। ये मान आकार की [Frame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/frame/) से प्राप्त किए जा सकते हैं।

फ़्लिप सेटिंग्स को बदलने के लिए, एक नया [ShapeFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/shapeframe/) इंस्टेंस आकार की वर्तमान स्थिति और आकार, `FlipH` और `FlipV` के इच्छित मान, तथा घूर्णन कोण के साथ बनाया जाता है। इस इंस्टेंस को आकार की [Frame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/frame/) में असाइन करने और प्रेजेंटेशन को सहेजने से मिरर ट्रांसफ़ॉर्मेशन लागू होते हैं और आउटपुट फ़ाइल में कमिट होते हैं।

मान लीजिए हमारे पास एक sample.pptx फ़ाइल है जिसमें पहली स्लाइड में एक ही आकार है जिसके डिफ़ॉल्ट फ़्लिप सेटिंग्स हैं, जैसा कि नीचे दिखाया गया है।

![The shape to be flipped](shape_to_be_flipped.png)

निम्न कोड उदाहरण आकार की वर्तमान फ़्लिप प्रॉपर्टीज़ को प्राप्त करता है और उसे क्षैतिज तथा लंबवत दोनों दिशा में फ़्लिप करता है।

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // आकार की क्षैतिज फ़्लिप प्रॉपर्टी प्राप्त करें।
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // आकार की ऊर्ध्वाधर फ़्लिप प्रॉपर्टी प्राप्त करें।
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // क्षैतिज रूप से फ़्लिप करें।
    NullableBool flipV = NullableBool.True; // ऊर्ध्वाधर रूप से फ़्लिप करें।
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

![The flipped shape](flipped_shape.png)

## **FAQ**

**क्या मैं स्लाइड पर आकारों (union/intersect/subtract) को डेस्कटॉप एडिटर की तरह संयोजित कर सकता हूँ?**

निर्मित Boolean ऑपरेशन API नहीं है। आप स्वयं वांछित आउटलाइन बनाकर इसे लगभग कर सकते हैं—उदाहरण के लिए, परिणामस्वरूप जियोमेट्री को गणना करें ([GeometryPath](https://reference.aspose.com/slides/hi/net/aspose.slides/geometrypath/) के माध्यम से) और उस कंटूर के साथ एक नया आकार बनाएं, वैकल्पिक रूप से मूल आकारों को हटा दें।

**मैं स्टैकिंग क्रम (z-order) को कैसे नियंत्रित कर सकता हूँ ताकि कोई आकार हमेशा "ऊपर" रहे?**

स्लाइड के [shapes](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslide/shapes/) संग्रह में सम्मिलन/स्थानांतरण क्रम को बदलें। पूर्वानुमेय परिणामों के लिए, सभी अन्य स्लाइड संशोधनों के बाद z-order को अंतिम रूप दें।

**क्या मैं "लॉक" कर सकता हूँ एक आकार को ताकि PowerPoint में उपयोगकर्ता इसे संपादित न कर सकें?**

हाँ। [shape-level protection flags](/slides/hi/net/applying-protection-to-presentation/) (जैसे चयन, स्थानांतरण, आकार बदलना, टेक्स्ट संपादन को लॉक करना) सेट करें। आवश्यक होने पर, मास्टर या लेआउट पर प्रतिबंध लागू करें। ध्यान दें कि यह UI स्तर की सुरक्षा है, न कि सुरक्षा सुविधा; अधिक मजबूत सुरक्षा के लिए फ़ाइल‑स्तर प्रतिबंधों जैसे [read‑only सिफ़ारिशें या पासवर्ड](/slides/hi/net/password-protected-presentation/) के साथ संयोजन करें।