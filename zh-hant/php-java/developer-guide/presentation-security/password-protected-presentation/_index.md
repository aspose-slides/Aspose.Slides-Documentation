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
- presentation
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP 輕鬆鎖定與解鎖受密碼保護的 PowerPoint 和 OpenDocument 簡報。保護您的簡報。"
---
## **簡介**

當您對簡報設定密碼保護時，即表示您設定了一組密碼，以對簡報施加特定限制。若要移除這些限制，必須輸入密碼。受密碼保護的簡報被視為已鎖定的簡報。

通常，您可以設定密碼以對簡報強制執行這些限制：

- **修改**

  如果您希望只有特定使用者可以修改您的簡報，您可以設定修改限制。此限制會阻止人員修改、變更或複製簡報中的內容（除非提供密碼）。

  然而，即使未輸入密碼，使用者仍可存取您的文件並開啟它。在唯讀模式下，使用者可以檢視簡報內的內容或項目──超連結、動畫、特效等──但無法複製項目或儲存簡報。

- **開啟**

  如果您希望只有特定使用者能開啟您的簡報，您可以設定開啟限制。此限制會阻止人員甚至檢視簡報的內容（除非提供密碼）。

  從技術上說，開啟限制同時也會阻止使用者修改簡報：當人員無法開啟簡報時，便無法對其進行修改或變更。

  **注意** 當您以阻止開啟的方式對簡報設定密碼保護時，簡報檔案會被加密。

## **如何線上為簡報設定密碼保護**

1. 前往我們的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock)頁面。

   ![todo:image_alt_text](slides-lock.png)

2. 點擊**拖放或上傳您的檔案**。

3. 在您的電腦上選取想要設定密碼保護的檔案。

4. 輸入您偏好的編輯保護密碼；輸入您偏好的檢視保護密碼。

5. 如果您希望使用者看到最終版本的簡報，勾選**Mark as final**核取方塊。

6. 點擊**PROTECT NOW.**

7. 點擊**DOWNLOAD NOW.**

## **Aspose.Slides 中的簡報密碼保護**
**支援的格式**

Aspose.Slides 支援在以下格式的簡報上使用密碼保護、加密及類似操作：

- PPTX 和 PPT ─ Microsoft PowerPoint 簡報
- ODP ─ OpenDocument 簡報
- OTP ─ OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您透過密碼保護簡報，以以下方式防止修改：

- 加密簡報
- 為簡報設定寫入保護

**其他操作**

Aspose.Slides 讓您以以下方式執行其他與密碼保護和加密相關的工作：

- 解密簡報；開啟已加密的簡報
- 移除加密；停用密碼保護
- 從簡報中移除寫入保護
- 取得已加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否已設定密碼保護。

## **加密簡報**

您可以透過設定密碼來加密簡報。之後，若要修改已鎖定的簡報，使用者必須提供密碼。

若要加密或設定密碼保護簡報，必須使用 encrypt 方法（來自[ProtectionManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/)）為簡報設定密碼。將密碼傳遞給 encrypt 方法，然後使用 save 方法儲存已加密的簡報。

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

## **為簡報設定寫入保護**

您可以在簡報中加入「請勿修改」標記。如此即可告知使用者您不希望他們對簡報進行變更。

**注意** 寫入保護過程不會加密簡報。因此，使用者（若真的想）仍能修改簡報，但若要儲存變更，必須以不同的名稱建立簡報。

若要設定寫入保護，必須使用[setWriteProtection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#setWriteProtection) 方法。以下範例程式碼示範如何為簡報設定寫入保護：

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

## **載入已加密的簡報**

Aspose.Slides 允許您透過傳入密碼來載入已加密的檔案。若要解密簡報，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#removeEncryption) 方法且不帶參數。之後您需要輸入正確的密碼才能載入簡報。

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

## **從簡報中移除加密**

您可以移除簡報的加密或密碼保護。如此一來，使用者即可在無任何限制的情況下存取或修改簡報。

若要移除加密或密碼保護，必須呼叫[removeEncryption](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#removeEncryption) 方法。以下範例程式碼示範如何從簡報中移除加密：

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

## **從簡報中移除寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此一來，使用者可以隨意修改，且在執行此類操作時不會收到任何警告。

您可以透過使用[removeWriteProtection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#removeWriteProtection) 方法來移除簡報的寫入保護。以下範例程式碼示範如何從簡報中移除寫入保護：

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

## **取得已加密簡報的屬性**

通常，使用者很難取得已加密或受密碼保護的簡報的文件屬性。然而，Aspose.Slides 提供一種機制，讓您在為簡報設定密碼保護的同時，仍保留使用者存取該簡報屬性的方式。

**注意** 當 Aspose.Slides 加密簡報時，簡報的文件屬性預設也會被密碼保護。但若您需要在簡報加密後仍能存取其屬性，Aspose.Slides 允許您做到這一點。

若您希望使用者仍能存取您加密的簡報屬性，可使用帶有 `true` 值的[encryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) 方法。以下範例程式碼示範如何在加密簡報的同時，提供使用者存取其文件屬性的方式：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **檢查簡報是否受密碼保護**

在載入簡報之前，您可能想先檢查並確認該簡報未受密碼保護。如此可避免在未提供密碼而載入受密碼保護的簡報時發生錯誤與類似問題。

以下 PHP 程式碼示範如何檢查簡報是否受密碼保護（不會實際載入簡報）：

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。要執行此操作，您可以使用 [isEncrypted](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#isEncrypted) 方法，若簡報已加密則回傳 `true`，未加密則回傳 `false`。

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

## **檢查簡報是否受寫入保護**

Aspose.Slides 允許您檢查簡報是否受寫入保護。要執行此操作，您可以使用 [isWriteProtected](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#isWriteProtected) 方法，若簡報受寫入保護則回傳 `true`，未受寫入保護則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否受寫入保護：

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

您可能想檢查並確認已使用特定密碼來保護簡報文件。Aspose.Slides 提供驗證密碼的功能。

以下範例程式碼示範如何驗證密碼：

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # 檢查 "pass" 是否相符
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

如果簡報已使用指定的密碼加密，則回傳 `true`；否則回傳 `false`。

{{% alert color="primary" title="另見" %}} 
- [Digital Signature in PowerPoint](/slides/zh-hant/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的簡報具備高度資料安全性。

**嘗試開啟簡報時若輸入錯誤的密碼會發生什麼情況？**

若使用錯誤的密碼，系統會拋出例外，提示存取簡報被拒絕。這有助於防止未經授權的存取並保護簡報內容。

**在處理受密碼保護的簡報時是否會有性能影響？**

加密與解密過程可能在開啟與儲存操作時帶來輕微的額外負擔。大多數情況下，此性能影響很小，對簡報任務的整體處理時間不會有顯著影響。