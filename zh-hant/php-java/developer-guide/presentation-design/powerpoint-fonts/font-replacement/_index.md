---
title: 使用 PHP 精簡簡報中的字型取代
linktitle: 字型取代
type: docs
weight: 60
url: /zh-hant/php-java/font-replacement/
keywords:
- 字型
- 取代字型
- 字型取代
- 變更字型
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: 透過 Java 在 Aspose.Slides for PHP 中無縫取代字型，以確保 PowerPoint 與 OpenDocument 簡報的排版一致。
---
## **概觀**

Aspose.Slides 讓您在整個簡報中將一種字型取代為另一種字型。取代字型後，所有原始字型的實例都會變更為新字型。

要執行字型取代，請載入簡報、定義來源字型與取代字型、呼叫字型取代方法，然後將修改後的簡報儲存為 PPTX 檔案。當您有意在整個簡報中從一個字型系列切換到另一個時，此方法非常有用。

## **取代字型**

如果您改變了使用某個字型的想法，可以將該字型取代為其他字型。舊字型的所有實例都會被新字型取代。

Aspose.Slides 讓您以此方式取代字型：

1. 載入相關的簡報。  
2. 載入將被取代的字型。  
3. 載入新字型。  
4. 執行字型取代。  
5. 將修改後的簡報寫入為 PPTX 檔案。

```php
  # 載入簡報
  $pres = new Presentation("Fonts.pptx");
  try {
    # 載入將被取代的來源字型
    $sourceFont = new FontData("Arial");
    # 載入新字型
    $destFont = new FontData("Times New Roman");
    # 取代字型
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # 儲存簡報
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
若要設定在特定情況下（例如無法存取字型）會發生什麼的規則，請參閱 [**字型置換**](/slides/zh-hant/php-java/font-substitution/)。 
{{% /alert %}}

## **常見問題**

**「字型取代」、「字型置換」與「回退字型」之間有何差異？**

取代是有意在整個文件中從一個系列切換到另一個系列。[置換](/slides/zh-hant/php-java/font-substitution/) 是「如果字型不可用，使用 X」的規則。[回退](/slides/zh-hant/php-java/fallback-font/) 在缺少特定字形時，以外科式方式套用於單一缺失的字形，前提是基底字型已安裝但未包含所需字元。

**取代會套用到母片投影片、版面配置、備註與評論嗎？**

會。取代會影響所有使用原始字型的簡報物件，包括母片投影片與備註；評論亦屬文件的一部分，會由字型引擎考慮。

**嵌入的 OLE 物件（例如 Excel）內的字型會變更嗎？**

不會。[OLE 內容](/slides/zh-hant/php-java/manage-ole/) 受其自身應用程式控制。簡報中的取代不會重新格式化 OLE 內部資料；它可能以影像或外部可編輯內容的形式顯示。

**我可以只在簡報的部分（依投影片或區域）取代字型嗎？**

若在所需的物件/範圍層級變更字型，而非對整個文件執行全域取代，即可實現目標式取代。渲染期間的整體字型選擇邏輯保持不變。

**我要如何事先確定簡報使用了哪些字型？**

使用簡報的[字型管理器](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/)：它會提供正在使用的[使用中的字型系列](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getfonts/)清單，以及有關[置換/「未知」字型](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/getsubstitutions/)的資訊，協助規劃取代工作。

**在轉換為 PDF/映像時，字型取代仍會生效嗎？**

會。匯出時，Aspose.Slides 會套用相同的[字型選取/置換序列](/slides/zh-hant/php-java/font-selection-sequence/)，因此事先執行的取代會在轉換過程中得到遵守。

**我需要在系統中安裝目標字型，還是可以附加字型資料夾？**

不需要安裝：函式庫允許從使用者資料夾[載入外部字型](/slides/zh-hant/php-java/custom-font/)以供[渲染與匯出](/slides/zh-hant/php-java/convert-powerpoint/)使用。

**取代會解決「豆腐字」（方塊）而非字元的問題嗎？**

只有在目標字型實際包含所需字形時才會解決。若不包含，請[設定回退字型](/slides/zh-hant/php-java/fallback-font/)以涵蓋缺失的字元。