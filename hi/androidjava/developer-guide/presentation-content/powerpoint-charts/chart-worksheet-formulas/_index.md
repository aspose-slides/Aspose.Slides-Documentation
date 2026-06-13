---
title: प्रस्तुतीकरण में Android के लिए चार्ट कार्यपत्रक सूत्र लागू करें
linktitle: कार्यपत्रक सूत्र
type: docs
weight: 70
url: /hi/androidjava/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट कार्यपत्रक
- चार्ट सूत्र
- कार्यपत्रक सूत्र
- स्प्रेडशीट सूत्र
- डेटा स्रोत
- तार्किक स्थिरांक
- संख्यात्मक स्थिरांक
- स्ट्रिंग स्थिरांक
- त्रुटि स्थिरांक
- अंकगणितीय स्थिरांक
- तुलना ऑपरेटर
- A1 शैली
- R1C1 शैली
- पूर्वनिर्धारित फ़ंक्शन
- PowerPoint
- प्रस्तुतीकरण
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में Java चार्ट कार्यपत्रकों के माध्यम से Excel-शैली के सूत्र लागू करें और PPT तथा PPTX फ़ाइलों में रिपोर्टों को स्वचालित करें।"
---
## **परिचय**

एक चार्ट कार्यपत्रक प्रस्तुति में चार्ट के पीछे डेटा स्रोत होता है। यह श्रेणी और श्रृंखला के नामों को चार्ट द्वारा प्रदर्शित संख्यात्मक मानों के साथ संग्रहीत करता है। Aspose.Slides में, यह कार्यपत्रक चार्ट डेटा वर्कबुक के माध्यम से उपलब्ध है, जो आपको प्रोग्रामेटिक रूप से चार्ट डेटा के साथ काम करने की अनुमति देता है।

यह लेख बताता है कि चार्ट डेटा में कार्यपत्रक सूत्रों का उपयोग कैसे किया जाए ताकि सेल के मान मैन्युअली दर्ज करने के बजाय स्वतः गणना और अद्यतन हो सकें। यह दिखाता है कि सूत्रों को कैसे असाइन किया जाए, A1-शैली और R1C1-शैली दोनों संदर्भों का उपयोग कैसे किया जाए, वर्कबुक सूत्रों को पुनः गणना कैसे करें, और प्रस्तुतीकरण में चार्ट कार्यपत्रकों के लिए उपलब्ध समर्थित स्थिरांक, ऑपरेटर, सेल संदर्भ और पूर्वनिर्धारित फ़ंक्शन के साथ कैसे काम किया जाए।

## **प्रस्तुतीकरण में चार्ट स्प्रेडशीट सूत्रों के बारे में**

**Chart spreadsheet** (या chart worksheet) प्रस्तुतीकरण में चार्ट का डेटा स्रोत है। Chart spreadsheet में डेटा होता है, जो चार्ट पर ग्राफ़िक रूप में प्रदर्शित होता है।  
जब आप PowerPoint में एक चार्ट बनाते हैं, तो इस चार्ट से जुड़ा कार्यपत्रक स्वचालित रूप से बन जाता है। चार्ट कार्यपत्रक सभी प्रकार के चार्टों के लिए बनाया जाता है: लाइन चार्ट, बार चार्ट, सनबर्स्ट चार्ट, पाई चार्ट आदि। PowerPoint में चार्ट स्प्रेडशीट देखने के लिए आपको चार्ट पर डबल‑क्लिक करना चाहिए:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet में चार्ट तत्वों के नाम होते हैं (Category Name: *Category1*, Serie Name) और एक तालिका जिसमें इन श्रेणियों और श्रृंखलाओं के अनुसार संख्यात्मक डेटा होता है। डिफ़ॉल्ट रूप से, जब आप नया चार्ट बनाते हैं, तो चार्ट स्प्रेडशीट डेटा डिफ़ॉल्ट डेटा से सेट होते हैं। फिर आप कार्यपत्रक में स्प्रेडशीट डेटा को मैन्युअल रूप से बदल सकते हैं।

