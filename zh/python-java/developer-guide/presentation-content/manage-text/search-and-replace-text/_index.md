---
title: 在 Python via Java 中搜索和替换 PowerPoint 演示文稿文本
linktitle: 搜索和替换文本
type: docs
weight: 55
url: /zh/python-java/search-and-replace-text/
keywords:
- 搜索文本
- 突出显示文本
- 替换文本
- 正则表达式
- 结果回调
- 文本框
- 审计报告
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中搜索、突出显示和替换文本，并收集每一次匹配。"
---
## **概述**

Aspose.Slides for Python via Java 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。每项操作还可以通过结果回调通知应用程序每一次匹配。这使得在更新演示文稿的同时能够构建包含匹配文本、其上下文、位置、文本框和幻灯片编号的审计日志。

这些功能在审阅、脱敏、术语检查、模板清理和自动化报告工作流中非常有用。

在下面的首个示例中，我们使用名为“sample.pptx”的文件，该文件在第一张幻灯片上包含一个仅有以下文本的文本框：

![示例文本](sample_text.png)

## **选择搜索范围**

在 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 上使用方法将操作限制在单个文本框。 在 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 上使用方法则处理演示文稿中的所有适用文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 高亮字面文本 | [TextFrame.highlightText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#highlightText) | [Presentation.highlightText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#highlightText) |
| 高亮正则表达式匹配 | [TextFrame.highlightRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#highlightRegex) | [Presentation.highlightRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#highlightRegex) |
| 替换字面文本 | [TextFrame.replaceText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#replaceText) | [Presentation.replaceText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#replaceText) |
| 替换正则表达式匹配 | [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#replaceRegex) | [Presentation.replaceRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#replaceRegex) |

## **配置文本匹配**

对于字面文本操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textsearchoptions/) 控制匹配方式：

- [setWholeWordsOnly](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 仅匹配完整单词。
- [setCaseSensitive](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) 控制是否区分大小写。
- [setIncludeNotes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) 在演示文稿级别的搜索、替换和高亮操作中包括幻灯片备注。

正则表达式操作使用 Java `Pattern`，因此大小写敏感性和单词边界等匹配规则由表达式及其标志决定。

## **确定文本框的拥有者**

通用文本处理工作流在搜索、替换、验证或导出文本时经常接收到一个 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)。使用 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParentShape) 和 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParentCell) 可以确定哪个演示对象拥有该文本框。

预期值取决于拥有者：

| 文本框拥有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 或其他包含文本的形状 | 拥有者 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) | `None` |
| 表格单元格 | `None` | 拥有者 [Cell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cell/) |

两种方法均提供只读导航。调用它们不会移动文本框或更改其拥有者。通用代码应检查两者是否为 `None`，并处理两者均不可用的情况。

下面的示例使用 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideutil/#getAllTextFrames) 遍历演示文稿中的所有文本框。对于形状，报告形状名称、Java 运行时类型和所在幻灯片；对于表格单元格，报告零基的列行坐标以及所在幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

presentation = Presentation("presentation.pptx")
try:
    text_frames = SlideUtil.getAllTextFrames(presentation, False)
    for text_frame in text_frames:
        owner_shape = text_frame.getParentShape()
        owner_cell = text_frame.getParentCell()
        if owner_shape is not None:
            shape_name = str(owner_shape.getName()) or "(unnamed)"
            shape_type = owner_shape.getClass().getSimpleName()
            base_slide = owner_shape.getSlide()
        elif owner_cell is not None:
            base_slide = owner_cell.getSlide()
        else:
            print("The text frame owner is not available as a shape or table cell.")
            continue

        if isinstance(base_slide, Slide):
            slide_label = f"slide {base_slide.getSlideNumber()}"
        elif isinstance(base_slide, NotesSlide):
            slide_label = f"notes for slide {base_slide.getParentSlide().getSlideNumber()}"
        else:
            slide_label = str(base_slide.getClass().getSimpleName())

        if owner_shape is not None:
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
        else:
            print(f"Table cell: column {owner_cell.getFirstColumnIndex()}, row {owner_cell.getFirstRowIndex()}; {slide_label}")
finally:
    presentation.dispose()
```

对于 SmartArt 内容，遍历 [SmartArtNode.getShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartnode/#getShapes) 中的形状并访问每个 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartshape/#getTextFrame)。文本框可通过 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParentShape) 追溯到其关联形状，而 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParentCell) 返回 `None`。因此，示例中的形状分支同样处理来自 SmartArt 节点的文本。

## **使用回调收集匹配信息**

通过 `jpype.JProxy` 实现 `IFindResultCallback`，以在每次匹配时收到通知。其 `foundResult` 方法提供相关的文本框、源文本、匹配文本以及匹配位置。

回调不会直接收到幻灯片编号。下面的实现从父幻灯片推断出编号，并且还能处理位于幻灯片备注中的文本。可选的幻灯片编号使同一结果模型能够表示其他幻灯片类型的文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)
```

对于替换操作，`found_text` 包含原始匹配文本，因此回调可以准确记录被替换的词汇。

## **高亮文本**

