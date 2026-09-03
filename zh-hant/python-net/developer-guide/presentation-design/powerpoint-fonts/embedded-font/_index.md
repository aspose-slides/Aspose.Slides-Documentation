---
title: 在 Python 中為簡報嵌入字型
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/python-net/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得嵌入字型
- 新增嵌入字型
- 移除嵌入字型
- 壓縮嵌入字型
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 中管理嵌入字型。使用 Python 新增、取得、移除與壓縮字型，以保留文字外觀並減少檔案大小。"
---
## **Introduction**

嵌入字型會將字型資料儲存在 PowerPoint 簡報內。當檢視程式支援嵌入字型時，即使目標系統未安裝該字型，也能以該字型顯示文字，從而保留換行、文字間距與投影片版面配置。

Aspose.Slides for Python via .NET 讓您透過 [fonts_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/fonts_manager/) 屬性（屬於 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件）取得、加入與移除嵌入字型。您也可以透過移除簡報未使用的字元來減少嵌入字型資料的大小。

以下範例使用 PPTX 檔案。在嵌入字型之前，請確保 Aspose.Slides 能取得該字型的資料，且其授權允許嵌入。

## **Get and Remove Embedded Fonts**

使用 [get_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) 可列出簡報中儲存的字型。若要移除某個字型，將該字型傳遞給 [remove_embedded_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/remove_embedded_font/)，然後儲存簡報。

下例會列出 `EmbeddedFonts.pptx` 中的嵌入字型，並在出現 Calibri 時將其移除：

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

移除嵌入字型僅會刪除其儲存的字型資料；不會改變文字所指派的字型。如果目標系統已安裝該字型，文字仍可使用它。否則，渲染時可能會觸發 [font substitution](/slides/zh-hant/python-net/font-substitution/)，從而影響版面配置。

## **Inspect Font Data and Embedding Permissions**

使用 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/) 類別在嵌入前檢查字型。呼叫 [get_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_fonts/) 可取得簡報使用的字型。對於每個字型，將一個 [FontData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontdata/) 物件以及所需的 [FontStyleType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontstyletype/) 值傳給 [get_font_bytes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_font_bytes/)。該方法會回傳該字型樣式的二進位資料；若請求的字型或樣式不存在，則回傳 `None`。不要將 `None` 結果傳給 [get_font_embedding_level](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_font_embedding_level/)，因為該方法需要位元組陣列。

[EmbeddingLevel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/embeddinglevel/) 為旗標列舉，報告字型中儲存的嵌入限制：

- `INSTALLABLE` 允許嵌入並在其他系統永久安裝，受字型授權條款限制。
- `RESTRICTED` 除非取得字型合法擁有者的許可，否則禁止嵌入（當它是唯一的使用許可旗標時）。
- `PREVIEW_PRINT` 允許暫時用於檢視與列印；包含該字型的文件必須唯讀。
- `EDITABLE` 允許暫時使用，且文件可編輯與儲存。
- `NO_SUBSETTING` 為額外限制，禁止僅嵌入字形子集。若出現此旗標，必須嵌入所有字元。
- `BITMAP_ONLY` 為額外限制，只允許嵌入點陣字形（bitmap strikes），不允許嵌入輪廓資料。若字型沒有點陣字形，則無法嵌入。

前四個值說明使用許可，`NO_SUBSETTING` 與 `BITMAP_ONLY` 可與它們結合。使用位元運算檢查這些修飾子。因為 `INSTALLABLE` 為零，請先遮蔽使用許可位元，然後與 `INSTALLABLE` 比較。當前字型應至多設定一個使用許可位元。為相容設定了多個位元的舊字型，以下輔助程式會選擇限制最少的許可：先選 `EDITABLE`，再 `PREVIEW_PRINT`，最後 `RESTRICTED`。

下例審核 `get_fonts` 回傳的每個字型的正規、粗體、斜體與粗斜體資料。若樣式不存在、字型受限制、僅提供點陣、僅限預覽列印（因輸出仍可編輯）或已嵌入，則跳過。若任何可用樣式帶有 `NO_SUBSETTING`，則為該字型家族嵌入所有字元。

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

此檢查會回報每個字型檔案中編碼的限制。它不會授予授權、證明您已合法取得字型，亦不會取代在分發嵌入副本前檢查字型授權協議的步驟。

## **Add Embedded Fonts**

使用 [add_embedded_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/add_embedded_font/) 來嵌入字型。其多載接受 [FontData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontdata/) 物件或包含字型資料的位元組陣列。[EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/embedfontcharacters/) 列舉控制要包含的字元：

- [ALL](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/embedfontcharacters/) 會嵌入字型中的全部字元。當接收者需要編輯簡報並輸入新文字時使用此選項。
- [ONLY_USED](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/embedfontcharacters/) 只嵌入簡報中實際使用的字元，以減少檔案大小。完成的簡報主要供檢視時請選擇此選項。

下例使用 [get_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_fonts/) 取得 `Fonts.pptx` 中使用的字型，並嵌入尚未嵌入的字型。要加入的字型必須在執行程式的機器上可用。已嵌入的字型會保留其現有字元集。

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

## **Compress Embedded Fonts**

[compress_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) 會透過移除未使用的字元來減少已嵌入字型的資料。它只作用於已嵌入的字型，因此縮減幅度取決於簡報中未使用的字型資料量。

下例壓縮 `EmbeddedFonts.pptx` 中的字型，並將結果另存為新檔案：

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

如果收件人日後可能需要加入文字，請保留原始檔案。壓縮期間移除的字元將不再可從嵌入字型取得，即使您最初已嵌入全部字元。

## **FAQ**

**How can I check whether an embedded font will still be substituted during rendering?**

在渲染簡報的環境中呼叫 [get_substitutions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_substitutions/)，即可查看 Aspose.Slides 會替換哪些字型。同時檢查 [font substitution](/slides/zh-hant/python-net/font-substitution/) 設定與 [font fallback](/slides/zh-hant/python-net/fallback-font/) 規則。Fallback 處理缺失的字元，因此即使已嵌入字型，也不會解決字型本身不包含的字元。

**Should I embed common fonts such as Arial and Calibri?**

依目標環境決定。如果所需字型在每臺開啟或渲染簡報的機器上皆已安裝，則嵌入可能會額外增加檔案大小。若收件人或伺服器可能缺少這些字型，且授權允許，則嵌入可協助保留預期的外觀。