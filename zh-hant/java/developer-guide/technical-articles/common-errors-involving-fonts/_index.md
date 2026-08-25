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
## **概覽**

在 Linux 上使用 Aspose.Slides 時，如果 Java 進程無法存取所需的字體資料夾或臨時目錄、系統未安裝任何字體，或缺少 fontconfig、libfreetype 等必要的系統函式庫，可能會出現與字體相關的問題。

本文章說明 Linux 上常見的字體錯誤與例外，並提供解決方案。內容包括如何檢查對字體與 TEMP 目錄的存取權限、安裝所需的字體與函式庫，以及使用 `FontsLoader` 在不全域安裝字體的情況下載入字體。

## **在 Linux 上執行程式碼時缺少文字或圖像（EMF 或 WMF）**

此問題會在以下情況受限的系統中發生：

1. 系統未安裝任何字體，或 Java 進程無法存取字體資料夾  
2. 無法存取 TEMP 目錄

### **解決方案**

確認已授予對 TEMP 目錄與字體資料夾的存取權限。

{{% alert color="warning" %}}
在某些情況下，因環境或安全政策的限制，您可能無法為資料夾授權。請嘗試以下變通方法：
{{% /alert %}}

**變通方法**

使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader) 載入所需字體，而不必在系統層面安裝：

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

如果無法存取 TEMP 目錄，請使用以下程式碼為 Java 指定其他 TEMP 目錄：
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

## **例外：InvalidOperationException：找不到系統上安裝的任何字體**

發生此例外的原因：

1. Java 進程無法存取字體資料夾  
2. 系統未安裝任何字體

### **解決方案**

1. 確認已授予 Java 進程對字體資料夾的存取權限。  
2. 安裝字體或使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader)。  
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

   * 使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsLoader):

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **例外：InternalError：InvocationTargetException**

在 Linux 上將 PPTX 轉換為 PDF 時，可能會因 `java.lang.InternalError: java.lang.reflect.InvocationTargetException` 失敗。若底層錯誤顯示 `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`，表示 Linux 的字體設定不可用或其快取尚未初始化。

### **解決方案**

安裝 fontconfig 並重新建構字體快取：

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **例外：NoClassDefFoundError：無法初始化類別 com.aspose.slides.internal.ey.this**

此例外發生於缺少 fontconfig 與字體的 Linux 系統。

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

此外，某些 open‑jdk 版本（例如 **alpine JDK**）也 **需要安裝字體**。

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

## **例外：UnsatisfiedLinkError：libfreetype.so.6：無法開啟共享物件檔案：找不到檔案或目錄**

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
別忘了安裝字體或使用 FontsLoader。
{{% /alert %}}