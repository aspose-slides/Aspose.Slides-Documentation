---
title: प्रेजेंटेशन में जावा का उपयोग करके तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाएँ प्रबंधित करें
type: docs
weight: 30
url: /hi/java/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint में तालिका कोशिकाओं का सहजता से प्रबंधन करें। शीघ्रता से कोशिकाओं तक पहुंच, संशोधन और शैलीकरण में निपुण बनें, ताकि स्लाइड ऑटोमेशन सुगम हो सके।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुंचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बताता है कि मर्ज की गई तालिका कोशिकाओं की पहचान कैसे करें, कोशिका की सीमाओं को कैसे हटाएँ, मर्ज या विभाजन के बाद कोशिका क्रमांकन के साथ कैसे कार्य करें, कोशिका की पृष्ठभूमि रंग कैसे बदलें, और तालिका कोशिका के भीतर एक छवि कैसे जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएँ या खोलें, स्लाइड से तालिका कैसे प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका फ़ॉर्मेटिंग कैसे अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में कैसे सहेजें।

## **मर्ज की गई तालिका कोशिका की पहचान करें**
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. पहली स्लाइड से तालिका प्राप्त करें।
3. मर्ज की गई कोशिकाओं को खोजने के लिए तालिका की पंक्तियों और स्तंभों पर इटरेट करें।
4. जब मर्ज की गई कोशिकाएँ मिलें तो संदेश प्रिंट करें।

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
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
3. चौड़ाई के साथ स्तंभों की एक एरे परिभाषित करें।
4. ऊँचाई के साथ पंक्तियों की एक एरे परिभाषित करें।
5. स्लाइड में तालिका जोड़ने के लिए [addTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) मेथड का उपयोग करें।
6. प्रत्येक कोशिका पर इटरेट करके ऊपर, नीचे, दाएँ और बाएँ सीमाओं को साफ़ करें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Java कोड दिखाता है कि तालिका कोशिकाओं की सीमाओं को कैसे हटाएँ:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुंचता है
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // चौड़ाइयों के साथ कॉलम और ऊँचाइयों के साथ पंक्तियों को परिभाषित करता है
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // स्लाइड में टेबल शैप जोड़ता है
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

## **मर्ज की गई कोशिकाओं में क्रमांक**
यदि हम 2 जोड़े कोशिकाओं (1, 1) x (2, 1) और (1, 2) x (2, 2) को मर्ज करते हैं, तो परिणामी तालिका क्रमांकित होगी। यह Java कोड इस प्रक्रिया को दर्शाता है:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टांस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुंचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // चौड़ाइयों के साथ कॉलम और ऊँचाइयों के साथ पंक्तियों को परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में एक टेबल शैप जोड़ता है
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

    // कोशिकाएँ (1, 1) x (2, 1) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // कोशिकाएँ (1, 2) x (2, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

फिर हम (1, 1) और (1, 2) को मर्ज करके कोशिकाओं को आगे मर्ज करते हैं। परिणामस्वरूप एक तालिका का केंद्र में एक बड़ी मर्ज की गई कोशिका होगी:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टांस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुंचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // चौड़ाइयों के साथ कॉलम और ऊँचाइयों के साथ पंक्तियों को परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में एक टेबल शैप जोड़ता है
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

    // कोशिकाएँ (1, 1) x (2, 1) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // कोशिकाएँ (1, 2) x (2, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // कोशिकाएँ (1, 1) x (1, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	//PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विभाजित कोशिका में क्रमांक**
पिछले उदाहरणों में, जब तालिका कोशिकाएँ मर्ज हुईं, तो अन्य कोशिकाओं में क्रमांकन या संख्या प्रणाली नहीं बदली।

इस बार, हम एक नियमित तालिका (बिना मर्ज कोशिकाओं वाली तालिका) लेते हैं और फिर कोशिका (1,1) को विभाजित करने का प्रयास करते हैं ताकि एक विशेष तालिका प्राप्त हो सके। आप इस तालिका के क्रमांकन पर ध्यान देना चाहेंगे, जो अजीब लग सकता है। हालांकि, यह Microsoft PowerPoint द्वारा तालिका कोशिकाओं को क्रमांकित करने का तरीका है और Aspose.Slides भी यही करता है।

यह Java कोड उस प्रक्रिया को दर्शाता है जिसका हमने वर्णन किया था:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुंचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // चौड़ाइयों के साथ कॉलम और ऊँचाइयों के साथ पंक्तियों को परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में एक टेबल शैप जोड़ता है
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

    // कोशिकाएँ (1, 1) x (2, 1) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // कोशिकाएँ (1, 2) x (2, 2) को मर्ज करता है
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

    // कोशिका के लिए पृष्ठभूमि रंग सेट करें 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **तालिका कोशिका के भीतर एक छवि जोड़ें**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
3. चौड़ाई के साथ स्तंभों की एक एरे परिभाषित करें।
4. ऊँचाई के साथ पंक्तियों की एक एरे परिभाषित करें।
5. स्लाइड में तालिका जोड़ने के लिए [AddTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) मेथड का उपयोग करें।
6. `Images` ऑब्जेक्ट बनाकर छवि फ़ाइल रखें।
7. `IImage` छवि को `IPPImage` ऑब्जेक्ट में जोड़ें।
8. तालिका कोशिका के `FillFormat` को `Picture` सेट करें।
9. छवि को तालिका की पहली कोशिका में जोड़ें।
10. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Java कोड दर्शाता है कि तालिका बनाते समय तालिका कोशिका के भीतर छवि कैसे रखें:

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुंचता है
    ISlide islide = pres.getSlides().get_Item(0);

    // चौड़ाइयों के साथ कॉलम और ऊँचाइयों के साथ पंक्तियों को परिभाषित करता है
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // स्लाइड में एक टेबल शैप जोड़ता है
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // इमेज फ़ाइल का उपयोग करके IPPImage ऑब्जेक्ट बनाता है
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // पहली तालिका कोशिका में छवि जोड़ता है
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

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग-अलग लाइन मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellformat/#getBorderRight--) सीमाओं की अलग-अलग प्रॉपर्टीज़ हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है। यह लेख में दिखाए गए कोशिका के प्रति‑पार्श्व सीमा नियंत्रण से तर्कसंगत रूप से अनुसरण करता है।

**यदि मैं चित्र को कोशिका की पृष्ठभूमि के रूप में सेट करने के बाद स्तंभ/पंक्ति का आकार बदलता हूँ तो छवि के साथ क्या होता है?**

यह व्यवहार [fill mode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग पर, छवि नए कोशिका के अनुसार समायोजित होती है; टाइलिंग पर, टाइलें पुनः गणना की जाती हैं। लेख में कोशिका में छवि प्रदर्शन मोड्स का उल्लेख किया गया है।

**क्या मैं एक कोशिका की सभी सामग्री को हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/java/manage-hyperlinks/) को सेल के टेक्स्ट फ़्रेम के भीतर टेक्स्ट (portion) स्तर या पूरी तालिका/शेप स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को किसी भाग या सेल के सभी टेक्स्ट को असाइन करते हैं।

**क्या मैं एक ही कोशिका में अलग-अलग फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। एक कोशिका का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) (रन) का समर्थन करता है जिनमें स्वतंत्र फ़ॉर्मेटिंग—फ़ॉन्ट परिवार, शैली, आकार और रंग—होती है।