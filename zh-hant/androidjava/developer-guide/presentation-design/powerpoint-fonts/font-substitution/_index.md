---
title: 在 Android 上設定簡報的字體替代
linktitle: 字體替代
type: docs
weight: 70
url: /zh-hant/androidjava/font-substitution/
keywords:
- 字體
- 替代字體
- 字體替代
- 取代字體
- 字體取代
- 替代規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在使用 Java 於 Android 上的 Aspose.Slides 轉換 PowerPoint 與 OpenDocument 簡報為其他檔案格式時，啟用最佳的字體替代。"
---
## **概覽**

字體替代允許 Aspose.Slides 在渲染或轉換過程中原始簡報字體不可用時使用其他字體。您可以透過 `IFontsManager` 介面的 `getSubstitutions` 方法檢查哪些字體被替代。

Aspose.Slides 也允許您定義字體替代規則。例如，您可以指定將不可存取的字體替換為另一個可用的字體，然後透過簡報的字體管理員套用這些規則。

## **設定字體替代規則**

Aspose.Slides 允許您以以下方式設定字體規則，以決定在特定情況下（例如字體無法存取）應採取的措施：

1. 載入相關的簡報。
2. 載入將被取代的字體。
3. 載入新的字體。
4. 為取代加入規則。
5. 將規則加入簡報字體取代規則集合。
6. 產生投影片影像以觀察效果。

以下 Java 程式碼示範字體替代流程：

```java
// 載入簡報
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 載入將被取代的來源字體
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // 載入新的字體
    IFontData destFont = new FontData("Arial");
    
    // 新增字體取代規則
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // 將規則加入字體替代規則集合
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // 將字體規則集合加入規則清單
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // 當 SomeRareFont 無法存取時，將使用 Arial 字體取代
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
您可能想查看[**Font Replacement**](/slides/zh-hant/androidjava/font-replacement/)。
{{% /alert %}}

## **數學方程式字體的限制**

字體替代規則參與渲染與轉換過程中使用的標準字體選擇程序。它們適用於一般文字情境，Aspose.Slides 可依據設定的規則將不可存取的字體替換為其他可用的字體。

然而，Office 數學方程式存在一項重要限制。若方程式是使用 **Cambria Math** 建立，Aspose.Slides 仍可能需要原始的 **Cambria Math** 字體以正確計算與呈現方程式佈局。因此，將 **Cambria Math** 替換為其他數學字體（例如 **STIX Two Math**）在方程式呈現時不受支援，仍可能拋出表示需要 **Cambria Math** 的例外。

若要成功轉換此類簡報，請確保 **Cambria Math** 在執行時可供 Aspose.Slides 使用。您可以在作業系統中安裝該字體，或將其作為[external font](/slides/zh-hant/androidjava/custom-font/) 提供，使其能參與渲染與轉換過程中的正常字體選擇程序。

此限制僅適用於方程式呈現。上述的標準字體替代規則仍適用於原始字體不可取得時的普通簡報文字。

## **常見問題**

**字體取代與字體替代之差異為何？**  
[Replacement](/slides/zh-hant/androidjava/font-replacement/) 是在整個簡報中強制將一種字體覆寫為另一種字體。替代則是在特定條件下（例如原始字體不可用）觸發的規則，並使用指定的備援字體。

**替代規則到底何時套用？**  
這些規則參與在載入、渲染與轉換期間評估的標準[font selection](/slides/zh-hant/androidjava/font-selection-sequence/) 程序；若所選字體不可用，則會套用取代或替代。

**如果未設定取代或替代且系統缺少字體，預設行為為何？**  
函式庫會嘗試選取最相近的可用系統字體，類似 PowerPoint 的行為。

**我可以在執行時附加自訂外部字體以避免替代嗎？**  
可以。您可以在執行時[add external fonts](/slides/zh-hant/androidjava/custom-font/)，讓函式庫在選擇與渲染時考慮這些字體，亦包含後續的轉換。

**Aspose 會隨函式庫一起分發任何字體嗎？**  
不會。Aspose 不會分發付費或免費字體；字體的加入與使用須由使用者自行決定並負責。

**在 Windows、Linux 與 macOS 上的替代行為有差異嗎？**  
有。字體搜尋從作業系統的字體目錄開始。各平台預設可用字體集合與搜尋路徑不同，會影響可取得性與是否需要替代。

**我該如何準備環境以減少批次轉換時意外的替代？**  
在機器或容器之間同步字體集合，[add the external fonts](/slides/zh-hant/androidjava/custom-font/) 以支援輸出文件所需的字體，並在可能的情況下於簡報中[embed fonts](/slides/zh-hant/androidjava/embedded-font/)，確保所選字體於渲染時可用。