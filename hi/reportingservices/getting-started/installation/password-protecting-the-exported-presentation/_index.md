---
title: निर्यातित प्रस्तुति की पासवर्ड सुरक्षा
type: docs
weight: 90
url: /hi/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

प्रेजेंटेशन को पासवर्ड से सुरक्षित करने से अनधिकृत उपयोग और पहुंच रोकी जा सकती है। पासवर्ड सुरक्षा उपयोगी होती है जब आप ऐसे रिपोर्ट बना रहे हों जिनमें संवेदनशील डेटा या विवरण हो, जिन्हें केवल आपके संगठन के कुछ लोग ही देख सकते हैं।

यह लेख दर्शाता है कि कैसे अपने रिपोर्टिंग सर्विसेज या विजुअल स्टूडियो वातावरण को अद्यतन करके आप प्रेजेंटेशन को पासवर्ड सुरक्षा के साथ सहेज सकते हैं।

{{% /alert %}} 
## **रिपोर्टिंग सर्विसेज वातावरण में निर्यातित प्रेजेंटेशन्स में पासवर्ड सुरक्षा जोड़ना**
इन परिवर्तन들을 लागू करने के लिए, आपको उन फ़ाइलों को संशोधित करना होगा जो Microsoft SQL Server Reporting Services स्थापित होने वाले निर्देशिका में स्थित हैं।
### **चरण 1. रिपोर्टिंग सर्वर स्थापित निर्देशिका ढूँढ़ें।**
Microsoft SQL Server की रूट निर्देशिका आमतौर पर C:\Program Files\Microsoft SQL Server होती है।

{{% alert color="primary" %}} 

x64 बिट सिस्टम के लिए SQL Server का x86 इंस्टेंस C:\Program Files (x86)\Microsoft SQL Server\ में स्थापित होता है।

{{% /alert %}} 

Microsoft SQL Server 2005 और 2008: मशीन पर कई Microsoft SQL Server इंस्टेंस कॉन्फ़िगर हो सकते हैं। प्रत्येक एक अलग MSSQL.x उपनिर्देशिका में स्थित होता है, जैसे MSSQL.1, MSSQL.2 आदि। अगले चरणों को आगे बढ़ाने से पहले सही C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer निर्देशिका ढूँढ़ें।

नीचे उपयोग किए गए सभी पथ Microsoft SQL Server Reporting Services स्थापित निर्देशिका को <Instance> के रूप में संदर्भित करते हैं।
### **चरण 2. निर्यातित प्रेजेंटेशन्स में पासवर्ड जोड़ने के लिए कोड जोड़ें**
मौजूदा Aspose.Slides for Reporting Services रेंडरिंग एक्सटेंशन को **rsreportserver.config** फ़ाइल में बदलें। ऐसा करने के लिए, C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config फ़ाइल खोलें। 

नीचे तुरंत सूचीबद्ध रेंडरिंग विकल्पों को खोजें और उन्हें उसके बाद आने वाले खण्ड में दिए गए कोड से बदलें।
#### **Aspose.Slides for Reporting Service रेंडरिंग विकल्प खोजें**
**<Render>**

``` xml

   ...

  <!--यहाँ से शुरू करें।>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--यहाँ समाप्त करें।>


</Render>



```
#### **प्रतिस्थापन कोड**
**<Render>**

``` xml

   ...

  <!--यहाँ से शुरू करें।-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--यहाँ समाप्त करें.-->


</Render>



```
### **विज़ुअल स्टूडियो में निर्यातित प्रेजेंटेशन्स के लिए पासवर्ड सुरक्षा जोड़ना**
इन परिवर्तनों को लागू करने के लिए, आपको उस फ़ाइल को संशोधित करना होगा जहाँ Microsoft Visual Studio Report Designer स्थापित है।
### **चरण 1. विज़ुअल स्टूडियो निर्देशिका खोलें।**
- Visual Studio 2005 Report Designer के साथ एकीकृत करने के लिए, C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies निर्देशिका खोलें।
- Visual Studio 2008 Report Designer के साथ एकीकृत करने के लिए, C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies निर्देशिका खोलें।
### **चरण 2. निर्यातित प्रेजेंटेशन्स में पासवर्ड जोड़ने के लिए कोड जोड़ें।**
मौजूदा Aspose.Slides for Reporting Services रेंडरिंग एक्सटेंशन को **rsreportserver.config** फ़ाइल में बदलें। ऐसा करने के लिए, C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config फ़ाइल खोलें (जहाँ **<Version>** Visual Studio 2005 के लिए “8” या Visual Studio 2008 के लिए “9.0” है) और **<Render>** तत्व में ये पंक्तियाँ जोड़ें। फिर उन्हें अगले कोड खण्ड में दिए गए कोड से बदलें।
#### **Aspose.Slides for Reporting Service रेंडरिंग विकल्प खोजें**
**<Render>**

``` xml

   ...

  <!--यहाँ से शुरू करें।>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--यहाँ समाप्त करें.-->


</Render>



```
#### **प्रतिस्थापन कोड**
**<Render>**

``` xml

   ...

  <!--यहाँ से शुरू करें.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>
  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>
  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>
  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>
  <!--यहाँ समाप्त करें.-->


</Render>



```