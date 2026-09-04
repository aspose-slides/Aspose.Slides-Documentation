---
title: 在 PHP 中對簡報設定密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/php-java/password-protected-presentation/
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
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 和 PPTX 簡報。"
---
## **概述**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因而此保護提供機密性。

開啟密碼與寫入保護密碼不同。寫入保護限制修改，但不加密內容或阻止載入簡報。若要管理修改簡報的密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/php-java/write-protected-presentation/)。

以下工作流程適用於 PPT 和 PPTX 簡報。範例同時使用兩種格式，因為其檔案基礎和串流基礎的行為很重要。

## **使用開啟密碼加密簡報**

使用[ProtectionManager::encrypt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#encrypt)指派開啟密碼。然後使用[Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save)保存加密的簡報。

以下範例會加密 PPTX 簡報：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **保持文件屬性公開**

預設情況下，Aspose.Slides 會在簡報加密中包含文件屬性。[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 方法可獨立於投影片內容加密來控制此行為。當索引、分類、搜尋或文件管理系統必須在未提供開啟密碼的情況下讀取中繼資料時，請在呼叫[ProtectionManager::encrypt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#encrypt)之前傳遞 `false`。

以下範例會建立加密的 PPTX 簡報，同時保持其內建文件屬性為公開：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

將 `false` 傳遞給[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)不會使投影片、母片、版面配置、圖形、媒體或其他簡報內容公開。它僅影響文件屬性。若要在不載入加密內容的情況下讀取這些屬性，請參閱[Manage Presentation Properties](/slides/zh-hant/php-java/presentation-properties/)。

## **載入加密的簡報**

將[LoadOptions::setPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setPassword)設定為開啟密碼，並在載入檔案時將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)。如果需要開啟密碼但未提供或提供的密碼不正確，載入將失敗。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # 在此處理已解密的簡報。
} finally {
    $presentation->dispose();
}
```

## **移除簡報的加密**

使用開啟密碼載入簡報，呼叫[ProtectionManager::removeEncryption](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#removeEncryption)，然後儲存結果。儲存後的簡報即可在不需密碼的情況下載入。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在載入前驗證開啟密碼**

使用[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/#getPresentationInfo)取得[PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/)而不建立完整的簡報實例。於要求或驗證密碼之前，先檢查[PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#isPasswordProtected)。若存在保護，請使用[PresentationInfo::checkPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#checkPassword)驗證提供的密碼。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[LoadOptions::setPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setPassword)，然後載入完整的簡報：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **串流工作流程**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/#getPresentationInfo) 的串流覆載提供相同的工作流程。在從該串流載入完整簡報之前，請重設可搜尋串流的位置。

以下範例使用 PPT 檔案：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **checkPassword 回傳值**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#checkPassword) 只有在簡報具有開啟密碼且提供的密碼正確時才傳回 `true`。在以下情況皆會傳回 `false`：

- 密碼不正確。
- 簡報沒有開啟密碼。
- 提供的密碼為 `null` 或空字串。

PPT 與 PPTX 簡報的行為相同。

## **檢查已載入的簡報是否已加密**

使用正確密碼載入簡報後，檢查[ProtectionManager::isEncrypted](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#isEncrypted)以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請如上所示使用[PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#isPasswordProtected) 。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **安全性建議**

{{% alert color="warning" title="安全性" %}}
請勿記錄開啟密碼或將其包含在診斷訊息中。避免不必要的重複驗證嘗試，僅在需要時才將密碼保留在記憶體中，並在立即載入簡報時重新使用成功的驗證結果。

即使簡報內容已加密，公開的文件屬性仍可能洩露作者姓名、標題、主旨、關鍵字、公司資訊、備註以及自訂值。請同時加密敏感的中繼資料與簡報。僅在系統必須在未提供開啟密碼的情況下進行索引、分類、搜尋或管理檔案時，才明確決定將屬性設為公開。
{{% /alert %}}

## **線上為簡報設定密碼保護**

1. 開啟[Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock)應用程式。
2. 選取或上傳簡報。
3. 輸入檢視保護的密碼。
4. （可選）輸入用於編輯保護的另一個密碼。
5. 套用保護並下載產生的檔案。

{{% alert color="info" title="另見" %}}
- [Write-Protect Presentations](/slides/zh-hant/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何差異？**

開啟密碼會加密簡報，且必須提供才能載入其內容。寫入保護密碼則僅限制修改，並不加密內容。

**我能在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，並在建立完整簡報實例之前驗證密碼。

**應用程式能在未提供開啟密碼的情況下讀取中繼資料嗎？**

可以，但僅在簡報加密時已停用文件屬性加密的情況下。此時應用程式必須使用[Manage Presentation Properties](/slides/zh-hant/php-java/presentation-properties/)中描述的僅載入文件屬性模式。

**密碼檢查工作流程是否同時支援 PPT 與 PPTX？**

支援。檔案路徑與串流模式的密碼偵測與驗證在 PPT 與 PPTX 簡報上行為相同。