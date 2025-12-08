---
title: スライドサイズ
type: docs
weight: 70
url: /ja/nodejs-java/slide-size/
---

## **PowerPoint プレゼンテーションのスライドサイズ**

Aspose.Slides for Node.js via Java を使用すると、PowerPoint プレゼンテーションのスライドサイズやアスペクト比を変更できます。プレゼンテーションを印刷したり、スライドを画面に表示したりする場合は、スライドサイズやアスペクト比に注意する必要があります。

以下は最も一般的なスライドサイズとアスペクト比です。

- **標準 (4:3 アスペクト比)**

  プレゼンテーションが比較的古いデバイスや画面で表示・閲覧される場合は、この設定を使用するとよいでしょう。

- **ワイドスクリーン (16:9 アスペクト比)**

  プレゼンテーションが最新のプロジェクターやディスプレイで表示される場合は、この設定を使用するとよいでしょう。

単一のプレゼンテーションで複数のスライドサイズ設定を使用することはできません。プレゼンテーションのスライドサイズを選択すると、その設定がプレゼンテーション内のすべてのスライドに適用されます。

特別なスライドサイズを使用したい場合は、できるだけ早い段階で設定することを強くおすすめします。理想的には、プレゼンテーションの設定段階、すなわちコンテンツを追加する前に希望のスライドサイズを指定してください。これにより、スライドサイズの（将来的な）変更による問題を回避できます。

{{% alert color="primary" %}} 
Aspose.Slides を使用してプレゼンテーションを作成すると、すべてのスライドは自動的に標準サイズ（4:3 アスペクト比）になります。
{{% /alert %}} 

## **プレゼンテーションでのスライドサイズの変更**

このサンプルコードは、Aspose.Slides を使用して JavaScript でプレゼンテーションのスライドサイズを変更する方法を示しています:
```javascript
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

一般的なスライドサイズ（4:3 および 16:9）が目的に合わない場合、特定またはユニークなスライドサイズを使用することができます。たとえば、プレゼンテーションのスライドをカスタムページレイアウトでフルサイズ印刷したい場合や、特定の画面タイプで表示したい場合は、カスタムサイズ設定が役立ちます。

このサンプルコードは、Aspose.Slides for Node.js via Java を使用して JavaScript でプレゼンテーションのカスタムスライドサイズを指定する方法を示しています:
```javascript
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

プレゼンテーションのスライドサイズを変更すると、スライドの内容（画像やオブジェクトなど）が歪むことがあります。既定では、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように扱うかを示す設定を指定できます。

目的に応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さいスライドサイズに縮小する際に、すべてのオブジェクトがスライド内に収まるように自動で縮小させ、コンテンツが失われないようにしたい場合は、この設定を使用します。

- `Maximize`

  大きいスライドサイズに拡大する際に、オブジェクトを拡大して新しいスライドサイズに比例させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示しています:
```javascript
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

**カスタムスライドサイズをインチ以外の単位（ポイントやミリメートルなど）で設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの単位をポイントに変換し、その値でスライドの幅と高さを定義できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位でのスライドサイズが大きくなるほど、レンダリングスケールが高くなり、メモリ消費と処理時間が増加します。実用的なスライドサイズを目安とし、必要な出力品質を得るためにのみレンダリングスケールを調整してください。

**標準外のスライドサイズを1つ定義し、サイズが異なるプレゼンテーションからスライドをマージできますか？**

サイズが異なる状態で [merge presentations](/slides/ja/nodejs-java/merge-presentation/) はできません。まず、どちらかのプレゼンテーションのサイズを合わせてください。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの扱いを選択できます。サイズを揃えた後は、書式を保持したままスライドをマージできます。

**スライド内の個別のシェイプや特定領域のサムネイルを生成でき、そのサムネイルは新しいスライドサイズを反映しますか？**

はい。Aspose.Slides は [entire slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) と [selected shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) のサムネイルをレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保ちます。