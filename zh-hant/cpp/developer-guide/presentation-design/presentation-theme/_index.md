---
title: 在 C++ 中管理簡報佈景主題
linktitle: 簡報佈景主題
type: docs
weight: 10
url: /zh-hant/cpp/presentation-theme/
keywords:
- PowerPoint 佈景主題
- 簡報佈景主題
- 投影片佈景主題
- 設定佈景主題
- 變更佈景主題
- 管理佈景主題
- 外部佈景主題
- THMX
- 佈景色彩
- 附加調色盤
- 佈景字型
- 佈景樣式
- 佈景效果
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中使用母片簡報佈景主題，以建立、客製化並轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一套協調的顏色、字型、背景樣式、填色、線條與效果。具備佈景感知功能的物件會參照這些共享的定義，而不是將每個視覺屬性儲存為固定值，因而在變更佈景時能一次更新許多物件。

在 Aspose.Slides 中，簡報層級的佈景可透過[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/)取得。簡報亦可在較低層級包含佈景覆寫。母片可透過[MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)覆寫簡報佈景，而版面或單一投影片則可使用[IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/)。實務上，投影片的有效佈景會透過以下繼承鏈解析：簡報佈景 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下章節說明最常見的佈景工作流程：檢查佈景、變更顏色與字型、複製或套用佈景、更新背景與效果樣式，以及在繼承與覆寫解析完成後讀取有效值。

## **檢查佈景**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/) 物件會公開佈景的 [get_ColorScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)、[get_FontScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) 與 [get_FormatScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) 方法。變更前先檢查這些集合特別有用，因為從外部來源取得的簡報，其樣式項目的數量與內容可能各異。

以下範例讀取主要佈景屬性，並回報佈景中儲存的背景、填色、線條與效果樣式數量：

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

如果檔案使用多個母片，切勿假設每張投影片都有相同的有效佈景。請檢查與該投影片相關的母片，並在版面或投影片可能有覆寫時，使用本文稍後說明的有效佈景工作流程。

## **變更佈景顏色**

具佈景感知的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在佈景的 [IColorScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/icolorscheme/) 中變更相對應的項目時，所有仍參照該佈景顏色的物件都會以新值解析。直接使用 RGB 顏色的物件不會受到佈景顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將佈景的 `Accent4` 顏色改為紅色，儲存簡報、重新開啟，並列印有效填色：

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

因為矩形仍連結至 `Accent4`，佈景變更後其顯示顏色會變紅。若您在圖形上以直接顏色取代配色，之後對 `Accent4` 的變更就不會再影響該填色。

### **使用附加調色盤的顏色**

PowerPoint 會透過顏色變換從佈景顏色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/colortransformoperation/) 提供這些變換。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主要佈景顏色。  

**2** - 由主要佈景顏色產生的較亮與較暗變體。

以下範例建立六個基於 `Accent4` 的矩形，對其中五個套用亮度變換，最後儲存結果：

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

這些變體仍以佈景顏色為基礎。如果稍後 `Accent4` 變更，變換後的顏色會依新 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 欄位**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/icolorscheme/) 則將相同佈景欄位稱為 `Dark1`、`Light1`、`Dark2`、`Light2`，對映固定如下：

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

這些只是同一佈景欄位的別名，並非會在執行時相互轉換的值。

## **變更佈景字型**

佈景字型方案包含標題的主要字型集合與內文的次要字型集合。[FontScheme::get_Major()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/fontscheme/get_major/) 與 [FontScheme::get_Minor()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/fontscheme/get_minor/) 方法會公開這兩套字型。

PowerPoint 相容的佈景字型識別碼可直接用於文字格式設定：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）  
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）  
* `+mn-ea` - 內文字型 East Asian（次要 East Asian 字型）  
* `+mj-ea` - 標題字型 East Asian（主要 East Asian 字型）

以下範例建立一個使用主要 Latin 佈景字型的標題與一行使用次要 Latin 佈景字型的內文，然後變更佈景字型並儲存結果：

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

標題遵循主要字型，內文字則遵循次要字型。若文字使用了明確的字型名稱而非佈景識別碼，則在佈景字型方案變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與 Thaana）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/cpp/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多簡報字型資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/cpp/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用佈景**

以下工作流程解決不同的佈景相關問題。

### **將外部佈景套用至母片所依賴的投影片**

