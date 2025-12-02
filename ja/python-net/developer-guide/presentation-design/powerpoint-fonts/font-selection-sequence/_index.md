---
title: Aspose.Slides for Python におけるフォント選択シークエンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/python-net/font-selection-sequence/
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
- Aspose.Slides
description: "Aspose.Slides for Python（.NET）でフォントがどのように選択され、PPT、PPTX、ODP ファイルの鮮明で一貫した表示が保証されるかを確認し、今すぐスライドを改善しましょう。"
---

## **フォント選択**

プレゼンテーションが読み込まれたり、レンダリングされたり、別の形式に変換されたりする際には、フォントに関して特定のルールが適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとすると、選択されたフォントが OS に存在するかどうかが確認されます。フォントが見つからないと確認された場合は置き換えられます — 詳細は[**フォント置換**](https://docs.aspose.com/slides/python-net/font-replacement/)および[**フォント代替**](https://docs.aspose.com/slides/python-net/font-substitution/)をご覧ください。

以下は、Aspose.Slides がフォントを扱う際の手順です。

1. Aspose.Slides は OS 内のフォントを検索し、プレゼンテーションで選択されたフォントと一致するものを探します。  
2. 選択されたフォントが見つかれば Aspose.Slides はそれを使用します。見つからない場合は、PowerPoint が使用するものにできるだけ近い置換フォントを使用します。  
3. [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) を通じてフォント置換ルールが設定されている場合は、それが適用されます。

Aspose.Slides では、アプリケーションの実行時にフォントを追加し、そのフォントを使用することができます。詳しくは[**カスタムフォント**](https://docs.aspose.com/slides/python-net/custom-font/)をご覧ください。

プレゼンテーションに追加されたフォントは[**埋め込みフォント**](https://docs.aspose.com/slides/python-net/embedded-font/)と呼ばれます。

Aspose.Slides は、出力ドキュメントにのみ適用されるフォントを追加することも可能です。たとえば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを**外部フォント**として追加またはロードできます。

{{% alert title="Note" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。API は外部フォントの読み込みとドキュメントへの埋め込みをサポートしますが、フォントの使用はお客様の裁量と責任において行ってください。
{{% /alert %}}

## **FAQ**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように確認できますか？**

Aspose.Slides は[フォントマネージャー](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/)を介して使用中のフォントを検査できるため、[埋め込み](/slides/ja/python-net/embedded-font/)、[置換](/slides/ja/python-net/font-replacement/)、または[外部ソース](/slides/ja/python-net/custom-font/)のいずれかを選択できます。これにより、レンダリングやエクスポート時の不要な置換を防げます。

**OS にインストールせずに追加のフォントディレクトリを登録できますか？**

はい。[外部フォントソース](/slides/ja/python-net/custom-font/)としてフォルダーやメモリーストリームを登録でき、レンダリングやエクスポート時に使用できます。これによりホストシステムのフォントへの依存が解除され、レイアウトが予測可能になります。

**文字グリフが欠けている場合に不適切なフォントへ自動的にフォールバックするのを防ぐには？**

事前に明示的な[フォント置換](/slides/ja/python-net/font-replacement/)とフォント[フォールバック規則](/slides/ja/python-net/fallback-font/)を定義します。使用フォントを分析し、代替フォントの優先順位を制御することで、一貫したタイポグラフィを保ち、予期しない結果を回避できます。