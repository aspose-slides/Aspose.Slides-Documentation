---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /zh-hant/java/
keywords:
- 文件
- 簡報處理
- 簡報轉換
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "從此開始：安裝 Aspose.Slides for Java，建立第一個簡報，並查找常見任務、部署以及 API 參考的指南。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java 是一個類別庫，可在 Java 應用程式中建立、讀取、編輯和轉換 PowerPoint 與 OpenDocument 簡報，無需 Microsoft PowerPoint。

它可載入與儲存 PPT、PPTX、PPS、POT 與 ODP，包括支援巨集的與範本變體，並可匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 與影像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>入門指南</p>
<ul>
<li><a href="/slides/zh-hant/java/installation/">安裝</a></li>
<li><a href="/slides/zh-hant/java/create-presentation/">建立您的第一個簡報</a></li>
<li><a href="/slides/zh-hant/java/system-requirements/">系統需求</a></li>
<li><a href="/slides/zh-hant/java/getting-started/">入門指南</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/java/supported-file-formats/">支援的檔案格式</a></li>
<li><a href="/slides/zh-hant/java/features-overview/">功能概覽</a></li>
<li><a href="/slides/zh-hant/java/evaluate-aspose-slides/">試用限制</a></li>
<li><a href="/slides/zh-hant/java/licensing/">授權</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 建置</b></p>
<hr>
<p>常見任務</p>
<ul>
<li><a href="/slides/zh-hant/java/open-presentation/">開啟簡報</a></li>
<li><a href="/slides/zh-hant/java/save-presentation/">儲存簡報</a></li>
<li><a href="/slides/zh-hant/java/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/java/convert-slide/">將投影片渲染為影像</a></li>
<li><a href="/slides/zh-hant/java/manage-text/">編輯文字與形狀</a></li>
</ul>
<p>Slides 工作流程</p>
<ul>
<li><a href="/slides/zh-hant/java/powerpoint-charts/">圖表</a></li>
<li><a href="/slides/zh-hant/java/powerpoint-animation/">動畫</a></li>
<li><a href="/slides/zh-hant/java/manage-media-files/">音訊與影片</a></li>
<li><a href="/slides/zh-hant/java/presentation-design/">投影片設計</a></li>
<li><a href="/slides/zh-hant/java/merge-presentation/">合併簡報</a></li>
</ul>
<p>範例</p>
<ul>
<li><a href="/slides/zh-hant/java/examples/">依投影片元素的範例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">GitHub 上的範例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>部署與支援</b></p>
<hr>
<p>部署</p>
<ul>
<li><a href="/slides/zh-hant/java/system-requirements/#linux">Linux 前置條件</a></li>
<li><a href="/slides/zh-hant/java/how-to-run-aspose-slides-in-docker/">在 Docker 中執行</a></li>
<li><a href="/slides/zh-hant/java/deploy-fonts/">字型</a></li>
<li><a href="/slides/zh-hant/java/security/">安全性</a></li>
</ul>
<p>參考文件</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">API 參考文件</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">版本說明</a></li>
<li><a href="/slides/zh-hant/java/known-issues/">已知問題</a></li>
<li><a href="/slides/zh-hant/java/api-limitations/">輸出中繼資料限制</a></li>
<li><a href="https://products.aspose.com/slides/java/">產品頁面</a></li>
<li><a href="https://releases.aspose.com/slides/java/">下載</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援客服</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **您的第一個簡報**

Aspose.Slides for Java 發佈於 Aspose 自己的 Maven 儲存庫，而非 Maven Central。為 Maven 專案建立一個資料夾，並將此 *pom.xml* 儲存於其中。它宣告儲存庫、加入函式庫，並指定要執行的類別：

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloSlides</exec.mainClass>
    </properties>

    <repositories>
        <repository>
            <id>AsposeJavaAPI</id>
            <name>Aspose Java API</name>
            <url>https://releases.aspose.com/java/repo/</url>
        </repository>
    </repositories>

    <dependencies>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides</artifactId>
            <version>26.9</version>
            <classifier>jdk16</classifier>
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

將此程式碼儲存為 *src/main/java/HelloSlides.java*：

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // 建立一個簡報。它已包含一張空白投影片。
        Presentation presentation = new Presentation();
        try {
            // 取得第一張投影片。
            ISlide slide = presentation.getSlides().get_Item(0);

            // 新增雲形狀並在其中放入文字。
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // 將簡報儲存為 PPTX 檔案。
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

接著，在安裝了 JDK 11 或更新版本以及 Apache Maven 後，於專案資料夾中執行以下指令：

```bash
mvn compile exec:java
```

程式會將 *new_presentation.pptx* 儲存於專案資料夾，內含一張帶有雲形狀與文字的投影片。於 Linux 必須安裝 fontconfig 並至少一種字型；請參閱[Installation](/slides/zh-hant/java/installation/#linux)。未取得授權時，儲存的檔案會帶有評估水印 — 請參閱[Licensing](/slides/zh-hant/java/licensing/)。欲了解更多建立與填充簡報的方法，請參閱[Create Presentations](/slides/zh-hant/java/create-presentation/).