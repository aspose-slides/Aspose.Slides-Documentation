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
- 額外調色盤
- 主題字體
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 來管理簡報主題，以建立、客製化和轉換具有一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字體、背景樣式、填色、線條與效果。具備主題感知的物件會參照這些共享定義，而不是將每個視覺屬性儲存為固定值，因此變更主題即可一次更新多個物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/) 取得。簡報也可以在較低層級包含主題覆寫。母片可透過 [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) 覆寫簡報主題，而版面配置或個別投影片則可使用 [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/)。實務上，投影片的有效主題是透過以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![主題組成：顏色、字體、背景樣式與效果](theme-constituents.png)

下列章節說明最常見的主題工作流程：檢查主題、變更顏色與字體、複製或套用主題、更新背景與效果樣式，並在繼承與覆寫解析後讀取有效值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/) 物件會公開主題的 [get_ColorScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)、[get_FontScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) 與 [get_FormatScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) 方法。在變更前先檢查這些集合特別有用，因為外部來源的簡報可能在樣式項目的數量與內容上有所不同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少個背景、填色、線條與效果樣式：

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

如果檔案使用了多個母片，切勿假設每張投影片都有相同的有效主題。請檢查與投影片關聯的母片，並在版面配置或投影片可能有覆寫時，使用本文稍後說明的有效主題工作流程。

## **變更主題顏色**

具備主題感知的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在主題的 [IColorScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/icolorscheme/) 中變更相對應的項目時，所有仍參照該主題顏色的物件都會以新值重新解析。直接使用 RGB 顏色的物件不會因主題顏色更新而改變。

以下端對端範例建立一個使用 `Accent4` 的形狀，將主題的 `Accent4` 顏色改為紅色，儲存簡報、重新開啟，並列印有效的填色顏色：

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

因為矩形仍連結至 `Accent4`，主題變更後其可見顏色會變為紅色。如果您在形狀上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用額外調色盤的顏色**

PowerPoint 透過套用顏色變換，從主題色衍生出較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/colortransformoperation/) 公開這些變換。

