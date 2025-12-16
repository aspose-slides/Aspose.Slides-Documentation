---
title: Android でプレゼンテーション シェイプのサムネイルを作成
linktitle: シェイプ サムネイル
type: docs
weight: 70
url: /ja/androidjava/create-shape-thumbnails/
keywords:
- シェイプ サムネイル
- シェイプ 画像
- シェイプのレンダリング
- シェイプレンダリング
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して PowerPoint スライドから高品質なシェイプ サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートできます。"
---

## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java は、各ページがスライドに対応するプレゼンテーション ファイルを作成するために使用できます。スライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者はシェイプの画像を別途画像ビューアで確認したい場合があります。そのような場合、Aspose.Slides for Android via Java はスライド シェイプのサムネイル画像を生成するのに役立ちます。

{{% /alert %}} 

このトピックでは、さまざまな状況でスライドのサムネイルを生成する方法を示します。

- スライド内のシェイプ サムネイルの生成  
- ユーザー定義サイズでスライド シェイプのサムネイルを生成  
- シェイプの外観の境界内でサムネイルを生成  

## **スライドからシェイプサムネイルを生成**
Aspose.Slides for Android via Java を使用して任意のスライドからシェイプ サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. ID またはインデックスを使用して任意のスライドの参照を取得します。  
3. [シェイプのサムネイル画像を取得](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) し、デフォルト スケールで参照されたスライドから取得します。  
4. 好みの画像形式でサムネイル画像を保存します。

このサンプル コードは、スライドからシェイプ サムネイルを生成する方法を示しています:
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


## **ユーザー定義スケーリング係数サムネイルの生成**
Aspose.Slides for Android via Java を使用してスライドのシェイプ サムネイルをユーザー定義のサイズで生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. ID またはインデックスを使用して任意のスライドの参照を取得します。  
3. [シェイプのサムネイル画像を取得](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) し、ユーザー定義の寸法で参照されたスライドから取得します。  
4. 好みの画像形式でサムネイル画像を保存します。

このサンプル コードは、定義されたスケーリング係数に基づいてシェイプ サムネイルを生成する方法を示しています:
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


## **境界ベースのシェイプ外観サムネイルの作成**
この方法は、シェイプの外観の境界内でサムネイルを生成します。すべてのシェイプ効果が考慮され、生成されたシェイプ サムネイルはスライドの境界によって制限されます。シェイプの外観の境界内でスライド シェイプのサムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. ID またはインデックスを使用して任意のスライドの参照を取得します。  
3. シェイプの外観を境界として、参照されたスライドのサムネイル画像を取得します。  
4. 好みの画像形式でサムネイル画像を保存します。

このサンプル コードは、上記の手順に基づいています:
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

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/)、その他の形式が使用できます。シェイプは、シェイプのコンテンツを SVG として保存することにより、[ベクター SVG としてエクスポート](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) も可能です。

**サムネイルをレンダリングする際の Shape と Appearance の境界の違いは何ですか？**

`Shape` はシェイプのジオメトリを使用します。`Appearance` は[視覚効果](/slides/ja/androidjava/shape-effect/)（影、光彩など）を考慮します。

**シェイプが非表示としてマークされている場合、サムネイルは生成されますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、シェイプの画像生成を妨げません。

**グループ シェイプ、チャート、SmartArt などの複雑なオブジェクトはサポートされていますか？**

はい。「[Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/)」として表現できるオブジェクト（[GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/) を含む）は、サムネイルまたは SVG として保存できます。

**システムにインストールされているフォントは、テキスト シェイプのサムネイル品質に影響しますか？**

はい。不要なフォントの置き換えやテキストのリフローを防ぐために、[必要なフォントを提供](/slides/ja/androidjava/custom-font/)（または[フォント置換を構成](/slides/ja/androidjava/font-substitution/)）する必要があります。