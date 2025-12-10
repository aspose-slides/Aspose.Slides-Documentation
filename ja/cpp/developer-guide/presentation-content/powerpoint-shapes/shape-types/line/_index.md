---
title: C++でプレゼンテーションにラインシェイプを追加する
linktitle: ライン
type: docs
weight: 50
url: /ja/cpp/line/
keywords:
- ライン
- ライン作成
- ライン追加
- プレーンライン
- ライン設定
- ラインカスタマイズ
- ダッシュスタイル
- 矢印ヘッド
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションのライン書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルをご紹介します。"
---

## **プレーンラインの作成**
プレゼンテーションの選択されたスライドにシンプルなプレーンラインを追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが提供する[AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/)メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドにラインを追加しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **矢印形状のラインの作成**
Aspose.Slides for C++ は、ラインの外観を向上させるためにいくつかのプロパティを設定できるようにします。ラインを矢印のように見せるためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
- Aspose.Slides for C++ が提供するスタイルのいずれかに Line Style を設定します。
- ラインの幅を設定します。
- ラインの[Dash Style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/)を Aspose.Slides for C++ が提供するスタイルのいずれかに設定します。
- ラインの開始点の[Arrow Head Style](https://reference.aspose.com/slides/cpp/aspose.slides/lineformat/)と長さを設定します。
- ラインの終了点の Arrow Head Style と長さを設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**通常のラインをコネクタに変換して、図形に「スナップ」させることはできますか？**

いいえ。通常のライン（[AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) の[Line](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。図形にスナップさせるには、専用の[Connector](https://reference.aspose.com/slides/cpp/aspose.slides/connector/) タイプと、接続用の[corresponding APIs](/slides/ja/cpp/connector/) を使用してください。

**ラインのプロパティがテーマから継承されていて最終的な値を判定しにくい場合はどうすればよいですか？**

[有効なプロパティを読む](/slides/ja/cpp/shape-effective-properties/) を、[ILineFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformateffectivedata/) インターフェイスを通じて行います—これらは継承とテーマスタイルをすでに考慮しています。

**ラインを編集（移動やサイズ変更）からロックできますか？**

はい。Shapes は[ロック オブジェクト](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/get_autoshapelock/)を提供しており、これにより[編集操作の禁止](/slides/ja/cpp/applying-protection-to-presentation/)が可能です。