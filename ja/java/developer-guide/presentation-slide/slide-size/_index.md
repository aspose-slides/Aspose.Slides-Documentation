---
title: スライドサイズ
type: docs
weight: 70
url: /ja/java/slide-size/

---

## PowerPoint プレゼンテーションのスライドサイズ

Aspose.Slides for Java を使用すると、PowerPoint プレゼンテーションのスライドサイズまたはアスペクト比を変更できます。プレゼンテーションを印刷したり、そのスライドを画面に表示したりする予定がある場合、スライドサイズまたはアスペクト比に注意を払う必要があります。

一般的なスライドサイズとアスペクト比は以下の通りです：

- **標準 (4:3 アスペクト比)**

  プレゼンテーションが比較的古いデバイスや画面で表示される場合は、この設定を使用することをお勧めします。

- **ワイドスクリーン (16:9 アスペクト比)** 

  プレゼンテーションが最新のプロジェクターやディスプレイで表示される場合は、この設定を利用することをお勧めします。

1つのプレゼンテーションで複数のスライドサイズ設定を使用することはできません。プレゼンテーションのスライドサイズを選択すると、そのスライドサイズ設定はプレゼンテーション内のすべてのスライドに適用されます。

プレゼンテーションに特別なスライドサイズを使用したい場合は、早い段階で行うことを強くお勧めします。理想的には、プレゼンテーションを設定する際、つまりコンテンツを追加する前に、好みのスライドサイズを指定すべきです。このようにすれば、スライドのサイズに対する（将来の）変更による複雑な問題を回避できます。

{{% alert color="primary" %}} 

Aspose.Slides を使用してプレゼンテーションを作成すると、プレゼンテーション内のすべてのスライドは自動的に標準サイズまたは 4:3 アスペクト比になります。

{{% /alert %}} 

## プレゼンテーションのスライドサイズを変更する

このサンプルコードは、Aspose.Slides を使用してプレゼンテーションのスライドサイズを Java で変更する方法を示しています：

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## プレゼンテーションでカスタムスライドサイズを指定する

一般的なスライドサイズ (4:3 および 16:9) が作業に適していない場合、特定のユニークなスライドサイズを使用することを決定するかもしれません。たとえば、プレゼンテーションからフルサイズのスライドをカスタムページレイアウトで印刷する予定がある場合や、特定の画面タイプでプレゼンテーションを表示しようとする場合は、プレゼンテーションのカスタムサイズ設定を利用することで利益を得るでしょう。

このサンプルコードは、Aspose.Slides for Java を使用して、プレゼンテーションに対してカスタムスライドサイズを指定する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## プレゼンテーションでスライドサイズを変更する際の問題への対処

プレゼンテーションのスライドサイズを変更した後、スライドの内容（たとえば画像やオブジェクト）が歪む場合があります。デフォルトでは、オブジェクトは新しいスライドサイズに合わせて自動的にサイズ変更されます。しかし、プレゼンテーションのスライドサイズを変更する際には、Aspose.Slides がスライドの内容にどのように対処するかを決定する設定を指定できます。

何をするか、または達成したいかに応じて、以下の設定のいずれかを使用できます：

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  スライドサイズを小さくスケーリングしたい場合で、すべてのオブジェクトがスライドに収まるように Aspose.Slides にスライドのオブジェクトを縮小させたい場合は、この設定を使用します（これにより、コンテンツを失うのを防ぎます）。

- `Maximize`

  スライドサイズを大きくスケーリングしたい場合で、Aspose.Slides にスライドのオブジェクトを新しいスライドサイズに比例して拡大させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```