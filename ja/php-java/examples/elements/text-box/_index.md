---
title: テキストボックス
type: docs
weight: 40
url: /ja/php-java/examples/elements/text-box/
keywords:
- テキストボックス
- テキストボックスを追加
- テキストボックスにアクセス
- テキストボックスを削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でテキストボックスを作成および書式設定します。フォント、配置、折り返し、自動調整、リンクを設定し、PowerPoint および OpenDocument 用のスライドを洗練させます。"
---
Aspose.Slides では、**テキスト ボックス**は `AutoShape` で表されます。ほぼすべてのシェイプにテキストを含めることができますが、一般的なテキスト ボックスは塗りつぶしや枠線がなく、テキストだけが表示されます。

このガイドでは、テキスト ボックスをプログラムで追加、参照、削除する方法について説明します。

## **テキスト ボックスを追加**

テキスト ボックスは、塗りつぶしや枠線がなく、書式設定されたテキストが含まれる `AutoShape` にすぎません。作成方法は次のとおりです：

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 長方形シェイプを作成します（デフォルトで塗りつぶしと枠線があり、テキストはありません）。
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // 塗りつぶしと枠線を削除して、通常のテキストボックスのように見せます。
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // テキストの書式設定を行います。
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // 実際のテキスト内容を設定します。
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **注:** 空でない `TextFrame` を含む任意の `AutoShape` はテキスト ボックスとして機能します。

## **コンテンツでテキスト ボックスにアクセス**

特定のキーワード（例: "Slide"）を含むすべてのテキスト ボックスを見つけるには、シェイプを反復処理し、テキストをチェックします：

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のテキストボックスにアクセスします。
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // 一致するテキストボックスで何らかの処理を行います。
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **コンテンツでテキスト ボックスを削除**

この例では、特定のキーワードを含む最初のスライド上のすべてのテキスト ボックスを検索して削除します：

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **ヒント:** 反復処理中に変更する際にコレクション変更エラーを回避するため、必ずシェイプ コレクションのコピーを作成してから変更してください。