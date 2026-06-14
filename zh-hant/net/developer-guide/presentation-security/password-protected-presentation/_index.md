---
title: 在 .NET 中使用密碼保護投影片
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/net/password-protected-presentation/
keywords:
- 鎖定 PowerPoint
- 鎖定投影片
- 解鎖 PowerPoint
- 解鎖投影片
- 保護 PowerPoint
- 保護投影片
- 設定密碼
- 新增密碼
- 加密 PowerPoint
- 加密投影片
- 解密 PowerPoint
- 解密投影片
- 寫入保護
- PowerPoint 安全性
- 投影片安全性
- 移除密碼
- 移除保護
- 移除加密
- 停用密碼
- 停用保護
- 移除寫入保護
- PowerPoint
- OpenDocument
- 投影片
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 輕鬆鎖定與解鎖受密碼保護的 PowerPoint 與 OpenDocument 投影片。保護您的投影片。"
---
## **簡介**

當您為投影片設定密碼保護時，即是設定一組密碼，以對投影片施加特定限制。若要移除這些限制，必須輸入密碼。受密碼保護的投影片視為已鎖定的投影片。

通常，您可以設定密碼，以對投影片強制以下限制：

- **修改**

如果您只希望特定使用者能修改投影片，可以設定修改限制。此限制會阻止人在未提供密碼的情況下修改、變更或複製投影片中的元素。

但是，即使未輸入密碼，使用者仍然可以存取並開啟文件。在唯讀模式下，使用者可以檢視內容——包括超連結、動畫、效果與其他元素——但無法複製項目或儲存投影片。

- **開啟**

如果您只希望特定使用者能開啟投影片，可以設定開啟限制。此限制會阻止人在未提供密碼的情況下檢視投影片內容。

從技術上講，開啟限制同樣會阻止使用者修改投影片——如果無法開啟投影片，就無法對其進行修改或變更。

**注意：** 當您以密碼保護投影片以防止開啟時，投影片檔案會被加密。

## **Aspose.Slides 中的密碼保護**

**支援的格式**

Aspose.Slides 為以下格式的投影片提供密碼保護、加密以及類似操作的支援：

- PPTX 與 PPT – Microsoft PowerPoint 投影片
- ODP – OpenDocument 投影片
- OTP – OpenDocument 投影片範本

**支援的操作**

Aspose.Slides 允許您以密碼保護方式防止投影片被修改，具體方式如下：

- 加密投影片
- 為投影片設定寫入保護

**其他操作**

Aspose.Slides 亦提供以下與密碼保護和加密相關的額外功能：

- 解密投影片；開啟加密的投影片
- 移除加密；停用密碼保護
- 從投影片中移除寫入保護
- 取得加密投影片的屬性
- 載入投影片前檢查其是否已設定密碼保護
- 檢查投影片是否已加密
- 檢查投影片是否已設定密碼保護

## **使用密碼保護投影片**

您可以透過設定密碼來加密投影片。之後，若要修改已鎖定的投影片，使用者必須提供密碼。

若要加密（或設定密碼保護）投影片，請使用 [ProtectionManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager) 的 `Encrypt` 方法設定密碼。將密碼傳遞給 `Encrypt` 方法，然後使用 `Save` 方法儲存已加密的投影片。

以下範例程式碼示範如何加密投影片：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **在投影片上設定寫入保護** 

您可以在投影片上加入「請勿修改」的標記，告知使用者您不希望他們變更投影片內容。

**注意：** 寫入保護過程不會加密投影片。因此，使用者若願意，仍然可以修改投影片，但若要儲存變更，必須以不同的檔名儲存。

要設定寫入保護，請使用 `SetWriteProtection` 方法。以下範例程式碼示範如何在投影片上設定寫入保護：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **載入加密的投影片**

Aspose.Slides 允許您在提供正確密碼的情況下載入加密的投影片。以下範例程式碼示範如何載入加密的投影片：

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 處理已解密的投影片。
}
```

## **移除投影片的加密**

您可以移除投影片的加密或密碼保護，讓使用者在無任何限制的情況下存取或修改投影片。

若要移除加密或密碼保護，請呼叫 [RemoveEncryption](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/methods/removeencryption) 方法。以下範例程式碼示範如何移除投影片的加密：

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **移除投影片的寫入保護**

您可以使用 Aspose.Slides 移除投影片檔案的寫入保護。如此一來，使用者即可隨意修改投影片，且不會在執行此類操作時收到任何警告。

您可以透過使用 [RemoveWriteProtection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/methods/removewriteprotection) 方法來移除寫入保護。以下範例程式碼示範如何移除投影片的寫入保護：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **取得加密投影片的屬性**

通常，使用者在取得加密或受密碼保護的投影片之文件屬性時會遇到困難。然而，Aspose.Slides 提供了一種機制，允許您在對投影片設定密碼保護的同時，仍保有讓使用者存取其屬性的能力。

**注意：** 預設情況下，當 Aspose.Slides 加密投影片時，投影片的文件屬性也會受到密碼保護。若您需要在加密後仍能存取文件屬性，Aspose.Slides 可讓您如此設定。

若要讓使用者在加密投影片後仍能存取其屬性，您可以將 [EncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) 屬性設為 `true`。以下範例程式碼示範如何在加密投影片的同時，仍提供使用者存取文件屬性的功能：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **檢查投影片是否受密碼保護**

在載入投影片之前，您可能需要先檢查它是否已設定密碼保護。這可避免在未提供正確密碼的情況下載入受密碼保護的投影片時發生錯誤或類似問題。

以下 C# 程式碼示範如何在不實際載入投影片的前提下，檢查投影片是否受密碼保護：

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **檢查投影片是否已加密**

Aspose.Slides 允許您檢查投影片是否已加密。為執行此檢查，您可使用 [IsEncrypted](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/properties/isencrypted) 屬性，若投影片已加密則回傳 `true`，未加密則回傳 `false`。

以下範例程式碼示範如何檢查投影片是否已加密：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **檢查投影片是否受寫入保護**

Aspose.Slides 允許您檢查投影片是否受寫入保護。為執行此檢查，您可使用 [IsWriteProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/properties/iswriteprotected) 屬性，若投影片受寫入保護則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查投影片是否受寫入保護：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **驗證投影片密碼使用情況**

您可能想要檢查並確認特定密碼已被用於保護投影片文件。Aspose.Slides 提供驗證密碼的方式。

以下範例程式碼示範如何驗證密碼：

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // 檢查密碼是否匹配。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

如果投影片已使用指定密碼加密，會回傳 `true`；否則回傳 `false`。

{{% alert color="primary" title="另請參閱" %}} 
- [PowerPoint 中的數位簽章](/slides/zh-hant/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **線上為投影片設定密碼保護**

1. 前往我們的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock) 網頁。 
2. 點選 **Drop or upload your files**。 
3. 從電腦中選取要設定密碼保護的檔案。 
4. 輸入您想用於編輯保護的密碼，以及用於檢視保護的密碼。 
5. 若希望使用者將投影片視為最終版本，勾選 **Mark as final** 核取方塊。 
6. 點選 **PROTECT NOW.** 
7. 點選 **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **常見問答**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密演算法，包括基於 AES 的演算法，確保投影片資料具高安全性。

**如果在開啟投影片時輸入錯誤的密碼會發生什麼情況？**

系統會拋出例外，提示存取投影片被拒絕。此機制可防止未授權的存取，保護投影片內容。

**在處理受密碼保護的投影片時是否會影響效能？**

加解密過程可能在開啟與儲存時略增負荷。大多數情況下，效能影響甚微，並不會顯著延長投影片處理的整體時間。