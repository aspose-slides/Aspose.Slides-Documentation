---
title: 在 C++ 中建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/cpp/wordart/
keywords:
- WordArt
- 建立 WordArt
- WordArt 範本
- WordArt 效果
- 陰影效果
- 顯示效果
- 發光效果
- WordArt 變形
- 3D 效果
- 外部陰影效果
- 內部陰影效果
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中建立與自訂 WordArt 效果。此逐步指南協助開發人員使用 C++ 以專業文字增強簡報。"
---
## **概觀**

WordArt 效果讓您可以在 PowerPoint 簡報中加入視覺上吸引人、風格化的文字。使用 Aspose.Slides，開發人員可以以程式方式建立、自訂與管理 WordArt，就像在 Microsoft PowerPoint 中一樣——不需要安裝 Office。本篇文章概述了使用 WordArt 的方法，包括如何套用文字變形、填色樣式、輪廓、陰影以及其他格式設定，讓您的簡報內容更具表現力且更具吸引力。WordArt 允許您將文字視為圖形物件。它是對文字套用的各種效果或特殊變更，使文字更具吸引力或更顯眼。

## **建立簡易 WordArt 範本並套用至文字**

**使用 Aspose.Slides** 

首先，我們使用以下 C++ 程式碼建立簡單的文字：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

接著，我們將文字的字型高度設定為較大值，以便讓效果更明顯，程式碼如下：

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**使用 Microsoft PowerPoint**

前往 Microsoft PowerPoint 中的 WordArt 效果功能表：

![todo:image_alt_text](image-20200930113926-1.png)

在右側功能表中，您可以選擇預先定義的 WordArt 效果；在左側功能表中，您可以為新的 WordArt 指定設定。

以下是部分可用的參數或選項：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在此，我們使用以下程式碼將 SmallGrid 圖案色套用至文字，並加入寬度為 1 的黑色文字邊框：

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

產生的文字如下：

![todo:image_alt_text](image-20200930114108-4.png)

## **套用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程式介面中，您可以將這些效果套用至文字、文字方塊、圖形或類似的元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，陰影、反射與發光效果可套用至文字；3D 格式與 3D 旋轉效果可套用至文字方塊；柔和邊緣屬性可套用至圖形物件（即使未設定 3D 格式屬性仍會產生效果）。

### **將陰影效果套用至文字**

此處我們僅設定與文字相關的屬性，使用以下 C++ 程式碼將陰影效果套用至文字：

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Aspose.Slides API 支援三種陰影類型：OuterShadow、InnerShadow 與 PresetShadow。

使用 PresetShadow 時，您可以使用預設值將陰影套用至文字。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，僅能使用一種陰影類型。以下為範例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 實際上允許同時套用兩種陰影：InnerShadow 與 PresetShadow。

**注意：**

- 當同時使用 OuterShadow 與 PresetShadow 時，僅會套用 OuterShadow 效果。  
- 若同時使用 OuterShadow 與 InnerShadow，最終套用的效果取決於 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果會加倍；而在 PowerPoint 2007 中，僅套用 OuterShadow 效果。

### **套用反射效果**

我們使用以下 C++ 程式碼在文字上加入反射：

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **套用發光效果**

我們使用以下程式碼將發光效果套用至文字，使其更加閃耀或突顯：

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

操作結果如下：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以變更陰影、顯示與發光的參數。這些效果的屬性會分別設定於文字的每個區段。 

{{% /alert %}} 

### **在 WordArt 中使用變形**

我們透過以下程式碼使用 set_Transform 方法（套用於整個文字區塊）：

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

結果如下：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 與 Aspose.Slides for C++ 皆提供一定數量的預定義變形類型。 

{{% /alert %}} 

**使用 PowerPoint**

要存取預定義的變形類型，請依序點選：**Format** → **TextEffect** → **Transform**

**使用 Aspose.Slides**

要選取變形類型，請使用 TextShapeType 列舉。

### **將 3D 效果套用至文字與圖形**

我們使用以下範例程式碼將 3D 效果套用至文字圖形：

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

產生的文字與其圖形如下：

![todo:image_alt_text](image-20200930114816-9.png)

