---
title: API-begränsningar
type: docs
weight: 320
url: /sv/cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "Känn till begränsningarna i Aspose.Slides för C++: export sätter fast Application/Producer-metadata i PPT, PPTX, ODP och PDF—hjälper dig att planera integrationer utan överraskningar."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till utdatafilen. Den här artikeln förklarar begränsningarna relaterade till metadatafälten `Application`, `Creator` och `Producer` i PPTX- och PDF-filer.

## **Application och Producer**

När du skapar eller exporterar presentationer med Aspose.Slides för C++ skrivs viss teknisk metadata till filen. Två fält väcker ofta frågor:

**Application** identifierar programmet som skapade eller senast sparade en **PPTX**-presentation. I Aspose.Slides för C++ är detta värde fast och visar bibliotekets leverantör snarare än ditt app-namn, även om du använder [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/sv/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** identifierar renderingsmotorn som genererade den slutgiltiga filen under export. Vid **PDF**-export används metadatafälten **Creator** och **Producer**. Med Aspose.Slides för C++ är båda dessa fasta och speglar biblioteket och dess version.

## **Vad som är begränsat**

Du kan inte åsidosätta dessa fält via API-et för formaten ovan. För **PPTX** skrivs Application-egenskapen som "Aspose.Slides for C++". För **PDF** skrivs Creator- och Producer-egenskaperna som "Aspose.Slides for C++ x.x.x". Detta beteende är avsiktligt och gäller oavsett hur du laddar eller sparar filen, och oavsett värden som tilldelas med [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/sv/cpp/aspose.slides/documentproperties/set_nameofapplication/).