當您擁有 PowerPoint 佈景檔 (`.thmx`) 且想為所有依賴特定母片的投影片重新樣式時，請使用 [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/)。先從 [Presentation::get_Masters](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_masters/) 集合（實作自 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/)）選取母片，然後將佈景檔路徑傳入該方法。

此方法執行以下操作：

1. 以選取的母片建立新母片投影片。  
1. 將外部佈景套用至新母片。  
1. 將先前依賴選取母片的所有投影片指派至新母片。  
1. 回傳新建立的 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/)。

以下範例將外部佈景套用至依賴第一個母片的投影片，並儲存簡報：

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

無效、損毀或不受支援的佈景可能會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxexception/) 或其格式相關子類別。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在佈景成功套用後再儲存簡報。

僅會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其現有母片與佈景。具佈景感知的顏色、字型、填色、線條、背景與效果會依外部佈景解析；直接指派的顏色、字型、填色與其他明確格式可能保持不變。版面層級與投影片層級的覆寫亦可能優先於新母片繼承的值。

佈景可能參照執行環境中不存在的字型。為確保一致的呈現與匯出，請安裝所需字型、透過 [custom font sources](/slides/zh-hant/cpp/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/cpp/font-substitution/)。

這是一個純母片層級的工作流程：方法接受 `.thmx` 檔案路徑，無需自行建立投影片層級或版面層級的佈景覆寫。

### **在多母片簡報中套用不同的外部佈景**

當事先不知道相關母片時，請透過 [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/get_layoutslide/) 與 [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_masterslide/) 從代表性投影片取得母片。於套用任何佈景之前先儲存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個區段的投影片找出它們的母片，並分別為每個群組套用不同的外部佈景：

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

第一次呼叫僅影響依賴 `firstGroupMaster` 的投影片，第二次呼叫僅影響依賴 `secondGroupMaster` 的投影片。屬於其他母片的投影片不會重新樣式。

### **搬移投影片時保留來源佈景**

若要將投影片移至另一個簡報，同時保留其原始設計，請先用 [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/addclone/) 將來源母片克隆至目標簡報，接著以 [ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 及克隆後的母片克隆投影片。這會同時帶入母片、其版面以及相關佈景。

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

此流程在目標投影片必須與來源外觀相同時最為理想。僅僅將內容克隆至不相關的目標母片可能會改變佈景驅動的顏色、字型、背景與效果。

### **將佈景值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，可從來源佈景初始化投影片層級的覆寫。使用 [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) 與 [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) 方法將三個主要佈景組件複製到覆寫中。

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

此操作會變更該投影片使用的佈景，而不影響其他投影片繼承的佈景。若要移除本機覆寫並回復繼承值，請呼叫 [OverrideTheme::Clear()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/clear/)。

### **將佈景覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的所有投影片，除非特定投影片有自己的覆寫。可透過版面的 [IOverrideThemeManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/) 使用相同的初始化方法：

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

在需要許多版面與投影片共享相同基礎設計時，請使用母片或簡報層級的佈景；當單一版面族需要不同樣式時，使用版面覆寫；僅在真實例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域佈景變更難以預測。

## **更新佈景背景樣式**

佈景的背景填色儲存在 [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/)。PowerPoint 在 UI 中可能呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 能將佈景填色與佈景顏色及其他樣式參照結合。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

使用背景樣式前，請檢查儲存的集合以及目前的 [Background::get_StyleIndex()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/get_styleindex/)。`StyleIndex` 為 `0` 表示無佈景填色；正值則為佈景背景樣式參照。這與以 `idx_get(0)` 直接索引 C++ 集合不同，後者的 `0` 代表第一個儲存項目。切勿假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將佈景背景參照指派給第一個母片，並儲存簡報：

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

最終顯示結果取決於母片參照的佈景項目以及版面或投影片層級的任何背景覆寫。若投影片使用自己的背景，只變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用 [Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="Warning" %}}
請勿將 `StyleIndex` 視為零基集合索引。也避免硬編碼某檔案的樣式編號，然後假設在其他檔案中呈現相同外觀；佈景樣式定義是簡報特有的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
欲了解直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/cpp/presentation-background/)。
{{% /alert %}}

## **更新佈景效果**

