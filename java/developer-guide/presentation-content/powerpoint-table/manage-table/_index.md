---
title: Manage Table
type: docs
weight: 10
url: /java/manage-table/
---

## **Create Table from Scratch**
{{% alert color="primary" %}} 

Aspose.Slides for Java facilitates developers to add custom tables in their slides from scratch. This is one of the newest features added in Aspose.Slides for Java since last few versions. In this topic, we will explain how developers can create and add tables to their slides using Aspose.Slides for Java.

{{% /alert %}} 

Aspose.Slides for Java has provided the simplest API to create tables. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Create an Array of Columns' Width.
- Create an Array of Rows' Height.
- Add a Table to the slide using **addTable** method exposed by [ISlideCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlideCollection) object.
- Iterate through each Cell to apply formatting to the Top, Bottom, Right and Left Borders.
- Merge first two cells of the first row of the table.
- Access the Text Frame of a Cell.
- Add some text to the Text Frame.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-CreateATableFromScratchInASlide-CreateATableFromScratchInASlide.java" >}}

|![todo:image_alt_text](http://i.imgur.com/kZns0hk.jpg)|
| :- |
|**Figure: Table added to the slide**|


## **Access Table in Slide**
{{% alert color="primary" %}} 

Aspose.Slides for Java allows developers to not only add custom tables in their slides but also access or manage the existing ones. In this topic, we will discuss about accessing a table that already exists in a slide.

{{% /alert %}} 

To access a table that already exists in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide (that contains the table) by using its Position.
- Create an [ITable](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ITable) object and set it to null.
- Iterate through all Shapes until you find the Table. If a slide contains only one table then you can simply check a shape and if it is found to be a Table then just typecast it as a Table object. But, if the slide contains more than one tables then it is better to find your desired table using its Alternative Text.
- After the Table is found, you can use [ITable](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ITable) object to control the table. For example, in our case, we have added a new row in the desired table.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-TablesNew-AccessingAnExistingTableInSlide-.java" >}}

|![todo:image_alt_text](http://i.imgur.com/YnMe7FE.jpg)|
| :- |
|**Figure: Original table before modification**|
The above code snippet locates an existing table in the slide and then adds some text in the first column of the second row in the table as shown below:

|![todo:image_alt_text](http://i.imgur.com/OXnYI2m.jpg)|
| :- |
|**Figure: Table with modified text**|

## **Set Text Formatting on Table Level**
{{% alert color="primary" %}} 

Using Aspose.Slides for Java you can Format Text on a Table.

{{% /alert %}} 

To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its index.
- Access Table from Slide.
- Set Table Cells Font Height.
- Set Table Cells Text Alignment and right Margin in one Call
- Set Table Cells Vertical Type.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-SettingTextFormattingInsideTable-SettingTextFormattingInsideTable.java" >}}


## **Lock Aspect Ratio of Table**
The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. You can lock aspect ratio of table using  **setAspectRatioLocked** property. Below code example shows how to use this property.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-LockAspectRatio-LockAspectRatio.java" >}}
