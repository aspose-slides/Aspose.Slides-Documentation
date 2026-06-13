---
title: ".NET में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें"
linktitle: "पैराग्राफ प्रबंधित करें"
type: docs
weight: 40
url: /hi/net/manage-paragraph/
keywords:
- "पाठ जोड़ें"
- "पैराग्राफ जोड़ें"
- "पाठ प्रबंधित करें"
- "पैराग्राफ प्रबंधित करें"
- "बुलेट प्रबंधित करें"
- "पैराग्राफ इंडेंट"
- "हैंगिंग इंडेंट"
- "पैराग्राफ बुलेट"
- "नंबरित सूची"
- "बुलेटेड सूची"
- "पैराग्राफ गुण"
- "HTML आयात करें"
- "टेक्स्ट को HTML में"
- "पैराग्राफ को HTML में"
- "पैराग्राफ को छवि में"
- "टेक्स्ट को छवि में"
- "पैराग्राफ निर्यात करें"
- "PowerPoint"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ पैराग्राफ फ़ॉर्मेटिंग में माहिर बनें—PPT, PPTX, और ODP प्रेजेंटेशन में C# में संरेखण, स्पेसिंग और शैली को अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides वह सभी इंटरफ़ेस और क्लास प्रदान करता है जो आपको C# में PowerPoint पाठ, पैराग्राफ और पोर्शन के साथ काम करने के लिए आवश्यक हैं।

* Aspose.Slides आप को पैराग्राफ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने के लिए [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) इंटरफ़ेस प्रदान करता है। एक `ITextFame` ऑब्जेक्ट में एक या कई पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ कैरिज रिटर्न के माध्यम से बनाया जाता है)।
* Aspose.Slides आप को पोर्शन का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने के लिए [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) इंटरफ़ेस प्रदान करता है। एक `IParagraph` ऑब्जेक्ट में एक या कई पोर्शन (iPortions ऑब्जेक्ट का संग्रह) हो सकते हैं।
* Aspose.Slides आप को पाठ और उनकी फ़ॉर्मैटिंग गुणों का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने के लिए [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) इंटरफ़ेस प्रदान करता है।

एक `IParagraph` ऑब्जेक्ट अपने अंतर्निहित `IPortion` ऑब्जेक्ट्स के माध्यम से विभिन्न फ़ॉर्मैटिंग गुणों वाले पाठ को संभाल सकता है।

## **एकाधिक पोर्शन वाले कई पैराग्राफ जोड़ें**

इन चरणों में दिखाया गया है कि 3 पैराग्राफ और प्रत्येक पैराग्राफ में 3 पोर्शन वाला टेक्स्ट फ़्रेम कैसे जोड़ें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. उस [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) से जुड़ा ITextFrame प्राप्त करें।
5. दो [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) ऑब्जेक्ट बनाएं और उन्हें [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) के `IParagraphs` संग्रह में जोड़ें।
6. प्रत्येक नए `IParagraph` के लिए तीन [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) ऑब्जेक्ट बनाएं (डिफ़ॉल्ट पैराग्राफ के लिए दो Portion ऑब्जेक्ट) और प्रत्येक `IPortion` ऑब्जेक्ट को संबंधित `IParagraph` के IPortion संग्रह में जोड़ें।
7. प्रत्येक पोर्शन के लिए कुछ टेक्स्ट सेट करें।
8. `IPortion` ऑब्जेक्ट द्वारा प्रदत्त फ़ॉर्मैटिंग गुणों का उपयोग करके प्रत्येक पोर्शन पर वांछित फ़ॉर्मैटिंग लागू करें।
9. संशोधित प्रेजेंटेशन सहेजें।

