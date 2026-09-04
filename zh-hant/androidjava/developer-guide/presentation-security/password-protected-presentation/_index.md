---
title: 在 Android 上對簡報進行密碼保護
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
- 開啟加密簡報
- 移除加密
- PowerPoint
- PPT
- PPTX
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android (Java) 加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 和 PPTX 簡報。"
---
## **概述**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因而此保護提供機密性。

開啟密碼與寫入保護密碼不同。寫入保護限制修改，但不加密內容，也不阻止載入簡報。若要管理修改簡報的密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/androidjava/write-protected-presentation/)。

以下工作流程同時適用於 PPT 與 PPTX 簡報。範例會在需關注檔案模式與串流模式行為的情況下同時使用兩種格式。

## **使用開啟密碼加密簡報**

使用[IProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-)指派開啟密碼。然後使用[IPresentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-)將加密的簡報儲存下來。

以下範例加密 PPTX 簡報：

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

## **保留文件屬性為公開**

預設情況下，Aspose.Slides 會在簡報加密時包含文件屬性。[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 方法可獨立於投影片內容加密而控制此行為。若索引、分類、搜尋或文件管理系統必須在未提供開啟密碼的情況下讀取中繼資料，請在呼叫[IProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-)之前傳入`false`。

以下範例在建立加密的 PPTX 簡報時，保持內建文件屬性為公開：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

將 `false` 傳遞給[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)不會使投影片、母片、版面配置、圖形、媒體或其他簡報內容公開。它僅影響文件屬性。若要在不載入加密內容的情況下讀取這些屬性，請參閱[Manage Presentation Properties](/slides/zh-hant/androidjava/presentation-properties/)。

## **載入加密的簡報**

將[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)設定為開啟密碼，並在載入檔案時將該選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)。若需要開啟密碼但提供的密碼遺失或不正確，載入將失敗。

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

## **從簡報中移除加密**

使用開啟密碼載入簡報，呼叫[IProtectionManager.removeEncryption](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--)，並儲存結果。儲存後的簡報即可在不需要密碼的情況下載入。

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

使用[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-)可取得[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/)，而不必建立完整的簡報實例。在請求或驗證密碼之前，先檢查[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--)。若存在保護，請使用[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)驗證提供的值。

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-)的串流重載提供相同的工作流程。載入完整簡報之前，先將可尋址串流的位置重設。

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)僅在簡報具備開啟密碼且提供的密碼正確時回傳`true`。在以下情況皆回傳`false`：

- 密碼不正確。
- 簡報沒有開啟密碼。
- 提供的密碼為`null`或空字串。

此行為於 PPT 與 PPTX 簡報皆相同。

## **檢查已載入的簡報是否已加密**

使用正確密碼載入簡報後，檢查[IProtectionManager.isEncrypted](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--)以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請使用上面示範的`IPresentationInfo.isPasswordProtected`。

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

{{% alert color="warning" title="Security" %}}
請勿記錄開啟密碼或將其包含於診斷訊息中。避免不必要的重複驗證嘗試，僅在需要時於記憶體中保留密碼，並在立即載入簡報時重複使用成功的驗證結果。

即使簡報內容已加密，公開的文件屬性仍可能洩露作者姓名、標題、主旨、關鍵字、公司資訊、註解以及自訂值。應將敏感的中繼資料與簡報一併加密。僅在系統必須在未提供開啟密碼的情況下進行索引、分類、搜尋或管理檔案時，才應明確決定將屬性設為公開。
{{% /alert %}}

## **在線保護簡報密碼**

1. 開啟[Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock)應用程式。
1. 選取或上傳簡報。
1. 輸入檢視保護的密碼。
1. （可選）輸入用於編輯保護的其他密碼。
1. 套用保護並下載產生的檔案。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh-hant/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何差異？**

開啟密碼會加密簡報，且必須提供才能載入其內容。寫入保護密碼僅限制修改，且不會加密內容。

**是否可以在不載入全部投影片的情況下驗證開啟密碼？**

可以。先取得簡報資訊，檢查是否存在開啟密碼保護，然後在建立完整簡報實例之前驗證密碼。

**應用程式是否能在沒有開啟密碼的情況下讀取中繼資料？**

可以，但僅限於簡報在加密時已停用文件屬性加密的情況。此時應用程式必須使用 [Manage Presentation Properties](/slides/zh-hant/androidjava/presentation-properties/) 中描述的僅載入文件屬性的模式。

**密碼檢查工作流程是否同時支援 PPT 與 PPTX？**

是。檔案路徑與串流模式的密碼偵測與驗證在 PPT 與 PPTX 簡報中皆表現相同。