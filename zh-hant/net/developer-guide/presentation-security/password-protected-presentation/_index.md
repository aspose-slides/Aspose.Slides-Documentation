---
title: 在 .NET 中以密碼保護簡報
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/net/password-protected-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET，輕鬆鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 簡報，保護您的簡報。"
---
## **簡介**

當您以密碼保護投影片時，表示您設定了一組密碼，該密碼會對投影片施加特定限制。若要移除這些限制，必須輸入密碼。受密碼保護的投影片被視為已鎖定的投影片。

通常，您可以設定密碼以在投影片上強制執行這些限制：

- **Modification**

如果您只希望特定使用者修改您的投影片，您可以設定修改限制。此限制會阻止未提供密碼的人修改、更改或複製投影片中的元素。  
然而，即使沒有密碼，使用者仍然可以存取並開啟您的文件。於唯讀模式下，使用者可以檢視投影片內的內容（包括超連結、動畫、特效及其他元素），但無法複製項目或儲存投影片。

- **Opening**

如果您只希望特定使用者開啟投影片，您可以設定開啟限制。此限制會阻止未提供密碼的人甚至檢視投影片內容。  
從技術上說，開啟限制同樣會防止使用者修改投影片——如果無法開啟投影片，就無法修改或變更內容。

**注意：** 當您以密碼保護投影片以防止開啟時，投影片檔案會被加密。

## **Aspose.Slides 中的密碼保護**

**支援的格式**

Aspose.Slides 支援對以下格式的投影片進行密碼保護、加密等操作：

- PPTX 與 PPT – 微軟 PowerPoint 簡報
- ODP – OpenDocument 簡報
- OTP – OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您以以下方式使用密碼保護投影片以防止修改：

- 對投影片加密
- 設定投影片的寫入保護

**其他操作**

Aspose.Slides 允許您以以下方式執行其他涉及密碼保護與加密的任務：

- 解密投影片；開啟已加密的投影片
- 移除加密；停用密碼保護
- 移除投影片的寫入保護
- 取得已加密投影片的屬性
- 載入前檢查投影片是否受密碼保護
- 檢查投影片是否已加密
- 檢查投影片是否受密碼保護

## **以密碼保護投影片**

您可以透過設定密碼來加密投影片。之後，若要修改已鎖定的投影片，使用者必須提供密碼。

要加密（或以密碼保護）投影片，請使用來自[ProtectionManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager)的`Encrypt`方法設定密碼。將密碼傳遞給`Encrypt`方法，然後使用`Save`方法儲存已加密的投影片。

以下範例程式碼示範如何加密投影片：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **設定投影片的寫入保護** 

您可以在投影片上加入「請勿修改」的標記。此標記會告知使用者您不希望他們對投影片進行變更。

**注意：** 寫入保護過程不會加密投影片。因此，使用者—若願意—仍可修改投影片，但若要儲存變更，必須另存新檔。

要設定寫入保護，請使用`SetWriteProtection`方法。以下範例程式碼示範如何在投影片上設定寫入保護：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **載入已加密的投影片**

