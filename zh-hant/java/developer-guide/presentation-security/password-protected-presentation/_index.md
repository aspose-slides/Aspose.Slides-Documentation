---
title: 在 Java 中使用密碼保護簡報
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/java/password-protected-presentation/
keywords:
- 受密碼保護的簡報
- 開啟密碼
- 加密 PowerPoint
- 解密 PowerPoint
- 驗證簡報密碼
- 檢查簡報密碼
- 開啟已加密的簡報
- 移除加密
- PowerPoint
- PPT
- PPTX
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 於 Java 中加密、偵測、驗證、開啟與解密受密碼保護的 PowerPoint PPT 與 PPTX 簡報。"
---
## **概觀**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因此此保護提供機密性。

開啟密碼與寫入保護密碼不同。寫入保護會限制修改，但不會加密內容或阻止載入簡報。若要管理簡報的寫入密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/java/write-protected-presentation/)。

以下工作流程同時適用於 PPT 與 PPTX 簡報。範例在需要說明檔案與串流行為差異時同時使用兩種格式。

## **使用開啟密碼加密簡報**

使用[IProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) 指定開啟密碼。然後使用[IPresentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) 保存加密後的簡報。

以下範例加密一個 PPTX 簡報：

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

## **將文件屬性保持公開**

預設情況下，Aspose.Slides 會將文件屬性納入簡報加密。[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 方法可獨立於投影片內容加密控制此行為。當索引、分類、搜尋或文件管理系統必須在未提供開啟密碼的情況下讀取中繼資料時，請在呼叫[IProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) 前傳入 `false`。

以下範例在建立加密的 PPTX 簡報時，仍保留其內建文件屬性為公開：

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

將 `false` 傳遞給[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 不會使投影片、母片、版面配置、圖形、媒體或其他簡報內容公開。它僅影響文件屬性。若需在不載入加密內容的情況下讀取這些屬性，請參閱[Manage Presentation Properties](/slides/zh-hant/java/presentation-properties/)。

## **載入已加密的簡報**

將[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) 設為開啟密碼，並在載入檔案時將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)。如果需要開啟密碼但未提供或提供的密碼不正確，載入將失敗。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 使用已解密的簡報。
} finally {
    presentation.dispose();
}
```

## **從簡報中移除加密**

使用開啟密碼載入簡報，呼叫[IProtectionManager.removeEncryption](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#removeEncryption--)，然後保存結果。保存後的簡報即可在不提供密碼的情況下載入。

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

使用[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) 取得[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/)，而不必建立完整的簡報實例。於要求或驗證密碼前，先檢查[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--)。若已受到保護，使用[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) 驗證提供的值。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[ILoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)，然後載入完整簡報：

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) 的串流重載提供相同的工作流程。於從該串流載入完整簡報前，先將可搜尋串流的位置重設。

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) 只在簡報具有開啟密碼且提供的密碼正確時回傳 `true`。在以下情況皆回傳 `false`：

- 密碼不正確。
- 簡報沒有開啟密碼。
- 提供的密碼為 `null` 或空字串。

此行為在 PPT 與 PPTX 簡報中皆相同。

## **檢查已載入的簡報是否已加密**

在以正確密碼載入簡報後，檢查[IProtectionManager.isEncrypted](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) 以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請如上使用 `IPresentationInfo.isPasswordProtected`。

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
不要記錄開啟密碼或將其寫入診斷訊息。避免不必要的重複驗證嘗試，僅在需要時將密碼保留在記憶體中，並在立即載入簡報時重複使用已成功驗證的結果。

即使簡報內容已加密，公開的文件屬性仍可能洩漏作者名稱、標題、主旨、關鍵字、公司資訊、註解以及自訂值。請將敏感的中繼資料與簡報一起加密。僅在系統必須在未提供開啟密碼的情況下進行索引、分類、搜尋或管理檔案時，才明確決定將屬性保持公開。
{{% /alert %}}

## **線上為簡報設定寫入保護密碼**

1. 開啟[Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock) 應用程式。
2. 選取或上傳簡報。
3. 輸入檢視保護的密碼。
4. （可選）輸入用於編輯保護的另一組密碼。
5. 套用保護並下載產生的檔案。

{{% alert color="info" title="另請參閱" %}}
- [Write-Protect Presentations](/slides/zh-hant/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且必須提供才能載入其內容。寫入保護密碼僅限制修改，並不加密內容。

**是否能在不載入所有投影片的情況下驗證開啟密碼？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，然後在建立完整簡報實例前驗證密碼。

**應用程式能在未提供開啟密碼的情況下讀取中繼資料嗎？**

可以，但僅當簡報在加密時已停用文件屬性加密。此時應用程式必須使用 [Manage Presentation Properties](/slides/zh-hant/java/presentation-properties/) 中描述的「僅文件屬性」載入模式。

**密碼檢查工作流程是否同時支援 PPT 與 PPTX？**

支援。檔案路徑與串流方式的密碼偵測與驗證在 PPT 與 PPTX 簡報中行為相同。