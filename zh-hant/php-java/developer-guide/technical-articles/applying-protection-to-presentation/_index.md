---
title: 使用形狀鎖定在 PHP 中限制簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/php-java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止修改
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定調整大小
- 鎖定分組
- PowerPoint
- PPTX
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PPTX 簡報中鎖定與解除鎖定形狀，以限制選取、移動、調整大小和分組。"
---
## **概觀**

在自動工作流程中，Aspose.Slides for PHP via Java 的常見用途是建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制形狀的變更可以協助保留預期的版面配置與內容。

本文說明形狀在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除形狀鎖定。這些鎖定允許您限制對個別形狀的特定編輯操作。

## **投影片的組成**

投影片由自動圖形、表格、OLE 物件、群組形狀、圖片框、影片框、連接器以及其他用於建立簡報的元素等組成。在 Aspose.Slides for PHP via Java 中，投影片上的每個元素皆由繼承自 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 類別的物件表示。

不同的形狀類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) 類別是形狀鎖定的基底類別。Aspose.Slides for PHP via Java 提供下列鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 鎖定連接器形狀。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) 鎖定群組形狀。  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並對每個支援的形狀設定相應的鎖定。

## **套用與移除保護**

形狀鎖定會限制選取、移動與調整大小等操作；它們不會使整個簡報無法編輯。

### **套用保護至 PPTX 形狀**

Aspose.Slides for PHP via Java 提供 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 類別以操作投影片上的形狀。

範例對自動圖形呼叫 [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) 與 [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) 並傳入 `true`，對群組形狀、連接器和圖片框使用等效的鎖定。連接器使用 [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) 來限制移動；群組則使用 [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 以限制分組。

範例載入現有的 PPTX 簡報，檢查每張投影片的形狀集合，並儲存套用上述限制的副本。未屬於這四種處理類型的形狀則保持不變。迴圈不會遍歷群組內的子形狀。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **移除保護**

若要移除形狀鎖定，請將其值設定為 `false`。以下範例載入含有形狀鎖定的簡報，並透過 [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 與 [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 清除選取、移動與調整大小的限制。亦透過傳入 `false` 給 [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 移除分組限制，並儲存簡報的副本。其他鎖定設定則保持不變。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **結論**

Aspose.Slides for PHP via Java 讓您能限制個別形狀的特定編輯操作，或在多張投影片上套用相同的限制。請依形狀類型選擇支援的鎖定，且在需要移除限制時將其值設為 `false`。

## **常見問題**

**我可以在同一個簡報中同時使用形狀鎖定與密碼保護嗎？**

可以。形狀鎖定會限制特定的編輯操作，而 [password protection](/slides/zh-hant/php-java/password-protected-presentation/) 可以限制開啟或修改簡報。兩者可同時用於同一個檔案。

**我可以只限制特定投影片的編輯，而不影響其他投影片嗎？**

可以。僅對選取的投影片上的形狀套用鎖定，即不會改變其他投影片的鎖定設定。

**如何對群組內的個別形狀套用鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) 方法所回傳的集合，對每個子形狀套用相應的鎖定。對任何巢狀群組重複此步驟。上方的範例僅處理投影片的形狀集合，未對個別群組成員設定鎖定。