---
title: .NET में प्रस्तुतीकरण से पैराग्राफ सीमाएँ प्राप्त करें
linktitle: पैराग्राफ
type: docs
weight: 60
url: /hi/net/paragraph/
keywords:
- पैराग्राफ सीमाएँ
- टेक्स्ट भाग सीमाएँ
- पैराग्राफ निर्देशांक
- भाग निर्देशांक
- पैराग्राफ आकार
- टेक्स्ट भाग आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में पैराग्राफ और टेक्स्ट-भाग सीमाएँ प्राप्त करना सीखें ताकि PowerPoint प्रस्तुतियों में टेक्स्ट की स्थिति को अनुकूलित किया जा सके।"
---
## **सारांश**

यह लेख Aspose.Slides में पैराग्राफ और टेक्स्ट भागों की सीमाएँ, आकार और निर्देशांक कैसे प्राप्त करें, यह समझाता है। यह `GetRect()` का उपयोग करके `TextFrame` में पैराग्राफ का आयत प्राप्त करने, तालिका सेल टेक्स्ट फ्रेम के अंदर पैराग्राफ और भाग के निर्देशांक प्राप्त करने, और माप इकाइयाँ, टेक्स्ट रैपिंग के प्रभाव, पिक्सेल रूपांतरण और प्रभावी पैराग्राफ फ़ॉर्मेटिंग मान जैसे महत्वपूर्ण विवरणों को उजागर करता है।

## **TextFrame में पैराग्राफ और भाग के निर्देशांक प्राप्त करें**
Aspose.Slides for .NET का उपयोग करके, डेवलपर अब TextFrame के पैराग्राफ संग्रह के भीतर Paragraph के आयताकार निर्देशांक प्राप्त कर सकते हैं। यह आपको पैराग्राफ के portion संग्रह के भीतर भाग के निर्देशांक प्राप्त करने की सुविधा भी देता है। इस विषय में, हम एक उदाहरण की मदद से दिखाएंगे कि कैसे पैराग्राफ के आयताकार निर्देशांक के साथ-साथ पैराग्राफ के भीतर भाग की स्थिति प्राप्त की जा सकती है।

## **Paragraph के आयताकार निर्देशांक प्राप्त करें**
नया मेथड **GetRect()** जोड़ा गया है। यह पैराग्राफ की सीमाओं का आयत प्राप्त करने की अनुमति देता है।

```c#
// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **तालिका सेल TextFrame के भीतर पैराग्राफ और भाग का आकार प्राप्त करें**
तालिका सेल टेक्स्ट फ्रेम में [Portion](https://reference.aspose.com/slides/hi/net/aspose.slides/portion) या [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph) का आकार और निर्देशांक प्राप्त करने के लिए, आप [IPortion.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/methods/getrect) और [IParagraph.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/methods/getrect) मेथड का उपयोग कर सकते हैं।

यह नमूना कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पैराग्राफ और टेक्स्ट भागों के लिए लौटाए गए निर्देशांक किस इकाई में मापे जाते हैं?**

पॉइंट्स में, जहाँ 1 इंच = 72 पॉइंट्स। यह स्लाइड पर सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ की सीमाओं को प्रभावित करती है?**

हां। यदि [wrapping](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/wraptext/) को [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) में सक्षम किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टूटता है, जिससे पैराग्राफ की वास्तविक सीमाएँ बदल जाती हैं।

**क्या पैराग्राफ के निर्देशांक को निर्यातित छवि में पिक्सेल में विश्वसनीय रूप से मैप किया जा सकता है?**

हां। पॉइंट्स को पिक्सेल में बदलने के लिए उपयोग करें: pixels = points × (DPI / 72)। परिणाम रेंडरिंग/निर्यात के लिए चुने गए DPI पर निर्भर करता है।

**स्टाइल उत्तराधिकार को ध्यान में रखते हुए "प्रभावी" पैराग्राफ फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करें?**

आप [effective paragraph formatting data structure](/slides/hi/net/shape-effective-properties/) का उपयोग करें; यह इंडेंट्स, स्पेसिंग, रैपिंग, RTL और अन्य के लिए अंतिम एकीकृत मान लौटाता है।