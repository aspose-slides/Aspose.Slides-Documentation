---
title: 在演示文稿中访问幻灯片
type: docs
weight: 20
url: /zh/androidjava/access-slide-in-presentation/
keywords: "访问 PowerPoint 演示文稿，访问幻灯片，编辑幻灯片属性，改变幻灯片位置，设置幻灯片编号，索引，ID，位置 Java，Aspose.Slides"
description: "通过索引、ID 或位置在 Java 中访问 PowerPoint 幻灯片。编辑幻灯片属性"
---

Aspose.Slides 允许您通过两种方式访问幻灯片：通过索引和通过 ID。

## **通过索引访问幻灯片**

演示文稿中的所有幻灯片是根据幻灯片位置从 0 开始按数字排列的。第一个幻灯片可以通过索引 0 访问；第二个幻灯片通过索引 1 访问；依此类推。

表示演示文稿文件的 Presentation 类将所有幻灯片暴露为 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) 集合（[ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) 对象的集合）。下面的 Java 代码展示了如何通过索引访问幻灯片：

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("demo.pptx");
try {
    // 使用幻灯片索引访问幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **通过 ID 访问幻灯片**

演示文稿中的每个幻灯片都有一个唯一的 ID 与之相关联。您可以使用 [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) 方法（由 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类暴露）来定位该 ID。下面的 Java 代码展示了如何提供有效的幻灯片 ID 并通过 [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) 方法访问该幻灯片：

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("demo.pptx");
try {
    // 获取幻灯片 ID
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // 通过其 ID 访问幻灯片
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **改变幻灯片位置**

Aspose.Slides 允许您改变幻灯片的位置。例如，您可以指定第一张幻灯片应该变成第二张幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过其索引获取要改变位置的幻灯片的引用
3. 通过 [setSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#setSlideNumber-int-) 属性为幻灯片设置一个新位置。
4. 保存修改后的演示文稿。

下面的 Java 代码演示了将位置为 1 的幻灯片移动到位置 2 的操作：

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 获取将要改变位置的幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 为幻灯片设置新位置
    sld.setSlideNumber(2);
    
    // 保存修改后的演示文稿
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

第一张幻灯片变成了第二张；第二张幻灯片变成了第一张。当您改变幻灯片的位置时，其他幻灯片会自动调整。

## **设置幻灯片编号**

使用 [setFirstSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 属性（由 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类暴露），您可以为演示文稿中的第一张幻灯片指定一个新编号。此操作会导致其他幻灯片编号被重新计算。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 获取幻灯片编号。
3. 设置幻灯片编号。
4. 保存修改后的演示文稿。

下面的 Java 代码演示了将第一张幻灯片编号设置为 10 的操作：

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // 获取幻灯片编号
    int firstSlideNumber = pres.getFirstSlideNumber();

    // 设置幻灯片编号
    pres.setFirstSlideNumber(10);
	
    // 保存修改后的演示文稿
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

如果您希望跳过第一张幻灯片，可以这样从第二张幻灯片开始编号（并隐藏第一张幻灯片的编号）：

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // 设置演示文稿第一张幻灯片的编号
    presentation.setFirstSlideNumber(0);

    // 显示所有幻灯片的幻灯片编号
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // 隐藏第一张幻灯片的幻灯片编号
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // 保存修改后的演示文稿
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```