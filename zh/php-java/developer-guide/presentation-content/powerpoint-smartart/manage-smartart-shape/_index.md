---
title: 使用 PHP 管理演示文稿中的 SmartArt 图形
linktitle: SmartArt 图形
type: docs
weight: 20
url: /zh/php-java/manage-smartart-shape/
keywords:
- SmartArt 对象
- SmartArt 图形
- SmartArt 样式
- SmartArt 颜色
- 创建 SmartArt
- 添加 SmartArt
- 编辑 SmartArt
- 更改 SmartArt
- 访问 SmartArt
- SmartArt 布局类型
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中自动化 PowerPoint SmartArt 的创建、编辑和样式设置，提供简洁的代码示例和注重性能的指导。"
---

## **创建 SmartArt 形状**
Aspose.Slides for PHP via Java 提供了用于创建 SmartArt 形状的 API。要在幻灯片中创建 SmartArt 形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. [添加 SmartArt 形状](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSmartArt) 并设置其 [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType)。  
1. 将修改后的演示文稿保存为 PPTX 文件。  
```php
  # 实例化 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加 Smart Art 形状
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # 保存演示文稿
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**图：已添加到幻灯片的 SmartArt 形状**|

## **访问幻灯片上的 SmartArt 形状**
以下代码用于访问已在演示文稿幻灯片中添加的 SmartArt 形状。在示例代码中，我们将遍历幻灯片中的每个形状并检查它是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 形状。如果形状是 SmartArt 类型，则将其强制转换为 [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 实例。  
```php
  # 加载所需的演示文稿
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 遍历第一张幻灯片中的每个形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **访问具有特定布局类型的 SmartArt 形状**
以下示例代码可帮助访问具有特定 LayoutType 的 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 形状。请注意，SmartArt 的 LayoutType 为只读，且仅在添加 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 形状时设置，无法更改。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
1. 使用索引获取第一张幻灯片的引用。  
1. 遍历第一张幻灯片中的所有形状。  
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 类型，如果是，则将选定形状强制转换为 SmartArt。  
1. 检查具有特定 LayoutType 的 SmartArt 形状，并在之后执行所需的操作。  
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 遍历第一张幻灯片中的每个形状
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArtEx
        $smart = $shape;
        # 检查 SmartArt 布局
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **更改 SmartArt 形状样式**
本示例将演示如何更改任意 SmartArt 形状的快速样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
1. 使用索引获取第一张幻灯片的引用。  
1. 遍历第一张幻灯片中的所有形状。  
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 类型，如果是，则将选定形状强制转换为 SmartArt。  
1. 查找具有特定 Style 的 SmartArt 形状。  
1. 为该 SmartArt 形状设置新的 Style。  
1. 保存演示文稿。  
```php
  # 实例化 Presentation 类
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍历第一张幻灯片中的每个形状
    foreach($slide->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArtEx
        $smart = $shape;
        # 检查 SmartArt 样式
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # 更改 SmartArt 样式
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # 保存演示文稿
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**图：已更改 Style 的 SmartArt 形状**|

## **更改 SmartArt 形状颜色样式**
本示例将演示如何更改任意 SmartArt 形状的颜色样式。以下示例代码将访问具有特定颜色 Style 的 SmartArt 形状并更改其样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
1. 使用索引获取第一张幻灯片的引用。  
1. 遍历第一张幻灯片中的所有形状。  
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) 类型，如果是，则将选定形状强制转换为 SmartArt。  
1. 查找具有特定颜色 Style 的 SmartArt 形状。  
1. 为该 SmartArt 形状设置新的颜色 Style。  
1. 保存演示文稿。  
```php
  # 实例化 Presentation 类
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍历第一张幻灯片中的每个形状
    foreach($slide->getShapes() as $shape) {
      # 检查形状是否为 SmartArt 类型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 将形状强制转换为 SmartArtEx
        $smart = $shape;
        # 检查 SmartArt 颜色类型
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # 更改 SmartArt 颜色类型
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # 保存演示文稿
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**图：已更改颜色 Style 的 SmartArt 形状**|

## **FAQ**

**我可以将 SmartArt 作为单个对象进行动画处理吗？**

是的。SmartArt 是一种形状，您可以通过动画 API（进入、退出、强调、运动路径）对其应用 [标准动画](/slides/zh/php-java/powerpoint-animation/)，就像对其他形状一样。

**如果不知道内部 ID，如何在幻灯片上找到特定的 SmartArt？**

设置并使用替代文本（AltText），然后通过该值搜索形状——这是定位目标形状的推荐方式。

**我可以将 SmartArt 与其他形状分组吗？**

是的。您可以将 SmartArt 与其他形状（图片、表格等）分组，然后 [操作该组](/slides/zh/php-java/group/)。

**我如何获取特定 SmartArt 的图像（例如，用于预览或报告）？**

导出形状的缩略图/图像；库可以将单个形状 [渲染为光栅文件](/slides/zh/php-java/create-shape-thumbnails/)（PNG/JPG/TIFF）。

**将整个演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

是的。渲染引擎针对 [PDF 导出](/slides/zh/php-java/convert-powerpoint-to-pdf/) 提供高保真度，并提供多种质量和兼容性选项。