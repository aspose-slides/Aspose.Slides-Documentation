---
title: ".NET में प्रस्तुतियों में SmartArt शैप नोड्स का प्रबंधन"
linktitle: "SmartArt शैप नोड"
type: docs
weight: 30
url: /hi/net/manage-smartart-shape-node/
keywords:
- SmartArt नोड
- चाइल्ड नोड
- नोड जोड़ें
- नोड स्थिति
- नोड तक पहुँच
- नोड हटाएँ
- कस्टम स्थिति
- असिस्टेंट नोड
- फ़िल फ़ॉर्मेट
- नोड रेंडर
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PPT और PPTX में SmartArt आकार नोड्स को प्रबंधित करें। स्पष्ट कोड उदाहरण और सुझाव प्राप्त करें ताकि आप अपनी प्रस्तुतियों को सुव्यवस्थित कर सकें।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों में SmartArt ग्राफिक्स को टेक्स्ट वाले नोड्स के माध्यम से व्यवस्थित किया जाता है जो आरेख की संरचना को परिभाषित करते हैं। Aspose.Slides आपको इन SmartArt नोड्स के साथ प्रोग्रामेटिक रूप से काम करने की अनुमति देता है: नए नोड और चाइल्ड नोड जोड़ना, किसी विशिष्ट स्थिति पर चाइल्ड नोड सम्मिलित करना, मौजूदा नोड तक पहुँच प्राप्त करना, और उनके टेक्स्ट, लेवल और पोजीशन को पढ़ना।

यह लेख SmartArt शेप नोड्स को प्रबंधित करने के तरीके को समझाता है। यह दिखाता है कि नोड्स को कैसे हटाएँ, इंडेक्स या पोजीशन द्वारा चाइल्ड नोड्स के साथ काम करें, एक असिस्टेंट नोड को सामान्य नोड में बदलें, SmartArt नोड शेप की स्थिति, आकार और घुमाव को समायोजित करें, नोड फ़िल फ़ॉर्मेट सेट करें, और SmartArt चाइल्ड नोड के लिए थंबनेल इमेज जनरेट करें।

## **SmartArt नोड जोड़ें**
Aspose.Slides for .NET ने SmartArt शेप्स को सबसे आसान तरीके से प्रबंधित करने के लिए सबसे सरल API प्रदान किया है। नीचे दिया गया नमूना कोड SmartArt शेप के अंदर नोड और चाइल्ड नोड जोड़ने में मदद करेगा।

