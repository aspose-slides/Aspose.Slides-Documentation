---
title: ".NET में प्रस्तुतियों में तालिका कोशिकाओं को प्रबंधित करें"
linktitle: "कोशिकाओं को प्रबंधित करें"
type: docs
weight: 30
url: /hi/net/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides के साथ PowerPoint में तालिका कोशिकाओं को सहजता से प्रबंधित करें। कोशिकाओं तक पहुँचने, संशोधित करने और शैली देने में निपुण बनें, ताकि सहज स्लाइड स्वचालन हो सके।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख विलीन तालिका कोशिकाओं की पहचान करना, कोशिका बॉर्डर हटाना, मर्ज या विभाजन के बाद कोशिका क्रमांकन के साथ काम करना, कोशिका की पृष्ठभूमि रंग बदलना, और तालिका कोशिका के अंदर छवि जोड़ने के तरीके बताता है। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएं या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से स्वरूपण अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

## **विलीनीकृत तालिका कोशिका की पहचान**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.  
2. Get the table from the first slide.  
3. Iterate through the table's rows and columns to find merge cells.  
4. Print message when merged cells are found.

यह C# कोड आपको प्रस्तुति में विलीन तालिका कोशिकाओं की पहचान करने का तरीका दिखाता है:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // मानते हुए कि Slide#0.Shape#0 एक तालिका है
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **तालिका कोशिका बॉर्डर हटाएँ**

1. Create an instance of the `Presentation` class.  
2. Get a slide's reference through its index.  
3. Define an array of columns with width.  
4. Define an array of rows with height.  
5. Add a table to the slide through the `AddTable` method.  
6. Iterate through every cell to clear the top, bottom, right, and left borders.  
7. Save the modified presentation as a PPTX file.

