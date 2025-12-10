---
title: Java でのグループ プレゼンテーション シェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/java/group/
keywords:
- グループ シェイプ
- シェイプ グループ
- グループの追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint デッキでシェイプをグループ化およびグループ解除する方法を学びます—高速でステップバイステップのガイド、無料の Java コード付き。"
---

## **グループ シェイプの追加**
Aspose.Slides はスライド上のグループ シェイプの操作をサポートします。この機能により、開発者はよりリッチなプレゼンテーションを実現できます。Aspose.Slides for Java はグループ シェイプの追加と取得をサポートします。追加したグループ シェイプにシェイプを追加して内容を構成したり、グループ シェイプの任意のプロパティにアクセスしたりすることが可能です。Aspose.Slides for Java を使用してスライドにグループ シェイプを追加するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. スライドにグループ シェイプを追加します。
4. 追加したグループ シェイプにシェイプを追加します。
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加する方法を示しています。
```java
// Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // スライドのシェイプ コレクションにアクセス
    IShapeCollection slideShapes = sld.getShapes();

    // スライドにグループ シェイプを追加
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // 追加したグループ シェイプ内にシェイプを追加
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // グループ シェイプのフレームを追加
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // PPTX ファイルをディスクに保存
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **AltText プロパティのアクセス**
このトピックでは、グループ シェイプを追加し、スライド上のグループ シェイプの AltText プロパティにアクセスするための簡単な手順とコード例を示します。Aspose.Slides for Java を使用してスライド内のグループ シェイプの AltText にアクセスするには、次の手順を実行します。

1. PPTX ファイルを表す [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. スライドのシェイプ コレクションにアクセスします。
4. グループ シェイプにアクセスします。
5. [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--)プロパティにアクセスします。

以下の例は、グループ シェイプの代替テキストにアクセスする方法を示しています。
```java
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation("AltText.pptx");
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // スライドのシェイプ コレクションにアクセス
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // グループ シェイプにアクセス。
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

**ネストされたグループ化（グループ内のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) には [getParentGroup](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getParentGroup--) メソッドがあり、階層サポート（あるグループが別のグループの子になること）が直接示されています。

**スライド上の他のオブジェクトに対するグループの Z 順序をどのように制御しますか？**

[GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) の [getZOrderPosition](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) メソッドを使用して、表示スタック内の位置を確認します。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロック セクションは [GroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/#getGroupShapeLock--) を通じて公開されており、オブジェクトに対する操作を制限できます。