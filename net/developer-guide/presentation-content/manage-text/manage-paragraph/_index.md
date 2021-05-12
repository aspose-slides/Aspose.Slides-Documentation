---
title: Manage Paragraph
type: docs
weight: 30
url: /net/manage-paragraph/
---

## **Multiple Paragraphs having Multiple Portions**
An ITextFame object can have one or more Paragraphs (every paragraph is created through a carriage return), that is a collection of IParagraph objects. Furthermore, an IParagraph object can have one or more Portions (a collection of IPortion objects. An IPortion object manages text and its formatting properties. So, it means that IParagraph object has capacity to handle text with different formatting properties through its underlying IPortion objects.
Please follow the steps below to add TextFrame having 3 paragraphs and 3 portions for each paragraph using Aspose.Slides for .NET :

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type to the slide.
- Access the ITextFrame associated with the IAutoShape.
- Create two IParagraph objects and add it to the IParagraphs collection of the ITextFrame.
- Create three IPortion objects for each new IParagraph (two Portion objects for default Paragraph) and add each IPortion object to the IPortions collection of each IParagraph.
- Set some text for each Portion.
- Apply the desired formatting features to each Portion using different formatting properties exposed by IPortion object.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

// Create directory if it is not already present.
bool IsExists = System.IO.Directory.Exists(dataDir);
if (!IsExists)
    System.IO.Directory.CreateDirectory(dataDir);

// Instantiate a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{
    // Accessing first slide
    ISlide slide = pres.Slides[0];

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Access TextFrame of the AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Create Paragraphs and Portions with different text formats
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

    //Write PPTX to Disk
    pres.Save(dataDir + "multiParaPort_out.pptx", SaveFormat.Pptx);
}
```




## **Paragraph Bullets in PPTX**
This topic is also the part of the topic series of managing text paragraphs. This page will illustrate how we can manage paragraph bullets. Bullets are more useful where something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see how developers can use this small yet powerful feature of Aspose.Slides for .NET. Please follow the steps below to manage the paragraph bullets using Aspose.Slides for .NET:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in a selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class.
- Set the bullet type of the paragraph.
- Set the bullet type to Symbol and set the bullet character.
- Set the Paragraph Text.
- Set the Paragraph Indent to set the bullet.
- Set the Color of Bullet.
- Set the Height of Bullets.
- Add the created paragraph in TextFrame paragraph collection.
- Add the second paragraph and repeat the process given in steps 7 to 13.
- Save the presentation.

The implementation of the above steps is given below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

// Create directory if it is not already present.
bool IsExists = System.IO.Directory.Exists(dataDir);
if (!IsExists)
    System.IO.Directory.CreateDirectory(dataDir);

// Creating a presenation instance
using (Presentation pres = new Presentation())
{

    // Accessing the first slide
    ISlide slide = pres.Slides[0];


    // Adding and accessing Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accessing the text frame of created autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Removing the default exisiting paragraph
    txtFrm.Paragraphs.RemoveAt(0);

    // Creating a paragraph
    Paragraph para = new Paragraph();

    // Setting paragraph bullet style and symbol
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Setting paragraph text
    para.Text = "Welcome to Aspose.Slides";

    // Setting bullet indent
    para.ParagraphFormat.Indent = 25;

    // Setting bullet color
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // set IsBulletHardColor to true to use own bullet color

    // Setting Bullet Height
    para.ParagraphFormat.Bullet.Height = 100;

    // Adding Paragraph to text frame
    txtFrm.Paragraphs.Add(para);

    // Creating second paragraph
    Paragraph para2 = new Paragraph();

    // Setting paragraph bullet type and style
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Adding paragraph text
    para2.Text = "This is numbered bullet";

    // Setting bullet indent
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // set IsBulletHardColor to true to use own bullet color

    // Setting Bullet Height
    para2.ParagraphFormat.Bullet.Height = 100;

    // Adding Paragraph to text frame
    txtFrm.Paragraphs.Add(para2);


    //Writing the presentation as a PPTX file
    pres.Save(dataDir + "Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Paragraph Picture Bullets in PPTX**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate how we can manage paragraph picture bullets. Picture bullets are more useful where something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see how developers can use this small yet powerful feature of Aspose.Slides for .NET. Please follow the steps below to manage the paragraph picture bullets using Aspose.Slides for .NET:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in a selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class.
- Load Image from disc in IPPImage.
- Set the bullet type to Picture and set the image.
- Set the Paragraph Text.
- Set the Paragraph Indent to set the bullet.
- Set the Color of Bullet.
- Set the Height of Bullets.
- Add the created paragraph in TextFrame paragraph collection.
- Add the second paragraph and repeat the process given in the previous steps.
- Save the presentation.

The implementation of the above steps is given below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

Presentation presentation = new Presentation();

// Accessing the first slide
ISlide slide = presentation.Slides[0];

// Instantiate the image for bullets
Image image = new Bitmap(dataDir + "bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);

// Adding and accessing Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Accessing the text frame of created autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Removing the default exisiting paragraph
textFrame.Paragraphs.RemoveAt(0);

// Creating new paragraph
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Setting paragraph bullet style and image
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Setting Bullet Height
paragraph.ParagraphFormat.Bullet.Height = 100;

// Adding Paragraph to text frame
textFrame.Paragraphs.Add(paragraph);

// Writing the presentation as a PPTX file
presentation.Save(dataDir + "ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);
// Writing the presentation as a PPT file
presentation.Save(dataDir + "ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Multilevel Bullets**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate that how we can manage paragraphs with multilevel bullets. Please follow the steps below to manage the multilevel bullets using Aspose.Slides for .NET:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class and with depth set to 0.
- Create the second paragraph instance using Paragraph class and with depth set to 1.
- Create the third paragraph instance using Paragraph class and with depth set to 2.
- Create the fourth paragraph instance using Paragraph class and with depth set to 3.
- Add the created paragraphs in TextFrame paragraph collection.
- Save the presentation.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

// Create directory if it is not already present.
bool IsExists = System.IO.Directory.Exists(dataDir);
if (!IsExists)
    System.IO.Directory.CreateDirectory(dataDir);

// Creating a presenation instance
using (Presentation pres = new Presentation())
{

    // Accessing the first slide
    ISlide slide = pres.Slides[0];
    
    // Adding and accessing Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accessing the text frame of created autoshape
    ITextFrame text = aShp.AddTextFrame("");
    
    //clearing default paragraph
    text.Paragraphs.Clear();

    //Adding first paragraph
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    //Setting bullet level
    para1.ParagraphFormat.Depth = 0;

    //Adding second paragraph
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    //Setting bullet level
    para2.ParagraphFormat.Depth = 1;

    //Adding third paragraph
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    //Setting bullet level
    para3.ParagraphFormat.Depth = 2;

    //Adding fourth paragraph
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    //Setting bullet level
    para4.ParagraphFormat.Depth = 3;

    //Adding paragraphs to collection
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    //Writing the presentation as a PPTX file
    pres.Save(dataDir + "MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            
}
```


