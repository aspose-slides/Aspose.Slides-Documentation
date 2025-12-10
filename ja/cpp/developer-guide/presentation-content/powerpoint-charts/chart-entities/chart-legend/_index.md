---
title: C++ を使用したプレゼンテーションのチャート凡例のカスタマイズ
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
description: "Aspose.Slides for C++ を使用してチャート凡例をカスタマイズし、PowerPoint プレゼンテーションを調整された凡例フォーマットで最適化します。"
---

## **凡例の位置指定**
凡例のプロパティを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、チャートの凡例の位置とサイズを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}


## **凡例のフォントサイズを設定する**
Aspose.Slides for C++ では、開発者が凡例のフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}




## **個々の凡例エントリのフォントサイズを設定する**
Aspose.Slides for C++ では、開発者が個々の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**凡例を有効にして、チャートが凡例の上に重ねるのではなく自動的にスペースを確保するようにできますか？**

はい。非オーバーレイモード（[set_Overlay(false)](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/)）を使用します。この場合、プロット領域が縮小して凡例を収容します。

**凡例のラベルを複数行にできますか？**

はい。スペースが不足すると長いラベルは自動的に折り返されます。改行文字（\n）をシリーズ名に入れることで、強制的に改行することも可能です。

**凡例をプレゼンテーションのテーマのカラースキームに合わせるにはどうすればよいですか？**

凡例やそのテキストに明示的な色・塗りつぶし・フォントを設定しないでください。テーマから継承され、デザインが変更されても正しく更新されます。