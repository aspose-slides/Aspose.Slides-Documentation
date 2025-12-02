---
title: Pythonでプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/python-net/open-presentation/
keywords:
- PowerPointを開く
- プレゼンテーションを開く
- PPTXを開く
- PPTを開く
- ODPを開く
- プレゼンテーションを読み込む
- PPTXを読み込む
- PPTを読み込む
- ODPを読み込む
- 保護されたプレゼンテーション
- 大容量プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを手軽に開く—高速で信頼性が高く、機能が充実しています。"
---

## **概要**

最初からPowerPointプレゼンテーションを作成するだけでなく、Aspose.Slides は既存のプレゼンテーションを開くこともできます。プレゼンテーションをロードした後、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、その他さまざまな操作が可能です。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスをインスタンス化し、コンストラクタにファイルパスを渡します。

以下の Python 例は、プレゼンテーションを開いてスライド数を取得する方法を示しています:
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成し、コンストラクタにファイルパスを渡します。
with slides.Presentation("sample.pptx") as presentation:
    # プレゼンテーションのスライド総数を出力します。
    print(presentation.slides.length)
```


## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) プロパティにパスワードを渡して復号化し、ロードします。以下の Python コードはこの操作を示しています:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # 復号化されたプレゼンテーションで操作を実行します。
```


## **大容量プレゼンテーションを開く**

Aspose.Slides は、大容量プレゼンテーションのロードを支援するオプションを提供します――特に [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) プロパティです。

以下の Python コードは、たとえば 2 GB の大容量プレゼンテーションをロードする例を示しています:
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# KeepLocked 動作を選択します—プレゼンテーション ファイルは
# Presentation インスタンスの存続期間中ロックされたままですが、メモリにロードしたり一時ファイルにコピーしたりする必要はありません。
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # 大容量プレゼンテーションがロードされ、使用可能です。メモリ消費は低く抑えられます。

    # プレゼンテーションを変更します。
    presentation.slides[0].name = "Large presentation"

    # プレゼンテーションを別のファイルに保存します。この操作中もメモリ消費は低く抑えられます。
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # これを実行しないでください！プレゼンテーションオブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    os.remove(file_path)

# ここで実行しても問題ありません。ソースファイルはプレゼンテーションオブジェクトによってロックされていません。
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
ストリームで作業する際の特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量のプレゼンテーションをロードすると、プレゼンテーションがコピーされ、ロードが遅くなる可能性があります。そのため、大容量のプレゼンテーションをロードする必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。

大きなオブジェクト（ビデオ、オーディオ、高解像度画像など）を含むプレゼンテーションを作成する場合は、[BLOB management](/slides/ja/python-net/manage-blob/) を使用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。以下の Python コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています:
```python
# [TODO[not_supported_yet]: python の .NET インターフェイス実装]
```


## **埋め込みバイナリオブジェクトなしでプレゼンテーションをロードする**

PowerPoint プレゼンテーションには、次の種類の埋め込みバイナリオブジェクトが含まれることがあります。

- VBA プロジェクト（[Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) でアクセス可能）;
- OLE オブジェクトの埋め込みデータ（[OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) でアクセス可能）;
- ActiveX コントロールのバイナリデータ（[Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/) でアクセス可能）。

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) プロパティを使用すると、埋め込みバイナリオブジェクトなしでプレゼンテーションをロードできます。

このプロパティは、潜在的に悪意のあるバイナリコンテンツを除去するのに便利です。以下の Python コードは、埋め込みバイナリコンテンツなしでプレゼンテーションをロードする方法を示しています:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # プレゼンテーションで操作を実行します。
```


## **FAQ**

**ファイルが破損していて開けないことはどうやって判断できますか？**

ロード時にパース/フォーマット検証例外がスローされます。この種のエラーは、無効な ZIP 構造や破損した PowerPoint レコードが原因であることが多いです。

**開くときに必須フォントが欠落している場合はどうなりますか？**

ファイルは開きますが、後の [rendering/export](/slides/ja/python-net/convert-presentation/) 時にフォントが置き換えられる可能性があります。[フォント置換の構成](/slides/ja/python-net/font-substitution/) または [必要なフォントを追加](/slides/ja/python-net/custom-font/) してランタイム環境に設定してください。

**開くときに埋め込みメディア（ビデオ/オーディオ）はどうなりますか？**

それらはプレゼンテーションのリソースとして利用可能になります。メディアが外部パスで参照されている場合、そのパスが環境でアクセス可能であることを確認してください。そうでない場合、[rendering/export](/slides/ja/python-net/convert-presentation/) でメディアが省略されることがあります。