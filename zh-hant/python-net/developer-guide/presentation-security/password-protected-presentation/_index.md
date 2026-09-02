---
title: 使用 Python 以密碼保護安全簡報
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/python-net/password-protected-presentation/
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
- PowerPoint 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python 透過 .NET 輕鬆鎖定與解除鎖定受密碼保護的 PowerPoint 與 OpenDocument 簡報。透過我們的逐步指南提升工作效率並確保簡報安全。"
---
## **簡介**

當您為簡報設定密碼保護時，即是設定一組密碼以對簡報施加特定限制。要移除這些限制，必須輸入密碼。受到密碼保護的簡報被視為已鎖定的簡報。

通常，您可以設定密碼以對簡報施加這些限制：

- **修改**

  如果您希望僅特定使用者能修改您的簡報，您可以設定修改限制。此限制會防止人員修改、變更或複製簡報中的內容（除非提供密碼）。

  然而，即使沒有密碼，使用者仍可存取並開啟文件。在唯讀模式下，使用者可以檢視簡報內的內容或項目─超連結、動畫、特效等─但無法複製項目或儲存簡報。

- **開啟**

  如果您希望僅特定使用者能開啟您的簡報，您可以設定開啟限制。此限制會阻止人員甚至檢視簡報的內容（除非提供密碼）。

  從技術上講，開啟限制也會阻止使用者對簡報進行修改：當人員無法開啟簡報時，便無法進行修改或變更。

  **注意** 當您以密碼保護簡報以防止開啟時，簡報檔案會被加密。

## 如何在線上為簡報設定密碼保護

1. 前往我們的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh-hant/lock)頁面。  

   ![todo:image_alt_text](slides-lock.png)

2. 點擊**Drop or upload your files**。

3. 在您的電腦上選取要設定密碼保護的檔案。

4. 輸入您偏好的編輯保護密碼；輸入您偏好的檢視保護密碼。

5. 如果您希望使用者將簡報視為最終版本，請勾選**Mark as final**核取方塊。

6. 點擊**PROTECT NOW.**

7. 點擊**DOWNLOAD NOW.**

## **在 Aspose.Slides 中的簡報密碼保護**
**支援的格式**

Aspose.Slides 支援對以下格式的簡報進行密碼保護、加密及類似操作：

- PPTX 和 PPT - Microsoft PowerPoint 簡報
- ODP - OpenDocument 簡報
- OTP - OpenDocument 簡報範本

**支援的操作**

Aspose.Slides 允許您以以下方式對簡報使用密碼保護以防止修改：

- 加密簡報
- 為簡報設定寫入保護

**其他操作**

Aspose.Slides 允許您以以下方式執行其他與密碼保護和加密相關的任務：

- 解密簡報；開啟已加密的簡報
- 移除加密；停用密碼保護
- 從簡報中移除寫入保護
- 取得已加密簡報的屬性
- 檢查簡報是否已加密
- 檢查簡報是否受密碼保護

## **加密簡報**

您可以透過設定密碼來加密簡報。之後，要修改已鎖定的簡報，使用者必須提供密碼。

要加密或為簡報設定密碼保護，必須使用 encrypt 方法（來自[ProtectionManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/)）為簡報設定密碼。將密碼傳入 encrypt 方法，並使用 save 方法儲存已加密的簡報。

以下範例程式碼示範如何加密簡報：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **為簡報設定寫入保護**

您可以在簡報上加入「Do not modify」標記。如此即可告訴使用者您不希望他們變更簡報。

**注意** 寫入保護過程不會加密簡報。因此，使用者—如果真的想—仍能修改簡報，但若要儲存變更，必須以不同名稱建立簡報。

要設定寫入保護，必須使用 setWriteProtection 方法。以下範例程式碼示範如何為簡報設定寫入保護：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **解密簡報；開啟已加密的簡報**

