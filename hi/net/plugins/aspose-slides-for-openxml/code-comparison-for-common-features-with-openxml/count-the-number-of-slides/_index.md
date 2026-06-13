---
title: स्लाइड्स की संख्या गिनें
type: docs
weight: 50
url: /hi/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// प्रस्तुति ऑब्जेक्ट प्राप्त करें और इसे अगले CountSlides विधि को पास करें।

public static int CountSlides(string presentationFile)

{

    // प्रस्तुति को केवल पढ़ने के लिए खोलें।

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // प्रस्तुति को अगले CountSlide विधि को पास करें

        // और स्लाइड गिनती लौटाएं।

        return CountSlides(presentationDocument);

    }

}

// प्रस्तुति में स्लाइडों की गणना करें।

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

    // SlideParts से स्लाइड गिनती प्राप्त करें।

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // स्लाइड गिनती को पिछले विधि को लौटाएं।

    return slidesCount;

} 

```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //एक PresentationEx ऑब्जेक्ट को इंस्टैंटिएट करें जो PPTX फ़ाइल का प्रतिनिधित्व करता है

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

```
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)