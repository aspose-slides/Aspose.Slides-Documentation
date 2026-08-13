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
- フィットを確保
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java と Aspose.Slides for Android を使用して PPT、PPTX、ODP ファイルのスライドを迅速にリサイズし、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides は、印刷および画面表示の両方に重要な PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズと比率:

- **Standard (4:3 Aspect Ratio)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 Aspect Ratio)**: 最新のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つため、すべてのスライドは単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成プロセスの開始時にスライドの寸法を設定し、後からの問題を防ぎましょう。

{{% alert color="info" %}} 
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比が使用されます。
{{% /alert %}}

## **プレゼンテーションのスライドサイズの変更**

このサンプルコードは、Java で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示します:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションでカスタムスライドサイズを指定する**

一般的なスライドサイズ（4:3 と 16:9）が作業に適さない場合、特定または独自のスライドサイズを使用することができます。たとえば、カスタムページレイアウトでフルサイズのスライドを印刷する場合や、特定の画面タイプでプレゼンテーションを表示する場合、カスタムサイズ設定が役立ちます。

このサンプルコードは、Java 経由で Android 用 Aspose.Slides を使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示します:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **サイズ変更後のスライドコンテンツの処理**

プレゼンテーションのスライドサイズを変更すると、スライド上のコンテンツ（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは自動的に新しいスライドサイズに合わせてリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように扱うかを決定する設定を指定できます。

目的や達成したい結果に応じて、次のいずれかの設定を使用できます:

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さなスライドサイズに縮小し、すべてのオブジェクトがスライド内に収まるように Aspose.Slides に縮小させたい場合は、この設定を使用します（コンテンツの欠落を防ぎます）。

- `Maximize`

  大きなスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示します:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### インチ以外の単位（例えばポイントやミリメートル）でカスタムスライドサイズを設定できますか？

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、変換後の値でスライドの幅と高さを定義できます。

### 非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？

はい。ポイント単位でのスライド寸法が大きくなるほど、レンダリングスケールが高くなり、メモリ使用量と処理時間が増加します。実用的なスライドサイズを目指し、必要な出力品質を得るためにのみレンダリングスケールを調整してください。

### 標準外のスライドサイズを1つ定義し、サイズが異なるプレゼンテーションからスライドをマージできますか？

サイズが異なる状態でプレゼンテーションを[merge presentations](/slides/ja/androidjava/merge-presentation/)することはできません。まず、片方のプレゼンテーションをもう一方に合わせてリサイズします。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesizescaletype/) オプションを使用して既存コンテンツの取り扱い方法を選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

### スライド内の個別のシェイプや特定領域のサムネイルを生成できますか？また、新しいスライドサイズを尊重しますか？

はい。Aspose.Slides は[entire slides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)だけでなく、[selected shapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫した構図とジオメトリを保ちます。