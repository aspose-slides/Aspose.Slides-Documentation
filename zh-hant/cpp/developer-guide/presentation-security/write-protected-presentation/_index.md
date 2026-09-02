---
title: 在 C++ 中寫入保護簡報
linktitle: 寫入保護
type: docs
weight: 25
url: /zh-hant/cpp/write-protected-presentation/
keywords:
- 寫入保護
- 寫入保護 PowerPoint
- 修改密碼
- 限制簡報編輯
- 移除寫入保護
- 驗證修改密碼
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint PPT 與 PPTX 簡報中設定、偵測、驗證及移除寫入保護密碼。"
---
## **簡介**

寫入保護密碼會限制簡報的修改，但不會加密其內容。使用者可以在未輸入密碼的情況下載入並檢視受寫入保護的簡報。根據應用程式的不同，他們也可能可以編輯內容並以不同的名稱儲存，因此寫入保護不應視為保密機制。

開啟密碼的目的不同：它會加密簡報，且需要它才能載入內容。若要加密簡報或驗證開啟密碼，請參閱 [Password-Protect Presentations](/slides/zh-hant/cpp/password-protected-presentation/)。

本篇文章中的工作流程同時適用於 PPT 與 PPTX 簡報。範例使用 PPTX 檔案；若要儲存為 PPT，請使用 `.ppt` 副檔名與相應的 PPT 儲存格式。

## **設定簡報的寫入保護**

使用 [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) 為簡報指定修改密碼。儲存簡報時會保留保護設定。

以下範例為 PPTX 簡報設定寫入保護：

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **載入受寫入保護的簡報**

由於寫入保護不會加密簡報內容，載入簡報時不需要密碼。密碼僅在驗證修改受保護簡報的授權時才相關。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

不要將寫入保護密碼傳遞給 [LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/)。此屬性僅接受加密內容的開啟密碼。若簡報同時具有兩種保護，請提供開啟密碼以載入，並另行處理寫入保護密碼。

## **從簡報移除寫入保護**

使用 [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) 解除修改限制，然後儲存簡報。

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **檢查簡報是否已寫入保護**

若要在不建立完整的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 實例的情況下檢查檔案，請呼叫 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 並檢查 [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/)。此屬性使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/nullablebool/)，當偵測到寫入保護時會傳回 `NullableBool::True`。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 的串流重載提供相同的資訊，適用於以串流方式提供的簡報。

## **驗證寫入保護密碼**

使用 [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) 在未載入完整簡報的情況下驗證修改密碼。先檢查 [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/)，以便應用程式僅在存在寫入保護時才要求或驗證密碼。

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) 僅驗證寫入保護密碼。它不會驗證開啟密碼，也不會判斷是否可以載入加密內容。相反地，[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/checkpassword/) 僅驗證開啟密碼。若已載入完整的簡報，[IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) 可透過其保護管理員執行相同的寫入保護檢查。

在正式環境的應用程式中，請勿記錄密碼或將其包含於診斷訊息中。避免不必要的重複驗證，並且僅在需要時才在記憶體中保留密碼。

{{% alert color="info" title="另請參閱" %}}
- [Password-Protect Presentations](/slides/zh-hant/cpp/password-protected-presentation/)
- [Read-Only Presentations](/slides/zh-hant/cpp/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**寫入保護會加密簡報嗎？**

不會。它限制修改，但仍允許載入與檢視簡報內容。

**開啟簡報是否需要寫入保護密碼？**

不需要。僅需開啟密碼即可載入加密的簡報內容。

**簡報可以同時具有開啟密碼與寫入保護密碼嗎？**

可以。透過載入選項提供開啟密碼以開啟加密的簡報，並在需要修改授權時另行驗證寫入保護密碼。