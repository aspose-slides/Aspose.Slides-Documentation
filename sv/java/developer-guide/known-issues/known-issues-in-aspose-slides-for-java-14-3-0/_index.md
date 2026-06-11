---
title: Kända problem i Aspose.Slides för Java 14.3.0
type: docs
weight: 20
url: /sv/java/known-issues-in-aspose-slides-for-java-14-3-0/
keywords:
- kända problem
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska kända problem i Aspose.Slides för Java 14.3.0 för att säkerställa korrekt arbete med PowerPoint- och OpenDocument-filer och undvika överraskningar i dina presentationer."
---
Aspose.Slides for Java 14.3.0 (14.4.0) tillhandahåller en helt ny implementering av PPT-behandling. Det finns många förbättringar, partiell konvertering från PPTX till PPT. Men det finns vissa oimplementerade funktioner:

- Vissa former har fel geometri i serialiserade PPT-dokument (Call outs)
- Inte alla PPTX-textformateringsfunktioner stöds vid PPT-serialisering
- Information om textspråk och stavningsinställningar finns inte i serialiserade PPT-dokument
- Inte alla PPTX-temafunktioner stöds vid PPT-serialisering

**Det finns vissa skillnader jämfört med Aspose.Slides for Java 8.6.0:**

- Det finns kända problem med OLE/ActiveX-PPT-serialisering till PPT

**Det finns vissa skillnader jämfört med Aspose.Slides for .NET 14.3.0:**

- Stöd för utskrift av presentationer är för närvarande inte tillgängligt i Aspose.Slides for Java