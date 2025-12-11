---
title: Aspose.Slides for C++ のフォント選択シークエンス
linktitle: フォント選択
type: docs
weight: 80
url: /ja/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ がフォントを選択する仕組みを解説し、PPT、PPTX、ODP ファイルの鮮明で一貫した表示を実現します。スライドを今すぐ改善しましょう。"
---

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際には、フォントに対して特定の規則が適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとすると、プレゼンテーションのフォントがオペレーティングシステムにそのフォントが存在するかどうかチェックされます。フォントが存在しないことが確認された場合は置き換えられます — 詳細は[**フォント置換**](https://docs.aspose.com/slides/cpp/font-replacement/)および[**フォント代替**](https://docs.aspose.com/slides/cpp/font-substitution/)をご覧ください。

以下は Aspose.Slides がフォントを扱う際の手順です：

1. Aspose.Slides はオペレーティングシステム内でフォントを検索し、プレゼンテーションで指定されたフォントに一致するものを探します。  
2. 指定フォントが見つかった場合はそれを使用します。見つからない場合は、PowerPoint が使用するであろうフォントにできるだけ近い置換フォントを使用します。  
3. [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) を介してフォント置換規則が設定されている場合は、これが適用されます。  

Aspose.Slides では、アプリケーションの実行時にフォントを追加して使用することができます。詳しくは[**カスタムフォント**](https://docs.aspose.com/slides/cpp/custom-font/)をご参照ください。

プレゼンテーション内に追加フォントが配置されている場合、それらは[**埋め込みフォント**](https://docs.aspose.com/slides/cpp/embedded-font/)と呼ばれます。

Aspose.Slides は、*only* 出力ドキュメントに適用されるフォントを追加することも可能です。たとえば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントに存在しないフォントがある場合、必要なフォントを **外部フォント** として追加またはロードできます。

{{% alert title="Note" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。API は外部フォントをロードしてドキュメントに埋め込む機能を提供しますが、フォントの使用はご自身の裁量と責任で行ってください。
{{% /alert %}}

## **よくある質問**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように確認できますか？**

Aspose.Slides は [font manager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) を通じて使用フォントを検査できるため、[埋め込む](/slides/ja/cpp/embedded-font/)、[置換する](/slides/ja/cpp/font-replacement/)、または [外部ソースを追加](/slides/ja/cpp/custom-font/) するかを判断できます。これにより、レンダリングやエクスポート時の不要な置換を防げます。

**オペレーティングシステムにインストールせずに余分なフォントディレクトリを追加できますか？**

はい。フォルダーやメモリ内ストリームなどの [外部フォントソース](/slides/ja/cpp/custom-font/) を登録して、レンダリングやエクスポートに使用できます。これによりホストシステムのフォントへの依存がなくなり、レイアウトの予測可能性が保たれます。

**グリフが欠落しているときに不適切なフォントへのサイレントフォールバックを防ぐには？**

事前に明示的な [フォント置換](/slides/ja/cpp/font-replacement/) およびフォント [フォールバック規則](/slides/ja/cpp/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御することで、一貫したタイポグラフィを確保し、予期せぬ結果を回避できます。