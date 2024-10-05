---
title: PowerPointをPythonでMarkdownに変換する
type: docs
weight: 140
url: /python-net/convert-powerpoint-to-markdown/
keywords: "PowerPointをMarkdownに変換する, pptをmdに変換する, PowerPoint, PPT, PPTX, プレゼンテーション, Markdown, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointをMarkdownに変換する"
---

{{% alert color="info" %}} 

PowerPointからMarkdownへの変換サポートは、[Aspose.Slides 23.7](https://docs.aspose.com/slides/python-net/aspose-slides-for-python-net-23-7-release-notes/)で実装されました。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPointからMarkdownへのエクスポートはデフォルトで**画像なし**です。画像を含むPowerPoint文書をエクスポートしたい場合は、`saveOptions.export_type = MarkdownExportType.VISUAL`を設定し、Markdown文書で参照される画像が保存される`base_path`を設定する必要があります。

{{% /alert %}} 

## **PowerPointをMarkdownに変換する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成してプレゼンテーションオブジェクトを表します。
2. [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods)メソッドを使用して、オブジェクトをMarkdownファイルとして保存します。

以下のPythonコードは、PowerPointをMarkdownに変換する方法を示します：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:  
    pres.save("pres.md", slides.export.SaveFormat.MD)
```

## PowerPointをMarkdownフレーバーに変換する

Aspose.Slidesを使用すると、PowerPointをMarkdown（基本的な構文を含む）、CommonMark、GitHubフレーバーのMarkdown、Trello、XWiki、GitLab、および17の他のMarkdownフレーバーに変換できます。

以下のPythonコードは、PowerPointをCommonMarkに変換する方法を示します：

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, Flavor
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    saveOptions = MarkdownSaveOptions()
    saveOptions.flavor = Flavor.COMMONMARK

    pres.save("pres.md", SaveFormat.MD, saveOptions)
```

サポートされている23のMarkdownフレーバーは、[Flavor列挙体](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/)の下に[MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)クラスからリストされています。

## **画像を含むプレゼンテーションをMarkdownに変換する**

[MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/)クラスは、結果のMarkdownファイルに使用する特定のオプションや設定を許可するプロパティと列挙型を提供します。例えば、[MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/)列挙型は、画像がどのようにレンダリングまたは処理されるかを決定する値に設定できます：`Sequential`、`TextOnly`、`Visual`。

### **画像を順番に変換する**

画像が結果のMarkdownに一つずつ表示されるようにするには、順番のオプションを選択する必要があります。以下のPythonコードは、画像を含むプレゼンテーションをMarkdownに変換する方法を示します：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    markdownSaveOptions = slides.export.MarkdownSaveOptions()
    markdownSaveOptions.show_hidden_slides = True
    markdownSaveOptions.show_slide_number = True
    markdownSaveOptions.flavor = slides.export.Flavor.GITHUB
    markdownSaveOptions.export_type = slides.export.MarkdownExportType.SEQUENTIAL
    markdownSaveOptions.new_line_type = slides.export.NewLineType.WINDOWS
    
    pres.save("doc.md", [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ], slides.export.SaveFormat.MD, markdownSaveOptions)
```

### **画像を視覚的に変換する**

画像が結果のMarkdownに一緒に表示されるようにするには、視覚的なオプションを選択する必要があります。この場合、画像はアプリケーションの現在のディレクトリに保存され（Markdown文書内に相対パスが構築されます）、または好みのパスとフォルダ名を指定することができます。

以下のPythonコードは、操作を示しています：

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, MarkdownExportType
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    outPath = "c:\\documents"

    saveOptions = MarkdownSaveOptions()
    saveOptions.export_type = MarkdownExportType.VISUAL
    saveOptions.images_save_folder_name = "md-images"
    saveOptions.base_path = outPath

    pres.save(outPath + "\\pres.md", SaveFormat.MD, saveOptions)
```