---
title: Manage PowerPoint Paragraph in C#
type: docs
weight: 40
url: /net/manage-paragraph/
keywords: "Add PowerPoint paragraph, Manage paragraphs, Paragraph indent, Paragraph properties, HTML text, Export paragraph text, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Create and manage Paragraph, its text, its indent, and properties in PowerPoint presentations in C# or .NET"
---

Aspose.Slides provides all the interfaces and classes you need to work with PowerPoint texts, paragraphs, and portions in C#.

* Aspose.Slides provides the ITextFame interface to allow you to add objects that represent a paragraph. An ITextFame object can have one or multiple paragraphs (each paragraph is created through a carriage return).
* Aspose.Slides provides IParagraph interface to allow you to add objects that represent portions. An IParagraph object can have one or multiple portions (collection of iPortions objects).
* Aspose.Slides provides IPortion interface to allow you to add objects that represent texts and their formatting properties. 

An IParagraph object is capable of handling texts with different formatting properties through its underlying IPortion objects.

## **Add Multiple Paragraph Containing Multiple Portions**

These steps show you how to add a text frame containing 3 paragraphs and each paragraph containing 3 portions:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Access a slide's reference through its index.
3. Add a Rectangle IAutoShape to the slide.
4. Get the ITextFrame associated with the IAutoShape.
5. Create two IParagraph objects and add it to the IParagraphs collection of the ITextFrame.
6. Create three IPortion objects for each new IParagraph (two Portion objects for default Paragraph) and add each IPortion object to the IPortions collection of each IParagraph.
7. Set some text for each Portion.
8. Apply your preferred formatting features to each Portion using the formatting properties exposed by the IPortion object.
9. Save the modified presentation.

