---
title: Aspose.Slides for Node.js via Java
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /zh/nodejs-java/
keywords:
- 文档
- 演示文稿处理
- 演示文稿转换
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "从这里开始：安装 Aspose.Slides for Node.js via Java，创建第一个演示文稿，并查找常见任务指南、API 参考和支持。"
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java 是一个库，用于在 Node.js 应用程序中创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint。

它可以加载和保存 PPT、PPTX、PPS、POT 和 ODP，包括启用宏和模板的变体，并导出为 PDF、XPS、HTML、SVG、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>入门</b></p>
<hr>
<p>快速入门</p>
<ul>
<li><a href="/slides/zh/nodejs-java/installation/">安装</a></li>
<li><a href="/slides/zh/nodejs-java/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/nodejs-java/getting-started/">入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/nodejs-java/supported-file-formats/">支持的文件格式</a></li>
<li><a href="/slides/zh/nodejs-java/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/nodejs-java/licensing/">授权</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>常见任务</p>
<ul>
<li><a href="/slides/zh/nodejs-java/open-presentation/">打开演示文稿</a></li>
<li><a href="/slides/zh/nodejs-java/save-presentation/">保存演示文稿</a></li>
<li><a href="/slides/zh/nodejs-java/convert-powerpoint-to-pdf/">转换为 PDF</a></li>
<li><a href="/slides/zh/nodejs-java/convert-slide/">将幻灯片渲染为图像</a></li>
<li><a href="/slides/zh/nodejs-java/manage-text/">编辑文本和形状</a></li>
</ul>
<p>Slides 工作流</p>
<ul>
<li><a href="/slides/zh/nodejs-java/powerpoint-charts/">图表</a></li>
<li><a href="/slides/zh/nodejs-java/powerpoint-animation/">动画</a></li>
<li><a href="/slides/zh/nodejs-java/manage-media-files/">音频和视频</a></li>
<li><a href="/slides/zh/nodejs-java/presentation-design/">幻灯片设计</a></li>
<li><a href="/slides/zh/nodejs-java/merge-presentation/">合并演示文稿</a></li>
</ul>
<p>示例</p>
<ul>
<li><a href="/slides/zh/nodejs-java/examples/">按幻灯片元素分类的示例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考与支持</b></p>
<hr>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">发行说明</a></li>
<li><a href="/slides/zh/nodejs-java/known-issues/">已知问题</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">下载</a></li>
</ul>
<p>支持</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免费支持论坛</a></li>
<li><a href="https://helpdesk.aspose.com/">付费支持帮助台</a></li>
</ul>
</div>
</div>

------

## **您的第一个演示文稿**

除了 Node.js 20 或更高版本之外，该包还需要 Java 开发工具包（JDK）、Python 和 C++ 构建工具链，因为 npm 在安装期间会编译其 `java` 桥接。请参阅[Installation](/slides/zh/nodejs-java/installation/)了解各操作系统的步骤。然后创建项目并从 npm 安装此包：

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

将以下代码保存为项目文件夹中的 *hello.js*：

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

// Aspose.Slides 在 Java 虚拟机中运行，该虚拟机会保持 Node.js 持续运行，因此需要显式结束进程。
process.exit(0);
```

使用 `node hello.js` 运行它。脚本会保存一个包含文本框的单张幻灯片的 *hello.pptx*。如果没有许可证，保存的文件会带有评估水印——请参阅[Licensing](/slides/zh/nodejs-java/licensing/)。有关创建和填充演示文稿的更多方法，请参阅[Create Presentations](/slides/zh/nodejs-java/create-presentation/)。