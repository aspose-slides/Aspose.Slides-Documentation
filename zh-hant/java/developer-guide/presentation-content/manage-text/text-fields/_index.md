---
title: 在 Java 中管理 PowerPoint 簡報的文字欄位
linktitle: 文字欄位
type: docs
weight: 52
url: /zh-hant/java/text-fields/
keywords:
- 文字欄位
- 自動文字
- 投影片編號
- 日期與時間
- 表頭
- 表尾
- 文字部份
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "在 PowerPoint 簡報中使用 Aspose.Slides for Java 建立、檢查、修改與移除文字欄位。保留格式並驗證已儲存的 PPTX 與 PPT 檔案。"
---
## **概述**

文字段落由多個部份組成。普通的[IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/)僅包含文字；欄位部份還包含一個[IField](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifield/)，其型別會識別自動更新的值，例如投影片編號或日期。兩個部份可以顯示相同的字元，但只有一個包含欄位。

使用[IPortion.getField](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#getField--)來區分：普通文字的情況下它為`null`。[IPortion.addField](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-)會將現有的部份轉換為欄位。請將標籤與其動態值放在不同的部份中，以免在轉換值時同時取代標籤。

本指南說明文字中的欄位、其格式設定，以及在 PPTX 與 PPT 中的儲存方式。關於文字框與段落，請參閱[管理文字](/slides/zh-hant/java/manage-text/)。

## **建立投影片編號欄位**

以下完整範例建立一個文字方塊，內容為文字標籤`Slide `，後接自動更新的編號。它先設定編號的大小、粗細與顏色，然後加入欄位，接著重新開啟已儲存的簡報，檢查欄位型別、文字與格式。此範例不需要任何輸入檔。

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

新的簡報從投影片編號 1 開始，因此文字為`Slide 1`，兩項檢查皆會列印`true`。重新開啟後編號仍是欄位，而不是文字`1`。驗證程式碼中的型別轉換與索引指向本範例建立的圖形與部份。

## **選取欄位型別**

[FieldType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/)實作[IFieldType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifieldtype/)，提供以下方法以取得預定義的值。將適當的值傳遞給[addField](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-)。

| 方法 | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#getSlideNumber--) | 目前的投影片編號。 |
| [getDateTime](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#getDateTime--) | 以呈現應用程式的預設格式顯示日期/時間。 |
| [getDateTime1](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#getDateTime9--) | 預定義的日期或組合日期/時間格式。 |
| [getDateTime10](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#getDateTime13--) | 預定義的時間格式，可選擇是否顯示秒數與 12 小時制。 |
| [getHeader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#getHeader--) | 表頭欄位；請參閱下方的佔位符與格式限制。 |
| [getFooter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#getFooter--) | 表尾欄位。 |

例如，[getDateTime3](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#getDateTime3--) 代表「日、完整月份名稱與英文年份」。這些是預定義的欄位格式，而非任意的 Java 日期格式字串。使用[setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 設定的語言，以及處理簡報的應用程式，都可能影響最終顯示的結果。

## **從內部字串建立欄位**

[addField](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#addField-java.lang.String-) 的字串多載接受內部欄位識別碼。當需要保留其他應用程式提供且沒有預定義值的識別碼時，請使用它。您也可以從識別碼建構[FieldType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-)。[IFieldType.getInternalString](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifieldtype/#getInternalString--) 會公開此識別碼供檢查。

此範例將應用程式特定的 `custom-report-id` 欄位儲存為備援文字 `Report-042`。此識別碼不會註冊計算：Aspose.Slides 不會為未知類型產生報告 ID。必須由能識別此識別碼的應用程式自行提供意義並更新其值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

經過 PPTX 往返後，型別為 `custom-report-id`，文字為 `Report-042`。若傳遞字串如 `yyyy-MM-dd`，會成為欄位型別名稱，而不會設定自訂的日期格式。若需要固定日期且格式任意，請使用普通文字。

## **檢查、修改與移除日期/時間欄位**

透過[IField.setType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-)變更既有欄位。存取型別前請先確認欄位是否存在。若要停止自動更新，呼叫[IPortion.removeField](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#removeField--)。此操作會保留部份及其目前文字，同時移除欄位關聯。若需要特定的固定值，請在移除欄位後自行指定文字。

關於日期/時間欄位處理的 API 設定，請參閱[Presentation.setCurrentDateTime](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-)。下方範例在將欄位轉換為普通文字時使用明確的批准日期。

下載 [sample.pptx](sample.pptx) 並放置於工作目錄。該檔案包含兩個具名文字圖形 `UpdatedAt` 與 `ApprovedDate`，各自帶有日期/時間欄位，外加普通文字標籤。以下範例遍歷普通投影片上的頂層文字圖形，將日期/時間欄位改為長日期格式並設定斜體，同時保留其他格式。只有 `ApprovedDate` 的欄位會變為固定文字。

此範例會辨識內建的內部識別碼 `datetime` 以及 `datetime1` 到 `datetime13`。群組、表格、備註、版面配置與母片需要自行遍歷其文字容器，超出本範例範圍。

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

重新開啟後，`UpdatedAt` 的型別為 `datetime3`，仍保持動態。`ApprovedDate` 無欄位，文字為 `05 April 2030`。兩個日期部份皆為斜體，原本的字型大小、粗體設定與顏色保持不變。普通文字標籤則未受影響。驗證程式會讀取提供樣本中兩個已知圖形的第一個部份。

## **保留文字格式**

在加入欄位、變更其型別或移除欄位時，請直接使用現有的部份。這些操作會保留該部份的格式。使用[IPortion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#getPortionFormat--) 只變更必要的屬性，就像範例中對顏色或斜體的處理。

避免為了更新單一欄位而重建整個文字框：如此可能遺失原始部份的邊界與個別格式。同時請區分明確設定的格式與繼承自段落、版面配置或佈景主題的格式。更多格式選項請參閱[文字格式化](/slides/zh-hant/java/text-formatting/)。

## **欄位與表頭/表尾佔位符**

欄位是文字部份的一部份。佔位符則是具備簡報角色的圖形，例如表尾或投影片編號。將欄位加入普通文字方塊並不會使該圖形變成佔位符。

表頭/表尾管理員控制佔位符文字與在投影片、版面配置與母片上的可見性，並會傳遞至相依的投影片。自訂文字方塊中的編號欄位在未使用投影片編號佔位符時仍可能有用。相反地，變更佔位符可見性不會移除與其他文字方塊無關的欄位。

預定義的表頭與表尾型別不會建立相應的佔位符或提供其內容。特別是，一般的 PowerPoint 投影片沒有表頭佔位符；表頭屬於備註頁與講義。不要假設任意圖形中的表頭或表尾欄位會自動取得佔位符管理員所設定的文字。若需要此工作流程，請參閱[簡報表頭與表尾](/slides/zh-hant/java/presentation-header-and-footer/)。

## **PPTX 與 PPT 的限制**

儲存並重新開啟後，請同時檢查欄位型別與最終文字。保留識別碼並不代表應用程式一定能計算或顯示其值。

| 格式 | 欄位行為與限制 |
|---|---|
| PPTX | 同時儲存內部欄位識別碼與欄位文字。往返測試中，預定義型別與上述的自訂識別碼均能在儲存與重新開啟後存活。未知的自訂型別保留備援文字，未取得自動計算邏輯。其他應用程式可能以不同方式處理不支援的識別碼。 |
| PPT | 使用舊版欄位表示法，兼容性較低。往返測試中，投影片編號與預定義日期/時間欄位能在儲存與重新開啟後存活。普通投影片文字方塊中的自訂欄位重新開啟時仍保有識別碼，但文字顯示為 `*`；同樣情況也發生在表頭欄位。請勿依賴自訂欄位或不受支援的欄位上下文保留其可見文字。 |

若需可移植的固定輸出，請將不受支援的欄位轉換為普通文字，並在儲存前明確指派所需的值。這樣可保留選定的文字，同時停止自動更新。若您的工作流程中目標應用程式也會重新計算欄位，請一併進行測試。

## **常見問題**

**如何判斷顯示的編號或日期是否為欄位？**

檢查[IPortion.getField](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#getField--)。非 null 值即代表欄位；僅憑顯示的文字無法分辨。

**移除欄位會同時移除它的文字或格式嗎？**

不會。[removeField](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#removeField--) 會將現有部份轉換為普通文字。若需要特定的凍結日期或備援文字，請在移除後自行指定值。

**內部字串能定義新的日期格式或公式嗎？**

不能。它僅用於識別欄位型別。未知的識別碼不會提供評估器或 Java 日期格式模式。請使用受支援的預定義型別，或自行將值格式化為普通文字。

**為什麼要在儲存後再次檢查簡報？**

欄位識別碼、計算後的文字與格式是需要分別驗證的項目。格式轉換可能會改變可見結果，即使欄位識別碼仍然存在。