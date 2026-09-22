---
title: 於 Android 取得與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/androidjava/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 變更屬性
- 修改屬性
- 更新屬性
- 檢查 PPTX
- 檢查 PPT
- 檢查 ODP
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Java 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以加速洞察並提升內容稽核的智慧性。"
---
## **概觀**

Aspose.Slides 可以在不建立完整簡報物件模型的情況下辨識簡報的格式並讀取其文件中繼資料。當您需要分類檔案、建立清單或在決定是否載入與處理簡報內容之前檢查屬性時，這非常有用。

本文示範如何透過[PresentationFactory](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/) 與[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/) 進行輕量檢查，以及透過[IDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/) 進行目標更新。

## **檢查簡報格式**

如果您已經載入簡報，請參閱[Determine the Original Presentation Format](/slides/zh-hant/androidjava/detect-presentation-source-format/)，以在載入後進行偵測，並了解舊版 PPT、PPS 與 POT 串流的限制。

使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)可在不建立[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)實例的情況下檢查檔案。[IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--)方法會回報偵測到的格式，例如 PPTX、PPT 或 ODP。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **建立輕量簡報清單**

當您處理大量簡報檔案時，可能需要緊湊的清單以供驗證、索引或文件管理系統使用。在此情況下，使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)取得[IPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/)物件，然後呼叫[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)以讀取文件中繼資料。此方法不會建立[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)實例，也不需要遍歷完整的簡報物件模型。

[IDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/)所揭露的擴充屬性提供以下清單值：

| Method | Inventory value |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | 投影片總數。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | 隱藏投影片的數量。 |
| [getNotes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | 含有註解的投影片數量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | 段落總數（若有提供）。 |
| [getWords](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | 字數總計。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | 音訊與視訊剪輯的總數。 |

以下範例在不建立[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)物件的情況下讀取這些值並印出緊湊的清單。它也結合[getHeadingPairs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--)與[getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--)以顯示如字型、主題與投影片標題等內容群組。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

每個[IHeadingPair](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iheadingpair/)提供群組名稱以及該群組內項目的數量。[IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--)回傳平面且已排序的陣列，因此請依照每個標題對所指定的連續標題數量來取用。

### **已存儲的中繼資料與格式限制**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)返回的清單屬性反映來源文件中可用的中繼資料。Aspose.Slides 不會載入並遍歷簡報物件模型以重新計算此呼叫的值。缺少的屬性以預設值表示，且若最後儲存檔案的應用程式未更新文件屬性，已存儲的值可能已過時。

- **PPTX:** 此格式提供投影片、註解、隱藏投影片、段落、單字與多媒體計數等擴充文件屬性，以及標題對與部件標題。可用性取決於文件產生者寫入了哪些屬性。
- **PPT:** 此二進位格式可以儲存相對應的文件摘要屬性。如果屬性缺失或未由文件產生者重新整理，Aspose.Slides 會回傳其已存儲或預設值，而非從投影片重新計算。
- **ODP:** OpenDocument 中繼資料提供一般文件統計資訊，例如頁面、段落與單字計數，但這些值未對應每個 PowerPoint 專屬的擴充屬性。隱藏投影片、註解投影片、多媒體、標題對與部件標題的中繼資料可能不存在，清單屬性可能會回傳預設值。不要將零值或空陣列視為確定缺少相應內容的權威證據。

在建立清單與執行初步檢查時，請使用輕量中繼資料方法。若結果必須反映記憶體中的變更，或需要驗證實際的簡報內容，則應載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)返回的屬性同樣可以在不建立[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)實例的情況下變更。使用[IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)套用變更，然後使用[IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-)寫入已繫結的簡報。

下圖顯示原始的文件屬性。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下範例變更標題與最後儲存時間，並將結果寫入新檔案：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

![PowerPoint 簡報的變更後文件屬性](output_properties.png)

## **有用連結**

有關相關的安全檢查與保護設定，請參閱以下文章：

- [密碼保護簡報](/slides/zh-hant/androidjava/password-protected-presentation/)
- [寫入保護簡報](/slides/zh-hant/androidjava/write-protected-presentation/)

## **常見問題**

**我該如何檢查字型是否已嵌入以及哪些字型被嵌入？**

載入簡報並使用[Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getFontsManager--)。呼叫[IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--)以取得已嵌入的字型，並呼叫[IFontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getFonts--)取得簡報使用的字型。比較兩個結果即可找出渲染所需但尚未嵌入的字型。

**我該如何快速判斷檔案是否包含隱藏投影片以及有多少張？**

當已存儲的文件中繼資料足以判斷時，透過[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)與[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)讀取[IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--)。此方式適用於輕量清單。若簡報已在記憶體中被修改，已存儲的中繼資料可能遺失或過時，或需驗證即時值，則請遍歷[Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlides--)並檢查每張投影片的[ISlide.getHidden](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getHidden--)方法。

**我能偵測是否使用自訂投影片尺寸與方向，且是否與預設值不同嗎？**

可以。載入簡報並呼叫[Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlideSize--)。使用[ISlideSize.getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidesize/#getType--)、[ISlideSize.getSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidesize/#getSize--)以及[ISlideSize.getOrientation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidesize/#getOrientation--)將目前設定與預期的預設值與尺寸進行比較。

**是否有快速方法查看圖表是否參考外部資料來源？**

可以。尋找每個[Chart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/)並呼叫[IChartData.getDataSourceType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--)。若為外部活頁簿，則呼叫[IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)。資料來源類型與路徑可辨識外部參照，但驗證目標是否可用需另行執行資源檢查。

**我該如何評估可能減慢渲染或 PDF 匯出的「大型」投影片？**

沒有單一的複雜度屬性。遍歷[Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlides--)以及每張投影片的[IBaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/#getShapes--)集合。利用形狀數量及大型圖片、特效、動畫或多媒體的存在作為篩選指標，並在將投影片視為已確認的效能瓶頸之前，先測量具代表性的渲染或匯出時間。