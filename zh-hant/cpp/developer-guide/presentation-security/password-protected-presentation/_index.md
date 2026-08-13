---
title: 使用 C++ 為簡報設定密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/cpp/password-protected-presentation/
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
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 輕鬆鎖定與解除鎖定受密碼保護的 PowerPoint 和 OpenDocument 簡報，確保您的簡報安全。"
---
## **簡介**

當您為簡報設定密碼保護時，表示您正在設定一組會對簡報實施特定限制的密碼。若要移除這些限制，必須輸入密碼。受密碼保護的簡報視為已鎖定的簡報。

通常，您可以設定密碼以在簡報上強制執行這些限制：

- **修改**

  如果您只想讓特定使用者修改您的簡報，您可以設定修改限制。此限制會阻止人員在未提供密碼的情況下修改、變更或複製簡報中的內容。

  然而，即使未提供密碼，使用者仍能存取您的文件並開啟它。處於唯讀模式時，使用者可以檢視簡報中的內容或項目——超連結、動畫、特效等——但無法複製項目或儲存簡報。

- **開啟**

  如果您只想讓特定使用者開啟您的簡報，您可以設定開啟限制。此限制會阻止人員在未提供密碼的情況下甚至檢視簡報的內容。

  從技術上講，開啟限制也會阻止使用者修改您的簡報：當人員無法開啟簡報時，他們也無法對其進行修改或變更。

  **注意**：當您為防止開啟而對簡報設定密碼保護時，簡報檔案會被加密。

## **如何在線上為簡報設定密碼保護**

1. 前往我們的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock)頁面。

   ![todo:image_alt_text](slides-lock.png)

2. 點擊**將檔案拖放或上傳**。

3. 在電腦上選取您想要設定密碼保護的檔案。

4. 輸入您首選的編輯保護密碼；輸入您首選的檢視保護密碼。

5. 如果您希望使用者看到最終版本的簡報，選取**Mark as final**核取方塊。

6. 點擊**PROTECT NOW.**

7. 點擊**DOWNLOAD NOW.**

## **Aspose.Slides 中的簡報密碼保護**
**支援的格式**

Aspose.Slides 為以下格式的簡報支援密碼保護、加密及類似操作：

- PPTX 與 PPT - Microsoft PowerPoint 簡報
- ODP - OpenDocument 簡報
- OTP - OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您透過以下方式對簡報使用密碼保護以防止修改：

- 加密簡報
- 設定簡報的寫入保護

**其他操作**

Aspose.Slides 允許您以以下方式執行其他涉及密碼保護與加密的工作：

- 解密簡報；開啟已加密的簡報
- 移除加密；停用密碼保護
- 從簡報中移除寫入保護
- 取得已加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否受密碼保護。

## **加密簡報**

您可以透過設定密碼來加密簡報。然後，若要修改已鎖定的簡報，使用者必須提供密碼。

若要加密或設定密碼保護簡報，您必須使用 encrypt 方法（來自[ProtectionManager](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager)）為簡報設定密碼。將密碼傳遞給 encrypt 方法，然後使用 save 方法儲存已加密的簡報。

以下範例程式碼示範如何加密簡報：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **設定簡報的寫入保護**

您可以在簡報上添加「請勿修改」標記。如此一來，您即可告訴使用者您不希望他們對簡報進行變更。

**注意**：寫入保護過程不會加密簡報。因此，使用者——若真的想——仍可修改簡報，但若要儲存變更，必須以不同名稱建立簡報。

若要設定寫入保護，您必須使用 setWriteProtection 方法。以下範例程式碼示範如何對簡報設定寫入保護：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **載入已加密的簡報**

Aspose.Slides 允許您透過傳遞密碼來載入已加密的檔案。若要解密簡報，您必須呼叫[RemoveEncryption](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)方法且不帶參數。之後您需輸入正確的密碼以載入簡報。

