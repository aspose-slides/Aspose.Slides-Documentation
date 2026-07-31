---
title: ".NET में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें"
linktitle: "पैराग्राफ प्रबंधित करें"
type: docs
weight: 40
url: /hi/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
  - "टेक्स्ट जोड़ें"
  - "पैराग्राफ जोड़ें"
  - "टेक्स्ट प्रबंधित करें"
  - "पैराग्राफ प्रबंधित करें"
  - "बुलेट प्रबंधित करें"
  - "पैराग्राफ इंडेंट"
  - "हैंगिंग इंडेंट"
  - "पैराग्राफ बुलेट"
  - "नंबरित सूची"
  - "बुलेटेड सूची"
  - "पैराग्राफ प्रॉपर्टीज़"
  - "HTML आयात करें"
  - "टेक्स्ट से HTML"
  - "पैराग्राफ से HTML"
  - "पैराग्राफ से इमेज"
  - "टेक्स्ट से इमेज"
  - "पैराग्राफ निर्यात करें"
  - "PowerPoint"
  - "प्रेजेंटेशन"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ पैराग्राफ फ़ॉर्मेटिंग में महारत हासिल करें—PPT, PPTX, और ODP प्रेजेंटेशनों में संरेखण, स्पेसिंग और शैली को C# में अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides वह सभी इंटरफ़ेस और क्लासें प्रदान करता है जिनकी आपको C# में PowerPoint के टेक्स्ट, पैराग्राफ और पोर्शन के साथ काम करने के लिए आवश्यकता है।

* Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) इंटरफ़ेस प्रदान करता है जो आपको पैराग्राफ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने की अनुमति देता है। एक `ITextFame` ऑब्जेक्ट में एक या कई पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ कैरिज रिटर्न के माध्यम से बनाया जाता है)।
* Aspose.Slides [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) इंटरफ़ेस प्रदान करता है जो आपको पोर्शन का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने की अनुमति देता है। एक `IParagraph` ऑब्जेक्ट में एक या कई पोर्शन हो सकते हैं (iPortions ऑब्जेक्ट्स का संग्रह)।
* Aspose.Slides [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) इंटरफ़ेस प्रदान करता है जो आपको टेक्स्ट और उनके फ़ॉर्मेटिंग प्रॉपर्टीज़ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ने की अनुमति देता है।  

एक `IParagraph` ऑब्जेक्ट अपने अंतर्निहित `IPortion` ऑब्जेक्ट्स के माध्यम से विभिन्न फ़ॉर्मेटिंग प्रॉपर्टीज़ वाले टेक्स्ट को संभाल सकता है।

## **एक ही टेक्स्ट फ्रेम में कई पैराग्राफ और कई पोर्शन जोड़ना**

