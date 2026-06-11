---
title: API-begränsningar
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
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig om begränsningarna i Aspose.Slides för Java: export sätter fast Application/Producer-metadata i PPT, PPTX, ODP och PDF—hjälper dig att planera integrationer utan överraskningar."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till utdatafilen. Denna artikel förklarar begränsningarna relaterade till metadatafälten `Application`, `Creator` och `Producer` i PPTX‑ och PDF‑filer.

## **Application och Producer**

När du skapar eller exporterar presentationer med Aspose.Slides för Java skrivs viss teknisk metadata till filen. Två fält väcker ofta frågor:

**Application** identifierar programmet som skapade eller senast sparade en **PPTX**‑presentation. I Aspose.Slides för Java är detta värde fast och visar bibliotekets leverantör snarare än ditt programnamn, även om du använder [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifierar renderingsmotorn som genererade den slutliga filen vid export. Vid **PDF**‑export använder metadata fälten **Creator** och **Producer**. Med Aspose.Slides för Java är båda dessa fasta och speglar biblioteket och dess version.

**Vad som är begränsat**

Du kan inte åsidosätta dessa fält via API‑et för formaten ovan. För **PPTX** skrivs Application‑egenskapen som "Aspose.Slides för Java". För **PDF** skrivs Creator‑ och Producer‑egenskaperna som "Aspose.Slides för Java x.x.x." Detta beteende är avsiktligt och gäller oavsett hur du laddar eller sparar filen, och oavsett vilka värden som tilldelas med [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).