---
title: 從 Android 簡報匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/androidjava/exporting-math-equations/
keywords:
- 匯出數學方程式
- 匯出方程式至 LaTeX
- PowerPoint 至 LaTeX
- MathML
- LaTeX
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，直接將 PowerPoint 簡報中的數學方程式匯出為 LaTeX 或 MathML。"
---
## **簡介**

Aspose.Slides for Android via Java 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 
您可以直接將方程式匯出為 LaTeX 或 MathML，這是網路和許多應用程式中常用的數學內容標準。
{{% /alert %}}

## **匯出數學方程式為 LaTeX**

Aspose.Slides 可以直接將 PowerPoint 數學方程式轉換為 LaTeX；不需要中間的 MathML 檔案或外部轉換器。數學方程式以文字框的形式儲存為 [IMathPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathportion/)。使用 [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) 取得 [IMathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathparagraph/)，然後呼叫 [IMathParagraph.toLatex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathparagraph/#toLatex--)。此方法會回傳一個字串，您可以將其儲存、顯示、傳送至其他應用程式，或進一步處理。

以下範例會檢查每張投影片上的每個文字框，尋找所有數學區段，並將每個方程式寫入各自的 `.tex` 檔案：

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) 會返回投影片上找到的所有文字框。透過 [IMathPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathportion/) 的型別檢查，可將真正可編輯的方程式與普通文字和圖像區分開來。

LaTeX 引擎和文件模板並不都支援相同的指令、套件或 Unicode 字元。請使用您應用程式所使用的 LaTeX 引擎測試所回傳的字串。如果某個符號或 Office Math 元素在該環境中沒有適當的表示方式，請在回傳的字串中以專案自訂指令取代，或跳過該方程式並記錄問題以供日後檢查。

## **將數學方程式儲存為 MathML**

雖然人類可以輕鬆編寫 LaTeX 等某些方程式格式的程式碼，但在編寫 MathML 程式碼時會感到困難，因為後者應由應用程式自動產生。程式可以輕鬆讀取和解析 MathML，因為它的程式碼是 XML，因此 MathML 常被用作許多領域的輸出與列印格式。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**究竟匯出到 MathML 的是整段還是單一公式區塊？**  
您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathblock/)）匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式而非一般文字或圖像？**  
公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathportion/) 中，且具備 [MathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathparagraph/) 的圖像或一般文字區段，無法匯出為公式。

**簡報中的 MathML 來源是什麼——特定於 PowerPoint 還是標準？**  
匯出目標為標準 MathML（XML）。Aspose 使用 Presentation MathML——標準的呈現子集，已廣泛應用於各種應用程式與網路上。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**  
是的，只要這些物件的文字區段包含 [MathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathparagraph/)（即真正的 PowerPoint 公式），就會被匯出。若公式以圖像形式嵌入，則不會被匯出。

**匯出為 MathML 會修改原始簡報嗎？**  
不會。寫入 MathML 只是將公式內容序列化，並不會修改簡報檔案。