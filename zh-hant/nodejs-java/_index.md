---
title: Aspose.Slides for Node.js via Java
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /zh-hant/nodejs-java/
keywords:
- 文件說明
- 簡報處理
- 簡報轉換
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "從此開始：安裝 Aspose.Slides for Node.js via Java，建立第一個簡報，並查找常見任務指南、API 參考與支援資訊。"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides 用於 Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java 是一個用於在 Node.js 應用程式中建立、讀取、編輯和轉換 PowerPoint 與 OpenDocument 簡報的函式庫，無需 Microsoft PowerPoint。

它可以載入與儲存 PPT、PPTX、PPS、POT 與 ODP，包含巨集啟用和範本變體，並可匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 與圖片。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/zh-hant/nodejs-java/installation/">安裝</a></li>
<li><a href="/slides/zh-hant/nodejs-java/create-presentation/">建立您的第一個簡報</a></li>
<li><a href="/slides/zh-hant/nodejs-java/getting-started/">入門指南</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/zh-hant/nodejs-java/supported-file-formats/">支援的檔案格式</a></li>
<li><a href="/slides/zh-hant/nodejs-java/evaluate-aspose-slides/">試用限制</a></li>
<li><a href="/slides/zh-hant/nodejs-java/licensing/">授權</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 構建</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/zh-hant/nodejs-java/open-presentation/">開啟簡報</a></li>
<li><a href="/slides/zh-hant/nodejs-java/save-presentation/">儲存簡報</a></li>
<li><a href="/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/nodejs-java/convert-slide/">將投影片渲染為圖片</a></li>
<li><a href="/slides/zh-hant/nodejs-java/manage-text/">編輯文字與圖形</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/zh-hant/nodejs-java/powerpoint-charts/">圖表</a></li>
<li><a href="/slides/zh-hant/nodejs-java/powerpoint-animation/">動畫</a></li>
<li><a href="/slides/zh-hant/nodejs-java/manage-media-files/">音訊與視訊</a></li>
<li><a href="/slides/zh-hant/nodejs-java/presentation-design/">投影片設計</a></li>
<li><a href="/slides/zh-hant/nodejs-java/merge-presentation/">合併簡報</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/zh-hant/nodejs-java/examples/">依投影片元素分類的範例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>參考與支援</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">API 參考文件</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">發行說明</a></li>
<li><a href="/slides/zh-hant/nodejs-java/known-issues/">已知問題</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">下載</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援服務台</a></li>
</ul>
</div>
</div>

------

## **您的第一個簡報**

除了 Node.js 20 或更新版本外，套件還需要 Java Development Kit (JDK)、Python 與 C++ 建置工具鏈，因為 npm 會在安裝期間編譯其 `java` 橋接程式。請參考[安裝](/slides/zh-hant/nodejs-java/installation/)以瞭解各作業系統的步驟。然後建立專案並從 npm 安裝套件：

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

將以下程式碼儲存為專案資料夾中的 *hello.js*：

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides 在 Java 虛擬機中執行，會讓 Node.js 持續運行，因此需要明確結束程序。
process.exit(0);
```

使用 `node hello.js` 執行。此腳本會將 *hello.pptx* 儲存為一張包含文字方塊的投影片。若未取得授權，儲存的檔案會帶有評估水印 — 請參閱[授權](/slides/zh-hant/nodejs-java/licensing/)。想了解更多建立與填充簡報的方式，請參考[建立簡報](/slides/zh-hant/nodejs-java/create-presentation/)。