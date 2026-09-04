---
title: 在 .NET 中對簡報設置密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/net/password-protected-presentation/
keywords:
- 受密碼保護的簡報
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
description: "使用 Aspose.Slides for .NET 在 C# 中加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 與 PPTX 簡報。"
---
## **概觀**

開啟密碼會加密簡報。載入與檢視簡報內容時必須提供正確的密碼，因而此保護提供了機密性。

開啟密碼不同於寫入保護密碼。寫入保護會限制修改，但不會加密內容，也不會阻止簡報被載入。若要管理修改簡報的密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/net/write-protected-presentation/)。

以下工作流程同時適用於 PPT 與 PPTX 簡報。範例同時使用兩種格式，因為檔案與串流的行為皆很重要。

## **使用開啟密碼加密簡報**

使用[IProtectionManager.Encrypt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/encrypt/) 指定開啟密碼。然後使用[IPresentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/save/) 儲存加密後的簡報。

以下範例會加密一個 PPTX 簡報：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **將文件屬性保持為公開**

預設情況下，Aspose.Slides 會在簡報加密時包含文件屬性。[IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 屬性可在不影響投影片內容加密的情況下，獨立控制此行為。當索引、分類、搜尋或文件管理系統必須在不提供開啟密碼的前提下讀取中繼資料時，請在呼叫[IProtectionManager.Encrypt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/encrypt/) 之前將其設定為`false`。

以下範例會建立一個加密的 PPTX 簡報，同時保留其內建文件屬性為公開：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

將`EncryptDocumentProperties` 設為`false` 並不會讓投影片、母片、版面配置、形狀、媒體或其他簡報內容變為公開。它僅影響文件屬性。若要在不載入加密內容的情況下讀取這些屬性，請參閱[Manage Presentation Properties](/slides/zh-hant/net/presentation-properties/)。

## **載入加密的簡報**

在載入檔案時，將[LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 設為開啟密碼，並將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)。如果需要開啟密碼但未提供或密碼不正確，載入會失敗。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// 使用已解密的簡報。
```

## **移除簡報的加密**

使用開啟密碼載入簡報，呼叫[IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/removeencryption/)，然後儲存結果。儲存後的簡報即可在不需要密碼的情況下載入。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **在載入前驗證開啟密碼**

使用[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationfactory/getpresentationinfo/) 取得[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/) 而不必建立完整的簡報實例。於要求或驗證密碼前，先檢查[IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/ispasswordprotected/)。如果已設定保護，使用[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/checkpassword/) 驗證提供的值。

### **檔案路徑工作流程**

以下範例會驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/)，然後載入完整的簡報：

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

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationfactory/getpresentationinfo/) 的串流重載提供相同的工作流程。在從該串流載入完整簡報之前，請先將可搜尋的串流位置重設。

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

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/checkpassword/) 只在簡報具有開啟密碼且提供的密碼正確時回傳`true`。在以下情況皆回傳`false`：

- 密碼不正確。
- 簡報沒有開啟密碼。
- 提供的密碼為`null` 或空字串。

PPT 與 PPTX 簡報的行為相同。

## **檢查已載入的簡報是否已加密**

在使用正確密碼載入簡報後，檢查[IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/isencrypted/) 以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請如上使用`IPresentationInfo.IsPasswordProtected`。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **安全性建議**

{{% alert color="warning" title="Security" %}}
不要記錄開啟密碼或將其寫入診斷訊息。避免不必要的重複驗證嘗試，僅在需要時將密碼保留於記憶體中，並在立即載入簡報時重用成功的驗證結果。

即使簡報內容已加密，公開的文件屬性仍可能洩漏作者名稱、標題、主旨、關鍵字、公司資訊、註解與自訂值。應將敏感的中繼資料與簡報一起加密。將屬性設為公開應僅在系統必須在未取得開啟密碼的前提下進行索引、分類、搜尋或管理檔案時，才作為明確決策。
{{% /alert %}}

## **線上為簡報設定密碼保護**

1. 開啟[Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock) 應用程式。
1. 選取或上傳簡報。
1. 輸入用於檢視保護的密碼。
1.（可選）輸入用於編輯保護的另一組密碼。
1. 套用保護並下載產生的檔案。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh-hant/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問答**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且必須在載入內容時提供。寫入保護密碼則僅限制修改，並不加密內容。

**我可以在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，然後在建立完整簡報實例之前驗證密碼。

**應用程式可以在沒有開啟密碼的情況下讀取中繼資料嗎？**

可以，但前提是簡報在加密時將`EncryptDocumentProperties` 設為`false`。此時應用程式必須使用[Manage Presentation Properties](/slides/zh-hant/net/presentation-properties/) 中描述的僅讀文件屬性模式。

**密碼驗證工作流程是否同時支援 PPT 與 PPTX？**

是的。檔案路徑與串流方式的密碼偵測與驗證在 PPT 與 PPTX 簡報中行為相同。