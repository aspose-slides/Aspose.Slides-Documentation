---
title: 功能概覽
type: docs
weight: 20
url: /zh-hant/python-net/features-overview/
keywords:
- 功能
- 支援平台
- 檔案格式
- 轉換
- 渲染
- 格式化
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET：一個功能強大的 API，可有效地建立、編輯、自動化與轉換 PowerPoint 與 OpenDocument 簡報。"
---
## **支援平台**
Aspose.Slides for Python via .NET 可在 Windows x64 或 x86，以及安裝 Python 3.5 或更新版本的各式 Linux 發行版上使用。目標 Linux 平台還有以下額外需求：
- GCC-6 執行時庫（或更新版本）
- .NET Core Runtime 的相依項。不需要安裝 .NET Core Runtime 本身
- Python 3.5-3.7：需要 `pymalloc` 版的 Python。預設已啟用 `--with-pymalloc` 建置選項。通常 `pymalloc` 版的 Python 會在檔名末尾加上 `m` 後綴。
- `libpython` 共享 Python 函式庫。`--enable-shared` 建置選項預設為停用，部分 Python 發行版不包含 `libpython` 共享函式庫。某些 Linux 平台可透過套件管理員安裝，例如：`sudo apt-get install libpython3.7`。常見問題是 `libpython` 函式庫安裝於非系統共享函式庫的預設位置。可透過 Python 建置選項在編譯時設定替代路徑，或在系統標準的共享函式庫目錄下建立指向 `libpython` 檔案的符號連結來解決。一般而言，Python 3.5-3.7 的 `libpython` 共享函式庫檔名為 `libpythonX.Ym.so.1.0`，而 Python 3.8 之後則為 `libpythonX.Y.so.1.0`（例如：`libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）。

若需要支援更多平台，請參考「雙生兄弟」產品 Aspose.Slides for .NET 或 Aspose.Slides for Java。

## **檔案格式與轉換**
Aspose.Slides for Python via .NET 支援大多數 PowerPoint 文件格式，並可將其匯出為組織常用且廣泛交換的熱門格式。以下是相關細節：

|**功能**|**說明**|
| :- | :- |
|[Microsoft PowerPoint（PPT)](/slides/zh-hant/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET 提供此簡報文件格式最快的處理速度。|
|[PPT 轉換為 PPTX](/slides/zh-hant/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET 支援 PPT 轉換為 PPTX。|
|[可攜式文件格式（PDF)](/slides/zh-hant/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|您可以使用單一方法將所有支援的檔案格式匯出為 Adobe Portable Document Format（PDF）文件。|
|[XML 解析規範（XPS)](https://docs.aspose.com/slides/zh-hant/python-net/convert-powerpoint-to-xps/)|您可以使用單一方法將所有支援的檔案格式匯出為 XML Parser Specification（XPS）文件。|
|[標記圖像檔案格式（TIFF)](/slides/zh-hant/python-net/convert-powerpoint-to-tiff/)|您可以將所有支援的簡報檔案格式匯出為 Tagged Image File Format（TIFF）。|
|[PPTX 轉換為 HTML]((https://docs.aspose.com/slides/zh-hant/python-net/convert-powerpoint-to-html/))|Aspose.Slides for Python via .NET 支援將 PresentationEx 轉換為 HTML 格式。|

## **簡報渲染**
Aspose.Slides for Python via .NET 支援將簡報文件中的投影片以高保真度渲染為各種圖形格式。以下是相關細節：

|**功能**|**說明**|
| :- | :- |
|.NET 支援的圖像格式|使用 Aspose.Slides for Python via .NET，您可以將簡報投影片及投影片上的圖像渲染為所有 .NET 支援的圖形格式，例如 TIFF、PNG、BMP、JPEG、GIF 以及圖形圖案檔。|
|SVG 格式|Aspose.Slides for Python via .NET 亦提供內建方法，讓您將簡報投影片匯出為可縮放向量圖形（SVG）格式。|

## **內容功能**
Aspose.Slides for Python via .NET 允許您存取、修改或建立簡報文件中幾乎所有項目或內容。以下是相關細節：

|**功能**|**說明**|
| :- | :- |
|母片投影片|母片投影片定義一般投影片的版面配置。Aspose.Slides for Python via .NET 允許您存取並修改簡報文件的母片投影片。|
|普通投影片|使用 Aspose.Slides for Python via .NET，您可以建立不同類型的新投影片；亦可存取並修改簡報中現有的投影片。|
|複製/拷貝投影片|Aspose.Slides for Python via .NET 提供內建方法，可在同一簡報中複製或拷貝現有投影片，並可將複製或拷貝的投影片從一個簡報移至另一個簡報。由於投影片會從母片繼承版面配置，內建的複製方法會自動在複製時一起複製母片。|
|管理投影片區段|提供方法將投影片依不同區段組織於同一簡報內。|
|佔位符與文字佔位符|您可以存取投影片中的佔位符與文字佔位符；亦可使用適當的方法從頭建立包含文字佔位符的投影片。|
|頁首與頁尾|Aspose.Slides for Python via .NET 方便處理投影片的頁首/頁尾。|
|投影片備註|使用 Aspose.Slides for Python via .NET，您可以存取並修改投影片的備註，亦可新增備註。|
|尋找形狀|您也可以使用形狀的替代文字在投影片中尋找特定形狀。|
|背景|Aspose.Slides for Python via .NET 允許您處理母片或一般投影片的背景。|
|文字方塊|文字方塊可從頭建立，也可存取現有的文字方塊，且可在不失去原始文字格式的情況下修改其文字內容。|
|矩形形狀|您可使用 Aspose.Slides for Python via .NET 建立或修改矩形形狀。|
|多段線形狀|您可使用 Aspose.Slides for Python via .NET 建立或修改多段線形狀。|
|橢圓形狀|您可使用 Aspose.Slides for Python via .NET 建立或修改橢圓形狀。|
|群組形狀|Aspose.Slides for Python via .NET 支援群組形狀。|
|自動形狀|Aspose.Slides for Python via .NET 支援自動形狀。|
|SmartArt|Aspose.Slides for Python via .NET 提供對 MS PowerPoint 中 SmartArt 形狀的支援。|
|圖表|Aspose.Slides for Python via .NET 提供對 PowerPoint 中 MSO 圖表的支援。|
|形狀序列化|Aspose.Slides for Python via .NET 支援大量形狀。當缺少某種形狀的直接支援時，您可以使用序列化方法將該形狀從現有投影片序列化，之後依需求再次使用該形狀。|
|圖片框|您可以使用 Aspose.Slides for Python via .NET 管理圖片框中的圖片。|
|音訊框|您可以在投影片的音訊框中連結或嵌入音訊檔案。|
|視訊框|您可在視訊框中處理視訊檔案，Aspose.Slides for Python via .NET 亦支援連結與嵌入的視訊。|
|OLE 框|您可使用 Aspose.Slides for Python via .NET 在 OLE 框中管理 OLE 物件。|
|表格|Aspose.Slides for Python via .NET 支援投影片中的表格。|
|ActiveX 控制項|支援 ActiveX 控制項。|
|VBA 巨集|支援在簡報內管理 VBA 巨集。|
|文字框|您可以透過與形狀關聯的文字框存取該形狀的文字。|
|文字掃描|您可使用內建掃描方法在簡報或投影片層級掃描文字。|
|動畫|您可對形狀套用動畫。|
|投影片放映|Aspose.Slides for Python via .NET 支援投影片放映與投影片轉場。|

## **格式化功能**
使用 Aspose.Slides for Python via .NET，您可以在簡報投影片上格式化文字與形狀。以下是相關細節：

|**功能**|**說明**|
| :- | :- |
|文字格式化|<p>在 Aspose.Slides for Python via .NET 中，您可透過形狀關聯的文字框管理文字，進而使用段落與文字區段對文字進行格式化。這些文字元素可透過 Aspose.Slides for Python via .NET 進行以下格式設定：</p><p>- 字型類型</p><p>- 字型大小</p><p>- 字型顏色</p><p>- 字型色階</p><p>- 段落對齊</p><p>- 段落項目符號</p><p>- 段落方向</p>|
|形狀格式化|<p>在 Aspose.Slides for Python via .NET 中，投影片的基本元素為形狀。您可使用 Aspose.Slides for Python via .NET 對這些形狀元素進行以下格式設定：</p><p>- 位置</p><p>- 大小</p><p>- 線條</p><p>- 填充（包括圖案、漸層、實色）</p><p>- 文字</p><p>- 圖像</p>|

## **常見問題**

### 我是否需要在伺服器/電腦上安裝 Microsoft PowerPoint 才能讓程式庫正常運作？

不需要。PowerPoint 並非必要條件；Aspose.Slides 是一個獨立的引擎，用於建立、編輯、轉換與渲染簡報。

### 多執行緒如何運作？處理程序可以平行化嗎？

可以安全地在不同執行緒中處理不同文件；同一個 [簡報](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件不能同時被 [多執行緒](/slides/zh-hant/python-net/multithreading/) 使用。

### 是否支援檔案密碼與加密？

支援。[您可以](/slides/zh-hant/python-net/password-protected-presentation/) 開啟受加密的簡報、設定或移除開啟與寫入的密碼，並檢查保護狀態。

### 在 Linux 容器中是否需要關注字體套件？

需要。建議安裝常見字體套件，或在應用程式中明確 [指定字體目錄](/slides/zh-hant/python-net/custom-font/)，以避免意外的字體替換。

### 評估版本是否有限制？

在 [評估模式](/slides/zh-hant/python-net/licensing/) 下，輸出會加入浮水印且會有特定限制；可使用 [30 天臨時授權](https://purchase.aspose.com/temporary-license/) 進行完整功能測試。

### 是否支援將外部格式匯入簡報（PDF/HTML → PPTX）？

支援。您可以將 [PDF 頁面與 HTML 內容](/slides/zh-hant/python-net/import-presentation/) 新增至簡報，並將其轉換為投影片。