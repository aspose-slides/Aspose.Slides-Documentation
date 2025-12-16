---
title: Android のグループ プレゼンテーション シェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/androidjava/group/
keywords:
- グループシェイプ
- シェイプグループ
- グループの追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint デッキのシェイプをグループ化およびグループ解除する方法を学びます。高速でステップバイステップのガイドと無料の Java コード付き。"
---

## **グループシェイプの追加**
Aspose.Slides はスライド上でグループシェイプを操作することをサポートしています。この機能により、開発者はよりリッチなプレゼンテーションを実現できます。Aspose.Slides for Android via Java は、グループシェイプの追加やアクセスをサポートします。追加したグループシェイプにシェイプを追加して内容を埋め込んだり、グループシェイプの任意のプロパティにアクセスしたりすることが可能です。Aspose.Slides for Android via Java を使用してスライドにグループシェイプを追加するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループシェイプを追加します。
1. 追加したグループシェイプにシェイプを追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループシェイプを追加する方法を示しています。
```java
// Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // スライドのシェイプコレクションにアクセス
    IShapeCollection slideShapes = sld.getShapes();

    // スライドにグループシェイプを追加
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // 追加したグループシェイプ内にシェイプを追加
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // グループシェイプのフレームを追加
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // PPTX ファイルを書き出し
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **AltText プロパティへのアクセス**
このトピックでは、グループシェイプを追加し、スライド上のグループシェイプの AltText プロパティにアクセスする手順とコード例を示します。Aspose.Slides for Android via Java を使用してスライド内のグループシェイプの AltText にアクセスするには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します（PPTX ファイルを表します）。
1. インデックスを使用してスライドの参照を取得します。
1. スライドのシェイプコレクションにアクセスします。
1. グループシェイプにアクセスします。
1. [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) プロパティにアクセスします。

以下の例は、グループシェイプの代替テキストにアクセスする方法を示しています。
```java
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation("AltText.pptx");
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // スライドのシェイプコレクションにアクセス
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // グループシェイプにアクセス
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // AltText プロパティにアクセス
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**ネストされたグルーピング（グループ内のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/) には [getParentGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getParentGroup--) メソッドがあり、階層構造のサポートを直接示しています（グループは別のグループの子になることができます）。

**スライド上の他のオブジェクトに対するグループの Z オーダーはどのように制御しますか？**

[GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/) の [getZOrderPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) メソッドを使用して、表示スタック内での位置を確認します。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロックセクションは [getGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) で公開されており、オブジェクトに対する操作を制限できます。