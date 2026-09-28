---
title: 在 Android Studio 專案中安裝 Aspose.Slides for Android via Java
type: docs
weight: 90
url: /zh-hant/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- 安裝 Aspose.Slides
- 下載 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安裝
- Gradle
- Maven 套件庫
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Gradle 從 Aspose 的 Maven 套件庫將 Aspose.Slides for Android via Java 加入 Android Studio 專案，或手動加入 JAR 檔案。"
---
## **概述**

本文說明如何在 Android 專案中加入 Aspose.Slides for Android via Java。建議的方式是讓 Gradle 從 Aspose 的 Maven 儲存庫下載套件。也可以自行下載 JAR 檔並手動加入專案。

此套件未發布至 Maven Central 或 Google 的 Maven 儲存庫。它僅在 Aspose 自己的儲存庫中提供，artifact 為 `aspose-slides`，分類器為 `android.via.java`。

## **從 Aspose 的 Maven 儲存庫安裝**

### **步驟 1：新增儲存庫**

新的 Android Studio 專案會在 *settings.gradle.kts* 的 `dependencyResolutionManagement` 區塊中聲明其儲存庫，且 Gradle 會拒絕模組的 build 檔案自行加入的儲存庫。請將下方的 `maven` 行加入現有 `dependencyResolutionManagement` 區塊內的 `repositories` 區塊，而不是貼上第二個 `dependencyResolutionManagement` 區塊：

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **步驟 2：新增相依性**

在 app 模組的 build 檔 *app/build.gradle.kts* 的 `dependencies` 區塊中加入套件：

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

座標的最後一段 `android.via.java` 為選擇 Android 版套件的分類器。若省略此分類器，Gradle 將找不到該 artifact。

接著與 Gradle 檔案同步專案，使 Gradle 下載套件。

### **選擇版本**

Aspose.Slides for Android via Java 並非每個版本都有對應的建置。它只針對部分 Aspose.Slides for Java 版本發布 Android 版，若選擇沒有 Android 建置的版本將無法解析。請在 [Aspose.Slides for Android via Java 下載頁面](https://releases.aspose.com/slides/androidjava/) 中挑選版本。

### **Groovy 建置腳本**

如果專案使用 Groovy 建置腳本，請將 `maven` 行加入 *settings.gradle* 中現有 `dependencyResolutionManagement` 區塊的 `repositories` 區塊：

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

再將相依性加入 *app/build.gradle*：

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **手動新增 JAR 檔**

如果無法使用 Maven 儲存庫，請將 JAR 檔加入專案：

1. 從 [Aspose 的 Maven 儲存庫](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 中對應版本的資料夾下載 JAR 檔。以 26.9 版為例，檔名為 *aspose-slides-26.9-android.via.java.jar*，位於 *26.9* 資料夾內。
1. 將檔案複製到專案的 *app/libs* 資料夾；若資料夾不存在請自行建立。
1. 在 *app/build.gradle.kts* 的 `dependencies` 區塊中加入該檔案，然後同步專案：

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **建立第一個簡報**

專案同步完成後，請繼續參考 [建立簡報](/slides/zh-hant/androidjava/create-presentation/)。此範例會在投影片上加入文字方塊，並將簡報儲存至應用程式的私有儲存空間，無需儲存權限。若未授權，Aspose.Slides 會在每張投影片加入評估水印；詳情請見 [授權](/slides/zh-hant/androidjava/licensing/)。

## **版本資訊**

自 2018 年起，Aspose.Slides for Android via Java 的版本編號與 Aspose.Slides for Java 保持一致。Android 版不會為每個 Java 版發布；請參閱 [選擇版本](#choose-a-version)。

## **常見問題**

### 如何驗證 Aspose.Slides 是否正確整合？

建置專案，實例化一個空的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 並以新名稱儲存。若檔案能順利建立且未拋出例外，即表示套件已成功整合。

### 如何在處理大型簡報時限制記憶體使用量？

在 `finally` 區塊中呼叫每個 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 實例的 [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) 方法以立即釋放資源，並一次只處理一個大型簡報。此作法有助於防止記憶體不足錯誤，並在批次作業期間保持記憶體使用量可預測。

### 能否排除不需要的匯出格式以縮小最終 JAR 大小？

目前的 Aspose.Slides 版本皆以單一巨集檔案形式發行，無法在建置時停用特定匯出器（如 PDF 或 SVG）。