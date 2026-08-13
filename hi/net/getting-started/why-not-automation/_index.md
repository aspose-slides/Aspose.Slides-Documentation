---
title: "ऑटोमेशन क्यों नहीं?"
type: docs
weight: 40
url: /hi/net/why-not-automation/
keywords:
- "ऑटोमेशन"
- "Microsoft Office"
- "तुलना"
- "सुरक्षा"
- "स्थिरता"
- "विस्तारशीलता"
- "विशेषताएँ"
- "PowerPoint"
- "OpenDocument"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "खोजें कि सर्वर और सेवाओं के लिए Office ऑटोमेशन जोखिमपूर्ण क्यों है, और देखें कि Aspose.Slides PowerPoint और OpenDocument के लिए अधिक सुरक्षित, तेज़ प्रेजेंटेशन प्रोसेसिंग कैसे प्रदान करता है।"
---
## **परिचय**

Aspose घटकों के ऑटोमेशन की तुलना में बेहतर विकल्प होने के कई कारण हैं। मुख्य कारणों में से कुछ इस प्रकार हैं:

- सुरक्षा
- स्थिरता
- विस्तारशीलता/गति
- कीमत
- विशेषताएँ

नीचे प्रत्येक मुख्य बिंदु का अधिक विस्तृत स्पष्टीकरण दिया गया है।

## **महत्वपूर्ण प्रश्न**

Aspose में हमें अक्सर सुनने वाले दो प्रश्न हैं:

- क्या आपके उत्पादों को चलाने के लिए Microsoft Office स्थापित होना आवश्यक है?

छोटा, सरल उत्तर है **नहीं**।

Aspose घटक पूरी तरह से स्वतंत्र हैं और Microsoft Corporation द्वारा संबद्ध, अधिकृत, प्रायोजित, या अन्य किसी तरह से स्वीकृत नहीं हैं।

- हमें Microsoft Office Automation के बजाय Aspose उत्पादों का उपयोग क्यों करना चाहिए?

पहले, जब आप Aspose.Slides का उपयोग करते हैं तो मिलने वाले लाभ [जब आप Aspose.Slides का उपयोग करते हैं तो मिलने वाले लाभ](/slides/hi/net/product-overview/)।

दूसरा, Microsoft स्वयं सॉफ्टवेयर समाधान में Office Automation के उपयोग के खिलाफ दृढ़ता से **विरोध** करता है।

## **सुरक्षा**
निम्नलिखित Microsoft लेख से एक प्रत्यक्ष उद्धरण है:

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Aspose उत्पाद बहुत **सुरक्षित** हैं। Aspose घटक सभी ASP.NET अनुप्रयोगों के समान उपयोगकर्ता संदर्भ (ASPNET उपयोगकर्ता) में चलते हैं। इसलिए, Aspose घटक **खतरे** नहीं पैदा करते। वे महत्वपूर्ण सिस्टम संसाधनों की भी खपत नहीं करते। इसके अलावा, जब Aspose घटक कोई दस्तावेज़ खोलता है, तो मैक्रो स्वतः नहीं चलते। Aspose घटकों को डेवलपर्स को Office फ़ाइलें बनाने, संशोधित करने और सहेजने की अनुमति देने के लिए बनाया गया है।

{{% alert color="info" %}} 
Microsoft Office पैकेज से जुड़ी कोई भी जोखिम Aspose घटकों पर लागू नहीं होते। 
{{% /alert %}} 

## **स्थिरता**
यह पाठ पहले उल्लेखित Microsoft लेख से एक प्रत्यक्ष उद्धरण है:

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Aspose घटकों को एक ही DLL में पैकेज किया जाता है, इसलिए उपयोगकर्ताओं को उन्हें कार्य करने के लिए अतिरिक्त भाग या टुकड़े इंस्टॉल करने की ज़रूरत नहीं होती। Aspose घटकों को केवल .NET अनुप्रयोगों द्वारा उपयोग किया जाता है और घटक कोड का कोई हिस्सा मनुष्य को प्रतिक्रिया की प्रतीक्षा करने के लिए नहीं बनाया गया है।

