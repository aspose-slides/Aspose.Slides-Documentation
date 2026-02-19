---
title: ヘッダー フッター
type: docs
weight: 220
url: /ja/cpp/examples/elements/header-footer/
keywords:
- コード例
- ヘッダー
- フッター
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してスライドのヘッダーとフッターを制御します。C++ の例で、PPT、PPTX、ODP に日付、スライド番号、カスタムテキストを追加できます。"
---
この記事では、**Aspose.Slides for C++** を使用してフッターの追加と日付と時刻のプレースホルダーの更新方法を示します。

## **フッターの追加**
スライドのフッター領域にテキストを追加し、表示させます。

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **日付と時刻の更新**
スライド上の日付と時刻のプレースホルダーを変更します。

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```