यह C# कोड आपको तालिका कोशिकाओं से बॉर्डर हटाने का तरीका दिखाता है:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
using (Presentation pres = new Presentation())
{
   // पहली स्लाइड तक पहुँचता है
    Slide sld = (Slide)pres.Slides[0];

    // कॉलम को चौड़ाई और पंक्तियों को ऊँचाई के साथ परिभाषित करता है
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // स्लाइड में टेबल आकार जोड़ता है
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के लिए बॉर्डर प्रारूप सेट करता है
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **विलीनीकृत कोशिकाओं में क्रमांकन**

यदि हम 2 जोड़े कोशिकाएँ (1, 1) x (2, 1) और (1, 2) x (2, 2) को मिलाएँ, तो परिणामी तालिका क्रमांकित होगी। यह C# कोड प्रक्रिया को दर्शाता है:

```c#
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = presentation.Slides[0];

    // कॉलम को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में तालिका आकार जोड़ता है
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के लिए बॉर्डर प्रारूप सेट करता है
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // कोशिकाएँ (1, 1) x (2, 1) को मिलाता है
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // कोशिकाएँ (1, 2) x (2, 2) को मिलाता है
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

फिर हम (1, 1) और (1, 2) को मिलाकर कोशिकाओं को आगे विलीन करते हैं। परिणामस्वरूप तालिका के केंद्र में एक बड़ी विलीन कोशिका होगी:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = presentation.Slides[0];

    // कॉलम को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में तालिका आकार जोड़ता है
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के लिए बॉर्डर प्रारूप सेट करता है
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // कोशिकाएँ (1, 1) x (2, 1) को मिलाता है
    table.MergeCells(table[1, 1], table[2, 1], false);

    // कोशिकाएँ (1, 2) x (2, 2) को मिलाता है
    table.MergeCells(table[1, 2], table[2, 2], false);

    // कोशिकाएँ (1, 2) x (2, 2) को मिलाता है
    table.MergeCells(table[1, 1], table[1, 2], true);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **विभाजित कोशिका में क्रमांकन**

पिछले उदाहरणों में, जब तालिका कोशिकाएँ विलीन हुईं, तो अन्य कोशिकाओं में क्रमांकन या संख्या प्रणाली नहीं बदली।  

इस बार, हम एक सामान्य तालिका (बिना विलीन कोशिकाओं वाली तालिका) लेते हैं और फिर (1,1) कोशिका को विभाजित करने की कोशिश करते हैं ताकि एक विशेष तालिका प्राप्त हो। आप इस तालिका के क्रमांकन पर ध्यान देना चाह सकते हैं, जो अजीब लग सकता है। हालांकि, यही Microsoft PowerPoint तालिका कोशिकाओं को क्रमांकित करने का तरीका है और Aspose.Slides भी यही करता है।  

यह C# कोड हमारे द्वारा वर्णित प्रक्रिया को दर्शाता है:

```c#
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = presentation.Slides[0];

    // कॉलम को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में तालिका आकार जोड़ता है
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // प्रति कोशिका के लिए बॉर्डर प्रारूप सेट करता है
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // कोशिकाएँ (1, 1) x (2, 1) को मिलाता है
    table.MergeCells(table[1, 1], table[2, 1], false);

    // कोशिकाएँ (1, 2) x (2, 2) को मिलाता है
    table.MergeCells(table[1, 2], table[2, 2], false);

    // कोशिका (1, 1) को विभाजित करता है।
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

यह C# कोड आपको तालिका कोशिका की पृष्ठभूमि रंग बदलने का तरीका दिखाता है:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // नई तालिका बनाएं
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // एक कोशिका के लिए पृष्ठभूमि रंग सेट करें
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **तालिका कोशिका के भीतर छवि जोड़ें**

1. Create an instance of the`Presentation` class.  
2. Get a slide's reference through its index.  
3. Define an array of columns with width.  
4. Define an array of rows with height.  
5. Add a table to the slide through the `AddTable` method.  
6. Create a `Bitmap` object to hold the image file.  
7. Add the bitmap image to the `IPPImage` object.  
8. Set the `FillFormat` for the Table Cell to `Picture`.  
9. Add the image to the table's first cell.  
10. Save the modified presentation as a PPTX file

यह C# कोड दिखाता है कि तालिका बनाते समय तालिका कोशिका के भीतर छवि कैसे रखें:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = presentation.Slides[0];

    // कॉलम को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // स्लाइड में तालिका आकार जोड़ता है
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // फ़ाइल से एक छवि लोड करता है और उसे प्रस्तुति संसाधनों में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // छवि को पहली तालिका कोशिका में जोड़ता है
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं किसी एकल कोशिका के विभिन्न पक्षों के लिए अलग‑अलग लाइन की मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [ऊपर](https://reference.aspose.com/slides/hi/net/aspose.slides/cellformat/bordertop/)/[नीचे](https://reference.aspose.com/slides/hi/net/aspose.slides/cellformat/borderbottom/)/[बाएँ](https://reference.aspose.com/slides/hi/net/aspose.slides/cellformat/borderleft/)/[दाएँ](https://reference.aspose.com/slides/hi/net/aspose.slides/cellformat/borderright/) बॉर्डर के अलग-अलग प्रॉपर्टी होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है। यह लेख में प्रदर्शित किए गए सेल के प्रति‑पक्ष बॉर्डर नियंत्रण से तर्कसंगत रूप से जुड़ा है।

**यदि मैं सेल की पृष्ठभूमि के रूप में चित्र सेट करने के बाद कॉलम/पंक्ति का आकार बदलूँ तो छवि में क्या होता है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillmode/) (stretch/​tile) पर निर्भर करता है। स्ट्रेचिंग के साथ, छवि नई कोशिका के अनुसार समायोजित होती है; टाइलिंग के साथ, टाइलों की पुनर्गणना की जाती है। लेख में कोशिका में छवि प्रदर्शित करने के मोड का उल्लेख है।

**क्या मैं कोशिका की सभी सामग्री को हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/net/manage-hyperlinks/) को सेल के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/शेप स्तर पर सेट किया जाता है। व्यावहारिक रूप से, आप लिंक को किसी भाग या सेल के सभी टेक्स्ट को असाइन करते हैं।

**क्या मैं एक ही कोशिका में अलग-अलग फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। एक कोशिका के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/hi/net/aspose.slides/portion/) (रनों) का समर्थन होता है जिनकी फॉर्मेटिंग स्वतंत्र होती है—फ़ॉन्ट फ़ैमिली, शैली, आकार, और रंग।