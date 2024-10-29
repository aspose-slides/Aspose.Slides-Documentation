---
title: スライドサイズ
type: docs
weight: 70
url: /ja/androidjava/slide-size/

---

## PowerPointプレゼンテーションのスライドサイズ

Aspose.Slides for Android via Javaを使用すると、PowerPointプレゼンテーションのスライドサイズやアスペクト比を変更できます。プレゼンテーションを印刷したり、そのスライドを画面に表示したりする予定がある場合は、スライドサイズやアスペクト比に注意を払う必要があります。

これらは最も一般的なスライドサイズとアスペクト比です：

- **標準 (4:3アスペクト比)**

  プレゼンテーションが比較的古いデバイスや画面で表示される場合は、この設定を使用することを検討してください。

- **ワイドスクリーン (16:9アスペクト比)** 

  プレゼンテーションが最新のプロジェクターやディスプレイで表示される場合は、この設定を使用することを検討してください。

単一のプレゼンテーション内で複数のスライドサイズ設定を使用することはできません。プレゼンテーションのスライドサイズを選択すると、そのスライドサイズ設定はプレゼンテーション内のすべてのスライドに適用されます。

プレゼンテーションに特別なスライドサイズを使用することを希望する場合は、早めに行うことを強く推奨します。理想的には、プレゼンテーションの設定を行っている段階、つまりコンテンツを追加する前に好みのスライドサイズを指定すべきです。この方法で、スライドのサイズに関する（将来の）変更から生じる複雑さを避けることができます。

{{% alert color="primary" %}} 

 Aspose.Slidesを使用してプレゼンテーションを作成する場合、プレゼンテーション内のすべてのスライドは自動的に標準サイズまたは4:3アスペクト比を取得します。

{{% /alert %}} 

## プレゼンテーション内のスライドサイズの変更 

 このサンプルコードは、Aspose.Slidesを使用してJavaでプレゼンテーション内のスライドサイズを変更する方法を示しています：

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## プレゼンテーション内でのカスタムスライドサイズの指定

一般的なスライドサイズ（4:3および16:9）が作業に適していない場合、特定のスライドサイズまたはユニークなスライドサイズを使用することを考えるかもしれません。たとえば、カスタムページレイアウトでフルサイズのスライドを印刷する予定がある場合や、特定の画面タイプでプレゼンテーションを表示するつもりがある場合は、プレゼンテーションのためにカスタムサイズ設定を使用することでメリットを得るでしょう。

このサンプルコードは、Javaでのプレゼンテーション用にAspose.Slides for Android via Javaを使用してカスタムスライドサイズを指定する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4用紙サイズ
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## プレゼンテーション内のスライドサイズを変更する際の問題への対処

プレゼンテーションのスライドサイズを変更した後、スライドの内容（画像やオブジェクトなど）が歪む可能性があります。デフォルトでは、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、プレゼンテーションのスライドサイズを変更する際には、Aspose.Slidesがスライドの内容に対処する方法を決定する設定を指定できます。

あなたの目的に応じて、次の設定のいずれかを使用できます：

- `DoNotScale`

  スライドのオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  スライドサイズを小さくスケーリングしたい場合で、Aspose.Slidesにスライドのオブジェクトを縮小してすべての内容がスライドに収まるようにする必要がある場合は、この設定を使用します（こうすることで、内容を失うことを避けられます）。

- `Maximize`

  スライドサイズを大きくスケーリングしたい場合で、Aspose.Slidesにスライドのオブジェクトを新しいスライドサイズに比例させて拡大させる必要がある場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に`Maximize`設定を使用する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```