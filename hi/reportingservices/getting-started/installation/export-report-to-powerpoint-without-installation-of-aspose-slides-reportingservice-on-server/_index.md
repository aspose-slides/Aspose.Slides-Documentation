---
title: सर्वर पर Aspose.Slides.ReportingService की स्थापना किए बिना रिपोर्ट को Powerpoint में निर्यात करें
type: docs
weight: 120
url: /hi/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 
Aspose.Slides for Reporting Service को सर्वर पर इंस्टॉलेशन के बिना उपयोग किया जा सकता है। यह तरीका तब उपयुक्त है जब आपको अपने अनुप्रयोग में Powerpoint निर्यात को एकीकृत करने की आवश्यकता हो लेकिन सेवा तक पहुंच प्रतिबंधित हो।
{{% /alert %}} {{% alert color="primary" %}} 
इस दृष्टिकोण को दर्शाने वाला Visual Studio समाधान [यहाँ](attachments/10289165/10453062.zip) पाया जा सकता है।
{{% /alert %}} 

रेंडरिंग प्रक्रिया दो भागों में विभाजित होती है:

1. रिपोर्ट को Reporting Service Web Service का उपयोग करके RPL में रेंडर करें। Reporting Service Web Service के बारे में अधिक जानकारी [यहाँ](http://technet.microsoft.com/en-us/library/ms152787.aspx) मिल सकती है।
1. Aspose.Slides for Reporting service for ReportViewer का उपयोग करके RPL को Powerpoint में रेंडर करें। असेंबली का स्थान है {Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **PowerPoint निर्यात को कार्यान्वित करने का तरीका:**
 1) वेब सेवा प्रॉक्सी बनाएं (विवरण [यहाँ](http://technet.microsoft.com/en-us/library/ms155134.aspx)) और इसे अपने समाधान में जोड़ें.

 2) ReportViewer 2010 के लिए Aspose.Slides.ReportingServices.dll का संदर्भ जोड़ें.

 3) वेब सेवा प्रॉक्सी और Apose.Slides for Reporting Service को एकीकृत करने के लिए इस क्लास का उपयोग करें

``` xml

 class PowerpointRenderer

{

/// <summary>

/// क्लाइंट द्वारा अनुरोधित XML वेब सेवा का बेस URL प्राप्त करता है या सेट करता है।

/// </summary>

/// <value>

/// क्लाइंट द्वारा अनुरोधित XML वेब सेवा का बेस URL। डिफ़ॉल्ट रूप से यह System.String.Empty है।

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// रिपोर्टिंग सर्विस के लिए उपयोगकर्ता नाम प्राप्त करता है या सेट करता है।

/// </summary>

/// <value>

/// उपयोगकर्ता नाम।

/// </value>

public string Username { get; set; }

/// <summary>

/// रिपोर्टिंग सर्विस के लिए पासवर्ड प्राप्त करता है या सेट करता है।

/// </summary>

/// <value>

/// पासवर्ड।

/// </value>

public string Password { get; set; }

/// <summary>

/// निर्दिष्ट रिपोर्ट को फ़ाइल में रेंडर करता है।

/// </summary>

/// <param name="outputFileName">आउटपुट फ़ाइल का नाम।</param>

/// <param name="reportPath">रिपोर्ट पाथ।</param>

/// <param name="format">आउटपुट प्रस्तुति फ़ॉर्मेट।</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//start rendering process

//here we are choosing to export in PPT format and providing outputStream

renderer.StartRendering(format, false);

int page = 1;

//this cycle iterates through all pages of report

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//if rplStream is empty then we reached end of report

if (rplStream.Length == 0)

break;

//add report page as slide to the document

renderer.RenderPage(rplStream);

}

page++;

}

//call finish method to flush our newly created presentation to output stream

renderer.FinishRendering(pptSteam);

}

}

private MemoryStream CreateRplStream(int page, string reportPath)

{

ReportExecutionService _executionService = new ReportExecutionService();

_executionService.Url = ReportingServiceUrl + "/ReportExecution2005.asmx";

_executionService.Credentials = new System.Net.NetworkCredential(Username, Password, string.Empty);

string extension;

Warning[] warnings;

string[] streamIds;

string mimeType;

string encoding;

var executionInfo = _executionService.LoadReport(reportPath, null);

string deviceInfo = String.Format(

@"<DeviceInfo>

<StartPage>{0}</StartPage>

<EndPage>{0}</EndPage>

<SecondaryStreams>Embedded</SecondaryStreams>

</DeviceInfo>", page);

byte[] result = _executionService.Render("RPL", deviceInfo, out extension, out mimeType, out encoding, out warnings, out streamIds);

return new MemoryStream(result);

}

```


 4) अब आप इस कोड के माध्यम से रिपोर्ट निर्यात कर सकते हैं:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 
यह निर्यात प्रक्रिया यहाँ Word या Excel के समान सॉफ़्ट पेज ब्रेक का उपयोग करती है, इसलिए इसका परिणाम मानक विधि से निर्यात किए गए प्रस्तुतीकरण से अलग हो सकता है।
{{% /alert %}}