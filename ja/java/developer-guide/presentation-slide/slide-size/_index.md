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
- フィットを保証
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
descriptions: "JavaとAspose.Slidesを使用してPPT、PPTX、ODPファイルのスライドをすばやくリサイズし、品質を損なわずに任意の画面に最適化されたプレゼンテーションを作成する方法をご紹介します。"
---

## **PowerPoint プレゼンテーションのスライド サイズ**

Aspose.Slides for Java を使用すると、PowerPoint プレゼンテーションのスライド サイズまたはアスペクト比を変更できます。プレゼンテーションを印刷したり、画面でスライドを表示したりする場合は、スライド サイズまたはアスペクト比に注意する必要があります。 

最も一般的なスライド サイズとアスペクト比は次のとおりです。

- **Standard (4:3 アスペクト比)**

  プレゼンテーションを比較的古いデバイスや画面で表示または閲覧する場合は、この設定を使用したいかもしれません。 

- **Widescreen (16:9 アスペクト比)** 

  プレゼンテーションを最新のプロジェクターやディスプレイで表示する場合は、この設定を使用したいかもしれません。 

1 つのプレゼンテーションで複数のスライド サイズ設定を使用することはできません。プレゼンテーションのスライド サイズを選択すると、そのサイズ設定がプレゼンテーション内のすべてのスライドに適用されます。 

特別なスライド サイズを使用したい場合は、早めに設定することを強くお勧めします。理想的には、プレゼンテーションの設定段階、つまりコンテンツを追加する前に希望のスライド サイズを指定してください。これにより、スライド サイズの (将来の) 変更による複雑さを回避できます。 

{{% alert color="primary" %}} 

 Aspose.Slides でプレゼンテーションを作成すると、プレゼンテーション内のすべてのスライドは自動的に標準サイズまたは 4:3 アスペクト比になります。

{{% /alert %}} 

## **プレゼンテーションでスライド サイズを変更する**

 次のサンプルコードは、Aspose.Slides を使用して Java でプレゼンテーションのスライド サイズを変更する方法を示しています:
```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **プレゼンテーションでカスタム スライド サイズを指定する**

一般的なスライド サイズ (4:3 と 16:9) が作業に適さない場合、特定またはユニークなスライド サイズを使用することができます。たとえば、カスタムページレイアウトでフルサイズのスライドを印刷したり、特定の画面タイプでプレゼンテーションを表示したりする場合、カスタム サイズ設定が有益です。 

次のサンプルコードは、Aspose.Slides for Java を使用して Java でプレゼンテーションにカスタム スライド サイズを指定する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **サイズ変更後のスライド コンテンツの取り扱い**

プレゼンテーションのスライド サイズを変更すると、スライドのコンテンツ (画像やオブジェクトなど) が歪むことがあります。デフォルトでは、オブジェクトは新しいスライド サイズに合わせて自動的にリサイズされます。ただし、プレゼンテーションのスライド サイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように扱うかを決定する設定を指定できます。

目的や達成したいことに応じて、次の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  小さいスライド サイズに縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい場合 (コンテンツが失われるのを防ぐ) は、この設定を使用します。 

- `Maximize`

  大きいスライド サイズに拡大し、オブジェクトを新しいスライド サイズに比例させて拡大させたい場合は、この設定を使用します。 

次のサンプルコードは、プレゼンテーションのスライド サイズを変更する際に `Maximize` 設定を使用する方法を示しています:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**インチ以外の単位 (ポイントやミリメートルなど) でカスタム スライド サイズを設定できますか？**

はい。Aspose.Slides は内部でポイントを使用します。1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの任意の単位をポイントに変換し、変換後の値でスライドの幅と高さを定義できます。

**非常に大きなカスタム スライド サイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位でのスライド寸法が大きく、レンダリング スケールが高いほど、メモリ消費が増加し、処理時間が長くなります。実用的なスライド サイズを目指し、必要に応じてレンダリング スケールだけを調整して望ましい出力品質を得てください。

**標準外のスライド サイズを 1 つ定義し、サイズが異なるプレゼンテーションからスライドをマージできますか？**

スライド サイズが異なる状態で [merge presentations](/slides/ja/java/merge-presentation/) はできません。まず、どちらかのプレゼンテーションをサイズ合わせにリサイズします。スライド サイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/) オプションで既存コンテンツの取り扱い方法を選択できます。サイズを揃えた後は、書式を保持したままスライドをマージできます。

**個々のシェイプやスライドの特定領域のサムネイルを生成できますか？また、新しいスライド サイズを考慮しますか？**

はい。Aspose.Slides は、[entire slides](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) と [selected shapes](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) のサムネイルをレンダリングできます。生成された画像は現在のスライド サイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。