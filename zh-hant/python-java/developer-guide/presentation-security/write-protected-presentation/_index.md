---
title: 在 Python 中寫入保護簡報
linktitle: 寫入保護
type: docs
weight: 25
url: /zh-hant/python-java/write-protected-presentation/
keywords:
- 寫入保護
- 寫入保護 PowerPoint
- 修改密碼
- 限制簡報編輯
- 移除寫入保護
- 驗證修改密碼
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，在 PowerPoint PPT 與 PPTX 簡報中設定、偵測、驗證與移除寫入保護密碼。"
---
## **簡介**

寫入保護密碼會限制簡報的修改，但不會加密其內容。使用者可以在不輸入密碼的情況下載入並檢視寫入保護的簡報。根據不同的應用程式，使用者也可能編輯內容並以不同名稱儲存，因此寫入保護不應被視為機密機制。

開啟密碼則有不同的目的：它會加密簡報，且載入內容時需要提供。若要加密簡報或驗證開啟密碼，請參閱 [Password-Protect Presentations](/slides/zh-hant/python-java/password-protected-presentation/)。

本文章的工作流程適用於 PPT 與 PPTX 簡報。範例使用 PPTX 檔案；若儲存為 PPT，請使用 `.ppt` 副檔名與相對應的 PPT 儲存格式。

## **設定簡報的寫入保護**

使用 [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#setWriteProtection) 為簡報設定修改密碼。儲存簡報時會保留此保護設定。

以下範例在 PPTX 簡報上設定寫入保護：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **載入寫入保護的簡報**

由於寫入保護不會加密簡報內容，載入簡報時不需要密碼。此密碼僅在驗證修改受保護簡報的授權時才相關。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

不要將寫入保護密碼傳遞給 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword)。該方法接受用於加密內容的開啟密碼。若簡報同時具有兩種保護，請提供開啟密碼以載入簡報，並分別處理寫入保護密碼。

## **移除簡報的寫入保護**

使用 [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#removeWriteProtection) 解除修改限制，然後儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **檢查簡報是否具寫入保護**

若要在不建立完整的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例的情況下檢查檔案，呼叫 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 並檢視 [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#isWriteProtected)。該方法使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/nullablebool/) 並在偵測到寫入保護時返回 `NullableBool.True_`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 的串流重載可針對以串流提供的簡報提供相同資訊。

## **驗證寫入保護密碼**

使用 [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#checkWriteProtection) 在未載入完整簡報的情況下驗證修改密碼。請先檢查 [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#isWriteProtected)，以便應用程式僅在存在寫入保護時才要求或驗證密碼。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#checkWriteProtection) 僅驗證寫入保護密碼。它不會驗證開啟密碼，也不會判斷是否能載入加密內容。相反地，[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#checkPassword) 僅驗證開啟密碼。若已載入完整簡報，則可透過 [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#checkWriteProtection) 以其保護管理器執行等效的寫入保護檢查。

在正式環境的應用程式中，請勿記錄密碼或將其寫入診斷訊息。避免不必要的重複驗證，且僅在需要時於記憶體中保留密碼。

{{% alert color="info" title="另請參閱" %}}
- [密碼保護簡報](/slides/zh-hant/python-java/password-protected-presentation/)
- [唯讀簡報](/slides/zh-hant/python-java/read-only-presentation/)
- [PowerPoint 中的數位簽章](/slides/zh-hant/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**寫入保護會加密簡報嗎？**

不會。它僅限制修改，但仍允許載入與檢視簡報內容。

**開啟簡報時需要寫入保護密碼嗎？**

不需要。只有開啟密碼是載入已加密簡報內容所必需的。

**簡報可以同時擁有開啟密碼與寫入保護密碼嗎？**

可以。請透過載入選項提供開啟密碼以開啟加密的簡報，並在需要修改授權時另行驗證寫入保護密碼。