---
title: マスタースライド
type: docs
weight: 30
url: /ja/php-java/examples/elements/master-slide/
keywords:
- マスタースライド
- マスタースライドの追加
- マスタースライドへのアクセス
- マスタースライドの削除
- 未使用マスタースライド
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でマスタースライドを管理します：作成、編集、クローン、テーマ、背景、プレースホルダーの書式設定を行い、PowerPoint と OpenDocument のスライドを統一します。"
---
マスタースライドは PowerPoint のスライド継承階層の最上位を構成します。**マスタースライド** は背景、ロゴ、テキスト書式設定などの共通デザイン要素を定義します。**レイアウトスライド** はマスタースライドから継承し、**標準スライド** はレイアウトスライドから継承します。

この記事では、Aspose.Slides for PHP via Java を使用してマスタースライドを作成、変更、管理する方法を示します。

## **マスタースライドの追加**

この例では、デフォルトのマスタースライドをクローンして新しいマスタースライドを作成する方法を示します。

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // デフォルトのマスタースライドをクローンします。
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** マスタースライドは、すべてのスライドに対して一貫したブランディングや共有デザイン要素を適用する手段を提供します。マスターに加えた変更は、依存するレイアウトスライドと標準スライドに自動的に反映されます。

> 💡 **Tip 2:** マスタースライドに追加された形状や書式設定はレイアウトスライドに継承され、さらにそのレイアウトを使用するすべての標準スライドにも継承されます。  
> 下の画像は、マスタースライドに追加されたテキストボックスが最終スライドに自動的に描画される様子を示しています。

![Master Inheritance Example](master-slide-banner.png)

## **マスタースライドへアクセス**

`Presentation::getMasters` メソッドを使用してマスタースライドにアクセスできます。以下はマスタースライドを取得して操作する方法です。

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 最初のマスタースライドにアクセスします。
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **マスタースライドの削除**

マスタースライドはインデックスまたは参照によって削除できます。

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // インデックスで削除します。
        $presentation->getMasters()->removeAt(0);

        // または参照で削除します。
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **未使用マスタースライドの削除**

一部のプレゼンテーションには使用されていないマスタースライドが含まれています。これらのスライドを削除すると、ファイルサイズの削減に役立ちます。

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 未使用のマスタースライドをすべて削除します（「Preserve」マークされたものも含む）。
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** `removeUnused(true)` を使用して未使用のマスタースライドをクリーンアップし、プレゼンテーションのサイズを最小化します。