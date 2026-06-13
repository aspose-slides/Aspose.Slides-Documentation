---
title: Aspose.Slides for SharePoint लाइसेंस स्थापित करना
type: docs
weight: 10
url: /hi/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

एक बार जब आप अपने मूल्यांकन से संतुष्ट हों, तो आप एक लाइसेंस[खरीद सकते हैं](https://purchase.aspose.com/buy). खरीदने से पहले, सुनिश्चित करें कि आप लाइसेंस सब्सक्रिप्शन शर्तों को समझते हैं और उनसे सहमत हैं। ऑर्डर भुगतान होने के बाद लाइसेंस आपको ईमेल किया जाएगा।

लाइसेंस एक ZIP आर्काइव है जिसमें एक सामान्य SharePoint समाधान पैकेज शामिल है। आर्काइव में शामिल है:

- Aspose.Slides.SharePoint.License.wsp – SharePoint समाधान पैकेज फ़ाइल। लाइसेंस को एक SharePoint समाधान के रूप में पैकेज किया गया है ताकि सर्वर फार्म में तैनाती और पुनः प्राप्ति आसान हो सके।
- readme.txt – लाइसेंस स्थापना निर्देश।

{{% /alert %}} 
## **लाइसेंस तैनाती**
लाइसेंस की स्थापना **stsadm.exe** के माध्यम से सर्वर कंसोल से की जाती है।

{{% alert color="primary" %}} 

स्पष्टता के लिए नीचे के हिस्से में पाथ को छोड़ दिया गया है।

{{% /alert %}} 

Aspose.Slides for SharePoint लाइसेंस को तैनात करने के लिए निम्नलिखित चरणों को करें:

1. stsadm चलाएँ ताकि समाधान को SharePoint समाधान स्टोर में जोड़ा जा सके: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. समाधान को फार्म के सभी सर्वरों पर तैनात करें: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. तैनाती को तुरंत पूरा करने के लिए प्रशासनिक टाइमर जॉब्स निष्पादित करें: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

यदि Windows SharePoint Services Administration सेवा चल नहीं रही है तो तैनाती चरण चलाते समय आपको चेतावनी मिलेगी। **stsadm.exe** इस सेवा और Windows SharePoint Timer Service पर निर्भर करता है ताकि समाधान डेटा को फार्म में प्रतिलिपि किया सके। यदि ये सेवाएँ आपके सर्वर फार्म में नहीं चल रही हैं, तो आपको प्रत्येक सर्वर पर लाइसेंस तैनात करना पड़ सकता है। 

{{% /alert %}} 
## **लाइसेंस का परीक्षण**
यह जांचने के लिए कि लाइसेंस सही ढंग से स्थापित हुआ है या नहीं, किसी भी दस्तावेज़ को नए प्रारूप में बदलें। यदि दस्तावेज़ में कोई मूल्यांकन वॉटरमार्क नहीं है, तो लाइसेंस सफलतापूर्वक सक्रिय हो गया है।