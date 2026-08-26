---
title: 在 Python 中以密碼保護簡報
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/python-net/password-protected-presentation/
keywords:
- 受密碼保護的簡報
- 開啟密碼
- 加密 PowerPoint
- 解密 PowerPoint
- 驗證簡報密碼
- 檢查簡報密碼
- 開啟加密的簡報
- 移除加密
- PowerPoint
- PPT
- PPTX
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 加密、偵測、驗證、開啟以及解密受密碼保護的 PowerPoint PPT 與 PPTX 簡報。"
---
## **概覽**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因而此保護提供了機密性。

開啟密碼不同於寫入保護密碼。寫入保護限制修改，但不會加密內容或阻止載入簡報。若要管理修改簡報的密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/python-net/write-protected-presentation/)。

以下工作流程適用於 PPT 與 PPTX 簡報。範例同時使用兩種格式，以說明檔案模式與串流模式的行為差異。

## **使用開啟密碼加密簡報**

使用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/encrypt/)指派開啟密碼。然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/)儲存加密後的簡報。

以下範例會加密 PPTX 簡報：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **載入加密的簡報**

將[LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/)設定為開啟密碼，並在載入檔案時將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)。當需要開啟密碼但提供的密碼遺失或不正確時，載入會失敗。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # 與已解密的簡報一起工作。
    pass
```

## **移除簡報的加密**

使用開啟密碼載入簡報，呼叫[ProtectionManager.remove_encryption](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/remove_encryption/)，並儲存結果。儲存後的簡報即可在不提供密碼的情況下載入。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **在載入前驗證開啟密碼**

使用[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/)取得[PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/)，而不必建立完整的簡報實例。於請求或驗證密碼之前，先檢查[PresentationInfo.is_password_protected](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/is_password_protected/)。若已啟用保護，請使用[PresentationInfo.check_password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/check_password/)驗證提供的密碼。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳遞給[LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/)，然後載入完整的簡報：

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **串流工作流程**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 的串流重載提供相同的工作流程。在從該串流載入完整簡報之前，請重新設定可搜尋串流的位置。

以下範例使用 PPT 檔案：

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **CheckPassword 回傳值**

[PresentationInfo.check_password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/check_password/) 只在簡報具備開啟密碼且提供的密碼正確時回傳 `True`。在以下情況皆回傳 `False`：

- 密碼不正確。
- 簡報未設定開啟密碼。
- 提供的密碼為 `None` 或空值。

PPT 與 PPTX 簡報的行為相同。

## **檢查載入的簡報是否已加密**

使用正確密碼載入簡報後，檢查[ProtectionManager.is_encrypted](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/is_encrypted/)以確認來源簡報已加密。若要在載入前偵測開啟密碼保護，請如上所示使用 `PresentationInfo.is_password_protected`。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **安全性建議**

{{% alert color="warning" title="Security" %}}
不要記錄開啟密碼或將其寫入診斷訊息。避免不必要的重複驗證嘗試，僅在需要時將密碼保留在記憶體中，且在立即載入簡報時重新使用成功的驗證結果。
{{% /alert %}}

## **線上為簡報設定密碼保護**

1. 開啟[Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock)應用程式。
2. 選取或上傳簡報。
3. 輸入檢視保護的密碼。
4. 可選擇輸入編輯保護的另一組密碼。
5. 套用保護並下載產生的檔案。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh-hant/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh-hant/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且必須提供才能載入其內容。寫入保護密碼則限制修改，但不會加密內容。

**我可以在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，並在建立完整簡報實例之前驗證密碼。

**密碼驗證工作流程是否同時支援 PPT 與 PPTX？**

會。檔案路徑與串流模式的密碼偵測與驗證對於 PPT 與 PPTX 簡報的行為相同。