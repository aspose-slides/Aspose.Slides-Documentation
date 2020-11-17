---
title: Manage Placeholder
type: docs
weight: 10
url: /net/manage-placeholder/
---

## **Change Text in a Placeholder**
Using [Aspose.Slides for .NET](/slides/net/), developers can also find and modify a specific Placeholder present in a slide. In this topic, we are going to demonstrate with the help of an example that how the text contained inside a Placeholder can be replaced or modified using Aspose.Slides for .NET. The following two steps will be used to modify text in Placeholder.

Step 1: Create a Slide Containing a Placeholder

First of all, create a presentation file with a slide containing a Placeholder. You can create this presentation either MS PowerPoint. This is just the demonstration of replacing text in a Placeholder, so, you can create this presentation by yourself. This presentation will be used in the next step and the text in its Placeholder will be replaced.

Step 2: Replace Text of the Placeholder

To replace the text of a Placeholder, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Iterate through the Shapes and find the Placeholder shapes.
- Typecast the Placeholder shape to AutoShape and change the text using the TextFrame associated with the AutoShape.
- Write the modified presentation as a [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-ReplacingText-ReplacingText.cs" >}}
## **Set Prompt Text in a Placeholder**
As we know that Standard and pre-built layouts contain placeholders with default text like **Click to add a title** or **Click to add subtitle**. Using Aspose.Slides you can add prompt text manually by accessing the default placeholders.

The code snippet below shows how to use this feature:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Text-AddCustomPromptText-AddCustomPromptText.cs" >}}
