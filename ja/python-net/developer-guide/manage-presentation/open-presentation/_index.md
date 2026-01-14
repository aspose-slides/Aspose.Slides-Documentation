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
- プレゼンテーションをロードする
- PPTXをロードする
- PPTをロードする
- ODPをロードする
- 保護されたプレゼンテーション
- 大容量プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを簡単に開くことができます—高速で信頼性が高く、フル機能です。"
---

## **概要**

PowerPoint プレゼンテーションを最初から作成するだけでなく、Aspose.Slides では既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後は、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、その他さまざまな操作が可能です。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、コンストラクタにファイル パスを渡します。

次の Python の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています:
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成し、コンストラクタにファイルパスを渡します。
with slides.Presentation("sample.pptx") as presentation:
    # プレゼンテーションのスライド総数を出力します。
    print(presentation.slides.length)
```


## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) プロパティにパスワードを指定して復号化し、読み込みます。以下の Python コードがこの操作を示しています:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # 復号化されたプレゼンテーションで操作を実行します。
```


## **大容量プレゼンテーションを開く**

Aspose.Slides は、特に [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) プロパティなどのオプションを提供し、大容量プレゼンテーションの読み込みを支援します。

次の Python コードは、たとえば 2 GB の大容量プレゼンテーションを読み込む例です:
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# KeepLocked 動作を選択します—プレゼンテーション ファイルはインスタンスの存続期間中ロックされたままになります
# プレゼンテーション インスタンスですが、メモリにロードしたり一時ファイルにコピーする必要はありません。
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # 大容量のプレゼンテーションがロードされ、使用可能です。メモリ使用量は低く抑えられます。

    # プレゼンテーションを変更します。
    presentation.slides[0].name = "Large presentation"

    # プレゼンテーションを別のファイルに保存します。この操作中もメモリ使用量は低く抑えられます。
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # これを行わないでください！プレゼンテーション オブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    os.remove(file_path)

# ここで行っても問題ありません。ソース ファイルはプレゼンテーション オブジェクトによるロックが解除されています。
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
ストリームで作業する際の特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量プレゼンテーションを読み込むと、プレゼンテーションがコピーされ、読み込みが遅くなる可能性があります。したがって、大容量プレゼンテーションを読み込む必要がある場合は、ストリームではなくプレゼンテーションのファイル パスを使用することを強く推奨します。

大きなオブジェクト（動画、音声、高解像度画像など）を含むプレゼンテーションを作成する場合は、[BLOB management](/slides/ja/python-net/manage-blob/) を使用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) クラスを提供します。以下の Python コードは `IResourceLoadingCallback` クラスの使用方法を示しています:
```python
# [TODO[not_supported_yet]: .NET インターフェイスの Python 実装]
```


## **埋め込みバイナリ オブジェクトなしでプレゼンテーションをロードする**

PowerPoint プレゼンテーションには、次の種類の埋め込みバイナリ オブジェクトが含まれることがあります。

- VBA プロジェクト（[Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) でアクセス可能）;
- OLE オブジェクトの埋め込みデータ（[OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) でアクセス可能）;
- ActiveX コントロールのバイナリ データ（[Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/) でアクセス可能）.

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) プロパティを使用すると、埋め込みバイナリ オブジェクトを含まないプレゼンテーションを読み込むことができます。

このプロパティは、潜在的に危険なバイナリ コンテンツを除去するのに便利です。以下の Python コードは、埋め込みバイナリ コンテンツを含まないプレゼンテーションを読み込む方法を示しています:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # プレゼンテーションに対して操作を行います。
```


## **FAQ**

**ファイルが破損していて開けないことをどう判断できますか？**

読み込み中に解析/形式検証例外がスローされます。この種のエラーは、ZIP 構造が無効であるか PowerPoint のレコードが破損していることを示すことが多いです。

**開く際に必須フォントが欠落しているとどうなりますか？**

ファイルは開きますが、後の [rendering/export](/slides/ja/python-net/convert-presentation/) 時にフォントが置き換えられることがあります。[フォント置換の設定](/slides/ja/python-net/font-substitution/) または [必要なフォントの追加](/slides/ja/python-net/custom-font/) を実行環境に行ってください。

**開く際の埋め込みメディア（動画/音声）はどう扱われますか？**

メディアはプレゼンテーションのリソースとして利用可能になります。メディアが外部パスで参照されている場合、そのパスが環境でアクセス可能であることを確認してください。そうでないと、[rendering/export](/slides/ja/python-net/convert-presentation/) 時にメディアが省略される可能性があります。