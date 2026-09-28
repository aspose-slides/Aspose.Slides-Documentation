---
title: 功能概述
type: docs
weight: 94
url: /zh-hant/net/features-overview/
keywords:
- 功能
- 支援平台
- 檔案格式
- 轉換
- 呈現
- 簡報內容
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在評估 Aspose.Slides for .NET 之前，先檢視其涵蓋的內容：支援平台、檔案格式、投影片呈現，以及您可以建立和編輯的內容。"
---
## **概述**

Aspose.Slides for .NET 是一個用於建立、讀取、編輯、轉換和呈現 PowerPoint 與 OpenDocument 簡報的類別庫。它沒有自己的使用者介面，也不需要 Microsoft PowerPoint 或 Office，因此您可以在主控台應用程式、桌面應用程式（如 Windows Forms）、Web 應用程式和 Web 服務中使用它。本文概述了此函式庫的功能範圍，並連結到描述各個領域的文章。

## **支援平台**

Aspose.Slides for .NET 以具有相同 API 的兩個 NuGet 套件發行：

|**套件**|**套件內的建置**|**作業系統**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2、.NET Standard 2.0 以及 .NET 6。可搭配 .NET Framework 4.6.2 或更新版本，或 .NET 6 或更新版本使用。|Windows。Linux 與 macOS 需要 `libgdiplus` 函式庫以及 `System.Drawing.EnableUnixSupport` 開關。|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6。可搭配 .NET 6 或更新版本使用。|Windows（x86、x64）、Linux（x64，glibc 2.23 以上，ARM64，glibc 2.39 以上）以及 macOS（x64、ARM64）。|

[Installation](/slides/zh-hant/net/installation/) 說明如何選擇套件以及每個套件在 Linux 上的需求。[System Requirements](/slides/zh-hant/net/system-requirements/) 詳細列出支援的平台。

## **檔案格式與轉換**

Aspose.Slides 可以開啟與儲存 PPT、PPTX、PPS、POT、PPSX、POTX、PPTM、PPSM、POTM、ODP、OTP、FODP 以及 PowerPoint XML 簡報。它可將 PDF 與 HTML 內容匯入至投影片，並可將簡報儲存為 PDF、XPS、HTML、HTML5、TIFF、動畫 GIF、SWF、Markdown 與 XAML。[Supported File Formats](/slides/zh-hant/net/supported-file-formats/) 列出每種格式及其對應的讀寫 API。

|**功能**|**描述**|
| :- | :- |
|[PPT 和 PPTX](/slides/zh-hant/net/ppt-vs-pptx/)|讀寫二進位 PowerPoint 97-2003 格式與 Office Open XML 格式。|
|[PPT 轉換為 PPTX](/slides/zh-hant/net/convert-ppt-to-pptx/)|將舊版 PPT 簡報轉換為 PPTX。|
|[可攜式文件格式 (PDF)](/slides/zh-hant/net/convert-powerpoint-to-pdf/)|將簡報匯出為 PDF，包含 PDF/A 與 PDF/UA 文件。|
|[XML 紙張規格 (XPS)](/slides/zh-hant/net/convert-powerpoint-to-xps/)|將簡報匯出為 XPS 文件。|
|[標記式影像檔案格式 (TIFF)](/slides/zh-hant/net/convert-powerpoint-to-tiff/)|將簡報匯出為 TIFF 圖像。|
|[HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)|將簡報匯出為 HTML 與 HTML5。|
|[PDF 與 HTML 匯入](/slides/zh-hant/net/import-presentation/)|從 PDF 頁面與 HTML 內容建立投影片。|

## **簡報呈現**

Aspose.Slides 可將投影片與個別圖形渲染為 PNG、JPEG、BMP、GIF、TIFF 與 SVG 圖像，並將投影片渲染為 EMF 中繪檔。請參閱 [將簡報投影片轉換為圖像](/slides/zh-hant/net/convert-slide/)、[將投影片渲染為 SVG 圖像](/slides/zh-hant/net/render-a-slide-as-an-svg-image/) 與 [建立圖形縮圖](/slides/zh-hant/net/create-shape-thumbnails/)。

