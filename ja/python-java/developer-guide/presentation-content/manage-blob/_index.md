---
title: "効率的なメモリ使用のため、Python via Java でプレゼンテーション BLOB を管理する"
linktitle: "BLOB の管理"
type: docs
weight: 10
url: /ja/python-java/manage-blob/
keywords:
- 大きなオブジェクト
- 大きな項目
- 大容量ファイル
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
- Java
- Aspose.Slides
description: "Python via Java 用 Aspose.Slides の BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化して、プレゼンテーションの取り扱いを最適化します。"
---
## **概要**

Aspose.Slides は、プレゼンテーション内の大きなバイナリ データを BLOB ベースで処理し、大きな画像、音声、ビデオ、プレゼンテーション ファイルを扱う際のメモリ使用量を削減します。

本稿では、BLOB ベースの処理を使用してプレゼンテーションに大容量メディアを追加する方法、プレゼンテーションから大容量メディアをエクスポートする方法、および大規模なプレゼンテーションをより効率的にロードする方法を示します。また、処理中に一時ファイルを使用する方法と、その保存フォルダーを変更する方法についても説明します。

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存された大きな項目（写真、プレゼンテーション、文書、またはメディア）を指します。

Aspose.Slides for Python via Java は、オブジェクトに対して BLOB を使用できるようにし、大容量ファイルを扱う際のメモリ使用量を削減します。

{{% alert color="info" title="注意" %}}
ストリームとのやり取りで特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大容量のプレゼンテーションをロードすると、プレゼンテーションの内容がコピーされ、ロードが遅くなります。したがって、大容量のプレゼンテーションをロードする場合は、ストリームではなくプレゼンテーションのファイル パスを使用することを強く推奨します。
{{% /alert %}}

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB を使用してプレゼンテーションに大きなファイルを追加する**

[Aspose.Slides](/slides/ja/python-java/) for Python via Java は、BLOB を使用したプロセスで大容量ファイル（この場合は大きなビデオ ファイル）をプレゼンテーションに追加し、メモリ使用量を削減できます。

以下の Python コードは、BLOB プロセスを使用して大きなビデオ ファイルをプレゼンテーションに追加する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# ビデオを追加する新しいプレゼンテーションを作成します。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # ビデオ ファイルにアクセスしないため、ストリームをロックしたままにします。
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # メモリ使用量を抑えたままプレゼンテーションを保存します。
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **BLOB を使用してプレゼンテーションから大きなファイルをエクスポートする**

Aspose.Slides for Python via Java は、BLOB を使用したプロセスでプレゼンテーションから大容量ファイル（この場合は音声またはビデオ ファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディア ファイルを抽出したいが、コンピュータのメモリにロードしたくない場合があります。BLOB プロセスでファイルをエクスポートすることで、メモリ使用量を低く抑えることができます。

以下の Python コードは、上記の操作を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# ソース ファイルをロックし、メモリに読み込む代わりに使用します。
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # メモリ使用量を抑えるため、バッファを介してビデオ データを転送します。
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # ビデオ全体をバイト配列に読み込む代わりに、ストリームを使用します。
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # 必要に応じて、同じ手順をオーディオ ファイルに適用します。
finally:
    presentation.dispose()
```

### **画像を BLOB としてプレゼンテーションに追加する**

[ImageCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/) クラスのメソッドを使用すると、大きな画像をストリームとして追加し、BLOB として扱うことができます。

以下の Python コードは、BLOB プロセスを使用して大きな画像を追加する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# 画像を追加する新しいプレゼンテーションを作成します。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # 画像ファイルにアクセスしないため、ストリームをロックしたままにします。
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # メモリ使用量を抑えたままプレゼンテーションを保存します。
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **メモリと大規模プレゼンテーション**

通常、大規模なプレゼンテーションをロードするには、コンピュータは大量の一時メモリを必要とします。プレゼンテーションのすべての内容がメモリにロードされ、ロード元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオ ファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみます。プレゼンテーションをロードする標準的な方法は、以下の Python コードに示されています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

しかし、この方法では約 1.6 GB の一時メモリを消費します。

### **BLOB として大規模プレゼンテーションをロードする**

BLOB を使用したプロセスにより、少量のメモリで大規模なプレゼンテーションをロードできます。以下の Python コードは、BLOB プロセスを使用して大きなプレゼンテーション ファイル（large.pptx）をロードする実装を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **一時ファイルのフォルダーを変更する**

BLOB プロセスを使用すると、コンピュータはデフォルトの一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、[BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) を使用してストレージ設定を変更できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="注意" %}}
[BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) を使用すると、Aspose.Slides は一時ファイルを保存するフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

### **プレゼンテーション オブジェクトを破棄してメモリを解放する**

大規模なプレゼンテーションを処理する際は、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを適切に破棄し、占有していたメモリを解放してください。プレゼンテーションの使用が終わったら [Presentation.dispose](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#dispose) を呼び出してアンマネージド リソースを解放します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...プレゼンテーションを処理する...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # 明示的にリソースを解放します。
    presentation.dispose()
```

## **よくある質問**

**Aspose.Slides のプレゼンテーション内で BLOB とみなされ、BLOB オプションで制御されるデータは何ですか？**

画像、音声、ビデオなどの大容量バイナリ オブジェクトは BLOB とみなされます。また、プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理が行われます。これらのオブジェクトは BLOB ポリシーに従い、メモリ使用量を管理し、必要に応じて一時ファイルにスピル（書き出し）できるようになっています。

**プレゼンテーションの読み込み時に BLOB 処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/) を組み合わせて使用します。ここで BLOB のメモリ内上限、一時ファイルの許可・不許可、テンポラリ ファイルのルート パス、ソース ロックの動作を設定します。

**BLOB 設定はパフォーマンスに影響しますか？また、速度とメモリのバランスはどのように取りますか？**

はい。BLOB をメモリ上に保持すると速度は最大化されますが、RAM の消費が増加します。メモリ上限を下げると、より多くの処理が一時ファイルに委ねられ、RAM 使用量は減りますが I/O が増加します。ワークロードと環境に合わせて適切なバランスを取るには、[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) メソッドを使用してください。

**非常に大きなプレゼンテーション（例：ギガバイト単位）を開く際に BLOB オプションは役立ちますか？**

はい。そのようなシナリオ向けに設計された [BlobManagementOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/) を使用します。 一時ファイルの有効化とソース ロックの使用により、ピーク時の RAM 使用量を大幅に削減し、極めて大きなスライド デックの処理を安定させることができます。

**ディスク ファイルではなくストリームから読み込む場合でも BLOB ポリシーを使用できますか？**

はい。ストリームにも同じルールが適用されます。プレゼンテーション インスタンスは入力ストリームを所有・ロックでき（ロック モードに依存）、許可されている場合は一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。