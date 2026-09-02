---
title: 在 .NET 中寫入保護簡報
linktitle: 寫入保護
type: docs
weight: 25
url: /zh-hant/net/write-protected-presentation/
keywords:
- 寫入保護
- 寫入保護 PowerPoint
- 修改密碼
- 限制簡報編輯
- 移除寫入保護
- 驗證修改密碼
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPT 和 PPTX 簡報中設定、偵測、驗證與移除寫入保護密碼。"
---
## **簡介**

寫入保護密碼會限制簡報的修改，但不會加密其內容。使用者可以在不需密碼的情況下載入並檢視受寫入保護的簡報。根據應用程式不同，他們也可能能編輯內容並以不同名稱儲存，因此寫入保護不應被視為保密機制。

開啟密碼則用途不同：它會加密簡報，且載入內容時必須提供。若要加密簡報或驗證開啟密碼，請參閱[Password-Protect Presentations](/slides/zh-hant/net/password-protected-presentation/)。

本篇文章的工作流程同時適用於 PPT 與 PPTX 簡報。範例使用 PPTX 檔案；若儲存為 PPT，請使用`.ppt`副檔名與相對應的 PPT 儲存格式。

## **設定簡報的寫入保護**

使用[IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/setwriteprotection/)為簡報指派修改密碼。儲存簡報時會保留此保護設定。

以下範例在 PPTX 簡報上設定寫入保護：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **載入受寫入保護的簡報**

由於寫入保護不會加密簡報內容，載入簡報時不需要密碼。密碼僅在驗證是否有權限修改受保護簡報時才相關。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

不要將寫入保護密碼傳遞給[LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/)。該屬性只接受用於加密內容的開啟密碼。如果簡報同時具有兩種保護，請先提供開啟密碼載入簡報，然後再另行處理寫入保護密碼。

## **移除簡報的寫入保護**

使用[IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/removewriteprotection/)移除修改限制，之後儲存簡報。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **檢查簡報是否受到寫入保護**

若想在不建立完整[Presentation]((https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/))實例的情況下檢查檔案，呼叫[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationfactory/getpresentationinfo/)並檢查[IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/iswriteprotected/)。此屬性使用[NullableBool](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/nullablebool/)且在偵測到寫入保護時返回`NullableBool.True`。

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationfactory/getpresentationinfo/)的串流重載亦提供相同資訊，適用於以串流方式提供的簡報。

## **驗證寫入保護密碼**

使用[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/checkwriteprotection/)在不載入完整簡報的情況下驗證修改密碼。請先檢查[IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/iswriteprotected/)，以確保僅在簡報受寫入保護時才要求或驗證密碼。

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/checkwriteprotection/)僅驗證寫入保護密碼，並不驗證開啟密碼或判斷是否能載入加密內容。相對地，[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/checkpassword/)僅驗證開啟密碼。若已載入完整簡報，則[IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/checkwriteprotection/)可透過其保護管理員執行等效的寫入保護檢查。

在正式應用程式中，請勿記錄密碼或將其寫入診斷訊息。避免不必要的重複驗證，且僅在需要時於記憶體中保留密碼。

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/zh-hant/net/password-protected-presentation/)
- [Read-Only Presentations](/slides/zh-hant/net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**寫入保護會加密簡報嗎？**

不會。它僅限制修改，且簡報內容仍可載入與檢視。

**開啟簡報是否需要寫入保護密碼？**

不需要。只有開啟密碼才是載入加密簡報內容所必需的。

**簡報可以同時具有開啟密碼與寫入保護密碼嗎？**

可以。請透過載入選項提供開啟密碼以開啟加密簡報，然後在需要授權修改時另行驗證寫入保護密碼。