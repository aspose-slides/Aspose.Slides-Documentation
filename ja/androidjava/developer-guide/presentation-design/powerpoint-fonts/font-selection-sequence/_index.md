---
title: Aspose.Slides for Android via Java におけるフォント選択シーケンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/androidjava/font-selection-sequence/
keywords:
- フォント選択
- フォント代替
- フォント置換
- 置換規則
- 利用可能なフォント
- 欠落フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java がフォントを選択する仕組みを確認し、PPT、PPTX、ODP ファイルの鮮明で一貫したプレゼンテーションを実現します — 今すぐスライドを改善しましょう。"
---

## **フォント選択**

プレゼンテーションがロード、レンダリング、または別の形式に変換されるとき、フォントには特定の規則が適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとすると、選択されたフォントがオペレーティングシステムに存在するかどうかが確認されます。フォントが存在しないことが確認された場合、置換されます — 詳細は[**フォント置換**](https://docs.aspose.com/slides/androidjava/font-replacement/)および[**フォント代替**](https://docs.aspose.com/slides/androidjava/font-substitution/)をご覧ください。

以下は、Aspose.Slides がフォントを処理する際の手順です。

1. Aspose.Slides は、オペレーティングシステム内のフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを探します。
2. 選択されたフォントが見つかった場合、Aspose.Slides はそれを使用します。見つからない場合は、PowerPoint が使用するフォントにできる限り近い置換フォントを使用します。
3. フォント置換規則が [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) を介して設定されている場合、それらが適用されます。

Aspose.Slides では、アプリケーションの実行時にフォントを追加し、そのフォントを使用できます。[**カスタムフォント**](https://docs.aspose.com/slides/androidjava/custom-font/)をご参照ください。

プレゼンテーション内に追加のフォントが配置されている場合、それらは[**埋め込みフォント**](https://docs.aspose.com/slides/androidjava/embedded-font/)と呼ばれます。

Aspose.Slides は、*出力ドキュメントにのみ*適用されるフォントを追加することができます。たとえば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを **外部フォント** として追加またはロードできます。

{{% alert title="Note" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。当社の API は外部フォントをロードし、ドキュメントに埋め込むことを可能にしますが、フォントの使用はお客様の裁量と責任で行ってください。 
{{% /alert %}}

## **FAQ**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように確認できますか？**

Aspose.Slides は [font manager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/) を使用して使用されているフォントを検査できるため、[埋め込む](/slides/ja/androidjava/embedded-font/)、[置換する](/slides/ja/androidjava/font-replacement/)、または[外部ソース](/slides/ja/androidjava/custom-font/)を追加するかを決定できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

**オペレーティングシステムにインストールせずに、追加のフォントディレクトリを追加できますか？**

はい。フォルダーやメモリストリームなどの[外部フォントソース](/slides/ja/androidjava/custom-font/)を登録して、レンダリングやエクスポートに使用できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**グリフが欠落している場合に、不適切なフォントへのサイレントフォールバックを防ぐにはどうすればよいですか？**

事前に明示的な[フォント置換](/slides/ja/androidjava/font-replacement/)とフォント[フォールバック規則](/slides/ja/androidjava/fallback-font/)を定義します。使用フォントを分析し、代替フォントの優先順位を制御して設定することで、一貫したタイポグラフィを確保し、予期しない結果を回避できます。