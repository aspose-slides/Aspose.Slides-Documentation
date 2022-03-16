---
title: Manage OLE
type: docs
weight: 40
url: /python-net/manage-ole/
keywords: "Add OLE, Add object, Embed object Object Linking & Embedding, OLE Object Frame, Embed OLE, PowerPoint presentation, Python, Aspose.Slides for Python via .NET "
description: "Add OLE object to PowerPoint presentation in Python"
---

{{% alert title="Info" color="info" %}}

OLE  (Object Linking & Embedding) is a Microsoft technology that allows data and objects created in one application to be placed in another application through linking or embedding. 

{{% /alert %}} 

Consider a chart created in MS Excel. The chart is then placed inside a PowerPoint slide. That Excel chart is considered an OLE object. 

- An OLE object may appear as an icon. In this case, when you double-click the icon, the chart gets opened in its associated application (Excel), or you are asked to select an application for object opening or editing. 
- An OLE object may display actual contents—for example, the contents of a chart. In this case, the chart is activated in PowerPoint, the chart interface loads, and you get to modify the chart's data within the PowerPoint app.

Aspose.Slides for Python via .NET allows you to insert OLE Objects into slides as OLE Object Frames. 

## **Adding OLE Object Frames to Slides**
Assuming you already created a chart in Microsoft Excel and want to embed that chart in a slide as an OLE Object Frame using Aspose.Slides for Python via .NET, you can do it this way:

1. Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
1. Obtain the reference of the slide by using its index.
1. Open the Excel file containing the Excel chart object and save it to `MemoryStream`.
1. Add the OLE Object Frame to the slide containing the array of bytes and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example below, we added a chart from an Excel file to a slide as an OLE Object Frame using Aspose.Slides for Python via .NET.  
**Note** that the [IOleEmbeddedDataInfo](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ioleembeddeddatainfo/) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

```py 
import aspose.slides as slides

# Instantiate the Presentation class that represents the PPTX
with slides.Presentation() as pres:
    # Access the first slide
    sld = pres.slides[0]

    # Load an excel file to stream
    with open(path + "book1.xlsx", "rb") as fs:
        bytes = fs.read()
    
        # Create a data object for embedding
        dataInfo = slides.dom.ole.OleEmbeddedDataInfo(bytes, "xlsx")

        # Add an Ole Object Frame shape
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # Write the PPTX to disk
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Accessing OLE Object Frames**
If an OLE object is already embedded in a slide, you can find or access that object easily using Aspose.Slides for Python via .NET this way:

1. Create an instance of the `Presentation` class.

1. Obtain the reference of the slide by using its index.

1. Access the [OleObjectFrame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/oleobjectframe/) shape.

   In our example, we used the previously created PPTX that has only one shape on the first slide.  We then *cast* that object as an [OleObjectFrame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/oleobjectframe/). This was the desired OLE Object Frame to be accessed.

1. Once the OLE Object Frame is accessed, you can perform any operation on it.

In the example below, an OLE Object Frame (an Excel chart object embedded in a slide) is accessed—and then its file data gets written to an Excel file.

```py 
import aspose.slides as slides

# Load the PPTX to Presentation object
with slides.Presentation(path + "AccessingOLEObjectFrame.pptx") as pres:
    # Access the first slide
    sld = pres.slides[0]

    # Cast the shape to OleObjectFrame
    oleObjectFrame = sld.shapes[0]

    # Read the OLE Object and write it to disk
    if type(oleObjectFrame) is slides.OleObjectFrame:
        # Get embedded file data
        data = oleObjectFrame.embedded_data.embedded_file_data

        # Get embedded file extention
        fileExtention = oleObjectFrame.embedded_data.embedded_file_extension

        # Create a path to save the extracted file
        extractedPath = "excelFromOLE_out" + fileExtention

        # Save extracted data
        with open("out.xlsx", "wb") as fs:
            fs.write(data)
