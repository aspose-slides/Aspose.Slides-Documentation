---
title: Python के साथ प्रस्तुतियों में चित्र फ्रेम जोड़ें
linktitle: चित्र फ़्रेम
type: docs
weight: 10
url: /hi/python-net/picture-frame/
keywords:
- चित्र फ़्रेम
- चित्र फ़्रेम जोड़ें
- चित्र फ़्रेम बनाएं
- चित्र जोड़ें
- चित्र बनाएं
- चित्र निकालें
- रैस्टर छवि
- वेक्टर छवि
- छवि क्रॉप करें
- क्रॉप किया गया क्षेत्र
- StretchOff प्रॉपर्टी
- चित्र फ्रेम स्वरूपण
- चित्र फ्रेम गुण
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ्रेम जोड़ें। अपने कार्यप्रवाह को सरल बनाएं और स्लाइड डिज़ाइनों को सुधारें।"
---
## **परिचय**

Aspose.Slides for Python में चित्र फ्रेम आपको रैस्टर और वेक्टर छवियों को मूल स्लाइड आकारों के रूप में रखने और प्रबंधित करने की अनुमति देते हैं। आप फ़ाइलों या स्ट्रीम से चित्र सम्मिलित कर सकते हैं, सटीक निर्देशांक के साथ उनका स्थान तथा आकार बदल सकते हैं, घूर्णन लागू कर सकते हैं, पारदर्शिता सेट कर सकते हैं, और अन्य आकारों के साथ z‑order को नियंत्रित कर सकते हैं। API क्रॉपिंग, अनुपात बनाए रखना, बॉर्डर और प्रभाव सेट करने, तथा लेआउट को पुनः बनाए बिना मूल छवि को बदलने का समर्थन भी करती है। क्योंकि चित्र फ्रेम सामान्य आकारों की तरह व्यवहार करते हैं, आप एनीमेशन, हाइपरलिंक और अल्ट टेक्स्ट जोड़ सकते हैं, जिससे दृश्य रूप से समृद्ध, सुलभ प्रस्तुतियाँ बनाना सरल हो जाता है।

## **चित्र फ्रेम बनाएं**

यह अनुभाग दिखाता है कि Aspose.Slides for Python के साथ एक स्लाइड में चित्र सम्मिलित करने के लिए एक [PictureFrame] बनाकर कैसे किया जाता है। आप सीखेंगे कि छवि को लोड करना, उसे स्लाइड पर सटीक रूप से रखना, और उसके आकार तथा स्वरूप को नियंत्रित करना।

1. एक [Presentation] वर्ग की इंस्टेंस बनाएं।
2. इंडेक्स द्वारा एक स्लाइड प्राप्त करें।
3. छवि को प्रस्तुति के [ImageCollection] में जोड़कर एक [PPImage] बनाएं। यह छवि आकार को भरने के लिए उपयोग की जाएगी।
4. फ़्रेम की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. उस आकार का एक [PictureFrame] बनाने के लिए [add_picture_frame] मेथड का उपयोग करें।
6. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दिखाता है कि कैसे एक चित्र फ्रेम बनाया जाता है:

```py
import aspose.slides as slides

# PPTX फ़ाइल को दर्शाने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # छवि को प्रस्तुति में जोड़ें।
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # छवि के आकार के अनुसार एक चित्र फ़्रेम जोड़ें।
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # प्रस्तुति को PPTX के रूप में सहेजें।
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
चित्र फ्रेम आपको छवियों से जल्दी प्रस्तुति स्लाइड बनाने की अनुमति देते हैं। जब आप चित्र फ्रेम को Aspose.Slides सहेजने विकल्पों के साथ संयोजित करते हैं, तो आप छवियों को एक स्वरूप से दूसरे स्वरूप में बदलने के लिए I/O संचालन नियंत्रित कर सकते हैं। आप इन पृष्ठों को देख सकते हैं: convert [छवि को JPG](https://products.aspose.com/slides/hi/python-net/conversion/image-to-jpg/); convert [JPG को छवि](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-image/); convert [JPG को PNG](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-png/); convert [PNG को JPG](https://products.aspose.com/slides/hi/python-net/conversion/png-to-jpg/); convert [PNG को SVG](https://products.aspose.com/slides/hi/python-net/conversion/png-to-svg/); convert [SVG को PNG](https://products.aspose.com/slides/hi/python-net/conversion/svg-to-png/)।
{{% /alert %}}

## **सापेक्ष स्केल के साथ चित्र फ्रेम बनाएं**

यह अनुभाग दर्शाता है कि कैसे एक स्थिर आकार पर छवि रखी जाये और फिर उसकी चौड़ाई तथा ऊँचाई पर स्वतंत्र रूप से प्रतिशत‑आधारित स्केल लागू किया जाये। प्रतिशत अलग‑अलग होने पर अनुपात बदल सकता है। स्केलिंग छवि के मूल आयामों के सापेक्ष की जाती है।

1. एक [Presentation] वर्ग की इंस्टेंस बनाएं।
2. इंडेक्स द्वारा एक स्लाइड प्राप्त करें।
3. छवि को प्रस्तुति के [ImageCollection] में जोड़कर एक [PPImage] बनाएं।
4. स्लाइड में एक [PictureFrame] जोड़ें।
5. चित्र फ्रेम की सापेक्ष चौड़ाई और ऊँचाई सेट करें।
6. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दिखाता है कि कैसे सापेक्ष स्केल के साथ एक चित्र फ्रेम बनाया जाता है:

```py
import aspose.slides as slides

