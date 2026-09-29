---
title: ऑटोमेशन क्यों नहीं
type: docs
weight: 170
url: /hi/java/why-not-automation/
keywords:
- स्वचालन
- Microsoft Office
- तुलना
- सुरक्षा
- स्थिरता
- स्केलेबिलिटी
- सुविधाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "खोजें कि ऑफिस ऑटोमेशन सर्वर और सर्विसेज़ के लिए क्यों जोखिमपूर्ण है, और देखें कि Aspose.Slides कैसे PowerPoint और OpenDocument के लिए सुरक्षित, तेज़ प्रस्तुति प्रोसेसिंग प्रदान करता है।"
---
## **परिचय**

Aspose घटकों को स्वचालन की तुलना में बेहतर विकल्प बनाने के कई कारण हैं। प्रमुख कारण नीचे दिए गए हैं:

- सुरक्षा
- स्थिरता
- स्केलेबिलिटी/गति
- कीमत
- सुविधाएँ

नीचे प्रत्येक प्रमुख बिंदु का अधिक विस्तृत विवरण दिया गया है।

## **महत्वपूर्ण प्रश्न**

Aspose में हम अक्सर दो प्रश्न सुनते हैं:

- क्या आपके उत्पादों को चलाने के लिए Microsoft Office स्थापित होना आवश्यक है?

संक्षिप्त, सरल उत्तर है **नहीं**।

Aspose घटक पूरी तरह स्वतंत्र हैं और Microsoft Corporation के साथ किसी भी प्रकार का सम्बंध, प्राधिकरण, प्रायोजन या स्वीकृति नहीं रखते।

- हमें Microsoft Office Automation के बजाय Aspose उत्पादों का उपयोग क्यों करना चाहिए?

पहले, आपको कई [Aspose.Slides का उपयोग करने पर मिलने वाले लाभ](/slides/hi/java/product-overview/) मिलते हैं।

दूसरा, Microsoft स्वयं सॉफ़्टवेयर समाधान में Office Automation के **विरोध** में दृढ़ता से सलाह देता है।

## **सुरक्षा**

निम्नलिखित Microsoft लेख से प्रत्यक्ष उद्धरण है:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*


Aspose उत्पाद बहुत सुरक्षित हैं। Aspose घटक महत्वपूर्ण सिस्टम संसाधनों के लिए संभावित जोखिम नहीं बनाते। इसके अलावा, जब कोई दस्तावेज़ Aspose घटक द्वारा खोला जाता है, तो मैक्रो स्वचालित रूप से नहीं चलाए जाते। Aspose घटकों को इस लक्ष्य के साथ बनाया गया है कि डेवलपर Office फ़ाइलें बना, बदल और सहेज सकें। Microsoft Office पैकेज से जुड़ी कोई भी जोखिम Aspose घटकों में अंतर्निहित नहीं है।

## **स्थिरता**

निम्नलिखित Microsoft लेख से प्रत्यक्ष उद्धरण है:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*


