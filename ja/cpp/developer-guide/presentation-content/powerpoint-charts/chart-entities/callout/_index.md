---
title: C++ を使用したプレゼンテーション チャートの呼び出し線の管理
linktitle: 呼び出し線
type: docs
url: /ja/cpp/callout/
keywords:
- チャート 呼び出し線
- 呼び出し線 の 使用
- データ ラベル
- ラベル フォーマット
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で呼び出し線を作成・スタイル設定し、簡潔なコード例を使用して PPT および PPTX と互換性があり、プレゼンテーションのワークフローを自動化します。"
---
## **概要**

この記事では、Aspose.Slides のチャート データ ラベルの呼び出し線（callout）の操作方法を説明します。`set_ShowLabelAsDataCallout` メソッドを使用してラベルを呼び出し線として表示する方法、ドーナツ チャートの呼び出し線関連ラベル設定の構成方法、そしてプレゼンテーションを PDF、HTML5、SVG、ラスター画像形式へエクスポートした場合でも呼び出し線とその外観が保持されることについて説明します。

## **呼び出し線の使用**
**DataLabelFormat** クラスと **IDataLabelFormat** インターフェイスに新しいプロパティ **ShowLabelAsDataCallout** が追加され、指定されたチャートのデータ ラベルをデータ呼び出し線として表示するかデータ ラベルとして表示するかを決定できます。以下の例では、呼び出し線を設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **ドーナツ チャートの呼び出し線の設定**
Aspose.Slides for C++ は、ドーナツ チャートの系列データ ラベル呼び出し線の形状設定をサポートしています。以下にサンプル例を示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**プレゼンテーションを PDF、HTML5、SVG、または画像に変換するときに呼び出し線は保持されますか？**

はい。呼び出し線はチャートの描画の一部であるため、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[HTML5](/slides/ja/cpp/export-to-html5/)、[SVG](/slides/ja/cpp/render-a-slide-as-an-svg-image/)、または[ラスター画像](/slides/ja/cpp/convert-powerpoint-to-png/)へエクスポートした場合でも、スライドの書式と共に保持されます。

**カスタム フォントは呼び出し線で使用でき、エクスポート時に外観が保持されますか？**

はい。Aspose.Slides はプレゼンテーションへの[フォント埋め込み](/slides/ja/cpp/embedded-font/)をサポートしており、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) などへのエクスポート時にフォント埋め込みを制御することで、異なるシステム間でも呼び出し線の外観が同じになるようにします。