{{% alert color="info" %}} 
Aspose घटकों की पूरी तरह से परीक्षण किया गया है और वे बहुत स्थिर साबित हुए हैं। Aspose घटकों का उपयोग ऐसे [companies](http://www.aspose.com/Corporate/Aspose/Customerlist.html) द्वारा किया जाता है जैसे **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, और कई अन्य प्रमुख संगठनों द्वारा विभिन्न उद्योगों में। 
{{% /alert %}} 

## **विस्तारशीलता/गति**
निम्नलिखित Microsoft लेख से एक प्रत्यक्ष उद्धरण है:

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Aspose घटक अत्यंत विस्तारशील और बिजली जैसी गति वाले हैं। Office अनुप्रयोग 100 या 1000 उपयोगकर्ताओं द्वारा एक साथ उपयोग के लिए नहीं बनाए गए थे, जबकि Aspose घटक विशेष रूप से इसके लिए डिज़ाइन किए गए हैं। हमारे घटक एक सच्चा .NET समाधान हैं।

{{% alert color="info" %}} 
Aspose घटकों का प्रदर्शन एकल सर्वर (एकल अनुप्रयोग को शक्ति प्रदान करने) या लोड‑बैलेंस्ड वेब फ़ॉर्म (एंटरप्राइज़‑व्यापी अनुप्रयोग को शक्ति प्रदान करने) पर बेजोड़ है। 
{{% /alert %}} 

## **कीमत**
जब कोई अनुप्रयोग Microsoft Office Automation का उपयोग करता है, तो प्रत्येक मशीन के लिए Microsoft Office की एक प्रति खरीदनी पड़ती है जो एप्लिकेशन चलाती है। कई बार एक अनुप्रयोग को एक Office फ़ाइल बनाना या संशोधित करना पड़ता है, लेकिन प्रक्रिया के लिए Microsoft Office की आवश्यकता नहीं होती।

{{% alert color="info" %}} 
Aspose एक बहुत ही [cost-effective](https://purchase.aspose.com/) और royalty‑free पुनर्वितरण लाइसेंस प्रदान करता है जो असीमित संख्या में उपयोगकर्ताओं को लाइसेंस की चिंता के बिना डिप्लॉय करने की अनुमति देता है। 
{{% /alert %}} 

वेब-आधारित अनुप्रयोग बनाते समय यह याद रखना महत्वपूर्ण है कि Microsoft Office Automation घटक न तो सर्वर‑साइड समाधान के लिए मूल्यांकित हैं और न ही लाइसेंस किए गए हैं। इसलिए, Microsoft Office घटकों का उपयोग करने वाले वेब अनुप्रयोगों के लिए कोई उपयुक्त लाइसेंस समाधान नहीं है। दूसरी ओर, Aspose सर्वर‑आधारित अनुप्रयोगों के लिए भी एक बहुत ही [cost-effective](https://purchase.aspose.com/) समाधान प्रदान करता है।

## **विशेषताएँ**
Aspose घटक Office फ़ाइलों को प्रबंधित करने के लिए आवश्यक सभी चीज़ें और बहुत कुछ प्रदान करते हैं। हमने उन्हें इस सिद्धांत पर डिज़ाइन किया है कि डेवलपर्स कम से कम प्रयास से सर्वोत्तम परिणाम प्राप्त कर सकें।

{{% alert color="info" %}} 
Office Automation के विपरीत, Aspose घटक कई शक्तिशाली और समय‑बचाने वाले फ़ंक्शन प्रदान करते हैं। 
{{% /alert %}} 

उदाहरण के लिए, [Aspose.Cells](https://products.aspose.com/cells/net/) डेवलपर्स को **DataTable** या **DataView** से सीधे Excel फ़ाइल में डेटा आयात करने की क्षमता देता है। [Aspose.Words](https://products.aspose.com/words/net/) समान सुविधा प्रदान करता है जो डेवलपर्स को किसी भी .NET डेटा ऑब्जेक्ट से सीधे Word (उदाहरण स्वरूप Mail Merge) दस्तावेज़ को भरने की अनुमति देती है। [Aspose परिवार का प्रत्येक घटक](https://products.aspose.com/total/net/) अपनी अनूठी और शक्तिशाली विशेषताओं का सेट प्रदान करता है।

Aspose घटक खरीदने का सबसे बड़ा लाभ हमारी विकास टीमों तक पहुंच है। उदाहरण के तौर पर, यदि आप Office Automation ऑब्जेक्ट्स का उपयोग करते हैं और कुछ विशेषताओं की आवश्यकता होती है, तो उन विशेषताओं को जोड़ाने की संभावना बहुत, बहुत कम होती है। लेकिन Aspose घटकों के साथ स्थिति अलग है।

{{% alert color="info" %}} 
हमारी विकास टीमें समझती हैं कि यदि आपकी कंपनी को कोई विशेषता चाहिए, तो अन्य कंपनियों को भी वही आवश्यकता हो सकती है। जबकि हम जानते हैं कि हम हर अनुरोधित विशेषता को लागू नहीं कर सकते, हम अपने ग्राहकों की प्रतिक्रिया के आधार पर संभवतः अधिक से अधिक विशेषताएं जोड़ने का प्रयास करते हैं। 
{{% /alert %}} 

हमारी टीमें सहायता प्रदान करते समय हमेशा खुले दिमाग और लचीली रहती हैं—इसी कारण Aspose घटक आज जितने शक्तिशाली हैं, उतने ही विकसित हुए हैं।

## **निष्कर्ष**
{{% alert color="info" %}} 
हालाँकि इस लेख में Aspose घटकों के Office Automation की तुलना में बेहतर विकल्प होने के कुछ मुख्य बिंदुओं को कवर किया गया है, आपको यह समझना चाहिए कि कई, कई और लाभ भी हैं। हमने केवल प्रमुख कुछ लाभों का उल्लेख किया है। 

इसके अतिरिक्त, सभी Aspose उत्पाद और घटक जोखिम‑रहित, बिना किसी बाध्यता के एक [Evaluation Version](https://downloads.aspose.com/slides/hi/net) प्रदान करते हैं। हम आपको मूल्यांकन का उपयोग करने के लिए प्रोत्साहित करते हैं ताकि आप देख सकें कि Aspose आपके अनुप्रयोगों या व्यापार के लिए क्या कर सकता है। 
{{% /alert %}}