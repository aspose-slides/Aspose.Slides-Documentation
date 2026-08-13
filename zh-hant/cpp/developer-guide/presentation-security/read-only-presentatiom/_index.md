---
title: 使用 C++ 以唯讀模式儲存簡報
linktitle: 唯讀簡報
type: docs
weight: 30
url: /zh-hant/cpp/read-only-presentation/
keywords:
- 唯讀
- 保護簡報
- 防止編輯
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 以唯讀模式載入和儲存 PowerPoint 檔案（PPT、PPTX），提供精確的投影片預覽且不會更改您的簡報。"
---
## **簡介**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 設定，作為使用者用來保護簡報的選項之一。您可能想在以下情況下使用此唯讀設定來保護簡報：

- 您希望防止意外編輯，並保持簡報內容的安全。
- 您希望提醒他人您提供的簡報是最終版本。

在為簡報選取 **Always Open Read-Only** 選項後，使用者開啟簡報時，會看到 **Read-Only** 建議，並可能看到以下訊息：*To prevent accidental changes, the author has set this file to open as read-only.*

Read-Only 建議是一種簡單卻有效的阻嚇方式，因為使用者必須先執行步驟才能移除該建議，才能編輯簡報。如果您不希望使用者更改簡報，且想以禮貌的方式告知他們，Read-Only 建議可能是個不錯的選擇。

> 如果在較舊的 Microsoft PowerPoint 應用程式中開啟帶有 **Read-Only** 保護的簡報——該程式不支援最近推出的功能——則 **Read-Only** 建議會被忽略（簡報會正常開啟）。

## **套用唯讀模式**

Aspose.Slides for C++ 允許您將簡報設定為 **Read-Only**，這表示使用者（在開啟簡報後）會看到 **Read-Only** 建議。以下範例程式碼示範如何在 C++ 中使用 Aspose.Slides 將簡報設定為 **Read-Only**：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 
**注意**：**Read-Only** 建議僅旨在阻止編輯或避免使用者對 PowerPoint 簡報造成意外變更。如果一個有動機且懂得如何操作的人決定編輯您的簡報，他們可以輕易移除唯讀設定。如果您真的需要防止未授權的編輯，最好使用[更嚴格的加密與密碼保護](https://docs.aspose.com/slides/zh-hant/cpp/password-protected-presentation/)。 
{{% /alert %}} 

## **常見問題**

### 「Read-Only recommended」與完整密碼保護有何不同？

「Read-Only recommended」僅顯示以唯讀模式開啟檔案的建議，且容易繞過。[密碼保護](/slides/zh-hant/cpp/password-protected-presentation/) 真的會限制開啟或編輯，當您需要真正的安全控制時，這是適當的做法。

### 「Read-Only recommended」可以與浮水印結合以進一步阻止編輯嗎？

是的。此建議可與[浮水印](/slides/zh-hant/cpp/watermark/) 搭配使用，作為視覺阻嚇；它們是獨立的機制，且能很好地協同運作。

### 啟用建議時，巨集或外部工具仍能修改檔案嗎？

是的。此建議不會阻止程式化的變更。若要防止自動化編輯，請使用[密碼與加密](/slides/zh-hant/cpp/password-protected-presentation/)。

### 「Read-Only recommended」與「is encrypted」和「is write protected」旗標有何關聯？

它們是不同的訊號。「Read-Only recommended」是一個柔性的、可選的提示；[get_IsWriteProtected](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) 與 [get_IsEncrypted](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/protectionmanager/get_isencrypted/) 表示實際的寫入或讀取限制，這取決於密碼或加密。