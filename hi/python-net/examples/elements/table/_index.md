---
title: टेबल
type: docs
weight: 120
url: /hi/python-net/examples/elements/table/
keywords:
- टेबल
- टेबल जोड़ें
- टेबल तक पहुँचें
- टेबल हटाएँ
- सेल्स मर्ज करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में तालिकाएं बनाएं और स्वरूपित करें: डेटा सम्मिलित करें, सेल्स मर्ज करें, बॉर्डर स्टाइल करें, सामग्री संरेखित करें, और PPT, PPTX और ODP के लिए आयात/निर्यात करें।"
---
**Aspose.Slides for Python via .NET** का उपयोग करके तालिकाएँ जोड़ने, उनका एक्सेस करने, उन्हें हटाने और सेल्स को मर्ज करने के उदाहरण।

## **तालिका जोड़ें**

दो पंक्तियों और दो स्तंभों वाली एक साधारण तालिका बनाएँ।

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # कॉलम चौड़ाई और पंक्ति ऊँचाई निर्धारित करें।
        widths = [80, 80]
        heights = [30, 30]

        # स्लाइड में एक टेबल शेप जोड़ें।
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका तक पहुँचें**

स्लाइड पर पहली तालिका shape प्राप्त करें।

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # स्लाइड पर पहली तालिका तक पहुँचें।
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **तालिका हटाएँ**

स्लाइड से एक तालिका हटाएँ।

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लें कि पहली shape एक तालिका है।
        table = slide.shapes[0]

        # स्लाइड से तालिका हटाएँ।
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **तालिका सेल्स को मर्ज करें**

तालिका की सन्निहित सेल्स को एकल सेल में मर्ज करें।

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहली shape एक तालिका है।
        table = slide.shapes[0]

        # कोशिकाओं को मिलाएँ।
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```