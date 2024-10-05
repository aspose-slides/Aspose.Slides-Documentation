---
title: エラーバー
type: docs
url: /cpp/error-bar/
---

## **エラーバーの追加**
Aspose.Slides for C++は、エラーバーの値を管理するためのシンプルなAPIを提供します。サンプルコードは、カスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの**DataPoints**コレクション内の特定のデータポイントの**ErrorBarCustomValues**プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. 希望するスライドにバブルチャートを追加します。
1. 最初のチャートシリーズにアクセスし、エラーバーX形式を設定します。
1. 最初のチャートシリーズにアクセスし、エラーバーY形式を設定します。
1. バーの値と形式を設定します。
1. 変更されたプレゼンテーションをPPTXファイルに書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **カスタムエラーバーの追加**
Aspose.Slides for C++は、カスタムエラーバーの値を管理するためのシンプルなAPIを提供します。サンプルコードは、**IErrorBarsFormat.ValueType**プロパティが**Custom**に等しい場合に適用されます。値を指定するには、シリーズの**DataPoints**コレクション内の特定のデータポイントの**ErrorBarCustomValues**プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. 希望するスライドにバブルチャートを追加します。
1. 最初のチャートシリーズにアクセスし、エラーバーX形式を設定します。
1. 最初のチャートシリーズにアクセスし、エラーバーY形式を設定します。
1. チャートシリーズの個々のデータポイントにアクセスし、個々のシリーズのデータポイントのエラーバー値を設定します。
1. バーの値と形式を設定します。
1. 変更されたプレゼンテーションをPPTXファイルに書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}