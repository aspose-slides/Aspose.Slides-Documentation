---
title: 章节
type: docs
weight: 90
url: /zh/cpp/examples/elements/section/
keywords:
- 代码示例
- 章节
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中管理幻灯片章节：创建、重命名、重新排序，并使用 C++ 示例对 PPT、PPTX 和 ODP 进行幻灯片分组。"
---
使用 **Aspose.Slides for C++** 以编程方式管理演示文稿章节的示例——添加、访问、删除和重命名。

## **添加章节**

在指定幻灯片处创建一个章节。

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 指定标记章节开始的幻灯片。
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **访问章节**

读取演示文稿中的章节信息。

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // 通过索引访问章节。
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **删除章节**

删除之前添加的章节。

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // 删除第一个章节。
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **重命名章节**

更改现有章节的名称。

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