```

## **Changing OLE Object Data**

If an OLE object is already embedded in a slide, you can easily access that object with Aspose.Slides for Python via .NET and modify its data this way:

1. Open the desired presentation with the embedded OLE Object by creating an instance of the `Presentation` class.

1. Obtain the reference of the slide by using its Index.

1. Access the OLE Object Frame shape.

   In our example, we used the previously created PPTX, which has only one shape on the first slide. We then *cast* that object as an [OleObjectFrame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/oleobjectframe/). This was the desired OLE Object Frame to be accessed.

1. Once the OLE Object Frame is accessed, you can perform any operation on it.

1. Create the Workbook object and access the OLE Data.

1. Access the desired Worksheet and amend the data.

1. Save the updated Workbook in streams.

1. Change the OLE object data from stream data.

In the example below, an OLE Object Frame (an Excel chart object embedded in a slide) is accessed—and then its file data is modified to change the chart data.

```py 
# [TODO:require Aspose.Cells for Python via .NET]
```

## Embedding Other File Types in Slides

Besides Excel charts, Aspose.Slides for Python via .NET allows you to embed other types of files in slides. For example, you can insert HTML, PDF, and ZIP files as objects into a slide. When a user double-clicks the inserted object, the object automatically gets launched in the relevant program, or the user gets directed to select an appropriate program to open the object. 

This python code shows you how to embed HTML and ZIP in a slide:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open(path + "index.html", "rb") as fs1:
        htmlBytes = fs1.read()
        dataInfoHtml = slides.dom.ole.OleEmbeddedDataInfo(htmlBytes, "html")
        oleFrameHtml = slide.shapes.add_ole_object_frame(150, 120, 50, 50, dataInfoHtml)
        oleFrameHtml.is_object_icon = True

    with open(path + "archive.zip", "rb") as fs2:
        zipBytes = fs2.read()
        dataInfoZip = slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip")
        oleFrameZip = slide.shapes.add_ole_object_frame(150, 220, 50, 50, dataInfoZip)
        oleFrameZip.is_object_icon = True

    pres.save("embeddedOle.pptx", slides.export.SaveFormat.PPTX)
```

## Setting File Types for Embedded Objects

When working on presentations, you may need to replace old OLE objects with new ones. Or you may need to replace an unsupported OLE object with a supported one. 

Aspose.Slides for Python via .NET allows you to set the file type for an embedded object. This way, you get to change the OLE frame data or its extension. 

This python code shows you how to set the file type for an embedded OLE object:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    print("Current embedded data extension is:" + oleObjectFrame.embedded_data.embedded_file_extension)
   
    with open(path + "1.zip", "rb") as fs2:
        zipBytes = fs2.read()

    oleObjectFrame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip"))
   
    pres.save("embeddedChanged.pptx", slides.export.SaveFormat.PPTX)
```

## Setting Icon Images and Titles for Embedded Objects

After you embed an OLE object, a preview consisting of an icon image and title gets added automatically. The preview is what users see before they access or open the OLE object. 

If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for Python via .NET. 

This Python code shows you how to set the icon image and title for an embedded object: 

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    
    with open("img.jpeg", "rb") as in_file:
        oleImage = pres.images.add_image(in_file)

    oleObjectFrame.substitute_picture_title = "My title"
    oleObjectFrame.substitute_picture_format.picture.image = oleImage
    oleObjectFrame.is_object_icon = False

    pres.save("embeddedOle-newImage.pptx", slides.export.SaveFormat.PPTX)
```



## Extracting Embedded Files

Aspose.Slides for Python via .NET allows you to extract the files embedded in slides as OLE objects this way:

1. Create an instance of the Presentation class containing the OLE object you intend to extract.
2. Loop through all the shapes in the presentation and access the OLE Object Frame shape.
3. Access the embedded file's data from the OLE Object Frame and write it to disk. 

This python code shows you how to extract a file embedded in a slide as an OLE object:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    index = 0
    for shape in slide.shapes:

        if type(shape) is slides.OleObjectFrame:
            data = shape.embedded_data.embedded_file_data
            extension = shape.embedded_data.embedded_file_extension
            
            with open("oleFrame{idx}{ex}".format(idx = str(index), ex = extension), "wb") as fs:
                fs.write(data)
        index += 1
```

