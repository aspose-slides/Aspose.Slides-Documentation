---
title: Python के साथ प्रस्तुतियों में चित्र फ्रेम जोड़ें
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/python-net/picture-frame/
keywords:
- चित्र फ्रेम
- चित्र फ्रेम जोड़ें
- चित्र फ्रेम बनाएं
- चित्र जोड़ें
- चित्र बनाएं
- चित्र निकालें
- रास्टर चित्र
- वेक्टर चित्र
- चित्र को क्रॉप करें
- क्रॉप किया गया क्षेत्र
- StretchOff प्रॉपर्टी
- चित्र फ्रेम फ़ॉर्मेटिंग
- चित्र फ्रेम प्रॉपर्टी
- सापेक्ष स्केल
- चित्र प्रभाव
- अस्पेक्ट रेशियो
- चित्र पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ्रेम जोड़ें। अपने कार्यप्रवाह को सरल बनाएं और स्लाइड डिज़ाइन को बेहतर करें।"
---
## **परिचय**

Aspose.Slides for Python में चित्र फ्रेम आपको रास्टर और वेक्टर इमेजेज़ को नेवेटिव स्लाइड शेप के रूप में रखने और प्रबंधित करने की सुविधा देते हैं। आप फ़ाइलों या स्ट्रीम्स से चित्र सम्मिलित कर सकते हैं, सटीक निर्देशांकों के साथ उनकी स्थिति और आकार बदल सकते हैं, घुमाव लागू कर सकते हैं, पारदर्शिता सेट कर सकते हैं, और अन्य शेप्स के साथ z‑order नियंत्रित कर सकते हैं। API क्रॉपिंग, अनुपात बनाए रखने, बॉर्डर और इफ़ेक्ट सेट करने, और लेआउट को पुनः बनाये बिना मूल छवि को बदलने का समर्थन भी करती है। क्योंकि चित्र फ्रेम सामान्य शेप्स की तरह व्यवहार करते हैं, आप एनीमेशन, हाइपरलिंक, और Alt टेक्स्ट जोड़ सकते हैं, जिससे दृश्य रूप से समृद्ध और सुलभ प्रस्तुतियों का निर्माण आसान हो जाता है।

## **चित्र फ्रेम बनाना**

यह अनुभाग दिखाता है कि Aspose.Slides for Python के साथ एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) बनाकर स्लाइड में चित्र कैसे डालें। आप सीखेंगे कि चित्र को लोड करना, स्लाइड पर सटीक रूप से रखना, और उसके आकार व फ़ॉर्मेटिंग को नियंत्रित करना।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से एक स्लाइड प्राप्त करें।
3. प्रस्तुति की [ImageCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/) में चित्र जोड़कर एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) बनाएं। यह चित्र शेप को भरने के लिए उपयोग किया जाएगा।
4. फ्रेम की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. उस आकार के साथ एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) बनाएं, इसके लिए [add_picture_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_picture_frame/) मेथड का उपयोग करें।
6. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया Python कोड दिखाता है कि चित्र फ्रेम कैसे बनाया जाता है:

```py
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास का इंस्टैंस बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # प्रस्तुति में चित्र जोड़ें।
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # चित्र के आकार के अनुसार एक picture frame जोड़ें।
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # प्रस्तुति को PPTX के रूप में सहेजें।
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
चित्र फ्रेम का उपयोग करके आप जल्दी से छवियों से प्रस्तुति स्लाइड बना सकते हैं। जब आप चित्र फ्रेम को Aspose.Slides की सेव विकल्पों के साथ संयोजित करते हैं, तो आप I/O ऑपरेशन को नियंत्रित कर एक फॉर्मेट से दूसरे फॉर्मेट में छवियों को बदल सकते हैं। आप इन पृष्ठों को देखना चाह सकते हैं: convert [छवि को JPG में बदलें](https://products.aspose.com/slides/hi/python-net/conversion/image-to-jpg/); convert [JPG को छवि में बदलें](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-image/); convert [JPG को PNG में बदलें](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-png/); convert [PNG को JPG में बदलें](https://products.aspose.com/slides/hi/python-net/conversion/png-to-jpg/); convert [PNG को SVG में बदलें](https://products.aspose.com/slides/hi/python-net/conversion/png-to-svg/); convert [SVG को PNG में बदलें](https://products.aspose.com/slides/hi/python-net/conversion/svg-to-png/)।
{{% /alert %}}

## **सापेक्ष स्केल के साथ चित्र फ्रेम बनाना**

यह अनुभाग दर्शाता है कि एक निश्चित आकार पर चित्र रखें, फिर उसकी चौड़ाई और ऊँचाई पर प्रतिशत‑आधारित स्केल स्वतंत्र रूप से लागू करें। चूँकि प्रतिशत अलग‑अलग हो सकते हैं, इसलिए अनुपात बदल सकता है। स्केलिंग चित्र के मूल आयामों के सापेक्ष की जाती है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से एक स्लाइड प्राप्त करें।
3. प्रस्तुति की [ImageCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/) में चित्र जोड़कर एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) बनाएं।
4. स्लाइड में एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) जोड़ें।
5. चित्र फ्रेम की सापेक्ष चौड़ाई और ऊँचाई सेट करें।
6. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया Python कोड दर्शाता है कि सापेक्ष स्केल के साथ चित्र फ्रेम कैसे बनाया जाए:

```py
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास का इंस्टैंस बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # प्रस्तुति की इमेज कलेक्शन में चित्र जोड़ें।
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # स्लाइड में एक picture frame जोड़ें।
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करें।
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # प्रस्तुति को सहेजें।
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **चित्र फ्रेम से रास्टर इमेज निकालना**

