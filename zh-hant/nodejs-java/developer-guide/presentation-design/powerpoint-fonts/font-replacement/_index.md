---
title: 使用 JavaScript 簡化簡報中的字型取代
linktitle: 字型取代
type: docs
weight: 60
url: /zh-hant/nodejs-java/font-replacement/
keywords:
- 字型
- 取代字型
- 字型取代
- 變更字型
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "透過 Java 在 Node.js 的 Aspose.Slides 中無縫以 JavaScript 取代字型，確保 PowerPoint 與 OpenDocument 簡報中的排版一致。"
---
## **概述**

Aspose.Slides 允許您在整個簡報中將一種字型取代為另一種字型。取代字型時，原始字型的所有實例都會變更為新字型。

若要執行字型取代，請載入簡報、定義來源字型與取代字型、呼叫字型取代方法，然後將修改後的簡報儲存為 PPTX 檔案。當您有意在整個簡報中將一個字型系列切換為另一個字型系列時，此方法相當有用。

## **取代字型**

如果您改變了使用特定字型的想法，您可以將該字型取代為另一個字型。舊字型的所有實例都會被新字型取代。

Aspose.Slides 允許您以以下方式取代字型：

1. 載入相關的簡報。  
2. 載入將被取代的字型。  
3. 載入新字型。  
4. 執行字型取代。  
5. 將修改後的簡報寫入為 PPTX 檔案。  

此 JavaScript 程式碼示範字型取代：

```javascript
// 載入簡報
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 載入將被取代的來源字型
    var sourceFont = new aspose.slides.FontData("Arial");
    // 載入新字型
    var destFont = new aspose.slides.FontData("Times New Roman");
    // 取代字型
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // 儲存簡報
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
若要設定在特定情況下（例如無法存取字型）會發生什麼的規則，請參閱 [**字型取代**](/slides/zh-hant/nodejs-java/font-substitution/)。
{{% /alert %}}

## **常見問題**

**「字型取代」、 「字型替代」與「備用字型」之間有何差異？**  
取代是有意在整個文件中將一個字型系列切換為另一個字型系列。[**字型替代**](/slides/zh-hant/nodejs-java/font-substitution/) 是類似「如果字型不可用，則使用 X」的規則。[**備用字型**](/slides/zh-hant/nodejs-java/fallback-font/) 則在基礎字型已安裝但缺少所需字元時，針對個別缺少的字形進行手術式的應用。

**取代會套用到母片、佈局、備註與評論嗎？**  
是的。取代會影響所有使用原始字型的簡報物件，包括母片與備註；評論亦屬於文件的一部份，會被字型引擎考慮。

**嵌入的 OLE 物件（例如 Excel）內的字型會改變嗎？**  
不會。[**OLE 內容**](/slides/zh-hant/nodejs-java/manage-ole/) 由其自身的應用程式控制。簡報內的取代不會重新格式化內部 OLE 資料；它可能以影像或外部可編輯的內容顯示。

**我可以只在簡報的部分（如投影片或區域）取代字型嗎？**  
如果您在需要的物件/範圍層級變更字型，而非對整個文件套用全域取代，則可以進行目標化的取代。渲染過程中的整體字型選擇邏輯仍保持不變。

**如何事先確定簡報使用了哪些字型？**  
使用簡報的 [字型管理員](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/)：它會提供使用中的 [字型系列](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getfonts/) 和關於 [取代/「未知」字型](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 的資訊，這有助於規劃取代工作。

**字型取代在轉換為 PDF/圖像時會生效嗎？**  
會的。匯出時，Aspose.Slides 會套用相同的 [字型選擇/取代順序](/slides/zh-hant/nodejs-java/font-selection-sequence/)，因此事先執行的取代會在轉換過程中受到尊重。

**我需要在系統中安裝目標字型，還是可以附加字型資料夾？**  
不需要安裝：此函式庫允許從使用者資料夾 [載入外部字型](/slides/zh-hant/nodejs-java/custom-font/)，以在 [渲染與匯出](/slides/zh-hant/nodejs-java/convert-powerpoint/) 時使用。

**取代會解決「豆腐字」（方框）而非字元的問題嗎？**  
僅當目標字型確實包含所需字形時才會有效。若不包含，請[設定備用字型](/slides/zh-hant/nodejs-java/fallback-font/) 以涵蓋缺失的字元。