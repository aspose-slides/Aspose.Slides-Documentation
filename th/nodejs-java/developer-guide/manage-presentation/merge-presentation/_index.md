---
title: รวมชุดนำเสนออย่างมีประสิทธิภาพด้วย JavaScript
linktitle: รวมชุดนำเสนอ
type: docs
weight: 40
url: /th/nodejs-java/merge-presentation/
keywords:
- รวม PowerPoint
- รวมชุดนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- ผสาน PowerPoint
- ผสานชุดนำเสนอ
- ผสานสไลด์
- ผสาน PPT
- ผสาน PPTX
- ผสาน ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีรวมชุดนำเสนอ PowerPoint และ OpenDocument ด้วย JavaScript โดยคัดลอกสไลด์, ควบคุมมาสเตอร์และเลเอาต์, ปรับขนาดเนื้อหาสไลด์, คงส่วนต่างๆ, และจัดการไฟล์ที่ถูกป้องกันหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java merges presentations by cloning slides from one [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) into another. The main operation is [SlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), which can preserve the source slide's formatting or attach the cloned slide to a master or layout in the destination presentation.

This article covers the most common merging workflows:

- merge all slides while preserving their source formatting;
- merge selected slides;
- apply a master from the destination presentation;
- apply a specific layout from the destination presentation;
- normalize different slide sizes before merging;
- add cloned slides to a section;
- merge several presentations in one end-to-end workflow;
- handle masters, resources, notes, comments, media, fonts, passwords, large files, and multithreading concerns.

## **การคัดลอกสไลด์มีผลต่อมาสเตอร์และเลเอาต์อย่างไร**

A slide inherits much of its appearance from its layout and master. For that reason, the cloning overload you choose determines how the merged slide is integrated into the destination presentation.

Use [SlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) in one of these ways:

- `addClone(sourceSlide)` — preserve the source slide's layout and formatting. When required, the source master can be cloned into the destination presentation automatically. Aspose.Slides tracks automatically cloned masters so repeated slides that use the same source master do not cause that master to be cloned repeatedly.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — attach the cloned slide to a specific destination [MasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/). Aspose.Slides looks for a matching layout under that master by layout type or name.
- `addClone(sourceSlide, destinationLayout)` — attach the cloned slide directly to a specific destination [LayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/).

The master or layout passed to an `addClone` overload must belong to the **destination** presentation, not the source presentation.

## **รวมชุดนำเสนอทั้งหมดและคงรูปแบบต้นทาง**

The simplest merge copies every slide from the source presentation to the destination presentation. This is the appropriate choice when the imported slides should keep their original theme, master, and layout relationships.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

The resulting presentation may contain multiple masters when the source and destination use different designs. This is expected when source formatting is intentionally preserved.

## **รวมสไลด์ที่เลือก**

You do not have to clone every slide. The following example imports only selected slide indexes from the source presentation.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Validate slide indexes before cloning when they come from user input or external configuration.

## **รวมสไลด์โดยใช้มาสเตอร์ปลายทาง**

Use the [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) overload when imported slides should follow a master that already belongs to the destination presentation.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides selects an appropriate layout under the specified master by matching the source layout's type or name. If no suitable layout exists and `allowCloneMissingLayout` is `true`, the source layout is cloned so the slide can be added. If it is `false`, a [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxeditexception/) is thrown.

Use `false` when you want the merge to fail instead of introducing an additional layout into the destination master.

## **รวมสไลด์โดยใช้เลเอ็ตปลายทางเฉพาะ**

Use the [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) overload when you know exactly which destination layout the imported slides should use.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Applying a destination layout changes the inherited layout relationship; it does not redesign the source slide content. If the source and destination layouts have different placeholder structures, inspect the result to confirm that the inherited formatting and placeholder behavior are appropriate.

## **รวมชุดนำเสนอที่มีขนาดสไลด์ต่างกัน**

