---
title: 使用 Python 在演示文稿中嵌入字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/python-net/embedded-font/
keywords:
- 添加字体
- 嵌入字体
- 字体嵌入
- 获取嵌入字体
- 添加嵌入字体
- 删除嵌入字体
- 压缩嵌入字体
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理 PowerPoint 中的嵌入字体。使用 Python 添加、检索、删除和压缩字体，以保持文本外观并减小文件大小。"
---
## **简介**

嵌入字体会将字体数据存储在 PowerPoint 演示文稿内部。当查看器支持嵌入字体时，即使目标系统未安装这些字体，也可以使用它们来显示文本。这有助于保持换行、文本间距和幻灯片布局。

Aspose.Slides for Python via .NET 通过 [fonts_manager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/fonts_manager/) 属性（属于 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 对象）让您检索、添加和删除嵌入字体。您还可以通过移除演示文稿未使用的字符来减小嵌入字体数据的体积。

以下示例针对 PPTX 文件。嵌入字体前，请确保相应的字体数据可供 Aspose.Slides 使用，并且其许可证允许嵌入。

## **获取并删除嵌入字体**

使用 [get_embedded_fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) 列出演示文稿中存储的字体。要删除某个字体，只需将该列表中的字体传递给 [remove_embedded_font](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/remove_embedded_font/)，然后保存演示文稿。

下面的示例列出 `EmbeddedFonts.pptx` 中的嵌入字体，并在出现 Calibri 时将其删除：

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

删除嵌入字体会移除其存储的字体数据；不会更改文本所使用的字体。如果目标系统已安装该字体，文本仍可以使用它。否则，渲染可能需要进行 [font substitution](/slides/zh/python-net/font-substitution/)，这会影响布局。

## **检查字体数据和嵌入权限**

使用 [FontsManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/) 类在嵌入前检查字体。调用 [get_fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_fonts/) 获取演示文稿使用的字体。对每个字体，传入一个 [FontData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontdata/) 对象和所需的 [FontStyleType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontstyletype/) 值，调用 [get_font_bytes](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_font_bytes/)。该方法返回该字体样式的二进制数据；如果请求的字体或样式不可用，则返回 `None`。不要把 `None` 结果传递给 [get_font_embedding_level](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_font_embedding_level/)，因为该方法需要字节数组。

[EmbeddingLevel](https://reference.aspose.com/slides/zh/python-net/aspose.slides/embeddinglevel/) 是一个标志枚举，报告字体中存储的嵌入限制：

- `INSTALLABLE` 允许嵌入并在其他系统上永久安装，前提是符合字体许可证。
- `RESTRICTED` 禁止嵌入，除非从字体合法拥有者处获得许可（当它是唯一的使用权限标志时）。
- `PREVIEW_PRINT` 允许临时用于查看和打印；包含该字体的文档必须是只读的。
- `EDITABLE` 允许临时使用，并且文档可以编辑并保存。
- `NO_SUBSETTING` 是附加限制，禁止仅嵌入子集字形。出现此标志时必须嵌入所有字符。
- `BITMAP_ONLY` 是附加限制，仅允许嵌入位图字形，而不包括轮廓数据。如果字体没有位图字形，则无法嵌入。

前四个值描述使用权限，`NO_SUBSETTING` 和 `BITMAP_ONLY` 可以与它们组合使用。使用位运算检查这些修饰符。由于 `INSTALLABLE` 为零，需要对使用权限位进行掩码并与 `INSTALLABLE` 比较。当前字体应最多设置一个使用权限位。为兼容可能设置多个权限位的旧字体，下面的辅助代码会选择限制最宽松的权限：`EDITABLE`、`PREVIEW_PRINT`、`RESTRICTED` 的顺序。

下面的示例审计 `get_fonts` 返回的每个字体的常规、粗体、斜体和粗斜体数据。它会跳过不可用的样式、受限字体、仅位图字体、仅用于预览和打印的字体（因为输出仍然可编辑），以及已经嵌入的字体。如果任何可用样式带有 `NO_SUBSETTING`，则会为该字体系列嵌入所有字符。

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

此检查报告每个字体文件中编码的限制。它不提供许可证，也不证明您合法获取了该字体，更不能替代在分发嵌入副本前检查字体许可证协议的步骤。

## **添加嵌入字体**

使用 [add_embedded_font](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/add_embedded_font/) 嵌入字体。其重载接受 `FontData` 对象或包含字体数据的字节数组。[EmbedFontCharacters](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/embedfontcharacters/) 枚举决定包含哪些字符：

- [ALL](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/embedfontcharacters/) 嵌入字体中的所有字符。收件人需要编辑演示文稿并输入新文本时使用此选项。
- [ONLY_USED](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/embedfontcharacters/) 仅嵌入演示文稿中使用的字符，以减小文件大小。对主要用于查看的已完成演示文稿请选择此选项。

下面的示例使用 [get_fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_fonts/) 获取 `Fonts.pptx` 中使用的字体，并嵌入那些尚未嵌入的字体。要添加的字体必须在运行代码的机器上可用。已嵌入的字体会保留其现有字符集。

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **压缩嵌入字体**

[compress_embedded_fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) 通过移除未使用的字符来减小嵌入字体数据的体积。它作用于已经嵌入的字体，因此压缩幅度取决于演示文稿中未使用的字体数据量。

下面的示例压缩 `EmbeddedFonts.pptx` 中的字体，并将结果保存为另一个文件：

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

如果收件人以后可能需要添加文本，请保留原始文件。压缩过程中移除的字符将不再可从嵌入字体中获取，即使最初已经嵌入了全部字符。

## **常见问题**

**如何检查嵌入的字体在渲染时是否仍会被替换？**

在实际渲染演示文稿的环境中调用 [get_substitutions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_substitutions/)，查看 Aspose.Slides 将替换哪些字体。同时检查 [font substitution](/slides/zh/python-net/font-substitution/) 设置和 [font fallback](/slides/zh/python-net/fallback-font/) 规则。回退机制处理缺失字符，因此即使已嵌入字体，也不能解决字体本身不包含的字符。

**是否应该嵌入常用字体，例如 Arial 和 Calibri？**

应根据目标环境决定。如果所需字体在打开或渲染演示文稿的每台机器上都已可用，嵌入它们可能会导致不必要的文件增大。如果收件人或服务器可能缺少这些字体，且许可证允许嵌入，则嵌入可以帮助保持预期的外观。