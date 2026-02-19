---
title: インク
type: docs
weight: 180
url: /ja/java/examples/elements/ink/
keywords:
- コード例
- インク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でインクを操作します：ストロークの描画、インポート、編集、色と幅の調整、そして Java のサンプルを使用して PPT、PPTX、ODP へエクスポートします。"
---
このガイドでは、既存のインク形状にアクセスし、それらを削除する例を **Aspose.Slides for Java** を使用して示します。

> ❗ **注意:** インク形状は特殊デバイスからのユーザー入力を表します。Aspose.Slides はプログラムで新しいインクストロークを作成できませんが、既存のインクを読み取ったり変更したりできます。

## **インクにアクセス**

スライド上の最初のインク形状からタグを読み取ります。

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

## **インクの削除**

スライドにインク形状が存在する場合、それを削除します。

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