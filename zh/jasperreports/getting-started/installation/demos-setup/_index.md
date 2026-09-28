---
title: 演示项目设置
type: docs
weight: 70
url: /zh/jasperreports/demos-setup/
description: "从 Aspose.Slides for JasperReports 下载中设置演示项目，修改其使用的导出器类，并使用 Ant 构建它们。"
---
## **演示内容**

*samples* 文件夹中包含八个演示项目：*charts*、*fonts*、*images*、*landscape*、*shapes*、*subreport*、*text* 和 *xmldatasource*。它们是标准的 JasperReports 演示，只是加入了 `ppt` 构建目标，用于将已填充的报告导出为 PPT。下载中不包含已导出的演示文稿；需要通过构建相应的演示来生成。

## **在构建之前更改导出器类**

默认情况下，演示的 Java 代码使用 `com.aspose.slides.jasperreports.JRPptExporter`，而该类不在当前 jar 中，所以演示无法编译。在演示的应用程序类中（例如 *shapes* 演示里的 *ShapesApp.java*），将 `JRPptExporter` 替换为同一包中的 PPT 导出器 `ASPptExporter`。*fonts* 演示导入了整个包，因此只需要更改代码中的类名。

这些演示还使用了后期 JasperReports 版本已移除的类，例如 `JExcelApiExporter` 和 `JRExporterParameter.FONT_MAP`。完成上述更改后，演示可以如下编译：

| JasperReports version | 可编译的演示 |
| :- | :- |
| 5.5.1 | 全部八个 |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* and *xmldatasource* |
| 6.16.0 | *charts* |

## **构建演示**

每个演示的 *build.xml* 都假设 JasperReports 项目的文件夹结构：它会相对于演示文件夹编译，引用 *../../../build/classes* 和位于 *../../../lib* 的 jar 包。

1. 将演示文件夹复制到 JasperReports 项目文件夹中的 *demo/samples*。
2. 从下载的 *lib* 子文件夹中复制对应您 JasperReports 版本的 *aspose.slides.jasperreports.library-xx.x.jar* 到 JasperReports 项目的 *lib* 文件夹。参见[Installing Aspose.Slides for JasperReports](/slides/zh/jasperreports/installing-aspose-slides-for-jasperreports/)。
3. 将您 JasperReports 版本对应的 jar 以及其依赖的 jar 放入同一个 *lib* 文件夹。除了演示文件外，*build.xml* 仅将 *build/classes* 和 *lib* 下的 jar 添加到类路径，而 *build/classes* 只有在您从源码编译 JasperReports 后才包含 JasperReports 类。
4. *charts*、*subreport* 和 *text* 演示读取 JasperReports 的 HSQLDB 示例数据库（`jdbc:hsqldb:hsql://localhost`），因此请先启动其服务器，具体步骤见下载中的 *samples/Readme.txt*。其他演示不需要数据库。
5. 在演示文件夹中，编译应用程序、编译报表设计、填充报表并导出为 PPT：

```bash
ant javac
ant compile
ant fill
ant ppt
```

`ppt` 目标会在已填充的报表旁边生成演示文稿，文件名与报表相同（例如 *LandscapeReport.ppt*）。

有两个演示需要额外的步骤：

- *images* 演示在导出时会加载 `http://jasperreports.sourceforge.net/jasperreports.png` 中的一张图片。该地址现在会重定向到 HTTPS，因此在 *ImagesReport.jrxml* 中将地址改为 `https://` 之前，`ppt` 步骤不会生成演示文稿。使用 JasperReports 6.4.0 时，即使是 HTTPS，导出该图片也会失败。
- *xmldatasource* 报表使用 Arial 字体。如果系统中没有 Arial，`ant fill` 会打印出字体“is not available to the JVM”，并且不会生成已填充的报表，导致 `ant ppt` 没有可导出的内容。构建仍会显示成功，所以请检查每一步的输出。