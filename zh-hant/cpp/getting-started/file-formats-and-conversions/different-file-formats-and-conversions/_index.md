---
title: 不同的檔案格式與轉換
type: docs
weight: 50
url: /zh-hant/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **關於 PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) 是一種簡報文件檔案格式，可由不同版本的 Microsoft PowerPoint 建立、讀取、操作與寫入。這是 Microsoft 開發的二進位簡報文件格式。

### **C++ 版 Aspose.Slides 中的 PPT**
Aspose.Slides for C++ 可以讀取以下軟體所建立的 PPT 檔案。

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

同樣地，Aspose.Slides for C++ 所建立的 PPT 檔案也可以被上述軟體讀取。

### **對 PPT 的完整支援**
Aspose.Slides for C++ 提供幾乎所有與 PPT 文件格式相關的功能支援。它不僅涵蓋各版本 Microsoft PowerPoint 所提供的基本與進階功能，還包括一些 Microsoft PowerPoint 本身不支援的功能。使用 Aspose.Slides for C++ API 函式庫的主要優勢在於處理這些功能的使用便利性。

除了建立、讀取與寫入 PPT 文件的基本工作之外，Aspose.Slides for C++ 還提供以下功能：

- 將其他 MS Office 檔案格式匯入為 PPT 文件中的 OLE 物件。
- 將 PPT 文件匯出為 PDF、TIFF、XPS 格式。
- 將 PPT 文件中的投影片匯出為 SVG 格式。
- 將投影片渲染為 C++ 框架支援的任何影像格式。
- 設定 PPT 文件中投影片的大小。
- 管理形狀的動畫。
- 管理投影片秀。
- 設定投影片中文字的格式。
- 掃描 PPT 文件中的文字。
- 處理投影片上的表格。
- 使用克隆功能自動複製母片。

由 Aspose.Slides for C++ 產生、在 Microsoft PowerPoint 中開啟的 PPT 檔案

## **PresentationML（PPTX，XML）**
### **關於 PresentationML**
PresentationML 是一族基於 XML 的簡報文件格式名稱。Office OpenXML（OOXML）是自 Microsoft Office 2007 起在 Office 應用程式中引入的 XML 基礎格式。Office OpenXML 是多種專用 XML 標記語言的容器格式，PresentationML 則是 Microsoft Office PowerPoint 2007 用來存儲文件的標記語言。

