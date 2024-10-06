---
title: スライドサイズ
type: docs
weight: 70
url: /ja/python-net/slide-size/
keywords: "スライドの設定、スライドサイズの編集、PowerPointプレゼンテーション、カスタムスライドサイズ、スライドの問題を解決する、Python、Aspose.Slides"
descriptions: "PythonでPowerPointのスライドサイズやアスペクト比を設定および編集する"
---

## PowerPointプレゼンテーションのスライドサイズ

Aspose.Slides for Python via .NETを使用すると、PowerPointプレゼンテーションのスライドサイズやアスペクト比を変更できます。プレゼンテーションを印刷したり、スライドをスクリーンに表示したりする場合は、スライドサイズやアスペクト比に注意する必要があります。

一般的なスライドサイズとアスペクト比は以下の通りです。

- **標準 (4:3 アスペクト比)**

  プレゼンテーションが比較的古いデバイスやスクリーンで表示される場合は、この設定を使用することを検討してください。

- **ワイドスクリーン (16:9 アスペクト比)** 

  プレゼンテーションが最新のプロジェクターやディスプレイで見られる場合は、この設定を使用することを検討してください。

単一のプレゼンテーション内で複数のスライドサイズ設定を使用することはできません。プレゼンテーションのスライドサイズを選択すると、そのスライドサイズ設定がプレゼンテーションのすべてのスライドに適用されます。

特別なスライドサイズをプレゼンテーションで使用したい場合は、早めに行うことを強くお勧めします。理想的には、プレゼンテーションを設定しているとき、つまりコンテンツを追加する前に、好みのスライドを指定すべきです。これにより、将来のスライドサイズの変更による複雑さを回避できます。

{{% alert color="primary" %}} 

 Aspose.Slidesを使用してプレゼンテーションを作成すると、自動的にすべてのスライドが標準サイズの4:3アスペクト比になります。

{{% /alert %}} 

## プレゼンテーション内のスライドサイズの変更

このサンプルコードは、Aspose.Slidesを使用してPythonでプレゼンテーション内のスライドサイズを変更する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## プレゼンテーション内のカスタムスライドサイズの指定

一般的なスライドサイズ（4:3および16:9）が作業に適していない場合、特定のまたはユニークなスライドサイズを使用することを決定することができます。たとえば、プレゼンテーションからフルサイズのスライドをカスタムページレイアウトで印刷する予定がある場合や、特定の画面タイプでプレゼンテーションを表示する予定がある場合、プレゼンテーションのカスタムサイズ設定を使用すると便利です。

このサンプルコードは、Aspose.Slides for Python via .NETを使用して、Pythonでプレゼンテーションのカスタムスライドサイズを指定する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4用紙サイズ
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## プレゼンテーション内のスライドサイズ変更時の問題への対処

プレゼンテーションのスライドサイズを変更した後、スライドの内容（画像やオブジェクトなど）が歪む可能性があります。デフォルトでは、オブジェクトは新しいスライドサイズに合わせて自動的にサイズ変更されます。ただし、プレゼンテーションのスライドサイズを変更する際には、Aspose.Slidesがスライド上の内容にどのように対処するかを決定する設定を指定できます。

何をしたいか、または達成したいかに応じて、次の設定のいずれかを使用できます。

- `DO_NOT_SCALE`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `ENSURE_FIT`

  小さいスライドサイズにスケールダウンし、Aspose.Slidesにすべてのオブジェクトがスライドに収まるようにスケールダウンさせたい場合（これにより、コンテンツを失うことを避けられます）には、この設定を使用します。

- `MAXIMIZE`

  大きいスライドサイズにスケールアップし、Aspose.Slidesに新しいスライドサイズに比例するようにオブジェクトを拡大させたい場合には、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に`MAXIMIZE`設定を使用する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```