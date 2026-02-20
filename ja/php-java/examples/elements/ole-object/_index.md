---
title: OLE オブジェクト
type: docs
weight: 210
url: /ja/php-java/examples/elements/ole-object/
keywords:
- OLE オブジェクト
- OLE オブジェクトを追加
- OLE オブジェクトにアクセス
- OLE オブジェクトを削除
- OLE オブジェクトを更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で OLE オブジェクトを操作します。埋め込みファイルの挿入や更新、アイコンやリンクの設定、コンテンツの抽出、PPT、PPTX、ODP の動作制御が可能です。"
---
**Aspose.Slides for PHP via Java** を使用して、ファイルを OLE オブジェクトとして埋め込み、そのデータを更新する方法をデモンストレーションします。

## **OLE オブジェクトを追加**

PDF ファイルをプレゼンテーションに埋め込みます。

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE オブジェクトにアクセス**

スライド上の最初の OLE オブジェクト フレームを取得します。

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初の OLE フレームにアクセスします。
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE オブジェクトを削除**

スライドから埋め込まれた OLE オブジェクトを削除します。

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプが OLE フレームであると想定しています。
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE オブジェクト データの更新**

既存の OLE オブジェクトに埋め込まれたデータを置き換えます。

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプが OLE フレームであると想定しています。
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```