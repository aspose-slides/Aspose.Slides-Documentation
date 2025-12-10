---
title: C++ を使用したプレゼンテーションチャートのコールアウト管理
linktitle: コールアウト
type: docs
url: /ja/cpp/callout/
keywords:
- チャート コールアウト
- コールアウトの使用
- データ ラベル
- ラベル フォーマット
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でコールアウトを作成・スタイル設定し、簡潔なコード例で PPT および PPTX に対応し、プレゼンテーションのワークフローを自動化します。"
---

## **コールアウトの使用**
新しいプロパティ **ShowLabelAsDataCallout** が **DataLabelFormat** クラスと **IDataLabelFormat** インターフェイスに追加されました。このプロパティは、指定したチャートのデータ ラベルをデータ コールアウトとして表示するかデータ ラベルとして表示するかを決定します。以下の例では、コールアウトを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **ドーナツチャートのコールアウトを設定する**
Aspose.Slides for C++ は、ドーナツチャートの系列データ ラベル コールアウト シェイプを設定する機能を提供します。以下にサンプル例を示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **よくある質問**

**プレゼンテーションを PDF、HTML5、SVG、または画像に変換した場合、コールアウトは保持されますか？**

はい。コールアウトはチャートの描画の一部であるため、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[HTML5](/slides/ja/cpp/export-to-html5/)、[SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/)、または[raster images](/slides/ja/cpp/convert-powerpoint-to-png/)へエクスポートすると、スライドの書式設定とともに保持されます。

**カスタム フォントはコールアウトで機能しますか？また、エクスポート時に外観を保持できますか？**

はい。Aspose.Slides は、プレゼンテーションに[embedding fonts](/slides/ja/cpp/embedded-font/)を埋め込むことをサポートしており、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) などへのエクスポート時にフォント埋め込みを制御します。これにより、異なるシステム間でもコールアウトの外観が同じまま保持されます。