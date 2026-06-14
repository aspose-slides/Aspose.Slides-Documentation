---
title: 在 Python 中管理 PowerPoint 簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/python-net/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python (透過 .NET) 中掌握簡報主題，以建立、客製化並轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義其設計元素的屬性。當您選擇主題時，即是選取一套協調一致的視覺元素及其屬性。

在 PowerPoint 中，主題包含顏色、[字型](/slides/zh-hant/python-net/powerpoint-fonts/)、[背景樣式](/slides/zh-hant/python-net/presentation-background/)以及效果。

![theme-constituents](theme-constituents.png)

## **變更主題顏色**

PowerPoint 主題為投影片上的不同元素使用特定的顏色集合。如果您不喜歡預設值，可以透過套用新的主題顏色來變更它們。為了讓您選取新的主題顏色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/) 列舉中提供了相應的值。

此 Python 程式碼顯示如何變更主題的強調色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

您可以如下方式取得結果顏色的實際值：

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# 範例輸出:
#
# ff8064a2 (顏色 [A=255, R=128, G=100, B=162])
```

為了進一步示範顏色變更，我們建立另一個元素，將其指派為初始步驟的強調色，然後更新主題顏色。

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

新顏色會自動套用到兩個元素。

### **從額外調色盤設定主題顏色**

當您對主題主要顏色 (1) 套用亮度變換時，會產生來自額外調色盤 (2) 的顏色。之後即可設定與取得這些主題顏色。

![additional-palette-colors](additional-palette-colors.png)

**1** — 主題主要顏色  
**2** — 來自額外調色盤的顏色

此 Python 程式碼示範如何從主題主要顏色衍生額外調色盤顏色，並在圖形中使用：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 強調色 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # 強調色 4，較亮 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # 強調色 4，較亮 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # 強調色 4，較亮 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # 強調色 4，較暗 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # 強調色 4，較暗 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **對映 `SchemeColor` 到 `ColorScheme` 顏色**

當您使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/) 時，可能會注意到它包含以下主題顏色值：

`BACKGROUND1`, `BACKGROUND2`, `TEXT1`, and `TEXT2`.

然而，`Presentation.master_theme.color_scheme` 會回傳 [ColorScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/colorscheme/)，其對應的顏色分別為：

`dark1`, `dark2`, `light1`, and `light2`.

這個差異僅在命名上。這些值指向相同的主題顏色槽，且對映關係固定：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

`TEXT`/`BACKGROUND` 與 `dark`/`light` 之間沒有動態轉換，它們只是相同主題顏色的替代名稱。

此命名差異來源於 Microsoft Office 的術語。較舊的 Office 版本使用 `Dark 1`, `Light 1`, `Dark 2`, `Light 2`，而較新的 UI 版本則將相同槽位顯示為 `Text 1`, `Background 1`, `Text 2`, `Background 2`.

## **變更主題字型**

為了讓您能為主題與其他用途選取字型，Aspose.Slides 使用以下特殊識別碼（類似於 PowerPoint）：

- **+mn-lt** — 正文字型拉丁文（次要拉丁字型）
- **+mj-lt** — 標題字型拉丁文（主要拉丁字型）
- **+mn-ea** — 正文字型東亞語系（次要東亞字型）
- **+mj-ea** — 標題字型東亞語系（主要東亞字型）

此 Python 程式碼顯示如何將拉丁字型指派給主題元素：

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

此 Python 範例示範如何變更簡報的主題字型：

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

所有文字方塊皆會更新為新字型。

{{% alert color="primary" title="TIP" %}}
如需更多資訊，請參閱 [Master PowerPoint Fonts with Python](/slides/zh-hant/python-net/powerpoint-fonts/)。
{{% /alert %}}

## **變更主題背景樣式**

預設情況下，PowerPoint 提供 12 種預先定義的背景，但一般簡報僅儲存其中的 3 種。

![todo:image_alt_text](presentation-design_8.png)

例如，您在 PowerPoint 中儲存簡報後，可以執行以下 Python 程式碼，以判斷其中包含多少預先定義的背景：

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/) 類別的 `background_fill_styles` 屬性，您可以在 PowerPoint 主題中新增或存取背景樣式。
{{% /alert %}}

此 Python 範例示範如何設定簡報背景：

```python
presentation.masters[0].background.style_index = 2  # 0 表示無填充；索引從 1 開始。
```

{{% alert color="primary" title="TIP" %}}
如需更多資訊，請參閱 [Manage Presentation Backgrounds in Python](/slides/zh-hant/python-net/presentation-background/)。
{{% /alert %}}

## **變更主題效果**

PowerPoint 主題通常在每個樣式陣列中包含三個值。這些陣列結合為三個效果層級：細緻、適中與強烈。例如，以下是將這些效果套用到特定圖形時的結果：

![todo:image_alt_text](presentation-design_10.png)

使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/) 類別的三個屬性—`FillStyles`、`LineStyles`、`EffectStyles`，您可以比在 PowerPoint 中更彈性地修改主題元素。

此 Python 程式碼顯示如何透過變更這些元素的部份屬性來變更主題效果：

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

產生的變更包括填色、填充類型、陰影效果以及其他屬性的更新：

![todo:image_alt_text](presentation-design_11.png)

## **常見問題**

**我可以在不更改母片的情況下，將主題套用到單一投影片嗎？**

可以。Aspose.Slides 支援投影片層級的主題覆寫，您可以僅將本機主題套用至該投影片，同時保持母片主題不變（透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/slidethememanager/)）。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

使用 [Clone slides](/slides/zh-hant/python-net/clone-slides/) 搭配其母片一起複製到目標簡報。這會保留原始的母片、版面配置以及相關的主題，確保外觀一致。

**如何查看所有繼承與覆寫後的「有效」值？**

使用 API 的「["effective" views](/slides/zh-hant/python-net/shape-effective-properties/)」來取得主題、顏色、字型、效果的最終解析屬性。