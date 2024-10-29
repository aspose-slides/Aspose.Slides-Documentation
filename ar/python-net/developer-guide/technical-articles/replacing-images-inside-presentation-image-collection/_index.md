---
title: استبدال الصور داخل مجموعة صور العرض
type: docs
weight: 110
url: /ar/python-net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

تتيح لك Aspose.Slides لـ Python عبر .NET استبدال الصور المضافة في أشكال الشرائح. يشرح هذا المقال كيفية استبدال الصورة المضافة في مجموعة صور العرض باستخدام طرق مختلفة.

{{% /alert %}} 
## **استبدال الصورة داخل مجموعة صور العرض**
توفر Aspose.Slides لـ Python عبر .NET طرق API بسيطة لاستبدال الصور داخل مجموعة صور العرض. يرجى اتباع الخطوات أدناه:

1. قم بتحميل ملف العرض مع الصورة بداخله باستخدام [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. قم بتحميل صورة من ملف في مصفوفة بايت.
1. استبدل الصورة المستهدفة بالصورة الجديدة في مصفوفة بايت.
1. في الطريقة الثانية، قم بتحميل الصورة في كائن Image واستبدل الصورة المستهدفة بالصورة التي تم تحميلها.
1. في الطريقة الثالثة، استبدل الصورة بصورة تم إضافتها مسبقًا في مجموعة صور العرض.
1. قم بكتابة العرض المعدل كملف PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

#Instantiate the presentation
with slides.Presentation("pres.pptx") as presentation:

    #the first way
    data = read_all_bytes("image_0.jpeg")
    oldImage = presentation.images[0]
    oldImage.replace_image(data)

    #the second way
    newImage = slides.Images.from_file("image_1.jpeg")
    oldImage = presentation.images[1]
    oldImage.replace_image(newImage)

    #the third way
    oldImage = presentation.images[2]
    oldImage.replace_image(presentation.images[3])

    #Save the presentation
    presentation.save("replace_image-out.pptx", slides.export.SaveFormat.PPTX)
```