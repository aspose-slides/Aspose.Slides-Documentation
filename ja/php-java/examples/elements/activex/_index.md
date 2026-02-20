---
title: ActiveX
type: docs
weight: 200
url: /ja/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の追加
- ActiveX へのアクセス
- ActiveX の削除
- ActiveX プロパティ
- コード例
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用した PHP での ActiveX コントロールの検索、編集、削除方法と、PowerPoint プレゼンテーションのプロパティ更新について学びます。"
---
プレゼンテーションで **Aspose.Slides for PHP via Java** を使用して ActiveX コントロールを追加、アクセス、削除、設定する方法を示します。

## **ActiveX コントロールの追加**

新しい ActiveX コントロールを挿入します。

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 新しい ActiveX コントロールを追加します。
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // プレゼンテーションを破棄します。
        $presentation->dispose();
    }
}
```

## **ActiveX コントロールへのアクセス**

スライド上の最初の ActiveX コントロールから情報を読み取ります。

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 最初の ActiveX コントロールにアクセスします。
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // プレゼンテーションを破棄します。
        $presentation->dispose();
    }
}
```

## **ActiveX コントロールの削除**

スライドから既存の ActiveX コントロールを削除します。

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // 最初の ActiveX コントロールを削除します。
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // プレゼンテーションを破棄します。
        $presentation->dispose();
    }
}
```

## **ActiveX プロパティの設定**

複数の ActiveX プロパティを設定します。

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 最初のコントロールが追加したものと仮定します。
        $control = $slide->getControls()->get_Item(0);

        // プロパティを設定します。
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // プレゼンテーションを破棄します。
        $presentation->dispose();
    }
}
```