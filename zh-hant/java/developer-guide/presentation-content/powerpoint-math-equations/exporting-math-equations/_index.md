---
title: 使用 Java 從簡報匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/java/exporting-math-equations/
keywords:
- 匯出數學方程式
- 匯出方程式至 LaTeX
- PowerPoint 轉 LaTeX
- MathML
- LaTeX
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 直接將 PowerPoint 簡報中的數學方程式匯出為 LaTeX 或 MathML。"
---
## **Introduction**

Aspose.Slides 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並在其他程式或平台中使用它們。 

{{% alert color="primary" %}} 
您可以直接將方程式匯出為 LaTeX 或 MathML，後者是網路上以及多種應用程式中使用的流行數學內容標準。 
{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides 能直接將 PowerPoint 數學方程式轉換為 LaTeX；不需要中介的 MathML 檔案或外部轉換器。數學方程式以 [IMathPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathportion/) 的形式儲存在文字框中。使用 [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathportion/#getMathParagraph--) 取得 [IMathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathparagraph/)，然後呼叫 [IMathParagraph.toLatex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathparagraph/#toLatex--)。此方法會回傳字串，您可以將其儲存、顯示、傳送至其他應用程式，或進一步處理。

以下範例會檢查每一張投影片的所有文字框，找出所有數學區段，並將每個方程式寫入各自的 `.tex` 檔案：

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
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) 會回傳投影片上找到的所有文字框。透過 [IMathPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathportion/) 類型檢查，可將真正可編輯的方程式與普通文字和影像區分開來。

LaTeX 引擎和文件範本並非全部支援相同的指令、套件或 Unicode 字元。請使用您應用程式所使用的 LaTeX 引擎測試回傳的字串。若某個符號或 Office Math 元素在該環境中沒有合適的表示方式，請在回傳的字串中以專案特定的指令取代，或略過該方程式並記錄問題以供審查。

## **將數學方程式儲存為 MathML**

雖然人類可以輕鬆撰寫 LaTeX 等某些方程式格式的程式碼，但對於 MathML 卻較為困難，因為後者應由應用程式自動產生。程式能輕鬆讀取與解析 MathML，因為其程式碼是 XML 格式，所以 MathML 常被用作許多領域的輸出與列印格式。

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

**實際匯出到 MathML 的是段落還是單一公式區塊？**

您可以將整個數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/)）或單一區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathblock/)）匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**我如何辨識投影片上的物件是數學公式而非普通文字或影像？**

公式存在於 [MathPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathportion/) 中，且擁有一個 [MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/)。沒有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/) 的影像或普通文字區段不會被匯出為公式。

**簡報中的 MathML 來源是什麼——是 PowerPoint 專屬還是標準？**

匯出目標為標準 MathML（XML）。Aspose 使用的是 Presentation MathML——標準的簡報子集，廣泛應用於各種應用程式與網路上。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，只要這些物件的文字區段包含 [MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/)（即真正的 PowerPoint 公式），就會被匯出。若公式以影像形式嵌入，則不會被匯出。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 只是將公式內容序列化，不會修改簡報檔案。