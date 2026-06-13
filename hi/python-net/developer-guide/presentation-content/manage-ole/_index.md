---
title: Python का उपयोग करके प्रस्तुतियों में OLE प्रबंधन
linktitle: OLE प्रबंधन
type: docs
weight: 40
url: /hi/python-net/manage-ole/
keywords:
- OLE ऑब्जेक्ट
- ऑब्जेक्ट लिंकिंग और एम्बेडिंग
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
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सुगमता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert title="Info" color="info" %}}

**OLE (ऑब्जेक्ट लिंकिंग & एम्बेडिंग)** एक Microsoft तकनीक है जो एक एप्लिकेशन में बनाई गई डेटा और ऑब्जेक्ट्स को किसी अन्य में लिंक या एम्बेड करने की अनुमति देती है।

{{% /alert %}}

उदाहरण के लिए, Microsoft Excel में बनाई गई एक चार्ट को PowerPoint स्लाइड पर रखा जाता है, वह एक OLE ऑब्जेक्ट है।

- एक OLE ऑब्जेक्ट आइकन के रूप में दिख सकता है। आइकन पर डबल‑क्लिक करने से ऑब्जेक्ट उसके संबंधित एप्लिकेशन (जैसे, Excel) में खुलता है या आपको इसे खोलने या संपादित करने के लिए किसी ऐप का चयन करने के लिए प्रेरित करता है।
- एक OLE ऑब्जेक्ट अपनी सामग्री (उदाहरण के लिए, एक चार्ट) प्रदर्शित कर सकता है। इस स्थिति में, PowerPoint एम्बेडेड ऑब्जेक्ट को सक्रिय करता है, चार्ट इंटरफ़ेस लोड करता है, और आपको PowerPoint के भीतर चार्ट डेटा को संपादित करने की अनुमति देता है।

Aspose.Slides for Python आपको OLE ऑब्जेक्ट्स को स्लाइड्स में OLE ऑब्जेक्ट फ्रेम के रूप में डालने देता है ([OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/)).

## **स्लाइड्स में OLE ऑब्जेक्ट्स जोड़ें**

यदि आपने पहले ही Microsoft Excel में एक चार्ट बनाया है और Aspose.Slides for Python का उपयोग करके उसे OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो इन चरणों का पालन करें:

1. Presentation वर्ग का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
1. Excel फ़ाइल को बाइट एरे में पढ़ें।
1. बाइट एरे और अन्य OLE ऑब्जेक्ट विवरण प्रदान करके स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्न उदाहरण में, एक Excel फ़ाइल से निकाली गई चार्ट को स्लाइड में एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) के रूप में एम्बेड किया गया है।

**Note:** The [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) constructor takes the embeddable object’s file extension as its second parameter. PowerPoint uses this extension to identify the file type and select the appropriate application to open the OLE object.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **लिंक्ड OLE ऑब्जेक्ट्स जोड़ें**

Aspose.Slides for Python आपको एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) जोड़ने देता है जो डेटा को एम्बेड करने के बजाय फ़ाइल से लिंक करता है।

निम्न Python उदाहरण दिखाता है कि कैसे एक स्लाइड पर Excel फ़ाइल से लिंक्ड [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) जोड़ें:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE ऑब्जेक्ट्स तक पहुँचें**

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे निम्न प्रकार से एक्सेस कर सकते हैं:

1. Presentation वर्ग का एक इंस्टेंस बनाकर उस प्रस्तुति को लोड करें जिसमें एम्बेडेड OLE ऑब्जेक्ट है।
1. इंडेक्स द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
1. OleObjectFrame आकार तक पहुँचें।
1. एक बार OLE ऑब्जेक्ट फ्रेम प्राप्त हो जाने पर, आवश्यक कोई भी ऑपरेशन करें।

निम्न उदाहरण में OLE ऑब्जेक्ट फ्रेम—एक एम्बेडेड Excel चार्ट—तक पहुँच प्राप्त की जाती है और उसकी फ़ाइल डेटा प्राप्त किया जाता है। इस उदाहरण में, हम एक PPTX का उपयोग करते हैं जिसमें पहली स्लाइड पर एक ही आकार है।

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # एम्बेडेड फ़ाइल डेटा प्राप्त करें।
        file_data = ole_frame.embedded_data.embedded_file_data

        # एम्बेडेड फ़ाइल का एक्सटेन्शन प्राप्त करें।
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **लिंक्ड OLE ऑब्जेक्ट गुणों तक पहुँचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम की प्रॉपर्टीज़ तक पहुँचने की सुविधा देता है।

निम्न Python उदाहरण जांचता है कि OLE ऑब्जेक्ट लिंक्ड है या नहीं और यदि है तो लिंक्ड फ़ाइल की पाथ प्राप्त करता है:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # जांचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
        if ole_frame.is_object_link:
            # लिंक्ड फ़ाइल का पूर्ण पाथ प्रिंट करें।
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पाथ प्रिंट करें।
            # केवल .ppt प्रस्तुतियों में रिलेटिव पाथ हो सकता है।
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="primary" %}}

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for Python via .NET](/cells/python-net/) का उपयोग करता है।

{{% /alert %}}

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे एक्सेस करके उसका डेटा निम्न प्रकार से बदल सकते हैं:

