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
description: "了解如何使用 Aspose.Slides for C++ 輕鬆鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 簡報。保護您的簡報安全。"
---
## **簡介**

當您對簡報設定密碼保護時，表示您正在設定一組密碼，以對簡報施加特定限制。若要解除這些限制，必須輸入密碼。受密碼保護的簡報被視為已鎖定的簡報。

通常，您可以設定密碼以對簡報施加以下限制：

- **修改**

  若您只希望某些使用者能修改簡報，可設定修改限制。此限制會阻止未提供密碼的人修改、變更或複製簡報中的內容。

  但是，即使未輸入密碼，使用者仍可以存取並開啟文件。此時處於唯讀模式，使用者可以檢視簡報內的內容或項目（如超連結、動畫、效果等），但無法複製項目或儲存簡報。

- **開啟**

  若您只希望特定使用者能開啟簡報，可設定開啟限制。此限制會阻止未提供密碼的人檢視簡報內容。

  從技術上來說，開啟限制同時也會阻止使用者修改簡報：當使用者無法開啟簡報時，亦無法對其進行修改。

  **注意** 當您以防止開啟的方式為簡報設定密碼保護時，簡報檔案會被加密。

## **線上為簡報設定密碼保護的方式**

1. 前往我們的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock)頁面。

   ![todo:image_alt_text](slides-lock.png)

2. 點選**Drop or upload your files**。

3. 從電腦中選取您要設定密碼保護的檔案。

4. 輸入您偏好的編輯保護密碼；輸入您偏好的檢視保護密碼。

5. 若您希望使用者將簡報視為最終版本，請勾選**Mark as final**核取方塊。

6. 點選**PROTECT NOW.**  

7. 點選**DOWNLOAD NOW.**

## **Aspose.Slides 中的簡報密碼保護**
**支援的格式**

Aspose.Slides 支援以下格式的簡報之密碼保護、加密及類似操作：

- PPTX 與 PPT - Microsoft PowerPoint 簡報  
- ODP - OpenDocument 簡報  
- OTP - OpenDocument 簡報範本  

**支援的操作**

Aspose.Slides 允許您以以下方式對簡報設定密碼保護，以防止修改：

- 加密簡報  
- 設定簡報的寫入保護  

**其他操作**

Aspose.Slides 允許您以以下方式執行其他與密碼保護與加密相關的工作：

- 解密簡報；開啟已加密的簡報  
- 移除加密；停用密碼保護  
- 移除簡報的寫入保護  
- 取得已加密簡報的屬性  
- 檢查簡報是否已加密  
- 檢查簡報是否受密碼保護  

## **加密簡報**

您可以透過設定密碼來加密簡報。之後，若要修改已鎖定的簡報，使用者必須提供密碼。

要加密或為簡報設定密碼保護，必須使用 [ProtectionManager](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager) 的 encrypt 方法為簡報設定密碼。將密碼傳入 encrypt 方法，然後使用 save 方法儲存已加密的簡報。

以下範例程式碼示範如何加密簡報：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **為簡報設定寫入保護** 

您可以在簡報上加入「請勿修改」標記，告知使用者您不希望他們對簡報進行變更。

**注意** 寫入保護的過程不會加密簡報。因此，使用者若真的想修改簡報，仍可進行修改，只是儲存變更時需要另存為不同名稱的檔案。

要設定寫入保護，必須使用 setWriteProtection 方法。以下範例程式碼示範如何為簡報設定寫入保護：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **載入已加密的簡報**

Aspose.Slides 允許您在傳入密碼後載入已加密的檔案。若要解密簡報，必須呼叫 [RemoveEncryption](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法且不帶參數，之後再輸入正確的密碼以載入簡報。

以下範例程式碼示範如何解密簡報：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 使用已解密的簡報
```

## **從簡報中移除加密**

您可以移除簡報的加密或密碼保護，讓使用者能在不受限制的情況下存取或修改簡報。

要移除加密或密碼保護，必須呼叫 [RemoveEncryption](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法。以下範例程式碼示範如何從簡報中移除加密：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **從簡報中移除寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。這樣使用者即可自由修改，且不會在執行此類操作時收到任何警告。

您可以透過呼叫 [RemoveWriteProtection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) 方法來移除寫入保護。以下範例程式碼示範如何從簡報中移除寫入保護：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **取得已加密簡報的屬性**

通常使用者難以取得已加密或受密碼保護的簡報之文件屬性。Aspose.Slides 提供了一種機制，讓您在為簡報設定密碼保護的同時，仍保留使用者存取該簡報屬性的方式。

**注意** 當 Aspose.Slides 加密簡報時，簡報的文件屬性也會預設受到密碼保護。但若您需要在簡報加密後仍讓屬性可被存取，Aspose.Slides 允許您如此操作。

若您希望使用者在您加密的簡報上仍能存取屬性，可將 `true` 傳入 [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) 方法。以下範例程式碼示範如何在加密簡報的同時，提供使用者存取文件屬性的功能：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **檢查簡報是否受密碼保護**

在載入簡報之前，您可能想先檢查並確認該簡報未被密碼保護。如此可避免在未提供密碼的情況下載入受保護簡報時產生錯誤或類似問題。

以下 C++ 程式碼示範如何在不載入簡報本體的情況下，檢查簡報是否受密碼保護：

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。為執行此任務，可使用 [get_IsEncrypted()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) 方法，若簡報已加密則回傳 `true`，未加密則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否已加密：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **檢查簡報是否受寫入保護**

Aspose.Slides 允許您檢查簡報是否受寫入保護。為執行此任務，可使用 [get_IsWriteProtected()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) 方法，若簡報受寫入保護則回傳 `true`，未受保護則回傳 `false`。

以下範例程式碼示範如何檢查簡報是否受寫入保護：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **驗證簡報密碼的使用情況**

您可能想確認特定密碼是否已用於保護簡報文件。Aspose.Slides 提供驗證密碼的功能。

以下範例程式碼示範如何驗證密碼：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// 檢查 "pass" 是否匹配
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

若簡報已使用指定密碼加密，會回傳 `true`；否則回傳 `false`。

{{% alert color="primary" title="See also" %}} 
- [PowerPoint 中的數位簽章](/slides/zh-hant/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援現代加密方法，包括基於 AES 的演算法，確保您的簡報資料具備高度安全性。

**如果在開啟簡報時輸入錯誤的密碼會發生什麼情況？**

系統會拋出例外，提示存取簡報被拒絕，從而防止未授權的存取並保護簡報內容。

**在處理受密碼保護的簡報時會有性能影響嗎？**

加密與解密過程可能在開啟與儲存時帶來輕微的額外開銷。在大多數情況下，這種性能影響微乎其微，不會顯著影響簡報任務的整體處理時間。