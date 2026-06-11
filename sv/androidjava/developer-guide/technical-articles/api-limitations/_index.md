---
title: API-begränsningar
type: docs
weight: 320
url: /sv/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "Känn till begränsningarna i Aspose.Slides för Android: exporteringar sätter fast Application/Producer-metadata i PPT, PPTX, ODP och PDF - hjälper dig att planera integrationer utan överraskningar."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till utdatafilen. Den här artikeln förklarar begränsningarna för metadatafälten `Application`, `Creator` och `Producer` i PPTX‑ och PDF‑filer.

## **Application och Producer**

När du skapar eller exporterar presentationer med Aspose.Slides for Android via Java skrivs viss teknisk metadata till filen. Två fält väcker ofta frågor:

**Application** identifierar programmet som skapade eller senast sparade en **PPTX**‑presentation. I Aspose.Slides for Android via Java är detta värde fast och visar bibliotekets leverantör snarare än ditt app‑namn, även om du använder [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifierar renderingsmotorn som genererade den slutliga filen under export. Vid **PDF**‑export används metadatafält **Creator** och **Producer**. Med Aspose.Slides for Android via Java är båda dessa fasta och speglar biblioteket och dess version.

**Vad som är begränsat**

Du kan inte skriva över dessa fält via API:et för formaten ovan. För **PPTX** skrivs Application‑egenskapen som "Aspose.Slides for Android via Java". För **PDF** skrivs Creator‑ och Producer‑egenskaperna som "Aspose.Slides for Android via Java x.x.x." Detta beteende är avsiktligt och gäller oavsett hur du läser in eller sparar filen, och oavsett värden som tilldelas med [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).