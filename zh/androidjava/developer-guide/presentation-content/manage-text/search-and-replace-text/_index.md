---
title: 在 Android 上的 PowerPoint 演示文稿中搜索和替换文本
linktitle: 搜索和替换文本
type: docs
weight: 55
url: /zh/androidjava/search-and-replace-text/
keywords:
- 搜索文本
- 突出显示文本
- 替换文本
- 正则表达式
- 结果回调
- 文本框
- 审计报告
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 演示文稿中搜索、突出显示和替换文本，同时收集每一次匹配。"
---
## **概述**

Aspose.Slides for Android via Java 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。每个操作还可以通过结果回调通知应用程序每个匹配。这使得能够在更新演示文稿的同时构建包含匹配的文本、其上下文、位置、文本框和幻灯片编号的审计跟踪。

这些功能对于审阅、编辑、术语检查、模板清理和自动报告工作流非常有用。

在下面的第一个示例中，我们使用名为 “sample.pptx” 的文件，该文件在第一张幻灯片上包含一个带有以下文本的文本框：

![示例文本](sample_text.png)

## **选择搜索范围**

使用[ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)上的方法将操作限制在单个文本框。使用[IPresentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/)上的方法处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **配置文本匹配**

对于文字匹配操作，使用[TextSearchOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textsearchoptions/)来控制匹配行为：

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 将匹配限制为完整单词。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 控制是否必须匹配字符大小写。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 在演示文稿级别的搜索、替换和突出显示操作中包括幻灯片备注。

正则表达式操作使用 Java `Pattern`，因此大小写敏感性和单词边界等匹配规则由表达式本身及其标志决定。

## **识别文本框的所有者**

通用的文本处理工作流在搜索、替换、验证或导出文本时经常接收到[ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)。使用[ITextFrame.getParentShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#getParentShape--)和[ITextFrame.getParentCell](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#getParentCell--)可确定哪个演示文稿对象拥有该文本框。

期望的返回值取决于所有者：

| 文本框所有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| 自动形状或其他包含文本的形状 | 拥有者[IShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/) | `null` |
| 表格单元格 | `null` | 拥有者[ICell](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icell/) |

两种方法均提供只读导航。调用它们不会移动文本框或更改其所有者。通用代码应检查两个返回值是否为`null`，并处理两者均不可用的情况。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

对于 SmartArt 内容，遍历[ISmartArtNode.getShapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ismartartnode/#getShapes--)中的形状，并访问每个[ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--)。文本框可以通过[ITextFrame.getParentShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#getParentShape--)追溯到其关联的形状，而[ITextFrame.getParentCell](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#getParentCell--)返回`null`。因此，示例中的形状分支同样处理来自 SmartArt 节点的文本。

## **使用回调收集匹配信息**

实现[IFindResultCallback](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifindresultcallback/)以接收每个匹配的通知。其[IFindResultCallback.foundResult](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-)方法提供相关的文本框、源文本、匹配文本以及匹配位置。

回调不会直接收到幻灯片编号。下面的实现从父幻灯片推导出编号，并且还能处理位于幻灯片备注中的文本。可空的`Integer`允许同一结果模型表示与其他幻灯片类型关联的文本。

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

对于替换操作，`foundText` 包含原始匹配的文本，因此回调可以精确记录哪些术语被替换。

## **突出显示文本**

使用[ITextFrame.highlightText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)方法在文本框中突出显示文字匹配。传入[TextSearchOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textsearchoptions/)以控制搜索，并提供回调以收集匹配细节。

下面的代码示例先突出显示所有 **"try"** 字符出现的位置，然后仅突出显示完整单词 **"to"**。两次搜索均向同一回调报告匹配。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // 突出显示文本框中所有出现的 "try"。
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // 仅突出显示完整单词 "to"。
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![突出显示的文本](highlighted_text.png)

## **使用正则表达式突出显示文本**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) 方法在文本框中突出显示正则表达式匹配的文本。

以下代码突出显示所有包含七个或更多字符的单词，并收集每个匹配：

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![使用正则表达式突出显示的文本](highlighted_text_using_regex.png)

## **跨演示文稿突出显示文本**

使用[IPresentation.highlightText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)和[IPresentation.highlightRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)在演示文稿中所有适用的文本框中搜索。下面的示例突出显示一个文字词语以及所有电子邮件地址，并为两次搜索保持独立的结果集合。

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在文本框中替换文本**

使用[ITextFrame.replaceText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)进行文字替换，使用[ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)进行基于模式的替换。这些方法在现有文本框内更新匹配的文本，保留周围内容的格式，而不是从纯字符串重新构建文本框。

下面的示例统一拼写变体后再替换版本标签。相同的回调记录两次操作匹配的原始词语。

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果一次匹配跨越了格式不同的片段，请检查输出以确认替换文本应采用哪种格式。

## **跨演示文稿替换文本**

使用[IPresentation.replaceText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)和[IPresentation.replaceRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)在整个演示文稿中执行相同的操作。这对模板清理、术语更新和编辑删除非常有用。

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **分组匹配以生成报告**

因为每个结果都存储了幻灯片编号和文本框，应用程序可以按审计、报告或审阅工作流对匹配进行分组。下面的示例先按幻灯片再按文本框对收集的结果进行分组：

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **常见问题**

**如何仅搜索单个文本框而不是整个演示文稿？**

获取形状的文本框并在该文本框上调用[ITextFrame.highlightText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)、[ITextFrame.replaceText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、或[ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)。演示文稿级别的方法会处理所有适用的文本框。

**如何匹配完整单词且区分大小写？**

将[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-)和[TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-)均设为`true`，并将这些选项传递给文字搜索或替换方法。对于正则表达式，在 Java `Pattern` 本身中定义单词边界和大小写敏感性。

**搜索和替换是否可以包括幻灯片备注中的文本？**

可以。使用演示文稿级别的文字操作时，将[TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-)设为`true`。上面示例中的回调实现会将备注页的匹配映射回其父幻灯片编号。

**如何在不二次扫描演示文稿的情况下生成报告？**

将[IFindResultCallback](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifindresultcallback/)实现传递给突出显示或替换操作。回调在操作执行期间接收每个匹配，应用程序即可存储源文本、匹配文本、位置、文本框以及推导出的幻灯片编号，以便后续分组或导出。

**替换文本是否会保留其格式？**

[ITextFrame.replaceText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)和[ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)在现有文本框内修改匹配的文本并保留周围部分的格式。如果一次匹配跨越了格式不同的片段，请检查结果以确保替换使用所需的样式。