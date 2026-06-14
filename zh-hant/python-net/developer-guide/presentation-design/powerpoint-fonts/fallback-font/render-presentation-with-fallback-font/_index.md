---
title: 使用備援字型在 Python 中呈現簡報
linktitle: 呈現簡報
type: docs
weight: 30
url: /zh-hant/python-net/render-presentation-with-fallback-font/
keywords:
- 備援字型
- 呈現 PowerPoint
- 呈現簡報
- 呈現投影片
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中使用備援字型呈現簡報 – 透過一步步程式碼範例確保 PPT、PPTX 與 ODP 之間的文字保持一致。"
---
## **概覽**

Aspose.Slides 允許您使用備援字型規則來呈現簡報。本文說明如何建立備援字型規則集合、透過移除或新增備援字型來修改其規則，並將該集合指定給 `FontsManager.font_fall_back_rules_collection` 屬性。

將備援字型規則集合指派給簡報的 `fonts_manager` 後，這些規則會在儲存、呈現和轉換簡報等操作中套用。範例示範了在呈現投影片縮圖並將其儲存為 PNG 圖像時，如何使用已設定的規則。

## **使用備援字型規則呈現投影片**

以下範例包含這些步驟：

1. 我們[建立備援字型規則集合](/slides/zh-hant/python-net/create-fallback-fonts-collection/)。
1. [移除](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontfallbackrule/remove/)備援字型規則，並[add_fall_back_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/)新增至另一條規則。
1. 將規則集合設定為[FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/)屬性。
1. 使用[Presentation.save()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)方法，我們可以將簡報儲存為相同格式，或儲存為其他格式。將備援字型規則集合設定給 FontsManager 後，這些規則會在所有簡報操作（儲存、呈現、轉換等）中套用。

```py
import aspose.slides as slides

# 建立規則集合的新實例
rulesList = slides.FontFallBackRulesCollection()

# 建立多個規則
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# 嘗試從已載入的規則中移除備援字型「Tahoma」
	fallBackRule.remove("Tahoma")

	# 並為指定範圍更新規則
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

	# 同時我們可以從清單中移除任何既有規則
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# 指派已準備好的規則清單以供使用
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# 使用已初始化的規則集合渲染縮圖並儲存為 PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
了解更多關於如何在 Python 中[將 PowerPoint 投影片轉換為 PNG](/slides/zh-hant/python-net/convert-powerpoint-to-png/)。
{{% /alert %}}