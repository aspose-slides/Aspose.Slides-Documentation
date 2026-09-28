---
title: हाथ से स्थापित करें
type: docs
weight: 30
url: /hi/reportingservices/install-manually/
keywords:
- मैन्युअल स्थापना
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "DLLs-only ZIP पैकेज से Aspose.Slides for Reporting Services को हाथ से स्थापित करें: कौन सा असेंबली कॉपी करना है, और rsreportserver.config तथा rssrvpolicy.config में क्या जोड़ना है।"
---
## **अवलोकन**

MSI इंस्टॉलर के बिना Aspose.Slides for Reporting Services को स्थापित करने के लिए ये चरणों का पालन करें, ZIP पैकेज *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* से, जो [download page](https://releases.aspose.com/slides/reportingservices/) पर उपलब्ध है। ये [MSI installer](/slides/hi/reportingservices/install-with-msi-installer/) के समान एक्सटेंशन रजिस्टर करते हैं। प्रत्येक रिपोर्ट सर्वर इंस्टेंस के लिए इन्हें दोहराएँ।

शुरू करने से पहले, [system requirements](/slides/hi/reportingservices/system-requirements/) देखें। आपको रिपोर्ट सर्वर पर स्थानीय प्रशासक अधिकारों की आवश्यकता होगी।

## **एसेंबली चुनें**

ZIP पैकेज में कई बिल्ड्स होते हैं। रिपोर्ट सर्वर पर ठीक एक *Aspose.Slides.ReportingServices.dll* कॉपी करें:

| ZIP पैकेज में फ़ाइल | उपयोग |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 और बाद के Reporting Services, तथा Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | रिपोर्ट सर्वर के लिए नहीं: वे एप्लिकेशन जो ReportViewer 2010 या 2012 कंट्रोल से एक्सपोर्ट करते हैं, देखें [Using Aspose.Slides with ReportViewer 2010 and 2012](/slides/hi/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | वैकल्पिक: समस्याग्रस्त रिपोर्टों के लिए रिपोर्ट को RPL फ़ॉर्मेट में सहेजता है, देखें [Exporting Reports to RPL Format](/slides/hi/reportingservices/exporting-reports-to-rpl-format/) |

## **रिपोर्ट सर्वर फ़ोल्डर खोजें**

नीचे दिए गए चरण रिपोर्ट सर्वर के *ReportServer* फ़ोल्डर को संदर्भित करते हैं, जिसमें *rsreportserver.config* और *rssrvpolicy.config* होते हैं। डिफ़ॉल्ट इंस्टॉलेशन में, यह है:

| रिपोर्ट सर्वर | डिफ़ॉल्ट *ReportServer* फ़ोल्डर |
| :- | :- |
| SQL Server 2017 और बाद के Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 और पहले के Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, जहाँ instance folder, उदाहरण के लिए, SQL Server 2016 के लिए `MSRS13.MSSQLSERVER` या SQL Server 2005 के लिए `MSSQL.x` है |

अधिक स्थानों के लिए, Microsoft के [RsReportServer.config configuration file](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file) लेख को देखें।

## **एक्सटेंशन स्थापित करें**

1. चुनी हुई असेंबली को *ReportServer* फ़ोल्डर के *bin* सबफ़ोल्डर में कॉपी करें।

   कॉपी की गई फ़ाइल पर स्पष्ट रूप से असाइन किए गए NTFS अधिकार नहीं होने चाहिए, अन्यथा रिपोर्ट सर्वर असेंबली लोड करते समय पहुँच से वंचित हो जाता है और नए निर्यात फ़ॉर्मेट दिखाई नहीं देते। फ़ाइल पर राइट‑क्लिक करें, **Properties** चुनें, और **Security** टैब में किसी भी स्पष्ट रूप से असाइन किए गए अधिकारों को हटाएँ, केवल विरासत में मिले अधिकार रखें। यदि **General** टैब में **Unblock** विकल्प दिखे, तो उसे चुनें।

2. *rsreportserver.config* की एक प्रति सहेजें, फिर फ़ाइल को टेक्स्ट एडिटर में खोलें। `<Render>` तत्व के भीतर निम्न प्रविष्टियाँ जोड़ें:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   प्रत्येक प्रविष्टि एक निर्यात फ़ॉर्मेट रजिस्टर करती है; `Name` को रेंडरिंग एक्सटेंशन में अद्वितीय होना चाहिए। MSI इंस्टॉलर समान छह नाम और प्रकार रजिस्टर करता है। यदि आप किसी फ़ॉर्मेट को निर्यात सूची में नहीं चाहते तो उसे छोड़ दें।

3. *rssrvpolicy.config* की एक प्रति सहेजें, फिर फ़ाइल को टेक्स्ट एडिटर में खोलें। उस कोड ग्रुप को खोजें जिसका `Description` है "This code group grants MyComputer code Execution permission." और इस कोड ग्रुप को उसके अंतिम चाइल्ड के रूप में जोड़ें:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` Aspose.Slides.ReportingServices असेंबली की पब्लिक कुंजी है। इसे एक पंक्ति में रखें।

4. दोनों फ़ाइलें सहेजें। जब फ़ाइलें सहेजी जाती हैं तो रिपोर्ट सर्वर अपनी कॉन्फ़िगरेशन फ़ाइलें फिर से पढ़ता है। यदि किसी फ़ाइल में खराब XML है, तो रिपोर्ट सर्वर उसे अनदेखा कर देता है या शुरू नहीं होता, इसलिए यदि कुछ गड़बड़ हो तो अपनी प्रतिलिपि को पुनर्स्थापित करें।

## **स्थापना की जाँच करें**

वेब पोर्टल (SQL Server 2014 और पहले के लिए Report Manager) में एक पेजिनेटेड रिपोर्ट खोलें और **Export** सूची खोलें। अब इसमें ये फ़ॉर्मेट शामिल हैं:

- PPT - Aspose.Slides के माध्यम से PowerPoint प्रस्तुति
- PPS - Aspose.Slides के माध्यम से PowerPoint स्लाइडशो
- PPTX - Aspose.Slides के माध्यम से PowerPoint 2007 प्रस्तुति
- PPSX - Aspose.Slides के माध्यम से PowerPoint 2007 स्लाइडशो
- ODP - Aspose.Slides के माध्यम से OpenDocument प्रस्तुति
- XPS - Aspose.Slides के माध्यम से

इनमें से किसी एक को चुनें ताकि रिपोर्ट निर्यात हो सके। फ़ाइल अपने फ़ॉर्मेट से संबद्ध एप्लिकेशन में खुल जाएगी।

![Aspose.Slides for Reporting Services द्वारा PowerPoint में निर्यात की गई रिपोर्ट](install-manually_2.png)

यदि फ़ॉर्मेट दिखाई नहीं देते, तो कॉपी की गई असेंबली के NTFS अधिकारों की जाँच करें। बिना लाइसेंस के, निर्यात फ़ाइलों में मूल्यांकन वाटरमार्क होता है; देखें [Licensing](/slides/hi/reportingservices/license-aspose-slides-for-reporting-services/).