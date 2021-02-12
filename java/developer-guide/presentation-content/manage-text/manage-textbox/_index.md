---
title: Manage TextBox
type: docs
weight: 20
url: /java/manage-textbox/
---


## **Create TextBox**
{{% alert color="primary" %}} 

Using Aspose.Slides for Java, developers can create **TextBox** on a **Slide** in the Presentation. All you have to do is to add an **AutoShape** of **Rectangle** type and call the **addTextFrame** method exposed by [IAutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IAutoShape) object.

{{% /alert %}} 

Please follow the following steps to create a **TextBox**:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of the first slide in the presentation which is created on instantiation of Presentation.
1. Add an [IAutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IAutoShape) with **ShapeType** as **Rectangle** at a specified position of the slide and obtain the reference of that newly added [IAutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IAutoShape) object.
1. Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
1. Finally, save the PPTX file using the Presentation object.

The implementation of above steps is demonstrated below in an example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-CreatingATextBoxOnSlide-CreatingATextBoxOnSlide.java" >}}


The above code snippet adds a **TextBox** with text **Aspose TextBox** as shown below:

|![todo:image_alt_text](http://i.imgur.com/7gTRWsp.jpg)|
| :- |
|**Figure: TextBox with text “Aspose TextBox”**|
## **Create TextBox with Hyperlink**
{{% alert color="primary" %}} 

In the previous topic, we discussed about creating a **TextBox** with some text. In this topic, we will create a **TextBox** with a **Hyperlink**. You will have to instantiate [IHyperlinkManager](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IHyperlinkManager) class and assign it to the desired portion of the **TextFrame** associated with the **TextBox**.

{{% /alert %}} 

Please follow the steps below to create a **TextBox** with **Hyperlink** by using Aspose.Slides for Java API:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of the first slide in the presentation which is created on instantiation of Presentation.
- Add an AutoShape with ShapeType as Rectangle at a specified position of the slide and obtain the reference of that newly added AutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Instantiate the [IHyperlinkManager](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IHyperlinkManager) class.
- Assign the [IHyperlinkManager](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IHyperlinkManager) object to the **HLinkClick** property associated with the desired portion of the TextFrame.
- Finally, save the PPTX file using the Presentation object.

The implementation of above steps is demonstrated below in an example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-CreatingTextBoxWithHyperlink-CreatingTextBoxWithHyperlink.java" >}}

The above code will create a TextBox with the hyperlink Aspose.Slides (pointing to <http://www.aspose.com>) as shown below:

|![todo:image_alt_text](http://i.imgur.com/Py029l3.png)|
| :- |
|**Figure: TextBox with hyperlink Aspose.Slides**|
## **Add Column to TextBox**
Using Aspose.Slides for Java, developers can add column in text boxes on a Slide in the Presentation, property ColumnCount and ColumnSpacing has been added to ITextFrameFormat interface and TextFrameFormat class respectively. These properties specify the number of columns in textbox and set an amount of spacing in points between columns.

The implementation is demonstrated below in an example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-AddColumnInTextBoxes-AddColumnInTextBoxes.java" >}}
## **Add Column to TextFrame**
Using Aspose.Slides for Java, developers can add columns in text frames on a Slide in the Presentation. **ColumnCount** property has been added to **ITextFrameFormat** interface. This property specifies the number of columns in the text frame.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-AddColumnsinTextFrame-AddColumnsinTextFrame.java" >}}
