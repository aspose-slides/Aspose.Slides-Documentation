---
title: .NET 用 Aspose.Slides におけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/net/font-selection-sequence/
keywords:
- フォント選択
- フォント置換
- フォント置換
- 置換規則
- 利用可能なフォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET がフォントを選択する方法を解明し、PPT、PPTX、ODP ファイルの鮮明で一貫した表示を実現します—今すぐスライドを改善しましょう。"
---
## **概要**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際、Aspose.Slides はプレゼンテーションで使用されているフォントがオペレーティングシステムに存在するかどうかを確認します。必要なフォントが不足している場合、Aspose.Slides は PowerPoint が使用するフォントにできるだけ近い代替フォントを選択します。

Aspose.Slides はまず、オペレーティングシステム内で選択されたフォントを検索します。フォントが見つかればそれを使用します。見つからない場合は適切な代替フォントが適用されます。`FontSubstRule` を使用してフォント置換規則が定義されている場合、これらの規則も考慮されます。

アプリケーションの実行時にフォントを追加したり、プレゼンテーションから埋め込みフォントを使用したり、PDF ファイルなどの出力ドキュメント用に外部フォントをロードしたりすることもできます。

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際、フォントには特定の規則が適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとすると、プレゼンテーションのフォントがオペレーティングシステムに存在するかどうかが確認されます。フォントが欠落していることが確認された場合、置換されます — 詳細は[**Font Replacement**](https://docs.aspose.com/slides/ja/net/font-replacement/) と [**Font Substitution**](https://docs.aspose.com/slides/ja/net/font-substitution/) を参照してください。

Aspose.Slides がフォントを扱う際の手順は次のとおりです：

1. Aspose.Slides はオペレーティングシステムでフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを探します。  
2. 選択されたフォントが見つかれば Aspose.Slides はそれを使用します。見つからない場合、Aspose.Slides は PowerPoint が使用するフォントにできるだけ近い代替フォントを使用します。  
3. フォント置換規則が [FontSubstRule](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsubstrule/) を通じて設定されている場合、それらが適用されます。  

Aspose.Slides はアプリケーションの実行時にフォントを追加し、そのフォントを使用できるようにします。 詳細は[**Custom fonts**](https://docs.aspose.com/slides/ja/net/custom-font/) を参照してください。

プレゼンテーション内に追加のフォントが配置されている場合、これらは[**Embedded fonts**](https://docs.aspose.com/slides/ja/net/embedded-font/) と呼ばれます。

Aspose.Slides は *出力ドキュメントにのみ* 適用されるフォントを追加できるようにします。たとえば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを **外部フォント** として追加またはロードできます。

{{% alert title="Note" color="info" %}} 
当社は有料・無料を問わずフォントを配布していません。API は外部フォントをロードしてドキュメントに埋め込むことを可能にしますが、フォントの使用はお客様の裁量と責任で行ってください。 
{{% /alert %}}

## **FAQ**

### 変換前にプレゼンテーションで実際に使用されているフォントをどのように判断できますか？

Aspose.Slides は [font manager](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/fontsmanager/) を使用して使用されているフォントを検査できるため、[embed](/slides/ja/net/embedded-font/)、[replace](/slides/ja/net/font-replacement/)、または [external sources](/slides/ja/net/custom-font/) を追加するかを判断できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

### フォントをオペレーティングシステムにインストールせずに、追加のフォントディレクトリを追加できますか？

はい。フォルダーやメモリ内ストリームなどの [external font sources](/slides/ja/net/custom-font/) を登録して、レンダリングやエクスポートに利用できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

### グリフが欠落している場合に不適切なフォントへのサイレントフォールバックを防ぐにはどうすればよいですか？

事前に明示的な [font replacement](/slides/ja/net/font-replacement/) とフォント [fallBack rules](/slides/ja/net/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御して設定することで、一貫したタイポグラフィを確保し、予期しない結果を回避できます。