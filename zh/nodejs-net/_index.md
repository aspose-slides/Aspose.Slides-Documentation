---
title: "Aspose.Slides for Node.js via .NET"
second_title: "Aspose.Slides for Node.js"
type: docs
weight: 47
url: /zh/nodejs-net/
keywords:
- "文档"
- "演示文稿处理"
- "演示文稿转换"
- "PowerPoint"
- "OpenDocument"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "从这里开始：安装 Aspose.Slides for Node.js via .NET，创建第一个演示文稿，并查找常见任务、授权、API 参考和支持的指南。"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET 是一个库，用于在 Node.js 应用程序中创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint 或 Office 自动化。它通过 edge-js 桥运行 Aspose.Slides for .NET，因此其 JavaScript API 与 .NET API 镜像，成员名称采用 camelCase。

它加载并保存 PPT、PPTX、PPS、POT 和 ODP，包括启用宏的和模板变体，并导出为 PDF、XPS、HTML、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------
<div class="row">
<div class="col-md-4">
<p><b>快速入门</b></p>
<hr>
<p>开始使用</p>
<ul>
<li><a href="/slides/zh/nodejs-net/installation/">安装</a></li>
<li><a href="/slides/zh/nodejs-net/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/nodejs-net/developer-guide/">开发者指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/nodejs-net/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/nodejs-net/licensing/">授权</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>常见任务</p>
<ul>
<li><a href="/slides/zh/nodejs-net/open-presentation/">打开并保存演示文稿</a></li>
<li><a href="/slides/zh/nodejs-net/convert-powerpoint-to-pdf/">转换为 PDF</a></li>
<li><a href="/slides/zh/nodejs-net/convert-slide/">将幻灯片渲染为图像</a></li>
<li><a href="/slides/zh/nodejs-net/manage-text/">编辑文本</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考&amp;支持</b></p>
<hr>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">发行说明</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">产品页面</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">下载</a></li>
</ul>
<p>支持</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免费支持论坛</a></li>
<li><a href="https://helpdesk.aspose.com/">付费支持服务台</a></li>
</ul>
</div>
</div>

------
## **您的第一个演示文稿**

您需要 Node.js 22 或 24 以及 .NET SDK 8 或更高版本；Linux 还需要一些系统软件包。[安装](/slides/zh/nodejs-net/installation/) 列出了它们以及已测试的平台。创建一个项目，添加一个覆盖项以告诉 npm 安装哪个 edge-js 版本，然后安装该包：

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

每台机器只需执行一次，恢复库所依赖的 .NET 包。将来自[恢复 .NET 依赖项](/slides/zh/nodejs-net/installation/#restore-the-net-dependencies)的 `deps.csproj` 文件保存到项目文件夹内的 `deps` 文件夹中，然后运行：

```sh
dotnet restore deps/deps.csproj
```

将此代码保存为项目文件夹中的 *hello.js*：

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// 新建的演示文稿包含一个空幻灯片。
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置和尺寸使用点（1/72 英寸）：x、y、宽度、高度。
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // 释放支撑演示文稿的 .NET 对象。
    presentation.dispose();
}
```

在项目文件夹中运行它：

```sh
node hello.js
```

脚本打印 `Saved hello.pptx` 并保存 *hello.pptx*，其中包含一个包含文本的矩形幻灯片。未授权时，保存的文件会带有评估水印 —— 请参阅[授权](/slides/zh/nodejs-net/licensing/)。欲了解更多创建和填充演示文稿的方法，请参阅[创建演示文稿](/slides/zh/nodejs-net/create-presentation/)。