---
title: Androidでプレゼンテーション シェイプのサムネイルを作成する
linktitle: シェイプ サムネイル
type: docs
weight: 70
url: /ja/androidjava/create-shape-thumbnails/
keywords:
- シェイプ サムネイル
- シェイプ 画像
- シェイプ レンダリング
- シェイプ 描画
- 視覚的境界
- シェイプ境界
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して PowerPoint スライドから高品質なシェイプ サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートできます。"
---
## **はじめに**

Aspose.Slides for Android via Java は、各ページがスライドに対応するプレゼンテーション ファイルを作成するために使用できます。スライドは Microsoft PowerPoint で開くことで表示できます。ただし、開発者がシェイプの画像を別々に画像ビューアで確認したい場合があります。そのような場合、Aspose.Slides for Android via Java はスライドシェイプのサムネイル画像を生成するのに役立ちます。

このトピックでは、さまざまな状況でスライドのサムネイルを生成する方法を示します。

- スライド内のシェイプのサムネイルを生成する。
- ユーザー定義のサイズでスライドシェイプのサムネイルを生成する。
- シェイプの外観の境界内でサムネイルを生成する。

## **スライドからシェイプ サムネイルを生成する**
Aspose.Slides for Android via Java を使用して任意のスライドからシェイプ サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドへの参照を取得します。
1. [形状のサムネイル画像を取得](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShape#getImage--) し、デフォルトのスケールで参照されたスライドから取得します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、スライドからシェイプ サムネイルを生成する方法を示しています。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成する
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // 画像を PNG 形式でディスクに保存する
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ユーザー定義スケーリング係数のサムネイルを生成する**
Aspose.Slides for Android via Java を使用してスライドのシェイプ サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドへの参照を取得します。
1. [ユーザー定義のサイズで形状のサムネイル画像を取得](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、定義されたスケーリング係数に基づいてシェイプ サムネイルを生成する方法を示しています。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成する
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // 画像を PNG 形式でディスクに保存する
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **境界ベースのシェイプ外観サムネイルを作成する**
このサムネイル作成方法は、開発者がシェイプの外観の境界内でサムネイルを生成できるようにします。すべてのシェイプ効果が考慮されます。生成されたシェイプ サムネイルはスライドの境界で制限されます。シェイプの外観の境界内でスライドシェイプのサムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドへの参照を取得します。
1. シェイプの外観を境界として、参照されたスライドのサムネイル画像を取得します。
1. 好みの画像形式でサムネイル画像を保存します。

上記の手順に基づくサンプルコードは次のとおりです。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成する
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // 画像を PNG 形式でディスクに保存する
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **シェイプの実際の視覚的境界を取得する**

[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) のフレーム プロパティ—`getX()`、`getY()`、`getWidth()`、`getHeight()` メソッド—は、プレゼンテーション モデルに格納されている矩形を記述します。実際に描画されるコンテンツはそのフレームを超えて拡張したり、軸に平行な別の矩形を占有したりすることがあります。回転、アウトライン、矢じり、テキストのレイアウトとオーバーフロー、生成された SmartArt のジオメトリ、およびその他のレンダリング効果が占有領域を変更する可能性があります。

画像を作成せずに占有領域を計算するには、[Shape.getVisualBounds](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getVisualBounds--) を使用します。このメソッドはスライド座標系の [RectF](https://developer.android.com/reference/android/graphics/RectF) を返します。返された矩形はスライドにクリップされないため、コンテンツがスライドの原点を超える場合は座標が負になることがあります。

現在、[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) インターフェイスには [Shape.getVisualBounds](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getVisualBounds--) が宣言されていません。そのため、スライドのシェイプ コレクションから取得したシェイプをインターフェイス型として保持し、メソッドを呼び出すときにキャストしてください。

以下の例はフレーム境界と視覚的境界を取得し、比較します。

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

同じ [RectF](https://developer.android.com/reference/android/graphics/RectF) を使用して、近接シェイプを左、右、上、または下の端に揃えたり、生成されたレイアウトに十分な余白を確保したり、許可された領域外のコンテンツを検出したりできます。視覚的境界は、SmartArt、テキスト ボックス、矢印、画像、回転シェイプ、グループシェイプなど、格納されたフレームが完全なレンダリング結果を表さない場合に特に有用です。

レイアウトや検証のために座標が必要でビットマップが不要な場合は [Shape.getVisualBounds](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getVisualBounds--) を使用し、シェイプを描画する必要がある場合は [IShape.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getImage--) を使用してください。`ShapeThumbnailBounds.Shape` はシェイプ境界（アウトライン設定を含む）から画像サイズを決定し、`ShapeThumbnailBounds.Appearance` はシェイプの外観からサイズを決定し、結果をスライド境界で制限します。これに対し、[Shape.getVisualBounds](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getVisualBounds--) は計算された矩形だけを返し、スライドにクリップしません。

## **FAQ**

**形状サムネイルを保存するときに使用できる画像形式は何ですか？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imageformat/)、その他の形式が使用できます。シェイプは、シェイプのコンテンツを SVG として保存することで [ベクタ SVG としてエクスポート](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) も可能です。

**サムネイルをレンダリングする際の Shape 境界と Appearance 境界の違いは何ですか？**

`Shape` はシェイプのジオメトリを使用し、`Appearance` は [視覚効果](/slides/ja/androidjava/shape-effect/)（影、光彩など）を考慮します。

**シェイプが非表示としてマークされている場合、サムネイルは生成されますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、シェイプの画像生成を妨げません。

**グループ シェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/) として表現できるオブジェクト（[GroupShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/smartart/) を含む）はサムネイルや SVG として保存できます。

**システムにインストールされているフォントは、テキストシェイプのサムネイル品質に影響しますか？**

はい。不要なフォントのフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/androidjava/custom-font/)（または [フォント置換を構成](/slides/ja/androidjava/font-substitution/)）する必要があります。