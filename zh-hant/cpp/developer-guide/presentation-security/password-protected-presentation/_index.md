---
title: 在 C++ 中對簡報進行密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/cpp/password-protected-presentation/
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
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides 加密、偵測、驗證、開啟以及解密受密碼保護的 PowerPoint PPT 與 PPTX 簡報。"
---
## **概觀**

開啟密碼會對簡報進行加密。必須輸入正確的密碼才能載入並檢視簡報內容，因而提供機密性。

開啟密碼不同於寫入保護密碼。寫入保護限制修改，但不會加密內容，也不會阻止簡報被載入。如需管理簡報的修改密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/cpp/write-protected-presentation/)。

以下工作流程同時適用於 PPT 和 PPTX 簡報。範例同時使用兩種格式，以說明檔案與串流行為的差異。

## **使用開啟密碼加密簡報**

使用[IProtectionManager::Encrypt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/encrypt/)指派開啟密碼，然後使用[IPresentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/save/)將加密後的簡報寫入。

以下範例會加密一個 PPTX 簡報：

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

## **將文件屬性設為公開**

預設情況下，Aspose.Slides 會將文件屬性納入簡報加密。[IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/)可獨立於投影片內容加密控制此行為。在呼叫[IProtectionManager::Encrypt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/encrypt/)之前，將此方法的參數設為`false`，以便索引、分類、搜尋或文件管理系統在未提供開啟密碼的情況下讀取中繼資料。

以下範例會產生一個加密的 PPTX 簡報，同時將其內建文件屬性保留為公開：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

將`false`傳遞給`set_EncryptDocumentProperties`不會使投影片、母片、版面配置、圖形、媒體或其他簡報內容公開。它僅影響文件屬性。若要在不載入加密內容的情況下讀取這些屬性，請參閱[Manage Presentation Properties](/slides/zh-hant/cpp/presentation-properties/)。

## **載入加密簡報**

將[LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/)設定為開啟密碼，並在載入檔案時將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)。當需要開啟密碼但未提供或提供錯誤時，載入會失敗。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// 使用已解密的簡報進行操作。
```

## **移除簡報的加密**

以開啟密碼載入簡報，呼叫[IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/removeencryption/)，然後儲存結果。儲存後的簡報即可在不需密碼的情況下載入。

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

## **在載入前驗證開啟密碼**

使用[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)取得[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/)，而不必建立完整的簡報實例。於要求或驗證密碼之前，先檢查[IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/)。若已受到保護，使用[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/checkpassword/)驗證提供的值。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/)，然後載入完整簡報：

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

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/)的串流重載提供相同的工作流程。在從該串流載入完整簡報之前，先將可搜尋串流的位置重設。

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/checkpassword/)僅在簡報具有開啟密碼且提供的密碼正確時回傳`true`。在以下情況皆回傳`false`：

- 密碼不正確。
- 簡報未設定開啟密碼。
- 提供的密碼為`null`或空字串。

PPT 與 PPTX 簡報的行為相同。

## **檢查已載入的簡報是否已加密**

載入正確密碼的簡報後，檢查[IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/get_isencrypted/)以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請如上使用`IPresentationInfo::get_IsPasswordProtected`。

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
請勿記錄開啟密碼或將其寫入診斷訊息。避免不必要的重複驗證，僅在需要時將密碼保留於記憶體中，並在立即載入簡報時重複使用已成功驗證的結果。

即使簡報內容已加密，公開的文件屬性仍可能洩漏作者姓名、標題、主旨、關鍵字、公司資訊、註解以及自訂值。請將敏感的中繼資料與簡報一起加密。僅在系統必須在未提供開啟密碼的情況下進行索引、分類、搜尋或管理檔案時，才明確決定將屬性設為公開。
{{% /alert %}}

## **線上為簡報設定密碼保護**

1. 開啟[Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock)應用程式。  
2. 選取或上傳簡報。  
3. 輸入用於檢視保護的密碼。  
4. （可選）輸入用於編輯保護的另一組密碼。  
5. 套用保護並下載產生的檔案。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh-hant/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且必須提供才能載入其內容。寫入保護密碼僅限制修改，並不加密內容。

**可以在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，並在建立完整簡報實例前驗證密碼。

**應用程式可以在未提供開啟密碼的情況下讀取中繼資料嗎？**

可以，但前提是簡報在加密時使用了`set_EncryptDocumentProperties(false)`。此時應用程式必須使用[Manage Presentation Properties](/slides/zh-hant/cpp/presentation-properties/)中描述的僅讀取文件屬性的模式。

**密碼檢查工作流程是否同時支援 PPT 與 PPTX？**

是的。檔案路徑與串流基礎的密碼偵測與驗證在 PPT 與 PPTX 簡報中行為相同。