---
title: PowerPointをSWF Flashに変換
type: docs
weight: 80
url: /ja/php-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTXからSWF"
description: "PowerPoint PPT, PPTXをSWFに変換"
---

## **PPT(X)をSWFに変換**
[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスによって公開されている[Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、全体のプレゼンテーションを**SWF**ドキュメントに変換できます。以下の例は、[**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions)クラスによって提供されるオプションを使用して、プレゼンテーションを**SWF**ドキュメントに変換する方法を示しています。また、[**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions)クラスおよび[**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions)インターフェースを使用して、生成されたSWFにコメントを含めることもできます。

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # プレゼンテーションを保存
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
```php

```