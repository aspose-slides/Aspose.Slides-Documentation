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
description: "從 Aspose 的 Maven 套件庫或 JAR 檔安裝 Aspose.Slides for Java，設定 Linux 前置條件，並以第一個程式檢查安裝是否成功。"
---
## **概觀**

本文說明如何將 Aspose.Slides for Java 新增至專案中。Aspose.Slides for Java 於 Aspose 自己的 Maven 套件庫中發布，而非 Maven Central，故 Maven 專案必須聲明該套件庫。您也可以自行下載 JAR 檔並放入 class path。兩種方式最終都會執行一段短程式，以確認函式庫能正常運作。

Aspose.Slides for Java 不需要 Microsoft PowerPoint。它會以程式方式產生必要的簡報檔案。然而，要檢視產生的簡報，可能仍須 Microsoft PowerPoint 或其他簡報檢視程式。

## **先決條件**

- Java Development Kit (JDK)。本篇文章中的專案與指令需要 JDK 11 或更新版本。使用 JDK 11 時，檢查安裝的程式會顯示以「WARNING: An illegal reflective access operation has occurred」開頭的警告；此警告不會影響結果，可忽略。
- [Apache Maven](https://maven.apache.org/install.html)，若您使用 Maven 方式。
- 在 Linux 上，需要 fontconfig 函式庫以及至少一種已安裝的字型。請參閱[Linux](#linux)。

## **從 Maven 套件庫安裝**

Aspose 於其自行的 [Maven 套件庫](https://releases.aspose.com/java/repo/com/aspose/) 中提供 Java 函式庫。若要在 Maven 專案中使用 [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)，請在 *pom.xml* 中加入兩個條目。

1. **聲明 Aspose Maven 套件庫。**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **加入 Aspose.Slides for Java 相依性。**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

必須使用 `jdk16` classifier：它會選取 Java SE 版的函式庫。將 `26.9` 替換為[套件庫](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 中列出的最新版本。套件庫會在每個 JAR 旁發布 SHA-1 檢查碼檔案，Maven 會在下載函式庫時驗證此檔案。

### **檢查安裝**

使用新專案檢查設定：

1. 為專案建立資料夾，並將以下 *pom.xml* 儲存於該資料夾：

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
               <version>26.9</version>
               <classifier>jdk16</classifier>
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

   除了套件庫與相依性之外，這個 *pom.xml* 會設定要編譯的 Java 版號、指定 `mvn exec:java` 要執行的類別，並明確 pin 版本的 compiler plugin，因為某些 Maven 安裝預設使用的舊版 plugin 會忽略 `maven.compiler.release` 設定。

2. 將[建立簡報](/slides/zh-hant/java/create-presentation/)中的第一個範例儲存為 *src/main/java/HelloSlides.java*。

3. 在專案資料夾中執行：

   ```bash
   mvn compile exec:java
   ```

Maven 會下載 Aspose.Slides for Java、編譯程式並執行。程式會在專案資料夾中產生 *new_presentation.pptx*。

## **不使用 Maven 的 JAR 檔使用方式**

1. 從[版本資料夾](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/)下載 *aspose-slides-26.9-jdk16.jar*。若需其他版本，請在[套件庫](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 中開啟相應資料夾，下載以 *-jdk16.jar* 結尾的檔案。
2. 將[建立簡報](/slides/zh-hant/java/create-presentation/)中的第一個範例儲存為 *HelloSlides.java*，與 JAR 檔放在同一資料夾。
3. 在該資料夾中執行：

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK 會編譯並執行單一來源檔，程式會在該資料夾中產生 *new_presentation.pptx*。在您的應用程式中，請將 JAR 檔加入建置工具或 IDE 的 class path。

## **Linux**

Aspose.Slides for Java 依賴 Java 的字型支援，於 Linux 必須安裝 fontconfig 函式庫以及至少一種字型。若缺少上述項目，儲存簡報時會出現「Fontconfig head is null, check your fonts or fonts configuration」錯誤。許多最小化的伺服器與容器映像都不包含這兩者；例如官方的 Ubuntu 容器映像就沒有。

在 Debian 與 Ubuntu 上，可使用以下指令安裝 JDK、Maven、fontconfig 以及 DejaVu 字型：

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

還必須安裝您簡報中使用的字型，或相容的替代字型，才能正確呈現文字。

## **常見問題**

### 如何驗證 Aspose.Slides 已正確整合？

編譯您的專案，建立一個空的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 並以新檔名儲存。若檔案能在未拋出例外的情況下建立，即表示函式庫已成功整合。

### 在處理大型簡報時，如何限制記憶體消耗？

只將 JVM 記憶體上限提升到必要的程度，並在 `finally` 區塊中對每個 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 例項呼叫 [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--)，以即時釋放快取。此作法可防止記憶體不足錯誤，並在批次作業期間維持可預測的總記憶體使用量。

### 能否排除不需要的匯出格式以縮小最終 JAR 大小？

目前的 Aspose.Slides 版本以單一整合函式庫方式發布，無法在建置時停用特定匯出器（例如 PDF 或 SVG）。