# PPTX फ़ाइल को प्रतिनिधित्व करने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # स्लाइड में एक चित्र फ़्रेम जोड़ें।
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करें।
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # प्रस्तुति को सहेजें।
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **चित्र फ्रेम से रैस्टर छवियों को निकालें**

आप [PictureFrame] ऑब्जेक्ट से रैस्टर छवियों को निकाल सकते हैं और उन्हें PNG, JPG और अन्य स्वरूपों में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे "sample.pptx" दस्तावेज़ से एक छवि निकाली जाए और PNG स्वरूप में सहेजी जाए।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **चित्र फ्रेम से SVG छवियों को निकालें**

जब किसी प्रस्तुति में [PictureFrame] आकारों के अंदर रखे गए SVG ग्राफ़िक्स होते हैं, तो Aspose.Slides for Python via .NET आपको मूल वेक्टर छवियों को पूर्ण सटीकता के साथ प्राप्त करने की अनुमति देता है। स्लाइड की आकार संग्रह को पार करके आप प्रत्येक [PictureFrame] को पहचान सकते हैं, जांच सकते हैं कि अंतर्निहित [PPImage] में SVG सामग्री है या नहीं, और फिर उस छवि को डिस्क या स्ट्रीम में उसकी मूल SVG स्वरूप में सहेज सकते हैं।

निम्नलिखित कोड उदाहरण दिखाता है कि कैसे एक चित्र फ्रेम से SVG छवि निकाली जाये:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **छवि की पारदर्शिता प्राप्त करें**

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव को प्राप्त करने की अनुमति देता है। यह Python कोड इस संचालन को प्रदर्शित करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
छवियों पर लागू सभी प्रभाव [aspose.slides.effects](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/) में पाए जा सकते हैं।
{{% /alert %}}

## **छवि की चमक और कंट्रास्ट प्राप्त करें**

Aspose.Slides आपको छवि पर लागू चमक और कंट्रास्ट प्रभाव को प्राप्त करने की अनुमति देता है। [Luminance] क्लास इस छवि रूपांतरण प्रभाव को दर्शाती है।

यह Python कोड दिखाता है कि कैसे एक चित्र फ्रेम से चमक और कंट्रास्ट सेटिंग्स प्राप्त की जाएँ:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **चित्र फ्रेम स्वरूपण**

Aspose.Slides कई स्वरूपण विकल्प प्रदान करता है जिन्हें आप एक चित्र फ्रेम पर लागू कर सकते हैं। इन विकल्पों के साथ, आप विशिष्ट आवश्यकताओं को पूरा करने के लिए एक चित्र फ्रेम को समायोजित कर सकते हैं।

