---
title: 在 Python via Java 中將簡報匯出為 XAML
linktitle: 簡報轉換為 XAML
type: docs
weight: 30
url: /zh-hant/python-java/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報 轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- 將 PPT 儲存為 XAML
- 將 PPTX 儲存為 XAML
- 將 ODP 儲存為 XAML
- 匯出 PPT 為 XAML
- 匯出 PPTX 為 XAML
- 匯出 ODP 為 XAML
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 將 PowerPoint 與 OpenDocument 簡報匯出為 XAML。使用預設選項或包含隱藏投影片。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Python via Java 將 PowerPoint 與 OpenDocument 簡報匯出為 XAML。它會介紹 XAML、展示如何使用預設設定匯出，並說明如何使用 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/) 包含隱藏投影片。

這些範例需要 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。請將 `pres.pptx` 放在目前的工作目錄中。每個範例僅在 JVM 尚未啟動時才會啟動它。

## **關於 XAML**

XAML（Extensible Application Markup Language）是一種基於 XML 的語言，用於描述使用者介面。它被 Windows Presentation Foundation（WPF）等框架所使用。您可以使用視覺化設計工具或文字編輯器來建立和編輯 XAML。

## **使用預設選項將簡報匯出為 XAML**

從輸入檔案建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)，然後將 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/) 傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 以使用預設設定匯出：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **使用自訂選項將簡報匯出為 XAML**

使用 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/) 來設定匯出。若要包含隱藏投影片，請在儲存之前以 `True` 呼叫 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **常見問題**

**當原始字型不可用時，我該如何選擇備援字型？**

在您的 [XamlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/) 物件上使用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) 來指定備援字型。請確保所選字型在匯出環境中可用。

**我可以在任何 XAML 框架中使用匯出的標記嗎？**

不同的 XAML 框架支援的元素與功能各有差異。請在將匯出標記整合到應用程式之前，於目標框架中測試其相容性。

**預設會匯出隱藏投影片嗎？**

不會。若要包含隱藏投影片，請以 `True` 呼叫 [setExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)。若要排除，則保持設定為 `False`。