---
title: C++ でプレゼンテーション シェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/cpp/shape-manipulations/
keywords:
- PowerPoint シェイプ
- プレゼンテーション シェイプ
- スライド上のシェイプ
- シェイプの検索
- シェイプのクローン作成
- シェイプの削除
- シェイプの非表示
- シェイプ順序の変更
- Interop シェイプ ID の取得
- シェイプの代替テキスト
- シェイプのレイアウト形式
- SVG としてのシェイプ
- シェイプを SVG に変換
- シェイプの配置
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でシェイプを作成、編集、最適化し、高性能な PowerPoint プレゼンテーションを作成できるようになります。"
---

## **スライド上のシェイプを検索する**
このトピックでは、開発者が内部 Id を使用せずにスライド上の特定のシェイプを簡単に見つけられるシンプルな手法について説明します。PowerPoint プレゼンテーション ファイルでは、スライド上のシェイプを識別できる手段は内部の一意 Id だけであることに注意が必要です。内部の一意 Id を使用してシェイプを見つけるのは開発者にとって困難です。スライドに追加されたすべてのシェイプには代替テキストが設定されています。特定のシェイプを検索する際には代替テキストを使用することを推奨します。将来変更する可能性のあるオブジェクトに対して代替テキストを定義するには、MS PowerPoint を使用してください。

任意のシェイプの代替テキストを設定したら、Aspose.Slides for C++ でそのプレゼンテーションを開き、スライドに追加されたすべてのシェイプを走査できます。各イテレーションでシェイプの代替テキストを確認し、代替テキストが一致するシェイプが目的のシェイプとなります。この手法をより分かりやすく示すために、スライド内の特定シェイプを検索し、そのシェイプを返す [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) メソッドを作成しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **シェイプをクローンする**
Aspose.Slides for C++ を使用してシェイプをスライドにクローンする手順:

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソーススライドのシェイプ コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソーススライドのシェイプ コレクションから新しいスライドへシェイプをクローンします。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **シェイプを削除する**
Aspose.Slides for C++ では、任意のシェイプを削除できます。スライドからシェイプを削除する手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを削除します。
1. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **シェイプを非表示にする**
Aspose.Slides for C++ では、任意のシェイプを非表示にできます。シェイプを非表示にする手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを非表示にします。
1. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **シェイプの順序を変更する**
Aspose.Slides for C++ では、シェイプの順序を変更できます。シェイプの順序を変更すると、前面に表示するシェイプや背面に表示するシェイプを指定できます。スライド上のシェイプ順序を変更する手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. シェイプを追加します。
1. シェイプのテキスト フレームにテキストを入力します。
1. 同じ座標に別のシェイプを追加します。
1. シェイプの順序を変更します。
1. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Interop シェイプ ID を取得する**
Aspose.Slides for C++ では、UniqueId プロパティとは対照的にスライド スコープで一意のシェイプ識別子を取得できます。OfficeInteropShapeId プロパティが IShape インターフェイスと Shape クラスに追加されました。OfficeInteropShapeId プロパティが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプル コードを示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **AlternativeText プロパティを設定する**
Aspose.Slides for C++ では、任意のシェイプの AlternativeText を設定できます。シェイプの AlternativeText を設定する手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 任意のシェイプをスライドに追加します。
1. 追加したシェイプで作業を行います。
1. シェイプを走査して目的のシェイプを見つけます。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **シェイプのレイアウト フォーマットにアクセスする**
Aspose.Slides for C++ では、シェイプのレイアウト フォーマットにアクセスできます。この記事では、シェイプの **FillFormat** と **LineFormat** プロパティへのアクセス方法を示します。

以下にサンプル コードを示します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **シェイプを SVG としてレンダリングする**
現在、Aspose.Slides for C++ はシェイプを SVG としてレンダリングする機能をサポートしています。WriteAsSvg メソッド（およびそのオーバーロード）が Shape クラスと IShape インターフェイスに追加されました。このメソッドを使用すると、シェイプの内容を SVG ファイルとして保存できます。以下のコード スニペットは、スライドのシェイプを SVG ファイルにエクスポートする方法を示しています。
```cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```


## **シェイプの配置**
Aspose.Slides では、シェイプをスライドの余白に対して、または相互に対して配置できます。この目的のために、オーバーロードされた [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) メソッドが追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) 列挙体は、可能な配置オプションを定義します。

**例 1**

以下のソース コードは、インデックス 1、2、4 のシェイプをスライドの上端に沿って配置します。
```cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```


**例 2**

以下の例は、コレクション内の最下部シェイプに対してコレクション全体を配置する方法を示します。
```cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```


## **フリップ プロパティ**

Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) クラスが `flipH` と `flipV` プロパティを通じてシェイプの水平および垂直ミラーリングを制御します。両プロパティは [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) 型で、`True` がフリップ、`False` がフリップなし、`NotDefined` がデフォルト動作を示します。これらの値はシェイプの [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) から取得できます。

フリップ設定を変更するには、シェイプの現在の位置とサイズ、目的の `flipH` と `flipV` の値、および回転角度を指定して新しい [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) インスタンスを作成します。このインスタンスをシェイプの [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) に割り当て、プレゼンテーションを保存するとミラー変換が適用され、出力ファイルに反映されます。

以下の例では、最初のスライドにデフォルトのフリップ設定が適用された単一シェイプがある sample.pptx ファイルを想定しています。

![フリップ対象のシェイプ](shape_to_be_flipped.png)

次のコード例は、シェイプの現在のフリップ プロパティを取得し、水平・垂直にフリップします。
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// シェイプの水平フリップ プロパティを取得します。
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// シェイプの垂直フリップ プロパティを取得します。
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // 水平方向にフリップします。
auto flipV = NullableBool::True; // 水平方向にフリップします。
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


結果:

![フリップされたシェイプ](flipped_shape.png)

## **FAQ**

**スライド上でデスクトップ エディタのようにシェイプを結合（union/intersect/subtract）できますか？**

組み込みのブーリアン演算 API はありません。代わりに、[GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) などを使用して目的の輪郭を自分で計算し、その輪郭で新しいシェイプを作成し、元のシェイプを削除することで近似できます。

**シェイプが常に「最前面」に表示されるようにスタック順（z-order）を制御できますか？**

スライドの [shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) コレクション内で挿入/移動順序を変更します。予測可能な結果を得るには、他のスライド変更がすべて完了した後に z-order を最終決定してください。

**PowerPoint でユーザーがシェイプを編集できないように「ロック」できますか？**

できます。シェイプ レベルの保護フラグを設定します（例: 選択ロック、移動ロック、サイズ変更ロック、テキスト編集ロック）。必要に応じて、マスターやレイアウトでも同様の制限を設定できます。これは UI レベルの保護であり、セキュリティ機能ではありません。より強力な保護が必要な場合は、[読み取り専用推奨やパスワード](/slides/ja/cpp/password-protected-presentation/) などのファイル レベルの制限と組み合わせて使用してください。