---
title: एंड्रॉइड पर प्रस्तुतियों में चार्ट डेटा लेबल्स का प्रबंधन
linktitle: डेटा लेबल
type: docs
url: /hi/androidjava/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "अधिक आकर्षक स्लाइड्स के लिए जावा के माध्यम से एंड्रॉइड के लिए Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल्स को जोड़ना और फ़ॉर्मेट करना सीखें।"
---
## **परिचय**

चार्ट में डेटा लेबल्स चार्ट डेटा श्रृंखला या व्यक्तिगत डेटा पॉइंट्स के बारे में विवरण दिखाते हैं। वे पाठकों को डेटा श्रृंखला को जल्दी पहचानने में मदद करते हैं और चार्ट को समझना आसान बनाते हैं।

## **चार्ट डेटा लेबल्स में डेटा प्रिसीजन सेट करें**

यह Java कोड दिखाता है कि चार्ट डेटा लेबल में डेटा प्रिसीजन कैसे सेट किया जाए:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **प्रतिशत को लेबल के रूप में प्रदर्शित करें**
Aspose.Slides for Android via Java आपको प्रदर्शित चार्ट पर प्रतिशत लेबल सेट करने की अनुमति देता है। यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
// Presentation क्लास की एक इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // चार्ट सहित प्रस्तुति को सहेजता है
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट डेटा लेबल्स में प्रतिशत चिह्न सेट करें**
यह Java कोड दिखाता है कि चार्ट डेटा लेबल के लिए प्रतिशत चिह्न कैसे सेट किया जाए:

```java
// Presentation क्लास की एक इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // स्लाइड पर PercentsStackedColumn चार्ट बनाता है
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // NumberFormatLinkedToSource को false सेट करता है
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // नई सीरीज़ जोड़ता है
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // सीरीज़ का फ़िल रंग सेट करता है
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // LabelFormat गुण सेट करता है
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // नई सीरीज़ जोड़ता है
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // फ़िल प्रकार और रंग सेट करता है
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **धुरी से लेबल की दूरी निर्धारित करें**
यह Java कोड दिखाता है कि धुरी से श्रेणी धुरी की दूरी कैसे निर्धारित की जाए जब आप धुरी से प्लॉट किए गए चार्ट के साथ काम कर रहे हों:

```java
// Presentation क्लास की एक इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // स्लाइड का रेफ़रेंस प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // स्लाइड पर एक चार्ट बनाता है
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // धुरी से लेबल की दूरी सेट करता है
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **लेबल स्थान समायोजित करें**

जब आप ऐसा चार्ट बनाते हैं जो किसी धुरी पर निर्भर नहीं करता, जैसे पाई चार्ट, तो चार्ट के डेटा लेबल्स किनारे के बहुत पास आ सकते हैं। ऐसे में आपको डेटा लेबल की स्थिति को समायोजित करना पड़ता है ताकि लीडर लाइनें स्पष्ट रूप से दिखाई दें।

यह Java कोड दिखाता है कि पाई चार्ट पर लेबल की स्थिति कैसे समायोजित की जाए:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**घने चार्ट में डेटा लेबल्स के ओवरलैप को कैसे रोकें?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइनें, और फ़ॉन्ट आकार को कम करें; यदि आवश्यक हो तो कुछ फ़ील्ड्स (उदाहरण के लिए, श्रेणी) को छिपाएँ या केवल महत्वपूर्ण/अत्यधिक पॉइंट्स के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक या खाली मानों के लिए लेबल्स को कैसे निष्क्रिय करें?**

लेबल सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और शून्य, नकारात्मक या अनुपस्थित मानों के लिए दर्शाना बंद करने के लिए एक परिभाषित नियम लागू करें।

**PDF/छवियों में निर्यात करते समय लेबल शैली को सुसंगत कैसे रखें?**

फ़ॉन्ट (परिवार, आकार) को स्पष्ट रूप से सेट करें और सुनिश्चित करें कि रेंडरिंग पक्ष पर फ़ॉन्ट उपलब्ध है ताकि फ़ॉलबैक न हो।