Aspose.Slides 可讓您透過傳入正確的密碼載入已加密的投影片。以下範例程式碼示範如何載入已加密的投影片：

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 使用已解密的簡報。
}
```

## **自投影片中移除加密**

您可以從投影片中移除加密或密碼保護，使使用者在無限制的情況下存取或修改投影片。

若要移除加密或密碼保護，請呼叫[RemoveEncryption](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/methods/removeencryption)方法。以下範例程式碼示範如何自投影片中移除加密：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **自投影片中移除寫入保護**

您可以使用 Aspose.Slides 移除投影片檔案的寫入保護。這樣，使用者即可自行修改投影片，且在執行此類操作時不會收到任何警告。

您可以透過使用[RemoveWriteProtection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/methods/removewriteprotection)方法來移除寫入保護。以下範例程式碼示範如何自投影片中移除寫入保護：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **取得已加密投影片的屬性**

通常，使用者在取得已加密或受密碼保護投影片的文件屬性時會遇到困難。然而，Aspose.Slides 提供了一種機制，讓您在以密碼保護投影片的同時，仍保留使用者存取其屬性的能力。

**注意：** 預設情況下，當 Aspose.Slides 加密投影片時，投影片的文件屬性也會受到密碼保護。若您需要在加密後仍能存取文件屬性，Aspose.Slides 允許您如此設定。

若您希望使用者仍能存取已加密投影片的屬性，請將[IProtectionManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/)的`EncryptDocumentProperties`屬性設定為`false`。以下範例程式碼示範如何在加密投影片的同時，仍讓使用者存取其文件屬性：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **僅從已加密投影片載入文件屬性**

若要在不載入投影片或其他內容的情況下檢查已加密投影片的中繼資料，請建立一個[LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/)物件，並將[OnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/onlyloaddocumentproperties/)設定為`true`。在此模式下，Aspose.Slides 會忽略密碼，僅載入可公開存取的文件屬性。

以下程式碼範例透過[IPresentation.DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/documentproperties/)讀取內建與自訂的文件屬性：

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

此工作流程僅在投影片加密時文件屬性保持未加密（公開）時可運作。若文件屬性已加密，將`OnlyLoadDocumentProperties`設定為`true`會導致例外，因為此模式會忽略密碼。若要存取已加密的文件屬性或載入完整的投影片（包括投影片與其他內容），請在[LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/)中提供正確的`Password`值。

## **檢查投影片是否受密碼保護**

在載入投影片之前，您可能想先檢查其是否已被密碼保護。這樣可避免在未提供正確密碼載入受密碼保護的投影片時發生錯誤或類似問題。

此 C# 程式碼示範如何檢查投影片是否受密碼保護，而不實際載入投影片：

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **檢查投影片是否已加密**

Aspose.Slides 允許您檢查投影片是否已加密。執行此操作時，可使用[IsEncrypted](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/properties/isencrypted)屬性，若投影片已加密則回傳`true`，未加密則回傳`false`。

以下範例程式碼示範如何檢查投影片是否已加密：

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **檢查投影片是否受寫入保護**

Aspose.Slides 允許您檢查投影片是否受寫入保護。執行此操作時，可使用[IsWriteProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/properties/iswriteprotected)屬性，若投影片受寫入保護則回傳`true`，未受保護則回傳`false`。

以下範例程式碼示範如何檢查投影片是否受寫入保護：

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **驗證投影片密碼的使用情形**

您可能想要檢查並確認特定密碼已用於保護投影片文件。Aspose.Slides 提供了驗證密碼的方法。

以下範例程式碼示範如何驗證密碼：

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // 檢查密碼是否匹配。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

若投影片已使用指定密碼加密，則回傳`true`；否則回傳`false`。

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/zh-hant/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **線上以密碼保護投影片**

1. 前往我們的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock)頁面。 
1. 點選**Drop or upload your files**。 
1. 在電腦上選取您想要以密碼保護的檔案。 
1. 輸入您用於編輯保護的密碼以及用於檢視保護的密碼。 
1. 若您希望使用者將投影片視為最終版，勾選**Mark as final**核取方塊。 
1. 點選**PROTECT NOW.** 
1. 點選**DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的投影片具有高層次的資料安全性。

**當嘗試開啟投影片時輸入錯誤密碼會發生什麼情況？**

如果使用錯誤的密碼，系統會拋出例外，提示您無法存取投影片。此機制有助於防止未授權存取並保護投影片內容。

**在處理受密碼保護的投影片時會有性能影響嗎？**

加密與解密過程可能在開啟與儲存時產生輕微的額外負載。大多數情況下，這種效能影響很小，對投影片任務的總處理時間不會有顯著影響。