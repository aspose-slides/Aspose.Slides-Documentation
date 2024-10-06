---
title: フォント選択シーケンス
linktitle: フォント選択シーケンス
type: docs
weight: 80
url: /ja/php-java/font-selection-sequence/
keywords: "フォント, フォント選択, フォント置換, フォント置き換え, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: PowerPointフォント選択シーケンス
---

## フォント選択

プレゼンテーションがロード、レンダリング、または別の形式に変換される際、フォントに関して特定のルールが適用されます。たとえば、プレゼンテーション（スライド）を画像に変換しようとすると、選択されたフォントがオペレーティングシステムに利用可能か確認するために、プレゼンテーションのフォントがチェックされます。フォントが見つからない場合は、フォントが置き換えられます—[**フォント置換**](https://docs.aspose.com/slides/php-java/font-replacement/)および[**フォント置き換え**](https://docs.aspose.com/slides/php-java/font-substitution/)を参照してください。

Aspose.Slidesがフォントを扱う際のプロセスは次のとおりです：

1. Aspose.Slidesは、プレゼンテーションの選択されたフォントに一致するフォントを見つけるためにオペレーティングシステム内を検索します。
2. 選択されたフォントが見つかった場合、Aspose.Slidesはそれを使用します。見つからない場合、Aspose.SlidesはPowerPointが使用するフォントにできるだけ近い置換フォントを使用します。
3. [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/)を通じてフォント置換ルールが設定されている場合、それが適用されます。

Aspose.Slidesでは、フォントをAsposeランタイムに追加し、それらのフォントを使用することができます。[**カスタムフォント**](https://docs.aspose.com/slides/php-java/custom-font/)を参照してください。

プレゼンテーション内に追加のフォントが配置されている場合、それらは[**埋め込まれたフォント**](https://docs.aspose.com/slides/php-java/embedded-font/)と呼ばれます。

Aspose.Slidesでは、*出力文書のみに*適用されるフォントを追加できます。たとえば、PDFに変換したいプレゼンテーションにシステムに存在しないフォントと埋め込まれたフォントが含まれている場合、必要なフォントを**外部フォント**として追加またはロードできます。