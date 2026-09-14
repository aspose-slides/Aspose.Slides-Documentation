---
title: 在 Python 透過 Java 使用回退字型呈現簡報
linktitle: 呈現簡報
type: docs
weight: 30
url: /zh-hant/python-java/render-presentation-with-fallback-font/
keywords:
- 回退字型
- 呈現 PowerPoint
- 呈現簡報
- 呈現投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python 透過 Java 使用回退字型呈現簡報 - 透過逐步的 Python 程式碼範例，保持在 PPT、PPTX 與 ODP 之間的文字一致性。"
---
## **概述**

Aspose.Slides 允許您使用回退字型規則來呈現簡報。本篇文章說明如何建立回退字型規則集合、透過移除或新增回退字型來修改規則，並使用 [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 方法指派該集合。

將回退字型規則集合指派給簡報的 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 後，這些規則會在保存、渲染和轉換簡報等操作期間套用。範例示範如何在渲染投影片縮圖並將其保存為 JPEG 影像時使用已設定的規則。

## **使用回退字型規則渲染投影片**

以下範例包含這些步驟：

1. [建立回退字型規則集合](/slides/zh-hant/python-java/create-fallback-fonts-collection/)。
2. 從規則中[移除](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrule/#remove)回退字型，並向另一規則[新增回退字型](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts)。
3. 使用 [setFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 在由 [getFontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getFontsManager) 回傳的字型管理員上指派規則集合。
4. 使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法將簡報保存為相同格式或其他格式。將回退字型規則集合指派給 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 後，這些規則會在簡報的各種操作期間套用：保存、渲染、轉換等。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# 建立新的規則集合。
fallback_rules = FontFallBackRulesCollection()

# 建立多個規則。
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # 嘗試從規則中移除回退字型 "Tahoma"。
    fallback_rule.remove("Tahoma")

    # 為指定範圍更新規則。
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# 移除現有規則，保留至少一個規則以供渲染。
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # 指派已準備好的規則集合。
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # 使用已設定的規則集合呈現縮圖。
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # 以 JPEG 格式將影像儲存到磁碟。
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
閱讀更多關於如何在 Python 透過 Java [將 PPT 與 PPTX 轉換為 JPG（Python 透過 Java）](/slides/zh-hant/python-java/convert-powerpoint-to-jpg/)。
{{% /alert %}}