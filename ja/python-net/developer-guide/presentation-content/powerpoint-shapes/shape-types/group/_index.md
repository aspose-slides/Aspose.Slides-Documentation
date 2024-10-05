---
title: グループ
type: docs
weight: 40
url: /python-net/group/
keywords: "グループ形状, PowerPoint形状, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションにグループ形状を追加する"
---

## **グループ形状の追加**
Aspose.Slidesはスライド上のグループ形状の操作をサポートしています。この機能は、開発者がよりリッチなプレゼンテーションをサポートするのに役立ちます。Aspose.Slides for Python via .NETは、グループ形状の追加またはアクセスをサポートしています。追加されたグループ形状に形状を追加して内容を充実させたり、グループ形状の任意のプロパティにアクセスすることが可能です。Aspose.Slides for Python via .NETを使用してスライドにグループ形状を追加するには：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループ形状を追加します。
1. 追加されたグループ形状に形状を追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、スライドにグループ形状を追加します。

```py
import aspose.slides as slides

# Presentationクラスのインスタンスを生成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # スライドの形状コレクションにアクセス
    slideShapes = sld.shapes

    # スライドにグループ形状を追加
    groupShape = slideShapes.add_group_shape()

    # 追加されたグループ形状内に形状を追加
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # グループ形状のフレームを追加
    groupShape.frame = slides.ShapeFrame(100, 300, 500, 40, -1, -1, 0)

    # PPTXファイルをディスクに書き込む
    pres.save("GroupShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **AltTextプロパティへのアクセス**
このトピックでは、グループ形状を追加し、スライド上のグループ形状のAltTextプロパティにアクセスするための簡単なステップをコード例と共に示します。Aspose.Slides for Python via .NETを使用してスライドのグループ形状のAltTextにアクセスするには：

1. PPTXファイルを表す`Presentation`クラスをインスタンス化します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドの形状コレクションにアクセスします。
1. グループ形状にアクセスします。
1. AltTextプロパティにアクセスします。

以下の例では、グループ形状の代替テキストにアクセスします。

```py
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスのインスタンスを生成
with slides.Presentation(path + "AltText.pptx") as pres:

    # 最初のスライドを取得
    sld = pres.slides[0]

    for i in range(len(sld.shapes)):
        # スライドの形状コレクションにアクセス
        shape = sld.shapes[i]

        if type(shape) is slides.GroupShape:
            # グループ形状にアクセス
            for j in range(len(shape.shapes)):
                # AltTextプロパティにアクセス
                print(shape.shapes[j].alternative_text)
```