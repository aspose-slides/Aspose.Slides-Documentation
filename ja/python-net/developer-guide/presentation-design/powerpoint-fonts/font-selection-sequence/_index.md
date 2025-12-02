---
title: Aspose.Slides for Python におけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/python-net/font-selection-sequence/
keywords:
- フォント選択
- フォント置換
- フォント置換
- 置換規則
- 利用可能フォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET がフォントを選択し、PPT、PPTX、ODP ファイルの鮮明で一貫した表示を実現する方法をご紹介します—スライドを今すぐ改善しましょう。"
---

## **フォント選択**

プレゼンテーションがロード、レンダリング、または別の形式に変換される際には、フォントに関する特定の規則が適用されます。例えば、プレゼンテーション（スライド）を画像に変換しようとする場合、プレゼンテーションのフォントがオペレーティングシステムにそのフォントが存在するかどうかが確認されます。フォントが欠落していることが確認された場合、置き換えられます — [**フォント置換**](https://docs.aspose.com/slides/python-net/font-replacement/) と [**フォント代替**](https://docs.aspose.com/slides/python-net/font-substitution/) を参照してください。

Aspose.Slides がフォントを扱う際のプロセスは次のとおりです:

1. Aspose.Slides はオペレーティングシステム内のフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを探します。  
2. 選択されたフォントが見つかった場合、Aspose.Slides はそれを使用します。見つからない場合、PowerPoint が使用するものにできるだけ近い置換フォントを使用します。  
3. FontSubstRule を使用してフォント置換ルールが設定されている場合、それらが適用されます。  

Aspose.Slides ではアプリケーションの実行時にフォントを追加し、使用することができます。[**カスタムフォント**](https://docs.aspose.com/slides/python-net/custom-font/) を参照してください。  

プレゼンテーション内に追加のフォントが配置されている場合、それらは [**埋め込みフォント**](https://docs.aspose.com/slides/python-net/embedded-font/) と呼ばれます。  

Aspose.Slides は *出力ドキュメントにのみ* 適用されるフォントを追加することができます。例えば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを **外部フォント** として追加または読み込むことができます。  

{{% alert title="Note" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。当社の API は外部フォントの読み込みとドキュメントへの埋め込みを可能にしますが、フォントの使用はお客様の裁量と責任において行ってください。
{{% /alert %}}

## **よくある質問**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように確認できますか？**

Aspose.Slides は [フォントマネージャ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) を使用して使用中のフォントを検査できるため、[埋め込み](/slides/ja/python-net/embedded-font/)、[置換](/slides/ja/python-net/font-replacement/)、または [外部ソース](/slides/ja/python-net/custom-font/) を決定できます。これにより、レンダリングやエクスポート時の不要な置き換えを防止できます。  

**オペレーティングシステムにインストールせずに追加のフォントディレクトリを追加できますか？**

はい。フォルダーやメモリ内ストリームなどの [外部フォントソース](/slides/ja/python-net/custom-font/) を登録して、レンダリングやエクスポートに使用できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトを予測可能に保つことができます。  

**グリフが欠如している場合に不適切なフォントへのサイレントフォールバックを防ぐにはどうすればよいですか？**

事前に明示的な [フォント置換](/slides/ja/python-net/font-replacement/) と [フォントフォールバック規則](/slides/ja/python-net/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御することで、一貫したタイポグラフィを確保し、予期しない結果を回避できます。