---
title: SmartArt
type: docs
weight: 140
url: /ja/cpp/examples/elements/smart-art/
keywords:
- コード例
- SmartArt
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で SmartArt を操作: PowerPoint および OpenDocument プレゼンテーション用に C++ で図表の作成、編集、変換、スタイル設定を行います。"
---
この記事では、**Aspose.Slides for C++** を使用して SmartArt グラフィックを追加し、アクセスし、削除し、レイアウトを変更する方法を示します。

## **SmartArt の追加**

組み込みのレイアウトのいずれかを使用して SmartArt グラフィックを挿入します。

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **SmartArt へのアクセス**

スライド上の最初の SmartArt オブジェクトを取得します。

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **SmartArt の削除**

スライドから SmartArt シェイプを削除します。

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **SmartArt レイアウトの変更**

既存の SmartArt グラフィックのレイアウト タイプを更新します。

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```