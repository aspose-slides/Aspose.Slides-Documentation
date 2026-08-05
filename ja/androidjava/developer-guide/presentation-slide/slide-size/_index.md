---
title: Android でプレゼンテーションのスライドサイズを変更する
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/androidjava/slide-size/
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
- フィットを保証
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java と Android 用 Aspose.Slides を使用して、PPT、PPTX、ODP ファイルのスライドを素早くリサイズし、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **はじめに**

Aspose.Slides は、印刷や画面表示の両方に重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズと比率:

- **標準 (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **ワイドスクリーン (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を確保するため、すべてのスライドに単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、作成プロセスの初めにスライドの寸法を設定し、問題を防ぎましょう。

{{% alert color="primary" %}} 
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションのスライドサイズを変更する**

このサンプルコードは、Aspose.Slides を使用した Java でプレゼンテーションのスライドサイズを変更する方法を示しています。

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

一般的なスライドサイズ（4:3 と 16:9）が作業に適さない場合、特定のユニークなスライドサイズを使用することができます。たとえば、カスタムページレイアウトでプレゼンテーションからフルサイズのスライドを印刷する場合や、特定の画面タイプでプレゼンテーションを表示する場合、カスタムサイズ設定を利用すると便利です。

このサンプルコードは、Java 経由で Android 用 Aspose.Slides を使用し、プレゼンテーションのカスタムスライドサイズを指定する方法を示しています。

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **サイズ変更後のスライドコンテンツの取り扱い**

プレゼンテーションのスライドサイズを変更すると、スライドの内容（画像やオブジェクトなど）が歪むことがあります。既定では、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さいスライドサイズに縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides にダウンスケールさせたい場合（コンテンツの損失を防ぐため）この設定を使用します。

- `Maximize`

  大きいスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示しています。

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **よくある質問**

**インチ以外の単位（たとえばポイントやミリメートル）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、その変換値を使用してスライドの幅と高さを定義できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位で大きなスライドサイズと高いレンダリング倍率を組み合わせると、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリング倍率を調整して目的の出力品質を得るようにしてください。

**非標準のスライドサイズを定義し、サイズが異なるプレゼンテーションからスライドをマージできますか？**

スライドサイズが異なる状態では[プレゼンテーションをマージ](/slides/ja/androidjava/merge-presentation/)できません—まず、1つのプレゼンテーションをもう一方に合わせてリサイズします。スライドサイズを変更する際は、既存コンテンツの処理方法を[SlideSizeScaleType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesizescaletype/)オプションで選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**スライドの個別のシェイプや特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は、[全スライド](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) のサムネイルだけでなく、[選択されたシェイプ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを確保します。