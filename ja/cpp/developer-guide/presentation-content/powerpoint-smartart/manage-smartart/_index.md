---
title: C++ を使用した PowerPoint プレゼンテーションの SmartArt の管理
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウトタイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint の SmartArt を構築・編集する方法を、スライドのデザインと自動化を高速化する明確なコードサンプルで学びます。"
---

## **SmartArt オブジェクトからテキストを取得する**
現在、ISmartArtShape インターフェイスと SmartArtShape クラスにそれぞれ TextFrame プロパティが追加されました。このプロパティを使用すると、ノードのテキストだけでなく SmartArt 全体のテキストを取得できます。以下のサンプルコードは、SmartArt ノードからテキストを取得する方法を示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **SmartArt オブジェクトのレイアウトタイプを変更する**
SmartArt のレイアウトタイプを変更するには、次の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- SmartArt BasicBlockList を追加します。
- LayoutType を BasicProcess に変更します。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、2 つの図形の間にコネクタを追加しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **SmartArt オブジェクトの Hidden プロパティを確認する**
メソッド `com.aspose.slides.ISmartArtNode.isHidden()` は、データモデル内でこのノードが非表示ノードである場合に true を返すことに注意してください。SmartArt の任意のノードの Hidden プロパティを確認するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
- SmartArt RadialCycle を追加します。
- SmartArt にノードを追加します。
- isHidden プロパティを確認します。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、2 つの図形の間にコネクタを追加しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **組織図のタイプを取得または設定する**
メソッド `com.aspose.slides.ISmartArtNode.getOrganizationChartLayout()`、`setOrganizationChartLayout(int)` は、現在のノードに関連付けられた組織図のタイプを取得または設定できます。組織図のタイプを取得または設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
- スライドに SmartArt を追加します。
- 組織図のタイプを取得または設定します。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、2 つの図形の間にコネクタを追加しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **SmartArt の状態を取得または設定する**
一部の SmartArt 図は反転をサポートしていません（例: Vertical bullet list、Vertical Process、Descending Process、Funnel、Gear、Balance、Circle Relationship、Hexagon Cluster、Reverse List、Stacked Venn）。SmartArt の向きを変更するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
- スライドに SmartArt を追加します。
- SmartArt 図の状態を取得または設定します。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、2 つの図形の間にコネクタを追加しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **ピクチャ組織図を作成する**
Aspose.Slides for C++ は、ピクチャ組織図（PictureOrganizationChart）を簡単に作成できるシンプルな API を提供します。スライド上にチャートを作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ (ChartType.PictureOrganizationChart) を指定してチャートを追加します。
4. 変更したプレゼンテーションを書き出して PPTX ファイルにします。

以下のコードはチャート作成に使用します。
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```


## **FAQ**

**SmartArt は RTL 言語に対してミラーリング/反転をサポートしていますか？**

はい。選択した SmartArt タイプが反転をサポートしている場合、[set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) メソッドが図の方向（LTR/RTL）を切り替えます。

**同じスライドまたは別のプレゼンテーションに SmartArt をコピーして書式を保持するにはどうすればよいですか？**

シェイプコレクションの [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) を使用して SmartArt シェイプを [クローン]( /slides/cpp/shape-manipulations/) するか、またはそのシェイプを含むスライド全体を [クローン]( /slides/cpp/clone-slides/) できます。どちらの方法でもサイズ、位置、スタイリングが保持されます。

**SmartArt をプレビューや Web エクスポート用にラスタ画像にレンダリングするには？**

スライド（またはプレゼンテーション全体）を PNG/JPEG に変換する API（[スライドをレンダリング](/slides/ja/cpp/convert-powerpoint-to-png/)）を使用してください。SmartArt はスライドの一部として描画されます。

**スライドに複数の SmartArt がある場合、プログラムで特定の SmartArt を選択する方法は？**

一般的な手法は、[代替テキスト](/slides/ja/cpp/shape-manipulations/)（Alt Text）または [名前](/slides/ja/cpp/shape-manipulations/) を設定し、[スライドシェイプ](/slides/ja/cpp/shape-manipulations/) コレクション内でその属性でシェイプを検索し、タイプが [SmartArt](/slides/ja/cpp/shape-manipulations/) かどうかを確認することです。ドキュメントにはシェイプの検索と操作に関する典型的なテクニックが記載されています。