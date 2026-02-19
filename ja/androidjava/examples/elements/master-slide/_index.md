---
title: マスタースライド
type: docs
weight: 30
url: /ja/androidjava/examples/elements/master-slide/
keywords:
- コード例
- マスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android のマスタースライド例を探索し、PPT、PPTX、ODP でマスター、プレースホルダー、テーマを作成、編集、スタイル設定する方法を明確な Java コードで示します。"
---
マスタースライドは PowerPoint のスライド継承階層の最上位を構成します。**マスタースライド**は背景、ロゴ、テキストの書式設定などの共通デザイン要素を定義します。**レイアウトスライド**はマスタースライドから継承し、**ノーマルスライド**はレイアウトスライドから継承します。

この記事では、Aspose.Slides for Android（Java）を使用してマスタースライドの作成、変更、管理方法を示します。

## **マスタースライドを追加**

この例では、デフォルトのマスタースライドをクローンして新しいマスタースライドを作成する方法を示します。その後、レイアウト継承を通じて全スライドに会社名バナーを追加します。

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // デフォルトのマスタースライドをクローンします。
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // マスタースライドの上部に会社名バナーを追加します。
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // 新しいマスタースライドをレイアウトスライドに割り当てます。
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // レイアウトスライドをプレゼンテーションの最初のスライドに割り当てます。
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注 1:** マスタースライドは、すべてのスライドに一貫したブランドや共有デザイン要素を適用する手段を提供します。マスターに加えた変更は、依存するレイアウトスライドおよびノーマルスライドに自動的に反映されます。

> 💡 **注 2:** マスタースライドに追加された図形や書式設定は、レイアウトスライドに継承され、さらにそれらのレイアウトを使用するすべてのノーマルスライドにも継承されます。  
> 以下の画像は、マスタースライドに追加されたテキストボックスが最終スライドに自動的に描画される様子を示しています。

![マスタ継承例](master-slide-banner.png)

## **マスタースライドにアクセス**

プレゼンテーションのマスターコレクションを使用してマスタースライドにアクセスできます。以下はマスタースライドを取得して操作する方法です。

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // 背景の種類を変更します。
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **マスタースライドを削除**

マスタースライドはインデックスまたは参照で削除できます。

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // インデックスでマスタースライドを削除します。
        presentation.getMasters().removeAt(0);

        // 参照でマスタースライドを削除します。
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **未使用のマスタースライドを削除**

一部のプレゼンテーションには使用されていないマスタースライドが含まれています。これらのスライドを削除すると、ファイルサイズの削減に役立ちます。

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // 未使用のマスタースライドをすべて削除します（Preserve とマークされたものも含めて）。
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```