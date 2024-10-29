---
title: Javaにおけるフォント選択シーケンス
linktitle: Javaにおけるフォント選択シーケンス
type: docs
weight: 80
url: /ja/java/font-selection-sequence/
keywords:
- フォント
- フォント選択
- フォント置換
- フォント置き換え
- PowerPointプレゼンテーション
- Java
- Aspose.Slides for Java
description: JavaにおけるPowerPointフォント選択シーケンス
---

## フォント選択

プレゼンテーションが読み込まれ、レンダリングされ、または別の形式に変換される際には、フォントに適用される特定のルールがあります。例えば、プレゼンテーション（そのスライド）を画像に変換しようとすると、選択したフォントがオペレーティングシステムで利用可能かどうかを確認するために、プレゼンテーションのフォントがチェックされます。フォントが欠けていると確認された場合、フォントは置き換えられます — [**フォント置き換え**](https://docs.aspose.com/slides/java/font-replacement/)と[**フォント置換**](https://docs.aspose.com/slides/java/font-substitution/)の詳細を参照してください。

Aspose.Slidesがフォントを扱う際のプロセスは次のとおりです。

1. Aspose.Slidesは、プレゼンテーションの選択されたフォントに一致するフォントを見つけるために、オペレーティングシステム内のフォントを検索します。
2. 選択されたフォントが見つかった場合、Aspose.Slidesはそれを使用します。そうでない場合、Aspose.SlidesはPowerPointが使用するものにできるだけ近い置換フォントを使用します。
3. [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/)を通じてフォント置換ルールが設定されている場合は、それが適用されます。

Aspose.Slidesでは、アプリケーションのランタイムにフォントを追加し、そのフォントを使用することができます。[**カスタムフォント**](https://docs.aspose.com/slides/java/custom-font/)を参照してください。

プレゼンテーション内に追加のフォントが配置されている場合、それは[**埋め込みフォント**](https://docs.aspose.com/slides/java/embedded-font/)と呼ばれます。

Aspose.Slidesでは、*のみ*出力ドキュメントに適用されるフォントを追加できます。例えば、PDFに変換しようとしているプレゼンテーションに、システムに存在しないフォントや埋め込みフォントが含まれている場合、必要なフォントを**外部フォント**として追加または読み込むことができます。

{{% alert title="注意" color="primary" %}} 
私たちは有料または無料のフォントを配布していません。当社のAPIでは、外部フォントを読み込んでドキュメントに埋め込むことができますが、フォントはお客様の裁量と責任で使用してください。
{{% /alert %}}