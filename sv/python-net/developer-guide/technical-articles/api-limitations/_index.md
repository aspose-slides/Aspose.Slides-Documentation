---
title: API-begränsningar
type: docs
weight: 210
url: /sv/python-net/api-limitations/
keywords:
- API-begränsningar
- exportformat
- program
- producent
- dokumentegenskaper
- metadata
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Känn till begränsningarna i Aspose.Slides for Python: exporterar fastställer fast Application/Producer-metadata i PPT, PPTX, ODP och PDF—hjälper dig att planera integrationer utan överraskningar."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till utdatafilen. Denna artikel förklarar begränsningarna för metadata‑fälten `Application`, `Creator` och `Producer` i PPTX‑ och PDF‑filer.

## **Program och producent**

När du skapar eller exporterar presentationer med Aspose.Slides for Python via .NET skrivs viss teknisk metadata till filen. Två fält väcker ofta frågor:

**Application** identifierar programmet som skapade eller senast sparade en **PPTX**‑presentation. I Aspose.Slides for Python via .NET är detta värde fast och visar bibliotekets leverantör snarare än ditt app‑namn, även om du sätter [DocumentProperties.name_of_application](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** identifierar renderingsmotorn som genererade den slutgiltiga filen vid export. Vid **PDF**‑export använder metadata fälten **Creator** och **Producer**. Med Aspose.Slides for Python via .NET är båda dessa fasta och återspeglar biblioteket och dess version.

**Vad som är begränsat**

Du kan inte åsidosätta dessa fält via API‑et för de ovanstående formaten. För **PPTX** skrivs Application‑egenskapen som "Aspose.Slides for Python via .NET". För **PDF** skrivs Creator‑ och Producer‑egenskaperna som "Aspose.Slides for Python via .NET x.x.x". Detta beteende är avsiktligt och gäller oavsett hur du laddar eller sparar filen, och oavsett vilka värden som tilldelas [DocumentProperties.name_of_application](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/name_of_application/).