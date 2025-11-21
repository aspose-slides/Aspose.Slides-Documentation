---
title: スライドトランジション
type: docs
weight: 110
url: /ja/net/examples/elements/slide-transition/
keywords:
- スライドトランジションの例
- スライドトランジションを追加
- スライドトランジションにアクセス
- スライドトランジションを削除
- トランジション期間
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用した C# でスライドトランジションを制御します。種類、速度、サウンド、タイミングを選択して、PPT、PPTX、ODP のプレゼンテーションを磨きます。"
---

**Aspose.Slides for .NET** を使用したスライドのトランジション効果とタイミングの適用を示します。

## スライドトランジションを追加する

最初のスライドにフェードトランジション効果を適用します。
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // フェード遷移を適用
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## スライドトランジションにアクセスする

スライドに現在割り当てられているトランジションの種類を取得します。
```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // トランジションタイプにアクセス
    var type = slide.SlideShowTransition.Type;
}
```


## スライドトランジションを削除する

`None` に設定して、すべてのトランジション効果をクリアします。
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // none を設定してトランジションを削除
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## トランジションの期間を設定する

スライドが自動的に進むまでの表示時間を指定します。
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // ミリ秒で
}
```
