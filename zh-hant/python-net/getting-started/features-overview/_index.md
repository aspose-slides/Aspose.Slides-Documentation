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
- 呈現
- 列印
- 格式化
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET：一個功能強大的 API，能高效建立、編輯、自動化與轉換 PowerPoint 與 OpenDocument 簡報。"
---
## **支援平台**
Aspose.Slides for Python via .NET 可在 Windows x64 或 x86，以及安裝了 Python 3.5 或更高版本的各種 Linux 發行版上使用。目標 Linux 平台還有以下額外需求：
- GCC-6 執行時庫（或更新）
- .NET Core Runtime 的相依性。**不需要**安裝 .NET Core Runtime 本身
- 針對 Python 3.5‑3.7：需要 `pymalloc` 版的 Python。`--with-pymalloc` Python 編譯選項預設已啟用。通常 `pymalloc` 版的 Python 檔名會在結尾加上 `m` 後綴。
- `libpython` 共享 Python 函式庫。`--enable-shared` Python 編譯選項預設為停用，某些 Python 發行版不會包含 `libpython` 共享函式庫。對於某些 Linux 平台，可使用套件管理員安裝 `libpython` 共享函式庫，例如：`sudo apt-get install libpython3.7`。常見問題是 `libpython` 函式庫安裝在與系統標準共享函式庫位置不同的路徑下。可透過在編譯 Python 時使用編譯選項設定替代庫路徑，或在系統標準共享函式庫位置為 `libpython` 檔案建立符號連結來解決。`libpython` 共享函式庫檔名通常為 Python 3.5‑3.7 的 `libpythonX.Ym.so.1.0`，或 Python 3.8 以上的 `libpythonX.Y.so.1.0`（例如：`libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）。

如需支援更多平台，請參考「雙胞胎」產品 Aspose.Slides for .NET 或 Aspose.Slides for Java。

## **檔案格式與轉換**
Aspose.Slides for Python via .NET 支援大多數 PowerPoint 文件格式，亦可將它們匯出為組織廣泛使用且互相交換的常見格式。請參考以下資訊：

|**功能**|**說明**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/zh-hant/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET 為此簡報文件格式提供最快速的處理速度。|
|[PPT to PPTX conversion](/slides/zh-hant/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET 支援將 PPT 轉換為 PPTX。|
|[Portable Document Format (PDF)](/slides/zh-hant/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|您只需呼叫一個方法，即可將所有支援的檔案格式匯出為 Adobe Portable Document Format (PDF) 文件。|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/zh-hant/python-net/convert-powerpoint-to-xps/)|您只需呼叫一個方法，即可將所有支援的檔案格式匯出為 XML Parser Specification (XPS) 文件。|
|[Tagged Image File Format (TIFF)](/slides/zh-hant/python-net/convert-powerpoint-to-tiff/)|您可將所有支援的簡報檔案格式匯出為 Tagged Image File Format (TIFF)。|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/zh-hant/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET 支援將 PresentationEx 轉換為 HTML 格式。|

## **渲染與列印**
Aspose.Slides for Python via .NET 支援將簡報文件中的投影片高保真渲染為各種圖形格式。請參考以下資訊：

|**功能**|**說明**|
| :- | :- |
|.NET 支援的圖像格式|使用 Aspose.Slides for Python via .NET，您可以將簡報投影片和投影片上的圖像渲染為所有 .NET 支援的圖形格式，如 TIFF、PNG、BMP、JPEG、GIF 以及圖層檔。|
|SVG 格式|Aspose.Slides for Python via .NET 亦提供內建方法，允許您將簡報投影片匯出為 Scalable Vector Graphics (SVG) 格式。|
|簡報列印|最新版本的 Aspose.Slides for Python via .NET 提供具備多種選項的內建列印方法。|

## **內容功能**
Aspose.Slides for Python via .NET 讓您幾乎可以存取、修改或建立簡報文件中的所有項目或內容。請參考以下資訊：

|**功能**|**說明**|
| :- | :- |
|母片投影片|母片投影片定義了普通投影片的版面配置。Aspose.Slides for Python via .NET 允許您存取並修改簡報文件的母片投影片。|
|普通投影片|使用 Aspose.Slides for Python via .NET，您可以建立不同類型的全新投影片；亦可存取並修改簡報中已存在的投影片。|
|克隆 / 複製投影片|Aspose.Slides for Python via .NET 提供內建方法，可在同一簡報內克隆或複製現有投影片，亦可將已複製或已克隆的投影片從一個簡報搬移至另一個簡報。由於投影片會從母片繼承其版面配置，內建的克隆方法會自動在克隆時複製母片。|
|管理投影片分節|提供方法將投影片組織於簡報內的不同分節中。|
|占位符與文字占位符|您可以存取投影片中的占位符與文字占位符。此外，您亦可使用適當的方法從頭建立包含文字占位符的投影片。|
|頁首與頁尾|Aspose.Slides for Python via .NET 方便您處理投影片中的頁首與頁尾。|
|投影片註解|使用 Aspose.Slides for Python via .NET，您可以存取並修改與投影片關聯的註解，亦可新增註解。|
|尋找圖形|您還可以透過圖形的替代文字在投影片中尋找特定圖形。|
|背景|Aspose.Slides for Python via .NET 允許您處理與母片或普通投影片相關的背景。|
|文字框|文字框可從頭建立，也可存取現有文字框，且可在不失去原始文字格式的情況下修改其文字內容。|
|矩形圖形|您可使用 Aspose.Slides for Python via .NET 建立或修改矩形圖形。|
|折線圖形|您可使用 Aspose.Slides for Python via .NET 建立或修改折線圖形。|
|橢圓圖形|您可使用 Aspose.Slides for Python via .NET 建立或修改橢圓圖形。|
|群組圖形|Aspose.Slides for Python via .NET 支援群組圖形。|
|自動圖形|Aspose.Slides for Python via .NET 支援自動圖形。|
|SmartArt|Aspose.Slides for Python via .NET 提供對 MS PowerPoint 中 SmartArt 圖形的支援。|
|圖表|Aspose.Slides for Python via .NET 提供對 PowerPoint 中 MSO 圖表的支援。|
|圖形序列化|Aspose.Slides for Python via .NET 支援大量圖形。當 Aspose.Slides for Python via .NET 尚未支援某圖形時，您可使用序列化方法將該圖形從現有投影片序列化，之後依需求再次使用該圖形。|
|圖片框|您可使用 Aspose.Slides for Python via .NET 在圖片框中管理圖片。|
|音訊框|您可在音訊框中連結或嵌入音訊檔案。|
|視訊框|您可在視訊框中處理視訊檔案。Aspose.Slides for Python via .NET 亦支援連結與嵌入式視訊。|
|OLE 框|您可在 OLE 框中管理 OLE 物件。|
|表格|Aspose.Slides for Python via .NET 支援投影片中的表格。|
|ActiveX 控制項|支援 ActiveX 控制項。|
|VBA 巨集|支援在簡報中管理 VBA 巨集。|
|文字框|您可透過與圖形關聯的文字框存取該圖形的文字。|
|文字掃描|您可使用內建掃描方法在簡報或投影片層級掃描文字。|
|動畫|您可對圖形套用動畫。|
|投影片放映|Aspose.Slides for Python via .NET 支援投影片放映與投影片過場效果。|

## **格式化功能**
使用 Aspose.Slides for Python via .NET，您可以格式化簡報投影片中的文字與圖形。請參考以下資訊：

|**功能**|**說明**|
| :- | :- |
|文字格式化|<p>在 Aspose.Slides for Python via .NET 中，您可透過與圖形關聯的文字框管理文字。因而可使用段落與文字框內的子項目對文字進行格式設定。這些文字元素可透過 Aspose.Slides for Python via .NET 進行格式化。</p><p>- 字型類型</p><p>- 字型大小</p><p>- 字型顏色</p><p>- 字型色階</p><p>- 段落對齊</p><p>- 段落項目符號</p><p>- 段落方向</p>|
|圖形格式化|<p>在 Aspose.Slides for Python via .NET 中，投影片的基本元素是圖形。您可使用 Aspose.Slides for Python via .NET 對這些圖形元素進行格式化：</p><p>- 位置</p><p>- 大小</p><p>- 線條</p><p>- 填充（包括圖案、漸層、純色）</p><p>- 文字</p><p>- 圖像</p>|

## **常見問題**

**我需要在伺服器或電腦上安裝 Microsoft PowerPoint 才能使用此函式庫嗎？**

不需要。PowerPoint 並非必要；Aspose.Slides 是一個獨立的引擎，可用於建立、編輯、轉換與渲染簡報。

**多執行緒如何運作？可以平行化處理嗎？**

在不同執行緒中處理不同文件是安全的；同一個 [簡報](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件不能同時被 [多執行緒](/slides/zh-hant/python-net/multithreading/) 使用。

**是否支援檔案密碼與加密？**

是的。您可以 [開啟受保護的簡報](/slides/zh-hant/python-net/password-protected-presentation/)，設定或移除開啟與寫入密碼，並檢查保護狀態。

**在 Linux 容器中需要關注字型套件嗎？**

需要。建議安裝常見的字型套件，或在應用程式中明確 [指定字型目錄](/slides/zh-hant/python-net/custom-font/)，以避免意外的字型替換。

**評估版有什麼限制？**

在 [評估模式](/slides/zh-hant/python-net/licensing/) 下，輸出會加上浮水印，且會有某些限制；您可以取得 [30 天暫時授權](https://purchase.aspose.com/temporary-license/) 以完整測試所有功能。

**是否支援將外部格式匯入簡報（PDF/HTML → PPTX）？**

是的。您可以將 [PDF 頁面和 HTML 內容](/slides/zh-hant/python-net/import-presentation/) 新增至簡報，將它們轉換為投影片。