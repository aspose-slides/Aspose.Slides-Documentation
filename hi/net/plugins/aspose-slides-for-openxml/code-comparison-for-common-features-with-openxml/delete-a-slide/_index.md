---
title: स्लाइड हटाएँ
type: docs
weight: 80
url: /hi/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// प्रस्तुति ऑब्जेक्ट प्राप्त करें और इसे अगले DeleteSlide मेथड को पास करें।

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // स्रोत दस्तावेज़ को पढ़ने/लिखने के मोड में खोलें।

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // स्रोत दस्तावेज़ और हटाए जाने वाली स्लाइड का इंडेक्स अगले DeleteSlide मेथड को पास करें।

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// प्रस्तुति से निर्दिष्ट स्लाइड को हटाएँ।

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // प्रस्तुति में स्लाइडों की संख्या प्राप्त करने के लिए CountSlides उदाहरण का उपयोग करें।

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // प्रस्तुति दस्तावेज़ से प्रस्तुति भाग प्राप्त करें. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // प्रस्तुति भाग से प्रस्तुति प्राप्त करें।

    Presentation presentation = presentationPart.Presentation;

    // प्रस्तुति में स्लाइड ID की सूची प्राप्त करें।

    SlideIdList slideIdList = presentation.SlideIdList;

    // निर्दिष्ट स्लाइड का स्लाइड ID प्राप्त करें

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // स्लाइड का रिलेशनशिप ID प्राप्त करें।

    string slideRelId = slideId.RelationshipId;

    // स्लाइड को स्लाइड सूची से हटाएँ।

    slideIdList.RemoveChild(slideId);

    //

    // सभी कस्टम शो से स्लाइड के रेफरेंसेज़ हटाएँ।

    if (presentation.CustomShowList != null)

    {

        // कस्टम शो की सूची पर इटरेंट करें।

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // स्लाइड सूची प्रविष्टियों की लिंक्ड लिस्ट घोषित करें।

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // कस्टम शो से हटाने के लिए स्लाइड रेफ़रेंस खोजें।

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // कस्टम शो से स्लाइड के सभी रेफ़रेंसेज़ हटाएँ।

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // संशोधित प्रस्तुति को सहेजें।

    presentation.Save();

    // निर्दिष्ट स्लाइड के लिए स्लाइड पार्ट प्राप्त करें।

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // स्लाइड पार्ट हटाएँ।

    presentationPart.DeletePart(slidePart);

}

// प्रस्तुति ऑब्जेक्ट प्राप्त करें और इसे अगले CountSlides मेथड को पास करें।

public static int CountSlides(string presentationFile)

{

    // प्रस्तुति को केवल-पढ़ने मोड में खोलें।

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // प्रस्तुति को अगले CountSlide मेथड को पास करें

        // और स्लाइड गणना लौटाएँ।

        return CountSlides(presentationDocument);

    }

}

// प्रस्तुति में स्लाइडों की गिनती करें।

public static int CountSlides(PresentationDocument presentationDocument)

{

    // शून्य (null) दस्तावेज़ ऑब्जेक्ट की जाँच करें।

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // दस्तावेज़ का प्रस्तुति भाग प्राप्त करें।

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts से स्लाइड गणना प्राप्त करें।

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // स्लाइड गणना को पिछले मेथड को लौटाएँ।

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //एक PresentationEx ऑब्जेक्ट बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
    using (Presentation pres = new Presentation(presentationFile))
    {

        //स्लाइड कलेक्शन में उसके इंडेक्स का उपयोग करके स्लाइड तक पहुँच रहा है
        ISlide slide = pres.Slides[slideIndex];


        //स्लाइड को उसके रेफ़रेंस से हटाया जा रहा है
        pres.Slides.Remove(slide);


        //प्रस्तुति को PPTX फ़ाइल के रूप में लिख रहा है
        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)