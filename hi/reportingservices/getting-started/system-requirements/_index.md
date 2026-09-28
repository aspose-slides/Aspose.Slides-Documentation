---
title: सिस्टम आवश्यकताएँ
type: docs
weight: 15
url: /hi/reportingservices/system-requirements/
keywords:
- सिस्टम आवश्यकताएँ
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "जाँचें कि Aspose.Slides for Reporting Services को स्थापित करने से पहले कौन‑से रिपोर्ट सर्वर, संस्करण और .NET Framework संस्करण की आवश्यकता है।"
---
## **समीक्षा**

Aspose.Slides for Reporting Services रिपोर्ट सर्वर के भीतर एक रेंडरिंग एक्सटेंशन के रूप में चलता है। यह पृष्ठ उन आवश्यकताओं की सूची देता है जो रिपोर्ट सर्वर मशीन को आपके द्वारा इसे [स्थापित](/slides/hi/reportingservices/installing-aspose-slides-for-reporting-services/) करने से पहले चाहिए। Microsoft PowerPoint और Microsoft Office आवश्यक नहीं हैं।

## **समर्थित रिपोर्ट सर्वर**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, for paginated (RDL) reports

Both 32-bit and 64-bit report servers are supported. SQL Server 2005 uses its own build of the extension; all later versions and Power BI Report Server use the same build. [मैन्युअल रूप से स्थापित करें](/slides/hi/reportingservices/install-manually/) shows which file to copy.

If your report server version is not in this list, ask on the [नि:शुल्क समर्थन मंच](https://forum.aspose.com/c/slides/hi/11) before you deploy.

## **रिपोर्ट सर्वर संस्करण**

SQL Server 2016 Reporting Services और बाद के संस्करणों और Power BI Report Server के लिए, Microsoft Enterprise, Standard, Developer और Evaluation संस्करणों में रेंडरिंग एक्सटेंशन को समर्थन देता है; Web और Express संस्करण इनका समर्थन नहीं करते। देखें [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). MSI इंस्टॉलर Express संस्करण के SQL Server 2016 और उससे पुराने संस्करणों को छोड़ देता है।

## **.NET Framework**

.NET Framework 3.5 को रिपोर्ट सर्वर मशीन पर स्थापित होना आवश्यक है। एक्सटेंशन की असेंबलियों को .NET Framework 2.0 रनटाइम के लिए बनाया गया है, और यदि .NET Framework 3.5 अनुपलब्ध है तो MSI इंस्टॉलर एक संदेश के साथ रुक जाता है। Windows Server पर, Add Roles and Features विज़ार्ड में **.NET Framework 3.5 Features** जोड़ें; देखें [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **अनुमतियां**

एक्सटेंशन को स्थापित करने से रिपोर्ट सर्वर फ़ोल्डर में फ़ाइलें बदलती हैं, इसलिए दोनों स्थापना मार्गों को स्थानीय प्रशासक अधिकारों की आवश्यकता होती है। यदि आप MSI इंस्टॉलर को इन अधिकारों के बिना चलाते हैं, तो यह स्वयं को प्रशासक विशेषाधिकारों के साथ पुनः शुरू करने का विकल्प देता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे रिपोर्ट सर्वर पर Microsoft PowerPoint की आवश्यकता है?**

नहीं। एक्सटेंशन स्वयं प्रस्तुतियों का निर्माण करता है; PowerPoint या Microsoft Office स्थापित होने की आवश्यकता नहीं है।

**क्या मैं Express संस्करण पर एक्सटेंशन स्थापित कर सकता हूँ?**

नहीं। Express संस्करणों में रेंडरिंग एक्सटेंशन समर्थित नहीं होते। MSI इंस्टॉलर SQL Server 2016 और उससे पहले के Express इंस्टेंस को छुपाता है; बाद के संस्करणों में, Express इंस्टेंस को चयनित न करें।

**एक्सटेंशन निर्यात सूची में कौन‑से फ़ॉर्मेट जोड़ता है?**

PPT, PPS, PPTX, PPSX, ODP और XPS। देखें [Supported File Formats](/slides/hi/reportingservices/supported-file-formats/).