---
title: Java でプレゼンテーションのスライドサイズを変更する
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
- フィットを保証
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドをすばやくリサイズし、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化する方法を学びます。"
---
## **はじめに**

Aspose.Slides は、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供し、印刷や画面表示の両方に重要です。

一般的なスライドサイズと比率:

- **標準 (4:3 アスペクト比)**: 従来の画面やデバイスに最適です。
- **ワイドスクリーン (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つため、すべてのスライドに同じスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成の最初の段階でスライドの寸法を設定し、後からの問題を防ぎましょう。

{{% alert color="info" %}} 
デフォルトでは、Aspose.Slidesで作成されたプレゼンテーションは標準の4:3アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションのスライドサイズを変更する**

このサンプルコードは、Aspose.Slides for Java を使用してプレゼンテーションのスライドサイズを変更する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションでカスタムスライドサイズを指定する**

一般的なスライドサイズ（4:3 と 16:9）が用途に合わない場合、特定のカスタムスライドサイズを使用することができます。たとえば、カスタムページレイアウトでプレゼンテーションのフルサイズスライドを印刷したい場合や、特定の画面タイプでプレゼンテーションを表示したい場合は、カスタムサイズ設定が有効です。

このサンプルコードは、Aspose.Slides for Java を使用して Java でプレゼンテーションのカスタムスライドサイズを指定する方法を示しています。

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

プレゼンテーションのスライドサイズを変更すると、スライドの内容（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは自動的に新しいスライドサイズに合わせてリサイズされます。ただし、スライドサイズ変更時に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを決める設定を指定できます。

目的や達成したい結果に応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  スライドサイズを小さく縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい場合（コンテンツの欠落を防ぐため）には、この設定を使用します。

- `Maximize`

  スライドサイズを大きく拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示しています。

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

### インチ以外の単位（たとえばポイントやミリメートル）でカスタムスライドサイズを設定できますか？

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、変換後の値でスライドの幅と高さを設定できます。

### 非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？

はい。ポイント単位で大きなスライド寸法に高いレンダリングスケールを組み合わせると、メモリ使用量が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールを調整して目的の出力品質を得てください。

### 標準外のスライドサイズを一つ定義し、サイズが異なるプレゼンテーションからスライドを結合できますか？

スライドサイズが異なる状態では、[プレゼンテーションを結合](/slides/ja/java/merge-presentation/)できません—まず、一方のプレゼンテーションのサイズをもう一方に合わせてリサイズします。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後、書式を保持したままスライドを結合できます。

### 個別のシェイプやスライドの特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを尊重しますか？

はい。Aspose.Slides は[スライド全体](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)および[選択したシェイプ](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getImage-int-float-float-)のサムネイルを生成できます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。