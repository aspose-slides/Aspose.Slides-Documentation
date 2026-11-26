---
title: 使用 PHP 管理簡報中的 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/php-java/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 管理 ActiveX
- 新增 ActiveX
- 修改 ActiveX
- 媒體播放器
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "編輯 ActiveX 文字方塊和按鈕，更新控制項預覽，並在 PowerPoint 簡報中使用 Aspose.Slides for PHP via Java 重複使用 Windows Media Player 控制項。"
---
## **簡介**

ActiveX 控制項為 PowerPoint 投影片提供互動元素，例如文字方塊、指令按鈕和媒體播放器。Aspose.Slides for PHP via Java 透過 [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls) 讓投影片的控制項可取得。使用此集合來編輯控制項、在投影片上移動或移除它。

## **列出 ActiveX 控制項及其儲存屬性**

要檢查不熟悉的範本，請以唯讀方式開啟並遍歷每張投影片上的控制項。範例會報告投影片編號、控制項名稱、[getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId)，以及在 [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) 中的每個鍵值對。它會在不啟動控制項、觸發事件或巨集、變更值或儲存檔案的情況下讀取簡報。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

從 `ActiveX.pptm` 取得的選取輸出顯示了一個文字方塊和一個指令按鈕。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的屬性集合會顯示為 `[]`。對於使用二進位儲存的控制項，[getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) 可能返回 `null`，顯示為 `Properties unavailable`。如果只需要名稱，可在檢查為 null 後使用 [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties)。報告列出簡報中可用的屬性。控制項在執行階段可能支援額外的屬性。

## **修改 ActiveX 控制項**

此範例假設簡報已啟用巨集，且第一張投影片上有名稱為 `TextBox1` 的文字方塊和名稱為 `CommandButton1` 的指令按鈕。它使用 [控制項屬性集合](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) 變更文字方塊的值與按鈕的標題。每個控制項也有 PowerPoint 可以在啟動前顯示的靜態預覽。為每個控制項提供 PNG 圖檔，以顯示更新後的文字與外觀。範例透過 [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat) 指派這些圖像。

範例使用 [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame) 將第一張投影片上所有控制項向下移動 100 點。它以 PPTM 格式儲存編輯後的簡報，然後使用 [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) 再儲存一個第二份副本，該副本已從該投影片移除所有 ActiveX 控制項。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **新增 ActiveX 媒體播放器控制項**

若要重複使用已配置的 Windows Media Player 控制項，請以第一張投影片包含名稱為 `WindowsMediaPlayer1` 的播放器的範本作為起點。[SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) 會將整張投影片複製到新簡報中。範例在其 [屬性集合](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) 中設定播放器的 `URL`，並將複製的投影片儲存為輸出的唯一投影片。影片保留為外部檔案，因此請選擇播放器在播放期間可存取的路徑。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **常見問題**

**Aspose.Slides 能在不執行的情況下保留 ActiveX 控制項嗎？**

是。Aspose.Slides 能在不啟動控制項的情況下讀取並儲存控制項，包括它們的屬性與位置。

**ActiveX 控制項與 OLE 物件有何不同？**

ActiveX 控制項允許使用者與投影片互動，例如輸入文字或點擊按鈕。 [OLE 物件](/slides/zh-hant/php-java/manage-ole/) 讓投影片包含或連結到由其他應用程式管理的內容，例如 Excel 工作表。

**儲存使用 Aspose.Slides 的簡報後，ActiveX 事件仍會觸發 VBA 巨集嗎？**

將簡報儲存為支援巨集的格式（例如 PPTM）即可保留 VBA 專案。當 Windows 版 PowerPoint 的安全性設定同時允許 ActiveX 控制項與巨集時，便會執行現有的事件處理常式。