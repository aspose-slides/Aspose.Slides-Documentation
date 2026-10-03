---
title: Begränsningar för utdata-metadata
type: docs
weight: 320
url: /sv/java/api-limitations/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java skriver fast applikations-, skapare- och producentmetadata till sparade PPTX-, PDF- och ODP-filer, oavsett vilket applikationsnamn du anger."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till utdatafilen. Denna artikel förklarar begränsningarna relaterade till metadatafälten `Application`, `Creator`, `Producer` och generator i PPTX-, PDF- och ODP-filer.

## **Applikation och producent**

När du skapar eller exporterar presentationer med Aspose.Slides for Java skrivs viss teknisk metadata till filen. Två fält väcker ofta frågor:

**Application** identifierar programmet som skapade eller senast sparade en **PPTX**‑presentation. I Aspose.Slides for Java är detta värde fast och visar bibliotekets namn snarare än ditt programnamn, även om du använder [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifierar renderingsmotorn som genererade den slutliga filen vid export. Vid **PDF**‑export används metadatafälten **Creator** och **Producer**. Med Aspose.Slides for Java är båda dessa fasta och speglar biblioteket och dess version.

**Vad som är begränsat**

Du kan inte åsidosätta dessa fält via API‑et för formaten ovan. För **PPTX** skrivs Application‑egendomen som "Aspose.Slides for Java". För **PDF** skrivs Creator‑ och Producer‑egendomen som "Aspose.Slides for Java" följt av bibliotekets version. För **ODP** skrivs generator‑fältet som "Aspose.Slides for Java" följt av bibliotekets version. Detta beteende är avsiktligt och gäller oavsett hur du läser in eller sparar filen, och oavsett värden som tilldelats med [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Denna begränsning gäller inte för **PPT**‑filer: i en PPT‑fil sparas appl‑namnet som du ställer in med [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).