---
title: .NET में प्रस्तुतियों में ActiveX नियंत्रणों को प्रबंधित करना
linktitle: ActiveX
type: docs
weight: 80
url: /hi/net/activex/
keywords:
- ActiveX
- ActiveX नियंत्रण
- ActiveX का प्रबंधन
- ActiveX जोड़ें
- ActiveX संशोधित करें
- मीडिया प्लेयर
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "जानें कि Aspose.Slides for .NET कैसे ActiveX का उपयोग करके PowerPoint प्रस्तुतियों को स्वचालित और सुधरता है, जिससे डेवलपर्स को स्लाइड्स पर शक्तिशाली नियंत्रण मिलता है।"
---
## **परिचय**

ActiveX नियंत्रणों का उपयोग प्रस्तुतियों में किया जाता है। Aspose.Slides for .NET आपको ActiveX नियंत्रणों को प्रबंधित करने की अनुमति देता है, लेकिन उनका प्रबंधन सामान्य प्रस्तुति आकारों से कुछ अधिक जटिल और अलग होता है। Aspose.Slides for .NET 6.9.0 से, यह घटक ActiveX नियंत्रणों के प्रबंधन का समर्थन करता है। वर्तमान में, आप अपनी प्रस्तुति में पहले से जोड़े गए ActiveX नियंत्रण तक पहुंच सकते हैं और उसके विभिन्न गुणों का उपयोग करके उसे संशोधित या हटाना सकते हैं। ध्यान रखें, ActiveX नियंत्रण आकार नहीं होते और प्रस्तुति के IShapeCollection का हिस्सा नहीं होते, बल्कि अलग IControlCollection में होते हैं। यह लेख दर्शाता है कि उनके साथ कैसे काम किया जाए।

## **ActiveX नियंत्रणों को संशोधित करें**
एक स्लाइड पर टेक्स्ट बॉक्स और साधारण कमांड बटन जैसे सरल ActiveX नियंत्रण को प्रबंधित करने के लिए:

1. Presentation क्लास का एक उदाहरण बनाएं और उसमें ActiveX नियंत्रणों वाली प्रस्तुति लोड करें।
1. उसके इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
1. IControlCollection तक पहुंचकर स्लाइड में मौजूद ActiveX नियंत्रणों को प्राप्त करें।
1. ControlEx ऑब्जेक्ट का उपयोग करके TextBox1 ActiveX नियंत्रण तक पहुंचें।
1. TextBox1 ActiveX नियंत्रण के विभिन्न गुणों जैसे टेक्स्ट, फ़ॉन्ट, फ़ॉन्ट ऊँचाई और फ्रेम स्थिति को बदलें।
1. दूसरे नियंत्रण जिसे CommandButton1 कहा जाता है, तक पहुंचें।
1. बटन का कैप्शन, फ़ॉन्ट और स्थिति बदलें।
1. ActiveX नियंत्रणों के फ्रेम की स्थिति को शिफ्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

नीचे दिया गया कोड स्निपेट प्रस्तुति स्लाइडों पर ActiveX नियंत्रणों को नीचे दिखाए अनुसार अपडेट करता है।

```c#
// ActiveX नियंत्रणों के साथ प्रस्तुति को एक्सेस करना
Presentation presentation = new Presentation("ActiveX.pptm");

// प्रस्तुति में पहली स्लाइड को एक्सेस करना
ISlide slide = presentation.Slides[0];

// TextBox टेक्स्ट को बदलना
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // प्रतिस्थापन चित्र बदलना। PowerPoint ActiveX सक्रियकरण के दौरान इस चित्र को बदल देगा, इसलिए कभी‑कभी इसे जैसा का तैसा छोड़ना ठीक है।

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// बटन कैप्शन बदलना
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // प्रतिस्थापन बदलना
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// ActiveX फ्रेम्स को 100 पॉइंट नीचे ले जाना
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// सहेजें प्रस्तुति संपादित ActiveX नियंत्रणों के साथ
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// अब नियंत्रणों को हटाया जा रहा है
slide.Controls.Clear();

// साफ किए गए ActiveX नियंत्रणों के साथ प्रस्तुति सहेजना
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **ActiveX मीडिया प्लेयर नियंत्रण जोड़ें**
ActiveX मीडिया प्लेयर नियंत्रण जोड़ने के लिए, निम्नलिखित चरणों को पूरा करें:

1. Presentation क्लास का एक उदाहरण बनाएं और उसमें Media Player ActiveX नियंत्रण वाली नमूना प्रस्तुति लोड करें।
1. लक्ष्य Presentation क्लास का एक उदाहरण बनाएं और खाली प्रस्तुति उत्पन्न करें।
1. टेम्प्लेट प्रस्तुति से Media Player ActiveX नियंत्रण वाली स्लाइड को लक्ष्य Presentation में क्लोन करें।
1. लक्ष्य Presentation में क्लोन की गयी स्लाइड तक पहुंचें।
1. IControlCollection तक पहुंचकर स्लाइड में मौजूद ActiveX नियंत्रणों को प्राप्त करें।
1. Media Player ActiveX नियंत्रण तक पहुंचें और उसकी गुणों का उपयोग करके वीडियो पथ सेट करें।
1. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```c#
// PPTX फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
Presentation presentation = new Presentation("template.pptx");

// खाली प्रस्तुति इंस्टेंस बनाएं
Presentation newPresentation = new Presentation();

// डिफ़ॉल्ट स्लाइड हटाएं
newPresentation.Slides.RemoveAt(0);

// Media Player ActiveX नियंत्रण वाली स्लाइड को क्लोन करें
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Media Player ActiveX नियंत्रण को एक्सेस करें और वीडियो पथ सेट करें
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// प्रस्तुति सहेजें
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides .NET रनटाइम में निष्पादित नहीं हो पाने पर पढ़ने और पुनः सहेजने के दौरान ActiveX नियंत्रणों को संरक्षित रखता है?**

हां। Aspose.Slides उन्हें प्रस्तुति का हिस्सा मानता है और उनके गुणों व फ्रेम को पढ़/संशोधित कर सकता है; नियंत्रणों को स्वयं निष्पादित करना इनके संरक्षण के लिए आवश्यक नहीं है।

**ActiveX नियंत्रण प्रस्तुति में OLE ऑब्जेक्ट्स से कैसे अलग होते हैं?**

ActiveX नियंत्रण इंटरैक्टिव प्रबंधित नियंत्रण होते हैं (बटन, टेक्स्ट बॉक्स, मीडिया प्लेयर), जबकि [OLE](/slides/hi/net/manage-ole/) एम्बेडेड एप्लिकेशन ऑब्जेक्ट्स को दर्शाता है (जैसे, Excel कार्यपत्रक)। वे अलग तरीके से संग्रहीत और संभाले जाते हैं तथा उनकी प्रॉपर्टी मॉडल अलग होती है।

**क्या Aspose.Slides द्वारा फ़ाइल संशोधित होने पर ActiveX इवेंट्स और VBA मैक्रो काम करते हैं?**

Aspose.Slides मौजूदा मार्कअप और मेटाडेटा को संरक्षित रखता है; हालांकि इवेंट्स और मैक्रो केवल Windows पर PowerPoint में तब ही चलते हैं जब सुरक्षा अनुमति देती है। लाइब्रेरी VBA को निष्पादित नहीं करती।