Aspose घटक पूरी तरह परीक्षण किए गए हैं और अत्यंत स्थिर हैं। Aspose घटकों का उपयोग [कंपनियाँ](https://about.aspose.com/customers/) जैसे **Bank of America** और कई अन्य करती हैं।

## **स्केलेबिलिटी/गति**

निम्नलिखित Microsoft लेख से प्रत्यक्ष उद्धरण है:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.*


Aspose घटक अत्यधिक स्केलेबल और अत्यंत तेज़ हैं। Office एप्लिकेशन को सैकड़ों या हजारों उपयोगकर्ताओं द्वारा एक साथ इस्तेमाल करने के लिए नहीं बनाया गया था। हालांकि, Aspose घटकों को विशेष रूप से इसके लिए डिजाइन किया गया है। हमारे घटक चाहे एकल सर्वर पर हों, एकल एप्लिकेशन को शक्ति प्रदान कर रहे हों, या लोड‑बैलेंस्ड वेब सर्वर फ़ार्म पर एंटरप्राइज़‑वाइड एप्लिकेशन को चलाते हों, हमेशा बेदाग कार्य करते हैं।

## **कीमत**

जब कोई एप्लिकेशन Microsoft Office Automation का उपयोग करता है, तो एप्लिकेशन चलाने वाले प्रत्येक कंप्यूटर के लिए Microsoft Office की एक प्रति खरीदनी पड़ती है। कई बार एक एप्लिकेशन को Office फ़ाइल बनानी या बदलनी पड़ती है, लेकिन उपयोगकर्ता के पास Microsoft Office होना आवश्यक नहीं होता। Aspose एक बहुत ही [Cost Effective](https://purchase.aspose.com/) और रॉयल्टी‑फ्री री‑डिस्ट्रिब्यूशन लाइसेंस प्रदान करता है, जिससे अनलिमिटेड संख्या में उपयोगकर्ताओं के लिए डिप्लॉयमेंट संभव है और लाइसेंस की चिंता नहीं रहती।

वेब‑आधारित एप्लिकेशन बनाते समय यह जानना महत्वपूर्ण है कि Microsoft Office Automation घटकों की कीमत या लाइसेंस सर्वर‑साइड समाधान के लिए नहीं है; इसलिए, Microsoft Office घटकों का उपयोग करने वाले वेब एप्लिकेशनों की डिप्लॉयमेंट के लिए कोई उचित लाइसेंस समाधान उपलब्ध नहीं है। Aspose सर्वर‑आधारित एप्लिकेशनों के लिए भी एक बहुत ही Cost Effective समाधान प्रदान करता है।

## **सुविधाएँ**

Aspose घटक Office फ़ाइलों के प्रबंधन के लिए आवश्यक सभी चीज़ें और उससे अधिक प्रदान करते हैं। उन्हें इस दार्शनिकता के साथ डिज़ाइन किया गया है कि डेवलपर कम से कम प्रयास में अधिकतम परिणाम प्राप्त कर सके। Office Automation के विपरीत, Aspose घटक कई शक्तिशाली और समय‑बचाने वाली कार्यक्षमताएँ प्रदान करते हैं। उदाहरण स्वरूप, [Aspose.Cells](https://products.aspose.com/cells/java/) डेवलपर को **DataTable** या **DataView** से डेटा सीधे Excel फ़ाइल में आयात करने की सुविधा देता है। [Aspose.Words](https://products.aspose.com/words/java/) समान विशेषता प्रदान करता है जो डेवलपर को Mail Merge दस्तावेज़ (Word) को भरने की अनुमति देता है। [प्रत्येक घटक](https://products.aspose.com/total/java/) Aspose परिवार में अपनी अनोखी और शक्तिशाली सुविधाओं का सेट प्रदान करता है।

एक Aspose घटक (या [Aspose.Total](https://products.aspose.com/total/java/) जैसे घटक सूट) खरीदने का सबसे अच्छा पहलू हमारी विकास टीमों तक पहुँच होना है। हमारी विकास टीमें समझती हैं कि यदि आपकी कंपनी को कोई सुविधा चाहिए, तो अन्य कंपनियों को भी वही आवश्यकता होगी। जबकि हर फीचर अनुरोध को लागू नहीं किया जा सकता, हमारी टीम सहायता प्रदान करने में बहुत खुली और लचीली रहती है। यही सोच Aspose घटकों को आज की शक्ति प्रदान करती है। यदि आप Office Automation ऑब्जेक्ट्स से अतिरिक्त सुविधाएँ चाहते हैं, तो उन्हें जोड़वाने की संभावना बहुत, बहुत कम है।

## **निष्कर्ष**
{{% alert color="info" title="Note" %}}

जबकि इस लेख में इसलिए कई प्रमुख बिंदु बताये गये हैं कि Aspose घटक Office Automation की तुलना में बेहतर विकल्प क्यों हैं, और भी, बहुत‑से अन्य बिंदु हैं। यह लेख मुख्य रूप से सबसे प्रमुख बिंदुओं को संबोधित करता है। सभी विभिन्न Aspose घटक जोखिम‑रहीत, बिना किसी बाध्यता के [Evaluation Version](https://releases.aspose.com/slides/hi/java/) प्रदान करते हैं। हम आपको यह Evaluation उपयोग करने के लिए प्रोत्साहित करते हैं ताकि आप बेहतर रूप से देख सकें कि Aspose आपके एप्लिकेशन के लिए क्या कर सकता है।

{{% /alert %}}