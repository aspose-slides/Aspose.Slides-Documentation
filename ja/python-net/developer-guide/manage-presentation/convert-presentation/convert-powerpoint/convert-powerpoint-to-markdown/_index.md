---
title: Python で PowerPoint プレゼンテーションを Markdown に変換する
linktitle: PowerPoint から Markdown
type: docs
weight: 140
url: /ja/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を Markdown に変換
- OpenDocument を Markdown に変換
- プレゼンテーションを Markdown に変換
- スライドを Markdown に変換
- PPT を Markdown に変換
- PPTX を Markdown に変換
- ODP を Markdown に変換
- PowerPoint を MD に変換
- OpenDocument を MD に変換
- プレゼンテーションを MD に変換
- スライドを MD に変換
- PPT を MD に変換
- PPTX を MD に変換
- ODP を MD に変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- Markdown
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のスライド（PPT、PPTX、ODP）をクリーンな Markdown に変換し、ドキュメント作成を自動化し、書式を維持する方法を学びましょう。"
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

## よくある質問（F.A.Q.）

### **PythonでPowerPointをMarkdown形式に変換できますか？**

はい、[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/python-net/)を使用することで、PythonコードからPowerPoint（PPT、PPTX、ODP）をMarkdown形式に変換できます。

### **変換結果に画像を含めるにはどうすればよいですか？**

デフォルトでは画像は含まれません。画像付きでMarkdownに変換するには、`MarkdownSaveOptions.export_type`に`VISUAL`を指定し、画像保存先の`base_path`とフォルダ名を設定してください。

### **どのMarkdownフレーバーがサポートされていますか？**

Aspose.Slidesは、GitHub、CommonMark、Trello、XWiki、GitLabなど、合計23種類のMarkdownフレーバーに対応しています。詳細は[Flavor列挙体](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/)を参照してください。

### **Markdownへの変換時にスライド番号や非表示スライドを含められますか？**

はい、`MarkdownSaveOptions`を使用することで、スライド番号の表示や非表示スライドの出力を制御できます。

### **変換対象のスライドを選択することはできますか？**

はい、`save`メソッドの第2引数にスライド番号のリストを渡すことで、特定のスライドのみをMarkdownに変換できます。

### **Markdownファイルと一緒に保存される画像のパスはどのように指定できますか？**

`images_save_folder_name`と`base_path`プロパティで、画像の保存フォルダとMarkdown内での画像リンクを制御できます。

### **変換後のMarkdownファイルはどこに保存されますか？**

変換先のファイルパスを`save`メソッドで指定できます。ファイル名とパスを明示的に設定することで、任意の場所に保存可能です。

### **Markdown変換はどのAspose.Slidesバージョンで利用できますか？**

PowerPointからMarkdownへの変換は、[Aspose.Slides 23.7](https://docs.aspose.com/slides/python-net/aspose-slides-for-python-net-23-7-release-notes/)からサポートされています。
