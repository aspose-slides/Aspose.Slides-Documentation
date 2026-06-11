---
title: API-begränsningar
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
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Känn till begränsningarna i Aspose.Slides för .NET: export sätter fast Application/Producer-metadata i PPT, PPTX, ODP och PDF—hjälper dig att planera integrationer utan överraskningar."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till utdatafilen. Denna artikel förklarar begränsningarna relaterade till metadatafältens `Application`, `Creator` och `Producer` i PPTX‑ och PDF‑filer.

## **Applikation och producent**

När du skapar eller exporterar presentationer med Aspose.Slides för .NET skrivs viss teknisk metadata till filen. Två fält väcker ofta frågor:

**Application** identifierar programmet som skapade eller senast sparade en **PPTX**‑presentation. I Aspose.Slides för .NET är detta värde fast och visar bibliotekets leverantör snarare än ditt app‑namn, även om du sätter [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/sv/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifierar renderingsmotorn som genererade den slutgiltiga filen vid export. Vid **PDF**‑export använder metadata fälten **Creator** och **Producer**. Med Aspose.Slides för .NET är båda dessa fasta och speglar biblioteket och dess version.

**Vad som är begränsat**

Du kan inte åsidosätta dessa fält via API‑et för formaten ovan. För **PPTX** skrivs Application‑egenskapen som "Aspose.Slides for .NET". För **PDF** skrivs Creator‑ och Producer‑egenskaperna som "Aspose.Slides for .NET x.x.x". Detta beteende är avsiktligt och gäller oavsett hur du laddar eller sparar filen, och oavsett vilka värden som tilldelas [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/sv/net/aspose.slides/documentproperties/nameofapplication/).