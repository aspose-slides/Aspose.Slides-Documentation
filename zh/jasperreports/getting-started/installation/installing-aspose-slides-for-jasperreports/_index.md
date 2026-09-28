---
title: 安装 Aspose.Slides for JasperReports
type: docs
weight: 40
url: /zh/jasperreports/installing-aspose-slides-for-jasperreports/
description: "选择与您的 JasperReports 版本匹配的 Aspose.Slides for JasperReports JAR 包，并将其添加到 JasperReports、Maven 项目或 JasperReports Server 中。"
---
## **为您的 JasperReports 版本选择 JAR 包**

Aspose.Slides for JasperReports 在[下载页面](https://releases.aspose.com/slides/jasperreport/)提供 ZIP 包。其 *lib* 文件夹中每个子文件夹对应一个 JasperReports 版本范围。请从对应您使用的 JasperReports 版本的子文件夹中获取 JAR 包：

| JasperReports 版本 | *lib* 子文件夹 |
| :- | :- |
| 3.7.2 到 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 到 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 到 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

没有针对 JasperReports 6.17.0 或更高版本（包括 JasperReports 7）的子文件夹。*JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* 子文件夹不包含 JAR，仅有一则说明——对这些版本的支持已在 Aspose.Slides for JasperReports 17.6 中结束。

每个子文件夹包含两个 JAR，名称中的 *xx.x* 表示产品版本：

- *aspose.slides.jasperreports.library-xx.x.jar* 包含 JasperReports Library 的导出器（`ASPptExporter`、`ASPptxExporter`、`ASPdfExporter` 和 `ASHtmlExporter`）以及 `License` 类。
- *aspose.slides.jasperreports.server-xx.x.jar* 包含 JasperReports Server 的导出操作。它基于库 JAR，因此 Server 必须同时使用同一子文件夹中的两个 JAR。

## **将库 JAR 添加到 JasperReports 或您的应用程序**

将匹配子文件夹中的 *aspose.slides.jasperreports.library-xx.x.jar* 复制到 JasperReports 的 *lib* 文件夹或您的应用程序类路径中。随后，您的应用程序即可在代码中创建导出器。

{{% alert color="info" title="注意" %}}
在 Linux 上，JasperReports 需要 fontconfig 和至少一个已安装的字体才能填充报表。缺少字体时，填充会因 “Error initializing graphic environment” 错误而失败。
{{% /alert %}}

## **将库 JAR 添加到 Maven 项目**

该 JAR 随 ZIP 包提供，而非来自 Maven 仓库。要在 Maven 构建中使用它，需要将其安装到本地 Maven 仓库。针对 26.6 版本，在保存 JAR 的文件夹中运行以下命令：

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

然后在 *pom.xml* 的依赖项中添加它，并同时指定该 JAR 所在子文件夹对应的 JasperReports 版本：

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

group 和 artifact ID 是您在安装命令中选择的，只需保持一致即可。使用 JasperReports 6.16.0 的完整项目可在[您的首次导出](/slides/zh/jasperreports/#your-first-export)中找到。

## **将 JAR 包添加到 JasperReports Server**

将匹配子文件夹中的两个 JAR 复制到 JasperReports Server Web 应用的 *WEB-INF/lib* 文件夹，然后按照[与 JasperServer 的集成](/slides/zh/jasperreports/integration-with-jasperserver/)中的说明注册导出器。