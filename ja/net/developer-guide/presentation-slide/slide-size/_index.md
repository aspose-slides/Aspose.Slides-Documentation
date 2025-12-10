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
- フィットを確保
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
descriptions: ".NET と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドをすばやくリサイズする方法を学び、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---

## **プレゼンテーションのスライドサイズとアスペクト比のカスタマイズ**

Aspose.Slides for .NET は、印刷と画面表示の両方に重要な PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

### **一般的なスライドサイズと比率**

- **Standard (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、スライドサイズとアスペクト比はすべてのスライドに対して共通です。最適な結果を得るには、プレゼンテーション作成プロセスの初期段階でスライドの寸法を設定し、後からのトラブルを防ぎましょう。

{{% alert color="primary" %}} 
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションでスライドサイズを変更する方法**

この例では、C# で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示します:
```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```


## **カスタムスライドサイズの指定**

独自の紙のレイアウトや画面仕様に合わせてスライドサイズを調整すると便利です。以下は Aspose.Slides for .NET でカスタムスライドサイズを設定する方法です:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 用紙サイズ
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```


## **サイズ変更後のスライドコンテンツの扱い**

サイズ変更後、スライドのコンテンツが歪むことがあります。Aspose.Slides がこのリサイズをどのように処理するかを制御できます:

- **`DoNotScale`**: オブジェクトを元のサイズのまま保持し、拡大縮小を防止します。
- **`EnsureFit`**: 小さなスライドに収まるようオブジェクトを縮小し、コンテンツの欠落を防ぎます。
- **`Maximize`**: 大きなスライドに合わせてオブジェクトを拡大し、視覚的一貫性を保ちます。

`Maximize` 設定を使用したスライドサイズ調整の例:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```


## **FAQ**

**カスタムスライドサイズをインチ以外の単位（ポイントやミリメートルなど）で設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、その値でスライドの幅と高さを指定できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位のスライドサイズが大きくなるほど、レンダリングスケールが高くなるため、メモリ消費が増加し、処理時間も長くなります。実用的なスライドサイズを目指し、必要な出力品質を得るためにレンダリングスケールだけを調整してください。

**標準外のスライドサイズを1つ定義し、サイズが異なるプレゼンテーションからスライドをマージできますか？**

サイズが異なるプレゼンテーションは[プレゼンテーションの結合](/slides/ja/net/merge-presentation/)できません。まず、1つのプレゼンテーションをもう一方のサイズに合わせてリサイズする必要があります。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後は、書式を保持したままスライドをマージできます。

**個々のシェイプやスライドの特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は[スライド全体]https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/ のサムネイルだけでなく、[選択したシェイプ]https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/ のサムネイルも生成できます。生成された画像は現在のスライドサイズとアスペクト比を反映し、フレーミングとジオメトリの一貫性を保ちます。