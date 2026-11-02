---
title: 使用 Python via Java 管理演示文稿超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/python-java/manage-hyperlinks/
keywords:
- 添加 URL
- 添加超链接
- 创建超链接
- 格式化超链接
- 移除超链接
- 更新超链接
- 文本超链接
- 幻灯片超链接
- 形状超链接
- 图像超链接
- 视频超链接
- 可变超链接
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、更新和移除超链接，提供 Python 示例。"
---
## **介绍**

超链接将演示文稿内容连接到网站或演示文稿内的某个位置。在 PowerPoint 中，超链接通常有两个用途：

* 从文本、形状或媒体框架打开网站。
* 从目录等跳转到另一张幻灯片。

Aspose.Slides for Python via Java 让您可以添加这些链接、控制它们的外观和声音、更新其属性并将其移除。下面的示例展示了如何在单个元素上使用超链接以及如何在演示文稿、幻灯片或文本框层级访问超链接。

{{% alert color="info" title="Note" %}}

您还可以使用[免费在线 Aspose PowerPoint 编辑器](https://products.aspose.app/slides/editor)编辑演示文稿。

{{% /alert %}} 

## **添加 URL 超链接**

您可以为文本、形状或媒体框架分配网站 URL。分配超链接的元素决定了可点击的区域：文本片段会链接所选文本，而形状或框架会链接整个幻灯片对象。

对于包含相对超链接的演示文稿，请参阅[管理超链接基准](/slides/zh/python-java/presentation-properties/#manage-the-hyperlink-base)以读取、修改或清除文档级别的基准。

### **为文本添加 URL 超链接**

要将文本链接到网站，请将一个[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/)传递给文本片段的[setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick)方法，如下所示。只有该文本片段会变为可点击。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **为形状和媒体框架添加 URL 超链接**

要使形状或框架可点击，请调用其[setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick)方法。超链接属于对象本身，而不是其中的文本片段。

同样的方法适用于图片、音频和视频框架：将超链接分配给框架，并在需要时调用[setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip)。

以下示例使一个矩形可点击：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **使用超链接创建目录**

内部超链接允许读者从目录跳转到特定幻灯片。以下示例使用[setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick)将第一张幻灯片上的“Page 2”文本链接到第二张幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **格式化超链接**

### **颜色**

[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/)的[setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource)方法决定超链接是使用演示文稿的超链接颜色还是文本片段的格式。要应用自定义文本颜色，请选择[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/)并设置片段的填充颜色。此功能在 PowerPoint 2019 中引入；旧版本不适用此设置。

以下示例向同一张幻灯片添加了两个文本超链接。第一个使用红色文本填充，而第二个保留默认的超链接颜色。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **声音**

超链接在激活时可以播放声音，或停止已在播放的声音。使用以下方法来配置这些行为：

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound)指定与超链接关联的音频。
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)控制激活超链接时是否停止之前的声音。

#### **添加超链接声音**

以下示例加载 `sampleaudio.wav` 并将其关联到第一张幻灯片上的按钮。单击该按钮会播放声音并跳转到下一张幻灯片。该幻灯片上的第二个形状在单击时停止之前的声音，不执行导航操作。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **提取超链接声音**

以下示例打开上述创建的演示文稿，并通过[getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound)和[getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData)将第一个形状的超链接音频读取到内存中。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **工具提示和交互设置**

将超链接分配给文本或形状后，您可以调用以下[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/)方法：

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip)设置查看者可以显示为链接提示的文本。
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame)在适用时指定父 HTML frameset 中的目标框架。
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory)控制激活链接时是否将其目标添加到已查看超链接列表中。
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick)控制点击时是否突出显示超链接。

## **从演示文稿中移除超链接**

在更改之前，使用[getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)收集超链接容器，包括文本片段链接。以下示例从第一张幻灯片移除两种激活类型。若仅移除一种类型，只调用[removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick)或[removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver)；移除点击操作不会移除其鼠标悬停对应操作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

若要无条件移除，[removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)在一次调用中移除所选范围内的两种激活类型。有关选择性清理以及对母版、布局和备注的覆盖，请参阅[报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)。

## **构建完整的超链接清单**

在发布演示文稿之前，需要对其交互操作及网络链接进行清点。[getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)返回超链接容器，如[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)和[PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/)对象，而非 URL 字符串的平面列表。对每个容器检查[getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick)和[getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver)。它们是独立的：同一容器可以公开两种操作，因此完整报告每个容器可能需要两行。

仅扫描形状层级的超链接可能会漏掉附加在文本片段上的链接。请改为查询相应的范围，并保留返回的容器，以便稍后更新或移除其操作。

### **查询演示文稿、幻灯片和文本框范围**

[HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/)类可通过[Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries)、[BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries)和[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries)获取。每个范围支持相同的查询：

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)返回具有点击操作的容器。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)返回具有鼠标悬停操作的容器。
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)返回具有任一或两种操作的容器。

