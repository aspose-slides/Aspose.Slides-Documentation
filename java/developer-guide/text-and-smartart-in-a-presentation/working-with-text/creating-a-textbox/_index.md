---
title: Creating a TextBox
type: docs
weight: 10
url: /java/creating-a-textbox/
---

## **Creating a TextBox on the Slide**
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
## **Add Column in TextBoxes**
Using Aspose.Slides for Java, developers can add column in text boxes on a Slide in the Presentation, property ColumnCount and ColumnSpacing has been added to ITextFrameFormat interface and TextFrameFormat class respectively. These properties specify the number of columns in textbox and set an amount of spacing in points between columns.

The implementation is demonstrated below in an example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-AddColumnInTextBoxes-AddColumnInTextBoxes.java" >}}
## **Add Columns in Text Frames**
Using Aspose.Slides for Java, developers can add columns in text frames on a Slide in the Presentation. **ColumnCount** property has been added to **ITextFrameFormat** interface. This property specifies the number of columns in the text frame.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-AddColumnsinTextFrame-AddColumnsinTextFrame.java" >}}
## **Change Language for Presentation and Shape's Text**
- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Rectangle type to the slide.
- Add some text to the TextFrame.
- Setting Language Id to text.
- Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-SettingLanguage-SettingLanguage.java" >}}
## **Creating a TextBox with Hyperlink**
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
## **Replacing Text in a Placeholder**
{{% alert color="primary" %}} 

Using Aspose.Slides for Java, developers can also find and modify a specific **Placeholder** present in a slide. In this topic, we are going to demonstrate with the help of an example that how the text contained inside a **Placeholder** can be replaced or modified using Aspose.Slides for Java.

{{% /alert %}} 

The following two steps will be used to modify text in Placeholder.

Step 1: Create a Slide Containing a Placeholder
First of all, create a presentation file with a slide containing a **Placeholder**. You can even create this presentation using MS PowerPoint. This is just the demonstration of replacing text in a Placeholder, so you can create this presentation by yourself. This presentation will be used in next step and the text in its **Placeholder** will be replaced. The slide containing the text in a **Placeholder** is shown below:

|![todo:image_alt_text](http://i.imgur.com/ugVf6QJ.jpg)|
| :- |
|**Figure: Slide with a Placeholder containing some text**|
Step 2: Replace Text of the Placeholder
To replace the text of a **Placeholder**, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Iterate through the Shapes and find the Placeholder shapes.
1. Typecast the Placeholder shape to AutoShape and change the text using the TextFrame associated with the AutoShape.
1. Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ReplacingTextInAPlaceholder-ReplacingTextInAPlaceholder.java" >}}

The above code snippet replaces the text of the **Placeholder** to **This is Placeholder** as shown below:

|![todo:image_alt_text](http://i.imgur.com/sa1gmft.png)|
| :- |
|**Figure: Placeholders with replaced text**|
## **Set Prompt Text in a Placeholder**
As we know that Standard and pre-built layouts contain placeholders with default text like **Click to add a title** or **Click to add subtitle**. Using Aspose.Slides you can add prompt text manually by accessing the default placeholders.

The code snippet below shows how to use this feature:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-AddCustomPromptText-AddCustomPromptText.java" >}}


## **Tabs and EffectiveTabs in Presentation**
All text tabulations are given in pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs).
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Hello World!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".
