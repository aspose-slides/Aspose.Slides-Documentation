---
title: Pythonでプレゼンテーションにスライドを追加する
linktitle: スライドを追加
type: docs
weight: 10
url: /ja/python-java/add-slide-to-presentation/
keywords:
- スライドを追加
- スライドを作成
- 空のスライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションにスライドを簡単に追加できます。数秒でシームレスかつ効率的にスライドを挿入します。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーションにプログラムでスライドを追加できます。プレゼンテーションはマスター/レイアウト スライドと通常のスライドで構成され、通常のスライドはゼロベースのインデックスで配置されます。各スライドは一意の ID を持ち、スライドが含まれていないプレゼンテーション ファイルはサポートされません。

本記事では、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトの作成方法、スライドコレクションへのアクセス、空のスライドの追加、新しく追加したスライドの操作、更新したプレゼンテーションの保存方法について説明します。また、特定の位置へのスライド挿入、レイアウトの使用、 新規作成されたプレゼンテーションに既に存在する空白スライドの理解など、関連するポイントも取り上げます。

## **プレゼンテーションにスライドを追加する**

スライドをプレゼンテーション ファイルに追加する方法を説明する前に、スライドに関するいくつかの事実を確認しましょう。各 PowerPoint プレゼンテーション ファイルには **マスター/レイアウト** スライドと **通常** スライドが含まれます。プレゼンテーション ファイルは少なくとも 1 枚のスライドを含む必要があります。スライドがないプレゼンテーション ファイルは Aspose.Slides for Python via Java ではサポートされません。各スライドは一意の ID を持ち、すべての通常スライドはゼロベースのインデックスで指定された順序で配置されます。

Aspose.Slides for Python via Java は、開発者がプレゼンテーションに空のスライドを追加できるようにします。空のスライドをプレゼンテーションに追加するには、次の手順に従います。

- [プレゼンテーション] クラスのインスタンスを作成します。
- [プレゼンテーション] オブジェクトが提供する [getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) メソッドを使用して、[SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトへの参照を取得します。
- [SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) オブジェクトが提供する [addEmptySlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addEmptySlide) メソッドを呼び出し、プレゼンテーションのスライドコレクションの末尾に空のスライドを追加します。
- 新しく追加した空のスライドで必要な処理を行います。
- 最後に、[プレゼンテーション] オブジェクトを使用してプレゼンテーション ファイルを書き出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
presentation = Presentation()
try:
    # スライドコレクションを取得します。
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # スライドコレクションに空のスライドを追加します。
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # 新しく追加されたスライドで何らかの処理を行います。

    # PPTX ファイルをディスクに保存します。
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**特定の位置に新しいスライドを挿入できますか？（末尾だけでなく）**

はい。ライブラリはスライドコレクションと [insert](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertClone) 操作をサポートしているため、末尾だけでなく必要なインデックスにスライドを追加できます。

**レイアウトに基づくスライドを追加した場合、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択したレイアウトとそれに関連付けられたマスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションにはどのスライドが存在しますか？**

新しく作成されたプレゼンテーションには、インデックス 0 の空白スライドが既に 1 枚含まれています。挿入インデックスを計算する際に考慮が必要です。

**マスターに多数のレイアウトがある場合、どのレイアウトを新しいスライドに選べばよいですか？**

一般的には、必要な構造（[LayoutSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/) が一致するもの）を持つレイアウト（[タイトルとコンテンツ、2 つのコンテンツ、等](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidelayouttype/)）を選択します。そのようなレイアウトが存在しない場合は、[add it to the master](/slides/ja/python-java/slide-layout/) してから使用できます。