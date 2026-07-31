---
title: Linux 上與字體相關的常見例外與錯誤
type: docs
weight: 200
url: /zh-hant/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "字體例外, 字體錯誤, Linux, Java, Aspose.Slides for Java"
description: "Linux 上的字體例外與錯誤"
---
## **概觀**

在 Linux 上使用 Aspose.Slides 時，如果 Java 程序無法存取所需的字體資料夾或暫存目錄、系統上未安裝任何字體，或缺少 fontconfig 或 libfreetype 等必要的系統函式庫，可能會發生與字體相關的問題。

本文說明了 Linux 上常見的字體錯誤與例外情形，並提供解決方案。內容包括如何檢查對字體與 TEMP 目錄的存取權限、安裝所需的字體與函式庫，以及使用 `FontsLoader` 在不安裝系統字體的情況下載入字體。

## **在 Linux 執行程式碼時缺少文字或圖像 (EMF 或 WMF)**

此問題發生於以下受限制的情況：

1. 系統未安裝字體或 Java 程序無法存取字體資料夾
2. 無法存取 TEMP 目錄

### **解決方案**

檢查並確認已取得對 TEMP 目錄與字體資料夾的存取權限。

{{% alert color="warning" %}}

在某些情況下，可能因環境或安全政策的限制而無法授予資料夾存取權限。可嘗試以下變通方法：

{{% /alert %}}

**變通方法**

使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader) 載入所需的字體而不必安裝到系統：

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

若無法存取 TEMP 目錄，可使用以下程式碼為 Java 指定其他目錄作為 TEMP：
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

## **例外狀況：InvalidOperationException：找不到系統上安裝的任何字體**

當發生以下情形時會拋出此例外：

1. Java 程序無法存取字體資料夾
2. 系統未安裝任何字體

### **解決方案**

1. 檢查並確認已取得 Java 程序對字體資料夾的存取權限。

2. 安裝一些字體或使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader)。

3. 安裝字體。

   * Ubuntu：

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS：

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```

   * 使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader)：

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **例外狀況：NoClassDefFoundError：無法初始化類別 com.aspose.slides.internal.ey.this**

此例外發生於缺少 fontconfig 與字體的 Linux 系統。

### **解決方案**

安裝 fontconfig：

* Ubuntu：

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
```

* CentOS：

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
```

此外，某些 open-jdk 版本（例如 **alpine JDK**）亦 **需要已安裝的字體**。

* Ubuntu：

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
```

* CentOS：

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
```

## **例外狀況：UnsatisfiedLinkError：libfreetype.so.6：無法開啟共享物件檔案：找不到檔案或目錄**

此例外發生於缺少 libfreetype 函式庫的 Linux 系統。

### **解決方案**

安裝 libfreetype 與 fontconfig：

* Ubuntu：

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
```

* CentOS：

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
```

{{% alert title="TIP" color="primary" %}} 

別忘了安裝字體或使用 FontsLoader。

{{% /alert %}}