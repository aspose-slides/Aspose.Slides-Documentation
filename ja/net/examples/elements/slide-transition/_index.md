---
title: スライドトランジション
type: docs
weight: 110
url: /ja/net/examples/elements/slide-transition/
keywords:
- スライドトランジションの例
- スライドトランジションの追加
- スライドトランジションへのアクセス
- スライドトランジションの削除
- トランジション期間
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用した C# でスライド トランジションを制御します：種類、速度、サウンド、タイミングを選択して、PPT、PPTX、ODP のプレゼンテーションを洗練させます。"
---

**Aspose.Slides for .NET** を使用してスライドのトランジション効果とタイミングを適用する方法を示します。

## **スライドトランジションの追加**

最初のスライドにフェード トランジション効果を適用します。
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // フェード トランジションを適用する
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## **スライドトランジションへのアクセス**

スライドに現在割り当てられているトランジションの種類を取得します。
```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // トランジションの種類にアクセス
    var type = slide.SlideShowTransition.Type;
}
```


## **スライドトランジションの削除**

`None` に設定して、すべてのトランジション効果をクリアします。
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // none に設定してトランジションを削除
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## **トランジション期間の設定**

自動的に次へ進む前に、スライドが表示される時間を指定します。
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // ミリ秒単位
}
```
