---
title: 通过 Java 为 Android 安装 Aspose.Slides
type: docs
weight: 90
url: /zh/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- 安装 Aspose.Slides
- 下载 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安装
- Gradle
- Maven 仓库
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "通过 Gradle 从 Aspose 的 Maven 仓库将 Aspose.Slides for Android via Java 添加到 Android Studio 项目，或手动添加 JAR 文件。"
---
## **概述**

本文说明如何将 Aspose.Slides for Android via Java 添加到 Android 项目中。推荐的方式是让 Gradle 从 Aspose 的 Maven 仓库下载该库。您也可以手动下载 JAR 文件并将其添加到项目中。

该库未发布到 Maven Central 或 Google 的 Maven 仓库。它可从 Aspose 的专用仓库获取，作为带有 `android.via.java` 分类器的 `aspose-slides` 工件。

## **从 Aspose 的 Maven 仓库安装**

### **步骤 1：添加仓库**

新的 Android Studio 项目在 *settings.gradle.kts* 的 `dependencyResolutionManagement` 块中声明其仓库，Gradle 会拒绝模块构建文件中添加的仓库。请将下面显示的 `maven` 行添加到该块内部的 `repositories` 块中，而不是粘贴第二个 `dependencyResolutionManagement` 块：

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

### **步骤 2：添加依赖**

将库添加到应用模块的构建文件 *app/build.gradle.kts* 的 `dependencies` 块中：

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

坐标的最后部分 `android.via.java` 是选择库的 Android 构建的分类器。没有它，Gradle 无法找到该工件。

然后使用 Gradle 文件同步项目，以便 Gradle 下载该库。

### **选择版本**

Aspose.Slides for Android via Java 并非为仓库中的每个版本构建。它仅针对部分 Aspose.Slides for Java 版本发布构建，缺少 Android 构建的版本将解析失败。请选择列在 [Aspose.Slides for Android via Java 下载页面](https://releases.aspose.com/slides/zh/androidjava/) 的版本。

### **Groovy 构建脚本**

如果您的项目使用 Groovy 构建脚本，请将 `maven` 行添加到 *settings.gradle* 中现有 `dependencyResolutionManagement` 块内部的 `repositories` 块中：

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

并将依赖添加到 *app/build.gradle* 中：

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **手动添加 JAR 文件**

如果无法使用 Maven 仓库，请将 JAR 文件添加到项目中：

1. 从 [Aspose 的 Maven 仓库](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 的对应版本文件夹下载 JAR 文件。对于 26.9 版本，文件为 *aspose-slides-26.9-android.via.java.jar*，位于 *26.9* 文件夹中。
2. 将文件复制到项目的 *app/libs* 文件夹中。如果该文件夹不存在，请创建它。
3. 将文件添加到 *app/build.gradle.kts* 的 `dependencies` 块中，然后同步项目：

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **创建您的第一个演示文稿**

项目同步后，继续阅读 [创建演示文稿](/slides/zh/androidjava/create-presentation/)。该示例的第一个例子向幻灯片添加文本框并将演示文稿保存到应用的私有存储，无需存储权限。未提供许可证时，Aspose.Slides 会在每个保存的幻灯片上添加评估水印；请参阅 [许可](/slides/zh/androidjava/licensing/)。

## **版本管理**

自 2018 年起，Aspose.Slides for Android via Java 的版本号遵循 Aspose.Slides for Java 的版本规则。并非每个 Java 版本都有对应的 Android 构建；请参阅 [选择版本](#choose-a-version)。

## **常见问题**

### 如何验证 Aspose.Slides 已正确集成？

构建项目，实例化一个空的 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 并以新名称保存。如果文件创建成功且未抛出异常，则说明库已成功集成。

### 在处理大型演示文稿时，如何限制内存消耗？

在 `finally` 块中调用每个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 实例的 [dispose](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#dispose--) 方法，及时释放其资源，并一次只处理一个大型演示文稿。这有助于防止内存不足错误，并在批处理操作期间保持整体内存使用可预测。

### 我能排除不需要的导出格式以减小最终 JAR 大小吗？

当前的 Aspose.Slides 发行版以单一整体库形式提供，无法在构建时禁用诸如 PDF 或 SVG 等特定导出器。