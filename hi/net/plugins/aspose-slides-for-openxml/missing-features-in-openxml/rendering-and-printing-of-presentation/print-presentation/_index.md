---
title: प्रेजेंटेशन प्रिंट करें
type: docs
url: /hi/net/print-the-presentation/
---
Aspose.Slides for .NET प्रस्तुतियों को प्रिंट करने के लिए चार ओवरलोड मेथड्स प्रदान करता है। ये मेथड्स लचीले होते हैं ताकि प्रस्तुति को डिफ़ॉल्ट प्रिंटर या उपलब्ध किसी भी प्रिंटर पर कस्टम सेटिंग्स के साथ प्रिंट किया जा सके। आपको केवल आवश्यकता के अनुसार उचित प्रिंट मेथड चुनना है।

## **डिफ़ॉल्ट प्रिंटर पर प्रिंट करें**
Aspose.Slides for .NET में प्रस्तुति को डिफ़ॉल्ट प्रिंटर पर प्रिंट करना काफी सरल है। डिफ़ॉल्ट प्रिंटर पर प्रस्तुति को प्रिंट करने के लिए निम्नलिखित चरणों को लागू करें:

- प्रिंट करने हेतु प्रस्तुति को लोड करने के लिए Presentation क्लास की एक इंस्टेंस बनाएं
- Presentation ऑब्जेक्ट द्वारा प्रदान किए गए Print मेथड को बिना किसी पैरामीटर के कॉल करें

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //प्रस्तुति लोड करें

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //डिफ़ॉल्ट प्रिंटर पर पूरी प्रस्तुति प्रिंट करने के लिए प्रिंट मेथड को कॉल करें

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //प्रस्तुति लोड करें

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //इच्छित प्रिंटर पर पूरी प्रस्तुति प्रिंट करने के लिए प्रिंट मेथड को कॉल करें

    asposePresentation.Print("LaserJet1100");


``` 

## **विशिष्ट प्रिंटर पर प्रिंट करें**
विशिष्ट प्रिंटर पर प्रस्तुति को प्रिंट करने के लिए प्रिंटर का नाम Print मेथड के पैरामीटर के रूप में आवश्यक है। वांछित प्रिंटर पर प्रस्तुति को प्रिंट करने के लिए निम्नलिखित चरणों को लागू करें:

- प्रिंट करने हेतु प्रस्तुति को लोड करने के लिए Presentation क्लास की एक इंस्टेंस बनाएं
- Presentation क्लास के Print मेथड को प्रिंटर नाम स्ट्रिंग पैरामीटर के रूप में देकर कॉल करें

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //प्रस्तुति लोड करें

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //इच्छित प्रिंटर पर पूरी प्रस्तुति प्रिंट करने के लिए प्रिंट मेथड को कॉल करें

    asposePresentation.Print("LaserJet1100");

}

``` 

## **सैंपल कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)