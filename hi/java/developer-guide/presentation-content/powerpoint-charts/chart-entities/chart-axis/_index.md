---
title: Java का उपयोग करके प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/java/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को नियंत्रित करें
- अक्ष को प्रबंधित करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "रिपोर्ट और दृश्यावलोकनों के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने हेतु Aspose.Slides for Java का उपयोग कैसे करें, जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट अक्षों को अनुकूलित करने का तरीका समझाता है। यह दिखाता है कि वास्तविक अक्ष मान कैसे प्राप्त करें, अक्षों के बीच डेटा कैसे बदलें, लाइन चार्ट के लिए ऊर्ध्वाधर या क्षैतिज अक्ष को कैसे छिपाएँ, श्रेणी अक्ष प्रकार कैसे बदलें, श्रेणी अक्ष मानों के लिए तिथि स्वरूप कैसे सेट करें, अक्ष शीर्षक को कैसे घुमाएँ, अक्ष की स्थिति कैसे सेट करें, और मान अक्ष पर यूनिट लेबल कैसे प्रदर्शित करें।

## **चार्ट में ऊर्ध्वाधर अक्ष पर अधिकतम मान प्राप्त करें**
Aspose.Slides for Java आपको ऊर्ध्वाधर अक्ष पर न्यूनतम और अधिकतम मान प्राप्त करने की अनुमति देता है। निम्नलिखित चरणों को अपनाएँ:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएं।
2. पहली स्लाइड तक पहुँचें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
4. अक्ष पर वास्तविक अधिकतम मान प्राप्त करें।
5. अक्ष पर वास्तविक न्यूनतम मान प्राप्त करें।
6. अक्ष की वास्तविक major unit प्राप्त करें।
7. अक्ष की वास्तविक minor unit प्राप्त करें।
8. अक्ष के वास्तविक major unit scale प्राप्त करें।
9. अक्ष के वास्तविक minor unit scale प्राप्त करें।

यह नमूना कोड—ऊपर बताए गए चरणों का कार्यान्वयन—जावाग्ल में आवश्यक मान प्राप्त करने का तरीका दिखाता है:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// प्रस्तुति को सहेजता है
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **अक्षों के बीच डेटा बदलें**
Aspose.Slides आपको अक्षों के बीच डेटा जल्दी से बदलने की अनुमति देता है—ऊर्ध्वाधर अक्ष (y-अक्ष) पर प्रदर्शित डेटा क्षैतिज अक्ष (x-अक्ष) में जाता है और इसके विपरीत।

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//पंक्तियों और स्तंभों को बदलता है
	chart.getChartData().switchRowColumn();

	// प्रस्तुति सहेजता है
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **लाइन चार्ट के लिए ऊर्ध्वाधर अक्ष को अक्षम करें**
यह जावा कोड दिखाता है कि लाइन चार्ट के लिए ऊर्ध्वाधर अक्ष को कैसे छिपाएँ:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष को अक्षम करें**
यह कोड दिखाता है कि लाइन चार्ट के लिए क्षैतिज अक्ष को कैसे छिपाएँ:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **एक श्रेणी अक्ष बदलें**
**CategoryAxisType** प्रॉपर्टी का उपयोग करके, आप अपनी पसंदीदा श्रेणी अक्ष प्रकार (**date** या **text**) निर्दिष्ट कर सकते हैं। यह जावा कोड इस ऑपरेशन को दर्शाता है:

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**
Aspose.Slides for Java आपको श्रेणी अक्ष मान के लिए तिथि स्वरूप सेट करने की अनुमति देता है। यह ऑपरेशन इस जावा कोड में दिखाया गया है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करें**
Aspose.Slides for Java आपको चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करने की अनुमति देता है। यह जावा कोड इस ऑपरेशन को दर्शाता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **श्रेणी या मान अक्ष पर अक्ष की स्थिति सेट करें**
Aspose.Slides for Java आपको श्रेणी या मान अक्ष में अक्ष की स्थिति सेट करने की अनुमति देता है। यह जावा कोड कार्य को कैसे किया जाए दिखाता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट मान अक्ष पर डिस्प्ले यूनिट लेबल सक्षम करें**
Aspose.Slides for Java आपको एक चार्ट को इस प्रकार कॉन्फ़िगर करने की अनुमति देता है कि वह अपने मान अक्ष पर यूनिट लेबल दिखाए। यह जावा कोड इस ऑपरेशन को दर्शाता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक अक्ष दूसरे अक्ष को जहाँ कटता है (अक्ष क्रॉसिंग) उस मान को कैसे सेट करूँ?**

अक्ष एक [crossing setting](https://reference.aspose.com/slides/hi/java/com.aspose.slides/axis/#setCrossType-int-) प्रदान करते हैं: आप शून्य पर, अधिकतम श्रेणी/मान पर, या किसी विशिष्ट संख्यात्मक मान पर क्रॉस करने को चुन सकते हैं। यह X-अक्ष को ऊपर या नीचे शिफ्ट करने या बेसलाइन को उजागर करने में उपयोगी है।

**टिक लेबल को अक्ष के सापेक्ष (साइड बाय साइड, बाहर, अंदर) कैसे स्थित करूँ?**

टिक लेबल की स्थिति सेट करने के लिए [label position](https://reference.aspose.com/slides/hi/java/com.aspose.slides/axis/#setMajorTickMark-int-) को "cross", "outside", या "inside" पर रखें। इससे पठनीयता प्रभावित होती है और विशेषकर छोटे चार्ट पर स्थान बचाने में मदद मिलती है।