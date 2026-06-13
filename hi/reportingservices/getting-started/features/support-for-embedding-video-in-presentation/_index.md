---
title: प्रेज़ेंटेशन में वीडियो एम्बेड करने के लिए समर्थन
type: docs
weight: 80
url: /hi/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services में एंबेडेड वीडियो के साथ रिपोर्ट को PowerPoint प्रस्तुतियों में निर्यात करने की अंतर्निहित क्षमता नहीं है। Aspose.Slides for Reporting Services 4.10 और उसके बाद के संस्करण प्रस्तुति के भीतर वीडियो एम्बेड करने का समर्थन करते हैं। 

{{% /alert %}} 

स्लाइड्स में वीडियो एम्बेड करने के लिए कृपया रिपोर्ट में निम्नलिखित पाठ वाले एक टेक्स्ट बॉक्स को जोड़ें: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

यह SQL Server संस्करण 2008 और उससे ऊपर के लिए काम करता है। यह सुविधा केवल PPTX निर्यात के लिए समर्थित है।