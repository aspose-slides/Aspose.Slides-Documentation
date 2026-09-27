---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /zh/androidjava/
keywords:
- 文档
- 演示文稿处理
- 演示文稿转换
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "从这里开始：将 Aspose.Slides for Android via Java 添加到您的应用程序，创建第一个演示文稿，并查找常见任务的指南、API 参考和支持。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java 是一个类库，可在 Android 应用程序中创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint。

它可以加载和保存 PPT、PPTX、PPS、POT 和 ODP，包括带宏的和模板变体，并可导出为 PDF、XPS、HTML、SVG、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>入门</b></p>
<hr>
<p>快速入门</p>
<ul>
<li><a href="/slides/zh/androidjava/install-aspose-slides-for-android-via-java/">安装</a></li>
<li><a href="/slides/zh/androidjava/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/androidjava/getting-started/">入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/androidjava/supported-file-formats/">受支持的文件格式</a></li>
<li><a href="/slides/zh/androidjava/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/androidjava/licensing/">授权</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>常见任务</p>
<ul>
<li><a href="/slides/zh/androidjava/open-presentation/">打开演示文稿</a></li>
<li><a href="/slides/zh/androidjava/save-presentation/">保存演示文稿</a></li>
<li><a href="/slides/zh/androidjava/convert-powerpoint-to-pdf/">转换为 PDF</a></li>
<li><a href="/slides/zh/androidjava/convert-slide/">将幻灯片渲染为图像</a></li>
<li><a href="/slides/zh/androidjava/manage-text/">编辑文本和形状</a></li>
</ul>
<p>Slides 工作流</p>
<ul>
<li><a href="/slides/zh/androidjava/powerpoint-charts/">图表</a></li>
<li><a href="/slides/zh/androidjava/powerpoint-animation/">动画</a></li>
<li><a href="/slides/zh/androidjava/manage-media-files/">音频和视频</a></li>
<li><a href="/slides/zh/androidjava/presentation-design/">幻灯片设计</a></li>
<li><a href="/slides/zh/androidjava/merge-presentation/">合并演示文稿</a></li>
</ul>
<p>示例</p>
<ul>
<li><a href="/slides/zh/androidjava/examples/">按幻灯片元素划分的示例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考与支持</b></p>
<hr>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/zh/androidjava/">API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/zh/androidjava/release-notes/">发行说明</a></li>
<li><a href="/slides/zh/androidjava/known-issues/">已知问题</a></li>
<li><a href="https://releases.aspose.com/slides/zh/androidjava/">下载</a></li>
</ul>
<p>支持</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/zh/11">免费支持论坛</a></li>
<li><a href="https://helpdesk.aspose.com/">付费支持帮助台</a></li>
</ul>
</div>
</div>

------

## **您的第一个演示文稿**

该库来自 Aspose 的 Maven 仓库。新的 Android Studio 项目已经在 *settings.gradle.kts* 中拥有 `dependencyResolutionManagement` 块。请将下面显示的 `maven` 行添加到其中的 `repositories` 块，而不是粘贴第二个块：

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

然后将库添加到 *app/build.gradle.kts* 并同步项目：

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/zh/androidjava/install-aspose-slides-for-android-via-java/) 包含 Groovy 构建脚本、手动 JAR 文件以及如何选择版本的说明。您的第一个演示文稿的代码位于 [Create Presentations](/slides/zh/androidjava/create-presentation/) 页面：它向幻灯片添加一个文本框并将演示文稿保存到应用的存储中。该示例已编译并构建成 APK；尚未在设备上运行。没有许可证时，保存的演示文稿会带有评估水印——请参阅 [Licensing](/slides/zh/androidjava/licensing/)。