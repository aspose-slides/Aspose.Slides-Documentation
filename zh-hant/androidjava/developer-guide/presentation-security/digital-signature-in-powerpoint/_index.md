---
title: 在 Android 上為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/androidjava/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權單位
- PFX 憑證
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 為 PowerPoint 與 OpenDocument 檔案加上數位簽章。只需幾秒，即可透過清晰的 Java 程式碼範例保護您的投影片。"
---
## **簡介**

**數位憑證** 用於建立受密碼保護的 PowerPoint 簡報，並標示為特定組織或個人所建立。可透過聯繫授權機構（憑證授權中心）取得數位憑證。將數位憑證安裝到系統後，可透過「檔案 → 資訊 → 保護簡報」為簡報加入數位簽章：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

簡報可能包含多個數位簽章。加入數位簽章後，PowerPoint 內會顯示特殊訊息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

若要為簡報簽章或檢查簽章的真偽，**Aspose.Slides API** 提供[**IDigitalSignature**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IDigitalSignature) 介面、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IDigitalSignatureCollection) 介面以及[**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) 方法。目前僅支援 PPTX 格式的數位簽章。
## **從 PFX 憑證新增數位簽章**
以下程式碼示範如何從 PFX 憑證新增數位簽章：

1. 開啟 PFX 檔案並將 PFX 密碼傳遞給[**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/DigitalSignature) 物件。
1. 將建立的簽章加入簡報物件。

```java
// 開啟簡報檔案
Presentation pres = new Presentation();
try {
    // 使用 PFX 檔案與 PFX 密碼建立 DigitalSignature 物件
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // 為新的數位簽章設定註解
    signature.setComments("Aspose.Slides digital signing test.");

    // 將數位簽章加入簡報
    pres.getDigitalSignatures().add(signature);

    // 儲存簡報
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

現在可以檢查簡報是否已簽署且未被修改：

```java
// 開啟簡報
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // 檢查所有數位簽章是否有效
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**我可以從檔案中移除現有的簽章嗎？**

可以。數位簽章集合支援[移除個別項目](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) 與[全部清除](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--)；儲存檔案後，簡報將不會有任何簽章。

**簽署後檔案會變成「唯讀」嗎？**

不會。簽章保留完整性與作者資訊，但不會阻止編輯。若需限制編輯，可搭配["唯讀" 或密碼](/slides/zh-hant/androidjava/password-protected-presentation/) 使用。

**不同 PowerPoint 版本會正確顯示簽章嗎？**

此簽章是為 OOXML（PPTX）容器建立。支援 OOXML 簽章的現代 PowerPoint 版本會正確顯示此類簽章的狀態。