---
title: 在 PHP 中使用形狀鎖定限制簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/php-java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 保護免於編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定調整大小
- 鎖定群組化
- PowerPoint
- PPTX
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PPTX 簡報中鎖定與解除鎖定形狀，以限制選取、移動、調整大小及群組化。"
---
## **概觀**

Aspose.Slides for PHP via Java 的常見用途是作為自動化工作流程的一部分，建立、更新並保存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制對圖形的變更可以協助保留預期的版面配置和內容。

本文說明圖形在投影片中的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定可讓您限制對個別圖形的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for PHP via Java 中，投影片上的每個元素皆以繼承自 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 類別的物件表示。

不同的圖形類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) 類別是圖形鎖定的基底類別。Aspose.Slides for PHP via Java 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 鎖定連接線圖形。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) 鎖定群組圖形。  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並對每個支援的圖形設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器使用圖形鎖定來限制個別的編輯操作。檔案加密與文件層級的寫入保護是獨立的[簡報保護設定](/slides/zh-hant/php-java/password-protected-presentation/)。

### **套用 PPTX 圖形保護**

Aspose.Slides for PHP via Java 提供 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 類別，以在投影片上操作圖形。

此範例對自動圖形呼叫 [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) 並傳入 `true`，對群組圖形、連接線和圖片框使用等效的鎖定。連接線使用 [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) 以限制移動；群組同時使用 [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 來限制分組。

此範例載入現有的 PPTX 簡報，檢查每張投影片之圖形集合中的圖形，並儲存一個套用此限制的副本。四種已處理類型之外的圖形保持不變。此迴圈不會遍歷群組內的子圖形。

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

若要移除圖形鎖定，請將其值設為 `false`。以下範例載入含有圖形鎖定的簡報，並透過 [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), 以及 [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 清除選取、移動與調整大小的限制。它亦透過將 `false` 傳遞給 [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 來移除分組限制，並儲存簡報的副本。其他鎖定設定保持不變。

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

在工作目錄中放置一張名為 `photo.jpg` 的照片。此範例將左側裁切 12%，右側裁切 8%，然後對圖片框的鎖定呼叫 [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked)。傳入 `true` 可限制進一步裁切並保留現有的裁切。

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

`PictureLocked.pptx` 將裁切鎖定儲存為 `true`。在 PowerPoint 中，選取照片時 **Crop** 命令會被停用。

### **保持圖表群組化**

此範例將一個矩形與箭頭群組，然後對群組的鎖定呼叫 [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) 以保持圖表的元件在一起。其他編輯，如移動群組或變更元件的填色，仍可使用。

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

`DiagramLocked.pptx` 將解除群組鎖定儲存為 `true`。在 PowerPoint 中，選取整個圖表時 **Ungroup** 命令會被停用。

### **結論**

Aspose.Slides for PHP via Java 讓您能限制個別圖形的特定編輯操作，或在多張投影片間套用相同的限制。請依圖形類型選取支援的鎖定，並在需要移除限制時將其值設為 `false`。

## **常見問題**

**我可以在同一簡報中同時結合圖形鎖定與密碼保護嗎？**

可以。圖形鎖定限制特定的編輯操作，而[密碼保護](/slides/zh-hant/php-java/password-protected-presentation/)則可以限制簡報的開啟或修改。您可以在同一檔案中同時使用兩者。

**我可以僅限制特定投影片的編輯而不影響其他投影片嗎？**

可以。僅對選取的投影片上的圖形套用鎖定。這不會改變其他投影片的鎖定設定。

**我該如何對群組內的個別圖形套用鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) 方法返回的集合，並對每個子圖形套用相應的鎖定。對任何巢狀群組重複此操作。上述範例僅處理投影片的圖形集合，未對個別群組成員設定鎖定。