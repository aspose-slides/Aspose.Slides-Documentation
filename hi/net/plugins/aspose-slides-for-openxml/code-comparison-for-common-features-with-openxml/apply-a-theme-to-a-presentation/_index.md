---
title: प्रस्तुति पर थीम लागू करें
type: docs
weight: 30
url: /hi/net/apply-a-theme-to-a-presentation/
---
## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// नई थीम को प्रस्तुति में लागू करें। 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// नई थीम को प्रस्तुति में लागू करें। 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // प्रस्तुति दस्तावेज़ के प्रस्तुति भाग को प्राप्त करें।

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // मौजूदा स्लाइड मास्टर भाग को प्राप्त करें।

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // नया स्लाइड मास्टर भाग प्राप्त करें।

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // मौजूदा थीम भाग को हटाएँ।

    presentationPart.DeletePart(presentationPart.ThemePart);

    // पुराने स्लाइड मास्टर भाग को हटाएँ।

    presentationPart.DeletePart(slideMasterPart);

    // नया स्लाइड मास्टर भाग आयात करें, और पुराने संबंध आईडी को पुन: उपयोग करें।

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // नए थीम भाग में बदलें।

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // इस उदाहरण के लिए लेआउट कोड डालें।

    string defaultLayoutType = "Title and Content";

    // सभी स्लाइड्स पर स्लाइड लेआउट संबंध को हटाएँ। 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // प्रत्येक स्लाइड के लिए स्लाइड लेआउट प्रकार निर्धारित करें।

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // पुराना लेआउट भाग हटाएँ।

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // नया लेआउट भाग लागू करें।

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // नया डिफ़ॉल्ट लेआउट भाग लागू करें।

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// स्लाइड लेआउट प्रकार प्राप्त करें।

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // टिप्पणी: यदि इसे उत्पादन कोड में उपयोग किया जाता है, तो null संदर्भ के लिए जाँच करें।

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
थीम लागू करने के लिए हमें स्लाइड को मास्टर के साथ क्लोन करना होगा, कृपया नीचे दिए गए चरणों का पालन करें:

- स्रोत प्रस्तुति जिसमें से स्लाइड क्लोन की जाएगी, उसे सम्मिलित करने वाले Presentation क्लास का एक इंस्टेंस बनाएं।
- गंतव्य प्रस्तुति जिसमें स्लाइड क्लोन की जाएगी, उसे सम्मिलित करने वाले Presentation क्लास का एक इंस्टेंस बनाएं।
- क्लोन की जाने वाली स्लाइड को उसके मास्टर स्लाइड के साथ एक्सेस करें।
- गंतव्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा प्रदर्शित Masters संग्रह को संदर्भित करके IMasterSlideCollection क्लास का एक इंस्टेंस बनाएं।
- IMasterSlideCollection ऑब्जेक्ट द्वारा प्रदर्शित AddClone मेथड को कॉल करें और स्रोत PPTX से क्लोन करने वाले मास्टर को पैरामीटर के रूप में पास करें।
- गंतव्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके ISlideCollection क्लास का एक इंस्टेंस बनाएं।
- ISlideCollection ऑब्जेक्ट द्वारा प्रदर्शित AddClone मेथड को कॉल करें और स्रोत प्रस्तुति से क्लोन की जाने वाली स्लाइड और मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
- संशोधित गंतव्य प्रस्तुति फ़ाइल को लिखें।

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास का एक इंस्टेंस बनाएँ
    Presentation srcPres = new Presentation(presentationFile);
    //गंतव्य प्रस्तुति (जहाँ स्लाइड क्लोन की जाएगी) के लिए Presentation क्लास का एक इंस्टेंस बनाएँ
    Presentation destPres = new Presentation(outputFile);
    //स्रोत प्रस्तुति में स्लाइड्स के संग्रह से ISlide को मास्टर स्लाइड के साथ इंस्टेंटिएट करें
    //मास्टर स्लाइड
    ISlide SourceSlide = srcPres.Slides[0];
    //स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को मास्टर संग्रह में क्लोन करें
    //गंतव्य प्रस्तुति में
    IMasterSlideCollection masters = destPres.Masters;
    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;
    //स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को मास्टर संग्रह में क्लोन करें
    //गंतव्य प्रस्तुति में
    IMasterSlide iSlide = masters.AddClone(SourceMaster);
    //स्रोत प्रस्तुति से वांछित स्लाइड को इच्छित मास्टर के साथ गंतव्य प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
    //गंतव्य प्रस्तुति में स्लाइड संग्रह के अंत में
    ISlideCollection slds = destPres.Slides;
    slds.AddClone(SourceSlide, iSlide, true);
    //स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को मास्टर संग्रह में क्लोन करें //गंतव्य प्रस्तुति
    //गंतव्य प्रस्तुति को डिस्क पर सहेजें
    destPres.Save(outputFile, SaveFormat.Pptx);
}
``` 
## **Download Running Code Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)