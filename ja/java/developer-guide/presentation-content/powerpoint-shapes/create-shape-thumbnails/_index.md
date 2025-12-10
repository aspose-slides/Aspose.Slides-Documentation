---
title: Javaでプレゼンテーション シェイプのサムネイルを作成
linktitle: シェイプ サムネイル
type: docs
weight: 70
url: /ja/java/create-shape-thumbnails/
keywords:
- シェイプ サムネイル
- シェイプ 画像
- シェイプ をレンダリング
- シェイプ レンダリング
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライドから高品質なシェイプ サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成・エクスポートできます。"
---

## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for Java は、各ページがスライドに対応するプレゼンテーション ファイルを作成するために使用できます。スライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者がシェイプの画像を画像ビューアで個別に表示したい場合があります。そのような場合、Aspose.Slides for Java はスライド シェイプのサムネイル画像を生成するのに役立ちます。

{{% /alert %}} 

このトピックでは、さまざまな状況でスライド サムネイルを生成する方法を示します。

- スライド内のシェイプのサムネイルを生成する。
- ユーザー定義のサイズでスライド シェイプのサムネイルを生成する。
- シェイプの外観の境界内でサムネイルを生成する。

## **スライドからシェイプ サムネイルを生成する**
Aspose.Slides for Java を使用して任意のスライドからシェイプ サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドへの参照を取得します。
1. 参照したスライドの [シェイプ サムネイル画像](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) をデフォルト スケールで取得します。
1. サムネイル画像を好みの画像形式で保存します。

このサンプル コードは、スライドからシェイプ サムネイルを生成する方法を示しています：
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // 画像を PNG 形式でディスクに保存
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **ユーザー定義スケーリング係数サムネイルを生成する**
Aspose.Slides for Java を使用してスライドのシェイプ サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドへの参照を取得します。
1. ユーザー定義のサイズで参照したスライドの [シェイプ サムネイル画像](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) を取得します。
1. サムネイル画像を好みの画像形式で保存します。

このサンプル コードは、定義されたスケーリング係数に基づいてシェイプ サムネイルを生成する方法を示しています：
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // 画像を PNG 形式でディスクに保存
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
このサムネイル作成方法は、シェイプの外観の境界内でサムネイルを生成できます。すべてのシェイプ効果が考慮され、生成されたシェイプ サムネイルはスライドの境界で制限されます。シェイプの外観の境界でスライド シェイプのサムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドへの参照を取得します。
1. シェイプの外観を境界として参照したスライドのサムネイル画像を取得します。
1. サムネイル画像を好みの画像形式で保存します。

このサンプル コードは上記の手順に基づいています：
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケールの画像を作成
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // 画像を PNG 形式でディスクに保存
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**シェイプ サムネイルを保存する際に使用できる画像形式は何ですか？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/)、その他多数。シェイプは、シェイプのコンテンツを SVG として保存することで、[ベクター SVG としてエクスポート](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) することもできます。

**サムネイルをレンダリングする際の Shape 境界と Appearance 境界の違いは何ですか？**

`Shape` はシェイプのジオメトリを使用します。`Appearance` は[ビジュアル効果](/slides/ja/java/shape-effect/)（影、光彩など）を考慮します。

**シェイプが非表示としてマークされている場合、サムネイルは生成されますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショー表示に影響しますが、シェイプの画像生成を妨げません。

**グループ シェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/java/com.aspose.slides/shape/) として表現できるオブジェクト（[GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/java/com.aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/) など）すべてサムネイルまたは SVG として保存できます。

**システムにインストールされているフォントは、テキスト シェイプのサムネイル品質に影響しますか？**

はい。不要なフォント置き換えやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/java/custom-font/)（または[フォント置換を構成](/slides/ja/java/font-substitution/)）する必要があります。