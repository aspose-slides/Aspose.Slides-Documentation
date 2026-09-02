---
title: 在 Java 中管理演示文稿的绘图参考线
linktitle: 绘图参考线
type: docs
weight: 85
url: /zh/java/drawing-guides/
keywords:
- 绘图参考线
- 水平参考线
- 垂直参考线
- 对齐参考线
- 幻灯片视图
- 母版幻灯片
- 布局幻灯片
- 笔记母版
- 讲义母版
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 演示文稿中添加、访问和清除水平和垂直绘图参考线。"
---
## **概述**

绘图参考线是可调节的水平和垂直线，可帮助用户在 PowerPoint 中编辑演示文稿时始终如一地对齐形状。它们在应用程序生成演示文稿后需要手动细化时尤其有用：应用程序可以保存相同的对齐辅助，作者在添加或移动内容时应遵循这些辅助。

绘图参考线是编辑辅助工具，而非幻灯片内容。它们不会出现在幻灯片放映或渲染输出中。Aspose.Slides for Java 通过 [IDrawingGuidesCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguidescollection/) 接口公开它们。参考线由 [IDrawingGuide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguide/) 表示，具有方向、位置和颜色。

位置以点为单位，从相关幻灯片或母版的左上角测量。垂直参考线使用水平坐标，通常在 0 到幻灯片宽度之间。水平参考线使用垂直坐标，通常在 0 到幻灯片高度之间。

## **向幻灯片视图添加参考线**

使用 [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) 来管理编辑普通幻灯片时显示的参考线。调用 [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) 并提供一个 [Orientation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/orientation/) 值和以点为单位的位置。

以下示例在幻灯片中心右侧添加一条垂直参考线，并在其下方添加一条水平参考线：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **访问绘图参考线**

[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguidescollection/#getCount--) 和 [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) 方法提供对现有参考线的访问。[IDrawingGuide.getOrientation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguide/#getOrientation--)、[IDrawingGuide.getPosition](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguide/#getPosition--) 和 [IDrawingGuide.getColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguide/#getColor--) 方法返回可通过相应的 setter 方法更改的值。

以下示例读取上述创建的演示文稿中的幻灯片视图参考线：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **向母版和布局幻灯片添加参考线**

幻灯片母版及其每个布局幻灯片都可以拥有各自的绘图参考线集合。对母版幻灯片使用 [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslide/#getDrawingGuides--)，对布局幻灯片使用 [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--)。

以下示例向第一张母版幻灯片添加一条垂直参考线，并向第一张布局幻灯片添加一条水平参考线：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **向笔记母版和讲义母版添加参考线**

笔记母版和讲义母版也支持绘图参考线。使用 [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) 和 [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) 访问它们的集合。如果演示文稿不包含这些母版之一，则 [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) 或 [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) 会创建默认母版并返回它。

以下示例向笔记母版添加一条水平参考线，并向讲义母版添加一条垂直参考线：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **清除绘图参考线**

调用 [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguidescollection/#clear--) 可从特定集合中移除所有参考线。清除一个集合不会影响存储在其他范围中的参考线。

以下示例在不创建缺失母版的情况下，清除幻灯片视图参考线以及幻灯片母版、布局幻灯片、笔记母版和讲义母版上的所有参考线：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**绘图参考线会出现在幻灯片放映或导出图像中吗？**

不会。绘图参考线是用于编辑的对齐辅助线，不会作为演示内容进行渲染。

**可以直接向单个普通幻灯片添加绘图参考线吗？**

普通幻灯片的编辑参考线存储在演示文稿的幻灯片视图属性中。幻灯片母版、布局幻灯片、笔记母版和讲义母版各自拥有独立的参考线集合。

**参考线位置使用什么单位？**

位置采用点（point）为单位，1 英寸等于 72 点。垂直位置从左边缘测量，水平位置从顶部测量。

**清除绘图参考线会删除形状或更改幻灯片内容吗？**

不会。 [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idrawingguidescollection/#clear--) 方法仅移除所选集合中的参考线。形状和其他幻灯片内容保持不变。