---
title: 如何執行範例
type: docs
weight: 140
url: /zh-hant/php-java/how-to-run-the-examples/
keywords:
- 範例
- 軟體需求
- GitHub
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "快速執行 Aspose.Slides for PHP via Java 範例：克隆儲存庫、還原套件，然後建置並測試 PPT、PPTX 與 ODP 功能。"
---
## **從 GitHub 下載**
所有 Aspose.Slides for PHP via Java 的範例均託管於 [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java)。您可以使用喜愛的 Github 用戶端將倉儲克隆下來，或從 [here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) 下載 ZIP 檔案。

將 ZIP 檔案的內容解壓縮至電腦上的任意資料夾。所有範例都位於 **Examples** 資料夾中。

![todo:image_alt_text](examples_directory.png)

## **將範例匯入 IDE**
此專案使用 Maven 建置系統。任何現代 IDE 都能輕鬆開啟或匯入專案及其相依性。以下示範如何使用常見的 IDE 來建置並執行範例。

### **IntelliJ IDEA**
點選 **File** 功能表並選擇 **Open**。瀏覽至專案資料夾並選取 **pom.xml** 檔案。

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

它會自動開啟專案並下載相依性。從 Project 分頁，瀏覽 **src/main/java** 資料夾中的範例。要執行範例，只需右鍵點擊檔案並選擇「Run ..」，範例將被執行，且輸出會顯示於內建的主控台視窗。

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
點選 **File** 功能表並選擇 **Import**。選取 **Maven** - Existing Maven Projects。

![todo:image_alt_text](eclipse_import.png)

瀏覽至您從 GitHub 克隆或下載的資料夾，選取 **pom.xml** 檔案。它會自動開啟專案並下載相依性。從 Package Explorer 分頁，瀏覽 **src/main/java** 資料夾中的範例。要執行範例，只需右鍵點擊檔案並選擇 **Run As** - **Java Application**，範例將被執行，且輸出會顯示於內建的主控台視窗。

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
點選 **File** 功能表並選擇 **Open Project**。瀏覽至您從 GitHub 克隆或下載的資料夾。**Examples** 資料夾的圖示會顯示它是 Maven 專案。選取 Examples 並開啟。

![todo:image_alt_text](netbeans_openproject.png)

它會自動開啟專案並下載相依性。從 Projects 分頁，瀏覽 **source packages** 中的範例。要執行範例，只需右鍵點擊檔案並選擇 **Run File**，範例將被執行，且輸出會顯示於內建的主控台視窗。

![todo:image_alt_text](netbeans_run_example.png)

## **將 Aspose.Slides 函式庫加入 Maven 本機儲存庫**
當您將 **Aspose.Slides Examples** 專案匯入 IDE 時，Maven 會自動從 [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/) 下載 aspose.slides JAR 檔案。若無法連線至網際網路，您可以手動將 JAR 加入本機儲存庫。

### **mvn install**
下載 [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/)，解壓縮後將 aspose.slides-version.jar 複製至其他位置，例如 C 磁碟。執行以下指令：

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

現在，**aspose.slides** JAR 已被複製至您的 Maven 本機儲存庫。

### **pom.xml**
安裝完成後，只需在 pom.xml 中宣告 **aspose.slides** 的坐標。於 repositories 頁籤加入以下儲存庫，於 dependencies 頁籤加入相依性。

```xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php

### **Done**
編譯它，現在 **aspose.slides** JAR 可以從您的 Maven 本機儲存庫中取得。

## **Contribute**
如果您想新增或改進範例，我們鼓勵您為此專案貢獻。此儲存庫中的所有範例與示範專案皆為開源，且可自由用於您的應用程式中。

要貢獻，您可以 Fork 此儲存庫、編輯原始碼，並提交 Pull Request。我們會審查變更，若有幫助則會將其納入儲存庫。