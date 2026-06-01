---
title: PHP におけるプレゼンテーションからの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/php-java/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPoint からテキスト抽出
- OpenDocument からテキスト抽出
- PPT からテキスト抽出
- PPTX からテキスト抽出
- ODP からテキスト抽出
- テキスト取得
- スライドからテキスト取得
- プレゼンテーションからテキスト取得
- PowerPoint からテキスト取得
- OpenDocument からテキスト取得
- PPT からテキスト取得
- PPTX からテキスト取得
- ODP からテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルでステップバイステップのガイドに従って、時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキスト データへのアクセスと取得は、分析、 automation、インデックス作成、コンテンツ移行などの目的で極めて重要です。

本稿では、Aspose.Slides for PHP via Java を使用して PPT、PPTX、ODP のさまざまなプレゼンテーション形式からテキストを効率的に抽出する方法を包括的に解説します。プレゼンテーション要素を体系的に反復処理し、必要なテキスト コンテンツを正確に取得する手順を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for PHP via Java は [SlideUtil](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/) クラスを提供します。このクラスは、プレゼンテーションまたはスライド全体のテキストを抽出するための、複数のオーバーロードされた static メソッドを公開しています。スライド内のテキストを抽出するには、[getAllTextBoxes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/#getAllTextBoxes) メソッドを使用します。このメソッドは [BaseSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/) 型のオブジェクトをパラメータとして受け取ります。実行時にメソッドはスライド全体を走査し、テキストを検出して [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) 型のオブジェクト配列として返し、テキストの書式情報を保持します。

以下のコード スニペットは、プレゼンテーションの最初のスライド