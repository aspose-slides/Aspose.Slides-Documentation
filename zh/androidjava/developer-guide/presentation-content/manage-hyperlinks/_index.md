---
title: 在 Android 上管理演示文稿超链接
linktitle: 管理超链接
type: docs
weight: 20
url: /zh/androidjava/manage-hyperlinks/
keywords:
- 添加 URL
- 添加 超链接
- 创建 超链接
- 格式化 超链接
- 移除 超链接
- 更新 超链接
- 文本 超链接
- 幻灯片 超链接
- 形状 超链接
- 图像 超链接
- 视频 超链接
- 可变 超链接
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，利用 Java 示例在 PowerPoint 和 OpenDocument 演示文稿中添加、格式化、更新和移除超链接。"
---
## **介绍**

超链接将演示文稿内容连接到网站或演示文稿内部的某个位置。在 PowerPoint 中，超链接通常有两个用途：

* 从文本、形状或媒体框打开网站。
* 从例如目录的地方导航到另一张幻灯片。

Aspose.Slides for Android via Java 让您可以添加这些链接、控制其外观和声音、更新其属性以及移除它们。下面的示例展示了如何在单个元素上使用超链接，以及如何在演示文稿、幻灯片或文本框级别访问超链接。

{{% alert color="info" title="注意" %}}
您还可以使用 [免费在线 Aspose PowerPoint 编辑器](https://products.aspose.app/slides/zh/editor) 编辑演示文稿。
{{% /alert %}} 

## **添加 URL 超链接**

您可以将网站 URL 分配给文本、形状或媒体框。分配超链接的元素决定了可点击区域：文本部分链接所选文本，而形状或框则链接整个幻灯片对象。

### **向文本添加 URL 超链接**

要将文本链接到网站，请将 [Hyperlink](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/hyperlink/) 传递给文本部分的 [setHyperlinkClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) 方法，如下所示。只有该文本部分可点击。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **向形状和媒体框添加 URL 超链接**

要使形状或框可点击，调用其 [setHyperlinkClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) 方法。超链接属于对象本身，而不是其中的文本部分。

相同的方法适用于图片、音频和视频框：将超链接分配给框并在需要时调用 [setTooltip](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-)。

下面的示例使一个矩形可点击：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **使用超链接创建目录**

内部超链接让读者可以从目录跳转到特定幻灯片。下面的示例使用 [setInternalHyperlinkClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) 将第一张幻灯片上的 “Page 2” 文本链接到第二张幻灯片。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **格式化超链接**

### **颜色**

[IHyperlink](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/) 的 [setColorSource](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) 方法决定超链接是使用演示文稿的超链接颜色还是文本部分的格式。要应用自定义文字颜色，请选择 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/hyperlinkcolorsource/) 并设置该部分的填充颜色。此功能在 PowerPoint 2019 中引入；较早的版本不支持此设置。

下面的示例在同一张幻灯片上添加了两个文本超链接。第一个使用红色填充，第二个保留默认的超链接颜色。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **声音**

激活超链接时可以播放声音，或停止已经在播放的声音。使用以下方法配置这些行为：

- [IHyperlink.setSound](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) 指定与超链接关联的音频。
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) 控制激活超链接时是否停止之前的声音。

#### **添加超链接声音**

下面的示例加载 `sampleaudio.wav` 并将其关联到第一张幻灯片上的一个按钮。单击按钮会播放声音并跳转到下一张幻灯片。该幻灯片上的第二个形状在单击时停止前面的声音，但不执行导航操作。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **提取超链接声音**