我們使用以下 C++ 程式碼將 3D 效果套用至文字：

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

操作結果如下：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

將 3D 效果套用於文字或其圖形，以及不同效果之間的交互，皆遵循特定規則。

請將文字與其所在圖形視為一個場景。3D 效果包含 3D 物件的表現以及放置該物件的場景。

- 當圖形與文字皆設定了場景時，圖形的場景優先級較高，文字的場景會被忽略。  
- 若圖形本身沒有場景但具備 3D 表現，則使用文字的場景。  
- 否則——當圖形原本沒有 3D 效果時，圖形保持平面，3D 效果僅套用於文字。  

這些說明與 ThreeDFormat.getLightRig() 與 ThreeDFormat.getCamera() 方法相關。

{{% /alert %}} 

## **將外部陰影效果套用至圖形**
Aspose.Slides for C++ 提供 [**IOuterShadow**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.effects.i_outer_shadow) 與 [**IInnerShadow**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.effects.i_inner_shadow) 介面，讓您可以將陰影效果套用至 TextFrame 所攜帶的文字。請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 在投影片中加入矩形類型的 AutoShape。  
4. 取得該 AutoShape 關聯的 TextFrame。  
5. 將 AutoShape 的 FillType 設為 NoFill。  
6. 實例化 OuterShadow 類別。  
7. 設定陰影的 BlurRadius。  
8. 設定陰影的 Direction。  
9. 設定陰影的 Distance。  
10. 將 RectanglelAlign 設為 TopLeft。  
11. 將陰影的 PresetColor 設為 Black。  
12. 將簡報寫入為 PPTX 檔案。

以下 C++ 範例程式碼示範了上述步驟，說明如何將外部陰影效果套用至文字：

``` cpp
auto pres = System::MakeObject<Presentation>();
// 取得投影片的參考
auto sld = pres->get_Slides()->idx_get(0);

// 新增矩形類型的 AutoShape
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 為矩形加入 TextFrame
ashp->AddTextFrame(u"Aspose TextBox");

// 停用形狀填色，以便取得文字的陰影
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 新增外部陰影並設定所有必要參數
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// 將簡報寫入磁碟
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **將內部陰影效果套用至圖形**
請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。  
2. 取得投影片的參考。  
3. 加入矩形類型的 AutoShape。  
4. 啟用 InnerShadowEffect。  
5. 設定所有必要的參數。  
6. 將 ColorType 設為 Scheme。  
7. 設定 Scheme Color。  
8. 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下範例程式碼（根據上述步驟）示範了如何在 C++ 中於兩個圖形之間新增連接器：

``` cpp
auto presentation = System::MakeObject<Presentation>();
// 取得投影片的參考
auto slide = presentation->get_Slides()->idx_get(0);

// 新增矩形類型的 AutoShape
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 為矩形新增 TextFrame
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// 啟用 InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// 設定所有必要參數
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// 設定 ColorType 為 Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// 設定 Scheme 顏色
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// 儲存簡報
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **常見問題集**

**我可以在不同字型或文字系統（例如阿拉伯文、中文）上使用 WordArt 效果嗎？**

可以，Aspose.Slides 支援 Unicode，並可與所有主要的字型與文字系統一起使用。陰影、填色與輪廓等 WordArt 效果不受語言限制，儘管字型可用性與渲染會依系統安裝的字型而異。

**我可以將 WordArt 效果套用至投影片母片元素嗎？**

可以，您可以將 WordArt 效果套用至母片投影片上的圖形，包括標題佔位元、頁尾或背景文字。對母片版面的變更會反映在所有相關投影片上。

**WordArt 效果會影響簡報檔案大小嗎？**

會有輕微影響。陰影、發光與漸層填色等 WordArt 效果會因為增加了格式化的中繼資料而稍微增大檔案大小，但差異通常可以忽略不計。

**我能在未儲存簡報的情況下預覽 WordArt 效果的結果嗎？**

可以，您可以使用 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 介面的 `GetImage` 方法，將包含 WordArt 的投影片渲染為圖像（例如 PNG、JPEG），從而在記憶體或螢幕上預覽結果，無需先儲存或匯出完整簡報。