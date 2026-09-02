---
title: Python के साथ प्रस्तुतियों में पिक्चर फ्रेम को प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/python-net/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एम्बेडेड छवि
- लिंक्ड छवि
- छवि निकालें
- रेस्टर छवि
- SVG छवि
- छवि क्रॉप करें
- क्रॉप किए क्षेत्रों को हटाएं
- छवि संकुचित करें
- StretchOffset
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ प्रस्तुतियों में पिक्चर फ्रेम को बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संकुचित करें।"
---
## **अवलोकन**

एक पिक्चर फ्रेम एक स्लाइड आकार है जो छवि को प्रदर्शित करता है। Aspose.Slides में, छवि संसाधन और वह आकार जो इसे प्रदर्शित करता है अलग-अलग वस्तुएँ हैं: एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) अपने [ImageCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/) के माध्यम से एम्बेडेड छवि संसाधनों का मालिक होता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) छवि की स्थिति, आकार, रेखा स्वरूपण, घुमाव, क्रॉपिंग, पिक्चर इफ़ेक्ट्स और अन्य फ्रेम‑स्तर सेटिंग्स को नियंत्रित करता है।

यह विभाजन उपयोगी है जब समान छवि एक से अधिक बार दिखायी जाती है। छवि को प्रस्तुति में एक बार जोड़ें, लौटाई गई [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) को रखें, और पिक्चर फ्रेम बनाते समय उस छवि संसाधन का उपयोग करें।

पिक्चर फ्रेम PNG या JPEG जैसे रास्टर इमेज और SVG जैसे वेक्टर इमेज दोनों रख सकते हैं। वे प्रस्तुति में छवि बाइट्स को संग्रहीत करने के बजाय लिंक्ड इमेज का भी संदर्भ दे सकते हैं। यह विकल्प पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण और निर्यात व्यवहार को प्रभावित करता है, इसलिए स्वरूपण या अनुकूलन लागू करने से पहले यह तय करना उपयोगी है कि छवि कैसे संग्रहीत की जानी चाहिए।

## **एंबेडेड छवि जोड़ें और स्वरूपित करें**

एक एम्बेडेड छवि के लिए, छवि डेटा को प्रस्तुति में जोड़ें और [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_picture_frame/) का उपयोग करके पिक्चर फ्रेम बनाएँ। छवि प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए प्रस्तुति को दूसरे कंप्यूटर पर ले जाने पर भी वह स्व‑निहित रहती है।

निम्नलिखित उदाहरण JPEG छवि जोड़ता है, छवि के मूल आयामों पर एक फ्रेम बनाता है, और रेखा स्वरूपण तथा घुमाव लागू करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

पिक्चर फ्रेम प्रदर्शित जियामिति को नियंत्रित करता है; फ्रेम का आकार बदलने से एम्बेडेड छवि संसाधन में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में छवि को क्रॉप या संकुचित करने पर महत्वपूर्ण हो जाता है।

## **सापेक्ष स्केल का उपयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) [relative_scale_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/relative_scale_width/) और [relative_scale_height](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/relative_scale_height/) को फ्रेम के लिए उजागर करता है। `1.0` का मान मूल चित्र आकार का 100% दर्शाता है। सापेक्ष स्केल तब उपयोगी होता है जब किसी वर्कफ़्लो को स्रोत छवि आकार के साथ संबंध बनाए रखना आवश्यक हो, न कि अंतिम आयामों की मैन्युअल गणना।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

सापेक्ष स्केल फ्रेम के स्केल सेटिंग्स को बदलता है; यह एम्बेडेड छवि को री‑सैंपल या संकुचित नहीं करता।

## **एम्बेडेड और लिंक्ड इमेजेज**

एक एम्बेडेड चित्र प्रस्तुति के अंदर छवि डेटा संग्रहीत करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमानित रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड चित्र बाहरी स्थान को [Picture](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picture/) लिंक पाथ के माध्यम से संग्रहीत करता है, बजाय उसी तरीके से छवि डेटा एम्बेड करने के।

लिंक्ड इमेजेज PPTX में संग्रहीत छवि डेटा की मात्रा को कम कर सकते हैं, लेकिन वे एक बाहरी निर्भरता पेश करते हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन के लिए सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पाथ बदलता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन उपलब्ध नहीं है, तो लिंक्ड चित्र उम्मीद के मुताबिक प्रदर्शित नहीं हो सकता। उन प्रस्तुतियों के लिए जिन्हें ईमेल, आर्काइव या अलग‑अलग वातावरण में रेंडर किया जाना आवश्यक है, एम्बेडेड इमेजेज सामान्यतः अधिक भरोसेमंद होते हैं।

