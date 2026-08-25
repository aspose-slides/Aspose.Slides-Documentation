---
title: 在 Android 上高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/androidjava/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併 簡報
- 合併 投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 結合 PowerPoint
- 結合 簡報
- 結合 投影片
- 結合 PPT
- 結合 PPTX
- 結合 ODP
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上透過克隆投影片、控制母版與布局、調整投影片內容大小、保留章節，並處理受保護或大型檔案，以合併 PowerPoint 與 OpenDocument 簡報。"
---
## **概述**

Aspose.Slides for Android via Java 通过克隆幻灯片将演示文稿从一个 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 合并到另一个。主要操作是 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)，它可以保留源幻灯片的格式，或将克隆的幻灯片附加到目标演示文稿的母版或布局。

本文介绍最常见的合并工作流：

- 合并所有幻灯片并保留其源格式；
- 合并选定的幻灯片；
- 应用目标演示文稿的母版；
- 应用目标演示文稿的特定布局；
- 在合并前规范化不同的幻灯片尺寸；
- 将克隆的幻灯片添加到章节；
- 在一个端到端工作流中合并多个演示文稿；
- 处理母版、资源、备注、批注、媒体、字体、密码、大文件和多线程相关问题。

## **幻灯片克隆如何影响母版和布局**

幻灯片的大部分外观继承自其布局和母版。因此，您选择的克隆重载决定了合并后幻灯片在目标演示文稿中的集成方式。

使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/) 的以下方式之一：

- `addClone(sourceSlide)` — 保持源幻灯片的布局和格式。必要时，源母版会自动克隆到目标演示文稿。Aspose.Slides 会跟踪自动克隆的母版，以免对使用相同源母版的重复幻灯片进行多次克隆。
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 将克隆的幻灯片附加到特定的目标 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/)。Aspose.Slides 会在该母版下按布局类型或名称查找匹配的布局。
- `addClone(sourceSlide, destinationLayout)` — 将克隆的幻灯片直接附加到特定的目标 [ILayoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/)。

传递给 `addClone` 重载的母版或布局必须属于 **目标** 演示文稿，而不是源演示文稿。

## **合并整个演示文稿并保留源格式**

最简单的合并方式是将源演示文稿的每一张幻灯片复制到目标演示文稿。这是在导入的幻灯片应保持原始主题、母版和布局关系时的合适选择。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

当源和目标使用不同设计时，生成的演示文稿可能包含多个母版。这在有意保留源格式时是预期行为。

## **合并选定的幻灯片**

您不必克隆每张幻灯片。下面的示例仅从源演示文稿导入选定的幻灯片索引。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

在克隆之前对幻灯片索引进行验证，尤其是这些索引来自用户输入或外部配置时。

## **使用目标母版合并幻灯片**

当导入的幻灯片应遵循已属于目标演示文稿的母版时，使用 [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 重载。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides 会通过匹配源布局的类型或名称，在指定的母版下选择合适的布局。如果不存在匹配的布局且 `allowCloneMissingLayout` 为 `true`，则会克隆源布局以便添加幻灯片；如果为 `false`，则会抛出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxeditexception/)。

在希望合并失败而不是向目标母版引入额外布局时，请使用 `false`。

## **使用特定目标布局合并幻灯片**

当您明确知道导入的幻灯片应使用哪个目标布局时，使用 [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ILayoutSlide-) 重载。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

应用目标布局会更改继承的布局关系；它不会重新设计源幻灯片的内容。如果源布局与目标布局的占位符结构不同，请检查结果，以确认继承的格式和占位符行为是否符合预期。

## **合并不同幻灯片尺寸的演示文稿**

尺寸不同的演示文稿可以合并，但将幻灯片克隆到具有另一尺寸的演示文稿时，内容不会自动为新画布重新设计。因此形状可能出现位置偏移、意外缩放，或超出可见幻灯片区域。

