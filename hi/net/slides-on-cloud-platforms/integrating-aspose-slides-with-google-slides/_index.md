---
title: Aspose.Slides को Google Slides के साथ एकीकृत करना
linktitle: Google स्लाइड्स
type: docs
weight: 50
url: /hi/net/integrating-aspose-slides-with-google-slides/
keywords:
- क्लाउड प्लेटफ़ॉर्म
- क्लाउड एकीकरण
- Google स्लाइड्स
- Google ड्राइव
- Google API
- Google सर्विस अकाउंट
- SaaS एकीकरण
- OAuth 2.0
- PPT से PDF
- PowerPoint ऑटोमेशन
- प्रस्तुति प्रोसेसिंग
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides को Google Slides के साथ जोड़ें ताकि प्रस्तुतियों को आयात, सिंक और रूपांतरित किया जा सके, कार्यप्रवाहों को स्वचालित किया जा सके, और PowerPoint तथा OpenDocument को एक ही पाइपलाइन में रखा जा सके।"
---
## **परिचय**

Aspose.Slides अब अपने [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) के माध्यम से Google Slides और Google Drive के साथ एकीकरण प्रदान करता है। यह एकीकरण .NET एप्लिकेशन को Google Slides प्रस्तुतियों को परिवर्तित, संपादित, डाउनलोड और अपलोड करने में सक्षम बनाता है।