Presentations with different slide dimensions can be merged, but cloning a slide into a presentation with another slide size does not automatically redesign its content for the new canvas. Shapes may therefore appear shifted, scaled unexpectedly, or outside the visible slide area.

A practical approach is to resize the source presentation before cloning. The [SlideSize.setSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) method can scale existing content while changing the slide dimensions. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesizescaletype/) scales content to fit within the requested size.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Resizing changes the source presentation object in memory. If you need the original source presentation unchanged for other operations, open a separate instance for the merge.

## **รวมสไลด์เข้าส่วนของชุดนำเสนอ**

The basic slide-cloning loop does not recreate the source presentation's section hierarchy. If sections matter in the output, create or select sections in the destination presentation and clone slides into them explicitly with [addClone(Slide, Section)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

The cloned slides are appended to the specified destination section. To preserve several source sections, recreate those sections in the destination and map each source slide to the corresponding destination section.

## **รวมหลายชุดนำเสนออย่างปลอดภัย**

The following end-to-end example uses the first presentation as the destination, normalizes the slide size of each additional source, keeps each source open only while it is being copied, and saves the final file once.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

This is a useful baseline for preserving the source formatting of imported slides. If your output must use a single destination theme, replace the simple `addClone(sourceSlide)` call with the appropriate destination-master or destination-layout overload shown earlier.

## **ข้อควรพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลเอ็ต, และความแม่นยำของการจัดรูปแบบ**

Default slide cloning can automatically bring a required source master into the destination presentation. Aspose.Slides keeps an internal registry for automatically cloned masters to avoid cloning the same master repeatedly. Manually cloned masters are not tracked by that registry, so avoid pre-cloning masters unless you need explicit control over the master structure.

Do not assume that two masters or layouts with the same name are visually equivalent. If a corporate template must control the final appearance, choose a destination master or layout explicitly and verify the result after merging.

### **โน้ตและคอมเมนต์**

