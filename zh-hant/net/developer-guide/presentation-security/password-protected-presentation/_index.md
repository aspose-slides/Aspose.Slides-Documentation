---
title: 在 .NET 中對簡報設定密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/net/password-protected-presentation/
keywords:
- 已加密的簡報
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
- .NET
- C#
- Aspose.Slides
description: "在 C# 中使用 Aspose.Slides for .NET 加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 與 PPTX 簡報。"
---
## **概觀**

開啟密碼會加密簡報。必須提供正確的密碼才能載入與檢視簡報內容，因而提供保密性。

開啟密碼與寫入保護密碼不同。寫入保護會限制修改，但不加密內容，也不阻止載入簡報。若要管理簡報的修改密碼，請參閱[寫入保護簡報](/slides/zh-hant/net/write-protected-presentation/)。

以下工作流程同時適用於 PPT 與 PPTX 簡報。範例在兩種格式下皆有展示其檔案基礎與串流基礎行為的重要性。

## **使用開啟密碼加密簡報**

使用[IProtectionManager.Encrypt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/encrypt/) 指定開啟密碼。然後使用[IPresentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/save/) 以保存加密後的簡報。

以下範例會加密 PPTX 簡報：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **載入已加密的簡報**

將[LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 設為開啟密碼，並在載入檔案時將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)。如果需要開啟密碼但未提供或提供的密碼不正確，載入將失敗。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// 使用已解密的簡報。
```

## **移除簡報的加密**

使用開啟密碼載入簡報，呼叫[IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/removeencryption/)，然後保存結果。之後即可在不提供密碼的情況下載入已保存的簡報。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **載入前驗證開啟密碼**

使用[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationfactory/getpresentationinfo/) 取得[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/)，而不必建立完整的簡報實例。於請求或驗證密碼之前，先檢查[IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/ispasswordprotected/)。若存在保護，請使用[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/checkpassword/) 來驗證提供的密碼。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/)，然後載入完整的簡報：

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **串流工作流程**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationfactory/getpresentationinfo/) 的串流重載提供相同的工作流程。在從該串流載入完整簡報之前，請先重設可查詢串流的位置。

以下範例使用 PPT 檔案：

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **CheckPassword 回傳值**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/checkpassword/) 只在簡報具備開啟密碼且提供的密碼正確時回傳 `true`。在以下情況皆會回傳 `false`：

- 密碼不正確。
- 簡報沒有開啟密碼。
- 提供的密碼為 `null` 或空字串。

PPT 與 PPTX 簡報的行為相同。

## **檢查已載入的簡報是否已加密**

使用正確密碼載入簡報後，檢查[IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/isencrypted/) 以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，可使用上方示範的 `IPresentationInfo.IsPasswordProtected`。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **安全性建議**

{{% alert color="warning" title="安全性" %}}
不要記錄開啟密碼或將其包含在診斷訊息中。避免不必要的重複驗證嘗試，僅在需要時將密碼保留於記憶體中，並在立即載入簡報時重複使用成功的驗證結果。
{{% /alert %}}

## **線上為簡報設定密碼保護**

1. 開啟 [Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock) 應用程式。
2. 選取或上傳簡報。
3. 輸入檢視保護的密碼。
4. （可選）為編輯保護輸入另一組密碼。
5. 套用保護並下載產生的檔案。

{{% alert color="info" title="另請參閱" %}}
- [寫入保護簡報](/slides/zh-hant/net/write-protected-presentation/)
- [PowerPoint 數位簽章](/slides/zh-hant/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且必須提供才能載入其內容。寫入保護密碼則僅限制修改，且不會加密內容。

**我可以在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，並在建立完整簡報實例之前驗證密碼。

**密碼驗證工作流程是否同時支援 PPT 與 PPTX？**

支援。檔案路徑與串流方式的密碼偵測與驗證在 PPT 與 PPTX 簡報中行為相同。