आमतौर पर, चार्ट जटिल डेटा का प्रतिनिधित्व करता है (जैसे वित्तीय विशलेषण, वैज्ञानिक विशलेषण), जिसमें सेल अन्य सेलों के मानों या अन्य डायनामिक डेटा से गणना किए जाते हैं। सेल के मान को मैन्युअली गणना करके हार्ड‑कोड करने से भविष्य में इसे बदलना कठिन हो जाता है। यदि आप किसी विशेष सेल का मान बदलते हैं, तो उस पर निर्भर सभी सेलों को भी अपडेट करना पड़ेगा। इसके अलावा, तालिका डेटा अन्य तालिकाओं के डेटा पर निर्भर हो सकता है, जिससे प्रस्तुतीकरण डेटा योजना जटिल हो जाती है और इसे आसानी और लचीले ढंग से अपडेट करने की आवश्यकता होती है।

प्रस्तुतीकरण में **Chart spreadsheet formula** एक अभिव्यक्ति है जो स्वचालित रूप से चार्ट स्प्रेडशीट डेटा की गणना और अपडेट करती है। स्प्रेडशीट सूत्र किसी निश्चित सेल या सेल सेट के लिए डेटा गणना लॉजिक को परिभाषित करता है। स्प्रेडशीट सूत्र एक गणितीय सूत्र या तर्कसंगत सूत्र हो सकता है, जो उपयोग करता है: सेल संदर्भ, गणित फ़ंक्शन, तर्कसंगत ऑपरेटर, अंकगणितीय ऑपरेटर, रूपांतरण फ़ंक्शन, स्ट्रिंग स्थिरांक आदि। सूत्र की परिभाषा एक सेल में लिखी जाती है, और यह सेल केवल सरल मान नहीं रखता। स्प्रेडशीट सूत्र मान की गणना करता है और उसे वापस लौटाता है, फिर यह मान सेल को असाइन किया जाता है। प्रस्तुतीकरण में चार्ट स्प्रेडशीट सूत्र वास्तविक रूप से एक्सेल सूत्रों के समान हैं, तथा उनके कार्यान्वयन के लिए समान डिफ़ॉल्ट फ़ंक्शन, ऑपरेटर और स्थिरांक समर्थित हैं।

