---
title: セクション
type: docs
weight: 90
url: /ja/java/examples/elements/section/
keywords:
- コード例
- セクション
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でスライドのセクションを管理します。PPT、PPTX、ODP の Java サンプルを使用して、セクションの作成、名前変更、並び替え、グループ化を行います。"
---
**Aspose.Slides for Java** を使用して、プレゼンテーションのセクションをプログラムで管理する例（追加、アクセス、削除、名前の変更）。

## **セクションの追加**

特定のスライドから開始するセクションを作成します。

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // セクションの開始を示すスライドを指定します。
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **セクションへのアクセス**

プレゼンテーションからセクション情報を取得します。

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // インデックスでセクションにアクセスします。
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **セクションの削除**

以前に追加したセクションを削除します。

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // 最初のセクションを削除します。
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **セクションの名前変更**

既存のセクションの名前を変更します。

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```