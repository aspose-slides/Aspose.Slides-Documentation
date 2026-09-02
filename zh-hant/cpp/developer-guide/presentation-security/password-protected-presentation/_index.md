---
title: 在 C++ 中使用密碼保護簡報
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
description: "了解如何使用 Aspose.Slides for C++ 輕鬆鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 簡報。保護您的簡報。"
---
## **簡介**

當您對簡報設定密碼保護時，表示您正在設置一組密碼，以對簡報實施特定限制。要解除這些限制，必須輸入密碼。受密碼保護的簡報被視為已鎖定的簡報。

通常，您可以設定密碼以對簡報施加以下限制：

- **修改**

  若您只希望特定使用者修改簡報，則可以設定修改限制。此限制可防止人員在未提供密碼的情況下修改、更改或複製簡報中的內容。

  但是，即使沒有密碼，使用者仍可存取您的文件並開啟它。以唯讀模式時，使用者可以檢視簡報內的內容或項目（超連結、動畫、效果等），但無法複製項目或儲存簡報。

- **開啟**

  若您只希望特定使用者開啟簡報，則可以設定開啟限制。此限制可防止人員在未提供密碼的情況下甚至檢視簡報內容。

  從技術上講，開啟限制亦會阻止使用者修改簡報：當使用者無法開啟簡報時，便無法對其進行任何修改。

  **Note** that when you password protect a presentation to prevent opening, the presentation file becomes encrypted.

## **如何在線對簡報設定密碼保護**

1. 前往我們的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock) 頁面。  

   ![todo:image_alt_text](slides-lock.png)

2. 點擊 **Drop or upload your files**。

3. 在電腦上選取您想要設定密碼保護的檔案。

4. 輸入您偏好的編輯保護密碼；輸入您偏好的檢視保護密碼。

5. 若您希望使用者看到最終版的簡報，勾選 **Mark as final** 核取方塊。

6. 點擊 **PROTECT NOW.** 

7. 點擊 **DOWNLOAD NOW.**

## **Aspose.Slides 中的簡報密碼保護**
**支援的格式**

Aspose.Slides 支援以下格式的簡報密碼保護、加密及相關操作：

- PPTX 與 PPT - Microsoft PowerPoint 簡報
- ODP - OpenDocument 簡報
- OTP - OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您以以下方式使用密碼保護簡報，以防止修改：

- 加密簡報
- 為簡報設定寫入保護

**其他操作**

Aspose.Slides 亦提供以下與密碼保護與加密相關的功能：

- 解密簡報；開啟已加密的簡報
- 移除加密；停用密碼保護
- 從簡報中移除寫入保護
- 取得已加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否受密碼保護。

## **加密簡報**

您可以透過設定密碼來加密簡報。之後若要修改已鎖定的簡報，使用者必須提供密碼。

要加密或對簡報設定密碼保護，您必須使用 encrypt 方法（來自 [ProtectionManager](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager)）為簡報設定密碼。將密碼傳遞給 encrypt 方法，然後使用 save 方法儲存已加密的簡報。

以下範例程式碼示範如何加密簡報：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **為簡報設定寫入保護**

您可以在簡報中加入「請勿修改」標記，以告知使用者您不希望他們對簡報做出變更。

**Note** that the write protection process does not encrypt the presentation. Therefore, users—if they actually want to—can modify the presentation, but to save the changes, they will have to create a presentation with a different name.

要設定寫入保護，必須使用 setWriteProtection 方法。以下範例程式碼示範如何為簡報設定寫入保護：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **載入已加密的簡報**

