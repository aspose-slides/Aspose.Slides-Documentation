---
title: 在 JavaScript 中管理演示文稿超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/nodejs-java/manage-hyperlinks/
keywords:
- 添加 URL
- 添加超链接
- 创建超链接
- 格式化超链接
- 移除超链接
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 的 JavaScript 示例，在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、更新和移除超链接。"
---
## **介绍**

超链接将演示文稿内容连接到网站或演示文稿内部的位置。在 PowerPoint 中，超链接通常有两种用途：

* 从文本、形状或媒体框打开网站。
* 从目录等跳转到另一张幻灯片。

Aspose.Slides for Node.js via Java 允许您添加这些链接、控制其外观和声音、更新属性以及删除它们。下面的示例展示了如何在单个元素上使用超链接，以及如何在演示文稿、幻灯片或文本框级别访问超链接。

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [free online Aspose PowerPoint editor](https://products.aspose.app/slides/zh/editor).

{{% /alert %}} 

## **添加 URL 超链接**

您可以为文本、形状或媒体框分配网站 URL。分配超链接的元素决定可点击区域：文本部分的链接仅针对所选文本，而形状或框的链接则针对整个幻灯片对象。

### **向文本添加 URL 超链接**

要将文本链接到网站，请将 [Hyperlink](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink) 传递给文本部分的 [setHyperlinkClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) 方法，如下所示。只有该文本部分会变为可点击。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **向形状和媒体框添加 URL 超链接**

要使形状或框可点击，调用其 [setHyperlinkClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Shape#setHyperlinkClick) 方法。该超链接属于对象本身，而不是其中的文本部分。

相同的方法适用于图片、音频和视频框：将超链接分配给框并在需要时调用 [setTooltip](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#setTooltip)。

下面的示例使一个矩形可点击：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **使用超链接创建目录**

内部超链接允许读者从目录跳转到特定幻灯片。以下示例使用 [setInternalHyperlinkClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) 将第一张幻灯片上的 “Page 2” 文本链接到第二张幻灯片。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **格式化超链接**

### **颜色**

[Hyperlink](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink) 的 [setColorSource](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#setColorSource) 方法决定超链接是使用演示文稿的超链接颜色还是文本部分的格式。要应用自定义文本颜色，请选择 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkColorSource) 并设置该部分的填充颜色。此功能在 PowerPoint 2019 中引入；旧版本不应用此设置。

下面的示例在同一张幻灯片上添加了两个文本超链接。第一个使用红色文本填充，第二个保留默认超链接颜色。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **声音**

超链接可在激活时播放声音或停止已在播放的声音。使用以下方法配置这些行为：

- [Hyperlink.setSound](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#setSound) 指定与超链接关联的音频。
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) 控制激活超链接时是否停止先前的声音。

#### **添加超链接声音**

下面的示例加载 `sampleaudio.wav` 并将其关联到第一张幻灯片上的按钮。点击按钮会播放声音并跳转到下一张幻灯片。该幻灯片上的第二个形状在点击时停止先前的声音，但不执行跳转操作。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **提取超链接声音**

下面的示例打开上面创建的演示文稿，并通过 [getSound](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#getSound) 和 [getBinaryData](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Audio#getBinaryData) 将第一个形状的超链接音频读取到内存。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **工具提示和交互设置**

在为文本或形状分配超链接后，可以调用以下 [Hyperlink](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink) 方法：

- [setTooltip](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#setTooltip) 设置查看者可显示的链接提示文字。
- [setTargetFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) 指定在父 HTML frameset 中的目标框（如适用）。
- [setHistory](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#setHistory) 控制激活链接时是否将其目的地添加到已查看超链接列表。
- [setHighlightClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) 控制点击时是否突出显示超链接。

## **从演示文稿中移除超链接**

使用 [getAnyHyperlinks](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) 在更改之前收集包括文本部分链接在内的超链接容器。下面的示例从第一张幻灯片中移除两种激活类型。若只想移除一种类型，只调用 [removeHyperlinkClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) 或 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver)；移除点击操作并不会移除其鼠标悬停对应项。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

若需无条件移除，`[removeAllHyperlinks](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks)` 可一次性在选定范围内移除两种激活类型。有关选择性清理以及对母版、布局和备注的覆盖，请参阅 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)。

## **构建完整的超链接清单**

在分发演示文稿之前，需要清点其交互操作及网络链接。`[getAnyHyperlinks](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks)` 返回的是超链接容器，而不是 URL 字符串的平面列表。检查每个容器的 `[getHyperlinkClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Shape#getHyperlinkClick)` 与 `[getHyperlinkMouseOver](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver)`。它们是独立的：同一个容器可以同时暴露两种操作，因此完整报告每个容器可能需要两行。

仅在形状层级扫描可能会遗漏附加在文本部分的链接。请改为查询适当的作用域，并保留返回的容器，以便后续更新或移除其操作。

### **查询演示文稿、幻灯片和文本框作用域**

`[HyperlinkQueries](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkQueries)` 类可通过 `[Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)`、`[BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries)` 与 `[TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries)` 获得。每个作用域支持相同的查询：

- `[getHyperlinkClicks](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks)` 返回具有点击操作的容器。
- `[getHyperlinkMouseOvers](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers)` 返回具有鼠标悬停操作的容器。
- `[getAnyHyperlinks](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks)` 返回具有任一或两种操作的容器。

下面的示例创建 `hyperlink-audit-input.pptx`，其中包含外部点击链接、文件鼠标悬停链接、内部幻灯片导航、文本鼠标悬停链接和宏操作。示例不执行这些操作。相同的三种查询在每个作用域均可使用；计数描述的是容器数量，而不是操作总数。文本框作用域会排除其所属形状的链接。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对本示例而言，演示文稿和幻灯片查询各报告 3 个点击容器、2 个鼠标悬停容器以及 3 个任一操作的容器。文本框查询在每个类别中各报告 1 个容器。

### **对操作和目标进行分类**

使用 `[Hyperlink.getActionType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#getActionType)` 在解释目标之前先解释操作。`[HyperlinkActionType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkActionType)` 的取值覆盖了除网页导航之外的多种情况：

| 值 | 审计含义 |
| --- | --- |
| `Hyperlink` | 外部超链接；检查 URL 及其协议。 |
| `JumpSpecificSlide` | 跳转到特定幻灯片的内部导航。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 内置幻灯片放映导航，在放映上下文中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 结束当前放映或启动自定义放映。 |
| `StartMacro` | 执行宏。 |
| `StartProgram` | 启动程序。 |
| `OpenFile`, `OpenPresentation` | 打开文件或另一个演示文稿；需单独审查。 |
| `StartStopMedia` | 启动或停止媒体播放。 |
| `NoAction`, `Unknown` | 无导航操作或未知操作，需要审查。 |

通过 `[getExternalUrl](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#getExternalUrl)` 读取外部目标；通过 `[getTargetSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#getTargetSlide)` 读取特定内部目标。内部操作和内置命令可能没有外部 URL；空 URL 并不意味着容器没有操作。若 `[getExternalUrlOriginal](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal)` 返回的值与规范化 URL 不同，请保留原始值，并在可用时包含 `[getTooltip](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Hyperlink#getTooltip)` 返回的工具提示。

### **报告、清理并验证超链接**

下面的 JavaScript 示例读取已有演示文稿（使用上面创建的文件），写入 `hyperlink-audit.json`，应用策略，保存为 `hyperlink-sanitized.pptx`，并重新打开以再次检查两种激活类型。它在更改前收集容器，并使用引用相等性避免对同一容器重复处理。演示文稿查询覆盖普通幻灯片；若需全包清点，还显式查询母版、布局、备注以及备注和讲义母版（如存在）。

报告记录基于 1 的幻灯片索引和可用的 `[getSlideId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/BaseSlide#getSlideId)`。`[getSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Shape#getSlide)` 为受支持的容器提供所属幻灯片。母版、布局和备注没有普通幻灯片索引，以其作用域标识。形状容器和文本部分格式容器单独标记；其他容器类型保留其运行时类型名称。每个容器获得报告本地 ID，以便关联其两个操作。报告将操作类型存为 `HyperlinkActionType` 枚举中的整数常量。

此受限的应用策略仅允许绝对 HTTPS URL 和有效的内部幻灯片目标。它会拒绝宏、程序、文件操作、其他幻灯片操作、未知操作以及其他 URL 协议。这些拒绝是策略决定，而非 Aspose.Slides 安全判定。仅有 HTTPS 并不等同于可信：请为您的应用添加主机白名单等检查。原始和规范化的外部 URL 均会被检查。示例仅审计元数据，不会跟随链接或执行操作。

对于修复，容器的 `[getHyperlinkManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Shape#getHyperlinkManager)` 支持 `[setExternalHyperlinkClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick)`、`[removeHyperlinkClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick)` 与 `[removeHyperlinkMouseOver](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver)`。在此示例中，受限的外部点击链接被替换为固定的 HTTPS 登录页；其他受限的点击和受限的鼠标悬停操作则分别被移除。将 `replaceExternalClicks` 设置为 `false` 可以删除所有策略违规。请在部署前准备好应用拥有的替换页面。

报告的导出标记采用保守的 PDF 审查策略：将鼠标悬停操作以及除外部链接或特定幻灯片跳转之外的任何操作标记为可能不受支持。这仅是审查提示，而非功能测试或对未标记链接的导出保证。支持的 [PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/) 与 [HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/) 导出可能保留超链接，取决于操作、导出选项和查看器。栅格 [images](/slides/zh/nodejs-java/convert-powerpoint-to-png/) 与 [video](/slides/zh/nodejs-java/convert-powerpoint-to-video/) 无法保留交互超链接；在审计这些输出时请标记每个操作。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

使用上述输入创建的报告包含五行操作。文件鼠标悬停链接和宏点击被移除，HTTPS 链接和内部幻灯片导航保留。验证阶段打印出零个违规操作。包含受限外部点击 URL 的输入还演示了替换分支。一个同时拥有允许点击和受限鼠标悬停的容器保留其点击操作。

此选择性清理不同于 `[removeAllHyperlinks](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks)`，后者会在选定范围内无论策略如何都移除两种激活类型。此处的验证仅检查超链接操作，不会移除嵌入的 VBA 项目、OLE 对象或其他活动内容，也不对导出的 PDF 或 HTML 文件进行验证。

## **常见问题解答**

**如何链接到某个章节或其首张幻灯片？**

PowerPoint 中的章节用于对幻灯片分组，但内部超链接只能定位到单个幻灯片。若要实现跳转到章节，请链接到该章节的第一张幻灯片。

**我能将超链接附加到母版幻灯片元素上，使其在所有幻灯片上都有效吗？**

可以。母版幻灯片和布局元素支持超链接。这些元素上的链接在使用相应母版或布局的幻灯片放映期间可用。

**导出为 PDF、HTML、图像或视频时，超链接会被保留吗？**

支持的 PDF 和 HTML 导出可能保留超链接；栅格图像和视频则不能。请参阅 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) 中的导出注意事项。