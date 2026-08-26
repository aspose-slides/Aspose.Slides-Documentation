---
title: 在 Python 中對簡報設置寫入保護
linktitle: 寫入保護
type: docs
weight: 25
url: /zh-hant/python-net/write-protected-presentation/
keywords:
- write protection
- write-protect PowerPoint
- password to modify
- restrict presentation editing
- remove write protection
- validate modification password
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 在 PowerPoint PPT 與 PPTX 簡報中設定、偵測、驗證與移除寫入保護密碼。"
---
## **簡介**

寫入保護密碼會限制簡報的修改，但不會加密其內容。使用者在未提供密碼的情況下仍能載入並檢視受寫入保護的簡報。視應用程式而定，他們也可能能編輯內容並以不同名稱儲存，因此寫入保護不應被視為機密機制。

開啟密碼則用途不同：它會加密簡報，且在載入內容時必須提供。若要加密簡報或驗證開啟密碼，請參閱[Password-Protect Presentations](/slides/zh-hant/python-net/password-protected-presentation/)。

本篇文章的工作流程同時適用於 PPT 與 PPTX 簡報。範例使用 PPTX 檔案；若儲存為 PPT，請使用 `.ppt` 副檔名並使用對應的 PPT 儲存格式。

## **設定簡報的寫入保護**

使用[ProtectionManager.set_write_protection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/set_write_protection/)為簡報指定修改密碼。儲存簡報時會保留此保護設定。

以下範例在 PPTX 簡報上設定寫入保護：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **載入受寫入保護的簡報**

因寫入保護不會加密簡報內容，載入簡報時不需要密碼。密碼僅在驗證是否有權限修改受保護的簡報時才相關。

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

請勿將寫入保護密碼傳遞給[LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/)。該屬性僅接受加密內容的開啟密碼。如果簡報同時具有兩種保護，請以開啟密碼載入簡報，並另行處理寫入保護密碼。

## **移除簡報的寫入保護**

使用[ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/remove_write_protection/)移除修改限制，然後儲存簡報。

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **檢查簡報是否受寫入保護**

若要在不建立完整[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)實例的情況下檢查檔案，呼叫[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 並檢視[PresentationInfo.is_write_protected](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/is_write_protected/)。此屬性使用[NullableBool](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/nullablebool/) 並在偵測到寫入保護時回傳 `NullableBool.TRUE`。

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 的串流重載也會提供相同資訊，適用於以串流形式提供的簡報。

## **驗證寫入保護密碼**

使用[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/check_write_protection/) 可在未載入完整簡報的情況下驗證修改密碼。請先檢查[PresentationInfo.is_write_protected](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/is_write_protected/)，如此應用程式只在存在寫入保護時才要求或驗證密碼。

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/check_write_protection/) 僅驗證寫入保護密碼，並不驗證開啟密碼或判斷是否能載入加密內容。相對地，[PresentationInfo.check_password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/check_password/) 僅驗證開啟密碼。若已載入完整簡報，可透過[ProtectionManager.check_write_protection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/check_write_protection/) 以保護管理員的方式執行等效的寫入保護檢查。

在正式環境中，請勿記錄密碼或將其寫入診斷訊息。避免不必要的重複驗證，並僅在需要時於記憶體中保留密碼。

{{% alert color="info" title="另見" %}}
- [Password-Protect Presentations](/slides/zh-hant/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/zh-hant/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**寫入保護會加密簡報嗎？**

不會。它限制修改，但仍可載入與檢視簡報內容。

**開啟簡報需要寫入保護密碼嗎？**

不需要。僅需開啟密碼即可載入加密的簡報內容。

**簡報可以同時擁有開啟密碼與寫入保護密碼嗎？**

可以。請透過載入選項提供開啟密碼以開啟加密簡報，並在需要修改授權時另行驗證寫入保護密碼。