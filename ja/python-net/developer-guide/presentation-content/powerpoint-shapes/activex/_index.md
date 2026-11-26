---
title: Python でプレゼンテーションの ActiveX コントロールを管理する
linktitle: ActiveX
type: docs
weight: 80
url: /ja/python-net/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX を管理
- ActiveX を追加
- ActiveX を変更
- メディアプレーヤー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションの ActiveX テキストボックスとボタンを編集し、コントロールのプレビューを更新し、Windows Media Player コントロールを再利用します。"
---
## **導入**

ActiveX コントロールは、テキスト ボックス、コマンド ボタン、メディア プレーヤーなどのインタラクティブな要素を PowerPoint スライドに提供します。Aspose.Slides for Python via .NET は、スライドのコントロールを [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/) で公開します。このコレクションを使用してコントロールを編集したり、スライド上で移動したり、削除したりできます。

## **ActiveX コントロールとその保存されたプロパティの一覧**

未知のテンプレートを調査するには、テンプレートを読み取りモードで開き、各スライドのコントロールを反復処理します。このサンプルは、スライド番号、コントロール名、[class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/)、および [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties) の各キー‑バリュー ペアを報告します。プレゼンテーションは、コントロールをアクティブ化したり、イベントやマクロを呼び出したり、値を変更したり、ファイルを保存したりせずに読み取ります。

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

`ActiveX.pptm` の選択された出力は、テキスト ボックスとコマンド ボタンを示します。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空のプロパティ コレクションは `[]` として表示されます。バイナリ ストレージを使用するコントロールの場合、`properties` は `None` を返すことがあり、その場合は `Properties unavailable` と表示されます。名前だけが必要な場合は、`None` であるか確認した上で [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) を使用してください。レポートはプレゼンテーションから取得できるプロパティを一覧表示します。実行時に追加のプロパティをサポートするコントロールもあります。

## **ActiveX コントロールの変更**

このサンプルは、最初のスライドに `TextBox1` という名前のテキスト ボックスと `CommandButton1` という名前のコマンド ボタンがあるマクロ対応プレゼンテーションを前提としています。[control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) を使用してテキスト ボックスの値とボタンのキャプションを変更します。各コントロールには、アクティブ化前に PowerPoint が表示できる静的プレビューがあり、更新されたテキストと外観を示す PNG を各コントロールに提供します。この画像は [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/) を介して割り当てられます。

サンプルは、最初のスライド上のすべてのコントロールを、[frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/) を変更して下方向に 100 ポイント移動させます。編集後のプレゼンテーションを PPTM 形式で保存し、次に [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) を使用して同じスライドからすべての ActiveX コントロールを除去した第 2 のコピーを保存します。

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX メディア プレーヤー コントロールの追加**

構成済みの Windows Media Player コントロールを再利用するには、最初のスライドに `WindowsMediaPlayer1` という名前のプレーヤーが含まれるテンプレートから開始します。[SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) は、スライド全体を新しいプレゼンテーションにコピーします。サンプルは、プレーヤーの `URL` をその [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) に設定し、クローンされたスライドを出力の唯一のスライドとして保存します。ビデオは外部に保持されるため、再生中にプレーヤーがアクセスできるパスを選択してください。

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides は、ActiveX コントロールを実行せずに保持できますか？**

はい。Aspose.Slides は、コントロールとそのプロパティ、位置情報をアクティブ化せずに読み取りおよび保存できます。

**ActiveX コントロールは OLE オブジェクトとどう違いますか？**

ActiveX コントロールは、テキスト入力やボタンのクリックなど、スライド上でユーザーが直接操作できるようにします。[OLE オブジェクト](/slides/ja/python-net/manage-ole/) は、スライドが別のアプリケーションで管理されているコンテンツ（例: Excel のワークシート）を含むかリンクすることを可能にします。

**Aspose.Slides でプレゼンテーションを保存した後、ActiveX イベントは VBA マクロを引き続きトリガーしますか？**

プレゼンテーションを PPTM などのマクロ対応形式で保存すれば、VBA プロジェクトが保持されます。Windows 用 PowerPoint のセキュリティ設定で ActiveX コントロールとマクロの両方が許可されている場合、既存のイベント ハンドラが実行されます。