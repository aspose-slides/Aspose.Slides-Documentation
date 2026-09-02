---
title: 在 C++ 中對簡報設定密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/cpp/password-protected-presentation/
keywords:
- 已受密碼保護的簡報
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
- C++
- Aspose.Slides
description: 在 C++ 中使用 Aspose.Slides 加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 與 PPTX 簡報。
---
## **概觀**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因此此保護提供機密性。

開啟密碼與寫入保護密碼不同。寫入保護限制修改，但不會加密內容或阻止載入簡報。若要管理修改簡報的密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/cpp/write-protected-presentation/)。

以下工作流程適用於 PPT 和 PPTX 簡報。範例同時使用兩種格式，以說明檔案式與串流式行為的重要性。

## **使用開啟密碼加密簡報**

使用[IProtectionManager::Encrypt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/encrypt/)指定開啟密碼。然後使用[IPresentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/save/)儲存加密後的簡報。

以下範例會加密 PPTX 簡報：

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **載入加密的簡報**

將[LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/)設定為開啟密碼，並在載入檔案時將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)。當需要開啟密碼但未提供或提供的密碼不正確時，載入將失敗。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// 與已解密的簡報一起工作。
```

## **移除簡報的加密**

使用開啟密碼載入簡報，呼叫[IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/removeencryption/)，並儲存結果。此後即可在不需密碼的情況下載入已儲存的簡報。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **在載入之前驗證開啟密碼**

使用[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)取得[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/)，而不必建立完整的簡報實例。在請求或驗證密碼之前，先檢查[IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/)。若存在保護，請使用[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/checkpassword/)驗證提供的值。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/)，然後載入完整的簡報：

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **串流工作流程**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)的串流重載提供相同的工作流程。載入完整簡報前，先重設可搜尋串流的位置。

以下範例使用 PPT 檔案：

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **CheckPassword 回傳值**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/checkpassword/)僅在簡報具有開啟密碼且提供的密碼正確時回傳 `true`。在以下情況皆會回傳 `false`：

- 密碼不正確。
- 簡報沒有開啟密碼。
- 提供的密碼為 null 或空字串。

此行為在 PPT 與 PPTX 簡報中相同。

## **檢查已載入的簡報是否已加密**

使用正確密碼載入簡報後，檢查[IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/get_isencrypted/)以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請如上使用`IPresentationInfo::get_IsPasswordProtected`。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **安全性建議**

{{% alert color="warning" title="Security" %}}
請勿記錄開啟密碼或在診斷訊息中包含它們。避免不必要的重複驗證嘗試，僅在需要時將密碼保留在記憶體中，並在立即載入簡報時重複使用成功的驗證結果。
{{% /alert %}}

## **線上為簡報設定密碼保護**

1. 開啟 [Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock) 應用程式。
1. 選取或上傳簡報。
1. 輸入用於檢視保護的密碼。
1. 可選擇輸入另一個用於編輯保護的密碼。
1. 套用保護並下載產生的檔案。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh-hant/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且在載入內容時必須提供。寫入保護密碼僅限制修改，並不會加密內容。

**我可以在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，然後在建立完整簡報實例之前驗證密碼。

**密碼檢查工作流程是否同時支援 PPT 與 PPTX？**

可以。檔案路徑和串流式的密碼偵測與驗證在 PPT 與 PPTX 簡報中皆以相同方式運作。