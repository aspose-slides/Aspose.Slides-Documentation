---
title: मॉडर्न API के साथ इमेज प्रोसेसिंग को बढ़ाएँ
linktitle: मॉडर्न API
type: docs
weight: 280
url: /hi/python-net/modern-api/
keywords:
- मॉडर्न API
- ड्राइंग
- स्लाइड थंबनेल
- स्लाइड से इमेज
- शेप थंबनेल
- शेप से इमेज
- प्रेजेंटेशन थंबनेल
- प्रेजेंटेशन से इमेजेज
- इमेज जोड़ें
- चित्र जोड़ें
- Python
- Aspose.Slides
description: "डिप्रिकेटेड इमेजिंग API को Python Modern API से बदलकर स्लाइड इमेज प्रोसेसिंग को आधुनिक बनाएँ, जिससे PowerPoint और OpenDocument ऑटोमेशन सुगम हो।"
---
## **परिचय**

Aspose.Slides for Python सार्वजनिक API वर्तमान में निम्नलिखित `aspose.pydrawing` प्रकारों पर निर्भर करता है:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

संस्करण 24.4 से, इस सार्वजनिक API को **अप्रचलित** माना गया है क्योंकि [परिवर्तनों](https://releases.aspose.com/slides/hi/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) के कारण।

Public API से `aspose.pydrawing` को हटाने के लिए, हमने **Modern API** पेश किया है। `aspose.pydrawing.Image` और `aspose.pydrawing.Bitmap` का उपयोग करने वाले मेथड अप्रचलित हैं और उनके Modern API समतुल्य द्वारा प्रतिस्थापित किए जाने चाहिए। `aspose.pydrawing.Graphics` का उपयोग करने वाले मेथड अप्रचलित हैं और उनका कोई प्रत्यक्ष Modern API प्रतिस्थापन नहीं है।

वर्तमान संस्करणों में, `aspose.pydrawing` पर निर्भर सार्वजनिक API को पुराना/अप्रचलित मानें। नए कोड और मौजूदा इमेज‑प्रोसेसिंग वर्कफ़्लो को माइग्रेट करते समय Modern API का उपयोग करें।

## **Modern API**

निम्नलिखित क्लास और एन्नम सार्वजनिक API में जोड़े गए हैं:

- [aspose.slides.IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) - एक रास्टर या वेक्टर छवि को दर्शाता है।
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imageformat/) - एक इमेज फ़ाइल फ़ॉर्मेट को दर्शाता है।
- [aspose.slides.Images](https://reference.aspose.com/slides/hi/python-net/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) के साथ काम करने के लिए मेथड प्रदान करता है।

`get_image` का उपयोग एकल स्लाइड या शेप को रेंडर करने के लिए करें। कई प्रेजेंटेशन स्लाइड्स को रेंडर करने के लिए `get_images` का उपयोग करें। इमेज लोड करने के लिए [Images](https://reference.aspose.com/slides/hi/python-net/aspose.slides/images/) मेथड, प्रेजेंटेशन में जोड़ने के लिए `add_image` के साथ [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/), और मौजूदा प्रेजेंटेशन इमेज को अपडेट करने के लिए `replace_image` के साथ [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) का उपयोग करें।

नए API के एक सामान्य उपयोग उदाहरण इस प्रकार दिखता है:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **पुराने कोड को Modern API से बदलें**

नया [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) क्लास `aspose.pydrawing.Image` और `aspose.pydrawing.Bitmap` क्लासों के अलग‑अलग API को दर्शाता है। अधिकांश मामलों में, आपको केवल `aspose.pydrawing` का उपयोग करने वाले मेथड कॉल को उनके Modern API समकक्ष से बदलना होगा।

### **स्लाइड थंबनेल प्राप्त करें**

**अप्रचलित API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **शेप थंबनेल प्राप्त करें**

**अप्रचलित API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **प्रेजेंटेशन थंबनेल प्राप्त करें**

**अप्रचलित API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Modern API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **प्रेजेंटेशन में चित्र जोड़ें**

**अप्रचलित API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **हटाए जाने वाले मेथड और प्रॉपर्टी तथा उनके Modern प्रतिस्थापन**

### **Presentation क्लास**

|मेथड सिग्नेचर|प्रतिस्थापन मेथड सिग्नेचर|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Slide क्लास**

|मेथड सिग्नेचर|प्रतिस्थापन मेथड सिग्नेचर|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Shape क्लास**

|मेथड सिग्नेचर|प्रतिस्थापन मेथड सिग्नेचर|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection क्लास**

|मेथड सिग्नेचर|प्रतिस्थापन मेथड सिग्नेचर|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage क्लास**

|मेथड/प्रॉपर्टी सिग्नेचर|प्रतिस्थापन मेथड/प्रॉपर्टी सिग्नेचर|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory क्लास**

|मेथड सिग्नेचर|प्रतिस्थापन मेथड सिग्नेचर|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat क्लास**

|मेथड सिग्नेचर|प्रतिस्थापन मेथड सिग्नेचर|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData क्लास**

|मेथड सिग्नेचर|प्रतिस्थापन मेथड सिग्नेचर|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output क्लास**

|मेथड सिग्नेचर|प्रतिस्थापन मेथड सिग्नेचर|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **aspose.pydrawing.Graphics के लिए API समर्थन**

`aspose.pydrawing.Graphics` का उपयोग करने वाले मेथड अप्रचलित हैं और उनका कोई प्रत्यक्ष Modern API प्रतिस्थापन नहीं है।

`aspose.pydrawing.Graphics` पर रेंडर करने वाले API के बजाय Modern API इमेज‑रेंडरिंग मेथड का उपयोग करें:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**`aspose.pydrawing.Graphics` क्यों हटाया गया?**

`aspose.pydrawing.Graphics` के लिए समर्थन सार्वजनिक API में अप्रचलित कर दिया गया है ताकि रेंडरिंग और इमेज के काम को एकीकृत किया जा सके, प्लेटफ़ॉर्म‑विशिष्ट निर्भरताओं को हटाया जा सके, और [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) के साथ क्रॉस‑प्लेटफ़ॉर्म दृष्टिकोण अपनाया जा सके। `aspose.pydrawing.Graphics` पर रेंडर करने के बजाय `get_image` या `get_images` का उपयोग करें।

**[IImage] का `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap` की तुलना में व्यावहारिक लाभ क्या है?**

[IImage] रास्टर और वेक्टर दोनों इमेज के साथ काम करने को एकीकृत करता है, विभिन्न फ़ॉर्मेट में सहेजने को [ImageFormat] के माध्यम से सरल बनाता है, pydrawing पर निर्भरता को घटाता है, और कोड को विभिन्न पर्यावरणों में अधिक पोर्टेबल बनाता है।

**क्या Modern API थंबनेल जनरेट करने के प्रदर्शन को प्रभावित करेगा?**

`get_thumbnail` से `get_image` में स्विच करने से प्रदर्शन में कोई गिरावट नहीं आती; नए मेथड समान क्षमताएँ प्रदान करते हैं, विकल्पों और आकारों के साथ इमेज उत्पन्न करने के लिए, जबकि रेंडरिंग विकल्पों को भी सपोर्ट करते हैं। विशिष्ट लाभ या कमी परिदृश्य पर निर्भर करती है, लेकिन कार्यात्मक रूप से प्रतिस्थापन समान हैं।