## **Google Slides क्या है?**
[Google Slides](https://workspace.google.com/products/slides/hi/) एक मुफ्त, वेब‑आधारित प्रेजेंटेशन सॉफ्टवेयर है जिसे Google ने विकसित किया है। यह उपयोगकर्ताओं को Microsoft PowerPoint की तरह ऑनलाइन स्लाइड प्रस्तुतियों को बनाना, संपादित करना और साझा करना देता है। यह रीयल‑टाइम सहयोग, क्लाउड स्टोरेज का समर्थन करता है और इंटरनेट एक्सेस वाले किसी भी डिवाइस पर काम करता है।

## **Google API**
Aspose.Slides के माध्यम से अपने Google Slides प्रस्तुतियों के साथ काम शुरू करने से पहले आपको एक Google API प्रोजेक्ट बनाना होगा और एक [Google Cloud project](https://developers.google.com/workspace/guides/create-project) बनाकर वांछित API को सक्षम करना होगा।

इसके बाद आपको यह चुनना होगा कि आप Google API तक कैसे पहुँचेंगे—[Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) दो तरीके समर्थन करता है:
- `Google Service Account`
- `OAuth 2.0` ब्राउज़र के माध्यम से उपयोगकर्ता इंटरैक्शन के साथ।

### **Google Service Account**
एक सर्विस अकाउंट एक विशेष Google खाता है जिसे एप्लिकेशन या सर्वर प्रोग्रामेटिक रूप से उपयोगकर्ता इंटरैक्शन के बिना Google API तक पहुँचने के लिए उपयोग करते हैं। यह आमतौर पर बैकएंड सिस्टम या स्वचालित कार्यों में प्रयोग होता है। सर्विस अकाउंट को एक JSON की फ़ाइल द्वारा प्रमाणित किया जाता है और उनका अपना ई‑मेल पता होता है। उन्हें [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) के माध्यम से विशिष्ट अनुमतियाँ दी जा सकती हैं और अक्सर Google Drive, Sheets या BigQuery जैसी API के साथ सुरक्षित, स्वचालित पहुँच के लिए उपयोग किया जाता है।

### **OAuth 2.0**
Google API तक पहुँचने का एक और सामान्य तरीका है OAuth 2.0, जिसमें ब्राउज़र के माध्यम से उपयोगकर्ता इंटरैक्शन शामिल है। इस प्रवाह में उपयोगकर्ता को Google साइन‑इन पेज पर पुनः निर्देशित किया जाता है जहाँ वह एप्लिकेशन को अनुमति देता है। अनुमोदन के बाद, एप्लिकेशन को एक Authorization Code प्राप्त होता है, जिसे वह एक्सेस टोकन और रिफ्रेश टोकन के लिए बदलता है।

एक्सेस टोकन अस्थायी रूप से Google API तक पहुँच प्रदान करता है, जबकि रिफ्रेश टोकन को संग्रहीत किया जा सकता है और नया एक्सेस टोकन प्राप्त करने के लिए पुनः उपयोग किया जा सकता है, बिना फिर से उपयोगकर्ता को लॉग‑इन करवाए। इसका अर्थ है कि ब्राउज़र इंटरैक्शन केवल एक बार आवश्यक है, जिससे बाद के API कॉल पूरी तरह स्वचालित हो जाते हैं। यह विधि आमतौर पर उन एप्लिकेशन के लिए उपयोग की जाती है जिन्हें उपयोगकर्ता के डेटा (जैसे Gmail, Calendar या Drive) तक उसकी सहमति के साथ पहुँच की आवश्यकता होती है।

## **चलो कोड लिखें**
पहले, अपने प्रोजेक्ट में [Aspose.Slides SaaS Integration NuGet package](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) जोड़ें:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **उदाहरण 1**
निम्नलिखित उदाहरण में हम Google Drive से एक Google Slides प्रस्तुति डाउनलोड करेंगे और उसे स्थानीय डिस्क पर PDF फ़ाइल के रूप में सहेजेंगे। हम प्रमाणन के लिए एक Google Service Account का उपयोग करेंगे, यह मानते हुए कि सर्विस अकाउंट की JSON फ़ाइल पहले ही डाउनलोड की जा चुकी है।

```csharp
// बाहर से प्रबंधित HttpClient बनाएँ
HttpClient httpClient = new HttpClient();

// एक सर्विस अकाउंट JSON फ़ाइल का उपयोग करके प्रमाणीकरण प्रदाता बनाएँ
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// प्रमाणीकरण प्रदाता के साथ Google Slides एकीकरण सेवा को प्रारंभ करें
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Google Drive से फ़ाइल ID द्वारा एक प्रस्तुति लोड करके उसे Aspose.Slides IPresentation इंस्टेंस में रखें
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// यदि आवश्यक हो प्रस्तुति को संशोधित करें (उदाहरण के लिए, दूसरी स्लाइड हटाएँ)
pres.Slides.RemoveAt(1);

// प्रस्तुति को स्थानीय रूप से PDF फ़ाइल के रूप में सहेजें
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

सुविधा के लिए, Aspose.Slides SaaS Integration उपयोगकर्ता के लिये उपलब्ध सभी फ़ाइलों की सूची देने के लिये एक मेथड प्रदान करता है। लौटाया गया डेटा फ़ाइल नाम, MIME प्रकार, और फ़ाइल ID शामिल करता है।

```csharp
// प्रदान किए गए सर्विस अकाउंट के लिए उपलब्ध फ़ाइलों की सूची प्राप्त करें
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

फ़ाइल ID प्राप्त करने का दूसरा तरीका है Google Slides वेब एप्लीकेशन में प्रस्तुति खोलना और URL में उसका स्थान देखना।

उदाहरण के लिये, निम्नलिखित URL में:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

फ़ाइल ID है:

```
1A2B3C4D5E6F7G8H9I0J
```

## **उदाहरण 2**
अगले उदाहरण में हम शून्य से एक PowerPoint प्रस्तुति बनाएँगे और उसे Google Drive में Google Slides प्रारूप में अपलोड करेंगे। प्रमाणन के लिये हम OAuth 2.0 का प्रयोग करेंगे।

```csharp
// बाहर से प्रबंधित HttpClient बनाएँ
HttpClient httpClient = new HttpClient();

// OAuth के साथ क्लाइंट ID और क्लाइंट सीक्रेट का उपयोग करके एक प्रमाणीकरण प्रदाता बनाएँ
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// प्रमाणीकरण प्रदाता के साथ Google Slides एकीकरण सेवा को आरंभ करें
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// एक नमूना प्रस्तुति बनाएँ
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // प्रस्तुति को Google Drive रूट फ़ोल्डर में Google Slides प्रारूप में सहेजें
    // आप Aspose.Slides द्वारा समर्थित कोई भी अन्य निर्यात फ़ॉर्मेट चुन सकते हैं
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

यदि आप अपने एप में इस प्रकार का प्रमाणन उपयोग करते हैं, तो `interaction with the browser is required`। आपको अपना खाता चुनना होगा और यह पुष्टि करनी होगी कि आप एप को अपने Google Drive API तक पहुँच की अनुमति देते हैं। यही है—यह ऑपरेशन केवल पहले रन पर आवश्यक होता है।

### **उदाहरण 3**
निम्नलिखित उदाहरण में हम पहले से प्राप्त एक्सेस टोकन का उपयोग करेंगे। `GoogleAccessTokenAuthProvider` `IGoogleAuthorizationProvider` इंटरफ़ेस का एक कार्यान्वयन है जो मौजूदा OAuth 2.0 एक्सेस टोकन का उपयोग करके Google API अनुरोधों को प्रमाणित करता है। उन प्रदाताओं के विपरीत जो OAuth प्रवाह को प्रारंभ या प्रबंधित करते हैं, यह क्लास कॉलर से वैध एक्सेस टोकन प्राप्त होने पर निर्भर करती है।

यह प्रदाता उन सिस्टम्स में उपयोगी है जहाँ एक्सेस टोकन बाहरी रूप से प्राप्त किया जाता है—आमतौर पर फ़्रंटएंड एप्लिकेशन या किसी अन्य सेवा द्वारा—और बैकएंड को दिया जाता है। यह विशेष रूप से वितरित वातावरण में उपयुक्त है जहाँ सर्वर‑साइड रिफ्रेश टोकन प्रबंधन जटिलता या समानांतर रिफ्रेश प्रयासों के कारण टोकन अमान्य होने के जोखिम को बढ़ा सकता है।

यह उदाहरण दर्शाता है कि कैसे फ़ाइल को बदलें और उसका नाम Google Drive पर अपडेट करें जबकि उसका फ़ाइल ID बना रहे।

```csharp
// अनुरोध करने के लिए HTTP क्लाइंट बनाएं
using HttpClient httpClient = new HttpClient();

// एक्सेस टोकन का उपयोग करके Google Drive प्रमाणीकरण सेट अप करें
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// प्रमाणीकरण और HTTP क्लाइंट का उपयोग करके Google Slides/Drive एकीकरण को प्रारंभ करें
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Create a sample presentation using Aspose.Slides
using (var presentation = new Presentation())
{
    // पहले स्लाइड में एक आयताकार रूप जोड़ें और उसका टेक्स्ट सेट करें
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // विशिष्ट गुणवत्ता और अनुपालन सेटिंग्स के साथ PDF सहेजने के विकल्प परिभाषित करें
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // फ़ाइल ID द्वारा Google Drive पर मौजूदा फ़ाइल को सहेजें (बदलें), उसका नाम अपडेट करें, और PDF के रूप में निर्यात करें
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // Google Drive पर मौजूदा फ़ाइल का ID
        GoogleSaveFormatType.Pdf,         // सहेजने के लिए वांछित फ़ॉर्मेट
        saveOptions,           
        "NewFileName.pdf"                 // फ़ाइल को देने के लिए नया नाम
    );
}
```

## **सारांश**
Aspose.Slides अब प्रबंधन के लिए एक अतिरिक्त फ़ाइल प्रारूप का समर्थन करता है, जिससे क्लाउड‑आधारित कार्य‑प्रवाहों को स्वचालित करना, प्रस्तुतियों को बनाना, साझा करना और संपादित करना आसान हो गया है।

इस लेख में मूलभूत सुविधाओं को कवर किया गया है। आप फ़ाइलों को सबफ़ोल्डर में सहेज सकते हैं, मौजूदा फ़ाइलों को बदल सकते हैं, और विभिन्न प्रारूपों में (केवल Google Slides प्रस्तुतियों तक सीमित नहीं) Google Drive पर निर्यात कर सकते हैं।

Aspose.Slides SaaS Integration भविष्य में प्रस्तुति SaaS प्लेटफ़ॉर्म के समर्थन को विस्तारित करेगा, इसलिए भविष्य के अपडेट के लिये वापस देखें।

## **FAQ**

**क्या इस एकीकरण का उपयोग करने के लिये मुझे Google Workspace खाता चाहिए?**  
नहीं। आप एक मुफ्त Google खाता या एक Google Workspace खाता दोनों का उपयोग कर सकते हैं। आवश्यक पहुँच आपके Google Drive और Slides अनुमतियों पर निर्भर करती है।

**कौन से प्रमाणन विधि चुनूँ—Service Account या OAuth 2.0?**  
बिना उपयोगकर्ता इंटरैक्शन वाले बैकएंड या स्वचालित कार्य‑प्रवाहों के लिये **Service Account** का उपयोग करें।  
यदि आपको किसी विशिष्ट उपयोगकर्ता के Google Slides या Drive फ़ाइलों तक उसकी सहमति के साथ पहुँचनी है तो **OAuth 2.0** चुनें।

**क्या मैं Google Slides के अलावा अन्य प्रारूपों के साथ काम कर सकता हूँ?**  
हाँ। Aspose.Slides प्रस्तुतीकरण को विभिन्न प्रारूपों (जैसे PDF, PPTX, HTML) में सहेजने की अनुमति देता है, जिन्हें बाद में Google Drive पर अपलोड किया जा सकता है।

**मैं Google Slides प्रस्तुति की फ़ाइल ID कैसे प्राप्त करूँ?**  
आप `GetDriveFileInfosAsync()` मेथड का उपयोग करके या Google Slides में प्रस्तुति के URL से कॉपी करके फ़ाइल ID प्राप्त कर सकते हैं।

**क्या एकीकरण Google Drive पर मौजूदा फ़ाइल को बदलने का समर्थन करता है?**  
हाँ। `SavePresentationToExistingFileAsync` मेथड का उपयोग करके आप फ़ाइल को अपडेट कर सकते हैं जबकि उसका फ़ाइल ID बना रहता है।

**क्या OAuth 2.0 उपयोग करते समय हर बार ब्राउज़र इंटरैक्शन आवश्यक है?**  
नहीं। ब्राउज़र इंटरैक्शन केवल पहली अनधिकृति के दौरान आवश्यक है। उसके बाद संग्रहीत रिफ्रेश टोकन स्वचालित पहुँच की अनुमति देते हैं।