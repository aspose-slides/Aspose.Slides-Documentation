---
title: Android のプレゼンテーション スライドサイズを変更する
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
- ユニークスライドサイズ
- フルサイズスライド
- スクリーンタイプ
- スケールしない
- フィットを確保
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java と Aspose.Slides for Android を使用して PPT、PPTX、ODP ファイルのスライドを素早くリサイズし、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **はじめに**

Aspose.Slides は、印刷や画面表示の両方に重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズとアスペクト比:

- **Standard (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成プロセスの開始時にスライドの寸法を設定し、問題を回避してください。

{{% alert color="info" title="Note" %}}
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

ノートページと配布資料ページは、通常のスライドとは別の寸法を持ちます。サイズと向きを変更するには、[ノートページサイズ](/slides/ja/androidjava/notes-size/) を参照してください。

## **プレゼンテーションでスライドサイズを変更する**

このサンプルコードは、Java で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示します。

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

一般的なスライドサイズ (4:3 および 16:9) が作業に適さない場合、特定またはユニークなスライドサイズを使用することを検討できます。例えば、プレゼンテーションのスライドをカスタムページレイアウトでフルサイズで印刷する場合や、特定の画面タイプで表示する場合、カスタムサイズ設定を使用するとメリットがあります。

このサンプルコードは、Java 経由で Android 用 Aspose.Slides を使用し、プレゼンテーションのカスタムスライドサイズを指定する方法を示します。

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

プレゼンテーションのスライドサイズを変更すると、スライドのコンテンツ（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは自動的に新しいスライドサイズに合わせてリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  より小さなスライドサイズにスケーリングし、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい場合（コンテンツの喪失を防ぐため）、この設定を使用します。

- `Maximize`

  より大きなスライドサイズにスケーリングし、オブジェクトを拡大して新しいスライドサイズに比例させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示します。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **よくある質問**

**カスタムスライドサイズをインチ以外の単位（例：ポイントやミリメートル）で設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントはインチの 1/72 に相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、変換した値でスライドの幅と高さを定義できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位での大きなスライド寸法に加えて、レンダリングスケールが高くなると、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールを調整して希望の出力品質を得てください。

**非標準のスライドサイズを定義した上で、異なるサイズのプレゼンテーションからスライドをマージできますか？**

異なるスライドサイズのままでは[プレゼンテーションのマージ](/slides/ja/androidjava/merge-presentation/)できません。まず、片方のプレゼンテーションのサイズをもう一方に合わせてリサイズします。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後は、書式を保持したままスライドをマージできます。

**個々のシェイプやスライドの特定領域のサムネイルを生成できますか？また、新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は、[スライド全体](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)や[選択されたシェイプ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)のサムネイルをレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。