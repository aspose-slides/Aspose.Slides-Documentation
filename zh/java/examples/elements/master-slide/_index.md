---
title: 母版幻灯片
type: docs
weight: 30
url: /zh/java/examples/elements/master-slide/
keywords:
- 代码示例
- 母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 的母版幻灯片示例：在 PPT、PPTX 和 ODP 中创建、编辑和设置母版、占位符和主题，提供清晰的 Java 代码。"
---
母版幻灯片构成 PowerPoint 幻灯片继承层次结构的顶层。**母版幻灯片**定义公共设计元素，例如背景、徽标和文本格式。**布局幻灯片**继承自母版幻灯片，**普通幻灯片**继承自布局幻灯片。

本文演示如何使用 Aspose.Slides for Java 创建、修改和管理母版幻灯片。

## **添加母版幻灯片**

本示例展示如何通过克隆默认母版创建新的母版幻灯片。随后通过布局继承将公司名称横幅添加到所有幻灯片。

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // 克隆默认母版幻灯片。
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // 在母版幻灯片顶部添加公司名称横幅。
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // 将新母版幻灯片分配给布局幻灯片。
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // 将布局幻灯片分配给演示文稿中的第一张幻灯片。
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意 1:** 母版幻灯片提供了一种在所有幻灯片上应用一致品牌或共享设计元素的方式。对母版所做的任何更改会自动反映在依赖的布局幻灯片和普通幻灯片上。

> 💡 **注意 2:** 添加到母版幻灯片的任何形状或格式都会被布局幻灯片继承，进而被使用这些布局的所有普通幻灯片继承。  
> 下图展示了在母版幻灯片上添加的文本框如何自动呈现在最终幻灯片上。

![母版继承示例](master-slide-banner.png)

## **访问母版幻灯片**

您可以使用演示文稿的母版集合访问母版幻灯片。以下示例演示如何检索并使用它们：

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // 更改背景类型。
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **删除母版幻灯片**

可以通过索引或引用删除母版幻灯片。

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // 按索引移除母版幻灯片。
        presentation.getMasters().removeAt(0);

        // 按引用移除母版幻灯片。
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **删除未使用的母版幻灯片**

某些演示文稿包含未使用的母版幻灯片。删除这些幻灯片可以帮助减小文件大小。

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // 删除所有未使用的母版幻灯片（即使它们标记为 Preserve）。
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```