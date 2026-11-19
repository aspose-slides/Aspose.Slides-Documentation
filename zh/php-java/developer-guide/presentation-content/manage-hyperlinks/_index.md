---
title: 在 PHP 中管理演示文稿超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/php-java/manage-hyperlinks/
keywords:
- 添加 URL
- 添加超链接
- 创建超链接
- 格式化超链接
- 删除超链接
- 更新超链接
- 文本超链接
- 幻灯片超链接
- 形状超链接
- 图像超链接
- 视频超链接
- 可变超链接
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、更新和删除超链接，提供 PHP 示例。"
---
## **介绍**

超链接将演示文稿内容连接到网站或演示文稿内部的位置。在 PowerPoint 中，超链接通常有两个用途：

* 从文本、形状或媒体框打开网站。
* 从目录等跳转到另一张幻灯片。

Aspose.Slides for PHP via Java 让您可以添加这些链接、控制其外观和声音、更新其属性并将其删除。下面的示例展示了如何在单个元素上使用超链接以及如何在演示文稿、幻灯片或文本框级别访问超链接。示例假设已初始化 PHP/Java Bridge 和 Aspose.Slides PHP 包装器。没有 PHP 参考页面链接的 API 成员会链接到底层的 Java API。

{{% alert color="info" title="Note" %}}
您还可以使用[免费在线 Aspose PowerPoint 编辑器](https://products.aspose.app/slides/editor)编辑演示文稿。
{{% /alert %}}

## **添加 URL 超链接**

您可以将网站 URL 分配给文本、形状或媒体框。分配超链接的元素决定了可点击区域：文本片段链接所选文本，而形状或框则链接整个幻灯片对象。

对于包含相对超链接的演示文稿，请参阅[管理超链接基址](/slides/zh/php-java/presentation-properties/#manage-the-hyperlink-base)以读取、修改或清除文档级基址。

### **向文本添加 URL 超链接**

要将文本链接到网站，请将一个[Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/)传递给文本片段的[setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/)方法，如下所示。只有该文本片段会变为可点击。

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **向形状和媒体框添加 URL 超链接**

在矩形上调用[setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/)可使其整个区域可点击。使用[setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/)在鼠标悬停矩形时向读者显示目的地提示。这两个方法同样适用于图片、音频和视频框。

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **使用超链接创建目录**

内部超链接允许读者从目录跳转到特定幻灯片。下面的示例使用[setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/)将第一张幻灯片上的“Page 2”文本链接到第二张幻灯片。

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **格式化超链接**

您可以更改链接文本的颜色、在读者激活链接时播放或停止声音，以及设置悬停时显示的工具提示。

### **颜色**

[Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/)的[setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/)方法决定超链接是使用演示文稿的默认超链接颜色还是使用文本片段的格式。要应用自定义文本颜色，请选择[HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/)并设置片段的填充颜色。此功能在 PowerPoint 2019 中引入；旧版本不适用此设置。

在本示例中，[setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/)使第一个链接使用文本片段的红色填充。第二个链接保留演示文稿的超链接颜色。

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **声音**

超链接可以在激活时播放声音，或停止已经在播放的声音。使用以下方法配置这些行为：

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/)指定与超链接关联的音频。
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/)控制激活超链接时是否停止之前的声音。

#### **添加超链接声音**

第一张幻灯片上的按钮使用[Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/)在读者点击前进时播放 `sampleaudio.wav`。第二张幻灯片上的另一个按钮使用[Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/)停止播放并保持读者停留在该幻灯片。

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **提取超链接声音**

下面的示例打开上面创建的演示文稿，并通过[getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/)和[getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/)将第一个形状的超链接音频读取到内存中。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **工具提示和交互设置**

将超链接分配给文本或形状后，您可以调用以下[Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/)方法：

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) 设置在悬停时显示的提示文本。
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) 在适用时指定父 HTML 框架集中的目标框架。
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) 控制激活链接后是否将其目标添加到已查看超链接列表中。
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) 控制点击时是否突出显示超链接。

## **从演示文稿中删除超链接**

