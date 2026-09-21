---
title: 在 Android 上的 PowerPoint 簡報中管理文字欄位
linktitle: 文字欄位
type: docs
weight: 52
url: /zh-hant/androidjava/text-fields/
keywords:
- 文字欄位
- 自動文字
- 投影片編號
- 日期與時間
- 頁首
- 頁腳
- 文字部分
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 簡報中建立、檢查、修改與移除文字欄位。保留格式並驗證已儲存的 PPTX 與 PPT 檔案。"
---
## **概觀**

文字段落由多個部分組成。普通的 [IPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/) 包含文字字串；欄位部分還有一個 [IField](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifield/) ，其類型表示自動更新的值，例如投影片編號或日期。兩個部分可以顯示相同的字元，但僅有一個包含欄位。

使用 [IPortion.getField](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#getField--) 來區分它們：對普通文字而言會是 `null`。[IPortion.addField](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) 會將現有部分轉換為欄位。將標籤與其動態值放在不同的部分中，以免在轉換值時同時取代標籤。

本指南涵蓋文字內的欄位、其格式設定，以及在 PPTX 與 PPT 中的儲存方式。欲了解文字框與段落，請參閱 [Manage Text](/slides/zh-hant/androidjava/manage-text/)。

## **建立投影片編號欄位**

以下完整範例建立一個文字方塊，內含文字字串 `Slide ` 標籤，後接自動更新的編號。它在加入欄位前設定編號的大小、粗細與顏色，然後重新開啟已儲存的簡報，檢查欄位類型、文字與格式。此範例不需要任何輸入檔案。

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

新簡報從投影片編號 1 開始，因此文字為 `Slide 1`，兩項檢查皆列印 `true`。重新開啟後編號仍為欄位，而非文字 `1`。驗證中的型別轉換與索引指的是此範例所建立的圖形與部分。

## **選擇欄位類型**

[FieldType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/) 實作 [IFieldType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifieldtype/) 並提供以下方法以取得預定義值。將適當的值傳遞給 [addField](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-)。

| 方法 | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | 目前的投影片編號。 |
| [getDateTime](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | 日期/時間，採用呈現應用程式的預設格式。 |
| [getDateTime1](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | 預先定義的日期或組合日期/時間格式。 |
| [getDateTime10](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | 預先定義的時間格式，包含秒數和 12 小時制的選項。 |
| [getHeader](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#getHeader--) | 標題欄位；請參閱下方的佔位符與格式限制。 |
| [getFooter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#getFooter--) | 頁腳欄位。 |

例如，[getDateTime3](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) 代表英文的「日、完整月份名稱與年份」。這些是預先定義的欄位格式，而非任意的 Java 日期格式字串。使用 [setLanguageId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 設定的語言以及處理簡報的應用程式，都可能影響最終顯示結果。

## **從內部字串建立欄位**

[addField](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) 的字串重載接受內部欄位識別碼。當需要保留來自其他應用程式、且沒有預定義值的識別碼時使用。也可以使用該識別碼建構 [FieldType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-)。[IFieldType.getInternalString](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) 可將該識別碼公開供檢查。

此範例在文字方塊中儲存應用程式特定的 `custom-report-id` 欄位，備援文字為 `Report-042`。此識別碼不會註冊計算：Aspose.Slides 不會為未知類型產生報告 ID。必須由能理解此識別碼的應用程式提供其含義並更新其值。

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

經過此 PPTX 往返後，類型為 `custom-report-id`，文字為 `Report-042`。傳遞類似 `yyyy-MM-dd` 的字串只會命名欄位類型，並不會設定自訂日期格式。如需以任意格式的固定日期，請使用普通文字。

## **檢查、修改與移除日期/時間欄位**

透過 [IField.setType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) 變更既有欄位。存取型別前先確定欄位存在。若要停止自動更新，呼叫 [IPortion.removeField](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#removeField--)。此方法保留部分本身及其目前文字，同時移除欄位關聯。若需要特定的固定值，可在移除欄位後自行指派文字。

關於日期/時間欄位處理的 API 設定，請參閱 [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-)。以下範例在將欄位轉為普通文字時使用明確的核准日期。

下載 [sample.pptx](sample.pptx) 並放置於工作目錄。檔案包含兩個具名文字圖形 `UpdatedAt` 與 `ApprovedDate`，各自帶有日期/時間欄位，另有普通文字標籤。下列範例遍歷普通投影片上的頂層文字圖形，將日期/時間欄位改為長日期格式並斜體，同時保留其他格式。僅 `ApprovedDate` 中的欄位會變為固定文字。

樣本可辨識內建的識別碼 `datetime` 以及 `datetime1`~`datetime13`。群組、表格、備註、版面配置與母片需自行遍歷其文字容器，超出本範例範圍。

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

重新開啟後，`UpdatedAt` 的類型為 `datetime3` 並保持動態；`ApprovedDate` 沒有欄位，文字為 `05 April 2030`。兩個日期部分皆為斜體，其原始字型大小、粗體設定與顏色均未改變。普通文字標籤保持不變。驗證程式會讀取提供樣本中兩個已知圖形的第一個部分。

## **保留文字格式**

在加入欄位、變更類型或移除欄位時，請使用現有的部分。這些操作會保留該部分的格式。使用 [IPortion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#getPortionFormat--) 只變更所需的屬性，如範例所示的顏色或斜體設定。

避免僅為更新單一欄位而重建整個文字框：如此可能遺失原始部分的邊界與各自格式。同時須區分明確設定的格式與繼承自段落、版面或佈景主題的格式。請參閱 [Text Formatting](/slides/zh-hant/androidjava/text-formatting/) 了解更廣泛的格式選項。

## **欄位與頁首/頁腳佔位符**

欄位是文字部分的一部份。佔位符則是具備投影片角色（如頁腳或投影片編號）的圖形。將欄位加入普通文字方塊不會使該圖形變成佔位符。

頁首/頁腳管理員控制佔位符文字與可見性，涵蓋投影片、版面與母片，並會傳遞至相依投影片。即使未使用投影片編號佔位符，在自訂文字方塊中加入編號欄位仍可能有用。相反地，變更佔位符可見性不會移除與其他文字方塊無關的欄位。

預定義的頁首與頁腳類型不會建立對應的佔位符或提供其內容。特別是，普通的 PowerPoint 投影片沒有頁首佔位符；頁首屬於備註頁與講義。不要假設任意圖形中的頁首或頁腳欄位會自動取得透過佔位符管理員設定的文字。相關工作流程請參閱 [Presentation Headers and Footers](/slides/zh-hant/androidjava/presentation-header-and-footer/)。

## **PPTX 與 PPT 限制**

在儲存與重新開啟後，同時檢查欄位類型與其產生的文字。保留識別碼並不代表應用程式一定能計算或顯示其值。

| 格式 | 欄位行為與限制 |
|---|---|
| PPTX | 於欄位文字旁儲存內部欄位識別碼。往返檢查中，預定義類型與前述自訂識別碼皆能保留。未知的自訂類型僅保留備援文字，未取得自動計算邏輯。其他應用程式可能以不同方式處理不支援的識別碼。 |
| PPT | 使用舊式欄位表示法，相容性較受限。往返檢查時，投影片編號與預定義日期/時間欄位能保留。普通投影片文字方塊中的自訂欄位會以 `*` 作為文字重新開啟；同情境下的頁首欄位亦會產生 `*`。不要依賴自訂欄位或不受支援的欄位環境保留其可見文字。 |

若需可移植且固定的輸出，請在儲存前將不支援的欄位轉為普通文字，並明確指定欲保留的值。這樣可保留選定文字，同時刻意停止自動更新。若目標應用程式本身會重新計算欄位，也請一併測試其行為。

## **常見問題**

**如何判斷顯示的號碼或日期是否為欄位？**  
檢查 [IPortion.getField](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#getField--)。非 `null` 的回傳值即代表欄位，僅憑顯示的文字無法分辨。

**移除欄位會同時移除其文字或格式嗎？**  
不會。[removeField](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#removeField--) 只會將現有部分轉為普通文字。如需特定的凍結日期或備援文字，移除欄位後自行指派文字即可。

**內部字串能定義新的日期格式或公式嗎？**  
不能。它僅用於識別欄位類型。未知的識別碼不會提供運算器或 Java 日期格式模式。請使用受支援的預定義類型，或自行將值格式化為普通文字。

**為什麼要在儲存後再次檢查簡報？**  
欄位識別碼、計算後的文字與格式是需要分別驗證的項目。格式轉換可能會改變可見結果，即使欄位識別碼仍然存在。