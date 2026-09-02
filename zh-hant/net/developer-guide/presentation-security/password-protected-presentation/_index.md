---
title: .NET 中以密碼保護的投影片安全性
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/net/password-protected-presentation/
keywords:
- 鎖定 PowerPoint
- 鎖定投影片
- 解除鎖定 PowerPoint
- 解除鎖定投影片
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
description: "了解如何使用 Aspose.Slides for .NET 輕鬆鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 投影片，為您的投影片提供安全保護。"
---
## **簡介**

當您對投影片設定密碼保護時，表示您正在設定一組密碼，以對投影片實施特定限制。若要移除這些限制，必須輸入密碼。受密碼保護的投影片被視為已鎖定的投影片。

通常，您可以設定密碼以對投影片強制這些限制：

- **修改**

如果您只希望特定使用者修改您的投影片，您可以設定修改限制。此限制會阻止未提供密碼的人對投影片的元素進行修改、變更或複製。  

然而，即使未輸入密碼，使用者仍可存取並開啟您的文件。於唯讀模式下，使用者可以檢視投影片內的內容——包括超連結、動畫、特效與其他元素——但無法複製項目或儲存投影片。

- **開啟**

如果您只希望特定使用者開啟您的投影片，您可以設定開啟限制。此限制會阻止未提供密碼的人甚至檢視投影片的內容。  

從技術上說，開啟限制同時也會阻止使用者修改投影片——若無法開啟投影片，就無法對其進行修改或變更。

**注意：**當您以密碼保護投影片以防止開啟時，投影片檔案會被加密。

## **Aspose.Slides 中的密碼保護**

**支援的格式**

Aspose.Slides 支援以下格式的投影片進行密碼保護、加密等操作：

- PPTX 和 PPT – Microsoft PowerPoint 投影片
- ODP – OpenDocument 投影片
- OTP – OpenDocument 投影片範本

**支援的操作**

Aspose.Slides 允許您以以下方式使用密碼保護來防止投影片被修改：

- 加密投影片
- 對投影片設定寫入保護

**其他操作**

Aspose.Slides 允許您以以下方式執行與密碼保護和加密相關的其他工作：

- 解密投影片；開啟加密的投影片
- 移除加密；停用密碼保護
- 從投影片中移除寫入保護
- 取得加密投影片的屬性
- 在載入之前檢查投影片是否受密碼保護
- 檢查投影片是否已加密
- 檢查投影片是否受密碼保護

## **使用密碼保護投影片**

您可以透過設定密碼來加密投影片。之後，要修改已鎖定的投影片，使用者必須提供密碼。

為了加密（或密碼保護）投影片，請使用來自[ProtectionManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager)的`Encrypt`方法設定密碼。將密碼傳遞給`Encrypt`方法，然後使用`Save`方法儲存已加密的投影片。

此範例程式碼示範如何加密投影片：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **對投影片設定寫入保護**

您可以在投影片上加入「請勿修改」的標記。此標記告知使用者您不希望他們對投影片進行變更。

**注意：**寫入保護過程不會加密投影片。因此，使用者—如果他們願意—仍可修改投影片，但若要儲存變更，必須以不同的檔名儲存。

要設定寫入保護，請使用`SetWriteProtection`方法。此範例程式碼示範如何對投影片設定寫入保護：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **載入加密的投影片**

