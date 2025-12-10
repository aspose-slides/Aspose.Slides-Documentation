---
title: C++でプレゼンテーションシェイプのサムネイルを作成
linktitle: シェイプ サムネイル
type: docs
weight: 70
url: /ja/cpp/shape-thumbnails/
keywords:
- シェイプ サムネイル
- シェイプ 画像
- シェイプ レンダリング
- シェイプ レンダリング
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint スライドから高品質なシェイプサムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成・エクスポートします。"
---

## **シェイプのサムネイルを作成**
Aspose.Slides for C++ は、各ページがスライドとなるプレゼンテーション ファイルを作成するために使用されます。これらのスライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者がシェイプの画像を画像ビューアで個別に確認したい場合があります。そのような場合、Aspose.Slides for C++ はスライドのシェイプのサムネイル画像を生成するのに役立ちます。この機能の使用方法はこの記事で説明します。

この記事では、さまざまな方法でスライドのサムネイルを生成する方法を説明します：

- スライド内でシェイプのサムネイルを生成する。
- ユーザー定義のサイズでスライド シェイプのサムネイルを生成する。
- シェイプの外観の境界内でシェイプのサムネイルを生成する。
- SmartArt の子ノードのサムネイルを生成する。

## **スライドからシェイプのサムネイルを生成**
Aspose.Slides for C++ を使用して任意のスライドからシェイプのサムネイルを生成する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドの参照を取得します。
3. 参照したスライドのシェイプ サムネイル画像をデフォルトスケールで取得します。
4. サムネイル画像を任意の画像形式で保存します。

以下の例はシェイプのサムネイルを生成します。
```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **ユーザー定義スケーリング係数のサムネイルを生成**
Aspose.Slides for C++ を使用して任意のスライド シェイプのサムネイルを生成する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドの参照を取得します。
3. 参照したスライドのシェイプ境界でサムネイル画像を取得します。
4. サムネイル画像を任意の画像形式で保存します。

以下の例は、ユーザー定義のスケーリング係数を使用してサムネイルを生成します。
```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // X軸とY軸に沿ったスケーリング。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **境界ベースのシェイプ外観サムネイルを作成**
このシェイプのサムネイル作成方法は、開発者がシェイプの外観の境界内でサムネイルを生成できるようにします。すべてのシェイプ効果を考慮します。生成されたシェイプのサムネイルはスライドの境界で制限されます。外観の境界内で任意のスライド シェイプのサムネイルを生成するには、以下のサンプルコードを使用します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドの参照を取得します。
3. 参照したスライドのシェイプ境界（外観）でサムネイル画像を取得します。
4. サムネイル画像を任意の画像形式で保存します。

以下の例は、ユーザー定義のスケーリング係数を使用してサムネイルを作成します。
```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // X軸とY軸に沿ったスケーリング。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **FAQ**

**シェイプのサムネイルを保存するときに使用できる画像形式は何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), など。他にもあります。シェイプは、シェイプの内容を SVG として保存することで、[ベクタ SVG としてエクスポート](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) することもできます。

**サムネイルをレンダリングする際の Shape と Appearance の境界の違いは何ですか？**

`Shape` はシェイプのジオメトリを使用します。`Appearance` は[ビジュアル エフェクト](/slides/ja/cpp/shape-effect/)（影、光彩など）を考慮します。

**シェイプが非表示としてマークされている場合、どうなりますか？サムネイルとしてレンダリングされますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショー表示に影響しますが、シェイプの画像生成を妨げません。

**グループシェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) として表現できるすべてのオブジェクト（[GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/) を含む）は、サムネイルまたは SVG として保存できます。

**システムにインストールされたフォントは、テキストシェイプのサムネイル品質に影響しますか？**

はい。不要なフォントフォールバックやテキストの折り返しを防ぐために、[必要なフォントを提供](/slides/ja/cpp/custom-font/)（または[フォント置換を構成](/slides/ja/cpp/font-substitution/)）すべきです。