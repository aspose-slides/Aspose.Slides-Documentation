---
title: 在 Android 上擷取與更新簡報資訊
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
description: "使用 Java 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快的洞見與更智慧的內容稽核。"
---
## **概覽**

Aspose.Slides 能夠辨識簡報的格式並在不建立完整簡報物件模型的情況下讀取文件中繼資料。當您需要對檔案進行分類、建立清單或在決定是否載入與處理簡報內容之前檢查屬性時，這非常有用。

本文示範如何透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/) 與 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/) 執行輕量檢查，以及如何透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/) 進行目標更新。

## **檢查簡報格式**

使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例的情況下檢查檔案。[IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) 方法會回報偵測到的格式，例如 PPTX、PPT 或 ODP。

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

當您處理大量簡報檔案時，可能需要緊湊的清單以供驗證、索引或文件管理系統使用。在此情境下，使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 取得 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/) 物件，接著呼叫 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 讀取文件中繼資料。此做法不會建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例，也不需要遍歷完整的簡報物件模型。

由 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/) 所公開的延伸屬性提供以下清單值：

| 方法 | 清單值 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | 投影片總數。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | 隱藏投影片的數量。 |
| [getNotes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | 含備註的投影片數量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | （若有）段落總數。 |
| [getWords](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | 單字總數。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | 音訊與視訊剪輯總數。 |

下列範例在未建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 物件的情況下讀取上述值，並印出緊湊的清單。它同時結合 [getHeadingPairs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) 與 [getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) 以顯示字型、主題與投影片標題等內容群組。

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

每個 [IHeadingPair](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iheadingpair/) 皆提供群組名稱與該群組內項目的數量。[IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) 會回傳平面、已排序的陣列，因此請依每個標題對所指定的連續標題數量來消費。

### **已儲存的中繼資料與格式限制**

由 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 回傳的清單屬性反映原始文件中可用的中繼資料。Aspose.Slides 不會載入並遍歷簡報物件模型以重新計算這些值。缺少的屬性會以預設值表示，且若最後一次儲存檔案的應用程式未更新其文件屬性，儲存的值可能已過時。

- **PPTX:** 此格式提供投影片、備註、隱藏投影片、段落、單字與多媒體計數等延伸文件屬性，以及標題對與部件標題。可用性取決於文件產生者寫入了哪些屬性。
- **PPT:** 二進位格式可以儲存對應的文件摘要屬性。若屬性缺失或未由文件產生者重新整理，Aspose.Slides 會回傳其儲存值或預設值，而不會從投影片重新計算。
- **ODP:** OpenDocument 中繼資料提供一般文件統計資訊，如頁面、段落與單字計數，但這些值未必對應每個 PowerPoint 特有的延伸屬性。隱藏投影片、備註投影片、多媒體、標題對與部件標題等中繼資料可能不存在，清單屬性可能回傳預設值。不要將零值或空陣列視為相應內容不存在的權威證明。

對於清單與初步檢查，請使用輕量中繼資料方法。當結果必須反映記憶體變更，或需要驗證實際簡報內容時，請載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

透過 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 取得的屬性也可以在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 實例的情況下變更。使用 [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 套用變更，然後使用 [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) 將綁定的簡報寫出。

以下影像顯示原始文件屬性。

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

以下影像顯示已更新的文件屬性。

![PowerPoint 簡報的變更後文件屬性](output_properties.png)

## **有用的連結**

相關的安全性檢查與保護設定，請參閱下列文章：

- [密碼保護簡報](/slides/zh-hant/androidjava/password-protected-presentation/)
- [寫入保護簡報](/slides/zh-hant/androidjava/write-protected-presentation/)

## **常見問題**

**如何檢查字型是否已嵌入以及哪些字型已嵌入？**

載入簡報並使用 [Presentation.getFontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getFontsManager--)。呼叫 [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) 取得已嵌入的字型，並呼叫 [IFontsManager.getFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) 取得簡報使用的字型。比較兩個結果即可找出需要渲染但未嵌入的字型。

**如何快速判斷檔案是否有隱藏投影片以及有多少？**

當儲存的文件中繼資料足夠時，透過 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 與 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 讀取 [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--)。此方式適合輕量清單。如果簡報已在記憶體中被修改，儲存的中繼資料可能缺失或已過時，或需要驗證即時值，請遍歷 [Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlides--)，並檢查每張投影片的 [ISlide.getHidden](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getHidden--) 方法。

**我能否偵測是否使用自訂投影片尺寸與方向，且是否與預設不同？**

可以。載入簡報後呼叫 [Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlideSize--)。使用 [ISlideSize.getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidesize/#getType--)、[ISlideSize.getSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidesize/#getSize--) 以及 [ISlideSize.getOrientation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidesize/#getOrientation--) 來比較目前設定與預設預設值與尺寸是否相符。

**有沒有快速方法可查看圖表是否參考外部資料來源？**

有。找出每個 [Chart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/)，並呼叫 [IChartData.getDataSourceType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--)。若為外部活頁簿，呼叫 [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)。資料來源類型與路徑可辨識外部參考，但要確認目標是否可用需另行檢查資源。

**我該如何評估可能導致渲染或 PDF 匯出變慢的「較重」投影片？**

沒有單一的複雜度屬性。遍歷 [Presentation.getSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlides--) 並檢查每張投影片的 [IBaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/#getShapes--) 集合。使用形狀數量、是否包含大尺寸影像、效果、動畫或多媒體等作為篩選訊號，並在將投影片視為確定的效能瓶頸前，先進行具代表性的渲染或匯出測試。