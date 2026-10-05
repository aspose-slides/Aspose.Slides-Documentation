---
title: Python के साथ प्रस्तुतियों में OLE का प्रबंधन
linktitle: OLE प्रबंधन
type: docs
weight: 40
url: /hi/python-net/manage-ole/
keywords:
- OLE ऑब्जेक्ट
- ऑब्जेक्ट लिंकिंग एवं एम्बेडिंग
- OLE जोड़ें
- OLE एम्बेड करें
- ऑब्जेक्ट जोड़ें
- ऑब्जेक्ट एम्बेड करें
- फ़ाइल जोड़ें
- फ़ाइल एम्बेड करें
- लिंक्ड ऑब्जेक्ट
- लिंक्ड फ़ाइल
- OLE बदलें
- OLE आइकन
- OLE शीर्षक
- OLE निकालें
- ऑब्जेक्ट निकालें
- फ़ाइल निकालें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="info" title="ध्यान दें" %}}

**OLE (Object Linking & Embedding)** एक Microsoft तकनीक है जो किसी एक एप्लिकेशन में बनाए गए डेटा और ऑब्जेक्ट्स को दूसरे एप्लिकेशन में लिंक या एम्बेड करने की अनुमति देती है।

{{% /alert %}}

उदाहरण के लिए, Microsoft Excel में बनाया गया एक चार्ट जिसे PowerPoint स्लाइड पर रखा गया है, वह एक OLE ऑब्जेक्ट है।

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। आइकन पर डबल‑क्लिक करने से ऑब्जेक्ट उसके सम्बंधित एप्लिकेशन (जैसे Excel) में खुलता है या आपको इसे खोलने या संपादित करने के लिए कोई ऐप चुनने का संकेत देता है।
- एक OLE ऑब्जेक्ट अपनी सामग्री (उदाहरण के लिए, एक चार्ट) प्रदर्शित कर सकता है। इस स्थिति में, PowerPoint एम्बेडेड ऑब्जेक्ट को सक्रिय करता है, चार्ट इंटरफ़ेस लोड करता है, और आपको PowerPoint के भीतर ही चार्ट डेटा को संपादित करने की अनुमति देता है।

Aspose.Slides for Python आपको OLE ऑब्जेक्ट्स को स्लाइड्स में OLE ऑब्जेक्ट फ्रेम के रूप में डालने की अनुमति देता है ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/))।

## **स्लाइड्स में OLE ऑब्जेक्ट्स जोड़ें**

यदि आप पहले ही Microsoft Excel में एक चार्ट बना चुके हैं और Aspose.Slides for Python का उपयोग करके उसे OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. स्लाइड को उसके सूचकांक से प्राप्त करें।
1. Excel फ़ाइल को बाइट ऐरे में पढ़ें।
1. स्लाइड में एक [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) जोड़ें, बाइट ऐरे और अन्य OLE ऑब्जेक्ट विवरण प्रदान करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिए गए उदाहरण में, एक Excel फ़ाइल से चार्ट को स्लाइड में एक [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) के रूप में एम्बेड किया गया है।

**ध्यान दें:** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) कंस्ट्रक्टर एम्बेडेबल ऑब्जेक्ट की फ़ाइल एक्सटेंशन को अपने दूसरे पैरामीटर के रूप में लेता है। PowerPoint इस एक्सटेंशन का उपयोग फ़ाइल प्रकार की पहचान करने और OLE ऑब्जेक्ट खोलने के लिये उपयुक्त एप्लिकेशन चुनने में करता है।

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # OLE ऑब्जेक्ट के लिये डेटा तैयार करें।
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **लिंक्ड OLE ऑब्जेक्ट्स जोड़ें**

Aspose.Slides for Python आपको एक [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) जोड़ने देता है जो डेटा एम्बेड करने के बजाय फ़ाइल से लिंक करता है।

निम्न Python उदाहरण एक स्लाइड पर Excel फ़ाइल से लिंक किए हुए एक [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) को कैसे जोड़ना है दर्शाता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE ऑब्जेक्ट्स तक पहुँचें**

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप इसे निम्न प्रकार से एक्सेस कर सकते हैं:

