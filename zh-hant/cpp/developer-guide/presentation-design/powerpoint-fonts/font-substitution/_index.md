---
title: 設定 C++ 簡報中的字型取代
linktitle: 字型取代
type: docs
weight: 70
url: /zh-hant/cpp/font-substitution/
keywords:
- 字型
- 取代字型
- 字型取代
- 替換字型
- 字型取代
- 取代規則
- 替換規則
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中啟用最佳字型取代，將 PowerPoint 與 OpenDocument 簡報轉換為其他檔案格式時。"
---
## **概觀**

字型取代允許 Aspose.Slides 在渲染或轉換期間原始簡報字型不存在時使用其他字型。您可以透過 `IFontsManager` 介面的 `GetSubstitutions` 方法檢查哪些字型已被取代。

Aspose.Slides 亦允許您定義字型取代規則。例如，您可以指定在無法存取的字型時，使用另一個可用字型取代，並透過簡報的字型管理員套用這些規則。

## **設定字型取代規則**

Aspose.Slides 允許您設定字型規則，以決定在特定條件（例如無法存取字型）時應執行的動作，方法如下：

1. 載入相關的簡報。
2. 載入將被取代的字型。
3. 載入新的字型。
4. 新增一條取代規則。
5. 將規則加入簡報的字型取代規則集合中。
6. 產生投影片影像以觀察效果。

以下 C++ 程式碼示範字型取代流程：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 載入簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 定義將被取代的字型與新字型
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// 為字型取代新增規則
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// 將規則加入字型取代規則集合
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// 將字型規則集合加入規則清單
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// 儲存 PPTX 到磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看[**字型取代**](/slides/zh-hant/cpp/font-replacement/)。 
{{% /alert %}}

## **數學方程式字型的限制**

字型取代規則會參與在渲染與轉換期間使用的標準字型選擇程序。它們適用於一般文字情況，Aspose.Slides 能依照已設定的規則將無法存取的字型替換為另一個可用字型。

然而，Office 數學方程式有一項重要限制。若方程式是使用 **Cambria Math** 建立的，Aspose.Slides 仍可能需要原始的 **Cambria Math** 字型才能正確計算與渲染方程式版面。因為此原因，將 **Cambria Math** 替換為其他數學字型（例如 **STIX Two Math**）不支援於方程式渲染，仍可能拋出需要 **Cambria Math** 的例外。

若要成功轉換此類簡報，請確保 **Cambria Math** 在執行時可供 Aspose.Slides 使用。您可以將該字型安裝於作業系統，或以[外部字型](/slides/zh-hant/cpp/custom-font/)的方式提供，使其在渲染與轉換期間參與一般的字型選擇程序。

此限制僅針對方程式渲染。上述標準的字型取代規則仍會在原始字型無法存取時套用於一般簡報文字。

## **常見問題**

**字型取代與字型替代有何不同？**

`[取代](/slides/zh-hant/cpp/font-replacement/)` 是在整個簡報中強制以另一字型覆寫原有字型。替代則是一項規則，於特定情況（例如原始字型不可用時）觸發，並使用指定的備用字型。

**字型替代規則到底何時會被套用？**

這些規則參與在載入、渲染與轉換期間評估的標準[字型選擇](/slides/zh-hant/cpp/font-selection-sequence/)程序；若選擇的字型不可用，則會套用取代或替代。

**如果未設定取代或替代且系統缺少該字型，預設行為為何？**

庫會嘗試選取最接近的可用系統字型，行為類似 PowerPoint。

**我能在執行時附加自訂外部字型以避免替代嗎？**

可以。您可以在執行時[新增外部字型](/slides/zh-hant/cpp/custom-font/)，讓程式庫在選擇與渲染時考慮它們，亦包括後續的轉換。

**Aspose 是否隨函式庫一起分發任何字型？**

不會。Aspose 不會分發付費或免費字型；您須自行自行決定與負責添加與使用字型。

**在 Windows、Linux 與 macOS 上的替代行為是否有所差異？**

有。字型偵測會從作業系統的字型目錄開始。各平台預設可用的字型集合與搜尋路徑不同，這會影響可取得性以及是否需要替代。

**我應如何準備環境以減少批次轉換時意外的字型替代？**

在機器或容器間同步字型集合、[新增外部字型](/slides/zh-hant/cpp/custom-font/)以滿足輸出文件的需求，並在可能的情況下於簡報中[嵌入字型](/slides/zh-hant/cpp/embedded-font/)，確保選用的字型在渲染時可取得。