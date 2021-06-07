---
title: Working Solution for Chart Resizing in PPTX
type: docs
weight: 60
url: /cpp/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

It has been observed that Excel Charts embedded as OLE in a PowerPoint Presentation through Aspose components are resized to an unidentified scale after first time activation. This behavior creates a considerable visual difference of the presentation between pre and post chart activation states. Aspose team with the help of Microsoft team has investigated this issue in detail and found the solution to this issue. This article covers the reasons and the solution to this issue. 

{{% /alert %}} 
## **Background**
In [previous article](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) , we have explained how to create an Excel Chart using Aspose.Cells for C++ and further embed this chart in a PowerPoint Presentation using Aspose.Slides for C++. In order to accommodate the object changed issue, we assigned the chart image to the Chart OLE Object Frame. In the output presentation, when we double click the OLE Object Frame showing the Chart Image, the Excel Chart is activated. The end users can make any desired changes in the actual Excel Workbook and then return to the concerned Slide by clicking outside the activated Excel Workbook. The size of the OLE Object Frame will change when the user gets back to the slide. The resizing factor will be different for different sizes of OLE Object Frame and embedded Excel Workbook.

## **Cause of Resizing**
Since the Excel Workbook has its own window size, it tries to retain its original size on first time activation. On the other hand, the OLE Object Frame will have its own size. According to Microsoft, on activation of the Excel Workbook, Excel and PowerPoint negotiate the size and ensure it is in the correct proportions as part of the embedding operation. Based on the differences in the Excel Windows size and OLE Object Frame size / position, the resizing takes place. 

## **Working Solution**
There are two possible scenarios for creation of the PowerPoint Presentations using Aspose.Slides for C++. 

**Scenario 1:** Create the presentation based on an existing template.

**Scenario 2:** Create the presentation from scratch. 

The solution that we will provide here will be valid for both scenarios. The base of all the solution approaches will be same. That is: **Embedded OLE Object Window size should be the same as that of the OLE Object Frame** **in the PowerPoint Slide** . Now, we will discuss the two approaches of the solution. 

## **First Approach**
In this approach, we will learn how to set the window size of the embedded Excel Workbook equivalent to the size of the OLE Object Frame in the PowerPoint Slide. 

**Scenario 1** 

Suppose, we have defined a template and desire to create the presentations based on this template. Let us say there is some shape at index 2 in the template where we want to place an OLE Frame carrying an embedded Excel Workbook. In this scenario, the size of the OLE Object Frame will be considered as predefined (which is the size of the shape at index 2 in the template). All we have to do: set the window size of the Workbook equal to the size of the Shape. The following code snippet will serve this purpose: 

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
// define chart size with window 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shapes()->idx_get(2);

// set window width of the workbook in inches (divided by 72 as PowerPoint uses 
// 72 pixels / inch)
wb->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// set window height of the workbook in inches
wb->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Instantiate MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream3(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Create an OLE Object Frame with embedded Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(), 
	shape->get_Height(),
	dataInfo);
```

**Scenario 2** 

Let us say, we want to create a presentation from scratch and desire an OLE Object Frame of any size with an embedded Excel Workbook. In the following code snippet, we have created an OLE Object Frame with 4 inch height and 9.5 inch width in the slide at x-axis=0.5 inch and y-axis=1 inch. Further, we have set the equivalent Excel Workbook window size, that is: height 4 inch and width 9.5 inch. 

``` cpp
// Our desired height
int32_t desiredHeight = 288; //4 inch (4 * 72)

// Our desired width
int32_t desiredWidth = 684; //9.5 inch (9.5 * 72)

// define chart size with window 
chart->SetSizeWithWindow(true);

// set window width of the workbook in inches
wb->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// set window height of the workbook in inches
wb->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Instantiate MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Create an OLE Object Frame with embedded Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f,
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```


## **Second Approach**
In this approach, we will learn how to set the chart size present in the embedded Excel Workbook equivalent to the size of the OLE Object Frame in the PowerPoint Slide. This approach is useful when the size of the chart up-front is known and will never change. 

**Scenario 1** 

Suppose, we have defined a template and desire to create the presentations based on this template. Let us say there is some shape at index 2 in the template where we want to place an OLE Frame carrying an embedded Excel Workbook. In this scenario, the size of the OLE Frame will be considered as predefined (which is the size of the shape at index 2 in the template). All we have to do: set the size of the chart in the Workbook equal to the size of the shape. The following code snippet will serve this purpose: 

``` cpp
// define chart size without window 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shapes()->idx_get(2);

// set chart width in pixels (Multiply by 96 as Excel uses 96 pixels per inch)    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// set chart height in pixels
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Define chart print size
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Instantiate MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Create an OLE Object Frame with embedded Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(),
	shape->get_Height(),
	dataInfo);
```

**Scenario 2** 

Let us say, we want to create a presentation from scratch and desire an OLE Object Frame of any size with an embedded Excel Workbook. In the following code snippet, we have created an OLE Object Frame with 4 inch height and 9.5 inch width in the slide at x-axis=0.5 inch and y-axis=1 inch. Further, we have set the equivalent Chart size, that is: height 4 inch and width 9.5 inch. 

``` cpp
// Our desired height
int32_t desiredHeight = 288; // 4 inch (4 * 576)

// Our desired width
int32_t desiredWidth = 684; // 9.5 inch(9.5 * 576)

// define chart size without window 
chart->SetSizeWithWindow(false);

// set chart width in pixels    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// set chart height in pixels    
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Instantiate MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Create an OLE Object Frame with embedded Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f, 
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```

## **Conclusion**
{{% alert color="primary" %}} 

There are two approaches to fix the chart resizing issue. The selection of the appropriate approach depends upon the requirement and the use case. Both approaches work in the same way whether the presentations are created from a template or create from scratch. Also, there is no limit of the OLE Object Frame size in the solution. 

{{% /alert %}} 
## **Related Sections**
[Creating and Embedding an Excel Chart as OLE Object in Presentation](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

