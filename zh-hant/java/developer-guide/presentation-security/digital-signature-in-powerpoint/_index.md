---
title: 在 Java 中為簡報新增數位簽章
linktitle: 數位簽章
type: docs
weight: 10
url: /zh-hant/java/digital-signature-in-powerpoint/
keywords:
- 數位簽章
- 數位憑證
- 憑證授權機構
- PFX 憑證
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 為 PowerPoint 與 OpenDocument 檔案加上數位簽章。只需幾秒鐘，即可透過清晰的程式範例保護您的簡報。"
---
## **簡介**

**數位憑證** 用於建立受密碼保護的 PowerPoint 簡報，並標示為由特定組織或個人建立。可透過聯繫授權機構（憑證頒發機構）取得數位憑證。將數位憑證安裝到系統後，可透過「檔案 -> 資訊 -> 保護簡報」將數位簽章加入簡報：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

簡報可能包含多個數位簽章。將數位簽章加入簡報後，PowerPoint 會顯示一則特殊訊息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

若要簽署簡報或檢查簡報簽章的真偽，**Aspose.Slides API** 提供了 [**IDigitalSignature**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IDigitalSignature) 介面、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IDigitalSignatureCollection) 介面以及 [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentation#getDigitalSignatures--) 方法。目前，數位簽章僅支援 PPTX 格式。

## **從 PFX 憑證新增數位簽章**
以下程式範例示範如何從 PFX 憑證新增數位簽章：

1. 開啟 PFX 檔案並將 PFX 密碼傳遞給 [**DigitalSignature**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/DigitalSignature) 物件。  
1. 將已建立的簽章加入簡報物件。

```java
// 開啟簡報檔案
Presentation pres = new Presentation();
try {
    // 使用 PFX 檔案與 PFX 密碼建立 DigitalSignature 物件
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // 為新數位簽章添加註解
    signature.setComments("Aspose.Slides digital signing test.");

    // 將數位簽章加入簡報
    pres.getDigitalSignatures().add(signature);

    // 儲存簡報
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

現在可以檢查簡報是否已簽署數位簽章且未被修改：

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

## **常見問題**

**Can I remove existing signatures from a file?**

是。數位簽章集合支援[移除個別項目](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-)與[完全清除](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/digitalsignaturecollection/#clear--)；儲存檔案後，簡報將不會保留任何簽章。

**Does the file become "read-only" after signing?**

否。簽章僅維持完整性與作者身份，並不阻止編輯。若需限制編輯，可搭配「[唯讀]或密碼](/slides/zh-hant/java/password-protected-presentation/)」。

**Will the signature display correctly in different versions of PowerPoint?**

簽章是針對 OOXML（PPTX）容器建立的。支援 OOXML 簽章的現代 PowerPoint 版本會正確顯示此類簽章的狀態。