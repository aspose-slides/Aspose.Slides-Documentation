---
title: Aspose.Slides for Android via Java におけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/androidjava/font-selection-sequence/
keywords:
- フォント選択
- フォント代替
- フォント置換
- 置換ルール
- 利用可能なフォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java がフォントを選択し、PPT、PPTX、ODP ファイルの鮮明で一貫した表示を実現します—今すぐスライドを改善しましょう。"
---
## **概要**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際、Aspose.Slides はプレゼンテーションで使用されているフォントがオペレーティングシステムに存在するかどうかをチェックします。必要なフォントが見つからない場合、Aspose.Slides は PowerPoint が使用するものにできるだけ近い代替フォントを選択します。

Aspose.Slides はまずオペレーティングシステム内で選択されたフォントを検索します。フォントが見つかればそれを使用します。見つからない場合は適切な代替フォントが適用されます。`FontSubstRule` でフォント置換ルールが定義されている場合、これらのルールも考慮されます。

アプリケーション実行時にフォントを追加したり、プレゼンテーションに埋め込まれたフォントを使用したり、PDF ファイルなどの出力ドキュメント用に外部フォントをロードすることもできます。

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際、フォントには特定の規則が適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとする場合、プレゼンテーションのフォントがオペレーティングシステムに存在するかどうかが確認されます。フォントが欠落していることが判明した場合、置き換えられます — 参照 [**フォント置換**](https://docs.aspose.com/slides/ja/androidjava/font-replacement/) および [**フォント代替**](https://docs.aspose.com/slides/ja/androidjava/font-substitution/)。

フォントを処理する際の Aspose.Slides の手順は次のとおりです：

1. Aspose.Slides はオペレーティングシステム内のフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを探します。  
2. 選択されたフォントが見つかれば Aspose.Slides はそれを使用します。見つからない場合は、PowerPoint が使用するものにできるだけ近い代替フォントが使用されます。  
3. [FontSubstRule](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsubstrule/) でフォント置換ルールが設定されている場合、それらが適用されます。

Aspose.Slides では、アプリケーション実行時にフォントを追加してそれらを使用できます。参照 [**カスタムフォント**](https://docs.aspose.com/slides/ja/androidjava/custom-font/)。

プレゼンテーション内に追加のフォントが配置されている場合、それらは [**埋め込みフォント**](https://docs.aspose.com/slides/ja/androidjava/embedded-font/) と呼ばれます。

Aspose.Slides は、*出力ドキュメントのみに* 適用されるフォントを追加することも可能です。たとえば、PDF に変換しようとしているプレゼンテーションに、システムや埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを **external fonts** として追加またはロードできます。

{{% alert title="Note" color="info" %}} 
当社は有料・無料を問わずフォントを配布していません。当社の API を使用すると外部フォントをロードしてドキュメントに埋め込むことができますが、フォントの使用はお客様の裁量と責任で行ってください。 
{{% /alert %}}

## **FAQ**

### 変換前にプレゼンテーションで実際に使用されているフォントをどのように確認できますか？

Aspose.Slides は [font manager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsmanager/) を使用して使用されているフォントを検査できるため、[embed](/slides/ja/androidjava/embedded-font/)、[replace](/slides/ja/androidjava/font-replacement/)、または [external sources](/slides/ja/androidjava/custom-font/) を追加するかを決定できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

### オペレーティングシステムにインストールせずに、追加のフォントディレクトリを追加できますか？

はい。フォルダーやインメモリ ストリームなどの [external font sources](/slides/ja/androidjava/custom-font/) を登録して、レンダリングやエクスポートに使用できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

### グリフが欠落している場合に、不適切なフォントへの無音フォールバックを防ぐにはどうすればよいですか？

事前に明示的な [font replacement](/slides/ja/androidjava/font-replacement/) とフォント [fallback rules](/slides/ja/androidjava/fallback-font/) を定義します。使用されているフォントを分析し、代替フォントの優先順位を制御して設定することで、一貫したタイポグラフィを確保し、予期しない結果を回避できます。