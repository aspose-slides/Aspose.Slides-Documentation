---
title: Javaにおけるフォント選択シーケンス
linktitle: Javaにおけるフォント選択シーケンス
type: docs
weight: 80
url: /ja/androidjava/font-selection-sequence/
keywords:
- フォント
- フォント選択
- フォント置換
- フォント変更
- PowerPointプレゼンテーション
- Java
- Aspose.Slides for Android via Java
description: JavaにおけるPowerPointのフォント選択シーケンス
---

## フォント選択

プレゼンテーションを読み込んだり、レンダリングしたり、他のフォーマットに変換したりする際には、特定のルールがフォントに適用されます。例えば、プレゼンテーション（そのスライド）を画像に変換しようとすると、選択されたフォントがオペレーティングシステムで利用可能かどうかが確認されます。フォントが欠如していると確認された場合は、それらは置き換えられます — 詳細は[**フォント変更**](https://docs.aspose.com/slides/androidjava/font-replacement/)および[**フォント置換**](https://docs.aspose.com/slides/androidjava/font-substitution/)を参照してください。

Aspose.Slidesがフォントを扱う際のプロセスは次の通りです：

1. Aspose.Slidesは、オペレーティングシステム内でプレゼンテーションの選択されたフォントに一致するフォントを検索します。 
2. 選択されたフォントが見つかれば、Aspose.Slidesはそれを使用します。そうでなければ、Aspose.SlidesはPowerPointが使用するフォントにできるだけ近い置換フォントを使用します。
3. [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/)を通じてフォント置換ルールが設定されている場合、それが適用されます。

Aspose.Slidesは、アプリケーションのランタイムにフォントを追加し、それらを使用できるようにします。詳しくは[**カスタムフォント**](https://docs.aspose.com/slides/androidjava/custom-font/)を参照してください。

プレゼンテーション内に追加のフォントが配置されると、それらは[**埋め込まれたフォント**](https://docs.aspose.com/slides/androidjava/embedded-font/)と呼ばれます。

Aspose.Slidesは、*出力ドキュメントにのみ*適用されるフォントを追加することを許可します。例えば、PDFに変換しようとしているプレゼンテーションに、システムに存在しないフォントや埋め込まれたフォントが含まれている場合、必要なフォントを**外部フォント**として追加または読み込むことができます。

{{% alert title="注意" color="primary" %}} 
私たちは、有料または無料のフォントを配布していません。私たちのAPIは外部フォントを読み込み、ドキュメントに埋め込むことを可能にしますが、これはあなたの裁量と責任で行ってください。
{{% /alert %}}