यह C# कोड पैराग्राफ़ में पोर्शन जोड़ने के चरणों का कार्यान्वयन है:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
using (Presentation pres = new Presentation())
{
    // पहले स्लाइड तक पहुँचता है
    ISlide slide = pres.Slides[0];

    // एक आयताकार IAutoShape जोड़ता है
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape के TextFrame तक पहुँचता है
    ITextFrame tf = ashp.TextFrame;

    // विभिन्न टेक्स्ट फ़ॉर्मेट वाले पैराग्राफ और पोर्शन बनाता है
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // संशोधित प्रेजेंटेशन को सहेजता है
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **पैराग्राफ बुलेट्स प्रबंधित करें**
बुलेट सूची आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती है। बुलेटेड पैराग्राफ हमेशा पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. चयनित स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. autoshape के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुंचें। 
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएं।
8. पैराग्राफ के लिए बुलेट `Type` को `Symbol` सेट करें और बुलेट कैरेक्टर सेट करें।
9. पैराग्राफ `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
11. बुलेट के लिए एक रंग सेट करें।
12. बुलेट की ऊँचाई सेट करें।
13. नया पैराग्राफ `TextFrame` पैराग्राफ संग्रह में जोड़ें।
14. दूसरा पैराग्राफ जोड़ें और चरण 7 से 13 तक की प्रक्रिया दोहराएँ।
15. प्रेजेंटेशन सहेजें।

यह C# कोड दिखाता है कि बुलेट पैराग्राफ कैसे जोड़ें:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
using (Presentation pres = new Presentation())
{
    // पहले स्लाइड तक पहुँचता है
    ISlide slide = pres.Slides[0];

    // ऑटोशेप जोड़ता और पहुँचता है
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // ऑटोशेप के टेक्स्ट फ्रेम तक पहुँचता है
    ITextFrame txtFrm = aShp.TextFrame;

    // डिफ़ॉल्ट पैराग्राफ हटाता है
    txtFrm.Paragraphs.RemoveAt(0);

    // एक पैराग्राफ बनाता है
    Paragraph para = new Paragraph();

    // पैराग्राफ बुलेट शैली और प्रतीक सेट करता है
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // पैराग्राफ टेक्स्ट सेट करता है
    para.Text = "Welcome to Aspose.Slides";

    // बुलेट इंडेंट सेट करता है
    para.ParagraphFormat.Indent = 25;

    // बुलेट रंग सेट करता है
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor को true सेट करें ताकि अपना बुलेट रंग उपयोग किया जा सके

    // बुलेट ऊँचाई सेट करता है
    para.ParagraphFormat.Bullet.Height = 100;

    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    txtFrm.Paragraphs.Add(para);

    // दूसरा पैराग्राफ बनाता है
    Paragraph para2 = new Paragraph();

    // पैराग्राफ बुलेट प्रकार और शैली सेट करता है
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // पैराग्राफ टेक्स्ट जोड़ता है
    para2.Text = "This is numbered bullet";

    // बुलेट इंडेंट सेट करता है
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor को true सेट करें ताकि अपना बुलेट रंग उपयोग किया जा सके

    // बुलेट ऊँचाई सेट करता है
    para2.ParagraphFormat.Bullet.Height = 100;

    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    txtFrm.Paragraphs.Add(para2);

    // संशोधित प्रेजेंटेशन को सहेजता है
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);
}
```

## **चित्र बुलेट्स प्रबंधित करें**
बुलेट सूची आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती है। चित्र पैराग्राफ पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. autoshape के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) तक पहुंचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएं।
7. [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) में छवि लोड करें।
8. बुलेट प्रकार को [Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) सेट करें और छवि सेट करें।
9. पैराग्राफ `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
11. बुलेट के लिए एक रंग सेट करें।
12. बुलेट की ऊँचाई सेट करें।
13. नया पैराग्राफ `TextFrame` पैराग्राफ संग्रह में जोड़ें।
14. दूसरा पैराग्राफ जोड़ें और पिछले चरणों के आधार पर प्रक्रिया दोहराएँ।
15. संशोधित प्रेजेंटेशन सहेजें।

यह C# कोड दिखाता है कि चित्र बुलेट कैसे जोड़ें और प्रबंधित करें:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation presentation = new Presentation();

// पहले स्लाइड तक पहुँचता है
ISlide slide = presentation.Slides[0];

// बुलेट्स के लिये इमेज का इंस्टेंस बनाता है
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// ऑटोशेप जोड़ता और पहुँचता है
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// ऑटोशेप के टेक्स्टफ़्रेम तक पहुँचता है
ITextFrame textFrame = autoShape.TextFrame;

// डिफ़ॉल्ट पैराग्राफ हटाता है
textFrame.Paragraphs.RemoveAt(0);

// नया पैराग्राफ बनाता है
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// पैराग्राफ बुलेट शैली और इमेज सेट करता है
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// बुलेट की ऊँचाई सेट करता है
paragraph.ParagraphFormat.Bullet.Height = 100;

// पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ता है
textFrame.Paragraphs.Add(paragraph);

// प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजता है
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// प्रेजेंटेशन को PPT फ़ाइल के रूप में सहेजता है
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **बहुस्तरीय बुलेट्स प्रबंधित करें**
बुलेट सूची आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती है। बहुस्तरीय बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)class का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. नई स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. autoshape के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) तक पहुंचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ बनाएं और गहराई 0 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ बनाएं और गहराई 1 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ बनाएं और गहराई 2 सेट करें।
9. `Paragraph` क्लास के माध्यम से चौथा पैराग्राफ बनाएं और गहराई 3 सेट करें।
10. नए पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
11. संशोधित प्रेजेंटेशन सहेजें।

यह C# कोड दिखाता है कि बहुस्तरीय बुलेट्स कैसे जोड़ें और प्रबंधित करें:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
using (Presentation pres = new Presentation())
{

    // पहले स्लाइड तक पहुँचता है
    ISlide slide = pres.Slides[0];
    
    // ऑटोशेप जोड़ता और पहुँचता है
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // बनाए गए ऑटोशेप के टेक्स्ट फ़्रेम तक पहुँचता है
    ITextFrame text = aShp.AddTextFrame("");
    
    // डिफ़ॉल्ट पैराग्राफ को साफ़ करता है
    text.Paragraphs.Clear();

    // पहला पैराग्राफ जोड़ता है
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // बुलेट स्तर सेट करता है
    para1.ParagraphFormat.Depth = 0;

    // दूसरा पैराग्राफ जोड़ता है
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // बुलेट स्तर सेट करता है
    para2.ParagraphFormat.Depth = 1;

    // तीसरा पैराग्राफ जोड़ता है
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // बुलेट स्तर सेट करता है
    para3.ParagraphFormat.Depth = 2;

    // चौथा पैराग्राफ जोड़ता है
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // बुलेट स्तर सेट करता है
    para4.ParagraphFormat.Depth = 3;

    // पैराग्राफ को संग्रह में जोड़ता है
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजता है
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **कस्टम नंबर्ड लिस्ट के साथ पैराग्राफ प्रबंधित करें**
[IBulletFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/) इंटरफ़ेस [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith) गुण और अन्य प्रदान करता है जो आपको कस्टम नंबरिंग या फ़ॉर्मैटिंग के साथ पैराग्राफ प्रबंधित करने की अनुमति देता है। 

1. [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)class का एक उदाहरण बनाएं।
2. पैराग्राफ वाली स्लाइड तक पहुंचें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. autoshape के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) तक पहुंचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ बनाएं और [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith) को 2 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ बनाएं और `NumberedBulletStartWith` को 3 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ बनाएं और `NumberedBulletStartWith` को 7 सेट करें।
9. नए पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
10. संशोधित प्रेजेंटेशन सहेजें।

यह C# कोड दिखाता है कि कस्टम नंबरिंग या फ़ॉर्मैटिंग के साथ पैराग्राफ कैसे जोड़ें और प्रबंधित करें:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// बनाए गए ऑटोशेप के टेक्स्ट फ्रेम तक पहुँचता है
	ITextFrame textFrame = shape.TextFrame;

	// डिफ़ॉल्ट मौजूद पैराग्राफ को हटाता है
	textFrame.Paragraphs.RemoveAt(0);

	// पहली सूची
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **पैराग्राफ के लिए प्रथम‑पंक्ति इंडेंट सेट करें**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) गुण का उपयोग करके पैराग्राफ की प्रथम‑पंक्ति इंडेंट को नियंत्रित करें। यह गुण केवल पैराग्राफ की बाएं मार्जिन की तुलना में पहली पंक्ति को ही ले जाता है। सकारात्मक मान पहली पंक्ति को दाईं ओर शिफ्ट करता है, जबकि बाकी पंक्तियां पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरे पैराग्राफ को ले जाने के लिए [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) का उपयोग करें। केवल पहली पंक्ति को ले जाने के लिए [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) का उपयोग करें।

निम्न उदाहरण कई पैराग्राफ बनाता है और विभिन्न `Indent` मान लागू करता है ताकि दिखाया जा सके कि प्रथम‑पंक्ति इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।
4. रूप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेज़ेंटेशन सहेजें।

यह कोड दिखाता है कि पैराग्राफ इंडेंट कैसे सेट करें:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![The first-line indent of the paragraphs](first_line_indent.png)

## **पैराग्राफ के लिए हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति बाकी पंक्तियों से बाएँ शुरू होती है। Aspose.Slides में आप इस प्रभाव को [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) गुण से बनाते हैं। `Indent` को नकारात्मक मान सेट करने से पहली पंक्ति पैराग्राफ बॉडी की तुलना में बाएँ खिसकती है।

व्यावहारिक रूप से, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) पैराग्राफ बॉडी की बायीं स्थिति तय करता है, और [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) पहली पंक्ति की उस मार्जिन के सापेक्ष स्थिति तय करता है। हैंगिंग इंडेंट बनाने के लिए, `MarginLeft` को सकारात्मक मान और `Indent` को नकारात्मक मान सेट करें।

यह फ़ॉर्मैटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ के लिए उपयोगी है जहाँ रैप्ड पंक्तियों को पैराग्राफ बॉडी के तहत संरेखित होना चाहिए, न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।
4. रूप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. प्रत्येक पैराग्राफ के लिए एक सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए एक नकारात्मक [Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेज़ेंटेशन सहेजें।

यह कोड दिखाता है कि पैराग्राफ के लिए हैंगिंग इंडेंट कैसे सेट करें:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![The hanging indent of the paragraphs](hanging_indent.png)

## **End पैराग्राफ रन गुण प्रबंधित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. पैराग्राफ वाले स्लाइड का उसकी स्थिति के माध्यम से संदर्भ प्राप्त करें।
1. स्लाइड में एक आयताकार [autoshape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।
1. Rectangle में दो पैराग्राफ वाले एक [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) जोड़ें।
1. पैराग्राफ के लिए `FontHeight` और फ़ॉन्ट प्रकार सेट करें।
1. पैराग्राफ के End गुण सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह C# कोड दिखाता है कि PowerPoint में पैराग्राफ के End गुण कैसे सेट करें:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **HTML टेक्स्ट को पैराग्राफ में आयात करें**
Aspose.Slides पैराग्राफ में HTML टेक्स्ट आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।
4. `autoshape` [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) जोड़ें और उसका संदर्भ प्राप्त करें।
5. `ITextFrame` में डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. एक TextReader में स्रोत HTML फ़ाइल पढ़ें।
7. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ बनाएं।
8. पढ़े गए TextReader की सामग्री को TextFrame के [ParagraphCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/) में जोड़ें।
9. संशोधित प्रेज़ेंटेशन सहेजें।

यह C# कोड HTML टेक्स्ट को पैराग्राफ में आयात करने के चरणों का कार्यान्वयन है:

```c#
// खाली प्रेजेंटेशन इंस्टेंस बनाता है
using (Presentation pres = new Presentation())
{
    // प्रेजेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचता है
    ISlide slide = pres.Slides[0];

    // HTML सामग्री रखने के लिए ऑटोशेप जोड़ता है
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // शेप में टेक्स्ट फ़्रेम जोड़ता है
    ashape.AddTextFrame("");

    // जोड़े गए टेक्स्ट फ़्रेम में सभी पैराग्राफ साफ़ करता है
    ashape.TextFrame.Paragraphs.Clear();

    // स्ट्रीम रीडर का उपयोग करके HTML फ़ाइल लोड करता है
    TextReader tr = new StreamReader("file.html");

    // HTML स्ट्रीम रीडर से टेक्स्ट को टेक्स्ट फ़्रेम में जोड़ता है
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // प्रेजेंटेशन सहेजता है
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**
Aspose.Slides पैराग्राफ में मौजूद टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं और इच्छित प्रेज़ेंटेशन लोड करें।
2. उसके इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. HTML में निर्यात किए जाने वाले टेक्स्ट वाले शेप तक पहुंचें।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) तक पहुंचें।
5. `StreamWriter` का एक उदाहरण बनाएं और नई HTML फ़ाइल जोड़ें।
6. `StreamWriter` के लिए प्रारंभिक इंडेक्स प्रदान करें और अपनी पसंदीदा पैराग्राफ निर्यात करें।