1. एक [Presentation] वर्ग की इंस्टेंस बनाएं।
2. इंडेक्स द्वारा एक स्लाइड प्राप्त करें।
3. छवि को प्रस्तुति के [ImageCollection] में जोड़कर एक [PPImage] बनाएं। यह छवि आकार को भरने के लिए उपयोग की जाएगी।
4. फ़्रेम की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. स्लाइड के [add_picture_frame] मेथड का उपयोग करके उस आकार का एक [PictureFrame] बनाएं।
6. चित्र फ्रेम की रेखा का रंग सेट करें।
7. चित्र फ्रेम की रेखा की चौड़ाई सेट करें।
8. एक सकारात्मक (घड़ी की दिशा) या नकारात्मक (घड़ी के विपरीत) मान प्रदान करके चित्र फ्रेम को घुमाएँ।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड चित्र फ्रेम स्वरूपण प्रक्रिया को प्रदर्शित करता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX फ़ाइल को दर्शाने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # छवि के आकार के अनुसार एक चित्र फ़्रेम जोड़ें।
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # चित्र फ़्रेम पर स्वरूपण लागू करें।
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # प्रस्तुति को PPTX के रूप में सहेजें।
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose ने एक मुफ्त [Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको [JPG/JPEG को मिलाएँ](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मिलाना, या [फ़ोटो ग्रिड बनाएँ](https://products.aspose.app/slides/hi/collage/photo-grid) की आवश्यकता है, तो आप इस सेवा का उपयोग कर सकते हैं।
{{% /alert %}}

## **लिंक के रूप में छवियों को जोड़ें**

प्रस्तुति फ़ाइलों को छोटा रखने के लिए, आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियों या वीडियो को जोड़ सकते हैं। निम्नलिखित Python कोड दिखाता है कि कैसे एक प्लेसहोल्डर में एक छवि और एक वीडियो सम्मिलित किया जाये:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **छवियों को क्रॉप करें**

इस अनुभाग में, आप सीखेंगे कि कैसे एक चित्र फ्रेम के भीतर छवि के दिखाए जाने वाले क्षेत्र को स्रोत फ़ाइल को बदले बिना क्रॉप किया जाए। आप स्लाइड पर सीधे एक साफ़, केंद्रित संरचना बनाने के लिए क्रॉपिंग मार्जिन लागू करने की बुनियादी विधि भी सीखेंगे।

निम्नलिखित Python कोड दिखाता है कि स्लाइड पर छवि को कैसे क्रॉप किया जाये:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # स्लाइड में एक चित्र फ़्रेम जोड़ें।
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # छवि को क्रॉप करें (प्रतिशत मान)।
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # परिणाम सहेजें।
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **छवियों के क्रॉप किए गए क्षेत्रों को हटाएँ**

यदि आप फ़्रेम में छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो [delete_picture_cropped_areas] मेथड का उपयोग करें। यह मेथड क्रॉप की गई छवि को लौटाता है, या यदि कोई क्रॉपिंग आवश्यक नहीं है तो मूल छवि को।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # पहली स्लाइड से PictureFrame प्राप्त करें।
    picture_frame = slides.shape[0]

    # पहली स्लाइड से PictureFrame प्राप्त करें।
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # परिणाम सहेजें।
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
[delete_picture_cropped_areas] मेथड क्रॉप की गई छवि को प्रस्तुति के इमेज कलेक्शन में जोड़ता है। यदि छवि केवल प्रोसेस्ड [PictureFrame] में उपयोग हुई है, तो यह प्रस्तुति का आकार घटा सकता है; अन्यथा, परिणामी प्रस्तुति में छवियों की संख्या बढ़ सकती है।

क्रॉपिंग के दौरान, यह मेथड WMF/EMF मेटा‑फ़ाइलों को रैस्टर PNG छवि में परिवर्तित करता है।
{{% /alert %}}

## **छवियों को संपीड़ित करें**

आप प्रस्तुति में एक चित्र को [PictureFillFormat.compress_image] मेथड का उपयोग करके संपीड़ित कर सकते हैं।
यह मेथड आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर छवि का आकार घटाकर, विकल्प के साथ क्रॉप किए गए क्षेत्रों को हटाकर छवि को संपीड़ित करता है।

यह चित्र का आकार और रिज़ॉल्यूशन PowerPoint की **Picture Format -> Compress Pictures -> Resolution** सुविधा के समान समायोजित करता है।

निम्नलिखित Python उदाहरण दिखाते हैं कि कैसे लक्ष्य रिज़ॉल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में छवि को संपीड़ित किया जाये:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 150 DPI (वेब रिज़ॉल्यूशन) के लक्ष्य रिज़ॉल्यूशन के साथ छवि को संपीड़ित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # संपीड़न के परिणाम की जाँच करें।
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

या सीधे एक कस्टम DPI मान का उपयोग करके:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # 150 DPI (वेब रिज़ॉल्यूशन) पर छवि को संपीड़ित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
यह मेथड आकार और प्रदान किए गये DPI के आधार पर छवि को निम्न रिज़ॉल्यूशन में परिवर्तित करता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप किए गए क्षेत्रों को भी हटाया जा सकता है।
यदि छवि WMF/EMF जैसी मेटा‑फ़ाइल या SVG है, तो संपीड़न लागू नहीं किया जाएगा। साथ ही, JPEG गुणवत्ता को रिज़ॉल्यूशन के अनुसार बरकरार रखा जाता है या हल्के से घटाया जाता है, ठीक उसी तरह जैसे PowerPoint उच्च‑रिज़ॉल्यूशन JPEG को संभालता है।
{{% /alert %}}

## **आस्पेक्ट रेशियो को लॉक करें**

यदि आप चाहते हैं कि कोई आकार जो छवि रखता है, छवि के आयाम बदलने के बाद भी अपना आस्पेक्ट रेशियो बनाए रखे, तो [aspect_ratio_locked] प्रॉपर्टी को `True` सेट करें।

निम्नलिखित Python कोड दिखाता है कि कैसे एक आकार का आस्पेक्ट रेशियो लॉक किया जाये:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # आकार बदलते समय आस्पेक्ट अनुपात को लॉक करें।
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
यह *Lock Aspect Ratio* सेटिंग केवल आकार का आस्पेक्ट रेशियो सुरक्षित रखती है, भीतर की छवि का नहीं।
{{% /alert %}}

## **Stretch Offset गुणों का उपयोग करें**

[PictureFillFormat] क्लास की `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right`, और `stretch_offset_bottom` प्रॉपर्टी का उपयोग करके आप एक फ़िल रेक्टैंगल परिभाषित कर सकते हैं।

जब किसी छवि के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत रेक्टैंगल को फ़िल रेक्टैंगल में फिट करने के लिए स्केल किया जाता है। फ़िल रेक्टैंगल का प्रत्येक किनारा आकार के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित होता है। एक सकारात्मक प्रतिशत इनसेट को दर्शाता है, जबकि एक नकारात्मक प्रतिशत आउटसेट को दर्शाता है।

1. एक [Presentation] वर्ग की इंस्टेंस बनाएं।
2. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक आयताकार [AutoShape] जोड़ें।
4. आकार का फ़िल प्रकार सेट करें।
5. आकार का पिक्चर फ़िल मोड सेट करें।
6. एक छवि लोड करें।
7. छवि को आकार को भरने के लिए सौंपें।
8. आकार के बाउंडिंग बॉक्स के संबंधित किनारों से छवि ऑफ़सेट निर्दिष्ट करें।
9. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दिखाता है कि कैसे Stretch Offset गुणों का उपयोग किया जाये:

```py
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # एक आयताकार AutoShape जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # आकार का फ़िल प्रकार सेट करें।
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # आकार का पिक्चर फ़िल मोड सेट करें।
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # छवि को लोड करें और प्रस्तुति में जोड़ें।
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # आकार को भरने के लिए छवि असाइन करें।
    shape.fill_format.picture_fill_format.picture.image = image

    # आकार के बाउंडिंग बॉक्स के संबंधित किनारों से छवि ऑफ़सेट निर्दिष्ट करें।
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX फ़ाइल को डिस्क में सहेजें।
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose मुफ्त कन्वर्टर्स—[JPEG को PowerPoint में](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG को PowerPoint में](https://products.aspose.app/slides/hi/import/png-to-ppt)—प्रदान करता है, जिससे आप छवियों से जल्दी प्रस्तुति बना सकते हैं।
{{% /alert %}}

## **प्रश्नोत्तर**

**मैं कैसे पता कर सकता हूँ कि PictureFrame के लिए कौन से छवि स्वरूप समर्थित हैं?**

Aspose.Slides रैस्टर छवियों (PNG, JPEG, BMP, GIF आदि) और वेक्टर छवियों (जैसे SVG) को उस छवि ऑब्जेक्ट के माध्यम से समर्थन करता है जो एक [PictureFrame] को असाइन किया जाता है। समर्थित स्वरूपों की सूची आमतौर पर स्लाइड और इमेज कन्वर्ज़न इंजन की क्षमताओं के साथ ओवरलैप करती है।

**बड़े आकार की कई छवियों को जोड़ने से PPTX का आकार और प्रदर्शन पर क्या प्रभाव पड़ता है?**

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; छवियों को लिंक करने से प्रस्तुति का आकार कम रहता है, लेकिन बाहरी फ़ाइलें सुलभ रहनी चाहिए। Aspose.Slides लिंक के द्वारा छवियों को जोड़ने की सुविधा देता है जिससे फ़ाइल आकार कम किया जा सके।

**मैं छवि ऑब्जेक्ट को आकस्मिक मूव/रीसाइज़ से कैसे लॉक कर सकता हूँ?**

एक [PictureFrame] के लिए [shape locks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/picture_frame_lock/) का उपयोग करें (जैसे मूविंग या रिसाइज़िंग को निष्क्रिय करना)। लॉकिंग तंत्र को अलग [protection article](/slides/hi/python-net/applying-protection-to-presentation/) में वर्णित किया गया है और विभिन्न आकार प्रकारों, सहित [PictureFrame], के लिए समर्थित है।

**क्या SVG वेक्टर फ़िडेलिटी PDF/छवियों में निर्यात करते समय संरक्षित रहती है?**

Aspose.Slides आपको एक [PictureFrame] से मूल वेक्टर के रूप में SVG निकालने की अनुमति देता है। जब PDF (/slides/hi/python-net/convert-powerpoint-to-pdf/) या रैस्टर स्वरूपों (/slides/hi/python-net/convert-powerpoint-to-png/) में निर्यात किया जाता है, तो परिणाम निर्यात सेटिंग्स पर निर्भर करके रैस्टर हो सकता है; मूल SVG को वेक्टर के रूप में संग्रहीत रखने की पुष्टि निकालने के व्यवहार से होती है।