使用[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)收集包括文本片段链接在内的所有超链接容器，然后再进行修改。下面的示例删除第一张幻灯片的两种激活方式。如只想删除一种，请仅调用[removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/)或[removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/)；删除点击操作并不会删除其鼠标悬停对应操作。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

若需无条件删除，[removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)一次调用即可在选定范围内删除两种激活方式。若需有选择地清理并覆盖母版、版式和备注，请参阅[报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)。

### **在替换 SmartArt 文本之前清除超链接**

在现有 SmartArt 节点中替换段落时，清除其文本片段可能会留下旧的超链接。通过[SmartArtNode::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/gettextframe/)获取段落。清除片段之前，先对显示该段落的节点形状的文本框调用[getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/)，然后在返回的对象上调用[removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)。这会删除该框架中的所有超链接，包括其他段落中的链接。

示例假设 `SmartArtHyperlink.pptx` 的第一张幻灯片的第三个形状是 SmartArt 图形。它替换第四个节点的第一段。在本演示文稿中，该节点的第一个形状显示该段落。

添加两个片段后，示例使用[getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/)读取它们的有效格式。在该格式上，[getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) 返回第一片段的新超链接，而第二片段返回 `null`。

```php
use aspose\slides\Hyperlink;
use aspose\slides\Portion;
use aspose\slides\Presentation;

$presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $smartArt = $slide->getShapes()->get_Item(2);
    $node = $smartArt->getAllNodes()->get_Item(3);
    $paragraph = $node->getTextFrame()->getParagraphs()->get_Item(0);

    $node->getShapes()->get_Item(0)->getTextFrame()->getHyperlinkQueries()->removeAllHyperlinks();
    $paragraph->getPortions()->clear();

    $link = new Portion("New reference");
    $link->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://example.com/new"));
    $paragraph->getPortions()->add($link);
    $text = new Portion(" (updated)");
    $paragraph->getPortions()->add($text);

    echo java_values($link->getPortionFormat()->getEffective()->getHyperlinkClick()->getExternalUrl()), PHP_EOL; // https://example.com/new
    var_dump(java_is_null($text->getPortionFormat()->getEffective()->getHyperlinkClick())); // bool(true): 第二段没有超链接。
} finally {
    $presentation->dispose();
}
```

## **构建完整的超链接清单**

在分发演示文稿之前，需要清点其交互操作以及网页链接。[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)返回[IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/)对象，而不是平铺的 URL 字符串。请检查每个容器的[getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--)和[getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--)。它们相互独立：同一容器可以同时暴露两种操作，因此完整报告可能需要为每个容器提供最多两行。

仅扫描形状级别的超链接可能会遗漏附加在文本片段上的链接。请改为查询相应的范围，并保留返回的容器，以便稍后更新或删除其操作。

### **查询演示文稿、幻灯片和文本框范围**

[HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) 类可通过[Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/)、[IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--)和[TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/)获取。每个范围支持相同的查询：

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) 返回具有点击操作的容器。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) 返回具有鼠标悬停操作的容器。
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) 返回同时或任意包含上述两种操作的容器。

本示例为形状及其文本分配点击和鼠标悬停操作，并为另一个按钮分配宏操作。它比较了[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) 返回的容器数量与每种激活类型的计数。文本框查询仅统计文本中的链接。外部形状自身的操作出现在幻灯片和演示文稿查询中。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

对于本示例，演示文稿和幻灯片查询各报告 3 个点击容器、2 个鼠标悬停容器以及 3 个任意操作容器。文本框查询在每个类别中各报告 1 个容器。

### **对操作和目标进行分类**

使用[Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/)在解释目标之前先解释操作。[HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) 的取值涵盖了超出网页导航的情况：

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | 外部超链接；检查 URL 及其协议。 |
| `JumpSpecificSlide` | 导航到特定幻灯片的内部跳转。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 内建的幻灯片放映导航，在放映上下文中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 结束当前演示或启动自定义演示。 |
| `StartMacro` | 执行宏。 |
| `StartProgram` | 启动程序。 |
| `OpenFile`, `OpenPresentation` | 打开文件或另一个演示文稿；需单独审查，区别于网页 URL。 |
| `StartStopMedia` | 启动或停止媒体播放。 |
| `NoAction`, `Unknown` | 无导航操作，或未知操作，需要进行审查。 |