### **लिंक्ड इमेज जोड़ें**

निम्नलिखित उदाहरण एक पिक्चर फ्रेम बनाता है और उसे स्थानीय इमेज फ़ाइल की ओर इंगित करता है। यह केवल इमेज लिंकिंग से निपटता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और जानबूझकर इस उदाहरण में मिश्रित नहीं किया गया है।

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

बाहरी फ़ाइल प्रबंधन इरादे से होने पर लिंक का उपयोग करें। उन्हें केवल संकुचन के विकल्प के रूप में न प्रयोग करें: टूटी हुई इमेज निर्भरताओं वाला छोटा PPTX आमतौर पर बड़े स्व‑निहित प्रस्तुति से कम उपयोगी होता है।

## **पिक्चर फ्रेम से इमेज निकालें**

मौजूदा प्रस्तुति से इमेज निकालने से पहले जांचें कि आकार वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) है और उसमें एम्बेडेड इमेज है। लिंक्ड पिक्चर फ्रेम में वह इमेज बाइट्स नहीं हो सकते जो उसी तरह निकाले जा सकें।

### **रेस्टर इमेज निकालें**

आधुनिक इमेज API सीधे [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) का उपयोग करता है। निम्नलिखित उदाहरण स्लाइड पर पहली एम्बेडेड रेस्टर तस्वीर को खोजता है और उसे PNG के रूप में सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

[IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) के माध्यम से सहेजने से निकाली गई इमेज को अनुरोधित आउटपुट फ़ॉर्मेट में परिवर्तित किया जाता है। यदि आप प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स की आवश्यकता रखते हैं न कि परिवर्तित रेस्टर फ़ाइल की, तो इसके बजाय [PPImage.binary_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/binary_data/) प्रॉपर्टी का उपयोग करें।

### **SVG इमेज निकालें**

एक SVG चित्र के लिए, [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) एक [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) ऑब्जेक्ट उजागर करता है। यह आपको पहले चित्र को रास्टराइज़ किए बिना सीधे SVG डेटा प्राप्त करने की अनुमति देता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

SVG सामग्री को SVG ही रखने से प्रस्तुति के भीतर वेक्टर स्रोत संरक्षित रहता है। PNG या JPEG जैसे रेस्टर निर्यात अनिवार्य रूप से उस वेक्टर सामग्री को पिक्सेल में बदलते हैं। PDF या SVG स्लाइड निर्यात भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यातित ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑फ़ॉर‑बाइट कॉपी मानना नहीं चाहिए; जब मूल वेक्टर संसाधन की आवश्यकता हो तो एम्बेडेड [SvgImage.svg_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/svg_data/) का उपयोग करें।

## **इमेज को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर इमेज के किस भाग को दिखाया जाए, बदलता है। [PictureFillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) पर क्रॉप मान स्रोत इमेज आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारम्भिक रूप से एम्बेडेड इमेज से छिपे पिक्सेल को नहीं हटाता; यह केवल दिखाने योग्य क्षेत्र को बदलता है।

निम्नलिखित उदाहरण सुरक्षित रूप से एक पिक्चर फ्रेम खोजता है और क्रॉप मान लागू करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

क्योंकि छिपा इमेज डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार पुनरावर्तनीयता से अधिक महत्वपूर्ण है, तो अगली सेक्शन में वर्णित अनुसार क्रॉप किए क्षेत्रों को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप किए इमेज डेटा को हटाएँ**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) वर्तमान क्रॉप आयत के बाहर के इमेज डेटा को हटाता है और परिणामी इमेज संसाधन लौटाता है। यह फ़ाइल आकार को कम कर सकता है, लेकिन यह एक विनाशकारी अनुकूलन है: प्रस्तुति सहेजने के बाद हटाए गए पिक्सेल बाद में अनक्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहते।

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

यह विधि प्रस्तुति में एक नया इमेज संसाधन जोड़ सकती है। यदि मूल इमेज अन्य पिक्चर फ्रेम द्वारा भी उपयोग की जाती है, तो उन फ्रेमों को अभी भी अपना मौजूदा संसाधन चाहिए रहेगा, इसलिए क्रॉप किए क्षेत्रों को हटाना आवश्यक नहीं कि कुल इमेजों की संख्या घटाए। इस विधि से WMF या EMF सामग्री को क्रॉप करने से क्रॉप परिणाम PNG में रास्टराइज़ हो जाता है।

