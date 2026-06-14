---
title: 從簡報中擷取整個投影片背景為圖像
linktitle: 整個投影片背景
type: docs
weight: 95
url: /zh-hant/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 投影片背景
- 最終背景
- 擷取背景
- 完整背景
- 背景轉圖像
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，從 PowerPoint 和 OpenDocument 簡報中將完整投影片背景匯出為圖像，簡化視覺工作流程。"
---
## **概述**

在 PowerPoint 簡報中，投影片背景可能由多個元素組成，包括投影片背景圖像、簡報主題、色彩配置，以及放置在母片或版面投影片上的物件。

本文說明如何使用 Aspose.Slides 將整個投影片背景提取為圖像。由於沒有單一方法可完成此任務，做法是將選取的投影片複製到臨時簡報中，刪除投影片上的形狀，然後將所得的投影片背景轉換為圖像。

## **取得整個投影片背景**

Aspose.Slides for Node.js via Java 不提供直接將整個簡報投影片背景提取為圖像的簡單方法，但您可以依照以下步驟執行：
1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入簡報。
2. 從簡報取得投影片大小。
3. 選取投影片。
4. 建立臨時簡報。
5. 在臨時簡報中設定相同的投影片大小。
6. 將選取的投影片複製到臨時簡報中。
7. 刪除複製投影片上的形狀。
8. 將複製的投影片轉換為圖像。

以下程式碼示例說明如何將整個簡報投影片背景提取為圖像。
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **常見問題**

**從母片的複雜漸層、紋理或圖片填充會在產生的背景圖像中保留嗎？**  
是。Aspose.Slides 會呈現在投影片、版面或母片上定義的漸層、圖片與紋理填充。如果您需要將外觀從繼承的母片中分離，請在匯出之前於當前投影片[設定自訂背景](/slides/zh-hant/nodejs-java/presentation-background/)。

**我可以在儲存之前為產生的背景圖像加入浮水印嗎？**  
是。您可以在可作業的[投影片副本](/slides/zh-hant/nodejs-java/clone-slides/)上[加入浮水印](/slides/zh-hant/nodejs-java/watermark/)形狀或圖像（置於其他內容之後），然後再匯出。如此即可產生已內嵌浮水印的背景圖像。

**我能取得特定版面或母片的背景，而不必將其綁定至既有投影片嗎？**  
是。存取所需的母片或版面，將其套用至具有所需大小的[臨時投影片](/slides/zh-hant/nodejs-java/clone-slides/)，然後匯出該投影片，即可取得來自該版面或母片的背景。

**是否有授權限制會影響圖像匯出？**  
只要擁有[有效授權](/slides/zh-hant/nodejs-java/licensing/)，即可完整使用渲染功能。於評估模式下，輸出可能會有浮水印等限制。請於執行批次匯出前於每個程序激活授權。