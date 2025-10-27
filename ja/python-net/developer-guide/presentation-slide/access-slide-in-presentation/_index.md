---
title: Access Slides in Presentations with Python
linktitle: Access Slide
type: docs
weight: 20
url: /ja/python-net/developer-guide/presentation-slide/access-slide-in-presentation/
keywords:
- access slide
- slide index
- slide id
- slide position
- change position
- slide properties
- slide number
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to access and manage slides in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET. Boost productivity with code examples."
---

## **概要**

この記事では、Aspose.Slides for Python を使用して PowerPoint プレゼンテーション内の特定のスライドにアクセスする方法を説明します。プレゼンテーションを開き、インデックスまたは一意の ID でスライドを参照し、ファイル内でのナビゲーションに必要な基本的なスライド情報を取得する手順を示します。これらの手法を使用すれば、検査または処理したい正確なスライドを確実に見つけることができます。

## **インデックスでスライドにアクセスする**

プレゼンテーション内のスライドは、位置に基づいて 0 から始まるインデックスが付けられます。最初のスライドはインデックス 0、2 番目のスライドはインデックス 1 と続きます。

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラス（プレゼンテーション ファイルを表す）では、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) を通じて [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) オブジェクトにアクセスできます。

以下の Python コードは、インデックスでスライドにアクセスする方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation を作成します。
with slides.Presentation("sample.pptx") as presentation:
    # インデックスでスライドを取得します。
    slide = presentation.slides[0]
```

## **ID でスライドにアクセスする**

プレゼンテーション内の各スライドには、一意の ID が割り当てられています。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) メソッドを使用して、その ID のスライドを取得できます。

以下の Python コードは、有効なスライド ID を指定して [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) メソッドでスライドにアクセスする方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation を作成します。
with slides.Presentation("sample.pptx") as presentation:
    # スライド ID を取得します。
    id = presentation.slides[0].slide_id
    # ID でスライドにアクセスします。
    slide = presentation.get_slide_by_id(id)
```

## **スライドの位置を変更する**

Aspose.Slides を使用すると、スライドの位置を変更できます。たとえば、最初のスライドを 2 番目に移動させることが可能です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスで位置を変更したいスライドへの参照を取得します。  
3. [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) プロパティで新しい位置を設定します。  
4. 変更後のプレゼンテーションを保存します。

以下の Python コードは、位置 1 のスライドを位置 2 に移動します。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します。
with slides.Presentation("sample.pptx") as presentation:
    # 位置を変更するスライドを取得します。
    slide = presentation.slides[0]
    # スライドの新しい位置を設定します。
    slide.slide_number = 2
    # 変更後のプレゼンテーションを保存します。
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

最初のスライドが 2 番目になり、2 番目のスライドが最初になります。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号を設定する**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) プロパティを使用すると、プレゼンテーション内の最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライド番号を設定します。  
3. 変更後のプレゼンテーションを保存します。

以下の Python コードは、最初のスライド番号を 10 に設定する例です。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します。
with slides.Presentation("sample.pptx") as presentation:
    # スライド番号を設定します。
    presentation.first_slide_number = 10
    # 変更後のプレゼンテーションを保存します。
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

最初のスライドをスキップしたい場合は、2 番目のスライドから番号付けを開始し（最初のスライドの番号は非表示に）次のようにします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # プレゼンテーション内の最初のスライド番号を設定します。
    presentation.first_slide_number = 0

    # すべてのスライドに番号を表示します。
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # 最初のスライドの番号を非表示にします。
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # 変更後のプレゼンテーションを保存します。
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ユーザーが見るスライド番号はコレクションのゼロベース インデックスと一致しますか？**

スライドに表示される番号は任意の値（例: 10）から開始でき、インデックスと一致する必要はありません。この関係はプレゼンテーションの [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) 設定で制御されます。

**非表示スライドはインデックスに影響しますか？**

はい。非表示スライドはコレクション内に残り、インデックス計算に含まれます。「非表示」は表示状態を指すもので、コレクション内の位置には影響しません。

**他のスライドが追加または削除されたときにスライドのインデックスは変わりますか？**

はい。インデックスは常に現在のスライド順序を反映し、挿入、削除、移動操作が行われるたびに再計算されます。