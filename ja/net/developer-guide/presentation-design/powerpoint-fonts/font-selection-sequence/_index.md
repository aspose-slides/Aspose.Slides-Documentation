---
title: C#におけるフォント選択のシーケンス
linktitle: C#におけるフォント選択のシーケンス
type: docs
weight: 80
url: /net/font-selection-sequence/
keywords:
- フォント
- フォント選択
- フォント代替
- フォント置換
- PowerPoint プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: C#におけるPowerPointフォント選択のシーケンス
---

## フォント選択

プレゼンテーションが読み込まれたり、レンダリングされたり、別の形式に変換されたりする際には、フォントにいくつかのルールが適用されます。例えば、プレゼンテーション（そのスライド）を画像に変換しようとした場合、選択したフォントがオペレーティングシステムに存在するかどうかを確認するために、プレゼンテーションのフォントがチェックされます。フォントが不足していることが確認された場合、それらは置き換えられます — [**フォント置換**](https://docs.aspose.com/slides/net/font-replacement/) と [**フォント代替**](https://docs.aspose.com/slides/net/font-substitution/)を参照してください。

Aspose.Slidesがフォントを処理する際のプロセスは次のとおりです：

1. Aspose.Slidesはオペレーティングシステム内のフォントを検索し、プレゼンテーションが選択したフォントと一致するフォントを見つけます。
2. 選択したフォントが見つかった場合、Aspose.Slidesはそれを使用します。そうでない場合、Aspose.SlidesはPowerPointが使用するものにできるだけ近い置換フォントを使用します。
3. [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/)を通じてフォント置換ルールが設定されている場合、それらが適用されます。

Aspose.Slidesでは、アプリケーションのランタイムにフォントを追加し、これらのフォントを使用することができます。詳しくは [**カスタムフォント**](https://docs.aspose.com/slides/net/custom-font/)を参照してください。

プレゼンテーション内に追加のフォントが配置されると、それらは [**埋め込みフォント**](https://docs.aspose.com/slides/net/embedded-font/)と呼ばれます。

Aspose.Slidesでは、*出力文書のみに* 適用されるフォントを追加することができます。例えば、PDFに変換しようとしているプレゼンテーションがシステムに存在しないフォントと埋め込みフォントを含む場合、必要なフォントを**外部フォント**として追加または読み込むことができます。

{{% alert title="注" color="primary" %}} 
私たちは、有料または無料のフォントを配布していません。私たちのAPIでは、外部フォントを読み込み、文書に埋め込むことができますが、それはあなたの裁量と責任で行ってください。
{{% /alert %}}