## **रेस्टर इमेज को संकुचित करें**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/compress_image/) चित्र के प्रदर्शित आकार के संबंध में रेस्टर इमेज रिज़ॉल्यूशन को कम करता है। यह एक ही ऑपरेशन में क्रॉप किए क्षेत्रों को भी हटा सकता है। यह विधि तब `True` लौटाती है जब इमेज का आकार बदल दिया गया हो या क्रॉप किया गया हो और उस समय `False` लौटाती है जब कोई बदलाव आवश्यक नहीं था।

जब एक मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो तो एक पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/picturescompression/) मान का उपयोग करें:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

जब विशिष्ट लक्ष्य आवश्यक हो तो enum मान के बजाय एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

संकुचन रेस्टर इमेजेज के लिए अभिप्रेत है। SVG और मेटा फ़ाइल सामग्री इस रेस्टर संकुचन वर्कफ़्लो से नहीं घटती है। साथ ही याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉपेड क्षेत्रों को अनुकूलित प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। सबसे बड़े आकार के आधार पर लक्ष्य रिज़ॉल्यूशन चुनें जिस पर इमेज वास्तव में देखी या निर्यात की जाएगी, बजाय वैश्विक रूप से सबसे कम DPI लागू करने के।

## **इमेज इफ़ेक्ट्स की जाँच करें**

पिक्चर इफ़ेक्ट्स फ्रेम द्वारा उपयोग किए गए पिक्चर पर संग्रहीत होते हैं। इमेज ट्रांसफ़ॉर्म कलेक्शन में ट्रांस्पेरेन्सी के लिए फिक्स्ड अल्फा मोड्यूलेशन और ब्राइटनेस व कॉन्ट्रास्ट के लिए ल्यूमिनेंस जैसे इफ़ेक्ट्स शामिल हो सकते हैं। नीचे दिया गया उदाहरण स्लाइड पर पहले पिक्चर फ्रेम से दोनों प्रकार के इफ़ेक्ट्स को सुरक्षित रूप से पढ़ता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/alphamodulatefixed/) और [Luminance](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/luminance/) फ्रेम में इमेज के रेंडरिंग को बदलते हैं; वे मूल एम्बेडेड इमेज बाइट्स को पुनः नहीं लिखते।

## **पिक्चर फ्रेम जियोमेट्री को लॉक करें**

[PictureFrameLock](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि पिक्चर फ्रेम के लिए कौन से संपादन ऑपरेशन निष्क्रिय हैं। उदाहरण के लिए, [aspect_ratio_locked](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) प्रॉपर्टी आकार बदलते समय आकार के अनुपात को बनाए रखती है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

लॉक पिक्चर फ्रेम आकार पर लागू होता है। यह स्रोत इमेज को री‑सैंपल या स्थायी रूप से समान अनुपात में बदलने के लिए बाध्य नहीं करता।

## **StretchOffset मान समायोजित करें**

जब पिक्चर फ़िल मोड स्ट्रेच हो, तो [PictureFillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) पर स्ट्रेच‑ऑफ़सेट मान पिक्चर फ्रेम के बाउंडिंग बॉक्स के सापेक्ष फ़िल आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से अंदर की ओर इन्सेट बनाते हैं, जबकि नकारात्मक प्रतिशत बाहर की ओर आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत इमेज के किस भाग को दिखाया जाए चुनते हैं; स्ट्रेच ऑफ़सेट दृश्यमान पिक्चर फ़िल को जिस आयत में स्ट्रेच किया जाता है, उसे बदलते हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

फ़िल प्लेसमेंट के लिए स्ट्रेच ऑफ़सेट का उपयोग करें। स्रोत‑इमेज किनारों को छिपाने के लक्ष्य के लिए क्रॉप प्रॉपर्टीज़ का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार, और निर्यात पर विचार**

मुख्य ट्रेडऑफ़ को प्रबंधित करना आसान होता है जब इमेज स्टोरेज और पिक्चर‑फ़्रेम फ़ॉर्मेटिंग को अलग‑अलग माना जाता है:

- **Embedded images** प्रस्तुति को स्व‑निहित बनाते हैं और साझा करने और सर्वर‑साइड रेंडरिंग के लिए सबसे विश्वसनीय होते हैं, लेकिन बड़े रेस्टर इमेजेज PPTX आकार और मेमोरी उपयोग बढ़ाते हैं।
- **Linked images** पैकेज को छोटा रख सकते हैं, लेकिन प्रस्तुति बाहरी फ़ाइलों पर निर्भर करती है कि वे संग्रहीत पाथ या स्थानों पर उपलब्ध रहें।
- **Cropping** प्रारम्भ में गैर‑विनाशकारी है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक कि क्रॉप किए क्षेत्रों को स्पष्ट रूप से हटाया न जाए या संकुचन के दौरान हटाया न जाए।
- **Compression** बड़े रेस्टर इमेजेज के लिए फ़ाइल आकार को उल्लेखनीय रूप से कम कर सकता है, लेकिन यह स्रोत रिज़ॉल्यूशन से समझौता करता है। इसे स्लाइड पर इच्छित आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG images** को तब SVG ही रहना चाहिए जब वेक्टर संरक्षण महत्वपूर्ण हो। जब आपको वेक्टर संसाधन स्वयं चाहिए तो एम्बेडेड SVG को सीधे निकालें। रेस्टर स्लाइड निर्यात हमेशा रेंडर की गई स्लाइड को पिक्सेल में परिवर्तित करते हैं।
- **Repeated images** को संभव होने पर मौजूदा [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) संसाधन का पुनः उपयोग करना चाहिए, न कि एक ही फ़ाइल को बार‑बार प्रस्तुति वर्कफ़्लो में लोड करना।

बड़ी प्रस्तुतियों के लिए, इमेज अनुकूलन आमतौर पर तब सबसे प्रभावी होता है जब चयनात्मक रूप से किया जाए: लोगो और आरेख को वेक्टर सामग्री के रूप में रखें, फ़ोटोग्राफ़ को उनकी वास्तविक प्रदर्शित आकार के अनुसार संकुचित करें, केवल तब क्रॉप किए पिक्सेल हटाएँ जब बाद में संपादन आवश्यक न हो, और बाहरी लिंक से बचें जब तक कि निर्भरता प्रबंधन डिप्लॉयमेंट डिज़ाइन का हिस्सा न हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**पिक्चर फ्रेम और इमेज रिसोर्स में क्या अंतर है?**

एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) प्रस्तुति से जुड़ा इमेज रिसोर्स दर्शाता है। एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) स्लाइड पर एक आकार है जो इमेज प्रदर्शित करता है और फ़्रेम‑स्तर जियोमेट्री और फ़ॉर्मेटिंग जैसे आकार, घुमाव, क्रॉप मान, इफ़ेक्ट्स और लॉक संग्रहीत करता है।