यह C# कोड दिखाता है कि PowerPoint पैराग्राफ टेक्स्ट को HTML में कैसे निर्यात करें:

```c#
// प्रेजेंटेशन फ़ाइल लोड करता है
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // प्रेजेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुँचता है
    ISlide slide = pres.Slides[0];

    // आवश्यक सूचकांक तक पहुँचता है
    int index = 0;

    // जोड़े गए शेप तक पहुँचता है
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // पैराग्राफ डेटा को HTML में लिखता है, पैराग्राफ शुरू होने वाले सूचकांक और कॉपी किए जाने वाले पैराग्राफों की संख्या निर्दिष्ट करके
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **पैराग्राफ को छवि के रूप में सहेजें**

इस अनुभाग में हम दो उदाहरणों का अध्ययन करेंगे जो दिखाते हैं कि कैसे [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) इंटरफ़ेस द्वारा प्रतिनिधित्व किए गए टेक्स्ट पैराग्राफ को छवि के रूप में सहेजा जा सकता है। दोनों उदाहरणों में [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) इंटरफ़ेस के GetImage मेथड का उपयोग करके पैराग्राफ वाले शेप की छवि प्राप्त करना, शेप में पैराग्राफ की सीमाएँ गणना करना, और उसे बिटमैप छवि के रूप में निर्यात करना शामिल है। ये तरीके आपको PowerPoint प्रेज़ेंटेशन से टेक्स्ट के विशिष्ट भाग निकालने और उन्हें अलग-अलग छवियों के रूप में सहेजने की अनुमति देते हैं, जो विभिन्न परिदृश्यों में उपयोगी हो सकते हैं।

मान लीजिए हमारे पास sample.pptx नाम की एक प्रेज़ेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![The text box with three paragraphs](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में हम दूसरे पैराग्राफ को छवि के रूप में प्राप्त करते हैं। इसके लिए हम प्रेज़ेंटेशन की पहली स्लाइड से शेप की छवि निकालते हैं और फिर शेप के टेक्स्ट फ्रेम में दूसरे पैराग्राफ की सीमाएँ गणना करते हैं। पैराग्राफ को नए बिटमैप इमेज पर फिर से ड्रॉ किया जाता है और PNG फ़ॉर्मेट में सहेजा जाता है। यह विधि विशेष रूप से तब उपयोगी होती है जब आपको विशिष्ट पैराग्राफ को अलग छवि के रूप में सहेजना हो जबकि टेक्स्ट की सटीक आयाम और फ़ॉर्मैटिंग बनाए रखना हो।

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// आकृति को मेमोरी में बिटमैप के रूप में सहेजता है।
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// मेमोरी से एक आकार बिटमैप बनाता है।
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// दूसरे पैराग्राफ की सीमाएँ गणना करता है।
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// आउटपुट छवि के आकार की गणना करता है (न्यूनतम आकार - 1x1 पिक्सेल)।
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// पैराग्राफ के लिए बिटमैप तैयार करता है।
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// आकार बिटमैप से पैराग्राफ बिटमैप पर पैराग्राफ को पुनः चित्रित करता है।
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

परिणाम:

![The paragraph image](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में हम पूर्ववर्ती विधि को पैराग्राफ छवि में स्केलिंग फैक्टर जोड़कर विस्तारित करते हैं। शेप को प्रेज़ेंटेशन से निकालकर `2` स्केल फ़ैक्टर के साथ छवि के रूप में सहेजा जाता है। इससे निर्यातित पैराग्राफ की रेज़ॉल्यूशन बढ़ती है। पैराग्राफ की सीमाएँ स्केल को ध्यान में रखकर गणना की जाती हैं। उच्च‑रिज़ॉल्यूशन छवि की आवश्यकता होने पर, जैसे हाई‑क्वालिटी प्रिंट सामग्री में उपयोग, यह विशेष रूप से उपयोगी है।

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// स्केलिंग के साथ आकृति को मेमोरी में बिटमैप के रूप में सहेजता है।
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// मेमोरी से एक आकृति बिटमैप बनाता है।
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// दूसरे पैराग्राफ की सीमाएँ गणना करता है।
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// आउटपुट छवि के आकार की गणना करता है (न्यूनतम आकार - 1x1 पिक्सेल)।
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// पैराग्राफ के लिए बिटमैप तैयार करता है।
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// आकृति बिटमैप से पैराग्राफ बिटमैप पर पैराग्राफ को पुनः चित्रित करता है।
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ़्रेम के भीतर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। टेक्स्ट फ़्रेम की रैपिंग सेटिंग ([WrapText](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/wraptext/)) का उपयोग करके रैपिंग बंद कर सकते हैं ताकि लाइनें फ्रेम के किनारों पर नहीं टूटें।

**मैं विशिष्ट पैराग्राफ की स्लाइड पर सटीक सीमाएँ कैसे प्राप्त कर सकूँ?**

आप पैराग्राफ (और यहाँ तक कि एकल पोर्शन) का बाउंडिंग रेक्टैंगल प्राप्त करके उसकी सटीक स्थिति और आकार स्लाइड पर जान सकते हैं।

**पैराग्राफ संरेखण (बाएँ/दाएँ/केन्द्र/जस्टिफ़ाई) कहाँ नियंत्रित किया जाता है?**

[Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphformat/alignment/) ParagraphFormat में पैराग्राफ‑स्तर की सेटिंग है; यह पूरे पैराग्राफ पर लागू होती है चाहे व्यक्तिगत पोर्शन की फ़ॉर्मैटिंग कुछ भी हो।

**क्या मैं केवल पैराग्राफ के भाग (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**

हाँ। भाषा पोर्शन स्तर पर सेट की जाती है ([PortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/languageid/)), इसलिए एक ही पैराग्राफ में कई भाषाएँ सह-अस्तित्व रख सकती हैं।