---
title: 使用 C++ 簡化投影片中的字型取代
linktitle: 字型取代
type: docs
weight: 60
url: /zh-hant/cpp/font-replacement/
keywords:
- 字型
- 取代字型
- 字型取代
- 變更字型
- PowerPoint
- OpenDocument
- 投影片
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中無縫取代字型，確保 PowerPoint 與 OpenDocument 投影片的排版一致性。"
---
## **概述**

Aspose.Slides 允許您在整個投影片中將一種字型取代為另一種字型。取代字型後，所有原始字型的出現都會變更為新字型。

要執行字型取代，請載入投影片，定義來源字型與取代字型，呼叫字型取代方法，並將修改後的投影片儲存為 PPTX 檔案。當您有意在整份投影片中從一個字型系列切換到另一個時，此方法非常有用。

## **取代字型**

如果您改變使用字型的想法，您可以將該字型取代為其他字型。所有舊字型的出現都會被新字型取代。

Aspose.Slides 允許您以以下方式取代字型：

1. 載入相關的投影片。  
2. 載入將被取代的字型。  
3. 載入新字型。  
4. 執行字型取代。  
5. 將修改後的投影片寫入為 PPTX 檔案。

以下 C++ 程式碼示範字型取代：

``` cpp
// 載入投影片
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 載入將被取代的來源字型
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// 載入新字型
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// 取代字型
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// 儲存投影片
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
若要設定在特定情況下的規則（例如無法存取字型），請參閱 [**字型替代**](/slides/zh-hant/cpp/font-substitution/)。 
{{% /alert %}}

## **常見問題**

**「字型取代」、「字型替代」與「備援字型」之差異為何？**  
取代是有意在整份文件中從一個字型系列切換到另一個。 [字型替代](/slides/zh-hant/cpp/font-substitution/) 是在字型不可用時使用 X 的規則。 [備援字型](/slides/zh-hant/cpp/fallback-font/) 則在基礎字型已安裝但缺少特定字元時，針對個別缺失的字形進行手術式的套用。

**取代是否會套用到母片、佈局、備註與評論？**  
是的。取代會影響所有使用原始字型的投影片物件，包括母片與備註；評論亦屬於文件的一部份，會被字型引擎考慮在內。

**嵌入的 OLE 物件（例如 Excel）內的字型會被變更嗎？**  
不會。[OLE 內容](/slides/zh-hant/cpp/manage-ole/) 受其自身應用程式控制。投影片中的取代不會重新格式化內部 OLE 資料；它可能以影像或可外部編輯的內容顯示。

**我能只在投影片的部份（依投影片或區域）取代字型嗎？**  
若在所需的物件/範圍層級變更字型，而非對整份文件執行全域取代，即可實現有目標的取代。渲染過程中的整體字型選擇邏輯保持不變。

**如何事先判定投影片使用了哪些字型？**  
使用投影片的 [字型管理器](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/)：它提供 [使用中的字型系列](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/getfonts/) 清單，以及關於 [替代/「未知」字型](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/getsubstitutions/) 的資訊，協助規劃取代作業。

**字型取代在轉換為 PDF/影像時是否有效？**  
會的。在匯出過程中，Aspose.Slides 會套用相同的 [字型選取/替代順序](/slides/zh-hant/cpp/font-selection-sequence/)，因此事先執行的取代會在轉換時被遵守。

**我需要在系統中安裝目標字型，還是可以附加字型資料夾？**  
不需要安裝：此函式庫允許從使用者資料夾 [載入外部字型](/slides/zh-hant/cpp/custom-font/)，以供 [渲染與匯出](/slides/zh-hant/cpp/convert-powerpoint/) 時使用。

**取代會解決「豆腐」字（方塊）而非正確字元的情況嗎？**  
僅當目標字型確實包含所需字形時才會。若不包含，請 [設定備援字型](/slides/zh-hant/cpp/fallback-font/) 以補足缺少的字元。