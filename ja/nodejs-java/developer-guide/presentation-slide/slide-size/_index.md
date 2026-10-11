---
title: JavaScript でプレゼンテーションのスライドサイズを変更する
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/nodejs-java/slide-size/
keywords:
- スライドサイズ
- アスペクト比
- 標準
- ワイドスクリーン
- 4:3
- 16:9
- スライドサイズを設定
- スライドサイズを変更
- カスタムスライドサイズ
- 特別なスライドサイズ
- ユニークなスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケールしない
- フィットを確保
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドをすばやくリサイズし、品質を損なうことなくあらゆる画面向けにプレゼンテーションを最適化する方法を学びます。"
---
## **はじめに**

Aspose.Slides は、印刷や画面表示の両方で重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズと比率:

- **Standard (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに同じスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成プロセスの最初にスライドのサイズを設定し、問題を回避してください。

{{% alert color="info" title="Note" %}}
既定では、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

ノートページと配布資料ページは通常のスライドとは別のサイズを持ちます。サイズや向きを変更するには、[Notes Page Size](/slides/ja/nodejs-java/notes-size/)をご覧ください。

## **プレゼンテーションのスライドサイズを変更する**

 このサンプルコードは、Aspose.Slides を使用して JavaScript でプレゼンテーションのスライドサイズを変更する方法を示します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **プレゼンテーションでカスタムスライドサイズを指定する**

一般的なスライドサイズ（4:3 と 16:9）が作業に適さない場合、特定またはユニークなスライドサイズを使用することを検討できます。たとえば、カスタムページレイアウトでプレゼンテーションのフルサイズスライドを印刷する予定がある場合や、特定の画面タイプでプレゼンテーションを表示する予定がある場合、カスタムサイズ設定を使用すると便利です。

このサンプルコードは、Node.js 用 Aspose.Slides を Java 経由で使用し、JavaScript でプレゼンテーションのカスタムスライドサイズを指定する方法を示します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **プレゼンテーションのスライドサイズ変更時の問題への対処**

プレゼンテーションのスライドサイズを変更すると、スライドの内容（画像やオブジェクトなど）が歪むことがあります。既定では、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さいスライドサイズに縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい場合（これによりコンテンツの損失を防げます）、この設定を使用します。

- `Maximize`

  大きいスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**カスタムスライドサイズをインチ以外の単位（例えばポイントやミリメートル）で設定できますか？**

はい。Aspose.Slides は内部でポイント単位を使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、その変換後の値をスライドの幅と高さの定義に使用できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位でのスライドサイズが大きく、かつレンダリングスケールが高いと、メモリ使用量が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールのみ調整して目的の出力品質を得るようにしてください。

**非標準のスライドサイズを定義した後、異なるサイズのプレゼンテーションからスライドをマージできますか？**

スライドサイズが異なる状態では [merge presentations](/slides/ja/nodejs-java/merge-presentation/) はできません。まず、一方のプレゼンテーションをもう一方に合わせてサイズ変更します。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesizescaletype/) オプションを使用して既存コンテンツの処理方法を選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**スライドの個々のシェイプや特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを尊重しますか？**

はい。Aspose.Slides は、[entire slides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#getImage) と同様に [selected shapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getImage) のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを確保します。