**क्या मुझे इमेजेज एम्बेड करनी चाहिए या लिंक?**

इमेजेज को एम्बेड करें जब प्रस्तुति को पोर्टेबल, आर्काइव्ड या बाहरी संसाधनों तक पहुँच के बिना रेंडर किया जाना हो। इमेजेज को लिंक करें केवल तभी जब PPTX के बाहर इमेज फ़ाइलें रखना इरादतन हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सकता हो।

**क्या क्रॉपिंग PPTX फ़ाइल आकार को कम करती है?**

स्वयं में नहीं। सामान्य क्रॉप सेटिंग्स स्रोत इमेज के भागों को छिपाती हैं लेकिन अंतर्निहित पिक्सेल को रखती हैं। जब उन पिक्सेल को स्थायी रूप से हटाया जा सकता हो तो [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) या क्रॉप्ड‑एरिया हटाने के साथ इमेज संकुचन का उपयोग करें।

**क्या संकुचन के बाद इमेज गुणवत्ता को पुनः प्राप्त किया जा सकता है?**

नहीं। संकुचन संग्रहीत रेस्टर रिज़ॉल्यूशन को घटा सकता है, और क्रॉप्ड क्षेत्रों को हटाने से इमेज डेटा मिट जाता है। यदि बाद में उच्च‑रिज़ॉल्यूशन संपादन की आवश्यकता हो तो मूल स्रोत इमेज को प्रस्तुति के बाहर रखें।

**SVG इमेजेज को कैसे संभालना चाहिए?**

जब वेक्टर विश्वसनीयता महत्वपूर्ण हो तो SVG सामग्री को SVG ही रखें। एम्बेडेड [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रेस्टर फ़ॉर्मेट में रेंडर करने से SVG स्लाइड इमेज का हिस्सा बन कर रास्टराइज़ हो जाता है।

**मौजूदा स्लाइड पढ़ते समय असुरक्षित कास्ट से कैसे बचें?**

पिक्चर‑फ़्रेम‑विशिष्ट सदस्यों का उपयोग करने से पहले आकार प्रकार जाँचें। `isinstance(shape, slides.PictureFrame)` का उपयोग करने से अमान्य कास्ट से बचा जा सकता है और कोड उन स्लाइडों को संभाल सकता है जिनमें पिक्चर फ्रेम नहीं होते।