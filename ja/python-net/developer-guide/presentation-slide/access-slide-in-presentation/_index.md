---
title: Pythonでプレゼンテーションのスライドにアクセス
linktitle: スライドにアクセス
type: docs
weight: 20
url: /ja/python-net/access-slide-in-presentation/
keywords:
- スライドにアクセス
- スライドインデックス
- スライドID
- スライド位置
- 位置の変更
- スライドプロパティ
- スライド番号
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NET を介した Python 用 Aspose.Slides で、PowerPoint および OpenDocument プレゼンテーションのスライドにアクセスし管理する方法を学びます。コード例で生産性を向上させましょう。"
---

## **概要**

この記事では、Aspose.Slides for Python を使用して PowerPoint プレゼンテーション内の特定のスライドにアクセスする方法を説明します。プレゼンテーションの開き方、インデックスまたは一意の ID でスライドを参照する方法、ファイル内のナビゲーションに必要な基本的なスライド情報の取得方法を示します。これらの手法を使用すれば、検査または処理したい正確なスライドを確実に見つけることができます。

## **インデックスでスライドにアクセスする**

プレゼンテーション内のスライドは位置でインデックス付けされ、0 から始まります。最初のスライドのインデックスは 0、2 番目のスライドはインデックス 1 というように続きます。

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラス（プレゼンテーション ファイルを表す）は、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) を介して [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) オブジェクトのコレクションとしてスライドを公開します。

以下の Python コードは、インデックスでスライドにアクセスする方法を示します:
```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation を作成します。
with slides.Presentation("sample.pptx") as presentation:
    # インデックスでスライドを取得します。
    slide = presentation.slides[0]
```


## **ID でスライドにアクセスする**

プレゼンテーション内の各スライドには一意の ID が割り当てられています。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) メソッドを使用してその ID を対象にできます。

以下の Python コードは、有効なスライド ID を指定し、[get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) メソッドでそのスライドにアクセスする方法を示します:
```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation を作成します。
with slides.Presentation("sample.pptx") as presentation:
    # スライド ID を取得します。
    id = presentation.slides[0].slide_id
    # ID でスライドにアクセスします。
    slide = presentation.get_slide_by_id(id)
```


## **スライドの位置を変更する**

Aspose.Slides を使用すると、スライドの位置を変更できます。例えば、最初のスライドを 2 番目にすることができます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで位置を変更したいスライドへの参照を取得します。
1. [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) プロパティを使用してスライドの新しい位置を設定します。
1. 変更されたプレゼンテーションを保存します。

以下の Python コードは、位置 1 のスライドを位置 2 に移動します:
```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します。
with slides.Presentation("sample.pptx") as presentation:
    # 位置を変更するスライドを取得します。
    slide = presentation.slides[0]
    # スライドの新しい位置を設定します。
    slide.slide_number = 2
    # 変更されたプレゼンテーションを保存します。
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```


最初のスライドが 2 番目になり、2 番目のスライドが 1 番目になります。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号の設定**

[first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) プロパティ（[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが公開）を使用すると、プレゼンテーションの最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライド番号を設定します。
1. 変更されたプレゼンテーションを保存します。

以下の Python コードは、最初のスライド番号を 10 に設定する操作を示します:
```python
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します。
with slides.Presentation("sample.pptx") as presentation:
    # スライド番号を設定します。
    presentation.first_slide_number = 10
    # 変更されたプレゼンテーションを保存します。
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```


最初のスライドをスキップしたい場合は、次のように 2 番目のスライドから番号付けを開始し（最初のスライドの番号は非表示に）ることができます:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # プレゼンテーションの最初のスライドの番号を設定します。
    presentation.first_slide_number = 0

    # すべてのスライドにスライド番号を表示します。
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # 最初のスライドのスライド番号を非表示にします。
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # 変更されたプレゼンテーションを保存します。
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**ユーザーが見るスライド番号は、コレクションの 0 基準インデックスと一致しますか？**

スライドに表示される番号は任意の値（例: 10）から開始でき、インデックスと一致する必要はありません。この関係はプレゼンテーションの [first slide number] 設定によって制御されます。

**非表示スライドはインデックスに影響しますか？**

はい。非表示スライドはコレクション内に残り、インデックス計算に含まれます。「非表示」は表示上の状態を指すだけで、コレクション内の位置には影響しません。

**他のスライドが追加または削除されたとき、スライドのインデックスは変わりますか？**

はい。インデックスは常に現在のスライド順序を反映し、挿入、削除、移動が行われるたびに再計算されます。