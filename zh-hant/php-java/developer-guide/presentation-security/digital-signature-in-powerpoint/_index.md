---
title: 在 PHP 中為簡報加入數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/php-java/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權單位
- PFX 憑證
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP（透過 Java）為 PowerPoint 與 OpenDocument 檔案加入數位簽章。只需數秒，即可使用清晰的程式碼範例保護您的簡報。"
---
## **簡介**

**數位憑證** 用於建立受密碼保護的 PowerPoint 簡報，並標示為由特定組織或個人建立。可以透過聯絡授權組織（憑證授權單位）取得數位憑證。將數位憑證安裝到系統後，即可透過 File -> Info -> Protect Presentation 為簡報加入數位簽章：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

簡報可能包含多個數位簽章。加入數位簽章後，PowerPoint 會顯示特殊訊息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

若要為簡報簽章或驗證簽章的真偽，**Aspose.Slides API** 提供 [**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/DigitalSignature) 、[**DigitalSignatureCollection**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/DigitalSignatureCollection) 以及 [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getDigitalSignatures) 方法。目前，僅支援 PPTX 格式的數位簽章。

## **從 PFX 憑證添加數位簽章**

以下程式碼示範如何從 PFX 憑證加入數位簽章：

1. 開啟 PFX 檔案，並將 PFX 密碼傳遞給 [**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/DigitalSignature) 物件。
2. 將建立的簽章加入至簡報物件。

```php
  # 開啟簡報檔案
  $pres = new Presentation();
  try {
    # 使用 PFX 檔案與密碼建立 DigitalSignature 物件
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # 為新數位簽章設定註解
    $signature->setComments("Aspose.Slides digital signing test.");
    # 將數位簽章加入簡報
    $pres->getDigitalSignatures()->add($signature);
    # 儲存簡報
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

現在可以檢查簡報是否已加入數位簽章且未被修改：

```php
  # 開啟簡報
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # 檢查所有數位簽章是否有效
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以從檔案中移除已存在的簽章嗎？**

可以。數位簽章集合支援[移除個別項目](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignaturecollection/removeat/)和[全部清除](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/digitalsignaturecollection/clear/)；儲存檔案後，簡報將不會有任何簽章。

**簽章後檔案會變成「唯讀」嗎？**

不會。簽章會維護完整性與作者資訊，但不會阻止編輯。若要限制編輯，可結合[「唯讀」或密碼](/slides/zh-hant/php-java/password-protected-presentation/)。

**簽章會在不同版本的 PowerPoint 中正確顯示嗎？**

此簽章是針對 OOXML（PPTX）容器建立的。支援 OOXML 簽章的現代 PowerPoint 版本會正確顯示此類簽章的狀態。