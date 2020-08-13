---
title: Saving a Presentation
type: docs
weight: 60
url: /java/saving-a-presentation/
---

{{% alert color="primary" %}} 

[Opening a Presentation](/slides/java/opening-a-presentation-html/) described how to use the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class to open a presentation. This article explains how to create and save presentations.

{{% /alert %}} 

The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for Java, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:
## **Saving a Presentation to File**
Save a presentation to file by calling the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class **Save** method. Simply pass the file name and **SaveFormat** to the **Save** method.

The examples that follow show how to save a presentation with Aspose.Slides for Java.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavingAPresentation-SavingAPresentation.java" >}}
## **Saving a Presentation to Stream**
It is possible to save a presentation to a stream by passing an output stream to the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class **Save** method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SaveToStream-SaveToStream.java" >}}
## **Saving a Password Protected Presentation**
It's possible to save presentations with password protection. The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class exposes the **Encrypt** method which sets a password for the presentation. To do this, simply pass the password to the **Encrypt** method and then use the **Save** method exposed by the Presentation class as a string to save the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavingAPasswordProtectedPresentation-SavingAPasswordProtectedPresentation.java" >}}
## **Saving a Password Protected Presentation with Read Access to Document Properties**
It is possible to save presentations with password protection. But in that case access to the presentation's document properties is also prohibited. Aspose.Slides offers a mechanism for password protecting a presentation but still being able to access the document properties in PowerPoint.

The [**Presentation**](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) exposes the [**setEncryptDocumentProperties**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#setEncryptDocumentProperties-boolean-) property that takes a Boolean value to allow or disallow access to the document properties in password-protected mode. By default, its value is set to **true**. The Presentation class also exposes the [**Encrypt** ](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#encrypt-java.lang.String-)method which sets the presentation's password. To do this, simply pass the password to the **Encrypt** method and then use the **Save** method exposed by the Presentation class as a string to save the presentation method.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavingAPassProtectPresWithReadAccessToDocProps-SavingAPassProtectPresWithReadAccessToDocProps.java" >}}
## **Saving Presentation in Read Only Mode**
Developers can save presentations with write protection to allow the presentation to be read in read-only mode. The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class exposes the [**SetWriteProtection(string Password)**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) method with which it is possible to save the presentation in read-only mode by applying write protection on it. To do so, call the method and set the write protection password.

The code example that shows how to apply write protection to a presentation with Aspose.Slides for Java.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavingPresentationInReadOnlyMode-SavingPresentationInReadOnlyMode.java" >}}
## **Removing Write Protection from a Presentation**
Aspose.Slides for Java provides a facility for accessing write-protected presentation through the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. The [**IsWriteProtected**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#isWriteProtected--) property identifies whether a presentation is write-protected or not. If it is write-protected, the protection can be removed using the [**removeWriteProtection()**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#removeWriteProtection--) method.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemovingWriteProtectionFromAPresentation-RemovingWriteProtectionFromAPresentation.java" >}}
## **Save Presentation with Predefined View Type**
Aspose.Slides for Java provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [ViewProperties](https://apireference.aspose.com/java/slides/com.aspose.slides/ViewProperties) class. The [**setLastView**](https://apireference.aspose.com/java/slides/com.aspose.slides/ViewProperties#setLastView-int-) property is used to set the view type by using the [**ViewType**](https://apireference.aspose.com/java/slides/com.aspose.slides/ViewType) enumerator.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavePresentationWithPredefinedViewType-SavePresentationWithPredefinedViewType.java" >}}
## **Save Presentation to Strict Open XML Spreadsheet Format**
Aspose.Slides allows you to save the presentation in Strict Open XML format. For that purpose, it provides the [**PptxOptions** ](https://apireference.aspose.com/java/slides/com.aspose.slides/pptxoptions)class where you can set the Conformance property while saving the presentation file. If you set its value as [**Conformance.Iso29500_2008_Strict**](https://apireference.aspose.com/java/slides/com.aspose.slides/Conformance#Iso29500_2008_Strict), then the output presentation file will be saved in Strict Open XML format.

The following sample code creates a presentation and saves it in the Strict Open XML Format. While calling the Save method for the presentation, the **PptxOptions** object is passed into it with the Conformance property set as **Conformance.Iso29500_2008_Strict**.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SaveToStrictOpenXML-SaveToStrictOpenXML.java" >}}
## **Render comments when saving Presentation into Image**
Aspose.Slides for Java provides a facility to render comments of presentations or slide when converting those into images.  An example is given below that shows how to render comments of presentation into the image.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RenderComments-RenderComments.java" >}}



` `Render Emoji

` `Aspose.Slides for Java provides a facility to render emoji characters of presentations or slide when converting those into [PDF](https://wiki.fileformat.com/view/pdf/), image, [XPS ](https://wiki.fileformat.com/page-description-language/xps/)or [SWF](https://wiki.fileformat.com/page-description-language/swf/).  An example is given below that shows how to render emoji characters of presentation.



{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Rendering-RenderEmoji-RenderEmoji.java" >}}


## **Add an Image From SVG Object**
` `Aspose.Slides for Java added a new [**addImage** ](https://apireference.aspose.com/java/slides/com.aspose.slides/IImageCollection#addImage-java.awt.image.BufferedImage-)method to **[IImageCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/IImageCollection)** **interface** and [**ImageCollection**](https://apireference.aspose.com/java/slides/com.aspose.slides/ImageCollection) **class.** These methods provide the ability to insert [SVG ](https://wiki.fileformat.com/page-description-language/svg/)fragments to the presentation image collection.  

The code sample below shows how to insert SVG fragments to the presentation image collection.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-AddImageFromSVGObject-AddImageFromSVGObject.java" >}}



The following code shows how to insert SVG fragments to the presentation image collection from external resource.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-AddImageFromSVGObjectFromExternalResource-AddImageFromSVGObjectFromExternalResource.java" >}}




## **Convert SVG Images Into Group Shape**
` `New [**addGroupShape**](https://apireference.aspose.com/java/slides/com.aspose.slides/IShapeCollection#addGroupShape--) method has been added to **[IShapeCollection ](https://apireference.aspose.com/java/slides/com.aspose.slides/IShapeCollection)interface** and [**ShapeCollection** ](https://apireference.aspose.com/java/slides/com.aspose.slides/ShapeCollection)**class** in Aspose.Slides for Java. This method allows to convert [**SvgImage**](https://apireference.aspose.com/java/slides/com.aspose.slides/SvgImage) object that represents [SVG](https://wiki.fileformat.com/page-description-language/svg/) data into a group of shapes.


` `The code sample below shows how to convert SVG images into a group of shapes.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ConvertSvgImageObjectIntoGroupOfShapes-ConvertSvgImageObjectIntoGroupOfShapes.java" >}}


## **Saving Progress Updates in Percentage**
` `New [**IProgressCallback**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProgressCallback) interface has been added to [**ISaveOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISaveOptions) interface and [**SaveOptions** ](https://apireference.aspose.com/java/slides/com.aspose.slides/SaveOptions)abstract class. **IProgressCallback** interface represents a callback object for saving progress updates in percentage.  

The following code snippets below show how to use IProgressCallback interface:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-CovertToPDFWithProgressUpdate-ExportProgressHandler.java" >}}
