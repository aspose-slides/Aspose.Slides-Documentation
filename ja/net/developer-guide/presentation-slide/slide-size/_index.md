---
title: スライドサイズをカスタマイズ
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/net/slide-size/
keywords: "スライドサイズ設定, プレゼンテーション寸法のカスタマイズ, PowerPoint アスペクト比, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPointでC#または.NETを使用し、Aspose.Slidesでスライドサイズやアスペクト比をカスタマイズおよび調整する方法を学びます。"
---

## **PowerPoint のスライドサイズとアスペクト比のカスタマイズ**

Aspose.Slides for .NET は、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整する包括的なツールを提供し、印刷や画面表示の両方に重要です。

### **一般的なスライドサイズと比率**

- **Standard (4:3 アスペクト比)**: 旧式の画面やデバイスに最適です。
- **Widescreen (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

スライドサイズとアスペクト比はプレゼンテーション全体で一貫させる必要があります。最適な結果を得るために、プレゼンテーション作成プロセスの開始段階でスライドの寸法を設定し、後からのトラブルを防ぎましょう。

{{% alert color="primary" %}} 
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **PowerPoint でスライドサイズを変更する方法**

この例は、C# で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示しています:
```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```


## **カスタムスライドサイズの指定**

固有の用紙レイアウトや画面仕様に合わせてスライドサイズを調整することは有益です。以下は、Aspose.Slides for .NET でカスタムスライドサイズを設定する方法です:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 用紙サイズ
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```


## **サイズ変更後のスライド内容の扱い**

サイズ変更後、スライドの内容が歪むことがあります。Aspose.Slides がこのリサイズをどのように管理するかを制御できます:

- **`DoNotScale`**: オブジェクトを元のサイズのままに保ち、拡大縮小を防止します。
- **`EnsureFit`**: オブジェクトを小さなスライドに合わせて縮小し、コンテンツの欠落を防ぎます。
- **`Maximize`**: オブジェクトを大きなスライドに合わせて拡大し、見た目の一貫性を保ちます。

`Maximize` 設定を使用したスライドサイズ調整の例:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```


## **FAQ**

**カスタムスライドサイズをインチ以外の単位（例：ポイントやミリメートル）で設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに換算し、その値でスライドの幅と高さを指定できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位で大きなスライド寸法と高いレンダリングスケールを組み合わせると、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールを調整して望む出力品質を得るようにしてください。

**非標準のスライドサイズを1つ定義し、異なるサイズのプレゼンテーションからスライドをマージできますか？**

スライドサイズが異なる状態で[merge presentations](/slides/ja/net/merge-presentation/)はできません。まず、片方のプレゼンテーションをもう一方のサイズに合わせてリサイズしてください。スライドサイズを変更する際は、[SlideSizeScaleType]([https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/]) オプションで既存コンテンツの取り扱いを選択できます。サイズを揃えた後は、書式を保持したままスライドをマージできます。

**スライド内の個々のシェイプや特定の領域のサムネイルを生成できますか？ その際、新しいスライドサイズが反映されますか？**

はい。Aspose.Slides は[entire slides]([https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/])だけでなく、[selected shapes]([https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/])のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、フレーミングとジオメトリが一貫します。