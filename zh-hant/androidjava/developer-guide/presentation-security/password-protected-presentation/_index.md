---
title: 在 Android 上對簡報設定密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/androidjava/password-protected-presentation/
keywords:
- 受密碼保護的簡報
- 開啟密碼
- 加密 PowerPoint
- 解密 PowerPoint
- 驗證簡報密碼
- 檢查簡報密碼
- 開啟加密的簡報
- 移除加密
- PowerPoint
- PPT
- PPTX
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 透過 Java 加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 和 PPTX 簡報。"
---
## **概覽**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因此此保護提供機密性。

開啟密碼不同於寫入保護密碼。寫入保護限制修改，但不會加密內容或阻止簡報載入。如需管理修改簡報的密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/androidjava/write-protected-presentation/)。

以下工作流程適用於 PPT 與 PPTX 簡報。範例會同時使用兩種格式，因為檔案基礎與串流基礎的行為皆很重要。

## **使用開啟密碼加密簡報**

使用[IProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) 來指定開啟密碼。然後使用[IPresentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) 將加密的簡報儲存下來。

以下範例會加密 PPTX 簡報：

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **載入加密的簡報**

將[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) 設為開啟密碼，並在載入檔案時將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)。當需要開啟密碼但提供的密碼遺失或不正確時，載入會失敗。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 處理已解密的簡報。
} finally {
    presentation.dispose();
}
```

## **移除簡報的加密**

使用開啟密碼載入簡報後，呼叫[IProtectionManager.removeEncryption](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--)，再將結果儲存。儲存後的簡報即可在不需要密碼的情況下載入。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在載入前驗證開啟密碼**

使用[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) 可取得[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/)，而無需建立完整的簡報實例。於請求或驗證密碼之前，先檢查[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--)。若存在保護，請使用[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) 來驗證提供的密碼。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)，然後載入完整的簡報：

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **串流工作流程**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) 的串流重載提供相同的工作流程。在從該串流載入完整簡報之前，請先重設可搜尋串流的位置。

以下範例使用 PPT 檔案：

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **checkPassword 回傳值**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) 只有在簡報具有開啟密碼且提供的密碼正確時才回傳 `true`。在以下情況皆會回傳 `false`：

- 密碼不正確。
- 簡報沒有開啟密碼。
- 提供的密碼為 `null` 或空字串。

此行為在 PPT 與 PPTX 簡報中皆相同。

## **檢查已載入的簡報是否已加密**

使用正確密碼載入簡報後，檢查[IProtectionManager.isEncrypted](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) 以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請如上所示使用 `IPresentationInfo.isPasswordProtected`。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **安全性建議**

{{% alert color="warning" title="安全性" %}}
請勿記錄開啟密碼或將其寫入診斷訊息。避免不必要的重複驗證嘗試，僅在需要時將密碼保留在記憶體中，並在立即載入簡報時重複使用成功的驗證結果。
{{% /alert %}}

## **在線為簡報設定密碼保護**

1. 開啟 [Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock) 應用程式。
1. 選取或上傳簡報。
1. 輸入檢視保護的密碼。
1. （可選）輸入用於編輯保護的另一個密碼。
1. 套用保護並下載產生的檔案。

{{% alert color="info" title="另請參閱" %}}
- [Write-Protect Presentations](/slides/zh-hant/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且必須提供才能載入其內容。寫入保護密碼則僅限制修改，並不會加密內容。

**我能在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。先取得簡報資訊，檢查是否有開啟密碼保護，然後在建立完整簡報實例之前驗證該密碼。

**密碼驗證工作流程是否同時支援 PPT 與 PPTX？**

是的。檔案路徑與串流式的密碼偵測與驗證在 PPT 與 PPTX 簡報中都以相同方式運作。