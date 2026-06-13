---
title: प्रस्तुति में लेआउट स्लाइड जोड़ें
type: docs
weight: 10
url: /hi/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET डेवलपर्स को प्रस्तुति में नई लेआउट स्लाइड जोड़ने की अनुमति देता है। लेआउट स्लाइड जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक उदाहरण बनाएं
- Master Slide संग्रह तक पहुंचें
- मौजूदा लेआउट स्लाइड्स को खोजने का प्रयास करें कि क्या आवश्यक स्लाइड पहले से ही Layout Slide संग्रह में उपलब्ध है या नहीं
- यदि इच्छित लेआउट उपलब्ध नहीं है तो नई Layout स्लाइड जोड़ें
- नए जोड़े गए Layout स्लाइड के साथ एक खाली स्लाइड जोड़ें
- अंत में, Presentation ऑब्जेक्ट का उपयोग करके प्रस्तुति फ़ाइल लिखें।

## **उदाहरण**
``` csharp

 //प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं

using (Presentation p = new Presentation("Test.pptx"))

{

   // लेआउट स्लाइड प्रकार द्वारा खोजने का प्रयास करें

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // वह स्थिति जब प्रस्तुति में कुछ प्रकार के लेआउट नहीं होते।

     // Technographics.pptx प्रस्तुति में केवल Blank और Custom लेआउट प्रकार होते हैं।

     // लेकिन Custom प्रकार वाली लेआउट स्लाइड्स के अलग-अलग स्लाइड नाम होते हैं,

     // जैसे "Title", "Title and Content", आदि। और इन्हें उपयोग करना संभव है

     // लेआउट स्लाइड चयन के लिए नाम।

     // साथ ही placeholder shape प्रकारों का सेट उपयोग करना संभव है। उदाहरण के लिए,

     // Title स्लाइड में केवल Title placeholder प्रकार होना चाहिए, आदि.

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

  // जोड़ित लेआउट स्लाइड के साथ खाली स्लाइड जोड़ना
  p.Slides.InsertEmptySlide(0, layoutSlide);
  // प्रस्तुति सहेजें
  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **चल रहा उदाहरण डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
For more details, visit [Apply or Change Slide Layouts in .NET](/slides/hi/net/slide-layout/).
{{% /alert %}}