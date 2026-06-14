---
title: 從簡報中將整個投影片背景提取為影像
linktitle: 整個投影片背景
type: docs
weight: 95
url: /zh-hant/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 投影片背景
- 最終背景
- 提取背景
- 整體背景
- 背景轉為影像
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java，從 PowerPoint 與 OpenDocument 簡報中提取完整投影片背景為影像，簡化視覺工作流程。"
---
## **概觀**

在 PowerPoint 簡報中，投影片的背景可能由多個元素組成，包括投影片背景圖像、簡報主題、配色方案，以及放置在母片或版面配置投影片上的物件。

本文章說明如何使用 Aspose.Slides for .NET 將整個投影片背景提取為影像。由於此任務沒有單一方法，需將選取的投影片克隆到暫存簡報中，刪除投影片形狀，然後將產生的投影片背景轉換為影像。

## **取得整個投影片背景**

Aspose.Slides for Java 並未提供直接將整個簡報投影片背景提取為影像的簡易方法，但您可以依照下列步驟完成此操作：
1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別載入簡報。
1. 從簡報取得投影片大小。
1. 選取投影片。
1. 建立暫存簡報。
1. 在暫存簡報中設定相同的投影片大小。
1. 將選取的投影片克隆到暫存簡報中。
1. 刪除克隆投影片上的形狀。
1. 將克隆投影片轉換為影像。

以下程式碼範例將整個簡報投影片背景提取為影像。
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **常見問題**

**Will complex gradients, textures, or picture fills from a master slide be preserved in the resulting background image?**

是。Aspose.Slides 會呈現投影片、版面配置或母片上定義的漸層、圖片和紋理填滿。如果需要將外觀與繼承的母片分離，請在匯出前於目前投影片[設定自己的背景](/slides/zh-hant/java/presentation-background/)。

**Can I add a watermark to the resulting background image before saving it?**

是。您可以在工作用的[投影片副本](/slides/zh-hant/java/clone-slides/)上加入[浮水印](/slides/zh-hant/java/watermark/)形狀或影像（放在其他內容之後），然後匯出。這樣即可產生已內嵌浮水印的背景影像。

**Can I get the background for a specific layout or master without tying it to an existing slide?**

是。取得目標母片或版面配置，將其套用到具備所需大小的[暫存投影片](/slides/zh-hant/java/clone-slides/)，然後匯出該投影片即可取得該版面配置或母片所產生的背景。

**Are there licensing limitations that affect image export?**

只要具備[有效授權](/slides/zh-hant/java/licensing/)，即可完整使用渲染功能。評估模式下，輸出可能會有如浮水印等限制。在執行批次匯出前，請於每個程序中啟用授權一次。