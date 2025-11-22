---
title: グループ
type: docs
weight: 40
url: /ja/nodejs-java/group/
---

## **グループ シェイプの追加**
Aspose.Slides はスライド上のグループ シェイプの操作をサポートします。この機能により、開発者はよりリッチなプレゼンテーションを実現できます。Aspose.Slides for Node.js via Java はグループ シェイプの追加および取得をサポートします。追加したグループ シェイプにシェイプを配置したり、グループ シェイプの任意のプロパティにアクセスしたりすることが可能です。Aspose.Slides for Node.js via Java を使用してスライドにグループ シェイプを追加する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループ シェイプを追加します。
1. 追加したグループ シェイプにシェイプを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例はスライドにグループ シェイプを追加するものです。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // スライドのシェイプ コレクションにアクセス
    var slideShapes = sld.getShapes();
    // スライドにグループ シェイプを追加
    var groupShape = slideShapes.addGroupShape();
    // 追加したグループ シェイプ内にシェイプを追加
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // グループ シェイプのフレームを設定
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // PPTX ファイルをディスクに保存
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **AltText プロパティへのアクセス**
このトピックでは、グループ シェイプを追加し、スライド上のグループ シェイプの AltText プロパティにアクセスする手順とコード例を示します。Aspose.Slides for Node.js via Java を使用してスライド内のグループ シェイプの AltText にアクセスする手順は次のとおりです。

1. PPTX ファイルを表す [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドのシェイプ コレクションにアクセスします。
1. グループ シェイプにアクセスします。
1. [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) プロパティを呼び出します。

以下の例はグループ シェイプの代替テキストにアクセスするものです。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // スライドのシェイプ コレクションにアクセス
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // グループ シェイプにアクセス。
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // AltText プロパティにアクセス
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**ネストされたグルーピング（グループ内に別のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) には [getParentGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getparentgroup/) メソッドがあり、階層構造のサポート（あるグループが別のグループの子になること）が直接示されています。

**スライド上の他のオブジェクトに対するグループの Z オーダーをどのように制御できますか？**

[GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) の [getZOrderPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) メソッドを使用して、表示スタック内での位置を確認できます。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロック セクションは [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) を通じて公開されており、オブジェクトに対する操作を制限できます。