---
title: Python で PowerPoint プレゼンテーションを Markdown に変換する
linktitle: PowerPoint から Markdown へ
type: docs
weight: 140
url: /ja/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から MD へ
- プレゼンテーションから MD へ
- スライドから MD へ
- PPT から MD へ
- PPTX から MD へ
- PowerPoint を Markdown として保存
- プレゼンテーションを Markdown として保存
- スライドを Markdown として保存
- PPT を MD として保存
- PPTX を MD として保存
- PPT を MD にエクスポート
- PPTX を MD にエクスポート
- Markdown 画像エクスポート
- CDN 画像リンク
- PowerPoint
- プレゼンテーション
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Python で PPT および PPTX のプレゼンテーションを Markdown に変換し、エクスポートされた画像の保存場所と生成された Markdown が画像を参照する方法を制御します。"
---
## **概要**

Aspose.Slides for Python via .NET は、ドキュメント作成、静的サイト、コンテンツ移行、バージョン管理のワークフロー向けに、PPT および PPTX プレゼンテーションを Markdown に変換できます。Markdown のフレーバーを選択したり、スライドコンテンツのレンダリング方法を制御したり、エクスポートされた画像の保存場所や生成された Markdown が画像を参照する方法を決定したりできます。

既定では、Markdown エクスポートはテキストのみの出力になります。ビジュアルコンテンツをエクスポートするには、[MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownsaveoptions/export_type/) プロパティを [MarkdownExportType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownexporttype/) 列挙体の `SEQUENTIAL` または `VISUAL` のいずれかに設定します。`SEQUENTIAL` はスライド項目を個別かつ順番通りにレンダリングし、`VISUAL` はグループ化された項目をまとめて保持し、視覚的な関係を保ちます。`TEXT_ONLY` の値は画像リソースを出力しません。

## **プレゼンテーションを Markdown に変換する**

ソースファイルを [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスで読み込み、次に [Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ipresentation/save/) メソッドを呼び出し、[SaveFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) 列挙体の `MD` 値を指定します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Markdown フレーバーを選択する**

[MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownsaveoptions/flavor/) プロパティは、出力に使用される Markdown の仕様を制御します。[Flavor](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/flavor/) 列挙体には CommonMark、GitHub Flavored Markdown、その他のサポートされているバリアントが含まれます。

以下の例はプレゼンテーションを CommonMark としてエクスポートします：

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **デフォルトのローカル保存動作で画像をエクスポートする**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownsaveoptions/) クラスは、ローカルに保存される画像のための2つのプロパティを提供します：

- [base_path](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownsaveoptions/base_path/) は Markdown ドキュメントとそのリソースの基礎ディレクトリを指定します。
- [images_save_folder_name](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) は画像のサブディレクトリを指定します。その既定値は `Images` です。

以下の例はビジュアルコンテンツをレンダリングし、画像を `output/assets` に書き込み、Markdown ドキュメントに相対的な画像参照を作成します：

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

エクスポートが画像リソースを生成する場合、Aspose.Slides は画像サブディレクトリを作成しますが、アプリケーションは Markdown ファイルを保存する前に `base_path` を作成する必要があります。

## **Markdown と画像を公開用に準備する**

Aspose.Slides for Python via .NET は、エクスポート中に生成された各画像リンクを置き換えるための .NET 画像保存コールバックを公開していません。その代わりに、Markdown ドキュメントと画像フォルダーを公開ディレクトリにエクスポートし、相対構造を変更せずにそのディレクトリを公開します。

以下の例は `cdn-origin/presentations/quarterly-report` をマウントまたは同期された公開ディレクトリとして準備します。このサンプル自体はネットワークへのアップロードを行いません。生成されたリンクは、ディレクトリが目的のサイトまたは CDN の場所で公開された後に有効になります。

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

`presentation.md` と `assets` ディレクトリを一緒に公開します。Markdown ドキュメントは相対画像参照を使用しているため、両方の項目は宛先で同じ関係を保持する必要があります。公開システムが絶対外部 URL を要求する場合は、すべての画像ファイルが公開された後に、生成されたリンクを別の後処理ステップで書き換えてください。

## **FAQ**

**Python のコールバックで Markdown エクスポート中に個々の画像ファイルやリンクをカスタマイズできますか？**

いいえ。Aspose.Slides for Python via .NET は .NET の `ImageSaving` および `SvgImageSaving` コールバックを公開していません。ローカル出力は [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownsaveoptions/base_path/) と [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) で構成し、生成されたリソースを公開または後処理してください。

**エクスポートされた画像はどこに保存されますか？**

画像の保存場所は [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownsaveoptions/base_path/) と [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) によって制御されます。Markdown ドキュメントはそれらの画像を相対パスで参照します。

**画像リンクにはどのパス区切り文字を使用すべきですか？**

Markdown のリンクや URL ではスラッシュ (`/`) を使用してください。ファイルシステムのパスには `os.path.join` を使用し、後処理で作成したリンクは別途正規化してください。

**ハイパーリンクは Markdown エクスポート中に保持されますか？**

はい。テキストの [ハイパーリンク](/slides/ja/python-net/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [トランジション](/slides/ja/python-net/slide-transition/) や [アニメーション](/slides/ja/python-net/powerpoint-animation/) は変換されません。

**プレゼンテーションを並列に Markdown に変換できますか？**

異なるプレゼンテーション ファイルを並列に処理することは可能ですが、スレッド間で同じ [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを共有しないでください。[multithreading guidelines](/slides/ja/python-net/multithreading/) に従い、各ファイルごとに別々のインスタンスを使用してください。