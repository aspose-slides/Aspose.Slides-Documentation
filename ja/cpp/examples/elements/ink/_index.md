---
title: インク
type: docs
weight: 180
url: /ja/cpp/examples/elements/ink/
keywords:
- コード例
- インク
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のインクを操作します: ストロークの描画、インポート、編集、色と幅の調整、C++ のサンプルを使用して PPT、PPTX、ODP にエクスポートします。"
---
この記事では、既存のインク シェイプにアクセスし、**Aspose.Slides for C++** を使用してそれらを削除する例を示します。

> ❗ **注意:** インク シェイプは、特殊デバイスからのユーザー入力を表します。Aspose.Slides はプログラムで新しいインク ストロークを作成できませんが、既存のインクを読み取り、変更することはできます。

## **インクへのアクセス**

スライド上の最初のインク シェイプからタグを読み取ります。

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // tagName を必要に応じて使用します。
        }
    }

    presentation->Dispose();
}
```

## **インクの削除**

インク シェイプが存在する場合、スライドから削除します。

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```