---
title: Python के साथ प्रस्तुतियों में चित्र फ्रेम प्रबंधित करें
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/python-net/picture-frame/
keywords:
- चित्र फ्रेम
- चित्र फ्रेम जोड़ें
- चित्र फ्रेम बनाएं
- एम्बेडेड छवि
- लिंक्ड छवि
- छवि निकालें
- रास्टर छवि
- SVG छवि
- क्रॉप छवि
- क्रॉप किए गए क्षेत्र हटाएँ
- छवि संकुचित करें
- StretchOffset
- चित्र फ्रेम फ़ॉर्मेटिंग
- सापेक्ष स्केल
- छवि प्रभाव
- अस्पेक्ट अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ प्रस्तुतियों में चित्र फ्रेम बनाना, फ़ॉर्मेट करना, लिंक करना, क्रॉप करना, निकालना और संकुचित करना।"
---
## **अवलोकन**

एक चित्र फ्रेम एक स्लाइड आकार है जो एक छवि प्रदर्शित करता है। Aspose.Slides में, छवि संसाधन और उसे प्रदर्शित करने वाला आकार अलग-अलग वस्तुएँ हैं: एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) अपने [ImageCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/) के माध्यम से एम्बेडेड छवि संसाधनों का स्वामित्व रखता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) छवि की स्थिति, आकार, लाइन फ़ॉर्मेटिंग, घूर्णन, क्रॉपिंग, चित्र प्रभाव और अन्य फ्रेम‑स्तर सेटिंग्स को नियंत्रित करता है।

जब एक ही छवि को एक से अधिक बार दिखाया जाता है तो यह विभाजन उपयोगी होता है। छवि को प्रस्तुति में एक बार जोड़ें, लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) को रखें, और चित्र फ्रेम बनाते समय उसी छवि संसाधन का उपयोग करें।

चित्र फ्रेम PNG या JPEG जैसी रास्टर छवियों और SVG जैसी वेक्टर छवियों दोनों को धारण कर सकते हैं। वे प्रस्तुति में छवि बाइट्स संग्रहीत करने के बजाय लिंक्ड छवियों को भी संदर्भित कर सकते हैं। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण और निर्यात व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या अनुकूलन लागू करने से पहले यह तय करना उपयोगी है कि छवि कैसे संग्रहीत की जानी चाहिए।

## **एम्बेडेड छवि जोड़ें और फॉर्मेट करें**

एक एम्बेडेड छवि के लिए, छवि डेटा को प्रस्तुति में जोड़ें और [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_picture_frame/) के साथ एक चित्र फ्रेम बनाएँ। छवि प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए प्रस्तुति को दूसरे कंप्यूटर पर ले जाने पर भी वह स्वतंत्र रहती है।

निम्न उदाहरण JPEG छवि जोड़ता है, छवि के मूल आयामों पर एक फ्रेम बनाता है, और लाइन फ़ॉर्मेटिंग एवं घूर्णन लागू करता है:

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

चित्र फ्रेम प्रदर्शित ज्यामिति को नियंत्रित करता है; फ्रेम आकार बदलने से एम्बेडेड छवि संसाधन में संग्रहित मूल पिक्सेल आयाम नहीं बदलते। बाद में क्रॉपिंग या संपीड़न करने पर यह अंतर महत्वपूर्ण हो जाता है।

## **सापेक्ष स्केल का प्रयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) फ्रेम के लिए [relative_scale_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/relative_scale_width/) और [relative_scale_height](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/relative_scale_height/) उजागर करता है। `1.0` का मान मूल चित्र आकार के 100 % के बराबर है। सापेक्ष स्केल तब उपयोगी होता है जब वर्कफ़्लो को अंतिम आयाम मैन्युअल रूप से गणना करने के बजाय स्रोत छवि आकार के संबंध को बनाए रखना हो।

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

सापेक्ष स्केल फ्रेम की स्केल सेटिंग्स बदलता है; यह एम्बेडेड छवि को री‑सैंपल या संपीड़ित नहीं करता।

## **एम्बेडेड और लिंक्ड छवियां**

एक एम्बेडेड चित्र प्रस्तुति के भीतर छवि डेटा संग्रहीत करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमेय रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड चित्र बाहरी स्थान को [Picture](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picture/) लिंक पथ के माध्यम से संग्रहीत करता है, बजाय उसी तरह छवि डेटा एम्बेड करने के।

