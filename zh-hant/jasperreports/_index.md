---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /zh-hant/jasperreports/
keywords:
- 文件說明
- JasperReports
- JasperReports Server
- 報表匯出
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "從此開始：安裝 Aspose.Slides for JasperReports，將第一個報表匯出為 PowerPoint，並找到有關匯出、JasperReports Server 整合與支援的指南。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports 為 JasperReports Library 與 JasperReports Server 添加了 PowerPoint 匯出功能，使 Java 應用程式和報表伺服器能在未安裝 Microsoft PowerPoint 的情況下，將已填寫的報表儲存為簡報。

它可以將已填寫的報表匯出為 PPT 和 PPTX（每個報表頁對應一張投影片），同時也支援匯出為 PDF 和 HTML。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>快速入門</p>
<ul>
<li><a href="/slides/zh-hant/jasperreports/installing-aspose-slides-for-jasperreports/">安裝</a></li>
<li><a href="/slides/zh-hant/jasperreports/product-overview/">產品概觀</a></li>
<li><a href="/slides/zh-hant/jasperreports/system-requirements/">系統需求</a></li>
<li><a href="/slides/zh-hant/jasperreports/getting-started/">入門指南</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/jasperreports/supported-file-formats/">支援的檔案格式</a></li>
<li><a href="/slides/zh-hant/jasperreports/evaluate-aspose-slides/">試用版限制</a></li>
<li><a href="/slides/zh-hant/jasperreports/licensing/">授權資訊</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 開發</b></p>
<hr>
<p>匯出</p>
<ul>
<li><a href="/slides/zh-hant/jasperreports/ppt-pptx-pdf-and-html-export/">匯出為 PPT、PPTX、PDF 與 HTML</a></li>
<li><a href="/slides/zh-hant/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">對應字型</a></li>
<li><a href="/slides/zh-hant/jasperreports/integration-with-jasperserver/">JasperReports Server 整合</a></li>
</ul>
<p>範例</p>
<ul>
<li><a href="/slides/zh-hant/jasperreports/demos-setup/">示範專案</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>參考與支援</b></p>
<hr>
<p>參考</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">發行說明</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">下載</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援服務台</a></li>
</ul>
</div>
</div>

------

## **您的第一次匯出**

以下步驟會編譯一個單行報表、填入資料，並使用來自 Maven Central 的 JasperReports 6.16.0 匯出為 PPTX。您需要 JDK 11 或更新版本，以及 Apache Maven。

1. 從[下載頁面](https://releases.aspose.com/slides/jasperreport/)下載 ZIP 並解壓縮。其 *lib* 資料夾依 JasperReports 版本區間劃分子資料夾，每個子資料夾內包含該區間的 jar。針對 JasperReports 6.16.0，將 *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* 複製到空的專案資料夾中。

2. jar 包隨 ZIP 一併提供，並未上傳至 Maven 儲存庫，請將其安裝至本機 Maven 儲存庫。於專案資料夾執行以下指令：

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. 將此 *pom.xml* 儲存於專案資料夾。它會加入 JasperReports 6.16.0 與您先前安裝的 jar，並指定要執行的類別。JasperReports 6.16.0 宣告了一個未在 Maven Central 上的修補版 iText，因此此檔案會將其排除；Aspose 匯出器不需要它。

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

4. 將此報表設計儲存為 *hello.jrxml*，放在專案資料夾中。它會在標題區段列印一行文字：

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

5. 將此程式碼儲存為 *src/main/java/HelloExport.java*。程式會編譯設計、以一筆空記錄填充，並使用 `ASPptxExporter` 匯出結果：

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
        // 編譯報表設計並以一筆空記錄填充。
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // 將已填充的報表匯出為 PPTX。
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. 於專案資料夾執行以下指令：

```bash
mvn compile exec:java
```

程式會在專案資料夾中產生 *hello.pptx*，其中的唯一投影片包含報表文字。編譯器會指出此程式碼使用了已棄用的 API：匯出器透過 `JRExporterParameter` 接收輸入與輸出，且不接受較新的 `setExporterInput` 與 `setExporterOutput` 設定。在 Linux 上必須安裝 fontconfig 與至少一種字型，否則填充報表會失敗。未授權時，每張投影片的中心會出現評估水印——請參閱[授權](/slides/zh-hant/jasperreports/licensing/)。若要匯出為 PPT、PDF 或 HTML，請參閱[PPT、PPTX、PDF 與 HTML 匯出](/slides/zh-hant/jasperreports/ppt-pptx-pdf-and-html-export/).