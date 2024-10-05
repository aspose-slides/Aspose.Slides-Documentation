---
title: ノート付きPowerPointをTIFFに変換
type: docs
weight: 100
url: /androidjava/convert-powerpoint-to-tiff-with-notes/
keywords: "ノート付きPowerPointをTIFFに変換"
description: "Aspose.Slidesを使用してノート付きPowerPointをTIFFに変換します。"
---

## **ノートスライドビューのPPT(X)をTIFFに変換**
[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスによって公開された[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用して、ノートスライドビューのプレゼンテーション全体をTIFFに変換できます。以下のコードスニペットは、ノートスライドビューでTIFF画像にサンプルプレゼンテーションを更新します。

```java
//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //ノートのTIFFにプレゼンテーションを保存
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

上記のコードスニペットは、ノートスライドビューでTIFF画像にサンプルプレゼンテーションを更新します。

|**スライドノート付きのソースプレゼンテーションビュー**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**ノートスライドビューで生成されたTIFF画像**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料PowerPointからポスターへのコンバーター](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をチェックしてみてください。

{{% /alert %}}