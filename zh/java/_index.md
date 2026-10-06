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
description: "从这里开始：安装 Aspose.Slides for Java，创建第一个演示文稿，并查找常见任务、部署和 API 参考的指南。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java 是一个类库，可在 Java 应用程序中创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint。

它支持加载和保存 PPT、PPTX、PPS、POT 和 ODP，包括带宏的和模板变体，并可导出为 PDF、XPS、HTML、SVG、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------


<div class="row">
<div class="col-md-4">
<p><b>入门</b></p>
<hr>
<p>快速入门</p>
<ul>
<li><a href="/slides/zh/java/installation/">安装</a></li>
<li><a href="/slides/zh/java/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/java/system-requirements/">系统要求</a></li>
<li><a href="/slides/zh/java/getting-started/">入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/java/supported-file-formats/">受支持的文件格式</a></li>
<li><a href="/slides/zh/java/features-overview/">功能概览</a></li>
<li><a href="/slides/zh/java/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/java/licensing/">授权</a></li>
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
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">GitHub 上的示例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>部署与支持</b></p>
<hr>
<p>部署</p>
<ul>
<li><a href="/slides/zh/java/system-requirements/#linux">Linux 前置条件</a></li>
<li><a href="/slides/zh/java/how-to-run-aspose-slides-in-docker/">在 Docker 中运行</a></li>
<li><a href="/slides/zh/java/deploy-fonts/">字体</a></li>
<li><a href="/slides/zh/java/security/">安全性</a></li>
</ul>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/zh/java/">API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/zh/java/release-notes/">发布说明</a></li>
<li><a href="/slides/zh/java/known-issues/">已知问题</a></li>
<li><a href="/slides/zh/java/api-limitations/">输出元数据限制</a></li>
<li><a href="https://releases.aspose.com/slides/zh/java/">下载</a></li>
</ul>
<p>支持</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/zh/11">免费支持论坛</a></li>
<li><a href="https://helpdesk.aspose.com/">付费支持帮助台</a></li>
</ul>
</div>
</div>

------


<a name="your-first-presentation"></a>

## **您的第一个演示文稿**

Aspose.Slides for Java 在 Aspose 自己的 Maven 仓库发布，而非 Maven Central。为 Maven 项目创建一个文件夹，并在其中保存此 *pom.xml*。该文件声明了仓库、添加了库，并指定要运行的类：

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
        // 创建演示文稿。它已经包含一个空幻灯片。
        Presentation presentation = new Presentation();
        try {
            // 获取第一张幻灯片。
            ISlide slide = presentation.getSlides().get_Item(0);

            // 添加云形状并在其中放入文本。
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

随后，在已安装 JDK 11 或更高版本和 Apache Maven 的情况下，在项目文件夹中运行以下命令：

```bash
mvn compile exec:java
```

该程序将在项目文件夹中保存 *new_presentation.pptx*，其中包含一个带有文本的云形状幻灯片。 在 Linux 上，必须安装 fontconfig 并至少一种字体；请参阅[安装](/slides/zh/java/installation/#linux)。 未授权情况下，保存的文件会带有评估水印——请参阅[授权](/slides/zh/java/licensing/)。 欲了解更多创建和填充演示文稿的方法，请参阅[创建演示文稿](/slides/zh/java/create-presentation/)。