以下示例创建 `hyperlink-audit-input.pptx`，其中包含外部点击链接、文件鼠标悬停链接、内部幻灯片导航、文本鼠标悬停链接以及宏操作。它不会执行这些操作。这三个查询在每个范围内均可使用；计数描述的是容器数量，而非操作总数。文本框范围排除其包含的形状自身的链接。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在本示例中，演示文稿和幻灯片查询各报告三个点击容器、两个鼠标悬停容器以及三个任一操作的容器。文本框查询在每个类别中报告一个容器。

### **对操作和目标进行分类**

使用[Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType)在解释目标之前先解释操作。[HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/)的值涵盖的不仅仅是网页导航：

| 值 | 审计含义 |
| --- | --- |
| `Hyperlink` | 外部超链接；检查 URL 及其协议。 |
| `JumpSpecificSlide` | 内部导航到特定幻灯片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 内置幻灯片放映导航，在放映上下文中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 结束当前放映或启动自定义放映。 |
| `StartMacro` | 执行宏。 |
| `StartProgram` | 启动程序。 |
| `OpenFile`, `OpenPresentation` | 打开文件或其他演示文稿；需与网页 URL 分别审查。 |
| `StartStopMedia` | 开始或停止媒体播放。 |
| `NoAction`, `Unknown` | 无导航动作，或需要审查的未识别动作。 |

使用[getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl)读取外部目标，使用[getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide)读取特定内部目标。内部操作和内置命令可能没有外部 URL；空 URL 并不表示容器没有操作。当[getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal)返回的值与标准化 URL 不同时，请保留该值，并在可用时包含[getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip)返回的工具提示。

### **报告、清理和验证超链接**

下面的 Python 示例读取已有演示文稿（使用上面创建的文件），写入 `hyperlink-audit.json`，应用策略，保存为 `hyperlink-sanitized.pptx`，并重新打开以再次检查两种激活类型。它在更改之前收集容器，并使用引用相等性避免对同一容器进行两次处理。演示文稿查询覆盖普通幻灯片；若要进行全包清点，还会显式查询母版、布局、备注以及出现时的备注和讲义母版。

报告记录基于 1 的幻灯片索引和（如可用的）[getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId)。[getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide)为受支持的容器提供所属幻灯片。母版、布局和备注没有普通幻灯片索引，以其范围标识。形状容器和文本片段格式容器分别标记；其他容器类型保留其运行时类型名称。每个容器获得报告本地 ID，以便关联其两个操作。报告将操作类型存为 Java 枚举定义的整数常量。

此刻意严格的应用策略仅允许绝对的 HTTPS URL 和有效的内部幻灯片目标。它会拒绝宏、程序、文件操作、其他幻灯片放映操作、未知操作以及其他 URL 方案。这些拒绝是策略决定，而非 Aspose.Slides 的安全判定。仅 HTTPS 并不能建立信任：请为您的应用程序添加主机白名单及其他检查。原始和标准化的外部 URL 均会被检查。示例在不跟随链接或执行操作的情况下审计元数据。

为进行修复，容器的[getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager)支持[setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick)、[removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick)和[removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver)。这里，将被禁止的外部点击链接替换为固定的 HTTPS 着陆页；其他被禁止的点击和被禁止的鼠标悬停操作则分别被移除。将 `replace_external_clicks` 设置为 `False` 可改为移除所有策略违规。请在部署前选择由应用拥有的替换页面。

报告的导出标记使用保守的 PDF 审查策略：将鼠标悬停操作以及除外部链接或特定幻灯片跳转之外的任何操作标记为可能不受支持。这是一种审查提示，而非能力测试，也不保证未标记的链接在导出后仍然有效。受支持的[PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)和[HTML](/slides/zh/python-java/convert-powerpoint-to-html/)导出可能保留超链接，具体取决于操作、导出选项和查看器。光栅[图像](/slides/zh/python-java/convert-powerpoint-to-png/)和[视频](/slides/zh/python-java/convert-powerpoint-to-video/)无法保留交互式超链接；在针对这些输出进行审计时请标记所有操作。

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

使用上述创建的输入，报告包含五行操作。文件鼠标悬停链接和宏点击被移除，而 HTTPS 链接和内部幻灯片导航仍保留。验证结果显示零个违规操作。包含被禁止的外部点击 URL 的输入也会触发替换分支。既有允许的点击又有被禁止的鼠标悬停的容器会保留其点击操作。

此选择性清理不同于[removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)，后者会在所选范围内无论策略如何都移除两种激活类型。此处的验证仅检查超链接操作；它不会移除嵌入的 VBA 项目、OLE 对象或其他活动内容，也不会验证导出的 PDF 或 HTML 文件。

## **常见问题**

**如何链接到章节或其第一张幻灯片？**

PowerPoint 中的章节用于对幻灯片进行分组，但内部超链接只能定位到单个幻灯片。若要实现跳转到章节，需链接到该章节的第一张幻灯片。

**我可以将超链接附加到母版幻灯片元素，使其在所有幻灯片上生效吗？**

可以。母版幻灯片和布局元素支持超链接。这些元素上的链接在使用相应母版或布局的幻灯片放映期间可用。

**导出为 PDF、HTML、图像或视频时，超链接会被保留下来吗？**

支持的 PDF 和 HTML 导出可能会保留超链接；光栅图像和视频则不能。请参阅[报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)中的导出注意事项。