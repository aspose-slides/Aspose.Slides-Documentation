---
title: 使用 Java 簡化簡報中的字型替換
linktitle: 字型替換
type: docs
weight: 60
url: /zh-hant/java/font-replacement/
keywords:
- 字型
- 替換字型
- 字型替換
- 更改字型
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中無縫替換字型，以確保 PowerPoint 與 OpenDocument 簡報的排版一致性。"
---
## **概述**

Aspose.Slides 允許您在整個簡報中將一種字型替換為另一種字型。當字型被替換時，所有原始字型的實例都會被新字型取代。

要執行字型替換，請載入簡報，定義來源字型和替換字型，呼叫字型替換方法，並將修改後的簡報儲存為 PPTX 檔案。當您有意在整個簡報中從一個字型系列切換到另一個字型系列時，此方法非常有用。

## **取代字型**

如果您改變了使用某種字型的想法，您可以將該字型替換為另一種字型。舊字型的所有實例都會被新字型取代。

Aspose.Slides 允許您以以下方式替換字型：

1. 載入相關的簡報。  
2. 載入將被替換的字型。  
3. 載入新的字型。  
4. 執行字型替換。  
5. 將修改後的簡報寫入為 PPTX 檔案。  

此 Java 程式碼示範字型替換：

```java
// 載入簡報
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 載入將被替換的來源字型
    IFontData sourceFont = new FontData("Arial");
    
    // 載入新的字型
    IFontData destFont = new FontData("Times New Roman");
    
    // 替換字型
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // 儲存簡報
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

若要設定在特定條件（例如無法存取字型）下的處理規則，請參閱 [**字型替代**](/slides/zh-hant/java/font-substitution/)。 

{{% /alert %}}

## **常見問題**

**字型替換、字型替代與回退字型之間有何差異？**

替換是有意在整個文件中將一個字型系列換成另一個字型系列。[替代](/slides/zh-hant/java/font-substitution/) 是類似「如果字型不可用，使用 X」的規則。[回退](/slides/zh-hant/java/fallback-font/) 則在基礎字型已安裝但缺少特定字元時，針對單個缺失的字形進行處理。

**替換會套用到母片、版面配置、備註與評論嗎？**

會。替換會影響所有使用原始字型的簡報物件，包括母片與備註；評論也是文件的一部份，會被字型引擎考慮。

**嵌入的 OLE 物件（例如 Excel）內的字型會改變嗎？**

不會。[OLE 內容](/slides/zh-hant/java/manage-ole/) 受其自身應用程式控制。簡報中的替換不會重新格式化內部 OLE 資料；它可能以影像或可外部編輯的內容顯示。

**我可以只在簡報的部分（依投影片或區域）替換字型嗎？**

如果在所需的物件/範圍層級調整字型，而不是對整個文件執行全域替換，就可以實現針對性的替換。渲染時的整體字型選取邏輯仍保持不變。

**如何事先確定簡報使用了哪些字型？**

使用簡報的 [字型管理員](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/)：它提供 [正在使用的系列](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#getFonts--) 清單以及有關 [替代/「未知」字型](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#getSubstitutions--) 的資訊，協助規劃替換。

**在轉換為 PDF/影像時，字型替換仍會生效嗎？**

會。匯出時，Aspose.Slides 會套用相同的 [字型選取/替代順序](/slides/zh-hant/java/font-selection-sequence/)，因此事先執行的替換在轉換過程中會被遵守。

**需要在系統中安裝目標字型，還是可以附加字型資料夾？**

不需要安裝：此函式庫允許從使用者資料夾 [載入外部字型](/slides/zh-hant/java/custom-font/)，以供 [渲染與匯出](/slides/zh-hant/java/convert-powerpoint/) 使用。

**替換能解決顯示為「豆腐方塊」（方塊）而非字元的問題嗎？**

只有當目標字型實際包含所需字形時才會有效。若無，請 [設定回退](/slides/zh-hant/java/fallback-font/) 以涵蓋缺失的字元。