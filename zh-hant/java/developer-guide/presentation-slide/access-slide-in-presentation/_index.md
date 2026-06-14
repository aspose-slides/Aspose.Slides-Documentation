---
title: 在 Java 中存取簡報投影片
linktitle: 存取投影片
type: docs
weight: 20
url: /zh-hant/java/access-slide-in-presentation/
keywords:
- 存取投影片
- 投影片索引
- 投影片 ID
- 投影片位置
- 變更位置
- 投影片屬性
- 投影片編號
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 存取與管理 PowerPoint 與 OpenDocument 簡報中的投影片。透過程式碼範例提升生產力。"
---
## **概述**

本文說明如何使用 Aspose.Slides 來存取和管理簡報中的投影片。它展示了如何從投影片集合中依照零基索引取得投影片，以及如何使用 `getSlideById` 方法依唯一 ID 存取投影片。

您也將學習如何使用 `setSlideNumber` 方法變更投影片的位置，並使用 `setFirstSlideNumber` 方法為簡報定義起始投影片編號。範例說明了載入簡報、取得投影片參考、更新投影片順序或編號，並儲存修改後的簡報。

## **依索引存取投影片**

簡報中的所有投影片皆依投影片位置以數字排列，起始索引為 0。第一張投影片可透過索引 0 存取；第二張投影片可透過索引 1 存取；依此類推。

`Presentation` 類別代表簡報檔案，將所有投影片以 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/)（[ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 物件的集合）公開。以下 Java 程式碼示範如何依索引存取投影片：

```java
// 實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("demo.pptx");
try {
    // 使用投影片索引存取投影片
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **依 ID 存取投影片**

簡報中的每一張投影片都有唯一的 ID。您可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別公開的 [getSlideById](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSlideById-long-) 方法來定位該 ID。以下 Java 程式碼示範如何提供有效的投影片 ID，並透過 [getSlideById](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getSlideById-long-) 方法存取該投影片：

```java
// 實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("demo.pptx");
try {
    // 取得投影片 ID
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // 透過 ID 存取投影片
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **變更投影片位置**

Aspose.Slides 允許您變更投影片的位置。例如，您可以指定將第一張投影片變為第二張投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。  
1. 透過索引取得欲變更位置之投影片的參考  
1. 使用 [setSlideNumber](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#setSlideNumber-int-) 屬性設定投影片的新位置。  
1. 儲存已修改的簡報。

以下 Java 程式碼示範將位置 1 的投影片移至位置 2 的操作：

```java
// 實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 取得將要變更位置的投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 設定投影片的新位置
    sld.setSlideNumber(2);
    
    // 儲存已修改的簡報
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

第一張投影片變成第二張；第二張投影片變成第一張。變更投影片位置時，其他投影片會自動調整。

## **設定投影片編號**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別公開的 [setFirstSlideNumber](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 屬性，您可以為簡報的第一張投影片指定新的編號。此操作會重新計算其他投影片的編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。  
1. 取得投影片編號。  
1. 設定投影片編號。  
1. 儲存已修改的簡報。

以下 Java 程式碼示範將第一張投影片的編號設定為 10 的操作：

```java
// 實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // 取得投影片編號
    int firstSlideNumber = pres.getFirstSlideNumber();

    // 設定投影片編號
    pres.setFirstSlideNumber(10);
	
    // 儲存已修改的簡報
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

如果您想略過第一張投影片，也可以從第二張投影片開始編號（並隱藏第一張投影片的編號），方式如下：

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // 設定第一張簡報投影片的編號
    presentation.setFirstSlideNumber(0);

    // 顯示所有投影片的投影片編號
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // 隱藏第一張投影片的投影片編號
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // 儲存已修改的簡報
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **常見問題**

**使用者看到的投影片編號是否與集合的零基索引相同？**

投影片上顯示的編號可以從任意值（例如 10）開始，並不必須與索引相同；此關係由簡報的 [first slide number](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 設定控制。

**隱藏投影片會影響索引嗎？**

會。隱藏的投影片仍保留在集合中，且會被計入索引；「隱藏」指的是顯示與否，並不影響其在集合中的位置。

**當其他投影片被加入或移除時，投影片的索引會改變嗎？**

會。索引始終反映投影片的當前順序，並於插入、刪除或移動操作時重新計算。