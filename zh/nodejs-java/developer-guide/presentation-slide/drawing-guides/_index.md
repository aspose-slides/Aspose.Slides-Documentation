---
title: 在 JavaScript 中管理演示文稿的绘图参考线
linktitle: 绘图参考线
type: docs
weight: 85
url: /zh/nodejs-java/drawing-guides/
keywords:
- 绘图参考线
- 水平参考线
- 垂直参考线
- 对齐参考线
- 幻灯片视图
- 母版幻灯片
- 布局幻灯片
- 备注母版
- 讲义母版
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 演示文稿中添加、访问和清除水平和垂直绘图参考线。"
---
## **概述**

绘图参考线是可调节的水平和垂直线，可帮助用户在 PowerPoint 中编辑演示文稿时始终一致地对齐形状。它们在应用程序生成演示文稿后需要手动进行细化时尤其有用：应用程序可以保存相同的对齐辅助，作者在添加或移动内容时应遵循这些辅助。

绘图参考线是编辑辅助，而不是幻灯片内容。它们不会出现在幻灯片放映或渲染的输出中。Aspose.Slides for Node.js via Java 通过[DrawingGuidesCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguidescollection/)类公开它们。参考线由[DrawingGuide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguide/)表示，具有方向、位置和颜色。

位置以点为单位，从相关幻灯片或母版的左上角测量。垂直参考线使用水平坐标，通常在零到幻灯片宽度之间。水平参考线使用垂直坐标，通常在零到幻灯片高度之间。

## **向幻灯片视图添加参考线**

使用[CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides)来管理在编辑普通幻灯片时显示的参考线。调用[DrawingGuidesCollection.add](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguidescollection/#add)并传入一个[Orientation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/orientation/)值以及以点为单位的位置。

下面的示例在幻灯片中心右侧添加了一条垂直参考线，并在其下方添加了一条水平参考线：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **访问参考线**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguidescollection/#getCount)和[DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguidescollection/#get_Item)方法提供对现有参考线的访问。[DrawingGuide.getOrientation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguide/#getOrientation)、[DrawingGuide.getPosition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguide/#getPosition)和[DrawingGuide.getColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguide/#getColor)方法返回的值也可以通过相应的 setter 方法进行更改。

下面的示例读取上面创建的演示文稿中的幻灯片视图参考线：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **向母版和布局幻灯片添加参考线**

幻灯片母版及其每个布局幻灯片都可以拥有各自的绘图参考线集合。对母版幻灯片使用[MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/#getDrawingGuides)，对布局幻灯片使用[LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides)。

下面的示例在第一个母版幻灯片上添加了一条垂直参考线，在第一个布局幻灯片上添加了一条水平参考线：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **向备注和讲义母版添加参考线**

备注母版和讲义母版也支持绘图参考线。使用[MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides)和[MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides)访问它们的集合。如果演示文稿未包含这些母版，`MasterNotesSlideManager.setDefaultMasterNotesSlide`或`MasterHandoutSlideManager.setDefaultMasterHandoutSlide`会创建默认母版并返回它。

下面的示例在备注母版上添加了一条水平参考线，在讲义母版上添加了一条垂直参考线：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **清除绘图参考线**

调用[DrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguidescollection/#clear)可删除特定集合中的所有参考线。清除一个集合不会影响存储在其他范围中的参考线。

下面的示例在不创建缺失母版的情况下，清除幻灯片视图参考线以及母版、布局幻灯片、备注母版和讲义母版上的所有参考线：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**绘图参考线会出现在幻灯片放映或导出的图像中吗？**

不会。绘图参考线是用于编辑的对齐辅助，并不会作为演示文稿内容进行渲染。

**可以直接向单个普通幻灯片添加绘图参考线吗？**

普通幻灯片的编辑参考线存储在演示文稿的幻灯片视图属性中。母版幻灯片、布局幻灯片、备注母版和讲义母版各自拥有独立的参考线集合。

**参考线位置使用什么单位？**

位置以点为单位指定，72 点等于一英寸。垂直位置相对于左边缘测量，水平位置相对于顶部边缘测量。

**清除绘图参考线会删除形状或更改幻灯片内容吗？**

不会。[DrawingGuidesCollection.clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/drawingguidescollection/#clear)方法仅删除所选集合中的参考线，形状和其他幻灯片内容保持不变。