---
title: Aspose.Slides for C++ のフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/cpp/font-selection-sequence/
keywords:
- フォント選択
- フォント代替
- フォント置換
- 代替ルール
- 利用可能なフォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ がフォントを選択する方法を学び、PPT、PPTX、ODP ファイルの鮮明で一貫した表示を実現し、スライドを今すぐ改善しましょう。"
---
## **概要**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換されると、Aspose.Slides はプレゼンテーションで使用されているフォントがオペレーティングシステムに存在するかどうかをチェックします。必要なフォントが存在しない場合、Aspose.Slides は PowerPoint が使用するものにできるだけ近い代替フォントを選択します。

Aspose.Slides は最初にオペレーティングシステム内で選択されたフォントを検索します。フォントが見つかればそれが使用されます。見つからない場合は適切な代替フォントが適用されます。`FontSubstRule` を使用してフォント置換ルールが定義されている場合、これらのルールも考慮されます。

アプリケーションの実行時にフォントを追加したり、プレゼンテーションから埋め込みフォントを使用したり、PDF ファイルなどの出力ドキュメント用に外部フォントをロードしたりすることもできます。

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際、フォントには特定のルールが適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとする場合、プレゼンテーションのフォントがチェックされ、選択されたフォントがオペレーティングシステムに存在するかが確認されます。フォントが存在しないことが確認された場合、置換されます — 詳細は[**Font Replacement**](https://docs.aspose.com/slides/ja/cpp/font-replacement/) および [**Font Substitution**](https://docs.aspose.com/slides/ja/cpp/font-substitution/) を参照してください。

フォントを扱う際に Aspose.Slides が従うプロセスは次のとおりです：
1. Aspose.Slides はオペレーティングシステム内でフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを探します。  
2. 選択されたフォントが見つかれば Aspose.Slides はそれを使用します。見つからない場合、PowerPoint が使用するものにできるだけ近い代替フォントを使用します。  
3. フォント置換ルールが[FontSubstRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsubstrule/) を通じて設定されている場合、それらが適用されます。  

Aspose.Slides はアプリケーション実行時にフォントを追加し、それらのフォントを使用できるようにします。詳しくは[**Custom fonts**](https://docs.aspose.com/slides/ja/cpp/custom-font/) をご覧ください。

プレゼンテーション内に追加のフォントが配置されている場合、それらは[**Embedded fonts**](https://docs.aspose.com/slides/ja/cpp/embedded-font/) と呼ばれます。

Aspose.Slides は*出力ドキュメントのみに*適用されるフォントを追加できます。たとえば、PDF に変換しようとしているプレゼンテーションにシステムおよび埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを **外部フォント** として追加またはロードできます。

{{% alert title="Note" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。当社の API は外部フォントをロードしてドキュメントに埋め込むことを可能にしますが、フォントの使用はお客様の裁量と責任で行ってください。
{{% /alert %}}

## **よくある質問**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように特定できますか？**

Aspose.Slides は[font manager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_fontsmanager/) を介して使用されているフォントを検査できるため、[埋め込み](/slides/ja/cpp/embedded-font/)、[置換](/slides/ja/cpp/font-replacement/)、または[外部ソース](/slides/ja/cpp/custom-font/) を追加するかを判断できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

**フォントディレクトリを追加して、OS にインストールせずに使用できますか？**

はい。レンダリングおよびエクスポート用に、フォルダーやメモリ ストリームなどの[外部フォントソース](/slides/ja/cpp/custom-font/) を登録できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**グリフが欠落している場合に不適切なフォントへの無音フォールバックを防ぐにはどうすればよいですか？**

事前に明示的な[フォント置換](/slides/ja/cpp/font-replacement/) とフォント[フォント フォールバック ルール](/slides/ja/cpp/fallback-font/) を定義します。使用されているフォントを分析し、代替フォントの優先順位を制御して設定することで、一貫したタイポグラフィを確保し、予期しない結果を回避できます。