---
title: Python के साथ प्रस्तुतियों आयात करें
linktitle: प्रस्तुति आयात करें
type: docs
weight: 60
url: /hi/python-net/import-presentation/
keywords:
- PowerPoint आयात
- प्रस्तुति आयात
- स्लाइड आयात
- PDF से प्रस्तुति
- PDF से PPT
- PDF से PPTX
- PDF से ODP
- HTML से प्रस्तुति
- HTML से PPT
- HTML से PPTX
- HTML से ODP
- Python
- Aspose.Slides
description: "Python में Aspose.Slides के साथ PDF और HTML दस्तावेज़ों को PowerPoint और OpenDocument प्रस्तुतियों में आसानी से आयात करें, जिससे सहज और उच्च-प्रदर्शन स्लाइड प्रोसेसिंग प्राप्त हो।"
---
## **परिचय**

With [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/hi/python-net/), you can import content into a presentation from other file formats. The [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) class provides methods to import slides from PDF, HTML, and other sources.

## **PDF को प्रस्तुति में बदलें**

This section shows how to convert a PDF into a presentation using Aspose.Slides. It walks you through importing the PDF, turning its pages into slides, and saving the result as a PPTX file.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class.
2. Call the [add_from_pdf](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_from_pdf/) method and pass the PDF file.
3. Use the [save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) method to save the presentation in PowerPoint format.

The following Python example demonstrates converting a PDF to a presentation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
आप Aspose का मुफ्त PDF से PowerPoint वेब ऐप आज़मा सकते हैं — यह यहाँ वर्णित प्रक्रिया का एक लाइव कार्यान्वयन है।
{{% /alert %}}

## **HTML को प्रस्तुति में बदलें**

This section shows how to import HTML content into a presentation using Aspose.Slides. It covers loading the HTML, transforming it into slides with preserved text, images, and basic formatting, and saving the result as a PPTX file.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class.
2. Call the [add_from_html](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_from_html/) method and pass the HTML file. 
3. Use the [save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) method to save the presentation in PowerPoint format.

The following Python example demonstrates converting an HTML to a presentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PDF आयात करते समय तालिकाएँ संरक्षित रहती हैं, और उनकी पहचान को सुधारा जा सकता है?**

Tables can be detected during import; [PdfImportOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.importing/pdfimportoptions/) includes a [detect_tables](https://reference.aspose.com/slides/hi/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) parameter that enables table recognition. The effectiveness depends on the PDF’s structure.

{{% alert title="Note" color="info" %}}
You can also use Aspose.Slides to convert HTML into other popular file formats:

* [HTML to image](https://products.aspose.com/slides/hi/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/hi/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/hi/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/hi/python-net/conversion/html-to-tiff/)

{{% /alert %}}