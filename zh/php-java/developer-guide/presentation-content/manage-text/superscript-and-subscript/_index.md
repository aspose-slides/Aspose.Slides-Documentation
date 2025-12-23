---
title: 使用 PHP 在演示文稿中管理上标和下标
linktitle: 上标和下标
type: docs
weight: 80
url: /zh/php-java/superscript-and-subscript/
keywords:
- 上标
- 下标
- 添加上标
- 添加下标
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for PHP 中精通上标和下标，并通过专业的文本格式提升您的演示文稿，实现最大影响。"
---

## **管理上标和下标文本**
您可以在任何段落部分中添加上标和下标文本。要在 Aspose.Slides 文本框中添加上标或下标文本，必须使用 [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) 方法的 [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat) 类。

此属性返回或设置上标或下标文本（取值范围为 -100%（下标）到 100%（上标））。例如：

- 创建 Presentation 类的实例。
- 通过使用索引获取幻灯片的引用。
- 向幻灯片添加 Rectangle 类型的 IAutoShape。
- 访问与 IAutoShape 关联的 ITextFrame。
- 清除现有段落
- 创建一个用于保存上标文本的新段落对象，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的 Portion 对象
- 将该 Portion 的 Escapement 属性设置为 0 到 100 之间的值以添加上标。（0 表示无上标）
- 为 Portion 设置一些文本，然后将其添加到段落的 Portion 集合中。
- 创建一个用于保存下标文本的新段落对象，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的 Portion 对象
- 将该 Portion 的 Escapement 属性设置为 0 到 -100 之间的值以添加下标。（0 表示无下标）
- 为 Portion 设置一些文本，然后将其添加到段落的 Portion 集合中。
- 将演示文稿保存为 PPTX 文件。

下面给出了上述步骤的实现。
```php
  # 实例化一个表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 创建文本框
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # 创建用于上标文本的段落
    $superPar = new Paragraph();
    # 创建普通文本的 Portion
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # 创建上标文本的 Portion
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # 创建用于下标文本的段落
    $paragraph2 = new Paragraph();
    # 创建普通文本的 Portion
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # 创建下标文本的 Portion
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # 将段落添加到文本框
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**导出为 PDF 或其他格式时，上标和下标会被保留吗？**

是的，Aspose.Slides 在将演示文稿导出为 PDF、PPT/PPTX、图像以及其他受支持的格式时，会正确保留上标和下标的格式。所有输出文件中的专门格式均保持完整。

**上标和下标可以与其他格式样式（如粗体或斜体）组合使用吗？**

是的，Aspose.Slides 允许在同一 Portion 文本中混合多种文本样式。您可以启用粗体、斜体、下划线，并通过设置 [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) 中的相应属性同时应用上标或下标。

**上标和下标格式适用于表格、图表或 SmartArt 中的文本吗？**

是的，Aspose.Slides 支持在大多数对象（包括表格和图表元素）内进行格式设置。使用 SmartArt 时，需要访问相应的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)）及其文本容器，然后以类似方式配置 [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) 属性。