---
title: PHPでプレゼンテーションのスライドサイズを変更する
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
- スライドサイズを設定する
- スライドサイズを変更する
- カスタムスライドサイズ
- 特別なスライドサイズ
- ユニークなスライドサイズ
- フルサイズスライド
- スクリーンタイプ
- スケールしない
- フィットを確保する
- 最大化する
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを迅速にリサイズし、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化する方法を学びます。"
---
## **紹介**

Aspose.Slides は、印刷および画面表示の両方に重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズと比率:

- **Standard (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドは単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、作成プロセスの最初にスライドの寸法を設定し、問題を回避してください。

{{% alert color="primary" %}} 
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションのスライドサイズを変更する**

このサンプルコードは、Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示しています。

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

一般的なスライドサイズ（4:3 と 16:9）が作業に適さない場合、特定または固有のスライドサイズを使用することを検討できます。たとえば、カスタムページレイアウトでプレゼンテーションのフルサイズスライドを印刷する予定がある場合や、特定の画面タイプでプレゼンテーションを表示する場合、カスタムサイズ設定を使用するとメリットがあります。

このサンプルコードは、Java を介して PHP 用 Aspose.Slides を使用し、プレゼンテーションのカスタムスライドサイズを指定する方法を示しています。

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

プレゼンテーションのスライドサイズを変更すると、スライドのコンテンツ（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは自動的に新しいスライドサイズに合わせてリサイズされます。ただし、プレゼンテーションのスライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように扱うかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`
  
  オブジェクトをリサイズしたくない場合は、この設定を使用します。

- `EnsureFit`
  
  小さいスライドサイズに縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides にダウンスケールさせたい場合（コンテンツの欠損を防ぐ）に使用します。 

- `Maximize`
  
  大きいスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合に使用します。 

このサンプルコードは、プレゼンテーションのスライドサイズ変更時に `Maximize` 設定を使用する方法を示しています。

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

## **FAQ**

**インチ以外の単位（たとえばポイントやミリメートル）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、変換した値をスライドの幅と高さの定義に使用できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位でサイズが大きくなるほど、描画スケールが高くなるとメモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じて描画スケールのみ調整して望ましい出力品質を得てください。

**標準外のスライドサイズを定義し、サイズが異なるプレゼンテーションからスライドを統合できますか？**

スライドサイズが異なる状態では[プレゼンテーションを統合](/slides/ja/php-java/merge-presentation/)できません — まず、どちらかのプレゼンテーションをもう一方に合わせてサイズ変更します。スライドサイズを変更する際、既存コンテンツの処理方法は[SlideSizeScaleType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesizescaletype/)オプションで選択できます。サイズを揃えた後、書式を保持したままスライドを統合できます。

**スライド内の個別の形状や特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は、[スライド全体](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage)だけでなく、[選択した形状](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getImage)のサムネイルも描画できます。生成される画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。