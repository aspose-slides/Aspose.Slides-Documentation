---
title: .NET でプレゼンテーションのスライドサイズを変更する
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
- スライドサイズの設定
- スライドサイズの変更
- カスタムスライドサイズ
- 特別なスライドサイズ
- ユニークなスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケールしない
- フィットを確保
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを迅速にリサイズする方法を学び、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **はじめに**

Aspose.Slides for .NET は、印刷や画面表示の両方に重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。  

一般的なスライドサイズと比率:

- **標準 (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **ワイドスクリーン (16:9 アスペクト比)**: 最新のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに同一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、作成プロセスの最初にスライドの寸法を設定し、問題を防ぎましょう。

{{% alert color="primary" %}} 
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションのスライドサイズを変更する方法**

この例は、C# で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示しています。

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **カスタムスライドサイズの指定**

独自の用紙レイアウトや画面仕様など、特定のニーズに合わせてスライドサイズを調整すると便利です。以下は、Aspose.Slides for .NET でカスタムスライドサイズを設定する方法です。

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 用紙サイズ
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **リサイズ後のスライドコンテンツの処理**

リサイズ後、スライドのコンテンツが歪むことがあります。Aspose.Slides がこのリサイズをどのように管理するかを制御できます。

- **`DoNotScale`**: オブジェクトを元のサイズのままに保ち、拡大縮小を防ぎます。
- **`EnsureFit`**: オブジェクトを縮小して小さいスライドに合わせ、コンテンツの欠損を防ぎます。
- **`Maximize`**: オブジェクトを拡大して大きいスライドに合わせ、美的な一貫性を保ちます。

スライドサイズ調整に `Maximize` 設定を使用する例:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **よくある質問**

**インチ以外の単位（たとえばポイントやミリメートル）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部でポイント単位を使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、その変換値をスライドの幅と高さの指定に使用できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。スライドの寸法が大きく（ポイント単位）なると、レンダリングスケールが高くなることでメモリ消費が増加し、処理時間も長くなります。実用的なスライドサイズを目指し、必要な出力品質を得るためにレンダリングスケールを必要に応じて調整してください。

**非標準のスライドサイズを定義し、サイズが異なるプレゼンテーションからスライドをマージできますか？**

スライドサイズが異なる状態で[merge presentations](/slides/ja/net/merge-presentation/) を行うことはできません—まず、一方のプレゼンテーションのサイズをもう一方に合わせてリサイズします。スライドサイズを変更する際、既存コンテンツの処理方法は[SlideSizeScaleType](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesizescaletype/) オプションで選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**スライドの個々の形状や特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを尊重しますか？**

はい。Aspose.Slides は、[全スライド](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage/) のサムネイルだけでなく、[選択した形状](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/getimage/) のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。