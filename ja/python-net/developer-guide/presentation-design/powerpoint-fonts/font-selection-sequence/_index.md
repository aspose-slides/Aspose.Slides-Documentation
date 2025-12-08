---
title: Python を使用したプレゼンテーションにおけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/python-net/font-selection-sequence/
keywords:
- フォント選択
- フォント置換
- フォント代替
- 置換ルール
- 利用可能なフォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET がフォントを選択し、PPT、PPTX、ODP ファイルの鮮明で一貫した表示を実現する方法を発見し、今すぐスライドを改善しましょう。"
---

## **フォントの選択**

プレゼンテーションが読み込まれたり、レンダリングされたり、別の形式に変換されたりする際には、フォントに対して特定のルールが適用されます。例えば、プレゼンテーション（スライド）を画像に変換しようとすると、プレゼンテーションのフォントがチェックされ、選択されたフォントがオペレーティングシステムに存在するかが確認されます。フォントが欠落していることが確認された場合、置き換えられます — 詳細は[**フォント置換**](https://docs.aspose.com/slides/python-net/font-replacement/) と[**フォント代替**](https://docs.aspose.com/slides/python-net/font-substitution/)。

Aspose.Slides がフォントを扱う際のプロセスは以下の通りです：

1. Aspose.Slides はオペレーティングシステム内のフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを探します。  
2. 選択されたフォントが見つかれば Aspose.Slides が使用します。見つからない場合は、PowerPoint が使用するフォントにできるだけ近い置換フォントが使用されます。  
3. フォント置換ルールが [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) で設定されている場合、それらが適用されます。

Aspose.Slides では、アプリケーションの実行時にフォントを追加して使用できます。詳細は[**カスタムフォント**](https://docs.aspose.com/slides/python-net/custom-font/)をご覧ください。

プレゼンテーションに追加のフォントが埋め込まれる場合、それらは [**埋め込みフォント**](https://docs.aspose.com/slides/python-net/embedded-font/) と呼ばれます。

Aspose.Slides は、*出力ドキュメントにのみ* 適用されるフォントを追加できます。例えば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントに存在しないフォントがある場合、必要なフォントを **外部フォント** として追加またはロードできます。

{{% alert title="Note" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。当社の API は外部フォントをロードし、ドキュメントに埋め込むことを可能にしますが、フォントの使用は利用者の裁量と責任において行ってください。
{{% /alert %}}

## **よくある質問**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように判断できますか？**

Aspose.Slides は [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) を使用して使用されているフォントを調査できるため、[埋め込み](/slides/ja/python-net/embedded-font/)、[置換](/slides/ja/python-net/font-replacement/)、または [外部ソース](/slides/ja/python-net/custom-font/) を判断できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

**フォントディレクトリをシステムにインストールせずに追加できますか？**

はい。フォルダーやメモリ内ストリームなどの [外部フォントソース](/slides/ja/python-net/custom-font/) を登録して、レンダリングやエクスポートに使用できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**文字グリフが欠落している場合に、不適切なフォントへの自動フォールバックを防ぐにはどうすればよいですか？**

事前に明示的な [フォント置換](/slides/ja/python-net/font-replacement/) とフォント [フォールバックルール](/slides/ja/python-net/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御して設定することで、タイポグラフィを一貫させ、予期せぬ結果を回避できます。