---
title: 在 Python 中對簡報設定密碼保護
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
- 開啟已加密的簡報
- 移除加密
- PowerPoint
- PPT
- PPTX
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 加密、偵測、驗證、開啟及解密受密碼保護的 PowerPoint PPT 和 PPTX 簡報。"
---
## **概述**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因而此保護提供機密性。

開啟密碼不同於寫入保護密碼。寫入保護限制修改，但不會加密內容或阻止載入簡報。如需管理修改簡報的密碼，請參閱[Write-Protect Presentations](/slides/zh-hant/python-net/write-protected-presentation/)。

以下工作流程適用於 PPT 與 PPTX 簡報。範例同時使用這兩種格式，說明檔案模式與串流模式的行為差異。

## **使用開啟密碼加密簡報**

使用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/encrypt/)指派開啟密碼，然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/)將加密後的簡報保存。

下面的範例會加密 PPTX 簡報：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **保留文件屬性為公開**

預設情況下，Aspose.Slides 會在簡報加密時同時加密文件屬性。[ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/encrypt_document_properties/)屬性可獨立於投影片內容加密來控制此行為。如索引、分類、搜尋或文件管理系統必須在未提供開啟密碼的情況下讀取中繼資料，請在呼叫[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/encrypt/)之前將其設為 `False`。

下面的範例在建立加密的 PPTX 簡報時，將其內建文件屬性保留為公開：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

將 `encrypt_document_properties` 設為 `False` 並不會使投影片、母片、版面配置、圖形、媒體或其他簡報內容變為公開。它僅影響文件屬性。如需在不載入加密內容的情況下讀取這些屬性，請參閱[Manage Presentation Properties](/slides/zh-hant/python-net/presentation-properties/)。

## **載入已加密的簡報**

在載入檔案時，將[LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/)設定為開啟密碼，並將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)。若簡報需要開啟密碼但提供的密碼遺失或不正確，載入將失敗。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # 在已解密的簡報上工作。
    pass
```

## **從簡報中移除加密**

以開啟密碼載入簡報後，呼叫[ProtectionManager.remove_encryption](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/remove_encryption/)，並將結果保存。此後保存的簡報即可在未提供密碼的情況下載入。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **在載入前驗證開啟密碼**

使用[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/)可取得[PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/)，而無需建立完整的簡報實例。於請求或驗證密碼前，先檢查[PresentationInfo.is_password_protected](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/is_password_protected/)。若已啟用保護，請使用[PresentationInfo.check_password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/check_password/)驗證所提供的值。

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

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 的串流重載提供相同的工作流程。在從該串流載入完整簡報之前，請先重設可搜尋串流的位置。

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

只有當簡報設定了開啟密碼且提供的密碼正確時，[PresentationInfo.check_password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/check_password/) 會回傳 `True`。在以下情況皆會回傳 `False`：

- 密碼不正確。
- 簡報未設定開啟密碼。
- 提供的密碼為 `None` 或空值。

此行為於 PPT 與 PPTX 簡報皆相同。

## **檢查已載入的簡報是否已加密**

以正確的密碼載入簡報後，檢查[ProtectionManager.is_encrypted](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/is_encrypted/) 以確認來源簡報已加密。若要在載入前偵測開啟密碼保護，請如上使用 `PresentationInfo.is_password_protected`。

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
請勿記錄開啟密碼或將其寫入診斷訊息。避免不必要的重複驗證嘗試，僅在需要時將密碼保留在記憶體中，且在立即載入簡報時可重複使用成功的驗證結果。

即使簡報內容已加密，公開的文件屬性仍可能透露作者名稱、標題、主題、關鍵字、公司資訊、註解以及自訂值。請將敏感的中繼資料與簡報一起加密。僅在系統必須在未提供開啟密碼的情況下索引、分類、搜尋或管理檔案時，才應明確決定將屬性保持公開。
{{% /alert %}}

## **線上為簡報設定密碼保護**

1. 開啟 [Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock) 應用程式。
2. 選取或上傳簡報。
3. 輸入用於檢視保護的密碼。
4. （可選）輸入用於編輯保護的另一個密碼。
5. 套用保護並下載產生的檔案。

{{% alert color="info" title="See also" %}}
- [寫入保護簡報](/slides/zh-hant/python-net/write-protected-presentation/)
- [PowerPoint 中的數位簽章](/slides/zh-hant/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何不同？**

開啟密碼會加密簡報，且在載入內容時必須提供。寫入保護密碼僅限制修改，而不會加密內容。

**我可以在不載入全部投影片的情況下驗證開啟密碼嗎？**

可以。先取得簡報資訊，檢查是否存在開啟密碼保護，並在建立完整簡報實例之前驗證密碼。

**應用程式可以在未提供開啟密碼的情況下讀取中繼資料嗎？**

可以，但前提是簡報在加密時將 `encrypt_document_properties` 設為 `False`。此時應用程式必須使用在[管理簡報屬性](/slides/zh-hant/python-net/presentation-properties/) 中描述的僅載入文件屬性的模式。

**密碼檢查工作流程是否同時支援 PPT 與 PPTX？**

是的。檔案路徑與串流模式的密碼偵測與驗證在 PPT 與 PPTX 簡報中行為相同。