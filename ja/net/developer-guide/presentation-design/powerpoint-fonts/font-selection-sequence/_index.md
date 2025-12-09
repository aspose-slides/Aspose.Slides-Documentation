---
title: Aspose.Slides for .NET のフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/net/font-selection-sequence/
keywords:
- フォント選択
- フォント置換
- フォント代替
- 置換規則
- 利用可能なフォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET がフォントを選択する方法を解説し、PPT、PPTX、ODP ファイルの鮮明で一貫した表示を実現します—今すぐスライドを改善しましょう。"
---

## **フォントの選択**

プレゼンテーションが読み込まれたり、レンダリングされたり、別の形式に変換されたりする際には、フォントに関する特定の規則が適用されます。例えば、プレゼンテーション（スライド）を画像に変換しようとすると、オペレーティングシステムに選択されたフォントが存在するかどうかが確認されます。フォントが見つからないことが確認された場合、置換が行われます — [**フォント置換**](https://docs.aspose.com/slides/net/font-replacement/) と [**フォント代替**](https://docs.aspose.com/slides/net/font-substitution/) を参照してください。

以下は、フォントを扱う際の Aspose.Slides の処理手順です。

1. Aspose.Slides はオペレーティングシステム内でフォントを検索し、プレゼンテーションで選択されたフォントと一致するものを探します。  
2. 選択されたフォントが見つかれば、Aspose.Slides はそれを使用します。見つからない場合、PowerPoint が使用するものにできるだけ近い置換フォントを使用します。  
3. [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) を介してフォント置換規則が設定されている場合、それらが適用されます。  

Aspose.Slides では、アプリケーションの実行時にフォントを追加し、使用できるようにすることができます。[**カスタム フォント**](https://docs.aspose.com/slides/net/custom-font/) を参照してください。

プレゼンテーション内に追加フォントが配置されている場合、これらは [**埋め込みフォント**](https://docs.aspose.com/slides/net/embedded-font/) と呼ばれます。

Aspose.Slides は、出力ドキュメントにのみ適用されるフォントを追加することを可能にします。たとえば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントに存在しないフォントが含まれている場合、**外部フォント** として必要なフォントを追加または読み込むことができます。

{{% alert title="Note" color="primary" %}} 
当社はフォント（有料・無料を問わず）を配布していません。API は外部フォントを読み込みドキュメントに埋め込む機能を提供しますが、フォントの使用はすべて利用者の裁量と責任において行われます。
{{% /alert %}}

## **FAQ**

**変換前にプレゼンテーションで実際に使用されているフォントを確認するにはどうすればよいですか？**

Aspose.Slides は [フォント マネージャー](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) を通じて使用されているフォントを検査できるため、[埋め込み](/slides/ja/net/embedded-font/)、[置換](/slides/ja/net/font-replacement/)、または [外部ソース](/slides/ja/net/custom-font/) のいずれかを決定できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

**オペレーティングシステムにインストールせずに追加のフォント ディレクトリを登録できますか？**

はい。レンダリングやエクスポートのために、フォルダーやメモリ ストリームなどの [外部フォント ソース](/slides/ja/net/custom-font/) を登録できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**文字グリフが欠落している場合に不適切なフォントへ自動的にフォールバックするのを防ぐには？**

事前に明示的な [フォント置換](/slides/ja/net/font-replacement/) とフォント [フォールバック ルール](/slides/ja/net/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御することで、一貫したタイポグラフィを保証し、予期せぬ結果を回避できます。