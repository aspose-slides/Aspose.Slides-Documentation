---
title: Javaを使用してPowerPointプレゼンテーションを作成する
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /java/create-presentation/
keywords: ppt java 作成, ppt プレゼンテーション 作成, pptx java 作成
description: Javaを使用してPPT、PPTXなどのPowerPointプレゼンテーションをゼロから作成する方法を学びます。
---

## **PowerPointプレゼンテーションの作成**
プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

1. Presentationクラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shapesオブジェクトが公開するaddAutoShapeメソッドを使用して、ラインタイプのAutoShapeを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにラインを追加しています。

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // ラインタイプのオートシェイプを追加します
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```