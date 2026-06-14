---
title: "使用 Python 精簡簡報中的字型取代"
linktitle: "字型取代"
type: docs
weight: 60
url: /zh-hant/python-net/font-replacement/
keywords:
- 字型
- 取代字型
- 字型取代
- 變更字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "透過 .NET 在 Aspose.Slides Python 中無縫取代字型，確保 PowerPoint 與 OpenDocument 簡報的排版一致。"
---
## **概觀**

Aspose.Slides 允許您在整個簡報中將一種字型取代為另一種字型。當字型被取代時，所有原始字型的實例都會改為新字型。

要執行字型取代，請載入簡報，定義來源字型與取代字型，呼叫字型取代方法，然後將修改後的簡報儲存為 PPTX 檔案。此方法在您希望將整個簡報從一個字型系列切換到另一個字型系列時非常實用。

## **取代字型**

如果您改變了對字型的使用想法，可以將該字型取代為另一個字型。舊字型的所有實例都會被新字型取代。

Aspose.Slides 允許您以以下方式取代字型：

1. 載入相關的簡報。 
2. 載入將被取代的字型。 
3. 載入新的字型。 
4. 執行字型取代。 
5. 將修改後的簡報寫入為 PPTX 檔案。

以下 Python 程式碼示範字型取代：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# 載入簡報
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 載入將被取代的來源字型
    sourceFont = slides.FontData("Arial")

    # 載入新字型
    destFont = slides.FontData("Times New Roman")

    # 取代字型
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # 儲存簡報
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
若要設定在特定情況（例如無法存取字型）下的處理規則，請參閱[**字型取代**](/slides/zh-hant/python-net/font-substitution/)。 
{{% /alert %}}

## **常見問題**

**「字型取代」與「字型替代」以及「備用字型」有何差異？**

取代是指在整個文件中有意將一個系列換成另一個系列。[替代](/slides/zh-hant/python-net/font-substitution/) 是類似「如果字型不可用，則使用 X」的規則。[備用](/slides/zh-hant/python-net/fallback-font/) 則在個別缺少字形時使用，當基礎字型已安裝但不包含所需字元時會套用。

**取代會影響母片、版面配置、註解與備註嗎？**

會。取代會影響所有使用原始字型的簡報物件，包括母片與註解；備註也是文件的一部份，會被字型引擎考慮。

**字型會在嵌入的 OLE 物件（例如 Excel）內改變嗎？**

不會。[OLE 內容](/slides/zh-hant/python-net/manage-ole/) 受其自身應用程式控制。簡報中的取代不會重新格式化 OLE 內部資料；它可能以影像或可外部編輯的內容呈現。

**我可以只在簡報的部份（例如特定投影片或區域）取代字型嗎？**

如果在所需的物件/範圍層級變更字型，而非對整個文件套用全域取代，則可以進行目標取代。渲染時的整體字型選擇邏輯仍保持不變。

**如何事先了解簡報到底使用了哪些字型？**

使用簡報的[字型管理員](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/)：它會提供[使用中的字型系列](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_fonts/)清單，以及[替代或「未知」字型](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/get_substitutions/)資訊，協助規劃取代作業。

**在轉換為 PDF/影像時，字型取代會有效嗎？**

會。匯出時，Aspose.Slides 會套用相同的[字型選擇/替代順序](/slides/zh-hant/python-net/font-selection-sequence/)，因此事先執行的取代會在轉換時遵守。

**我需要在系統中安裝目標字型，還是可以附加字型資料夾？**

不需要安裝：函式庫允許從使用者資料夾[載入外部字型](/slides/zh-hant/python-net/custom-font/)，以供[渲染與匯出](/slides/zh-hant/python-net/convert-powerpoint/)使用。

**取代能解決顯示「豆腐」方塊而非字元的問題嗎？**

只有在目標字型實際包含所需字形時才會解決。若不包含，請[設定備用字型](/slides/zh-hant/python-net/fallback-font/)以覆蓋缺失的字元。