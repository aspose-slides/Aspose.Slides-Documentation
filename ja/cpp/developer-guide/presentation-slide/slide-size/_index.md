---
title: スライドサイズ
type: docs
weight: 70
url: /ja/cpp/slide-size/

---

## PowerPointプレゼンテーションのスライドサイズ

Aspose.Slides for C++を使用すると、PowerPointプレゼンテーションのスライドサイズやアスペクト比を変更できます。プレゼンテーションを印刷する予定がある場合や、スライドを画面で表示する場合は、スライドサイズやアスペクト比に注意を払う必要があります。

これらは最も一般的なスライドサイズとアスペクト比です：

- **標準（4:3アスペクト比）**

  プレゼンテーションが比較的古いデバイスや画面で表示される場合、この設定を使用したいかもしれません。

- **ワイドスクリーン（16:9アスペクト比）**

  プレゼンテーションが最新のプロジェクターやディスプレイで表示される場合、この設定を使用したいかもしれません。

単一のプレゼンテーション内で複数のスライドサイズを設定することはできません。プレゼンテーションのためにスライドサイズを選択すると、そのスライドサイズ設定はプレゼンテーション内のすべてのスライドに適用されます。

プレゼンテーションに特別なスライドサイズを使用したい場合は、できるだけ早めに行うことを強くお勧めします。理想的には、プレゼンテーションを設定している最初の段階、すなわち、コンテンツを追加する前に希望のスライドサイズを指定すべきです。このようにすることで、スライドのサイズに対する（将来の）変更によって生じる複雑さを回避できます。

{{% alert color="primary" %}} 

 Aspose.Slidesを使用してプレゼンテーションを作成すると、すべてのスライドは自動的に標準サイズまたは4:3アスペクト比になります。

{{% /alert %}} 

## プレゼンテーションでのスライドサイズの変更

このサンプルコードは、Aspose.Slidesを使用してC++のプレゼンテーションでスライドサイズを変更する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## プレゼンテーションでのカスタムスライドサイズの指定

一般的なスライドサイズ（4:3および16:9）が作業に適さない場合、特定のユニークなスライドサイズを使用することを決定するかもしれません。たとえば、プレゼンテーションからカスタムページレイアウトでフルサイズのスライドを印刷する予定がある場合や、特定の画面タイプでプレゼンテーションを表示する予定がある場合、プレゼンテーションにカスタムサイズ設定を使用することで利益を得ることができます。

このサンプルコードは、C++でAspose.Slidesを使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4用紙サイズ
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## プレゼンテーションのスライドサイズを変更する際の問題への対処

プレゼンテーションのスライドサイズを変更した後、スライドの内容（画像やオブジェクトなど）が歪む可能性があります。デフォルトでは、オブジェクトは新しいスライドサイズに合わせて自動的にサイズ変更されます。ただし、プレゼンテーションのスライドサイズを変更する際には、Aspose.Slidesがスライド上の内容をどのように扱うかを決定する設定を指定できます。

何をしたいかによって、次のいずれかの設定を使用できます：

- `DoNotScale`

  スライド上のオブジェクトをサイズ変更したくない場合は、この設定を使用します。

- `EnsureFit`

  より小さいスライドサイズにスケールダウンしたい場合、Aspose.Slidesにスライドのオブジェクトをすべてスライドに収まるように縮小させたい場合は、この設定を使用します（これにより、コンテンツの損失を回避できます）。

- `Maximize`

  より大きなスライドサイズにスケールアップしたい場合、Aspose.Slidesにスライドのオブジェクトを新しいスライドサイズに比例して拡大させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に`Maximize`設定を使用する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```