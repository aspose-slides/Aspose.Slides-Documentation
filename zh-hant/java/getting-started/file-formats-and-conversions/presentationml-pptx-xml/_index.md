---
title: PresentationML（PPTX，XML）
type: docs
weight: 20
url: /zh-hant/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML 是一系列基於 XML 的簡報文件格式的名稱。Office OpenXML (OOXML) 是在 Microsoft Office 2007 應用程式中引入的基於 XML 的格式。Office OpenXML 是一種容器格式，用於多種專門的基於 XML 的標記語言。PresentationML 是 Microsoft Office PowerPoint 2007 用於儲存文件的標記語言。

{{% /alert %}} 

## **在 Aspose.Slides for Java 中的 PresentationML**
OOXML PresentationML 文件以 PPTX 檔案形式存在，這些壓縮的 XML 封裝遵循 [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 規範。Aspose.Slides for Java 完全支援建立、讀取、操作與寫入 PresentationML 文件。此外，Aspose.Slides for Java 能夠將 PresentationML 文件匯出為廣泛使用的文件格式，例如 PDF。之所以能做到這點，是因為 Aspose.Slides for Java 的設計目標是全面處理簡報文件，而 PresentationML 基本上以壓縮的 XML 封裝保存文件的內部結構。

**由 Aspose.Slides for Java 產生、在 Microsoft PowerPoint 中開啟的 PPTX 文件** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**在 ZIP 中檢視由 Aspose.Slides for Java 產生的相同 PPTX 文件** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML 是開放的，為何要使用 Aspose.Slides for Java？**
由於 PresentationML 基於 XML，完全可以使用 XML 類別自行開發應用程式來處理與產生 PresentationML 文件，而不依賴 Aspose.Slides for Java 等第三方類庫。然而，使用 Aspose.Slides for Java 相較於直接使用 XML 類別處理 PresentationML 文件，有多項優勢。

OOXML 規範長達數千頁，若要正確處理 PresentationML 文件，必須花費大量時間與精力來了解格式細節。相反地，使用 Aspose.Slides for Java，您只需呼叫類別及其方法與屬性，即可執行若以 XML 類別實作會相當複雜的操作。

以下是 Aspose.Slides 所提供、在使用 XML 類別時根本無法取得的功能：

- 將 PPT 文件匯出為 PDF 格式。
- 將投影片渲染為 Java 框架支援的任何圖像格式。
- 使用克隆功能自動從來源簡報複製母片。
- 對圖形套用保護。

下面是一個包含單一投影片、其中有一個文字方塊顯示「Hello World」的 PresentationML 文件範例。若要使用 XML 類別讀取文字，您必須撰寫程式碼來解析以下片段中的簡單文字。Aspose.Slides 會為您完成這項工作。

**XML**

``` xml
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