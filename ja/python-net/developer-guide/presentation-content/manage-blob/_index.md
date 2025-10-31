---
title: プレゼンテーションでのPythonによるBLOB管理と効率的なメモリ使用
linktitle: BLOB管理
type: docs
weight: 10
url: /ja/python-net/manage-blob/
keywords:
- 大きなオブジェクト
- 大容量アイテム
- 大きなファイル
- BLOBの追加
- BLOBのエクスポート
- 画像をBLOBとして追加
- メモリ削減
- メモリ消費
- 大規模プレゼンテーション
- 一時ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET で BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化してプレゼンテーション処理のメモリ使用を最適化します。"
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存される大きな項目（写真、プレゼンテーション、文書、メディアなど）です。

Aspose.Slides for Python via .NET を使用すると、BLOB をオブジェクトに利用でき、サイズの大きいファイルを扱う際のメモリ消費を削減できます。

## **BLOB を使用してメモリ消費を削減する**

### **BLOB を介して大型ファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/python-net/) for .NET は、メモリ消費を抑えるために BLOB を介して大型ファイル（この例では大型ビデオファイル）を追加する機能を提供します。

以下の Python コードは、BLOB プロセスを介して大型ビデオファイルをプレゼンテーションに追加する方法を示しています。

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# ビデオを追加する新しいプレゼンテーションを作成します
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # ビデオをプレゼンテーションに追加します。KeepLocked 動作を選択したのは
        # 「veryLargeVideo.avi」ファイルにアクセスする予定がないためです。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # プレゼンテーションを保存します。大型プレゼンテーションが出力されても、
        # pres オブジェクトのライフサイクル全体でメモリ消費は低く抑えられます
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **BLOB を介して大型ファイルをプレゼンテーションからエクスポートする**

Aspose.Slides for Python via .NET は、BLOB を介して大型ファイル（この例では音声またはビデオ）をプレゼンテーションからエクスポートする機能を提供します。たとえば、プレゼンテーションから大型メディアファイルを抽出したいが、メモリに読み込むのは避けたい場合、BLOB プロセスを使用するとメモリ消費を低く保てます。

以下の Python コードは、上記操作を示しています。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
    # 各ビデオをファイルに保存します。高いメモリ使用を防ぐために、プレゼンテーションのビデオストリームから
    # 新しく作成したビデオファイル用ストリームへデータを転送するバッファが必要です。
    # byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

    # ビデオを列挙します
    index = 0
    # 必要に応じて、オーディオファイルにも同じ手順を適用できます。
    for video in pres.videos:
        # プレゼンテーションのビデオストリームを開きます。意図的に video.BinaryData のようなプロパティへのアクセスは回避しています。
        # これはプロパティがビデオ全体を含むバイト配列を返し、メモリにロードされてしまうためです。代わりに video.GetStream を使用し、Stream を取得します。
        # これによりビデオ全体をメモリにロードする必要がありません。
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **プレゼンテーションに画像を BLOB として追加する**

[IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) インターフェイスおよび [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) クラスのメソッドを使用すると、画像をストリームとして追加し BLOB として扱うことができます。

以下の Python コードは、BLOB プロセスを介して大型画像を追加する方法を示しています。

```py
import aspose.slides as slides

# 画像を追加する新しいプレゼンテーションを作成します。
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **メモリと大型プレゼンテーション**

通常、大型プレゼンテーションを読み込むには多くの一時メモリが必要です。プレゼンテーションのすべての内容がメモリにロードされ、元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオファイルを含む大型 PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。標準的な読み込み方法は次の Python コードで示されます。

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
    pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

しかしこの方法では約 1.6 GB の一時メモリが消費されます。

### **BLOB として大型プレゼンテーションを読み込む**

BLOB プロセスを使用すれば、少量のメモリで大型プレゼンテーションを読み込めます。以下の Python コードは、BLOB を利用して large.pptx を読み込み、PDF に変換する例です。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
    pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **一時ファイル用フォルダーを変更する**

BLOB プロセスを使用すると、デフォルトの一時ファイルフォルダーに一時ファイルが作成されます。別のフォルダーに保存したい場合は、`temp_files_root_path` を使用して設定できます。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="情報" color="info" %}}
`temp_files_root_path` を使用する場合、Aspose.Slides は一時フォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides のプレゼンテーションで、どのデータが BLOB とみなされ、BLOB オプションで制御されますか？**

画像、音声、ビデオなどの大型バイナリオブジェクトが BLOB とみなされます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理の対象となります。これらのオブジェクトは、メモリ使用量を管理し、必要に応じて一時ファイルへスピルできる BLOB ポリシーで制御されます。

**プレゼンテーションの読み込み時に BLOB 処理のルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限、一時ファイルの許可・不許可、ルートパス、ソースロック動作などを設定します。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

はい。BLOB をメモリに保持すれば速度は速くなりますが RAM 消費が増えます。メモリ上限を下げれば一時ファイルが多く使用され、RAM は減りますが I/O が増えて速度が低下します。`max_blobs_bytes_in_memory` の閾値を調整して、ワークロードや環境に最適なバランスを見つけてください。

**極端に大きなプレゼンテーション（数ギガバイト規模）を開く際に BLOB 設定は役立ちますか？**

はい。[BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルの有効化とソースロックの使用により、ピーク RAM 使用量を大幅に削減し、安定した処理が可能になります。

**ストリームから読み込む場合でも BLOB ポリシーは適用できますか？**

はい。ストリームでも同じルールが適用されます。プレゼンテーションインスタンスは選択したロックモードに応じて入力ストリームを所有・ロックでき、許可されていれば一時ファイルが使用され、処理中のメモリ使用量が予測可能になります。