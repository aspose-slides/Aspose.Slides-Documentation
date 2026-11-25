---
title: 使用形狀鎖定在 PHP 中限制簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/php-java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定調整大小
- 鎖定群組
- PowerPoint
- PPTX
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PPTX 簡報中鎖定與解除鎖定形狀，以限制選取、移動、調整大小與群組。"
---
## **概述**

Aspose.Slides for PHP via Java 的常見用法是於自動化工作流程中建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制對形狀的變更可協助保留預期的版面配置與內容。

本文說明形狀在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除形狀鎖定。這些鎖定讓您能限制對個別形狀的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組形狀、圖片框、影片框、連接線以及其他用於建構簡報的元素組成。在 Aspose.Slides for PHP via Java 中，投影片上的每個元素皆以繼承自 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 類別的物件表示。

不同的形狀類型會提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) 類別是形狀鎖定的基礎類別。Aspose.Slides for PHP via Java 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 鎖定連接線形狀。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) 鎖定群組形狀。  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並在每個支援的形狀上設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器會使用形狀鎖定來限制個別的編輯操作。檔案加密與文件層級的寫入保護是獨立的 [簡報保護設定](/slides/zh-hant/php-java/password-protected-presentation/)。

### **套用 PPTX 形狀保護**

Aspose.Slides for PHP via Java 提供 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 類別以在投影片上操作形狀。

此範例對自動圖形呼叫 [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) 與 [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) 並傳入 `true`，對群組形狀、連接線與圖片框使用等效的鎖定。連接線使用 [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) 以限制移動；群組亦使用 [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 來限制群組化。

此範例載入既有 PPTX 簡報，檢查每張投影片的形狀集合，並儲存套用此限制的副本。未屬於上述四種處理類型的形狀將保持不變。此迴圈不會遍歷群組內的子形狀。

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

若要移除形狀鎖定，將其值設為 `false`。以下範例載入含有形狀鎖定的簡報，並透過 [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 取消選取、移動與調整大小的限制。亦透過將 `false` 傳遞給 [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 解除群組限制，並儲存簡報的副本。其他鎖定設定保持不變。

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

### **保留圖片裁切**

在工作目錄放置名為 `photo.jpg` 的照片。此範例將左側裁切 12%、右側裁切 8%，然後在圖片框的鎖定上呼叫 [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked)。傳入 `true` 會限制進一步的裁切並保留現有的裁切結果。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` 將裁切鎖定儲存為 `true`。在 PowerPoint 中，選取照片時 **Crop** 指令會被停用。

### **保留圖表群組**

此範例將矩形與箭頭群組，然後在群組的鎖定上呼叫 [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) 以保留圖表的元件在一起。其他編輯，例如移動群組或變更元件填色，仍然可用。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` 將解除群組鎖定儲存為 `true`。在 PowerPoint 中，選取整個圖表時 **Ungroup** 指令會被停用。

### **報告現有形狀鎖定**

若要檢查模板，請開啟它並讀取每個形狀的鎖定物件。[getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) 方法在該物件的所有旗標皆關閉時傳回 `true`，只要有至少一個啟用則傳回 `false`。群組與其子形狀擁有分別的鎖定物件，因此即使群組無鎖定，也要檢查其子形狀。

此範例檢查自動圖形、圖片框與群組的移動。也檢查圖片的裁切以及群組的解除群組。報告列出它辨識到的已啟用旗標，並標示未檢查的形狀類型。

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $re

strictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

假設 `Sample.pptx` 的第 1 張投影片包含一個名為 `Layout`、已鎖定解除群組的群組，其中有一張名為 `Photo`、已鎖定裁切的圖片，以及一個未鎖定的矩形 `Free`。報告會略過 `Free`，並列印以下兩行：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

報告會讀取儲存的形狀層級編輯旗標，且不會更改它們或儲存簡報。文件層級的寫入保護是另一項設定，且每個旗標的執行方式取決於編輯器。

### **結論**

Aspose.Slides for PHP via Java 讓您能限制個別形狀的特定編輯操作，或在所有投影片上套用相同的限制。選擇每種形狀類型支援的鎖定，並在需要移除這些限制時將其值設為 `false`。

## **常見問題**

**我可以在同一簡報中同時結合形狀鎖定與密碼保護嗎？**

可以。形狀鎖定會限制特定的編輯操作，而 [密碼保護](/slides/zh-hant/php-java/password-protected-presentation/) 可以限制開啟或修改簡報。您可以在同一檔案中同時使用兩者。

**我可以只限制特定投影片的編輯而不影響其他投影片嗎？**

可以。僅對選取的投影片上的形狀套用鎖定。這不會更改其他投影片的鎖定設定。

**我該如何對群組內的個別形狀套用鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) 方法回傳的集合，並對每個子形狀套用相應的鎖定。對所有巢狀群組重複此步驟，遵循報告範例中的遍歷方式。