---
title: 使用 Python 透過 Java 簡化簡報中的字型取代
linktitle: 字型取代
type: docs
weight: 60
url: /zh-hant/python-java/font-replacement/
keywords:
- 字型
- 取代字型
- 字型取代
- 變更字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中無縫取代字型，以確保 PowerPoint 與 OpenDocument 簡報的字體排版一致。"
---
## **概觀**

Aspose.Slides 允許您在整個簡報中將一種字型取代為另一種字型。字型被取代後，所有原始字型的實例都會變更為新字型。

若要執行字型取代，請載入簡報，定義來源字型與取代字型，呼叫字型取代方法，並將修改後的簡報儲存為 PPTX 檔案。當您有意在整個簡報中從一個字型族切換到另一個字型族時，這種方法非常有用。

## **取代字型**

如果您改變了使用字型的想法，可以將該字型取代為另一個字型。舊字型的所有實例都會被新字型取代。

Aspose.Slides 允許您以以下方式取代字型：

1. 載入相關的簡報。  
2. 載入要被取代的字型。  
3. 載入新字型。  
4. 執行字型取代。  
5. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Python 程式碼示範字型取代：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# 載入簡報。
presentation = Presentation("Fonts.pptx")
try:
    # 載入將被取代的來源字型。
    source_font = FontData("Arial")

    # 載入新字型。
    destination_font = FontData("Times New Roman")

    # 取代字型。
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # 儲存簡報。
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}  
若要設定在特定情況（例如無法存取字型）下的規則，請參閱 [Font Substitution](/slides/zh-hant/python-java/font-substitution/)。  
{{% /alert %}}

## **常見問題**

**「字型取代」與「字型替代」以及「備用字型」有何差異？**  
取代是指在整個文件中有意將一個字型族切換為另一個字型族。[Substitution](/slides/zh-hant/python-java/font-substitution/) 是一種規則，例如「如果字型不可用，則使用 X」。[Fallback](/slides/zh-hant/python-java/fallback-font/) 則在基礎字型已安裝但不包含所需字元時，針對個別缺失的字形套用備用字型。

**取代會影響母版投影片、版面配置、筆記與註解嗎？**  
會。取代會影響所有使用原始字型的簡報物件，包括母版投影片與筆記；註解也是文件的一部份，會被字型引擎考慮。

**內嵌的 OLE 物件（例如 Excel）內的字型會變更嗎？**  
不會。[OLE content](/slides/zh-hant/python-java/manage-ole/) 由其自身的應用程式控制。簡報中的取代不會重新格式化內部的 OLE 資料；它可能會以影像或可外部編輯的內容顯示。

**我能只在簡報的某部分（依投影片或區域）取代字型嗎？**  
若在需要的物件/範圍層級變更字型，而非對整個文件套用全域取代，即可實現針對性的取代。渲染過程中的整體字型選擇邏輯保持不變。

**我如何事先判斷簡報使用了哪些字型？**  
使用簡報的 [font manager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/)：它提供正在使用的字型族清單以及有關 [substitutions/"未知"字型](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#getSubstitutions) 的資訊，協助規劃取代作業。

**字型取代在轉換為 PDF/影像時會生效嗎？**  
會。匯出時，Aspose.Slides 會套用相同的 [font selection/substitution sequence](/slides/zh-hant/python-java/font-selection-sequence/)，因此事先執行的取代會在轉換過程中得到遵守。

**我需要在系統中安裝目標字型，還是可以附加字型資料夾？**  
不需要安裝：該函式庫允許從使用者資料夾 [loading external fonts](/slides/zh-hant/python-java/custom-font/)，以便在 [rendering and export](/slides/zh-hant/python-java/convert-powerpoint/) 時使用。

**取代會解決顯示為「豆腐塊」(方塊) 而非字元的問題嗎？**  
僅當目標字型實際包含所需字形時才會解決。若不包含，請 [configure fallback](/slides/zh-hant/python-java/fallback-font/) 以補足缺少的字元。