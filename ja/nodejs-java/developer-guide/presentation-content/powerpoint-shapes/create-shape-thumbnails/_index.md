---
title: JavaScriptでプレゼンテーションシェイプのサムネイルを作成
linktitle: シェイプ サムネイル
type: docs
weight: 70
url: /ja/nodejs-java/create-shape-thumbnails/
keywords:
- シェイプ サムネイル
- シェイプ 画像
- シェイプ をレンダリング
- シェイプ レンダリング
- 視覚的境界
- シェイプ 境界
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して PowerPoint スライドから高品質なシェイプ サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートできます。"
---
## **イントロダクション**

Aspose.Slides は、各ページがスライドであるプレゼンテーション ファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者が形状の画像を画像ビューアで個別に確認したい場合があります。そのようなケースでは、Aspose.Slides がスライド形状のサムネイル画像を生成するのに役立ちます。この機能の使用方法は本記事で説明します。

本記事では、スライドのサムネイルをさまざまな方法で生成する手順を説明します。

- スライド内のシェイプ サムネイルを生成する。
- ユーザー定義のサイズでスライド シェイプのサムネイルを生成する。
- シェイプの外観の境界内でサムネイルを生成する。

## **スライドからシェイプ サムネイルを生成**

Aspose.Slides for Node.js via Java を使用して任意のスライドからシェイプ サムネイルを生成するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドのデフォルトスケールで[シェイプのサムネイル画像を取得](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Shape#getImage--)します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプル コードは、スライドからシェイプ サムネイルを生成する方法を示しています。

```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // 画像を PNG 形式でディスクに保存
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ユーザー定義スケーリング ファクターでシェイプ サムネイルを生成**

Aspose.Slides for Node.js via Java を使用してスライドのシェイプ サムネイルを生成するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. ユーザー定義の寸法で参照されたスライドの[シェイプのサムネイル画像を取得](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Shape#getImage-int-float-float-)します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプル コードは、定義されたスケーリング ファクターに基づいてシェイプ サムネイルを生成する方法を示しています。

```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // 画像を PNG 形式でディスクに保存
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **境界のシェイプ サムネイルを生成**

このシェイプ サムネイル作成方法により、開発者はシェイプの外観の境界内でサムネイルを生成できます。すべてのシェイプ効果が考慮されます。生成されたシェイプ サムネイルはスライドの境界で制限されます。シェイプの外観の境界内でスライド シェイプのサムネイルを生成するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドのシェイプ境界を外観として使用してサムネイル画像を取得します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプルコードは上記の手順に基づいています。

```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // 画像を PNG 形式でディスクに保存
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **シェイプの実際の視覚境界を取得**

シェイプ([Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/)) のフレーム プロパティ—`getX()`、`getY()`、`getWidth()`、`getHeight()` メソッド—は、プレゼンテーションモデルに保存されている矩形を記述します。実際にレンダリングされるコンテンツは、そのフレームを超えて拡張したり、別の軸平行矩形を占有したりすることがあります。回転、アウトライン、矢じり、テキストのレイアウトとオーバーフロー、生成された SmartArt のジオメトリ、その他のレンダリング効果はすべて占有領域を変更できます。

画像を作成せずに占有領域を計算するには、[Shape.getVisualBounds](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getVisualBounds--) を使用します。このメソッドはスライド座標系で[Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) オブジェクトを返します。返された矩形はスライドでクリップされないため、コンテンツがスライドの原点を超える場合は座標が負になることがあります。

次の例はフレームと視覚境界を取得して比較します：

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

同じ矩形を使用して、近接するシェイプを左、右、上、下のエッジに合わせたり、生成されたレイアウトで十分なスペースを確保したり、許可された領域外のコンテンツを検出したりできます。視覚境界は、格納されたフレームが完全なレンダリング結果を表さない可能性がある SmartArt、テキストボックス、矢印、画像、回転シェイプ、グループシェイプなどで特に有用です。

レイアウトや検証のために座標が必要で、ビットマップが不要な場合は[Shape.getVisualBounds](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getVisualBounds--) を使用します。シェイプをレンダリングする必要がある場合は[Shape.getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getImage--) を使用します。[ShapeThumbnailBounds](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapethumbnailbounds/) を使用すると、`ShapeThumbnailBounds.Shape` はアウトライン設定を含むシェイプの境界から画像のサイズを決定し、`ShapeThumbnailBounds.Appearance` はシェイプの外観からサイズを決定し、結果をスライドの境界に制限します。これに対し、[Shape.getVisualBounds](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getVisualBounds--) は計算された矩形のみを返し、スライドにクリップしません。

## **FAQ**

**シェイプ サムネイルを保存する際に使用できる画像形式は何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imageformat/)、その他。シェイプはシェイプの内容を SVG として保存することで、ベクター SVG としても[エクスポート](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/writeassvg/)できます。

**サムネイルをレンダリングする際の Shape と Appearance の境界の違いは何ですか？**

`Shape` はシェイプのジオメトリを使用し、`Appearance` は[ビジュアル効果](/slides/ja/nodejs-java/shape-effect/)（影、グローなど）を考慮します。

**シェイプが非表示としてマークされている場合はどうなりますか？ サムネイルとしてまだレンダリングされますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、シェイプの画像生成を妨げることはありません。

**グループシェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) として表現されるオブジェクト（[GroupShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartart/) を含む）は、サムネイルまたは SVG として保存できます。

**システムにインストールされたフォントはテキストシェイプのサムネイル品質に影響しますか？**

はい。不要なフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/nodejs-java/custom-font/)（または[フォント置換を構成](/slides/ja/nodejs-java/font-substitution/)）する必要があります。