- [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं और SmartArt शेप के साथ प्रेज़ेंटेशन लोड करें।
- उसके इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर सभी शेप्स के माध्यम से ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArt में टाइपकास्ट करें।
- SmartArt के NodeCollection में एक नया नोड जोड़ें और TextFrame में टेक्स्ट सेट करें।
- अब, नए जोड़े गए SmartArt नोड में एक चाइल्ड नोड जोड़ें और TextFrame में टेक्स्ट सेट करें।
- प्रेज़ेंटेशन को सेव करें।

```c#
// वांछित प्रस्तुति लोड करें
Presentation pres = new Presentation("AddNodes.pptx");

// पहले स्लाइड के भीतर प्रत्येक शेप के माध्यम से ट्रैवर्स करें
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // जांचें कि शेप SmartArt प्रकार का है
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // शेप को SmartArt में टाइपकास्ट करें
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // नया SmartArt नोड जोड़ रहे हैं
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // टेक्स्ट जोड़ रहे हैं
        TemNode.TextFrame.Text = "Test";

        // पैरेंट नोड में नया चाइल्ड नोड जोड़ रहे हैं। यह संग्रह के अंत में जोड़ा जाएगा
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // टेक्स्ट जोड़ रहे हैं
        newNode.TextFrame.Text = "New Node Added";

    }
}

// प्रेज़ेंटेशन सेव कर रहे हैं
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **विशिष्ट स्थिति पर SmartArt नोड जोड़ें**
निम्नलिखित नमूना कोड में हमने बताया है कि SmartArt शेप के संबंधित नोड्स के चाइल्ड नोड्स को विशिष्ट स्थिति पर कैसे जोड़ा जाए।

- `Presentation` क्लास का एक इंस्टेंस बनाएं।
- उसके इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- एक्सेस की गई स्लाइड में StackedList प्रकार का SmartArt शेप जोड़ें।
- जोड़े गए SmartArt शेप में पहला नोड एक्सेस करें।
- अब, चयनित नोड के लिए पोजीशन 2 पर चाइल्ड नोड जोड़ें और उसका टेक्स्ट सेट करें।
- प्रेज़ेंटेशन को सेव करें।

```c#
// प्रस्तुति का इंस्टेंस बना रहे हैं
Presentation pres = new Presentation();

// प्रस्तुति स्लाइड तक पहुंचें
ISlide slide = pres.Slides[0];

// Smart Art IShape जोड़ें
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// इंडेक्स 0 पर SmartArt नोड तक पहुंच रहे हैं
ISmartArtNode node = smart.AllNodes[0];

// पैरेंट नोड में पोजीशन 2 पर नया चाइल्ड नोड जोड़ रहे हैं
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// टेक्स्ट जोड़ें
chNode.TextFrame.Text = "Sample Text Added";

// प्रस्तुति सेव करें
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **SmartArt नोड एक्सेस करें**
निम्नलिखित नमूना कोड SmartArt शेप के भीतर नोड्स को एक्सेस करने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt का LayoutType नहीं बदल सकते क्योंकि यह केवल रीड‑ऑनली है और SmartArt शेप जोड़े जाने पर ही सेट होता है।

- `Presentation` क्लास का एक इंस्टेंस बनाएं और SmartArt शेप के साथ प्रेज़ेंटेशन लोड करें।
- उसके इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर सभी शेप्स के माध्यम से ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArt में टाइपकास्ट करें।
- SmartArt शेप के सभी नोड्स के माध्यम से ट्रैवर्स करें।
- SmartArt नोड की पोजीशन, लेवल और टेक्स्ट जैसी जानकारी एक्सेस करें और प्रदर्शित करें।

```c#
  // वांछित प्रस्तुति लोड करें
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // पहली स्लाइड के भीतर प्रत्येक शेप के माध्यम से ट्रैवर्स करें
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // जांचें कि शेप SmartArt प्रकार का है
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // शेप को SmartArt में टाइपकास्ट करें
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // SmartArt के भीतर सभी नोड्स के माध्यम से ट्रैवर्स करें
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // सूचक i पर SmartArt नोड तक पहुंच रहे हैं
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // SmartArt नोड पैरामीटर्स प्रिंट कर रहे हैं
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```



## **SmartArt चाइल्ड नोड एक्सेस करें**
निम्नलिखित नमूना कोड SmartArt शेप के संबंधित नोड्स के चाइल्ड नोड्स को एक्सेस करने में मदद करेगा।

- `PresentationEx` क्लास का एक इंस्टेंस बनाएं और SmartArt शेप के साथ प्रेज़ेंटेशन लोड करें।
- उसके इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर सभी शेप्स के माध्यम से ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArtEx में टाइपकास्ट करें।
- SmartArt शेप के सभी नोड्स के माध्यम से ट्रैवर्स करें।
- प्रत्येक चयनित SmartArt शेप नोड के लिए, संबंधित नोड के सभी चाइल्ड नोड्स के माध्यम से ट्रैवर्स करें।
- चाइल्ड नोड की पोजीशन, लेवल और टेक्स्ट जैसी जानकारी एक्सेस करें और प्रदर्शित करें।

```c#
// वांछित प्रस्तुति लोड करें
Presentation pres = new Presentation("AccessChildNodes.pptx");

// पहली स्लाइड के भीतर प्रत्येक शेप के माध्यम से ट्रैवर्स करें
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // जांचें कि शेप SmartArt प्रकार का है
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // शेप को SmartArt में टाइपकास्ट करें
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // SmartArt के भीतर सभी नोड्स के माध्यम से ट्रैवर्स करें
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // इंडेक्स i पर SmartArt नोड तक पहुंच रहे हैं
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // इंडेक्स i पर SmartArt नोड के चाइल्ड नोड्स के माध्यम से ट्रैवर्स कर रहे हैं
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // SmartArt नोड में चाइल्ड नोड तक पहुंच रहे हैं
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // SmartArt चाइल्ड नोड पैरामीटर्स प्रिंट कर रहे हैं
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **विशिष्ट स्थिति पर SmartArt चाइल्ड नोड एक्सेस करें**
इस उदाहरण में हम समझेंगे कि कैसे विशिष्ट स्थिति पर SmartArt शेप के संबंधित नोड्स के चाइल्ड नोड्स को एक्सेस किया जाए।

- `Presentation` क्लास का एक इंस्टेंस बनाएं।
- उसके इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- StackedList प्रकार का SmartArt शेप जोड़ें।
- जोड़े गए SmartArt शेप को एक्सेस करें।
- एक्सेस किए गए SmartArt शेप के लिए इंडेक्स 0 पर नोड एक्सेस करें।
- अब, GetNodeByPosition() मेथड का उपयोग करके एक्सेस किए गए SmartArt नोड के लिए पोजीशन 1 पर चाइल्ड नोड एक्सेस करें।
- चाइल्ड नोड की पोजीशन, लेवल और टेक्स्ट जैसी जानकारी एक्सेस करें और प्रदर्शित करें।

```c#
// प्रेजेंटेशन का इंस्टांस बनाएं
Presentation pres = new Presentation();

// पहली स्लाइड तक पहुंच
ISlide slide = pres.Slides[0];

// पहली स्लाइड में SmartArt शैप जोड़ रहे हैं
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// इंडेक्स 0 पर SmartArt  नोड तक पहुंच रहे हैं
ISmartArtNode node = smart.AllNodes[0];

// पैरेंट नोड में पोजीशन 1 पर चाइल्ड नोड तक पहुंच रहे हैं
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// SmartArt चाइल्ड नोड पैरामीटर्स प्रिंट कर रहे हैं
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **SmartArt नोड हटाएँ**
इस उदाहरण में हम सीखेंगे कि SmartArt शेप के भीतर नोड्स को कैसे हटाया जाए।

- `Presentation` क्लास का एक इंस्टेंस बनाएं और SmartArt शेप के साथ प्रेज़ेंटेशन लोड करें।
- उसके इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर सभी शेप्स के माध्यम से ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArt में टाइपकास्ट करें।
- जांचें कि SmartArt में 0 से अधिक नोड्स हैं।
- हटाने के लिए SmartArt नोड चुनें।
- अब, RemoveNode() मेथड का उपयोग करके चयनित नोड को हटाएँ और प्रेज़ेंटेशन को सेव करें।

```c#
// वांछित प्रस्तुति लोड करें
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // पहली स्लाइड के भीतर प्रत्येक शेप के माध्यम से ट्रैवर्स करें
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // जांचें कि शेप SmartArt प्रकार का है
        if (shape is ISmartArt)
        {
            // शेप को SmartArtEx में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // इंडेक्स 0 पर SmartArt नोड तक पहुंच रहे हैं
                ISmartArtNode node = smart.AllNodes[0];

                // चयनित नोड को हटा रहे हैं
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // प्रस्तुति को सेव करें
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **विशिष्ट स्थिति पर SmartArt नोड हटाएँ**
इस उदाहरण में हम सीखेंगे कि SmartArt शेप के भीतर नोड्स को विशिष्ट स्थिति पर कैसे हटाया जाए।

- `Presentation` क्लास का एक इंस्टेंस बनाएं और SmartArt शेप के साथ प्रेज़ेंटेशन लोड करें।
- उसके इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर सभी शेप्स के माध्यम से ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArt में टाइपकास्ट करें।
- इंडेक्स 0 पर SmartArt शेप नोड चुनें।
- अब, जांचें कि चयनित SmartArt नोड में 2 से अधिक चाइल्ड नोड्स हैं।
- अब, RemoveNodeByPosition() मेथड का उपयोग करके पोजीशन 1 पर नोड हटाएँ।
- प्रेज़ेंटेशन को सेव करें।

```c#
// वांछित प्रस्तुति लोड करें             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// पहली स्लाइड के भीतर प्रत्येक शेप के माध्यम से ट्रैवर्स करें
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // जांचें कि शेप SmartArt प्रकार का है
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // शेप को SmartArt में टाइपकास्ट करें
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // इंडेक्स 0 पर SmartArt नोड तक पहुंच रहे हैं
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // पोजीशन 1 पर चाइल्ड नोड को हटा रहे हैं
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// प्रस्तुति को सेव करें
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **SmartArt ऑब्जेक्ट में चाइल्ड नोड के लिए कस्टम पोजीशन सेट करें**
अब Aspose.Slides for .NET SmartArtShape के X और Y प्रॉपर्टीज़ सेट करने को समर्थन देता है। नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे कस्टम SmartArtShape पोजीशन, आकार और रोटेशन सेट किया जाए। कृपया ध्यान दें कि नया नोड जोड़ने से सभी नोड्स की पोजीशन और आकार पुनर्गणना होते हैं।

```c#
// वांछित प्रस्तुति लोड करें
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// SmartArt शैप को नई स्थिति में ले जाएँ
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// SmartArt शैप की चौड़ाइयाँ बदलें
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// SmartArt शैप की ऊँचाई बदलें
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// SmartArt शैप का रोटेशन बदलें
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **असिस्टेंट नोड की जाँच करें**
निम्नलिखित नमूना कोड में हम यह जांचेंगे कि SmartArt नोड कलेक्शन में असिस्टेंट नोड्स को कैसे पहचानें और उनका स्टेटस बदलें।

- `PresentationEx` क्लास का एक इंस्टेंस बनाएं और SmartArt शेप के साथ प्रेज़ेंटेशन लोड करें।
- उसके इंडेक्स का उपयोग करके दूसरी स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर सभी शेप्स के माध्यम से ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है और यदि है तो चयनित शेप को SmartArtEx में टाइपकास्ट करें।
- SmartArt शेप के सभी नोड्स के माध्यम से ट्रैवर्स करें और जांचें कि वे असिस्टेंट नोड हैं या नहीं।
- असिस्टेंट नोड की स्थिति को सामान्य नोड में बदलें।
- प्रेज़ेंटेशन को सेव करें।

```c#
// प्रस्तुति का इंस्टेंस बना रहे हैं
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // पहली स्लाइड के भीतर प्रत्येक शेप के माध्यम से ट्रैवर्स करें
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // जांचें कि शेप SmartArt प्रकार का है
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // शेप को SmartArtEx में टाइपकास्ट करें
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // SmartArt शैप के सभी नोड्स के माध्यम से ट्रैवर्स कर रहे हैं

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // जांचें कि नोड असिस्टेंट नोड है
                if (node.IsAssistant)
                {
                    // असिस्टेंट नोड को false सेट कर रहे हैं और इसे सामान्य नोड बना रहे हैं
                    node.IsAssistant = false;
                }
            }
        }
    }
    // प्रस्तुति को सेव करें
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **नोड के Fill Format को सेट करें**
Aspose.Slides for .NET आपको कस्टम SmartArt शेप्स जोड़ने और उनके फ़िल फ़ॉर्मेट सेट करने की सुविधा देता है। यह लेख बताता है कि कैसे SmartArt शेप्स को बनाया और एक्सेस किया जाए और Aspose.Slides for .NET का उपयोग करके उनके फ़िल फ़ॉर्मेट को सेट किया जाए।

