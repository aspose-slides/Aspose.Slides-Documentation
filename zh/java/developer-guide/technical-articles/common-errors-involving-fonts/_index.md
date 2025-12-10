---
title: Linux 上与字体相关的常见异常和错误
type: docs
weight: 200
url: /zh/java/technical-articles/common-errors-involving-fonts
keywords: "字体异常, 字体错误, Linux, Java, Aspose.Slides for Java"
description: "Linux 上的字体异常和错误"
---

## **在 Linux 上执行代码时缺少文本或图像（EMF 或 WMF）**

此问题在以下受限情况下出现：

1. 当未安装任何字体或 java 进程的字体文件夹无法访问时
2. 当 TEMP 目录无法访问时。

### **解决方案**

检查并确认已授权访问 TEMP 目录和字体文件夹。 

{{% alert color="warning" %}}
在某些情况下，由于环境或安全策略的限制，您可能无法授权访问文件夹。请尝试以下解决方法： 
{{% /alert %}}

**解决方法**

使用[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader)加载所需字体，而无需安装它们：
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


## **异常：InvalidOperationException：无法在系统中找到任何已安装的字体**

当出现以下情况时会抛出此异常：

1. Java 进程无法访问字体文件夹
2. 系统未安装任何字体。

### **解决方案**

1. 检查并确认已授权 Java 进程访问字体文件夹。

2. 安装一些字体或使用[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader)。

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


   * 使用[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader):
     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```


## **异常：NoClassDefFoundError：无法初始化类 com.aspose.slides.internal.ey.this**

此异常在缺少 fontconfig 和字体的 Linux 系统上出现。

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


此外，某些 open-jdk 版本（例如 **alpine JDK**）也 **需要已安装的字体**。

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


## **异常：UnsatisfiedLinkError：libfreetype.so.6：无法打开共享对象文件：没有此类文件或目录**

此异常在缺少 libfreetype 库的 Linux 系统上出现。

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
不要忘记安装字体或使用 FontsLoader。
{{% /alert %}}