以下範例程式碼示範如何解密簡報：

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 使用已解密的簡報
```

## **從簡報中移除加密**

您可以移除簡報的加密或密碼保護。如此一來，使用者即可在無限制的情況下存取或修改簡報。

若要移除加密或密碼保護，您必須呼叫[RemoveEncryption](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)方法。以下範例程式碼示範如何從簡報中移除加密：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **從簡報中移除寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此一來，使用者可以隨意修改——且在執行此類操作時不會收到任何警告。

您可以透過使用[RemoveWriteProtection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50)方法來移除簡報的寫入保護。以下範例程式碼示範如何從簡報中移除寫入保護：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **取得已加密簡報的屬性**

通常，使用者在取得已加密或受密碼保護的簡報文件屬性時會遇到困難。然而，Aspose.Slides 提供了一種機制，使您在對簡報設定密碼保護的同時仍能存取其文件屬性。

**注意**：預設情況下，當 Aspose.Slides 加密簡報時，簡報的文件屬性也會受到密碼保護。如果您需要在加密後仍能存取文件屬性，Aspose.Slides 允許您如此操作。

如果您希望使用者仍能存取已加密簡報的屬性，請對[IProtectionManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/)的`set_EncryptDocumentProperties`方法傳遞 `false`。以下範例程式碼示範如何在加密簡報的同時仍提供使用者存取其文件屬性：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **僅從已加密簡報載入文件屬性**

若要在不載入投影片或其他內容的情況下檢查已加密簡報的中繼資料，請建立一個[LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/)物件，並將[set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) 設為 `true`。在此模式下，Aspose.Slides 會忽略密碼，僅載入可公開存取的文件屬性。

以下程式碼示範透過[IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_documentproperties/) 讀取內建與自訂文件屬性：

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

此工作流程僅在文件屬性在加密簡報時未被加密（即為公開）時有效。如果文件屬性已加密，將 `LoadOptions::set_OnlyLoadDocumentProperties` 設為 `true` 會導致例外，因為在此模式下會忽略密碼。若要存取已加密的文件屬性或載入完整的簡報（包括投影片和其他內容），請在[LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/) 中使用 `LoadOptions::set_Password` 並提供正確的密碼。

## **檢查簡報是否受密碼保護**

在載入簡報之前，您可能想先檢查並確認簡報未被密碼保護。如此一來，您即可避免在未提供密碼而載入受密碼保護的簡報時出現錯誤及類似問題。

以下 C++ 程式碼示範如何在不載入簡報本身的情況下檢查簡報是否受密碼保護：

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。為執行此操作，您可以使用[get_IsEncrypted()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) 方法，若簡報已加密則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否已加密：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **檢查簡報是否受寫入保護**

Aspose.Slides 允許您檢查簡報是否受寫入保護。為執行此操作，您可以使用[get_IsWriteProtected()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) 方法，若簡報受寫入保護則回傳 `true`，否則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否受寫入保護：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **驗證簡報密碼使用情況**

您可能想檢查並確認已使用特定密碼來保護簡報文件。Aspose.Slides 提供驗證密碼的功能。

以下範例程式碼示範如何驗證密碼：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// 檢查 "pass" 是否匹配
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

若簡報已使用指定密碼加密，則回傳 `true`；否則回傳 `false`。

{{% alert color="info" title="另見" %}} 
- [PowerPoint 中的數位簽章](/slides/zh-hant/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援包括基於 AES 的演算法在內的現代加密方法，確保您的簡報具有高水平的資料安全性。

**在嘗試開啟簡報時若輸入錯誤密碼會發生什麼情況？**

若使用錯誤的密碼，系統會拋出例外，提示存取簡報被拒絕。此機制有助於防止未授權的存取並保護簡報內容。

**在處理受密碼保護的簡報時會有性能影響嗎？**

加密與解密過程在開啟與儲存操作時可能會產生輕微的開銷。在大多數情況下，這種性能影響是最小的，且不會顯著影響您的簡報任務的整體處理時間。