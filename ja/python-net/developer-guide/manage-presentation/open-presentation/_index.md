---
title: Python でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/python-net/open-presentation/
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
- 大規模プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- Python
- Aspose.Slides
description: "Python で PowerPoint と OpenDocument のプレゼンテーションを開く方法、開く際のパスワードを設定する方法、そして Aspose.Slides for Python via .NET を使用してメモリ使用量を削減する方法を学びます。"
---
## **概要**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/ja/python-net/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションを読み込むことができます。プレゼンテーションを読み込んだ後、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または別のサポートされた形式で保存したりできます。

[LoadOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/) クラスを使用して、読み込み動作をカスタマイズできます。たとえば、開く際のパスワードを指定したり、大きなバイナリオブジェクトをメモリ外に保持したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションを開く**

ファイルまたはストリームを読み込んだ後、[元のプレゼンテーション形式を判定](/slides/ja/python-net/detect-presentation-source-format/) して、アプリケーションの処理方法を選択できます。

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) コンストラクタに渡します。`with` 文を使用して、ファイルハンドルや一時データ、その他のリソースが速やかに解放されるようにします。

次の Python の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **パスワードで保護されたプレゼンテーションを開く**

開く際のパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) に設定し、そのオプションを [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) コンストラクタに渡します。パスワードが未設定または誤っている場合、読み込みは失敗します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

パスワードの検出、検証、暗号化ワークフローについては、[Password-Protect Presentations](/slides/ja/python-net/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的にパブリックなドキュメントプロパティと共に保存されている場合、そのプロパティはパスワードなしで読み取れます。詳細は [Manage Presentation Properties](/slides/ja/python-net/presentation-properties/) をご覧ください。

## **大きなプレゼンテーションを開く**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/blob_management_options/) は、画像、音声、動画などのバイナリ大規模オブジェクト (BLOB) の処理方法を制御します。ソースファイルをロックしたままにしたり、一時ファイルを許可したり、メモリに保持する BLOB データ量を制限したりできます。

この Python コードは、大きなプレゼンテーション（例として 2 GB）を読み込む方法を示しています：

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior.KEEP_LOCKED` を使用すると、`Presentation` オブジェクトが破棄されるまでソースファイルがロックされたままになります。オブジェクトが存続している間は、ソースファイルを移動、上書き、削除しないでください。

Aspose.Slides は、読み込み時に入力ストリームの内容をコピーすることがあります。大きなプレゼンテーションの場合、ファイルパスの方がストリームよりも一般的に効率的です。追加のストレージやメモリ管理オプションについては、[Manage BLOBs](/slides/ja/python-net/manage-blob/) を参照してください。
{{% /alert %}}

## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

プレゼンテーションには、アプリケーションが必要としない、または保持したくない埋め込みバイナリデータが含まれていることがあります。例としては、以下があります：

- VBA プロジェクトは [Presentation.vba_project](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/vba_project/) で取得できます；
- 埋め込み OLE データは [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) で取得できます；
- ActiveX コントロールデータは [Control.active_x_control_binary](https://reference.aspose.com/slides/ja/python-net/aspose.slides/control/active_x_control_binary/) で取得できます。

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) を `True` に設定すると、読み込み時にこのバイナリデータが削除されます。サニタイズされた結果を保持するために、読み込んだプレゼンテーションを保存してください。

このオプションは不要な埋め込みペイロードへの曝露を減らしますが、完全なマルウェア検出やコンテンツサニタイズのシステムではありません。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**ファイルが破損していて開けないことはどのように判断できますか？**

Aspose.Slides は読み込み中に解析エラーまたは形式エラーの例外をスローします。この失敗をパスワードが間違っているエラーとは別に処理し、アプリケーションが原因を正確に報告できるようにしてください。

**必要なフォントが見つからない場合はどうなりますか？**

プレゼンテーションは依然として読み込むことができますが、レンダリングやエクスポート時にフォントが置換される可能性があります。出力をより予測可能にするために、[font substitution の設定](/slides/ja/python-net/font-substitution/) または [カスタムフォントの提供](/slides/ja/python-net/custom-font/) を行うことができます。

**プレゼンテーションの読み込みは埋め込みメディアも読み込みますか？**

埋め込みの音声や動画はプレゼンテーションオブジェクトモデルを通じて利用可能になります。外部リソースはデフォルトのリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。