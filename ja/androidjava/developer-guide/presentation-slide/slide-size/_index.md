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
- スライドサイズの設定
- スライドサイズの変更
- カスタムスライドサイズ
- 特別なスライドサイズ
- ユニークなスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケールしない
- フィットさせる
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
descriptions: "Java と Aspose.Slides for Android を使用して PPT、PPTX、ODP ファイルのスライドをすばやくリサイズし、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---

## **PowerPoint プレゼンテーションのスライドサイズ**

Aspose.Slides for Android via Java を使用すると、PowerPoint プレゼンテーションのスライドサイズやアスペクト比を変更できます。プレゼンテーションを印刷したり、画面でスライドを表示する場合は、スライドサイズやアスペクト比に注意する必要があります。

以下は最も一般的なスライドサイズとアスペクト比です。

- **標準 (4:3 アスペクト比)**

  プレゼンテーションを比較的古いデバイスや画面で表示または閲覧する場合は、この設定を使用することを検討してください。

- **ワイドスクリーン (16:9 アスペクト比)**

  プレゼンテーションを最新のプロジェクターやディスプレイで表示する場合は、この設定を使用することを検討してください。

1 つのプレゼンテーションで複数のスライドサイズ設定を使用することはできません。プレゼンテーションのスライドサイズを選択すると、その設定がプレゼンテーション内のすべてのスライドに適用されます。

プレゼンテーションに特別なスライドサイズを使用したい場合は、なるべく早い段階で設定することを強くおすすめします。理想的には、プレゼンテーションの作成を開始した直後、コンテンツを追加する前に希望のスライドサイズを指定してください。こうすることで、後からスライドサイズを変更した際に発生する問題を回避できます。

{{% alert color="primary" %}}  
Aspose.Slides を使用してプレゼンテーションを作成すると、すべてのスライドは自動的に標準サイズ（4:3 アスペクト比）になります。  
{{% /alert %}}

## **プレゼンテーションのスライドサイズを変更する**

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

一般的なスライドサイズ（4:3 と 16:9）が作業に合わない場合、特定または固有のスライドサイズを使用することができます。たとえば、カスタムページレイアウトでフルサイズのスライドを印刷する場合や、特定の画面タイプでプレゼンテーションを表示する場合は、カスタムサイズ設定を利用するとメリットがあります。

このサンプルコードは、Java で Aspose.Slides for Android via Java を使用してプレゼンテーションにカスタムスライドサイズを指定する方法を示しています:
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

プレゼンテーションのスライドサイズを変更すると、スライドのコンテンツ（画像やオブジェクトなど）が歪むことがあります。既定では、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを指定できる設定があります。

目的に応じて、次のいずれかの設定を使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さいスライドサイズに縮小する際に、すべてのオブジェクトがスライド内に収まるように Aspose.Slides に縮小させたい場合（コンテンツの欠損を防ぐ）に、この設定を使用します。

- `Maximize`

  大きいスライドサイズに拡大する際に、オブジェクトを新しいスライドサイズに比例させて拡大したい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**カスタムスライドサイズをインチ以外の単位（たとえばポイントやミリメートル）で設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの任意の単位をポイントに換算し、変換した値でスライドの幅と高さを指定できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位でのスライド寸法が大きくなると、レンダリングスケールが高くなるため、メモリ消費が増加し、処理時間も長くなります。実用的なスライドサイズを目安にし、必要に応じてレンダリングスケールを調整して目的の出力品質を得るようにしてください。

**非標準のスライドサイズを 1 つ定義した後、サイズが異なるプレゼンテーションからスライドをマージできますか？**

スライドサイズが異なる状態で [merge presentations](/slides/ja/androidjava/merge-presentation/) はできません。まず、片方のプレゼンテーションをもう片方のサイズに合わせてリサイズします。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/) オプションで既存コンテンツの取り扱い方法を選択できます。サイズを揃えた後は、書式を保持したままスライドをマージできます。

**スライド内の個別のシェイプや特定領域のサムネイルを生成できますか？また、新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は [entire slides]（https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-）だけでなく、[selected shapes]（https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-）のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保ちます。