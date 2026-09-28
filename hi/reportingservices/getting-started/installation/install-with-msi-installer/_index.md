---
title: MSI इंस्टॉलर के साथ स्थापित करें
type: docs
weight: 20
url: /hi/reportingservices/install-with-msi-installer/
keywords:
- MSI इंस्टॉलर
- स्थापना
- SQL Server रिपोर्टिंग सर्विसेज
- Power BI रिपोर्ट सर्वर
- Aspose.Slides for Reporting Services
description: "Aspose.Slides for Reporting Services को उसके MSI इंस्टॉलर के साथ स्थापित करें: इंस्टॉलर को क्या चाहिए, प्रत्येक रिपोर्ट सर्वर इंस्टेंस में यह क्या बदलता है, और परिणाम कैसे जाँचें।"
---
## **स्थापना**

MSI इंस्टॉलर Aspose.Slides for Reporting Services को स्थापित करने का सबसे सरल तरीका है। इसे .NET Framework 3.5 और रिपोर्ट सर्वर पर व्यवस्थापक अधिकारों की आवश्यकता होती है; देखें [System Requirements](/slides/hi/reportingservices/system-requirements/).

1. MSI इंस्टॉलर, *Aspose.Slides for Reporting Services XX.XX*, को [download page](https://releases.aspose.com/slides/reportingservices/) से डाउनलोड करें और उसे रिपोर्ट सर्वर पर कॉपी करें।
2. इसे व्यवस्थापक के रूप में चलाएँ। यदि .NET Framework 3.5 अनुपलब्ध है, तो इंस्टॉलर एक संदेश के साथ रुक जाता है; .NET Framework 3.5 फ़ीचर इंस्टॉल करें और फिर से चलाएँ।
3. लाइसेंस समझौते को स्वीकार करें।
4. **Custom Setup** पृष्ठ पर, फीचर ट्री मशीन पर इंस्टॉलर द्वारा पता लगाए गए प्रत्येक SQL Server Reporting Services और Power BI Report Server इंस्टेंस को सूचीबद्ध करता है। किसी इंस्टेंस को अपरिवर्तित रखने के लिए, उसके आइकन पर क्लिक करें और **Entire feature will be unavailable** चुनें। Express संस्करण रेंडरिंग एक्सटेंशन को समर्थन नहीं देते, इसलिए Express इंस्टेंस का चयन न करें। इंस्टॉलर SQL Server 2016 और उससे पुराने Express इंस्टेंस को छुपाता है।
5. **Next** चुनें, फिर **Install**।

वैकल्पिक **Rpl Export** फीचर डिफ़ॉल्ट रूप से चयनित नहीं होता है। यह एक छुपा एक्सटेंशन जोड़ता है जो रिपोर्ट को RPL फ़ॉर्मेट में सहेजता है, जो Aspose को समस्या रिपोर्ट भेजते समय उपयोगी होता है; देखें [Exporting Reports to RPL Format](/slides/hi/reportingservices/exporting-reports-to-rpl-format/).

## **इंस्टॉलर क्या बदलता है**

इंस्टॉलर अपनी फ़ाइलें *Aspose\Aspose.Slides for Reporting Services* फ़ोल्डर में रखता है — 64‑बिट Windows पर *Program Files (x86)*, क्योंकि इंस्टॉलर 32‑बिट पैकेज है। फिर, प्रत्येक चयनित इंस्टेंस के लिए, यह:
- *Aspose.Slides.ReportingServices.dll* को इंस्टेंस के *ReportServer\bin* फ़ोल्डर में कॉपी करता है — SQL Server 2005 के लिए बिल्ड, या SQL Server 2008 और बाद के संस्करण तथा Power BI Report Server के लिए बिल्ड;
- छः रेंडरिंग एक्सटेंशन — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS और ASODP — को *rsreportserver.config* के `<Render>` तत्व में जोड़ता है;
- एक कोड समूह जोड़ता है जो असेंबली को *rssrvpolicy.config* में पूर्ण भरोसा देता है;
- प्रत्येक बदलित कॉन्फ़िगरेशन फ़ाइल की एक प्रति *.bak* फ़ाइलनाम के साथ सहेजता है।

[Install Manually](/slides/hi/reportingservices/install-manually/) इन परिवर्तनों को चरण‑दर‑चरण दिखाता है।

यदि कोई इंस्टेंस कॉन्फ़िगर नहीं किया जा सकता, तो इंस्टॉलर उसे संदेश में नाम देता है और विवरण *rserrors<date>.log* फ़ाइल में इंस्टॉल फ़ोल्डर में लिखता है। उस इंस्टेंस पर एक्सटेंशन को मैन्युअल रूप से इंस्टॉल करें।

## **इंस्टॉलेशन की जाँच**

वेब पोर्टल (SQL Server 2014 और पहले के संस्करण में Report Manager) में एक पेजिनेटेड रिपोर्ट खोलें और **Export** सूची खोलें। अब इसमें निम्न फ़ॉर्मेट शामिल हैं:
- PPT - Aspose.Slides के माध्यम से PowerPoint प्रस्तुति
- PPS - Aspose.Slides के माध्यम से PowerPoint स्लाइडशो
- PPTX - Aspose.Slides के माध्यम से PowerPoint 2007 प्रस्तुति
- PPSX - Aspose.Slides के माध्यम से PowerPoint 2007 स्लाइडशो
- ODP - Aspose.Slides के माध्यम से OpenDocument प्रस्तुति
- XPS - Aspose.Slides के माध्यम से

बिना लाइसेंस के, निर्यात की गई फ़ाइलों पर मूल्यांकन वाटरमार्क होता है; देखें [Licensing](/slides/hi/reportingservices/license-aspose-slides-for-reporting-services/).

## **कब मैन्युअल रूप से इंस्टॉल करें**

इसकी बजाय एक्सटेंशन को [manually](/slides/hi/reportingservices/install-manually/) मैन्युअल रूप से इंस्टॉल करें जब:
- इंस्टॉलर किसी इंस्टेंस को कॉन्फ़िगर नहीं कर सकता, उदाहरण के लिए सर्वर की सुरक्षा सेटिंग्स के कारण;
- अपग्रेड के बाद, आप केवल असेंबली बदलना चाहते हैं, पुराने संस्करण को अनइंस्टॉल कर नए इंस्टॉलर को चलाने के बजाय।

उत्पाद को अनइंस्टॉल करने से प्रत्येक इंस्टेंस से असेंबली और कॉन्फ़िगरेशन प्रविष्टियाँ हट जाती हैं।