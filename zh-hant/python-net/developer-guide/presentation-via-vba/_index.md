---
title: 使用 Python 管理簡報中的 VBA 專案
linktitle: 透過 VBA 的簡報
type: docs
weight: 250
url: /zh-hant/python-net/presentation-via-vba/
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
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 透過 VBA 產生與操作 PowerPoint 與 OpenDocument 簡報，以簡化工作流程。"
---
## **概觀**

本文探討 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中處理巨集的主要功能。此函式庫提供方便的工具來新增、移除和擷取巨集，讓您能自動化簡報的建立與修改。

- 加速簡報開發——自動化例行任務可減少準備素材所需的時間。  
- 確保彈性——管理巨集的能力讓您能將簡報客製化以符合特定任務和情境。  
- 整合資料——簡單的外部資料來源整合有助於保持投影片內容的即時性。  
- 簡化維護——集中式的巨集管理讓套用變更與更新簡報更為容易。  

本文接著提供實務範例，說明如何使用 Aspose.Slides 有效操作 PowerPoint 中的巨集。

[aspose.slides.vba](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.vba/) 命名空間提供用於處理巨集和 VBA 程式碼的類別。

{{% alert title="Note" color="warning" %}}
當您將包含巨集的簡報轉換為其他格式（PDF、HTML 等）時，Aspose.Slides 會忽略巨集——它們不會傳輸至輸出檔案。

當您向簡報新增巨集或重新儲存包含巨集的簡報時，Aspose.Slides 會原樣寫入巨集位元組。

Aspose.Slides **永不** 執行簡報中的巨集。
{{% /alert %}}

## **新增 VBA 巨集**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.vba/vbaproject/) 類別，以建立 VBA 專案（與專案參考）並編輯現有模組。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.vba/vbaproject/#constructors) 建構函式來新增 VBA 專案。  
3. 將模組新增至 VBA 專案。  
4. 設定模組的原始程式碼。  
5. 加入對 `<stdole>` 的參考。  
6. 加入對 **Microsoft Office** 的參考。  
7. 將這些參考與 VBA 專案關聯。  
8. 儲存簡報。

以下 Python 程式碼示範如何從頭新增 VBA 巨集至簡報：

```python
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:

    # 建立新的 VBA 專案。
    presentation.vba_project = slides.vba.VbaProject()

    # 為 VBA 專案新增空白模組。
    module = presentation.vba_project.modules.add_empty_module("Module")

    # 設定模組的來源程式碼。
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # 建立對 <stdole> 的參考。
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # 建立對 Microsoft Office 的參考。
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # 將參考加入 VBA 專案。
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # 儲存簡報。
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
您也可以試用 **Aspose** [Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros)，這是一個免費的 Web 應用程式，可從 PowerPoint、Excel 與 Word 文件中移除巨集。
{{% /alert %}}

## **移除 VBA 巨集**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的 [vba_project](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/vba_project/) 屬性，您可以移除 VBA 巨集。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。  
2. 存取巨集模組並將其移除。  
3. 儲存已修改的簡報。

以下 Python 程式碼示範如何移除 VBA 巨集：

```python
import aspose.slides as slides

# 載入包含巨集的簡報。
with slides.Presentation("VBA.pptm") as presentation:
    
    # 取得 VBA 模組。
    vba_module = presentation.vba_project.modules[0]

    # 移除 VBA 模組。
    presentation.vba_project.modules.remove(vba_module)

    # 儲存簡報。
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **擷取 VBA 巨集**

使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.vba/vbaproject/) 類別的 `modules` 屬性，您可以存取 VBA 專案的所有模組。 [VbaModule](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.vba/vbamodule/) 類別可用於擷取模組的屬性，例如名稱與程式碼。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。  
2. 檢查簡報是否包含 VBA 專案。  
3. 遍歷 VBA 專案中的所有模組以檢視巨集。

以下 Python 程式碼示範如何從簡報中擷取 VBA 巨集：

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # 檢查簡報是否包含 VBA 專案。
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **檢查 VBA 專案是否受密碼保護**

使用 [VbaProject.is_password_protected](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.vba/vbaproject/is_password_protected/) 屬性，您可以判斷專案的屬性是否受密碼保護。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。  
2. 檢查簡報是否包含 [VBA 專案](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.vba/vbaproject/)。  
3. 檢查 VBA 專案是否受密碼保護以檢視其屬性。

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # 檢查簡報是否包含 VBA 專案。
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **常見問題**

**如果我將簡報儲存為 PPTX，巨集會怎樣？**  
巨集會被移除，因為 PPTX 不支援 VBA。若要保留巨集，請選擇 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在簡報內執行巨集，例如刷新資料嗎？**  
不能。此函式庫永不執行 VBA 程式碼；執行僅能在具備相應安全設定的 PowerPoint 中完成。

**是否支援與 VBA 程式碼連結的 ActiveX 控制項操作？**  
可以，您能存取現有的 [ActiveX controls](/slides/zh-hant/python-net/activex/)，修改其屬性，並將其移除。當巨集與 ActiveX 互動時，這非常有用。