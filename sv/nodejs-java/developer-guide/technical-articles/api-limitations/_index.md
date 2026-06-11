---
title: API-begränsningar
type: docs
weight: 320
url: /sv/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Känn till begränsningarna i Aspose.Slides för Node.js: exporterar med fast Application/Producer-metadata i PPT, PPTX, ODP och PDF—hjälper dig att planera integrationer utan överraskningar."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till den resulterande filen. Den här artikeln förklarar begränsningarna relaterade till metadatafälten `Application`, `Creator` och `Producer` i PPTX‑ och PDF‑filer.

## **Application och Producer**

När du skapar eller exporterar presentationer med Aspose.Slides for Node.js via Java skrivs viss teknisk metadata till filen. Två fält väcker ofta frågor:

**Application** identifierar programmet som skapade eller senast sparade en **PPTX**‑presentation. I Aspose.Slides for Node.js via Java är detta värde fast och visar leverantören av biblioteket snarare än ditt app‑namn, även om du använder [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifierar renderingsmotorn som genererade den slutgiltiga filen vid export. Vid **PDF**‑export använder metadata fälten **Creator** och **Producer**. Med Aspose.Slides for Node.js via Java är båda dessa fasta och speglar biblioteket och dess version.

**Vad som är begränsat**

Du kan inte åsidosätta dessa fält genom API‑et för formaten ovan. För **PPTX** skrivs Application‑egenskapen som "Aspose.Slides for Node.js via Java". För **PDF** skrivs Creator‑ och Producer‑egenskaperna som "Aspose.Slides for Node.js via Java x.x.x." Detta beteende är avsiktligt och gäller oavsett hur du laddar eller sparar filen, och oavsett vilka värden som tilldelas med [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).