इन चरणों में दिखाया गया है कि कैसे 3 पैराग्राफ वाला एक टेक्स्ट फ्रेम जोड़ें और प्रत्येक पैराग्राफ में 3 पोर्शन रखें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएँ।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक Rectangle [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. उस [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) से जुड़ा `ITextFrame` प्राप्त करें।
5. दो [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) ऑब्जेक्ट बनाकर उन्हें [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) की `IParagraphs` संग्रह में जोड़ें।
6. प्रत्येक नए `IParagraph` के लिए तीन [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) ऑब्जेक्ट बनाएं (डिफ़ॉल्ट पैराग्राफ के लिए दो Portion ऑब्जेक्ट) और प्रत्येक `IPortion` को प्रत्येक `IParagraph` की IPortion संग्रह में जोड़ें।
7. प्रत्येक पोर्शन के लिए कुछ टेक्स्ट सेट करें।
8. प्रत्येक पोर्शन पर `IPortion` ऑब्जेक्ट द्वारा प्रदान की गई फ़ॉर्मेटिंग प्रॉपर्टीज़ का उपयोग करके अपनी इच्छित फ़ॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन को सेव करें।

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
using (Presentation pres = new Presentation())
{
    // पहली स्लाइड तक पहुंचता है
    ISlide slide = pres.Slides[0];

    // एक Rectangle IAutoShape जोड़ता है
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape के TextFrame तक पहुंचता है
    ITextFrame tf = ashp.TextFrame;

    // विभिन्न टेक्स्ट फ़ॉर्मेट्स के साथ Paragraphs और Portions बनाता है
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
बुलेट लिस्ट्स आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बुलेटेड पैराग्राफ हमेशा पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएँ।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. चयनित स्लाइड में एक [ऑटोशेप](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. ऑटोशेप के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) तक पहुंचें। 
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएँ।
8. पैराग्राफ की बुल्लेट `Type` को `Symbol` सेट करें और बुलेट कैरेक्टर निर्धारित करें।
9. पैराग्राफ का `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
11. बुलेट के लिए एक रंग निर्धारित करें।
12. बुलेट की ऊँचाई सेट करें।
13. नए पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
14. दूसरा पैराग्राफ जोड़ें और चरण 7 से 13 तक की प्रक्रिया दोहराएँ।
15. प्रेजेंटेशन को सेव करें।

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
using (Presentation pres = new Presentation())
{

    // पहली स्लाइड तक पहुंचता है
    ISlide slide = pres.Slides[0];


    // ऑटोशेप जोड़ता है और उसकी पहुंच हासिल करता है
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // ऑटोशेप के टेक्स्ट फ्रेम तक पहुंचता है
    ITextFrame txtFrm = aShp.TextFrame;

    // डिफ़ॉल्ट पैराग्राफ को हटाता है
    txtFrm.Paragraphs.RemoveAt(0);

    // एक पैराग्राफ बनाता है
    Paragraph para = new Paragraph();

    // पैराग्राफ बुलेट शैली और संकेत सेट करता है
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // पैराग्राफ का टेक्स्ट सेट करता है
    para.Text = "Welcome to Aspose.Slides";

    // बुलेट इंडेंट सेट करता है
    para.ParagraphFormat.Indent = 25;

    // बुलेट रंग सेट करता है
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor को true सेट करें ताकि अपना बुलेट रंग उपयोग किया जा सके

    // बुलेट की ऊँचाई सेट करता है
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

    // बुलेट की ऊँचाई सेट करता है
    para2.ParagraphFormat.Bullet.Height = 100;

    // पैराग्राफ को टेक्स्ट फ्रेम में जोड़ता है
    txtFrm.Paragraphs.Add(para2);


    // संशोधित प्रेजेंटेशन को सहेजता है
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **चित्र बुलेट्स प्रबंधित करें**
बुलेट लिस्ट्स आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। चित्र पैराग्राफ पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएँ।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [ऑटोशेप](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. ऑटोशेप के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) तक पहुंचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ इंस्टेंस बनाएँ।
7. [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) में इमेज लोड करें।
8. बुलेट टाइप को [Picture](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) सेट करें और इमेज निर्धारित करें।
9. पैराग्राफ का `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ `Indent` सेट करें।
11. बुलेट के लिए एक रंग निर्धारित करें।
12. बुलेट की ऊँचाई सेट करें।
13. नए पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
14. दूसरा पैराग्राफ जोड़ें और पिछले चरणों के आधार पर प्रक्रिया दोहराएँ।
15. संशोधित प्रेजेंटेशन को सेव करें।

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
Presentation presentation = new Presentation();

// पहली स्लाइड तक पहुंचता है
ISlide slide = presentation.Slides[0];

// बुलेट्स के लिए इमेज का इंस्टैंस बनाता है
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// ऑटोशेप जोड़ता है और उसकी पहुंच हासिल करता है
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// ऑटोशेप के टेक्स्टफ़्रेम तक पहुंचता है
ITextFrame textFrame = autoShape.TextFrame;

// डिफ़ॉल्ट पैराग्राफ को हटाता है
textFrame.Paragraphs.RemoveAt(0);

// एक नया पैराग्राफ बनाता है
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// पैराग्राफ बुलेट शैली और इमेज सेट करता है
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// बुलेट की ऊँचाई सेट करता है
paragraph.ParagraphFormat.Bullet.Height = 100;

// पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ता है
textFrame.Paragraphs.Add(paragraph);

// प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखता है
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// प्रेजेंटेशन को PPT फ़ाइल के रूप में लिखता है
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **बहु‑स्तरीय बुलेट्स प्रबंधित करें**
बुलेट लिस्ट्स आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बहु‑स्तरीय बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएँ।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. नए स्लाइड में एक [ऑटोशेप](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. ऑटोशेप के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) तक पहुंचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएँ और डेप्थ को 0 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ इंस्टेंस बनाएँ और डेप्थ को 1 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ इंस्टेंस बनाएँ और डेप्थ को 2 सेट करें।
9. `Paragraph` क्लास के माध्यम से चौथा पैराग्राफ इंस्टेंस बनाएँ और डेप्थ को 3 सेट करें।
10. नए पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
11. संशोधित प्रेजेंटेशन को सेव करें।

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
using (Presentation pres = new Presentation())
{

    // पहली स्लाइड तक पहुंचता है
    ISlide slide = pres.Slides[0];
    
    // ऑटोशेप जोड़ता है और उसकी पहुंच हासिल करता है
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // बनाए गए ऑटोशेप के टेक्स्ट फ्रेम तक पहुंचता है
    ITextFrame text = aShp.AddTextFrame("");
    
    // डिफ़ॉल्ट पैराग्राफ को हटाता है
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

    // पैराग्राफ को कलेक्शन में जोड़ता है
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखता है
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **कस्टम क्रमांकित सूची के साथ पैराग्राफ प्रबंधित करें**
[IBulletFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/) इंटरफ़ेस [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith) प्रॉपर्टी और अन्य प्रदान करता है जो आपको कस्टम नंबरिंग या फ़ॉर्मेटिंग के साथ पैराग्राफ प्रबंधित करने की अनुमति देता है।

1. [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएँ।
2. उस स्लाइड तक पहुंचें जिसमें पैराग्राफ है।
3. स्लाइड में एक [ऑटोशेप](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) जोड़ें।
4. ऑटोशेप के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) तक पहुंचें।
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएँ और [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/net/aspose.slides/ibulletformat/numberedbulletstartwith) को 2 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरा पैराग्राफ इंस्टेंस बनाएँ और `NumberedBulletStartWith` को 3 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरा पैराग्राफ इंस्टेंस बनाएँ और `NumberedBulletStartWith` को 7 सेट करें।
9. नए पैराग्राफ को `TextFrame` पैराग्राफ संग्रह में जोड़ें।
10. संशोधित प्रेजेंटेशन को सेव करें।

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// बनाए गए ऑटोशेप के टेक्स्ट फ्रेम तक पहुंचता है
	ITextFrame textFrame = shape.TextFrame;

	// डिफ़ॉल्ट मौजूदा पैराग्राफ को हटाता है
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

## **पैराग्राफ के पहले लाइन के इंडेंट को सेट करें**

पहली लाइन के इंडेंट को नियंत्रित करने के लिए आप [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी का उपयोग कर सकते हैं। यह प्रॉपर्टी केवल पैराग्राफ की बाएँ मार्जिन के सापेक्ष पहली लाइन को ही स्थानांतरित करती है। सकारात्मक मान पहली लाइन को दाएँ शिफ्ट करता है, जबकि बाकी लाइनों का लेआउट अपरिवर्तित रहता है।

यदि आपको पूरे पैराग्राफ को स्थानांतरित करना है तो [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) का उपयोग करें। केवल पहली लाइन को स्थानांतरित करने के लिए [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न `Indent` मान लागू करता है ताकि दिखाया जा सके कि पहली लाइन का इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।
4. शेप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सेव करें।

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

## **पैराग्राफ के हैंगिंग इंडेंट को सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली लाइन बाकी लाइनों से बाईं ओर शुरू होती है। Aspose.Slides में आप इसे [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) प्रॉपर्टी से बनाते हैं। पहली लाइन को पैराग्राफ बॉडी के सापेक्ष बाएँ शिफ्ट करने के लिए `Indent` को नकारात्मक मान पर सेट करें।

व्यावहारिक रूप से, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [IParagraphFormat.Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) पहली लाइन की उस मार्जिन से स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, सकारात्मक `MarginLeft` मान और नकारात्मक `Indent` मान सेट करें।

यह फ़ॉर्मेटिंग बायब्लियोग्राफी, रेफ़रेंसेस, शब्दकोश प्रविष्टियों आदि के लिए उपयोगी है जहाँ रैप की गई लाइनों को पैराग्राफ बॉडी के अंतर्गत संरेखित होना चाहिए, न कि पहली लाइन के पहले अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।
4. शेप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. प्रत्येक पैराग्राफ के लिए सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/marginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [Indent](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/indent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सेव करें।

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

## **एंड पैराग्राफ रन प्रॉपर्टीज प्रबंधित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएँ।
1. स्लाइड के पोजीशन के माध्यम से उस स्लाइड का रेफ़रेंस प्राप्त करें जिसमें पैराग्राफ है।
1. स्लाइड में एक आयताकार [ऑटोशेप](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।
1. आयताकार में दो पैराग्राफ वाला एक [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) जोड़ें।
1. पैराग्राफ के `FontHeight` और फ़ॉन्ट प्रकार सेट करें।
1. पैराग्राफ के End प्रॉपर्टीज़ सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

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

## **पैराग्राफ में HTML टेक्स्ट आयात करें**
Aspose.Slides HTML टेक्स्ट को पैराग्राफ में आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएँ।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [ऑटोशेप](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) जोड़ें।
4. `ऑटोशेप` का [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्राप्त करके उससे जुड़ें।
5. `ITextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक TextReader में स्रोत HTML फ़ाइल पढ़ें।
7. [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/) क्लास के माध्यम से पहला पैराग्राफ इंस्टेंस बनाएँ।
8. पढ़े गए TextReader की सामग्री को TextFrame की [ParagraphCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphcollection/) में जोड़ें।
9. संशोधित प्रेजेंटेशन को सेव करें।

```c#
// खाली प्रस्तुति इंस्टैंस बनाता है
using (Presentation pres = new Presentation())
{
    // प्रस्तुति की डिफ़ॉल्ट पहली स्लाइड तक पहुंचता है
    ISlide slide = pres.Slides[0];

    // HTML सामग्री रखने के लिए ऑटोशेप जोड़ता है
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // शेप में टेक्स्ट फ्रेम जोड़ता है
    ashape.AddTextFrame("");

    // जोड़े गए टेक्स्ट फ्रेम में सभी पैराग्राफ साफ़ करता है
    ashape.TextFrame.Paragraphs.Clear();

    // स्ट्रीम रीडर का उपयोग करके HTML फ़ाइल लोड करता है
    TextReader tr = new StreamReader("file.html");

    // HTML स्ट्रीम रीडर से टेक्स्ट को टेक्स्ट फ्रेम में जोड़ता है
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // प्रेजेंटेशन को सेव करता है
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**
Aspose.Slides पैराग्राफ में मौजूद टेक्स्ट को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाकर इच्छित प्रेजेंटेशन लोड करें।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. वह शेप प्राप्त करें जिसमें वह टेक्स्ट है जिसे HTML में निर्यात किया जाएगा।
4. शेप के [TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/) तक पहुंचें।
5. एक `StreamWriter` का उदाहरण बनाकर नई HTML फ़ाइल जोड़ें।
6. StreamWriter को प्रारंभिक इंडेक्स प्रदान करें और अपनी इच्छित पैराग्राफ निर्यात करें।

```c#
// प्रेजेंटेशन फ़ाइल लोड करता है
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // प्रेजेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुंचता है
    ISlide slide = pres.Slides[0];

    // आवश्यक इंडेक्स तक पहुंचता है
    int index = 0;

    // जोड़ी गई शेप तक पहुंचता है
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // पैराग्राफ डेटा को HTML में लिखता है, पैराग्राफ शुरुआती इंडेक्स और कॉपी किए जाने वाले पैराग्राफ की संख्या निर्दिष्ट करके
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **पैराग्राफ को चित्र के रूप में सहेजें**

इस अनुभाग में हम दो उदाहरणों के माध्यम से दिखाएंगे कि कैसे [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) इंटरफ़ेस द्वारा प्रतिनिधित्व किए गए टेक्स्ट पैराग्राफ को एक चित्र के रूप में सहेजा जा सकता है। दोनों उदाहरणों में पैराग्राफ वाले शेप की इमेज `GetImage` मेथड्स से प्राप्त की जाती है, शेप के भीतर पैराग्राफ की सीमा की गणना की जाती है, और उसे बिटमैप इमेज के रूप में एक्सपोर्ट किया जाता है। ये विधियाँ आपको पॉवरपॉइंट प्रेजेंटेशनों से टेक्स्ट के विशिष्ट भाग निकालने और उन्हें अलग-अलग इमेज के रूप में सहेजने की सुविधा देती हैं, जो विभिन्न परिदृश्यों में उपयोगी हो सकती हैं।

मान लीजिए हमारे पास sample.pptx नामक एक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, और पहली शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![The text box with three paragraphs](paragraph_to_image_input.png)

**उदाहरण 1**

इस उदाहरण में हम दूसरे पैराग्राफ को इमेज के रूप में प्राप्त करते हैं। इसके लिये हम प्रेजेंटेशन की पहली स्लाइड से शेप की इमेज निकालते हैं और फिर शेप के टेक्स्ट फ्रेम में दूसरे पैराग्राफ की सीमा की गणना करते हैं। पैराग्राफ को फिर एक नई बिटमैप इमेज पर फिर से ड्रॉ किया जाता है और PNG फ़ॉर्मेट में सहेजा जाता है। यह विधि विशेष रूप से तब उपयोगी होती है जब आपको विशिष्ट पैराग्राफ को अलग इमेज के रूप में सहेजना हो जबकि टेक्स्ट का सटीक आयाम और फ़ॉर्मेटिंग बरकरार रहे।

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

परिणाम:

![The paragraph image](paragraph_to_image_output.png)

**उदाहरण 2**

इस उदाहरण में हम पिछले तरीके को स्केलिंग फ़ैक्टर जोड़कर विस्तारित करते हैं। शेप को प्रेजेंटेशन से निकालकर `2` के स्केलिंग फ़ैक्टर के साथ इमेज के रूप में सहेजा जाता है। इससे पैराग्राफ को एक्सपोर्ट करते समय उच्च रेज़ॉल्यूशन प्राप्त होता है। फिर स्केल को ध्यान में रखते हुए पैराग्राफ की सीमा की गणना की जाती है। स्केलिंग तब उपयोगी होती है जब उच्च गुणवत्ता वाली प्रिंटिंग सामग्री के लिए अधिक विस्तृत इमेज की आवश्यकता होती है।

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// स्केलिंग के साथ शेप को मेमोरी में एक बिटमैप के रूप में सहेजें।
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// मेमोरी से शेप बिटमैप बनाएं।
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// दूसरे पैराग्राफ की सीमाएं गणना करें।
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// आउटपुट इमेज का आकार गणना करें (न्यूनतम आकार - 1x1 पिक्सेल)।
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// पैराग्राफ के लिए बिटमैप तैयार करें।
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// शेप बिटमैप से पैराग्राफ बिटमैप पर पैराग्राफ को पुनः ड्रॉ करें।
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के अंदर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। टेक्स्ट फ्रेम की रैपिंग सेटिंग ([WrapText](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/wraptext/)) का उपयोग करके रैपिंग को बंद कर सकते हैं जिससे लाइनों को फ्रेम की किनारों पर टूटना नहीं होगा।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक सीमा कैसे प्राप्त कर सकता हूँ?**

आप पैराग्राफ (और यहाँ तक कि एकल पोर्शन) की बाउंडिंग रेक्टेंगल प्राप्त कर सकते हैं जिससे उसकी सटीक स्थिति और आकार स्लाइड पर पता चल सके।

**पैराग्राफ एलाइनमेंट (बाएं/दाएं/केंद्र/जस्टिफ़ाई) कहाँ नियंत्रित होती है?**

[Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphformat/alignment/) पैराग्राफ स्तर की सेटिंग है जो [ParagraphFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraphformat/) में होती है; यह पूरे पैराग्राफ पर लागू होती है चाहे व्यक्तिगत पोर्शन का फ़ॉर्मेट कुछ भी हो।

**क्या मैं पैराग्राफ के केवल एक भाग (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**

हां। भाषा पोर्शन स्तर पर सेट होती है ([PortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/languageid/)), इसलिए एक ही पैराग्राफ में कई भाषाएँ coexist कर सकती हैं।