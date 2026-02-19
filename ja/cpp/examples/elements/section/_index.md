---
title: セクション
type: docs
weight: 90
url: /ja/cpp/examples/elements/section/
keywords:
- コード例
- セクション
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライド セクションを管理します。C++ のサンプルを使用して、PPT、PPTX、ODP のスライドを作成、名前変更、並び替え、グループ化できます。"
---
プログラムで **Aspose.Slides for C++** を使用してプレゼンテーション セクションを管理する例（追加、アクセス、削除、名前の変更）。

## **セクションの追加**

特定のスライドから開始するセクションを作成します。

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // セクションの開始を示すスライドを指定します。
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **セクションへのアクセス**

プレゼンテーションからセクション情報を読み取ります。

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // インデックスでセクションにアクセスします。
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **セクションの削除**

以前に追加したセクションを削除します。

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // 最初のセクションを削除します。
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **セクションの名前変更**

既存のセクションの名前を変更します。

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```