---
title: 使用 PHP 管理簡報中的 VBA 專案
linktitle: 透過 VBA 的簡報
type: docs
weight: 250
url: /zh-hant/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "探索如何使用 Aspose.Slides for PHP via Java，透過 VBA 產生與操作 PowerPoint 與 OpenDocument 簡報，以簡化您的工作流程。"
---
## **簡介**

Aspose.Slides API 包含用於處理巨集和 VBA 程式碼的類別。

{{% alert title="注意" color="warning" %}} 
當您將包含巨集的簡報轉換為其他檔案格式（PDF、HTML 等）時，Aspose.Slides 會忽略所有巨集（巨集不會被帶入輸出檔案）。

當您向簡報加入巨集或重新儲存包含巨集的簡報時，Aspose.Slides 只會寫入巨集的位元組資料。

Aspose.Slides **永不** 執行簡報中的巨集。
{{% /alert %}}

## **新增 VBA 巨集**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/vbaproject/) 類別，讓您建立 VBA 專案（以及專案參考）並編輯現有模組。您可以使用 `VbaProject` 類別來管理嵌入於簡報中的 VBA。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
2. 使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/vbaproject/#VbaProject) 建構函式來新增 VBA 專案。
3. 將模組新增至 VbaProject。
4. 設定模組的來源程式碼。
5. 加入對 <stdole> 的參考。
6. 加入對 **Microsoft Office** 的參考。
7. 將參考與 VBA 專案關聯。
8. 儲存簡報。

以下 PHP 程式碼示範如何從零開始將 VBA 巨集新增至簡報：

```php
  # 建立簡報類別的實例
  $pres = new Presentation();
  try {
    # 建立新的 VBA 專案
    $pres->setVbaProject(new VbaProject());
    # 向 VBA 專案新增空白模組
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # 設定模組來源程式碼
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # 建立對 <stdole> 的參考
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # 建立對 Office 的參考
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # 將參考加入 VBA 專案
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # 儲存簡報
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
您可能想試用 **Aspose** [Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros)——這是一個免費的網路應用程式，用於從 PowerPoint、Excel 與 Word 文件中移除巨集。 
{{% /alert %}} 

## **移除 VBA 巨集**

透過 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別下的 [VbaProject](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getVbaProject) 屬性，您可以移除 VBA 巨集。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例，並載入包含巨集的簡報。
2. 存取 Macro 模組並將其移除。
3. 儲存已修改的簡報。

```php
  # 載入包含巨集的簡報
  $pres = new Presentation("VBA.pptm");
  try {
    # 取得 Vba 模組並將其移除
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # 儲存簡報
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **擷取 VBA 巨集**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例，並載入包含巨集的簡報。
2. 檢查簡報是否包含 VBA 專案。
3. 遍歷 VBA 專案中所有模組以檢視巨集。

以下 PHP 程式碼示範如何從包含巨集的簡報中擷取 VBA 巨集：

```php
  # 載入包含巨集的簡報
  $pres = new Presentation("VBA.pptm");
  try {
    # 檢查簡報是否包含 VBA 專案
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **檢查 VBA 專案是否受密碼保護**

使用 [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/vbaproject/#isPasswordProtected) 方法，您可以判斷專案的屬性是否受密碼保護。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。
2. 檢查簡報是否包含 [VBA project](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/vbaproject/)。
3. 檢查 VBA 專案是否受密碼保護以查看其屬性。

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // 檢查簡報是否包含 VBA 專案。
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**當我將簡報儲存為 PPTX 時，會發生什麼事？**

巨集將會被移除，因為 PPTX 不支援 VBA。若要保留巨集，請選擇 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在簡報中執行巨集，例如重新整理資料嗎？**

不能。此函式庫永遠不會執行 VBA 程式碼；執行僅能在 PowerPoint 中、且具備適當的安全設定時才可能。

**是否支援與連結到 VBA 程式碼的 ActiveX 控制項互動？**

是的，您可以存取現有的 [ActiveX 控制項](/slides/zh-hant/php-java/activex/)、修改其屬性並將其移除。當巨集與 ActiveX 互動時，這非常有用。