一种实用方法是先调整源演示文稿的尺寸再进行克隆。`[SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-)` 方法可以在更改幻灯片尺寸的同时缩放已有内容。`[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesizescaletype/)` 会将内容缩放以适应指定尺寸。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

调整尺寸会修改内存中的源演示文稿对象。如果需要在其他操作中保持源演示文稿不变，请为合并打开单独的实例。

## **将幻灯片合并到演示文稿章节**

基本的幻灯片克隆循环不会重新创建源演示文稿的章节层级。如果章节在输出中很重要，请在目标演示文稿中创建或选择章节，并使用 `[addClone(ISlide, ISection)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-)` 显式将幻灯片克隆到相应章节。

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

克隆的幻灯片会附加到指定的目标章节。若要保留多个源章节，请遍历 `[Presentation.getSections](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSections--)`，使用 `[ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--)` 获取每个源章节的当前幻灯片，在目标中重新创建章节，并将每个返回的幻灯片克隆到对应的目标章节。完整的章节枚举示例请参见 [管理幻灯片章节](/slides/zh-hant/androidjava/slide-section/)，其中包括空章节和结构更改的处理。

## **安全地合并多个演示文稿**

下面的端到端示例使用第一个演示文稿作为目标，规范化每个额外源的幻灯片尺寸，仅在复制时打开每个源，并在最后一次保存文件。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

这是一种保留导入幻灯片源格式的有用基线。如果输出必须使用单一目标主题，请将简单的 `addClone(slide)` 调用替换为前面展示的适当的目标母版或目标布局重载。

## **实用注意事项**

### **母版、布局与格式保真度**

默认的幻灯片克隆可以自动将所需的源母版带入目标演示文稿。Aspose.Slides 为自动克隆的母版维护内部注册表，以避免对同一母版进行重复克隆。手动克隆的母版不会被该注册表跟踪，因此除非需要对母版结构进行显式控制，否则请避免预先克隆母版。

不要假设同名的两个母版或布局在视觉上是等价的。如果企业模板必须控制最终外观，请显式选择目标母版或布局，并在合并后验证结果。

### **备注和批注**

演讲者备注和幻灯片批注与幻灯片内容关联，克隆幻灯片时会一起复制。Aspose.Slides 还提供专用 API 用于 [演示文稿备注](/slides/zh-hant/androidjava/presentation-notes/) 和 [演示文稿批注](/slides/zh-hant/androidjava/presentation-comments/)。

如果备注页的格式很重要，请检查合并后的演示文稿，因为备注母版是演示文稿级对象，可能在源文件之间存在差异。对于评审工作流，还需在合并来自不同作者或模板的文件后验证批注作者和线程批注。

### **图像、音频、视频、OLE 对象和外部链接**

幻灯片可以引用演示文稿级资源，如图像、嵌入式音频、嵌入式视频和 OLE 数据。请克隆整个幻灯片，而不是仅复制可见形状，以便 Aspose.Slides 能维护幻灯片与其资源的关系。

嵌入式资源与链接资源应区别对待。链接的音频、视频、OLE 对象或超链接仍依赖其外部目标；克隆幻灯片不会将外部链接转换为嵌入内容。请在合并后在实际打开环境中测试链接资源的路径和 URL。

Aspose.Slides 会显式跟踪自动克隆的母版，但这不应被视为对不相关源演示文稿中相同二进制资源始终去重的通用保证。如果输出文件大小重要，请检查合并后的包并自行测量结果，而不是依赖隐式去重。

### **嵌入字体与字体可用性**

字体在演示文稿级别管理。如果排版必须在不同机器上保持一致，不要仅凭克隆幻灯片就假设所有必需字体在目标环境中可用。您可以使用 `[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)` 检查嵌入的字体，并按照 [在演示文稿中嵌入字体](/slides/zh-hant/androidjava/embedded-font/) 的说明显式管理嵌入。

同时，请确认您有权嵌入源文件使用的字体。字体许可证可能限制嵌入。