लिंक्ड छवियां PPTX में संग्रहीत छवि डेटा की मात्रा को कम कर सकती हैं, लेकिन वे बाहरी निर्भरताएँ पेश करती हैं। लिंक्ड फ़ाइल को उस अनुप्रयोग के लिए सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन अनुपलब्ध हो जाता है, तो लिंक्ड चित्र अपेक्षित रूप से प्रदर्शित नहीं हो सकता। जिन्हें ई‑मेल, अभिलेख या अलग‑थलग वातावरण में रेंडर किया जाना आवश्यक है, उन प्रस्तुतियों के लिए एम्बेडेड छवियां आमतौर पर अधिक विश्वसनीय होती हैं।

### **लिंक्ड छवि जोड़ें**

निम्न उदाहरण एक चित्र फ्रेम बनाता है और उसे स्थानीय छवि फ़ाइल की ओर इंगित करता है। यह केवल छवि लिंकिंग को संभालता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और जानबूझकर इस उदाहरण में मिश्रित नहीं किया गया है।

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

बाहरी फ़ाइल प्रबंधन का इरादा हो तो लिंक का उपयोग करें। उन्हें केवल संपीड़न के विकल्प के रूप में न प्रयोग करें: टूटे हुए लिंक वाले छोटे PPTX की तुलना में बड़े स्व‍यं‑समाहित प्रस्तुति अधिक उपयोगी होती है।

## **फ़्रेम से छवियां निकालें**

मौजूदा प्रस्तुति से छवि निकालने से पहले यह जांचें कि आकार वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) है और उसमें एम्बेडेड छवि मौजूद है। लिंक्ड चित्र फ्रेम में वह बाइट्स नहीं हो सकते जिन्हें उसी तरह निकाला जा सके।

### **रास्टर छवि निकालें**

आधुनिक छवि API सीधे [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) का उपयोग करता है। निम्न उदाहरण स्लाइड पर पहली एम्बेडेड रास्टर छवि को खोजता है और उसे PNG के रूप में सहेजता है:

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

[IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) के माध्यम से सहेजने से निकाली गई छवि को अनुरोधित आउटपुट फ़ॉर्मेट में बदला जाता है। यदि आप प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहते हैं न कि परिवर्तित रास्टर फ़ाइल, तो [PPImage.binary_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/binary_data/) प्रॉपर्टी का उपयोग करें।

### **SVG छवि निकालें**

एक SVG चित्र के लिए, [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) एक [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) ऑब्जेक्ट उजागर करता है। इससे आप SVG डेटा को सीधे प्राप्त कर सकते हैं बजाय पहले चित्र को रास्टराइज करने के।

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

SVG सामग्री को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसे रास्टर निर्यात आवश्यक रूप से उस वेक्टर सामग्री को पिक्सेल में रेंडर करता है। PDF या SVG स्लाइड निर्यात भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यात किए गए ग्राफिक्स को मूल एम्बेडेड SVG की बाइट‑दर‑बाइट कॉपी न मानें; मूल वेक्टर संसाधन की आवश्यकता होने पर एम्बेडेड [SvgImage.svg_data](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/svg_data/) का उपयोग करें।

## **छवि को क्रॉप करें**

क्रॉपिंग वह भाग बदलती है जो फ्रेम के भीतर छवि के रूप में दिखाई देता है। [PictureFillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) पर क्रॉप मान स्रोत छवि आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारम्भिक रूप से एम्बेडेड छवि से छिपे पिक्सेल को नहीं हटाती; यह केवल दृश्यमान क्षेत्र बदलती है।

निम्न उदाहरण सुरक्षित रूप से एक चित्र फ्रेम खोजता है और क्रॉप मान लागू करता है:

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

क्योंकि छिपा डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार अधिक मायने रखता है और पुनःक्रॉप की आवश्यकता नहीं है, तो अगला खंड वर्णित अनुसार क्रॉप किए गए क्षेत्रों को भौतिक रूप से हटा सकते हैं।

## **क्रॉप की गई छवि डेटा हटाएँ**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) वर्तमान क्रॉप आयत से बाहर के छवि डेटा को हटाता है और परिणामी छवि संसाधन लौटाता है। यह फ़ाइल आकार को कम कर सकता है, लेकिन यह एक विनाशकारी अनुकूलन है: प्रस्तुति सहेजने के बाद हटाए गए पिक्सेल बाद में अनक्रॉप ऑपरेशन के लिए उपलब्ध नहीं होते।

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