This C# code is an implementation of the steps

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{
    // Accesses the first slide
    ISlide slide = pres.Slides[0];

    // Adds a Rectangle IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accesses the AutoShape TextFrame
    ITextFrame tf = ashp.TextFrame;

    // Creates Paragraphs and Portions with different text formats
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
    // Saves the modified presentation
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

```


## **Manage Paragraph Bullets**
Bullet lists help you to organize and present information quickly and efficiently. Bulleted paragraphs are always easier to read and understand.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get a slide's reference through its index.
3. Add an autoshape in the selected slide.
4. Access the autoshape's TextFrame. 
5. Remove the default paragraph in the TextFrame.
6. Create the first paragraph instance using the Paragraph class.
7. Set a bullet type for the paragraph.
8. Set the bullet type to Symbol and set the bullet character.
9. Set the Paragraph Text.
10. Set the Paragraph Indent to set the bullet.
11. Set the color of the bullet.
12. Set the height of the bullet.
13. Add the created paragraph to the TextFrame paragraph collection.
14. Add the second paragraph and repeat the process given in steps 7 to 13.
15. Save the presentation.

This C# code shows you how to add a paragraph bullet:

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{

    // Accesses the first slide
    ISlide slide = pres.Slides[0];


    // Adds and accesses Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the autoshape text frame
    ITextFrame txtFrm = aShp.TextFrame;

    // Removes the default paragraph
    txtFrm.Paragraphs.RemoveAt(0);

    // Creates a paragraph
    Paragraph para = new Paragraph();

    // Sets a paragraph bullet style and symbol
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Sets a paragraph text
    para.Text = "Welcome to Aspose.Slides";

    // Sets bullet indent
    para.ParagraphFormat.Indent = 25;

    // Sets bullet color
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // set IsBulletHardColor to true to use own bullet color

    // Sets Bullet Height
    para.ParagraphFormat.Bullet.Height = 100;

    // Adds Paragraph to text frame
    txtFrm.Paragraphs.Add(para);

    // Creates second paragraph
    Paragraph para2 = new Paragraph();

    // Sets paragraph bullet type and style
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Adds paragraph text
    para2.Text = "This is numbered bullet";

    // Sets bullet indent
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // set IsBulletHardColor to true to use own bullet color

    // Sets Bullet Height
    para2.ParagraphFormat.Bullet.Height = 100;

    // Adds Paragraph to text frame
    txtFrm.Paragraphs.Add(para2);


    // Saves the modified presentation
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Manage Picture Bullets**
Bullet lists help you to organize and present information quickly and efficiently. Picture paragraphs are easy to read and understand.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get a slide's reference through its index.
3. Add an autoshape to the slide.
4. Access the autoshape's TextFrame.
5. Remove the default paragraph in the TextFrame.
6. Create the first paragraph instance using the Paragraph class.
7. Load the image from disc in IPPImage.
8. Set the bullet type to Picture and set the image.
9. Set the Paragraph Text.
10. Set the Paragraph Indent to set the bullet.
11. Set the color of the bullet.
12. Set the height of the bullet.
13. Add the new paragraph to the TextFrame paragraph collection.
14. Add the second paragraph and repeat the process based on the previous steps.
15. Save the modified presentation.

This C# code shows you how to add and manage picture bullets:

```c#
// Instantiates a Presentation class that represents a PPTX file
Presentation presentation = new Presentation();

// Accesses the first slide
ISlide slide = presentation.Slides[0];

// Instantiates the image for bullets
Image image = new Bitmap("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);

// Adds and accesses Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Accesses the autoshape textframe
ITextFrame textFrame = autoShape.TextFrame;

// Removes the default paragraph
textFrame.Paragraphs.RemoveAt(0);

// Creates a new paragraph
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Sets paragraph bullet style and image
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Sets bullet Height
paragraph.ParagraphFormat.Bullet.Height = 100;

// Adds paragraph to text frame
textFrame.Paragraphs.Add(paragraph);

// Writes the presentation as a PPTX file
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Writes the presentation as a PPT file
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Manage Multilevel Bullets**
Bullet lists help you to organize and present information quickly and efficiently. Multilevel bullets are easy to read and understand.

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Get a slide's reference through its index.
3. Add an autoshape in the new slide.
4. Access the autoshape's TextFrame.
5. Remove the default paragraph in the TextFrame.
6. Create the first paragraph instance through the Paragraph class and set the depth to 0.
7. Create the second paragraph instance using Paragraph class and set depth set to 1.
8. Create the third paragraph instance using Paragraph class and set depth set to 2.
9. Create the fourth paragraph instance using Paragraph class and setdepth set to 3.
10. Add the new paragraphs to the TextFrame paragraph collection.
11. Save the modified presentation.

This C# code shows you how to add and manage multilevel bullets:

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{

    // Accesses the first slide
    ISlide slide = pres.Slides[0];
    
    // Adds and accessing Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the text frame of created autoshape
    ITextFrame text = aShp.AddTextFrame("");
    
    // Clears default paragraph
    text.Paragraphs.Clear();

    // Adds first paragraph
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Sets the bullet level
    para1.ParagraphFormat.Depth = 0;

    // Adds the second paragraph
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Sets the bullet level
    para2.ParagraphFormat.Depth = 1;

    // Adds the third paragraph
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Sets the bullet level
    para3.ParagraphFormat.Depth = 2;

    // Adds the fourth paragraph
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Sets the bullet level
    para4.ParagraphFormat.Depth = 3;

    // Adds paragraphs to collection
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Writes the presentation as a PPTX file
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Manage Paragraph with Custom Numbered List**
The IBulletFormat interface provides the **NumberedBulletStartWith** property and others that allow you to manage paragraphs with custom numbering or formatting. 

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Access the desired slide in slide collection using ISlide object.
3. Add an autoshape in selected slide.
4. Access the TextFrame of the added shape.
5. Remove the default paragraph in the TextFrame.
6. Create the first paragraph instance using Paragraph class and set NumberedBulletStartWith to 2
7. Create the second paragraph instance using Paragraph class and set NumberedBulletStartWith to 3
8. Create the third paragraph instance using Paragraph class and set NumberedBulletStartWith to 7
9. Add the new paragraphs to the TextFrame paragraph collection.
10. Save the modified presentation.

This C# code shows you how to add and manage paragraphs with custom numbering or formatting:

```c#
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

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```


## **Paragraph Indent**
This page will illustrate how we can manage paragraph indent. We will see how developers can use this feature of Aspose.Slides for .NET. Please follow the steps below to manage the paragraph indent using Aspose.Slides for .NET:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with three Paragraphs in the Rectangle.
1. Hide the Lines of the Rectangle.
1. Set indent of each Paragraph using its BulletOffset property.
1. Write the modified presentation as a PPT file.

This C# code shows you how to set a paragraph indent:

```c#
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
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```


## **End Paragraph Run Properties for Paragraph**
This page will illustrate how we can manage end paragraph run properties. We will see how developers can use this feature of Aspose.Slides for .NET. Please follow the steps below to manage the End paragraph Run Properties using Aspose.Slides for .NET:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with two Paragraphs in the Rectangle.
1. Set Font Height and Font type of paragraphs.
1. Set End properties of paragraphs.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

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




## **Import HTML Text in Paragraphs**
This topic is also part of a series of topics about managing text paragraphs. Aspose.Slides for .NET has enhanced support for adding HTML text or saving paragraphs text to HTML. This article shows how to manage paragraphs to use HTML data and shows how developers can use this small yet powerful feature. To manage paragraph bullets using Aspose.Slides for .NET:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Access the desired slide in slide collection using the ISlide object.
- Add an autoshape to the selected slide.
- Add and access the ITextFrame of the added shape.
- Remove the default paragraph in the ITextFrame.
- Read the source HTML file in a TextReader.
- Create the first paragraph instance using the Paragraph class.
- Add the HTML file content in the read TextReader to the TextFrame's ParagraphCollection.
- Save the presentation.

```c#
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
    TextReader tr = new StreamReader("file.html");

    // Adding text from HTML stream reader in text frame
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Saving Presentation
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Export Paragraphs Text to HTML**
Please follow the steps below to see how to export the paragraph text to HTML using Aspose.Slides for .NET:

- Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and load the desired presentation.
- Access the desired slide into the slide collection using ISlide object.
- Access the desired shape for which text need to be exported to HTML.
- Access the TextFrame of the accessed shape.
- Create an instance of StreamWriter and add the new HTML file.
- Export the desired number of paragraphs data by providing starting index to the StreamWriter.
  The implementation of the above steps is given below.

```c#
// Load the presentation file
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Acesss the default first slide of presentation
    ISlide slide = pres.Slides[0];

    // Desired index
    int index = 0;

    // Accessing the added shape
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    //Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

