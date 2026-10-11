---
title: .NET でプレゼンテーションのスライドサイズを変更
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/net/slide-size/
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
- フィットさせる
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを素早くリサイズする方法を学び、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **イントロダクション**

Aspose.Slides for .NET は、印刷や画面表示の両方で重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズと比率:

- **Standard (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 アスペクト比)**: 最新のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに同一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成の初期段階でスライドの寸法を設定し、問題を防ぎましょう。

{{% alert color="info" %}} 
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

ノートページや配布資料は通常のスライドとは別のサイズを持ちます。サイズと向きを変更するには、[ノートページサイズ](/slides/ja/net/notes-size/) を参照してください。

## **プレゼンテーションのスライドサイズを変更する方法**

この例は、C# で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **カスタムスライドサイズの指定**

特定の紙のレイアウトや画面仕様など、個別のニーズに合わせてスライドサイズを調整すると便利です。以下は、Aspose.Slides for .NET でカスタムスライドサイズを設定する方法です。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 用紙サイズ
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **リサイズ後のスライドコンテンツの取り扱い**

リサイズ後、スライドの内容が歪むことがあります。Aspose.Slides がこのリサイズをどのように管理するかを制御できます。

- **`DoNotScale`**: オブジェクトを元のサイズのまま保ち、スケーリングを防ぎます。
- **`EnsureFit`**: 小さいスライドに合わせてオブジェクトを拡大縮小し、コンテンツの欠損を防ぎます。
- **`Maximize`**: 大きいスライドに合わせてオブジェクトを拡大し、見た目の一貫性を保ちます。

`Maximize` 設定を使用したスライドサイズ調整の例:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### カスタムスライドサイズをインチ以外の単位（例: ポイントやミリメートル）で設定できますか？

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、変換した値でスライドの幅と高さを指定できます。

### 非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？

はい。スライド寸法が大きく（ポイント単位）なり、さらに高いレンダリングスケールを使用すると、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールだけを調整して目的の出力品質を得てください。

### 標準外のスライドサイズを定義した後、異なるサイズのプレゼンテーションからスライドをマージできますか？

スライドサイズが異なる場合、[プレゼンテーションのマージ](/slides/ja/net/merge-presentation/) はできません — まず、片方のプレゼンテーションをもう一方に合わせてサイズ変更します。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesizescaletype/) オプションを使用して既存コンテンツの処理方法を選択できます。サイズを揃えた後、フォーマットを保持したままスライドをマージできます。

### 個々のシェイプやスライドの特定領域のサムネイルを生成できますか？また、新しいスライドサイズを考慮しますか？

はい。Aspose.Slides は、[スライド全体](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage/) および [選択されたシェイプ](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/getimage/) のサムネイルを描画できます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを確保します。