विधि प्रस्तुति में एक नया छवि संसाधन जोड़ सकती है। यदि मूल छवि अन्य चित्र फ्रेम द्वारा भी उपयोग की जा रही है, तो उन फ्रेमों को अभी भी अपना मौजूदा संसाधन चाहिए होता है, इसलिए क्रॉप किए गए क्षेत्रों को हटाना आवश्यक रूप से कुल छवियों की संख्या नहीं घटाता। इस विधि से WMF या EMF सामग्री को क्रॉप करने पर परिणाम PNG में रास्टराइज़ हो जाता है।

## **रास्टर छवियों को संकुचित करें**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/compress_image/) रास्टर छवि रिज़ॉल्यूशन को उस आकार के सापेक्ष घटाता है जिस पर चित्र प्रदर्शित होता है। यह समान ऑपरेशन में क्रॉप किए गए क्षेत्रों को भी हटा सकता है। विधि तब `True` लौटाती है जब छवि का आकार बदला गया हो या क्रॉप किया गया हो, और `False` जब कोई परिवर्तन आवश्यक न हो।

जब मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो तो पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/picturescompression/) मान का उपयोग करें:

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

विशिष्ट लक्ष्य की आवश्यकता होने पर एनुम मान के बजाय एक कस्टम सकारात्मक DPI मान भी पास किया जा सकता है।

संकुचन रास्टर छवियों के लिए अभिप्रेत है। SVG और मेटाफाइल सामग्री इस रास्टर संकुचन वर्कफ़्लो द्वारा कम नहीं होती। साथ ही याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप क्षेत्र अनुकूलित प्रस्तुति से फिर से प्राप्त नहीं किए जा सकते। लक्ष्य रिज़ॉल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर छवि वास्तव में देखी या निर्यात की जाएगी, न कि पूरे प्रस्तुति में सबसे कम DPI लागू करके।

## **छवि रूपांतरण प्रभाव प्रबंधित करें**

पूर्ण वर्कफ़्लो जिसमें चमक, कंट्रास्ट, रंग परिवर्तन, ब्लर, अल्फा प्रभाव, क्रमबद्ध चेन, निरीक्षण, हटाना और राउंड‑ट्रिप सत्यापन शामिल है, के लिए देखें [Image Transform Effects](/slides/hi/python-net/image-transform-effects/)।

## **चित्र फ्रेम ज्यामिति को लॉक करें**

