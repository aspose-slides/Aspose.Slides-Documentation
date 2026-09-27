---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /zh/php-java/
keywords:
- 文档
- 演示文稿处理
- 演示文稿转换
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "从这里开始：安装 Aspose.Slides for PHP via Java，创建第一个演示文稿，并查找常见任务指南、API 参考和支持。"
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java 是一个类库，用于在 PHP 应用程序中创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint 或 Office 自动化。

它加载并保存 PPT、PPTX、PPS、POT 和 ODP，包括启用宏和模板的变体，并导出为 PDF、XPS、HTML、SVG、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>开始使用</b></p>
<hr>
<p>入门指南</p>
<ul>
<li><a href="/slides/zh/php-java/installation/">安装</a></li>
<li><a href="/slides/zh/php-java/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/php-java/getting-started/">入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/php-java/supported-file-formats/">支持的文件格式</a></li>
<li><a href="/slides/zh/php-java/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/php-java/licensing/">授权</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>常见任务</p>
<ul>
<li><a href="/slides/zh/php-java/open-presentation/">打开演示文稿</a></li>
<li><a href="/slides/zh/php-java/save-presentation/">保存演示文稿</a></li>
<li><a href="/slides/zh/php-java/convert-powerpoint-to-pdf/">转换为 PDF</a></li>
<li><a href="/slides/zh/php-java/convert-slide/">将幻灯片渲染为图像</a></li>
<li><a href="/slides/zh/php-java/manage-text/">编辑文本和形状</a></li>
</ul>
<p>Slides 工作流</p>
<ul>
<li><a href="/slides/zh/php-java/powerpoint-charts/">图表</a></li>
<li><a href="/slides/zh/php-java/powerpoint-animation/">动画</a></li>
<li><a href="/slides/zh/php-java/manage-media-files/">音频和视频</a></li>
<li><a href="/slides/zh/php-java/presentation-design/">幻灯片设计</a></li>
<li><a href="/slides/zh/php-java/merge-presentation/">合并演示文稿</a></li>
</ul>
<p>示例</p>
<ul>
<li><a href="/slides/zh/php-java/examples/">按幻灯片元素划分的示例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考与支持</b></p>
<hr>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">发行说明</a></li>
<li><a href="/slides/zh/php-java/known-issues/">已知问题</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">下载</a></li>
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

Aspose.Slides for PHP via Java 在 Apache Tomcat 中的 Java 环境上运行，您的 PHP 脚本通过 PHP/Java Bridge 与其交互。[Installation](/slides/zh/php-java/installation/) 会设置 PHP 8.3 及更早版本、Java、Tomcat 和桥接器，然后在项目文件夹中从 Packagist 安装包。

```bash
composer require aspose/slides
```

然后将包的 JAR 文件复制到桥接器中并重启 Tomcat，如[Install on Linux](/slides/zh/php-java/installation/#install-on-linux) 的第 4 步或[Install on Windows](/slides/zh/php-java/installation/#install-on-windows) 的第 6 步所示。Tomcat 运行后，将此脚本保存为项目文件夹中的 *hello.php* 并运行 `php hello.php`：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

脚本会在同目录下保存 *hello.pptx*，其中包含一个带有文本框的幻灯片。没有许可证时，保存的文件会带有评估水印——请参阅 [Licensing](/slides/zh/php-java/licensing/)。有关创建和填充演示文稿的更多方法，请参阅 [Create Presentations](/slides/zh/php-java/create-presentation/).