1. Presentation क्लास का एक उदाहरण बनाकर उस प्रेज़ेंटेशन को लोड करें जिसमें एम्बेडेड OLE ऑब्जेक्ट है।
1. स्लाइड को उसके सूचकांक से प्राप्त करें।
1. OleObjectFrame आकार (shape) तक पहुँचें।
1. एक बार जब आपके पास OLE ऑब्जेक्ट फ्रेम हो, तो उस पर आवश्यक कोई भी ऑपरेशन करें।

नीचे दिया गया उदाहरण OLE ऑब्जेक्ट फ्रेम—एक एम्बेडेड Excel चार्ट—को एक्सेस करता है और उसकी फ़ाइल डेटा को प्राप्त करता है। इस उदाहरण में हम एक PPTX का उपयोग करते हैं जिसमें पहली स्लाइड पर एक ही आकार (shape) है।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # एम्बेडेड फ़ाइल डेटा प्राप्त करें।
        file_data = ole_frame.embedded_data.embedded_file_data

        # एम्बेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **लिंक्ड OLE ऑब्जेक्ट गुणों तक पहुँचें**

Aspose.Slides आपको एक लिंक्ड OLE ऑब्जेक्ट फ्रेम के गुणों तक पहुँचने की सुविधा देता है।

नीचे दिया गया Python उदाहरण जाँचता है कि OLE ऑब्जेक्ट लिंक्ड है या नहीं और यदि है तो लिंक्ड फ़ाइल का पथ प्राप्त करता है:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # जाँचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
        if ole_frame.is_object_link:
            # लिंक्ड फ़ाइल का पूर्ण पाथ प्रिंट करें।
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # यदि उपलब्ध हो तो लिंक्ड फ़ाइल का रिलेटिव पाथ प्रिंट करें।
            # केवल .ppt प्रेज़ेंटेशन में रिलेटिव पाथ हो सकता है।
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" title="ध्यान दें" %}}

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/) का उपयोग करता है।

{{% /alert %}}

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप इसे एक्सेस करके उसके डेटा को इस प्रकार संशोधित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाकर प्रेज़ेंटेशन को लोड करें।
1. लक्ष्य स्लाइड को उसके सूचकांक से प्राप्त करें।
1. [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) आकार (shape) तक पहुँचें।
1. एक बार जब आपके पास OLE ऑब्जेक्ट फ्रेम हो, तो उस पर आवश्यक ऑपरेशन करें।
1. एक `Workbook` ऑब्जेक्ट बनाएँ और OLE डेटा पढ़ें।
1. इच्छित `Worksheet` खोलें और डेटा संपादित करें।
1. अद्यतित `Workbook` को एक स्ट्रीम में सहेजें।
1. उस स्ट्रीम का उपयोग करके OLE ऑब्जेक्ट के डेटा को बदलें।

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (एक एम्बेडेड Excel चार्ट) को एक्सेस किया गया है और उसकी फ़ाइल डेटा को संशोधित करके चार्ट को अपडेट किया गया है। यह नमूना पहले से बनाई गई PPTX का उपयोग करता है जिसमें पहली स्लाइड पर एक ही आकार (shape) है।

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Workbook डेटा को संशोधित करें।
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # OLE फ्रेम ऑब्जेक्ट डेटा बदलें।
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड्स में फ़ाइलें एम्बेड करें**

Excel चार्ट के अलावा, Aspose.Slides for Python आपको स्लाइड्स में अन्य फ़ाइल प्रकारों को एम्बेड करने की भी अनुमति देता है। उदाहरण के लिए, आप HTML, PDF और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में डाल सकते हैं। जब उपयोगकर्ता एक सम्मिलित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से सम्बंधित एप्लिकेशन में खुल जाता है, या उपयोगकर्ता से उपयुक्त प्रोग्राम चुनने का संकेत दिया जाता है।

यह Python कोड दिखाता है कि एक स्लाइड में HTML और ZIP फ़ाइलों को कैसे एम्बेड किया जाता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार सेट करें**

प्रेज़ेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित में बदलना पड़ सकता है। Aspose.Slides for Python आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की सुविधा देता है, जिससे आप OLE फ्रेम डेटा या उसकी फ़ाइल एक्सटेंशन को अपडेट कर सकते हैं।

