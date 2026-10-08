---
title: 在 C++ 簡報中設定字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "在渲染或轉換 PowerPoint 與 OpenDocument 簡報時，於 Aspose.Slides for C++ 中設定字型替代規則並檢查被替代的字型。"
---
## **概觀**

字型替代允許 Aspose.Slides 在無法存取某個字型時，使用可用的字型來取代，於投影片渲染或轉換時使用。替代僅影響已渲染的輸出；不會更改投影片內容所指定的字型。

您可以在特定字型不可用時定義要使用的字型，並且可以檢查 Aspose.Slides 在渲染過程中將執行的替代。這有助於在具有不同已安裝字型的環境之間保持輸出一致性。

如果某個字型可用但沒有專用的粗體字型，請參閱[處理沒有專用粗體字型的字型](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)。該章節說明了在 PDF 匯出期間如何光柵化受影響的文字，以及對文字選取、搜尋和縮放的影響。

## **取得字型替代**

使用[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)方法來判斷在投影片渲染時會被替代的字型。該方法會回傳[FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/)物件，該物件識別原始字型與替代字型的名稱。

以下的 C++ 範例列出投影片的所有字型替代：

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **取得選取投影片的字型替代**

使用帶有 `System::ArrayPtr<int32_t> slides` 參數的[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)重載，以僅檢查渲染特定投影片所需的替代。當您要渲染或匯出投影片的部分內容、逐步檢查大型投影片、找出依賴不可用字型的投影片、為伺服器或容器準備最小字型套件，或在不處理不相關投影片的情況下診斷渲染差異時，這非常有用。

`slides` 陣列包含以 1 為起始索引的投影片編號：`1` 表示第一張投影片。相比之下，[Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) 方法使用零基索引，因此同一張投影片需以 `presentation->get_Slide(0)` 來存取。在建構陣列時請留意此差異，以避免產生一位錯誤。

透過[Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/)方法呼叫該重載。它僅回傳在渲染所選投影片時決定的替代。每個結果都是包含原始與替代字型名稱的[FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/)物件。結果反映了目前的字型環境、已設定的備援規則、儲存在[IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/)中的替代規則，以及[外部載入的字型](/slides/zh-hant/cpp/custom-font/)。

相同的替代可能被多個選取的投影片所需求。在建立字型清單或預檢報告時，請去除重複的結果。以下範例會回報所有回傳的替代，然後建立唯一字型對映的排序清單：

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

[IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) 介面提供兩種重載。請根據渲染作業的範圍選擇使用哪一個：

| 重載 | 使用情境 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | 需要整個投影片的字型替代。 |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | 需要針對選取範圍、增量檢查或部分匯出的字型替代。 |

## **設定字型替代規則**

指定在來源字型不可用時 Aspose.Slides 應使用的字型：

1. 載入投影片。
2. 為來源字型與替代字型建立字型定義。
3. 建立一個具有[WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/)條件的[FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/)。
4. 將規則加入[FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/)。
5. 使用[IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/)方法指派此集合。
6. 渲染或轉換投影片。

以下 C++ 範例在 `SomeRareFont` 不可用時以 `Arial` 取代之，然後渲染第一張投影片以驗證結果。替代字型必須對 Aspose.Slides 可用。

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
若要無條件變更整個投影片中使用的字型，請參閱[字型取代](/slides/zh-hant/cpp/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則是渲染與轉換過程中使用的標準字型選擇流程的一部份。當 Aspose.Slides 能以規則指定的可用字型取代不可存取的字型時，這些規則適用於一般文字。

Office Math 方程式有額外需求。如果方程式使用**Cambria Math**，Aspose.Slides 可能需要該特定字型來計算與渲染方程式版面。使用其他數學字型（例如**STIX Two Math**）的替代規則無法取代**Cambria Math**，因此渲染仍可能顯示需要**Cambria Math**。

若要渲染或轉換此類投影片，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可將其安裝於作業系統或以[外部字型](/slides/zh-hant/cpp/custom-font/)載入。

此限制適用於方程式版面配置。上述的替代規則仍適用於一般投影片文字。

## **FAQ**

**字型取代與字型替代有何不同？**

[字型取代](/slides/zh-hant/cpp/font-replacement/)會在整個投影片中有意地將一種字型更換為另一種字型。字型替代則在符合設定條件（例如原始字型不可用）時，為已渲染的輸出選擇字型。

**什麼時候會套用替代規則？**

這些規則在渲染與轉換期間參與[字型選擇序列](/slides/zh-hant/cpp/font-selection-sequence/)。使用 `WhenInaccessible` 時，僅在 Aspose.Slides 無法存取來源字型時才會套用規則。

**當字型缺失且未設定替代規則時會發生什麼情況？**

Aspose.Slides 會根據其字型選擇流程選取最接近的可用字型。結果取決於執行環境中可取得的字型。

**我能載入外部字型以避免替代嗎？**

可以。您可以[載入外部字型](/slides/zh-hant/cpp/custom-font/)，使 Aspose.Slides 在渲染與轉換期間使用它們。

**Aspose 是否隨函式庫一起分發字型？**

不會。您須自行提供字型並遵守其授權條款。

**替代結果在 Windows、Linux 與 macOS 之間可能不同嗎？**

會。不同作業系統的已安裝字型與字型搜尋位置各異，因而在一台機器上可用的字型可能在另一台機器上需要替代。

**如何在批次轉換時保持字型選擇一致性？**

在每台機器或容器上使用相同的字型檔案與版本，並[載入所需的外部字型](/slides/zh-hant/cpp/custom-font/)，以及在授權允許時[嵌入字型](/slides/zh-hant/cpp/embedded-font/)。您也可以在匯出前呼叫[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)以偵測意外的替代情況。