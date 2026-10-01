---
title: PHP でプレゼンテーションのスライドサイズを変更する
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/php-java/slide-size/
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
- 独自のスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケールしない
- フィットさせる
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PPT、PPTX、ODP ファイルのスライドを PHP と Aspose.Slides で迅速にリサイズする方法を学び、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **はじめに**

Aspose.Slides は、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供し、印刷や画面表示の両方に重要です。

一般的なスライドサイズと比率:

- **Standard (4:3 Aspect Ratio)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 Aspect Ratio)**: 最新のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドは同一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成の初期段階でスライドの寸法を設定し、問題を回避してください。

{{% alert color="info" title="Note" %}}
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

ノートと配布資料ページは通常のスライドとは別のサイズを持ちます。サイズや向きを変更するには、[ノートページサイズ](/slides/ja/php-java/notes-size/) を参照してください。

## **プレゼンテーションのスライドサイズを変更する**

このサンプルコードは、Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示します。

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **プレゼンテーションでカスタムスライドサイズを指定する**

一般的なスライドサイズ（4:3 や 16:9）が作業に適さない場合、特定のカスタムスライドサイズを使用することができます。たとえば、カスタムページレイアウトでプレゼンテーションのフルサイズスライドを印刷する場合や、特定の画面タイプでプレゼンテーションを表示する場合は、カスタムサイズ設定を利用すると便利です。

このサンプルコードは、PHP 用 Aspose.Slides（Java 経由）を使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示します。

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4 用紙サイズ

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **サイズ変更後のスライドコンテンツの処理**

プレゼンテーションのスライドサイズを変更すると、スライドのコンテンツ（画像やオブジェクトなど）が歪む可能性があります。デフォルトでは、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`

  スライドサイズを小さく縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい場合（コンテンツの損失を防ぐため）に、この設定を使用します。

- `Maximize`

  スライドサイズを大きく拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示します。

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **よくある質問**

**カスタムスライドサイズをインチ以外の単位（ポイントやミリメートルなど）で設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの任意の単位をポイントに変換し、変換後の値をスライドの幅と高さの定義に使用できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位での大きなスライド寸法と高いレンダリングスケールを組み合わせると、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、出力品質を得るために必要な場合のみレンダリングスケールを調整してください。

**非標準のスライドサイズを1つ定義し、サイズが異なるプレゼンテーションからスライドをマージできますか？**

サイズが異なるプレゼンテーションは、[プレゼンテーションのマージ](/slides/ja/php-java/merge-presentation/) できません。最初に、どちらかのプレゼンテーションのサイズをもう一方に合わせてリサイズしてください。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後、書式設定を保持したままスライドをマージできます。

**個々のシェイプやスライドの特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は、[スライド全体](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage)だけでなく、[選択したシェイプ](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getImage)のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。