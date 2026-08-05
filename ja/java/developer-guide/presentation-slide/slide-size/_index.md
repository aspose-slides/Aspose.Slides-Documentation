---
title: Javaでプレゼンテーションのスライドサイズを変更する
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/java/slide-size/
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
- フィット保証
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを手早くリサイズし、品質を損なうことなくあらゆる画面向けにプレゼンテーションを最適化する方法を学びます。"
---
## **導入**

Aspose.Slides は、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。印刷や画面表示の両方に重要です。

一般的なスライドサイズと比率:

- **標準 (4:3 アスペクト比)**：古い画面やデバイスに最適です。
- **ワイドスクリーン (16:9 アスペクト比)**：最新のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成の初期段階でスライド寸法を設定し、問題を回避してください。

{{% alert color="primary" %}} 
既定では、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションでスライドサイズを変更する**

このサンプルコードは、Java で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示しています:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションでカスタムスライドサイズを指定する**

一般的なスライドサイズ (4:3 と 16:9) が作業に適さない場合、特定または固有のスライドサイズを使用することができます。たとえば、カスタムページレイアウトでプレゼンテーションのフルサイズスライドを印刷する場合や、特定の画面タイプでプレゼンテーションを表示する場合、カスタムサイズ設定を使用すると便利です。

このサンプルコードは、Java 用 Aspose.Slides を使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示しています:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 紙サイズ
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **サイズ変更後のスライドコンテンツの処理**

プレゼンテーションのスライドサイズを変更すると、スライドの内容（画像やオブジェクトなど）が歪むことがあります。既定では、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます:

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さいスライドサイズに縮小したい場合で、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい（これによりコンテンツの欠落を防げます）場合は、この設定を使用します。

- `Maximize`

  大きいスライドサイズに拡大したい場合で、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示しています:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **よくある質問**

**インチ以外の単位（ポイントやミリメートルなど）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの任意の単位をポイントに変換し、変換後の値でスライドの幅と高さを定義できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位で大きなスライド寸法と高いレンダリングスケールを組み合わせると、メモリ消費が増加し、処理時間も長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールのみ調整して目的の出力品質を得てください。

**非標準のスライドサイズを1つ定義し、異なるサイズのプレゼンテーションからスライドをマージできますか？**

異なるスライドサイズのままは [プレゼンテーションをマージ](/slides/ja/java/merge-presentation/)できません。まず、どちらかのプレゼンテーションをサイズを合わせてリサイズします。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**スライドの個々のシェイプや特定領域のサムネイルを生成できますか？ それらは新しいスライドサイズを尊重しますか？**

はい。Aspose.Slides は、[スライド全体]((https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)) と [選択したシェイプ]((https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getImage-int-float-float-)) のサムネイルをレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。