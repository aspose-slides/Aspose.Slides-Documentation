---
title: Vbaマクロ
type: docs
weight: 150
url: /ja/php-java/examples/elements/vba-macro/
keywords:
- VBA マクロ
- VBA マクロの追加
- VBA マクロへのアクセス
- VBA マクロの削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で VBA マクロを操作します。プロジェクトやモジュールの追加・編集、マクロの署名または削除、そしてプレゼンテーションを PPT、PPTX、ODP 形式で保存できます。"
---
**Aspose.Slides for PHP via Java** を使用して VBA マクロを追加、アクセス、削除する方法を示します。

## **VBA マクロの追加**

VBA プロジェクトとシンプルなマクロ モジュールを含むプレゼンテーションを作成します。

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **VBA マクロへのアクセス**

VBA プロジェクトから最初のモジュールを取得します。

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **VBA マクロの削除**

VBA プロジェクトからモジュールを削除します。

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // VBA プロジェクトに少なくとも 1 つのモジュールがあると仮定しています。
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```