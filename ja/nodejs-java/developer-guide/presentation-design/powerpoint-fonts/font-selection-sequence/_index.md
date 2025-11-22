---
title: JavaScript におけるフォント選択シーケンス
linktitle: フォント選択シーケンス
type: docs
weight: 80
url: /ja/nodejs-java/font-selection-sequence/
keywords:
- フォント
- フォント選択
- フォント代替
- フォント置換
- PowerPoint プレゼンテーション
- Java
- Java を介した Node.js 用 Aspose.Slides
description: JavaScript における PowerPoint フォント選択シーケンス
---

## **Font Selection**

プレゼンテーションが読み込まれたり、レンダリングされたり、別の形式に変換されたりする際には、フォントに関する特定の規則が適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとする場合、プレゼンテーションで使用されているフォントが、選択されたフォントがオペレーティングシステムに存在するかどうかが確認されます。フォントが欠落していることが確認された場合、置き換えが行われます — **[**フォント置換**](https://docs.aspose.com/slides/nodejs-java/font-replacement/)** と **[**フォント代替**](https://docs.aspose.com/slides/nodejs-java/font-substitution/)** を参照してください。

これはフォントを扱う際の Aspose.Slides のプロセスです：

1. Aspose.Slides はオペレーティングシステム内のフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを探します。  
2. 選択されたフォントが見つかれば、Aspose.Slides はそれを使用します。見つからない場合、PowerPoint が使用するものにできるだけ近い置換フォントを Aspose.Slides が使用します。  
3. FontSubstRule を使用してフォント置換ルールが設定されている場合、それらが適用されます。

Aspose.Slides では、アプリケーションの実行時にフォントを追加し、それらのフォントを使用できます。**[**カスタムフォント**](https://docs.aspose.com/slides/nodejs-java/custom-font/)** を参照してください。

プレゼンテーション内に追加のフォントが配置されている場合、それらは **[**埋め込みフォント**](https://docs.aspose.com/slides/nodejs-java/embedded-font/)** と呼ばれます。

Aspose.Slides は、*出力ドキュメントにのみ* 適用されるフォントを追加することができます。たとえば、PDF に変換しようとしているプレゼンテーションに、システムや埋め込みフォントに存在しないフォントが含まれている場合、必要なフォントを **外部フォント** として追加または読み込むことができます。

{{% alert title="Note" color="primary" %}} 
当社は有料・無料を問わずフォントを配布していません。当社の API は外部フォントを読み込んでドキュメントに埋め込むことを可能にしますが、フォントの使用はご自身の判断と責任で行ってください。
{{% /alert %}}

## **FAQ**

**変換前にプレゼンテーションで実際に使用されているフォントをどのように特定できますか？**

Aspose.Slides は [font manager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) を使用して使用されているフォントを検査できるため、**[埋め込む](/slides/ja/nodejs-java/embedded-font/)**、**[置換する](/slides/ja/nodejs-java/font-replacement/)**、または**[外部ソースを追加](/slides/ja/nodejs-java/custom-font/)** かを判断できます。これにより、レンダリングやエクスポート時の不要な置換を防止できます。

**オペレーティングシステムにインストールせずに、追加のフォントディレクトリを追加できますか？**

はい。レンダリングやエクスポート用に、**[外部フォントソース](/slides/ja/nodejs-java/custom-font/)**（フォルダーやメモリ内ストリームなど）を登録できます。これにより、ホストシステムのフォントへの依存がなくなり、レイアウトが予測可能になります。

**文字が欠落しているときに不適切なフォントへの自動フォールバックを防ぐにはどうすればよいですか？**

事前に明示的な**[フォント置換](/slides/ja/nodejs-java/font-replacement/)**と**[フォールバック フォント ルール](/slides/ja/nodejs-java/fallback-font/)** を定義します。使用フォントを分析し、代替フォントの優先順位を制御して設定することで、一貫したタイポグラフィを確保し、予期しない結果を防止できます。