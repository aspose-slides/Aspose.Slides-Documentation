---
title: シェイプ サムネイルの作成
type: docs
weight: 70
url: /ja/nodejs-java/create-shape-thumbnails/
---

## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java を使用すると、各ページがスライドに対応するプレゼンテーション ファイルを作成できます。スライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者はシェイプの画像を画像ビューアで個別に表示する必要がある場合があります。そのようなケースでは、Aspose.Slides for Node.js via Java がスライド シェイプのサムネイル画像の生成を支援します。

{{% /alert %}} 

このトピックでは、さまざまな状況でスライド サムネイルを生成する方法を示します。

- スライド内のシェイプ サムネイルの生成。
- ユーザー定義のサイズでスライド シェイプのサムネイルを生成。
- シェイプの外観のバウンド内でシェイプ サムネイルを生成。

## **スライドからのシェイプサムネイルの生成**
Aspose.Slides for Node.js via Java を使用して任意のスライドからシェイプ サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. [参照したスライドのシェイプサムネイル画像を取得](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage--) し、デフォルト スケールを使用します。
1. 希望する画像形式でサムネイル画像を保存します。

このサンプルコードは、スライドからシェイプ サムネイルを生成する方法を示しています:
```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成します
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // 画像を PNG 形式でディスクに保存します
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


## **ユーザー定義のスケーリング係数によるシェイプサムネイルの生成**
Aspose.Slides for Node.js via Java を使用してスライドのシェイプ サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. [参照したスライドのシェイプサムネイル画像を取得](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) し、ユーザー定義の寸法を指定します。
1. 希望する画像形式でサムネイル画像を保存します。

このサンプルコードは、定義されたスケーリング係数に基づいてシェイプ サムネイルを生成する方法を示しています:
```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成します
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // 画像を PNG 形式でディスクに保存します
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


## **境界のシェイプサムネイルの生成**
この方法では、シェイプの外観のバウンド内でサムネイルを生成できます。すべてのシェイプ効果が考慮され、生成されたサムネイルはスライドのバウンドで制限されます。外観のバウンド内でスライド シェイプのサムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. シェイプ バウンドを外観として使用し、参照したスライドのサムネイル画像を取得します。
1. 希望する画像形式でサムネイル画像を保存します。

このサンプルコードは上記の手順に基づいています:
```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成します
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // 画像を PNG 形式でディスクに保存します
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


## **よくある質問**

**シェイプサムネイルを保存する際に使用できる画像形式は何ですか？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/) などがあります。シェイプは、シェイプのコンテンツを SVG として保存することで、[ベクタ SVG としてエクスポート](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) も可能です。

**サムネイルをレンダリングする際の Shape バウンドと Appearance バウンドの違いは何ですか？**

`Shape` はシェイプのジオメトリを使用します。`Appearance` は[視覚効果](/slides/ja/nodejs-java/shape-effect/)（影、光彩など）を考慮します。

**シェイプが非表示としてマークされている場合、サムネイルは生成されますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、シェイプの画像生成を妨げません。

**グループ シェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) として表現されるすべてのオブジェクト（[GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) を含む）は、サムネイルまたは SVG として保存できます。

**システムにインストールされているフォントは、テキストシェイプのサムネイル品質に影響しますか？**

はい。不要なフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/nodejs-java/custom-font/)（または[フォント置換を構成](/slides/ja/nodejs-java/font-substitution/)）する必要があります。