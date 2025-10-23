---
title: Manage OLE in Presentations Using Python
linktitle: Manage OLE
type: docs
weight: 40
url: /python-net/manage-ole/
keywords:
- OLE object
- Object Linking & Embedding
- add OLE
- embed OLE
- add object
- embed object
- add file
- embed file
- linked object
- linked file
- change OLE
- OLE icon
- OLE title
- extact OLE
- extract object
- extract file
- PowerPoint 
- presentation
- Python
- Aspose.Slides
description: "Optimize OLE object management in PowerPoint and OpenDocument files with Aspose.Slides for Python via .NET. Embed, update, and export OLE content seamlessly."
---

## **Overview**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** is a Microsoft technology that lets data and objects created in one application be linked or embedded in another.

{{% /alert %}}

For example, a chart created in Microsoft Excel and placed on a PowerPoint slide is an OLE object.

- An OLE object may appear as an icon. Double-clicking the icon opens the object in its associated application (e.g., Excel) or prompts you to choose an app to open or edit it.
- An OLE object may display its contents (for example, a chart). In this case, PowerPoint activates the embedded object, loads the chart interface, and allows you to edit the chart’s data within PowerPoint.

Aspose.Slides for Python lets you insert OLE objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Add OLE Objects to Slides**

If you’ve already created a chart in Microsoft Excel and want to embed it in a slide as an OLE object frame using Aspose.Slides for Python, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide by its index.
1. Read the Excel file into a byte array.
1. Add an [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) to the slide, supplying the byte array and other OLE object details.
1. Save the modified presentation as a PPTX file.

In the example below, a chart from an Excel file is embedded in a slide as an [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Note:** The [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) constructor takes the embeddable object’s file extension as its second parameter. PowerPoint uses this extension to identify the file type and select the appropriate application to open the OLE object.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Prepare the data for the OLE object.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Add an OLE object frame to the slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Add Linked OLE Objects**

Aspose.Slides for Python lets you add an [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) that links to a file instead of embedding its data.

The following Python example shows how to add an [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) linked to an Excel file on a slide:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an OLE object frame with a linked Excel file.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Access OLE Objects**

If an OLE object is already embedded in a slide, you can access it as follows:

1. Load the presentation that contains the embedded OLE object by creating an instance of the Presentation class.
1. Get a reference to the slide by its index.
1. Access the OleObjectFrame shape.
1. Once you have the OLE object frame, perform any required operations on it.

The example below accesses the OLE object frame—an embedded Excel chart—and retrieves its file data. In this example, we use a PPTX that has a single shape on the first slide.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Get the embedded file data.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Get the extension of the embedded file.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Access Linked OLE Object Properties**

Aspose.Slides lets you access the properties of a linked OLE object frame.

The Python example below checks whether an OLE object is linked and, if it is, retrieves the path to the linked file:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Check whether the OLE object is linked.
        if ole_frame.is_object_link:
            # Print the full path to the linked file.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Print the relative path to the linked file, if present.
            # Only .ppt presentations can contain a relative path.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Change OLE Object Data**

{{% alert color="primary" %}}

In this section, the code example below uses [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

If an OLE object is already embedded in a slide, you can access it and modify its data as follows:

1. Load the presentation by creating an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the target slide by its index.
1. Access the [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) shape.
1. Once you have the OLE object frame, perform the required operations on it.
1. Create a `Workbook` object and read the OLE data.
1. Open the desired `Worksheet` and edit the data.
1. Save the updated `Workbook` to a stream.
1. Replace the OLE object’s data using that stream.

In the example below, an OLE object frame (an embedded Excel chart) is accessed and its file data is modified to update the chart. The sample uses a previously created PPTX that contains a single shape on the first slide.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Read the OLE object data as a Workbook object.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modify the workbook data.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Change the OLE frame object data.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Embed Files in Slides**

In addition to Excel charts, Aspose.Slides for Python lets you embed other file types in slides. For example, you can insert HTML, PDF, and ZIP files as objects. When a user double-clicks an inserted object, it opens automatically in the associated application, or the user is prompted to choose an appropriate program.

This Python code shows how to embed HTML and ZIP files in a slide:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Set File Types for Embedded Objects**

When working with presentations, you may need to replace old OLE objects with new ones or swap an unsupported OLE object for a supported one. Aspose.Slides for Python lets you set the file type of an embedded object, allowing you to update the OLE frame data or its file extension.

This Python code shows how to set the embedded OLE object’s file type to `zip`:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Change the file type to ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Icon Images and Titles for Embedded Objects**

After you embed an OLE object, an icon-based preview is added automatically. This preview is what users see before they access or open the OLE object. If you want to use a specific image and text in the preview, you can set the icon image and title using Aspose.Slides for Python.

This Python code shows how to set the icon image and title for an embedded object:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Add an image to the presentation resources.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Set a title and the image for the OLE preview.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Prevent OLE Object Frames from Being Resized and Pepositioned**

After you add a linked OLE object to a slide, PowerPoint may prompt you to update links when you open the presentation. Selecting Update Links can change the OLE object frame’s size and position because PowerPoint refreshes the preview with data from the linked object. To prevent PowerPoint from prompting you to update the object’s data, set the `update_automatic` property of the [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) class to `False`:

```py
ole_frame.update_automatic = False
```

## **Extract Embedded Files**

Aspose.Slides for Python lets you extract files embedded in slides as OLE objects as follows:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class that contains the OLE objects you want to extract.
1. Iterate through all shapes in the presentation and locate the OLEObjectFrame shapes.
1. Retrieve the embedded file data from each [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) and write it to disk.

The following Python code shows how to extract files embedded in a slide as OLE objects:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**Will the OLE content be rendered when exporting slides to PDF/images?**

What is visible on the slide is rendered—the icon/substitute image (preview). The "live" OLE content is not executed during rendering. If needed, set your own preview image to ensure the expected appearance in the exported PDF.

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**

Lock the shape: Aspose.Slides provides [shape-level locks](/slides/python-net/applying-protection-to-presentation/). This is not encryption, but it effectively prevents accidental edits and movement.

**Why does a linked Excel object "jump" or change size when I open the presentation?**

PowerPoint may refresh the preview of the linked OLE. For a stable appearance, follow the [Working Solution for Worksheet Resizing](/slides/python-net/working-solution-for-worksheet-resizing/) practices—either fit the frame to the range, or scale the range to a fixed frame and set an appropriate substitute image.

**Will relative paths for linked OLE objects be preserved in the PPTX format?**

In PPTX, "relative path" information is not available—only the full path. Relative paths are found in the older PPT format. For portability, prefer reliable absolute paths/accessible URIs or embedding.