通过[getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/)读取外部目的地，通过[getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/)读取具体的内部目的地。内部操作和内建命令可能没有外部 URL；空 URL 并不意味着容器没有操作。当[getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) 的返回值与规范化 URL 不同时，请保留原始值；如果可用，也请包括[getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/)返回的工具提示。

### **报告、清理和验证超链接**

本示例打开前面示例中的演示文稿，并为每个操作写入一条 JSON 记录。它使用[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)收集普通幻灯片、母版、版式和备注（包括备注母版和讲义母版）中的容器。通过引用相等性确保每个容器只计数一次，应用下述策略后重新打开已保存的演示文稿，以检查点击和鼠标悬停两种操作。

报告记录基于 1 的幻灯片索引和[getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--)（如果可用）。[ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) 为支持的容器提供所属幻灯片。母版、版式和备注没有普通幻灯片索引，使用其范围标识。形状容器和文本片段格式容器分别标记；其他容器类型保留其运行时类型名称。每个容器获得报告本地 ID，以便关联其两个操作。报告将操作类型存为 PHP 枚举定义的整数常量。

此严格的应用策略仅允许绝对 HTTPS URL 和有效的内部幻灯片目标。它会拒绝宏、程序、文件操作、其他幻灯片放映操作、未知操作以及其他 URL 方案。这些拒绝属于策略决策，而非 Aspose.Slides 的安全判定。仅凭 HTTPS 并不能建立信任：请在应用中添加主机白名单和其他检查。原始和规范化的外部 URL 均会被检查。示例在不跟随链接或执行操作的情况下审计元数据。

若需整改，可使用容器的[getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--)，其支持[setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)、[removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/)和[removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/)。在本例中，受限制的外部点击链接被替换为固定的 HTTPS 着陆页；其他受限制的点击和受限制的鼠标悬停操作分别被删除。将 `$replaceExternalClicks` 设置为 `false` 则会移除所有策略违规项。请在部署前选择由应用拥有的替换页面。

报告的导出标记采用保守的 PDF 审核策略：将鼠标悬停操作以及除外部链接或特定幻灯片跳转以外的任何操作标记为可能不受支持。这仅是审核提示，而非功能测试或未标记链接一定会在导出后保留的保证。受支持的[PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)和[HTML](/slides/zh/php-java/convert-powerpoint-to-html/) 导出可能会保留超链接，具体取决于操作、导出选项和查看器。栅格[图像](/slides/zh/php-java/convert-powerpoint-to-png/)和[视频](/slides/zh/php-java/convert-powerpoint-to-video/) 无法保留交互式超链接；在针对这些输出进行审计时请对每个操作加标记。

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

使用上述输入，报告包含五行操作。文件的鼠标悬停链接和宏点击被删除，而 HTTPS 链接和内部幻灯片导航仍然保留。验证输出零个违规操作。输入中包含受限制的外部点击 URL 时，也会走到替换分支。一个同时拥有允许点击和受限制鼠标悬停的容器会保留其点击操作。

此选择性清理不同于[removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)，后者不论策略如何都会在选定范围内移除两种激活方式。此处的验证仅检查超链接操作；它不会删除嵌入的 VBA 项目、OLE 对象或其他活跃内容，也不对导出的 PDF 或 HTML 文件进行验证。

## **常见问题**

**如何链接到某个章节或其第一张幻灯片？**

PowerPoint 中的章节用于对幻灯片进行分组，但内部超链接只能定位到单独的幻灯片。若要实现对章节的导航，请链接到该章节的第一张幻灯片。

**我可以将超链接附加到母版幻灯片元素上，以便在所有幻灯片上都有效吗？**

可以。母版幻灯片和版式元素支持超链接。这些元素上的链接在使用相应母版或版式的幻灯片放映时可用。

**导出为 PDF、HTML、图像或视频时，超链接会被保留吗？**

受支持的 PDF 和 HTML 导出可能会保留超链接；栅格图像和视频则不能。有关导出注意事项，请参阅[报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)。