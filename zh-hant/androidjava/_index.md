---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /zh-hant/androidjava/
keywords:
- 文件
- 簡報處理
- 簡報轉換
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "從此開始：將 Aspose.Slides for Android via Java 添加到您的應用程式，建立第一個簡報，並查找常見任務指南、API 參考與支援。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java 是一個類別庫，可在 Android 應用程式中建立、讀取、編輯與轉換 PowerPoint 與 OpenDocument 簡報，無需 Microsoft PowerPoint。

它可以載入與儲存 PPT、PPTX、PPS、POT 與 ODP，包含含巨集及範本的變體，並匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 以及影像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>開始上手</p>
<ul>
<li><a href="/slides/zh-hant/androidjava/install-aspose-slides-for-android-via-java/">安裝</a></li>
<li><a href="/slides/zh-hant/androidjava/create-presentation/">建立您的第一個簡報</a></li>
<li><a href="/slides/zh-hant/androidjava/getting-started/">入門指南</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/androidjava/supported-file-formats/">支援的檔案格式</a></li>
<li><a href="/slides/zh-hant/androidjava/evaluate-aspose-slides/">試用限制</a></li>
<li><a href="/slides/zh-hant/androidjava/licensing/">授權資訊</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 建置</b></p>
<hr>
<p>常見任務</p>
<ul>
<li><a href="/slides/zh-hant/androidjava/open-presentation/">開啟簡報</a></li>
<li><a href="/slides/zh-hant/androidjava/save-presentation/">儲存簡報</a></li>
<li><a href="/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/androidjava/convert-slide/">將投影片渲染成影像</a></li>
<li><a href="/slides/zh-hant/androidjava/manage-text/">編輯文字與圖形</a></li>
</ul>
<p>Slides 工作流程</p>
<ul>
<li><a href="/slides/zh-hant/androidjava/powerpoint-charts/">圖表</a></li>
<li><a href="/slides/zh-hant/androidjava/powerpoint-animation/">動畫</a></li>
<li><a href="/slides/zh-hant/androidjava/manage-media-files/">音訊與影片</a></li>
<li><a href="/slides/zh-hant/androidjava/presentation-design/">投影片設計</a></li>
<li><a href="/slides/zh-hant/androidjava/merge-presentation/">合併簡報</a></li>
</ul>
<p>範例</p>
<ul>
<li><a href="/slides/zh-hant/androidjava/examples/">依投影片元素分類的範例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>參考與支援</b></p>
<hr>
<p>參考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API 參考</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">發行說明</a></li>
<li><a href="/slides/zh-hant/androidjava/known-issues/">已知問題</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">產品頁面</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">下載</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援服務台</a></li>
</ul>
</div>
</div>

------

## **您的第一個簡報**

此函式庫來自 Aspose 的 Maven 套件庫。新的 Android Studio 專案已在 *settings.gradle.kts* 中具備 `dependencyResolutionManagement` 區塊。請將下方的 `maven` 行加入其中的 `repositories` 區塊，而非貼上第二個區塊：

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

然後將函式庫加入 *app/build.gradle.kts* 並同步專案：

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[安裝](/slides/zh-hant/androidjava/install-aspose-slides-for-android-via-java/) 介紹 Groovy 建置腳本、手動 JAR 檔，以及如何選擇版本。您的第一個簡報程式碼位於 [建立簡報](/slides/zh-hant/androidjava/create-presentation/)：它會在投影片上新增文字方塊，並將簡報儲存至應用程式的儲存空間。此範例已編譯並建置成 APK；尚未在裝置上執行。若未取得授權，儲存的簡報會加上評估水印——請參閱 [授權資訊](/slides/zh-hant/androidjava/licensing/).