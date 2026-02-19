---
title: インク
type: docs
weight: 180
url: /ja/androidjava/examples/elements/ink/
keywords:
- コード例
- インク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でインクを操作します。ストロークの描画、インポート、編集、色や幅の調整を行い、Java の例を使用して PPT、PPTX、ODP にエクスポートします。"
---
この記事では、既存のインクシェイプにアクセスし、それらを削除する例を **Aspose.Slides for Android via Java** を使用して示します。

> ❗ **注意:** インクシェイプは特殊デバイスからのユーザー入力を表します。Aspose.Slides はプログラムで新しいインクストロークを作成できませんが、既存のインクを読み取り、変更することは可能です。

## **インクにアクセス**

スライド上の最初のインクシェイプからタグを読み取ります。

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // 必要に応じて tagName を使用します。
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **インクを削除**

スライドにインクシェイプが存在する場合は削除します。

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```