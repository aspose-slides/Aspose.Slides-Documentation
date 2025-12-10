---
title: Aspose.Slides for Java のフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/java/font-selection-sequence/
keywords:
- フォント選択
- フォント代替
- フォント置換
- 置換ルール
- 利用可能なフォント
- 欠損フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java がフォントを選択する方法を紹介し、PPT、PPTX、ODP ファイルの鮮明で一貫したプレゼンテーションを実現します—今すぐスライドを改善しましょう。"
---

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際、フォントには特定の規則が適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとすると、選択されたフォントが OS に存在するかどうかがチェックされます。フォントが存在しないことが確認された場合、置き換えが行われます — 詳細は[**フォント置換**](https://docs.aspose.com/slides/java/font-replacement/) と[**フォント代替**](https://docs.aspose.com/slides/java/font-substitution/) を参照してください。

Aspose.Slides がフォントを処理する際の手順は次のとおりです：

1. Aspose.Slides は OS 上のフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを探します。  
2. 選択されたフォントが見つかれば、Aspose.Slides はそれを使用します。見つからない場合、PowerPoint が使用するフォントにできるだけ近い置換フォントを使用します。  
3. [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) を使用してフォント置換ルールが設定されている場合、適用されます。  

Aspose.Slides では、アプリケーションの実行時にフォントを追加し、使用することができます。[**カスタムフォント**](https://docs.aspose.com/slides/java/custom-font/) を参照してください。

プレゼンテーション内に追加のフォントが配置されている場合、これらは[**埋め込みフォント**](https://docs.aspose.com/slides/java/embedded-font/) と呼ばれます。

Aspose.Slides は、*出力ドキュメントにのみ* 適用されるフォントを追加することができます。たとえば、PDF に変換しようとしているプレゼンテーションがシステムや埋め込みフォントに存在しないフォントを含んでいる場合、必要なフォントを **外部フォント** として追加またはロードできます。

{{% alert title="Note" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。当 API は外部フォントのロードとドキュメントへの埋め込みを可能にしますが、フォントの使用はお客様の裁量と責任で行う必要があります。
{{% /alert %}}

## **よくある質問**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように確認できますか？**

Aspose.Slides は [font manager](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/) を使用して使用中のフォントを検査できるため、[埋め込み](/slides/ja/java/embedded-font/)、[置換](/slides/ja/java/font-replacement/)、または[外部ソース](/slides/ja/java/custom-font/) の追加を判断できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

**フォントを OS にインストールせずに、追加のフォントディレクトリを追加できますか？**

はい。フォルダーやメモリ内ストリームなどの [外部フォントソース](/slides/ja/java/custom-font/) を登録して、レンダリングやエクスポートに使用できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**文字グリフが欠損している場合に、不適切なフォントへの静かなフォールバックを防ぐにはどうすればよいですか？**

事前に明示的な [フォント置換](/slides/ja/java/font-replacement/) とフォント [フォールバックルール](/slides/ja/java/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御することで、タイポグラフィを一貫させ、予期しない結果を回避できます。