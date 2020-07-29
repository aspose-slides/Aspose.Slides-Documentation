---
title: Aspose.Slides for Java 20.6 Release Notes
type: docs
weight: 60
url: /java/aspose-slides-for-java-20-6-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for Java 20.6](https://repository.aspose.com/repo/com/aspose/aspose-slides/20.6/)

{{% /alert %}} 
## **New Features and Enhancements**

|SLIDESNET-33764|Support for Open Type Font (OTF) in Aspose.Slides|Feature|
| :- | :- | :- |
|SLIDESNET-41930|Pptx to Html: Slide converted to PNG image when NotesPosition is set|Enhancement|
|SLIDESNET-41703|Text failed to extract in generated presentation|Enhancement|
|SLIDESNET-41702|Can't extract all text from slides|Enhancement|
|SLIDESNET-41892|Faulty link in web view of PDF file|Enhancement|
|SLIDESNET-41509|Conversion to PDF - accessibility standards|Feature|
|SLIDESNET-41023|PDF/UA compliance support|Feature|
|SLIDESNET-40996|Tagged PDF export|Feature|
|SLIDESNET-37215|getAllTextBoxes not getting text from table|Enhancement|
|SLIDESJAVA-38084|Support for Open Type Font (OTF) in Aspose.Slides|Feature|
|SLIDESJAVA-37951|Use Aspose.Slides for Net 20.6 features|Enhancement|
## **Other Improvements and Changes**

|SLIDESJAVA-38017|Compatability support for Open JDK 11 and Open JDK 13 in Aspose.Slides|Investigation|
| :- | :- | :- |
|SLIDESJAVA-38104|PPT to PDF: Different PDF results for same presentation on two exactly similar machines|Investigation|
|SLIDESJAVA-38117|PPTX to PDF OOM and poor performance|Bug|
|SLIDESJAVA-38112|KeyNotFoundException is thrown on merging slides|Bug|
|SLIDESJAVA-38108|Java Iterator contract seems to be broken in Aspose Slides collections|Bug|
|SLIDESJAVA-38103|Slide thumbnails are not properly generated|Bug|
|SLIDESJAVA-38099|Issue while converting PPTX to PDF|Bug|
|SLIDESJAVA-38098|“Cannot create graphic object from indexed image format” when rendering slide on grayscale bitmap|Bug|
|SLIDESJAVA-38080|Unknown Source exception on exporting to PDF|Bug|
|SLIDESJAVA-37745|Bryant font is changed to Calibri after saving slide as html|Bug|
|SLIDESJAVA-36940|Can't extract all text from slides|Bug|
|SLIDESJAVA-36566|Text failed to extract in generated presentation|Bug|
|SLIDESJAVA-35246|getAllTextBoxes not getting text from table|Bug|
# **Public API Changes**
### **New methods setRecoverWorkbookFromChartCache and getRecoverWorkbookFromChartCache have been added to SpreadsheetOptions**


New methods [**setRecoverWorkbookFromChartCache()**](https://apireference.aspose.com/slides/java/com.aspose.slides/SpreadsheetOptions#setRecoverWorkbookFromChartCache-boolean-) and [**getRecoverWorkbookFromChartCache()**](https://apireference.aspose.com/slides/java/com.aspose.slides/SpreadsheetOptions#getRecoverWorkbookFromChartCache--) have been added to [SpreadsheetOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/SpreadsheetOptions). If the data source of the chart is an external workbook and it's not available, it will be recovered from the chart cache.

LoadOptions lo = **new** LoadOptions();
lo.getSpreadsheetOptions().setRecoverWorkbookFromChartCache(**true**);

Presentation pres = **new** Presentation("Presentation.pptx", lo);
**try** {
`    `IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
`    `IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
`   `...
} **finally** {
`   `**if** (pres != **null**) pres.dispose();
}
### **iteratorJava() method has been added to IGenericCollection interface and several collection classes**
**iteratorJava()** method has been added to [IGenericCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IGenericCollection) interface and following classes:

- [AudioCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/AudioCollection#iteratorJava--)
- [BehaviorCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/BehaviorCollection#iteratorJava--)
- [BehaviorPropertyCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/BehaviorPropertyCollection#iteratorJava--)
- [CellCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/CellCollection#iteratorJava--)
- [ChartCategoryCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ChartCategoryCollection#iteratorJava--)
- [ChartCellCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ChartCellCollection#iteratorJava--)
- [ChartDataPointCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ChartDataPointCollection#iteratorJava--)
- [ChartSeriesCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ChartSeriesCollection#iteratorJava--)
- [ColorOperationCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ColorOperationCollection#iteratorJava--)
- [ColumnCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ColumnCollection#iteratorJava--)
- [CommentAuthorCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/CommentAuthorCollection#iteratorJava--)
- [CommentCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/CommentCollection#iteratorJava--)
- [ControlCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ControlCollection#iteratorJava--)
- [ControlPropertiesCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ControlPropertiesCollection#iteratorJava--)
- [CustomXmlPartCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/CustomXmlPartCollection#iteratorJava--)
- [DataLabelCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/DataLabelCollection#iteratorJava--)
- [DigitalSignatureCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/DigitalSignatureCollection#iteratorJava--)
- [EffectStyleCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/EffectStyleCollection#iteratorJava--)
- [ExtraColorSchemeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ExtraColorSchemeCollection#iteratorJava--)
- [FillFormatCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/FillFormatCollection#iteratorJava--)
- [FontFallBackRulesCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection#iteratorJava--)
- [FontSubstRuleCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/FontSubstRuleCollection#iteratorJava--)
- [GradientStopCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/GradientStopCollection#iteratorJava--)
- [GradientStopCollectionEffectiveData](https://apireference.aspose.com/slides/java/com.aspose.slides/GradientStopCollectionEffectiveData#iteratorJava--)
- [ImageCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ImageCollection#iteratorJava--)
- [ImageTransformOCollectionEffectiveData](https://apireference.aspose.com/slides/java/com.aspose.slides/ImageTransformOCollectionEffectiveData#iteratorJava--)
- [ImageTransformOperationCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ImageTransformOperationCollection#iteratorJava--)
- [LayoutSlideCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/LayoutSlideCollection#iteratorJava--)
- [LineFormatCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/LineFormatCollection#iteratorJava--)
- [MasterSlideCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/MasterSlideCollection#iteratorJava--)
- [MotionPath](https://apireference.aspose.com/slides/java/com.aspose.slides/MotionPath#iteratorJava--)
- [ParagraphCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ParagraphCollection#iteratorJava--)
- [PieSplitCustomPointCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/PieSplitCustomPointCollection#iteratorJava--)
- [PointCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/PointCollection#iteratorJava--)
- [PortionCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/PortionCollection#iteratorJava--)
- [RowCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/RowCollection#iteratorJava--)
- [SectionCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/SectionCollection#iteratorJava--)
- [SectionSlideCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/SectionSlideCollection#iteratorJava--)
- [Sequence](https://apireference.aspose.com/slides/java/com.aspose.slides/Sequence#iteratorJava--)
- [SequenceCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/SequenceCollection#iteratorJava--)
- [ShapeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeCollection#iteratorJava--)
- [SlideCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/SlideCollection#iteratorJava--)
- [SmartArtNodeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtNodeCollection#iteratorJava--)
- [SmartArtShapeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/SmartArtShapeCollection#iteratorJava--)
- [TabCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/TabCollection#iteratorJava--)
- [TagCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/TagCollection#iteratorJava--)
- [TextAnimationCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAnimationCollection#iteratorJava--)
- [TrendlineCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/TrendlineCollection#iteratorJava--)
- [VbaModuleCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/VbaModuleCollection#iteratorJava--)
- [VbaReferenceCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/VbaReferenceCollection#iteratorJava--)
- [VideoCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/VideoCollection#iteratorJava--)

This method allows to get an iterator that is fully complied with the Java Iterator logic.
