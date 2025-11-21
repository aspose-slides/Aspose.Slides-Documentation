---
title: 在演示文稿中访问幻灯片
type: docs
weight: 20
url: /zh/nodejs-java/access-slide-in-presentation/
keywords: "访问 PowerPoint 演示文稿, 访问幻灯片, 编辑幻灯片属性, 更改幻灯片位置, 设置幻灯片编号, 索引, ID, 位置 Java, Aspose.Slides"
description: "通过索引、ID 或位置在 JavaScript 中访问 PowerPoint 幻灯片。编辑幻灯片属性"
---

Aspose.Slides 允许您以两种方式访问幻灯片：按索引和按 ID。

## **按索引访问幻灯片**

演示文稿中的所有幻灯片都根据幻灯片位置按数字顺序排列，起始索引为 0。第一张幻灯片通过索引 0 访问；第二张幻灯片通过索引 1 访问；依此类推。

表示演示文稿文件的 Presentation 类将所有幻灯片公开为一个 [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/)（[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) 对象的集合）。下面的 JavaScript 代码展示了如何通过索引访问幻灯片：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // 使用幻灯片索引访问幻灯片
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **按 ID 访问幻灯片**

演示文稿中的每张幻灯片都有一个唯一的 ID。您可以使用由 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类公开的 [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) 方法来定位该 ID。下面的 JavaScript 代码展示了如何提供有效的幻灯片 ID 并通过 [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) 方法访问该幻灯片：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // 获取幻灯片 ID
    var id = pres.getSlides().get_Item(0).getSlideId();
    // 通过 ID 访问幻灯片
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **更改幻灯片位置**

Aspose.Slides 允许您更改幻灯片的位置。例如，您可以指定将第一张幻灯片变为第二张幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取要更改位置的幻灯片引用
1. 通过 [setSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#setSlideNumber-int-) 属性为幻灯片设置新位置。
1. 保存已修改的演示文稿。

下面的 JavaScript 代码演示了将位置为 1 的幻灯片移动到位置 2 的操作：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 获取将要更改位置的幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 为幻灯片设置新的位置
    sld.setSlideNumber(2);
    // 保存修改后的演示文稿
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


第一张幻灯片变成了第二张；第二张幻灯片变成了第一张。当您更改幻灯片的位置时，其他幻灯片会自动调整。

## **设置幻灯片编号**

使用由 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类公开的 [setFirstSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) 属性，您可以为演示文稿中的第一张幻灯片指定一个新编号。此操作会导致其他幻灯片编号重新计算。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 获取幻灯片编号。
1. 设置幻灯片编号。
1. 保存已修改的演示文稿。

下面的 JavaScript 代码演示了将第一张幻灯片的编号设置为 10 的操作：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // 获取幻灯片编号
    var firstSlideNumber = pres.getFirstSlideNumber();
    // 设置幻灯片编号
    pres.setFirstSlideNumber(10);
    // 保存修改后的演示文稿
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


如果您想跳过第一张幻灯片，可以从第二张幻灯片开始编号（并隐藏第一张幻灯片的编号），方法如下：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // 为演示文稿的第一张幻灯片设置编号
    presentation.setFirstSlideNumber(0);
    // 为所有幻灯片显示幻灯片编号
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // 隐藏第一张幻灯片的幻灯片编号
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // 保存修改后的演示文稿
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **常见问题**

**用户看到的幻灯片编号是否与集合的零基索引相匹配？**

幻灯片上显示的编号可以从任意值（例如 10）开始，并不一定要与索引匹配；两者的关系由演示文稿的 [first slide number](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) 设置控制。

**隐藏的幻灯片会影响索引吗？**

会。隐藏的幻灯片仍然保留在集合中，并计入索引；“隐藏”指的是显示状态，而不是其在集合中的位置。

**在添加或删除其他幻灯片时，幻灯片的索引会改变吗？**

会。索引始终反映当前的幻灯片顺序，并在插入、删除和移动操作后重新计算。