---
title: 在 Python via Java 中的簡報嵌入字型
linktitle: 已嵌入字型
type: docs
weight: 40
url: /zh-hant/python-java/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得已嵌入字型
- 新增已嵌入字型
- 移除已嵌入字型
- 壓縮已嵌入字型
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理 PowerPoint 中的已嵌入字型。新增、取得、移除與壓縮字型，以保留文字外觀並減少檔案大小。"
---
## **簡介**

嵌入字型會將字型資料儲存在 PowerPoint 簡報內。當檢視程式支援嵌入字型時，即使目標系統未安裝該字型，也能使用這些字型顯示文字。這有助於保留換行、文字間距與投影片佈局。

Aspose.Slides for Python via Java 讓您透過由 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getFontsManager) 回傳的 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 類別，取得、加入以及移除嵌入字型。您也可以透過移除簡報未使用的字元，減少嵌入字型資料的大小。

以下範例適用於 PPTX 檔案。嵌入字型前，請確保該字型資料可供 Aspose.Slides 使用且其授權允許嵌入。

## **取得與移除嵌入字型**

使用 [getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 列出簡報中儲存的字型。若要移除某個字型，將該清單中的字型傳遞給 [removeEmbeddedFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont)，然後儲存簡報。

以下範例列出 `EmbeddedFonts.pptx` 中的嵌入字型，並在存在時移除 Calibri：

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

移除嵌入字型會刪除其儲存的字型資料；不會變更文字所指定的字型。如果目標系統已安裝該字型，文字仍可使用它。否則，呈現時可能會發生字型替代，進而影響版面配置。

## **檢查字型資料與嵌入權限**

在嵌入字型之前，使用 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 類別檢查字型。呼叫 [FontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getFonts) 取得簡報中使用的字型。對於每個字型，傳遞一個 [FontData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontdata/) 物件及所需的 [FontStyleType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontstyletype/) 值給 [FontsManager.getFontBytes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getFontBytes)。此方法會回傳該字型樣式的二進位資料，若請求的字型或樣式不可用則回傳 `None`。不要將 `None` 結果傳遞給 [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel)，因為該方法需要位元組陣列。

[EmbeddingLevel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/embeddinglevel/) 是一個旗標列舉，用於回報字型中儲存的嵌入限制：

- `Installable` 允許嵌入並可在其他系統永久安裝，須遵守字型授權。
- `Restricted` 禁止嵌入，除非取得字型合法所有者的許可（當它是唯一的使用權限旗標時）。
- `PreviewPrint` 允許暫時用於檢視與列印；包含該字型的文件必須為唯讀。
- `Editable` 允許暫時使用，且文件可被編輯與儲存。
- `NoSubsetting` 是額外限制，禁止僅嵌入字形子集。若此旗標存在，必須嵌入所有字元。
- `BitmapOnly` 是額外限制，只允許嵌入位圖字形而非輪廓資料。若字型沒有位圖字形，則無法嵌入。

前四個值描述使用權限，`NoSubsetting` 與 `BitmapOnly` 可與之結合。請使用位元運算檢查這些修飾子。由於 `Installable` 為零，應將使用權限位元遮罩後與 `Installable` 比較，而不是將其視為旗標檢查。現行字型應最多只設定一個使用權限位元。為相容設定了多個權限的舊字型，下列輔助程式會選取最寬鬆的權限：`Editable`、接著 `PreviewPrint`，最後 `Restricted`。

以下範例稽核每個由 `getFonts` 回傳的字型所提供的常規、粗體、斜體及粗斜體資料。它會跳過不可用的樣式、受限制的字型、僅位圖的字型、因輸出仍可編輯而受限於預覽與列印的字型，以及已嵌入的字型。若任何可用樣式帶有 `NoSubsetting`，則為該字型系列嵌入所有字元。

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

此檢查會回報每個字型檔案中編碼的限制。它不會授予授權、證明您合法取得字型，也不能取代在分發嵌入副本前檢查字型授權協議的程序。

## **新增嵌入字型**

使用 [addEmbeddedFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) 來嵌入字型。其多載接受 [FontData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontdata/) 物件或包含字型資料的位元組陣列。[EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/embedfontcharacters/) 列舉控制包含哪些字元：

- [All](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/embedfontcharacters/) 會嵌入字型中的全部字元。當收件者需要編輯簡報並輸入新文字時，請使用此選項。
- [OnlyUsed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/embedfontcharacters/) 僅嵌入簡報中使用的字元，以減少檔案大小。對於主要供檢視的完成簡報，請選擇此選項。

以下範例使用 [getFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getFonts) 取得 `Fonts.pptx` 中使用的字型，並嵌入尚未嵌入的字型。要加入的字型必須在執行程式的機器上可用。既有的嵌入字型會保留其目前的字元集。

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

## **壓縮嵌入字型**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/#compressEmbeddedFonts) 透過移除未使用的字元來減少嵌入字型資料。它作用於已嵌入的字型，因此縮小的幅度取決於簡報中未使用的字型資料量。

以下範例壓縮 `EmbeddedFonts.pptx` 中的字型，並將結果儲存為另一個檔案：

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

若收件者日後可能需要新增文字，請保留原始檔案。壓縮過程中移除的字元將無法再從嵌入字型取得，即使您最初已嵌入全部字元。

## **常見問題**

**我該如何檢查在渲染時嵌入的字型是否仍會被替代？**

在呈現簡報的環境中呼叫 [getSubstitutions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getSubstitutions) 以查看 Aspose.Slides 將替換哪些字型。亦請檢查字型替代設定與字型回退規則。回退處理缺少的字元，因此嵌入字型無法解決該字型本身不包含的字元。

**我是否應該嵌入常見字型，例如 Arial 和 Calibri？**

請根據目標環境來決定。如果所有開啟或呈現簡報的機器皆已有所需字型，嵌入字型可能會增加不必要的檔案大小。若收件者或伺服器可能缺少這些字型，嵌入它們可以協助保留預期的外觀，前提是其授權允許嵌入。