आप [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) ऑब्जेक्ट्स से रास्टर इमेजेज़ निकाल सकते हैं और उन्हें PNG, JPG आदि फॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण "sample.pptx" दस्तावेज़ से एक इमेज निकालता है और PNG फॉर्मेट में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **चित्र फ्रेम से SVG इमेज निकालना**

जब प्रस्तुति में SVG ग्राफ़िक्स [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) शेप के भीतर रखी जाती हैं, तो Aspose.Slides for Python via .NET आपको मूल वेक्टर इमेजेज़ को पूरी सच्चाई के साथ प्राप्त करने की अनुमति देता है। स्लाइड की शेप कलेक्शन को ट्रैवर्स करके आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) की पहचान कर सकते हैं, देख सकते हैं कि अंतर्निहित [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) में SVG सामग्री है या नहीं, और फिर उस इमेज को डिस्क या स्ट्रीम में उसके मूल SVG फॉर्मेट में सहेज सकते हैं।

नीचे दिया गया कोड उदाहरण दर्शाता है कि एक चित्र फ्रेम से SVG इमेज कैसे निकाली जाए:

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

## **इमेज की पारदर्शिता प्राप्त करना**

Aspose.Slides आपको इमेज पर लागू पारदर्शिता इफ़ेक्ट को प्राप्त करने की अनुमति देता है। यह Python कोड इस ऑपरेशन को दर्शाता है:

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
छवियों पर लागू सभी इफ़ेक्ट्स को आप [aspose.slides.effects](https://reference.aspose.com/slides/hi/python-net/aspose.slides.effects/) में पा सकते हैं।
{{% /alert %}}

## **चित्र फ्रेम फ़ॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जिन्हें आप एक चित्र फ्रेम पर लागू कर सकते हैं। इन विकल्पों के साथ आप चित्र फ्रेम को विशिष्ट आवश्यकताओं के अनुसार समायोजित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से एक स्लाइड प्राप्त करें।
3. प्रस्तुति की [ImageCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/) में चित्र जोड़कर एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) बनाएं। यह चित्र शेप को भरने के लिए उपयोग किया जाएगा।
4. फ्रेम की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. स्लाइड की [add_picture_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_picture_frame/) मेथड का उपयोग करके उस आकार का एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) बनाएं।
6. चित्र फ्रेम की लाइन रंग सेट करें।
7. चित्र फ्रेम की लाइन चौड़ाई सेट करें।
8. सकारात्मक (घड़ी की दिशा) या नकारात्मक (घड़ी के विपरीत) मान प्रदान करके चित्र फ्रेम को घुमाएँ।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया Python कोड चित्र फ्रेम फ़ॉर्मेटिंग प्रक्रिया को दर्शाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX फ़ाइल का प्रतिनिधित्व करने के लिए Presentation क्लास का इंस्टैंस बनाएं।
with slides.Presentation() as presentation:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # प्रस्तुति की इमेज कलेक्शन में चित्र जोड़ें।
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # चित्र के आकार के अनुसार एक picture frame जोड़ें।
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # चित्र फ्रेम पर फ़ॉर्मेटिंग लागू करें।
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # प्रस्तुति को PPTX के रूप में सहेजें।
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose ने एक मुफ्त [Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको [JPG/JPEG को मर्ज करना](https://products.aspose.app/slides/hi/collage/jpg) या PNG इमेजेज़, या [फोटो ग्रिड बनाना](https://products.aspose.app/slides/hi/collage/photo-grid) है, तो आप इस सेवा का उपयोग कर सकते हैं।
{{% /alert %}}

## **इमेज को लिंक के रूप में जोड़ना**

प्रस्तुति फ़ाइलों के आकार को छोटा रखने के लिए, आप इमेजेज़ या वीडियो को सीधे एम्बेड करने के बजाय लिंक के माध्यम से जोड़ सकते हैं। नीचे दिया गया Python कोड दर्शाता है कि प्लेसहोल्डर में एक इमेज और एक वीडियो कैसे सम्मिलित किया जाए:

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

## **इमेज को क्रॉप करना**

इस अनुभाग में आप सीखेंगे कि चित्र फ्रेम के भीतर छवि के दिखाई देने वाले भाग को स्रोत फ़ाइल को बदले बिना कैसे क्रॉप किया जाए। आप स्लाइड पर सीधे एक साफ़, केंद्रित कंपोज़िशन बनाने के लिए क्रॉप मार्जिन लागू करने की बुनियादी विधि भी सीखेंगे।

नीचे दिया गया Python कोड स्लाइड पर इमेज को क्रॉप करने का तरीका दिखाता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # प्रस्तुति की इमेज कलेक्शन में चित्र जोड़ें।
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # स्लाइड में एक picture frame जोड़ें।
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # चित्र को क्रॉप करें (प्रतिशत मान)।
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # परिणाम सहेजें।
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **क्रॉप किए गए क्षेत्रों को हटाना**

यदि आप फ्रेम में एक इमेज के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो [delete_picture_cropped_areas](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) मेथड का उपयोग करें। यह मेथड क्रॉप की गई इमेज लौटाता है, या यदि कोई क्रॉप नहीं किया गया है तो मूल इमेज लौटाता है।

नीचे दिया गया Python कोड इस ऑपरेशन को दर्शाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # पहले स्लाइड से PictureFrame प्राप्त करें।
    picture_frame = slides.shape[0]

    # पहले स्लाइड से PictureFrame प्राप्त करें।
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # परिणाम सहेजें।
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
[delete_picture_cropped_areas](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) मेथड क्रॉप की गई इमेज को प्रस्तुति की इमेज कलेक्शन में जोड़ता है। यदि इमेज केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) में उपयोग हुई है, तो यह प्रस्तुति का आकार घटा सकता है; अन्यथा परिणामी प्रस्तुति में इमेज की संख्या बढ़ सकती है।

क्रॉपिंग के दौरान यह मेथड WMF/EMF मे्टाफाइलों को रास्टर PNG इमेज में बदल देता है।
{{% /alert %}}

## **इमेज को संपीड़ित करना**

आप एक प्रस्तुति में चित्र को [PictureFillFormat.compress_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/compress_image/) मेथड का उपयोग करके संपीड़ित कर सकते हैं। यह मेथड आकार को शेप के आकार और निर्दिष्ट रेज़ॉल्यूशन के आधार पर घटाकर इमेज को संपीड़ित करता है, साथ ही क्रॉप किए गए क्षेत्रों को हटाने का विकल्प देता है।

यह चित्र का आकार और रेज़ॉल्यूशन को PowerPoint के **Picture Format -> Compress Pictures -> Resolution** विकल्प के समान समायोजित करता है।

नीचे दिए गए Python उदाहरण दर्शाते हैं कि लक्ष्य रेज़ॉल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में इमेज को कैसे संपीड़ित किया जाए:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # लक्ष्य रेज़ॉल्यूशन 150 DPI (वेब रेज़ॉल्यूशन) के साथ छवि को संपीड़ित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
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

    # चित्र को 150 DPI (वेब रिज़ॉल्यूशन) तक संपीड़ित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
यह मेथड शेप के आकार और प्रदान किए गए DPI के आधार पर इमेज को कम रेज़ॉल्यूशन में बदल देता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप किए गए क्षेत्रों को भी हटाया जा सकता है।
यदि इमेज एक मे़टाफाइल (WMF/EMF) या SVG है, तो संपीड़न लागू नहीं किया जाएगा। साथ ही JPEG की गुणवत्ता रेज़ॉल्यूशन के अनुसार संरक्षित या हल्की घटेगी, ठीक उसी तरह जैसे PowerPoint उच्च‑रेज़ॉल्यूशन JPEG को संभालता है।
{{% /alert %}}

## **आस्पेक्ट रेशियो को लॉक करना**

यदि आप चाहते हैं कि कोई शेप जो इमेज रखता है, इमेज के आयाम बदलने के बाद भी अपना अस्पेक्ट रेशियो बनाए रखे, तो [aspect_ratio_locked](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) प्रॉपर्टी को `True` सेट करें।

नीचे दिया गया Python कोड दर्शाता है कि शेप के अस्पेक्ट रेशियो को कैसे लॉक किया जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # रिसाइज़ करते समय अस्पेक्ट रेशियो को लॉक करें।
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
यह *Lock Aspect Ratio* सेटिंग केवल शेप के अस्पेक्ट रेशियो को संरक्षित करती है, शेप के भीतर की इमेज के अस्पेक्ट रेशियो को नहीं।
{{% /alert %}}

## **Stretch Offset प्रॉपर्टीज़ का उपयोग करना**

[PictureFillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) क्लास की `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` और `stretch_offset_bottom` प्रॉपर्टीज़ का उपयोग करके आप एक फ़िल रेक्टेंगल परिभाषित कर सकते हैं।

जब किसी इमेज के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत रेक्टेंगल को फ़िल रेक्टेंगल में फिट करने के लिए स्केल किया जाता है। फ़िल रेक्टेंगल के प्रत्येक किनारे को शेप के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित किया जाता है। सकारात्मक प्रतिशत इन्सेट को दर्शाता है, जबकि नकारात्मक प्रतिशत आउटसेट को।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स से एक स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
4. शेप का फ़िल टाइप सेट करें।
5. शेप का पिक्चर फ़िल मोड सेट करें।
6. एक इमेज लोड करें।
7. शेप को भरने के लिए इमेज असाइन करें।
8. शेप के बाउंडिंग बॉक्स के संबंधित किनारों से इमेज ऑफ़सेट निर्दिष्ट करें।
9. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया Python कोड दिखाता है कि Stretch Offset प्रॉपर्टीज़ का उपयोग कैसे किया जाए:

```py
import aspose.slides as slides

    # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
    with slides.Presentation() as presentation:
        # पहली स्लाइड प्राप्त करें।
        slide = presentation.slides[0]

        # एक आयताकार AutoShape जोड़ें।
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

        # शेप का फ़िल टाइप सेट करें।
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # शेप की पिक्चर फ़िल मोड सेट करें।
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # इमेज लोड करें और उसे प्रस्तुति में जोड़ें।
        with open("image.jpeg", "rb") as image_stream:
            image = presentation.images.add_image(image_stream)

        # चित्र को शेप को भरने के लिए असाइन करें।
        shape.fill_format.picture_fill_format.picture.image = image

        # शेप के बाउंडिंग बॉक्स के संबंधित किनारों से इमेज ऑफ़सेट निर्दिष्ट करें।
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

        # PPTX फ़ाइल को डिस्क पर सहेजें।
        presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose मुफ्त कन्वर्टर्स प्रदान करता है—[JPEG को PowerPoint में बदलें](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG को PowerPoint में बदलें](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको इमेजेज़ से जल्दी प्रस्तुति बनाने देते हैं।
{{% /alert %}}

## **FAQ**

**मैं कैसे जान सकता हूँ कि PictureFrame के लिए कौन‑से इमेज फॉर्मेट समर्थित हैं?**

Aspose.Slides रास्टर इमेजेज़ (PNG, JPEG, BMP, GIF आदि) और वेक्टर इमेजेज़ (जैसे SVG) दोनों को उस इमेज ऑब्जेक्ट के माध्यम से सपोर्ट करता है जो एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) को असाइन किया गया है। समर्थित फॉर्मेट्स की सूची आम तौर पर स्लाइड और इमेज कन्वर्ज़न इंजन की क्षमताओं के साथ ओवरलैप करती है।

**दर्जनों बड़े इमेजेज़ जोड़ने से PPTX आकार और प्रदर्शन पर क्या असर पड़ता है?**

बड़ी इमेजेज़ को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; इमेजेज़ को लिंक करने से प्रस्तुति का आकार छोटा रहता है लेकिन बाहरी फ़ाइलें उपलब्ध रहनी चाहिए। Aspose.Slides लिंक के द्वारा इमेजेज़ जोड़ने की सुविधा देता है ताकि फ़ाइल आकार कम रहे।

**मैं इमेज ऑब्जेक्ट को आकस्मिक मूव/रीसाइज़ से कैसे लॉक करूँ?**

एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) के लिए आप [shape locks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/picture_frame_lock/) का उपयोग कर सकते हैं (उदाहरण के लिए, मूव या रीसाइज़ को डिसेबल करना)। लॉकिंग मैकेनिज़्म शेप्स के लिए एक अलग [protection article](/slides/hi/python-net/applying-protection-to-presentation/) में बताया गया है और विभिन्न शेप टाइप्स, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) शामिल है, के लिए सपोर्टेड है।

**PDF/इमेज में प्रस्तुति एक्सपोर्ट करते समय क्या SVG वेक्टर फ़िडेलिटी बनी रहती है?**

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने की अनुमति देता है। जब आप [PDF में एक्सपोर्ट](/slides/hi/python-net/convert-powerpoint-to-pdf/) या [रास्टर फॉर्मेट्स में एक्सपोर्ट](/slides/hi/python-net/convert-powerpoint-to-png/) करते हैं, तो सेटिंग्स के अनुसार परिणाम रास्टराइज़ हो सकता है; लेकिन मूल SVG को वेक्टर के रूप में संरक्षित रखने की पुष्टि एक्सट्रैक्शन व्यवहार से होती है।