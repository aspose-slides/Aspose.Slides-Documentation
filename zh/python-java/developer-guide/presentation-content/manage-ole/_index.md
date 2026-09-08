---
title: 使用 Python 管理演示文稿中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh/python-java/manage-ole/
keywords:
- OLE 对象
- 对象链接与嵌入
- 添加 OLE
- 嵌入 OLE
- 添加对象
- 嵌入对象
- 添加文件
- 嵌入文件
- 链接对象
- 链接文件
- 更改 OLE
- OLE 图标
- OLE 标题
- 提取 OLE
- 提取对象
- 提取文件
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 优化 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理，实现 OLE 内容的无缝嵌入、更新和导出。"
---
## **介绍**

{{% alert color="info" title="Note" %}}

OLE（对象链接与嵌入）是 Microsoft 的一项技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入的方式放置到另一个应用程序中。

{{% /alert %}}

设想在 Microsoft Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。

- OLE 对象可能以图标形式出现。在这种情况下，双击图标会在其关联的应用程序（Excel）中打开图表，或会提示您选择用于打开或编辑对象的应用程序。
- OLE 对象也可能直接显示其实际内容，例如图表的内容。在这种情况下，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表的数据。

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/zh/python-java/) 允许您在幻灯片中插入 OLE 对象作为 OLE 对象帧 ([OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/))。

## **向幻灯片添加 OLE 对象帧**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Python via Java 将其作为 OLE 对象帧嵌入到幻灯片中，您可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 将 Excel 文件读取为字节数组。
1. 将包含字节数组和 OLE 对象其他信息的 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/) 添加到幻灯片中。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for Python via Java 将 Excel 文件中的图表作为 OLE 对象帧添加到幻灯片中。**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleembeddeddatainfo/) 构造函数接受可嵌入对象的扩展名作为第二参数。此扩展名使 PowerPoint 能够正确识别文件类型并选择合适的应用程序打开该 OLE 对象。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # 为 OLE 对象准备数据。
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # 将 OLE 对象帧添加到幻灯片。
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **添加链接的 OLE 对象帧**

Aspose.Slides for Python via Java 允许您添加一个不嵌入数据、仅通过文件链接的 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/)。

下面的 Python 代码演示了如何向幻灯片添加带有链接的 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 添加一个带有链接的 Excel 文件的 OLE 对象帧。
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **访问 OLE 对象帧**

如果幻灯片中已经嵌入了 OLE 对象，您可以通过以下方式轻松查找或访问它：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例，加载包含嵌入式 OLE 对象的演示文稿。
2. 使用索引获取幻灯片的引用。
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/) 形状。在我们的示例中，使用之前创建的 PPTX，该 PPTX 的第一张幻灯片只有一个形状。随后我们检查该对象是 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/)。这就是要访问的目标 OLE 对象帧。
4. 一旦访问到 OLE 对象帧，您就可以对其执行任何操作。

在下面的示例中，访问了 OLE 对象帧（嵌入在幻灯片中的 Excel 图表对象）及其文件数据。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # 获取嵌入文件的数据。
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # 获取嵌入文件的扩展名。
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **访问链接的 OLE 对象帧属性**

Aspose.Slides 允许您访问链接的 OLE 对象帧属性。

下面的 Python 代码演示了如何检查 OLE 对象是否为链接，以及获取链接文件的路径：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # 检查 OLE 对象是否为链接。
        if ole_frame.isObjectLink():
            # 打印链接文件的完整路径。
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # 如果存在，打印链接文件的相对路径。
            # 仅 PPT 演示文稿可以包含相对路径。
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **更改 OLE 对象数据**

{{% alert color="info" title="Note" %}}

在本节中，下面的代码示例使用 [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/)。

{{% /alert %}}