[PictureFrameLock](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि चित्र फ्रेम के कौन‑से संपादन संचालन निष्क्रिय हैं। उदाहरण के लिए, [aspect_ratio_locked](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) प्रॉपर्टी आकार बदलते समय आकार अनुपात को बनाए रखती है।

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

लॉक चित्र फ्रेम आकार पर लागू होता है। यह स्रोत छवि को समान अनुपात में री‑सैंपल या स्थायी रूप से बदलता नहीं है।

## **StretchOffset मान समायोजित करें**

जब चित्र भराव मोड स्ट्रेच हो, तो [PictureFillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) पर stretch‑offset मान चित्र फ्रेम के बाउंडिंग बॉक्स के सापेक्ष भराव आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से अंदर की ओर खाली स्थान बनाते हैं, जबकि नकारात्मक प्रतिशत बाहर की ओर निकलते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत छवि के कौन‑से भाग को दिखाया जाए तय करते हैं; स्ट्रेच‑ऑफ़सेट दृश्यमान चित्र भराव को उस आयत में विस्तारित करते हैं जिसमें वह खिंचा जाता है।

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

भरण स्थान के लिए स्ट्रेच‑ऑफ़सेट का प्रयोग करें। स्रोत‑छवि किनारों को छिपाने के लक्ष्य के लिए क्रॉप गुणों का प्रयोग करें।

## **भंडारण, फ़ाइल आकार, और निर्यात विचार**

मुख्य समझौते तब आसान होते हैं जब छवि भंडारण और चित्र‑फ़्रेम फ़ॉर्मेटिंग को अलग‑अलग माना जाए:

- **एम्बेडेड छवियां** प्रस्तुति को स्वयंसंपूर्ण बनाती हैं और साझा करने व सर्वर‑साइड रेंडरिंग के लिये सबसे विश्वसनीय होती हैं, लेकिन बड़े रास्टर छवियां PPTX आकार और मेमोरी उपयोग को बढ़ाती हैं।
- **लिंक्ड छवियां** पैकेज को छोटा रख सकती हैं, लेकिन प्रस्तुति को बाहरी फ़ाइलों के उपलब्ध रहने पर निर्भर बनाती हैं।
- **क्रॉपिंग** प्रारम्भिक रूप से गैर‑विनाशकारी होती है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक कि क्रॉप किए गए क्षेत्रों को स्पष्ट रूप से हटाया न जाए या संकुचन के दौरान हटाया न जाए।
- **संकुचन** अत्यधिक बड़े रास्टर छवियों के फ़ाइल आकार को काफी घटा सकता है, लेकिन स्रोत रिज़ॉल्यूशन का त्याग करता है। इसे स्लाइड पर इच्छित आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG छवियां** वेक्टर संरक्षा आवश्यक होने पर SVG ही बनी रहनी चाहिए। जब आपको वेक्टर संसाधन चाहिए हो तो एम्बेडेड SVG को सीधे निकालें। रास्टर स्लाइड निर्यात हमेशा रेंडर किए गए स्लाइड को पिक्सेल में बदलते हैं।
- **दोहराई गई छवियां** संभव हो तो एक मौजूदा [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) संसाधन को पुनः उपयोग करें, बजाय प्रत्येक फ़ाइल को बार‑बार लोड करने के।

बड़ी प्रस्तुतियों के लिये, छवि अनुकूलन सबसे प्रभावी तब होता है जब चयनात्मक रूप से किया जाए: लोगो और आरेख को वेक्टर सामग्री के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक प्रदर्शन आकार के अनुसार संकुचित करें, क्रॉप किए गए पिक्सेल को तभी हटाएं जब बाद में संपादित करने की आवश्यकता न हो, और बाहरी लिंक को तभी अपनाएं जब निर्भरता प्रबंधन परिनियोजन डिज़ाइन का हिस्सा हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक चित्र फ्रेम और एक छवि संसाधन में क्या अंतर है?**

एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) प्रस्तुति से जुड़ा एक छवि संसाधन दर्शाता है। एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) स्लाइड पर वह आकार है जो छवि प्रदर्शित करता है और आकार, घूर्णन, क्रॉप मान, प्रभाव और लॉक जैसी फ्रेम‑स्तर ज्यामिति व फ़ॉर्मेटिंग को संग्रहीत करता है।

**मुझे छवियों को एम्बेड करना चाहिए या लिंक करना चाहिए?**

जब प्रस्तुति को पोर्टेबल, अभिलेखित या बाहरी संसाधनों के बिना रेंडर करने की आवश्यकता हो तो छवियों को एम्बेड करें। केवल तभी लिंक करें जब छवि फ़ाइलों को PPTX के बाहर रखना इरादा हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार को कम करती है?**

स्वतः नहीं। सामान्य क्रॉप सेटिंग्स स्रोत छवि के हिस्सों को छिपाती हैं लेकिन अंतर्निहित पिक्सेल को रखती हैं। उन पिक्सेल को स्थायी रूप से हटाने के लिए [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) या क्रॉप‑क्षेत्र हटाने के साथ छवि संकुचन का उपयोग करें।

**क्या मैं संकुचन के बाद छवि गुणवत्ता को पुनर्स्थापित कर सकता हूँ?**

नहीं। संकुचन संग्रहीत रास्टर रिज़ॉल्यूशन को घटा सकता है, और क्रॉपेड क्षेत्रों को हटाने से छवि डेटा हटा दिया जाता है। यदि बाद में उच्च‑रिज़ॉल्यूशन सम्पादन की आवश्यकता हो तो मूल स्रोत छवि को प्रस्तुति के बाहर रखें।

**SVG छवियों को कैसे संभालना चाहिए?**

जब वेक्टर फ़िडेलिटी महत्वपूर्ण हो तो SVG सामग्री को SVG ही रखें। एम्बेडेड [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में निर्यात करने से SVG वेक्टर को पिक्सेल में रेंडर किया जाता है।

**म Existing स्लाइड्स पढ़ते समय असुरक्षित कास्ट से कैसे बचूँ?**

चित्र‑फ़्रेम‑विशिष्ट सदस्यों का उपयोग करने से पहले आकार प्रकार जाँचें। `isinstance(shape, slides.PictureFrame)` का उपयोग करने से अमान्य कास्ट से बचा जा सकता है और कोड उन स्लाइडों को सही‑से‑हैंडल कर सकेगा जो चित्र‑फ़्रेम नहीं रखतीं।