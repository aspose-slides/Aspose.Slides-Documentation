---
title: API-begränsningar
type: docs
weight: 320
url: /sv/python-java/api-limitations/
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
- Python
- Java
- Aspose.Slides
description: "Lär dig om begränsningarna i Aspose.Slides för Python via Java: fast Application-, Creator- och Producer-metadata i PPTX- och PDF-filer."
---
## **Översikt**

När presentationer skapas eller exporteras med Aspose.Slides skrivs viss teknisk metadata till utdatafilen. Denna artikel förklarar begränsningarna relaterade till metadatafälten `Application`, `Creator` och `Producer` i PPTX- och PDF-filer.

## **Applikation och Producent**

När du skapar eller exporterar presentationer med Aspose.Slides för Python via Java skrivs viss teknisk metadata till filen. Två fält väcker ofta frågor:

**Application** identifierar det program som skapade eller senast sparade en **PPTX**-presentation. I Aspose.Slides för Python via Java är detta värde fast och visar bibliotekets leverantör snarare än ditt programnamn, även om du använder [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** identifierar renderingsmotorn som genererade den slutgiltiga filen vid export. I **PDF**-exporter använder metadata fälten **Creator** och **Producer**. Med Aspose.Slides för Python via Java är båda dessa fasta och speglar biblioteket och dess version.

**Vad som är begränsat**

Du kan inte åsidosätta dessa fält via API:et för formaten ovan. För **PPTX** skrivs Application‑egenskapen som "Aspose.Slides for Java". För **PDF** skrivs Creator‑ och Producer‑egenskaperna som "Aspose.Slides for Java x.x.x." Detta beteende är avsiktligt och gäller oavsett hur du laddar eller sparar filen, och oavsett vilka värden som tilldelas med [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **Vanliga frågor**

**Kan jag ersätta Application‑värdet i en PPTX‑fil med mitt programnamn?**

Nej. Värdet är fast, även om du använder [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Kan jag åsidosätta Creator‑ och Producer‑fälten i PDF‑exporter?**

Nej. Båda fälten är fasta och speglar biblioteket och dess version, oavsett hur du laddar eller sparar presentationen.