Aspose.Slides 允許您在傳入密碼後載入已加密的檔案。若要解密簡報，必須呼叫[remove_encryption](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 方法且不帶參數。之後您需要輸入正確的密碼以載入簡報。

以下範例程式碼示範如何解密簡報：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **移除加密；停用密碼保護**

您可以移除簡報的加密或密碼保護。如此一來，使用者即可在沒有任何限制的情況下存取或修改簡報。

若要移除加密或密碼保護，必須呼叫[remove_encryption](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 方法。以下範例程式碼示範如何從簡報中移除加密：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **從簡報中移除寫入保護**

您可以使用 Aspose.Slides 移除簡報檔案上的寫入保護。如此，使用者可以自行修改，而且在執行此類操作時不會收到警告。

可以透過使用 [remove_write_protection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 方法從簡報中移除寫入保護。以下範例程式碼示範如何從簡報中移除寫入保護：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **取得已加密簡報的屬性**

一般而言，使用者很難取得已加密或受密碼保護的簡報之文件屬性。然而，Aspose.Slides 提供了一種機制，使您在對簡報設定密碼保護的同時，仍能保留使用者存取其屬性的能力。

**注意**：預設情況下，當 Aspose.Slides 加密簡報時，簡報的文件屬性也會受到密碼保護。如果您需要在加密後仍能存取文件屬性，Aspose.Slides 允許您如此設定。

若您希望使用者仍能存取已加密簡報的屬性，請將 [ProtectionManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 的 `encrypt_document_properties` 屬性設為 `False`。以下範例程式碼示範如何在加密簡報的同時仍讓使用者存取其文件屬性：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **僅從已加密的簡報載入文件屬性**

若要在不載入投影片或其他內容的情況下檢查已加密簡報的中繼資料，可建立一個 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/) 物件，並將 [only_load_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/only_load_document_properties/) 設為 `True`。在此模式下，Aspose.Slides 會忽略密碼，僅載入可公開存取的文件屬性。

以下程式碼範例透過 [Presentation.document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/document_properties/) 讀取內建文件屬性並列出自訂文件屬性：

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # 讀取內建文件屬性。
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # 列出自訂文件屬性。
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

此工作流程僅在簡報加密時文件屬性保持未加密（公開）時才可運作。若文件屬性已被加密，將 `only_load_document_properties` 設為 `True` 會因密碼在此模式下被忽略而拋出例外。若要存取已加密的文件屬性或載入完整的簡報（包括投影片及其他內容），請在 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/) 中提供正確的 `password` 值。

## **在載入簡報前檢查其是否受密碼保護**

在載入簡報之前，您可能想先檢查並確認該簡報未受到密碼保護。如此即可避免在未提供密碼而載入受密碼保護的簡報時發生的錯誤及類似問題。

以下 Python 程式碼示範如何檢查簡報是否受密碼保護（而不實際載入簡報本身）：

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **檢查簡報是否已加密**

Aspose.Slides 允許您檢查簡報是否已加密。要執行此操作，可使用 [is_encrypted](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 屬性，若簡報已加密則回傳 `True`，否則回傳 `False`。

以下範例程式碼示範如何檢查簡報是否已加密：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **檢查簡報是否受寫入保護**

Aspose.Slides 允許您檢查簡報是否受寫入保護。要執行此操作，可使用 [is_write_protected](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/) 屬性，若簡報受寫入保護則回傳 `True`，否則回傳 `False`。

以下範例程式碼示範如何檢查簡報是否受寫入保護：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **驗證或確認已使用特定密碼保護簡報**

您可能想要檢查並確認已使用特定密碼保護簡報文件。Aspose.Slides 提供驗證密碼的功能。

以下範例程式碼示範如何驗證密碼：

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # 檢查 "pass" 是否匹配
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

如果簡報已使用指定密碼加密，則回傳 `True`；否則回傳 `False`。

{{% alert color="primary" title="另請參閱" %}} 
- [Digital Signature in PowerPoint](/slides/zh-hant/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援哪些加密方法？**

Aspose.Slides 支援包括基於 AES 的現代加密演算法，以確保您的簡報資料具備高水準的安全性。

**當嘗試開啟簡報時輸入錯誤密碼會發生什麼情況？**

如果使用錯誤的密碼，系統會拋出例外，提示您無法存取簡報。此機制可防止未授權的存取並保護簡報內容。

**使用受密碼保護的簡報時會有任何效能影響嗎？**

加密與解密過程可能在開啟與儲存時造成些微額外負擔。大多情況下，此效能影響較小，對簡報任務的整體處理時間影響不大。