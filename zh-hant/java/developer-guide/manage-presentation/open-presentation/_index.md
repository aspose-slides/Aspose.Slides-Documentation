---
title: 在 Java 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/java/open-presentation/
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
- Java
- Aspose.Slides
description: "了解如何在 Java 中開啟 PowerPoint 與 OpenDocument 簡報、提供開啟密碼、控制資源載入，並使用 Aspose.Slides for Java 減少記憶體使用。"
---
## **簡介**

[Aspose.Slides for Java](https://products.aspose.com/slides/zh-hant/java/) 可以從檔案和串流載入 PowerPoint 和 OpenDocument 簡報。載入簡報後，您可以檢查其結構、編輯投影片、管理資源，並以原始或其他支援的格式儲存。

載入行為可以透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/) 類別自訂。例如，您可以提供開啟密碼、將大型二進位物件保留在 Java 堆積記憶體之外、控制外部資源，或省略嵌入的二進位資料。

## **開啟簡報**

若要開啟現有簡報，將其檔案路徑傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 建構式。使用完畢後請釋放 (Dispose) 簡報，以便及時釋放檔案代碼、暫存資料與其他資源。

以下 Java 範例示範如何開啟簡報並取得投影片數量：

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

開啟密碼會加密簡報內容。若要載入完整簡報，請將正確的密碼傳遞給 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)，並將此選項提供給 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 建構式。若密碼缺失或不正確，載入將失敗。

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

有關密碼偵測、驗證與加密工作流程，請參閱 [Password-Protect Presentations](/slides/zh-hant/java/password-protected-presentation/)。如果加密的簡報特意以公開文件屬性儲存，則可在未提供密碼的情況下讀取這些屬性；請參閱 [Manage Presentation Properties](/slides/zh-hant/java/presentation-properties/)。

## **開啟大型簡報**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 會回傳控制 Aspose.Slides 處理二進位大型物件（如影像、音訊、視訊）的選項。您可以保持來源檔案鎖定、允許暫存檔案，並限制記憶體中保留的 BLOB 資料量。

以下 Java 程式碼示範載入大型簡報（例如 2 GB）：

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

{{% alert color="info" title="注意" %}}
使用 [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) 時，來源檔案會保持鎖定，直到釋放簡報實例為止。在該實例存活期間，請勿移動、覆寫或刪除來源檔案。

Aspose.Slides 可能在載入時複製輸入串流的內容。對於大型簡報，檔案路徑通常比串流更有效率。請參閱 [Manage BLOBs](/slides/zh-hant/java/manage-blob/) 以取得其他儲存與記憶體管理選項。
{{% /alert %}}

## **控制外部資源**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) 接受一個 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iresourceloadingcallback/) 的實作。回呼可提供替代資料、重新導向資源、使用預設載入器，或跳過該資源。當簡報包含必須依照特定應用程式安全或儲存規則解決的外部影像時，這非常有用。

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

簡報可能包含應用程式不需要或不想保留的嵌入二進位資料。例子包括：

- VBA 專案，可透過 [IPresentation.getVbaProject](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getVbaProject--) 取得；
- 嵌入的 OLE 資料，可透過 [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) 取得；
- ActiveX 控制項資料，可透過 [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) 取得。

將 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) 設為 `true`，即可在載入時移除這些二進位資料。將載入後的簡報儲存，以保留已清理的結果。

此選項可減少不必要的嵌入負載風險，但它並非完整的惡意程式偵測或內容清理系統。

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

**如果缺少必要的字型會發生什麼情況？**

簡報仍可載入，但渲染與匯出時可能會替代字型。您可以 [configure font substitution](/slides/zh-hant/java/font-substitution/) 或 [provide custom fonts](/slides/zh-hant/java/custom-font/) 以使輸出更可預測。

**載入簡報時是否同時載入其嵌入的媒體？**

嵌入的音訊與視訊可透過簡報物件模型取得。外部資源會依設定的資源載入行為解析；若無法存取其位置，則可能無法取得。