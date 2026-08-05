---
title: C++ を使用したプレゼンテーション チャートの誤差棒のカスタマイズ
linktitle: 誤差棒
type: docs
url: /ja/cpp/error-bar/
keywords:
- 誤差棒
- カスタム値
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してチャートに誤差棒を追加およびカスタマイズする方法を学び、PowerPoint プレゼンテーションのデータ ビジュアルを最適化しましょう。"
---
## **概要**

この記事では、Aspose.Slides を使用してプレゼンテーション チャートで誤差棒を操作する方法を説明します。誤差棒をチャート系列に追加し、X および Y の誤差棒設定を構成し、固定、パーセンテージ、カスタム値などのさまざまな値タイプを適用する方法を示します。

また、該当するデータ ポイント コレクションを使用して系列内の個々のデータ ポイントにカスタム誤差棒値を割り当てる方法も示します。さらに、誤差棒のエクスポート時の動作、マーカーやデータ ラベルとの互換性、および関連する API リファレンス クラスと列挙体の場所に関する簡潔なメモが含まれています。

## **誤差棒の追加**
Aspose.Slides for C++ は、誤差棒値を管理するためのシンプルな API を提供します。サンプルコードはカスタム値タイプを使用する場合に適用されます。値を指定するには、系列の **DataPoints** コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 目的のスライドにバブル チャートを追加します。
3. 最初のチャート系列にアクセスし、誤差棒 X の書式を設定します。
4. 最初のチャート系列にアクセスし、誤差棒 Y の書式を設定します。
5. 棒の値と書式を設定します。
6. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **カスタム誤差棒の追加**
Aspose.Slides for C++ は、カスタム誤差棒値を管理するためのシンプルな API を提供します。サンプルコードは **IErrorBarsFormat.ValueType** プロパティが **Custom** に等しい場合に適用されます。値を指定するには、系列の **DataPoints** コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 目的のスライドにバブル チャートを追加します。
3. 最初のチャート系列にアクセスし、誤差棒 X の書式を設定します。
4. 最初のチャート系列にアクセスし、誤差棒 Y の書式を設定します。
5. チャート系列の個々のデータ ポイントにアクセスし、特定の系列データ ポイントの誤差棒値を設定します。
6. 棒の値と書式を設定します。
7. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **よくある質問**

**プレゼンテーションを PDF や画像にエクスポートするとき、誤差棒はどうなりますか？**

誤差棒はチャートの一部として描画され、互換性のあるバージョンまたはレンダラーが使用されている限り、変換時にチャート全体の書式とともに保持されます。

**誤差棒はマーカーやデータ ラベルと組み合わせることができますか？**

はい。誤差棒は別個の要素であり、マーカーやデータ ラベルと互換性があります。要素が重なる場合は、書式を調整する必要があるかもしれません。

**API で誤差棒を操作するためのプロパティと列挙体の一覧はどこで確認できますか？**

API リファレンスで確認できます。[ErrorBarsFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/errorbarsformat/) クラスと、関連する列挙体 [ErrorBarType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/errorbartype/) および [ErrorBarValueType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/errorbarvaluetype/) が該当します。