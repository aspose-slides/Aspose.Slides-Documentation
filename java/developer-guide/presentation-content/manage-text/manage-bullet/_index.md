---
title: Manage Bullet
type: docs
weight: 35
url: /java/manage-bullet/
---

## **Create Bullet**
Please follow the steps below to manage the paragraph bullets using Aspose.Slides for Java:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access the desired slide in slide collection using [ISlide](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlide) object.
1. Add an **autoshape** in selected slide.
1. Access the **TextFrame** of the added shape.
1. Remove the default paragraph in the TextFrame.
1. Create the first paragraph instance using **Paragraph** class.
1. Set the bullet type of the paragraph.
1. Set the bullet type to **Symbol** and the set the bullet character.
1. Set the Paragraph Text.
1. Set the Paragraph Indent to set the bullet.
1. Set the Color of Bullet.
1. Set the Height of Bullets.
1. Add the created paragraph in TextFrame paragraph collection.
1. Add the second paragraph and repeat the process given in steps **7 to 13**.
1. Save the presentation.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingParagraphBulletsInPPTX-ManagingParagraphBulletsInPPTX.java" >}}


The above code snippet adds bullets to the text paragraph as shown below:

|![todo:image_alt_text](http://i.imgur.com/tSRTgs6.png)|
| :- |
|**Figure: Bulleted paragraphs**|
## **Create Picture Bullet**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate that how we can manage paragraph picture bullets. Picture bullets are more useful where the something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see that how developers can use this small yet powerful feature of Aspose.Slides for Java.

Please follow the steps below to manage the paragraph picture bullets using Aspose.Slides for Java:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class
- Access the desired slide in slide collection using [ISlide](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlide) object
- Add an autoshape in selected slide
- Access the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) of the added shape
- Remove the default paragraph in the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame)
- Create the first paragraph instance using Paragraph class
- Load Image from disc in [IPPImage](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPPImage)
- Set the bullet type to Picture and the set the image
- Set the Paragraph Text
- Set the Paragraph Indent to set the bullet
- Set the Color of Bullet
- Set the Height of Bullets
- Add the created paragraph in [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) paragraph collection
- Add the second paragraph and repeat the process given in previous steps
- Save the presentation

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingParagraphPictureBulletsInPPTX-ManagingParagraphPictureBulletsInPPTX.java" >}}
## **Create Multilevel Bullet**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate that how we can manage paragraphs with multilevel bullets. Please follow the steps below to manage the multilevel bullets using Aspose.Slides for Java:

- Create an instance of Presentation class.
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



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-MutilevelBullets-MutilevelBullets.java" >}}
## **Create Custom Numbered List**
Aspose.Slides for Java provides a simple API to manage paragraphs with custom numbers formatting. For this purpose, **NumberedBulletStartWith** property has been added to **IBulletFormat.** To add a custom number list in a paragraph, please follow the steps below:

- Create an instance of Presentation class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 2
- Create the second paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 3
- Create the third paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 7
- Add the created paragraphs in TextFrame paragraph collection.
- Save the presentation.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-SetCustomBulletsNumber-SetCustomBulletsNumber.java" >}}