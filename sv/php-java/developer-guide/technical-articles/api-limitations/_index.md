---
title: API-begränsningar
type: docs
weight: 320
url: /sv/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Känn till begränsningarna i Aspose.Slides för PHP: exporterar sätter fast metadata för Application/Producer i PPT, PPTX, ODP och PDF—hjälper dig att planera integrationer utan överraskningar."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till utdatafilen. Denna artikel förklarar begränsningarna relaterade till metadatafälten `Application`, `Creator` och `Producer` i PPTX- och PDF-filer.

## **Application och Producer**

När du skapar eller exporterar presentationer med Aspose.Slides for PHP via Java skrivs viss teknisk metadata till filen. Två fält väcker ofta frågor:

**Application** identifierar programmet som skapade eller senast sparade en **PPTX**‑presentation. I Aspose.Slides for PHP via Java är detta värde fast och visar biblioteksleverantören snarare än ditt app‑namn, även om du använder [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifierar renderingsmotorn som genererade den slutgiltiga filen vid export. Vid **PDF**‑export används metadatafälten **Creator** och **Producer**. Med Aspose.Slides for PHP via Java är båda dessa fasta och återspeglar biblioteket och dess version.

**Vad som är begränsat**

Du kan inte åsidosätta dessa fält via API:et för de ovanstående formaten. För **PPTX** skrivs Application‑egenskapen som "Aspose.Slides for PHP via Java". För **PDF** skrivs Creator‑ och Producer‑egenskaperna som "Aspose.Slides for PHP via Java x.x.x." Detta beteende är avsiktligt och gäller oavsett hur du laddar eller sparar filen, och oavsett vilka värden som tilldelas med [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/setnameofapplication/).