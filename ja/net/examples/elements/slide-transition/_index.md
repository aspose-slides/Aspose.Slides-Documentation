---
title: スライド トランジション
type: docs
weight: 110
url: /ja/net/examples/elements/slide-transition/
keywords:
- スライド トランジション
- スライド トランジションの追加
- スライド トランジションへのアクセス
- スライド トランジションの削除
- トランジション期間
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のスライド トランジションをマスターし、PPT、PPTX、ODP プレゼンテーション向けに C# の例を使って効果や期間の追加、カスタマイズ、シーケンスを行います。"
---
この記事では、**Aspose.Slides for .NET** を使用したスライドのトランジション効果とタイミングの適用方法を示します。

## **スライド トランジションの追加**

最初のスライドにフェードトランジション効果を適用します。

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // フェード トランジションを適用します。
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **スライド トランジションへのアクセス**

スライドに現在割り当てられているトランジションのタイプを読み取ります。

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // トランジション タイプにアクセスします。
    var type = slide.SlideShowTransition.Type;
}
```

## **スライド トランジションの削除**

タイプを `None` に設定して、すべてのトランジション効果をクリアします。

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // トランジションを None に設定して削除します。
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **トランジション期間の設定**

自動的に次のスライドへ進むまで、スライドが表示される時間を指定します。

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // ミリ秒単位
}
```