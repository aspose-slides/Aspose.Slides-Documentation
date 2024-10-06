---
title: Exporter le rapport vers Powerpoint sans installation d'Aspose.Slides.ReportingService sur le serveur
type: docs
weight: 120
url: /reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---

{{% alert color="primary" %}} 

Aspose.Slides pour Reporting Service peut être utilisé sans installation sur un serveur. Cette approche est adaptée lorsque vous devez intégrer l'exportation vers Powerpoint dans votre application mais que l'accès au service est restreint.

{{% /alert %}} {{% alert color="primary" %}} 

La solution Visual Studio qui illustre l'approche se trouve [ici](attachments/10289165/10453062.zip).

{{% /alert %}} 

Le processus de rendu comprend deux parties : 

1. Rendre le rapport en RPL en utilisant le service Web de Reporting Service. Voir plus d'informations sur le service Web de Reporting Service [ici](http://technet.microsoft.com/en-us/library/ms152787.aspx).
2. Rendre le RPL en Powerpoint en utilisant Aspose.Slides pour le service de Reporting pour ReportViewer. L'assemblage est situé dans ﻿﻿﻿﻿﻿{Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **Comment implémenter l’exportation vers PowerPoint :**
 1) Créez le proxy de service Web (voir les détails [ici](http://technet.microsoft.com/en-us/library/ms155134.aspx)) et ajoutez-le à votre solution.

 2) Ajoutez une référence à Aspose.Slides.ReportingServices.dll pour ReportViewer 2010.

 3) Utilisez cette classe pour intégrer le proxy de service Web et Apose.Slides pour Reporting Service

``` xml

 class PowerpointRenderer

{

/// <summary>

/// Obtient ou définit l'URL de base du service Web XML que le client demande.

/// </summary>

/// <value>

/// L'URL de base du service Web XML que le client demande. La valeur par défaut est System.String.Empty.

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// Obtient ou définit le nom d'utilisateur pour le service de Reporting.

/// </summary>

/// <value>

/// Le nom d'utilisateur.

/// </value>

public string Username { get; set; }

/// <summary>

/// Obtient ou définit le mot de passe pour le service de Reporting.

/// </summary>

/// <value>

/// Le mot de passe.

/// </value>

public string Password { get; set; }

/// <summary>

/// Rendu le rapport spécifié dans un fichier.

/// </summary>

/// <param name="outputFileName">Nom du fichier de sortie.</param>

/// <param name="reportPath">Le chemin du rapport.</param>

/// <param name="format">Le format de présentation de sortie.</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//démarrer le processus de rendu

//ici nous choisissons d'exporter au format PPT et de fournir outputStream

renderer.StartRendering(format, false);

int page = 1;

//ce cycle parcourt toutes les pages du rapport

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//si rplStream est vide alors nous avons atteint la fin du rapport

if (rplStream.Length == 0)

break;

//ajouter la page du rapport comme diapositive au document

renderer.RenderPage(rplStream);

}

page++;

}

//appeler la méthode finish pour vider notre nouvelle présentation créée dans le flux de sortie

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

 4) Maintenant, vous pouvez exporter le rapport à travers ce code:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Nom du Serveur>/Reportserver";

powerpointRenderer.Username = "Nom d'utilisateur";

powerpointRenderer.Password = "mot de passe";

powerpointRenderer.Render("test.ppt", "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

Le processus d'exportation ici utilise des sauts de page souples similaires à Word ou Excel, donc son résultat peut différer de la Présentation qui a été exportée en utilisant l'approche standard.

{{% /alert %}}