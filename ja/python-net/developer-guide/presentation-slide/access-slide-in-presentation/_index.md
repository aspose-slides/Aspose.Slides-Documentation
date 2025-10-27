---
title: Python でプレゼンテーションのスライドにアクセスする
linktitle: スライドにアクセス
type: docs
weight: 20
url: /ja/python-net/access-slide-in-presentation/
keywords:
- スライドにアクセス
- スライドインデックス
- スライドID
- スライド位置
- 位置を変更
- スライドプロパティ
- スライド番号
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーション内のスライドにアクセスし管理する方法を学びます。コード例で生産性を向上させましょう。"
---

## **概要**

この記事では、Aspose.Slides for Python を使用して PowerPoint プレゼンテーション内の特定のスライドにアクセスする方法を説明します。プレゼンテーションのオープン方法、インデックスまたは一意の ID でスライドを参照する方法、ファイル内でのナビゲーションに必要な基本的なスライド情報の取得方法を示します。これらのテクニックを使えば、検査や処理したい正確なスライドを確実に見つけることができます。

## **インデックスでスライドにアクセスする**

プレゼンテーション内のスライドは 0 から始まる位置でインデックス付けされます。最初のスライドのインデックスは 0、2 番目のスライドは 1 というように順番に割り当てられます。

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラス（プレゼンテーション ファイルを表す）では、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) を通じて [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) オブジェクトにアクセスできます。

次の Python コードはインデックスでスライドにアクセスする方法を示しています。

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide by its index.
    slide = presentation.slides[0]
```

## **ID でスライドにアクセスする**

プレゼンテーション内の各スライドには一意の ID が割り当てられています。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) メソッドを使ってその ID を指定できます。

次の Python コードは有効なスライド ID を取得し、[get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) メソッドでスライドにアクセスする例です。

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide ID.
    id = presentation.slides[0].slide_id
    # Access the slide by its ID.
    slide = presentation.get_slide_by_id(id)
```

## **スライドの位置を変更する**

Aspose.Slides を使用すると、スライドの位置を変更できます。たとえば、最初のスライドを 2 番目にすることが可能です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. 位置を変更したいスライドをインデックスで取得します。  
1. [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) プロパティで新しい位置を設定します。  
1. 変更後のプレゼンテーションを保存します。

次の Python コードは位置 1 のスライドを位置 2 に移動します。

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get the slide whose position will be changed.
    slide = presentation.slides[0]
    # Set the new position for the slide.
    slide.slide_number = 2
    # Save the modified presentation.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

最初のスライドが 2 番目になり、2 番目のスライドが最初になります。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号を設定する**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) プロパティを使って、プレゼンテーションの最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. スライド番号を設定します。  
1. 変更後のプレゼンテーションを保存します。

次の Python コードは最初のスライド番号を 10 に設定する例です。

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Set the slide number.
    presentation.first_slide_number = 10
    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

最初のスライドをスキップしたい場合は、2 番目のスライドから番号付けを開始し（最初のスライドの番号は非表示に）次のように設定できます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Set the number for the first slide in the presentation.
    presentation.first_slide_number = 0

    # Show slide numbers for all slides.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Hide the slide number on the first slide.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ユーザーが画面で見るスライド番号は、コレクションのゼロベースインデックスと一致しますか？**

スライドに表示される番号は任意の値（例: 10）から開始でき、インデックスと一致する必要はありません。番号とインデックスの関係はプレゼンテーションの [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) 設定で制御されます。

**非表示スライドはインデックス付けに影響しますか？**

はい。非表示スライドはコレクションに残り、インデックス計算に含まれます。「非表示」は表示属性を指すもので、コレクション内での位置には影響しません。

**他のスライドが追加または削除されたときにスライドのインデックスは変わりますか？**

はい。インデックスは常に現在のスライド順序を反映し、挿入・削除・移動操作が行われると再計算されます。