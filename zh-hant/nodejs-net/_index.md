---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /zh-hant/nodejs-net/
keywords:
- 文件
- 簡報處理
- 簡報轉換
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "從此開始：安裝 Aspose.Slides for Node.js via .NET，建立第一個簡報，並尋找常見任務、授權、API 參考與支援的指南。"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET 是一個用於在 Node.js 應用程式中建立、讀取、編輯與轉換 PowerPoint 與 OpenDocument 簡報的函式庫，無需 Microsoft PowerPoint 或 Office Automation。它透過 edge-js 橋接執行 Aspose.Slides for .NET，因此其 JavaScript API 與 .NET API 相同，使用 camelCase 成員名稱。

它可載入與儲存 PPT、PPTX、PPS、POT 與 ODP，包含支援巨集與範本的變體，並可匯出為 PDF、XPS、HTML、TIFF、Markdown 與圖片。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>快速開始</b></p>
<hr>
<p>開始使用</p>
<ul>
<li><a href="/slides/zh-hant/nodejs-net/installation/">安裝</a></li>
<li><a href="/slides/zh-hant/nodejs-net/create-presentation/">建立您的第一個簡報</a></li>
<li><a href="/slides/zh-hant/nodejs-net/developer-guide/">開發人員指南</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/nodejs-net/evaluate-aspose-slides/">試用限制</a></li>
<li><a href="/slides/zh-hant/nodejs-net/licensing/">授權</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 建置</b></p>
<hr>
<p>常見任務</p>
<ul>
<li><a href="/slides/zh-hant/nodejs-net/open-presentation/">開啟與儲存簡報</a></li>
<li><a href="/slides/zh-hant/nodejs-net/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/nodejs-net/convert-slide/">將投影片渲染為圖片</a></li>
<li><a href="/slides/zh-hant/nodejs-net/manage-text/">編輯文字</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>參考 &amp; 支援</b></p>
<hr>
<p>參考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API 參考</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">發行說明</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">產品頁面</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">下載</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援服務台</a></li>
</ul>
</div>
</div>

------

## **您的第一個簡報**

您需要 Node.js 22 或 24 以及 .NET SDK 8 或更新版本；Linux 亦需安裝幾個系統套件。[安裝](/slides/zh-hant/nodejs-net/installation/) 列出了它們以及已測試的平台。建立專案，新增一個覆寫以告訴 npm 要安裝哪個 edge-js 版本，然後安裝套件：

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

每台機器執行一次，還原此函式庫所依賴的 .NET 套件。將 `deps.csproj` 檔案從[還原 .NET 依賴項](/slides/zh-hant/nodejs-net/installation/#restore-the-net-dependencies) 保存至專案資料夾內的 `deps` 資料夾，然後執行：

```sh
dotnet restore deps/deps.csproj
```

將此程式碼儲存為 *hello.js* 於專案資料夾中：

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// 新的簡報包含一張空白投影片。
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置與尺寸以點 (1/72 英吋) 為單位：x、y、寬度、高度。
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // 釋放支援簡報的 .NET 物件。
    presentation.dispose();
}
```

在專案資料夾中執行它：

```sh
node hello.js
```

腳本會顯示 `Saved hello.pptx`，並將 *hello.pptx* 儲存為包含一張帶有文字矩形的投影片。如果未授權，儲存的檔案會有評估水印 ─ 請參見[授權](/slides/zh-hant/nodejs-net/licensing/)。如需更多建立與填充簡報的方式，請參閱[建立簡報](/slides/zh-hant/nodejs-net/create-presentation/)。