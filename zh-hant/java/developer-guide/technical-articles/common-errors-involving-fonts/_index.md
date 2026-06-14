---
title: Linux 上與字體相關的常見例外與錯誤
type: docs
weight: 200
url: /zh-hant/java/common-errors-involving-fonts/
keywords: "字體例外, 字體錯誤, Linux, Java, Aspose.Slides for Java"
description: "Linux 上的字體例外與錯誤"
---
## **概述**

當在 Linux 上使用 Aspose.Slides 時，如果 Java 程序無法存取所需的字體資料夾或暫存目錄、系統未安裝任何字體，或缺少 fontconfig 或 libfreetype 等所需的系統函式庫，可能會發生與字體相關的問題。

本文說明了 Linux 上與字體相關的常見錯誤與例外，並提供解決方案。它闡述了如何檢查對字體及 TEMP 目錄的存取權限、安裝所需的字體與函式庫，以及使用 `FontsLoader` 載入字體而無需在系統範圍內安裝它們。

## **在 Linux 執行程式碼時缺少文字或影像（EMF 或 WMF）**

此問題發生於具有限制的系統，情況如下：

1. 未安裝任何字體，或 Java 程序的字體資料夾無法存取時
2. TEMP 目錄無法存取時。

### **解決方案**

檢查並確認已獲得對 TEMP 目錄與字體資料夾的存取權限。 

{{% alert color="warning" %}}
在某些情況下，可能因環境或安全政策的限制而無法授予資料夾存取權限。請嘗試以下變通方法： 
{{% /alert %}}

**變通方法**

使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader) 載入所需的字體而無需安裝它們：

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

如果無法存取 TEMP 目錄，請使用以下程式碼將其他目錄指定為 Java 的 TEMP：

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

## **例外狀況：InvalidOperationException：無法在系統上找到任何已安裝的字體**

當出現以下情況時會拋出此例外：

1) Java 程序無法存取字體資料夾  
2) 系統未安裝任何字體。

### **解決方案**

1. 檢查並確認已授予 Java 程序對字體資料夾的存取權限。

2. 安裝一些字體或使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader)。

3. 安裝字體。

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

   * Using [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **例外狀況：NoClassDefFoundError：無法初始化類別 com.aspose.slides.internal.ey.this**

此例外發生於缺少 fontconfig 與字體的 Linux 系統上。

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

此外，某些 open-jdk 版本（例如 **alpine JDK**）亦 **需要已安裝的字體**。

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

## **例外狀況：UnsatisfiedLinkError：libfreetype.so.6：無法開啟共享物件檔案：系統找不到檔案**

此例外發生於缺少 libfreetype 函式庫的 Linux 系統上。

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

{{% alert title="TIP" color="primary" %}} 
請務必安裝字體或使用 FontsLoader。
{{% /alert %}}