下面的示例打开上面创建的演示文稿，并通过 [getSound](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#getSound--) 和 [getBinaryData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaudio/#getBinaryData--) 将第一个形状的超链接音频读取到内存中。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **提示和交互设置**

在为文本或形状分配超链接后，您可以调用以下 [IHyperlink](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/) 方法：

- [setTooltip](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) 设置查看者在悬停时显示的提示文字。
- [setTargetFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) 在适用时指定父 HTML frameset 中的目标框架。
- [setHistory](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) 控制激活链接后是否将其目标加入已查看超链接列表。
- [setHighlightClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) 控制单击时是否突出显示超链接。

## **从演示文稿中移除超链接**

使用 [getAnyHyperlinks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) 收集包括文本部分链接在内的所有超链接容器后，再对其进行修改。下面的示例从第一张幻灯片中移除两种激活方式。若只想移除一种，请仅调用 [removeHyperlinkClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) 或 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--)；移除点击操作并不会去除其鼠标悬停对应项。

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

若要无条件移除，使用 [removeAllHyperlinks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) 在选定范围内一次性移除两种激活方式。有关针对母版、布局和备注的选择性清理及完整覆盖，请参阅 [报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)。

## **构建完整的超链接清单**

在分发演示文稿前，请清点其中的交互操作以及网页链接。[getAnyHyperlinks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) 返回的是 [IHyperlinkContainer](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkcontainer/) 对象，而不是 URL 字符串的扁平列表。请检查每个容器的 [getHyperlinkClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) 和 [getHyperlinkMouseOver](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--)。它们是独立的：同一个容器可以同时暴露两种操作，因此完整报告每个容器可能需要两行。

仅在形状级别扫描超链接可能会遗漏附加在文本部分的链接。请改为查询相应的范围，并保留返回的容器，以便后续更新或移除其操作。

### **查询演示文稿、幻灯片和文本框范围**

[IHyperlinkQueries](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkqueries/) 接口可通过 [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--)、[IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) 和 [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) 访问。每个范围支持相同的查询：

- [getHyperlinkClicks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) 返回带有点击操作的容器。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) 返回带有鼠标悬停操作的容器。
- [getAnyHyperlinks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) 返回带有任一或两种操作的容器。

下面的示例创建 `hyperlink-audit-input.pptx`，其中包含外部点击链接、文件鼠标悬停链接、内部幻灯片导航、文本鼠标悬停链接以及宏操作。它不会执行这些操作。相同的三个查询在每个范围内均可使用；计数指的是容器数量，而非操作总数。文本框范围会排除外部形状自身的链接。

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在此示例中，演示文稿和幻灯片查询各报告三条点击容器、两条鼠标悬停容器以及三条任一操作的容器。文本框查询在每个类别中各报告一个容器。

### **对操作和目标进行分类**

