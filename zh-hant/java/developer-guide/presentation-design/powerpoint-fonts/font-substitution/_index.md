---
title: 使用 Java 在簡報中設定字型置換
linktitle: 字型置換
type: docs
weight: 70
url: /zh-hant/java/font-substitution/
keywords:
- 字型
- 置換字型
- 字型置換
- 取代字型
- 字型取代
- 置換規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在將 PowerPoint 與 OpenDocument 簡報轉換為其他檔案格式時，為 Aspose.Slides for Java 啟用最佳的字型置換。"
---
## **概觀**

字型置換允許 Aspose.Slides 在渲染或轉換期間，當原始簡報的字型不可用時使用其他字型。您可以使用 `IFontsManager` 介面的 `getSubstitutions` 方法來檢查哪些字型被置換。

Aspose.Slides 也允許您定義字型置換規則。例如，您可以指定將無法存取的字型替換為其他可用字型，然後透過簡報的字型管理員套用這些規則。

## **設定字型置換規則**

Aspose.Slides 以此方式為字型設定規則，決定在特定情況下（例如字型無法存取）該怎麼處理：

1. 載入相關的簡報。
2. 載入將被取代的字型。
3. 載入新字型。
4. 新增取代規則。
5. 將規則加入簡報的字型取代規則集合中。
6. 產生投影片影像以觀察效果。

以下 Java 程式碼示範字型置換流程：

```java
// 載入簡報
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 載入將被取代的來源字型
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // 載入新字型
    IFontData destFont = new FontData("Arial");
    
    // 新增字型取代規則
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // 將規則加入字型置換規則集合
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // 將字型規則集合加入規則清單
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // 當無法存取 SomeRareFont 時，將使用 Arial 字型取代
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // 將影像以 JPEG 格式儲存至磁碟
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看 [**字型取代**](/slides/zh-hant/java/font-replacement/)。 
{{% /alert %}}

## **數學方程式字型的限制**

字型置換規則參與渲染與轉換期間使用的標準字型選取程序。它們適用於一般文字情境，Aspose.Slides 可以根據設定的規則將無法存取的字型替換為其他可用字型。

然而，Office 數學方程式有一項重要限制。若方程式是使用 **Cambria Math** 建立的，Aspose.Slides 仍可能需要原始的 **Cambria Math** 字型來正確計算與渲染方程式版面。基於此，將 **Cambria Math** 替換為其他數學字型（例如 **STIX Two Math**）在方程式渲染時不受支援，仍可能拋出要求 **Cambria Math** 的例外。

若要成功轉換此類簡報，請確保執行時 Aspose.Slides 可使用 **Cambria Math**。您可以在作業系統中安裝該字型，或將其作為 [external font](/slides/zh-hant/java/custom-font/) 提供，以便在渲染與轉換期間參與正常的字型選取程序。

此限制僅限於方程式渲染。上述標準的字型置換規則仍適用於原始字型不可用時的一般簡報文字。

## **常見問題**

**字型取代與字型置換有何差異？**  
[Replacement](/slides/zh-hant/java/font-replacement/) 是在整份簡報中強制以另一個字型覆寫原始字型。置換則是一項在特定條件下觸發的規則，例如原始字型不可用時，會使用指定的備援字型。

**什麼時候會套用置換規則？**  
這些規則參與標準的 [font selection](/slides/zh-hant/java/font-selection-sequence/) 流程，該流程在載入、渲染與轉換期間評估；若所選字型不可用，則會套用取代或置換。

**如果未設定取代或置換，且系統缺少字型，預設行為為何？**  
函式庫會嘗試選取最相近的可用系統字型，類似 PowerPoint 的行為。

**我可以在執行時附加自訂外部字型以避免置換嗎？**  
可以。您可以在執行時 [add external fonts](/slides/zh-hant/java/custom-font/) ，讓函式庫在選取與渲染時考慮這些字型，亦包括後續的轉換。

**Aspose 會隨函式庫一起發佈任何字型嗎？**  
不會。Aspose 不會隨函式庫發佈付費或免費字型；字型的新增與使用皆由您自行決定並自行負責。

**在 Windows、Linux 與 macOS 上的置換行為有差異嗎？**  
有。字型偵測會從作業系統的字型目錄開始。各平台預設可用的字型集合與搜尋路徑不同，會影響字型的可用性與是否需要置換。

**在批次轉換時，如何準備環境以減少意外的置換？**  
在機器或容器之間同步字型集合，[add the external fonts](/slides/zh-hant/java/custom-font/) 以滿足輸出文件的需求，並盡可能在簡報中 [embed fonts](/slides/zh-hant/java/embedded-font/) ，確保選用的字型在渲染時可用。