![主要主題顏色與從額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

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

這些變體仍以主題色為基礎。若 `Accent4` 後續變更，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映到 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 暴露相同的主題插槽。對映固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是同一主題插槽的別名，並非會在執行時相互轉換的值。

## **變更主題字體**

主題字體方案包含標題的主要字體集合與正文的次要字體集合。[FontScheme::get_Major()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/fontscheme/get_major/) 與 [FontScheme::get_Minor()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/fontscheme/get_minor/) 方法會公開這些集合。

PowerPoint 相容的主題字體識別碼可於文字格式化時使用：

* `+mn-lt` - 正文字體拉丁文（Minor Latin Font）
* `+mj-lt` - 標題字體拉丁文（Major Latin Font）
* `+mn-ea` - 正文字體東亞（Minor East Asian Font）
* `+mj-ea` - 標題字體東亞（Major East Asian Font）

以下範例建立一個使用主要拉丁字體的標題與一個使用次要拉丁字體的正文，然後變更主題字體並儲存結果：

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

標題遵循主要字體，正文則遵循次要字體。若文字明確指定了字體名稱而非主題識別碼，則在主題字體方案變更時不會自動切換。

主要與次要字體集合也可以包含針對個別書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與Thaana）的字體映射。若要檢查、添加、取代或移除這些映射，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/cpp/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多簡報字體資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/cpp/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

常見的兩種工作流程解決不同的問題。

### **搬移投影片時保留來源主題**

若要將投影片搬移至其他簡報且保留其原始設計，請使用 [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/addclone/) 將來源母片複製至目標簡報，接著使用 [ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 複製投影片與已複製的母片。這會將母片、其版面配置與關聯的主題一併帶入。

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

此為在目的地必須保持來源投影片外觀的首選工作流程。單純將內容複製至不相關的目的地母片可能會改變主題驅動的顏色、字體、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面配置，請從來源主題初始化投影片層級的覆寫。[OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) 與 [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) 方法會將三個主要主題元件複製到覆寫中。

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

此變更僅會影響該投影片使用的主題，不會改變其他投影片繼承的主題。若要移除本機覆寫並回復至繼承值，請呼叫 [OverrideTheme::Clear()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/clear/)。

### **將主題覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面配置的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過版面配置的 [IOverrideThemeManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/) 使用：

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

當多個版面配置與投影片應共享相同基礎設計時，使用母片或簡報層級的主題；當單一版面配置系列需要不同樣式時，使用版面配置覆寫；僅在真正例外情況下才使用投影片覆寫。過度的投影片層級覆寫會讓日後全域主題變更變得難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/)。PowerPoint 在 UI 中提供的背景選項可能多於此集合實際儲存的填色定義，因為 UI 能將主題填色與主題顏色及其他樣式參照結合。

![PowerPoint 簡報主題的背景樣式庫](presentation-design_8.png)

在使用背景樣式前，請檢查已儲存的集合與目前的 [Background::get_StyleIndex()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/get_styleindex/)。`StyleIndex` 使用 `0` 表示沒有主題填色；正值則是主題背景樣式參照。這與直接以 `idx_get(0)` 取得 C++ 集合項目不同，後者的 `0` 表示第一筆儲存項目。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將主母片的背景參照指派為主題樣式，並儲存簡報：

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

最終呈現結果取決於母片所參照的主題條目，以及版面配置或投影片層級的任何背景覆寫。若投影片使用了自訂背景，只變更母片背景未必會影響該投影片。需要取得套用繼承後的最終背景時，請使用 [Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="Warning" %}}
請勿將 `StyleIndex` 當作零起始的集合索引。也避免硬編碼某檔案的樣式編號並假設在另一檔案中有相同外觀；主題樣式定義是簡報特定的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
欲取得直接的背景格式設定與背景繼承資訊，請參閱 [Presentation Background](/slides/zh-hant/cpp/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含分別的 [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)、[FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_linestyles/)、與 [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) 集合。典型的 Office 主題常包含三個主要樣式項目，視覺上對應為「細膩」(subtle)、「中等」(moderate) 與「強烈」(intense) 的格式，但程式碼應檢查每個集合而非假設固定數量。

![對同一形狀套用細膩、中等與強烈的主題效果](presentation-design_10.png)

在 C++ 中存取這些集合時，集合索引為零起始：`idx_get(0)` 為第一筆儲存的樣式，`idx_get(2)` 為第三筆。形狀的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapestyle/) 暴露。修改主題樣式會影響參照該主題樣式的形狀；直接格式化的形狀則可能保持不變。

以下範例檢查必要的樣式項目是否存在，變更第一個線條樣式、變更第三個填色樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對參照這些插槽的形狀而言，第一個主題線條樣式會變為紅色，第三個主題填色樣式會變為純森林綠，第三個效果樣式會新增距離為 10 點的外部陰影。最終視覺結果仍取決於每個形狀參照的樣式槽以及是否有直接格式覆寫主題。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取有效的主題值**

原始主題物件只告訴您在特定層級定義了什麼。有效值告訴您在繼承與本機覆寫解析後，投影片或形狀實際使用的內容。對投影片而言，呼叫 [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)。對背景使用 [Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/)，對填色則使用 [FillFormat::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/geteffective/)。

以下範例從投影片讀取有效的主題、背景與第一個形狀的填色：

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

使用有效資料進行渲染診斷、驗證與比較。如果只檢查 [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/)，可能會錯過母片、版面配置、投影片或形狀的覆寫，從而遺漏最終外觀的變化。

## **常見問題集**

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用投影片的 [IOverrideThemeManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/) 並初始化其覆寫主題。變更僅限於該投影片，其他投影片仍會繼承既有主題。

**將主題從一個簡報搬移到另一個簡報的最安全方法是什麼？**

在搬移投影片且需保留來源外觀時，先使用 [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/addclone/) 將來源母片複製至目標，然後以相同母片使用 [ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 複製投影片。這樣可確保母片、版面配置與主題一起保留下來。

**如何查看繼承與覆寫後的有效值？**

對投影片或版面配置的主題使用 [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)，對格式物件則使用相應的有效資料方法，例如 [Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/) 與 [FillFormat::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/geteffective/)。這些 API 會回傳在繼承與覆寫套用後解析出的最終值。