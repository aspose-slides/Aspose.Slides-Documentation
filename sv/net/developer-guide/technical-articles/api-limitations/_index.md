---
title: Begränsningar för utdata-metadata
type: docs
weight: 320
url: /sv/net/api-limitations/
keywords:
- API-begränsningar
- exportformat
- applikation
- producent
- dokumentegenskaper
- metadata
- generator
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET skriver fast applikations-, skapare- och producentmetadata till sparade PPTX-, PDF- och ODP-filer, oavsett vilket programnamn du anger."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till utdatafilen. Den här artikeln förklarar begränsningarna relaterade till metadatafälten `Application`, `Creator`, `Producer` och generator i PPTX-, PDF- och ODP-filer.

## **Applikation och Producent**

När du skapar eller exporterar presentationer med Aspose.Slides för .NET skrivs viss teknisk metadata in i filen. Två fält väcker ofta frågor:

**Application** identifierar programmet som skapade eller senast sparade en **PPTX**-presentation. I Aspose.Slides för .NET är detta värde fast och visar bibliotekets namn snarare än ditt programnamn, även om du ställer in [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/sv/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifierar renderingsmotorn som genererade den slutliga filen vid export. Vid **PDF**-exporter används metadatafälten **Creator** och **Producer**. Med Aspose.Slides för .NET är båda dessa fasta och återspeglar biblioteket och dess version.

**Vad som är begränsat**

Du kan inte åsidosätta dessa fält via API:et för formaten ovan. För **PPTX** skrivs Application‑egenskapen som "Aspose.Slides for .NET". För **PDF** skrivs Creator‑ och Producer‑egenskaperna som "Aspose.Slides for .NET" följt av bibliotekets version. För **ODP** skrivs generator‑fältet som "Aspose.Slides for .NET" följt av bibliotekets version. Detta beteende är avsiktligt och gäller oavsett hur du laddar eller sparar filen, och oavsett vilka värden som tilldelas [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/sv/net/aspose.slides/documentproperties/nameofapplication/).

Denna begränsning gäller inte **PPT**-filer: i en PPT‑fil sparas det programnamn du har angett i [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/sv/net/aspose.slides/documentproperties/nameofapplication/).