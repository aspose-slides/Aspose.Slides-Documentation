---
title: Saving, Printing and Managing
type: docs
weight: 110
url: /cpp/saving-printing-and-managing/
---

## **Saving a Presentation**
[Opening a Presentation]() described how to use the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class to open a presentation. This article explains how to create and save presentations.
The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for C++, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:
### **Save to File**
Save a presentation to files by calling the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class [Save](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/save/index) method. Simply pass the file name and save format to the [Save](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/save/index) method. The examples that follow show how to save a presentation with Aspose.Slides for C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveToFile-SaveToFile.cpp" >}}
### **Save to Stream**
It is possible to save a presentation to a stream by passing an output stream to the [Presentation](/pages/createpage.action?spaceKey=slidescpp&title=Aspose.Slides.Presentation+Class&linkCreation=true&fromPageId=60228364) class Save method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStream-SaveToStream.cpp" >}}
### **Save with Password Protection**
It's possible to save presentations with password protection. The presentation class exposes the [Encrypt](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/methods/encrypt) method which sets the password for the presentation. To do this, simply pass the password to the [Encrypt](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/methods/encrypt) method and then use the [Save](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/save/index) method exposed by the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class as a string to save the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveWithPassword-SaveWithPassword.cpp" >}}
### **Save with password protection and Read Access to Document Properties**
It's possible to save presentations with password protection. But in that case access to the presentation's document properties is also prohibited. Aspose.Slides offers a mechanism for password protecting a presentation but still being able to access the document properties in PowerPoint. The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class exposes the [EncryptDocumentProperties](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/properties/index) property that takes a Boolean value to allow or disallow access to the document properties in password protected mode. By default, its value is set to true. The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class also exposes the [Encrypt](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/methods/encrypt) method which sets the password for the presentation.

