---
title: 在 C++ 中管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/cpp/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 附加調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中管理簡報主題，以建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填充、線條和效果。支援主題的物件會參考這些共享定義，而不是將每個視覺屬性儲存為固定值，因而在變更主題時可以一次更新多個物件。

在 Aspose.Slides 中，簡報層級的主題可透過[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/)取得。簡報也可以在較低層級包含主題覆寫。母片可透過[MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)覆寫簡報主題，而版面配置或單一投影片可使用[IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/)。實務上，投影片的實際主題是透過以下繼承鏈解析得到：簡報主題、母片覆寫、版面配置覆寫，以及投影片覆寫。

![主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下各節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取實際值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/) 物件會公開主題的[get_ColorScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)、[get_FontScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) 與[get_FormatScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) 方法。在變更之前檢查這些集合特別有用，因為來自外部來源的簡報其樣式條目數量與內容可能不同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少背景、填充、線條與效果樣式：

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

如果檔案使用多個母片，請勿假設每張投影片都有相同的實際主題。檢查與投影片相關的母片，並在可能存在版面配置或投影片覆寫時使用本文後面示範的實際主題工作流程。

## **變更主題顏色**

支援主題的填充、線條和文字可以參考[SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在主題的[IColorScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/icolorscheme/) 中變更對應的條目時，仍參考該主題顏色的所有物件都會解析為新值。使用直接 RGB 顏色的物件不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，儲存簡報，重新開啟，並印出實際的填充顏色：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

因為矩形仍連結到 `Accent4`，所以在主題變更後其可見顏色會變為紅色。如果您在圖形上以直接顏色取代色系顏色，之後對 `Accent4` 的變更將不再影響該填充。

### **使用附加調色盤的顏色**

PowerPoint 會透過顏色變換從主題顏色衍生較亮與較暗的變體。Aspose.Slides 透過[ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/colortransformoperation/)公開這些變換。

![主要主題顏色以及由附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要主題顏色。  
**2** - 由主要主題顏色產生的較亮與較暗變體。

以下範例建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度變換，並儲存結果：

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

這些變體仍以主題顏色為基礎。若 `Accent4` 後續變更，變換後的顏色會以新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而[IColorScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/icolorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 暴露相同的主題插槽。對映關係固定：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些只是同一主題插槽的別名，並非會在執行期間相互轉換的值。

## **變更主題字型**

主題字型方案包含標題用的主要字型集合以及內文用的次要字型集合。`FontScheme::get_Major()` 和 `FontScheme::get_Minor()` 方法會公開這兩個集合。

PowerPoint 相容的主題字型識別碼可用於文字格式化：

* `+mn-lt` - 正文字型 Latin（Minor Latin Font）
* `+mj-lt` - 標題字型 Latin（Major Latin Font）
* `+mn-ea` - 正文字型 East Asian（Minor East Asian Font）
* `+mj-ea` - 標題字型 East Asian（Major East Asian Font）

以下範例建立一個使用主要 Latin 主題字型的標題，及一個使用次要 Latin 主題字型的內文行，然後變更主題字型並儲存結果：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

標題會遵循主要字型，內文則遵循次要字型。使用明確字型名稱（而非主題識別碼）的文字在主題字型方案變更時不會自動切換。

{{% alert color="info" title="Tip" %}}
如需更多關於簡報字型的資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/cpp/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

此處有兩種常見工作流程，解決不同的需求。

### **在移動投影片時保留來源主題**

若要將投影片移至另一個簡報且保留其原始設計，請使用[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/addclone/)將來源母片克隆至目標簡報，接著使用[ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/)將投影片與克隆的母片一起克隆。這會同時攜帶母片、其版面配置及相關主題。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

在需要讓來源投影片在目的地保持相同外觀時，這是首選工作流程。僅將內容克隆到不相關的目的地母片可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保持在目前的母片與版面配置上，請從來源主題初始化投影片層級的覆寫。`OverrideTheme::InitColorSchemeFrom()`、`OverrideTheme::InitFontSchemeFrom()` 與 `OverrideTheme::InitFormatSchemeFrom()` 方法會將三個主要主題元件複製到覆寫中。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

此作業會變更該投影片使用的主題，而不會影響其他投影片繼承的主題。若要移除本機覆寫並回復至繼承值，呼叫 `OverrideTheme::Clear()`。

### **將主題覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面配置的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過版面配置的[IOverrideThemeManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/)使用：

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

當多個版面配置與投影片需要共享相同的基礎設計時，使用母片或簡報層級的主題；當單一版面配置族別需要不同樣式時使用版面配置覆寫；僅在真正的例外情況下才使用投影片覆寫。過度的投影片層級覆寫會讓之後的全域主題變更變得難以預測。

## **更新主題背景樣式**

主題的背景填充儲存在[FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/)。PowerPoint 在 UI 中呈現的背景選項可能多於此集合實際儲存的填充定義，因為 UI 可以將主題填充與主題顏色及其他樣式參考結合。

![PowerPoint 簡報主題的背景樣式庫](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合以及目前的[Background::get_StyleIndex()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/get_styleindex/)。`StyleIndex` 使用 `0` 代表無主題填充；正值則為主題背景樣式的參考。這與使用 `idx_get(0)` 直接索引 C++ 集合不同，後者的 `0` 代表第一筆項目。請勿假設每個簡報都有相同數量的背景填充樣式。

以下範例回報可用的背景填充數量，將第一個母片指派為有主題背景參考，並儲存簡報：

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

最終顯示結果取決於母片參考的主題條目以及版面配置或投影片層級的任何背景覆寫。如果投影片使用自訂背景，僅變更母片背景可能不會影響該投影片。需要取得繼承後的最終背景時，請使用 `Background::GetEffective()`。

{{% alert color="warning" title="Warning" %}}
請勿將 `StyleIndex` 當作零基索引來使用。另外，也不要硬編碼來自單一檔案的樣式編號，並假設在其他檔案中會有相同外觀；主題樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有關直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/cpp/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的[FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)、[FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_linestyles/) 與[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) 集合。典型的 Office 主題往往包含三個主要樣式條目，分別對應微妙、適中與強烈的格式化，但程式碼應檢查每個集合，而非假設固定數量。

![對同一圖形套用微妙、適中與強烈的主題效果](presentation-design_10.png)

在 C++ 中存取這些集合時，集合索引為零基：`idx_get(0)` 為第一筆儲存的樣式，`idx_get(2)` 為第三筆。圖形的樣式參考索引是另一概念，透過[IShapeStyle](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapestyle/) 暴露。修改主題樣式會影響參考該樣式的圖形；直接格式設定的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、第三個填充樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

對於參考這些插槽的圖形而言，第一個主題線條樣式會變為紅色，第三個主題填充樣式會變為實心森林綠，且第三個效果樣式會獲得距離 10 點的外部陰影。實際視覺結果仍取決於每個圖形參考的樣式插槽以及是否有直接格式覆寫。

![變更線條、填充與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取實際主題值**

原始主題物件僅告訴您在特定層級定義了什麼。實際值則告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對於投影片，呼叫[IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)；對於背景，使用[Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/)，對於填充則使用[FillFormat::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/geteffective/)。

以下範例讀取投影片的實際主題、背景與第一個圖形的填充：

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

使用實際資料進行渲染診斷、驗證與比較。若僅檢查[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/)，可能會遺漏母片、版面配置、投影片或圖形的覆寫，從而錯過最終外觀的變化。

## **常見問題**

**我可以在不更改母片的情況下將主題套用到單一投影片嗎？**

可以。使用投影片的[IOverrideThemeManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/) 並初始化其覆寫主題。變更僅會影響該投影片，其他投影片仍會繼承其既有主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片並保留來源外觀時，請將來源母片以[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/addclone/) 克隆至目的地，然後使用[ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 搭配該母片克隆投影片。這樣可同時保留母片、版面配置與主題。

**如何在繼承與覆寫後看到實際的值？**

對於投影片或版面配置的主題使用[IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)，對於格式物件（如 Background 或 FillFormat）則使用對應的實際資料方法，例如[Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/)與[FillFormat::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/geteffective/)。這些 API 會在繼承與覆寫套用後回傳解析後的值。