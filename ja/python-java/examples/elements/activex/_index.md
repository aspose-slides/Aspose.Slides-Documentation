---
title: ActiveX
type: docs
weight: 200
url: /ja/python-java/examples/elements/activex/
keywords:
- コード例
- ActiveX
- ActiveX コントロール
- ActiveX プロパティ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "実用的なコード例を用いて、Python via Java 用 Aspose.Slides を使用し、PowerPoint プレゼンテーション内の ActiveX コントロールを追加、アクセス、削除、設定します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用してプレゼンテーションに ActiveX コントロールを追加、アクセス、削除、設定する方法を示します。

パッケージは [Installation](/slides/ja/python-java/installation/) に記載された手順でインストールします。各サンプルは JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。アクセスと削除のサンプルでは、最初のサンプルで作成された `add_activex.pptm` を使用します。

## **ActiveX コントロールの追加**

最初のスライドに Windows Media Player コントロールを挿入し、プレゼンテーションを PPTM ファイルとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player コントロールを追加します。
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX コントロールへのアクセス**

スライド上の最初の ActiveX コントロールの名前と自動再生設定を読み取ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # 最初の ActiveX コントロールにアクセスします。
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **ActiveX コントロールの削除**

スライドから最初の ActiveX コントロールを削除し、変更されたプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # 最初の ActiveX コントロールを削除します。
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX プロパティの設定**

Windows Media Player コントロールを追加し、自動再生を無効にし、再生コントロールを非表示にします。プロパティ値を文字列として設定するには、[ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/ja/python-java/aspose.slides/controlpropertiescollection/#set_Item) を使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player コントロールを追加し、そのプロパティを構成します。
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```