इन [**Aspose.Slides**](https://products.aspose.com/slides/hi/androidjava/) में चार्ट स्प्रेडशीट को [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) मेथड के द्वारा [**IChartDataWorkbook**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook) प्रकार में दर्शाया गया है।  
स्प्रेडशीट सूत्र को [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) मेथड द्वारा असाइन और बदल सकते हैं।  

आस्पोज़.स्लाइड्स में सूत्रों के लिए निम्नलिखित कार्यक्षमता समर्थित है:

- तार्किक स्थिरांक
- संख्यात्मक स्थिरांक
- स्ट्रिंग स्थिरांक
- त्रुटि स्थिरांक
- अंकगणितीय ऑपरेटर
- तुलना ऑपरेटर
- A1-शैली सेल संदर्भ
- R1C1-शैली सेल संदर्भ
- पूर्वनिर्धारित फ़ंक्शन

आम तौर पर, स्प्रेडशीट अंतिम गणना किए गए सूत्र मानों को संग्रहीत करता है। यदि प्रस्तुतीकरण लोड करने के बाद चार्ट डेटा नहीं बदला गया था - [**IChartDataCell.getValue**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataCell#getValue--) मेथड पढ़ते समय उन मानों को लौटाता है। लेकिन, यदि स्प्रेडशीट डेटा बदला गया हो, तो पढ़ते समय **ChartDataCell.Value** प्रोपर्टी [**CellUnsupportedDataException**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/CellUnsupportedDataException) फेंकती है उन असमर्थित सूत्रों के लिए। यह इसलिए है क्योंकि जब सूत्र सफलतापूर्वक पार्स होते हैं, तो सेल निर्भरताएँ निर्धारित होती हैं और अंतिम मानों की शुद्धता तय होती है। लेकिन यदि सूत्र पार्स नहीं किया जा सकता, तो सेल मान की शुद्धता की गारंटी नहीं दी जा सकती।

## **प्रस्तुतीकरण में चार्ट स्प्रेडशीट सूत्र जोड़ें**

पहले, नई प्रस्तुति की पहली स्लाइड में एक चार्ट जोड़ें [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) मेथड से। चार्ट का कार्यपत्रक स्वचालित रूप से बन जाता है और इसे [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) मेथड के द्वारा एक्सेस किया जा सकता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

सेलों में कुछ मान लिखें [**IChartDataCell.setValue**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) प्रोपर्टी के साथ, जो **Object** प्रकार की है, जिसका अर्थ है आप किसी भी मान को प्रोपर्टी में सेट कर सकते हैं:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

अब सेल में सूत्र लिखने के लिए, आप [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) मेथड का उपयोग कर सकते हैं:

*ध्यान दें*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) मेथड A1-शैली सेल संदर्भ सेट करने के लिए उपयोग किया जाता है।  

[R1C1Formula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) सेल संदर्भ सेट करने के लिए, आप [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) मेथड का उपयोग कर सकते हैं:

फिर यदि आप सेल B2 और C2 के मान पढ़ने का प्रयास करेंगे, तो वे गणना किए जाएंगे:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **तार्किक स्थिरांक**

आप सेल सूत्रों में *FALSE* और *TRUE* जैसे तार्किक स्थिरांक उपयोग कर सकते हैं:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // मान में बूलियन "false" शामिल है
```

## **संख्यात्मक स्थिरांक**

संख्याओं का उपयोग सामान्य या वैज्ञानिक संकेतन में करके चार्ट स्प्रेडशीट सूत्र बनाया जा सकता है:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **स्ट्रिंग स्थिरांक**

स्ट्रिंग (या लिटरल) स्थिरांक वह विशिष्ट मान है जिसे जैसे का तैसा उपयोग किया जाता है और वह नहीं बदलता। स्ट्रिंग स्थिरांक में दिनांक, टेक्स्ट, संख्या आदि शामिल हो सकते हैं:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **त्रुटि स्थिरांक**

कभी‑कभी सूत्र द्वारा परिणाम की गणना संभव नहीं होती। ऐसे मामलों में, सेल में उसका मान नहीं बल्कि त्रुटि कोड दिखाया जाता है। प्रत्येक प्रकार की त्रुटि का एक विशिष्ट कोड होता है:

- #DIV/0! - सूत्र शून्य से भाग करने का प्रयास करता है।
- #GETTING_DATA - सेल पर दिख सकता है जबकि उसका मान अभी गणना हो रहा है।
- #N/A - सूचना गायब है या उपलब्ध नहीं है। इसके कारण हो सकते हैं: सूत्र में प्रयुक्त सेल खाली होना, अतिरिक्त स्पेस कैरेक्टर, वर्तनी त्रुटि आदि।
- #NAME? - किसी सेल या अन्य सूत्र वस्तु को उसके नाम से नहीं पाया जा सका।
- #NULL! - सूत्र में त्रुटि के कारण हो सकता है, जैसे (,) या कॉलन (:) के स्थान पर स्पेस कैरेक्टर।
- #NUM! - सूत्र में संख्यात्मक मान अमान्य, बहुत बड़ा या बहुत छोटा हो सकता है।
- #REF! - अमान्य सेल संदर्भ।
- #VALUE! - अपेक्षित प्रकार का मान नहीं, उदाहरण के लिए स्ट्रिंग मान को संख्यात्मक सेल में सेट करना।

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // मान में स्ट्रिंग "#DIV/0!" शामिल है
```

## **अंकगणितीय ऑपरेटर**

आप चार्ट कार्यपत्रक सूत्रों में सभी अंकगणितीय ऑपरेटर उपयोग कर सकते हैं:

|**ऑपरेटर**|**अर्थ**|**उदाहरण**|
| :- | :- | :- |
|+ (plus sign)|जोड़ या यूनरी प्लस|2 + 3|
|- (minus sign)|घटाव या नकारात्मक|2 - 3<br>-3|
|* (asterisk)|गुणन|2 * 3|
|/ (forward slash)|भाग|2 / 3|
|% (percent sign)|प्रतिशत|30%|
|^ (caret)|घातांक|2 ^ 3|

*ध्यान दें*: मूल्यांकन क्रम बदलने के लिए, सबसे पहले गणना किए जाने वाले भाग को कोष्ठकों में रखें।

## **तुलना ऑपरेटर**

आप तुलना ऑपरेटरों के माध्यम से सेल मानों की तुलना कर सकते हैं। इन ऑपरेटरों से दो मानों की तुलना करने पर परिणाम *TRUE* या *FALSE* तर्कसंगत मान होता है:

|**ऑपरेटर**|**अर्थ**|**अर्थ**|
| :- | :- | :- |
|= (equal sign)|समान|A2 = 3|
|<> (not equal sign)|असमान|A2 <> 3|
|> (greater than sign)|से बड़ा|A2 > 3|
|>= (greater than or equal to sign)|से बड़ा या बराबर|A2 >= 3|
|< (less than sign)|से छोटा|A2 < 3|
|<= (less than or equal to sign)|से छोटा या बराबर|A2 <= 3|

## **A1-शैली सेल संदर्भ**

**A1-शैली सेल संदर्भ** कार्यपत्रकों में उपयोग होते हैं, जहाँ कॉलम का पहचानकर्ता अक्षर (जैसे "*A*") और पंक्ति का पहचानकर्ता संख्या (जैसे "*1*") होता है। A1-शैली सेल संदर्भ निम्न प्रकार उपयोग किए जा सकते हैं:

|**सेल संदर्भ**|**उदाहरण**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

यहाँ एक उदाहरण है कि A1-शैली सेल संदर्भ को सूत्र में कैसे उपयोग किया जाता है:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1-शैली सेल संदर्भ**

**R1C1-शैली सेल संदर्भ** कार्यपत्रकों में उपयोग होते हैं, जहाँ पंक्ति और कॉलम दोनों का संख्यात्मक पहचानकर्ता होता है। R1C1-शैली सेल संदर्भ निम्न प्रकार उपयोग किए जा सकते हैं:

|**सेल संदर्भ**|**उदाहरण**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

यहाँ एक उदाहरण है कि R1C1-शैली सेल संदर्भ को सूत्र में कैसे उपयोग किया जाता है:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **पूर्वनिर्धारित फ़ंक्शन**

ऐसे पूर्वनिर्धारित फ़ंक्शन हैं, जो सूत्रों में उपयोग किए जा सकते हैं ताकि उनका कार्यान्वयन सरल हो सके। ये फ़ंक्शन आमतौर पर उपयोग किए जाने वाले संचालन को सम्मिलित करते हैं, जैसे:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सूत्रों वाले चार्ट के डेटा स्रोत के रूप में बाहरी Excel फ़ाइलें समर्थित हैं?**

Yes. Aspose.Slides supports external workbooks as a [chart's data source](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdatasourcetype/), which lets you use formulas from an XLSX outside the presentation.

**क्या चार्ट सूत्र उसी वर्कबुक की शीट नाम से शीट को संदर्भित कर सकते हैं?**

Yes. Formulas follow the standard Excel reference model, so you can reference other sheets within the same workbook or an external workbook. For external references, include the path and workbook name using Excel syntax.