---
title: C++でプレゼンテーションスライドを比較する
linktitle: スライドの比較
type: docs
weight: 50
url: /ja/cpp/compare-slides/
keywords:
- スライドの比較
- スライド比較
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションをプログラムで比較します。コード内でスライドの違いをすばやく特定できます。"
---

## **2 つのスライドを比較する**
Equals メソッドが IBaseSlide インターフェイスと BaseSlide クラスに追加されました。構造と静的コンテンツが同一のスライド / レイアウトスライド / マスタースライドに対して true を返します。

すべてのシェイプ、スタイル、テキスト、アニメーション、その他の設定が同一である場合、2 つのスライドは等しいとみなされます。比較では SlideId などの一意識別子や、Date Placeholder の現在の日付値などの動的コンテンツは考慮されません。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **FAQ**

**スライドが非表示であることは、スライド自体の比較に影響しますか？**

[Hidden status](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/) はプレゼンテーション/再生レベルのプロパティであり、視覚的コンテンツではありません。2 つの特定のスライドの等価性は、その構造と静的コンテンツによって決まります。スライドが非表示であるという事実だけでは、スライドは異なるものとはみなされません。

**ハイパーリンクとそのパラメータは考慮されますか？**

はい。リンクはスライドの静的コンテンツの一部です。URL やハイパーリンク アクションが異なる場合、通常は静的コンテンツの違いとして扱われます。

**チャートが外部の Excel ファイルを参照している場合、そのファイルの内容は考慮されますか？**

いいえ。比較はスライド自体に基づいて行われます。外部データ ソースは比較時に読み取られないのが一般的で、スライドの構造と静的状態に存在するものだけが考慮されます。