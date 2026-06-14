---
title: 安裝 Aspose.Slides for Android via Java
type: docs
weight: 90
url: /zh-hant/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- 安裝 Aspose.Slides
- 下載 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安裝
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "快速安裝 Aspose.Slides for Android。一步一步的指南、系統需求與 Java 程式碼範例——立即開始使用 PowerPoint 簡報！"
---
## **概述**

本文說明如何於 Android 以 Java 安裝 Aspose.Slides 並將其加入 Android 專案。文章描述兩種安裝方式：手動將 Aspose.Slides JAR 檔加入專案，以及從 Maven 套件庫安裝此函式庫。

另外，本文提供一步步範例，示範如何在 Android Studio 中建立新的 Android 應用程式、參考 Aspose.Slides 函式庫、以程式碼建立 PowerPoint 簡報，並以 PPTX 格式儲存。內容亦包含版本說明以及常見問題的解答，說明如何驗證整合、管理記憶體使用量，以及縮減最終 JAR 檔大小。

## **安裝**
以前，Aspose.Slides for Android via Java 以單一 ZIP 檔提供，內含 JAR 檔、示範程式與產品說明文件。

1. 若要使用早於 Aspose.Words for Android via Java 18.9 的版本，必須將 Aspose.Slides.Android.zip 解壓至您偏好的目錄。 
1. 使用 Build Path 設定將解壓後的 Jar 檔加入您的應用程式。 
### **將 Aspose.Slides for Android via Java Jar 加入參考**
1. 下載最新版本的 [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/zh-hant/androidjava) 
1. 將 aspose-slides-18.9-android.via.java.jar 複製到專案的 *libs/* 資料夾

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **從 Maven 套件庫安裝 Aspose.Slides for Android via Java**
1. 將 Maven 套件庫加入您的 build.gradle。 
1. 將 [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JAR 作為相依性加入。

``` java

 // 1. 將 Maven 套件庫加入您的 build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. 將 'Aspose.Slides for Android via Java' JAR 加入為相依性

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}
```
## **使用 Aspose.Slides for Android via Java 的第一個應用程式**
在本節中，您將學習如何開始使用 Aspose.Slides for Android via Java。我們將示範如何從頭建立新的 Android 專案、加入 Aspose.Slides JAR 參考，並建立一個會儲存為 PPTX 格式的 PowerPoint 簡報。此範例使用 [Android Studio](https://developer.android.com/studio/index.html) 進行開發，並在 Android 模擬器上執行。請依照以下步驟教學，建立使用 Aspose.Slides for Android via Java 的應用程式：

1. 下載並安裝 [Android Studio](https://developer.android.com/studio/index.html) 到任意位置。 
1. 執行 Android Studio。 
1. 建立新的 Android Application 專案。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)

1. 將 aspose-slides-XX.XX-android.via.java.jar 複製到專案的 libs/folder

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

1. 在檔案選單中選取 **Project** 區段，然後點擊 **Dependencies** 分頁。  
   1. 點擊 “+” 按鈕，選取 **File dependency**。  
   1. 從 libs 資料夾選擇 Aspose.Slides 函式庫，然後按 **OK**。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)

1. 如有需要，與 Gradle 檔案同步專案。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)

1. 若要存取 SD 卡，必須加入特殊權限。開啟 AndroidManifest.xml 檔案並切換至 XML 檢視，將以下行加入檔案 `<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />`

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)

1. 回到應用程式的程式碼區段，加入以下匯入：

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment; 

```

現在，將以下程式碼插入 `onCreate` 方法的主體，使用 Aspose.Slides 從頭建立新的 Presentation，並以 PPTX 格式儲存至 SD 卡。

``` java

 try
{
    // 實例化代表 PPTX 的 Presentation 類別
    Presentation pres = new Presentation();

    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增矩形類型的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 為矩形新增 TextFrame
    ashp.addTextFrame(" ");

    // 取得文字框架
    ITextFrame txtFrame = ashp.getTextFrame();

    // 為文字框建立 Paragraph 物件
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 為段落建立 Portion 物件
    IPortion portion = para.getPortions().get_Item(0);

    // 設定文字
    portion.setText("Aspose TextBox");

    // 將 PPTX 儲存至卡片
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}
catch (Exception e)
{
   e.printStackTrace();
}
```

完整程式碼如下所示：

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)

1. 再次執行應用程式。此時，Aspose.Slides 程式碼會在背景執行，產生文件並儲存至 SD 卡。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. 若要檢視已建立的文件，前往 **Tools** 功能表，選取 **Android**，再選擇 **Android Device Monitor**。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **版本說明**
自 2018 年起，Aspose.Slides for Android via Java 的版本編號遵循 Aspose.Slides for Java。

## **常見問題**

**如何驗證 Aspose.Slides 已正確整合？**

編譯您的專案，建立一個空的 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 並以新名稱儲存。若檔案能順利產生且未拋出例外，即表示函式庫已成功整合。

**在處理大型簡報時，如何限制記憶體使用量？**

僅將 JVM 記憶體上限提升到必要的程度，並在 `finally` 區塊中關閉每個 [Presentation] 實例，以立即釋放快取。此做法可防止記憶體不足錯誤，並在批次作業期間保持記憶體使用量可預測。

**能否排除不需要的匯出格式以縮減最終 JAR 檔大小？**

目前的 Aspose.Slides 版號皆以單一巨集式函式庫形式提供，無法在建置時停用特定匯出器（例如 PDF 或 SVG）。