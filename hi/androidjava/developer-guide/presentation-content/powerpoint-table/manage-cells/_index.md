---
title: Android पर प्रस्तुतियों में तालिका कोशिकाएँ प्रबंधित करें
linktitle: कोशिकाएँ प्रबंधित करें
type: docs
weight: 30
url: /hi/androidjava/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java के माध्यम से Android के लिए Aspose.Slides के साथ PowerPoint में तालिका कोशिकाओं को सहजता से प्रबंधित करें। शीघ्रता से कोशिकाओं तक पहुँच, संशोधन और शैलियों को नियंत्रित कर स्लाइड ऑटोमेशन को निर्बाध बनाएं।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की सुविधा देता है। यह लेख बताता है कि मर्ज की गई तालिका कोशिकाओं की पहचान कैसे करें, कोशिका की सीमाएँ कैसे हटाएँ, मर्ज या विभाजन के बाद कोशिका क्रमांक कैसे काम करता है, कोशिका की पृष्ठभूमि रंग कैसे बदलें, और तालिका कोशिका के भीतर छवि कैसे जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएँ या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका स्वरूपण अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

## **मर्ज की गई तालिका कोशिका की पहचान करें**
1.  [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2.  पहली स्लाइड से तालिका प्राप्त करें। 
3.  तालिका की पंक्तियों और स्तंभों के माध्यम से इटररेट करके मर्ज किए गए कोशिकाओं को खोजें।
4.  जब मर्ज की गई कोशिकाएँ मिलें तो संदेश प्रिंट करें।

यह Java कोड दिखाता है कि प्रस्तुति में मर्ज की गई तालिका कोशिकाओं की पहचान कैसे करें:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // मानते हुए कि Slide#0.Shape#0 एक तालिका है
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका कोशिका की सीमाएँ हटाएँ**
1.  [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2.  स्लाइड के इंडेक्स द्वारा उसका रेफ़रेंस प्राप्त करें। 
3.  चौड़ाई के साथ स्तंभों की एक एरे परिभाषित करें।
4.  ऊँचाई के साथ पंक्तियों की एक एरे परिभाषित करें।
5.  [addTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) मेथड के द्वारा स्लाइड में तालिका जोड़ें।
6.  प्रत्येक कोशिका के शीर्ष, नीचे, दाएं और बाएं सीमाएँ साफ करने के लिए इटररेट करें।
7.  संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Java कोड दिखाता है कि तालिका कोशिकाओं की सीमाएँ कैसे हटाएँ:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // स्लाइड में तालिका आकार जोड़ता है
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // PPTX को डिस्क पर लिखता है
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **मर्ज की गई कोशिकाओं में क्रमांकन**
यदि हम दो जोड़ों की कोशिकाओं (1, 1) × (2, 1) और (1, 2) × (2, 2) को मर्ज करते हैं, तो परिणामी तालिका क्रमांकित होगी। यह Java कोड प्रक्रिया दर्शाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में तालिका आकार जोड़ता है
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // कोशिकाओं (1, 1) x (2, 1) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // कोशिकाओं (1, 2) x (2, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

फिर हम कोशिकाओं को आगे मर्ज करते हैं, (1, 1) और (1, 2) को मर्ज करके। परिणामस्वरूप एक बड़ी मर्ज की गई कोशिका के साथ मध्य में तालिका बनती है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में तालिका आकार जोड़ता है
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // कोशिकाओं (1, 1) x (2, 1) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // कोशिकाओं (1, 2) x (2, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // कोशिकाओं (1, 1) x (1, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
	
	//PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विभाजित कोशिका में क्रमांकन**
पिछले उदाहरणों में, जब तालिका कोशिकाओं को मर्ज किया गया, तो अन्य कोशिकाओं में क्रमांकन या संख्या प्रणाली नहीं बदली। 

इस बार हम एक सामान्य तालिका (बिना मर्ज की हुई) लेते हैं और फिर (1,1) कोशिका को विभाजित करने का प्रयास करते हैं ताकि एक विशेष तालिका प्राप्त हो सके। आपको इस तालिका के क्रमांकन पर ध्यान देना चाहिए, जो थोड़ा अजीब लग सकता है। हालांकि, यही Microsoft PowerPoint तालिका कोशिकाओं को क्रमांकित करता है और Aspose.Slides भी यही करता है। 

यह Java कोड उस प्रक्रिया को दर्शाता है जिसका हमने उल्लेख किया:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में तालिका आकार जोड़ता है
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // कोशिकाओं (1, 1) x (2, 1) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // कोशिकाओं (1, 2) x (2, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // कोशिका (1, 1) को विभाजित करता है
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

यह Java कोड दिखाता है कि तालिका कोशिका का पृष्ठभूमि रंग कैसे बदलें:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // नई तालिका बनाएं
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // सेल की पृष्ठभूमि रंग सेट करें
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **तालिका कोशिका के भीतर छवि जोड़ें**

1.  [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2.  स्लाइड के इंडेक्स द्वारा उसका रेफ़रेंस प्राप्त करें।
3.  चौड़ाई के साथ स्तंभों की एक एरे परिभाषित करें।
4.  ऊँचाई के साथ पंक्तियों की एक एरे परिभाषित करें।
5.  [AddTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) मेथड के द्वारा स्लाइड में तालिका जोड़ें।
6.  छवि फ़ाइल रखने के लिए एक `Images` ऑब्जेक्ट बनाएँ।
7.  `IImage` छवि को `IPPImage` ऑब्जेक्ट में जोड़ें।
8.  तालिका कोशिका के लिए `FillFormat` को `Picture` सेट करें।
9.  छवि को तालिका की पहली कोशिका में जोड़ें।
10. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Java कोड दिखाता है कि तालिका बनाते समय तालिका कोशिका के भीतर छवि कैसे रखें:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide islide = pres.getSlides().get_Item(0);

    // स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // स्लाइड में तालिका आकार जोड़ता है
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // छवि फ़ाइल का उपयोग करके एक IPPImage ऑब्जेक्ट बनाता है
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // छवि को पहली तालिका कोशिका में जोड़ता है
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग‑अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हां। [top](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellformat/#getBorderRight--) सीमाओं की अलग‑अलग प्रॉपर्टी होती है, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है। यह लेख में प्रदर्शित कोशिका की प्रति‑पक्ष सीमा नियंत्रण से तार्किक रूप से जुड़ा है।

**अगर मैं चित्र को कोशिका की पृष्ठभूमि के रूप में सेट करने के बाद कॉलम/पंक्ति का आकार बदलूँ तो छवि क्या करेगी?**

व्यवहार [fill mode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग के साथ, छवि नई कोशिका के अनुसार समायोजित होती है; टाइलिंग के साथ, टाइलें पुनः गणना की जाती हैं। लेख में कोशिका में छवि प्रदर्शन मोडों का उल्लेख है।

**क्या मैं कोशिका की सभी सामग्री को एक हाइपरलिंक दे सकता हूँ?**

[Hyperlinks](/slides/hi/androidjava/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/shape स्तर पर सेट किया जाता है। व्यावहारिक रूप से, आप लिंक को एक portion या कोशिका के सभी टेक्स्ट को असाइन करते हैं।

**क्या मैं एक ही कोशिका के भीतर अलग‑अलग फ़ॉन्ट सेट कर सकता हूँ?**

हां। एक कोशिका का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) (runs) को स्वतंत्र स्वरूपण—फ़ॉन्ट फ़ॅमिली, शैली, आकार और रंग—के साथ समर्थन देता है।