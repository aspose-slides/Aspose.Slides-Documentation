---
title: シェイプ サムネイル
type: docs
weight: 70
url: /cpp/shape-thumbnails/
keywords: 
- シェイプ サムネイル
- シェイプ画像
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides for С++
description: "C++でPowerPointプレゼンテーションからシェイプのサムネイルを抽出する"
---


## **シェイプサムネイルの作成**
Aspose.Slides for C++は、各ページがスライドであるプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションファイルを開くことで表示できます。しかし時には、開発者は画像ビューアでシェイプの画像を別々に表示する必要があるかもしれません。そのような場合、Aspose.Slides for C++はスライドシェイプのサムネイル画像を生成するのに役立ちます。この機能の使用方法はこの記事で説明します。
この記事では、さまざまな方法でスライドのサムネイルを生成する方法を説明します：

- スライド内でシェイプのサムネイルを生成する。
- ユーザー定義の寸法を持つスライドシェイプのサムネイルを生成する。
- シェイプの外観の範囲内でシェイプのサムネイルを生成する。
- SmartArt子ノードのサムネイルを生成する。

## **スライドからシェイプサムネイルを生成**
Aspose.Slides for C++を使用して任意のスライドからシェイプサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドのシェイプサムネイル画像をデフォルトのスケールで取得します。
1. サムネイル画像を任意の希望の画像フォーマットで保存します。

以下の例は、シェイプサムネイルを生成します。

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **ユーザー定義のスケーリングファクタサムネイルを生成**
Aspose.Slides for C++を使用して任意のスライドシェイプのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. シェイプの範囲を持つ参照スライドのサムネイル画像を取得します。
1. サムネイル画像を任意の希望の画像フォーマットで保存します。

以下の例は、ユーザー定義のスケーリングファクタでサムネイルを生成します。

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

## **シェイプの外観に基づくサムネイルの作成**
このメソッドは、シェイプのサムネイルを作成するために、開発者がシェイプの外観の範囲にサムネイルを生成できるようにします。すべてのシェイプ効果を考慮に入れます。生成されたシェイプサムネイルはスライドの範囲によって制約されます。任意のスライドシェイプの外観の範囲内でサムネイルを生成するには、以下のサンプルコードを使用します：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. シェイプの外観としてシェイプの範囲を持つ参照スライドのサムネイル画像を取得します。
1. サムネイル画像を任意の希望の画像フォーマットで保存します。

以下の例は、ユーザー定義のスケーリングファクタでサムネイルを生成します。

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