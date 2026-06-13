---
title: प्रस्तुति में ऑडियो एम्बेड करने का समर्थन
type: docs
weight: 90
url: /hi/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services में रिपोर्टों को एम्बेडेड ऑडियो के साथ PowerPoint प्रस्तुतियों में निर्यात करने की अंतर्निहित क्षमताएँ नहीं हैं। Aspose.Slides for Reporting Services 4.10 और बाद के संस्करण निर्यातित प्रस्तुति में ऑडियो एम्बेड करने का समर्थन करते हैं। 

{{% /alert %}} 

स्लाइड्स में ऑडियो एम्बेड करने के लिए कृपया रिपोर्ट में वह टेक्स्ट बॉक्स डालें जिसमें निम्नलिखित पाठ हो: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

यह SQL Server संस्करण 2008 और उसके बाद के संस्करणों के लिए काम करता है। यह सुविधा केवल PPTX निर्यात के लिए समर्थित है।