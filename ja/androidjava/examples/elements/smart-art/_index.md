---
title: SmartArt
type: docs
weight: 140
url: /ja/androidjava/examples/elements/smart-art/
keywords:
- コード例
- SmartArt
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android で SmartArt を操作します。PowerPoint および OpenDocument プレゼンテーション用に、Java で図表の作成、編集、変換、スタイル設定を行うことができます。"
---
この記事では、**Aspose.Slides for Android via Java** を使用して SmartArt グラフィックの追加、アクセス、削除、およびレイアウトの変更方法を示します。

## **SmartArt の追加**

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

## **SmartArt の取得**

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

## **SmartArt の削除**

スライドから SmartArt シェイプを削除します。

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

## **SmartArt のレイアウトの変更**

既存の SmartArt グラフィックのレイアウト タイプを更新します。

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