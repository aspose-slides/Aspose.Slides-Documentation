---
title: PythonでPPTXをPPTに変換
linktitle: PPTXからPPTへ
type: docs
weight: 21
url: /ja/python-java/convert-pptx-to-ppt/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTXを変換
- PPTXからPPTへ
- PPTXをPPTとして保存
- PPTXをPPTにエクスポート
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python 用 Aspose.Slides for Java を使用して、PPTX をレガシー PPT 形式に変換します。コード例と互換性や保護されたファイルに関する注意点を含みます。"
---
## **概要**

Aspose.Slides for Python via Java を使用すると、Microsoft PowerPoint をインストールせずに、PPTX プレゼンテーションを PowerPoint 97–2003 で使用される従来の PPT 形式に変換できます。以下のように PPTX ファイルを読み込み、PPT 出力形式で保存します。

## **PPTX を PPT に変換**

ソース ファイルは [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスでロードし、出力パスと [SaveFormat.Ppt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Ppt) を指定して [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を呼び出します。

以下の例は、必要に応じて Java 仮想マシンを起動し、デフォルト オプションで `template.pptx` を `output.ppt` に変換します。パスはご自身のファイル名に置き換えてください。`finally` ブロックは、保存に失敗した場合でもプレゼンテーションのリソースを解放します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# PPTX プレゼンテーションをロードします。
presentation = Presentation("template.pptx")
try:
    # プレゼンテーションを PPT 形式で保存します。
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

[SaveFormat.Ppt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Ppt) 引数は出力形式を選択します。ファイル拡張子を変更するだけではプレゼンテーションは変換されません。新しい機能に PPT で同等のものがない場合に備えて、元の PPTX ファイルを残しておいてください。

## **PPTX を他の形式に変換**

Aspose.Slides は他の出力形式もサポートしています。形式固有のオプションやサンプルについては、該当する記事をご覧ください。

- [Python で PowerPoint を PDF に変換](/slides/ja/python-java/convert-powerpoint-to-pdf/)
- [Python で PowerPoint を XPS に変換](/slides/ja/python-java/convert-powerpoint-to-xps/)
- [Python で PowerPoint を HTML に変換](/slides/ja/python-java/convert-powerpoint-to-html/)
- [Python でプレゼンテーションを ODP として保存](/slides/ja/python-java/save-presentation/)
- [Python で PowerPoint を PNG に変換](/slides/ja/python-java/convert-powerpoint-to-png/)

## **FAQ**

**すべての PPTX のエフェクトや機能は PPT への変換後も保持されますか？**

必ずしもそうではありません。従来の PPT 形式は PPTX で利用できるすべての機能をサポートしていません。いくつかのエフェクト、オブジェクト、動作は簡略化されたり、表示が変わったりすることがあります。特に新しい PowerPoint 機能が含まれている場合は、目的のビューアで変換後のプレゼンテーションを確認してください。

**特定のスライドだけを PPT に変換できますか？**

PPT に保存するとプレゼンテーション全体が書き込まれます。特定のスライドだけを変換したい場合は、新しいプレゼンテーションを作成し、最初の空スライドを削除して、必要なスライドをクローンしてから PPT として保存します。[Clone Slides in Python](/slides/ja/python-java/clone-slides/) を参照してください。

**パスワードで保護された PPTX ファイルを変換できますか？**

はい、ソース プレゼンテーションをロードする際に正しいパスワードを指定すれば変換できます。出力ファイルに対しても保護を設定できます。[Password-Protected Presentations](/slides/ja/python-java/password-protected-presentation/)。