---
title: マスタースライド
type: docs
weight: 30
url: /ja/python-net/examples/elements/master-slide/
keywords:
- マスタースライド
- マスタースライドの追加
- マスタースライドへのアクセス
- マスタースライドの削除
- 未使用のマスタースライド
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用した Python でマスタースライドを管理します。テーマ、背景、プレースホルダーの作成、編集、クローン、書式設定により、PowerPoint と OpenDocument のスライドを統一できます。"
---
マスタースライドは PowerPoint のスライド継承階層の最上位を構成します。**マスタースライド** は背景、ロゴ、テキスト書式設定などの共通デザイン要素を定義します。**レイアウトスライド** はマスタースライドから継承し、**標準スライド** はレイアウトスライドから継承します。

この記事では、Aspose.Slides for Python via .NET を使用してマスタースライドを作成、変更、および管理する方法を示します。

## **マスタースライドの追加**

この例では、デフォルトのマスタースライドをクローンして新しいマスタースライドを作成する方法を示します。

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # デフォルトのマスタースライドをクローンします。
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** マスタースライドは、すべてのスライドに対して一貫したブランディングや共有デザイン要素を適用する方法を提供します。マスタースライドに加えた変更は、依存するレイアウトスライドや標準スライドに自動的に反映されます。

> 💡 **Tip 2:** マスタースライドに追加された形状や書式設定は、レイアウトスライドに継承され、さらにそれらのレイアウトを使用するすべての標準スライドにも継承されます。  
> 以下の画像は、マスタースライドに追加されたテキストボックスが最終スライドに自動的に反映される様子を示しています。

![マスタ継承例](master-slide-banner.png)

## **マスタースライドへのアクセス**

`Presentation.masters` コレクションを使用してマスタースライドにアクセスできます。以下は、マスタースライドを取得して操作する方法です。

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # 最初のマスタースライドにアクセスします。
        first_master_slide = presentation.masters[0]
```

## **マスタースライドの削除**

マスタースライドはインデックスまたは参照で削除できます。

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # インデックスで削除します。
        presentation.masters.remove_at(0)

        # または参照で削除します。
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **未使用のマスタースライドの削除**

一部のプレゼンテーションには使用されていないマスタースライドが含まれています。これらのスライドを削除すると、ファイルサイズの削減に役立ちます。

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # 未使用のマスタースライドをすべて削除します（Preserve とマークされたものも含む）。
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** `remove_unused(True)` を使用して未使用のマスタースライドをクリーンアップし、プレゼンテーションのサイズを最小化します。