---
title: Linux 上涉及字体的常见异常和错误
type: docs
weight: 200
url: /zh/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "字体异常, 字体错误, Linux, Java, Aspose.Slides for Java"
description: "Linux 上的字体异常和错误"
---
## **概述**

在 Linux 上使用 Aspose.Slides 时，如果 Java 进程无法访问所需的字体文件夹或临时目录，系统未安装字体，或缺少 fontconfig、libfreetype 等必需的系统库，可能会出现与字体相关的问题。

本文描述了 Linux 上常见的字体错误和异常，并提供了解决方案。本文说明了如何检查对字体和 TEMP 目录的访问权限，安装必需的字体和库，以及使用 `FontsLoader` 在不全局安装字体的情况下加载字体。

## **在 Linux 上执行代码时缺少文本或图像（EMF 或 WMF）**

当出现以下情况时会出现此问题：

1. 未安装任何字体或 Java 进程无法访问字体文件夹  
2. 无法访问 TEMP 目录  

### **解决方案**

检查并确认已授予对 TEMP 目录和字体文件夹的访问权限。

{{% alert color="warning" %}}
在某些情况下，受环境或安全策略限制，可能无法授予文件夹访问权限。请尝试以下变通方法：
{{% /alert %}}

**变通方法**

使用 [FontsLoader](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontsLoader) 加载所需字体，而无需全局安装：

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

如果无法访问 TEMP 目录，可使用以下代码为 Java 指定其他目录作为 TEMP：

```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **异常：InvalidOperationException：Cannot Find Any Fonts Installed on the System**

此异常在以下情况下出现：

1）Java 进程无法访问字体文件夹  
2）系统未安装任何字体  

### **解决方案**

1. 检查并确认已授予 Java 进程对字体文件夹的访问权限。  
2. 安装一些字体或使用 [FontsLoader](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontsLoader)。  
3. 安装字体。

   * Ubuntu:

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS:

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```

   * 使用 [FontsLoader](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontsLoader)：

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **异常：NoClassDefFoundError：Could Not Initialize Class com.aspose.slides.internal.ey.this**

此异常出现在缺少 fontconfig 和字体的 Linux 系统上。

### **解决方案**

安装 fontconfig：

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

此外，某些 open‑jdk 版本（例如 **alpine JDK**）也 **需要已安装的字体**。

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **异常：UnsatisfiedLinkError：libfreetype.so.6：Cannot Open Shared Object File：No Such File or Directory**

此异常出现在缺少 libfreetype 库的 Linux 系统上。

### **解决方案**

安装 libfreetype 和 fontconfig：

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="primary" %}} 
别忘了安装字体或使用 FontsLoader。 
{{% /alert %}}