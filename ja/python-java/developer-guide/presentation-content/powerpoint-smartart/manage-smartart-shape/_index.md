---
title: Python を使用したプレゼンテーションにおける SmartArt グラフィックの管理
linktitle: SmartArt グラフィック
type: docs
weight: 20
url: /ja/python-java/manage-smartart-shape/
keywords:
- SmartArt オブジェクト
- SmartArt グラフィック
- SmartArt スタイル
- SmartArt カラー
- SmartArt の作成
- SmartArt の追加
- SmartArt の編集
- SmartArt の変更
- SmartArt へのアクセス
- SmartArt レイアウトタイプ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint の SmartArt の作成、編集、スタイリングを自動化し、簡潔なコード例とパフォーマンス重視のガイダンスを提供します。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーションで SmartArt グラフィックをプログラムで作成および管理できます。この記事では、スライドに SmartArt シェイプを追加し、既存の SmartArt シェイプにアクセスし、特定のレイアウトタイプで SmartArt を検索し、SmartArt スタイルまたは配色スタイルを変更して外観を更新する方法を説明します。

例では、プレゼンテーション スライドのシェイプ コレクションを介して SmartArt シェイプを操作し、シェイプが SmartArt かどうかを確認してからプロパティを変更または検査する方法を示します。

## **SmartArt シェイプの作成**
Aspose.Slides for Python via Java は SmartArt シェイプを作成する API を提供します。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドを取得します。
1. [SmartArtLayoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartlayouttype/) を指定して [Add a SmartArt shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addSmartArt) を呼び出します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # SmartArt シェイプを追加します。
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # プレゼンテーションを保存します。
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**図: スライドに追加された SmartArt シェイプ**|

## **スライド上の SmartArt シェイプへのアクセス**
以下の例は、プレゼンテーション スライド上の SmartArt シェイプにアクセスします。スライド上のすべてのシェイプを反復処理し、シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうかをチェックします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # 最初のスライド上のすべてのシェイプを反復処理します。
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **特定のレイアウトタイプを持つ SmartArt シェイプへのアクセス**
以下の例は、[SmartArt.getLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/#getLayout) が返す特定のレイアウトタイプを持つ [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) シェイプにアクセスします。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) のインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスで最初のスライドを取得します。
1. 最初のスライド上のすべてのシェイプを反復処理します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうかを確認します。
1. SmartArt シェイプが指定されたレイアウトタイプを持つかどうかをチェックし、必要な操作を実行します。

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # 最初のスライド上のすべてのシェイプを反復処理します。
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt のレイアウトを確認します。
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **SmartArt シェイプのスタイル変更**
この例は、SmartArt シェイプのクイック スタイルを変更する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) のインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスで最初のスライドを取得します。
1. 最初のスライド上のすべてのシェイプを反復処理します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうかを確認します。
1. 指定されたスタイルを持つ SmartArt シェイプを検索します。
1. SmartArt シェイプに新しいスタイルを設定します。
1. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 最初のスライド上のすべてのシェイプを反復処理します。
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt のスタイルを確認し、変更します。
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**図: スタイルが変更された SmartArt シェイプ**|

## **SmartArt シェイプの配色スタイル変更**
この例は、特定の配色スタイルを持つ SmartArt シェイプにアクセスし、そのスタイルを変更します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) のインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスで最初のスライドを取得します。
1. 最初のスライド上のすべてのシェイプを反復処理します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうかを確認します。
1. 指定された配色スタイルを持つ SmartArt シェイプを検索します。
1. SmartArt シェイプに新しい配色スタイルを設定します。
1. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 最初のスライド上のすべてのシェイプを反復処理します。
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # SmartArt のスタイルを確認し、変更します。
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**図: 配色スタイルが変更された SmartArt シェイプ**|

## **よくある質問**

**SmartArt を単一オブジェクトとしてアニメーション化できますか？**

はい。SmartArt はシェイプなので、他のシェイプと同様にアニメーション API（開始、終了、強調、動きのパス）を使用して [標準アニメーション](/slides/ja/python-java/powerpoint-animation/) を適用できます。

**内部 ID が分からない場合、スライド上の特定の SmartArt をどうやって見つけますか？**

[代替テキスト](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#setAlternativeText) を設定してその値でシェイプを検索します。これが推奨される方法です。

**SmartArt を他のシェイプとグループ化できますか？**

はい。SmartArt を画像やテーブルなどの他のシェイプとグループ化でき、その後 [グループを操作](/slides/ja/python-java/group/) できます。

**特定の SmartArt の画像（プレビューやレポート用）を取得するには？**

シェイプのサムネイル/画像をエクスポートします。ライブラリは個々のシェイプを [Raster ファイル (PNG/JPG/TIFF) にレンダリング](/slides/ja/python-java/create-shape-thumbnails/) できます。

**プレゼンテーション全体を PDF に変換したときに SmartArt の外観は保持されますか？**

はい。レンダリング エンジンは [PDF エクスポート](/slides/ja/python-java/convert-powerpoint-to-pdf/) において高忠実度を目指しており、品質と互換性のオプションが多数用意されています。