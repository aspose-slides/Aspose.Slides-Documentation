---
title: C++ を使用してプレゼンテーションのチャート凡例をカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/cpp/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してチャート凡例をカスタマイズし、カスタマイズされた凡例書式で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides は PowerPoint プレゼンテーション内のチャート凡例をカスタマイズするためのオプションを提供します。本記事では、凡例の位置とサイズの設定方法、凡例全体のフォントサイズの設定方法、個々の凡例エントリへの書式設定の適用方法を示します。

また、FAQ では、凡例のためにプロット領域の余白を確保する非オーバーレイモードの使用、長い凡例ラベルの自動折り返しや改行の使用、明示的なテキストや塗りつぶし設定を行わない場合に凡例の書式がプレゼンテーションのテーマから継承されるといった関連する動作についても説明しています。

## **凡例の配置**
凡例のプロパティを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、チャート凡例の位置とサイズを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **凡例のフォントサイズを設定する**
Aspose.Slides for C++ を使用すると、開発者は凡例のフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **個々の凡例のフォントサイズを設定する**
Aspose.Slides for C++ を使用すると、開発者は個々の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**凡例を有効にして、チャートが凡例の上に重ねるのではなく自動的にスペースを確保するようにできますか？**

はい。非オーバーレイモード（[set_Overlay(false)](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/legend/set_overlay/)）を使用します。この場合、プロット領域は凡例を収めるように縮小されます。

**複数行の凡例ラベルを作成できますか？**

はい。スペースが不足している場合、長いラベルは自動的に折り返されます。また、シリーズ名に改行文字を入れることで強制的な改行もサポートされます。

**凡例をプレゼンテーションのテーマの配色に従わせるにはどうすればよいですか？**

凡例やテキストに明示的な色・塗りつぶし・フォントを設定しないでください。そうすると、テーマから継承され、デザインが変更された際にも正しく更新されます。