1. Presentation वर्ग का एक इंस्टेंस बनाकर प्रस्तुति लोड करें।
1. इंडेक्स द्वारा लक्ष्य स्लाइड प्राप्त करें।
1. [OleObjectFrame] आकार तक पहुँचें।
1. एक बार OLE ऑब्जेक्ट फ्रेम प्राप्त हो जाने पर, आवश्यक ऑपरेशन करें।
1. एक `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा पढ़ें।
1. इच्छित `Worksheet` खोलें और डेटा संपादित करें।
1. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।
1. उस स्ट्रीम का उपयोग करके OLE ऑब्जेक्ट का डेटा बदलें।

निम्न उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (एक एम्बेडेड Excel चार्ट) तक पहुँच प्राप्त की जाती है और उसके फ़ाइल डेटा को संशोधित करके चार्ट को अपडेट किया जाता है। यह सैंपल पहले से निर्मित PPTX का उपयोग करता है जिसमें पहली स्लाइड पर एक ही आकार है।

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
            # OLE ऑब्जेक्ट डेटा को एक Workbook ऑब्जेक्ट के रूप में पढ़ें।
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # वर्कबुक डेटा संशोधित करें।
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

## **फ़ाइलों को स्लाइड्स में एम्बेड करें**

Excel चार्ट के अतिरिक्त, Aspose.Slides for Python आपको अन्य फ़ाइल प्रकारों को स्लाइड्स में एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में डाल सकते हैं। जब कोई उपयोगकर्ता डाली गई वस्तु पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से संबंधित एप्लिकेशन में खुलती है, या उपयोगकर्ता को उपयुक्त प्रोग्राम चुनने के लिए प्रेरित किया जाता है।

यह Python कोड दर्शाता है कि स्लाइड में HTML और ZIP फ़ाइलों को कैसे एम्बेड करें:

```py
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

## **एम्बेडेड ऑब्जेक्ट्स के फ़ाइल प्रकार निर्धारित करें**

प्रेजेंटेशन पर काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से स्वैप करना पड़ सकता है। Aspose.Slides for Python आपको एम्बेडेड ऑब्जेक्ट का फ़ाइल प्रकार सेट करने की सुविधा देता है, जिससे आप OLE फ्रेम डेटा या उसकी फ़ाइल एक्सटेन्शन को अपडेट कर सकते हैं।

यह Python कोड दिखाता है कि एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` कैसे सेट करें:

```py
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

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेजेस और शीर्षक सेट करें**

एक OLE ऑब्जेक्ट एम्बेड करने के बाद, एक आइकन‑आधारित प्रीव्यू स्वचालित रूप से जोड़ा जाता है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट तक पहुँचने या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज और टेक्स्ट उपयोग करना चाहते हैं, तो आप Aspose.Slides for Python का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह Python कोड दिखाता है कि एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक कैसे सेट करें:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # प्रस्तुति संसाधनों में एक इमेज जोड़ें।
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE प्रीव्यू के लिए शीर्षक और इमेज सेट करें।
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और पुनः स्थित करने से रोकें**

स्लाइड में लिंक्ड OLE ऑब्जेक्ट जोड़ने के बाद, PowerPoint प्रस्तुति खोलते समय लिंक अपडेट करने के लिए प्रॉम्प्ट कर सकता है। "Update Links" को चुनने से लिंक्ड ऑब्जेक्ट से डेटा रीफ़्रेश होने के कारण OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है। PowerPoint को डेटा अपडेट करने के लिए प्रॉम्प्ट करने से रोकने हेतु, [OleObjectFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/oleobjectframe/) वर्ग की `update_automatic` प्रॉपर्टी को `False` सेट करें:

```py
ole_frame.update_automatic = False
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for Python आपको स्लाइड्स में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में निम्न प्रकार से निकालने देता है:

1. उस Presentation वर्ग का एक इंस्टेंस बनाएं जिसमें आप निकाली जाने वाली OLE ऑब्जेक्ट्स हों।
1. प्रस्तुति में सभी आकारों पर इटरिट करें और OLEObjectFrame आकारों को खोजें।
1. प्रत्येक [OLEObjectFrame] से एम्बेडेड फ़ाइल डेटा प्राप्त करें और उसे डिस्क पर लिखें।

निम्न Python कोड दर्शाता है कि स्लाइड में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलों को कैसे निकाला जाए:

```py
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

**Will the OLE content be rendered when exporting slides to PDF/images?**  
क्या स्लाइड्स को PDF/छवियों में निर्यात करते समय OLE सामग्री रेंडर होगी?

स्लाइड पर दिखाई देने वाली चीज़ रेंडर होती है—आइकन/सब्स्टिट्यूट इमेज (प्रीव्यू)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो निर्यातित PDF में वांछित रूप दिखाने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**  
मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूँ ताकि उपयोगकर्ता PowerPoint में इसे स्थानांतरित/संपादित न कर सकें?

आकार को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/python-net/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन आकस्मिक संपादन और मूवमेंट को प्रभावी रूप से रोकता है।

**Why does a linked Excel object "jump" or change size when I open the presentation?**  
जब मैं प्रस्तुति खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जंप" क्यों करता है या आकार बदलता है?

PowerPoint लिंक्ड OLE के प्रीव्यू को रीफ़्रेश कर सकता है। स्थिर रूप के लिए, [Working Solution for Worksheet Resizing](/slides/hi/python-net/working-solution-for-worksheet-resizing/) के अभ्यास का पालन करें—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को स्थायी फ्रेम में स्केल करें और उपयुक्त सब्स्टिट्यूट इमेज सेट करें।

**Will relative paths for linked OLE objects be preserved in the PPTX format?**  
क्या PPTX प्रारूप में लिंक्ड OLE ऑब्जेक्ट्स के लिए रिलेटिव पाथ संरक्षित रहेंगी?

PPTX में "रिलेटिव पाथ" जानकारी उपलब्ध नहीं होती—केवल पूर्ण पाथ। रिलेटिव पाथ पुराने PPT फ़ॉर्मेट में पाए जाते हैं। पोर्टेबलिटी के लिए विश्वसनीय एब्सॉल्यूट पाथ/एक्सेसिबल URIs या एम्बेडिंग का उपयोग करें।