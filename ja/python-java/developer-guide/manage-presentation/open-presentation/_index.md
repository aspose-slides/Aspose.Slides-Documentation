---
title: Python via Java でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/python-java/open-presentation/
keywords:
- PowerPoint を開く
- プレゼンテーションを開く
- PPTX を開く
- PPT を開く
- ODP を開く
- プレゼンテーションを読み込む
- PPTX を読み込む
- PPT を読み込む
- ODP を読み込む
- 保護されたプレゼンテーション
- 大容量プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- Python
- Java
- Aspose.Slides
description: "Python via Java で PowerPoint および OpenDocument プレゼンテーションを開く方法、開くためのパスワードを指定する方法、リソースの読み込みを制御する方法、そして Aspose.Slides for Python via Java を使用してメモリ使用量を削減する方法を学びます。"
---
## **はじめに**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ja/python-java/) は、PowerPoint および OpenDocument プレゼンテーションをファイルやストリームから読み込むことができます。プレゼンテーションが読み込まれた後は、構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または他のサポート形式で保存したりできます。

読み込み動作は [LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) クラスでカスタマイズできます。たとえば、開くためのパスワードを指定したり、巨大なバイナリオブジェクトを Java ヒープメモリの外に保持したり、外部リソースを制御したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、ファイルパスを [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドル、テンポラリデータ、その他のリソースが速やかに解放されるようにしてください。

以下の Python の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **パスワードで保護されたプレゼンテーションを開く**

開くためのパスワードはプレゼンテーションのコンテンツを暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setPassword) に渡し、オプションを [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) コンストラクタに提供します。パスワードが不足しているか間違っている場合、読み込みは失敗します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

パスワードの検出、検証、暗号化ワークフローについては、[Password-Protect Presentations](/slides/ja/python-java/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメントプロパティとともに保存されている場合、パスワードなしでこれらのプロパティを読み取ることができます。詳細は [Manage Presentation Properties](/slides/ja/python-java/presentation-properties/) をご覧ください。

## **大容量プレゼンテーションを開く**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) は、画像、音声、動画などのバイナリ大容量オブジェクト（BLOB）を Aspose.Slides がどのように扱うかを制御するオプションを返します。ソースファイルをロックしたままにしたり、テンポラリファイルを許可したり、メモリに保持する BLOB データ量を制限したりできます。

以下の Python コードは、たとえば 2 GB の大容量プレゼンテーションを読み込む方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) を使用すると、プレゼンテーション インスタンスが破棄されるまでソースファイルはロックされたままになります。そのインスタンスが存続している間は、ソースファイルを移動、上書き、削除しないでください。

Aspose.Slides は読み込み時に入力ストリームの内容をコピーすることがあります。大容量プレゼンテーションの場合、ストリームよりもファイルパスを使用した方が一般的に効率的です。ストレージおよびメモリ管理の追加オプションについては、[Manage BLOBs](/slides/ja/python-java/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースの制御**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) は、Java のリソース読み込みコールバックインターフェイスを実装した JPype プロキシを受け取ります。コールバックは代替データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。これは、プレゼンテーションに外部画像が含まれており、アプリケーション固有のセキュリティまたはストレージルールに従って解決する必要がある場合に便利です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

アプリケーションが不要、または保持したくない埋め込みバイナリデータがプレゼンテーションに含まれていることがあります。例としては次のものがあります。

- VBA プロジェクトは [Presentation.getVbaProject](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getVbaProject) で取得できます。
- 埋め込み OLE データは [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) で取得できます。
- ActiveX コントロールデータは [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ja/python-java/aspose.slides/control/#getActiveXControlBinary) で取得できます。

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) を `True` に設定すると、読み込み時にこれらのバイナリデータが削除されます。ロードしたプレゼンテーションを保存して、サニタイズされた結果を永続化してください。

このオプションは不要な埋め込みペイロードへの曝露を減らしますが、完全なマルウェア検出やコンテンツサニタイズシステムではありません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**ファイルが破損していて開けないことをどのように判断できますか？**

Aspose.Slides はロード中にパース例外または形式例外をスローします。パスワードが誤っているエラーとは別にこの失敗を処理し、原因を正確に報告できるようにしてください。

**必要なフォントが欠落している場合はどうなりますか？**

プレゼンテーションは依然としてロードされますが、レンダリングやエクスポート時にフォントが置き換えられることがあります。[フォント置換の構成](/slides/ja/python-java/font-substitution/) や [カスタムフォントの提供](/slides/ja/python-java/custom-font/) を利用して、出力をより予測可能にできます。

**プレゼンテーションをロードすると埋め込みメディアもロードされますか？**

埋め込みの音声や動画はプレゼンテーション オブジェクト モデルを通じて利用可能になります。外部リソースは構成されたリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。