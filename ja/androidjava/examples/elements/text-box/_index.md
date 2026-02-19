---
title: テキスト ボックス
type: docs
weight: 40
url: /ja/androidjava/examples/elements/text-box/
keywords:
- コード例
- テキストボックス
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でテキスト ボックスを操作します。PPT、PPTX、ODP プレゼンテーション用に Java を使用して、テキストの追加、書式設定、配置、折り返し、オートフィット、スタイル設定を行います。"
---
Aspose.Slides では、**テキスト ボックス**は `AutoShape` で表されます。ほぼすべてのシェイプはテキストを含めることができますが、典型的なテキスト ボックスは塗りつぶしや枠線がなく、テキストのみが表示されます。

このガイドでは、テキスト ボックスをプログラムで追加、アクセス、削除する方法について説明します。

## **テキスト ボックスの追加**

テキスト ボックスは、塗りつぶしや枠線がなく、書式設定されたテキストを含む `AutoShape` にすぎません。作成方法は次のとおりです：

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 長方形シェイプを作成します（デフォルトでは塗りつぶしと枠線があり、テキストはありません）。
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // 塗りつぶしと枠線を削除して、典型的なテキストボックスのように見せます。
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // テキストの書式設定を行います。
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // 実際のテキストコンテンツを設定します。
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注:** `TextFrame` が空でない `AutoShape` は、テキスト ボックスとして機能します。

## **コンテンツでテキスト ボックスにアクセス**

特定のキーワード（例: "Slide"）を含むすべてのテキスト ボックスを見つけるには、シェイプを列挙し、そのテキストを確認します：

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
                    // 条件に合致するテキストボックスで何らかの処理を行います。
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **コンテンツでテキスト ボックスを削除**

この例では、特定のキーワードを含む最初のスライド上のすべてのテキスト ボックスを検索し、削除します：

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

> 💡 **ヒント:** 反復処理中に変更する前に、シェイプ コレクションのコピーを必ず作成して、コレクション変更エラーを回避してください。