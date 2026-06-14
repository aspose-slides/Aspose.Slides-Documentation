---
title: 使用 Python 高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/python-net/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併 簡報
- 合併 投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 結合 PowerPoint
- 結合 簡報
- 結合 投影片
- 結合 PPT
- 結合 PPTX
- 結合 ODP
- Python
- Aspose.Slides
description: 輕鬆地使用 Aspose.Slides for Python 透過 .NET 合併 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報，簡化您的工作流程。
---
## **概觀**

Aspose.Slides 允許您透過從一個簡報複製投影片到另一個簡報的方式合併簡報。本文件說明如何合併整個簡報或選取的投影片、在合併期間使用投影片母片或特定版面配置、處理具有不同投影片尺寸的簡報，以及將合併的投影片新增至簡報節。亦討論與合併內容相關的實務注意事項，包括講者備註、註解、受密碼保護的來源檔案，以及執行緒使用情形。

## **最佳化您的簡報合併**

使用 [Aspose.Slides for Python](https://products.aspose.com/slides/zh-hant/python-net/)，您可以無縫結合 PowerPoint 簡報，同時保留樣式、版面配置及所有元素。與其他工具不同，Aspose.Slides 在合併簡報時不會降低品質或遺失資料。您可以合併整個簡報、特定投影片，甚至不同的檔案格式（例如 PPT 轉 PPTX）。

### **合併功能**

- **完整簡報合併**：將所有投影片彙集成單一檔案。
- **特定投影片合併**：挑選並合併所選投影片。
- **跨格式合併**：整合不同格式的簡報，同時保持完整性。

## **簡報合併**

將一個簡報合併到另一個簡報時，實際上是將兩者的投影片合併成單一簡報，產生一個檔案。大多數簡報程式（例如 PowerPoint 或 OpenOffice）皆未提供此類合併功能。

然而，[Aspose.Slides for Python](https://products.aspose.com/slides/zh-hant/python-net/) 允許您以多種方式合併簡報。您可合併簡報的所有圖形、樣式、文字、格式、註解與動畫，且不會有任何品質或資料的遺失。

**另請參閱**

[在 Python 中克隆 PowerPoint 投影片](/slides/zh-hant/python-net/clone-slides/)

### **可以合併的內容**

使用 Aspose.Slides，您可以合併：

- 整個簡報：來源簡報的所有投影片皆合併成單一簡報。
- 特定投影片：僅將選取的投影片合併成單一簡報。
- 相同格式的簡報（例如 PPT→PPT、PPTX→PPTX）或跨不同格式的簡報（例如 PPT→PPTX、PPTX→ODP）。

### **合併選項**

您可以控制以下情況：

- 輸出簡報中的每張投影片保留其原始樣式，或  
- 所有投影片套用單一樣式。

要合併簡報，Aspose.Slides 在 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 類別上提供了 [add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 方法。這些方法的重載決定了合併的執行方式。每個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件都會公開一個 [slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/) 集合，因此您需要在目標簡報的投影片集合上呼叫 `add_clone`。

`add_clone` 方法會回傳一個 `Slide`——來源投影片的複製品。輸出簡報中的投影片是原始投影片的副本，您可以修改產生的投影片（例如套用樣式、格式或版面配置），而不會影響來源簡報。

## **合併簡報** 

Aspose.Slides 提供了 [add_clone(ISlide)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) 方法，可在保留投影片版面配置與樣式（使用預設參數）的情況下合併投影片。

以下 Python 範例示範如何合併簡報：

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **使用投影片母片合併簡報**

Aspose.Slides 提供了 [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) 方法，可在合併投影片時套用來自範本的投影片母片。如此一來，您在需要時即可重新設計輸出簡報中的投影片樣式。

以下 Python 範例示範此操作：

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="注意" color="warning" %}}
在指定的投影片母片下，會自動決定適當的版面配置。若找不到合適的版面且 `allow_clone_missing_layout` 布林參數的 `add_clone` 方法設定為 `True`，則會改用來源投影片的版面配置。否則會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxeditexception/)。
{{% /alert %}}

若要在輸出簡報的投影片上套用不同的版面配置，合併時請使用 [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) 方法。

## **從簡報合併特定投影片**

從多個簡報中合併特定投影片在建立自訂投影片組時相當有用。Aspose.Slides 允許您僅挑選並匯入所需的投影片，同時保留原始投影片的格式、版面配置與設計。

以下 Python 範例建立新簡報，從另外兩個簡報加入標題投影片，並將結果儲存為檔案：

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **使用投影片版面配置合併簡報**

以下 Python 範例示範如何在合併多個簡報的投影片時套用特定投影片版面配置，以產生單一輸出簡報：

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **使用不同投影片尺寸合併簡報**

{{% alert title="注意" color="warning" %}}
您無法直接合併具有不同投影片尺寸的簡報。
{{% /alert %}}

若要合併兩個投影片尺寸不同的簡報，首先需調整其中一個簡報的尺寸，使其投影片尺寸與另一個相符。

以下範例程式碼示範此過程：

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **將投影片合併至簡報節**

以下 Python 範例說明如何將特定投影片合併至簡報的某個節中：

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

該投影片會被加入至該節的末端。

{{% alert title="提示" color="primary" %}}
想找快速且 **免費線上工具** 來 **合併 PowerPoint 簡報** 嗎？請試用 [**Aspose PowerPoint 合併器**](https://products.aspose.app/slides/zh-hant/merger)。

- **輕鬆合併 PowerPoint 檔案**：將多個 **PPT、PPTX、ODP** 簡報合併為單一檔案。  
- **支援不同格式**：合併 **PPT 轉 PPTX**、**PPTX 轉 ODP** 等。  
- **免安裝**：直接在瀏覽器中執行，快速且安全。  

[![線上合併 PowerPoint 檔案](slides-merger.png)](https://products.aspose.app/slides/zh-hant/merger)  

立即使用 **Aspose 免費線上工具** 開始合併您的 PowerPoint 檔案！  
{{% /alert %}}

{{% alert title="提示" color="primary" %}}
Aspose 提供一個 [免費拼貼網站應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG 至 JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 至 PNG 圖片，建立 [相片格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等。 
{{% /alert %}}

## **常見問題**

**合併時會保留講者備註嗎？**

會。當克隆投影片時，Aspose.Slides 會保留所有投影片元素，包括備註、格式和動畫。

**註解及其作者會被轉移嗎？**

註解作為投影片內容的一部份，會隨投影片一起複製。註解的作者標籤會以註解物件形式保留於產生的簡報中。

**如果來源簡報受密碼保護怎麼辦？**

必須透過 [LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/) 使用密碼開啟 [受密碼保護的簡報](/slides/zh-hant/python-net/password-protected-presentation/)，載入後即可安全地將這些投影片克隆至未受保護的目標檔案（或同樣受保護的檔案）。

**合併操作的執行緒安全性如何？**

請勿在[多個執行緒](/slides/zh-hant/python-net/multithreading/)中使用相同的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例。建議的規則是「一份文件 — 一個執行緒」；不同的檔案可以在獨立執行緒中平行處理。