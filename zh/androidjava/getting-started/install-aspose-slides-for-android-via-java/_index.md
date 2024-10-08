---
title: 通过 Java 安装 Aspose.Slides for Android
type: docs
weight: 90
url: /zh/androidjava/install-aspose-slides-for-android-via-java/
---




## **安装**
以前，Aspose.Slides for Android 通过 Java 作为一个单独的 ZIP 文件分发，该 ZIP 文件包含 JAR 文件、演示和产品文档。

1. 如果您想使用早于 Aspose.Words for Android 通过 Java 18.9 的版本，则需要将该版本的 Aspose.Slides.Android.zip 解压缩到您选择的目录中。
1. 通过使用构建路径配置将提取的 JAR 文件添加到您的应用程序中。
### **添加对 Aspose.Slides for Android 通过 Java JAR 的引用**
1. 下载最新版本的 [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/androidjava)
1. 将 aspose-slides-18.9-android.via.java.jar 复制到项目的 *libs/* 文件夹中

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **从 Maven 仓库安装 Aspose.Slides for Android 通过 Java**
1. 在您的 build.gradle 中添加 Maven 仓库。
1. 将 [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JAR 作为依赖项添加。

``` java

 // 1. 在您的 build.gradle 中添加 Maven 仓库 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. 将 'Aspose.Slides for Android via Java' JAR 作为依赖项添加

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **使用 Aspose.Slides for Android 通过 Java 的第一个应用程序**
在本节中，您将学习如何开始使用 Aspose.Slides for Android 通过 Java。我们打算向您展示如何从头开始设置一个新的 Android 项目，添加对 Aspose.Slides JAR 的引用，并创建一个保存为 PPTX 格式的新的 PowerPoint 演示文稿。这里的示例使用 [Android Studio](https://developer.android.com/studio/index.html) 进行开发，应用程序在 Android 模拟器上运行。要开始使用 Aspose.Slides for Android 通过 Java，请按照此逐步教程创建一个使用 Aspose.Slides for Android 通过 Java 的应用程序：

1. 下载 [Android Studio](https://developer.android.com/studio/index.html) 并安装到任意位置。
1. 运行 Android Studio。
1. 创建一个新的 Android 应用程序项目。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. 将 aspose-slides-XX.XX-android.via.java.jar 复制到项目的 libs/ 文件夹中

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. 从文件菜单中选择项目部分，点击依赖关系选项卡。
   1. 点击 "+" 按钮。选择文件依赖项选项。
   1. 从 libs 文件夹中选择 Aspose.Slides 库并点击 OK。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. 如有必要，使用 Gradle 文件同步项目。 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. 要访问 SD 卡，必须添加特殊权限。点击 AndroidManifest.xml 文件并选择 XML 视图。将此行添加到文件中 <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. 返回应用程序的代码部分并添加以下导入： 

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

现在，将此代码插入到 onCreate 方法的主体中，以使用 Aspose.Slides 创建一个新的演示文稿并将其以 PPTX 格式保存到 SD 卡。

``` java

 try

{

    // 实例化表示 PPTX 的 Presentation 类

    Presentation pres = new Presentation();



    // 访问第一个幻灯片

    ISlide sld = pres.getSlides().get_Item(0);



    // 添加一个矩形类型的 AutoShape

    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // 向矩形添加 TextFrame

    ashp.addTextFrame(" ");



    // 访问文本框

    ITextFrame txtFrame = ashp.getTextFrame();



    // 为文本框创建段落对象

    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // 为段落创建 Portion 对象

    IPortion portion = para.getPortions().get_Item(0);



    // 设置文本

    portion.setText("Aspose TextBox");



    // 将 PPTX 保存到卡中

    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;

    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);

}

catch (Exception e)

{

   e.printStackTrace();

}

```

完整代码应该如下所示：

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. 现在再次运行应用程序。这一次，Aspose.Slides 代码将在后台运行并生成保存到 SD 卡的文档。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. 要查看创建的文档，请导航到工具菜单。选择 Android，然后选择 Android 设备监视器。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **版本控制**
自2018年起，Aspose.Slides for Android 通过 Java 的版本控制遵循 Aspose.Slides for Java。