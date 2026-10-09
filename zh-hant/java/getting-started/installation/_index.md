---
title: 安裝
type: docs
weight: 70
url: /zh-hant/java/installation/
keywords:
- 安裝 Aspose.Slides
- 下載 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安裝
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "從 Aspose 的 Maven 套件庫或以 JAR 檔案安裝 Aspose.Slides for Java，設定 Linux 前置需求，並使用第一個程式檢查安裝是否成功。"
---
## **概覽**

本文說明如何將 Aspose.Slides for Java 加入專案。Aspose.Slides for Java 授權於 Aspose 自己的 Maven 套件庫，而非 Maven Central， 因此 Maven 專案必須宣告該套件庫。您也可以自行下載 JAR 檔並放入類別路徑。兩種方式最終都會執行一個簡短程式，以驗證程式庫可正常運作。

Aspose.Slides for Java 不需要 Microsoft PowerPoint。它會以程式方式產生所需的簡報檔案。然而，要檢視產生的簡報，可能需要 Microsoft PowerPoint 或其他簡報檢視器。

## **先決條件**

- Java Development Kit（JDK）。本文章中的專案與指令需要 JDK 11 或更新版本。在 JDK 11 上，檢查安裝的程式會印出以「WARNING: An illegal reflective access operation has occurred」開頭的警告；此警告不會影響結果，可忽略。
- [Apache Maven](https://maven.apache.org/install.html)，如果您使用 Maven 方式。
- 在 Linux 上，需要 fontconfig 函式庫以及至少一種已安裝的字型。請參閱 [Linux](#linux)。

## **從 Maven 套件庫安裝**

Aspose 將其 Java 函式庫託管於自己的 [Maven 套件庫](https://releases.aspose.com/java/repo/com/aspose/)。若要在 Maven 專案中使用 [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)，請在 *pom.xml* 中新增兩個條目。

1. **宣告 Aspose Maven 套件庫。**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **新增 Aspose.Slides for Java 相依性。**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

`jdk8` classifier 為必需項目：它會選擇 Java SE 版的函式庫。將 `26.10` 替換為 [套件庫](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 中列出的最新版本。套件庫會在每個 JAR 旁邊發布 SHA-1 檢查碼檔案，Maven 在下載函式庫時會驗證該檔案。

### **檢查安裝**

使用新專案檢查設定：

1. 為專案建立資料夾，並將此 *pom.xml* 儲存於其中：

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.10</version>
               <classifier>jdk8</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   除了套件庫與相依性之外，這個 *pom.xml* 會設定要編譯的 Java 版本、指定 `mvn exec:java` 執行的類別，並鎖定編譯器外掛，因為某些 Maven 安裝預設使用的舊版外掛會忽略 `maven.compiler.release` 設定。

2. 將 [建立簡報](/slides/zh-hant/java/create-presentation/) 中的第一個範例另存為 *src/main/java/HelloSlides.java*。

3. 在專案資料夾中執行：

   ```bash
   mvn compile exec:java
   ```

Maven 會下載 Aspose.Slides for Java，編譯程式，並執行它。程式會將 *new_presentation.pptx* 儲存於專案資料夾中。

## **在未使用 Maven 時使用 JAR 檔案**

1. 從套件庫中的 [版本資料夾](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) 下載 *aspose-slides-26.10-jdk8.jar*。若要其他版本，請在 [套件庫](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 開啟相應的資料夾，下載以 *-jdk8.jar* 結尾的檔案。

2. 將 [建立簡報](/slides/zh-hant/java/create-presentation/) 中的第一個範例另存為 *HelloSlides.java*，放在與 JAR 檔相同的資料夾內。

3. 在該資料夾中執行：

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK 會編譯並執行這個單一來源檔案，程式會將 *new_presentation.pptx* 儲存在該資料夾中。於您自己的應用程式中，請將 JAR 檔加入建置工具或 IDE 的類別路徑。

## **Linux**

Aspose.Slides for Java 依賴 Java 的字型支援，在 Linux 上需要 fontconfig 函式庫以及至少一種已安裝的字型。若缺少這些，儲存簡報時會出現錯誤「Fontconfig head is null, check your fonts or fonts configuration」。最小化的伺服器與容器映像檔可能都沒有這些；例如官方的 Ubuntu 容器映像檔就兩者皆無。

在 Debian 和 Ubuntu 上，這個指令安裝 JDK、Maven、fontconfig 與 DejaVu 字型：

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

您的簡報所使用的字型，或合適的替代字型，也必須安裝，才能正確呈現文字。

## **常見問題**

### 如何驗證已正確整合 Aspose.Slides？

建置您的專案，建立一個空的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 實例，並以新名稱保存。若檔案能在未拋出例外的情況下建立，即表示函式庫已成功整合。

### 如何在處理大型簡報時限制記憶體使用？

僅將 JVM 記憶體上限提升至實際需求的程度，並在 `finally` 區塊中對每個 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 實例呼叫 [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) 以立即釋放快取。此作法可防止記憶體不足錯誤，並在批次作業期間保持整體記憶體使用的可預測性。

### 是否可以排除不需要的匯出格式以減小最終 JAR 大小？

目前的 Aspose.Slides 版本以單一巨集函式庫方式發佈，故在建置時無法停用特定匯出器（例如 PDF 或 SVG）。