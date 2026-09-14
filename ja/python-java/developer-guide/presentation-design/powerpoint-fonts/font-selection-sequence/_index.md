---
title: Aspose.Slides for Python via Java におけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/python-java/font-selection-sequence/
keywords:
- フォント選択
- フォント代替
- フォント置換
- 代替規則
- 利用可能なフォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java がフォントを選択する方法を探り、PPT、PPTX、ODP ファイルの鮮明で一貫したプレゼンテーションを実現し、スライドを今すぐ改善しましょう。"
---
## **概要**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換されるとき、Aspose.Slides はプレゼンテーションで使用されているフォントがオペレーティングシステムに存在するかどうかを確認します。必要なフォントが欠落している場合、Aspose.Slides は PowerPoint が使用するフォントにできるだけ近い代替フォントを選択します。

Aspose.Slides は最初に選択されたフォントをオペレーティングシステムで検索します。フォントが見つかればそれが使用されます。見つからない場合は適切な代替フォントが適用されます。フォント置換規則が[FontSubstRule](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsubstrule/)を介して定義されている場合、これらの規則も考慮されます。

アプリケーションの実行時にフォントを追加したり、プレゼンテーションから埋め込みフォントを使用したり、PDF ファイルなどの出力ドキュメント用に外部フォントをロードしたりすることもできます。

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換されるとき、フォントには特定の規則が適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとする場合、選択されたフォントがオペレーティングシステムに存在するかどうかが確認されます。フォントが欠落していることが確認された場合、置換されます — 詳細は[Font Replacement](/slides/ja/python-java/font-replacement/) と[Font Substitution](/slides/ja/python-java/font-substitution/) を参照してください。

以下は、Aspose.Slides がフォントを処理する際の手順です：

1. Aspose.Slides はオペレーティングシステム内のフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを見つけます。
2. 選択されたフォントが見つかれば Aspose.Slides はそれを使用します。見つからない場合、Aspose.Slides は PowerPoint が使用するフォントにできるだけ近い代替フォントを使用します。
3. フォント置換規則が[FontSubstRule](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsubstrule/)を通じて設定されている場合、それらが適用されます。

Aspose.Slides はアプリケーションの実行時にフォントを追加し、それらのフォントを使用できるようにします。[Custom fonts](/slides/ja/python-java/custom-font/) を参照してください。

プレゼンテーション内に追加フォントが配置されている場合、それらは[Embedded fonts](/slides/ja/python-java/embedded-font/) と呼ばれます。

Aspose.Slides は出力ドキュメントに *のみ* 適用されるフォントを追加できるようにします。たとえば、PDF に変換しようとしているプレゼンテーションがシステムにインストールされておらず、プレゼンテーションにも埋め込まれていないフォントを使用している場合、必要なフォントを **external fonts** として追加またはロードできます。

{{% alert title="Note" color="info" %}}
有料でも無料でもフォントは配布していません。当社の API は外部フォントをロードし、ドキュメントに埋め込むことを可能にしますが、これらはすべてご自身の裁量と責任で行ってください。
{{% /alert %}}

## **FAQ**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように確認できますか？**

Aspose.Slides は[font manager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) を使用して使用されているフォントを検査できるため、[embed](/slides/ja/python-java/embedded-font/)、[replace](/slides/ja/python-java/font-replacement/)、または[external sources](/slides/ja/python-java/custom-font/) を追加するかを判断できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

**フォントディレクトリをオペレーティングシステムにインストールせずに追加できますか？**

はい。フォルダーやメモリ内ストリームなどの[external font sources](/slides/ja/python-java/custom-font/) を登録して、レンダリングやエクスポートに使用できます。これによりホストシステムのフォントへの依存がなくなり、レイアウトを予測可能に保てます。

**文字グリフが欠落しているときに不適切なフォントへの自動フォールバックを防ぐにはどうすればよいですか？**

事前に明示的な[font replacement](/slides/ja/python-java/font-replacement/) とフォント[fallback rules](/slides/ja/python-java/fallback-font/) を定義します。使用しているフォントを分析し、代替フォントの優先順位を制御して設定することで、タイポグラフィを一貫させ、予期しない結果を回避できます。