कृपया नीचे दिए गए चरणों का पालन करें:

- `Presentation` क्लास का एक इंस्टेंस बनाएं।
- उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- उसके LayoutType को सेट करके एक SmartArt शेप जोड़ें।
- SmartArt शेप नोड्स के लिए FillFormat सेट करें।
- संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

```c#
using (Presentation presentation = new Presentation())
{
    // स्लाइड तक पहुंच
    ISlide slide = presentation.Slides[0];

    // SmartArt शैप और नोड्स जोड़ रहे हैं
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // नोड भराव रंग सेट कर रहे हैं
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // प्रेज़ेंटेशन सहेज रहे हैं
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **SmartArt चाइल्ड नोड की थंबनेल जनरेट करें**
डेवलपर्स नीचे दिए गए चरणों का पालन करके SmartArt के चाइल्ड नोड की थंबनेल बना सकते हैं:

1. `Presentation` क्लास का एक इंस्टेंस बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है।
2. SmartArt जोड़ें।
3. उसके इंडेक्स का उपयोग करके नोड का रेफ़रेंस प्राप्त करें।
4. थंबनेल इमेज प्राप्त करें।
5. थंबनेल इमेज को इच्छित किसी भी इमेज फ़ॉर्मेट में सेव करें।

नीचे का उदाहरण SmartArt चाइल्ड नोड की थंबनेल जेनरेट करता है

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **FAQ**

**क्या SmartArt एनीमेशन समर्थित है?**

हां। SmartArt को एक सामान्य शेप के रूप में माना जाता है, इसलिए आप [मानक एनीमेशन लागू](/slides/hi/net/shape-animation/) (एंट्री, एग्ज़िट, एम्फेसिस, मोशन पाथ) कर सकते हैं और टाइमिंग को समायोजित कर सकते हैं। आवश्यकता पड़ने पर SmartArt नोड्स के भीतर के शेप्स को भी एनीमेट किया जा सकता है।

**यदि किसी स्लाइड में SmartArt का आंतरिक ID неизвест है तो उसे विश्वसनीय रूप से कैसे खोजें?**

[ऑल्टरनेटिव टेक्स्ट]((https://reference.aspose.com/slides/hi/net/aspose.slides/shape/alternativetext/)) का उपयोग करें और उसे सेट करें। SmartArt पर विशिष्ट AltText सेट करने से आप प्रोग्रामेटिक रूप से इसे खोज सकते हैं बिना आंतरिक पहचानकर्ताओं पर निर्भर हुए।

**प्रेज़ेंटेशन को PDF में कन्वर्ट करते समय SmartArt का रूप बना रहता है क्या?**

हां। Aspose.Slides PDF निर्यात के दौरान SmartArt को उच्च दृश्य गुणवत्ता के साथ रेंडर करता है, जिससे लेआउट, रंग और इफ़ेक्ट्स संरक्षित रहते हैं।

**क्या मैं पूरे SmartArt की इमेज (प्रीव्यू या रिपोर्ट के लिए) निकाल सकता हूँ?**

हां। आप SmartArt शेप को [रास्टर फ़ॉर्मेट]((https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getimage/)) या [SVG]((https://reference.aspose.com/slides/hi/net/aspose.slides/shape/writeassvg/)) में रेंडर कर सकते हैं, जिससे थंबनेल, रिपोर्ट या वेब उपयोग के लिए उपयुक्त स्केलेबल या रास्टर इमेज प्राप्त होती है।