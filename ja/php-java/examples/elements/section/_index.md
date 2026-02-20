---
title: セクション
type: docs
weight: 90
url: /ja/php-java/examples/elements/section/
keywords:
- セクション
- スライド セクション
- セクションを追加
- セクションにアクセス
- セクションを削除
- セクションの名前を変更
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用した PHP でスライドセクションを管理します：作成、名前の変更、簡単な並び替え、セクション間のスライド移動、PPT、PPTX、ODP の表示制御が可能です。"
---
プレゼンテーションセクションの管理例 — 追加、アクセス、削除、名前変更を **Aspose.Slides for PHP via Java** を使用してプログラムで実行します。

## **セクションを追加**

特定のスライドから開始するセクションを作成します。

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // セクションの開始を示すスライドを指定します。
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **セクションにアクセス**

プレゼンテーションからセクション情報を読み取ります。

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // インデックスでセクションにアクセスします。
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **セクションを削除**

以前に追加したセクションを削除します。

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // セクションを削除します。
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **セクションの名前を変更**

既存のセクションの名前を変更します。

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```