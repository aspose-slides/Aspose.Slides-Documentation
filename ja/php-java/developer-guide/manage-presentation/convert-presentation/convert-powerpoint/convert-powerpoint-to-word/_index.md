---
title: PowerPointをWordに変換
type: docs
weight: 110
url: /ja/php-java/convert-powerpoint-to-word/
keywords: "PowerPointを変換, PPT, PPTX, プレゼンテーション, Word, DOCX, DOC, PPTXをDOCXに, PPTをDOCに, PPTXをDOCに, PPTをDOCXに, Java, java, Aspose.Slides"
description: "PowerPointプレゼンテーションをWordに変換"
---

プレゼンテーション（PPTまたはPPTX）からテキストコンテンツや情報を新しい方法で使用する予定がある場合、そのプレゼンテーションをWord（DOCまたはDOCX）に変換することで利益を得ることができます。

* Microsoft PowerPointと比較して、Microsoft Wordアプリはコンテンツのためのツールや機能が充実しています。
* Wordの編集機能に加えて、強化されたコラボレーション、印刷、共有機能の恩恵を受けることもできます。

{{% alert color="primary" %}}

私たちの[**プレゼンテーションをWordに変換するオンラインコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-word)を試してみると、スライドからのテキストコンテンツを使用することで得られるメリットを確認できます。

{{% /alert %}}

## **Aspose.SlidesとAspose.Words**

PowerPointファイル（PPTXまたはPPT）をWord（DOCXまたはDOCX）に変換するには、[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/)と[Aspose.Words for Java](https://products.aspose.com/words/php-java/)の両方が必要です。

スタンドアロンAPIとして、Java用の[Aspose.Slides](https://products.aspose.app/slides)は、プレゼンテーションからテキストを抽出するための機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/php-java/)は、Microsoft Wordを利用せずにファイルの生成、修正、変換、レンダリング、印刷を行い、文書に関する他の作業を実行できる高度な文書処理APIです。

## **PowerPointをWordに変換**

1. [Aspose.Slides for PHP via Java](https://downloads.aspose.com/slides/java)と[Aspose.Words for Java](https://downloads.aspose.com/words/java)ライブラリをダウンロードします。
2. *aspose-slides-x.x-jdk16.jar*と*aspose-words-x.x-jdk16.jar*をCLASSPATHに追加します。
3. 次のコードスニペットを使用してPowerPointをWordに変換します：

```php
  $pres = new Presentation($inputPres);
  try {
    $doc = new Document();
    $builder = new DocumentBuilder($doc);
    foreach($pres->getSlides() as $slide) {
      # スライド画像を生成して挿入
      $bitmap = $slide->getThumbnail(1, 1);
      $builder->insertImage($bitmap);
      # スライドのテキストを挿入
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