---
title: 使用 Python 在簡報中設定字型替代
linktitle: 字型替代
type: docs
weight: 70
url: /zh-hant/python-net/font-substitution/
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
- Python
- Aspose.Slides
description: "在使用 .NET 的 Python Aspose.Slides 中啟用最佳字型替代，將 PowerPoint 與 OpenDocument 簡報轉換為其他檔案格式時。"
---
## **概觀**

字型替代允許 Aspose.Slides 在渲染或轉換期間，當原始簡報的字型不可用時使用其他字型。您可以透過 `FontsManager` 類別的 `get_substitutions` 方法檢查哪些字型被替代。

Aspose.Slides 也允許您定義字型替代規則。例如，您可以指定將無法存取的字型替換為另一個可用的字型，然後透過簡報的字型管理員套用這些規則。

## **設定替代規則**

Aspose.Slides 讓您以以下方式為字型設定在特定情況下（例如無法存取字型）要執行的規則：

1. 載入相關的簡報。
2. 載入將被取代的字型。
3. 載入新字型。
4. 為取代新增規則。
5. 將規則加入簡報字型取代規則集合。
6. 產生投影片影像以觀察效果。

以下 Python 程式碼示範字型替代流程：

```python
import aspose.slides as slides

# 載入簡報
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 載入將被取代的來源字型
    sourceFont = slides.FontData("SomeRareFont")

    # 載入新字型
    destFont = slides.FontData("Arial")

    # 新增字型取代規則
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # 將規則加入字型替代規則集合
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # 將字型規則集合加入規則清單
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # 在無法存取 SomeRareFont 時，將使用 Arial 字型取代
    with presentation.slides[0].get_image(1, 1) as bmp:
        # 將影像以 JPEG 格式儲存至磁碟
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 

您可能想參閱[**字型取代**](/slides/zh-hant/python-net/font-replacement/)。 

{{% /alert %}}

## **數學方程式字型的限制**

字型替代規則會參與渲染與轉換期間的標準字型選取流程。它們適用於一般文字情境，Aspose.Slides 可以依照設定的規則將無法存取的字型替換為其他可用字型。

然而，Office 數學方程式有一項重要限制。若方程式是使用 **Cambria Math** 建立，Aspose.Slides 仍可能需要原始的 **Cambria Math** 字型才能正確計算與渲染方程式版面。基於此，將 **Cambria Math** 替換為其他數學字型（例如 **STIX Two Math**）不支援方程式渲染，仍可能導致例外，指出需要 **Cambria Math**。

若要成功轉換此類簡報，請確保執行時 Aspose.Slides 可取得 **Cambria Math**。您可以在作業系統中安裝該字型，或將其作為[外部字型](/slides/zh-hant/python-net/custom-font/)提供，使其能在渲染與轉換期間參與正常的字型選取流程。

此限制僅針對方程式渲染。上述的標準字型替代規則仍適用於原始字型無法取得時的普通簡報文字。

## **常見問題**

**字型取代與字型替代有何不同？**

[取代](/slides/zh-hant/python-net/font-replacement/) 是在整個簡報中將一種字型強制覆寫為另一種字型。替代則是當特定條件發生時（例如原始字型不存在），根據設定的備援字型使用規則。

**替代規則到底何時會套用？**

這些規則參與在載入、渲染與轉換期間評估的標準[字型選取](/slides/zh-hant/python-net/font-selection-sequence/)序列；如果選取的字型不可用，則會套用取代或替代。

**如果系統上缺少字型，且未設定取代或替代，預設行為是什麼？**

程式庫會嘗試選取最相近的可用系統字型，類似 PowerPoint 的行為。

**我可以在執行時附加自訂外部字型以避免替代嗎？**

可以。您可以在執行時[加入外部字型](/slides/zh-hant/python-net/custom-font/)，讓程式庫在選取與渲染時考慮它們，亦包括後續的轉換。

**Aspose 會隨程式庫一起分發任何字型嗎？**

不會。Aspose 不會分發付費或免費字型；字型的新增與使用全由使用者自行決定並自行負責。

**在 Windows、Linux 與 macOS 上的替代行為有差異嗎？**

有。字型偵測會從作業系統的字型目錄開始。不同平台的預設可用字型集合與搜尋路徑不同，會影響字型的可取得性與是否需要替代。

**該如何準備環境以在批次轉換時減少意外的替代？**

在機器或容器之間同步字型集合，[加入輸出文件所需的外部字型](/slides/zh-hant/python-net/custom-font/)，並盡可能在簡報中[嵌入字型](/slides/zh-hant/python-net/embedded-font/)，確保所選字型在渲染時可用。