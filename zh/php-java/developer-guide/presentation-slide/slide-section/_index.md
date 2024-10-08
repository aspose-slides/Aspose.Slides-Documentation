---
title: 幻灯片章节
type: docs
weight: 90
url: /php-java/slide-section/
---

使用 Aspose.Slides for PHP via Java，您可以将 PowerPoint 演示文稿组织为章节。您可以创建包含特定幻灯片的章节。

您可能希望在以下情况下创建章节并用它们来组织或划分演示文稿中的幻灯片为逻辑部分：

- 当您与其他人或团队一起处理大型演示文稿时——并且需要将某些幻灯片分配给同事或某些团队成员。
- 当您处理的演示文稿包含许多幻灯片——并且您在一次性管理或编辑其内容时遇到困难。

理想情况下，您应该创建一个包含相似幻灯片的章节——这些幻灯片有某种共同之处，或者可以基于某种规则存在于一个组中——并给这个章节一个描述内部幻灯片的名称。

## 在演示文稿中创建章节

要添加一个包含幻灯片的章节，Aspose.Slides for PHP via Java 提供了 [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) 方法，允许您指定要创建的章节的名称以及章节开始的幻灯片。

以下示例代码演示了如何在演示文稿中创建一个章节：

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("章节 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("章节 2", $newSlide3);// section1 将在 newSlide2 结束，在它之后 section2 开始

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("最后一个空章节");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 更改章节名称

在 PowerPoint 演示文稿中创建章节后，您可能会决定更改其名称。

以下示例代码演示了如何使用 Aspose.Slides 更改演示文稿中章节的名称：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("我的章节");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```