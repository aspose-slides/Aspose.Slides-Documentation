---
title: Aspose.Slides for Android via Java 20.6 Release Notes
type: docs
weight: 60
url: /java/aspose-slides-for-android-via-java-20-6-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for Aspose.Slides for Android via Java 20.6

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESANDROID-240|[Use Aspose.Slides for Java 20.6 features](/slides/java/aspose-slides-for-java-20-6-release-notes/)|Enhancement|

# **Public API Changes**
### **New methods setRecoverWorkbookFromChartCache and getRecoverWorkbookFromChartCache have been added to SpreadsheetOptions**


New methods [**setRecoverWorkbookFromChartCache()**](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/SpreadsheetOptions#setRecoverWorkbookFromChartCache-boolean-) and [**getRecoverWorkbookFromChartCache()**](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/SpreadsheetOptions#getRecoverWorkbookFromChartCache--) have been added to [SpreadsheetOptions](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/SpreadsheetOptions). If the data source of the chart is an external workbook and it's not available, it will be recovered from the chart cache.

{{< highlight java >}}
LoadOptions lo = new LoadOptions();
lo.getSpreadsheetOptions().setRecoverWorkbookFromChartCache(true);

Presentation pres = new Presentation("Presentation.pptx", lo);
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    ...
} finally {
    if (pres != null) pres.dispose();
}
{{< /highlight >}}

### **iteratorJava() method has been added to IGenericCollection interface and several collection classes**
**iteratorJava()** method has been added to [IGenericCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IGenericCollection) interface and following classes:

- [AudioCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/AudioCollection#iteratorJava--)
- [BehaviorCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/BehaviorCollection#iteratorJava--)
- [BehaviorPropertyCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/BehaviorPropertyCollection#iteratorJava--)
- [CellCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/CellCollection#iteratorJava--)
- [ChartCategoryCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ChartCategoryCollection#iteratorJava--)
- [ChartCellCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ChartCellCollection#iteratorJava--)
- [ChartDataPointCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ChartDataPointCollection#iteratorJava--)
- [ChartSeriesCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ChartSeriesCollection#iteratorJava--)
- [ColorOperationCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ColorOperationCollection#iteratorJava--)
- [ColumnCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ColumnCollection#iteratorJava--)
- [CommentAuthorCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthorCollection#iteratorJava--)
- [CommentCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#iteratorJava--)
- [ControlCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ControlCollection#iteratorJava--)
- [ControlPropertiesCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ControlPropertiesCollection#iteratorJava--)
- [CustomXmlPartCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/CustomXmlPartCollection#iteratorJava--)
- [DataLabelCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/DataLabelCollection#iteratorJava--)
- [DigitalSignatureCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/DigitalSignatureCollection#iteratorJava--)
- [EffectStyleCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/EffectStyleCollection#iteratorJava--)
- [ExtraColorSchemeCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ExtraColorSchemeCollection#iteratorJava--)
- [FillFormatCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/FillFormatCollection#iteratorJava--)
- [FontFallBackRulesCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection#iteratorJava--)
- [FontSubstRuleCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/FontSubstRuleCollection#iteratorJava--)
- [GradientStopCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GradientStopCollection#iteratorJava--)
- [GradientStopCollectionEffectiveData](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/GradientStopCollectionEffectiveData#iteratorJava--)
- [ImageCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection#iteratorJava--)
- [ImageTransformOCollectionEffectiveData](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ImageTransformOCollectionEffectiveData#iteratorJava--)
- [ImageTransformOperationCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ImageTransformOperationCollection#iteratorJava--)
- [LayoutSlideCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/LayoutSlideCollection#iteratorJava--)
- [LineFormatCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/LineFormatCollection#iteratorJava--)
- [MasterSlideCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/MasterSlideCollection#iteratorJava--)
- [MotionPath](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/MotionPath#iteratorJava--)
- [ParagraphCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ParagraphCollection#iteratorJava--)
- [PieSplitCustomPointCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/PieSplitCustomPointCollection#iteratorJava--)
- [PointCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/PointCollection#iteratorJava--)
- [PortionCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/PortionCollection#iteratorJava--)
- [RowCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/RowCollection#iteratorJava--)
- [SectionCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/SectionCollection#iteratorJava--)
- [SectionSlideCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/SectionSlideCollection#iteratorJava--)
- [Sequence](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#iteratorJava--)
- [SequenceCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/SequenceCollection#iteratorJava--)
- [ShapeCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/ShapeCollection#iteratorJava--)
- [SlideCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#iteratorJava--)
- [SmartArtNodeCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNodeCollection#iteratorJava--)
- [SmartArtShapeCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShapeCollection#iteratorJava--)
- [TabCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/TabCollection#iteratorJava--)
- [TagCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/TagCollection#iteratorJava--)
- [TextAnimationCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/TextAnimationCollection#iteratorJava--)
- [TrendlineCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/TrendlineCollection#iteratorJava--)
- [VbaModuleCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/VbaModuleCollection#iteratorJava--)
- [VbaReferenceCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/VbaReferenceCollection#iteratorJava--)
- [VideoCollection](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/VideoCollection#iteratorJava--)

This method allows to get an iterator that is fully complied with the Java Iterator logic.
