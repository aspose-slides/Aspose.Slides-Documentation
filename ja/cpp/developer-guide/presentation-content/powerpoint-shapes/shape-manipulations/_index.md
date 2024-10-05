---
title: 形状の操作
type: docs
weight: 40
url: /cpp/shape-manipulations/
---

## **スライド内の形状を見つける**
このトピックでは、開発者が内部IDを使用せずにスライド上の特定の形状を見つけやすくするためのシンプルな手法を説明します。PowerPointプレゼンテーションファイルは、内部のユニークIDを除いてスライド上の形状を特定する方法がないことを知っておくことが重要です。開発者が内部ユニークIDを使用して形状を見つけるのは難しいようです。スライドに追加されたすべての形状には、いくつかの代替テキストがあります。特定の形状を見つけるために代替テキストを使用することを開発者に推奨します。今後変更する予定のオブジェクトの代替テキストを定義するためにMS PowerPointを使用できます。

希望する形状の代替テキストを設定した後、Aspose.Slides for C++を使用してそのプレゼンテーションを開き、スライドに追加されたすべての形状を反復処理できます。各反復の間に、形状の代替テキストを確認し、一致する代替テキストを持つ形状が必要な形状になります。この技術をより良く示すために、特定の形状をスライド内で見つけてその形状を単に返すメソッド[FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f)を作成しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **形状を複製する**
Aspose.Slides for C++を使用してスライドに形状を複製するには：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソーススライドの形状コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソーススライドの形状コレクションから新しいスライドに形状を複製します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、グループ形状をスライドに追加します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **形状を削除する**
Aspose.Slides for C++では、開発者が任意の形状を削除できます。任意のスライドから形状を削除するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定のAlternativeTextを持つ形状を見つけます。
1. 形状を削除します。
1. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **形状を隠す**
Aspose.Slides for C++では、開発者が任意の形状を隠すことができます。任意のスライドから形状を隠すには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定のAlternativeTextを持つ形状を見つけます。
1. 形状を隠します。
1. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **形状の順序を変更する**
Aspose.Slides for C++では、開発者が形状の順序を変更できます。形状の順序を変更することで、どの形状が前面にあるか、どの形状が背面にあるかを指定します。任意のスライドから形状の順序を変更するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 形状を追加します。
1. 形状のテキストフレームにテキストを追加します。
1. 同じ座標を持つ別の形状を追加します。
1. 形状の順序を変更します。
1. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **インタープロップ形状IDを取得する**
Aspose.Slides for C++は、UniqueIdプロパティとは対照的に、スライドスコープ内でユニークな形状識別子を取得することを可能にします。これはプレゼンテーションスコープ内でユニークな識別子を取得できます。OfficeInteropShapeIdプロパティは、IShapeインターフェースおよびShapeクラスに追加されました。OfficeInteropShapeIdプロパティによって返される値は、Microsoft.Office.Interop.PowerPoint.ShapeオブジェクトのIdの値に対応します。以下はサンプルコードです。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **AlternativeTextプロパティを設定する**
Aspose.Slides for C++は、開発者が任意の形状のAlternateTextを設定できるようにします。形状のAlternateTextを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに任意の形状を追加します。
1. 新しく追加した形状で何らかの作業を行います。
1. 形状を辿って形状を見つけます。
1. AlternativeTextを設定します。
1. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **形状のレイアウト形式にアクセスする**
Aspose.Slides for C++は、開発者が形状のレイアウト形式にアクセスできるようにします。この資料では、形状の**FillFormat**および**LineFormat**プロパティにアクセスする方法を示します。

以下はサンプルコードです。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **形状をSVGとしてレンダリングする**
現在、Aspose.Slides for C++は、形状をSVGとしてレンダリングすることをサポートしています。WriteAsSvgメソッド（およびそのオーバーロード）がShapeクラスとIShapeインターフェースに追加されました。このメソッドは、形状のコンテンツをSVGファイルとして保存できるようにします。以下のコードスニペットは、スライドの形状をSVGファイルにエクスポートする方法を示しています。

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **形状の配置**
Aspose.Slidesでは、形状をスライドのマージンに対して、または相互に配置できます。この目的のために、オーバーロードされた[SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab)メソッドが追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f)列挙型は、可能な整列オプションを定義します。

**例1**

以下のソースコードは、インデックス1、2、4の形状をスライドの上部境界に沿って整列します。

``` cpp
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

**例2**

以下の例は、形状の全コレクションをコレクション内の最も下にある形状に対して整列する方法を示しています。

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```