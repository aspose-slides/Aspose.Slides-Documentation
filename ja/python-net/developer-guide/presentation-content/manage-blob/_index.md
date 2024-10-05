---
title: BLOBの管理
type: docs
weight: 10
url: /python-net/manage-blob/
keywords: "BLOBの追加, BLOBのエクスポート, BLOBとして画像を追加, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションにBLOBを追加します。BLOBをエクスポートします。画像をBLOBとして追加します。"
---

### **BLOBについて**

**BLOB** (**Binary Large Object**) は通常、バイナリ形式で保存された大きなアイテム（写真、プレゼンテーション、ドキュメント、メディアなど）を指します。

Aspose.Slides for Python via .NETは、大きなファイルが関与する場合にメモリ消費を減らす方法でオブジェクトにBLOBを使用することを可能にします。

# **メモリ消費を減らすためのBLOBの使用**

### **プレゼンテーションにBLOBを介して大きなファイルを追加する**

[Aspose.Slides](/slides/python-net/) for .NETは、メモリ消費を減らすためにBLOBを使用するプロセスを介して大きなファイル（この場合は大きな動画ファイル）をプレゼンテーションに追加することを可能にします。

このPythonコードは、BLOBプロセスを介して大きな動画ファイルをプレゼンテーションに追加する方法を示しています：

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# 動画が追加される新しいプレゼンテーションを作成
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # プレゼンテーションに動画を追加します - "veryLargeVideo.avi"ファイルにアクセスするつもりはないので
        # KeepLockedの動作を選択します。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、presオブジェクトのライフサイクルを通じて
        # メモリ消費は低く抑えられます。
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **プレゼンテーションからBLOBを介して大きなファイルをエクスポートする**
Aspose.Slides for Python via .NETは、プレゼンテーションからBLOBを使用するプロセスを介して大きなファイル（この場合はオーディオまたは動画ファイル）をエクスポートすることを可能にします。たとえば、大きなメディアファイルをプレゼンテーションから抽出する必要があるが、コンピュータのメモリにファイルを読み込みたくない場合があります。BLOBプロセスを通じてファイルをエクスポートすることで、メモリ消費を低く抑えることができます。

このPythonコードは、説明した操作を示しています：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
    # 各動画をファイルに保存します。高いメモリ使用を防ぐために、プレゼンテーションの動画ストリームから
    # 新しく作成された動画ファイルのストリームにデータを転送するためのバッファが必要です。
    # byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

    # 動画を反復処理
    index = 0
    # 必要であれば、オーディオファイルにも同様の手順を適用することができます。
    for video in pres.videos:
        # プレゼンテーション動画ストリームを開きます。注意してください、意図的にvideo.BinaryDataのようなプロパティにアクセスすることは
        # 避けています - なぜならこのプロパティは全動画を含むバイト配列を返すため、その後バイトがメモリにロードされるからです。video.GetStreamを使用し、
        # ストリームを返します - そして全動画をメモリに読み込む必要はありません。
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index=index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **プレゼンテーションにBLOBとして画像を追加する**
[**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)インターフェースと[**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/)クラスのメソッドを使用すると、大きな画像をストリームとして追加してBLOBとして扱うことができます。

このPythonコードは、BLOBプロセスを介して大きな画像を追加する方法を示しています：

```py
import aspose.slides as slides

# 画像が追加される新しいプレゼンテーションを作成します。
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **メモリと大きなプレゼンテーション**

通常、大きなプレゼンテーションをロードするには、コンピュータは大量の一時メモリを必要とします。プレゼンテーションの内容はすべてメモリにロードされ、プレゼンテーションが読み込まれたファイルは使用されなくなります。

1.5 GBの動画ファイルを含む大きなPowerPointプレゼンテーション（large.pptx）を考えてみてください。プレゼンテーションをロードする標準的な方法は、このPythonコードで説明されています：

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
    pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

しかし、この方法は約1.6 GBの一時メモリを消費します。

### **大きなプレゼンテーションをBLOBとしてロードする**

BLOBを使用するプロセスを介して、大きなプレゼンテーションを少ないメモリでロードすることができます。このPythonコードは、BLOBプロセスを使用して大きなプレゼンテーションファイル（large.pptx）をロードする実装を示しています：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
    pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

#### **一時ファイルのフォルダーを変更する**

BLOBプロセスを使用すると、コンピュータは一時ファイルを一時ファイル用のデフォルトフォルダーに作成します。一時ファイルを別のフォルダーに保持したい場合は、`temp_files_root_path`を使用してストレージの設定を変更できます：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="情報" color="info" %}}

`temp_files_root_path`を使用する際、Aspose.Slidesは一時ファイルを保存するために自動的にフォルダーを作成しません。手動でフォルダーを作成する必要があります。

{{% /alert %}}