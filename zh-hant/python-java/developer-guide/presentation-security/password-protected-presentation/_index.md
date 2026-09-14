---
title: 在 Python 中為簡報設定密碼保護
linktitle: 密碼保護
type: docs
weight: 20
url: /zh-hant/python-java/password-protected-presentation/
keywords:
- 受密碼保護的簡報
- 開啟密碼
- 加密 PowerPoint
- 解密 PowerPoint
- 驗證簡報密碼
- 檢查簡報密碼
- 開啟加密簡報
- 移除加密
- PowerPoint
- PPT
- PPTX
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 加密、偵測、驗證、開啟與解密受密碼保護的 PowerPoint PPT 和 PPTX 簡報。"
---
## **概觀**

開啟密碼會加密簡報。必須提供正確的密碼才能載入並檢視簡報內容，因而提供機密性。

開啟密碼不同於寫入保護密碼。寫入保護限制修改，但不會加密內容或阻止簡報載入。若想管理簡報的修改密碼，請參閱[寫入保護簡報](/slides/zh-hant/python-java/write-protected-presentation/)。

以下工作流程適用於 PPT 與 PPTX 簡報。範例同時使用兩種格式，因為檔案與串流的行為很重要。

## **使用開啟密碼加密簡報**

使用[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#encrypt)指派開啟密碼。然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)儲存加密後的簡報。

以下範例會加密 PPTX 簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **將文件屬性保留公開**

預設情況下，Aspose.Slides 會將文件屬性納入簡報加密。[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 方法可獨立於投影片內容加密控制此行為。在呼叫[ProtectionManager.encrypt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#encrypt)之前傳入`False`，即可讓索引、分類、搜索或文件管理系統在未提供開啟密碼的情況下讀取中繼資料。

以下範例會建立加密的 PPTX 簡報，同時讓內建文件屬性保持公開：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

傳入`False`至[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 並不會讓投影片、母片、版面配置、形狀、媒體或其他簡報內容公開。它僅影響文件屬性。若要在不載入加密內容的情況下讀取這些屬性，請參閱[管理簡報屬性](/slides/zh-hant/python-java/presentation-properties/)。

## **載入加密的簡報**

將[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword) 設為開啟密碼，並在載入檔案時將該選項傳給[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)。若需要開啟密碼但未提供或密碼錯誤，載入會失敗。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # 對已解密的簡報進行操作。
    pass
finally:
    presentation.dispose()
```

## **移除簡報的加密**

使用開啟密碼載入簡報，呼叫[ProtectionManager.removeEncryption](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#removeEncryption)，然後儲存結果。儲存後的簡報即可在無需密碼的情況下載入。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **載入前驗證開啟密碼**

使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo)取得[PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/)，而不建立完整的簡報實例。在要求或驗證密碼之前，先檢查[PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#isPasswordProtected)。若存在保護，使用[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#checkPassword)驗證提供的值。

### **檔案路徑工作流程**

以下範例驗證 PPTX 檔案的開啟密碼，將驗證後的值傳給[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword)，然後載入完整的簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **串流工作流程**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 的串流重載提供相同的工作流程。在從該串流載入完整簡報之前，請先重設可搜尋串流的位置。

以下範例使用 PPT 檔案：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **checkPassword 回傳值**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#checkPassword) 只在簡報具有開啟密碼且提供的密碼正確時回傳 `True`。在以下情況皆回傳 `False`：

- 密碼不正確。
- 簡報沒有開啟密碼。
- 提供的密碼為 `None` 或空白。

PPT 與 PPTX 簡報的行為相同。

## **檢查已載入的簡報是否已加密**

在使用正確密碼載入簡報後，檢查[ProtectionManager.isEncrypted](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#isEncrypted) 以確認來源簡報已被加密。若要在載入前偵測開啟密碼保護，請如上使用[PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#isPasswordProtected)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **安全性建議**

{{% alert color="warning" title="Security" %}}
請勿記錄開啟密碼或將其寫入診斷訊息。避免不必要的重複驗證嘗試，僅在需要時將密碼保留於記憶體，並在立即載入簡報時重複使用成功驗證的結果。

即使簡報內容已加密，公開的文件屬性仍可能洩漏作者姓名、標題、主旨、關鍵字、公司資訊、註解以及自訂值。請將敏感的中繼資料與簡報一起加密。只有在系統必須在未提供開啟密碼的情況下進行索引、分類、搜索或管理檔案時，才應明確決定將屬性保持公開。
{{% /alert %}}

## **線上設定簡報密碼保護**

1. 開啟[Aspose.Slides Lock](https://products.aspose.app/slides/zh-hant/lock) 應用程式。
1. 選取或上傳簡報。
1. 輸入用於檢視保護的密碼。
1. （可選）輸入用於編輯保護的另一組密碼。
1. 套用保護並下載產生的檔案。

{{% alert color="info" title="See also" %}}
- [寫入保護簡報](/slides/zh-hant/python-java/write-protected-presentation/)
- [PowerPoint 數位簽章](/slides/zh-hant/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常見問題**

**開啟密碼與寫入保護密碼有何差異？**

開啟密碼會加密簡報，且必須在載入內容時提供。寫入保護密碼僅限制修改，而不加密內容。

**可以在不載入所有投影片的情況下驗證開啟密碼嗎？**

可以。取得簡報資訊，檢查是否存在開啟密碼保護，然後在建立完整簡報實例之前驗證密碼。

**應用程式可以在未提供開啟密碼的情況下讀取中繼資料嗎？**

可以，但前提是加密時已停用文件屬性加密。此時應用程式必須使用[管理簡報屬性](/slides/zh-hant/python-java/presentation-properties/) 中描述的僅讀取文件屬性的載入模式。

**密碼檢查工作流程同時支援 PPT 與 PPTX 嗎？**

支援。檔案路徑與串流的密碼偵測與驗證在 PPT 與 PPTX 簡報中行為相同。