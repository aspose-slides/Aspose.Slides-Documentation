---
title: マスタースライド
type: docs
weight: 30
url: /ja/python-java/examples/elements/master-slide/
keywords:
- コード例
- マスタースライド
- マスタースライドの追加
- マスタースライドへのアクセス
- マスタースライドの削除
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してマスタースライドを管理します。PowerPoint および OpenDocument プレゼンテーションで、マスターの作成、アクセス、削除、クリーンアップが可能です。"
---
マスター スライドは PowerPoint のスライド継承階層の最上位レベルを構成します。**マスター スライド**は背景、ロゴ、テキスト書式設定などの共通デザイン要素を定義します。**レイアウト スライド**はマスター スライドから継承し、**標準スライド**はレイアウト スライドから継承します。

この記事では、**Aspose.Slides for Python via Java** を使用してマスター スライドを作成、変更、管理する方法を示します。

[Installation](/slides/ja/python-java/installation/) に記載された手順でパッケージをインストールします。各例では JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になった後に API をインポートします。

## **マスター スライドの追加**

この例はデフォルトのマスター スライドをクローンして新しいマスター スライドを作成する方法を示します。その後、レイアウト 継承を通じてすべてのスライドに会社名バナーを追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # デフォルトのマスター スライドをクローンします。
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # マスター スライドの上部に会社名バナーを追加します。
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # 新しいマスター スライドをレイアウト スライドに割り当てます。
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # レイアウト スライドをプレゼンテーションの最初のスライドに割り当てます。
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
マスター スライドは、すべてのスライドに一貫したブランディングや共有デザイン要素を適用する方法を提供します。マスターに対する変更は、依存するレイアウト スライドおよび標準スライドに自動的に反映されます。
{{% /alert %}}

{{% alert color="info" title="Note" %}}
マスター スライドに追加された図形や書式設定はレイアウト スライドに継承され、さらにそれらのレイアウトを使用するすべての標準スライドにも継承されます。下の画像は、マスター スライドに追加されたテキスト ボックスが最終スライドに自動的にレンダリングされる様子を示しています。
{{% /alert %}}

![マスター継承例](master-slide-banner.png)

## **マスター スライドへのアクセス**

プレゼンテーションのマスター コレクションを介してマスター スライドにアクセスできます。この例は最初のマスター スライドを取得し、その背景タイプを変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **マスター スライドの削除**

マスター スライドは、使用されなくなった後にインデックスまたは参照で削除できます。この例はクローンしたマスター スライドをプレゼンテーションに割り当て、元のマスターをインデックスで削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # インデックスで未使用の元マスター スライドを削除します。
    presentation.getMasters().removeAt(0)

    # あるいは、参照で未使用のマスター スライドを削除します：
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **未使用のマスター スライドの削除**

一部のプレゼンテーションには使用されていないマスター スライドが含まれています。これらのスライドを削除するとファイル サイズの削減に役立ちます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # すべての未使用マスター スライドを削除します（Preserve とマークされたものも含む）。
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```