---
title: ऑटोमेशन क्यों नहीं
type: docs
weight: 50
url: /hi/java/why-not-automation/
keywords:
- ऑटोमेशन
- माइक्रोसॉफ्ट ऑफिस
- तुलना
- सुरक्षा
- स्थिरता
- विस्तारशीलता
- विशेषताएँ
- पॉवरपॉइंट
- ओपनडॉक्यूमेंट
- प्रेजेंटेशन
- जावा
- Aspose.Slides
description: "जानों कि सर्वरों और सेवाओं के लिए ऑफिस ऑटोमेशन क्यों जोखिमपूर्ण है, और देखें कि Aspose.Slides कैसे पॉवरपॉइंट और ओपनडॉक्यूमेंट के लिए अधिक सुरक्षित, तेज़ प्रेजेंटेशन प्रोसेसिंग प्रदान करता है।"
---
## **परिचय**

Aspose घटकों को ऑटोमेशन की तुलना में बेहतर विकल्प बनाते हुए कई कारण हैं। प्रमुख कारणों में शामिल हैं:

- सुरक्षा
- स्थिरता
- विस्तारशीलता/गति
- कीमत
- सुविधाएँ

नीचे प्रत्येक प्रमुख बिंदु की अधिक विस्तृत व्याख्या दी गई है।

## **महत्वपूर्ण प्रश्न**

Aspose में हम अक्सर दो प्रश्न सुनते हैं:

- क्या आपके उत्पादों को चलाने के लिए Microsoft Office स्थापित होना आवश्यक है?

संक्षिप्त, सरल उत्तर **नहीं** है।

- हमें Microsoft Office Automation के बजाय Aspose उत्पाद क्यों इस्तेमाल करने चाहिए?

पहले, आपके पास कई [Aspose.Slides का उपयोग करने पर मिलने वाले लाभ](/slides/hi/java/product-overview/) हैं।

दूसरा, Microsoft स्वयं सॉफ़्टवेयर समाधान में Office Automation के उपयोग के विरुद्ध **सख़्त सलाह** देता है।

## **सुरक्षा**

निम्नलिखित Microsoft लेख से एक प्रत्यक्ष उद्धरण है:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."* 


Aspose उत्पाद बहुत सुरक्षित हैं। Aspose घटक महत्वपूर्ण सिस्टम संसाधनों के लिए संभावित जोखिम नहीं पैदा करते। इसके अलावा, जब किसी दस्तावेज़ को Aspose घटक द्वारा खोलते हैं, तो मैक्रो स्वचालित रूप से नहीं चलाए जाते। Aspose घटकों को इस लक्ष्य से बनाय़ा गया है कि डेवलपर Office फ़ाइलें बनाएं, संशोधित करें और सहेजें। Microsoft Office पैकेज से जुड़े किसी भी जोखिम का अस्तित्व Aspose घटकों में नहीं है। 

## **स्थिरता**
निम्नलिखित Microsoft लेख से एक प्रत्यक्ष उद्धरण है:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."* 


