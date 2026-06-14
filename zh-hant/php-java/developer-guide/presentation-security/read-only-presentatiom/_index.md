---
title: 使用 PHP 以唯讀模式儲存簡報
linktitle: 唯讀簡報
type: docs
weight: 30
url: /zh-hant/php-java/read-only-presentation/
keywords:
- 唯讀
- 保護簡報
- 防止編輯
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 以唯讀模式載入與儲存 PowerPoint 檔案（PPT、PPTX），提供精確的投影片預覽，且不會更改您的簡報。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 設定，作為使用者保護簡報的選項之一。當您想要使用此唯讀設定來保護簡報時，可能的情況包括：

- 您希望防止意外編輯，並保持簡報內容的安全。
- 您希望提醒他人您提供的簡報是最終版本。

在為簡報選取 **Always Open Read-Only** 選項後，使用者開啟簡報時，會看到 **Read-Only** 建議，並可能看到以下訊息：*為防止意外變更，作者已將此檔案設定為唯讀開啟。*

**Read-Only** 建議是一種簡單卻有效的阻嚇手段，因為使用者必須先執行移除動作才能編輯簡報，從而減少編輯意願。如果您不希望使用者對簡報進行變更，且希望以禮貌的方式告知他們，**Read-Only** 建議可能是個不錯的選擇。

> 如果使用較舊的 Microsoft PowerPoint 應用程式開啟帶有 **Read-Only** 保護的簡報——該版本不支援近期推出的功能——則會忽略 **Read-Only** 建議（簡報會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for PHP via Java 讓您可以將簡報設定為 **Read-Only**，也就是說使用者（開啟簡報後）會看到 **Read-Only** 建議。以下範例程式碼示範如何使用 Aspose.Slides 將簡報設定為 **Read-Only**：

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
**注意**：**Read-Only** 建議僅用於阻止編輯或避免使用者對 PowerPoint 簡報造成意外變更。如果有具備相關知識且有動機的人決定編輯您的簡報，他們仍可輕易移除唯讀設定。若您真的需要防止未授權的編輯，建議使用[更嚴格的加密與密碼保護](https://docs.aspose.com/slides/zh-hant/php-java/password-protected-presentation/)。
{{% /alert %}} 

## **常見問題**

**「Read-Only recommended」與完整密碼保護有何不同？**  
「Read-Only recommended」僅顯示以唯讀模式開啟檔案的建議，且很容易繞過。[Password protection](/slides/zh-hant/php-java/password-protected-presentation/) 實際限制開啟或編輯，適用於您需要真正安全控制的情況。

**「Read-Only recommended」能否與浮水印結合以進一步阻止編輯？**  
可以。此建議可與[watermarks](/slides/zh-hant/php-java/watermark/) 結合，作為視覺阻嚇；兩者屬於不同機制，且能良好互補。

**啟用此建議時，巨集或外部工具仍能修改檔案嗎？**  
會。此建議不會阻止程式化的變更。若要防止自動化編輯，請使用[passwords and encryption](/slides/zh-hant/php-java/password-protected-presentation/)。

**「Read-Only recommended」與方法「isEncrypted」與「isWriteProtected」之關係為何？**  
它們是不同的訊號。「Read-Only recommended」屬於軟性、可選的提示；[isWriteProtected](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/iswriteprotected/) 與 [isEncrypted](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/isencrypted/) 則表示依賴密碼或加密的實際寫入或讀取限制。