To do this, simply pass the password to the [Encrypt](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/methods/encrypt) method and then use the [Save](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/save/index) method exposed by the Presentation class as a string to save the presentation.method.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveProperties-SaveProperties.cpp" >}}
### **Save in Read Only Mode**
Developers can now save presentations with write protection to allow the presentation to be read in read only mode. The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class exposes the [SetWriteProtection(string Password)](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/setwriteprotection) method with which it is possible to save the presentation in read only mode by applying write protection on it. To do so, call the method and set the write protection password. The following code snippet shows you how to apply write protection to a presentation with Aspose.Slides for C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsReadOnly-SaveAsReadOnly.cpp" >}}
### **Save with predefined View Type**
Aspose.Slides for C++ provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties) class. The [LastView](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) property is used to set the view type by using the [ViewType](http://www.aspose.com/api/net/slides/aspose.slides/viewtype) enumerator.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cpp" >}}
### **Save Presentation to Strict Open XML Spreadsheet Format**
Aspose.Slides allows you to save the presentation in Strict Open XML format. For that purpose, it provides the **PptxOptions** class where you can set the Conformance property while saving the presentation file. If you set its value as **Conformance.Iso29500_2008_Strict**, then the output presentation file will be saved in Strict Open XML format.

The following sample code creates a presentation and saves it in the Strict Open XML Format. While calling the Save method for the presentation, the **PptxOptions** object is passed into it with the Conformance property set as **Conformance.Iso29500_2008_Strict**.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStrictOpenXML-SaveToStrictOpenXML.cpp" >}}


## **Working with Document Properties**
As we have described earlier that Aspose.Slides for C++ supports two kinds of document properties, which are **Built-in** and **Custom** properties. So, developers can access both kinds of properties with the use of Aspose.Slides for C++ API. Aspose.Slides for C++ provides a class [IDocumentProperties](http://www.aspose.com/api/net/slides/aspose.slides/idocumentproperties) that represents the document properties associated with a presentation file through [Presentation.DocumentProperties](http://www.aspose.com/api/net/slides/aspose.slides/presentation/properties/documentproperties) property. Developers can use [IDocumentProperties](http://www.aspose.com/api/net/slides/aspose.slides/idocumentproperties/properties/index) property exposed by **Presentation** object to access the document properties of the presentation files as described below:

{{% alert color="primary" %}} 

Please note that you cannot set values against the **Application** and **Producer** fields, because Aspose Ltd. and Aspose.Slides for C++ x.x.x will be displayed against these fields.

{{% /alert %}} 


### **Managing Document Properties**
Microsoft PowerPoint provides a feature to add some properties to the presentation files. These document properties allow some useful information to be stored along with the documents (presentation files). There are two kinds of document properties as follows

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for .NET, developers can access and modify the values of built-in properties as well as custom properties. Microsoft PowerPoint 2007 allows managing the document properties of the presentation files. All you have to do is to click the Office icon and further **Prepare | Properties | Advanced Properties** menu item of the Microsoft PowerPoint 2007. After you select **Advanced Properties** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file. In the **Properties Dialog**, you can see that there are many tab pages like **General, Summary, Statistics, Contents and Custom**. All these tab pages allow configuring different kinds of information related to the PowerPoint files. **Custom** tab is used to manage custom properties of the PowerPoint files.
### **Accessing Built-in Properties**
These properties as exposed by **IDocumentProperties** object include: **Creator(Author)**, **Description**, **KeyWords** **Created** (Creation Date), **Modified** Modification Date, **Printed** Last Print Date, **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** and **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}
### **Modifying Built-in Properties**
Modifying the built-in properties of presentation files is as easy as that of accessing them. You can simply assign a string value to any desired property and the property value would be modified. In the example given below, we have demonstrated that how we can modify the built-in document properties of the presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}
### **Accessing and Modifying Custom Properties**
Aspose.Slides for C++ also allows developers to access the values of custom properties. An example is given below that shows how can you access and modify all of these custom properties for a presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}
### **Adding Custom Document Properties**
Aspose.Slides for C++ also allows developers to add the custom the values for presentation Document properties. An example is given below that shows how to set the custom properties for a presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}
## **Removing Write Protection from a Presentation**
Aspose.Slides for C++ provides a facility for accessing write protected presentation through the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class. The [IsWriteProtected](http://www.aspose.com/api/net/slides/aspose.slides/presentation/properties/iswriteprotected) property identifies whether a presentation is write protected or not. Then if it is write protected, the protection can be removed using the [RemoveWriteProtection](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/removewriteprotection) method.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveWriteProtection-RemoveWriteProtection.cpp" >}}
## **Add Blob in Presentations**
Aspose.Slides for C++ provides a facility to add large files (video file in that case) and prevent a high memory consumption. An example is given below that shows how to add Blob in presentations.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddBlobToPresentation-AddBlobToPresentation.cpp" >}}
## **Export Blob from Presentations**
Aspose.Slides for C++ provides a facility to Export large files (audio and video file in that case). We want to extract these files from the presentation and don't want to load this presentation into memory to keep our memory consumption low. Here's is an example given below how we can export blob from presentations.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExportBlobFromPresentation-ExportBlobFromPresentation.cpp" >}}
## **Check if Presentation is Modified or Created**
Aspose.Slides for C++ provides a facility to check if a presentation is modified or created. An example is given below that shows how to check if the presentation is created or modified.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}
## **Support for adding EMZ image to Images collection**
Aspose.Slides for C++ provides a facility to embed emz file inside a presentation images collection. An example is given below that shows how to add emz image to images collection.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddingEMZImagesToImageCollection-AddingEMZImagesToImageCollection.cpp" >}}
## **Render comments when saving Presentation into Image**
Aspose.Slides for C++ provides a facility to render comments of presentations or slide when converting those into images.  An example is given below that shows how to render comments of presentation into an image.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RenderComments-RenderComments.cpp" >}}
## **Add an Image From SVG Object**
Aspose.Slides for C++ added new **AddImage** method to **IImageCollection** **interface** and **ImageCollection class.** These methods provide the ability to insert SVG fragments to the presentation image collection.

The code sample below shows how to insert SVG fragments to the presentation image collection.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddImageFromSVGObject-AddImageFromSVGObject.cpp" >}}

The following code shows how to insert SVG fragments to the presentation image collection from an external resource.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddImageFromSVGObjectFromExternalResource-AddImageFromSVGObjectFromExternalResource.cpp" >}}


## **Convert SVG Images Into Group Shape**


` `New **AddGroupShape** method has been added to **IShapeCollection interface** and **ShapeCollection class** in Aspose.Slides for C++. This method allows to convert **SvgImage** object that represents SVG data into a group of shapes.

` `The code sample below shows how to convert SVG images into a group of shapes.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ConvertSvgImageObjectIntoGroupOfShapes-ConvertSvgImageObjectIntoGroupOfShapes.cpp" >}}
## **Add Image as BLOB in Presentation**
Aspose.Slides for C++ added a new method to **IImageCollection** interface and **ImageCollection** class to support adding a large image as streams to treat them as BLOBs.

This example demonstrates how to include the large BLOB (image) and prevent a high memory consumption.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddBlobImageToPresentation-AddBlobImageToPresentation.cpp" >}}
## **Saving Progress Updates in Percentage**
` `New **IProgressCallback** interface has been added to **ISaveOptions** interface and **SaveOptions** abstract class. **IProgressCallback** interface represents a callback object for saving progress updates in percentage.  

The following code snippets below shows how to use IProgressCallback interface:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cpp" >}}

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-ExportProgressHandler.cpp" >}}

