---
title: Android में समूह प्रस्तुति आकार
linktitle: आकार समूह
type: docs
weight: 40
url: /hi/androidjava/group/
keywords:
- समूह आकार
- आकार समूह
- समूह जोड़ें
- वैकल्पिक पाठ
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके PowerPoint डेक में आकारों को समूहित और अनसमूहित करना सीखें—तेज़, चरण-दर-चरण मार्गदर्शिका जिसमें निःशुल्क Java कोड शामिल है।"
---
## **अवलोकन**

यह लेख Aspose.Slides में समूह आकारों के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि स्लाइड में समूह आकार कैसे जोड़ें, उसके भीतर आकार रखें, और अपडेटेड प्रस्तुति को सहेजें। यह यह भी दर्शाता है कि समूह के भीतर संग्रहीत आकारों तक कैसे पहुंचें और उनके `AlternativeText` मान पढ़ें। इसके अतिरिक्त, लेख संक्षेप में संबंधित समूह‑आकार क्षमताओं जैसे नेस्टेड समूह, z-order, और लॉकिंग विकल्पों को कवर करता है।

## **समूह आकार जोड़ें**
Aspose.Slides स्लाइड्स में समूह आकारों के साथ काम करने का समर्थन करता है। यह सुविधा डेवलपर्स को अधिक समृद्ध प्रस्तुतियों को समर्थन देने में मदद करती है। Aspose.Slides for Android via Java समूह आकार जोड़ने या पहुंचने का समर्थन करता है। जोड़े गए समूह आकार में आकार जोड़ना संभव है ताकि उसे भर सकें या समूह आकार की किसी भी प्रॉपर्टी तक पहुंच सकें। Aspose.Slides for Android via Java का उपयोग करके स्लाइड में समूह आकार जोड़ने के लिए:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) class.
2. Obtain the reference of a slide by using its Index
3. Add a group shape to the slide.
4. Add the shapes to the added group shape.
5. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

```java
// Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // स्लाइड्स के आकार संग्रह को एक्सेस करना
    IShapeCollection slideShapes = sld.getShapes();

    // स्लाइड में एक समूह आकार जोड़ना
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // जोड़े गए समूह आकार के भीतर आकार जोड़ना
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // समूह आकार फ्रेम जोड़ना
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **AltText प्रॉपर्टी तक पहुँचें**
यह विषय सरल चरण दिखाता है, कोड उदाहरणों सहित, स्लाइड्स पर समूह आकार जोड़ने और AltText प्रॉपर्टी तक पहुंचने के लिए। Aspose.Slides for Android via Java का उपयोग करके स्लाइड में समूह आकार के AltText तक पहुंचने के लिए:

1. Instantiate [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) class that represents PPTX file.
2. Obtain the reference of a slide by using its Index.
3. Accessing the shape collection of slides.
4. Accessing the group shape.
5. Accessing the [AlternativeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getAlternativeText--) property.

The example below accesses alternative text of group shape.

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("AltText.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // स्लाइड्स के आकार संग्रह को एक्सेस करना
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // समूह आकार को एक्सेस करना।
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // AltText प्रॉपर्टी को एक्सेस करना
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या नेस्टेड समूह (एक समूह के अंदर एक समूह) समर्थित है?**

Yes. [GroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/groupshape/) के पास [getParentGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getParentGroup--) मेथड है, जो सीधे ही पदानुक्रम समर्थन दर्शाता है (एक समूह किसी अन्य समूह का चाइल्ड हो सकता है)।

**स्लाइड पर अन्य वस्तुओं के सापेक्ष समूह के z-order को कैसे नियंत्रित करूँ?**

Use the [GroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/groupshape/)’s [getZOrderPosition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getZOrderPosition--) method to inspect its position in the display stack.

**क्या मैं मूविंग/एडिटिंग/अनग्रुपिंग को रोक सकता हूँ?**

Yes. The group’s lock section is exposed via [getGroupShapeLock](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--), which lets you restrict operations on the object.