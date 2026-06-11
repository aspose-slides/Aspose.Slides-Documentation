---
title: Installera med MSI-installerare
type: docs
weight: 20
url: /sv/reportingservices/install-with-msi-installer/
---
## **Installation**
Du kan installera Aspose.Slides for Reporting Services via en MSI-installerare.

{{% alert title="Note" color="warning" %}}

**Aspose.Slides for Reporting Services** kräver att **.NET Framework 3.5** är installerat på värddatorn.

{{% /alert %}}

Kör ***Aspose.Slides.ReportingServices.msi*** och följ stegen som erbjuds av installeraren.

Installeraren kopierar samlingen och andra filer till den angivna katalogen och installerar produkten på standardinstansen av Reporting Services. Du behöver inte kopiera eller ändra några filer manuellt om du inte vill lägga till speciella konfigurationsparametrar.

Installation med MSI-installeraren är det bästa alternativet i de flesta fall. Du kan dock vilja installera produkten manuellt i vissa situationer:

- Automatisk installation misslyckas på grund av säkerhetsproblem eller andra orsaker.
- the product has to be installed on a named (not default) instance of Reporting Services or on multiple instances.
- efter en uppgradering till den senaste versionen vill du bara ersätta samlingen istället för att avinstallera den gamla versionen och installera den nya med MSI-installeraren. **Obs** att du i så fall kan få kvar andra filer.