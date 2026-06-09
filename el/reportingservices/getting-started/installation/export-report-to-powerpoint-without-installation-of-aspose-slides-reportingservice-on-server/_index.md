---
title: Εξαγωγή αναφοράς σε PowerPoint χωρίς εγκατάσταση του Aspose.Slides.ReportingService στον διακομιστή
type: docs
weight: 120
url: /el/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 

Το Aspose.Slides for Reporting Service μπορεί να χρησιμοποιηθεί χωρίς εγκατάσταση σε διακομιστή. Αυτή η προσέγγιση είναι κατάλληλη όταν χρειάζεται να ενσωματώσετε την εξαγωγή σε PowerPoint στην εφαρμογή σας, αλλά η πρόσβαση στην υπηρεσία είναι περιορισμένη.

{{% /alert %}} {{% alert color="primary" %}} 

Η λύση Visual Studio που εικονογραφεί την προσέγγιση μπορεί να βρεθεί [εδώ](attachments/10289165/10453062.zip).

{{% /alert %}} 

Η διαδικασία απόδοσης αποτελείται από δύο μέρη:

1. Απόδοση της αναφοράς σε RPL χρησιμοποιώντας το Reporting Service Web Service. Δείτε περισσότερες πληροφορίες για το Reporting Service Web Service [εδώ](http://technet.microsoft.com/en-us/library/ms152787.aspx).
2. Απόδοση του RPL σε PowerPoint χρησιμοποιώντας το Aspose.Slides for Reporting Service για το ReportViewer. Η συναρμολόγηση βρίσκεται στο {Aspose.Slides for Reporting Services home directory}\bin\RV2010  

## **Πώς να υλοποιήσετε την εξαγωγή σε PowerPoint:**  
1) Δημιουργήστε το proxy της web υπηρεσίας (δείτε τις λεπτομέρειες [εδώ](http://technet.microsoft.com/en-us/library/ms155134.aspx)) και προσθέστε το στη λύση σας.

2) Προσθέστε μια αναφορά στο Aspose.Slides.ReportingServices.dll για το ReportViewer 2010.

3) Χρησιμοποιήστε αυτήν την κλάση για την ενσωμάτωση του proxy της web υπηρεσίας και του Aspose.Slides for Reporting Service

``` xml

 class PowerpointRenderer

{

/// <summary>

/// Λαμβάνει ή ορίζει το βασικό URL της υπηρεσίας XML Web που ζητά ο πελάτης.

/// </summary>

/// <value>

/// Το βασικό URL της υπηρεσίας XML Web που ζητά ο πελάτης. Η προεπιλογή είναι System.String.Empty.

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// Λαμβάνει ή ορίζει το όνομα χρήστη για το Reporting Service.

/// </summary>

/// <value>

/// Το όνομα χρήστη.

/// </value>

public string Username { get; set; }

/// <summary>

/// Λαμβάνει ή ορίζει τον κωδικό πρόσβασης για το Reporting Service.

/// </summary>

/// <value>

/// Ο κωδικός πρόσβασης.

/// </value>

public string Password { get; set; }

/// <summary>

/// Εξάγει την καθορισμένη αναφορά σε αρχείο.

/// </summary>

/// <param name="outputFileName">Όνομα του αρχείου εξόδου.</param>

/// <param name="reportPath">Διαδρομή της αναφοράς.</param>

/// <param name="format">Τύπος εξόδου της παρουσίασης.</param>

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

4) Τώρα μπορείτε να εξάγετε την αναφορά μέσω αυτού του κώδικα:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

Η διαδικασία εξαγωγής εδώ χρησιμοποιεί ήπια διαχωριστικά σελίδων παρόμοια με το Word ή το Excel, επομένως το αποτέλεσμα της ενδέχεται να διαφέρει από την Παρουσίαση που εξάχθηκε με την τυπική προσέγγιση.

{{% /alert %}}