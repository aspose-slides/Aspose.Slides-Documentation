---
title: 在 .NET 中簡化簡報的字型取代
linktitle: 字型取代
type: docs
weight: 60
url: /zh-hant/net/font-replacement/
keywords:
- 字型
- 取代字型
- 字型取代
- 變更字型
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中無縫取代字型，以確保 PowerPoint 與 OpenDocument 簡報的字型排版一致。"
---
## **概述**

Aspose.Slides 允許您在整個簡報中將一種字型取代為另一種字型。當字型被取代時，所有原始字型的出現都會被更改為新字型。

要執行字型取代，請載入簡報、定義來源字型和取代字型、呼叫字型取代方法，並將修改後的簡報儲存為 PPTX 檔案。當您有意在整個簡報中從一個字型家族切換到另一個字型家族時，這種做法非常有用。

## **取代字型**

如果您改變了對字型的使用意願，您可以將該字型取代為另一個字型。舊字型的所有出現都會被新字型取代。

Aspose.Slides 允許您以以下方式取代字型：

1. 載入相關的簡報。  
2. 載入將被取代的字型。  
3. 載入新字型。  
4. 執行字型取代。  
5. 將修改後的簡報寫入為 PPTX 檔案。  

以下 C# 程式碼示範字型取代：

```c#
// 載入簡報
Presentation presentation = new Presentation("Fonts.pptx");

// 載入將被取代的來源字型
IFontData sourceFont = new FontData("Arial");

// 載入新字型
IFontData destFont = new FontData("Times New Roman");

// 取代字型
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// 儲存簡報
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 
若要設定在特定情況下（例如字型無法存取）會發生什麼事的規則，請參閱 [**字型取代**](/slides/zh-hant/net/font-substitution/)。 
{{% /alert %}}

## **常見問題**

**「字型取代」、「字型替代」與「備用字型」之間有何差異？**  
取代是有意在整個文件中將一個字型家族切換為另一個字型家族。[**字型替代**](/slides/zh-hant/net/font-substitution/) 是一種規則，例如「如果字型無法使用，則使用 X」。[**備用字型**](/slides/zh-hant/net/fallback-font/) 則在基礎字型已安裝但缺少所需字元時，針對個別缺少的字形進行手術式的應用。

**取代是否會套用於母片、版面配置、備註與評論？**  
是的。取代會影響所有使用原始字型的簡報物件，包括母片與備註；評論亦屬於文件的一部份，會被字型引擎考慮。

**嵌入的 OLE 物件（例如 Excel）內的字型會改變嗎？**  
不會。[OLE 內容](/slides/zh-hant/net/manage-ole/) 受其自身應用程式控制。簡報中的取代不會重新格式化內部的 OLE 資料；它可能以影像或外部可編輯的內容顯示。

**我可以只在簡報的某部分（依投影片或區域）取代字型嗎？**  
如果在所需的物件/範圍層級變更字型，而非對整個文件套用全域取代，則可以進行針對性的取代。渲染過程中的整體字型選擇邏輯仍保持不變。

**如何提前得知簡報實際使用了哪些字型？**  
使用簡報的 [字型管理員](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/)：它提供使用中的 [字型家族清單](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getfonts/) 以及有關 [替代/「未知」字型](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getsubstitutions/) 的資訊，協助規劃取代作業。

**字型取代在轉換成 PDF/影像時是否有效？**  
是的。在匯出時，Aspose.Slides 會套用相同的 [字型選擇/替代順序](/slides/zh-hant/net/font-selection-sequence/)，因此事先執行的取代會在轉換過程中被遵守。

**我需要在系統中安裝目標字型，還是可以附加字型資料夾？**  
不需要安裝：此函式庫允許從使用者資料夾 [載入外部字型](/slides/zh-hant/net/custom-font/)，以供 [渲染與匯出](/slides/zh-hant/net/convert-powerpoint/) 時使用。

**取代會解決顯示為「豆腐 (方塊)」而非字元的問題嗎？**  
僅當目標字型實際包含所需字形時才會有效。若未包含，請 [設定備用字型](/slides/zh-hant/net/fallback-font/) 以涵蓋缺少的字元。