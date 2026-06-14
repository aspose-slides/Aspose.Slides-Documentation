---
title: 母片
type: docs
weight: 30
url: /zh-hant/androidjava/examples/elements/master-slide/
keywords:
- 程式碼範例
- 母片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Android 的母片範例：使用清晰的 Java 程式碼建立、編輯與樣式化母片、佔位符與主題，支援 PPT、PPTX 與 ODP。"
---
母片構成 PowerPoint 中投影片繼承階層的最高層級。**母片** 定義共用的設計元素，例如背景、標誌與文字格式。**版面投影片** 繼承自母片，而 **普通投影片** 繼承自版面投影片。

本文示範如何使用 Aspose.Slides for Android（透過 Java）來建立、修改與管理母片。

## **新增母片**

此範例示範如何透過複製預設母片來建立新的母片，並藉由版面繼承將公司名稱橫幅新增至所有投影片。

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // 複製預設的母片。
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // 在母片的頂部加入公司名稱橫幅。
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // 將新的母片指定給版面投影片。
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // 將版面投影片指定給簡報中的第一張投影片。
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **註記 1：** 母片提供了一種在所有投影片上套用一致品牌或共用設計元素的方式。對母片所做的任何變更都會自動反映在相依的版面投影片和普通投影片上。

> 💡 **註記 2：** 任何新增至母片的圖形或格式都會被版面投影片繼承，進而被使用該版面的所有普通投影片繼承。以下圖示說明了在母片上新增的文字方塊如何自動顯示在最終投影片上。

![母片繼承範例](master-slide-banner.png)

## **存取母片**

您可以透過簡報的母片集合來存取母片。以下說明如何取得並使用它們：

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // 變更背景類型。
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **移除母片**

母片可以依索引或參考方式移除。

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // 依索引移除母片。
        presentation.getMasters().removeAt(0);

        // 依參考移除母片。
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **移除未使用的母片**

某些簡報可能包含未使用的母片。移除這些母片可協助減少檔案大小。

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // 移除所有未使用的母片（即使標記為 Preserve 的也會移除）。
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```