## **內容功能**

Aspose.Slides 讓您可以建立、讀取與修改簡報中幾乎所有的內容：

|**領域**|**您可以執行的操作**|
| :- | :- |
|[投影片](/slides/zh-hant/net/presentation-slide/)|新增、複製、重新排序與移除投影片；套用版面配置與母片；將投影片組織成章節；變更投影片大小。|
|[設計](/slides/zh-hant/net/presentation-design/)|設定背景、主題顏色、頁首與頁尾，以及字型。|
|[文字](/slides/zh-hant/net/manage-text/)|建立與編輯文字框、段落與文字片段；設定字型、顏色、項目符號與對齊方式；搜尋與取代文字。|
|[圖形](/slides/zh-hant/net/powerpoint-shapes/)|建立自動形狀、線條、連接線、群組圖形與圖片框；設定位置、大小、線條及實心、漸層或圖案填色；依替代文字找尋圖形。|
|[表格](/slides/zh-hant/net/powerpoint-table/)、[圖表](/slides/zh-hant/net/powerpoint-charts/) 與 [SmartArt](/slides/zh-hant/net/powerpoint-smartart/)|建立與編輯表格、Microsoft Office 圖表以及 SmartArt 圖示。|
|[媒體](/slides/zh-hant/net/manage-media-files/)、[OLE 物件](/slides/zh-hant/net/manage-ole/) 與 [ActiveX 控制項](/slides/zh-hant/net/activex/)|新增嵌入或連結的音訊與視訊框架、嵌入 OLE 物件，並新增、修改或移除 ActiveX 控制項。|
|[備註](/slides/zh-hant/net/presentation-notes/) 與 [評論](/slides/zh-hant/net/presentation-comments/)|新增、讀取與編輯講者備註與審閱評論。|
|[動畫](/slides/zh-hant/net/powerpoint-animation/) 與 [轉場](/slides/zh-hant/net/slide-transition/)|對圖形套用動畫效果，設定投影片轉場，並配置投影片播放設定。|
|[安全性](/slides/zh-hant/net/presentation-security/)|以密碼加密簡報，設定寫入保護，並處理數位簽章。|
|[VBA 巨集](/slides/zh-hant/net/presentation-via-vba/)|在啟用巨集的簡報中新增、提取與移除 VBA 模組。|
|[屬性](/slides/zh-hant/net/presentation-properties/)|讀取與編輯文件屬性。|

## **常見問題**

**我是否需要在伺服器或 PC 上安裝 Microsoft PowerPoint 才能使用此函式庫？**

不需要。PowerPoint 並非必備；Aspose.Slides 是一個獨立的引擎，用於建立、編輯、轉換和呈現簡報。

**多執行緒運作方式是什麼？處理可以平行化嗎？**

在不同執行緒中處理不同文件是安全的；同一個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 物件不能同時被 [多執行緒](/slides/zh-hant/net/multithreading/) 使用。

**是否支援檔案密碼與加密？**

是的。[您可以](/slides/zh-hant/net/password-protected-presentation/) 開啟受加密的簡報、設定或移除開啟與寫入密碼，並檢查保護狀態。

**在 Linux 容器中，我需要關注字型嗎？**

是的。簡報中使用的字型或其合適的替代字型必須安裝在系統上，才能正確呈現文字。您也可以在應用程式中[指定字型目錄](/slides/zh-hant/net/custom-font/)。[安裝](/slides/zh-hant/net/installation/) 列出每個套件在 Linux 上的先決條件。

**評估版是否有任何限制？**

是的。若未取得 [授權](/slides/zh-hant/net/licensing/)，Aspose.Slides 會在每張儲存的投影片上加上評估水印，並截斷從簡報讀取的文字。可取得[30 天暫時授權](https://purchase.aspose.com/temporary-license/)以進行完整功能測試。

**是否支援將外部格式匯入至簡報（PDF 或 HTML 轉換為 PPTX）？**

是的。您可以將[PDF 頁面與 HTML 內容](/slides/zh-hant/net/import-presentation/) 加入簡報，將其轉換為投影片。