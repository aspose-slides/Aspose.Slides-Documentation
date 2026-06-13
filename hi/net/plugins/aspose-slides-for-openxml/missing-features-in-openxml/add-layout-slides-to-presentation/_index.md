---
title: प्रेजेंटेशन में लेआउट स्लाइड जोड़ें
type: docs
weight: 20
url: /hi/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET डेवलपर्स को प्रस्तुति में नए लेआउट स्लाइड जोड़ने की अनुमति देता है। लेआउट स्लाइड जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- Presentation वर्ग का एक इंस्टेंस बनाएँ
- Master Slide संग्रह तक पहुँचें
- मौजूदा लेआउट स्लाइड खोजने का प्रयास करें यह देखने के लिए कि आवश्यक स्लाइड लेआउट स्लाइड संग्रह में पहले से उपलब्ध है या नहीं
- यदि वांछित लेआउट उपलब्ध नहीं है तो नया लेआउट स्लाइड जोड़ें
- नए जोड़े गए लेआउट स्लाइड के साथ एक खाली स्लाइड जोड़ें
- अंत में, Presentation ऑब्जेक्ट का उपयोग करके प्रस्तुति फ़ाइल लिखें
## **उदाहरण**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें

using (Presentation p = new Presentation(FileName))

{

    // लेआउट स्लाइड प्रकार द्वारा खोजें

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // वह स्थिति जब प्रेजेंटेशन में कुछ प्रकार के लेआउट शामिल नहीं होते हैं।

        // Technographics.pptx प्रेजेंटेशन में केवल Blank और Custom लेआउट प्रकार होते हैं।

        // लेकिन Custom प्रकार वाले लेआउट स्लाइड में अलग-अलग स्लाइड नाम होते हैं,

        // जैसे "Title", "Title and Content", आदि। और इनका उपयोग करना संभव है

        // लेआउट स्लाइड चयन के लिए नामों का।

        // साथ ही प्लेसहोल्डर शेप प्रकारों के सेट का उपयोग करना संभव है। उदाहरण के लिए,

        // Title स्लाइड में केवल Title प्लेसहोल्डर टाइप होना चाहिए, आदि।

        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

        {

            if (titleAndObjectLayoutSlide.Name == "Title and Object")

            {

                layoutSlide = titleAndObjectLayoutSlide;

                break;

            }

        }

        if (layoutSlide == null)

        {

            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

            {

                if (titleLayoutSlide.Name == "Title")

                {

                    layoutSlide = titleLayoutSlide;

                    break;

                }

            }

            if (layoutSlide == null)

            {

                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

                if (layoutSlide == null)

                {

                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");

                }

            }

        }

    }

    //जोड़ें खाली स्लाइड को जोड़े गए लेआउट स्लाइड के साथ 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //प्रेजेंटेशन सहेजें    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **चल रहा उदाहरण डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 
अधिक जानकारी के लिए, देखें [.NET में स्लाइड लेआउट लागू या बदलें](/slides/hi/net/slide-layout/).
{{% /alert %}}