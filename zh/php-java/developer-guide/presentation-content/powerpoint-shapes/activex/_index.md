---
title: 使用 PHP 在演示文稿中管理 ActiveX 控件
linktitle: ActiveX
type: docs
weight: 80
url: /zh/php-java/activex/
keywords:
- ActiveX
- ActiveX 控件
- 管理 ActiveX
- 添加 ActiveX
- 修改 ActiveX
- 媒体播放器
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "编辑 ActiveX 文本框和按钮，更新控件预览，并在 PowerPoint 演示文稿中使用 Aspose.Slides for PHP via Java 重用 Windows Media Player 控件。"
---
## **介绍**

ActiveX 控件为 PowerPoint 幻灯片提供交互元素，例如文本框、命令按钮和媒体播放器。Aspose.Slides for PHP via Java 通过 [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls) 暴露幻灯片的控件。使用此集合可编辑控件、在幻灯片上移动它或将其删除。

## **列出 ActiveX 控件及其存储属性**

要检查不熟悉的模板，请以读取模式打开并遍历每张幻灯片上的控件。示例报告幻灯片编号、控件名称、[getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId)以及 [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) 中的每个键值对。它在读取演示文稿时不会激活控件、触发事件或宏、更改数值或保存文件。

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

从 `ActiveX.pptm` 中选取的输出显示了一个文本框和一个命令按钮。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空属性集合显示为 `[]`。对于使用二进制存储的控件，[getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) 可能返回 `null`，显示为 `Properties unavailable`。如果只需要属性名称，请在空值检查后使用 [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties)。报告列出了演示文稿中可用的属性。控件在运行时可能支持其他属性。

## **修改 ActiveX 控件**

示例需要一个支持宏的演示文稿，第一张幻灯片上有名为 `TextBox1` 的文本框和名为 `CommandButton1` 的命令按钮。它使用 [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) 来更改文本框的值和按钮的标题。每个控件还有 PowerPoint 在激活前可显示的静态预览。为每个控件提供显示其更新文本和外观的 PNG。示例通过 [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat) 分配这些图像。

示例通过设置 [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame) 将第一张幻灯片上所有控件向下移动 100 点。它以 PPTM 格式保存编辑后的演示文稿，然后使用 [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) 保存第二个副本，该副本从该幻灯片中移除所有 ActiveX 控件。

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

## **添加 ActiveX 媒体播放器控件**

要复用已配置的 Windows Media Player 控件，请从第一张幻灯片包含名为 `WindowsMediaPlayer1` 的播放器的模板开始。[SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) 将整张幻灯片复制到新演示文稿中。示例在其 [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) 中设置播放器的 `URL`，并将克隆的幻灯片保存为唯一的输出幻灯片。视频保持外部存储，因此请选择播放器在播放期间能够访问的路径。

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

## **常见问题**

**Aspose.Slides 能在不运行的情况下保留 ActiveX 控件吗？**

可以。Aspose.Slides 能读取并保存控件及其属性和位置，而无需激活它们。

**ActiveX 控件与 OLE 对象有何区别？**

ActiveX 控件允许用户与幻灯片交互，例如输入文本或点击按钮。[OLE object](/slides/zh/php-java/manage-ole/) 使幻灯片包含或链接到由其他应用程序管理的内容，如 Excel 工作表。

**使用 Aspose.Slides 保存演示文稿后，ActiveX 事件仍会触发 VBA 宏吗？**

请将演示文稿保存为支持宏的格式（例如 PPTM）以保留其 VBA 项目。当 PowerPoint for Windows 的安全设置同时允许运行 ActiveX 控件和宏时，现有的事件处理程序将会被执行。