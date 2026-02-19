---
title: テキスト ボックス
type: docs
weight: 40
url: /ja/java/examples/elements/text-box/
keywords:
- コード例
- テキスト ボックス
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Javaでテキスト ボックスを操作します：Javaを使用してPPT、PPTX、ODPプレゼンテーションのテキストを追加、書式設定、配置、折り返し、自動調整、スタイル設定します。"
---
Aspose.Slides では、**テキスト ボックス**は `AutoShape` で表されます。ほぼすべてのシェイプはテキストを含めることができますが、標準的なテキスト ボックスは塗りつぶしも境界線もなく、テキストだけが表示されます。

このガイドでは、テキスト ボックスをプログラムで追加、アクセス、削除する方法を説明します。

## **テキスト ボックスの追加**

テキスト ボックスは、塗りつぶしや境界線がなく、書式設定されたテキストを持つ `AutoShape` にすぎません。作成方法は次のとおりです:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 矩形シェイプを作成します（デフォルトでは塗りつぶしと枠線があり、テキストはありません）。
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // 塗りつぶしと枠線を削除して、典型的なテキスト ボックスのように見せます。
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // テキストの書式設定を行います。
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // 実際のテキスト内容を割り当てます。
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意:** 空でない `TextFrame` を含む `AutoShape` はすべてテキスト ボックスとして機能します。

## **コンテンツでテキスト ボックスにアクセス**

特定のキーワード（例: "Slide"）を含むすべてのテキスト ボックスを見つけるには、シェイプを反復処理し、テキストを確認します:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // 編集可能なテキストを含めることができるのは AutoShape のみです。
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // 該当するテキスト ボックスで何か処理を行います。
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **コンテンツでテキスト ボックスを削除**

この例では、特定のキーワードを含む最初のスライド上のすべてのテキスト ボックスを検索して削除します:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ヒント:** 反復処理中に変更する前に、常にシェイプ コレクションのコピーを作成して、コレクションの変更エラーを防ぎます。