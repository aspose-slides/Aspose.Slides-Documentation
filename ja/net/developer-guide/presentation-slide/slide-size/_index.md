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
- .NET
- C#
- Aspose.Slides
description: ".NET と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを素早くリサイズする方法を学び、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **はじめに**

Aspose.Slides for .NET は、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供し、印刷と画面表示の両方において重要です。

一般的なスライドサイズと比率:

- **Standard (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 アスペクト比)**: 最新のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドは単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーションの作成プロセスの最初にスライドの寸法を設定し、問題を防ぎましょう。

{{% alert color="info" %}} 
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションでのスライドサイズの変更方法**

この例では、C# で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示します。

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

固有の紙のレイアウトや画面仕様など、特定のニーズに合わせてスライドサイズを調整すると便利です。以下は、Aspose.Slides for .NET でカスタムスライドサイズを設定する方法です。

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

リサイズ後、スライドのコンテンツが歪むことがあります。Aspose.Slides がこのリサイズをどのように処理するかを制御できます。

- **`DoNotScale`**: オブジェクトを元のサイズのままにし、拡大縮小を回避します。
- **`EnsureFit`**: オブジェクトを小さいスライドに合わせてスケーリングし、コンテンツの欠落を防ぎます。
- **`Maximize`**: 大きいスライドに合わせてオブジェクトを拡大し、見た目の一貫性を保ちます。

`Maximize` 設定を使用したスライドサイズ調整の例:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **よくある質問**

### インインチ以外の単位（例えばポイントやミリメートル）でカスタムスライドサイズを設定できますか？

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インインチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、その変換値でスライドの幅と高さを指定できます。

### 非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？

はい。スライドの寸法が大きく（ポイント単位）なると、レンダリングスケールが高くなることでメモリ使用量が増加し、処理時間も長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールだけを調整して目的の出力品質を得てください。

### 標準外のスライドサイズを定義し、異なるサイズのプレゼンテーションからスライドをマージできますか？

異なるスライドサイズのままでは [merge presentations](/slides/ja/net/merge-presentation/) はできません。まず、片方のプレゼンテーションのサイズを他方に合わせてリサイズします。スライドサイズを変更する際、既存のコンテンツの処理方法は [SlideSizeScaleType](https://reference.aspose.com/slides/ja/net/aspose.slides/slidesizescaletype/) オプションで選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

### スライドの個々のシェイプや特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを考慮しますか？

はい。Aspose.Slides は [entire slides](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/getimage/) と [selected shapes](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/getimage/) のサムネイルをレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫した構図とジオメトリを保ちます。