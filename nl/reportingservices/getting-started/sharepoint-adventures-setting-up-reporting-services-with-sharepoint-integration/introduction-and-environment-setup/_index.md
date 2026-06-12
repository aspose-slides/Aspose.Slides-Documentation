---
title: Introductie en Omgevingsconfiguratie
type: docs
weight: 10
url: /nl/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}} 

Er zijn in het verleden vragen geweest over Aspose.Slides voor Reporting Services-integratie met SharePoint. In dit artikel richten we ons op SharePoint 2010. Er wordt aangenomen dat er al een SharePoint Farm-omgeving is opgezet. De voorbeelden die we in dit artikel volgen, gebruiken een volledige SharePoint Cloud, maar de stappen zijn vergelijkbaar voor een SharePoint Foundation Server. Voordat we verder gaan, laten we beginnen met enkele belangrijke documenten die je als referentie kunt gebruiken:

- [Overzicht van Reporting Services en SharePoint-technologie-integratie](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Reporting Services configureren voor SharePoint 2010-integratie](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Omgevingsconfiguratie**
De configuratie bestaat uit **4 servers**. Dat omvat een **Domain Controller**, een **SQL Server**, een **SharePoint Server** en een server voor **Reporting Services**. Je kunt ervoor kiezen om SharePoint en Reporting Services op dezelfde machine te draaien.