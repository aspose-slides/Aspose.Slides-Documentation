---
title: 管理 C++ 中的簡報主題
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
- 外部主題
- THMX
- 主題顏色
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中掌握簡報主題，以建立、 自訂 並轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填滿、線條與效果。具備主題感知的物件會參照這些共享定義，而不是將每個視覺屬性儲存為固定值，這樣變更主題即可一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/)取得。簡報也可以在較低層級套用主題覆寫。母片可透過[MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)覆寫簡報主題，而版面或單一投影片則可使用[IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/)。實務上，投影片的實際主題是透過以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下章節展示最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，並在繼承與覆寫完成後讀取實際值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/) 物件會公開主題的[get_ColorScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)、[get_FontScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) 與 [get_FormatScheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) 方法。變更之前先檢查這些集合特別有用，因為從外部來源取得的簡報可能在樣式項目的數量與內容上有所不同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少個背景、填滿、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的實際主題。檢查與投影片相關的母片，並在版面或投影片可能有覆寫時，使用本章稍後說明的實際主題工作流程。

## **變更主題顏色**

具備主題感知的填滿、線條與文字可以參照[SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在主題的[IColorScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/icolorscheme/) 中變更對應項目時，所有仍參照該主題顏色的物件都會以新值重新解析。直接使用 RGB 顏色的物件不會因主題顏色更新而改變。

以下端對端範例建立一個使用 `Accent4` 的形狀，將主題的 `Accent4` 顏色改為紅色，儲存簡報後重新開啟，並列印實際的填充顏色：

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

因為矩形仍連結到 `Accent4`，當主題變更後其可見顏色會變為紅色。若您將形狀的配色改為直接顏色，之後對 `Accent4` 的變更將不再影響該填充。

### **使用「額外調色盤」的顏色**

PowerPoint 會透過顏色變換從主題顏色衍生較亮與較暗的變體。Aspose.Slides 透過[ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/colortransformoperation/)公開這些變換。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主題的主要顏色。  
**2** - 由主要主題顏色產生的較亮與較暗變體。

以下範例建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度變換，然後儲存結果：

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

這些變體仍以主題顏色為基礎。若 `Accent4` 稍後變更，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而[IColorScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 曝露相同的主題槽位。對映關係固定：

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

這些是同一主題槽位的別名，並非會在執行時相互轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與內文的次要字型集合。[FontScheme::get_Major()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/fontscheme/get_major/) 與 [FontScheme::get_Minor()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/fontscheme/get_minor/) 方法會公開這些集合。

PowerPoint 相容的主題字型識別碼可在文字格式設定中使用：

* `+mn-lt` - 內文字型拉丁文（Minor Latin Font）  
* `+mj-lt` - 標題字型拉丁文（Major Latin Font）  
* `+mn-ea` - 內文字型東亞（Minor East Asian Font）  
* `+mj-ea` - 標題字型東亞（Major East Asian Font）

以下範例建立一個使用主要拉丁字型的標題與一個使用次要拉丁字型的內文，然後變更主題字型並儲存結果：

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

標題會遵循主要字型，內文則遵循次要字型。若文字明確指定字型名稱而非主題識別碼，則在主題字型方案變更時不會自動切換。

主要與次要字型集合也可能包含針對特定書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與塔納字母）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱[Script-Specific Theme Fonts](/slides/zh-hant/cpp/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得有關簡報字型的更多資訊，請參閱[PowerPoint Fonts](/slides/zh-hant/cpp/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至母片所依賴的投影片**

當您擁有 PowerPoint 主題檔 (`.thmx`) 且想重新樣式化所有依賴特定母片的投影片時，請使用[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/)。從[Presentation::get_Masters](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_masters/)集合（實作[IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/)）中選取母片，並將主題檔路徑傳入該方法。

此方法執行以下操作：

1. 依所選母片建立新母片。  
2. 將外部主題套用至新母片。  
3. 將先前依賴所選母片的所有投影片指派給新母片。  
4. 回傳新建立的[IMasterSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/)。

以下範例將外部主題套用至第一個母片所依賴的投影片，並儲存簡報：

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

無效、損毀或不支援的主題可能拋出[PptxException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxexception/)或其格式相關子類別。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在主題成功套用後才儲存簡報。

只有依賴所選母片的投影片會被重新指派。屬於其他母片的投影片會保留其既有母片與主題。具備主題感知的顏色、字型、填滿、線條、背景與效果會根據外部主題重新解析。直接指定的顏色、字型、填滿等顯式格式可能保持不變。版面層級與投影片層級的覆寫亦可能優先於新母片繼承的值。

主題可能參照執行環境中不存在的字型。為確保一致的呈現與匯出，請安裝所需字型、透過[custom font sources](/slides/zh-hant/cpp/custom-font/) 提供，或設定[font substitution](/slides/zh-hant/cpp/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，無需手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當事先不知道相關母片時，可透過[ISlide::get_LayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/get_layoutslide/) 以及[ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_masterslide/) 從具代表性的投影片取得母片。套用任何主題前請先保存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片找出其母片，並對每組套用不同的外部主題：

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

第一次呼叫僅影響依賴 `firstGroupMaster` 的投影片，第二次呼叫僅影響依賴 `secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **搬移投影片時保留來源主題**

若要將投影片移至另一個簡報且保留其原始設計，請先使用[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/addclone/)將來源母片複製至目標簡報，然後使用[ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/)將投影片與已複製的母片一起複製。如此即可同時攜帶母片、版面與相關主題。

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

這是在目標簡報中必須保持相同外觀時的首選工作流程。僅將內容克隆至不相關的目標母片可能會改變主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，可從來源主題初始化投影片層級的覆寫。使用[OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) 與[OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) 方法將三大主題元件複製至覆寫。

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

此變更只會影響該投影片使用的主題，而不會改變其他投影片繼承的主題。若要移除本地覆寫並回復繼承值，請呼叫[OverrideTheme::Clear()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/overridetheme/clear/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的所有投影片，除非特定投影片有自己的覆寫。可透過版面的[IOverrideThemeManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/) 使用相同的初始化方法：

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

當多個版面與投影片需共享相同基礎設計時，使用母片或簡報層級的主題；若只有一個版面族需要不同樣式，則使用版面覆寫；僅在真正例外的情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填充儲存在[FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/)。PowerPoint 在 UI 中提供的背景選項可能多於此集合實際儲存的填充定義，因為 UI 可以將主題填充與主題顏色及其他樣式參照組合。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

使用背景樣式前，請先檢查已儲存的集合與目前的[Background::get_StyleIndex()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/get_styleindex/)。`StyleIndex` 使用 `0` 表示無主題填充；正值代表主題背景樣式參照。這與直接以 `idx_get(0)` 取得 C++ 集合時的索引概念不同，後者的 `0` 表示第一筆儲存的項目。請勿假設每個簡報都有相同數量的背景填充樣式。

以下範例回報可用的背景填充數量，將主題化的背景參照指派給第一個母片，並儲存簡報：

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

最終顯示結果取決於母片所參照的主題條目，以及版面或投影片層級的任何背景覆寫。若投影片自行設定背景，只變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用[Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="Warning" %}}
請勿將 `StyleIndex` 當作零基索引使用。也不要從一個檔案硬編碼樣式編號，並假設在另一個檔案中會有相同外觀；主題樣式定義是針對簡報而定的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有關直接背景格式設定與背景繼承，請參閱[Presentation Background](/slides/zh-hant/cpp/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的[FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)、[FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_linestyles/) 與[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) 集合。典型的 Office 主題常包含三個主要樣式條目，分別對應微妙、適中與強烈的視覺效果，但程式碼應檢查每個集合，而非假設固定數量。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 C++ 中存取這些集合時，索引為零基：`idx_get(0)` 為第一筆儲存的樣式，`idx_get(2)` 為第三筆。形狀的樣式參照索引則是另一概念，透過[IShapeStyle](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapestyle/) 暴露。修改主題樣式會影響所有參照該樣式的形狀；直接格式設定的形狀可能保持不變。

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

對於參照這些槽位的形狀而言，第一個主題線條樣式會變成紅色，第三個主題填充樣式會變成實心森林綠，第三個效果樣式會獲得距離 10 點的外部陰影。最終的視覺結果仍取決於每個形狀參照的樣式槽位以及是否有直接格式覆寫。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **讀取實際主題值**

原始主題物件僅告訴您在特定層級上定義了什麼。實際值則告訴您投影片或形狀在繼承與本地覆寫解析後實際使用的內容。對投影片呼叫[IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)。對背景使用[Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/)，對填充使用[FillFormat::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/geteffective/)。

以下範例讀取投影片的實際主題、背景與第一個形狀的填充：

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

使用實際資料可協助進行渲染診斷、驗證與比較。若只檢查[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_mastertheme/)，可能會錯過母片、版面、投影片或形狀的覆寫，從而遺失最終外觀。

## **常見問答**

**套用外部主題會影響簡報中的每一張投影片嗎？**

不會。[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) 僅重新指派依賴選取母片的投影片。使用其他母片的投影片會保留其既有主題。

**我可以只對單一投影片套用主題而不更改母片嗎？**

可以。使用該投影片的[IOverrideThemeManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ioverridethememanager/) 並初始化其覆寫主題。變更僅限於該投影片，本簡報的其他投影片會繼續繼承原先的主題。

**將主題從一個簡報攜帶到另一個簡報的最安全方式是什麼？**

在搬移投影片且需保留來源外觀時，先使用[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/addclone/) 將來源母片複製至目標簡報，然後使用[ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 連同該母片一起複製投影片。如此即可同時保留母片、版面與主題。

**如何查看繼承與覆寫後的實際值？**

對投影片或版面主題呼叫[IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)，對格式物件（如[Background::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/background/geteffective/) 與[FillFormat::GetEffective()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/geteffective/)）使用相應的實際資料方法。這些 API 會回傳在繼承與覆寫完成後解析出的值。