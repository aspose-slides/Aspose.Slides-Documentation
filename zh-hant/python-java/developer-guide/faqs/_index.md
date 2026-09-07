---
title: 常見問題
type: docs
weight: 340
url: /zh-hant/python-java/faqs/
keywords:
- 常見問題
- 簡報格式
- 記憶體不足錯誤
- 投影片尺寸
- 擷取文字
- 段落大小
- 表格邊框
- 字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "找出有關 Aspose.Slides for Python via Java 的常見問題的答案，內容包括檔案格式、記憶體使用、投影片尺寸、文字、表格、影像與字型。"
---
## **概覽**

本常見問題說明支援的檔案格式、大型簡報的記憶體使用情況、投影片尺寸與預覽、文字擷取、表格邊框、圖片放置，以及在將簡報轉換為 PDF 或影像時字型差異等主題。

## **常見問題**

### **支援的檔案格式**

**Aspose.Slides for Python via Java 支援哪些檔案格式？**

請參閱[支援的檔案格式](/slides/zh-hant/python-java/supported-file-formats/)以了解支援的簡報、文件與影像格式以及其匯入與匯出功能。

### **例外情況**

**為何在載入含有影像的大型簡報時會出現記憶體不足錯誤？是否有檔案大小限制？**

沒有單一的檔案大小門檻可以預測簡報是否能裝入記憶體。記憶體需求取決於簡報結構、解壓縮後的影像、特效，以及您執行的操作。影像佔用的記憶體往往遠大於磁碟上的壓縮大小。

Aspose.Slides for Python via Java 透過 JPype 使用 Java 引擎，因此 JVM 堆必須有足夠的空間來處理。僅憑系統可用 RAM 無法判斷 JVM 可使用的記憶體量。完成使用後，請使用[Presentation.dispose](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#dispose)釋放簡報。環境設定請參閱[系統需求](/slides/zh-hant/python-java/system-requirements/)與[安裝](/slides/zh-hant/python-java/installation/)。

### **操作投影片**

**我可以變更簡報中投影片的尺寸嗎？**

可以。使用[Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getslidesize)取得簡報的投影片尺寸設定，然後使用[SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/#setsize)設定尺寸，並選擇現有內容的縮放方式。

**同一簡報中的投影片可以有不同的尺寸嗎？**

不能。Microsoft PowerPoint 文件在簡報層級定義投影片尺寸，所有投影片共用相同的尺寸。

**我可以在儲存簡報之前預覽投影片嗎？**

可以。將投影片渲染為影像並在您的應用程式中顯示該影像，無需先儲存簡報。

### **操作文字**

**我可以取得簡報中的所有文字嗎？**

可以。使用[SlideUtil](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/)類別提供的方法，可從簡報或單一投影片中擷取文字。

**為何段落大小在 Windows 與 Linux 上不同？**

段落尺寸取決於字型的度量資訊。若缺少字型，系統會使用替代字型，可能導致字元寬度與行高不同，進而改變換行與段落尺寸。請在兩個系統上安裝相同的字型，或在建立或載入簡報之前使用[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#loadexternalfonts)載入相同的字型檔案。

### **格式設定與影像**

**如何設定表格邊框的顏色？**

使用[Cell.getCellFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/#getcellformat)取得各儲存格的邊框格式，並為相關邊框設定填色。若要變更所有邊框，請處理所有儲存格；若只需變更表格的外框，則僅更新位於表格邊緣儲存格的外向邊框。

**定位與調整影像大小使用什麼單位？**

形狀的座標與尺寸以點 (points) 為單位。1 英吋等於 72 點；此數值並非像素座標。

### **操作字型**

**為何在將簡報轉換為 PDF 或影像時字型會變更？**

執行轉換的機器可能缺少所需的字型。請安裝原始字型，或使用[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#loadexternalfonts)加入包含字型的資料夾。請在建立或開啟簡報之前先載入外部字型。

以下範例註冊一個字型資料夾。請將路徑替換為實際存在且包含字型檔案的資料夾。此範例假設已依照[安裝](/slides/zh-hant/python-java/installation/)中的說明設定環境。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

此範例會讓 JVM 保持啟動狀態，以供後續簡報操作使用。關於筆記型電腦使用方式與 JVM 生命週期限制，請參閱[限制與 API 差異](/slides/zh-hant/python-java/limitations-and-api-differences/)。