使用 [IHyperlink.getActionType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#getActionType--) 在解释目标之前先解释操作。[HyperlinkActionType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/hyperlinkactiontype/) 的取值覆盖了不仅仅是网页导航的情况：

| 值 | 审计含义 |
| --- | --- |
| `Hyperlink` | 外部超链接；检查 URL 及其方案。 |
| `JumpSpecificSlide` | 导航到具体幻灯片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 内置幻灯片放映导航，在放映上下文中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 结束当前放映或启动自定义放映。 |
| `StartMacro` | 执行宏。 |
| `StartProgram` | 启动程序。 |
| `OpenFile`, `OpenPresentation` | 打开文件或其他演示文稿；需单独于网页 URL 进行审查。 |
| `StartStopMedia` | 开始或停止媒体播放。 |
| `NoAction`, `Unknown` | 无导航操作，或未识别的操作，需要审查。 |

通过 [getExternalUrl](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) 读取外部目标；通过 [getTargetSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) 读取具体内部目标。内部操作和内置命令可能没有外部 URL；空 URL 并不意味着容器没有操作。若 [getExternalUrlOriginal](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) 返回的值与标准化 URL 不同，请保留该原始值，并在可用时包括 [getTooltip](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) 返回的提示。

### **报告、清理和验证超链接**

下面的 Java 示例读取已有演示文稿（使用上面创建的文件），写入 `hyperlink-audit.json`，应用策略，保存为 `hyperlink-sanitized.pptx`，并重新打开以再次检查两种激活方式。它在更改前收集容器，并使用引用相等性避免对同一容器进行双重处理。演示文稿查询覆盖普通幻灯片；若需全包清单，还会显式查询母版、布局、备注以及存在时的备注和讲义母版。

报告记录了基于 1 的幻灯片索引和在可用时的 [getSlideId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseslide/#getSlideId)。[ISlideComponent.getSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islidecomponent/#getSlide--) 为受支持的容器提供所属幻灯片。母版、布局和备注没有普通幻灯片索引，使用其范围进行标识。形状容器和文本段落格式容器分别标记；其他容器类型保留其运行时类型名称。每个容器获得报告本地 ID，以便关联其两种操作。报告将操作类型存为 Java 枚举定义的整数常量。

此限制性应用策略仅允许绝对 HTTPS URL 和有效的内部幻灯片目标。它会拒绝宏、程序、文件操作、其他幻灯片操作、未知操作以及其他 URL 方案。这些拒绝是策略决策，而非 Aspose.Slides 安全判定。仅 HTTPS 并不能建立信任：请为您的应用添加主机白名单等检查。外部 URL 的原始和标准化形式都会被检查。示例在不跟随链接或运行操作的情况下审计元数据。

对于修复，容器的 [getHyperlinkManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) 支持 [setExternalHyperlinkClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)、[removeHyperlinkClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) 和 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--)。这里，将被禁止的外部点击链接替换为固定的 HTTPS 落地页；其他被禁止的点击和鼠标悬停操作则分别移除。将 `replaceExternalClicks` 设置为 `false` 可直接移除所有违规项。请在部署前选择由应用拥有的替代页面。

报告的导出标记采用保守的 PDF 审核策略：将鼠标悬停操作以及除外部链接或特定幻灯片跳转之外的所有内容标记为可能不受支持。这是审查提示，而非功能测试或对未标记链接在导出后仍能保留的保证。受支持的 [PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/) 和 [HTML](/slides/zh/androidjava/convert-powerpoint-to-html/) 导出可能保留超链接，具体取决于操作、导出选项和查看器。光栅化的 [图像](/slides/zh/androidjava/convert-powerpoint-to-png/) 与 [视频](/slides/zh/androidjava/convert-powerpoint-to-video/) 则无法保留交互式超链接；在针对这些输出进行审计时请为每个操作打标记。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // 序列化此报告的平面行，无需额外的 JSON 依赖。
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

使用上述输入，报告包含五行操作。文件鼠标悬停链接和宏点击被移除，HTTPS 链接和内部幻灯片导航保留。验证阶段输出零个违规操作。包含被禁止的外部点击 URL 的输入还会演示替换分支。一个容器如果拥有允许的点击且被禁止的鼠标悬停，则保留其点击操作。

此选择性清理不同于 [removeAllHyperlinks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--)——后者会在选定范围内不顾策略一次性移除两种激活方式。此处的验证仅检查超链接操作，不会移除嵌入的 VBA 项目、OLE 对象或其他活动内容，也不对导出的 PDF 或 HTML 文件进行验证。

## **常见问题**

**如何链接到某个章节或其第一张幻灯片？**

PowerPoint 中的章节用于组织幻灯片，但内部超链接只能定位到单个幻灯片。若要实现章节导航，请链接到该章节的第一张幻灯片。

**能否将超链接附加到母版幻灯片元素，使其在所有幻灯片上生效？**

可以。母版幻灯片和布局元素支持超链接。这些元素上的链接在使用相应母版或布局的幻灯片放映时可用。

**导出为 PDF、HTML、图像或视频时超链接会被保留吗？**

受支持的 PDF 和 HTML 导出可能会保留超链接；光栅图像和视频则不会。详细的导出注意事项请参阅 [报告、清理和验证超链接](#report-sanitize-and-verify-hyperlinks)。