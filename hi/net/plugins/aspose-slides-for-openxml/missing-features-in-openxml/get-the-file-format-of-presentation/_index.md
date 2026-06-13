---
title: प्रस्तुति का फ़ाइल फ़ॉर्मेट प्राप्त करें
type: docs
weight: 50
url: /hi/net/get-the-file-format-of-presentation/
---
फ़ाइल फ़ॉर्मेट प्राप्त करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- **IPresentationInfo** क्लास का एक उदाहरण बनाएं
- प्रेज़ेंटेशन के बारे में जानकारी प्राप्त करें

नीचे दिए गए उदाहरण में, हमें फ़ाइल फ़ॉर्मेट मिल गया है।
## **उदाहरण**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **सैंपल कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **रनिंग उदाहरण डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)