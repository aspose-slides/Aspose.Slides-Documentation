---
title: ActiveX
type: docs
weight: 200
url: /ja/cpp/examples/elements/activex/
keywords:
- コード例
- ActiveX
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ の ActiveX の例をご覧ください：PPT および PPTX プレゼンテーションで ActiveX オブジェクトを挿入、構成、制御する方法が、明確な C++ コードで示されています。"
---
この記事では、**Aspose.Slides for C++** を使用してプレゼンテーションに ActiveX コントロールを追加、アクセス、削除、構成する方法を示します。

## **ActiveX コントロールの追加**
新しい ActiveX コントロールを挿入し、必要に応じてプロパティを設定します。

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 新しい ActiveX コントロールを追加します。
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // 必要に応じていくつかのプロパティを設定します。
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX コントロールへのアクセス**
スライド上の最初の ActiveX コントロールから情報を読み取ります。

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // 最初の ActiveX コントロールにアクセスします。
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **ActiveX コントロールの削除**
スライドから既存の ActiveX コントロールを削除します。

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // 最初の ActiveX コントロールを削除します。
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX プロパティの設定**
コントロールを追加し、複数の ActiveX プロパティを構成します。

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Windows Media Player コントロールを追加し、プロパティを構成します。
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```