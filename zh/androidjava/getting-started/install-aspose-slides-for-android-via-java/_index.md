---
title: 安装 Aspose.Slides for Android via Java
type: docs
weight: 90
url: /zh/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- 安装 Aspose.Slides
- 下载 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安装
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "快速安装 Aspose.Slides for Android。分步指南、系统要求和 Java 代码示例——立即开始使用 PowerPoint 演示文稿！"
---

## **安装**
以前，Aspose.Slides for Android via Java 以单个 ZIP 文件的形式分发，包含 JAR 文件、示例和产品文档。

1. 如果您想使用早于 Aspose.Words for Android via Java 18.9 的版本，需要将该版本的 Aspose.Slides.Android.zip 解压到您选择的目录中。
1. 使用 Build Path 配置将解压后的 Jar 文件添加到您的应用程序中。

### **添加对 Aspose.Slides for Android via Java Jar 的引用**
1. 下载最新版本的[Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/androidjava)
1. 将 aspose‑slides‑18.9‑android.via.java.jar 复制到项目的 *libs/* 文件夹中

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

### **从 Maven 仓库安装 Aspose.Slides for Android via Java**
1. 在您的 build.gradle 中添加 Maven 仓库。
1. 将 [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JAR 添加为依赖项。

``` java

 // 1. 将 Maven 仓库添加到您的 build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. 将 'Aspose.Slides for Android via Java' JAR 添加为依赖

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```

## **使用 Aspose.Slides for Android via Java 的第一个应用程序**
在本节中，您将学习如何入门 Aspose.Slides for Android via Java。我们将演示如何从头创建一个新的 Android 项目，添加对 Aspose.Slides JAR 的引用，并创建一个保存为 PPTX 格式的新 PowerPoint 演示文稿。示例使用 [Android Studio](https://developer.android.com/studio/index.html) 开发，应用程序在 Android 模拟器上运行。要开始使用 Aspose.Slides for Android via Java，请按照本分步教程创建一个使用该库的应用程序：

1. 下载并安装 [Android Studio](https://developer.android.com/studio/index.html) 到任意位置。
1. 运行 Android Studio。
1. 创建一个新的 Android 应用程序项目。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)

1. 将 aspose‑slides‑XX.XX‑android.via.java.jar 复制到项目的 libs/ 文件夹中

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

1. 选择 Project Section（文件菜单），点击 Dependencies 选项卡。
   1. 点击 “+” 按钮，选择文件依赖项选项。
   1. 从 libs 文件夹中选择 Aspose.Slides 库并点击 OK。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)

1. 如有必要，使用 Gradle 同步项目。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)

1. 为访问 SD 卡，需要添加特殊权限。打开 AndroidManifest.xml 文件，切换到 XML 视图。向文件中添加以下行 `<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />`

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)

1. 返回应用程序的代码区域，添加以下 import：

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment; 

```


现在，在 onCreate 方法体中插入以下代码，以使用 Aspose.Slides 从头创建一个新的 Presentation，并将其保存到 SD 卡的 PPTX 格式。

``` java

 try
{
    // 实例化表示 PPTX 的 Presentation 类
    Presentation pres = new Presentation();

    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加 TextFrame
    ashp.addTextFrame(" ");

    // 访问文本框架
    ITextFrame txtFrame = ashp.getTextFrame();

    // 为文本框架创建 Paragraph 对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 为段落创建 Portion 对象
    IPortion portion = para.getPortions().get_Item(0);

    // 设置文本
    portion.setText("Aspose TextBox");

    // 将 PPTX 保存到卡
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}
catch (Exception e)
{
   e.printStackTrace();
}
```


完整代码应如下所示：

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)

1. 重新运行应用程序。此时，Aspose.Slides 代码将在后台执行，并在 SD 卡上生成并保存文档。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. 要查看生成的文档，进入 Tools 菜单，选择 Android，然后选择 Android Device Monitor

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)

## **版本控制**
自 2018 年起，Aspose.Slides for Android via Java 的版本号遵循 Aspose.Slides for Java 的版本规则。

## **常见问题**

**如何验证 Aspose.Slides 已正确集成？**

构建项目，实例化一个空白的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 并以新名称保存。如果文件创建成功且未抛出异常，则说明库已成功集成。

**在处理大型演示文稿时，如何限制内存消耗？**

仅将 JVM 内存上限提升到所需的程度，并在 `finally` 块中关闭每个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 实例，以及时释放缓存。这可以防止内存不足错误，并在批量操作期间保持整体内存使用可预测。

**能否排除不需要的导出格式以缩小最终 JAR 大小？**

当前的 Aspose.Slides 发行版以单一整体库形式提供，无法在构建时禁用特定的导出器（如 PDF 或 SVG）。