## **Paragraph with Custom Numbered List**
Aspose.Slides for .NET provides a simple API to manage paragraphs with custom numbers formatting. For this purpose, **NumberedBulletStartWith** property has been added to **IBulletFormat.** To add a custom number list in a paragraph, please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 2
- Create the second paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 3
- Create the third paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 7
- Add the created paragraphs in TextFrame paragraph collection.
- Save the presentation.

```c#
 // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Text();

            using (var presentation = new Presentation())
            {
                var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

                // Accessing the text frame of created autoshape
                ITextFrame textFrame = shape.TextFrame;

                // Removing the default exisiting paragraph
                textFrame.Paragraphs.RemoveAt(0);

                // First list
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

                presentation.Save(dataDir + "SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
            }
```




## **Paragraph Indent**
This page will illustrate how we can manage paragraph indent. We will see how developers can use this feature of Aspose.Slides for .NET. Please follow the steps below to manage the paragraph indent using Aspose.Slides for .NET:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with three Paragraphs in the Rectangle.
1. Hide the Lines of the Rectangle.
1. Set indent of each Paragraph using its BulletOffset property.
1. Write the modified presentation as a PPT file.

The implementation of the above steps is given below.

```c#
 // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Text();

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            // Instantiate Presentation Class
            Presentation pres = new Presentation();

            // Get first slide
            ISlide sld = pres.Slides[0];

            // Add a Rectangle Shape
            IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

            // Add TextFrame to the Rectangle
            ITextFrame tf = rect.AddTextFrame("This is first line \rThis is second line \rThis is third line");

            // Set the text to fit the shape
            tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

            // Hide the lines of the Rectangle
            rect.LineFormat.FillFormat.FillType = FillType.Solid;

            // Get first Paragraph in the TextFrame and set its Indent
            IParagraph para1 = tf.Paragraphs[0];
            // Setting paragraph bullet style and symbol
            para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
            para1.ParagraphFormat.Alignment = TextAlignment.Left;

            para1.ParagraphFormat.Depth = 2;
            para1.ParagraphFormat.Indent = 30;

            // Get second Paragraph in the TextFrame and set its Indent
            IParagraph para2 = tf.Paragraphs[1];
            para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
            para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
            para2.ParagraphFormat.Alignment = TextAlignment.Left;
            para2.ParagraphFormat.Depth = 2;
            para2.ParagraphFormat.Indent = 40;

            // Get third Paragraph in the TextFrame and set its Indent
            IParagraph para3 = tf.Paragraphs[2];
            para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
            para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
            para3.ParagraphFormat.Alignment = TextAlignment.Left;
            para3.ParagraphFormat.Depth = 2;
            para3.ParagraphFormat.Indent = 50;

            //Write the Presentation to disk
            pres.Save(dataDir + "InOutDent_out.pptx", SaveFormat.Pptx);
```


