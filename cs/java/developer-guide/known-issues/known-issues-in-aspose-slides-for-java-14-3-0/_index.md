---
title: Známé problémy v Aspose.Slides pro Java 14.3.0
type: docs
weight: 20
url: /cs/java/known-issues-in-aspose-slides-for-java-14-3-0/
keywords:
- známý problém
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si známé problémy v Aspose.Slides pro Java 14.3.0, abyste zajistili přesnou práci s soubory PowerPoint a OpenDocument a předešli překvapením ve vašich prezentacích."
---
Aspose.Slides for Java 14.3.0 (14.4.0) poskytuje zcela novou implementaci zpracování PPT. Existuje mnoho vylepšení, částečná konverze PPTX na PPT. Avšak některé funkce nejsou implementovány:

- Některé tvary mají nesprávnou geometriku v serializovaných PPT dokumentech (Call outs)
- Ne všechny funkce formátování textu v PPTX jsou podporovány v serializaci do PPT
- Informace o jazyce textu a nastavení pravopisu nejsou v serializovaných PPT dokumentech přítomny
- Ne všechny funkce motivů PPTX jsou podporovány v serializaci do PPT

**Existují některé rozdíly ve srovnání s Aspose.Slides for Java 8.6.0:**

- Jsou známy problémy při serializaci OLE/ActiveX PPT do PPT

**Existují některé rozdíly ve srovnání s Aspose.Slides for .NET 14.3.0:**

- Podpora tisku prezentací je v současné době v Aspose.Slides for Java nedostupná