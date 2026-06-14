---
title: 在 Android 上開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/androidjava/open-presentation/
keywords:
- 開啟 PowerPoint
- 開啟 OpenDocument
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
description: "使用 Aspose.Slides for Android 透過 Java 輕鬆開啟 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）簡報——快速、可靠、功能完整。"
---
## **簡介**

除了從頭建立 PowerPoint 簡報外，Aspose.Slides 也允許您開啟現有的簡報。載入簡報後，您可以取得其資訊、編輯投影片內容、加入新投影片、移除現有投影片等。

## **開啟簡報**

若要開啟現有簡報，請實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別，並將檔案路徑傳入其建構函式。

以下 Java 範例說明如何開啟簡報並取得投影片數量：

```java
// 實例化 Presentation 類別並將檔案路徑傳入其建構函式。
Presentation presentation = new Presentation("Sample.pptx");
try {
    // 列印簡報中投影片的總數。
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **開啟受密碼保護的簡報**

當需要開啟受密碼保護的簡報時，請透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/) 類別的 [setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 方法傳入密碼，以進行解密並載入。以下 Java 程式碼示範此操作：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // 在已解密的簡報上執行操作。
} finally {
    presentation.dispose();
}
```

## **開啟大型簡報**

Aspose.Slides 提供多種選項，尤其是 [LoadOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/) 類別中的 [getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 方法，協助您載入大型簡報。

以下 Java 程式碼示範載入大型簡報（例如 2 GB）：

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// 選擇 KeepLocked 行為—簡報檔案在其生命週期內將保持鎖定
// Presentation 實例，但不需要載入到記憶體中或複製到暫存檔案。
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // 大型簡報已載入且可使用，同時記憶體消耗保持低水平。

    // 對簡報進行變更。
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // 將簡報儲存為另一個檔案。在此操作期間，記憶體消耗保持低水平。
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // 不要這麼做！會拋出 I/O 例外，因為檔案在釋放 presentation 物件之前會被鎖定。
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// 此處執行是可以的。來源檔案已不再被 presentation 物件鎖定。
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
為了解決使用串流時的某些限制，Aspose.Slides 可能會複製串流的內容。從串流載入大型簡報會導致簡報被複製，進而降低載入速度。因此，若需要載入大型簡報，我們強烈建議使用簡報檔案路徑，而非串流。

在建立包含大型物件（影片、音訊、高解析度影像等）的簡報時，您可以使用 [BLOB management](/slides/zh-hant/androidjava/manage-blob/) 以減少記憶體使用量。
{{%/alert %}}

## **控制外部資源**

Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iresourceloadingcallback/) 介面，讓您管理外部資源。以下 Java 程式碼示範如何使用 `IResourceLoadingCallback` 介面：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // 載入替代影像。
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // 使用任意方法取得位元組
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 設定替代 URL。
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // 跳過所有其他影像。
        return ResourceLoadingAction.Skip;
    }
}
```

## **載入不含內嵌二進位物件的簡報**

PowerPoint 簡報可能包含以下類型的內嵌二進位物件：

- VBA 專案（可透過 [IPresentation.getVbaProject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) 存取）；
- OLE 物件內嵌資料（可透過 [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) 存取）；
- ActiveX 控制項二進位資料（可透過 [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) 存取）。

使用 [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) 方法，即可載入不含任何內嵌二進位物件的簡報。

此方法有助於移除可能的惡意二進位內容。以下 Java 程式碼示範如何載入不含任何內嵌二進位內容的簡報：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // 在簡報上執行操作。
} finally {
    presentation.dispose();
}
```

## **常見問答**

**如何判斷檔案已損壞且無法開啟？**

載入時會拋出解析/格式驗證例外。此類錯誤通常會提及無效的 ZIP 結構或損壞的 PowerPoint 記錄。

**開啟時若缺少必要字型，會發生什麼情況？**

檔案仍會開啟，但之後的 [rendering/export](/slides/zh-hant/androidjava/convert-presentation/) 可能會替換字型。請於執行環境中 [Configure font substitutions](/slides/zh-hant/androidjava/font-substitution/) 或 [add the required fonts](/slides/zh-hant/androidjava/custom-font/)。

**開啟時嵌入的媒體（影片/音訊）會怎樣？**

它們會作為簡報資源可供使用。若媒體是透過外部路徑引用，請確保這些路徑在您的環境中可存取；否則在 [rendering/export](/slides/zh-hant/androidjava/convert-presentation/) 時可能會省略該媒體。