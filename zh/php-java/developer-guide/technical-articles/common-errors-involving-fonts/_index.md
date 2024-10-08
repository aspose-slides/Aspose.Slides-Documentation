---
title: 在Linux上与字体有关的常见异常和错误
type: docs
weight: 200
url: /php-java/technical-articles/common-errors-involving-fonts
keywords: "字体异常, 字体错误, Linux, Java, Aspose.Slides for PHP via Java"
description: "Linux上的字体异常和错误"
---

## **在Linux上执行代码时缺少文本或图像（emf或wmf）**

此问题在以下限制的系统中发生：

1. 当没有安装字体或Java进程无法访问字体文件夹时
2. 当TEMP目录无法访问时。

### 解决方案

检查并确认已授予对TEMP目录和字体文件夹的访问权限。

{{% alert color="warning" %}}

在某些情况下，由于环境或安全策略施加的限制，您可能无法授予对文件夹的访问权限。尝试以下解决方法：

{{% /alert %}}

**解决方法**

使用[FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader)加载所需字体而无需安装它们：

```php

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

```

如果TEMP目录无法访问，请使用此代码指定另一个目录作为Java的TEMP：
```php

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
    # ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```php

```

## **异常：InvalidOperationException：找不到安装在系统上的任何字体**

当发生以下情况时，会出现此异常：

1）Java进程无法访问字体文件夹
2）未安装任何字体。

### 解决方案

1. 检查并确认已授予Java进程对字体文件夹的访问权限。

2. 安装一些字体或使用[FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader)。

3. 安装字体。

   * Ubuntu:

```php

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```php

     ```

   * CentOS:

```php

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```php

     ```

   * 使用[FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader):

```php

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

     ```

## **异常：NoClassDefFoundError：无法初始化类com.aspose.slides.internal.ey.this**

此异常发生在缺少fontconfig和字体的Linux系统上。

### 解决方案：

安装fontconfig：

* Ubuntu:

```php

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS:

```php

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
```php

  ```

此外，一些open-jdk版本（例如，**alpine JDK**）也**需要安装字体**。

* Ubuntu:

```php

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
```php

  ```

* CentOS:

```php

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
```php

  ```

## **异常：UnsatisfiedLinkError：libfreetype.so.6：无法打开共享对象文件：没有这样的文件或目录**

此异常发生在缺少libfreetype库的Linux系统上。

### 解决方案：

安装libfreetype和fontconfig：

* Ubuntu:

```php

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS:

```php

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
```php

  ```

{{% alert title="提示" color="primary" %}} 

不要忘记安装字体或使用FontsLoader。

{{% /alert %}}  