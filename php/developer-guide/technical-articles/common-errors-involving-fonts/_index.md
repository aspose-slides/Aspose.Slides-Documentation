---
title: Common Exceptions and Errors Involving Fonts on Linux
type: docs
weight: 200
url: /java/technical-articles/common-errors-involving-fonts
keywords: "Font exception, Font error, Linux, Java, Aspose.Slides for PHP via Java"
description: "Font exceptions and errors on Linux"
---

## **Missing text or images (emf or wmf) when code is executed on Linux**

This problem occurs in systems with restrictions in these cases:

1. When there are no fonts installed or when the font folder for the java process cannot be accessed
2. When the TEMP directory cannot be accessed.

### Solution

Check and confirm that access to the TEMP directory and the fonts folder has been granted. 

{{% alert color="warning" %}}

In some cases, you may be unable to grant access to folders due to restrictions imposed by the environment or a security policy. Try these workarounds: 

{{% /alert %}}

**Workaround**

Use [FontsLoader](https://reference.aspose.com/slides/php-java/com.aspose.slides/FontsLoader) to load the required fonts without installing them:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

If the TEMP directory cannot be accessed, use this code to specify another directory as the TEMP for Java:
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

## **Exception: InvalidOperationException: Cannot find any fonts installed on the system**

This exception occurs when

1) the Java process cannot access the fonts folder
2) no fonts have been installed.

### Solution

1. Check and confirm that access to the font folder for the Java process has been granted.

2. Install some fonts or use [FontsLoader](https://reference.aspose.com/slides/php-java/com.aspose.slides/FontsLoader).

3. Install fonts.

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

   * Using [FontsLoader](https://reference.aspose.com/slides/php-java/com.aspose.slides/FontsLoader):

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Exception: NoClassDefFoundError: Could not initialize class com.aspose.slides.internal.ey.this**

This exception occurs on a Linux system that lacks fontconfig and fonts. 

### Solution:

Install fontconfig:

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

Additionally, some open-jdk versions (for example, **alpine JDK**) also **require installed fonts**.

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

## **Exception: UnsatisfiedLinkError: libfreetype.so.6: cannot open shared object file: No such file or directory**

This exception occurs on a Linux system that lacks the libfreetype library. 

### Solution:

Install libfreetype and fontconfig:

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

Don't forget to install fonts or use FontsLoader.

{{% /alert %}}  
