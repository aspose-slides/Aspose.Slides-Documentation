---
title: Pythonにおけるフォント選択シーケンス
linktitle: Pythonにおけるフォント選択シーケンス
type: docs
weight: 80
url: /python-net/font-selection-sequence/
keywords:
- フォント
- フォント選択
- フォント置換
- フォント置き換え
- PowerPointプレゼンテーション
- Python
- Aspose.Slides for Python
description: "PythonにおけるPowerPointフォント選択シーケンス"
---

## フォント選択

プレゼンテーションがロード、レンダリング、または他のフォーマットに変換されるときに、フォントに関する特定のルールが適用されます。たとえば、プレゼンテーション（そのスライド）を画像に変換しようとする場合、プレゼンテーションのフォントがオペレーティングシステムで利用可能であるかどうかが確認されます。フォントが不足していることが確認された場合、それらは置き換えられます — 詳細は[**フォント置き換え**](https://docs.aspose.com/slides/python-net/font-replacement/)および[**フォント置換**](https://docs.aspose.com/slides/python-net/font-substitution/)を参照してください。

Aspose.Slidesがフォントを扱う際のプロセスは次のとおりです：

1. Aspose.Slidesはオペレーティングシステム内でフォントを検索し、プレゼンテーションで選択されたフォントに一致するフォントを見つけます。
2. 選択されたフォントが見つかった場合、Aspose.Slidesはそれを使用します。そうでない場合、Aspose.SlidesはPowerPointが使用するものにできるだけ近い置換フォントを使用します。
3. [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/)を通じてフォント置換ルールが設定されている場合、それが適用されます。

Aspose.Slidesはアプリケーションのランタイムにフォントを追加し、そのフォントを使用することを許可します。詳細は[**カスタムフォント**](https://docs.aspose.com/slides/python-net/custom-font/)を参照してください。

プレゼンテーション内に追加のフォントが配置されている場合、それらは[**埋め込みフォント**](https://docs.aspose.com/slides/python-net/embedded-font/)と呼ばれます。

Aspose.Slidesは出力ドキュメントに*のみ*適用されるフォントを追加することを許可します。たとえば、PDFに変換しようとしているプレゼンテーションがシステムにないフォントと埋め込みフォントを含んでいる場合、必要なフォントを**外部フォント**として追加またはロードできます。

{{% alert title="注意" color="primary" %}} 
私たちは有料または無料のフォントを配布することはありません。私たちのAPIは外部フォントをロードし、ドキュメントに埋め込むことを許可しますが、それはユーザーの裁量と責任で行ってください。
{{% /alert %}}