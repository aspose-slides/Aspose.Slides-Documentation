---
title: C++ でプレゼンテーション形状のサムネイルを作成する
linktitle: 形状サムネイル
type: docs
weight: 70
url: /ja/cpp/shape-thumbnails/
keywords:
- 形状サムネイル
- 形状画像
- 形状のレンダリング
- 形状描画
- ビジュアル境界
- 形状境界
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint スライドから高品質な形状サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートできます。"
---
## **概要**

Aspose.Slides は、各ページがスライドであるプレゼンテーション ファイルを作成するために使用されます。これらのスライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者が形状の画像を個別の画像ビューアで確認したい場合があります。そのようなケースでは、Aspose.Slides がスライドの形状のサムネイル画像の生成を支援します。この機能の使用方法については、この記事で説明します。

この記事では、スライド サムネイルを生成するさまざまな方法について説明します。

- スライド内の形状サムネイルを生成する。
- ユーザー定義の寸法でスライド形状のサムネイルを生成する。
- 形状の外観の境界内で形状サムネイルを生成する。

## **スライドから形状サムネイルを生成する**
Aspose.Slides for C++ を使用して任意のスライドから形状サムネイルを生成するには:

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドの参照を取得します。
3. 参照されたスライドの形状サムネイル画像をデフォルト スケールで取得します。
4. サムネイル画像を任意の画像形式で保存します。

以下の例は形状サムネイルを生成します。

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **ユーザー定義スケーリング ファクターのサムネイルを生成する**
Aspose.Slides for C++ を使用して任意のスライド形状のサムネイルを生成するには:

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドの参照を取得します。
3. 参照されたスライドの形状境界を使用してサムネイル画像を取得します。
4. サムネイル画像を任意の画像形式で保存します。

以下の例は、ユーザー定義のスケーリング ファクターでサムネイルを生成します。

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // X 軸と Y 軸のスケーリング。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **境界ベースの形状外観サムネイルを作成する**
この形状サムネイル作成メソッドは、開発者が形状の外観の境界内でサムネイルを生成できるようにします。すべての形状効果が考慮されます。生成された形状サムネイルはスライドの境界によって制限されます。外観の境界内で任意のスライド形状のサムネイルを生成するには、以下のサンプル コードを使用します。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドの参照を取得します。
3. 参照されたスライドの形状境界（外観）でサムネイル画像を取得します。
4. サムネイル画像を任意の画像形式で保存します。

以下の例は、ユーザー定義スケーリング ファクターでサムネイルを作成します。

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // X 軸と Y 軸のスケーリング。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **形状の実際のビジュアル境界を取得する**

[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) のフレーム プロパティ—`IShape::get_X()`、`IShape::get_Y()`、`IShape::get_Width()`、および `IShape::get_Height()`—は、プレゼンテーション モデルに格納されている矩形を記述します。実際にレンダリングされるコンテンツは、そのフレームを超えて拡張したり、別の軸平行矩形を占有したりする可能性があります。回転、アウトライン、矢じり、テキスト レイアウトとオーバーフロー、生成された SmartArt ジオメトリ、およびその他のレンダリング効果はすべて、占有領域を変更する可能性があります。

画像を作成せずに占有領域を計算するには、[Shape::GetVisualBounds](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getvisualbounds/) を使用します。このメソッドはスライド座標系の [RectangleF](https://reference.aspose.com/slides/ja/cpp/system.drawing/rectanglef/) を返します。返された矩形はスライドにクリップされないため、コンテンツがスライドの原点を超える場合は座標が負になることがあります。

[Shape::GetVisualBounds](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getvisualbounds/) は現在、[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) インターフェイスで宣言されていません。そのため、スライドの形状コレクションから取得した形状をインターフェイス値として保持し、メソッドを呼び出す際にのみキャストしてください。

以下の例はフレームとビジュアル境界を取得して比較します。

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

同じ [RectangleF](https://reference.aspose.com/slides/ja/cpp/system.drawing/rectanglef/) を使用して、`RectangleF::get_Left()`、`RectangleF::get_Right()`、`RectangleF::get_Top()`、または `RectangleF::get_Bottom()` のエッジに近接する形状を整列させたり、生成されたレイアウトに十分なスペースを確保したり、許可された領域外のコンテンツを検出したりできます。ビジュアル境界は特に SmartArt、テキスト ボックス、矢印、画像、回転形状、グループ形状に有用で、保存されたフレームが完全なレンダリング結果を表さない場合があります。

レイアウトや検証のために座標が必要で画像が不要な場合は、[Shape::GetVisualBounds](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getvisualbounds/) を使用します。形状をレンダリングする必要がある場合は、[IShape::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/getimage/) を使用します。[ShapeThumbnailBounds](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapethumbnailbounds/) では、`ShapeThumbnailBounds::Shape` がアウトライン設定を含む形状境界から画像サイズを決定し、`ShapeThumbnailBounds::Appearance` が形状の外観からサイズを決定し、結果をスライド境界に制限します。対照的に、[Shape::GetVisualBounds](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/getvisualbounds/) は計算された矩形のみを返し、スライドにクリップしません。

## **よくある質問**

**形状サムネイルを保存する際に使用できる画像形式は何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imageformat/)、その他。形状はコンテンツを SVG として保存することで、ベクトル SVG としてもエクスポートできます。[exported as vector SVG](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/writeassvg/) を参照してください。

**サムネイルをレンダリングする際の Shape 境界と Appearance 境界の違いは何ですか？**

`Shape` は形状のジオメトリを使用します。`Appearance` は [visual effects](/slides/ja/cpp/shape-effect/)（影、光彩など）を考慮します。

**形状が非表示としてマークされている場合、サムネイルは生成されますか？**

非表示の形状はモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショー表示に影響しますが、形状の画像生成を阻止しません。

**グループ形状、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/) として表現されるオブジェクト（[GroupShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartart/) を含む） はサムネイルまたは SVG として保存できます。

**システムにインストールされているフォントはテキスト形状のサムネイル品質に影響しますか？**

はい。不要なフォントのフォールバックやテキストの再フローを防ぐために、[required fonts](/slides/ja/cpp/custom-font/) を提供するか、[font substitutions](/slides/ja/cpp/font-substitution/) を構成してください。