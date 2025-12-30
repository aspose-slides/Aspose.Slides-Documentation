---
title: Aspose.Slides for PHP におけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/php-java/font-selection-sequence/
keywords:
- フォント選択
- フォント代替
- フォント置換
- 置換規則
- 利用可能フォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java がフォントを選択し、PPT、PPTX、ODP ファイルの鮮明で一貫したプレゼンテーションを実現する方法をご紹介します — 今すぐスライドを改善しましょう。"
---

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際には、フォントに特定の規則が適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとすると、使用されているフォントがオペレーティングシステムに存在するか確認されます。フォントが存在しないことが確認された場合、フォントは置換されます—[**フォント置換**](https://docs.aspose.com/slides/php-java/font-replacement/) と [**フォント代替**](https://docs.aspose.com/slides/php-java/font-substitution/) を参照してください。

これは、Aspose.Slides がフォントを扱う際のプロセスです:

1. Aspose.Slides は、プレゼンテーションで選択されたフォントに一致するフォントをオペレーティングシステム内で検索します。  
2. 選択されたフォントが見つかった場合、Aspose.Slides はそれを使用します。見つからない場合、Aspose.Slides は PowerPoint が使用するものにできるだけ近い置換フォントを使用します。  
3. フォント置換ルールが [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) を通じて設定されている場合、それらが適用されます。

Aspose.Slides は、フォントを Aspose ランタイムに追加し、使用できるようにします。[**カスタムフォント**](https://docs.aspose.com/slides/php-java/custom-font/) を参照してください。

プレゼンテーション内に追加フォントが配置されている場合、これらは [**埋め込みフォント**](https://docs.aspose.com/slides/php-java/embedded-font/) と呼ばれます。

Aspose.Slides は、*唯一* 出力ドキュメントに適用されるフォントを追加できるようにします。たとえば、PDF に変換しようとしているプレゼンテーションに、システムや埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを **外部フォント** として追加またはロードできます。

## **よくある質問**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように特定できますか？**

Aspose.Slides は、[font manager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) を介して使用されているフォントを検査できるため、[埋め込み](/slides/ja/php-java/embedded-font/)、[置換](/slides/ja/php-java/font-replacement/)、または[外部ソース](/slides/ja/php-java/custom-font/) を追加するかを決定できます。これにより、レンダリングおよびエクスポート時の不要な置換を防止できます。

**フォントディレクトリをシステムにインストールせずに追加できますか？**

はい。フォルダーやメモリ内ストリームなどの [外部フォントソース](/slides/ja/php-java/custom-font/) を登録して、レンダリングおよびエクスポートに使用できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**グリフが欠如している場合に不適切なフォントへの静かなフォールバックを防ぐにはどうすればよいですか？**

事前に明示的な [フォント置換](/slides/ja/php-java/font-replacement/) とフォント [フォールバック規則](/slides/ja/php-java/fallback-font/) を定義します。使用フォントを分析し、置換候補の優先順位を制御して設定することで、一貫したタイポグラフィを確保し、予期しない結果を回避できます。