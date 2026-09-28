---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /zh/jasperreports/
keywords:
- 文档
- JasperReports
- JasperReports Server
- 报表导出
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "从这里开始：安装 Aspose.Slides for JasperReports，将第一份报表导出为 PowerPoint，并查找导出、JasperReports Server 集成和支持的指南。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports 为 JasperReports Library 和 JasperReports Server 添加了 PowerPoint 导出器，使 Java 应用程序和报表服务器能够在没有 Microsoft PowerPoint 的情况下将填充的报表保存为演示文稿。

它将填充的报表导出为 PPT 和 PPTX（每个报表页面对应一张幻灯片），也可以导出为 PDF 和 HTML。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>入门</b></p>
<hr>
<p>开始使用</p>
<ul>
<li><a href="/slides/zh/jasperreports/installing-aspose-slides-for-jasperreports/">安装</a></li>
<li><a href="/slides/zh/jasperreports/product-overview/">产品概览</a></li>
<li><a href="/slides/zh/jasperreports/system-requirements/">系统要求</a></li>
<li><a href="/slides/zh/jasperreports/getting-started/">入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/jasperreports/supported-file-formats/">支持的文件格式</a></li>
<li><a href="/slides/zh/jasperreports/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/jasperreports/licensing/">许可</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>导出</p>
<ul>
<li><a href="/slides/zh/jasperreports/ppt-pptx-pdf-and-html-export/">导出为 PPT、PPTX、PDF 和 HTML</a></li>
<li><a href="/slides/zh/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">映射字体</a></li>
<li><a href="/slides/zh/jasperreports/integration-with-jasperserver/">JasperReports Server 集成</a></li>
</ul>
<p>示例</p>
<ul>
<li><a href="/slides/zh/jasperreports/demos-setup/">示例项目</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考与支持</b></p>
<hr>
<p>参考资料</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">发布说明</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">下载</a></li>
</ul>
<p>支持</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免费支持论坛</a></li>
<li><a href="https://helpdesk.aspose.com/">收费支持服务台</a></li>
</ul>
</div>
</div>

------

## **首次导出**

以下步骤编译一个单行报表，填充数据，并使用来自 Maven Central 的 JasperReports 6.16.0 将其导出为 PPTX。你需要 JDK 11 或更高版本以及 Apache Maven。

1. 从[下载页面](https://releases.aspose.com/slides/jasperreport/)下载 ZIP 并解压。其 *lib* 文件夹按 JasperReports 版本范围划分子文件夹，每个子文件夹包含对应范围的 jar。对于 JasperReports 6.16.0，将 *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* 复制到一个空项目文件夹中。

2. 该 jar 位于 ZIP 中而非 Maven 仓库，因此需要将其安装到本地 Maven 仓库。在项目文件夹中运行以下命令：

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. 将此 *pom.xml* 保存到项目文件夹中。它会添加 JasperReports 6.16.0 以及你已安装的 jar，并指定要运行的类。JasperReports 6.16.0 声明了一个未在 Maven Central 上的补丁 iText 构建，因此文件中未包含它；Aspose 导出器不需要它。

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
        </dependency>
    </dependencies>

    <build>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

4. 将此报表设计保存为项目文件夹中的 *hello.jrxml*。它在标题带中打印一行文本：

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. 将此代码保存为 *src/main/java/HelloExport.java*。它编译设计，使用一条空记录填充报表，并使用 `ASPptxExporter` 导出结果：

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // 编译报表设计并使用一条空记录填充。
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // 将填充的报表导出为 PPTX。
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. 在项目文件夹中运行以下命令：

```bash
mvn compile exec:java
```

程序会在项目文件夹中保存 *hello.pptx*，其中包含一张展示报表文本的幻灯片。编译器会提示代码使用了已弃用的 API：导出器通过 `JRExporterParameter` 进行输入输出，不接受较新的 `setExporterInput` 和 `setExporterOutput` 配置。在 Linux 上，必须安装 fontconfig 并至少一个字体，否则填充报表会失败。未授权时，每张幻灯片的中心会出现评估水印——参见[许可](/slides/zh/jasperreports/licensing/)。如需导出为 PPT、PDF 或 HTML，请参见[导出为 PPT、PPTX、PDF 和 HTML](/slides/zh/jasperreports/ppt-pptx-pdf-and-html-export/).