---
title: "Javaでプレゼンテーションシェイプのサムネイルを作成する"
linktitle: "シェイプ サムネイル"
type: docs
weight: 70
url: /ja/java/create-shape-thumbnails/
keywords:
  - シェイプ サムネイル
  - シェイプ 画像
  - シェイプ のレンダリング
  - シェイプ レンダリング
  - ビジュアル 境界
  - シェイプ 境界
  - PowerPoint
  - プレゼンテーション
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライドから高品質なシェイプサムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成・エクスポートします。"
---
## **はじめに**

Aspose.Slides for Java は、各ページがスライドに対応するプレゼンテーション ファイルを作成するために使用できます。スライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者がシェイプの画像を画像ビューアで個別に確認する必要がある場合があります。そのような場合、Aspose.Slides for Java はスライドのシェイプのサムネイル画像の生成を支援します。

この記事では、スライドのサムネイルをさまざまな方法で生成する手順を説明します。

- スライド内のシェイプのサムネイルを生成する方法  
- ユーザー定義のサイズでスライド シェイプのサムネイルを生成する方法  
- シェイプの外観の境界内でサムネイルを生成する方法  

## **スライドからシェイプのサムネイルを生成する**
Aspose.Slides for Java を使用して任意のスライドからシェイプのサムネイルを生成するには、次の手順を実行します。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスを使用して任意のスライドへの参照を取得します。  
3. 参照したスライドのデフォルト スケールで[シェイプのサムネイル画像](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getImage--) を取得します。  
4. 好みの画像形式でサムネイル画像を保存します。

以下のサンプルコードは、スライドからシェイプのサムネイルを生成する方法を示しています。

```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成する
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

## **ユーザー定義のスケーリング係数でサムネイルを生成する**
Aspose.Slides for Java を使用してスライドのシェイプ サムネイルをユーザー定義のスケーリングで生成するには、次の手順を実行します。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスを使用して任意のスライドへの参照を取得します。  
3. ユーザー定義のサイズで参照したスライドの[シェイプのサムネイル画像](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getImage-int-float-float-) を取得します。  
4. 好みの画像形式でサムネイル画像を保存します。

以下のサンプルコードは、定義されたスケーリング係数に基づいてシェイプのサムネイルを生成する方法を示しています。

```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成する
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

## **外観の境界に基づくシェイプのサムネイルを作成する**
この方法では、シェイプの外観の境界内でサムネイルを生成します。シェイプのすべての効果が考慮され、生成されたシェイプ サムネイルはスライドの境界で制限されます。外観の境界内でスライド シェイプのサムネイルを生成するには、次の手順を実行します。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ID またはインデックスを使用して任意のスライドへの参照を取得します。  
3. 外観としてシェイプの境界を使用して、参照したスライドのサムネイル画像を取得します。  
4. 好みの画像形式でサムネイル画像を保存します。

以下のサンプルコードは上記手順に基づいています。

```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成する
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

## **シェイプの実際のビジュアル境界を取得する**

[IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) のフレーム プロパティ—`getX()`、`getY()`、`getWidth()`、`getHeight()` メソッド—は、プレゼンテーション モデルに格納された矩形を記述します。実際にレンダリングされるコンテンツはそのフレームを超えて拡張したり、別の軸に整列した矩形を占有したりすることがあります。回転、アウトライン、矢じり、テキスト配置とオーバーフロー、生成された SmartArt のジオメトリ、その他のレンダリング効果が占有領域を変更する可能性があります。

画像を作成せずに占有領域を計算するには、[Shape.getVisualBounds](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getVisualBounds--) を使用します。このメソッドはスライド座標系の [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) を返します。返される矩形はスライドにクリップされないため、コンテンツがスライドの原点を超える場合は座標が負になることがあります。

現在、[IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) インターフェイスには [Shape.getVisualBounds](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getVisualBounds--) が宣言されていません。したがって、スライドのシェイプコレクションから取得したシェイプはインターフェイス型のまま保持し、メソッドを呼び出すときにだけキャストしてください。

以下の例はフレーム境界とビジュアル境界を取得して比較します。

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

同じ [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) を使用して、近接シェイプを左・右・上・下のエッジに揃えたり、生成レイアウトで十分な余白を確保したり、許可領域外のコンテンツを検出したりできます。ビジュアル境界は、SmartArt、テキスト ボックス、矢印、画像、回転シェイプ、グループシェイプなど、保存されたフレームが完全なレンダリング結果を表さない場合に特に有用です。

レイアウトや検証のために座標が必要でビットマップが不要な場合は [Shape.getVisualBounds](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getVisualBounds--) を使用し、シェイプをレンダリングする必要がある場合は [IShape.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getImage--) を使用してください。[ShapeThumbnailBounds](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shapethumbnailbounds/) では、`ShapeThumbnailBounds.Shape` がアウトライン設定を含むシェイプの境界から画像サイズを決定し、`ShapeThumbnailBounds.Appearance` がシェイプの外観からサイズを決定し、結果をスライド境界で制限します。これに対し、[Shape.getVisualBounds](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getVisualBounds--) は計算された矩形のみを返し、スライドへのクリップは行いません。

## **FAQ**

**シェイプのサムネイルを保存する際に使用できる画像形式は何ですか？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imageformat/) などがあります。シェイプは [SVG としてベクタ形式でエクスポート](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) することもでき、SVG として保存できます。

**サムネイルをレンダリングする際の Shape 境界と Appearance 境界の違いは何ですか？**

`Shape` はシェイプのジオメトリのみを使用し、`Appearance` は [ビジュアル効果](/slides/ja/java/shape-effect/)（影、光彩など）を考慮します。

**シェイプが非表示としてマークされている場合はどうなりますか？サムネイルは生成されますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、シェイプの画像生成を阻止するものではありません。

**グループシェイプ、チャート、SmartArt、およびその他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/) として表現できるオブジェクト（[GroupShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/smartart/) を含む）は、サムネイルや SVG として保存できます。

**システムにインストールされているフォントはテキストシェイプのサムネイル品質に影響しますか？**

はい。不要なフォントフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/java/custom-font/)（または [フォント置換を構成](/slides/ja/java/font-substitution/)）する必要があります。