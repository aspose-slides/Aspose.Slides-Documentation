---
title: 在 Android 上開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/androidjava/open-presentation/
keywords:
- 開啟 PowerPoint
- 開啟簡報
- 開啟 PPTX
- 開啟 PPT
- 開啟 ODP
- 載入簡報
- 載入 PPTX
- 載入 PPT
- 載入 ODP
- 受保護的簡報
- 大型簡報
- 外部資源
- 二進位物件
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上開啟 PowerPoint 和 OpenDocument 簡報、提供開啟密碼、控制資源載入，並使用 Aspose.Slides for Android via Java 減少記憶體使用。"
---
## **簡介**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/zh-hant/androidjava/) 可以從檔案和串流載入 PowerPoint 與 OpenDocument 簡報。載入簡報後，您可以檢查其結構、編輯投影片、管理資源，並以原始或其他支援的格式儲存。

可以透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/) 類別自訂載入行為。例如，您可以提供開啟密碼、將大型二進位物件保留在 Java 堆外、控制外部資源，或省略內嵌的二進位資料。

## **開啟簡報**

載入檔案或串流後，您可以[確定其原始簡報格式](/slides/zh-hant/androidjava/detect-presentation-source-format/)，以決定應用程式的處理方式。

要開啟現有簡報，將其檔案路徑傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 建構函式。使用完畢後請釋放簡報，以便即時釋放檔案句柄、暫存資料及其他資源。

以下 Java 程式碼示範如何開啟簡報並取得投影片數量：

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **開啟受密碼保護的簡報**

開啟密碼會加密簡報內容。若要載入完整簡報，請將正確的密碼傳遞給 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)，並將選項提供給 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 建構函式。若密碼遺漏或不正確，載入將失敗。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

若需密碼偵測、驗證與加密工作流程，請參閱[密碼保護簡報](/slides/zh-hant/androidjava/password-protected-presentation/)。如果已加密的簡報故意以公開文件屬性儲存，這些屬性可在不提供密碼的情況下讀取；請參閱[管理簡報屬性](/slides/zh-hant/androidjava/presentation-properties/)。

## **開啟大型簡報**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 會回傳控制 Aspose.Slides 處理二進位大型物件（如影像、音訊與視訊）的選項。您可以將來源檔案保持鎖定、允許暫存檔案，並限制保留在記憶體中的 BLOB 資料量。

以下 Java 程式碼示範如何載入大型簡報（例如 2 GB）：

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
使用 [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) 時，來源檔案會保持鎖定，直至釋放簡報實例。請勿在該實例仍在使用時移動、覆寫或刪除來源檔案。

Aspose.Slides 可能在載入時複製輸入串流的內容。對於大型簡報而言，檔案路徑通常比串流更有效率。請參閱[管理 BLOBs](/slides/zh-hant/androidjava/manage-blob/)取得額外的儲存與記憶體管理選項。
{{% /alert %}}

## **控制外部資源**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) 接受 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iresourceloadingcallback/) 的實作。回呼函式可以提供替代資料、重新導向資源、使用預設載入器，或跳過該資源。當簡報包含必須依據應用程式特定安全或儲存規則解析的外部影像時，此功能相當有用。

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **載入不含嵌入二進位物件的簡報**

簡報可能包含應用程式不需要或不想保留的嵌入二進位資料。例如：

- VBA 專案，可透過 [IPresentation.getVbaProject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) 取得；
- 嵌入的 OLE 資料，可透過 [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) 取得；
- ActiveX 控制項資料，可透過 [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) 取得。

將 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) 設為 `true`，即可在載入時移除這些二進位資料。將載入後的簡報儲存以保留已清理的結果。

此選項可降低不必要的嵌入式負載風險，但其並非完整的惡意程式偵測或內容清理系統。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**如何判斷檔案已損毀且無法開啟？**

Aspose.Slides 會在載入期間拋出解析或格式例外。請將此失敗與密碼錯誤的例外分開處理，以便應用程式能正確回報原因。

**如果缺少所需字體會發生什麼情況？**

簡報仍可載入，但在渲染與匯出時可能會替換字體。您可以[設定字體替換](/slides/zh-hant/androidjava/font-substitution/)或[提供自訂字體](/slides/zh-hant/androidjava/custom-font/)，以使輸出更可預測。

**載入簡報時是否同時載入其嵌入媒體？**

嵌入的音訊與視訊可透過簡報物件模型存取。外部資源會依照設定的資源載入行為解析，若無法存取其位置則可能無法使用。