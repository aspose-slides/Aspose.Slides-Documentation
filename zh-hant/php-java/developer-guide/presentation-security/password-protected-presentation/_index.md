---
title: 在 PHP 中使用密碼保護簡報
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/php-java/password-protected-presentation/
keywords:
- 鎖定 PowerPoint
- 鎖定簡報
- 解除鎖定 PowerPoint
- 解除鎖定簡報
- 保護 PowerPoint
- 保護簡報
- 設定密碼
- 新增密碼
- 加密 PowerPoint
- 加密簡報
- 解密 PowerPoint
- 解密簡報
- 寫入保護
- PowerPoint 安全性
- 簡報安全性
- 移除密碼
- 移除保護
- 移除加密
- 停用密碼
- 停用保護
- 移除寫入保護
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP 輕鬆地鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 簡報，保障您的簡報安全。"
---
## **簡介**

當您為簡報設定密碼保護時，表示您正在設定一組密碼，以對簡報實施特定限制。要移除這些限制，必須輸入密碼。受密碼保護的簡報被視為已鎖定的簡報。

通常，您可以設定密碼以對簡報施加以下限制：

- **修改**

  若您只想讓特定使用者修改簡報，可以設定修改限制。此限制可防止他人在未提供密碼的情況下修改、變更或複製簡報內容。

  但是，即使沒有密碼，使用者仍能開啟您的文件。在唯讀模式下，使用者可以查看簡報中的內容或項目—如超連結、動畫、效果等—但無法複製項目或儲存簡報。

- **開啟**

  若您只想讓特定使用者開啟簡報，可以設定開啟限制。此限制可防止人員即使在未提供密碼的情況下檢視簡報內容。

  從技術上說，開啟限制亦會防止使用者修改簡報：當使用者無法開啟簡報時，便無法對其進行修改或變更。

  **注意** 當您以密碼保護簡報以防止開啟時，簡報檔案會被加密。

## **在線保護簡報密碼的方式**

1. 前往我們的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock)頁面。

   ![todo:image_alt_text](slides-lock.png)

2. 點選 **拖放或上傳檔案**。

3. 從電腦中選取您想要設定密碼保護的檔案。

4. 輸入您想要用於編輯保護的密碼；輸入您想要用於檢視保護的密碼。

5. 若您希望使用者看到的簡報是最終版，勾選 **Mark as final** 核取方塊。

6. 點選 **PROTECT NOW.** 

7. 點選 **DOWNLOAD NOW.**

## **Aspose.Slides 中簡報的密碼保護**

**支援的格式**

Aspose.Slides 支援以下格式的簡報進行密碼保護、加密及類似操作：

- PPTX 與 PPT - Microsoft PowerPoint 簡報
- ODP - OpenDocument 簡報
- OTP - OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您以以下方式對簡報使用密碼保護，以防止修改：

- 加密簡報
- 設定簡報的寫入保護

**其他操作**

Aspose.Slides 亦允許您以以下方式執行其他與密碼保護與加密相關的任務：

- 解密簡報；開啟加密的簡報
- 移除加密；停用密碼保護
- 移除簡報的寫入保護
- 取得加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否受密碼保護

## **加密簡報**

您可以透過設定密碼來加密簡報。之後，若要修改已鎖定的簡報，使用者必須提供密碼。

要加密或設定密碼保護，您必須使用 [ProtectionManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/) 的 encrypt 方法為簡報設定密碼。將密碼傳遞給 encrypt 方法，然後使用 save 方法保存已加密的簡報。

以下範例程式碼示範如何加密簡報：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **設定簡報寫入保護**

您可以在簡報上加入「請勿修改」的標記。如此一來，您即可告訴使用者不希望他們對簡報做出變更。

**注意** 寫入保護過程不會加密簡報。因此，使用者若真的想修改簡報，仍可進行，只是儲存變更時必須另存為不同名稱的簡報。

