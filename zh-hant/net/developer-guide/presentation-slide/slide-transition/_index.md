---
title: 在 .NET 中管理簡報的投影片過渡
linktitle: 投影片過渡
type: docs
weight: 90
url: /zh-hant/net/slide-transition/
keywords:
- 投影片過渡
- 新增投影片過渡
- 套用投影片過渡
- 進階投影片過渡
- Morph 轉換
- 過渡類型
- 過渡效果
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中自訂投影片過渡，並提供 PowerPoint 與 OpenDocument 簡報的逐步指南。"
---
## **概述**

本文說明如何使用 Aspose.Slides 管理簡報中的投影片過渡效果。它展示了如何將過渡類型套用到投影片、設定點擊或指定時間後前進等過渡行為、檢查並停用自動前進、使用 Morph 轉換及其類型，並設定過渡效果選項。範例說明了如何載入或建立簡報、修改選取投影片的過渡設定，並將結果儲存為 PPTX 檔案。本文同時回答了過渡速度、過渡音效、將相同過渡套用至多張投影片以及檢查投影片目前設定的過渡等常見問題。

## **新增投影片過渡效果**
為了讓說明更易於理解，我們示範了使用 Aspose.Slides for .NET 來管理簡單的投影片過渡。開發人員不僅可以對投影片套用不同的過渡效果，還能自訂這些過渡效果的行為。建立簡單的投影片過渡效果，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過 TransitionType 列舉，從 Aspose.Slides for .NET 提供的過渡效果中為投影片套用一種投影片過渡類型。  
3. 寫入已修改的簡報檔案。

```c#
// 實例化 Presentation 類別以載入來源簡報檔案
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // 在第 1 張投影片套用圓形過渡效果
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // 在第 2 張投影片套用梳狀過渡效果
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // 將簡報寫入磁碟
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **新增進階投影片過渡效果**
在前一節中，我們只套用了簡單的過渡效果。現在，為了讓這個簡單的過渡效果更完善且可控，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 於投影片套用 Aspose.Slides for .NET 所提供的其中一種過渡效果。  
3. 您也可以將過渡設為「點擊前進」(Advance On Click)、在特定時間後前進，或同時設定兩者。  
4. 若投影片過渡已啟用「點擊前進」(Advance On Click)，則過渡僅會在使用者點擊滑鼠時前進。此外，若設定了 Advance After Time 屬性，則過渡會在指定的時間過後自動前進。  
5. 將已修改的簡報寫入為簡報檔案。

```c#
// 實例化代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // 在第 1 張投影片套用圓形過渡效果
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // 設定 3 秒的過渡時間
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // 在第 2 張投影片套用梳狀過渡效果
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // 設定 5 秒的過渡時間
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // 在第 3 張投影片套用縮放過渡效果
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // 設定 7 秒的過渡時間
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // 將簡報寫入磁碟
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

此外，使用 [AdvanceAfter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islideshowtransition/advanceafter/) 屬性，您可以檢查投影片過渡是否已設定為移至下一張投影片，或停用此設定。

以下 C# 程式碼示範了此操作：

```c#
// 實例化一個代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // 取得投影片的過渡設定
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // 檢查是否已啟用 Advance After Time 設定
        if (slideTransition.AdvanceAfter)
        {
            // 列印 Advance After Time 值
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // 若 AdvanceAfterTime 值大於 2 秒，則停用在特定時間後的過渡
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Morph 轉換**
Aspose.Slides for .NET 現在支援 [Morph Transition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/imorphtransition)。它是 PowerPoint 2019 中引入的新型 Morph 轉換。Morph 轉換可讓您在投影片之間產生平滑的動畫移動。本文說明了此概念以及如何使用 Morph 轉換。若要有效使用 Morph 轉換，您需要兩張至少有一個共同物件的投影片。最簡單的方式是複製投影片，然後將第二張投影片上的物件移動到其他位置。

以下程式碼片段示範如何將含有文字的投影片副本加入簡報，並將第二張投影片的過渡設定為 [morph type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/imorphtransition/properties/morphtype)。

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Morph 轉換類型**
新增了 [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/transitionmorphtype) 列舉，代表不同類型的 Morph 投影片過渡。

TransitionMorphType 列舉有三個成員：

- ByObject：Morph 轉換會將形狀視為不可分割的物件來執行。  
- ByWord：Morph 轉換會在可能的情況下，以單詞為單位傳遞文字。  
- ByChar：Morph 轉換會在可能的情況下，以字元為單位傳遞文字。

以下程式碼片段示範如何為投影片設定 Morph 轉換並變更 Morph 類型：

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **設定過渡效果**
Aspose.Slides for .NET 支援設定從黑色、從左側、從右側等多種過渡效果。若要設定過渡效果，請依照下列步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
- 取得投影片的參考。  
- 設定過渡效果。  
- 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

在下方範例中，我們已設定過渡效果。

```c#
// 建立 Presentation 類別的實例
Presentation presentation = new Presentation("AccessSlides.pptx");

// 設定效果
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// 將簡報寫入磁碟
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **常見問題**

**我可以控制投影片過渡的播放速度嗎？**

可以。使用 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/transitionspeed/) 設定過渡的 [Speed](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/speed/)，例如慢速、普通或快速。

**我可以為過渡附加音訊並讓它循環播放嗎？**

可以。您可以為過渡嵌入音效，並透過 [Sound](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/sound/)、[SoundMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/soundmode/)、[SoundLoop](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/soundloop/) 等設定控制行為，此外還有 [SoundIsBuiltIn](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) 和 [SoundName](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/soundname/) 等相關屬性。

**將相同過渡套用到每張投影片的最快方法是什麼？**

在每張投影片的過渡設定中配置所需的過渡類型；過渡是儲存在每張投影片上的，因此在所有投影片上套用相同類型即可快速達成一致的效果。

**我要如何檢查投影片目前設定的是哪種過渡？**

檢查投影片的 [transition settings](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslide/slideshowtransition/)，並讀取其 [transition type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slideshow/slideshowtransition/type/)，即可得知目前套用了哪種過渡效果。