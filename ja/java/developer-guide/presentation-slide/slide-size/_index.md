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
- スライドサイズを設定する
- スライドサイズを変更する
- カスタムスライドサイズ
- 特別なスライドサイズ
- ユニークなスライドサイズ
- フルサイズスライド
- スクリーンタイプ
- スケールしない
- フィットさせる
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドをすばやくリサイズし、画質を損なうことなく任意の画面向けにプレゼンテーションを最適化する方法を学びます。"
---
## **はじめに**

Aspose.Slides は、印刷および画面表示の両方に重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。  

一般的なスライドサイズと比率：

- **Standard (4:3 Aspect Ratio)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 Aspect Ratio)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、作成プロセスの最初にスライドの寸法を設定し、問題を回避してください。

{{% alert color="info" title="Note" %}}
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

ノートページおよび配布資料ページは、通常のスライドとは異なるサイズを持ちます。サイズと向きを変更するには、[Notes Page Size](/slides/ja/java/notes-size/) を参照してください。

## **プレゼンテーションでスライドサイズを変更する**

このサンプルコードは、Java で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示しています。

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

一般的なスライドサイズ（4:3 と 16:9）が作業に適さない場合、特定または独自のスライドサイズを使用することを検討できます。たとえば、プレゼンテーションのスライドをカスタムページレイアウトでフルサイズで印刷したり、特定の画面タイプで表示したりする場合、カスタムサイズ設定を利用すると便利です。

このサンプルコードは、Java 用 Aspose.Slides を使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示しています。

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

プレゼンテーションのスライドサイズを変更すると、スライドのコンテンツ（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは自動的に新しいスライドサイズに合わせてリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツを処理する方法を決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さいスライドサイズに縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides にダウンスケールさせたい場合（コンテンツの損失を防ぐため）この設定を使用します。

- `Maximize`

  大きいスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させるように Aspose.Slides に拡大させたい場合は、この設定を使用します。

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

**インチ以外の単位（たとえばポイントやミリメートル）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、その変換値を使用してスライドの幅と高さを定義できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位のスライド寸法が大きく、かつレンダリングスケールが高いほど、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールを調整して望ましい出力品質を得てください。

**非標準のスライドサイズを定義し、異なるサイズのプレゼンテーションからスライドをマージできますか？**

異なるスライドサイズのままでは[merge presentations](/slides/ja/java/merge-presentation/)できません。まず、どちらかのプレゼンテーションのサイズを他方に合わせてリサイズします。スライドサイズを変更する際、既存コンテンツの処理方法は[SlideSizeScaleType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesizescaletype/) オプションで選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**個別のシェイプやスライドの特定領域のサムネイルを生成できますか？また、新しいスライドサイズを反映しますか？**

はい。Aspose.Slides は[entire slides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) と [selected shapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getImage-int-float-float-) のサムネイルをレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。