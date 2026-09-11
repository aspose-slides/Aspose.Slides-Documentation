---
title: 使用 Python 管理簡報中的 SmartArt 圖形
linktitle: SmartArt 圖形
type: docs
weight: 20
url: /zh-hant/python-java/manage-smartart-shape/
keywords:
- SmartArt 物件
- SmartArt 圖形
- SmartArt 樣式
- SmartArt 色彩
- 建立 SmartArt
- 新增 SmartArt
- 編輯 SmartArt
- 變更 SmartArt
- 存取 SmartArt
- SmartArt 版面配置類型
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中自動化 PowerPoint SmartArt 的建立、編輯與樣式設定，提供簡潔的程式碼範例與以效能為導向的指南。"
---
## **概觀**

Aspose.Slides 讓您可以以程式方式建立與管理 PowerPoint 簡報中的 SmartArt 圖形。本文章說明如何將 SmartArt 形狀新增至投影片、存取現有 SmartArt 形狀、依特定版面配置類型尋找 SmartArt，以及透過變更 SmartArt 樣式或色彩樣式來更新其視覺外觀。

範例示範如何透過簡報投影片的形狀集合操作 SmartArt 形狀、檢查形狀是否為 SmartArt，並進一步修改或檢視其屬性。

## **建立 SmartArt 形狀**
Aspose.Slides for Python via Java 提供用於建立 SmartArt 形狀的 API。若要在投影片中建立 SmartArt 形狀，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片。
3. 透過指定 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartlayouttype/)，[新增 SmartArt 形狀](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addSmartArt)。
4. 將修改後的簡報儲存為 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增 SmartArt 形狀。
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # 儲存簡報。
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖說：已新增至投影片的 SmartArt 形狀**|

## **在投影片上存取 SmartArt 形狀**
以下範例存取簡報投影片上的 SmartArt 形狀。它會遍歷投影片上的每個形狀，並檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 實例。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # 遍歷第一張投影片上的每個形狀。
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **以特定版面配置類型存取 SmartArt 形狀**
以下範例存取具有特定版面配置類型的 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 形狀，該類型由 [SmartArt.getLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/#getLayout) 取得。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入包含 SmartArt 形狀的簡報。
2. 依索引取得第一張投影片。
3. 遍歷第一張投影片上的每個形狀。
4. 檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 實例。
5. 檢查 SmartArt 形狀是否具備指定的版面配置類型，並執行所需的操作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # 遍歷第一張投影片上的每個形狀。
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # 檢查 SmartArt 版面配置。
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **變更 SmartArt 形狀樣式**
此範例示範如何變更 SmartArt 形狀的快速樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入包含 SmartArt 形狀的簡報。
2. 依索引取得第一張投影片。
3. 遍歷第一張投影片上的每個形狀。
4. 檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 實例。
5. 尋找具備指定樣式的 SmartArt 形狀。
6. 為 SmartArt 形狀設定新的樣式。
7. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 遍歷第一張投影片上的每個形狀。
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # 檢查並變更 SmartArt 樣式。
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖說：已變更樣式的 SmartArt 形狀**|

## **變更 SmartArt 形狀色彩樣式**
此範例存取具有特定色彩樣式的 SmartArt 形狀，並變更該樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入包含 SmartArt 形狀的簡報。
2. 依索引取得第一張投影片。
3. 遍歷第一張投影片上的每個形狀。
4. 檢查該形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 實例。
5. 尋找具備指定色彩樣式的 SmartArt 形狀。
6. 為 SmartArt 形狀設定新的色彩樣式。
7. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 遍歷第一張投影片上的每個形狀。
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # 檢查並變更 SmartArt 樣式。
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**圖說：已變更色彩樣式的 SmartArt 形狀**|

## **常見問題**

**我可以將 SmartArt 作為單一物件進行動畫化嗎？**

是的。SmartArt 是一個形狀，因此您可以透過動畫 API 為其套用[標準動畫](/slides/zh-hant/python-java/powerpoint-animation/)（進入、退出、強調、移動路徑），就像其他形狀一樣。

**如果不知道 SmartArt 的內部 ID，如何在投影片上找到特定的 SmartArt？**

設定並使用[替代文字](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setAlternativeText)，再以該值搜尋形狀——這是定位目標形狀的推薦方法。

**我可以將 SmartArt 與其他形狀群組嗎？**

是的。您可以將 SmartArt 與其他形狀（圖片、表格等）群組，然後[操作群組](/slides/zh-hant/python-java/group/)。

**如何取得特定 SmartArt 的影像（例如，用於預覽或報告）？**

匯出形狀的縮圖/影像；該函式庫可以[渲染個別形狀](/slides/zh-hant/python-java/create-shape-thumbnails/)為光柵檔案（PNG/JPG/TIFF）。

**將整個簡報轉換為 PDF 時，SmartArt 的外觀會保留嗎？**

是的。渲染引擎針對[PDF 匯出](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)提供高保真度，並具備多種品質與相容性選項。