---
title: "Quản lý Slide Master của Bài thuyết trình trong Java"
linktitle: "Slide Master"
type: docs
weight: 70
url: /vi/java/slide-master/
keywords:
  - "slide master"
  - "slide master"
  - "slide master PPT"
  - "nhiều slide master"
  - "so sánh slide master"
  - "nền"
  - "trình giữ chỗ"
  - "sao chép slide master"
  - "chép slide master"
  - "nhân bản slide master"
  - "slide master không dùng"
  - "PowerPoint"
  - "OpenDocument"
  - "bài thuyết trình"
  - "Java"
  - "Aspose.Slides"
description: "Quản lý slide master trong Aspose.Slides cho Java: truy cập, chỉnh sửa, sao chép, so sánh và xóa slide master trong các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

A **slide master** defines shared design settings for a group of slides. It can contain common shapes, logos, backgrounds, text styles, theme settings, and footer settings. In PowerPoint, editing a slide master is the usual way to keep a presentation consistent without repeating the same formatting on every slide.

Aspose.Slides for Java supports the same model. A presentation can contain one or more master slides, and each master slide can contain several layout slides. Normal slides do not usually refer to a master slide directly. Instead, a normal slide uses a layout slide, and that layout slide belongs to a master slide.

The hierarchy is:

1. **Slide master** - defines the shared design and theme.
1. **Layout slide** - defines a specific arrangement of placeholders and layout-level formatting.
1. **Normal slide** - contains the actual presentation content and uses one layout slide.

![Sơ đồ phân cấp của slide master, layout slide và normal slide](slide-master_2.jpg)

