---
title: Accessing an Existing Table in Slide
type: docs
weight: 20
url: /cpp/accessing-an-existing-table-in-slide/
---

{{% alert color="primary" %}} 

This page is no longer maintained. For an updated page, please [visit](/slides/cpp/adding-updating-and-manipulating-tables/)

{{% /alert %}} {{% alert color="primary" %}} 

Aspose.Slides for C++ allows developers to not only add custom tables in their slides but also access or manage the existing ones. In this topic, we will discuss about accessing a table that already exists in a slide.

{{% /alert %}} 
## **Accessing an Existing Table**
To access a table that already exists in a slide, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide (that contains the table) by using its Position
- Create an ITable object and set it to null
- Iterate through all Shapes until you find the Table. If a slide contains only one table then you can simply check a shape and if it is found to be a Table then just typecast it as a Table object. But, if the slide contains more than one tables then it's better to find your desired table using its Alternative Text
- After the Table is found, you can use ITable object to control the table. For example, in our case, we have added a new row in the desired table
- Save the modified presentation as a PPT file
### **Example**
[**C#**]()

``` cpp

 //Instantiate Presentation class that represents PPTX//Instantiate Presentation class that represents PPTX

using (Presentation pres = new Presentation("table.pptx"))

{

    //Access the first slide

    ISlide sld = pres.Slides[0];

    //Initialize null TableEx

    ITable tbl = null;

    //Iterate through the shapes and set a reference to the table found

    foreach (IShape shp in sld.Shapes)

        if (shp is ITable)

            tbl = (ITable)shp;

    //Set the text of the first column of second row

    tbl[0, 1].TextFrame.Text = "New";

    //Write the PPTX to Disk

    pres.Save("table1.pptx", SaveFormat.Pptx);

}



```

[**Visual Basic**]()

``` cpp

 'Instantiate Presentation class that represents PPTX

Using pres As New Presentation("table.pptx")

	'Access the first slide

	Dim sld As ISlide = pres.Slides(0)

	'Initialize null TableEx

	Dim tbl As ITable = Nothing

	'Iterate through the shapes and set a reference to the table found

	For Each shp As IShape In sld.Shapes

		If TypeOf shp Is ITable Then

			tbl = CType(shp, ITable)

		End If

	Next shp

	'Set the text of the first column of second row

	tbl(0, 1).TextFrame.Text = "New"

	'Write the PPTX to Disk

	pres.Save("table1.pptx", SaveFormat.Pptx)

End Using



```

![todo:image_alt_text](Accessing%20an%20Existing%20Table%20in%20SlideEx-00.png)

**Figure**: Original table before modification

The above code snippet locates an existing table in the slide and then adds some text in the first column of the second row in the table as shown below:

![todo:image_alt_text](Accessing%20an%20Existing%20Table%20in%20SlideEx-002.png)

**Figure**: Table with modified text
