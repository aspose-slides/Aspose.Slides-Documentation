---
title: 将 PowerPoint 转换为 Word
type: docs
weight: 110
url: /php-java/convert-powerpoint-to-word/
keywords: "将 PowerPoint, PPT, PPTX, 演示文稿, Word, DOCX, DOC, PPTX 转换为 DOCX, PPT 转换为 DOC, PPTX 转换为 DOC, PPT 转换为 DOCX, Java, java, Aspose.Slides"
description: "将 PowerPoint 演示文稿转换为 Word "
---

如果您计划以新的方式使用演示文稿（PPT 或 PPTX）中的文本内容或信息，您可能会受益于将演示文稿转换为 Word（DOC 或 DOCX）。 

* 与 Microsoft PowerPoint 相比，Microsoft Word 应用程序在内容工具或功能方面更为强大。 
* 除了 Word 中的编辑功能外，您还可以受益于增强的协作、打印和共享功能。 

{{% alert color="primary" %}} 

您可能想尝试我们的 [**在线演示文稿转 Word 转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，看看您从幻灯片的文本内容中可以获得什么。 

{{% /alert %}} 

## **Aspose.Slides 和 Aspose.Words**

要将 PowerPoint 文件（PPTX 或 PPT）转换为 Word（DOCX 或 DOC），您需要同时使用 [Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) 和 [Aspose.Words for Java](https://products.aspose.com/words/php-java/)。

作为独立 API，[Aspose.Slides](https://products.aspose.app/slides) for java 提供的功能允许您从演示文稿中提取文本。 

[Aspose.Words](https://docs.aspose.com/words/php-java/) 是一个高级文档处理 API，允许应用程序生成、修改、转换、渲染、打印文件，并在不使用 Microsoft Word 的情况下执行其他文档任务。

## **将 PowerPoint 转换为 Word**

1. 下载 [Aspose.Slides for PHP via Java](https://downloads.aspose.com/slides/java) 和 [Aspose.Words for Java](https://downloads.aspose.com/words/java) 库。
2. 将 *aspose-slides-x.x-jdk16.jar* 和 *aspose-words-x.x-jdk16.jar* 添加到您的 CLASSPATH 中。
3. 使用以下代码片段将 PowerPoint 转换为 Word：

```php
  $pres = new Presentation($inputPres);
  try {
    $doc = new Document();
    $builder = new DocumentBuilder($doc);
    foreach($pres->getSlides() as $slide) {
      # 生成并插入幻灯片图像
      $bitmap = $slide->getThumbnail(1, 1);
      $builder->insertImage($bitmap);
      # 插入幻灯片文本
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $builder->writeln($shape->getTextFrame()->getText());
        }
      }
      $builder->insertBreak(BreakType::PAGE_BREAK);
    }
    $doc->save($outputDoc);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```