Aspose.Slides 允許您在提供正確密碼的情況下載入加密的投影片。此範例程式碼示範如何載入加密的投影片：

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 使用已解密的投影片。
}
```

## **從投影片中移除加密**

您可以移除投影片的加密或密碼保護，讓使用者可以無限制地存取或修改投影片。

若要移除加密或密碼保護，請呼叫[RemoveEncryption](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/methods/removeencryption)方法。此範例程式碼示範如何從投影片中移除加密：

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **從投影片中移除寫入保護**

您可以使用 Aspose.Slides 移除投影片檔案的寫入保護。這樣，使用者即可任意修改投影片，且在執行此類操作時不會收到任何警告。

您可以透過使用[RemoveWriteProtection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/methods/removewriteprotection)方法移除寫入保護。此範例程式碼示範如何從投影片中移除寫入保護：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **取得加密投影片的屬性**

通常，使用者難以取得加密或受密碼保護投影片的文件屬性。然而，Aspose.Slides 提供了一種機制，允許您在對投影片設定密碼保護的同時，仍保留使用者存取其屬性的能力。

**注意：**預設情況下，Aspose.Slides 加密投影片時，投影片的文件屬性也會受到密碼保護。如需在加密後仍能存取文件屬性，Aspose.Slides 允許您這麼做。

若要讓使用者在加密投影片後仍能存取其屬性，請將[IProtectionManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/)的`EncryptDocumentProperties`屬性設為`false`。此範例程式碼示範如何在加密投影片的同時，仍提供使用者存取文件屬性的功能：

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **僅從加密投影片載入文件屬性**

若要在不載入投影片頁面或其他內容的情況下檢查加密投影片的中繼資料，請建立一個[LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/)物件，並將[OnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/onlyloaddocumentproperties/)設為`true`。在此模式下，Aspose.Slides 會忽略密碼，只載入可公開存取的文件屬性。

以下程式碼範例透過[IPresentation.DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/documentproperties/)讀取內建與自訂文件屬性：

```c#
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

此工作流程僅在投影片加密時，文件屬性保持未加密（公開）時有效。若文件屬性已加密，將`OnlyLoadDocumentProperties`設為`true`會拋出例外，因為此模式下會忽略密碼。若要存取加密的文件屬性或載入完整的投影片（包括頁面與其他內容），請在[LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/)中提供正確的`Password`值。

## **檢查投影片是否受密碼保護**

在載入投影片之前，您可能想先確認該投影片未受到密碼保護。這可避免在未提供正確密碼而載入受密碼保護的投影片時發生錯誤或類似問題。

此 C# 程式碼示範如何在不實際載入投影片的情況下檢查投影片是否受密碼保護：

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **檢查投影片是否已加密**

Aspose.Slides 允許您檢查投影片是否已加密。您可以使用[IsEncrypted](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/properties/isencrypted)屬性，若投影片已加密則返回`true`，否則返回`false`。

此範例程式碼示範如何檢查投影片是否已加密：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **檢查投影片是否寫入受保護**

Aspose.Slides 允許您檢查投影片是否寫入受保護。您可以使用[IsWriteProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/protectionmanager/properties/iswriteprotected)屬性，若投影片寫入受保護則返回`true`，否則返回`false`。

此範例程式碼示範如何檢查投影片是否寫入受保護：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **驗證投影片密碼的使用**

您可能想要確認特定密碼已被用於保護投影片文件。Aspose.Slides 提供驗證密碼的方式。

此範例程式碼示範如何驗證密碼：

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // 檢查密碼是否匹配。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

若投影片已使用指定密碼加密，則返回`true`；否則返回`false`。

{{% alert color="primary" title="另請參閱" %}} 
- [PowerPoint 的數位簽章](/slides/zh-hant/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **線上密碼保護投影片**

1. 前往我們的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock) 頁面。 
2. 點擊 **Drop or upload your files**。 
3. 在電腦上選取您想要設定密碼保護的檔案。 
4. 輸入您希望的編輯保護密碼以及檢視保護密碼。 
5. 如果您希望使用者將投影片視為最終版本，勾選 **Mark as final** 核取方塊。 
6. 點擊 **PROTECT NOW.** 
7. 點擊 **DOWNLOAD NOW.** 

![密碼保護 PowerPoint 投影片](slides-lock.png)

## **常見問題**

**What encryption methods are supported by Aspose.Slides?**  
Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的投影片具備高度的資料安全性。

**What happens if an incorrect password is entered when attempting to open a presentation?**  
若使用錯誤的密碼，系統會拋出例外，提示您無法存取投影片。此機制有助於防止未授權存取，保護投影片內容。

**Are there any performance implications when working with password-protected presentations?**  
加密與解密過程在開啟與儲存時可能會產生輕微的額外負擔。大多數情況下，此效能影響很小，不會顯著延長投影片任務的總處理時間。