### **C++ 版 Aspose.Slides 中的 PresentationML**
OOXML PresentationML 文件以 PPTX 形式呈現，這些檔案是依照 [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 規範壓縮的 XML 套件。Aspose.Slides for C++ 完全支援建立、讀取、操作與寫入 PresentationML 文件。此外，Aspose.Slides for C++ 也能將 PresentationML 文件匯出為 PDF、TIFF、XPS 等廣泛使用的文件格式。之所以能實現這些功能，是因為 Aspose.Slides for C++ 的設計目標是全面處理簡報文件，而 PresentationML 基本上以壓縮的 XML 套件形式保存文件的內部結構。

由 Aspose.Slides for C++ 產生、在 Microsoft PowerPoint 中開啟的 PPTX 文件

在 Zip 應用程式中檢視由 Aspose.Slides for C++ 產生的 PPTX 文件

### **PresentationML 是開放的，為何使用 Aspose.Slides for C++**
雖然 PresentationML 基於 XML，完全可以僅使用 XML 類別而不依賴 Aspose.Slides for C++ 等第三方函式庫來建置處理與產生 PresentationML 文件的應用程式。然而，使用 Aspose.Slides for C++ 相較於僅使用 XML 類別，在處理 PresentationML 文件時具有多項優勢。

OOXML 規範長達數千頁。若要正確處理 PresentationML 文件，您必須投入大量時間與精力來了解此類文件的格式。相反地，使用 Aspose.Slides for C++ 時，只需使用相關類別及其屬性/方法，即可執行在 XML 類別下相當複雜的操作。

以下功能在透過 XML 類別處理 PresentationML 時甚至無法實現：

- 將 PPT 文件匯出為 PDF、TIFF、XPS 格式
- 將 PPT 文件中的投影片匯出為 SVG 格式
- 將投影片渲染為 C++ 框架支援的任何影像格式
- 使用克隆功能自動從來源簡報複製母片
- 於形狀上套用保護

以下以一個只有單一投影片、內含一個文字方塊、文字為「Hello World」的 PresentationML 文件為例。若要使用 XML 類別讀取文字，您必須撰寫程式碼從以下片段中解析此簡單文字：

``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```

## **PPT 轉換為 PPTX**
### **關於轉換**
Aspose.Slides 目前也支援將 PPT 轉換為 PPTX。

### **轉換支援的功能**
Aspose.Slides for C++ 提供部分支援，將 PPT 文件格式的簡報轉換為 PPTX 文件格式的簡報。由於此轉換功能剛在 Aspose.Slides for C++ 中加入，現在僅能處理簡單形式的簡報，功能較為有限。Aspose.Slides for C++ API 函式庫在將 PPT 簡報轉換為 PPTX 格式時的主要優勢在於 API 使用的便利性。請前往 this[link]() 以取得程式碼範例區段的更多細節。以下段落明確說明在將 PPT 格式的簡報轉換為 PPTX 格式簡報時，哪些功能受到支援，哪些功能不受支援。

### **支援的功能**
在轉換過程中支援以下功能：

- 轉換母片、版面配置與投影片的結構
- 轉換母片、版面配置與投影片的結構
- 轉換圖表
- 群組形狀
- 轉換包括矩形與橢圓的自動形狀。但自動形狀的調整值可能不正確
- 具有自訂幾何形狀的形狀。有時可能無法轉換
- 自動形狀的紋理與圖片填充樣式。有時可能無法轉換
- 轉換佔位符
- 轉換文字框與文字持有者中的文字。但項目符號、對齊與跳格未完全實作

### **不支援的功能**
在轉換過程中不支援以下功能：

- 含有備註的投影片，PPTX 尚未實作讀取備註功能。若 PPT 有備註，則無法儲存為 PPTX。* 線條與多段線的轉換
- 線條與填充格式
- 漸層填充樣式
- OLE 框架、表格、影片與音訊框架等
- 動畫與其他投影片秀屬性將被略過

未來版本的 Aspose.Slides for C++ 將持續加入新功能或補足缺失功能。

Source PPT 簡報

Converted PPTX 簡報

## **可攜式文件格式 (PDF)**
### **關於 PDF**
[Portable Document Format](https://en.wikipedia.org/wiki/PDF) 是 Adobe 系統為不同組織之間的文件交換所建立的檔案格式。此格式的目的在於讓文件內容的視覺外觀不受檢視平台的影響。

### **C++ 版 Aspose.Slides 中的 PDF**
任何可載入 Aspose.Slides for C++ 的簡報文件，都可以轉換為符合 [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) 或 [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) 的 PDF 文件，取決於您的選擇。Aspose.Slides for C++ 以使匯出的 PDF 文件在大多數情況下與原始簡報文件外觀相近的方式進行匯出。Aspose 的解決方案在將簡報文件轉換為 PDF 時支援以下功能：

- 圖像、文字方塊與其他形狀
- 文字與格式設定
- 段落與格式設定
- 超連結
- 頁首與頁尾
- 項目符號
- 表格

您只需使用 Aspose.Slides for C++ 元件，即可直接將簡報文件匯出為 PDF 文件，無需任何其他第三方或 Aspose.Pdf 元件。除此之外，您還可以依照 [this topic](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/) 中說明的方式，以不同選項自訂簡報至 PDF 的匯出。

由 Aspose.Slides for C++ 轉換為 PDF 文件的簡報文件

## **XML 解析規範 (XPS)**
### **關於 XPS**
[XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) 是由 Microsoft 最初開發的頁面描述語言與固定文件格式。與 PDF 類似，XPS 是一種固定版面文件格式，旨在保留文件的精確外觀並提供與裝置無關的文件呈現。

### **C++ 版 Aspose.Slides 中的 XPS**
任何可由 Aspose.Slides for C++ 載入的簡報文件，都可以轉換為 XPS 格式。Aspose.Slides for C++ 使用高保真度的頁面版面與渲染引擎，產生固定版面的 XPS 文件。值得一提的是，Aspose.Slides for C++ 直接產生 XPS，並不依賴 Windows Presentation Foundation（WPF）類別，因而可在 C++ Framework 3.5 之前的版本上產生 XPS 文件。您可參閱 [this topic](https://docs.aspose.com/slides/zh-hant/cpp/convert-powerpoint-to-xps/) 了解如何透過 Aspose.Slides for C++ 將簡報文件匯出為 XPS 文件。

由 Aspose.Slides for C++ 轉換為 XPS 文件的簡報文件