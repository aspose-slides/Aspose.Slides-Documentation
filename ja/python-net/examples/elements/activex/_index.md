---
title: ActiveX
type: docs
weight: 200
url: /ja/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の追加
- ActiveX へのアクセス
- ActiveX の削除
- ActiveX プロパティ
- コード例
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して PowerPoint プレゼンテーションのプロパティ更新を含む ActiveX コントロールの検索、編集、削除方法を学びます。"
---
プレゼンテーションで **Aspose.Slides for Python via .NET** を使用して ActiveX コントロールを追加、アクセス、削除、構成する方法を示します。

## **ActiveX コントロールの追加**

新しい ActiveX コントロールを挿入します。

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 新しい ActiveX コントロール (TextBox) を追加します。
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX コントロールへのアクセス**

スライド上の最初の ActiveX コントロールから情報を読み取ります。

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # 最初の ActiveX コントロールにアクセスします。
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # コントロール名を出力します。
            print(f"Control Name: {control.name}")
```

## **ActiveX コントロールの削除**

スライドから既存の ActiveX コントロールを削除します。

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # 最初の ActiveX コントロールを削除します。
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX プロパティの設定**

複数の ActiveX プロパティを構成します。

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # コレクションに少なくとも1つのコントロールが含まれていると仮定します。
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```