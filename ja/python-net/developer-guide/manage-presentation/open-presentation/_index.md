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
- プレゼンテーションをロードする
- PPTX をロードする
- PPT をロードする
- ODP をロードする
- 保護されたプレゼンテーション
- 大きなプレゼンテーション
- 外部リソース
- バイナリオブジェクト
- Python
- Aspose.Slides
description: "Python で PowerPoint および OpenDocument のプレゼンテーションを開く方法、開く際のパスワードを指定する方法、そして Aspose.Slides for Python via .NET を使用してメモリ使用量を削減する方法を学びます。"
---
## **はじめに**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/ja/python-net/) は、ファイルやストリームから PowerPoint と OpenDocument のプレゼンテーションを読み込むことができます。プレゼンテーションを読み込んだ後、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または他のサポートされている形式で保存したりできます。

読み込み動作は [LoadOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/) クラスでカスタマイズできます。たとえば、開くためのパスワードを指定したり、大きなバイナリオブジェクトをメモリ外に保持したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、ファイルパスを [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) コンストラクタに渡します。`with` 文を使用すると、ファイルハンドル、テンポラリ データ、その他のリソースが速やかに解放されます。

以下の Python の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **パスワード保護されたプレゼンテーションを開く**

開く際のパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) に設定し、そのオプションを [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) コンストラクタに渡します。パスワードがない、または間違っている場合は読み込みに失敗します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

パスワードの検出、検証、暗号化ワークフローについては、[Password-Protect Presentations](/slides/ja/python-net/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメントプロパティとともに保存された場合、パスワードなしでそれらのプロパティを読むことができます。詳細は [Manage Presentation Properties](/slides/ja/python-net/presentation-properties/) をご覧ください。

## **大きなプレゼンテーションを開く**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/blob_management_options/) は、画像、音声、動画などのバイナリ大規模オブジェクトの取り扱いを制御します。ソースファイルをロックしたままにしたり、一時ファイルを許可したり、メモリに保持する BLOB データ量を制限したりできます。

以下の Python コードは、大きなプレゼンテーション（例として 2 GB）を読み込む方法を示しています：

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
`PresentationLockingBehavior.KEEP_LOCKED` を使用すると、`Presentation` オブジェクトが破棄されるまでソースファイルがロックされたままになります。そのオブジェクトが存続している間は、ソースファイルを移動、上書き、削除しないでください。

Aspose.Slides は読み込み時に入力ストリームの内容をコピーする場合があります。大きなプレゼンテーションでは、ストリームよりもファイルパスの方が一般的に効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/python-net/manage-blob/) を参照してください。
{{% /alert %}}

## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

プレゼンテーションには、アプリケーションが必要としない、または保持したくない埋め込みバイナリデータが含まれることがあります。例としては：

- VBA プロジェクトは [Presentation.vba_project](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/vba_project/) で利用できます；
- 埋め込み OLE データは [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) で利用できます；
- ActiveX コントロールデータは [Control.active_x_control_binary](https://reference.aspose.com/slides/ja/python-net/aspose.slides/control/active_x_control_binary/) で利用できます。

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) を `True` に設定すると、読み込み時にこのバイナリデータが削除されます。サニタイズされた結果を保持するために、読み込んだプレゼンテーションを保存してください。

このオプションは不要な埋め込みペイロードへの曝露を減らしますが、完全なマルウェア検出やコンテンツサニタイズシステムではありません。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**ファイルが破損していて開けないことはどのように判断できますか？**

Aspose.Slides は読み込み中にパース例外または形式例外をスローします。この失敗をパスワードが間違っているエラーとは別に処理し、アプリケーションが原因を正確に報告できるようにしてください。

**必要なフォントが見つからない場合はどうなりますか？**

プレゼンテーションは依然として読み込めますが、レンダリングやエクスポート時にフォントが置換されることがあります。出力をより予測可能にするために、[フォント置換の構成](/slides/ja/python-net/font-substitution/) または [カスタムフォントの提供](/slides/ja/python-net/custom-font/) を行うことができます。

**プレゼンテーションの読み込みは埋め込みメディアも読み込みますか？**

埋め込みの音声や動画はプレゼンテーションオブジェクトモデルを通じて利用可能になります。外部リソースはデフォルトのリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。