---
title: C++ を使用したプレゼンテーションでの SmartArt グラフィック管理
linktitle: SmartArt グラフィック
type: docs
weight: 20
url: /ja/cpp/manage-smartart-shape/
keywords:
- SmartArt オブジェクト
- SmartArt グラフィック
- SmartArt スタイル
- SmartArt カラー
- SmartArt の作成
- SmartArt の追加
- SmartArt の編集
- SmartArt の変更
- SmartArt へのアクセス
- SmartArt レイアウト タイプ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint の SmartArt の作成、編集、スタイリングを自動化し、簡潔なコード例とパフォーマンス重視のガイダンスを提供します。"
---

## **SmartArt シェイプの作成**
Aspose.Slides for C++ は、スライドにカスタム SmartArt シェイプを最初から追加できるようになりました。Aspose.Slides for C++ は、SmartArt シェイプを最も簡単に作成できる API を提供しています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutType を設定して SmartArt シェイプを追加します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **スライド上の SmartArt シェイプへのアクセス**
以下のコードは、プレゼンテーション スライドに追加された SmartArt シェイプにアクセスするために使用されます。サンプルコードでは、スライド内のすべてのシェイプを走査し、SmartArt シェイプかどうかを確認します。シェイプが SmartArt タイプであれば、SmartArt インスタンスに型キャストします。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **特定の Layout Type を持つ SmartArt シェイプへのアクセス**
以下のサンプルコードは、特定の LayoutType を持つ SmartArt シェイプにアクセスするのに役立ちます。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプが追加されるときにのみ設定されるため、変更できないことに注意してください。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションを読み込みます。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば型キャストします。
- 特定の LayoutType を持つ SmartArt シェイプを確認し、必要な処理を実行します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **SmartArt シェイプのスタイル変更**
以下のサンプルコードは、特定の LayoutType を持つ SmartArt シェイプにアクセスするのに役立ちます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションを読み込みます。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば型キャストします。
- 特定の Style を持つ SmartArt シェイプを検索します。
- SmartArt シェイプに新しい Style を設定します。
- プレゼンテーションを保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **SmartArt シェイプの色スタイル変更**
この例では、任意の SmartArt シェイプの色スタイルを変更する方法を学びます。以下のサンプルコードは、特定の色スタイルを持つ SmartArt シェイプにアクセスし、スタイルを変更します。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションを読み込みます。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば型キャストします。
- 特定の Color Style を持つ SmartArt シェイプを検索します。
- SmartArt シェイプに新しい Color Style を設定します。
- プレゼンテーションを保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**SmartArt を単一オブジェクトとしてアニメーション化できますか？**

はい。SmartArt はシェイプなので、他のシェイプと同様にアニメーション API（入場、退出、強調、動作パス）を使用して [standard animations](/slides/ja/cpp/powerpoint-animation/) を適用できます。

**内部 ID がわからない場合、スライド上で特定の SmartArt をどうやって見つけますか？**

代替テキスト (AltText) を設定してその値でシェイプを検索します。これが対象シェイプを特定する推奨方法です。

**SmartArt を他のシェイプとグループ化できますか？**

はい。SmartArt を画像やテーブルなど他のシェイプとグループ化でき、その後 [group](/slides/ja/cpp/group/) を操作できます。

**特定の SmartArt の画像（プレビューやレポート用など）を取得するには？**

シェイプのサムネイル/画像をエクスポートします。ライブラリは個別シェイプを [render individual shapes](/slides/ja/cpp/create-shape-thumbnails/) してラスターファイル (PNG/JPG/TIFF) に出力できます。

**プレゼンテーション全体を PDF に変換したとき、SmartArt の外観は保持されますか？**

はい。レンダリング エンジンは [PDF export](/slides/ja/cpp/convert-powerpoint-to-pdf/) の高忠実度を目指しており、品質や互換性のオプションが豊富に用意されています。