## **End Paragraph Run Properties for Paragraph**
This page will illustrate how we can manage end paragraph run properties. We will see how developers can use this feature of Aspose.Slides for .NET. Please follow the steps below to manage the End paragraph Run Properties using Aspose.Slides for .NET:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with two Paragraphs in the Rectangle.
1. Set Font Height and Font type of paragraphs.
1. Set End properties of paragraphs.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
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

pres.Save(dataDir+"pres.pptx", SaveFormat.Pptx);
}
}
```




## **Import HTML Text in Paragraphs**
This topic is also part of a series of topics about managing text paragraphs. Aspose.Slides for .NET has enhanced support for adding HTML text or saving paragraphs text to HTML. This article shows how to manage paragraphs to use HTML data and shows how developers can use this small yet powerful feature. To manage paragraph bullets using Aspose.Slides for .NET:

- Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Access the desired slide in slide collection using the ISlide object.
- Add an autoshape to the selected slide.
- Add and access the ITextFrame of the added shape.
- Remove the default paragraph in the ITextFrame.
- Read the source HTML file in a TextReader.
- Create the first paragraph instance using the Paragraph class.
- Add the HTML file content in the read TextReader to the TextFrame's ParagraphCollection.
- Save the presentation.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

// Create Empty presentation instance// Create Empty presentation instance
using (Presentation pres = new Presentation())
{
    // Acesss the default first slide of presentation
    ISlide slide = pres.Slides[0];

    // Adding the AutoShape to accomodate the HTML content
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Adding text frame to the shape
    ashape.AddTextFrame("");

    // Clearing all paragraphs in added text frame
    ashape.TextFrame.Paragraphs.Clear();

    // Loading the HTML file using stream reader
    TextReader tr = new StreamReader(dataDir + "file.html");

    // Adding text from HTML stream reader in text frame
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Saving Presentation
    pres.Save(dataDir + "output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Export Paragraphs Text to HTML**
Please follow the steps below to see how to export the paragraph text to HTML using Aspose.Slides for .NET:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class and load the desired presentation.
- Access the desired slide into the slide collection using ISlide object.
- Access the desired shape for which text need to be exported to HTML.
- Access the TextFrame of the accessed shape.
- Create an instance of StreamWriter and add the new HTML file.
- Export the desired number of paragraphs data by providing starting index to the StreamWriter.
  The implementation of the above steps is given below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

// Load the presentation file
using (Presentation pres = new Presentation(dataDir + "ExportingHTMLText.pptx"))
{

    // Acesss the default first slide of presentation
    ISlide slide = pres.Slides[0];

    // Desired index
    int index = 0;

    // Accessing the added shape
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter(dataDir + "output_out.html", false, Encoding.UTF8);

    //Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

