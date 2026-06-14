---
title: 在 Android 簡報中精簡字型替換
linktitle: 字型替換
type: docs
weight: 60
url: /zh-hant/androidjava/font-replacement/
keywords:
- 字型
- 替換字型
- 字型替換
- 變更字型
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Aspose.Slides for Android 中無縫替換字型，確保 PowerPoint 與 OpenDocument 簡報的排版一致性。"
---
## **概述**

Aspose.Slides 允許您在整個簡報中將一種字型替換為另一種字型。當字型被替換時，所有原始字型的實例都會改為新字型。

若要執行字型替換，請載入簡報、定義來源字型與替代字型、呼叫字型替換方法，並將修改後的簡報儲存為 PPTX 檔案。此方法在您有意在整個簡報中從一個字型系列切換到另一個字型系列時非常有用。

## **取代字型**

如果您改變使用某個字型的想法，您可以將該字型替換為另一個字型。舊字型的所有實例都會被新字型取代。

Aspose.Slides 允許您以此方式取代字型：

1. 載入相關的簡報。 
2. 載入將被取代的字型。 
3. 載入新的字型。 
4. 取代字型。 
5. 將修改後的簡報寫入為 PPTX 檔案。

以下 Java 程式碼示範字型取代：

```java
// 載入簡報
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 載入將被取代的來源字型
    IFontData sourceFont = new FontData("Arial");
    
    // 載入新字型
    IFontData destFont = new FontData("Times New Roman");
    
    // 取代字型
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // 儲存簡報
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
若要設定在特定條件下（例如無法存取字型）會發生何種行為的規則，請參閱 [**字型替代**](/slides/zh-hant/androidjava/font-substitution/)。
{{% /alert %}}

## **常見問題**

**「字型替換」、「字型替代」與「後備字型」之差異為何？**

替換是跨整個文件將一個字型系列有意切換為另一個字型系列。[替代](/slides/zh-hant/androidjava/font-substitution/) 是類似「如果字型不可用，使用 X」的規則。[後備](/slides/zh-hant/androidjava/fallback-font/) 則在基礎字型已安裝但不含所需字元時，針對個別缺失的字形進行外科式的應用。

**替換是否適用於母片投影片、版面配置、備註與評論？**

是的。替換會影響所有使用原始字型的簡報物件，包括母片投影片與備註；評論也是文件的一部份，會被字型引擎考慮。

**嵌入的 OLE 物件（例如 Excel）內的字型會改變嗎？**

不會。[OLE 內容](/slides/zh-hant/androidjava/manage-ole/) 由其各自的應用程式控制。簡報中的替換不會重新格式化內部 OLE 資料；它可能顯示為圖像或作為可外部編輯的內容。

**我可以僅在簡報的部分（依投影片或區域）替換字型嗎？**

若在所需的物件/範圍層級變更字型，而非對整個文件套用全域替換，即可進行目標式替換。渲染時的整體字型選擇邏輯保持不變。

**我該如何事先了解簡報使用了哪些字型？**

使用簡報的 [font manager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/)：它提供使用中的 [字型系列清單](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/#getFonts--) 以及關於 [替代/「未知」字型](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--) 的資訊，有助於規劃替換。

**字型替換在轉換為 PDF/影像時仍會生效嗎？**

是的。在匯出時，Aspose.Slides 會套用相同的 [字型選擇/替代順序](/slides/zh-hant/androidjava/font-selection-sequence/)，因此事前執行的替換會在轉換過程中被遵守。

**我需要在系統中安裝目標字型，還是可以附加字型資料夾？**

不需要安裝：此函式庫允許從使用者資料夾 [載入外部字型](/slides/zh-hant/androidjava/custom-font/)，以供 [渲染與匯出](/slides/zh-hant/androidjava/convert-powerpoint/) 時使用。

**替換能解決「豆腐」方塊（顯示為方塊）問題嗎？**

僅當目標字型確實包含所需字形時才會解決。若不包含，請 [設定後備](/slides/zh-hant/androidjava/fallback-font/) 以補足缺少的字元。