要設定寫入保護，您必須使用 [setWriteProtection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#setWriteProtection) 方法。以下範例程式碼示範如何為簡報設定寫入保護：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **載入加密的簡報**

Aspose.Slides 允許您在傳入密碼後載入加密檔案。若要解密簡報，您必須呼叫 [removeEncryption](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#removeEncryption) 方法且不帶參數。之後，您需輸入正確的密碼才能載入簡報。

以下範例程式碼示範如何解密簡報：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # 使用已解密的簡報
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **移除簡報的加密**

您可以移除簡報的加密或密碼保護。如此一來，使用者即可在不受限制的情況下存取或修改簡報。

要移除加密或密碼保護，您必須呼叫 [removeEncryption](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#removeEncryption) 方法。以下範例程式碼示範如何從簡報中移除加密：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **移除簡報的寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此一來，使用者即可任意修改，且執行此類操作時不會出現任何警告。

您可以透過使用 [removeWriteProtection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#removeWriteProtection) 方法來移除簡報的寫入保護。以下範例程式碼示範如何從簡報中移除寫入保護：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **取得加密簡報的屬性**

通常，使用者在取得加密或受密碼保護的簡報文件屬性時會遇到困難。然而，Aspose.Slides 提供了一種機制，使您在對簡報設定密碼保護的同時，仍能讓使用者存取其屬性。

**注意：** 預設情況下，當 Aspose.Slides 加密簡報時，簡報的文件屬性亦會受到密碼保護。如果您需要在加密後仍能存取文件屬性，Aspose.Slides 允許您如此操作。

若您希望使用者即使在簡報被加密後仍能存取其屬性，請將 `false` 傳遞給 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)。以下範例程式碼示範在加密簡報的同時仍提供使用者存取文件屬性的方法：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **僅從加密簡報載入文件屬性**

若要在不載入投影片或其他內容的情況下檢查加密簡報的中繼資料，請建立一個 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/) 物件，並將 `true` 傳遞給 [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties)。在此模式下，Aspose.Slides 會忽略密碼，只載入可公開存取的文件屬性。

以下程式碼範例透過 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDocumentProperties) 讀取內建與自訂文件屬性：

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # 讀取內建文件屬性。
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # 讀取自訂文件屬性。
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

此工作流程僅在文件屬性在加密簡報時被保留為未加密（公開）時才有效。若文件屬性已加密，將 `true` 傳遞給 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 會導致例外，因為此模式下會忽略密碼。若需存取加密的文件屬性或載入完整簡報（包括投影片與其他內容），請透過 [LoadOptions::setPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setPassword) 提供正確的密碼。

## **檢查簡報是否受密碼保護**

在載入簡報之前，您可能想先確認該簡報是否已被密碼保護。這樣可避免在未提供密碼就載入受密碼保護的簡報時發生錯誤與類似問題。

此 PHP 程式碼示範如何在不載入簡報本身的情況下檢查其是否受密碼保護：

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。為執行此操作，您可以使用 [isEncrypted](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#isEncrypted) 方法，若簡報已加密則回傳 `true`，未加密則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否已加密：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **檢查簡報是否寫入受保護**

Aspose.Slides 允許您檢查簡報是否寫入受保護。為執行此操作，您可以使用 [isWriteProtected](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#isWriteProtected) 方法，若簡報受寫入保護則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否寫入受保護：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **驗證或確認已使用特定密碼**

您可能想驗證並確認是否使用了特定密碼來保護簡報文件。Aspose.Slides 提供了驗證密碼的功能。

此範例程式碼示範如何驗證密碼：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # 檢查 "pass" 是否匹配
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

若簡報已使用指定密碼加密，則回傳 `true`；否則回傳 `false`。

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/zh-hant/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的簡報資料具備高水平的安全性。

**如果在嘗試開啟簡報時輸入錯誤的密碼會發生什麼情況？**

系統會拋出例外，提示存取簡報被拒絕。此機制有助於防止未授權的存取並保護簡報內容。

**在處理受密碼保護的簡報時會有性能影響嗎？**

加密與解密過程可能在開啟與儲存操作時帶來輕微的額外開銷。在大多數情況下，此性能影響最小，對簡報任務的整體處理時間影響不大。