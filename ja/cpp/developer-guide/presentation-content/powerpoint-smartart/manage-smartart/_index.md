---
title: C++ を使用して PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt を管理する
type: docs
weight: 10
url: /ja/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示 プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "明確なコードサンプルを使用して、Aspose.Slides for C++ で PowerPoint の SmartArt を作成・編集し、スライドのデザインと自動化を迅速化する方法を学びます。"
---
## **概要**

SmartArt はノード、ノードシェイプ、レイアウトで構成された PowerPoint ダイアグラムです。Aspose.Slides for C++ を使用すると、SmartArt を作成し、ノードからテキストを読み取り、レイアウトを変更し、非表示ノードを検査し、組織図のレイアウトを構成し、画像組織図を作成できます。

## **SmartArt オブジェクトからテキストを取得する**

SmartArt のノードは 1 つ以上のシェイプを含むことができます。表示テキストを取得するには、[ISmartArt::get_AllNodes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartart/get_allnodes/) を反復し、次に [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartartshape/get_textframe/) が返す [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) を読み取ります。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **SmartArt オブジェクトのレイアウトタイプを変更する**

SmartArt のレイアウトはノードの配置と接続方法を制御します。以下の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SmartArt ノードが非表示かどうかを確認する**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) は、ノードが SmartArt データモデルで非表示かどうかを示します。選択されたレイアウトで可視的なダイアグラム要素として表示されなくても、非表示ノードは構造内に存在する可能性があります。

以下の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartartlayouttype/) の `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、そのノードの非表示状態を確認します。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt ダイアグラムでは、[ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) と [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) が、親ノードの下で子ノードがどのように配置されるかを定義します。たとえば、選択された [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側に掛けるように設定できます。

以下の例は組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/organizationchartlayouttype/) の `LeftHanging` 値に設定します。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層ダイアグラム用に設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartartlayouttype/) の `PictureOrganizationChart` 値を使用します。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**SmartArt は RTL 言語のミラーリングまたは反転をサポートしていますか？**

はい。選択された SmartArt レイアウトが反転をサポートしている場合、[SmartArt::set_IsReversed](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartart/set_isreversed/) メソッドはダイアグラムの方向を左から右へ、または右から左へ、あるいは元に戻します。

**フォーマットを保持したまま、同じスライドまたは別のプレゼンテーションに SmartArt をコピーするにはどうすればよいですか？**

SmartArt シェイプは [ShapeCollection::AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shapecollection/addclone/) を使用して [clone the SmartArt shape](/slides/ja/cpp/shape-manipulations/) で、または SmartArt を含むスライド全体を [clone the whole slide](/slides/ja/cpp/clone-slides/) でクローンできます。どちらの方法もサイズ、位置、フォーマットを保持します。

**プレビューや Web エクスポートのために SmartArt をラスタ画像にレンダリングするにはどうすればよいですか？**

スライドを PNG または JPEG に [スライドをレンダリング](/slides/ja/cpp/convert-powerpoint-to-png/) するか、プレゼンテーション全体を変換します。SmartArt はスライドの一部としてレンダリングされます。

**スライド上に複数の SmartArt がある場合、特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の [Shape::set_AlternativeText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/set_alternativetext/) または [Shape::set_Name](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/set_name/) の値を設定し、[BaseSlide::get_Shapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseslide/get_shapes/) でその値を検索し、該当するシェイプが [ISmartArt](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/ismartart/) であることを確認します。