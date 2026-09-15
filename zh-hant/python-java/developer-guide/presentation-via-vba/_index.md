---
title: 使用 Python 管理簡報中的 VBA 專案
linktitle: 透過 VBA 的簡報
type: docs
weight: 250
url: /zh-hant/python-java/presentation-via-vba/
keywords:
- 巨集
- VBA
- VBA 巨集
- 新增巨集
- 移除巨集
- 擷取巨集
- 新增 VBA
- 移除 VBA
- 擷取 VBA
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "探索如何使用 Aspose.Slides for Python via Java 透過 VBA 產生與操控 PowerPoint 與 OpenDocument 簡報，以簡化您的工作流程。"
---
## **簡介**

Aspose.Slides 提供用於操作巨集與 VBA 程式碼的類別和介面。

{{% alert title="Warning" color="warning" %}} 

當您將包含巨集的簡報轉換為其他檔案格式（PDF、HTML 等）時，Aspose.Slides 會忽略所有巨集（巨集不會被帶入產生的檔案）。
當您向簡報加入巨集或重新儲存含有巨集的簡報時，Aspose.Slides 僅會寫入巨集的位元組。
Aspose.Slides **永不** 執行簡報中的巨集。

{{% /alert %}}

## **新增 VBA 巨集**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/vbaproject/) 類別，使您能建立 VBA 專案（及其參考）並編輯現有模組。您可以使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/vbaproject/) 類別來管理嵌入於簡報中的 VBA。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/vbaproject/#vbaproject) 建構函式新增 VBA 專案。
3. 將模組新增至 VBA 專案。
4. 設定模組的原始碼。
5. 加入對 `stdole` 的參考。
6. 加入對 **Microsoft Office** 的參考。
7. 將參考與 VBA 專案關聯。
8. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # 建立新的 VBA 專案。
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # 新增空白模組並設定其來源程式碼。
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # 建立對 stdole 與 Microsoft Office 的參考。
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # 將參考加入 VBA 專案。
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # 儲存簡報。
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}} 

您或許想了解 **Aspose** [Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros)——這是一個免費的網路應用程式，可用於從 PowerPoint、Excel 與 Word 文件中移除巨集。 

{{% /alert %}} 

## **移除 VBA 巨集**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的 [getVbaProject](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getvbaproject) 方法，即可移除 VBA 巨集。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入包含巨集的簡報。
2. 存取巨集模組並將其移除。
3. 儲存已修改的簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 載入包含巨集的簡報。
presentation = Presentation("VBA.pptm")
try:
    # 取得 VBA 模組並將其移除。
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # 儲存簡報。
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **擷取 VBA 巨集**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入包含巨集的簡報。
2. 檢查簡報是否包含 VBA 專案。
3. 遍歷 VBA 專案中所有模組以檢視巨集。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# 載入包含巨集的簡報。
presentation = Presentation("VBA.pptm")
try:
    # 檢查簡報是否包含 VBA 專案。
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **檢查 VBA 專案是否受密碼保護**

使用 [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/vbaproject/#ispasswordprotected) 方法，可判斷專案的屬性是否受密碼保護。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入包含巨集的簡報。
2. 檢查簡報是否包含 [VBA project](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/vbaproject/)。
3. 檢查 VBA 專案是否受密碼保護以檢視其屬性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # 檢查簡報是否包含 VBA 專案。
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **常見問題**

**如果我將簡報另存為 PPTX，巨集會發生什麼情況？**

巨集將被移除，因為 PPTX 不支援 VBA。若要保留巨集，請選擇 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在簡報內執行巨集，例如刷新資料嗎？**

不能。此函式庫永不執行 VBA 程式碼；執行僅能在具備適當安全設定的 PowerPoint 中完成。

**是否支援操作與 VBA 程式碼連結的 ActiveX 控制項？**

是，您可以存取現有的 [ActiveX controls](/slides/zh-hant/python-java/activex/)，修改其屬性，並將其移除。這在巨集與 ActiveX 互動時非常有用。