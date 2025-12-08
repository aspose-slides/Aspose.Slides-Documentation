---
title: PythonでPowerPointプレゼンテーションをMarkdownに変換
linktitle: PowerPointからMarkdownへ
type: docs
weight: 140
url: /ja/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPointをMarkdownに変換
- OpenDocumentをMarkdownに変換
- プレゼンテーションをMarkdownに変換
- スライドをMarkdownに変換
- PPTをMarkdownに変換
- PPTXをMarkdownに変換
- ODPをMarkdownに変換
- PowerPointをMDに変換
- OpenDocumentをMDに変換
- プレゼンテーションをMDに変換
- スライドをMDに変換
- PPTをMDに変換
- PPTXをMDに変換
- ODPをMDに変換
- PowerPoint
- OpenDocument
- presentation
- Markdown
- Python
- Aspose.Slides
description: "PowerPointとOpenDocumentのスライド（PPT、PPTX、ODP）をAspose.Slides for Python via .NETでクリーンなMarkdownに変換し、ドキュメントの自動化と書式の保持を実現します。"
---

## **プレゼンテーションをMarkdownに変換する**

以下の例は、Aspose.Slides for Python via .NET を使用し、既定の設定でPowerPointプレゼンテーションをMarkdownに変換する最も簡単な方法を示しています。

1. プレゼンテーションを読み込むために[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。
1. `save` を呼び出してMarkdownファイルとしてエクスポートします。

以下のPythonスニペットを使用して変換を実行します：
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```


## **プレゼンテーションをMarkdownフレーバーに変換する**

Aspose.Slides を使用すると、基本的なMarkdown、CommonMark、GitHubフレーバーMarkdown、Trello、XWiki、GitLab、その他17種類のMarkdownフレーバーを含む、さまざまなMarkdown形式にプレゼンテーションを変換できます。

以下のPython例は、PowerPointプレゼンテーションをCommonMarkに変換する方法を示しています：
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```


サポートされている23のMarkdownフレーバーは、[MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスの [Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 列挙体に一覧表示されています。

## **画像を含むプレゼンテーションをMarkdownに変換する**

[MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) クラスは、生成されるMarkdownファイルを構成できるプロパティと列挙体を提供します。たとえば、[MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 列挙体は画像の処理方法を制御します：`SEQUENTIAL`、`TEXT_ONLY`、または `VISUAL`。

### **画像を順次変換する**

生成されたMarkdownで画像を個別に（1枚ずつ）表示したい場合は、`SEQUENTIAL` オプションを選択します。以下のPython例は、画像付きプレゼンテーションをMarkdownに変換する方法を示しています。
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```


### **画像をビジュアルに変換する**

結果のMarkdownで画像をまとめて表示したい場合は、`VISUAL` オプションを選択します。このモードでは、画像はアプリケーションの現在のディレクトリに保存され（Markdown文書は相対パスを使用します）、またはカスタムの出力パスとフォルダー名を指定することもできます。

以下のPython例はこの操作を示しています：
```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```


## **FAQ**

**ハイパーリンクはMarkdownへのエクスポート後も残りますか？**

はい。テキストの[hyperlinks](/slides/ja/python-net/manage-hyperlinks/)は標準的なMarkdownリンクとして保持されます。スライドの[transitions](/slides/ja/python-net/slide-transition/)や[animations](/slides/ja/python-net/powerpoint-animation/)は変換されません。

**複数スレッドで実行して変換を高速化できますか？**

ファイル単位で並列化は可能ですが、スレッド間で同じ[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを[共有しない](/slides/ja/python-net/multithreading/)でください。ファイルごとに別々のインスタンスまたはプロセスを使用して競合を回避します。

**画像はどうなりますか？どこに保存され、パスは相対ですか？**

[Images](/slides/ja/python-net/image/) は専用フォルダーにエクスポートされ、Markdownファイルはデフォルトで相対パスで参照します。ベース出力パスとアセットフォルダー名を設定して、予測可能なリポジトリ構造を保つことができます。