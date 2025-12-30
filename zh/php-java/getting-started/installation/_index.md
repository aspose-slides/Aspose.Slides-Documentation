---
title: 安装
type: docs
weight: 70
url: /zh/php-java/installation/
keywords:
- 安装 Aspose.Slides
- 下载 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安装
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "快速安装 Aspose.Slides for PHP via Java。一步一步的指南、系统要求和代码示例——立即开始使用 PowerPoint 演示文稿！"
---

## **配置环境**

1. 安装 PHP 7，将 PHP 路径添加到系统 `PATH` 变量，并在 `php.ini` 文件中将 `allow_url_include` 设置为 `On`。
1. 安装 JRE 8。将 `JAVA_HOME` 环境变量设置为已安装 JRE 的路径。
1. 安装 Apache Tomcat 8.0。

## **下载 Aspose.Slides for PHP via Java** 

`packagist` 是下载 [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides) 的最简便方式。

要使用 Packagist 安装 Aspose.Slides，请运行以下命令：
   ```bash
   composer require aspose/slides
   ```


## **配置 Apache Tomcat**

1. 从 http://php-java-bridge.sourceforge.net/pjb/download.php 下载 PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`)，并将 `JavaBridge.war` 文件解压到 Tomcat `webapps` 文件夹。
1. 启动 Apache Tomcat 服务。
1. 下载 [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/php-java) 并解压到 `aspose.slides` 文件夹。将 `jar/aspose-slides-x.x-php.jar` 文件复制到 `webapps\JavaBridge\WEB-INF\lib` 文件夹。如果使用 **PHP 8**，请用 `Java.inc.php8.zip` 中的 `Java.inc` 替换 PHP-Java Bridge 中的原始 `Java.inc`。
1. 重启 Apache Tomcat 服务。
1. 在 `aspose.slides` 文件夹中运行 `example.php`，使用以下命令执行示例：
   ```bash
   php example.php
   ```


## **FAQ**

**如何确认 Aspose.Slides 已正确集成？**

构建项目，实例化一个空白的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 并另存为新名称。如果文件创建成功且未抛出异常，则说明库已成功集成。

**在处理大型演示文稿时，如何限制内存消耗？**

仅在需要时提升 JVM 内存上限，并在 `finally` 块中关闭每个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 实例，以及时释放缓存。这可防止内存不足错误，并在批处理操作期间保持整体内存使用的可预期性。

**能否排除不需要的导出格式以减小最终 JAR 大小？**

当前的 Aspose.Slides 发行版以单一整体库形式提供，无法在构建时禁用特定的导出器（例如 PDF 或 SVG）。