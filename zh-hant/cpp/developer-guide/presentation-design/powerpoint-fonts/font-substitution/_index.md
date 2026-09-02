---
title: 在 C++ 中配置投影片的字型取代
linktitle: 字型取代
type: docs
weight: 70
url: /zh-hant/cpp/font-substitution/
keywords:
- 字型
- 取代字型
- 字型取代
- 更換字型
- 字型替換
- 取代規則
- 替換規則
- PowerPoint
- OpenDocument
- 投影片
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中，於渲染或轉換 PowerPoint 與 OpenDocument 投影片時，設定字型取代規則並檢查被取代的字型。"
---
## **概觀**

字型取代允許 Aspose.Slides 在投影片呈現或轉換時，使用可用的字型來取代無法存取的字型。取代僅影響呈現的輸出；它不會更改投影片內容所指派的字型。

您可以在特定字型不可用時定義要使用的字型，並且可以檢查 Aspose.Slides 在呈現過程中所做的字型取代。這有助於在安裝字型不同的環境中保持輸出的一致性。

## **取得字型取代**

使用 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 方法來判斷在投影片呈現時會被取代的字型。該方法會傳回 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsubstitutioninfo/) 物件，該物件指出原始字型與取代字型的名稱。

以下 C++ 範例列出投影片的所有字型取代：

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

## **取得選取投影片的字型取代**

使用帶有 `System::ArrayPtr<int32_t> slides` 參數的 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 多載，以僅檢查渲染特定投影片所需的取代。這在您只渲染或匯出投影片的部分、逐步檢查大型投影片、找出依賴不可用字型的投影片、為伺服器或容器準備最小字型套件、或在不處理不相關投影片的情況下診斷呈現差異時，都相當有用。

`slides` 陣列使用以 1 為起始的投影片索引：`1` 代表第一張投影片。相較之下，[Presentation::get_Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_slide/) 方法使用零基索引，因此同一投影片需以 `presentation->get_Slide(0)` 取得。建立陣列時請記得此差異，以避免一位錯誤。

透過 [Presentation::get_FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_fontsmanager/) 方法呼叫此多載。它僅傳回在渲染所選投影片時決定的取代。每個結果都是包含原始與取代字型名稱的 [FontSubstitutionInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsubstitutioninfo/) 物件。結果會反映目前的字型環境、已配置的備援規則、儲存在 [IFontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsubstrulecollection/) 中的取代規則，以及 [externally loaded fonts](/slides/zh-hant/cpp/custom-font/)。

同一取代可能被多個選取的投影片需要。建立字型清單或預檢報告時請去除重複結果。以下範例列出所有回傳的取代，並產生唯一字型對映的排序清單：

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

[IFontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/) 介面提供兩種多載。請依照呈現作業的範圍選擇使用：

| 多載 | 使用時機 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | 您需要整份投影片的字型取代。 |
| [GetSubstitutions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | 您需要針對選取範圍、增量檢查或部分匯出的字型取代。 |

## **設定字型取代規則**

若要指定 Aspose.Slides 在來源字型不可用時應使用的字型：

1. 載入投影片。
2. 為來源字型與取代字型建立字型定義。
3. 使用 [WhenInaccessible](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsubstcondition/) 條件建立 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsubstrule/)。
4. 將規則加入 [FontSubstRuleCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsubstrulecollection/)。
5. 使用 [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) 方法指派此集合。
6. 呈現或轉換投影片。

以下 C++ 範例在 `SomeRareFont` 不可用時以 `Arial` 取代之，然後呈現第一張投影片以驗證結果。取代的字型必須可供 Aspose.Slides 使用。

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
若要無條件變更整份投影片中使用的字型，請參閱 [Font Replacement](/slides/zh-hant/cpp/font-replacement/)。
{{% /alert %}}

## **數學方程式字型的限制**

字型取代規則是呈現與轉換過程中使用的標準字型選擇流程的一部份。當 Aspose.Slides 能以規則指定的可用字型取代不可存取的字型時，這些規則可對一般文字起作用。

Office Math 方程式有額外需求。若方程式使用 **Cambria Math**，Aspose.Slides 可能需要該精確字型來計算與呈現方程式版面。使用其他數學字型（例如 **STIX Two Math**）的取代規則無法取代 **Cambria Math**，因此呈現仍可能顯示需要 **Cambria Math**。

若要呈現或轉換此類投影片，請確保 **Cambria Math** 可供 Aspose.Slides 使用。可在作業系統中安裝，或以 [external font](/slides/zh-hant/cpp/custom-font/) 方式載入。

此限制僅適用於方程式版面。上述的取代規則仍適用於一般投影片文字。

## **常見問題**

**字型取代與字型替換有何不同？**

[Font replacement](/slides/zh-hant/cpp/font-replacement/) 會有意地將投影片中所有使用的字型更換為另一種字型。字型取代則在符合設定條件（例如原始字型不可用）時，為呈現的輸出選擇可用的字型。

**字型取代規則何時套用？**

這些規則會在呈現與轉換期間參與 [font selection sequence](/slides/zh-hant/cpp/font-selection-sequence/)。使用 `WhenInaccessible` 時，規則僅在 Aspose.Slides 無法存取來源字型時套用。

**當字型缺失且未設定取代規則時會發生什麼情況？**

Aspose.Slides 會根據其字型選擇流程選取最接近的可用字型。結果取決於執行環境中可取得的字型。

**我能載入外部字型以避免取代嗎？**

可以。您可 [load external fonts](/slides/zh-hant/cpp/custom-font/) 讓 Aspose.Slides 在呈現與轉換時使用這些字型。

**Aspose 會隨函式庫一起分發字型嗎？**

不會。您需自行提供字型並遵守其授權條款。

**字型取代結果會在 Windows、Linux 與 macOS 之間不同嗎？**

會。不同作業系統之間的已安裝字型與字型搜尋位置不同，於某台機器可用的字型在另一台可能需取代。

**如何在批次轉換中保持字型選擇的一致性？**

在每台機器或容器上使用相同的字型檔案與版本，[load required external fonts](/slides/zh-hant/cpp/custom-font/)，並在授權允許時 [embed fonts](/slides/zh-hant/cpp/embedded-font/)。您亦可在匯出前呼叫 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 以偵測意外的取代情況。