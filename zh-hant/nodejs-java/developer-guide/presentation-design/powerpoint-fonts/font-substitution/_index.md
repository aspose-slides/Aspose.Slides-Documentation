---
title: 使用 JavaScript 在簡報中設定字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/nodejs-java/font-substitution/
keywords:
- 字型
- 替代字型
- 字型替代
- 取代字型
- 字型取代
- 替代規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在使用 JavaScript 將 PowerPoint 與 OpenDocument 簡報轉換為其他檔案格式時，為 Node.js 的 Aspose.Slides 啟用最佳字型替代。"
---
## **概述**

字型替代允許 Aspose.Slides 在渲染或轉換期間原始簡報字型不可用時使用其他字型。您可以透過 `FontsManager` 類別的 `getSubstitutions` 方法查詢已被替代的字型。

Aspose.Slides 也允許您定義字型替代規則。例如，您可以指定將無法存取的字型替換為其他可用的字型，然後透過簡報的字型管理員套用這些規則。

## **設定字型替代規則**

Aspose.Slides 允許您以以下方式設定字型規則，以決定在特定情況（例如字型無法存取）時需執行的操作：

1. 載入相關的簡報。
2. 載入將被替換的字型。
3. 載入新字型。
4. 新增替換規則。
5. 將規則加入簡報字型替換規則集合。
6. 產生投影片影像以觀察效果。

以下 JavaScript 程式碼示範字型替代過程：

```javascript
// 載入簡報
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 載入將被取代的來源字型
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // 載入新字型
    var destFont = new aspose.slides.FontData("Arial");
    // 新增字型取代規則
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // 將規則加入字型替代規則集合
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // 將字型規則集合加入規則清單
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // 當 SomeRareFont 無法存取時，將使用 Arial 字型取代
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // 以 JPEG 格式將影像儲存至磁碟
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看[**字型替換**](/slides/zh-hant/nodejs-java/font-replacement/)。
{{% /alert %}}

## **數學公式字型的限制**

字型替代規則參與在渲染與轉換期間使用的標準字型選擇程序。它們適用於一般文字情境，Aspose.Slides 可根據已設定的規則將無法存取的字型替換為其他可用的字型。

然而，Office 數學公式有一項重要限制。若公式是使用 **Cambria Math** 建立，Aspose.Slides 仍可能需要原始的 **Cambria Math** 字型才能正確計算與渲染公式版面。因此，將 **Cambria Math** 替換為其他數學字型（例如 **STIX Two Math**）並不支援於公式渲染，且仍可能拋出需要 **Cambria Math** 的例外。

若要成功轉換此類簡報，請確保 **Cambria Math** 在執行期間可供 Aspose.Slides 使用。您可以將此字型安裝於作業系統，或以[外部字型](/slides/zh-hant/nodejs-java/custom-font/)的方式提供，使其能在渲染與轉換期間參與正常的字型選擇程序。

此限制僅適用於公式渲染。上述的標準字型替代規則仍會在原始字型無法存取時，套用於一般簡報文字。

## **常見問題**

**字型替換與字型替代有何差異？**

[Replacement](/slides/zh-hant/nodejs-java/font-replacement/) 是在整個簡報中強制將一種字型覆寫為另一種字型。替代則是在特定條件下觸發的規則，例如當原始字型不可用時，使用指定的備用字型。

**替代規則究竟何時套用？**

這些規則會參與於載入、渲染與轉換期間評估的標準[字型選擇](/slides/zh-hant/nodejs-java/font-selection-sequence/)序列；若選擇的字型不可用，則會套用替換或替代。

**如果未設定替換或替代且系統缺少該字型，預設行為為何？**

函式庫會嘗試選取最接近的可用系統字型，類似於 PowerPoint 的行為。

**我可以在執行期間附加自訂外部字型以避免替代嗎？**

可以。您可以在執行期間[新增外部字型](/slides/zh-hant/nodejs-java/custom-font/)，讓函式庫在選擇與渲染時納入這些字型，亦包括後續的轉換。

**Aspose 是否隨函式庫一起分發任何字型？**

不會。Aspose 不會分發任何付費或免費字型；字型的添加與使用需由您自行斟酌與負責。

**Windows、Linux 與 macOS 上的替代行為有差異嗎？**

有。字型的偵測會從作業系統的字型目錄開始。各平台的預設可用字型集合與搜尋路徑不同，會影響字型的可用性與是否需要替代。

**我該如何準備環境以減少批次轉換期間意外的替代情況？**

在機器或容器之間同步字型集，[新增外部字型](/slides/zh-hant/nodejs-java/custom-font/)以滿足輸出文件的需求，並在可能的情況下於簡報中[嵌入字型](/slides/zh-hant/nodejs-java/embedded-font/)，確保選取的字型在渲染時可用。