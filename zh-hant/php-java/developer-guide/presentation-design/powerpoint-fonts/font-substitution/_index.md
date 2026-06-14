---
title: 使用 PHP 在簡報中設定字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/php-java/font-substitution/
keywords:
- 字型
- 替代字型
- 字型替代
- 取代字型
- 字型取代
- 替代規則
- 取代規則
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在使用 Java 的 Aspose.Slides for PHP 中，於將 PowerPoint 與 OpenDocument 簡報轉換為其他檔案格式時，啟用最佳的字型替代。"
---
## **簡介**

字型替代允許 Aspose.Slides 在渲染或轉換過程中，當原始簡報的字型不可用時使用其他字型。您可以使用 `FontsManager` 類別的 `getSubstitutions` 方法檢查哪些字型已被替代。

Aspose.Slides 也允許您定義字型替代規則。例如，您可以指定當字型無法存取時，應使用另一個可用的字型來取代，然後透過簡報的字型管理員套用這些規則。

## **設定字型替代規則**

Aspose.Slides 允許您設定字型規則，用以決定在特定情況下（例如字型無法存取）應執行的動作，方式如下：

1. 載入相關的簡報。
2. 載入將被取代的字型。
3. 載入新的字型。
4. 為取代動作新增規則。
5. 將規則加入簡報的字型取代規則集合中。
6. 產生投影片影像以觀察效果。

以下 PHP 程式碼示範字型替代的流程：

```php
  # 載入簡報
  $pres = new Presentation("Fonts.pptx");
  try {
    # 載入將被取代的來源字型
    $sourceFont = new FontData("SomeRareFont");
    # 載入新字型
    $destFont = new FontData("Arial");
    # 新增字型取代規則
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # 將規則加入字型取代規則集合
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # 將字型規則集合加入規則清單
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # 當來源字型無法存取時，將使用 Arial 取代 SomeRareFont
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 將影像以 JPEG 格式儲存至磁碟
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="NOTE"  color="warning"   %}} 
您可能想查看 [**字型取代**](/slides/zh-hant/php-java/font-replacement/)。 
{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則會參與渲染和轉換期間使用的標準字型選擇程序。它們適用於一般文字情況，Aspose.Slides 能根據已設定的規則將無法存取的字型替換為其他可用字型。

然而，Office 數學方程式有一項重要限制。如果方程式是以 **Cambria Math** 建立的，Aspose.Slides 仍可能需要原始的 **Cambria Math** 字型才能正確計算並渲染方程式版面。因此，將 **Cambria Math** 替換為其他數學字型（例如 **STIX Two Math**）在方程式渲染時不受支援，並可能仍拋出表示需要 **Cambria Math** 的例外。

要成功轉換此類簡報，請確保 **Cambria Math** 在執行階段可供 Aspose.Slides 使用。您可以將字型安裝到作業系統，或以 [外部字型](/slides/zh-hant/php-java/custom-font/) 形式提供，使其能在渲染與轉換時參與正常的字型選擇程序。

此限制僅適用於方程式渲染。上述的標準字型替代規則仍然適用於原始字型無法存取的普通簡報文字。

## **常見問題**

**字型取代與字型替代有何差異？**  
[取代](/slides/zh-hant/php-java/font-replacement/) 是在整個簡報中強制將一種字型覆寫為另一種字型。替代則是一條在特定條件下觸發的規則，例如原始字型不可用時，會使用指定的備用字型。

**替代規則到底何時套用？**  
這些規則參與在載入、渲染與轉換期間評估的標準 [字型選擇](/slides/zh-hant/php-java/font-selection-sequence/) 序列；若所選字型不可用，則會套用取代或替代。

**如果未設定取代或替代，且系統上缺少字型，預設行為是什麼？**  
程式庫會嘗試選擇最接近的可用系統字型，行為類似於 PowerPoint。

**我能在執行時附加自訂外部字型以避免替代嗎？**  
可以。您可以在執行時 [新增外部字型](/slides/zh-hant/php-java/custom-font/)，讓程式庫在選擇與渲染時考慮這些字型，亦包括後續的轉換。

**Aspose 會隨程式庫一起分發任何字型嗎？**  
不會。Aspose 不會隨程式庫分發付費或免費字型；字型的加入與使用需由您自行決定並自行負責。

**Windows、Linux 與 macOS 的替代行為有差異嗎？**  
有。字型的偵測會從作業系統的字型目錄開始。各平台的預設可用字型集合與搜尋路徑不同，這會影響字型的可用性與是否需要替代。

**如何準備環境以減少批次轉換時意外的替代？**  
在機器或容器之間同步字型集合，[新增外部字型](/slides/zh-hant/php-java/custom-font/) 以滿足輸出文件的需求，並在可能的情況下於簡報中 [嵌入字型](/slides/zh-hant/php-java/embedded-font/)，確保所選字型在渲染時可用。