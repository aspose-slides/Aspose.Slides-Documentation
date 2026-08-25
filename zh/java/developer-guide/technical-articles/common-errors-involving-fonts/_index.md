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

在 Linux 上使用 Aspose.Slides 时，如果 Java 进程无法访问所需的字体文件夹或临时目录，系统未安装任何字体，或缺少必需的系统库（如 fontconfig 或 libfreetype），则可能会出现与字体相关的问题。

本文介绍了 Linux 上常见的字体错误和异常，并提供了解决方案。它说明了如何检查对字体和 TEMP 目录的访问权限，如何安装所需的字体和库，以及如何使用 `FontsLoader` 在不全局安装字体的情况下加载字体。

## **在 Linux 上执行代码时缺少文本或图像（EMF 或 WMF）**

此问题在以下受限情况下会出现：

1. 系统未安装字体或 Java 进程无法访问字体文件夹  
2. 无法访问 TEMP 目录

### **解决方案**

检查并确认已授权访问 TEMP 目录和字体文件夹。

{{% alert color="warning" %}}
在某些情况下，由于环境或安全策略的限制，可能无法为文件夹授予访问权限。请尝试以下变通方法：
{{% /alert %}}

**变通方案**

使用 [FontsLoader](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontsLoader) 在不安装字体的情况下加载所需字体：

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

如果无法访问 TEMP 目录，请使用以下代码为 Java 指定另一个 TEMP 目录：

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

## **异常：InvalidOperationException：找不到系统中安装的任何字体**

此异常在以下情况下出现：

1) Java 进程无法访问字体文件夹  
2) 系统未安装任何字体

### **解决方案**

1. 检查并确认已授权 Java 进程访问字体文件夹。  
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

## **异常：InternalError：InvocationTargetException**

在 Linux 上将 PPTX 文件转换为 PDF 时，可能会出现 `java.lang.InternalError: java.lang.reflect.InvocationTargetException`。如果底层错误显示 `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`，则表示 Linux 字体配置不可用或其缓存尚未初始化。

### **解决方案**

安装 fontconfig 并重新生成字体缓存：

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **异常：NoClassDefFoundError：Could Not Initialize Class com.aspose.slides.internal.ey.this**

此异常发生在缺少 fontconfig 和字体的 Linux 系统上。

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

此异常发生在缺少 libfreetype 库的 Linux 系统上。

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

{{% alert title="TIP" color="info" %}} 
请务必安装字体或使用 FontsLoader。 
{{% /alert %}}