Aspose घटकों का व्यापक परीक्षण किया गया है और वे अत्यंत स्थिर हैं। Aspose घटकों का उपयोग [Companies](https://about.aspose.com/customers) जैसे: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** और कई, कई अन्य कंपनियों द्वारा किया जाता है। 

## **विस्तारशीलता/गति**
निम्नलिखित Microsoft लेख से एक प्रत्यक्ष उद्धरण है:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.* 


Aspose घटक अत्यधिक विस्तारशील और बिजली की गति के समान तेज़ हैं। Office अनुप्रयोग 100 या 1000 उपयोगकर्ताओं द्वारा एक साथ उपयोग करने के लिए डिज़ाइन नहीं किए गए थे। हालांकि, Aspose घटक विशेष रूप से इसके लिए बनाए गए हैं। हमारे घटक एकल सर्वर पर, एकल अनुप्रयोग को सक्षम करते हुए या लोड बैलेन्स्ड वेब फॉर्म पर एंटरप्राइज़‑व्यापी अनुप्रयोग को चलाते हुए बिना किसी बाधा के प्रदर्शन करते हैं। 

## **कीमत**
जब कोई अनुप्रयोग Microsoft Office Automation का उपयोग करता है, तो उस अनुप्रयोग को चलाने वाले प्रत्येक मशीन के लिए Microsoft Office की एक प्रति खरीदनी होती है। कई बार ऐसा अनुप्रयोग होता है जिसे Office फ़ाइल बनानी या संशोधित करनी होती है लेकिन उपयोगकर्ता के पास Microsoft Office की आवश्यकता नहीं होती। Aspose एक बहुत ही [लागत प्रभावी](https://purchase.aspose.com/) तथा रॉयल्टी‑मुक्त पुनर्वितरण लाइसेंस प्रदान करता है जो अनलिमिटेड संख्या में उपयोगकर्ताओं को बिना लाइसेंस की चिंता के डिप्लॉए करने की अनुमति देता है। 


वेब‑आधारित अनुप्रयोग बनाते समय यह जानना महत्वपूर्ण है कि Microsoft Office Automation घटकों को सर्वर‑साइड समाधान के लिए मूल्य नहीं रखा गया है और न ही लाइसेंस किया गया है; इसलिए, Microsoft Office घटकों को उपयोग करने वाले वेब अनुप्रयोग को डिप्लॉए करने के लिए कोई अच्छा लाइसेंस समाधान नहीं है। Aspose सर्वर‑आधारित अनुप्रयोगों के लिए भी एक बहुत ही लागत प्रभावी समाधान प्रदान करता है। 

## **विशेषताएँ**
Aspose घटक Office फ़ाइलों को प्रबंधित करने के लिये आवश्यक सब कुछ plus बहुत कुछ प्रदान करते हैं। उन्हें इस विचारधारा के साथ डिज़ाइन किया गया है कि डेवलपर कम से कम काम से अधिकतम परिणाम प्राप्त कर सकें। Office Automation के विपरीत, Aspose घटक कई शक्तिशाली और समय बचाने वाले फ़ंक्शन प्रदान करते हैं। उदाहरण के लिए, [Aspose.Cells](https://products.aspose.com/cells/java/) डेवलपर्स को **DataTable** या **DataView** से डेटा सीधे Excel फ़ाइल में आयात करने की क्षमता देता है। [Aspose.Words](https://products.aspose.com/words/java/) समान सुविधा प्रदान करता है जिससे डेवलपर Word (Mail Merge) दस्तावेज़ को भर सकते हैं। [Every Component](https://products.aspose.com/total/java/) Aspose परिवार में अपने स्वयं के अनोखे और शक्तिशाली फीचर्स का सेट पेश करता है। 


एक Aspose घटक (या [Aspose.Total](https://products.aspose.com/total/java/) जैसे घटक सूट) खरीदने का सबसे अच्छा पहलू हमारी विकास टीमों तक पहुंच है। हमारी विकास टीमें यह समझती हैं कि यदि आपके कंपनी को कोई फीचर चाहिए, तो संभवतः अन्य कंपनियों को भी वही चाहिए। जबकि हर फीचर अनुरोध को जोड़ा नहीं जा सकता, हमारी टीमें सहायता प्रदान करते समय बहुत खुली और लचीली रहने की कोशिश करती हैं। यही सोच ने Aspose घटकों को इतना शक्तिशाली बनाने में मदद की है। यदि Office Automation ऑब्जेक्ट्स से अतिरिक्त फीचर चाहिए, तो उन्हें जोड़ने की संभावना बहुत, बहुत कम है। 

## **निष्कर्ष**
{{% alert color="info" %}} 

यह लेख कई प्रमुख बिंदुओं को कवर करता है कि क्यों Aspose घटक Office Automation की तुलना में बेहतर विकल्प हैं, और भी कई कारण हैं। यह लेख मुख्यतः सबसे प्रमुख बिंदुओं को ही संबोधित करता है। सभी विभिन्न Aspose घटक जोखिम‑मुक्त, बिना प्रतिबद्धता के [Evaluation Version](https://downloads.aspose.com/slides/hi/java) प्रदान करते हैं। हम आपको इस Evaluation का लाभ उठाने के लिए प्रेरित करते हैं ताकि आप देख सकें कि Aspose आपके अनुप्रयोगों के लिए क्या कर सकता है। 

{{% /alert %}}