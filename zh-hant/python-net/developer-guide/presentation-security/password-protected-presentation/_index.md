---
title: 使用 Python 以密碼保護簡報安全
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/python-net/password-protected-presentation/
keywords:
- 鎖定 PowerPoint
- 鎖定簡報
- 解鎖 PowerPoint
- 解鎖簡報
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
- PowerPoint 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 輕鬆鎖定與解鎖受密碼保護的 PowerPoint 與 OpenDocument 簡報。透過步驟指南提升生產力，確保簡報安全。"
---
## **簡介**

當您對簡報設定密碼保護時，即表示您正在設定一組密碼，以對簡報施加特定限制。若要移除這些限制，必須輸入密碼。受密碼保護的簡報被視為已鎖定的簡報。

一般而言，您可以設定密碼以對簡報施加以下限制：

- **修改**

  如果您只想讓特定使用者修改您的簡報，您可以設定修改限制。此限制會阻止他人修改、變更或複製簡報中的內容（除非提供密碼）。

  然而，在此情況下，即使未輸入密碼，使用者仍可存取並開啟您的文件。於唯讀模式下，使用者可檢視簡報內的內容或項目（如超連結、動畫、特效等），但無法複製項目或儲存簡報。

- **開啟**

  如果您只想讓特定使用者開啟您的簡報，您可以設定開啟限制。此限制會阻止他人甚至檢視簡報內容（除非提供密碼）。

  從技術角度來看，開啟限制同樣會防止使用者修改簡報：當使用者無法開啟簡報時，亦無法對其進行修改或變更。

  **注意** 當您以密碼保護簡報以阻止開啟時，簡報檔案將會被加密。

## 如何線上為簡報設定密碼保護

1. 前往我們的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock) 頁面。 

   ![todo:image_alt_text](slides-lock.png)

2. 點擊 **拖放或上傳您的檔案**。

3. 在您的電腦上選取要設定密碼保護的檔案。 

4. 輸入您偏好的編輯保護密碼；輸入您偏好的檢視保護密碼。 

5. 若您希望使用者將簡報視為最終版，勾選 **Mark as final** 核取方塊。

6. 點擊 **PROTECT NOW.** 

7. 點擊 **DOWNLOAD NOW.**

## **Aspose.Slides 簡報的密碼保護**
**支援的格式**

Aspose.Slides 在以下格式的簡報中支援密碼保護、加密及類似操作：

- PPTX and PPT - Microsoft PowerPoint 簡報 
- ODP - OpenDocument 簡報 
- OTP - OpenDocument 簡報範本 

**支援的操作**

Aspose.Slides 允許您以密碼保護簡報，以以下方式防止修改：

- 加密簡報
- 為簡報設定寫入保護

**其他操作**

Aspose.Slides 允許您以以下方式執行其他與密碼保護和加密相關的任務：

- 解密簡報；開啟已加密的簡報
- 移除加密；停用密碼保護
- 移除簡報的寫入保護
- 取得已加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否受密碼保護

## **加密簡報**

您可以透過設定密碼來加密簡報。之後，若要修改已鎖定的簡報，使用者必須提供密碼。

若要加密或設定密碼保護簡報，您必須使用 encrypt 方法（來自 [ProtectionManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/)）為簡報設定密碼。將密碼傳遞給 encrypt 方法，然後使用 save 方法儲存已加密的簡報。

以下範例程式碼示範如何加密簡報：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **為簡報設定寫入保護**

您可以在簡報上加入「請勿修改」的標記。如此即可告知使用者您不希望他們變更簡報。

**注意** 寫入保護過程不會加密簡報。因此，使用者—若真的想—仍可修改簡報，但若要儲存變更，必須以不同的名稱建立簡報。

若要設定寫入保護，您必須使用 setWriteProtection 方法。以下範例程式碼示範如何為簡報設定寫入保護：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **解密簡報；開啟已加密的簡報**

Aspose.Slides 允許您透過傳入密碼來載入已加密的檔案。若要解密簡報，您必須呼叫 [remove_encryption](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 方法且不帶參數。之後您須輸入正確的密碼以載入簡報。

以下範例程式碼示範如何解密簡報：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **移除加密；停用密碼保護**

您可以移除簡報的加密或密碼保護。如此，使用者即可在無限制的情況下存取或修改簡報。

若要移除加密或密碼保護，您必須呼叫 [remove_encryption](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 方法。以下範例程式碼示範如何從簡報中移除加密：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **移除簡報的寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此，使用者可隨意修改，且在執行此類操作時不會收到警告。

您可以透過使用 [remove_write_protection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 方法來移除簡報的寫入保護。以下範例程式碼示範如何移除簡報的寫入保護：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **取得已加密簡報的屬性**

通常，使用者很難取得已加密或受密碼保護簡報的文件屬性。然而，Aspose.Slides 提供一種機制，使您在對簡報設定密碼保護的同時，仍保留使用者存取該簡報屬性的方式。

**注意** 當 Aspose.Slides 加密簡報時，簡報的文件屬性預設也會受到密碼保護。但若您需要在簡報加密後仍能存取其屬性，Aspose.Slides 可讓您精確做到這點。

若您希望使用者仍能存取您加密的簡報屬性，您可以將 [EncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 屬性設為 `True`。以下範例程式碼示範如何在加密簡報的同時提供使用者存取其文件屬性的方式：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **在載入簡報前檢查其是否受密碼保護**

在載入簡報之前，您可能想先檢查並確認簡報未受到密碼保護。如此可避免在未提供密碼就載入受密碼保護的簡報時發生錯誤和類似問題。

以下 Python 程式碼示範如何檢查簡報是否受密碼保護（而不真正載入簡報）：

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。執行此操作時，您可以使用 [is_encrypted](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 屬性，若簡報已加密則回傳 `True`，未加密則回傳 `False`。

以下範例程式碼示範如何檢查簡報是否已加密：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **檢查簡報是否受寫入保護**

Aspose.Slides 允許您檢查簡報是否受到寫入保護。執行此操作時，您可以使用 [is_write_protected](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 屬性，若簡報受寫入保護則回傳 `True`，未受寫入保護則回傳 `False`。

以下範例程式碼示範如何檢查簡報是否受寫入保護：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **驗證或確認已使用特定密碼保護簡報**

您可能想檢查並確認已使用特定密碼來保護簡報文件。Aspose.Slides 提供驗證密碼的功能。

以下範例程式碼示範如何驗證密碼：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # 檢查 "pass" 是否匹配
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

若簡報已使用指定密碼加密，則回傳 `True`；否則回傳 `False`。

{{% alert color="primary" title="另請參閱" %}} 
- [PowerPoint 中的數位簽章](/slides/zh-hant/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援包含 AES 系列演算法在內的現代加密方法，確保您的簡報資料具備高度的安全性。

**若在嘗試開啟簡報時輸入錯誤的密碼會發生什麼情況？**

若使用錯誤的密碼，系統會拋出例外，提醒您無法存取簡報。此機制可防止未授權存取，保護簡報內容。

**在使用受密碼保護的簡報時，是否會有效能影響？**

加密與解密過程可能在開啟和儲存操作時稍微增加負荷。大多數情況下，此效能影響極小，並不會顯著延長簡報任務的總處理時間。