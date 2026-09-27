---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /zh/java/
keywords:
- 文档
- 演示文稿处理
- 演示文稿转换
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "从这里开始：安装 Aspose.Slides for Java，创建第一个演示文稿，并查找常见任务指南、API 参考和支持。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java 是一个类库，用于在 Java 应用程序中创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint。

它可以加载和保存 PPT、PPTX、PPS、POT 和 ODP，包括支持宏的和模板变体，并可导出为 PDF、XPS、HTML、SVG、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>快速入门</b></p>
<hr>
<p>入门指南</p>
<ul>
<li><a href="/slides/zh/java/installation/">安装</a></li>
<li><a href="/slides/zh/java/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/java/getting-started/">入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/java/supported-file-formats/">支持的文件格式</a></li>
<li><a href="/slides/zh/java/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/java/licensing/">许可</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>常见任务</p>
<ul>
<li><a href="/slides/zh/java/open-presentation/">打开演示文稿</a></li>
<li><a href="/slides/zh/java/save-presentation/">保存演示文稿</a></li>
<li><a href="/slides/zh/java/convert-powerpoint-to-pdf/">转换为 PDF</a></li>
<li><a href="/slides/zh/java/convert-slide/">将幻灯片渲染为图像</a></li>
<li><a href="/slides/zh/java/manage-text/">编辑文本和形状</a></li>
</ul>
<p>Slides 工作流</p>
<ul>
<li><a href="/slides/zh/java/powerpoint-charts/">图表</a></li>
<li><a href="/slides/zh/java/powerpoint-animation/">动画</a></li>
<li><a href="/slides/zh/java/manage-media-files/">音频和视频</a></li>
<li><a href="/slides/zh/java/presentation-design/">幻灯片设计</a></li>
<li><a href="/slides/zh/java/merge-presentation/">合并演示文稿</a></li>
</ul>
<p>示例</p>
<ul>
<li><a href="/slides/zh/java/examples/">按幻灯片元素的示例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">GitHub 示例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考与支持</b></p>
<hr>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">发行说明</a></li>
<li><a href="/slides/zh/java/known-issues/">已知问题</a></li>
<li><a href="https://releases.aspose.com/slides/java/">下载</a></li>
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

Aspose.Slides for Java 在 Aspose 自己的 Maven 仓库中发布，而不是在 Maven Central。为 Maven 项目创建一个文件夹，并将此 *pom.xml* 保存到该文件夹中。它声明了仓库，添加了库，并指定要运行的类：

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

将此代码保存为 *src/main/java/HelloSlides.java*：

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // 创建一个演示文稿。它已经包含一个空幻灯片。
        Presentation presentation = new Presentation();
        try {
            // 获取第一张幻灯片。
            ISlide slide = presentation.getSlides().get_Item(0);

            // 添加一个云形状并在其中放入文本。
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // 将演示文稿保存为 PPTX 文件。
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

然后，在已安装 JDK 11 或更高版本以及 Apache Maven 的情况下，在项目文件夹中运行以下命令：

```bash
mvn compile exec:java
```

程序将在项目文件夹中保存 *new_presentation.pptx*，其中包含一个带有文本的云形状幻灯片。在 Linux 上，必须安装 fontconfig 并至少安装一种字体；请参阅[Installation](/slides/zh/java/installation/#linux)。如果没有许可证，保存的文件会带有评估水印——请参阅[Licensing](/slides/zh/java/licensing/)。更多创建和填充演示文稿的方法，请参阅[Create Presentations](/slides/zh/java/create-presentation/).