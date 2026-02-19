---
title: スライド トランジション
type: docs
weight: 110
url: /ja/cpp/examples/elements/slide-transition/
keywords:
- コード例
- スライド トランジション
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライド トランジションをマスターする: C++ の例を使用して PPT、PPTX、ODP プレゼンテーションの効果と期間を追加、カスタマイズ、シーケンス化します。"
---
この記事では、**Aspose.Slides for C++** を使用したスライドのトランジション効果とタイミングの適用方法を示します。

## **スライド トランジションの追加**
最初のスライドにフェード トランジション効果を適用します。

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // フェード トランジションを適用します。
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **スライド トランジションへのアクセス**
スライドに現在割り当てられているトランジションの種類を読み取ります。

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // トランジション タイプにアクセスします。
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **スライド トランジションの削除**
タイプを `None` に設定して、すべてのトランジション効果をクリアします。

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // トランジションを none に設定して削除します。
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **トランジション期間の設定**
自動的に次へ進む前に、スライドが表示される時間を指定します。

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // ミリ秒単位です。

    presentation->Dispose();
}
```