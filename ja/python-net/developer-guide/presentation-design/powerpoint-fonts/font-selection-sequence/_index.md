---
title: Aspose.Slides for Python におけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/python-net/font-selection-sequence/
keywords:
- フォント選択
- フォント置換
- フォント置き換え
- 置換ルール
- 利用可能なフォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET）がフォントを選択する方法を確認し、PPT、PPTX、ODP ファイルの鮮明で一貫したプレゼンテーションを実現しましょう—今すぐスライドを改善してください。"
---

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際には、フォントに関する特定のルールが適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとする場合、選択されたフォントが OS に存在するかどうかが確認されます。フォントが存在しないことが判明した場合は置き換えられます — [**フォント置換**](https://docs.aspose.com/slides/python-net/font-replacement/) と [**フォント置換**](https://docs.aspose.com/slides/python-net/font-substitution/) を参照してください。

これは、フォントを処理する際に Aspose.Slides が従うプロセスです：

1. Aspose.Slides は、プレゼンテーションで選択されたフォントに一致するフォントを OS で検索します。 
2. 選択されたフォントが見つかれば Aspose.Slides はそれを使用します。見つからない場合は、PowerPoint が使用するフォントにできるだけ近い置換フォントを使用します。
3. [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) でフォント置換ルールが設定されている場合、それらが適用されます。 

Aspose.Slides では、アプリケーション実行時にフォントを追加して使用できます。[**カスタムフォント**](https://docs.aspose.com/slides/python-net/custom-font/) を参照してください。 

プレゼンテーションに追加のフォントが含まれる場合、それらは[**埋め込みフォント**](https://docs.aspose.com/slides/python-net/embedded-font/) と呼ばれます。

Aspose.Slides は、*出力ドキュメントにのみ* 適用されるフォントを追加できます。たとえば、PDF に変換しようとしているプレゼンテーションに、システムや埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを **外部フォント** として追加またはロードできます。

{{% alert title="注" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。当社の API は外部フォントをロードしてドキュメントに埋め込むことを可能にしますが、フォントの使用はご自身の裁量と責任で行ってください。
{{% /alert %}}

## **FAQ**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように特定できますか？**

Aspose.Slides は、[フォントマネージャ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) を使用して使用中のフォントを確認できるため、[埋め込み](/slides/ja/python-net/embedded-font/)、[置換](/slides/ja/python-net/font-replacement/)、または[外部ソース](/slides/ja/python-net/custom-font/) の追加を判断できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

**フォントディレクトリを OS にインストールせずに追加できますか？**

はい。レンダリングやエクスポート用に、フォルダーやメモリ内ストリームなどの[外部フォントソース](/slides/ja/python-net/custom-font/) を登録できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**グリフが欠落しているときに不適切なフォントへのサイレントフォールバックを防ぐにはどうすればよいですか？**

事前に明示的な[フォント置換](/slides/ja/python-net/font-replacement/) とフォント[フォールバックルール](/slides/ja/python-net/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御して設定することで、一貫したタイポグラフィを保証し、予期しない結果を回避できます。