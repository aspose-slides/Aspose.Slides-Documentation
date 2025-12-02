---
title: Aspose.Slides for Python のフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/python-net/font-selection-sequence/
keywords:
- フォント選択
- フォント代替
- フォント置換
- 置換ルール
- 利用可能なフォント
- 不足フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python (.NET 経由) がフォントを選択する仕組みを解説し、PPT、PPTX、ODP ファイルの鮮明で一貫したプレゼンテーションを実現します—今すぐスライドを改善しましょう。"
---

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際には、フォントに対して特定の規則が適用されます。例えば、プレゼンテーション（スライド）を画像に変換しようとすると、プレゼンテーションのフォントがチェックされ、選択されたフォントが OS に存在するかが検証されます。フォントが欠如していることが確認された場合、置き換えられます — 詳細は[**Font Replacement**](https://docs.aspose.com/slides/python-net/font-replacement/) と [**Font Substitution**](https://docs.aspose.com/slides/python-net/font-substitution/) を参照してください。

フォントを扱う際の Aspose.Slides のプロセスは次の通りです：

1. Aspose.Slides は OS 内のフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを探します。  
2. 選択されたフォントが見つかれば Aspose.Slides はそれを使用します。見つからない場合は、PowerPoint が使用するものにできるだけ近い置換フォントが使用されます。  
3. フォント置換ルールが [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) を通じて設定されている場合、それらが適用されます。  

Aspose.Slides はアプリケーション実行時にフォントを追加し、それらを使用できるようにします。[**Custom fonts**](https://docs.aspose.com/slides/python-net/custom-font/) を参照してください。

プレゼンテーションに追加のフォントが含まれている場合、それらは [**Embedded fonts**](https://docs.aspose.com/slides/python-net/embedded-font/) と呼ばれます。

Aspose.Slides は出力ドキュメントのみに適用されるフォントを追加できます。例えば、PDF に変換しようとしているプレゼンテーションに、システムおよび埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを **external fonts** として追加またはロードできます。

{{% alert title="Note" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。API は外部フォントのロードとドキュメントへの埋め込みを可能にしますが、フォントの使用は利用者の裁量と責任で行ってください。
{{% /alert %}}

## **FAQ**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように特定できますか？**

Aspose.Slides は [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) を使用して使用中のフォントを検査できるため、[埋め込み](/slides/ja/python-net/embedded-font/)、[置換](/slides/ja/python-net/font-replacement/)、または [外部ソース](/slides/ja/python-net/custom-font/) を追加するかを決定できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

**フォントディレクトリを追加して、OS にインストールせずに使用できますか？**

はい。レンダリングやエクスポート用に、フォルダーやメモリストリームなどの [外部フォントソース](/slides/ja/python-net/custom-font/) を登録できます。これによりホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**文字グリフが不足している場合に、適切でないフォントへの静かなフォールバックを防ぐにはどうすればよいですか？**

事前に明示的な [font replacement](/slides/ja/python-net/font-replacement/) とフォント [fallBack rules](/slides/ja/python-net/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御することで、一貫したタイポグラフィを確保し、予期しない結果を回避できます。