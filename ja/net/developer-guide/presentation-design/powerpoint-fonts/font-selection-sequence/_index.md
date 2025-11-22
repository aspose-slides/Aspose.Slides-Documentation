---
title: C# におけるフォント選択シーケンス
linktitle: C# におけるフォント選択シーケンス
type: docs
weight: 80
url: /ja/net/font-selection-sequence/
keywords:
- フォント
- フォント選択
- フォント代替
- フォント置換
- PowerPoint プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: C# での PowerPoint フォント選択シーケンス
---

## **フォント選択**

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換されるとき、フォントには特定の規則が適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとすると、プレゼンテーションのフォントがチェックされ、選択されたフォントがオペレーティングシステムに存在するかが確認されます。フォントが不足していることが確認された場合、置き換えられます — 詳細は[**フォント置換**](https://docs.aspose.com/slides/net/font-replacement/) と [**フォント代替**](https://docs.aspose.com/slides/net/font-substitution/) を参照してください。

フォントを扱う際の Aspose.Slides の処理手順は次のとおりです。

1. Aspose.Slides はオペレーティングシステム内のフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを見つけます。  
2. 選択されたフォントが見つかった場合、Aspose.Slides はそれを使用します。見つからない場合、PowerPoint が使用するものに最も近い置換フォントを使用します。  
3. フォント置換規則が [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) を介して設定されている場合、それらが適用されます。  

Aspose.Slides では、アプリケーションの実行時にフォントを追加し、それらのフォントを使用できます。 詳細は[**カスタムフォント**](https://docs.aspose.com/slides/net/custom-font/)をご覧ください。  

プレゼンテーション内に追加フォントが配置されている場合、これらは [**埋め込みフォント**](https://docs.aspose.com/slides/net/embedded-font/) と呼ばれます。  

Aspose.Slides は、*出力ドキュメントにだけ* 適用されるフォントを追加できます。たとえば、PDF に変換しようとしているプレゼンテーションにシステムや埋め込みフォントに存在しないフォントがある場合、必要なフォントを **外部フォント** として追加またはロードできます。  

{{% alert title="Note" color="primary" %}} 
フォント（有料・無料を問わず）は一切配布していません。当社の API は外部フォントのロードとドキュメントへの埋め込みを可能にしますが、フォントの使用はお客様の判断と責任で行っていただく必要があります。  
{{% /alert %}}

## **よくある質問**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように判別できますか？**  
Aspose.Slides は [font manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) を通じて使用されているフォントを検査できるため、[埋め込み](/slides/ja/net/embedded-font/)、[置換](/slides/ja/net/font-replacement/)、または [外部ソース](/slides/ja/net/custom-font/) を追加するかを判断できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。  

**フォントディレクトリを OS にインストールせずに追加できますか？**  
はい。フォルダーやメモリ内ストリームなどの [外部フォントソース](/slides/ja/net/custom-font/) を登録して、レンダリングやエクスポートに使用できます。これによりホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。  

**文字が欠けているときに不適切なフォントへの無音フォールバックを防ぐにはどうすればよいですか？**  
事前に明示的な [フォント置換](/slides/ja/net/font-replacement/) とフォント [フォールバック規則](/slides/ja/net/fallback-font/) を定義します。使用フォントを分析し、代替フォントの優先順位を制御して設定することで、タイポグラフィの一貫性を確保し、予期しない結果を回避できます。