---
title: ノート付きPowerPointをTIFFに変換する
type: docs
weight: 100
url: /php-java/convert-powerpoint-to-tiff-with-notes/
keywords: "ノート付きPowerPointをTIFFに変換"
description: "Aspose.Slidesを使用して、ノート付きPowerPointをTIFFに変換します。"
---

## **ノートスライドビューでPPT(X)をTIFFに変換する**
[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスによって提供される[Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、ノートスライドビューのプレゼンテーション全体をTIFFに変換できます。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューのTIFF画像に更新する方法を示しています。

```php
//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("demo.pptx");
  try {
    $opts = new TiffOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # TIFFノートにプレゼンテーションを保存
    $pres->save("Tiff-Notes.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

上記のコードスニペットは、サンプルプレゼンテーションをノートスライドビューのTIFF画像に更新する方法を示しています。

|**スライドノート付きのソースプレゼンテーションビュー**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**ノートスライドビューで生成されたTIFF画像**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料PowerPointからポスターへの変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をチェックしてみると良いでしょう。

{{% /alert %}}