### **受密码保护的演示文稿**

在克隆幻灯片之前，必须成功打开受密码保护的源文件。请通过 `[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` 提供密码。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // 處理已解密的簡報。
} finally {
    source.dispose();
}
```

打开加密的源文件并不会自动将相同的保护应用到目标演示文稿。需要时请单独配置输出保护。

### **大文件演示文稿与内存使用**

包含高分辨率图像、音频、视频或其他大二进制对象的大型演示文稿可能会占用大量内存。`[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--)` 提供对 BLOB 处理和临时文件使用的控制。有关大文件策略，请参见 [管理演示文稿 BLOB](/slides/zh-hant/androidjava/manage-blob/)。

对于大文件，尽可能使用文件路径加载，在合并完成后立即释放每个源演示文稿，并避免反复保存中间结果，除非工作流需要检查点。

### **线程安全**

不要在多个线程中同时加载、修改、保存或克隆同一个 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 实例。将每个演示文稿实例限制在单个合并操作中。如果并行处理独立任务，请使用独立的演示文稿实例，并遵循 [Aspose.Slides 多线程指南](/slides/zh-hant/androidjava/multithreading/)。

## **常见问题解答**

**如何保持每个源演示文稿的原始设计？**

使用不提供目标母版或布局的 [addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-)。Aspose.Slides 可以在导入的幻灯片需要时自动克隆源母版。

**如何让导入的幻灯片使用目标主题？**

使用接受目标母版的重载。传入目标演示文稿中的母版，而不是来源的。Aspose.Slides 将尝试将每个源幻灯片映射到该母版下的合适布局。

**何时应使用特定的目标布局而不是目标母版？**

当每个导入的幻灯片都应使用已知的单一布局时使用特定布局；当希望 Aspose.Slides 根据源布局的类型或名称在该母版的布局中进行选择时使用母版。

**不同幻灯片尺寸的演示文稿能合并吗？**

可以，但幻灯片内容不会自动为目标尺寸重新设计。需要可预期的布局时，请先使用 `[SlideSize.setSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-)` 和 `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesizescaletype/)` 调整源演示文稿。

**可以将 PPT、PPTX 和 ODP 演示文稿合并为一个文件吗？**

可以。加载每个源演示文稿，将所需幻灯片克隆到同一目标中，并以支持的输出格式保存。由于各演示文稿格式的功能集并不完全相同，跨格式合并后请验证复杂内容。参见 [受支持的文件格式](/slides/zh-hant/androidjava/supported-file-formats/)。

**源章节会自动保留吗？**

基本只克隆幻灯片的循环不会保留章节。请在目标中重新创建所需章节，并在需要保留章节结构时使用 `[addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-)` 的章节重载。

**演讲者备注和批注会被保留吗？**

它们会随克隆的幻灯片一起复制。对于依赖备注母版样式、批注作者或线程审阅数据的工作流，请在合并后验证结果，因为这些场景涉及演示文稿级结构以及幻灯片级内容。

**音频、视频、OLE 对象和超链接会怎样处理？**

嵌入的内容会随克隆的幻灯片资源关系一起携带。外部链接仍保持外部状态，合并后其目标文件或 URL 必须仍然可用。

**是否保证所有源的嵌入字体在合并后可用？**

仅凭幻灯片克隆不能保证字体部署。请检查目标的嵌入字体，并在排版重要时显式管理字体嵌入或外部字体的可用性。

**如何合并受密码保护的文件？**

使用正确的 `[LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` 打开文件，然后正常克隆其幻灯片。输出保护需另行配置。

**如何处理非常大的演示文稿？**

在大型二进制对象占用内存较多的情况下使用 BLOB 管理，尽可能采用文件路径加载，及时释放源演示文稿，并仅在需要时保存最终结果。

**可以从多个线程合并幻灯片吗？**

不要在多个线程中并发使用同一个 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 实例。每个合并操作应使用各自独立的演示文稿实例。