In Aspose.Slides, a slide master is represented by the [IMasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/) interface. All master slides in a presentation are available through the [Presentation.getMasters](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getMasters--) collection, which implements [IMasterSlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

When the same property is defined at more than one level, the more specific level wins. For example, if a master slide and a layout slide both define a background, slides based on that layout use the layout background. For more information about layout slides, see [Áp dụng hoặc Thay đổi Bố cục Slide](/slides/vi/java/slide-layout/).

{{% /alert %}}

## **Truy cập Slide Masters**

In PowerPoint, you can open the Slide Master view from **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

In Aspose.Slides, use the `getMasters()` collection to access master slides:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

You can also get the master slide used by a normal slide through its layout:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Nội dung của Slide Master**

A master slide is a slide-like object. It implements [IBaseSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/), so it exposes many of the same slide properties used by normal and layout slides. Master-specific members are listed on the [IMasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/) API page.

Commonly used master slide members include:

| Thành viên | Mục đích |
| --- | --- |
| `getBackground()` | Sets the master-level slide background. |
| `getShapes()` | Stores shapes placed on the master, such as logos, picture frames, and shared text. |
| `getLayoutSlides()` | Stores the layout slides that belong to the master. |
| `getThemeManager()` | Provides access to the master theme APIs. |
| `getHeaderFooterManager()` | Controls headers, footers, dates, and slide numbers for the master and its child layouts. |
| `getDependingSlides()` | Returns normal slides that depend on the master through their layouts. |

## **Thêm Hình ảnh vào Slide Master**

When you add an image to a master slide, it appears on slides that use layouts from that master. This is useful for logos, watermarks, decorative bands, and other repeated visual elements.

The following example adds a logo to the first master slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

For more information about picture frames, see [Picture Frame](/slides/vi/java/picture-frame/).

## **Kiểm soát Hiển thị Đồ họa Master**

Use [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) to hide inherited master graphics, such as logos or decorative shapes, without deleting them from the master. Pass `false` to [Slide.setShowMasterShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) on the slide that should omit those graphics and keep it `true` on slides that should display them.

The following self-contained example creates a blue decorative band on a master and two slides that use the same blank layout. The band is visible on the first slide and hidden on the second. No input presentation or image is required.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The example uses the **Blank** layout supplied with a new presentation and removes the initial slide's own placeholders.

### **Chọn Phạm vi Cài đặt**

A normal slide uses its master through [ISlide.getLayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getLayoutSlide--) and [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Setting the property on an individual slide affects only that slide. Passing `false` to [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) hides master graphics for slides that use that shared layout, even if their own setting is `true`. To hide graphics on just one slide, change the slide property and leave the shared layout unchanged.

The setting is not supported as a visibility control on the master slide itself. On a master, [getShowMasterShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/masterslide/#getShowMasterShapes--) always returns `false`, and passing `true` to [setShowMasterShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) raises an exception. Apply it to a normal slide or a layout instead.

### **Phân biệt Đồ họa và Nền**

| Thao tác | Hiệu quả |
| --- | --- |
| Hide master graphics | Controls the visibility of inherited master shapes without deleting them or changing the slide's own shapes. |
| Change the slide background fill | Changes the background color, gradient, or image. Master graphics are separate shapes and can remain visible over that background. See [Presentation Background](/slides/vi/java/presentation-background/). |
| Delete a shape from the master | Removes the shared source shape, so it is no longer available to any slide using that master. |

## **Làm việc với Placeholder**

Placeholders are normally defined on layout slides. The master slide provides the shared style and theme that those layouts inherit, while each layout decides which placeholders are available and where they are placed.

In PowerPoint, placeholder commands are available in Slide Master view.

![Lệnh Insert Placeholder trong PowerPoint Slide Master view](slide-master_5.png)

To add new placeholders with Aspose.Slides, work with the layout slide that belongs to the master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

You can also format placeholder shapes that already exist on a master slide. The following example finds the title placeholder and applies a linear gradient fill:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Tiêu đề placeholder được định dạng kế thừa bởi các slide bình thường](slide-master_8.png)

For more placeholder and text formatting options, see [Set Prompt Text in Placeholder](/slides/vi/java/manage-placeholder/) and [Text Formatting](/slides/vi/java/text-formatting/).

## **Thay đổi Nền Slide Master**

A master background is inherited by layouts and slides that do not override it. The following example sets a solid background color for the first master slide:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

For related topics, see [Presentation Background](/slides/vi/java/presentation-background/) and [Presentation Theme](/slides/vi/java/presentation-theme/).

## **Sao chép Slide Master sang Bản trình chiếu Khác**

Use [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) to copy a master slide into another presentation. The copied master can then be used by layouts and slides in the destination presentation.

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

If you need to clone normal slides together with their master, see [Clone Slides](/slides/vi/java/clone-slides/).

## **Thêm Nhiều Slide Master**

A presentation can contain multiple master slides. This is useful when different sections require different branding, page structure, or theme settings.

![Các lệnh PowerPoint để chèn và quản lý slide master](slide-master_9.jpg)

The following example clones the default master, gives the clone a different background, creates a layout under that cloned master, and adds a new slide based on that layout:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **So sánh Slide Masters**

Master slides can be compared with the `equals` method inherited from [IBaseSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/). The comparison checks structure and static content, such as shapes, text, formatting, animations, and other slide settings. It does not compare unique identifiers, such as slide IDs, or dynamic placeholder values, such as the current date.

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

For more information, see [Compare Presentation Slides](/slides/vi/java/compare-slides/).

## **Đặt Slide Master View làm View Mặc định**

Use the `setLastView` method on [ViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/) to control the view that PowerPoint opens first. The following example opens the presentation in Slide Master view:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

For more view settings, see [Save Presentation](/slides/vi/java/save-presentation/).

## **Xóa Slide Master Không được Sử dụng**

Presentations sometimes contain master slides that are no longer used by any normal slides. Removing unused masters can reduce file size and simplify template maintenance.

Use `removeUnused` to remove unused masters from the `getMasters()` collection:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

You can also use the low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) method:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa slide master và layout slide là gì?**

A slide master defines shared design settings such as theme, background, common shapes, and text styles. A layout slide belongs to a master slide and defines a specific arrangement of placeholders. A normal slide uses a layout slide, so it inherits from both the layout and the master.

**Một bản trình chiếu có thể chứa nhiều slide master không?**

Yes. A presentation can contain several slide masters. Use multiple masters when different sections need different visual systems or branding.

**Nên thêm placeholder vào slide master hay layout slide?**

In most cases, add placeholders to layout slides. Put shared visual elements and shared formatting on the master slide, then put content placeholders on the layouts that normal slides will use.

**Có thể xóa một slide master vẫn còn được sử dụng không?**

No. A master slide that has dependent slides cannot be safely removed directly. First move those slides to layouts under another master, or use an unused-master cleanup method that removes only masters that are not in use.