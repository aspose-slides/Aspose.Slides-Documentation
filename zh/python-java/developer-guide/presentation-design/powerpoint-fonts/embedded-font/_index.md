---
title: 在 Python via Java 中的演示文稿嵌入字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/python-java/embedded-font/
keywords:
- 添加字体
- 嵌入字体
- 字体嵌入
- 获取已嵌入的字体
- 添加已嵌入的字体
- 删除已嵌入的字体
- 压缩已嵌入的字体
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理 PowerPoint 中的嵌入字体。添加、检索、删除和压缩字体，以保持文本外观并减小文件大小。"
---
## **介绍**

嵌入字体会将字体数据存储在 PowerPoint 演示文稿中。当查看器支持嵌入字体时，即使目标系统未安装这些字体，也能使用这些字体显示文本。这有助于保持换行、文本间距和幻灯片布局。

Aspose.Slides for Python via Java 允许您通过由[Presentation.getFontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getFontsManager)返回的[FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/)类检索、添加和删除嵌入字体。您还可以通过删除演示文稿未使用的字符来减小嵌入字体数据的大小。

下面的示例适用于 PPTX 文件。在嵌入字体之前，确保其字体数据对 Aspose.Slides 可用且其许可允许嵌入。

## **获取和删除嵌入字体**

使用[getEmbeddedFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts)列出存储在演示文稿中的字体。要删除某个字体，请将列表中的字体传递给[removeEmbeddedFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont)，然后保存演示文稿。

以下示例列出 `EmbeddedFonts.pptx` 中的嵌入字体，并在存在时删除 Calibri：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

删除嵌入字体会移除其存储的字体数据；它不会更改分配给文本的字体。如果目标系统已安装该字体，文本仍然可以使用它。否则，渲染可能需要进行字体替换，这会影响布局。

## **检查字体数据和嵌入权限**

使用[FontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/)类在嵌入前检查字体。调用[FontsManager.getFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getFonts)检索演示文稿中使用的字体。对于每个字体，将一个[FontData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontdata/)对象和所需的[FontStyleType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontstyletype/)值传递给[FontsManager.getFontBytes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getFontBytes)。该方法返回该字体样式的二进制数据，若请求的字体或样式不可用，则返回 `None`。不要将 `None` 结果传递给[FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel)，因为该方法需要字节数组。

[EmbeddingLevel](https://reference.aspose.com/slides/zh/python-java/aspose.slides/embeddinglevel/) 是一个标志枚举，用于报告字体中存储的嵌入限制：

- `Installable` 允许嵌入并在其他系统上永久安装，受字体许可证约束。
- `Restricted` 禁止嵌入，除非在它是唯一使用权限标志时获得字体合法拥有者的许可。
- `PreviewPrint` 允许临时用于查看和打印；包含该字体的文档必须为只读。
- `Editable` 允许临时使用，并且文档可以被编辑和保存。
- `NoSubsetting` 是一种附加限制，禁止仅嵌入字形子集。出现此标志时必须嵌入所有字符。
- `BitmapOnly` 是一种附加限制，仅允许嵌入位图字形，而不包括轮廓数据。如果字体没有位图字形，则无法嵌入。

前四个值描述使用权限，而 `NoSubsetting` 和 `BitmapOnly` 可以与它们组合。使用位运算检查这些修饰符。由于 `Installable` 为零，需对使用权限位进行掩码并将结果与 `Installable` 比较，而不是将其视为标志检查。当前的字体应最多仅设置一个使用权限位。为兼容设置了多个权限位的旧字体，下面的辅助函数会选择最宽松的权限：`Editable`、随后是 `PreviewPrint`，最后是 `Restricted`。

以下示例审计 `getFonts` 返回的每种字体的常规、粗体、斜体和粗斜体数据。它会跳过不可用的样式、受限制的字体、仅位图字体、仅限预览和打印的字体（因为输出保持可编辑），以及已经嵌入的字体。如果任何可用样式具有 `NoSubsetting`，则为该字体族嵌入所有字符。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此检查报告每个字体文件中编码的限制。它不授予许可证，也不证明您合法获取了字体，更不能替代在分发嵌入副本前检查字体许可证协议的步骤。

## **添加嵌入字体**

使用[addEmbeddedFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#addEmbeddedFont)嵌入字体。其重载接受[FontData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontdata/)对象或包含字体数据的字节数组。[EmbedFontCharacters](https://reference.aspose.com/slides/zh/python-java/aspose.slides/embedfontcharacters/) 枚举控制包含哪些字符：

- [All](https://reference.aspose.com/slides/zh/python-java/aspose.slides/embedfontcharacters/) 嵌入字体中的所有字符。当接收者需要编辑演示文稿并输入新文本时使用此选项。
- [OnlyUsed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/embedfontcharacters/) 仅嵌入演示文稿中使用的字符，以减小文件大小。对于主要用于观看的完成版演示文稿请选择此选项。

以下示例使用[getFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getFonts)检索 `Fonts.pptx` 中使用的字体并嵌入那些尚未嵌入的字体。要添加的字体必须在运行代码的机器上可用。已嵌入的字体会保留其当前字符集。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **压缩嵌入字体**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/#compressEmbeddedFonts) 通过删除未使用的字符来减小嵌入字体数据。它作用于已嵌入的字体，因此大小的缩减取决于演示文稿中未使用的字体数据量。

以下示例压缩 `EmbeddedFonts.pptx` 中的字体，并将结果另存为单独的文件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果接收者以后可能需要添加文本，请保留原始文件。压缩期间移除的字符将不再从嵌入字体中获取，即使您最初已嵌入所有字符。

## **常见问题**

**如何检查嵌入的字体在渲染时是否仍会被替换？**

在渲染演示文稿的环境中调用[getSubstitutions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getSubstitutions)可查看 Aspose.Slides 将替换哪些字体。还要检查字体替换设置和字体回退规则。回退处理缺失字符，因此嵌入字体并不能解决该字体本身不包含的字符。

**我应该嵌入诸如 Arial 和 Calibri 等常用字体吗？**

依据目标环境做出决定。如果所需字体在每台打开或渲染演示文稿的机器上都可用，嵌入它们可能会增加不必要的文件大小。如果接收者或服务器可能缺少这些字体，嵌入它们可以帮助保持预期的外观，前提是其许可证允许。