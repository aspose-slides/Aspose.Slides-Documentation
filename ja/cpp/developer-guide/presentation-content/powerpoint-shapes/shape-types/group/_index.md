---
title: C++ のグループ プレゼンテーション シェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/cpp/group/
keywords:
- グループ シェイプ
- シェイプ グループ
- グループ 追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint デッキでシェイプのグループ化とグループ解除を学ぶ — 迅速でステップバイステップのガイド、無料の C++ コード付き。"
---

## **グループ シェイプを追加**
Aspose.Slides はスライド上のグループ シェイプの操作をサポートしています。この機能は開発者がよりリッチなプレゼンテーションを実現するのに役立ちます。Aspose.Slides for C++ はグループ シェイプの追加や取得をサポートします。追加したグループ シェイプにシェイプを配置したり、グループ シェイプの任意のプロパティにアクセスしたりできます。Aspose.Slides for C++ を使用してスライドにグループ シェイプを追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループ シェイプを追加します。
1. 追加したグループ シェイプにシェイプを追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例はスライドにグループ シェイプを追加します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **AltText プロパティにアクセス**
このトピックでは、グループ シェイプを追加し、スライド上のグループ シェイプの AltText プロパティにアクセスするための簡単な手順とコード例を示します。Aspose.Slides for C++ を使用してスライド内のグループ シェイプの AltText にアクセスする手順は次のとおりです。

1. PPTX ファイルを表す `Presentation` クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドのシェイプ コレクションにアクセスします。
1. グループ シェイプにアクセスします。
1. AltText プロパティにアクセスします。

以下の例はグループ シェイプの代替テキストにアクセスします。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**入れ子のグループ化（グループ内に別のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) には [get_ParentGroup](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_parentgroup/) メソッドがあり、階層構造のサポート（グループが別のグループの子になること）が直接示されています。

**スライド上の他のオブジェクトに対するグループの Z オーダーをどのように制御しますか？**

[GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) の [Z-Order position](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) を使用して、表示スタック内での位置を確認できます。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロック セクションは [get_GroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/get_groupshapelock/) によって公開されており、オブジェクトに対する操作を制限できます。