---
title: マスタースライド
type: docs
weight: 30
url: /ja/java/examples/elements/master-slide/
keywords:
- コードサンプル
- マスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のマスタースライド例を探求し、PPT、PPTX、ODP でマスター、プレースホルダー、テーマを作成・編集・スタイル設定する方法を明確な Java コードで紹介します。"
---
マスタースライドは、PowerPoint のスライド継承階層の最上位レベルを構成します。**マスタースライド**は、背景やロゴ、テキスト書式設定などの共通デザイン要素を定義します。**レイアウトスライド**はマスタースライドから継承し、**標準スライド**はレイアウトスライドから継承します。

この記事では、Aspose.Slides for Java を使用してマスタースライドを作成、変更、管理する方法を示します。

## **マスタースライドの追加**

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

> 💡 **Note 1:** マスタースライドは、すべてのスライドに一貫したブランディングや共有デザイン要素を適用する手段を提供します。マスターに加えた変更は、依存するレイアウトスライドや標準スライドに自動的に反映されます。

> 💡 **Note 2:** マスタースライドに追加された図形や書式設定は、レイアウトスライドに継承され、さらにそれらのレイアウトを使用するすべての標準スライドにも継承されます。  
> 以下の画像は、マスタースライドに追加されたテキストボックスが最終スライドに自動的に表示される様子を示しています。

![Master Inheritance Example](master-slide-banner.png)

## **マスタースライドへのアクセス**

プレゼンテーションのマスターコレクションを使用してマスタースライドにアクセスできます。以下に、マスタースライドを取得して操作する方法を示します。

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

## **マスタースライドの削除**

マスタースライドは、インデックスまたは参照で削除できます。

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

## **未使用のマスタースライドの削除**

一部のプレゼンテーションには使用されていないマスタースライドが含まれています。これらのスライドを削除することで、ファイルサイズを削減できます。

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