佈景格式方案包含獨立的 [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)、[FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_linestyles/)、以及 [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) 集合。典型的 Office 佈景常包含三個主要樣式條目，分別對應微妙、適中與強烈的格式化，但程式碼應檢查每個集合，而非假設固定數量。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 C++ 中存取這些集合時，索引是零基的：`idx_get(0)` 為第一個儲存的樣式，`idx_get(2)` 為第三個。圖形的樣式參照索引則是另一概念，由 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapestyle/) 暴露。變更佈景樣式會影響參照該佈景樣式的圖形；直接格式化的圖形可能保持不變。

以下範例確認必要的樣式條目存在，變更第一個線條樣式、變更第三個填色樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對參照這些槽位的圖形而言，第一個佈景線條樣式會變為紅色，第三個佈景填色樣式會變為實心森林綠，第三個效果樣式會加入距離 10 點的外部陰影。最終視覺效果仍取決於每個圖形參照的樣式槽位以及直接格式化是否覆寫佈景。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **判斷有效實心填色是否使用佈景顏色**

填色可以直接儲存在物件上，或由段落、版面、母片、佈景樣式或其他格式層級繼承而來。呼叫 [IFillFormat::GetEffective](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifillformat/geteffective/) 可將該層級階層解析為不可變的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifillformateffectivedata/)。首先檢查 [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifillformateffectivedata/get_filltype/)。僅當它為 `FillType::Solid` 時才讀取實心填色屬性。

對於實心填色，[IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) 會在繼承、佈景查找與顏色變換完成後，回傳最終呈現的 RGB 值。[IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) 會回傳對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 槽位，例如 `Text1` 或 `Accent6`。若值為 `SchemeColor::NotDefined`，表示有效實心填色並非基於配色。於僅使用佈景顏色或直接 RGB 顏色的流程中，該值即代表直接 RGB 填色。

不要僅依賴本機的 [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icolorformat/get_schemecolor/) 來分類填色。例如，文字片段可能本機未定義配色，故其本機值為 `NotDefined`，但其有效填色可能繼承自佈景顏色，最終解析為 `Text1` 或 `Accent6`。相對地，`get_SolidFillSchemeColor` 只能告訴您是哪個邏輯佈景槽位產生了有效顏色，卻無法說明該槽位來源於哪個層級（物件、段落、版面、母片或其他）。

以下範例載入簡報，稽核形狀填色與文字片段填色，列印每個最終 RGB 值與相關的配色槽位，並標記不會追蹤佈景顏色變更的實心填色：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

`NotDefined` 分支會列出那些在佈景配色變更時不會更新的實心填色。請在簡報必須遵循新品牌調色盤時檢查這些物件。回報的 RGB 值仍顯示當前外觀，而配色值說明了該外觀是否與佈景相連。

有效格式物件是快照。變更簡報佈景、佈景覆寫或任何繼承格式後，請再次呼叫 `GetEffective`，取得新的 `IFillFormatEffectiveData` 物件，再進行顏色比較或報告。

## **讀取有效佈景值**

原始佈景物件只告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對於投影片，呼叫 [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)。對於背景，使用 [Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/)，對於填色則使用 [FillFormat::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/geteffective/)。

以下範例從投影片讀取有效佈景、背景與第一個形狀的填色：

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

使用有效資料進行渲染診斷、驗證與比較。如果僅檢查 [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/)，可能會錯過母片、版面、投影片或圖形的覆寫，從而遺漏最終外觀的變更。

## **常見問題集**

**套用外部佈景會影響簡報中的每張投影片嗎？**

不會。[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其現有佈景。

**可以在不變更母片的情況下，將佈景套用至單一投影片嗎？**

可以。使用該投影片的 [IOverrideThemeManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/)，初始化其覆寫佈景。變更僅限於該投影片，其餘投影片仍會繼承既有佈景。

**將佈景從一個簡報搬移至另一個簡報的最安全方式是什麼？**

搬移投影片且保留來源外觀時，請先以 [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/addclone/) 將來源母片克隆至目標簡報，然後使用 [ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 與該母片克隆投影片。此方式會同時保留母片、版面與佈景。

**如何查看繼承與覆寫後的有效值？**

對投影片或版面佈景使用 [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)，對格式物件則使用相應的有效資料方法，例如 [Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/) 與 [FillFormat::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/geteffective/)。這些 API 會在繼承與覆寫完成後回傳解析後的值。