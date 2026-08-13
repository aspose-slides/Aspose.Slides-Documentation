---
title: Aspose.Slides for Java におけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/java/font-selection-sequence/
keywords:
- フォント選択
- フォント置換
- フォント差し替え
- 置換ルール
- 利用可能なフォント
- 不足フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java がフォントを選択する方法を解説し、PPT、PPTX、ODP ファイルの鮮明で一貫した表示を実現します—今すぐスライドを改善しましょう。"
---
## **概要**

プレゼンテーションがロード、レンダリング、または別の形式に変換されるとき、Aspose.Slides はプレゼンテーションで使用されているフォントがオペレーティングシステムに存在するかどうかをチェックします。必要なフォントが欠落している場合、Aspose.Slides は PowerPoint が使用するフォントにできるだけ近い代替フォントを選択します。

Aspose.Slides はまず、選択されたフォントをオペレーティングシステムで検索します。フォントが見つかればそれが使用されます。見つからない場合は適切な代替フォントが適用されます。`FontSubstRule` を使用してフォント置換ルールが定義されている場合、これらのルールも考慮されます。

アプリケーションの実行時にフォントを追加したり、プレゼンテーションから埋め込みフォントを使用したり、PDF ファイルなどの出力ドキュメント用に外部フォントをロードしたりすることもできます。

## **フォント選択**

プレゼンテーションがロード、レンダリング、または別の形式に変換される際、フォントには特定のルールが適用されます。例えば、プレゼンテーション（スライド）を画像に変換しようとする場合、プレゼンテーションのフォントがチェックされ、選択されたフォントがオペレーティングシステムに存在するかが確認されます。フォントが欠落していることが確認された場合、置換されます — 詳細は[**Font Replacement**](https://docs.aspose.com/slides/ja/java/font-replacement/)および[**Font Substitution**](https://docs.aspose.com/slides/ja/java/font-substitution/)をご覧ください。

フォントを扱う際の Aspose.Slides のプロセスは次のとおりです：

1. Aspose.Slides はオペレーティングシステムでフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを見つけます。  
2. 選択されたフォントが見つかれば Aspose.Slides はそれを使用します。見つからない場合、Aspose.Slides は PowerPoint が使用するものにできるだけ近い代替フォントを使用します。  
3. [FontSubstRule](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstrule/) を使用してフォント置換ルールが設定されている場合、これらが適用されます。  

Aspose.Slides はアプリケーション実行時にフォントを追加し、そのフォントを使用できるようにします。[**Custom fonts**](https://docs.aspose.com/slides/ja/java/custom-font/) を参照してください。

プレゼンテーション内に追加のフォントが配置されている場合、それらは[**Embedded fonts**](https://docs.aspose.com/slides/ja/java/embedded-font/) と呼ばれます。

Aspose.Slides は*出力ドキュメントのみ*に適用されるフォントを追加できます。例えば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントにないフォントが含まれている場合、必要なフォントを **external fonts** として追加またはロードできます。

{{% alert title="Note" color="info" %}} 
有料・無料を問わず、当社はフォントを配布していません。API では外部フォントをロードしドキュメントに埋め込むことが可能ですが、フォントの使用はお客様の裁量と責任で行う必要があります。 
{{% /alert %}}

## **FAQ**

### 変換前にプレゼンテーションで実際に使用されているフォントをどのように確認できますか？

Aspose.Slides は [font manager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsmanager/) を通じて使用されているフォントを検査できるため、[embed](/slides/ja/java/embedded-font/)、[replace](/slides/ja/java/font-replacement/)、または[external sources](/slides/ja/java/custom-font/) を追加するかを判断できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

### フォントをオペレーティングシステムにインストールせずに、追加のフォントディレクトリを追加できますか？

はい。フォルダーやメモリ内ストリームなどの[external font sources](/slides/ja/java/custom-font/) を登録して、レンダリングやエクスポートに使用できます。これによりホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

### グリフが欠落している場合に不適切なフォントへの無音フォールバックを防ぐには？

事前に明示的な[font replacement](/slides/ja/java/font-replacement/) とフォント[fallback rules](/slides/ja/java/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御して設定することで、一貫したタイポグラフィを確保し、予期しない結果を回避できます。