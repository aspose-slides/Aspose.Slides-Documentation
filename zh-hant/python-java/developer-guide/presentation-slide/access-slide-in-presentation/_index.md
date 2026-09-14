---
title: 在 Python 中存取簡報投影片
linktitle: 存取投影片
type: docs
weight: 20
url: /zh-hant/python-java/access-slide-in-presentation/
keywords:
- 存取投影片
- 投影片索引
- 投影片 ID
- 投影片位置
- 變更位置
- 投影片屬性
- 投影片編號
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 簡報中存取與管理投影片。透過程式碼範例提升生產力。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 存取與管理簡報中的投影片。它展示如何從投影片集合中以零基索引取得投影片，以及如何使用[getSlideById](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlideById) 方法依唯一 ID 存取投影片。

您還將學習如何使用[setSlideNumber](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#setSlideNumber) 方法變更投影片位置，以及如何使用[setFirstSlideNumber](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#setFirstSlideNumber) 方法為簡報設定起始投影片編號。範例示範載入簡報、取得投影片參考、更新投影片順序或編號，並儲存已修改的簡報。

## **依索引存取投影片**

簡報中的所有投影片會依投影片位置以數字方式排列，起始索引為 0。第一張投影片可通過索引 0 存取；第二張投影片可通過索引 1 存取；依此類推。

代表簡報檔案的[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別，會將所有投影片以[SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/)（包含[Slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 物件的集合）公開。以下 Python 程式碼示範如何依索引存取投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# 建立一個代表簡報檔案的 Presentation 物件。
presentation = Presentation("demo.pptx")
try:
    # 使用索引存取投影片。
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **依 ID 存取投影片**

簡報中的每張投影片都有唯一的 ID。您可以使用[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別所提供的[getSlideById](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlideById) 方法針對該 ID 進行操作。以下 Python 程式碼示範如何提供有效的投影片 ID，並透過[getSlideById](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlideById) 方法存取該投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# 建立一個代表簡報檔案的 Presentation 物件。
presentation = Presentation("demo.pptx")
try:
    # 取得投影片 ID。
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # 透過 ID 存取投影片。
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **變更投影片位置**

Aspose.Slides 允許您變更投影片的位置。例如，您可以指定將第一張投影片改為第二張投影片。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
1. 透過索引取得欲變更位置的投影片參考。  
1. 使用[setSlideNumber](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#setSlideNumber) 方法為該投影片設定新位置。  
1. 儲存已修改的簡報。

以下 Python 程式碼示範將位置 1 的投影片移動至位置 2 的操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 建立一個代表簡報檔案的 Presentation 物件。
presentation = Presentation("Presentation.pptx")
try:
    # 取得會被變更位置的投影片。
    slide = presentation.getSlides().get_Item(0)

    # 為投影片設定新的位置。
    slide.setSlideNumber(2)

    # 儲存已修改的簡報。
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

第一張投影片變成第二張；第二張投影片變成第一張。當您變更投影片位置時，其他投影片會自動調整。

## **設定投影片編號**

使用[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別所提供的[setFirstSlideNumber](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#setFirstSlideNumber) 方法，您可以為簡報的第一張投影片指定新編號。此操作會導致其他投影片編號重新計算。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
1. 取得投影片編號。  
1. 設定投影片編號。  
1. 儲存已修改的簡報。

以下 Python 程式碼示範將第一張投影片的編號設定為 10 的操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 建立一個代表簡報檔案的 Presentation 物件。
presentation = Presentation("HelloWorld.pptx")
try:
    # 取得投影片編號。
    first_slide_number = presentation.getFirstSlideNumber()

    # 設定投影片編號。
    presentation.setFirstSlideNumber(10)

    # 儲存已修改的簡報。
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果您想略過第一張投影片，也可以從第二張投影片開始編號（並隱藏第一張投影片的編號），做法如下：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # 設定第一張簡報投影片的編號。
    presentation.setFirstSlideNumber(0)

    # 為所有投影片顯示投影片編號。
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(True)

    # 隱藏第一張投影片的編號。
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(False)

    # 儲存已修改的簡報。
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**使用者看到的投影片編號是否與集合的零基索引相同？**

投影片上顯示的編號可以從任意值（例如 10）開始，並不必與索引相同；兩者的關係由簡報的[first slide number](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#setFirstSlideNumber) 設定控制。

**隱藏的投影片會影響索引嗎？**

會。隱藏的投影片仍保留在集合中，且會計入索引；「隱藏」指的是顯示狀態，而非其在集合中的位置。

**當加入或移除其他投影片時，投影片的索引會改變嗎？**

會。索引始終反映投影片的當前順序，並在插入、刪除或移動操作後重新計算。