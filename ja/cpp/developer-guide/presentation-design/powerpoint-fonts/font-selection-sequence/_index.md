---
title: C++におけるフォント選択シーケンス
linktitle: C++におけるフォント選択シーケンス
type: docs
weight: 80
url: /ja/cpp/font-selection-sequence/
keywords:
- フォント
- フォント選択
- フォント置き換え
- フォントサブスティチューション
- PowerPointプレゼンテーション
- C++
- Aspose.Slides for C++
description: "C++におけるPowerPointフォント選択シーケンス"
---

## フォント選択

プレゼンテーションが読み込まれたり、レンダリングされたり、別の形式に変換されたりする際には、プレゼンテーション内のフォントに特定のルールが適用されます。例えば、プレゼンテーション（スライド）を画像に変換しようとすると、選択されたフォントがオペレーティングシステムに存在するかどうかを確認するために、プレゼンテーションのフォントがチェックされます。フォントが見つからない場合は、置き換えられます — 詳細は[**フォント置き換え**](https://docs.aspose.com/slides/cpp/font-replacement/)および[**フォントサブスティチューション**](https://docs.aspose.com/slides/cpp/font-substitution/)を参照してください。

Aspose.Slidesがフォントを扱う際に従うプロセスは次の通りです：

1. Aspose.Slidesは、プレゼンテーションで選択されたフォントに一致するフォントを見つけるために、オペレーティングシステム内を検索します。
2. 選択されたフォントが見つかった場合、Aspose.Slidesはそれを使用します。それ以外の場合、Aspose.SlidesはPowerPointが使用するフォントにできるだけ近い代替フォントを使用します。
3. [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/)を通じてフォント置き換えルールが設定されている場合、それが適用されます。 

Aspose.Slidesは、アプリケーションのランタイムにフォントを追加し、それらのフォントを使用することを可能にします。詳細は[**カスタムフォント**](https://docs.aspose.com/slides/cpp/custom-font/)を参照してください。 

プレゼンテーション内に追加のフォントが配置されている場合、それらは[**埋め込みフォント**](https://docs.aspose.com/slides/cpp/embedded-font/)と呼ばれます。

Aspose.Slidesは、*出力ドキュメントのみに*適用されるフォントを追加することを可能にします。例えば、PDFに変換しようとしているプレゼンテーションに、システムに存在しないフォントと埋め込みフォントが含まれている場合、必要なフォントを**外部フォント**として追加または読み込むことができます。 

{{% alert title="注意" color="primary" %}} 
私たちは、無料または有料のフォントを配布していません。当社のAPIでは外部フォントを読み込み、それらをドキュメントに埋め込むことができますが、フォントの使用はお客様の裁量と責任において行ってください。
{{% /alert %}}