如果幻灯片中已经嵌入 OLE 对象，您可以通过以下方式轻松访问该对象并修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例，加载包含嵌入式 OLE 对象的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 访问 OLE 对象帧形状。在我们的示例中，使用之前创建的 PPTX，该 PPTX 的第一张幻灯片只有一个形状。随后我们检查该对象是 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/)。这就是要访问的目标 OLE 对象帧。
4. 一旦访问到 OLE 对象帧，您就可以对其执行任何操作。
5. 创建一个 [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 对象并访问 OLE 数据。
6. 访问所需的 [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) 并修改数据。
7. 将更新后的 [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 保存到流中。
8. 从流中更改 OLE 对象的数据。

在下面的示例中，访问了 OLE 对象帧（嵌入在幻灯片中的 Excel 图表对象），并修改其文件数据以更新图表数据。

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # 将 OLE 对象数据读取为 Workbook 对象。
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # 修改工作簿数据。
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # 更改 OLE 框对象数据。
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表，Aspose.Slides for Python via Java 还允许您在幻灯片中嵌入其他类型的文件。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，它会自动在相应程序中打开，或提示用户选择合适的程序打开它。

下面的 Python 代码演示了如何将 HTML 和 ZIP 嵌入到幻灯片中：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置嵌入对象的文件类型**

在处理演示文稿时，您可能需要将旧的 OLE 对象替换为新的，或将不受支持的 OLE 对象替换为受支持的。Aspose.Slides for Python via Java 允许您设置嵌入对象的文件类型，从而更新 OLE 帧数据或其扩展名。

下面的 Python 代码演示了如何将嵌入的 OLE 对象的文件类型设置为 `zip`：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # 将文件类型更改为 ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **为嵌入对象设置图标图像和标题**

嵌入 OLE 对象后，会自动添加由图标图像组成的预览。这是用户在访问或打开 OLE 对象前看到的内容。如果您想在预览中使用特定的图像和文字作为元素，可以使用 Aspose.Slides for Python via Java 设置图标图像和标题。

下面的 Python 代码演示了如何为嵌入对象设置图标图像和标题：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # 向演示文稿资源添加图像。
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # 为 OLE 预览设置标题和图像。
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **防止 OLE 对象帧被调整大小和重新定位**

在将链接的 OLE 对象添加到演示文稿幻灯片后，打开 PowerPoint 时可能会看到提示更新链接的消息。单击 “Update Links” 按钮可能会因 PowerPoint 从链接的 OLE 对象更新数据并刷新对象预览而改变 OLE 对象帧的大小和位置。为防止 PowerPoint 提示更新对象数据，请将 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/) 类的 [setUpdateAutomatic](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 方法设为 `False`：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **提取嵌入文件**

Aspose.Slides for Python via Java 允许您按以下方式提取嵌入在幻灯片中的 OLE 对象文件：

1. 创建一个包含您要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 遍历演示文稿中的所有形状并访问其中的 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/) 形状。
3. 从 OLE 对象帧中获取嵌入文件的数据并写入磁盘。

下面的 Python 代码演示了如何提取嵌入在幻灯片中的 OLE 对象文件：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**在将幻灯片导出为 PDF/图像时，OLE 内容会被渲染吗？**

渲染的仅是幻灯片上可见的内容——图标/替代图像（预览）。在渲染过程中不会执行“实时” OLE 内容。如有需要，可设置自己的预览图像，以确保在导出的 PDF 中呈现预期外观。

**如何在幻灯片上锁定 OLE 对象，使用户在 PowerPoint 中无法移动或编辑它？**

锁定形状：Aspose.Slides 提供了 [形状级别的锁定](/slides/zh/python-java/applying-protection-to-presentation/)。这不是加密，但可以有效防止意外编辑和移动。

**为什么在打开演示文稿时，链接的 Excel 对象会“跳动”或大小改变？**

PowerPoint 可能会刷新链接 OLE 的预览。为获得稳定的外观，请遵循 [Worksheet Resizing 工作方案](/slides/zh/python-java/working-solution-for-worksheet-resizing/)——要么将框架适配到范围，要么将范围缩放到固定框架并设置合适的替代图像。

**在 PPTX 格式中，链接的 OLE 对象的相对路径会被保留吗？**

在 PPTX 中不提供“相对路径”信息——仅有完整路径。相对路径仅存在于旧的 PPT 格式。为了可移植性，建议使用可靠的绝对路径/可访问的 URI 或进行嵌入。