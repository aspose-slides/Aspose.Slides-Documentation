---
title: 在 PHP 中使用密碼保護簡報
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
description: "在 PHP 中使用 Aspose.Slides 加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 與 PPTX 簡報。"
---
## **概觀**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因而此保護提供了保密性。

開啟密碼不同於寫入保護密碼。寫入保護限制修改，但不會加密內容或阻止載入簡報。若要管理修改簡報的密碼，請參閱[寫入保護簡報](/slides/zh-hant/php-java/write-protected-presentation/)。

以下工作流程同時適用於 PPT 與 PPTX 簡報。範例在兩種格式中皆示範檔案型與串流型行為的重要性。

## **使用開啟密碼加密簡報**

使用[ProtectionManager::encrypt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#encrypt) 指定開啟密碼，然後使用[Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 儲存加密後的簡報。

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

## **載入加密的簡報**

將[LoadOptions::setPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setPassword) 設為開啟密碼，並在載入檔案時將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)。若需要開啟密碼但未提供或提供的密碼不正確，載入將失敗。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # 處理已解密的簡報.
} finally {
    $presentation->dispose();
}
```

## **從簡報中移除加密**

使用開啟密碼載入簡報，呼叫[ProtectionManager::removeEncryption](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#removeEncryption)，並儲存結果。儲存後的簡報即可在不提供密碼的情況下載入。

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

使用[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/#getPresentationInfo) 取得[PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/)，而無需建立完整的簡報實例。於請求或驗證密碼之前，先檢查[PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#isPasswordProtected)。若存在保護，請使用[PresentationInfo::checkPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#checkPassword) 來驗證提供的密碼。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[LoadOptions::setPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setPassword)，接著載入完整的簡報：

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

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/#getPresentationInfo) 的串流重載提供相同的工作流程。於從該串流載入完整簡報之前，請重設可搜尋串流的位置。

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

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#checkPassword) 只在簡報具備開啟密碼且提供的密碼正確時回傳 `true`。在以下情況皆會回傳 `false`：

- 密碼不正確。
- 簡報未設定開啟密碼。
- 提供的密碼為 `null` 或為空。

PPT 與 PPTX 簡報的行為相同。

## **檢查已載入的簡報是否已加密**

使用正確的密碼載入簡報後，檢查[ProtectionManager::isEncrypted](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#isEncrypted) 以確認來源簡報已加密。若要在載入前偵測開啟密碼保護，請如上所示使用[PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#isPasswordProtected)。

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

{{% alert color="warning" title="Security" %}}
不要記錄開啟密碼或在診斷訊息中包含它們。避免不必要的重複驗證嘗試，僅在需要時將密碼保留在記憶體中，並在立即載入簡報時重複使用成功的驗證結果。
{{% /alert %}}

## **線上為簡報設定密碼保護**

1. 開啟 [Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock) 應用程式。
1. 選取或上傳簡報。
1. 輸入檢視保護的密碼。
1. （可選）為編輯保護輸入另一個密碼。
1. 套用保護並下載產生的檔案。

{{% alert color="info" title="See also" %}}
- [寫入保護簡報](/slides/zh-hant/php-java/write-protected-presentation/)
- [PowerPoint 中的數位簽章](/slides/zh-hant/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且在載入內容時必須提供。寫入保護密碼僅限制修改，並不加密內容。

**我可以在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，並在建立完整簡報實例之前驗證密碼。

**密碼驗證工作流程是否同時支援 PPT 與 PPTX？**

支援。檔案路徑與串流式的密碼偵測與驗證在 PPT 與 PPTX 簡報中行為相同。