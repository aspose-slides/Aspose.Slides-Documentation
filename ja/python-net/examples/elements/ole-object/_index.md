---
title: OLE オブジェクト
type: docs
weight: 210
url: /ja/python-net/examples/elements/ole-object/
keywords:
- OLE オブジェクト
- OLE オブジェクトの追加
- OLE オブジェクトへのアクセス
- OLE オブジェクトの削除
- OLE オブジェクトの更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で Aspose.Slides を使用して OLE オブジェクトを操作します。埋め込みファイルの挿入や更新、アイコンやリンクの設定、コンテンツの抽出、PPT、PPTX、ODP の動作制御が可能です。"
---
OLE オブジェクトとしてファイルを埋め込み、データを更新する方法を **Aspose.Slides for Python via .NET** を使用して示します。

## **OLE オブジェクトの追加**

PDF ファイルをプレゼンテーションに埋め込みます。

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 埋め込む PDF データを読み込む。
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # スライドに OLE オブジェクト フレームを追加する。
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE オブジェクトへのアクセス**

スライド上の最初の OLE オブジェクト フレームを取得します。

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # スライド上の最初の OLE オブジェクト フレームを取得する。
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **OLE オブジェクトの削除**

スライドから埋め込まれた OLE オブジェクトを削除します。

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプが OleObjectFrame オブジェクトであると仮定する。
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE オブジェクト データの更新**

既存の OLE オブジェクトに埋め込まれたデータを置き換えます。

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプが OleObjectFrame オブジェクトであると仮定する。
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # 新しい埋め込みデータで OLE オブジェクトを更新する。
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```