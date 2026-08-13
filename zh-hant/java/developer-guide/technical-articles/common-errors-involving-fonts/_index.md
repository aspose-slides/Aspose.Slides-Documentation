---
title: Linux 上與字型相關的常見例外與錯誤
type: docs
weight: 200
url: /zh-hant/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "字型例外, 字型錯誤, Linux, Java, Aspose.Slides for Java"
description: "Linux 上的字型例外與錯誤"
---
## **概覽**

在 Linux 上使用 Aspose.Slides 時，如果 Java 進程無法存取所需的字型資料夾或暫存目錄、系統未安裝任何字型，或缺少必要的系統函式庫（如 fontconfig 或 libfreetype），可能會發生與字型相關的問題。

本文說明了 Linux 上與字型相關的常見錯誤與例外，並提供解決方案。內容包括如何檢查對字型與 TEMP 目錄的存取權限、安裝必要的字型與函式庫，以及使用 `FontsLoader` 於不安裝系統字型的情況下載入字型。

## **在 Linux 執行程式碼時缺少文字或圖像（EMF 或 WMF）**

此問題發生於以下受限制的情況：

1. 系統未安裝字型，或 Java 進程無法存取字型資料夾  
2. 無法存取 TEMP 目錄

### **解決方案**

檢查並確認已授予對 TEMP 目錄與字型資料夾的存取權限。

{{% alert color="warning" %}}

在某些情況下，可能因環境或安全政策的限制而無法授予資料夾存取權限。請嘗試以下變通方法：

{{% /alert %}}

**變通方法**

使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader) 載入所需字型，而不必安裝到系統：

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

如果無法存取 TEMP 目錄，可使用以下程式碼將另一個目錄指定為 Java 的 TEMP：

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

## **例外：InvalidOperationException：找不到系統上安裝的任何字型**

此例外發生於：

1) Java 進程無法存取字型資料夾  
2) 系統未安裝任何字型

### **解決方案**

1. 檢查並確認已授予 Java 進程對字型資料夾的存取權限。

2. 安裝一些字型或使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader)。

3. 安裝字型。

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

   * 使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader):  

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **例外：NoClassDefFoundError：無法初始化類別 com.aspose.slides.internal.ey.this**

此例外發生於缺少 fontconfig 與字型的 Linux 系統。

### **解決方案**

安裝 fontconfig：

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

另外，某些 open‑jdk 版本（例如 **alpine JDK**）亦 **需要安裝字型**。

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

## **例外：UnsatisfiedLinkError：libfreetype.so.6：無法開啟共享物件檔案：沒有此檔案或目錄**

此例外發生於缺少 libfreetype 函式庫的 Linux 系統。

### **解決方案**

安裝 libfreetype 與 fontconfig：

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

別忘了安裝字型或使用 FontsLoader。

{{% /alert %}}