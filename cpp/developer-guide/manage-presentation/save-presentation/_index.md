---
title: Save Presentation
type: docs
weight: 70
url: /cpp/save-presentation/
---

{{% alert title="Info" color="info" %}}

To learn how to open or load presentations, see the [*Open Presentation*](https://docs.aspose.com/slides/cpp/open-presentation/) article. 

{{% /alert %}}

The article here explains how to save presentations.

The [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for C++, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:

## **Save Presentation to File**
Save a presentation to files by calling the **Presentation** class [Save](https://apireference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method. Simply pass the file name and save format to the [Save](https://apireference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method. The examples that follow show how to save a presentation with Aspose.Slides for C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveToFile-SaveToFile.cpp" >}}
## **Save Presentation to Stream**
It is possible to save a presentation to a stream by passing an output stream to the [Presentation]() class Save method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStream-SaveToStream.cpp" >}}


## **Save Presentation with Predefined View Type**
Aspose.Slides for C++ provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties) class. The [LastView](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) property is used to set the view type by using the [ViewType](http://www.aspose.com/api/net/slides/aspose.slides/viewtype) enumerator.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cpp" >}}

## **Save Presentation to Strict Open XML Spreadsheet Format**
Aspose.Slides allows you to save the presentation in Strict Open XML format. For that purpose, it provides the **PptxOptions** class where you can set the Conformance property while saving the presentation file. If you set its value as **Conformance.Iso29500_2008_Strict**, then the output presentation file will be saved in Strict Open XML format.

The following sample code creates a presentation and saves it in the Strict Open XML Format. While calling the Save method for the presentation, the **PptxOptions** object is passed into it with the Conformance property set as **Conformance.Iso29500_2008_Strict**.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStrictOpenXML-SaveToStrictOpenXML.cpp" >}}


## **Save Progress Updates in Percentage**
 New **IProgressCallback** interface has been added to **ISaveOptions** interface and **SaveOptions** abstract class. **IProgressCallback** interface represents a callback object for saving progress updates in percentage.  

The following code snippets below shows how to use IProgressCallback interface:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cpp" >}}

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-ExportProgressHandler.cpp" >}}

{{% alert title="Info" color="info" %}}

Using its own API, Aspose developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) that allows users to split their presentations into multiple files. Essentially, the app saves selected slides from a given presentation as new PowerPoint (PPTX or PPT) files. 

{{% /alert %}}