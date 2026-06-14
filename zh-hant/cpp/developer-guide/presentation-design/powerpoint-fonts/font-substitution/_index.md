---
title: 使用 С++ 配置簡報中的字體替代
linktitle: 字體替代
type: docs
weight: 70
url: /zh-hant/cpp/font-substitution/
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
- С++
- Aspose.Slides
description: "在將 PowerPoint 與 OpenDocument 簡報轉換為其他檔案格式時，為 С++ 的 Aspose.Slides 啟用最佳的字體替代功能。"
---
## **概述**

字體替代允許 Aspose.Slides 在渲染或轉換期間原始簡報字體不可用時使用其他字體。您可以透過 `IFontsManager` 介面的 `GetSubstitutions` 方法來檢查哪些字體已被替代。

Aspose.Slides 也允許您定義字體替代規則。例如，您可以指定將無法存取的字體替換為另一個可用字體，然後透過簡報的字體管理員套用這些規則。

## **設定字體替代規則**

Aspose.Slides 允許您設定字體規則，以決定在特定情況下（例如字體無法存取）應採取的行動，方法如下：

1. 載入相關的簡報。
2. 載入將被替換的字體。
3. 載入新字體。
4. 新增一個替換規則。
5. 將規則加入簡報的字體替代規則集合。
6. 產生投影片影像以觀察效果。

此 C++ 程式碼示範字體替代過程：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 載入簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 定義將被取代的字體及新字體
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// 新增字體取代規則
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// 將規則加入字體替代規則集合
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// 將字體規則集合加入規則清單
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// 將 PPTX 儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看[**字體替換**](/slides/zh-hant/cpp/font-replacement/)。 
{{% /alert %}}

## **數學公式字體的限制**

字體替代規則參與渲染與轉換期間使用的標準字體選擇流程。它們適用於一般文字情境，Aspose.Slides 能依照設定的規則將無法存取的字體替換為其他可用字體。

然而，Office 數學公式有一項重要限制。若方程式是使用 **Cambria Math** 建立的，Aspose.Slides 仍可能需要原始的 **Cambria Math** 字體來正確計算與呈現公式版面。基於此，將 **Cambria Math** 替換為其他數學字體（例如 **STIX Two Math**）在公式渲染時不受支援，且仍可能拋出需要 **Cambria Math** 的例外。

若要成功轉換此類簡報，請確保 **Cambria Math** 在執行時間可供 Aspose.Slides 使用。您可以在作業系統中安裝該字體，或以[外部字體](/slides/zh-hant/cpp/custom-font/) 形式提供，使其能參與渲染與轉換期間的正常字體選擇流程。

此限制僅適用於公式渲染。上述標準字體替代規則仍會在原始字體不可用時套用於一般簡報文字。

## **常見問題**

**字體替換與字體替代有何不同？**

[Replacement](/slides/zh-hant/cpp/font-replacement/) 是在整個簡報中強制將一種字體覆寫為另一種字體。替代則是根據特定條件（例如原始字體不可用）觸發的規則，使用指定的備援字體。

**替代規則究竟在何時套用？**

這些規則參與在載入、渲染與轉換期間評估的標準[字體選擇](/slides/zh-hant/cpp/font-selection-sequence/) 流程；若選取的字體不可用，則會套用替換或替代。

**如果未設定替換或替代，且系統缺少該字體，預設行為為何？**

函式庫會嘗試選取最接近的可用系統字體，類似 PowerPoint 的行為。

**我能在執行時附加自訂外部字體以避免替代嗎？**

可以。您可以在執行時[加入外部字體](/slides/zh-hant/cpp/custom-font/)，讓函式庫在選擇與渲染時考慮它們，亦包含後續的轉換。

**Aspose 是否隨函式庫一起分發任何字體？**

不會。Aspose 不會分發付費或免費字體；您需自行決定並負責加入與使用字體。

**在 Windows、Linux 與 macOS 上，替代行為有何差異？**

有。字體偵測會從作業系統的字體目錄開始。各平台的預設可用字體集合與搜尋路徑不同，會影響字體可用性與是否需要替代。

**我應如何準備環境以降低批次轉換時意外的字體替代？**

同步各機器或容器的字體集合，[加入外部字體](/slides/zh-hant/cpp/custom-font/) 以滿足輸出文件的需求，並在可能時於簡報中[嵌入字體](/slides/zh-hant/cpp/embedded-font/)，確保在渲染時可使用所選字體。