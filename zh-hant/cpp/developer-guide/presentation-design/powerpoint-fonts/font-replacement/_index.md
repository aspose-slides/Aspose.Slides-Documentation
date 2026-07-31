---
title: 使用 C++ 簡化簡報中的字型取代
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
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中無縫取代字型，以確保 PowerPoint 與 OpenDocument 簡報的排版一致性。"
---
## **概覽**

Aspose.Slides 允許您在整個簡報中將一種字型取代為另一種字型。當字型被取代時，所有原始字型的實例都會被更改為新字型。

要執行字型取代，請載入簡報、定義來源字型與取代字型、呼叫字型取代方法，並將修改後的簡報儲存為 PPTX 檔案。當您有意在整個簡報中從一個字型族切換到另一個字型族時，此方法非常有用。

## **取代字型**

如果您改變了使用字型的想法，您可以將該字型取代為其他字型。所有舊字型的實例將會被新字型取代。

Aspose.Slides 允許您以以下方式取代字型：

1. 載入相關的簡報。  
2. 載入將被取代的字型。  
3. 載入新字型。  
4. 執行字型取代。  
5. 將修改後的簡報寫出為 PPTX 檔案。

以下 C++ 程式碼示範字型取代：

```cpp
// 載入簡報
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 載入將被取代的來源字型
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// 載入新字型
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// 取代字型
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// 儲存簡報
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

若要設定在特定情況下（例如無法存取字型）會發生什麼的規則，請參閱 [**字型替代**](/slides/zh-hant/cpp/font-substitution/)。 

{{% /alert %}}

## **常見問題**

**「字型取代」、「字型替代」與「備援字型」之差異為何？**

取代是有意在整個文件中將一個字型族切換為另一個字型族。[字型替代](/slides/zh-hant/cpp/font-substitution/) 是類似「若字型不可用，使用 X」的規則。[備援字型](/slides/zh-hant/cpp/fallback-font/) 則在基礎字型已安裝但缺少所需字符時，針對個別缺少的字形進行手術式的應用。

**取代是否會套用至母片投影片、版面配置、備註與註解？**

是的。取代會影響所有使用原始字型的簡報物件，包括母片投影片與備註；註解也是文件的一部份，字型引擎會考慮它們。

**嵌入的 OLE 物件（例如 Excel）內的字型會變更嗎？**

不會。[OLE 內容](/slides/zh-hant/cpp/manage-ole/) 由其自身的應用程式控制。簡報中的取代不會重新格式化內部 OLE 資料；它可能會以影像或可在外部編輯的內容顯示。

**我可以僅在簡報的部份（依投影片或區域）取代字型嗎？**

如果在所需的物件/範圍層級變更字型，而非對整個文件套用全域取代，則可進行目標式取代。渲染過程中的整體字型選擇邏輯保持不變。

**我該如何事先判斷簡報使用了哪些字型？**

使用簡報的 [字型管理員](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/)：它會提供使用中的 [字型族清單](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/getfonts/) 以及關於 [替代/「未知」字型](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/getsubstitutions/) 的資訊，協助規劃取代工作。

**在轉換為 PDF/影像時，字型取代會生效嗎？**

會。匯出時，Aspose.Slides 會套用相同的 [字型選擇/替代順序](/slides/zh-hant/cpp/font-selection-sequence/)，因此事先執行的取代會在轉換過程中得到遵守。

**我需要在系統中安裝目標字型，或是可以附加字型資料夾嗎？**

不需要安裝：此函式庫允許從使用者資料夾 [載入外部字型](/slides/zh-hant/cpp/custom-font/)，以供 [渲染與匯出](/slides/zh-hant/cpp/convert-powerpoint/) 時使用。

**取代會解決顯示方塊（「tofu」）而非字元的問題嗎？**

僅當目標字型實際包含所需字形時才會生效。若不包含，請 [設定備援字型](/slides/zh-hant/cpp/fallback-font/) 以補足缺少的字符。