Speaker notes and slide comments are associated with slide content and are copied when a slide is cloned. Aspose.Slides also exposes dedicated APIs for [presentation notes](https://docs.aspose.com/slides/th/nodejs-java/presentation-notes/) and [presentation comments](https://docs.aspose.com/slides/th/nodejs-java/presentation-comments/).

If notes-page formatting is important, verify the merged presentation because notes masters are presentation-level objects and may differ between source files. For review workflows, also verify comment authors and threaded comments after combining files from different authors or templates.

### **รูปภาพ, เสียง, วิดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

Slides can reference presentation-level resources such as images, embedded audio, embedded video, and OLE data. Clone the slide itself rather than copying only its visible shapes so Aspose.Slides can maintain the slide's relationships to its resources.

Embedded and linked resources should be treated differently. A linked audio, video, OLE object, or hyperlink remains dependent on its external target; cloning a slide does not turn an external link into embedded content. Test linked-resource paths and URLs in the environment where the merged presentation will be opened.

Aspose.Slides explicitly tracks automatically cloned masters, but this should not be treated as a general guarantee that identical binary resources from unrelated source presentations will always be deduplicated. If output file size is important, inspect the merged package and measure the result instead of relying on implicit deduplication.

### **ฟอนต์ฝังและการเข้าถึงฟอนต์**

Fonts are managed at the presentation level. If typography must remain consistent across machines, do not assume that cloning slides alone guarantees that every required font is available in the destination environment. You can inspect embedded fonts with [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) and manage embedding explicitly as described in [Embed Fonts in Presentations](https://docs.aspose.com/slides/th/nodejs-java/embedded-font/).

Also verify that you are permitted to embed the fonts used by the source files. Font licenses can restrict embedding.

### **ชุดนำเสนอที่ป้องกันด้วยรหัสผ่าน**

A password-protected source must be opened successfully before its slides can be cloned. Supply the password through [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // ทำงานกับชุดนำเสนอที่ถอดรหัสแล้ว.
} finally {
    source.dispose();
}
```

Opening an encrypted source does not automatically apply the same protection to the destination presentation. Configure output protection separately when required.

### **ชุดนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

Large presentations containing high-resolution images, audio, video, or other large binary objects can consume significant memory. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) provides controls for BLOB handling and temporary-file usage. See [Manage Presentation BLOBs](https://docs.aspose.com/slides/th/nodejs-java/manage-blob/) for large-file strategies.

For large files, prefer loading from file paths when possible, dispose each source presentation as soon as it has been merged, and avoid repeatedly saving intermediate results unless the workflow requires checkpoints.

### **ความปลอดภัยของเธรด**

Do not load, save, or clone a [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) instance in multiple threads. These operations are not supported for multithreaded use. If you need to parallelize independent merge jobs, use several single-threaded processes, each with its own presentation instances, and follow the [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/th/nodejs-java/multithreading/).

## **คำถามที่พบบ่อย**

**ฉันจะรักษาการออกแบบดั้งเดิมของแต่ละชุดนำเสนอต้นทางได้อย่างไร?**

Use [`addClone(sourceSlide)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) without supplying a destination master or layout. Aspose.Slides can automatically clone the source master when it is needed by the imported slide.

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมปลายทางได้อย่างไร?**

Use the overload that accepts a destination master. Pass a master from the destination presentation, not from the source. Aspose.Slides will try to map each source slide to an appropriate layout under that master.

**ควรใช้เลเอ็ตปลายทางเฉพาะแทนมาสเตอร์ปลายทางเมื่อใด?**

Use a specific layout when every imported slide should use one known layout. Use a master when you want Aspose.Slides to select among that master's layouts based on the source layout type or name.

**ชุดนำเสนอที่มีขนาดสไลด์ต่างกันสามารถรวมได้หรือไม่?**

Yes, but slide content is not automatically redesigned for the destination dimensions. Resize the source presentation first when you need predictable placement, for example with [SlideSize.setSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) and [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesizescaletype/).

**ฉันสามารถรวมไฟล์ PPT, PPTX, และ ODP เป็นไฟล์เดียวได้หรือไม่?**

Yes. Load each source presentation, clone the required slides into one destination, and save the destination in a supported output format. Because presentation formats do not support exactly the same feature set, verify complex content after cross-format merges. See [Supported File Formats](https://docs.aspose.com/slides/th/nodejs-java/supported-file-formats/).

**ส่วนของต้นทางจะถูกคงไว้โดยอัตโนมัติหรือไม่?**

Not by a basic loop that only clones slides. Recreate the required sections in the destination and use the section overload of [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) when section structure must be preserved.

**โน้ตของผู้พูดและคอมเมนต์จะถูกคงไว้หรือไม่?**

They are copied with the cloned slide. For workflows that depend on notes-master styling, comment authors, or threaded review data, verify the merged result because those scenarios involve presentation-level structures as well as slide-level content.

**จะเกิดอะไรกับเสียง, วิดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์?**

Embedded content is carried as part of the cloned slide's resource relationships. External links remain external, so their target files or URLs must still be available after the merge.

**ฟอนต์ฝังจากทุกแหล่งต้นถูกรับประกันว่าจะพร้อมใช้งานในชุดนำเสนอที่รวมหรือไม่?**

Do not rely on slide cloning alone for font deployment. Inspect the destination's embedded fonts and explicitly manage font embedding or external font availability when typography is important.

**ฉันจะรวมไฟล์ที่ป้องกันด้วยรหัสผ่านอย่างไร?**

Open it with the correct [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), then clone its slides normally. Output protection is configured separately.

**ฉันควรจัดการชุดนำเสนอขนาดใหญ่อย่างไร?**

Use BLOB management when large binary objects dominate memory usage, prefer file-path loading for very large files, dispose source presentations promptly, and save the final result only when needed.

**ฉันสามารถรวมสไลด์จากหลายเธรดได้หรือไม่?**

Do not load, save, or clone presentation instances in multiple threads. For parallel merge jobs, use separate single-threaded processes and independent presentation instances.