यह Python कोड दिखाता है कि एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` कैसे सेट करें:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # फ़ाइल प्रकार को ZIP में बदलें।
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करें**

एक OLE ऑब्जेक्ट एम्बेड करने के बाद, एक आइकन‑आधारित प्रीव्यू स्वचालित रूप से जोड़ा जाता है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट तक पहुँचने या उसे खोलने से पहले देखते हैं। यदि आप प्रीव्यू में कोई विशिष्ट चित्र और पाठ उपयोग करना चाहते हैं, तो आप Aspose.Slides for Python का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह Python कोड दिखाता है कि एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक कैसे सेट करें:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # प्रस्तुति संसाधनों में एक छवि जोड़ें।
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE प्रीव्यू के लिए एक शीर्षक और छवि सेट करें।
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE ऑब्जेक्ट फ्रेम्स को आकार बदलने और पुनः‑स्थापित होने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को स्लाइड में जोड़ते हैं, तो PowerPoint प्रेज़ेंटेशन खोलते समय लिंक अपडेट करने के लिये संकेत दे सकता है। 'Update Links' चुनने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड ऑब्जेक्ट से डेटा लेकर प्रीव्यू को रिफ्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने का संकेत देने से रोकने के लिये, [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) क्लास की `update_automatic` प्रॉपर्टी को `False` सेट करें:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for Python आपको स्लाइड्स में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलें इस प्रकार निकालने की अनुमति देता है:

1. उस [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ जिसमें आप जिन OLE ऑब्जेक्ट्स को निकालना चाहते हैं वे मौजूद हैं।
1. प्रेज़ेंटेशन में सभी आकारों (shapes) को पार करें और OLEObjectFrame आकारों को खोजें।
1. प्रत्येक [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) से एम्बेडेड फ़ाइल डेटा निकालें और डिस्क पर लिखें।

नीचे दिया गया Python कोड दिखाता है कि कैसे एक स्लाइड में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलें निकाली जा सकती हैं:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**क्या OLE सामग्री स्लाइड्स को PDF/छवियों में निर्यात करते समय रेंडर की जाएगी?**

स्लाइड पर जो दिखता है वह रेंडर किया जाता है—आइकन/प्रतिस्थापन चित्र (प्रीव्यू)। "लाइव" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो निर्यात किए गए PDF में अपेक्षित रूप दिखाने के लिये अपना स्वयं का प्रीव्यू चित्र सेट करें।

एम्बेडेड फ़ाइल को PDF अटैचमेंट के रूप में भी संरक्षित रखने के लिये, [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) को `True` सेट करें। यह विकल्प डिफ़ॉल्ट रूप से अक्षम है। एक उदाहरण और अटैचमेंट की जाँच करने के निर्देश के लिये देखें [Preserve Embedded OLE Files as PDF Attachments](/slides/hi/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)।

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक कर सकता हूँ ताकि उपयोगकर्ता PowerPoint में उसे हलचल/संपादित न कर सकें?**

आकार (shape) को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/python-net/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और आंदोलन को प्रभावी रूप से रोकता है।

**मैं जब प्रेज़ेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट क्यों "जम्प" करता है या उसका आकार बदल जाता है?**

PowerPoint लिंक्ड OLE का प्रीव्यू रिफ्रेश कर सकता है। एक स्थिर रूप के लिये, [Working Solution for Worksheet Resizing](/slides/hi/python-net/working-solution-for-worksheet-resizing/) की दिशानिर्देशों का पालन करें—या तो फ्रेम को रेंज के अनुरूप फिट करें, या रेंज को स्थिर फ्रेम में स्केल करके उपयुक्त प्रतिस्थापन चित्र सेट करें।

**क्या लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ PPTX प्रारूप में संरक्षित रहते हैं?**

PPTX में "रिलेटिव पाथ" जानकारी उपलब्ध नहीं है—केवल पूर्ण पाथ रहता है। रिलेटिव पाथ पुरानी PPT फ़ॉर्मेट में पाया जाता है। पोर्टेबिलिटी के लिये विश्वसनीय पूर्ण पाथ/सुलभ URI या एम्बेडिंग को प्राथमिकता दें।