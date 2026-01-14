---
title: Python を使用してプレゼンテーション内の BLOB を管理し、効率的なメモリ使用を実現する
linktitle: BLOB を管理
type: docs
weight: 10
url: /ja/python-net/manage-blob/
keywords:
- 大きなオブジェクト
- 大きなアイテム
- 大きなファイル
- BLOB の追加
- BLOB のエクスポート
- 画像を BLOB として追加
- メモリ削減
- メモリ消費
- 大規模プレゼンテーション
- 一時ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET における BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化して、プレゼンテーションの取り扱いを最適化します。"
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存される大きなアイテム（写真、プレゼンテーション、ドキュメント、またはメディア）です。

Aspose.Slides for Python via .NET は、大きなファイルが関わる場合にメモリ消費を抑える方法でオブジェクトに BLOB を使用できるようにします。

## **BLOB を使用してメモリ消費を削減する**

### **BLOB 経由で大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/python-net/) for .NET は、BLOB を利用したプロセスで大きなファイル（この場合は大きな動画ファイル）を追加し、メモリ消費を削減できます。

この Python は、BLOB プロセスを使用して大きな動画ファイルをプレゼンテーションに追加する方法を示します:
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# ビデオを追加する新しいプレゼンテーションを作成します
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # ビデオをプレゼンテーションに追加します - KeepLocked 動作を選択したのは
        # 「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ使用量は
        # pres オブジェクトのライフサイクル全体で低く保たれます 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```



### **プレゼンテーションから BLOB 経由で大きなファイルをエクスポートする**

Aspose.Slides for Python via .NET は、BLOB を利用したプロセスでプレゼンテーションから大きなファイル（この場合は音声または動画ファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディアファイルを抽出したいが、コンピュータのメモリに読み込ませたくない場合があります。BLOB プロセスでエクスポートすることで、メモリ消費を低く抑えることができます。

以下の Python コードは、上記の操作を実演しています：
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# 各ビデオをファイルに保存します。メモリ使用量を抑えるために、使用されるバッファが必要です
	# プレゼンテーションのビデオストリームから新しく作成されたビデオファイル用のストリームへデータを転送するために使用します。
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# ビデオを反復処理します
    index = 0
    # 必要に応じて、オーディオファイルにも同じ手順を適用できます。 
    for video in pres.videos:
		# プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを回避したことに注意してください
		# video.BinaryData のようなプロパティは、フルビデオを含むバイト配列を返すため、
		# メモリにバイトがロードされます。そのため、video.GetStream を使用し、Stream を返しますが、 
		# メモリ全体にビデオ全体をロードする必要はありません。
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

[**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

以下の Python コードは、BLOB プロセスを使用して大きな画像を追加する方法を示します：
```py
import aspose.slides as slides

# 画像が追加される新しいプレゼンテーションを作成します。
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```


## **メモリと大規模プレゼンテーション**

通常、大きなプレゼンテーションを読み込むには、コンピュータは大量の一時メモリを必要とします。プレゼンテーションのすべてのコンテンツがメモリにロードされ、プレゼンテーションが読み込まれたファイルは使用されなくなります。

1.5 GB の動画ファイルを含む大きな PowerPoint プレゼンテーション (large.pptx) を考えてみましょう。プレゼンテーションを読み込む標準的な方法は、以下の Python コードで示されています：

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


ただし、この方法では約 1.6 GB の一時メモリが消費されます。

### **BLOB として大きなプレゼンテーションを読み込む**

BLOB を利用したプロセスにより、少量のメモリで大きなプレゼンテーションを読み込むことができます。以下の Python コードは、BLOB プロセスを使用して大きなプレゼンテーションファイル (large.pptx) を読み込む実装を示しています：
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


### **一時ファイルのフォルダーを変更する**

BLOB プロセスを使用すると、コンピュータはデフォルトの一時ファイルフォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`temp_files_root_path` を使用してストレージ設定を変更できます：
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```


{{% alert title="Info" color="info" %}}
`temp_files_root_path` を使用すると、Aspose.Slides は一時ファイル用のフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides のプレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**

画像、音声、動画などの大きなバイナリオブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理が行われます。これらのオブジェクトは BLOB ポリシーに従い、メモリ使用量を管理し、必要に応じて一時ファイルにスピルできます。

**プレゼンテーションの読み込み時に BLOB 処理ルールを設定する場所はどこですか？**

[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ内上限、一時ファイルの許可・不許可、temp ファイルのルートパス、ソースロックの動作を設定します。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

はい。BLOB をメモリ内に保持すると速度は最大化されますが、RAM 消費が増加します。メモリ上限を下げると、より多くの処理が一時ファイルへ移り、RAM は削減されますが I/O が増加します。[max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) の閾値を調整し、ワークロードと環境に適したバランスを取ります。

**非常に大きなプレゼンテーション（例：ギガバイト単位）を開く際に BLOB オプションは役立ちますか？**

はい。そのようなシナリオ向けに [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) が用意されています。 一時ファイルを有効化し、ソースロックを使用することで、ピーク RAM 使用量を大幅に削減し、非常に大きなデックの処理を安定させます。

**ディスクファイルではなくストリームから読み込む際に BLOB ポリシーを使用できますか？**

はい。同じルールがストリームにも適用されます。プレゼンテーションインスタンスは入力ストリームを所有しロックできます（選択したロックモードに依存）、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。