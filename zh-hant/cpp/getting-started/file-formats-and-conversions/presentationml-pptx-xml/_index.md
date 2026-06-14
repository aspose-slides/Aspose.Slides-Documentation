---
title: PresentationML（PPTX，XML）
type: docs
weight: 20
url: /zh-hant/cpp/presentationml-pptx-xml/
---
## **關於 PresentationML**
PresentationML 是一個用於演示文件的 XML 為基礎格式族的名稱。Office OpenXML（OOXML）是 Microsoft Office 2007 應用程式引入的 XML 為基礎格式。Office OpenXML 是用於多種專門化 XML 為基礎標記語言的容器格式。PresentationML 是 Microsoft Office PowerPoint 2007 用於儲存其文件的標記語言。

## **Aspose.Slides for C++ 中的 PresentationML**
OOXML PresentationML 文件以 PPTX 檔案形式存在，這些檔案是遵循 [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 規範的壓縮 XML 套件。Aspose.Slides for C++ 廣泛支援建立、讀取、操作與寫入 PresentationML 文件。此外，Aspose.Slides for C++ 能夠將 PresentationML 文件匯出為不同廣泛使用的文件格式，如 PDF、TIFF 與 XPS。之所以能夠做到這一點，是因為 Aspose.Slides for C++ 的設計目標是完整處理演示文件，而 PresentationML 基本上以壓縮 XML 套件的形式保存文件的內部結構。

## **PresentationML 是開放的，為何要使用 Aspose.Slides for C++**
由於 PresentationML 基於 XML，完全可以使用 XML 類別自行建立處理與產生 PresentationML 文件的應用程式，而無需依賴像 Aspose.Slides for C++ 之類的第三方類別庫。然而，在處理 PresentationML 文件時，使用 Aspose.Slides for C++ 相較於純 XML 類別仍具備多項優勢。

OOXML 規範篇幅龐大，達數千頁之多。這意味著，要正確處理 PresentationML 文件，您必須投入大量時間與精力來了解此類文件的格式。相對地，使用 Aspose.Slides for C++ 時，只需使用相關類別及其相應的方法/屬性即可執行操作，而若用 XML 類別實作則相當複雜。

以下列出一些在透過 XML 類別處理 PresentationML 文件時甚至無法使用的功能：

- 將 PPT 文件匯出為 PDF、TIFF、XPS 格式
- 將 PPT 文件中的投影片匯出為 SVG 格式
- 將投影片渲染為 C++ 框架支援的任何圖像格式
- 使用複製功能自動從來源簡報複製母片
- 對圖形套用保護

讓我們以一個僅有單一投影片且包含一個文字方塊，內有「Hello World」文字的 PresentationML 文件為例。若要透過 XML 類別讀取該文字，您必須編寫程式以從以下片段中解析此簡單文字：

## **範例**

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