Aspose.Slides 允許您在傳入密碼後載入已加密的檔案。要解密簡報，必須呼叫 [RemoveEncryption](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法且不帶參數。接著您需要輸入正確的密碼才能載入簡報。

以下範例程式碼示範如何解密簡報：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 使用已解密的簡報
```

## **從簡報中移除加密**

您可以移除簡報的加密或密碼保護，讓使用者能在沒有任何限制的情況下存取或修改簡報。

要移除加密或密碼保護，必須呼叫 [RemoveEncryption](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法。以下範例程式碼示範如何從簡報中移除加密：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **從簡報中移除寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此一來，使用者即可自由修改，且執行此類操作時不會收到任何警告。

您可以使用 [RemoveWriteProtection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) 方法移除寫入保護。以下範例程式碼示範如何從簡報中移除寫入保護：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **取得已加密簡報的屬性**

通常使用者在取得已加密或受密碼保護的簡報的文件屬性時會遇到困難。然而，Aspose.Slides 提供了一種機制，讓您在對簡報設定密碼保護的同時，仍能存取其文件屬性。

**Note:** By default, when Aspose.Slides encrypts a presentation, the presentation’s document properties are also password protected. If you need to make the document properties accessible even after encryption, Aspose.Slides allows you to do precisely that.

若您希望使用者在簡報加密後仍能存取其屬性，請將 `false` 傳遞給 [IProtectionManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/) 的 `set_EncryptDocumentProperties` 方法。以下範例程式碼示範如何在加密簡報的同時仍提供使用者存取文件屬性的能力：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **僅載入已加密簡報的文件屬性**

若要在不載入投影片或其他內容的情況下檢查已加密簡報的中繼資料，請建立一個 [LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/) 物件，並將 `set_OnlyLoadDocumentProperties` 設為 `true`。在此模式下，Aspose.Slides 會忽略密碼，僅載入可公開存取的文件屬性。

以下程式碼範例透過 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_documentproperties/) 讀取內建與自訂文件屬性：

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

此工作流程僅在簡報加密時文件屬性已被設定為未加密（公開）時可行。若文件屬性已加密，將 `LoadOptions::set_OnlyLoadDocumentProperties` 設為 `true` 會拋出例外，因為在此模式下密碼會被忽略。如需存取已加密的文件屬性或載入包括投影片在內的完整簡報，請在 [LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/) 中使用正確的密碼設定 `LoadOptions::set_Password`。

## **檢查簡報是否受密碼保護**

在載入簡報之前，您可能想先確認該簡報是否已設定密碼保護。這可避免在未提供密碼的情況下載入受保護簡報時產生錯誤或其他問題。

以下 C++ 程式碼示範如何檢查簡報是否受密碼保護（不實際載入簡報）：

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。您可以使用 [get_IsEncrypted()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) 方法，它在簡報已加密時返回 `true`，未加密時返回 `false`。

以下範例程式碼示範如何檢查簡報是否已加密：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **檢查簡報是否寫入受保護**

Aspose.Slides 允許您檢查簡報是否寫入受保護。您可以使用 [get_IsWriteProtected()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) 方法，它在簡報寫入受保護時返回 `true`，未受保護時返回 `false`。

以下範例程式碼示範如何檢查簡報是否寫入受保護：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **驗證簡報密碼使用情形**

您可能想確認特定密碼是否已被用於保護簡報文件。Aspose.Slides 提供驗證密碼的功能。

以下範例程式碼示範如何驗證密碼：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// 檢查 "pass" 是否匹配
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

若簡報已使用指定密碼加密，則返回 `true`；否則返回 `false`。

{{% alert color="primary" title="另請參閱" %}} 
- [Digital Signature in PowerPoint](/slides/zh-hant/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的簡報資料具備高度安全性。

**當嘗試開啟簡報時輸入錯誤密碼會發生什麼情況？**

若使用錯誤的密碼，系統會拋出例外，提示存取簡報被拒絕。這有助於防止未授權的存取並保護簡報內容。

**使用受密碼保護的簡報時會有性能影響嗎？**

加解密過程在開啟與儲存時可能會產生輕微的額外負擔。大多數情況下，這種性能影響較小，並不會顯著影響簡報任務的整體處理時間。