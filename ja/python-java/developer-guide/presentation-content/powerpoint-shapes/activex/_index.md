---
title: Python を使用してプレゼンテーションの ActiveX コントロールを管理する
linktitle: ActiveX
type: docs
weight: 80
url: /ja/python-java/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディア プレーヤー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーション内の ActiveX テキスト ボックスとボタンを編集し、コントロールのプレビューを更新し、Windows Media Player コントロールを再利用します。"
---
## **導入**

ActiveX コントロールは、PowerPoint スライドにテキスト ボックス、コマンド ボタン、メディア プレーヤーなどのインタラクティブ要素を提供します。Aspose.Slides for Python via Java は、スライドのコントロールを[BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls) を通じて公開します。このコレクションを使用してコントロールを編集したり、スライド上で移動したり、削除したりできます。

## **ActiveX コントロールとその保存プロパティの一覧**

不慣れなテンプレートを調べるには、読み取りモードで開き、各スライドのコントロールを反復処理します。サンプルはスライド番号、コントロール名、[getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId)、そして [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) の各キーと値のペアを報告します。プレゼンテーションはコントロールをアクティブ化したり、イベントやマクロを呼び出したり、値を変更したり、ファイルを保存したりせずに読み取ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

`ActiveX.pptm` の選択された出力にはテキスト ボックスとコマンド ボタンが表示されます。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空のプロパティ コレクションは `[]` として表示されます。バイナリ ストレージを使用するコントロールでは、[getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) が `None` を返すことがあり、これは `Properties unavailable` と表示されます。名前だけが必要な場合は、コレクションが利用可能か確認した上で[getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) を使用してください。レポートはプレゼンテーションから取得できるプロパティを一覧表示します。コントロールは実行時に追加のプロパティをサポートする場合があります。

## **ActiveX コントロールの変更**

サンプルは、最初のスライドに `TextBox1` という名前のテキスト ボックスと `CommandButton1` という名前のコマンド ボタンがあるマクロ有効プレゼンテーションを想定しています。テキスト ボックスの値とボタンのキャプションを変更するために、[コントロール プロパティ コレクション](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) を使用します。各コントロールには、アクティベーション前に PowerPoint が表示できる静的プレビューもあります。更新されたテキストと外観を示す PNG を各コントロールに用意し、[Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat) を介してこれらの画像を割り当てます。

サンプルは、[Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame) でフレームを設定することにより、最初のスライド上のすべてのコントロールを 100 ポイント下に移動します。編集したプレゼンテーションを PPTM 形式で保存し、次に [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) を使用してそのスライドからすべての ActiveX コントロールを除去した 2 番目のコピーを保存します。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **ActiveX メディア プレーヤー コントロールの追加**

構成済みの Windows Media Player コントロールを再利用するには、最初のスライドに `WindowsMediaPlayer1` という名前のプレーヤーが含まれるテンプレートから開始します。[SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) はスライド全体を新しいプレゼンテーションにコピーします。サンプルはプレーヤーの `URL` をその[プロパティ コレクション](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/)に設定し、クローンされたスライドを出力の唯一のスライドとして保存します。ビデオは外部のままなので、再生中にプレーヤーがアクセスできるパスを選択してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **よくある質問**

**Aspose.Slides はコントロールを実行せずに保持できますか？**

はい。Aspose.Slides はコントロールをアクティブ化せずに読み取りおよび保存でき、プロパティや位置情報も保持します。

**ActiveX コントロールは OLE オブジェクトとどう違いますか？**

ActiveX コントロールはユーザーがテキストを入力したりボタンをクリックしたりしてスライドとやり取りできるようにします。[OLE オブジェクト](/slides/ja/python-java/manage-ole/) は、スライドが別のアプリケーションで管理されるコンテンツ（たとえば Excel ワークシート）を含んだりリンクしたりできるようにします。

**Aspose.Slides でプレゼンテーションを保存した後、ActiveX イベントは VBA マクロを引き続きトリガーしますか？**

プレゼンテーションを PPTM などのマクロ有効形式で保存すれば、VBA プロジェクトが保持されます。PowerPoint for Windows は、セキュリティ設定で ActiveX コントロールとマクロの両方が許可されている場合に、既存のイベント ハンドラを実行できます。