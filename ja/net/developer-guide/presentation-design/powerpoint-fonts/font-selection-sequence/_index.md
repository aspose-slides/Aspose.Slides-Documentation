---
title: Aspose.Slides for .NET におけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/net/font-selection-sequence/
keywords:
- フォント選択
- フォント代替
- フォント置換
- 代替ルール
- 利用可能フォント
- 欠損フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET がフォントを選択する方法を解説し、PPT、PPTX、ODP ファイルの鮮明で一貫したプレゼンテーションを実現します—今すぐスライドを改善しましょう。"
---
## **概要**

プレゼンテーションが読み込まれ、描画され、または別の形式に変換される際、Aspose.Slides は埋め込みフォントとアプリケーションで利用可能なフォントを考慮します。必要なフォントが利用できない場合、Aspose.Slides は PowerPoint が使用するフォントにできるだけ近い置換フォントを選択します。

利用可能なフォントには、システムフォント、アプリケーションがロードしたフォント、およびプレゼンテーションに埋め込まれたフォントが含まれます。埋め込みフォントと登録済みフォントが一致する場合、以下で説明する .NET 26.11 の設定が優先順位を制御します。[FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) で定義されたフォント置換ルールは別のメカニズムです。

アプリケーションの実行時にフォントを追加したり、プレゼンテーションから埋め込みフォントを使用したり、PDF ファイルなどの出力文書用に外部フォントをロードすることもできます。

## **フォント選択**

テキストは、明示的なファミリ名ではなく `+mn-lt` のようなテーマフォントを参照できます。適用されるテーマによって指定されたファミリを取得するには、[テーマフォント参照の解決](/slides/ja/net/presentation-theme/#resolve-theme-font-references) を参照してください。その参照の解決は、フォントの利用可否の確認や描画時の置換・グリフフォールバックの適用とは別で、最終的にテキストを描画するフォントファイルを特定するものではありません。

スライドを描画する際やプレゼンテーションを変換する際は、要求されたフォントが埋め込まれているか、登録済みのソースから利用可能かを確認してください。フォントが不足している場合は置換または代替が必要になることがあります。詳しくは[**フォント置換**](/slides/ja/net/font-replacement/) と[**フォント代替**](/slides/ja/net/font-substitution/) を参照してください。

フォント選択を調査する際は：

1. テーマ参照を含む要求されたファミリとスタイルを解決する。
2. 埋め込みフォントと登録済みソース（システムフォントやアプリケーションがロードしたフォント）を確認する。埋め込みと登録のバージョンが競合する場合は、以下の設定を使用する。
3. 要求されたフォントまたは文字が利用できない場合、[フォント置換ルール](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) とグリフフォールバックを確認する。

Aspose.Slides では、アプリケーションの実行時にフォントを追加し、それらのフォントを使用できます。[**カスタムフォント**](/slides/ja/net/custom-font/) を参照してください。

プレゼンテーション内に追加のフォントが配置されている場合、それらは [**埋め込みフォント**](/slides/ja/net/embedded-font/) と呼ばれます。

Aspose.Slides は、*出力文書のみに* 適用されるフォントを追加することができます。たとえば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントにないフォントが含まれている場合、必要なフォントを **外部フォント** として追加またはロードできます。

{{% alert title="Note" color="info" %}} 
当社は有料・無料を問わずフォントを配布していません。当社の API は外部フォントをロードし文書に埋め込むことを可能にしますが、フォントの使用はお客様の裁量と責任で行ってください。
{{% /alert %}}

## **登録済みフォントを埋め込みフォントより優先**

.NET 26.11 以降、[IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) により、エクスポート時に一致する登録済みフォントが埋め込みフォントより優先されます。デフォルトは `false` です。マッチングはフォント名とスタイルで行われ、異なるファミリ名は置換マッチとはみなされません。登録済みフォントはシステムから、または[明示的にロードされたフォントソース](/slides/ja/net/custom-font/) から取得できます。

以下の例は .NET 8 上で **Aspose.Slides.NET6.CrossPlatform 26.11** パッケージを使用しています。環境に合わせて [インストール ガイド](/slides/ja/net/installation/) に従ってください。埋め込みフォントを含む `embedded-fonts.pptx` と、同じファミリ名とスタイルの `preferred.ttf` を用意します。出力を比較したい場合は、2 つのフォントファイルが見た目で異なるようにしてください。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

この設定はエクスポート時のフォント優先順位を変更しますが、テキストのフォント名を変更したり、埋め込みフォントデータを削除したり、登録済みファイルを再埋め込みしたりはしません。これは実行時設定であり、プレゼンテーションを再度開いた後でも再設定が必要です。一致する登録済みフォントが存在しない場合、設定を有効にしてもフォントは提供されません。対象環境で、結果として得られるフォントとレイアウトを確認してください。

上記設定で明示的にロードした通常フォントを使用した PNG と PDF の出力を確認しました。同一結果を前提にする前に、使用するフォントファイル、スタイル、SDK ビルド、出力形式を確認してください。フォントメトリックは改行や位置に影響を与える可能性があります。別のファミリが必要な場合は [フォント置換](/slides/ja/net/font-replacement/) または [代替](/slides/ja/net/font-substitution/) を使用し、プレゼンテーションに保存されているフォントを変更する必要がある場合は [埋め込みフォント操作](/slides/ja/net/embedded-font/) を使用してください。

## **よくある質問**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように判断できますか？**

Aspose.Slides は [フォントマネージャ](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) を通じて使用されているフォントを検査できるため、[埋め込み](/slides/ja/net/embedded-font/)、[置換](/slides/ja/net/font-replacement/)、または [外部ソース](/slides/ja/net/custom-font/) の追加を判断できます。これにより、描画やエクスポート時の不要な置換を防止できます。

**オペレーティングシステムにインストールせずに、追加のフォントディレクトリを追加できますか？**

はい。フォルダーやメモリストリームなどの [外部フォントソース](/slides/ja/net/custom-font/) を登録して、描画やエクスポートに使用できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**グリフが欠如している場合に不適切なフォントへのサイレントフォールバックを防ぐにはどうすればよいですか？**

事前に明示的な [フォント置換](/slides/ja/net/font-replacement/) とフォント [フォールバック ルール](/slides/ja/net/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御することで、一貫したタイポグラフィを実現し、予期しない結果を回避できます。