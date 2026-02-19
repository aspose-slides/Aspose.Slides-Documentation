---
title: SmartArt
type: docs
weight: 140
url: /ja/java/examples/elements/smart-art/
keywords:
- コード例
- SmartArt
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java の SmartArt を操作します：Java を使用して PowerPoint および OpenDocument プレゼンテーション用の図表を作成、編集、変換、スタイル設定できます。"
---
この記事では、**Aspose.Slides for Java** を使用して SmartArt グラフィックの追加、アクセス、削除、およびレイアウト変更方法を示します。

## **SmartArtの追加**
組み込みレイアウトのいずれかを使用して SmartArt グラフィックを挿入します。

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArtのアクセス**
スライド上の最初の SmartArt オブジェクトを取得します。

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArtの削除**
スライドから SmartArt のシェイプを削除します。

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArtレイアウトの変更**
既存の SmartArt グラフィックのレイアウトタイプを更新します。

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```