使用 [TextFrame.highlightText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#highlightText) 方法在文本框中高亮字面文本匹配。传入 [TextSearchOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textsearchoptions/) 以控制搜索，并使用回调收集匹配详情。

下面的代码示例先高亮所有 **“try”** 字符，然后仅高亮完整单词 **“to”**。两次搜索均将匹配报告给同一个回调。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)

    substring_search_options = TextSearchOptions()
    substring_search_options.setCaseSensitive(False)
    substring_highlight_color = Color(173, 216, 230)

    # 突出显示文本框中所有出现的 "try"。
    shape.getTextFrame().highlightText("try", substring_highlight_color, substring_search_options, callback)

    whole_word_search_options = TextSearchOptions()
    whole_word_search_options.setWholeWordsOnly(True)
    whole_word_search_options.setCaseSensitive(False)
    whole_word_highlight_color = Color(238, 130, 238)

    # 只突出显示完整单词 "to"。
    shape.getTextFrame().highlightText("to", whole_word_highlight_color, whole_word_search_options, callback)

    for result in callback_handler.results:
        print(f"Found '{result.found_text}' at position {result.text_position} on slide {result.slide_number}.")

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![高亮后的文本](highlighted_text.png)

## **使用正则表达式高亮文本**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#highlightRegex) 方法高亮文本框中由正则表达式找到的匹配。

下面的代码高亮所有包含七个或更多字符的单词，并收集每一次匹配：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    regex = Pattern.compile("\\b[^\\s]{7,}\\b")

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback)

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![使用正则表达式高亮的文本](highlighted_text_using_regex.png)

## **跨演示文稿高亮文本**

使用 [Presentation.highlightText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#highlightText) 和 [Presentation.highlightRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#highlightRegex) 在演示文稿的所有适用文本框中搜索。下面的示例高亮一个字面术语和所有电子邮件地址，并为两次搜索分别保留结果集合。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    term_callback_handler = TextSearchCallback()
    term_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=term_callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    presentation.highlightText("confidential", Color.ORANGE, search_options, term_callback)

    email_callback_handler = TextSearchCallback()
    email_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=email_callback_handler)
    email_regex = Pattern.compile("\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", Pattern.CASE_INSENSITIVE)

    presentation.highlightRegex(email_regex, Color.YELLOW, email_callback)
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在文本框中替换文本**

使用 [TextFrame.replaceText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#replaceText) 进行字面文本替换，使用 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#replaceRegex) 进行基于模式的替换。这些方法在现有文本框内更新匹配的文本，保留周围部分的格式，而不是从纯字符串重新构建文本框。

下面的示例统一拼写变体后再替换版本标签。相同的回调记录两次操作匹配的原始词汇。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    shape.getTextFrame().replaceText("colour", "color", search_options, callback)

    version_regex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE)
    shape.getTextFrame().replaceRegex(version_regex, "current version", callback)

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果一次匹配跨越不同格式的片段，请检查输出以确认替换文本应使用哪种格式。

## **跨演示文稿替换文本**

使用 [Presentation.replaceText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#replaceText) 和 [Presentation.replaceRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#replaceRegex) 将相同操作应用于整个演示文稿。这对于模板清理、术语更新和脱敏非常有用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **将匹配分组以供报告**

因为每个结果都存储了幻灯片编号和文本框，应用程序可以按审计、报告或审阅工作流对匹配进行分组。下面的示例先按幻灯片再按文本框对收集的结果进行分组：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
    matches_by_slide = {}
    for result in callback_handler.results:
        matches_by_text_frame = matches_by_slide.setdefault(result.slide_number, {})
        text_frame_matches = matches_by_text_frame.setdefault(result.text_frame, [])
        text_frame_matches.append(result)

    for slide_number, matches_by_text_frame in matches_by_slide.items():
        slide_label = "Other" if slide_number is None else str(slide_number)
        print(f"Slide: {slide_label}")
        for text_frame, results in matches_by_text_frame.items():
            print(f"  Text frame: {text_frame.getText()}")
            for result in results:
                print(f"    '{result.found_text}' at position {result.text_position}; context: '{result.source_text}'")
finally:
    presentation.dispose()
```

## **常见问题解答**

**如何只搜索单个文本框而不是整个演示文稿？**

获取形状的文本框，然后在该文本框上调用 [TextFrame.highlightText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#highlightText)、[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#highlightRegex)、[TextFrame.replaceText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#replaceText) 或 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#replaceRegex)。演示文稿级别的方法会处理所有适用的文本框。

**如何匹配完整单词且保持正确的大小写？**

将 [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 和 [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) 设为 `True`，并将这些选项传递给字面文本的高亮或替换方法。对于正则表达式，在 Java `Pattern` 本身中定义单词边界和大小写敏感性。

**搜索和替换能否包括幻灯片备注中的文本？**

可以。对演示文稿级别的字面文本操作使用时，将 [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) 设为 `True`。上面示例中的回调实现会将备注页的匹配映射回其父幻灯片编号。

**如何在不二次扫描演示文稿的情况下生成报告？**

将 `IFindResultCallback` 实现传递给高亮或替换操作。回调在操作运行期间收到每一次匹配，应用程序即可存储源文本、匹配文本、位置、文本框以及推导出的幻灯片编号，以便后续分组或导出。

**替换文本时会保留其格式吗？**

[TextFrame.replaceText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#replaceText) 和 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#replaceRegex) 在现有文本框内修改匹配的文本并保留周围部分的格式。如果一次匹配跨越不同格式的片段，请检查结果确保替换使用所需的样式。