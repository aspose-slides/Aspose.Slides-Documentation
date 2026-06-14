---
title: 在 .NET 中設定簡報的字型替換
linktitle: 字型替換
type: docs
weight: 70
url: /zh-hant/net/font-substitution/
keywords:
- 字型
- 替代字型
- 字型替換
- 取代字型
- 字型取代
- 替換規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中，將 PowerPoint 與 OpenDocument 簡報轉換為其他檔案格式時，啟用最佳的字型替換。"
---
## **概述**

字型替換允許 Aspose.Slides 在渲染或轉換過程中原始簡報字型不可用時使用其他字型。您可透過 `IFontsManager` 介面的 `GetSubstitutions` 方法檢查哪些字型已被替換。

Aspose.Slides 亦允許您定義字型替換規則。例如，您可以指定將無法存取的字型取代為另一個可用的字型，然後透過簡報的字型管理員套用這些規則。

## **取得字型替換**

為了讓您找出在簡報渲染過程中被替換的字型，Aspose.Slides 提供了來自 [IFontsManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontsmanager/) 介面的 [GetSubstitution](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getsubstitutions/) 方法。

C# 程式碼示範了如何取得在簡報渲染時執行的所有字型替換：
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **設定字型替換規則**

Aspose.Slides 允許您設定字型規則，以決定在特定情況下（例如字型無法存取）該怎麼處理，步驟如下：

1. 載入相關的簡報。
2. 載入將被取代的字型。
3. 載入新的字型。
4. 新增取代規則。
5. 將規則加入簡報的字型取代規則集合中。
6. 產生投影片影像以觀察效果。

C# 程式碼示範了字型替換的過程：
```c#
// 載入簡報
Presentation presentation = new Presentation("Fonts.pptx");

// 載入將被取代的來源字型
IFontData sourceFont = new FontData("SomeRareFont");

// 載入新字型
IFontData destFont = new FontData("Arial");

// 新增字型取代的規則
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// 將規則加入字型替換規則集合
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// 將字型規則集合加入規則清單
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // 以 JPEG 格式將影像儲存到磁碟
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
您可能想參考 [**Font Replacement**](/slides/zh-hant/net/font-replacement/)。 
{{% /alert %}}

## **數學方程式字型的限制**

字型替換規則會參與在渲染和轉換過程中使用的標準字型選取程序。它們適用於一般文字情境，Aspose.Slides 可依照設定的規則將無法存取的字型取代為其他可用的字型。

然而，Office 數學方程式有一項重要限制。若方程式是以 **Cambria Math** 建立，Aspose.Slides 仍可能需要原始的 **Cambria Math** 字型才能正確計算與渲染方程式版面。因此，將 **Cambria Math** 替換成其他數學字型（例如 **STIX Two Math**）在方程式渲染時不受支援，且仍可能拋出需使用 **Cambria Math** 的例外情況。

若要成功轉換此類簡報，請確保 **Cambria Math** 在執行階段可供 Aspose.Slides 使用。您可以在作業系統中安裝該字型，或將其作為 [external font](/slides/zh-hant/net/custom-font/) 提供，讓其參與渲染與轉換時的正常字型選取程序。

此限制僅適用於方程式渲染。上述的標準字型替換規則仍會在原始字型無法存取時套用於一般簡報文字。

## **常見問題**

**字型取代與字型替換有何差異？**

[Replacement](/slides/zh-hant/net/font-replacement/) 是在整個簡報中強制將一種字型覆寫為另一種字型。字型替換則是於特定條件（例如原始字型不可用）下觸發的規則，會使用指定的備用字型。

**什麼時候會套用替換規則？**

這些規則會參與在載入、渲染與轉換期間評估的標準 [font selection](/slides/zh-hant/net/font-selection-sequence/) 程序；若所選字型不可用，則會套用取代或替換。

**如果系統中缺少字型且未設定取代或替換，預設行為為何？**

函式庫會嘗試選取最接近的可用系統字型，行為類似於 PowerPoint。

**我可以在執行時附加自訂外部字型以避免替換嗎？**

可以。您可以在執行時 [add external fonts](/slides/zh-hant/net/custom-font/) ，讓函式庫在選取與渲染時（包括後續轉換）考慮這些字型。

**Aspose 會隨函式庫一起分發任何字型嗎？**

不會。Aspose 不會分發付費或免費字型；您需自行決定並負責加入與使用字型。

**在 Windows、Linux 與 macOS 上的替換行為有差異嗎？**

有。字型偵測會從作業系統的字型目錄開始。不同平台的預設可用字型集合與搜尋路徑不同，會影響字型可用性與是否需要替換。

**我該如何準備環境以減少批次轉換時的意外替換？**

在機器或容器間同步字型集合，[add the external fonts](/slides/zh-hant/net/custom-font/) 以符合輸出文件的需求，並在可能的情況下於簡報中 [embed fonts](/slides/zh-hant/net/embedded-font/)，確保所選字型在渲染時可用。