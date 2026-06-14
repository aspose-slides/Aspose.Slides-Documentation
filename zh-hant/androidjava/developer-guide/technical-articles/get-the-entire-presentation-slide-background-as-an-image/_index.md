---
title: 從簡報中取得整個投影片背景作為影像
linktitle: 整個投影片背景
type: docs
weight: 95
url: /zh-hant/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 投影片背景
- 最終背景
- 提取背景
- 完整背景
- 背景轉為影像
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，將 PowerPoint 與 OpenDocument 簡報的完整投影片背景提取為影像，簡化視覺工作流程。"
---
## **概觀**

在 PowerPoint 簡報中，投影片背景可能由多個元素組成，包括投影片背景影像、簡報主題、色彩配置，以及放置在母片或版面配置投影片上的物件。

本文說明如何使用 Aspose.Slides for .NET 將整個投影片背景提取為影像。由於此任務沒有單一方法，採取的做法是將選取的投影片複製到暫存簡報中，移除投影片上的形狀，然後將產生的投影片背景轉換為影像。

## **取得整個投影片背景**

Aspose.Slides for Android via Java 不提供直接將整個簡報投影片背景提取為影像的簡易方法，但您可以依照以下步驟完成此操作：
1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入簡報。
1. 從簡報中取得投影片尺寸。
1. 選取投影片。
1. 建立暫存簡報。
1. 在暫存簡報中設定相同的投影片尺寸。
1. 將選取的投影片複製到暫存簡報中。
1. 刪除複製投影片上的形狀。
1. 將複製的投影片轉換為影像。

以下程式碼範例會將整個簡報投影片背景提取為影像。
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **常見問題**

**母片上複雜的漸層、紋理或圖片填充，會在產生的背景影像中被保留嗎？**

是。Aspose.Slides 會呈現在投影片、版面或母片上定義的漸層、圖片與紋理填充。如果您需要將外觀從繼承的母片中分離，請在匯出前於目前投影片上[設定自訂背景](/slides/zh-hant/androidjava/presentation-background/)。

**我可以在儲存前為產生的背景影像加入浮水印嗎？**

是。您可以在可作業的[投影片副本](/slides/zh-hant/androidjava/clone-slides/)上[加入浮水印](/slides/zh-hant/androidjava/watermark/)形狀或影像（放置在其他內容之後），然後再匯出。這樣即可產生已內嵌浮水印的背景影像。

**我可以在不依附現有投影片的情況下取得特定版面或母片的背景嗎？**

是。存取所需的母片或版面，將其套用至具有所需尺寸的[暫存投影片](/slides/zh-hant/androidjava/clone-slides/)，再匯出該投影片，即可取得來自該版面或母片的背景。

**授權限制會影響影像匯出嗎？**

使用[有效授權](/slides/zh-hant/androidjava/licensing/)即可完整使用渲染功能。評估模式下，輸出可能會有如浮水印等限制。請在執行批次匯出前於每個程序中啟用授權。