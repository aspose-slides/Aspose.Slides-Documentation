---
title: C++ を使用して PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt の管理
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
description: "Aspose.Slides for C++ を使用して PowerPoint の SmartArt を作成・編集する方法を、スライド デザインと自動化を高速化する明確なコードサンプルとともに学びます。"
---
## **概要**

SmartArt は、ノード、ノードシェイプ、レイアウトで構成された PowerPoint の図です。Aspose.Slides for C++ を使用すると、SmartArt の作成、ノードからのテキストの取得、レイアウトの変更、非表示ノードの検査、組織図レイアウトの構成、画像組織図の作成ができます。

## **SmartArt オブジェクトからテキストを取得する**

SmartArt のノードには 1 つ以上のシェイプを含めることができます。ノードシェイプからテキストを取得するには、[ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/) を反復処理し、[ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) が返す [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) を読み取ります。

この例では、少なくとも 1 枚のスライドが含まれ、該当スライドの最初のシェイプとして SmartArt オブジェクトが配置されたプレゼンテーションが必要です。利用可能な各テキストフレームをコンソールに出力します。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **SmartArt オブジェクトのレイアウトタイプを変更する**

SmartArt のレイアウトは、ノードの配置と接続方法を制御します。以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。[IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) に渡す位置とサイズはポイント単位です。レイアウトを変更するには [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) を使用します。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SmartArt ノードが非表示かどうかを確認する**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) は、ノードが SmartArt データモデルで非表示かどうかを示します。選択されたレイアウトで可視の図要素として表示されなくても、非表示ノードは構造内に存在する可能性があります。

以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) の `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、追加したノードの非表示状態を確認します。ノードが非表示の場合はメッセージを出力し、図を保存します。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt 図の場合、[ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) と [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) は、親ノードの下で子ノードがどのように配置されるかを定義します。たとえば、選択された [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側に吊り下げるように設定できます。

以下の例では、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) の `LeftHanging` 値に設定します。0 ベースのインデックス `0` が最上位ノードを選択し、子ノードは選択された配置を使用します。変更されたプレゼンテーションは保存されます。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図用に設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際に、[SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) の `PictureOrganizationChart` 値を使用します。この例では画像プレースホルダー付きの図を保存しますが、プレースホルダーに画像は設定しません。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **レガシー図をシェイプのグループに変換する**

既存のプレゼンテーションを最新化する際、PowerPoint 97–2003 で作成された組織図を更新する必要がある場合があります。Aspose.Slides はこれらのレガシー図を [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) オブジェクトとして表します。[ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) を使用して図をシェイプのグループに変換すれば、個々のビジュアル要素を編集できます。詳細は [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) を参照してください。

変換により、元の図を削除せずにシェイプコレクションに新しいグループが追加されます。変換が成功したら、重複コンテンツを防ぐために [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) で元の図を削除します。シェイプの追加・削除で反復が乱れないよう、変換前にレガシー図をベクターに収集しておきます。

以下の例では、プレゼンテーションを開き、すべてのスライドを検索して図をシェイプのグループに変換し、更新されたプレゼンテーションを PPTX として保存します。

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

保存されたプレゼンテーションには、変換されたレガシー図の代わりに編集可能なシェイプのグループが含まれ、元の図は残っていません。PowerPoint で PPTX を開くと、各グループ内のテキスト、塗り、位置など個々の要素を編集できます。

## **よくある質問**

**SmartArt は RTL 言語向けのミラーリングまたは反転をサポートしていますか？**

はい。選択された SmartArt レイアウトが反転をサポートしている場合、[SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) メソッドは図の方向を左から右へ、または右から左へ切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式を保持するにはどうすればよいですか？**

SmartArt が含まれるシェイプを [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) を使用して [SmartArt シェイプをクローン](/slides/ja/cpp/shape-manipulations/) するか、[SmartArt を含むスライド全体をクローン](/slides/ja/cpp/clone-slides/) できます。どちらの方法もサイズ、位置、書式を保持します。

**プレビューやウェブ出力のために SmartArt をラスタ画像としてレンダリングするにはどうすればよいですか？**

[スライドをレンダリング](/slides/ja/cpp/convert-powerpoint-to-png/) するか、プレゼンテーション全体を PNG または JPEG に変換してください。SmartArt はスライドの一部としてレンダリングされます。

**スライドに複数の SmartArt がある場合、特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) または [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) 値を設定し、[BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) でその値を検索し、該当シェイプが [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/) であることを確認します。