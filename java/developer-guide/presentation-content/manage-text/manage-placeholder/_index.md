---
title: Manage Placeholder
type: docs
weight: 10
url: /java/manage-placeholder/
---

## **Change Text in Placeholder**
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
## **Set Prompt Text in Placeholder**
As we know that Standard and pre-built layouts contain placeholders with default text like **Click to add a title** or **Click to add subtitle**. Using Aspose.Slides you can add prompt text manually by accessing the default placeholders.

The code snippet below shows how to use this feature:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-AddCustomPromptText-AddCustomPromptText.java" >}}

