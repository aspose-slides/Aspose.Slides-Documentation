---
title: C++ を使用したプレゼンテーション チャートのエラーバーのカスタマイズ
linktitle: エラーバー
type: docs
url: /ja/cpp/error-bar/
keywords:
- エラーバー
- カスタム値
- PowerPoint
- プレゼンテーション
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ を使用して、チャートにエラーバーを追加およびカスタマイズする方法を学び、PowerPoint プレゼンテーションのデータ可視化を最適化します。"
---

## **エラーバーの追加**
Aspose.Slides for C++ はエラーバー値を管理するシンプルな API を提供します。サンプルコードはカスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの **DataPoints** コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 目的のスライドにバブル チャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X フォーマットを設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y フォーマットを設定します。
1. バーの値とフォーマットを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **カスタム エラーバーの追加**
Aspose.Slides for C++ はカスタム エラーバー値を管理するシンプルな API を提供します。サンプルコードは **IErrorBarsFormat.ValueType** プロパティが **Custom** に等しい場合に適用されます。値を指定するには、シリーズの **DataPoints** コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 目的のスライドにバブル チャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X フォーマットを設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y フォーマットを設定します。
1. チャート系列の個々のデータ ポイントにアクセスし、個別の系列データ ポイントのエラーバー値を設定します。
1. バーの値とフォーマットを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**プレゼンテーションを PDF や画像にエクスポートするとき、エラーバーはどうなりますか？**

互換性のあるバージョンまたはレンダラーがある限り、エラーバーはチャートの一部としてレンダリングされ、変換中にチャートの他の書式設定と同様に保持されます。

**エラーバーをマーカーやデータ ラベルと組み合わせることはできますか？**

はい。エラーバーは別個の要素であり、マーカーやデータ ラベルと互換性があります。要素が重なる場合は、書式設定を調整する必要がある場合があります。

**API でエラーバーを操作するためのプロパティと列挙体の一覧はどこで確認できますか？**

API リファレンスで確認できます: [ErrorBarsFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarsformat/) クラスと、関連する列挙体 [ErrorBarType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbartype/) および [ErrorBarValueType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarvaluetype/)。